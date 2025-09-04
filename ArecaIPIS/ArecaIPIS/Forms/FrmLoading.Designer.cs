
namespace ArecaIPIS.Forms
{
    partial class FrmLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoading));
            this.label1 = new System.Windows.Forms.Label();
            this.timerProgressBar = new System.Windows.Forms.Timer(this.components);
            this.PrgLoadiingBar = new System.Windows.Forms.ProgressBar();
            this.lblLaoding = new System.Windows.Forms.Label();
            this.PnlLoading = new System.Windows.Forms.Panel();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.BtnApplicationExit = new System.Windows.Forms.Button();
            this.btnMinize = new System.Windows.Forms.Button();
            this.PnlLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(325, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(745, 55);
            this.label1.TabIndex = 7;
            this.label1.Text = "Welcome to Areca IPIS Systems";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timerProgressBar
            // 
            this.timerProgressBar.Interval = 100000000;
            this.timerProgressBar.Tick += new System.EventHandler(this.timerProgressBar_Tick);
            // 
            // PrgLoadiingBar
            // 
            this.PrgLoadiingBar.Location = new System.Drawing.Point(138, 84);
            this.PrgLoadiingBar.Name = "PrgLoadiingBar";
            this.PrgLoadiingBar.Size = new System.Drawing.Size(422, 30);
            this.PrgLoadiingBar.TabIndex = 2;
            // 
            // lblLaoding
            // 
            this.lblLaoding.AutoSize = true;
            this.lblLaoding.BackColor = System.Drawing.Color.Transparent;
            this.lblLaoding.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaoding.ForeColor = System.Drawing.Color.White;
            this.lblLaoding.Location = new System.Drawing.Point(100, 18);
            this.lblLaoding.Name = "lblLaoding";
            this.lblLaoding.Size = new System.Drawing.Size(514, 37);
            this.lblLaoding.TabIndex = 3;
            this.lblLaoding.Text = "Please Wait Server Is Loading....";
            // 
            // PnlLoading
            // 
            this.PnlLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PnlLoading.Controls.Add(this.lblCountdown);
            this.PnlLoading.Controls.Add(this.lblLaoding);
            this.PnlLoading.Controls.Add(this.PrgLoadiingBar);
            this.PnlLoading.Location = new System.Drawing.Point(335, 159);
            this.PnlLoading.Name = "PnlLoading";
            this.PnlLoading.Size = new System.Drawing.Size(670, 190);
            this.PnlLoading.TabIndex = 6;
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.Location = new System.Drawing.Point(314, 131);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(32, 24);
            this.lblCountdown.TabIndex = 8;
            this.lblCountdown.Text = "30";
            // 
            // BtnApplicationExit
            // 
            this.BtnApplicationExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnApplicationExit.BackgroundImage")));
            this.BtnApplicationExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnApplicationExit.FlatAppearance.BorderSize = 0;
            this.BtnApplicationExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApplicationExit.Location = new System.Drawing.Point(1288, 12);
            this.BtnApplicationExit.Name = "BtnApplicationExit";
            this.BtnApplicationExit.Size = new System.Drawing.Size(23, 23);
            this.BtnApplicationExit.TabIndex = 85;
            this.BtnApplicationExit.UseVisualStyleBackColor = true;
            this.BtnApplicationExit.Click += new System.EventHandler(this.BtnApplicationExit_Click);
            // 
            // btnMinize
            // 
            this.btnMinize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinize.BackgroundImage")));
            this.btnMinize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinize.FlatAppearance.BorderSize = 0;
            this.btnMinize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinize.Location = new System.Drawing.Point(1255, 12);
            this.btnMinize.Name = "btnMinize";
            this.btnMinize.Size = new System.Drawing.Size(23, 23);
            this.btnMinize.TabIndex = 84;
            this.btnMinize.UseVisualStyleBackColor = true;
            this.btnMinize.Click += new System.EventHandler(this.btnMinize_Click);
            // 
            // FrmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1364, 513);
            this.Controls.Add(this.BtnApplicationExit);
            this.Controls.Add(this.btnMinize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PnlLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLoading";
            this.Text = "FrmLoading";
            this.Load += new System.EventHandler(this.FrmLoading_Load);
            this.PnlLoading.ResumeLayout(false);
            this.PnlLoading.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerProgressBar;
        private System.Windows.Forms.ProgressBar PrgLoadiingBar;
        private System.Windows.Forms.Label lblLaoding;
        private System.Windows.Forms.Panel PnlLoading;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Button BtnApplicationExit;
        private System.Windows.Forms.Button btnMinize;
    }
}