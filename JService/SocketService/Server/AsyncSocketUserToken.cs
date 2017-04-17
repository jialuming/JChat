using JService.SocketService.AsyncSocketCore;
using JService.SocketService.AsyncSocketProtocolCore;
using System;
using System.Net.Sockets;

namespace JService.SocketService.Server
{
    public class AsyncSocketUserToken
    {
        protected byte[] asyncReceviceBuffer;
        //接受时使用的SAEA对象
        public SocketAsyncEventArgs RecevicveEventArgs { get; set; }
        //发送时使用的SAEA对象
        public SocketAsyncEventArgs SendEventArgs { get; set; }

        public DynamicBufferManager ReceiveBuffer { get; set; }
        public AsyncSendBufferManager SendBuffer { get; set; }

        public AsyncSocketInvokeElement AsyncSocketInvokeElement { get; set; }
        public DateTime ConnectDateTime { get; set; }

        private Socket socket;
        //当前链接的Socket对象
        public Socket Socket
        {
            get { return socket; }
            set
            {
                socket = value;
                RecevicveEventArgs.AcceptSocket = socket;
                SendEventArgs.AcceptSocket = socket;
            }
        }


        public AsyncSocketUserToken(int asyncReceviceBufferSize)
        {
            asyncReceviceBuffer = new byte[asyncReceviceBufferSize];
            RecevicveEventArgs = new SocketAsyncEventArgs();
            RecevicveEventArgs.UserToken = this;
            RecevicveEventArgs.SetBuffer(asyncReceviceBuffer, 0, asyncReceviceBuffer.Length);
            SendEventArgs = new SocketAsyncEventArgs();
            SendEventArgs.UserToken = this;

            ReceiveBuffer = new DynamicBufferManager(ProtocolConst.InitBufferSize);
            SendBuffer = new AsyncSendBufferManager(ProtocolConst.InitBufferSize);
        }
    }
}
