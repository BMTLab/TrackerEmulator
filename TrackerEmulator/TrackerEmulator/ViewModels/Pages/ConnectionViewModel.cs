#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 19.08.2019 12:19
#endregion


using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using TrackerEmulator.Models;

using Xamarin.Forms;


namespace TrackerEmulator.ViewModels.Pages
{
    public class ConnectionViewModel : BasePageViewModel
    {
        #region Constants
        public const string TitleDefault = "Connection";
        #endregion


        #region Fields
        #endregion


        #region Constructors
        public ConnectionViewModel(Page page) : base(page)
        {
            Title = TitleDefault;

            PropertyChanged += async (_, e) =>
            {
                if (e.PropertyName == nameof(CurrentClient))
                {
                    //RefreshInfo();
                    //ReceiveText();
                    await CurrentClient.ConnectAsync();

                    //Task.Run(async () => await ReceiveText());
                }
            };

            //ReceiveText();

            //var checker = new Thread(() =>
            //{
            //    Thread.Sleep(1000);
            //    OnAnotherPropertyChanged(nameof(CurrentClient));
            //});
            //checker.Start();
        }


        public ConnectionViewModel(Page page, TrackerTcpClient client) : base(page)
        {
            CurrentClient = client;
            Task.Run(Handle);
        }


        private async void Handle()
        {
            await CurrentClient.ConnectAsync();
            await CurrentClient.SendSelfInfoAsync();
            RefreshInfo();
            await ReceiveCommands();
        }
        #endregion


        #region Properties
        private TrackerTcpClient _trackerClient;

        public TrackerTcpClient CurrentClient
        {
            get => _trackerClient;
            set
            {
                _trackerClient = value;

                OnPropertyChanged();
            }
        }

        private IPAddress _hostIpInfo;

        public IPAddress HostIpInfo
        {
            get => _hostIpInfo;
            set
            {
                _hostIpInfo = value;
                OnPropertyChanged();
            }
        }

        private ushort _hostPortInfo;

        public ushort HostPortInfo
        {
            get => _hostPortInfo;
            set
            {
                _hostPortInfo = value;
                OnPropertyChanged();
            }
        }

        private bool _isConnected;

        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                OnPropertyChanged();
            }
        }

        private int _availableDataCount;

        public int AvailableDataCount
        {
            get => _availableDataCount;
            set
            {
                _availableDataCount = value;
                OnPropertyChanged();
            }
        }

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public Command RefreshInfoCommand => new Command(async () => await RefreshInfo());
        public Command DisconnectCommand => new Command(() => Disconnect());
        #endregion


        #region Methods
        private async Task RefreshInfo()
        {
            HostIpInfo = CurrentClient.IpAdressHost;
            HostPortInfo = CurrentClient.PortAdressHost;
            IsConnected = CurrentClient.Connected;
            AvailableDataCount = CurrentClient.Client.Available;
            await Task.CompletedTask;
        }


        private async Task ReceiveCommands()
        {
            var tracker = CurrentClient;
            
            if (!tracker.Connected)
                return;

            var stream = tracker.GetStream();

            try
            {
                while (tracker.Connected)
                {
                    var bData = new byte[tracker.ReceiveBufferSize];
                    var sbData = new StringBuilder(128);

                    if (tracker.Connected && stream.CanRead)
                    {
                        if (stream.DataAvailable)
                        {
                            while (stream.DataAvailable)
                            {
                                var bCount = await stream.ReadAsync(bData, 0, bData.Length);
                                sbData.Append(Encoding.Unicode.GetString(bData, 0, bCount));
                            }

                            Text = sbData.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.SendNotification(ex.Message);
            }
            finally
            {
                stream?.Close();
                tracker?.Client.Disconnect(true);
            }
        }


        private void Disconnect()
        {
            //CurrentClient?.Close();
            //CurrentClient?.Client?.Disconnect(false);
            Text = string.Empty;
        }
        #endregion
    }
}