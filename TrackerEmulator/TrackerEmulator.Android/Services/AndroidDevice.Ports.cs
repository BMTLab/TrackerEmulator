using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace TrackerEmulator.Droid.Services
{
    public partial class AndroidDevice
    {
        #region Fields
        //private IList<int> _freePortsList;
        #endregion

        #region Methods
        //public IEnumerable<int> GetAllFreePortList()
        //{
        //    //_freePortsList = new List<int>(ushort.MaxValue - 64);
        //    //var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
        //    //TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
        //    //return Enumerable.Range(1, ushort.MaxValue)
        //    //                               .Except(tcpConnInfoArray
        //    //                                       .Select(element => element.LocalEndPoint.Port)
        //    //                                       .Distinct());




        //}

        //public int GetAnyFreePort()
        //{
        //    //var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
        //    //TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
        //    //IList<int> portList = new List<int>(Enumerable
        //    //                                    .Range(1, ushort.MaxValue)
        //    //                                              .Except(tcpConnInfoArray
        //    //                                                      .Select(element => element.LocalEndPoint.Port)
        //    //                                                      .Distinct()
        //    //                                                      .ToList()));


        //    return 0;
        //}
        #endregion
    }
}
