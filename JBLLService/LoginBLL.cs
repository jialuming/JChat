using JDBService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBLLService
{
    public class LoginBLL
    {
        LoginQuery _loginQuery = new LoginQuery();

        public int CheckUser(string userName, string password)
        {
            if (userName == "1" && password == "1")
            {
                return 0;
            }
            return 1;
        }
    }
}
