#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 19.08.2019 12:19
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TrackerEmulator.Entites;
using TrackerEmulator.Helpers.Extension;
using TrackerEmulator.Models;
using Xamarin.Forms;
using static TrackerEmulator.App;

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

        private ushort _bufferSizeDevice ;
        private ImeiItem _selectedImeiDevice;
        private string _customImeiDevice;
        private string _ipAdressDevice;
        private string _portAdressDevice;
        #endregion


        #region Constructors 
        static Page1ViewModel()
        {
            // Initialize source for buffer size selection menu
            const int n = 10;

            _bufferSizes = new List<ushort>(n);
            for (int i = 0; i < n; i++)
            {
                _bufferSizes.Add((ushort)(1 << i));
            }

            ImeiItem.ItemSelectedColor = new Color().Primary();
            ImeiItem.ItemNonSelectedColor = Color.Transparent;
            ImeiItem.ItemNonSelectedTextColor = new Color().DarkTextColor();
            ImeiItem.ItemSelectedTextColor = new Color().LightTextColor();
            ImeiItem.TextColorDefault = new Color().DarkTextColor();
        }

        public Page1ViewModel(Page page) : base(page)
        {
            Title = TitleDefault;

            PortAdressDevice = TrackerClient.PortAdressDevice.ToString();
            BufferSizeDevice = TrackerClient.BufferSizeDevice;
            IpAdressDevice = DependencyService.Get<IDevice>().GetIpAddressDevice().ToString();
            ImeiListDevice = new ObservableCollection<ImeiItem>(DependencyService.Get<IDevice>().GetImeiList());
            SelectedImeiDevice = ImeiListDevice[0];

            var entry = PageView.FindByName<Entry>("CustomImeiDeviceEntry");
            var gridRow = PageView.FindByName<RowDefinition>("ImeisSettingGrid");

            entry.Completed += (_, e) =>
            {
                SelectedImeiDevice = CustomImeiDevice;
                ImeiListDevice.Add(CustomImeiDevice);
                entry.Text = string.Empty;
                entry.Placeholder = "Enter custom";
                gridRow.Height = new GridLength(gridRow.Height.Value + 40);
            };
        }
        #endregion


        #region Properties
        public IList<ushort> BufferSizes
        {
            get => _bufferSizes;
            set
            {
                _bufferSizes = value;
                OnPropertyChanged();
            }

        }
        public string IpAdressDevice
        {
            get => _ipAdressDevice;
            set
            {
                if (value == null)
                    return;

                _ipAdressDevice = value;
                OnPropertyChanged();
            }
        }

        public string PortAdressDevice
        {
            get => _portAdressDevice;
            set
            {
                if (value == null)
                    return;

                _portAdressDevice = value;
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
        #endregion
    }
}
