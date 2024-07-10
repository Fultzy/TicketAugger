namespace TicketServer
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.StartServerButton = new MaterialSkin.Controls.MaterialButton();
            this.RestartServerButton = new MaterialSkin.Controls.MaterialButton();
            this.StopServerButton = new MaterialSkin.Controls.MaterialButton();
            this.serverPortLabel = new MaterialSkin.Controls.MaterialLabel();
            this.serverIpLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.serverStatusLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.ClientCountLabel = new MaterialSkin.Controls.MaterialLabel();
            this.NetworkSelectionBox = new MaterialSkin.Controls.MaterialComboBox();
            this.ServerStatsCard = new MaterialSkin.Controls.MaterialCard();
            this.PingButton = new MaterialSkin.Controls.MaterialButton();
            this.PingLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.OpenSocketLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialCard1.SuspendLayout();
            this.ServerStatsCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.StartServerButton);
            this.materialCard1.Controls.Add(this.RestartServerButton);
            this.materialCard1.Controls.Add(this.StopServerButton);
            this.materialCard1.Controls.Add(this.serverPortLabel);
            this.materialCard1.Controls.Add(this.serverIpLabel);
            this.materialCard1.Controls.Add(this.materialLabel4);
            this.materialCard1.Controls.Add(this.materialLabel3);
            this.materialCard1.Controls.Add(this.serverStatusLabel);
            this.materialCard1.Controls.Add(this.materialLabel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(17, 78);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(338, 166);
            this.materialCard1.TabIndex = 0;
            // 
            // StartServerButton
            // 
            this.StartServerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartServerButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.StartServerButton.Depth = 0;
            this.StartServerButton.Enabled = false;
            this.StartServerButton.HighEmphasis = true;
            this.StartServerButton.Icon = null;
            this.StartServerButton.Location = new System.Drawing.Point(196, 115);
            this.StartServerButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.StartServerButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.StartServerButton.Size = new System.Drawing.Size(124, 36);
            this.StartServerButton.TabIndex = 1;
            this.StartServerButton.Text = "Start Server";
            this.StartServerButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.StartServerButton.UseAccentColor = true;
            this.StartServerButton.UseVisualStyleBackColor = true;
            this.StartServerButton.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // RestartServerButton
            // 
            this.RestartServerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RestartServerButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.RestartServerButton.Depth = 0;
            this.RestartServerButton.HighEmphasis = true;
            this.RestartServerButton.Icon = null;
            this.RestartServerButton.Location = new System.Drawing.Point(142, 115);
            this.RestartServerButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RestartServerButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.RestartServerButton.Name = "RestartServerButton";
            this.RestartServerButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.RestartServerButton.Size = new System.Drawing.Size(84, 36);
            this.RestartServerButton.TabIndex = 9;
            this.RestartServerButton.Text = "Restart";
            this.RestartServerButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.RestartServerButton.UseAccentColor = true;
            this.RestartServerButton.UseVisualStyleBackColor = true;
            this.RestartServerButton.Visible = false;
            // 
            // StopServerButton
            // 
            this.StopServerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StopServerButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.StopServerButton.Depth = 0;
            this.StopServerButton.HighEmphasis = true;
            this.StopServerButton.Icon = null;
            this.StopServerButton.Location = new System.Drawing.Point(18, 115);
            this.StopServerButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.StopServerButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.StopServerButton.Name = "StopServerButton";
            this.StopServerButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.StopServerButton.Size = new System.Drawing.Size(116, 36);
            this.StopServerButton.TabIndex = 8;
            this.StopServerButton.Text = "Stop Server";
            this.StopServerButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.StopServerButton.UseAccentColor = false;
            this.StopServerButton.UseVisualStyleBackColor = true;
            this.StopServerButton.Visible = false;
            this.StopServerButton.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // serverPortLabel
            // 
            this.serverPortLabel.AutoSize = true;
            this.serverPortLabel.Depth = 0;
            this.serverPortLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.serverPortLabel.Location = new System.Drawing.Point(123, 86);
            this.serverPortLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.serverPortLabel.Name = "serverPortLabel";
            this.serverPortLabel.Size = new System.Drawing.Size(1, 0);
            this.serverPortLabel.TabIndex = 7;
            // 
            // serverIpLabel
            // 
            this.serverIpLabel.AutoSize = true;
            this.serverIpLabel.Depth = 0;
            this.serverIpLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.serverIpLabel.Location = new System.Drawing.Point(123, 67);
            this.serverIpLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.serverIpLabel.Name = "serverIpLabel";
            this.serverIpLabel.Size = new System.Drawing.Size(1, 0);
            this.serverIpLabel.TabIndex = 6;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(83, 86);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(34, 19);
            this.materialLabel4.TabIndex = 5;
            this.materialLabel4.Text = "Port:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(38, 67);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(79, 19);
            this.materialLabel3.TabIndex = 4;
            this.materialLabel3.Text = "Ip Address:";
            // 
            // serverStatusLabel
            // 
            this.serverStatusLabel.AutoSize = true;
            this.serverStatusLabel.Depth = 0;
            this.serverStatusLabel.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.serverStatusLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.serverStatusLabel.Location = new System.Drawing.Point(173, 18);
            this.serverStatusLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.serverStatusLabel.Name = "serverStatusLabel";
            this.serverStatusLabel.Size = new System.Drawing.Size(84, 29);
            this.serverStatusLabel.TabIndex = 1;
            this.serverStatusLabel.Text = "Offline..";
            this.serverStatusLabel.Click += new System.EventHandler(this.serverStatusLabel_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel1.Location = new System.Drawing.Point(18, 18);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(149, 29);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Server Status:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(17, 39);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(91, 19);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "Client Count:";
            // 
            // ClientCountLabel
            // 
            this.ClientCountLabel.AutoSize = true;
            this.ClientCountLabel.Depth = 0;
            this.ClientCountLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientCountLabel.Location = new System.Drawing.Point(114, 39);
            this.ClientCountLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.ClientCountLabel.Name = "ClientCountLabel";
            this.ClientCountLabel.Size = new System.Drawing.Size(19, 19);
            this.ClientCountLabel.TabIndex = 3;
            this.ClientCountLabel.Text = "na";
            // 
            // NetworkSelectionBox
            // 
            this.NetworkSelectionBox.AutoResize = false;
            this.NetworkSelectionBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NetworkSelectionBox.Depth = 0;
            this.NetworkSelectionBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.NetworkSelectionBox.DropDownHeight = 174;
            this.NetworkSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NetworkSelectionBox.DropDownWidth = 121;
            this.NetworkSelectionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.NetworkSelectionBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NetworkSelectionBox.FormattingEnabled = true;
            this.NetworkSelectionBox.Hint = "Network Adaptor";
            this.NetworkSelectionBox.IntegralHeight = false;
            this.NetworkSelectionBox.ItemHeight = 43;
            this.NetworkSelectionBox.Location = new System.Drawing.Point(372, 78);
            this.NetworkSelectionBox.MaxDropDownItems = 4;
            this.NetworkSelectionBox.MouseState = MaterialSkin.MouseState.OUT;
            this.NetworkSelectionBox.Name = "NetworkSelectionBox";
            this.NetworkSelectionBox.Size = new System.Drawing.Size(411, 49);
            this.NetworkSelectionBox.StartIndex = 0;
            this.NetworkSelectionBox.TabIndex = 9;
            this.NetworkSelectionBox.SelectedIndexChanged += new System.EventHandler(this.NetworkSelectionBox_SelectedIndexChanged);
            // 
            // ServerStatsCard
            // 
            this.ServerStatsCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ServerStatsCard.Controls.Add(this.OpenSocketLabel);
            this.ServerStatsCard.Controls.Add(this.materialLabel6);
            this.ServerStatsCard.Controls.Add(this.PingButton);
            this.ServerStatsCard.Controls.Add(this.PingLabel);
            this.ServerStatsCard.Controls.Add(this.materialLabel5);
            this.ServerStatsCard.Controls.Add(this.materialLabel2);
            this.ServerStatsCard.Controls.Add(this.ClientCountLabel);
            this.ServerStatsCard.Depth = 0;
            this.ServerStatsCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ServerStatsCard.Location = new System.Drawing.Point(372, 144);
            this.ServerStatsCard.Margin = new System.Windows.Forms.Padding(14);
            this.ServerStatsCard.MouseState = MaterialSkin.MouseState.HOVER;
            this.ServerStatsCard.Name = "ServerStatsCard";
            this.ServerStatsCard.Padding = new System.Windows.Forms.Padding(14);
            this.ServerStatsCard.Size = new System.Drawing.Size(411, 100);
            this.ServerStatsCard.TabIndex = 10;
            this.ServerStatsCard.Visible = false;
            // 
            // PingButton
            // 
            this.PingButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PingButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.PingButton.Depth = 0;
            this.PingButton.HighEmphasis = true;
            this.PingButton.Icon = null;
            this.PingButton.Location = new System.Drawing.Point(329, 9);
            this.PingButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PingButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.PingButton.Name = "PingButton";
            this.PingButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.PingButton.Size = new System.Drawing.Size(64, 36);
            this.PingButton.TabIndex = 2;
            this.PingButton.Text = "Ping";
            this.PingButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.PingButton.UseAccentColor = false;
            this.PingButton.UseVisualStyleBackColor = true;
            this.PingButton.Click += new System.EventHandler(this.PingButton_Click);
            // 
            // PingLabel
            // 
            this.PingLabel.AutoSize = true;
            this.PingLabel.Depth = 0;
            this.PingLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PingLabel.Location = new System.Drawing.Point(114, 9);
            this.PingLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.PingLabel.Name = "PingLabel";
            this.PingLabel.Size = new System.Drawing.Size(19, 19);
            this.PingLabel.TabIndex = 1;
            this.PingLabel.Text = "na";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(71, 9);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(37, 19);
            this.materialLabel5.TabIndex = 0;
            this.materialLabel5.Text = "Ping:";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(23, 67);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(85, 19);
            this.materialLabel6.TabIndex = 4;
            this.materialLabel6.Text = "Connection:";
            // 
            // OpenSocketLabel
            // 
            this.OpenSocketLabel.AutoSize = true;
            this.OpenSocketLabel.Depth = 0;
            this.OpenSocketLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.OpenSocketLabel.Location = new System.Drawing.Point(114, 67);
            this.OpenSocketLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.OpenSocketLabel.Name = "OpenSocketLabel";
            this.OpenSocketLabel.Size = new System.Drawing.Size(19, 19);
            this.OpenSocketLabel.TabIndex = 5;
            this.OpenSocketLabel.Text = "na";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ServerStatsCard);
            this.Controls.Add(this.NetworkSelectionBox);
            this.Controls.Add(this.materialCard1);
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ServerStatsCard.ResumeLayout(false);
            this.ServerStatsCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        public MaterialSkin.Controls.MaterialLabel serverStatusLabel;
        private MaterialSkin.Controls.MaterialLabel ClientCountLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel serverPortLabel;
        private MaterialSkin.Controls.MaterialLabel serverIpLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton StopServerButton;
        private MaterialSkin.Controls.MaterialButton StartServerButton;
        private MaterialSkin.Controls.MaterialButton RestartServerButton;
        private MaterialSkin.Controls.MaterialComboBox NetworkSelectionBox;
        private MaterialSkin.Controls.MaterialCard ServerStatsCard;
        private MaterialSkin.Controls.MaterialLabel PingLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialButton PingButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel OpenSocketLabel;
    }
}

