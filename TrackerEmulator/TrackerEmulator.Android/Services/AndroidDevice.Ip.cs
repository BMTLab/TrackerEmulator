using System.Collections.Generic;
using System.Linq;
using System.Net;
using TrackerEmulator.Entites;
using TrackerEmulator.Models;

namespace TrackerEmulator.Droid.Services
{
    public partial class AndroidDevice
    {
        #region Methods
        public IPAddress GetIpAddressDevice()
            => Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault();
        #endregion
    }
}
