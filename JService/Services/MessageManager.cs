using JEntity;
using JService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace JService.Services
{
    public class MessageManager
    {
        private static MessageManager _instence;

        public static MessageManager Instence
        {
            get
            {
                return _instence ?? (_instence = new MessageManager());
            }
        }
        private Socket _mainTcp;

        public Socket MainTcp
        {
            get { return _mainTcp; }
            set { _mainTcp = value; }
        }

        private Socket _mainUdp;

        public Socket MainUdp
        {
            get { return _mainUdp; }
            set { _mainUdp = value; }
        }

        public MessageInfo MessageAnalysis(Byte[] bytes)
        {
            MessageInfo Result = new MessageInfo();
            return Result;
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public void MessageSend(Socket socket, byte[] bytes)
        {
            socket.Send(bytes, SocketFlags.None);
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public void MessageSend(byte[] bytes)
        {
            if (MainTcp == null)
            {
                _mainTcp = new TCPService().StartSocket();
            }
            if (MainTcp != null && MainTcp.Connected)
            {
                //byte[] bytes = Encoding.Unicode.GetBytes(MessageType.None + "|" + userName + "|" + password);
                MainTcp.Send(bytes);
            }
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public void MessageSend(string userName, string password)
        {
            
        }
        /// <summary>
        /// 回应
        /// </summary>
        /// <param name="socket"></param>
        public void Response(Socket socket)
        {

        }

    }
}
