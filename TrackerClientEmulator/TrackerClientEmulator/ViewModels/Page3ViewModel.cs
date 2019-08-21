#region HEADER
//    TrackerClientEmulator.TrackerClientEmulator
//    Created by Nikita Neverov at 19.08.2019 12:19
#endregion

using Xamarin.Forms;

namespace TrackerClientEmulator.ViewModels
{
    public class Page3ViewModel : BasePageViewModel
    {
        #region Constants
        public const string TitleDefault = "Connection Setting 3!";
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
