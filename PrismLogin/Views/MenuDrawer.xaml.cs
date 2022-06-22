using DropDownMenu.ViewModel;
using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrismLogin.Views
{
    /// <summary>
    /// MenuDrawer.xaml 的交互逻辑
    /// </summary>
    public partial class MenuDrawer : UserControl
    {
        private readonly IContainerExtension _container;
        public MenuDrawer(IContainerExtension container)
        {
            InitializeComponent();
            _container = container;
            string ProssPath = AppDomain.CurrentDomain.BaseDirectory;
            //this.Logo.Source = new BitmapImage(new Uri($"{ProssPath}Images/favicon.ico", UriKind.RelativeOrAbsolute));
            var menuRegister = new List<SubItem>();

            menuRegister.Add(new SubItem("客户", _container.Resolve<UserControlCustomers>()));

            menuRegister.Add(new SubItem("供应商", new UserControlProviders()));

            menuRegister.Add(new SubItem("员工", _container.Resolve<PuDataGrid>()));

            menuRegister.Add(new SubItem("产品"));

            var item6 = new ItemMenu("登记", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItem>();

            menuSchedule.Add(new SubItem("服务"));

            menuSchedule.Add(new SubItem("会议"));

            var item1 = new ItemMenu("预约", menuSchedule, PackIconKind.Schedule);

            var menuReports = new List<SubItem>();

            menuReports.Add(new SubItem("客户"));

            menuReports.Add(new SubItem("供应商"));

            menuReports.Add(new SubItem("产品"));

            menuReports.Add(new SubItem("库存"));

            menuReports.Add(new SubItem("销售额"));

            var item2 = new ItemMenu("报告", menuReports, PackIconKind.FileReport);

            var menuExpenses = new List<SubItem>();

            menuExpenses.Add(new SubItem("固定资产"));

            menuExpenses.Add(new SubItem("流动资金"));

            var item3 = new ItemMenu("费用", menuExpenses, PackIconKind.ShoppingBasket);

            var menuFinancial = new List<SubItem>();

            menuFinancial.Add(new SubItem("现金流"));

            var item4 = new ItemMenu("财务", menuFinancial, PackIconKind.ScaleBalance);

            Menu.Children.Add(new UserControlMenuItemA(item6, this));

            Menu.Children.Add(new UserControlMenuItemA(item1, this));

            Menu.Children.Add(new UserControlMenuItemA(item2, this));

            Menu.Children.Add(new UserControlMenuItemA(item3, this));

            Menu.Children.Add(new UserControlMenuItemA(item4, this));
        }
        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }
        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void GridTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //DragMove();
        }

        private void GridMenu_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            gdMian.Margin = new Thickness(e.NewSize.Width, 50, 0, 0);
        }

        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
