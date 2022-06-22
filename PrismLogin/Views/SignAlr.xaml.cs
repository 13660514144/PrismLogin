using Prism.Events;
using PrismLogin.Event;
using PrismLogin.Models;
using PrismLogin.Services;
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
    /// SignAlr.xaml 的交互逻辑
    /// </summary>
    public partial class SignAlr : UserControl
    {
        private IEventAggregator Pubshier; //发布  Prism模式
        private int rows = 0;
        private SignalrClientHub _HUB;
        private SpeekVoice _SpeekVoice;
        public SignAlr(IEventAggregator _pub, SignalrClientHub hub,SpeekVoice speekvoice)
        {
            InitializeComponent();
            Pubshier = _pub;
            Pubshier.GetEvent<SingalrMessage>().Subscribe(SubMessage);
            _HUB = hub;
            SignInfo.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
            _SpeekVoice = speekvoice;
        }
        private void SubMessage(string str)
        {
            if (rows > 100)
            {
                rows = 0;
                rows++;
                int len = stack.Children.Count-1;
                for (int x = len; x >= 0; x--)
                {
                    stack.Children.RemoveAt(x);
                }               
            }
            Dispatcher.Invoke(()=>{
                TextBlock txt = CreateTblock();
                txt.Text = str;
                this.stack.Children.Add(txt);
            });
        }

        private async void Getsample_Click(object sender, RoutedEventArgs e)
        {
            var s =await  _HUB.GetSample("test");
            Dispatcher.Invoke(() => {
                _SpeekVoice.ToSpeek("HA阿斯蒂芬设定");
                TextBlock txt = CreateTblock();
                txt.Text = s;
                this.stack.Children.Add(txt);
                
            });
        }

        private async void Getinfo_Click(object sender, RoutedEventArgs e)
        {            
            _HUB.RegiterObj.ClientType = "UP THIS TYPE";
            _HUB.RegiterObj.ClientIp = "192.0.0.0";
            _HUB.RegiterObj.ClientPort = "9292";
            _HUB.RegiterObj.ServerHost = "127.0.0.1";
            _HUB.RegiterObj.ServerPort = "8080";
            var guid = Guid.NewGuid().ToString("N");
            _HUB.RegiterObj.ToKen = guid;
            _HUB.RegiterObj.GUID = guid;
            var s =await  _HUB.Upinfo(_HUB.RegiterObj);
            Dispatcher.Invoke(() => {
                TextBlock txt = CreateTblock();
                txt.Text = s.ToString();
                this.stack.Children.Add(txt);
            });
        }
        private TextBlock CreateTblock()
        {
            TextBlock txt = new TextBlock()
            {
                FontSize = 20,
                FontFamily = new FontFamily("YaHei"),
                Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255)),
                Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0)),
                Margin = new Thickness(0, 1, 0, 0),
                Padding = new Thickness(10)
            };
            return txt;
        }
    }
}
