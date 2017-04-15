using System;

namespace JService.SocketService.Server
{
    public class AsyncSocketInvokeElement
    {
        protected AsyncSocketServer asyncSocketServer;
        protected AsyncSocketUserToken asyncSocketUserToken;
        public AsyncSocketUserToken AsyncSocketUserToken { get { return asyncSocketUserToken; } }

        //协议解析器
        protected IncomingDataParser incomingDataParser;
        protected OutgoingDataAssembler outgoingDataAssembler;

        //接收异步事件返回的数据，用于对数据进行缓存和分包
        public virtual bool ProcessReceive(byte[] buffer, int offset, int count)
        {
            //m_activeDT = DateTime.UtcNow;
            //DynamicBufferManager receiveBuffer = asyncSocketUserToken.ReceiveBuffer;

            //receiveBuffer.WriteBuffer(buffer, offset, count);
            //bool result = true;
            //while (receiveBuffer.DataCount > sizeof(int))
            //{
            //    //按照长度分包
            //    int packetLength = BitConverter.ToInt32(receiveBuffer.Buffer, 0); //获取包长度
            //    if (NetByteOrder)
            //        packetLength = System.Net.IPAddress.NetworkToHostOrder(packetLength); //把网络字节顺序转为本地字节顺序


            //    if ((packetLength > 10 * 1024 * 1024) | (receiveBuffer.DataCount > 10 * 1024 * 1024)) //最大Buffer异常保护
            //        return false;

            //    if ((receiveBuffer.DataCount - sizeof(int)) >= packetLength) //收到的数据达到包长度
            //    {
            //        result = ProcessPacket(receiveBuffer.Buffer, sizeof(int), packetLength);
            //        if (result)
            //            receiveBuffer.Clear(packetLength + sizeof(int)); //从缓存中清理
            //        else
            //            return result;
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}
            return true;
        }

        internal bool SendCompleted()
        {
            throw new NotImplementedException();
        }
    }
}