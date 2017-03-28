using JEntity;
using JService.Services;
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
            MessageManager mm = MessageManager.Instence;
            JService.Model.MessageInfo info = new JService.Model.MessageInfo(App.ResourceAssembly.GetName(false).Version.ToString(),
                           JService.Model.MessageType.CheckUser,
                           userName,
                           0,
                           "P:'" + password + "'");
            string s = Serialize(info);
            //byte[] bytes = info.GetBytes(); Encoding.Unicode.GetBytes(msg);
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            mm.MessageSend(bytes);
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

        public bool SendMessage(MessageInfo message)
        {
            throw new NotImplementedException();
        }

        public void SetUserInfo(User user)
        {
            throw new NotImplementedException();
        }

        public void ReceiveMessage(MessageInfo messageInfo)
        {
            throw new NotImplementedException();
        }
    }
}