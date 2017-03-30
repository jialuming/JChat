using JEntity;
using JEntity.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JService.Services
{
    public class MessageManager
    {
        public delegate void GetMessageHandler(Socket socket, MessageInfo messageInfo);
        public event GetMessageHandler GetMessage;

        private static MessageManager _instence;

        public static MessageManager Instence
        {
            get { return _instence ?? (_instence = new MessageManager()); }
        }

        public SocketPool AliveSocketPool { get; set; }
        public SocketPool UDPSocketPool { get; set; }

        private Socket _mainSocket;

        private Socket MainSocket
        {
            get { return _mainSocket ?? (_mainSocket = new TCPService().StartSocket()); }
        }
        public MessageManager()
        {
        }
        public void MessageAnalysis(Socket socket, byte[] bytes, int length)
        {
            try
            {
                var message = Encoding.Unicode.GetString(bytes, 0, length);
                MessageInfo Result = Deserialize<MessageInfo>(message);
                GetMessage?.Invoke(socket, Result);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("无效的信息");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public void MessageSend(Socket socket, MessageInfo messageInfo)
        {
            string s = Serialize(messageInfo);
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            socket.Send(bytes, SocketFlags.None);
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public void MessageSend(MessageInfo messageInfo)
        {
            string s = Serialize(messageInfo);
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MainSocket.Send(bytes, SocketFlags.None);
        }
        /// <summary>
        /// 回应
        /// </summary>
        /// <param name="socket"></param>
        public void Response(Socket socket)
        {

        }

        public string Serialize(object obj)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(obj);
        }
        // Json->Object
        public T Deserialize<T>(string json)
        {
            try
            {
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                //执行反序列化
                T obj = jsonSerializer.Deserialize<T>(json);
                return obj;
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
