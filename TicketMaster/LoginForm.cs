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
using TicketMaster.Controllers;
using TicketMaster.Properties;
using TicketMaster.Utilities;


namespace TicketMaster
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
            AuggerClient.Instance().ConnectionStatusChanged += Client_ConnectionStatusChanged;

            if (Settings.Default.Save_username)
            {
                saveUsernameCheckBox.Checked = true;
                usernameTextBox.Text = Settings.Default.Saved_username;
            }
        }

        private void Client_ConnectionStatusChanged(object sender, EventArgs e)
        {
            var client = AuggerClient.Instance();
            if (client.IsConnected)
            {
                EnableButtons(true);
            }
            else
            {
                EnableButtons(false);
            }
        }


        /////////////////// Button Clicks ///////////////////

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            // TODO: idk, make these flash a color or something cool instead of messageboxs
            if (usernameTextBox.Text == "")
            {
                MessageBox.Show("Missing Username");
                return;
            }
            if (passwordTextBox.Text == "")
            {
                MessageBox.Show("Missing Password");
                return;
            }

            EnableButtons(false); // prevent multiple clicks

            var client = AuggerClient.Instance();
            if (client.tcpClient.Connected)
            {
                // Save username
                if (Settings.Default.Save_username)
                {
                    Settings.Default.Saved_username = usernameTextBox.Text;
                    Settings.Default.Save();
                }
                SettingsFile.Save();

                var response = await new RequestHandler().LoginAsync(usernameTextBox.Text, passwordTextBox.Text);

                Console.WriteLine($"Client : Response From Server : '{response}'");

                if (response == "Success")
                {
                    SuccessfullLogin?.Invoke(this, EventArgs.Empty);
                    return;
                }
                else
                {
                    EnableButtons(true); // re-enable buttons if login failed
                }
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

        private void EnableButtons(bool state)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(EnableButtons), state);
            }
            else
            {
                loginButton.Enabled = state;
                usernameTextBox.Enabled = state;
                passwordTextBox.Enabled = state;
                saveUsernameCheckBox.Enabled = state;
            }
        }
    }
}
