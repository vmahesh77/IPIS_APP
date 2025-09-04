
namespace ArecaIPIS.Forms
{
    partial class frmLoginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginPage));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnApplicationExit = new System.Windows.Forms.Button();
            this.btnMinize = new System.Windows.Forms.Button();
            this.panLogin = new ArecaIPIS.MyControls.RoundPanel();
            this.lblVersionNO = new System.Windows.Forms.Label();
            this.pnAccountImg = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnLogin = new ArecaIPIS.MyControls.RoundButton();
            this.button1 = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnpicEye = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.panLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Castellar", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(44, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1266, 77);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to Areca IPIS Systems";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BtnApplicationExit
            // 
            this.BtnApplicationExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnApplicationExit.BackgroundImage")));
            this.BtnApplicationExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnApplicationExit.FlatAppearance.BorderSize = 0;
            this.BtnApplicationExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApplicationExit.Location = new System.Drawing.Point(1325, 9);
            this.BtnApplicationExit.Name = "BtnApplicationExit";
            this.BtnApplicationExit.Size = new System.Drawing.Size(23, 23);
            this.BtnApplicationExit.TabIndex = 81;
            this.BtnApplicationExit.UseVisualStyleBackColor = true;
            this.BtnApplicationExit.Click += new System.EventHandler(this.BtnApplicationExit_Click);
            // 
            // btnMinize
            // 
            this.btnMinize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinize.BackgroundImage")));
            this.btnMinize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinize.FlatAppearance.BorderSize = 0;
            this.btnMinize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinize.Location = new System.Drawing.Point(1292, 9);
            this.btnMinize.Name = "btnMinize";
            this.btnMinize.Size = new System.Drawing.Size(23, 23);
            this.btnMinize.TabIndex = 80;
            this.btnMinize.UseVisualStyleBackColor = true;
            this.btnMinize.Click += new System.EventHandler(this.btnMinize_Click);
            // 
            // panLogin
            // 
            this.panLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panLogin.Controls.Add(this.lblVersionNO);
            this.panLogin.Controls.Add(this.pnAccountImg);
            this.panLogin.Controls.Add(this.lblVersion);
            this.panLogin.Controls.Add(this.btnLogin);
            this.panLogin.Controls.Add(this.button1);
            this.panLogin.Controls.Add(this.lblLogin);
            this.panLogin.Controls.Add(this.lblUsername);
            this.panLogin.Controls.Add(this.btnpicEye);
            this.panLogin.Controls.Add(this.label3);
            this.panLogin.Controls.Add(this.txtPassword);
            this.panLogin.Controls.Add(this.txtUsername);
            this.panLogin.CornerRadius = 20;
            this.panLogin.Location = new System.Drawing.Point(571, 178);
            this.panLogin.Name = "panLogin";
            this.panLogin.Size = new System.Drawing.Size(273, 405);
            this.panLogin.TabIndex = 82;
            // 
            // lblVersionNO
            // 
            this.lblVersionNO.AutoSize = true;
            this.lblVersionNO.BackColor = System.Drawing.Color.White;
            this.lblVersionNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionNO.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblVersionNO.Location = new System.Drawing.Point(219, 385);
            this.lblVersionNO.Name = "lblVersionNO";
            this.lblVersionNO.Size = new System.Drawing.Size(47, 13);
            this.lblVersionNO.TabIndex = 84;
            this.lblVersionNO.Text = "1.0.0.0";
            // 
            // pnAccountImg
            // 
            this.pnAccountImg.BackColor = System.Drawing.Color.Transparent;
            this.pnAccountImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnAccountImg.BackgroundImage")));
            this.pnAccountImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnAccountImg.Location = new System.Drawing.Point(90, 70);
            this.pnAccountImg.Name = "pnAccountImg";
            this.pnAccountImg.Size = new System.Drawing.Size(68, 68);
            this.pnAccountImg.TabIndex = 9;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.White;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblVersion.Location = new System.Drawing.Point(143, 385);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(70, 13);
            this.lblVersion.TabIndex = 83;
            this.lblVersion.Text = "VERSION :";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.btnLogin.CornerRadius = 20;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.Location = new System.Drawing.Point(70, 327);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(106, 34);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(205, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLogin.Location = new System.Drawing.Point(86, 31);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(75, 24);
            this.lblLogin.TabIndex = 7;
            this.lblLogin.Text = "Sign In";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(16, 153);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(86, 16);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "UserName:";
            // 
            // btnpicEye
            // 
            this.btnpicEye.BackColor = System.Drawing.Color.White;
            this.btnpicEye.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnpicEye.BackgroundImage")));
            this.btnpicEye.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnpicEye.FlatAppearance.BorderSize = 0;
            this.btnpicEye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpicEye.Location = new System.Drawing.Point(210, 269);
            this.btnpicEye.Name = "btnpicEye";
            this.btnpicEye.Size = new System.Drawing.Size(20, 20);
            this.btnpicEye.TabIndex = 6;
            this.btnpicEye.UseVisualStyleBackColor = false;
            this.btnpicEye.Click += new System.EventHandler(this.btnpicEye_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(16, 266);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(220, 29);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "Demo@123";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(17, 181);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(214, 29);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.Text = "Superadmin";
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // frmLoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 720);
            this.Controls.Add(this.panLogin);
            this.Controls.Add(this.BtnApplicationExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMinize);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoginPage";
            this.Load += new System.EventHandler(this.frmLoginPage_Load);
            this.panLogin.ResumeLayout(false);
            this.panLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnpicEye;
        private System.Windows.Forms.Button BtnApplicationExit;
        private System.Windows.Forms.Button btnMinize;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnAccountImg;
        private MyControls.RoundPanel panLogin;
        private MyControls.RoundButton btnLogin;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblVersionNO;
    }
}