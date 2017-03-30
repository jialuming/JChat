using System;
using System.Text;

namespace JEntity.WebService
{
    public struct MessageInfo
    {
        public Guid Guid { get; set; }
        public string Version { get; set; }
        public MessageType MessageType { get; set; }
        public string UserID { get; set; }
        public int Number { get; set; }
        public long Length { get; set; }
        public MessageText MessageText { get; set; }

        public MessageInfo(string version, MessageType messageType, string userID, int number, long length, MessageText messageText)
        {
            this.Guid = Guid.NewGuid();
            Version = version;
            MessageType = messageType;
            UserID = userID;
            Number = number;
            Length = length;
            MessageText = messageText;

        }
        public byte[] GetBytes()
        {
            string msg = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", Version, (int)MessageType, UserID, Number, Length.ToString(), MessageText);

            byte[] msgBuffer = Encoding.Unicode.GetBytes(msg);
            byte[] lengthBuffer = Encoding.Unicode.GetBytes(msgBuffer.LongLength.ToString());

            long allLength = msgBuffer.LongLength + lengthBuffer.LongLength;
            byte[] lengthBuffer2 = Encoding.Unicode.GetBytes(allLength.ToString());

            if (lengthBuffer2.LongLength <= lengthBuffer.LongLength)
            {
                allLength -= 2;
            }
            string msg2 = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", Version, (int)MessageType, UserID, Number, allLength.ToString(), MessageText);
            lengthBuffer = Encoding.Unicode.GetBytes(msg2);
            return lengthBuffer;
        }
    }
    public enum MessageType
    {
        Alive = 0,
        CheckUser = 1,
        /// <summary>
        /// 转发
        /// </summary>
        SendMessage = 2,
        /// <summary>
        /// 文字消息
        /// </summary>
        GetFriendList = 3,
        /// <summary>
        /// 视频消息
        /// </summary>
        GetUserInfo = 4,
        Request = 5,
    }

    public enum MessageSendState
    {
        Failed,
        Succeed
    }
}
