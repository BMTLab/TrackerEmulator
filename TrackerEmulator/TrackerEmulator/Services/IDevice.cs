//      TrackerEmulator.TrackerEmulator
//      Created by Nikita Neverov at 28.08.2019 11:14

using System.Collections.Generic;
using System.Net;

using TrackerEmulator.Entites;


namespace TrackerEmulator.Services
{
    public interface IDevice
    {
        IEnumerable<ImeiItem> GetImeiList();
        IPAddress GetIpAddressDevice();

        //IEnumerable<int> GetAllFreePortList();
        //int GetAnyFreePort();
    }
}