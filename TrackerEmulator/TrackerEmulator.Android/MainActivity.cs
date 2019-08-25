using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Locations;
using Android.OS;
using Java.Lang;
using Plugin.LocalNotification;
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
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            NotificationCenter.CreateNotificationChannel(
                new Plugin.LocalNotification.Platform.Droid.NotificationChannelRequest());

            LoadApplication(new App());
        }

        protected override void OnNewIntent(Intent intent)
        {
            NotificationCenter.NotifyNotificationTapped(intent);
            base.OnNewIntent(intent);
        }
    }
}