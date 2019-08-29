using System;

namespace TrackerEmulator.Models
{
    [Flags]
    public enum Status : byte
    {
        IpNotCorrect = 1,
        PortNotCorrect = 1 << 1,
        BufferSizeIsNotValid = 1 << 2,
        CapacityOfConnectionsIsNotValid = 1 << 3,
        ConcurencyLevelOfConnectionsIsNotValid = 1 << 4
    }
}
