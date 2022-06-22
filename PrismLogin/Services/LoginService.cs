using System;
using System.Collections.Generic;
using System.Text;

namespace PrismLogin.Services
{
    public class LoginService : ILoginService
    {
        public bool UserLogin(string UserName, string Password)
        {
            bool Flg = false;
            if (UserName == "lzd" && Password == "123")
            {
                Flg = true;
            }
            return Flg;
        }
    }
}
