using System.Collections.Generic;
using TrackerEmulator.Entites;
using TrackerEmulator.Models;

namespace TrackerEmulator.Droid.Services
{
    public partial class AndroidDevice
    {
        #region Fields
        private IList<ImeiItem> _imeiList;
        #endregion

        #region Methods
        public IEnumerable<ImeiItem> GetImeiList()
        {
            _imeiList = new List<ImeiItem>(2);

            var i = 0;

            while (!string.IsNullOrWhiteSpace(MTelephonyMgr.GetImei(i)))
            {
                _imeiList.Add(MTelephonyMgr.GetImei(i));
                i++;
            }

            return _imeiList;
        }
        #endregion

    }
}
