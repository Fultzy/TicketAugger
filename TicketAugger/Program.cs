﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketAugger.Models;
using TicketAugger.Properties;
using TicketAugger.Utilities;

namespace TicketAugger
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            SettingsFile.Apply();

            // Exmaple use:
            var settings = new Settings();
            var ip = settings.Server_ipaddress;
            var port = settings.Server_port;
            // MessageBox.Show(ip + ":" + port);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            LoginForm loginForm = new LoginForm();
            loginForm.SuccessfullLogin += (sender, e) =>
            {
                MainForm mainForm = new MainForm();

                loginForm.Hide();
                mainForm.ShowDialog();
                loginForm.Close();

            };

            Application.Run(loginForm);
        }

    }
}
