﻿using System;
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

        }
        //todo create a settings.txt for this record. This would allow users to change the servers IP address. The problem with using hostname is if they use a different network adapter
        private void LoginButton_Click(object sender, EventArgs e)
        {
            AuggerClient.Instance().ConnectToServer("192.168.1.218", 5555);

            if (usernameTextBox.Text == "" && passwordTextBox.Text == "")
            {
                SuccessfullLogin?.Invoke(this, EventArgs.Empty);
            }
        }

        private void saveUsernameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (saveUsernameCheckBox.Checked)
            {
                //SaveUsername();
            }
            else
            {
                //ClearUsername();
            }
        }
    }
}
