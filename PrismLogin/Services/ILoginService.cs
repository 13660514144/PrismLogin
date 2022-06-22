using System;
using System.Collections.Generic;
using System.Text;

namespace PrismLogin.Services
{
    public interface ILoginService
    {
        public Boolean UserLogin(string UserName, string Password);
    }
}
