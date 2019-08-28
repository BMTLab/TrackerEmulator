#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 19.08.2019 12:19
#endregion

using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        private static IList<ImeiItem> _imeiListDevice;

        private string _ipAdressDevice;
        private string _portAdressDevice;
        private ushort _bufferSizeDevice;
        private ImeiItem _imeiDevice;
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

            // Initialize source for IMEI list selection menu
            _imeiListDevice = new List<ImeiItem>(2);


            ImeiItem.ItemSelectedColor = new Color().Primary();
            ImeiItem.ItemNonSelectedColor = new Color().WhiteBackgroundColor();
            ImeiItem.ItemNonSelectedTextColor = new Color().DarkTextColor();
            ImeiItem.ItemSelectedTextColor = new Color().LightTextColor();
        }

        public Page1ViewModel(Page page) : base(page)
        {
            Title = TitleDefault;
            IpAdressDevice = TrackerClient.IpAdressDevice.ToString();
            PortAdressDevice = TrackerClient.PortAdressDevice.ToString();
            ImeiListDevice = DependencyService.Get<IDevice>().GetImeiList();
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

        public IList<ImeiItem> ImeiListDevice
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
            get => _imeiDevice;
            set
            {
                if (value == null)
                    return;

                //foreach (var imeiItems in ImeiListDevice)
                //{
                //    imeiItems.IsActive = false;
                //}

                //SelectedImeiDevice.IsActive = true;

                _imeiDevice = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
