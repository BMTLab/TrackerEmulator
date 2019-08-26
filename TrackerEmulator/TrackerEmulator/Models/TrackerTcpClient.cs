using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace TrackerEmulator.Models
{
    public class TrackerTcpClient : TcpClient
    {
        #region Constants
        public const ushort BufferSizeDefault = 64;
        public const ushort PortAdressDefault = 58;
        #endregion


        #region Fields
        protected internal Status ClientErrors = 0;
        #endregion


        #region Constructors
        public TrackerTcpClient() : base()
        {
            //IpAdressDevice = GetIpAddressDevice();
        }
        #endregion


        #region Properties

        public IPAddress IpAdressDevice { get; set; } = GetIpAddressDevice();
        public  ushort PortAdressDevice { get; set; } = PortAdressDefault;
        public  ushort BufferSizeDevice { get; set; } = BufferSizeDefault;

        #endregion


        #region Methods

        public static IPAddress GetIpAddressDevice() 
            => Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault();

        #region Methods.Configuration
        public TrackerTcpClient SetIp(string ipString)
        {
            if (!IPAddress.TryParse(ipString, out var ip))
                ClientErrors |= Status.IpNotCorrect;

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
        #endregion
    }
}