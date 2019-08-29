using System.Net;
using System.Net.Sockets;

namespace TrackerEmulator.Models
{
    public class TrackerTcpClient : TcpClient
    {
        #region Constants
        public const ushort BufferSizeDefault = 64;
        public const ushort PortAddressDeviceDefault = 7;
        public const ushort PortAddressHostDefault = 4777;
        #endregion


        #region Fields
        protected internal Status ClientErrors = 0;
        #endregion


        #region Constructors
        #endregion


        #region Properties
        /* Device properties*/
        public IPAddress IpAdressDevice { get; set; } = GetIpAddressDefault();
        public ushort PortAdressDevice { get; set; } = PortAddressDeviceDefault;
        public ushort BufferSizeDevice { get; set; } = BufferSizeDefault;

        /* Host properties */
        public IPAddress IpAdressHost { get; set; } = GetIpAddressDefault();
        public ushort PortAdressHost { get; set; } = PortAddressHostDefault;
        #endregion


        #region Methods
        public static IPAddress GetIpAddressDefault()
            => IPAddress.Loopback;

        #region Methods.Configuration
        public TrackerTcpClient SetIpOrDomain(string domain)
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

            IpAdressDevice = ip;
            return this;
        }

        public TrackerTcpClient SetIp(IPAddress ip)
        {
            IpAdressDevice = ip;
            return this;
        }

        public TrackerTcpClient SetPort(ushort port)
        {
            PortAdressDevice = port;
            return this;
        }

        public TrackerTcpClient SetBufferSize(ushort bufferSize)
        {
            if (bufferSize < 4)
                ClientErrors |= Status.BufferSizeIsNotValid;

            BufferSizeDevice = bufferSize;
            return this;
        }
        #endregion

        public void Start()
        {
            //client.Connect(ipAddr, 4777);

            //try
            //{
            //    var stream = client.GetStream();

            //    while (true)
            //    {
            //        //Console.Write("\r\nInput your message: ");
            //        //var message = Console.ReadLine();

            //        //var data = Encoding.Unicode.GetBytes(message);
            //        //stream.Write(data, 0, data.Length);

            //        var data = new byte[BufferSize];
            //        var builder = new StringBuilder();
            //        do
            //        {
            //            var bytes = stream.Read(data, 0, data.Length);
            //            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            //        } while (stream.DataAvailable);

            //        var message = builder.ToString();
            //        Console.WriteLine("Server: {0}", message);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    client.Close();
            //}
        }

        /* GetActiveTcpConnections is not implemented exception on Android
        public int GetAnyFreePort()
        {
            var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            IList<int> portList = new List<int>(Enumerable
                                                .Range(1, ushort.MaxValue)
                                                .Except(tcpConnInfoArray
                                                        .Select(element => element.LocalEndPoint.Port)
                                                        .Distinct()
                                                        .ToList()));


            return portList[0];
        }
        */
        #endregion
    }
}
