using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketMaster.Utilities
{
    internal class AuggerClient
    {
        private TcpClient TcpClient;
        private int Port { get; set; }
        private readonly string IpAddress;
        public bool IsConnected => TcpClient.Connected;

        // A singleton Class
        private static AuggerClient instance;

        public static AuggerClient Instance()
        {
            if (instance == null)
            {
                instance = new AuggerClient();
            }
            return instance;
        }

        private AuggerClient()
        {
            TcpClient = new TcpClient();
        }

        public void ConnectToServer(string serverAddress, int port)
        {
            if (IsConnected)
                return;
            else
                try
                {
                    TcpClient.Connect(serverAddress, port);
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occurred: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        public void SendMessage(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            TcpClient.GetStream().Write(data, 0, data.Length);
        }

        public string ReceiveMessage()
        {
            byte[] data = new byte[1024];
            TcpClient.GetStream().Read(data, 0, data.Length);
            return Encoding.ASCII.GetString(data);
        }

        public void Disconnect()
        {
            TcpClient.Close();
        }

        public void Close()
        {
            TcpClient = null;
        }
    }
}
