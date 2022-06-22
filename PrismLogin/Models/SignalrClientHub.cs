using Microsoft.AspNetCore.SignalR.Client;
using Prism.Events;
using PrismLogin.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PrismLogin.Models
{
    public class SignalrClientHub
    {
        const string url = @"http://127.0.0.1:5100/SignalrHub";
        private IEventAggregator Pubshier; //发布  Prism模式
        public ClientObject RegiterObj;
        public HubConnection MasterHub;
        private System.Windows.Threading.DispatcherTimer Dtimer ;
        private bool IsCoonect = false;
        private DateTime Trecord;
        
        public SignalrClientHub(IEventAggregator _pub)
        {
            Trecord = DateTime.Now;
            Pubshier = _pub;
            RegiterObj = new ClientObject();
            Pubshier.GetEvent<SingalrMessage>().Publish("实例初始化"); //发布  Prism模式
            Dtimer = new DispatcherTimer();
            Dtimer.Interval = TimeSpan.FromMilliseconds(10000);
            Dtimer.Tick += new EventHandler(Dtimer_Tick);
            Dtimer.Start();
        }
        async void  Dtimer_Tick(object sender, EventArgs e)
        {
            TimeSpan nd = DateTime.Now - Trecord;
            Pubshier.GetEvent<SingalrMessage>().Publish($"Time Trecord=>{nd.TotalSeconds} "); //发布  Prism模式
            try
            {
                if (MasterHub.State.ToString() == "Connected")
                {
                    await InitLinkAsync();
                }
                else
                {
                    await MasterHub.StartAsync();
                }
            }
            catch (Exception ex)
            {
                IsCoonect = false;
                Pubshier.GetEvent<SingalrMessage>().Publish($"heart err=>{ex.Message.ToString()} "); //发布  Prism模式
            }
        }
        public async void StartAsync()
        {
            try
            {
                MasterHub = new HubConnectionBuilder().WithAutomaticReconnect(new[]
                {
                    TimeSpan.FromSeconds(0),
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(7),
                    TimeSpan.FromSeconds(15),
                    TimeSpan.FromSeconds(7),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(3)
                }).WithUrl(url).Build();

                //断开连接后重试
                MasterHub.Closed += async (error) =>
                {
                    Pubshier.GetEvent<SingalrMessage>().Publish($"服务器连接已断开：ex:{ error.Message.ToString()}"); //发布  Prism模式
                    IsCoonect = false;
                    await MasterHub.StartAsync();
                };
                //重连中
                MasterHub.Reconnecting += async (Task) =>
                {
                    Pubshier.GetEvent<SingalrMessage>().Publish($"断开重连...");
                };
                ////重连成功
                MasterHub.Reconnected += async (Task) =>
                {
                    Pubshier.GetEvent<SingalrMessage>().Publish($"重连成功...");
                };
                //心跳检查
                MasterHub.KeepAliveInterval = TimeSpan.FromSeconds(10);
                await ConnectServerAsync();
            }
            catch (Exception ex)
            {
                Pubshier.GetEvent<SingalrMessage>().Publish($"StartAsync err=>{ex.Message.ToString()} "); //发布  Prism模式
                IsCoonect = false;
            }

        }

        private async Task ConnectServerAsync()
        {
            //定义本地方法
 
            MasterHub.On<ClientObject>("RegisterToken", async (datas) =>
            {
                RegiterObj.ConnectId = datas.ConnectId;
                bool flg= await LinkAsync();
                Pubshier.GetEvent<SingalrMessage>().Publish($"RegisterToken=>{flg}"); //发布  Prism模式
            });
            MasterHub.On<string,string>("receivemessage", async (user,name) =>
            {
                Pubshier.GetEvent<SingalrMessage>().Publish($"receivemessage=>{user}:{name}"); //发布  Prism模式
            });
            await StartLinkAsync();
        }

        public async Task StartLinkAsync()
        {
            try
            {
                await MasterHub.StartAsync();               
            }
            catch (Exception ex)
            {
                Pubshier.GetEvent<SingalrMessage>().Publish($"连接服务器出错：{ex.Message} "); //发布  Prism模式
            }
            Pubshier.GetEvent<SingalrMessage>().Publish($"Connection state=>{MasterHub.State}"); //发布  Prism模式
            IsCoonect = (MasterHub.State.ToString() == "Connected") ? true : false;
            //await InitLinkAsync();
        }
        public async Task InitLinkAsync()
        {
            //发送心跳 
            var Flg = await MasterHub.InvokeAsync<bool>("HeartFlg", RegiterObj);
            Pubshier.GetEvent<SingalrMessage>().Publish($"heart=>{Flg} "); //发布  Prism模式
        }

        public async Task<bool> LinkAsync()
        {
            RegiterObj.ClientIp = "192.0.0.0";
            RegiterObj.ClientPort = "999";
            RegiterObj.ServerHost = "127.0.0.0";
            RegiterObj.ServerPort = "5100";
            RegiterObj.ClientType = "Owner Type";
            var guid = Guid.NewGuid().ToString("N");
            RegiterObj.ToKen = guid;
            RegiterObj.GUID = guid;
            var hasError = await MasterHub.InvokeAsync<bool>("UpConnectObj", RegiterObj);
            
            Pubshier.GetEvent<SingalrMessage>().Publish($"UpConnectObj=>{hasError} "); //发布  Prism模式
            return hasError;
        }
        public async Task<bool> Upinfo(ClientObject obj)
        {
            var hasError = await  MasterHub.InvokeAsync<bool>("UpConnectObj", obj);
            return hasError;
        }
        public async  Task<string> GetSample(string str)
        {
            var hasError =await  MasterHub.InvokeAsync<string>("GetSample", str);
            return hasError;
        }
    }
    public class ClientObject
    {
        public string ConnectId { get; set; } = string.Empty;
        public string ClientType { get; set; } = string.Empty;
        public string ClientIp { get; set; } = string.Empty;
        public string ClientPort { get; set; } = string.Empty;
        public string ServerHost { get; set; } = string.Empty;
        public string ServerPort { get; set; } = string.Empty;
        public string ToKen { get; set; } = string.Empty;
        public string GUID { get; set; } = string.Empty;
    }
}
