using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Plugin.LocalNotification;
using Plugin.LocalNotification.Platform.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace TrackerEmulator.Droid
{
    [Activity(
        Label = "Тracker Emulator",
        Icon = "@drawable/icon",
        Theme = "@style/MyTheme",
        MainLauncher = false,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        #region Methods
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            NotificationCenter.CreateNotificationChannel(
                new NotificationChannelRequest());

            LoadApplication(new App());
        }

        protected override void OnNewIntent(Intent intent)
        {
            NotificationCenter.NotifyNotificationTapped(intent);
            base.OnNewIntent(intent);
        }
        #endregion
    }
}
