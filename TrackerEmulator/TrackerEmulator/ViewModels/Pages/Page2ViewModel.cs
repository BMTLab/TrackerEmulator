#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 19.08.2019 12:19
#endregion

using System.ComponentModel.DataAnnotations;
using System.Net;
using TrackerEmulator.Models;
using Xamarin.Forms;

namespace TrackerEmulator.ViewModels.Pages
{
    public class Page2ViewModel : BasePageViewModel
    {
        #region Constants
        public const string TitleDefault = "Host Settings";
        #endregion


        #region Fields
        private IPAddress _ipAddressHost;
        private ushort _portAddressHost;
        private TrackerTcpClient _trackerClient;
        #endregion


        #region Constructors
        public Page2ViewModel(Page page) : base(page)
        {
            Title = TitleDefault;
        }
        #endregion


        #region Properties
        [Required]
        public TrackerTcpClient TrackerClient
        {
            get => _trackerClient;
            set
            {
                if (value == null) return;
                _trackerClient = value;
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
        #endregion


        #region Methods
        #endregion
    }
}
