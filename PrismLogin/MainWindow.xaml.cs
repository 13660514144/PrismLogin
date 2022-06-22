using Panuon.UI.Silver;
using Prism.Ioc;
using PrismLogin.Models;
using PrismLogin.ViewModels;
using PrismLogin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PrismLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsInnerChange = false;
        private MainWindowViewModel _MainWindowViewModel;
    

        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            _MainWindowViewModel = mainWindowViewModel;
            this.DataContext = _MainWindowViewModel;// new MainWindowViewModel();
           
        }

        //private void TbCmd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (IsInnerChange)
        //    {   // 内部改变
        //        IsInnerChange = false;
        //        return;
        //    }
        //    else
        //    {
        //        int SelectedIndex = TbCmd.SelectedIndex;
        //        if (SelectedIndex == 1)
        //        {
        //            MessageBoxResult result = MessageBox.Show(this, "Are you sure to leave?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //            if (result == MessageBoxResult.Yes)
        //            {   // 检测选择页面是否因弹出MessageBox后出现变化
        //                if (TbCmd.SelectedIndex != 1)
        //                {
        //                    IsInnerChange = true;   // 标记为内部改变
        //                    TbCmd.SelectedIndex = 1;
        //                    var tab = TbCmd.SelectedItem as TabItem;
        //                    tab.Content = LIST;
        //                }
        //            }
        //            else
        //            {   // 阻止页面切换
        //                Application.Current.Dispatcher.BeginInvoke((Action)delegate
        //                {
        //                    TbCmd.SelectedIndex = SelectedIndex;
        //                    var tab = TbCmd.SelectedItem as TabItem;
        //                    tab.Focus();
        //                });
        //            }
        //        }
        //    }
        //}

        
    }
}
