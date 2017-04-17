using JService.SocketService.AsyncSocketCore;
using JService.SocketService.AsyncSocketProtocolCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JService.SocketService.Client
{
    public class AsyncSocketServer
    {
        protected TcpClient tcpClient;
        protected string host;
        protected int port;
        protected ProtocolFlag protocolFlag;
        protected IncomingDataParser incomingDataParser;   //协议解析器
        protected DynamicBufferManager recvBuffer; //接收数据的缓存
        protected OutgoingDataAssembler outgoingDataAssembler;//协议组装器
        protected DynamicBufferManager sendBuffer; //发送数据的缓存，统一写到内存中，调用一次发送

        protected int SocketTimeOutMS { get { return tcpClient.SendTimeout; } set { tcpClient.SendTimeout = value; tcpClient.ReceiveTimeout = value; } }
        public bool NetByteOrder { get; set; }

        public AsyncSocketServer()
        {
            tcpClient = new TcpClient();
            tcpClient.Client.Blocking = true; //使用阻塞模式，即同步模式
            protocolFlag = ProtocolFlag.None;
            SocketTimeOutMS = ProtocolConst.SocketTimeOutMS;
            outgoingDataAssembler = new OutgoingDataAssembler();
            recvBuffer = new DynamicBufferManager(ProtocolConst.ReceiveBufferSize);
            incomingDataParser = new IncomingDataParser();
            sendBuffer = new DynamicBufferManager(ProtocolConst.ReceiveBufferSize);
        }

        public void Connect(string host, int port)
        {
            this.host = host;
            this.port = port;
            tcpClient.Connect(host, port);
            byte[] socketFlag = new byte[1];
            socketFlag[0] = (byte)protocolFlag;
            tcpClient.Client.Send(socketFlag, SocketFlags.None);
        }

        public void Disconnecrt()
        {
            tcpClient.Close();
            //tcpClient = new TcpClient();
        }

        public void SendCommand()
        {
            string commandText = outgoingDataAssembler.GetProtocolText();
            byte[] bufferUTF8 = Encoding.UTF8.GetBytes(commandText);
            int totalLength = sizeof(int) + bufferUTF8.Length; //获取总大小
            sendBuffer.Clear();
            sendBuffer.WriteInt(totalLength, false); //写入总大小
            sendBuffer.WriteInt(bufferUTF8.Length, false); //写入命令大小
            sendBuffer.WriteBuffer(bufferUTF8); //写入命令内容
            tcpClient.Client.Send(sendBuffer.Buffer, 0, sendBuffer.DataCount, SocketFlags.None); //使用阻塞模式，Socket会一次发送完所有数据后才返回
        }

        public void SendCommand(byte[] buffer, int offset, int count)
        {
            string commandText = outgoingDataAssembler.GetProtocolText();
            byte[] bufferUTF8 = Encoding.UTF8.GetBytes(commandText);
            int totalLength = sizeof(int) + bufferUTF8.Length + count; //获取总大小
            sendBuffer.Clear();
            sendBuffer.WriteInt(totalLength, false); //写入总大小
            sendBuffer.WriteInt(bufferUTF8.Length, false); //写入命令大小
            sendBuffer.WriteBuffer(bufferUTF8); //写入命令内容
            sendBuffer.WriteBuffer(buffer, offset, count); //写入二进制数据
            tcpClient.Client.Send(sendBuffer.Buffer, 0, sendBuffer.DataCount, SocketFlags.None);
        }

        public bool RecvCommand()
        {
            recvBuffer.Clear();
            tcpClient.Client.Receive(recvBuffer.Buffer, sizeof(int), SocketFlags.None);
            int packetLength = BitConverter.ToInt32(recvBuffer.Buffer, 0); //获取包长度
            if (NetByteOrder)
                packetLength = System.Net.IPAddress.NetworkToHostOrder(packetLength); //把网络字节顺序转为本地字节顺序
            recvBuffer.SetBufferSize(sizeof(int) + packetLength); //保证接收有足够的空间
            tcpClient.Client.Receive(recvBuffer.Buffer, sizeof(int), packetLength, SocketFlags.None);
            int commandLen = BitConverter.ToInt32(recvBuffer.Buffer, sizeof(int)); //取出命令长度
            string tmpStr = Encoding.UTF8.GetString(recvBuffer.Buffer, sizeof(int) + sizeof(int), commandLen);
            if (!incomingDataParser.DecodeProtocolText(tmpStr)) //解析命令
                return false;
            else
                return true;
        }

        public bool RecvCommand(out byte[] buffer, out int offset, out int size)
        {
            recvBuffer.Clear();
            tcpClient.Client.Receive(recvBuffer.Buffer, sizeof(int), SocketFlags.None);
            int packetLength = BitConverter.ToInt32(recvBuffer.Buffer, 0); //获取包长度
            if (NetByteOrder)
                packetLength = System.Net.IPAddress.NetworkToHostOrder(packetLength); //把网络字节顺序转为本地字节顺序
            recvBuffer.SetBufferSize(sizeof(int) + packetLength); //保证接收有足够的空间
            tcpClient.Client.Receive(recvBuffer.Buffer, sizeof(int), packetLength, SocketFlags.None);
            int commandLen = BitConverter.ToInt32(recvBuffer.Buffer, sizeof(int)); //取出命令长度
            string tmpStr = Encoding.UTF8.GetString(recvBuffer.Buffer, sizeof(int) + sizeof(int), commandLen);
            if (!incomingDataParser.DecodeProtocolText(tmpStr)) //解析命令
            {
                buffer = null;
                offset = 0;
                size = 0;
                return false;
            }
            else
            {
                buffer = recvBuffer.Buffer;
                offset = commandLen + sizeof(int) + sizeof(int);
                size = packetLength - offset;
                return true;
            }
        }
    }
}
