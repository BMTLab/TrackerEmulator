using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace TrackerEmulator.Models
{
    public class TrackerTcpClient : TcpClient, IValidatableObject
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
        public TrackerTcpClient(): base(AddressFamily.InterNetwork)
        {
        }
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
            => IPAddress.Parse("10.242.44.160");

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
            if (!IsEverythingGood())
                return this;

            SendBufferSize = ReceiveBufferSize = BufferSizeDevice;
            //Active = true;
            return this;
        }

        #endregion

        public async Task ConnectAsync()
        {
            //if (!Active) return;
            await ConnectAsync(IpAdressHost, PortAdressHost);
        }

        public void SendSelfInfo()
        {
            var message = ImeiDevice;
            var data = Encoding.Unicode.GetBytes(message);
            var stream = GetStream();
            if (stream.CanWrite)
                stream.Write(data, 0, data.Length);
            stream.Close();
        }

        public byte[] CreateBuffer()
        {
            return new byte[BufferSizeDevice];
        }

        public byte[] FromString(string message)
        {
            return Encoding.Unicode.GetBytes(message);
        }

        public string ToString(byte[] buffer, ushort bytes)
        {
            return Encoding.Unicode.GetString(buffer, 0, bytes);
        }

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
        // }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>(2);

            if (IsEverythingGood())
                return errors;

            if ((ClientErrors & Status.IpNotCorrect) != 0)
            {
                errors.Add(new ValidationResult("Ip not correct"));
                Console.Out.Write("Ip not correct");
            }

            if ((ClientErrors & Status.BufferSizeIsNotValid) != 0)
            {
                errors.Add(new ValidationResult("Buffer size is not valid"));
                Console.Out.Write("Buffer size is not valid");
            }

            return errors;
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

        private bool IsEverythingGood()
        {
            return (byte)ClientErrors == 0;

            //if ((ClientErrors & Status.IpNotCorrect) != 0)
            //    Console.Out.Write("Ip not correct");

            //if ((ClientErrors & Status.PortNotCorrect) != 0)
            //    Console.Out.Write("Port not correct");

            //if ((ClientErrors & Status.BufferSizeIsNotValid) != 0)
            //    Console.Out.Write("Buffer size is not valid");

            //if ((ClientErrors & Status.CapacityOfConnectionsIsNotValid) != 0)
            //    Console.Out.Write("Capacity of connections is not valid");

            //if ((ClientErrors & Status.ConcurencyLevelOfConnectionsIsNotValid) != 0)
            //    Console.Out.Write("Capacity of connections is not valid");
        }

        #endregion

    }
}
