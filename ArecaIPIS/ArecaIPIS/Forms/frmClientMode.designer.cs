
namespace ArecaIPIS
{
    partial class frmClientMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientMode));
            this.lblWelcomeMsg = new System.Windows.Forms.Label();
            this.pictureBoxLoad = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnApplicationExit = new System.Windows.Forms.Button();
            this.btnMinize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoad)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcomeMsg
            // 
            this.lblWelcomeMsg.AutoSize = true;
            this.lblWelcomeMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeMsg.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeMsg.Location = new System.Drawing.Point(217, 72);
            this.lblWelcomeMsg.Name = "lblWelcomeMsg";
            this.lblWelcomeMsg.Size = new System.Drawing.Size(745, 55);
            this.lblWelcomeMsg.TabIndex = 5;
            this.lblWelcomeMsg.Text = "Welcome to Areca IPIS Systems";
            this.lblWelcomeMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxLoad
            // 
            this.pictureBoxLoad.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLoad.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLoad.Image")));
            this.pictureBoxLoad.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLoad.InitialImage")));
            this.pictureBoxLoad.Location = new System.Drawing.Point(151, 49);
            this.pictureBoxLoad.Name = "pictureBoxLoad";
            this.pictureBoxLoad.Size = new System.Drawing.Size(226, 179);
            this.pictureBoxLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLoad.TabIndex = 7;
            this.pictureBoxLoad.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBoxLoad);
            this.panel1.Location = new System.Drawing.Point(350, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 321);
            this.panel1.TabIndex = 9;
            // 
            // BtnApplicationExit
            // 
            this.BtnApplicationExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnApplicationExit.BackgroundImage")));
            this.BtnApplicationExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnApplicationExit.FlatAppearance.BorderSize = 0;
            this.BtnApplicationExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApplicationExit.Location = new System.Drawing.Point(1291, 12);
            this.BtnApplicationExit.Name = "BtnApplicationExit";
            this.BtnApplicationExit.Size = new System.Drawing.Size(23, 23);
            this.BtnApplicationExit.TabIndex = 83;
            this.BtnApplicationExit.UseVisualStyleBackColor = true;
            this.BtnApplicationExit.Click += new System.EventHandler(this.BtnApplicationExit_Click);
            // 
            // btnMinize
            // 
            this.btnMinize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinize.BackgroundImage")));
            this.btnMinize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinize.FlatAppearance.BorderSize = 0;
            this.btnMinize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinize.Location = new System.Drawing.Point(1258, 12);
            this.btnMinize.Name = "btnMinize";
            this.btnMinize.Size = new System.Drawing.Size(23, 23);
            this.btnMinize.TabIndex = 82;
            this.btnMinize.UseVisualStyleBackColor = true;
            this.btnMinize.Click += new System.EventHandler(this.btnMinize_Click);
            // 
            // frmClientMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 720);
            this.Controls.Add(this.BtnApplicationExit);
            this.Controls.Add(this.btnMinize);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWelcomeMsg);
            this.ForeColor = System.Drawing.Color.LightGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmClientMode";
            this.Text = "frmClientMode";
            this.Load += new System.EventHandler(this.frmClientMode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoad)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWelcomeMsg;
        private System.Windows.Forms.PictureBox pictureBoxLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnApplicationExit;
        private System.Windows.Forms.Button btnMinize;
    }
}