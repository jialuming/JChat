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
        public static TUser TUser=new TUser();
        public BasicModel(TUser tUser)
        {
            TUser = tUser;
        }
    }
}
