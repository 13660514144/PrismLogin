using PrismLogin.ViewModels;
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
    /// CTLgetlist.xaml 的交互逻辑
    /// </summary>
    public partial class CTLgetlist : UserControl
    {
        private CTLgetlistViewModel Model;
        public CTLgetlist(CTLgetlistViewModel _Model)
        {
            InitializeComponent();
            Model = _Model;
            this.DataContext = Model;// new CTLgetlistViewModel();
        }
    }
}
