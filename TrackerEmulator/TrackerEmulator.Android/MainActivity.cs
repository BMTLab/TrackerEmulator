﻿using System.ComponentModel;
using Android.App;
using Android.Content.PM;
using Android.Locations;
using Android.OS;
using Java.Lang;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace TrackerEmulator.Droid
{
    [Activity(
        Label = "Тracker Emulator",
        Icon = "@drawable/icon",
        Theme = "@style/MyTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}