
namespace ArecaIPIS
{
    partial class frmIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndex));
            this.panForms = new System.Windows.Forms.Panel();
            this.panHeader = new System.Windows.Forms.Panel();
            this.panLogin = new System.Windows.Forms.Panel();
            this.timerslavestatus = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panForms
            // 
            this.panForms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panForms.AutoScroll = true;
            this.panForms.BackColor = System.Drawing.Color.White;
            this.panForms.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panForms.Location = new System.Drawing.Point(4, 170);
            this.panForms.Name = "panForms";
            this.panForms.Size = new System.Drawing.Size(1358, 548);
            this.panForms.TabIndex = 2;
            this.panForms.Visible = false;
          
            this.panHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(150)))), ((int)(((byte)(191)))));
            this.panHeader.Location = new System.Drawing.Point(4, 1);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(1358, 171);
            this.panHeader.TabIndex = 0;
            this.panHeader.Visible = false;
          
            // 
            // panLogin
            // 
            this.panLogin.BackColor = System.Drawing.Color.White;
            this.panLogin.Location = new System.Drawing.Point(4, 1);
            this.panLogin.Name = "panLogin";
            this.panLogin.Size = new System.Drawing.Size(1358, 718);
            this.panLogin.TabIndex = 0;
           
            // 
            // timerslavestatus
            // 
            this.timerslavestatus.Interval = 5000;
            this.timerslavestatus.Tick += new System.EventHandler(this.timerslavestatus_Tick);
            // 
            // frmIndex
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1366, 720);
            this.Controls.Add(this.panHeader);
            this.Controls.Add(this.panForms);
            this.Controls.Add(this.panLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmIndex";
            this.Text = "IPIS Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIndex_FormClosing);
            this.Load += new System.EventHandler(this.frmIndex_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panForms;
        private System.Windows.Forms.Panel panHeader;
        private System.Windows.Forms.Panel panLogin;
        private System.Windows.Forms.Timer timerslavestatus;
    }
}