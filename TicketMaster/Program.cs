using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketMaster.Utilities;
using TicketMaster.Properties;

namespace TicketMaster
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
                MasterForm masterForm = new MasterForm();

                loginForm.Hide();
                masterForm.ShowDialog();
                loginForm.Close();

            };

            Application.Run(loginForm);
        }
    }
}
