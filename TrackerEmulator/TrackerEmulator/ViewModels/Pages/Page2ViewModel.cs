#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 19.08.2019 12:19
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using TrackerEmulator.Entites;
using TrackerEmulator.Helpers.Extension;
using TrackerEmulator.Models;
using Xamarin.Forms;
using static TrackerEmulator.App;

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
        #endregion


        #region Constructors
        public Page2ViewModel(Page page) : base(page)
        {
            Title = TitleDefault;

            IpAddressHost = TrackerTcpClient.GetIpAddressDefault();
            PortAddressHost = TrackerTcpClient.PortAddressHostDefault;
        }
        #endregion


        #region Properties
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
    }
}
