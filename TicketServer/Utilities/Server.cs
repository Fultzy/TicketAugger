using System;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketServer.Properties;
using TicketServer.Controllers;
using System.Collections.Concurrent;


namespace TicketServer.Utilities
{
    public class Server
    {
        public string ServerAdapterName;
        public int Port;

        public bool IsOnline { get; private set; } = false;
        public IPEndPoint ServerEP;

        private TcpListener Listener;
        public readonly ConcurrentBag<TcpClient> tcpClients = new ConcurrentBag<TcpClient>();

        // Singleton instance
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
            Port = Settings.Default.Port;
            ServerEP = new IPEndPoint(IPAddress.Any, Port); // read off all IPs on the computer i guess? idk.
        }

        public Server Start()
        {
            if (string.IsNullOrEmpty(ServerAdapterName)) return this;

            Listener = new TcpListener(ServerEP);
            Listener.Start();
            IsOnline = true;

            Task.Run(BeginListening);
            return this;
        }

        public Server Stop()
        {
            IsOnline = false;
            Listener.Stop();
            return this;
        }

        public Server Restart()
        {
            Stop();
            Start();
            return this;
        }

        private async Task BeginListening()
        {
            while (IsOnline)
            {
                try
                {
                    TcpClient client = await Listener.AcceptTcpClientAsync();
                    tcpClients.Add(client);  // Keep track of the client
                    _ = HandleClient(client); // Handle asynchronously

                    if (client.Connected)
                    {
                        Console.WriteLine($"Server : Client connected : {tcpClients.Count}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Server : Error! : {ex.Message}");
                }
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                while (client.Connected) // loop until client is disconnected
                {
                    // Check for available data
                    if (stream.DataAvailable)
                    {
                        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            Console.WriteLine($"Server : Client disconnected gracefully.");
                            break; // Client has closed the connection
                        }

                        string request = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim('\0');
                        Console.WriteLine($"Server : Received : '{request}'"); // for debugging

                        var handler = new RequestHandler(request);
                        byte[] responseBytes = handler.GetResponseBytes();

                        await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
                    }
                    else
                    {
                        await Task.Delay(100); // Adjust as necessary
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Client Handling Error!\n {ex.Message}","Request Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                client.Close(); // Ensure the client is closed on completion or error
                Console.WriteLine("Server: Client connection closed.");
            }
        }


        ////////////////////// Network Utilities //////////////////////

        /// <summary>
        /// Get the current IPv4 address of the server and return it as a string
        /// </summary>
        /// <returns>A string representing an Ipv4 address</returns>
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

        /// <summary>
        /// Get a list of all network adapters
        /// </summary>
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

        /// <summary>
        /// Apply the selected network adapter to the server and create a new ServerEp
        /// </summary>
        /// <param name="adapterName"></param>
        public void SetAdapter(string adapterName)
        {
            ServerAdapterName = adapterName;
            ServerEP = new IPEndPoint(IPAddress.Parse(GetCurrentIPv4Address()), Port);
        }

        /// <summary>
        /// Ping the server to test the network connection
        /// </summary>
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

        /// <summary>
        /// Test the connection to the server
        /// </summary>
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