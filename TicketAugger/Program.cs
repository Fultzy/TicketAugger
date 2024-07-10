using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketAugger.Models;

namespace TicketAugger
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //Todo Ask for the hostname, or IP upon first launch. Write to a settings.txt file, and pull this info from there going forward
            //todo if settings.txt exists, skip selectHostForm.cs



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
