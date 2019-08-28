using System;
using System.Collections.Generic;
using Android.Content;
using Android.Telephony;
using TrackerEmulator.Droid.Services;
using TrackerEmulator.Entites;
using TrackerEmulator.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDevice))]

namespace TrackerEmulator.Droid.Services
{
    public class AndroidDevice : IDevice
    {
        #region Fields
        internal static readonly Context Context;
        private readonly TelephonyManager _mTelephonyMgr;
        private string _id = string.Empty;
        private IList<ImeiItem> _imeiList;
        #endregion


        #region Constructors
        static AndroidDevice()
        {
            Context = Android.App.Application.Context;
        }

        public AndroidDevice()
        {
            _mTelephonyMgr = (TelephonyManager)Context.GetSystemService(Context.TelephonyService);
        }
        #endregion


        #region Methods
        public IList<ImeiItem> GetImeiList()
        {
            _imeiList = new List<ImeiItem>(2);

            for (var i = 0; i < 4; i++)
            {
                if (!string.IsNullOrWhiteSpace(_mTelephonyMgr.GetImei(i)))
                    _imeiList.Add(_mTelephonyMgr.GetImei(i));
            }

            return _imeiList;
        }
        #endregion
    }
}
