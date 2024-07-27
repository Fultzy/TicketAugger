using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using TicketServer.Utilities;

namespace TicketServer
{
    public partial class ServerForm : MaterialForm
    {

        public ServerForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            //StartServerButton.Click += StartServerButton_Click;
            StopServerButton.Click += StopServerButton_Click;
            RestartServerButton.Click += RestartServerButton_Click;

            AddNetworkAdaptersToList();
        }

        private void serverStatusLabel_Click(object sender, EventArgs e)
        {
            //StartTimedStatusUpdate();
        }

        public void UpdateServerStatus(Server server)
        {
            if (server.IsOnline == true)
            {
                serverStatusLabel.Text = "Online";
                serverIpLabel.Text = server.ServerEP.Address.ToString();
                serverPortLabel.Text = server.ServerEP.Port.ToString();
                
                if (true) // for debug => Server.Instance().TestSocket()
                {
                    OpenSocketLabel.Text = "Open? idk..";
                    //ClientCountLabel.Text = server.Clients.Count().ToString();
                    
                    PingLabel.Text = server.PingNetwork().ToString() + "ms";
                }
                else
                {
                    OpenSocketLabel.Text = "Closed";
                    ClientCountLabel.Text = "";

                    PingLabel.Text = "";
                }
                
                ShowServerButtons(true);
            }
            else
            {
                serverStatusLabel.Text = "Offline";
                serverIpLabel.Text = "";
                serverPortLabel.Text = "";

                ShowServerButtons(false);
            }
            
        }

        private async Task StartTimedStatusUpdate()
        {
            while (Server.Instance().IsOnline)
            {
                UpdateServerStatus(Server.Instance());
                await Task.Delay(1000);
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            ServerStatsCard.Visible = true;
            StartServerButton.Enabled = false;
            NetworkSelectionBox.Enabled = false;
            RestartServerButton.Enabled = false;
            StopServerButton.Enabled = false;
            
            serverStatusLabel.Text = "Starting...";

            var server = Server.Instance();
            server.Start();
            UpdateServerStatus(server);
        }

        private void StopServerButton_Click(object sender, EventArgs e)
        {
            ServerStatsCard.Visible = false;
            StopServerButton.Enabled = false;
            RestartServerButton.Enabled = false;
            NetworkSelectionBox.Enabled = true;

            PingLabel.Text = "";
            ClientCountLabel.Text = "";

            serverStatusLabel.Text = "Stopping...";
            var server = Server.Instance();
            server.Stop();
            UpdateServerStatus(server);

        }

        private void RestartServerButton_Click(object sender, EventArgs e)
        {
            RestartServerButton.Enabled = false;
            StopServerButton.Enabled = false;

            serverStatusLabel.Text = "Restarting...";
            var server = Server.Instance();
            server.Restart();
            UpdateServerStatus(server);

        }

        private void ShowServerButtons(bool isOnline)
        {
            if (isOnline)
            {
                StartServerButton.Visible = false;
                StartServerButton.Enabled = false;

                StopServerButton.Visible = true;
                StopServerButton.Enabled = true;

                RestartServerButton.Visible = true;
                RestartServerButton.Enabled = true;
            }
            else
            {
                StartServerButton.Visible = true;
                StartServerButton.Enabled = true;

                StopServerButton.Visible = false;
                StopServerButton.Enabled = false;

                RestartServerButton.Visible = false;
                RestartServerButton.Enabled = false;
            }
        }

        private void NetworkSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedAdapter = NetworkSelectionBox.SelectedItem.ToString();

            if (selectedAdapter != "") 
            {
                Server.Instance().SetAdapter(selectedAdapter);
                StartServerButton.Enabled = true;
            }
        }

        private void AddNetworkAdaptersToList()
        {
            NetworkSelectionBox.Items.Clear();
            NetworkSelectionBox.Items.AddRange(Server.Instance().GetNetworkAdapters());
        }

        private void PingButton_Click(object sender, EventArgs e)
        {
            Server server = Server.Instance();

            PingLabel.Text = "Pinging...";
            Task.Delay(200).Wait();

            PingLabel.Text = server.PingNetwork().ToString() + "ms";
            ClientCountLabel.Text = server.tcpClients.Count().ToString();
        }


    }

}
