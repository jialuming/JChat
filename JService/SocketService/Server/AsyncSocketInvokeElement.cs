using JService.SocketService.AsyncSocketCore;
using System;
using System.Text;

namespace JService.SocketService.Server
{
    public class AsyncSocketInvokeElement
    {
        protected AsyncSocketServer asyncSocketServer;
        protected AsyncSocketUserToken asyncSocketUserToken;
        public AsyncSocketUserToken AsyncSocketUserToken { get { return asyncSocketUserToken; } }

        private bool netByteOrder;
        public bool NetByteOrder { get { return netByteOrder; } set { netByteOrder = value; } } //长度是否使用网络字节顺序

        protected IncomingDataParser incomingDataParser;   //协议解析器
        protected OutgoingDataAssembler outgoingDataAssembler;//协议组装器

        protected bool sendAsync; //标识是否有发送异步事件

        protected DateTime connectDT;
        public DateTime ConnectDT { get { return connectDT; } }
        protected DateTime activeDT;
        public DateTime ActiveDT { get { return activeDT; } }

        public AsyncSocketInvokeElement(AsyncSocketServer asyncSocketServer, AsyncSocketUserToken asyncSocketUserToken)
        {
            this.asyncSocketServer = asyncSocketServer;
            this.asyncSocketUserToken = asyncSocketUserToken;

            netByteOrder = false;

            incomingDataParser = new IncomingDataParser();
            outgoingDataAssembler = new OutgoingDataAssembler();

            sendAsync = false;

            connectDT = DateTime.UtcNow;
            activeDT = DateTime.UtcNow;
        }
        public virtual void Close()
        {
        }
        //接收异步事件返回的数据，用于对数据进行缓存和分包
        public virtual bool ProcessReceive(byte[] buffer, int offset, int count)
        {
            activeDT = DateTime.UtcNow;
            DynamicBufferManager receiveBuffer = asyncSocketUserToken.ReceiveBuffer;

            receiveBuffer.WriteBuffer(buffer, offset, count);
            bool result = true;
            while (receiveBuffer.DataCount > sizeof(int))
            {
                //按照长度分包
                int packetLength = BitConverter.ToInt32(receiveBuffer.Buffer, 0); //获取包长度
                if (NetByteOrder)
                    packetLength = System.Net.IPAddress.NetworkToHostOrder(packetLength); //把网络字节顺序转为本地字节顺序


                if ((packetLength > 10 * 1024 * 1024) | (receiveBuffer.DataCount > 10 * 1024 * 1024)) //最大Buffer异常保护
                    return false;
                Console.WriteLine(Encoding.UTF8.GetString(buffer));
                if ((receiveBuffer.DataCount - sizeof(int)) >= packetLength) //收到的数据达到包长度
                {
                    result = ProcessPacket(receiveBuffer.Buffer, sizeof(int), packetLength);
                    if (result)
                        receiveBuffer.Clear(packetLength + sizeof(int)); //从缓存中清理
                    else
                        return result;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        //处理分完包后的数据，把命令和数据分开，并对命令进行解析
        public virtual bool ProcessPacket(byte[] buffer, int offset, int count)
        {
            if (count < sizeof(int))
                return false;
            int commandLen = BitConverter.ToInt32(buffer, offset); //取出命令长度
            string tmpStr = Encoding.UTF8.GetString(buffer, offset + sizeof(int), commandLen);
            if (!incomingDataParser.DecodeProtocolText(tmpStr)) //解析命令
                return false;

            return ProcessCommand(buffer, offset + sizeof(int) + commandLen, count - sizeof(int) - commandLen); //处理命令
        }
        public virtual bool ProcessCommand(byte[] buffer, int offset, int count) //处理具体命令，子类从这个方法继承，buffer是收到的数据
        {
            return true;
        }
        public virtual bool SendCompleted()
        {
            activeDT = DateTime.UtcNow;
            sendAsync = false;
            AsyncSendBufferManager asyncSendBufferManager = asyncSocketUserToken.SendBuffer;
            asyncSendBufferManager.ClearFirstPacket(); //清除已发送的包
            int offset = 0;
            int count = 0;
            if (asyncSendBufferManager.GetFirstPacket(ref offset, ref count))
            {
                sendAsync = true;
                return asyncSocketServer.SendAsyncEvent(asyncSocketUserToken.Socket, asyncSocketUserToken.SendEventArgs,
                    asyncSendBufferManager.DynamicBufferManager.Buffer, offset, count);
            }
            else
                return SendCallback();
        }
        //发送回调函数，用于连续下发数据
        public virtual bool SendCallback()
        {
            return true;
        }

        public bool DoSendResult()
        {
            string commandText =outgoingDataAssembler.GetProtocolText();
            byte[] bufferUTF8 = Encoding.UTF8.GetBytes(commandText);
            int totalLength = sizeof(int) + bufferUTF8.Length; //获取总大小
            AsyncSendBufferManager asyncSendBufferManager = asyncSocketUserToken.SendBuffer;
            asyncSendBufferManager.StartPacket();
            asyncSendBufferManager.DynamicBufferManager.WriteInt(totalLength, false); //写入总大小
            asyncSendBufferManager.DynamicBufferManager.WriteInt(bufferUTF8.Length, false); //写入命令大小
            asyncSendBufferManager.DynamicBufferManager.WriteBuffer(bufferUTF8); //写入命令内容
            asyncSendBufferManager.EndPacket();

            bool result = true;
            if (!sendAsync)
            {
                int packetOffset = 0;
                int packetCount = 0;
                if (asyncSendBufferManager.GetFirstPacket(ref packetOffset, ref packetCount))
                {
                    sendAsync = true;
                    result = asyncSocketServer.SendAsyncEvent(asyncSocketUserToken.Socket,asyncSocketUserToken.SendEventArgs,
                        asyncSendBufferManager.DynamicBufferManager.Buffer, packetOffset, packetCount);
                }
            }
            return result;
        }

        public bool DoSendResult(byte[] buffer, int offset, int count)
        {
            string commandText = outgoingDataAssembler.GetProtocolText();
            byte[] bufferUTF8 = Encoding.UTF8.GetBytes(commandText);
            int totalLength = sizeof(int) + bufferUTF8.Length + count; //获取总大小
            AsyncSendBufferManager asyncSendBufferManager = asyncSocketUserToken.SendBuffer;
            asyncSendBufferManager.StartPacket();
            asyncSendBufferManager.DynamicBufferManager.WriteInt(totalLength, false); //写入总大小
            asyncSendBufferManager.DynamicBufferManager.WriteInt(bufferUTF8.Length, false); //写入命令大小
            asyncSendBufferManager.DynamicBufferManager.WriteBuffer(bufferUTF8); //写入命令内容
            asyncSendBufferManager.DynamicBufferManager.WriteBuffer(buffer, offset, count); //写入二进制数据
            asyncSendBufferManager.EndPacket();

            bool result = true;
            if (!sendAsync)
            {
                int packetOffset = 0;
                int packetCount = 0;
                if (asyncSendBufferManager.GetFirstPacket(ref packetOffset, ref packetCount))
                {
                    sendAsync = true;
                    result = asyncSocketServer.SendAsyncEvent(asyncSocketUserToken.Socket, asyncSocketUserToken.SendEventArgs,
                        asyncSendBufferManager.DynamicBufferManager.Buffer, packetOffset, packetCount);
                }
            }
            return result;
        }

        public bool DoSendBuffer(byte[] buffer, int offset, int count) //不是按包格式下发一个内存块，用于日志这类下发协议
        {
            AsyncSendBufferManager asyncSendBufferManager = asyncSocketUserToken.SendBuffer;
            asyncSendBufferManager.StartPacket();
            asyncSendBufferManager.DynamicBufferManager.WriteBuffer(buffer, offset, count);
            asyncSendBufferManager.EndPacket();

            bool result = true;
            if (!sendAsync)
            {
                int packetOffset = 0;
                int packetCount = 0;
                if (asyncSendBufferManager.GetFirstPacket(ref packetOffset, ref packetCount))
                {
                    sendAsync = true;
                    result = asyncSocketServer.SendAsyncEvent(asyncSocketUserToken.Socket, asyncSocketUserToken.SendEventArgs,
                        asyncSendBufferManager.DynamicBufferManager.Buffer, packetOffset, packetCount);
                }
            }
            return result;
        }
    }
}