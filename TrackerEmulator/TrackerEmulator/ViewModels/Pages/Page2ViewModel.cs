#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 19.08.2019 12:19
#endregion


using TrackerEmulator.Models;

using Xamarin.Forms;


namespace TrackerEmulator.ViewModels.Pages
{
    public class Page2ViewModel : BasePageViewModel
    {
        #region Constants
        public const string TitleDefault = "Connection";
        #endregion


        #region Fields
        private TrackerTcpClient _trackerClient;
        #endregion


        #region Constructors
        public Page2ViewModel(Page page) : base(page)
        {
            Title = TitleDefault;
        }
        #endregion


        #region Properties
        public TrackerTcpClient TrackerClient
        {
            get => _trackerClient;
            set
            {
                if (value == null)
                    return;

                if (_trackerClient == value)
                    return;

                _trackerClient = value;
                OnPropertyChanged();
            }
        }
        #endregion


        #region Methods
        #endregion
    }
}
