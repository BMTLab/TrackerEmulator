//      TrackerEmulator.TrackerEmulator
//      Created by Nikita Neverov at 28.08.2019 11:14

using System.Collections.Generic;
using TrackerEmulator.Entites;

namespace TrackerEmulator.Models
{
    public interface IDevice
    {
        IList<ImeiItem> GetImeiList();
    }
}
