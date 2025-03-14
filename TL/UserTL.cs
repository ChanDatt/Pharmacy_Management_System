using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL
{
    public class UserTL
    {
        private string userName, password;
        public UserTL(string userName, string password) { 
            this.userName = userName;
            this.password = password;
        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
    }
}
