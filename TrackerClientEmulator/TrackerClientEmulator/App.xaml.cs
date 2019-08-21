using System;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NLog;

using TrackerClientEmulator.Models;
using TrackerClientEmulator.ViewModels;
using TrackerClientEmulator.Views;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TrackerClientEmulator
{
    public partial class App : Application
    {
        #region Fields
        public static readonly Logger Log;
        #endregion


        #region Constructors
        static App()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Info("Version: {0}", Environment.Version.ToString());
            Log.Info("OS: {0} \r\n", Environment.OSVersion.ToString());
        }
        
        public App()
        {
            InitializeComponent();

            Pages = new ObservableCollection<BasePageViewModel>
            {
                new Page1ViewModel(new Page1()),
                new Page2ViewModel(new Page2()),
                new Page3ViewModel(new Page3())
            };

            MainPage = new MyMasterDetailPage
            {
                Master = new NavigationViewModel(new Views.NavigationPage()).CurrentNavigationPage,
                Detail = new Xamarin.Forms.NavigationPage(Pages.First().PageView)
            };
        }
        #endregion


        #region Properties
        public static ObservableCollection<BasePageViewModel> Pages { get; set; }
        #endregion
    }
}
