using JEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JChat.Test
{
    public class CreateData
    {
        public User User { get; set; }
        public List<User> FriendList { get; set; }

        public CreateData()
        {
            User = new User()
            {
                EMail = "邮箱",
                IcoPath = "/Img/touxiang.png",
                NickName = "昵称",
                Password = "",
                User_ID = 1234567,
                UserID = "23",
                Remarks = "备注",
                Sex = "性别",
                Signature = "个人签名"
            };
            ViewModel.ViewModelLocator vml = new ViewModel.ViewModelLocator();
            vml.Main.TUSer = User;
        }
    }
}
