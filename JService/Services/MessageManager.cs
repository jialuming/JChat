using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace JService.Services
{
    class MessageManager
    {
        public MessageResult MessageAnalysis(Byte[] bytes)
        {
            MessageResult Result = new MessageResult();
            return Result;
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        MessageSendState MessageSend(Socket socket, byte[] bytes)
        {
            socket.Send(bytes, SocketFlags.None);
            return MessageSendState.Failed;
        }
        /// <summary>
        /// 回应
        /// </summary>
        /// <param name="socket"></param>
        void Response(Socket socket)
        {

        }

    }
}
