using JEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JChat.Model
{
    public interface IDataService
    {

        bool CheckUser(string userName, string password);

        User GetUserInfo();

        bool SendMessage(MessageInfo message);

        void SetUserInfo(User user);

        void ReceiveMessage(MessageInfo messageInfo);

    }
}
