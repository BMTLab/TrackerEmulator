#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 19.08.2019 12:19
#endregion

using TrackerEmulator.Controls;
using TrackerEmulator.Models;
using Xamarin.Forms;

namespace TrackerEmulator.ViewModels.Pages
{
    public class Page1ViewModel : BasePageViewModel
    {
        #region Constants
        public const string TitleDefault = "Device Settings";
        #endregion

        #region Fields

        private string _ipAdressDevice;
        private string _portAdressDevice;
        private string _bufferSizeDevice;
        private ContentView _popupMenu;
        #endregion


        #region Constructors
        public Page1ViewModel(Page page) : base(page)
        {
            Title = TitleDefault;
            IpAdressDevice = App.TrackerClient.IpAdressDevice.ToString();
            PortAdressDevice = App.TrackerClient.PortAdressDevice.ToString();
            BufferSizeDevice = App.TrackerClient.BufferSizeDevice.ToString();
            PopupMenu = new PopupMenuIp();
        }
        #endregion


        #region Properties

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

        public string BufferSizeDevice
        {
            get => _bufferSizeDevice;
            set
            {
                if (value == null)
                    return;

                _bufferSizeDevice = value;
                OnPropertyChanged();
            }
        }

        public ContentView PopupMenu
        {
            get => _popupMenu;
            set
            {
                if (value == null)
                    return;

                _popupMenu = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
