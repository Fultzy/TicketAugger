using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketServer.Utilities;
using TicketServer.Properties;
using TicketServer.Utilities.Database;

namespace TicketServer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SettingsFile.Apply();

            LoginForm loginForm = new LoginForm();
            loginForm.SuccessfullLogin += (sender, e) =>
            {
                ServerForm serverForm = new ServerForm();

                loginForm.Hide();
                serverForm.ShowDialog();
                loginForm.Close();

            };

            

            Application.Run(new ServerForm());

        }
        
    }

}
