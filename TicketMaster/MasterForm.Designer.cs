namespace TicketMaster
{
    partial class MasterForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.home = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.home);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(940, 592);
            this.materialTabControl1.TabIndex = 1;
            // 
            // home
            // 
            this.home.ImageKey = "home-32.png";
            this.home.Location = new System.Drawing.Point(4, 31);
            this.home.Name = "home";
            this.home.Padding = new System.Windows.Forms.Padding(3);
            this.home.Size = new System.Drawing.Size(932, 557);
            this.home.TabIndex = 0;
            this.home.Text = "Home";
            this.home.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "home-32.png");
            this.imageList1.Images.SetKeyName(1, "bar_chart-32.png");
            this.imageList1.Images.SetKeyName(2, "edit-32.png");
            this.imageList1.Images.SetKeyName(3, "presentation-32.png");
            this.imageList1.Images.SetKeyName(4, "dice-32.png");
            this.imageList1.Images.SetKeyName(5, "folder-32.png");
            this.imageList1.Images.SetKeyName(6, "shop-32.png");
            this.imageList1.Images.SetKeyName(7, "phone2-32.png");
            this.imageList1.Images.SetKeyName(8, "archive-32.png");
            this.imageList1.Images.SetKeyName(9, "contacts-32.png");
            this.imageList1.Images.SetKeyName(10, "copy-32.png");
            this.imageList1.Images.SetKeyName(11, "download2-32.png");
            this.imageList1.Images.SetKeyName(12, "help-32.png");
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 659);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Name = "MasterForm";
            this.Text = "TicketMaster";
            this.Load += new System.EventHandler(this.MasterForm_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage home;
        private System.Windows.Forms.ImageList imageList1;
    }
}