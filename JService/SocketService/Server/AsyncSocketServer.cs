using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JService.SocketService.Server
{
    public class AsyncSocketServer
    {
        private int numConnections;   // 最大连接数
        private int receiveBufferSize;// 要为每个套接字 I/O 操作使用缓冲区大小
        BufferManager bufferManager;  // 表示一组大型的、 可重用的缓冲区的所有套接字操作
        const int opsToPreAlloc = 2;    // 读取、 写入 (不分配缓冲区空间为接受)
        Socket listenSocket;            // 用于侦听传入的连接请求的套接字
                                        // 池的可重复使用 SocketAsyncEventArgs 对象的写、 读和接受的套接字操作
        AsyncSocketAsyncEventArgsPool asyncSocketAsyncEventArgsPool;
        Semaphore maxNumberAcceptedClients; //限制访问接收连接的线程数，用来控制最大并发数
        private AsyncSocketUserTokenList asyncSocketUserTokenList;
        public AsyncSocketUserTokenList AsyncSocketUserTokenList { get { return asyncSocketUserTokenList; } }

        public AsyncSocketServer(int numConnections, int receiveBufferSize)
        {
            this.numConnections = numConnections;
            this.receiveBufferSize = receiveBufferSize;
            bufferManager = new BufferManager(receiveBufferSize * numConnections * opsToPreAlloc, receiveBufferSize);
            asyncSocketAsyncEventArgsPool = new AsyncSocketAsyncEventArgsPool(numConnections);
            asyncSocketUserTokenList = new AsyncSocketUserTokenList();
            maxNumberAcceptedClients = new Semaphore(numConnections, numConnections);
        }

        public void Init()
        {
            bufferManager.InitBuffer();

            AsyncSocketUserToken userToken;

            for (int i = 0; i < numConnections; i++)
            {
                userToken = new AsyncSocketUserToken(receiveBufferSize);
                userToken.RecevicveEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
                userToken.SendEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
                asyncSocketAsyncEventArgsPool.Push(userToken);
            }

        }

        public void Start(IPEndPoint localEndPoint)
        {
            //创建套接字进行侦听传入的连接
            listenSocket = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(localEndPoint);
            //启动服务器时听着积压的 100 个连接
            listenSocket.Listen(100);

            //端口上侦听套接字接受
            StartAccept(null);

            //Console.WriteLine("{0} connected sockets with one outstanding receive posted to each....press any key", m_outstandingReadCount);
            Console.WriteLine("开始监听{0}成功", localEndPoint.ToString());
        }


        // 开始操作以接受来自客户端的连接请求
        //
        // <param name="acceptEventArg">The context object to use when issuing 
        // the accept operation on the server's listening socket</param>
        public void StartAccept(SocketAsyncEventArgs acceptEventArg)
        {
            if (acceptEventArg == null)
            {
                acceptEventArg = new SocketAsyncEventArgs();
                acceptEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(AcceptEventArg_Completed);
            }
            else
            {
                // socket must be cleared since the context object is being reused
                acceptEventArg.AcceptSocket = null;
            }

            maxNumberAcceptedClients.WaitOne();
            bool willRaiseEvent = listenSocket.AcceptAsync(acceptEventArg);
            if (!willRaiseEvent)
            {
                ProcessAccept(acceptEventArg);
            }
        }

        //这种方法是与 Socket.AcceptAsync 关联的回调方法
        //操作和接受操作完成时调用
        void AcceptEventArg_Completed(object sender, SocketAsyncEventArgs acceptEventArg)
        {
            ProcessAccept(acceptEventArg);
        }

        private void ProcessAccept(SocketAsyncEventArgs acceptEventArgs)
        {
            Console.WriteLine("客户端已连接，本地地址：{0}，远程地址{1}", acceptEventArgs.AcceptSocket.LocalEndPoint, acceptEventArgs.AcceptSocket.RemoteEndPoint);
            AsyncSocketUserToken userToken = asyncSocketAsyncEventArgsPool.Pop();
            asyncSocketUserTokenList.Add(userToken);//添加到正在连接列表
            userToken.Socket = acceptEventArgs.AcceptSocket;
            userToken.ConnectDateTime = DateTime.Now;

            // As soon as the client is connected, post a receive to the connection
            bool willRaiseEvent = userToken.Socket.ReceiveAsync(userToken.RecevicveEventArgs);
            if (!willRaiseEvent)
            {
                lock (userToken)
                {
                    ProcessReceive(userToken.RecevicveEventArgs);
                }
            }

            StartAccept(acceptEventArgs);
        }

        // This method is called whenever a receive or send operation is completed on a socket 
        //
        // <param name="e">SocketAsyncEventArg associated with the completed receive operation</param>
        void IO_Completed(object sender, SocketAsyncEventArgs asyncEventArgs)
        {
            AsyncSocketUserToken userToken = asyncEventArgs.UserToken as AsyncSocketUserToken;
            // determine which type of operation just completed and call the associated handler
            lock (userToken)
            {
                switch (asyncEventArgs.LastOperation)
                {
                    case SocketAsyncOperation.Receive:
                        ProcessReceive(asyncEventArgs);
                        break;
                    case SocketAsyncOperation.Send:
                        ProcessSend(asyncEventArgs);
                        break;
                    default:
                        throw new ArgumentException("The last operation completed on the socket was not a receive or send");
                }

            }
        }

        private void ProcessReceive(SocketAsyncEventArgs AsyncEventArgs)
        {
            AsyncSocketUserToken userToken = AsyncEventArgs.UserToken as AsyncSocketUserToken;
            if (userToken.Socket == null)
                return;

            if (userToken.RecevicveEventArgs.BytesTransferred > 0 && userToken.RecevicveEventArgs.SocketError == SocketError.Success)
            {
                int offset = userToken.RecevicveEventArgs.Offset;
                int count = userToken.RecevicveEventArgs.BytesTransferred;
                if ((userToken.AsyncSocketInvokeElement == null) & (userToken.Socket != null))
                {
                    BuildingSocketInvokeElement(userToken);
                    offset += 1;
                    count -= 1;
                }
                if (userToken.AsyncSocketInvokeElement == null)//没有协议对象
                {
                    CloseClientSocket(userToken);
                }
                else
                {
                    if (count > 0)
                    {
                        if (!userToken.AsyncSocketInvokeElement.ProcessReceive(userToken.RecevicveEventArgs.Buffer, offset, count))
                        {
                            CloseClientSocket(userToken);
                        }
                    }
                    bool willRaiseEvent = userToken.Socket.ReceiveAsync(userToken.RecevicveEventArgs);
                    if (!willRaiseEvent)
                    {
                        ProcessReceive(userToken.RecevicveEventArgs);
                    }
                }
            }
            else
            {
                CloseClientSocket(userToken);
            }
        }
        private void BuildingSocketInvokeElement(AsyncSocketUserToken userToken)
        {
            userToken.AsyncSocketInvokeElement = new AsyncSocketInvokeElement();
        }


        //异步发送操作完成时，将调用此方法。
        //方法问题另一个接收套接字读取任何额外的
        //从客户端发送的数据
        //
        // <param name="e"></param>
        private bool ProcessSend(SocketAsyncEventArgs e)
        {
            AsyncSocketUserToken userToken = e.UserToken as AsyncSocketUserToken;
            if (userToken.AsyncSocketInvokeElement == null)
                return false;
            if (e.SocketError == SocketError.Success)
                return userToken.AsyncSocketInvokeElement.SendCompleted();
            else
            {
                CloseClientSocket((AsyncSocketUserToken)e.UserToken);
                return false;
            }
        }

        private void CloseClientSocket(AsyncSocketUserToken userToken)
        {
            Console.Write("关闭客户端连接，本地地址：{0}，远程地址：{1}", userToken.Socket.LocalEndPoint, userToken.Socket.RemoteEndPoint);
            if (userToken.Socket == null)
                return;
            try
            {
                userToken.Socket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception) { }
            userToken.Socket.Close();
            userToken.Socket = null;

            maxNumberAcceptedClients.Release();
            asyncSocketAsyncEventArgsPool.Push(userToken);
            asyncSocketUserTokenList.Remove(userToken);
        }

    }
}
