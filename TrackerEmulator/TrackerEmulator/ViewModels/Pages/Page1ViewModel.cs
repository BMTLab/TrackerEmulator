#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 19.08.2019 12:19
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using TrackerEmulator.Entites;
using TrackerEmulator.Helpers.Extension;
using TrackerEmulator.Models;
using TrackerEmulator.Services;
using Xamarin.Forms;

namespace TrackerEmulator.ViewModels.Pages
{
    public class Page1ViewModel : BasePageViewModel
    {
        #region Constants
        public const string TitleDefault = "Device Settings";
        #endregion


        #region Fields
        private static IList<ushort> _bufferSizes;
        private static ObservableCollection<ImeiItem> _imeiListDevice;

        private IPAddress _ipAddressDevice;
        private ushort _portAddressDevice;

        private IPAddress _ipAddressHost;
        private ushort _portAddressHost;

        private ushort _bufferSizeDevice;

        private ImeiItem _selectedImeiDevice;
        private string _customImeiDevice;
        #endregion


        #region Constructors 
        static Page1ViewModel()
        {
            /* Initialize source for buffer size selection menu */
            const int n = 10;

            _bufferSizes = new List<ushort>(n);
            for (int i = 0; i < n; i++)
            {
                _bufferSizes.Add((ushort)(1 << i));
            }


            /* Initialize the appearance of the list */
            ImeiItem.ItemSelectedColor = new Color().Primary();
            ImeiItem.ItemNonSelectedColor = Color.Transparent;

            ImeiItem.ItemNonSelectedTextColor = new Color().DarkTextColor();
            ImeiItem.ItemSelectedTextColor = new Color().LightTextColor();

            ImeiItem.TextColorDefault = new Color().DarkTextColor();
        }

        public Page1ViewModel(Page page) : base(page)
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
        #endregion


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

        private Task InitializeFields()
        {
            #region Initializing Fields with Default Values 
            IpAddressDevice = DependencyService.Get<IDevice>().GetIpAddressDevice();
            PortAddressDevice = TrackerTcpClient.PortAddressDeviceDefault;

            IpAddressHost = TrackerTcpClient.GetIpAddressDefault();
            PortAddressHost = TrackerTcpClient.PortAddressHostDefault;

            BufferSizeDevice = TrackerTcpClient.BufferSizeDefault;

            ImeiListDevice = new ObservableCollection<ImeiItem>(DependencyService.Get<IDevice>().GetImeiList());
            SelectedImeiDevice = ImeiListDevice[0];
            #endregion

            return Task.CompletedTask;
        }

        private Task InitializeEventHandlers()
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
                gridRow.Height = new GridLength(gridRow.Height.Value + 40);
            };

            return Task.CompletedTask;
        }
        #endregion
    }
}
