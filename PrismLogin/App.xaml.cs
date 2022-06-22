using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using PrismLogin.Models;
using PrismLogin.Services;
using PrismLogin.ViewModels;
using PrismLogin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PrismLogin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication  // Application
    {

        public App() { }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            if (Container.Resolve<Login>().ShowDialog() == false)
            {
                Application.Current?.Shutdown();
            }
            else
            {
                base.InitializeShell(shell);
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILoginService, LoginService>();  // 默认是transient注册
            #region 单例注入依赖
            //containerRegistry.RegisterSingleton<MainWindow>();
            containerRegistry.RegisterSingleton<MainWindowViewModel>();
            containerRegistry.RegisterSingleton<DataListGrid>();
            containerRegistry.RegisterSingleton<DataListGridViewModel>();
            containerRegistry.RegisterSingleton<SignalrClientHub>();
            containerRegistry.RegisterSingleton<SpeekVoice>();
            // containerRegistry.RegisterSingleton<CTLgetlist>();  //通过MAIN注入
            // containerRegistry.RegisterSingleton<CTLgetlistViewModel>();
            #endregion
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {

        }
    }
}
