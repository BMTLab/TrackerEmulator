using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TrackerEmulator.Models;
using TrackerEmulator.ViewModels.Navigation;
using TrackerEmulator.ViewModels.Pages;
using TrackerEmulator.Views.Pages;

using BaseThisNavigationPage = Xamarin.Forms.NavigationPage;
using ThisNavigationPage = TrackerEmulator.Views.Navigation.NavigationPage;

#if NLOG
using NLog;
#endif


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TrackerEmulator
{
    public partial class App : Application
    {
        #region Fields
        #if NLOG
        public static readonly Logger Log;
        #endif
        #endregion


        #region Properties
        public static ObservableCollection<BasePageViewModel> Pages { get; set; }
        #endregion


        #region Constructors
        static App()
        {
            #if NLOG
            Log = LogManager.GetCurrentClassLogger();
            Log.Info("Version: {0}", Environment.Version.ToString());
            Log.Info("OS: {0} \r\n", Environment.OSVersion.ToString());
            #endif
        }


        public App()
        {
            InitializeComponent();

            Pages = new ObservableCollection<BasePageViewModel>
            {
                new Page1ViewModel(new Page1()), new Page2ViewModel(new Page2()), new Page3ViewModel(new Page3())
            };

            MainPage = new MyMasterDetailPage
            {
                Master = new NavigationViewModel(new ThisNavigationPage()).CurrentNavigationPage,
                Detail = new BaseThisNavigationPage(Pages.First().PageView)
            };
        }
        #endregion
    }
}