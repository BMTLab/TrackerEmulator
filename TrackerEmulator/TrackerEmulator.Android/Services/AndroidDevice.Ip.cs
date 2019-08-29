using System.Linq;
using System.Net;

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
