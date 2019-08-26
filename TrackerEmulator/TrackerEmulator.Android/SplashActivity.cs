using Android.App;
using Android.Support.V7.App;

namespace TrackerEmulator.Droid
{
    [Activity(
        Label = "Тracker Emulator",
        Icon = "@drawable/icon",
        Theme = "@style/splashscreen",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        #region Methods
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
        #endregion
    }
}
