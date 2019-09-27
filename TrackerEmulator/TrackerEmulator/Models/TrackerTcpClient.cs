using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace TrackerEmulator.Models
{
    public class TrackerTcpClient : TcpClient
    {
        #region Fields
        protected internal Status ClientErrors = 0;
        #endregion


        #region Constructors
        public TrackerTcpClient() : base(AddressFamily.InterNetwork)
        {
        }
        #endregion


        #region Constants
        public const ushort BufferSizeDefault = 64;
        public const ushort PortAddressDeviceDefault = 7;
        public const ushort PortAddressHostDefault = 44355;
        #endregion


        #region Properties
        /* Device properties*/
        public IPAddress IpAdressDevice { get; protected set; } = GetIpAddressDefault();
        public ushort PortAdressDevice { get; protected set; } = PortAddressDeviceDefault;
        public ushort BufferSizeDevice { get; protected set; } = BufferSizeDefault;
        public string ImeiDevice { get; protected set; }

        /* Host properties */
        public IPAddress IpAdressHost { get; protected set; } = GetIpAddressDefault();
        public ushort PortAdressHost { get; protected set; } = PortAddressHostDefault;
        #endregion


        #region Methods
        public static IPAddress GetIpAddressDefault()
            => IPAddress.Parse(App.IpAddressHostDefault);


        #region Methods.Configuration
        public TrackerTcpClient SetIpOrDomainHost(string domain)
        {
            if (!IPAddress.TryParse(domain, out var ip))
            {
                try
                {
                    ip = Dns.GetHostEntry(domain).AddressList[0];
                }
                catch
                {
                    ClientErrors |= Status.IpNotCorrect;

                    return this;
                }
            }

            IpAdressHost = ip;

            return this;
        }


        public TrackerTcpClient SetIpHost(IPAddress ip)
        {
            IpAdressHost = ip;

            return this;
        }


        public TrackerTcpClient SetIpDevice(IPAddress ip)
        {
            IpAdressDevice = ip;

            return this;
        }


        public TrackerTcpClient SetPortHost(ushort port)
        {
            PortAdressHost = port;

            return this;
        }


        public TrackerTcpClient SetPortDevice(ushort port)
        {
            PortAdressDevice = port;

            return this;
        }


        public TrackerTcpClient SetBufferSize(ushort bufferSize)
        {
            if (bufferSize < 1)
                ClientErrors |= Status.BufferSizeIsNotValid;

            BufferSizeDevice = bufferSize;

            return this;
        }


        public TrackerTcpClient SetImeiDevice(string imei)
        {
            ImeiDevice = imei;

            return this;
        }


        public TrackerTcpClient Create()
        {
            if (!Validate())
                return this;

            SendBufferSize = ReceiveBufferSize = BufferSizeDevice;
            Active = true;

            return this;
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] FromString(string message)
        {
            return Encoding.Unicode.GetBytes(message);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(byte[] buffer, ushort bytes)
        {
            return Encoding.Unicode.GetString(buffer, 0, bytes);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] CreateBuffer()
        {
            return new byte[BufferSizeDevice];
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async Task ConnectAsync()
        {
            try
            {
                await ConnectAsync(IpAdressHost, PortAdressHost);
            }
            catch (Exception ex)
            {
                App.SendNotification(ex.Message);
            }
        }


        public async Task SendSelfInfoAsync()
        {
            var sData = ImeiDevice;
            var bData = Encoding.Unicode.GetBytes(sData);

            NetworkStream stream = null;
            try
            {
                stream = GetStream();

                if (stream.CanWrite)
                    await stream.WriteAsync(bData, 0, bData.Length);
            }
            catch (Exception ex)
            {
                stream?.Close();
                App.SendNotification(ex.Message);
            }
        }
        

        private bool Validate()
        {
            if ((ClientErrors & Status.IpNotCorrect) != 0)
                App.SendNotification("Ip not correct");

            if ((ClientErrors & Status.PortNotCorrect) != 0)
                App.SendNotification("Port not correct");

            if ((ClientErrors & Status.BufferSizeIsNotValid) != 0)
                App.SendNotification("Buffer size is not valid");

            if ((ClientErrors & Status.CapacityOfConnectionsIsNotValid) != 0)
                App.SendNotification("Capacity of connections is not valid");

            if ((ClientErrors & Status.ConcurencyLevelOfConnectionsIsNotValid) != 0)
                App.SendNotification("Capacity of connections is not valid");

            return (byte) ClientErrors == 0;
        }
        #endregion
    }
}