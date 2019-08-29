using Android.Content;
using Android.Telephony;
using TrackerEmulator.Droid.Services;
using TrackerEmulator.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDevice))]

namespace TrackerEmulator.Droid.Services
{
    public partial class AndroidDevice : IDevice
    {
        #region Fields
        protected internal static readonly Context Context;
        protected internal readonly TelephonyManager MTelephonyMgr;

        #endregion


        #region Constructors
        static AndroidDevice()
        {
            Context = Android.App.Application.Context;
        }

        public AndroidDevice()
        {
            MTelephonyMgr = (TelephonyManager)Context.GetSystemService(Context.TelephonyService);
        }
        #endregion


        #region Methods
        #endregion

    }
}
