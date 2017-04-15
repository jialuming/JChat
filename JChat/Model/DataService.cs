using JEntity;
using JEntity.WebService;
using System;
using System.Text;
using System.Web.Script.Serialization;

namespace JChat.Model
{
    public class DataService : IDataService
    {

        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }

        public bool CheckUser(string userName, string password)
        {
            //MessageManager mm = MessageManager.Instence;
            //MessageInfo info = new MessageInfo(App.ResourceAssembly.GetName(false).Version.ToString(),
            //                MessageType.CheckUser,
            //                userName,
            //                0, 0,
            //                new MessageText() { P = password });
            ////byte[] bytes = info.GetBytes(); Encoding.Unicode.GetBytes(msg);
            //mm.MessageSend(info);
            return true;
        }
        // Object->Json
        public string Serialize(object obj)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(obj);
            return json;
        }
        public User GetUserInfo()
        {
            throw new NotImplementedException();
        }

        public bool SendMessage(ChatInfo message)
        {
            throw new NotImplementedException();
        }

        public void SetUserInfo(User user)
        {
            throw new NotImplementedException();
        }

        public void ReceiveMessage(ChatInfo messageInfo)
        {
            throw new NotImplementedException();
        }
    }
}