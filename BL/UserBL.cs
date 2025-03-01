using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using TL;

namespace BL
{
    public class UserBL
    {
        public string AuthenticateUser(string username, string password) 
        {
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return "invalid"; 
            }
            return new DL.UserDL().Login(new UserTL(username, password));
        }
    }
}
