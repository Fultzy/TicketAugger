using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using TicketAugger.Properties;
using TicketAugger.Utilities;

namespace TicketAugger
{
    public partial class LoginForm : MaterialForm
    {

        public event EventHandler SuccessfullLogin;

        public LoginForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            loginButton.Click += LoginButton_Click;

            if (Settings.Default.Save_username)
            {
                saveUsernameCheckBox.Checked = true;
                usernameTextBox.Text = Settings.Default.Saved_username;
            }

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // TODO: idk, make these flash a color or something cool
            if (usernameTextBox.Text == "") { return; }
            if (passwordTextBox.Text == "") { return; }

            AuggerClient.Instance().ConnectToServer(Settings.Default.Server_ipaddress, Settings.Default.Server_port);

            // TODO: Verify username and password on server
            if (usernameTextBox.Text != "" && AuggerClient.Instance().IsConnected)
            {
                if (Settings.Default.Save_username)
                {
                    Settings.Default.Saved_username = usernameTextBox.Text;
                    Settings.Default.Save();
                }

                SettingsFile.Save();
                
                SuccessfullLogin?.Invoke(this, EventArgs.Empty);
            }
            else if (!AuggerClient.Instance().IsConnected)
            {
                //todo if no connection, open selectHostForm.cs
            }
        }

        private void saveUsernameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (saveUsernameCheckBox.Checked)
            {
                Settings.Default.Save_username = true;
            }
            else
            {
                Settings.Default.Save_username = false;
                Settings.Default.Saved_username = "";
            }
        }
    }
}
