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
    public class Page2ViewModel : BasePageViewModel
    {
        #region Constants
        public const string TitleDefault = "Host Settings";
        #endregion


        #region Fields
        private string _ipAdressHost;
        private string _portAdressHost;
        #endregion


        #region Constructors
        public Page2ViewModel(Page page) : base(page)
        {
            Title = TitleDefault;

            IpAdressHost = TrackerClient.IpAdressDevice.ToString();
            PortAdressHost = TrackerClient.PortAdressDevice.ToString();
        }
        #endregion


        #region Properties
        public string IpAdressHost
        {
            get => _ipAdressHost;
            set
            {
                if (value == null)
                    return;

                _ipAdressHost = value;
                OnPropertyChanged();
            }
        }

        public string PortAdressHost
        {
            get => _portAdressHost;
            set
            {
                if (value == null)
                    return;

                _portAdressHost = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
