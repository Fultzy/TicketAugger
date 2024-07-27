using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketMaster.Properties;

namespace TicketMaster.Utilities
{
    internal class AuggerClient : IDisposable
    {
        public TcpClient tcpClient;
        private NetworkStream _stream;

        public bool IsConnected = false;
        public bool IsConnecting = false;

        public event EventHandler ConnectionStatusChanged;


        // A Singleton Class
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
            _ = StartHeartbeat();

        }


        private async Task<bool> StartConnecting()
        {
            tcpClient = new TcpClient();
            IsConnecting = false;

            while (!IsConnected)
            {
                try
                {
                    await Task.Delay(800);
                    if (!IsConnecting) // Check if connection is already in progress
                    {
                        IsConnecting = true;
                        await tcpClient.ConnectAsync(Settings.Default.Server_ipaddress, Settings.Default.Server_port);

                        Console.WriteLine("Client : Connected to the server.");
                        IsConnected = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Client : Connection failed : {e.Message}");
                    IsConnected = false;
                }
                finally
                {
                    IsConnecting = false;
                }

                await Task.Delay(2000);
            }

            OnConnectionStatusChanged();
            return IsConnected;
        }


        /////////////////// Communication Methods ///////////////////
        public async Task SendRequestAsync(string request)
        {
            if (!IsConnected)
                throw new InvalidOperationException("Not connected to the server.");

            if (_stream == null)
                _stream = tcpClient.GetStream();

            byte[] data = Encoding.ASCII.GetBytes(request + "\0");
            await _stream.WriteAsync(data, 0, data.Length);
        }

        public async Task<string> GetResponseAsync()
        {
            if (!IsConnected)
                throw new InvalidOperationException("Not connected to the server.");

            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);

                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim('\0');
                Console.WriteLine($"Client : Received : '{response}'");
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Get Response Error!\n {ex.Message}", "Response Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _stream?.Dispose();
            return "Invalid Response";
        }


        /////////////////// Connection Monitor ///////////////////
        private async Task StartHeartbeat()
        {
            while (true)
            {
                if (IsConnecting)
                {
                    await Task.Delay(1000); // Finish attempt
                    continue;
                }
                if (!IsConnected) // try connecting
                {
                    await StartConnecting();
                }

                string response = "";
                try // Send a heartbeat request to the server
                {
                    await SendRequestAsync("PING");
                    response = await GetResponseAsync();
                    response = response.Trim('\0');
                    if (response != "PONG")
                    {
                        Console.WriteLine($"Client : HeartBeat Failed : response = '{response}'");
                        OnConnectionLost();
                    }
                }
                catch (Exception ex) // Connection lost with Error
                {
                    MessageBox.Show($"HeartBeat Error!\n Response: '{response}' \n{ex.Message}", "Response Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                Console.WriteLine($"Client : Heartbeat.. : {StatusString()}");
                await Task.Delay(5000);
            }
        }

        private void OnConnectionStatusChanged()
        {
            ConnectionStatusChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnConnectionLost()
        {
            IsConnected = false;
            Dispose();

            OnConnectionStatusChanged();
        }

        public void Dispose()
        {
            _stream?.Dispose();
            tcpClient?.Dispose();
            _stream = null;
        }

        public string StatusString()
        {
            var connection = IsConnected ? "Connected" : "Disconnected";
            var connecting = IsConnecting ? "Currently Connecting" : "Not Currently Connecting";
            var tcp = tcpClient.Connected ? "TCP Connected" : "TCP Disconnected";
            var stream = _stream == null ? "Stream Closed" : "Stream Open";

            return $"Client Status = {connection} | {connecting} | {tcp} | {stream}";
        }
    }
}
