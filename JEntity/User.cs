using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEntity
{
    public class User : EntityBase
    {
        public int User_ID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Nickame { get; set; }
        public string EMail { get; set; }
        public string Sex { get; set; }
        public string IcoPath { get; set; }
        public string Signature { get; set; }
    }
}
