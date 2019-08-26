#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 19.08.2019 12:19
#endregion

using Xamarin.Forms;

namespace TrackerEmulator.ViewModels.Pages
{
    public class Page3ViewModel : BasePageViewModel
    {
        #region Constants
        public const string TitleDefault = "App Settings";
        #endregion


        #region Constructors
        public Page3ViewModel(Page page) : base(page)
        {
            Title = TitleDefault;
        }
        #endregion


        #region Properties
        #endregion
    }
}
