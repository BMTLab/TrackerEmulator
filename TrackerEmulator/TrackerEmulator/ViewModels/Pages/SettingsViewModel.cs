#region HEADER
//  TrackerEmulator.TrackerEmulator
//  Created by Nikita Neverov at 19.08.2019 12:19
#endregion


#define ADDITIONAL_IMEIS

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

using TrackerEmulator.Entites;
using TrackerEmulator.Helpers.Extension;
using TrackerEmulator.Models;
using TrackerEmulator.Services;
using TrackerEmulator.Views.Pages;

using Xamarin.Forms;


namespace TrackerEmulator.ViewModels.Pages
{
    public class SettingsViewModel : BasePageViewModel
    {
        #region Constants
        public const string TitleDefault = "Connection Settings";
        #endregion


        #region Fields
        private static IList<ushort> _bufferSizes;
        private static ObservableCollection<ImeiItem> _imeiListDevice;
        private static byte _connectionId = 0;

        private IPAddress _ipAddressDevice;
        private ushort _portAddressDevice;

        private IPAddress _ipAddressHost;
        private ushort _portAddressHost;

        private ushort _bufferSizeDevice;

        private ImeiItem _selectedImeiDevice;
        private string _customImeiDevice;
        #endregion


        #region Constructors 
        static SettingsViewModel()
        {
            /* Initialize source for buffer size selection menu */
            const int n = 10;

            _bufferSizes = new List<ushort>(n);

            for (var i = 0; i < n; i++)
            {
                _bufferSizes.Add((ushort) (1 << i));
            }


            /* Initialize the appearance of the list */
            ImeiItem.ItemSelectedColor = new Color().Primary();
            ImeiItem.ItemNonSelectedColor = Color.Transparent;

            ImeiItem.ItemNonSelectedTextColor = new Color().DarkTextColor();
            ImeiItem.ItemSelectedTextColor = new Color().LightTextColor();

            ImeiItem.TextColorDefault = new Color().DarkTextColor();
        }


        public SettingsViewModel(Page page) : base(page)
        {
            Title = TitleDefault;

            InitializeFields();
            InitializeEventHandlers();
        }
        #endregion


        #region Properties
        public IPAddress IpAddressDevice
        {
            get => _ipAddressDevice;
            set
            {
                if (value == null)
                    return;

                _ipAddressDevice = value;
                OnPropertyChanged();
            }
        }

        public ushort PortAddressDevice
        {
            get => _portAddressDevice;
            set
            {
                _portAddressDevice = value;
                OnPropertyChanged();
            }
        }

        public IPAddress IpAddressHost
        {
            get => _ipAddressHost;
            set
            {
                if (value == null)
                    return;

                _ipAddressHost = value;
                OnPropertyChanged();
            }
        }

        public ushort PortAddressHost
        {
            get => _portAddressHost;
            set
            {
                _portAddressHost = value;
                OnPropertyChanged();
            }
        }

        public IList<ushort> BufferSizes
        {
            get => _bufferSizes;
            set
            {
                _bufferSizes = value;
                OnPropertyChanged();
            }
        }

        public ushort BufferSizeDevice
        {
            get => _bufferSizeDevice;
            set
            {
                _bufferSizeDevice = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ImeiItem> ImeiListDevice
        {
            get => _imeiListDevice;
            set
            {
                if (value == null)
                    return;

                _imeiListDevice = value;
                OnPropertyChanged();
            }
        }

        public ImeiItem SelectedImeiDevice
        {
            get => _selectedImeiDevice;
            set
            {
                if (value == null)
                    return;

                _selectedImeiDevice = value;

                RefreshImeiList();
                OnPropertyChanged();
            }
        }

        public string CustomImeiDevice
        {
            get => _customImeiDevice;
            set
            {
                if (value == null)
                    return;

                _customImeiDevice = value;

                RefreshImeiList();
                OnPropertyChanged();
            }
        }


        #region Commands
        public ICommand GenerateImeiCommand 
            => new Command(() => ImeiListDevice.Add(ImeiGenerator.Generate()));

        public ICommand RunCommand 
            => new Command(InitializeClient); 
        
        #endregion _Commands
        #endregion _Properties


        #region Methods
        public Task RefreshImeiList()
        {
            foreach (var item in ImeiListDevice)
            {
                item.IsActive = false;
            }

            SelectedImeiDevice.IsActive = true;

            return Task.CompletedTask;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeFields()
        {
            #region Initializing Fields with Default Values 
            IpAddressDevice = DependencyService.Get<IDevice>().GetIpAddressDevice();
            PortAddressDevice = TrackerTcpClient.PortAddressDeviceDefault;

            IpAddressHost = TrackerTcpClient.GetIpAddressDefault();
            PortAddressHost = TrackerTcpClient.PortAddressHostDefault;

            BufferSizeDevice = TrackerTcpClient.BufferSizeDefault;

            ImeiListDevice = new ObservableCollection<ImeiItem>(DependencyService.Get<IDevice>().GetImeiList())
            {
                #if ADDITIONAL_IMEIS || DEBUG
                "867567320091876",
                "777567320091876"
                #endif
            };

            SelectedImeiDevice = ImeiListDevice[0];
            #endregion
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeEventHandlers()
        {
            #region Get UI controls from an attached View
            var entry = PageView.FindByName<Entry>("CustomImeiDeviceEntry");
            var gridRow = PageView.FindByName<RowDefinition>("ImeisSettingGrid");
            #endregion


            entry.Completed += (_, e) =>
            {
                SelectedImeiDevice = CustomImeiDevice;
                ImeiListDevice.Add(CustomImeiDevice);
                entry.Text = string.Empty;
                entry.Placeholder = "Enter custom";
                gridRow.Height = new GridLength(gridRow.Height.Value + 64);
            };
        }


        private async void InitializeClient()
        {
            var client = new TrackerTcpClient()
                        .SetIpDevice(IpAddressDevice)
                        .SetPortDevice(PortAddressDevice)
                        .SetImeiDevice((string) SelectedImeiDevice)
                        .SetBufferSize(BufferSizeDevice)
                        .SetIpHost(IpAddressHost)
                        .SetPortHost(PortAddressHost)
                        .Create();

            var connectionViewModel = new ConnectionViewModel(new ConnectionView(), client)
            {
                Title = $"{++_connectionId}. {(string) SelectedImeiDevice}"
            };

            App.Pages.Add(connectionViewModel);
            connectionViewModel.PushPage();
            await Task.CompletedTask;
        }
        #endregion
    }
}