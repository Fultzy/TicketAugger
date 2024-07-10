using System;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using TicketAugger.Utilities.Logger;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Linq;

namespace TicketServer.Utilities
{
    public class Server
    {
        public readonly string ServerName;
        public string ServerAdapterName;
        public int Port;

        public bool IsOnline = false;

        public IPEndPoint ServerEP;
        private TcpListener Listener;

        public IEnumerable<TcpClient> Clients { get; private set; }
        
        
        // A singleton Class
        private static Server instance;

        public static Server Instance()
        {
            if (instance == null)
            {
                instance = new Server();
            }
            return instance;
        }

        private Server()
        {
            Port = 5555;
            Clients = new List<TcpClient>();
        }



        public Server StartServer()
        {
            SetAdapter(ServerAdapterName);
            Listener = new TcpListener(ServerEP);
            Listener.Start();

            StartHeartbeat();

            IsOnline = true;
            Task.Delay(800).Wait();

            return this;
        }

        public Server StopServer()
        {
            IsOnline = false;
            Listener.Stop();

            
            ServerEP = null;


            Task.Delay(800).Wait();

            return this;
        }

        public Server RestartServer()
        {
            StopServer();
            StartServer();

            return this;
        }

        private void StartHeartbeat()
        {
            Task.Run(() =>
            {
                while (IsOnline)
                {
                    try
                    {
                        TcpClient client = Listener.AcceptTcpClient();
                        Clients.Append(client);
                        
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("An error occurred: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            });
        }



        public string GetCurrentIPv4Address()
        {
            string ipAddress = string.Empty;
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up && networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback && networkInterface.Name == ServerAdapterName)
                {
                    IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
                    foreach (UnicastIPAddressInformation ipAddressInfo in ipProperties.UnicastAddresses)
                    {
                        if (ipAddressInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipAddress = ipAddressInfo.Address.ToString();
                            break;
                        }
                    }
                }
            }

            return ipAddress;
        }

        public object[] GetNetworkAdapters()
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            List<object> networkList = new List<object>();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up && networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
                    foreach (UnicastIPAddressInformation ipAddressInfo in ipProperties.UnicastAddresses)
                    {
                        if (ipAddressInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            networkList.Add(networkInterface.Name);
                            break;
                        }
                    }
                }
            }

            return networkList.ToArray();
        }

        public void SetAdapter(string adapterName)
        {
            ServerAdapterName = adapterName;
            ServerEP = new IPEndPoint(IPAddress.Parse(GetCurrentIPv4Address()), Port);
        }

        public int PingNetwork()
        {
            var ms = 0;

            if (ServerEP == null) return ms;

            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(ServerEP.Address, ServerEP.Port);
                ms = (int)reply.RoundtripTime;
            }
            catch (Exception ex)
            {
                Logger.Debugging(ex.Message);
            }

            return ms;
        }

        public bool SocketTest()
        {
            
            try
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    tcpClient.Connect(ServerEP.Address, ServerEP.Port);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    
    }
}