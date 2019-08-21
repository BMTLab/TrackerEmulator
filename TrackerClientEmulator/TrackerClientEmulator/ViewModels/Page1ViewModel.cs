#region HEADER
//    TrackerClientEmulator.TrackerClientEmulator
//    Created by Nikita Neverov at 19.08.2019 12:19
#endregion

using Xamarin.Forms;

namespace TrackerClientEmulator.ViewModels
{
    public class Page1ViewModel : BasePageViewModel
    {
        #region Constants
        public const string TitleDefault = "Connection Setting 1!";
        #endregion


        #region Constructors
        public Page1ViewModel(Page page) : base(page)
        {
            Title = TitleDefault;
        }
        #endregion


        #region Properties
        #endregion
    }
}
