using System;


namespace TrackerEmulator.Models
{
    [Flags]
    public enum Status : byte
    {
        IpNotCorrect = 1,
        PortNotCorrect = 2,
        BufferSizeIsNotValid = 4,
        CapacityOfConnectionsIsNotValid = 8,
        ConcurencyLevelOfConnectionsIsNotValid = 16
    }
}