using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using Prism.Commands;
using Prism.Mvvm;
using PrismLogin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace PrismLogin.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        [Dependency]  // using Unity;
        public ILoginService _loginService { get; set; }

        private string userName = "";
        private string password = "";

        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        ICommand? loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new DelegateCommand<object>(UserLogin);

                }
                return loginCommand;
            }
        }

        void UserLogin(object obj)
        {
            if (!_loginService.UserLogin(this.UserName, this.Password))
            {

                var R1 = MessageBoxX.Show("用户名或密码错误", "Error", null, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
                {
                    MessageBoxIcon = MessageBoxIcon.Error,
                    ButtonBrush = "#FF4C4C".ToColor().ToBrush(),
                });
                return;
            }
            var result = MessageBoxX.Show("登录成功", "Infomation", null, MessageBoxButton.OK);
            (obj as Window).DialogResult = true;
        }
    }


}
