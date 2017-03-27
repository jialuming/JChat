using JEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JChat.Model
{
    public class BasicModel
    {
        public static DateTime LoginTime;
        public static User TUser=new User();
        public BasicModel(User tUser)
        {
            TUser = tUser;
        }
    }
}
