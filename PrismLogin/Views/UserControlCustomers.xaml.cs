using Panuon.UI.Silver;
using Prism.Events;
using PrismLogin.Event;
using PrismLogin.Models;
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
    /// UserControlCustomers.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlCustomers : UserControl
    {
        private IEventAggregator Pubshier; //发布  Prism模式
        public UserControlCustomers(IEventAggregator _pub)
        {
            InitializeComponent();
            Pubshier = _pub;
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StudentInfo sTU = new StudentInfo
            {
                Name = "车是车市",
                Class = "3",
                Sex ="南",
                ClassRank = 5,
                SchoolRank = 36
            };
            var result = MessageBoxX.Show("This Is UserControlCustoners", "Infomation", null, MessageBoxButton.OK);
            Pubshier.GetEvent<DawerTo>().Publish(sTU); //发布  Prism模式
        }
    }
}
