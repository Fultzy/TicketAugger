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
