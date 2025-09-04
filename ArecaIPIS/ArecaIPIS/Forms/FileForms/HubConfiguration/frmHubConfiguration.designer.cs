
namespace ArecaIPIS
{
    partial class frmHubConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHubConfiguration));
            this.panHubConfiguration = new System.Windows.Forms.Panel();
            this.panPdcPorts = new System.Windows.Forms.Panel();
            this.btnEthernetports = new System.Windows.Forms.Button();
            this.txtCDS = new System.Windows.Forms.TextBox();
            this.panelshowwindowsall = new System.Windows.Forms.Panel();
            this.panHubConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // panHubConfiguration
            // 
            this.panHubConfiguration.AutoScroll = true;
            this.panHubConfiguration.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panHubConfiguration.Controls.Add(this.panPdcPorts);
            this.panHubConfiguration.Location = new System.Drawing.Point(9, 47);
            this.panHubConfiguration.Margin = new System.Windows.Forms.Padding(2);
            this.panHubConfiguration.Name = "panHubConfiguration";
            this.panHubConfiguration.Size = new System.Drawing.Size(418, 462);
            this.panHubConfiguration.TabIndex = 0;
            // 
            // panPdcPorts
            // 
            this.panPdcPorts.BackColor = System.Drawing.Color.GreenYellow;
            this.panPdcPorts.Location = new System.Drawing.Point(179, 84);
            this.panPdcPorts.Name = "panPdcPorts";
            this.panPdcPorts.Size = new System.Drawing.Size(123, 300);
            this.panPdcPorts.TabIndex = 2;
            this.panPdcPorts.Visible = false;
            // 
            // btnEthernetports
            // 
            this.btnEthernetports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEthernetports.Image = ((System.Drawing.Image)(resources.GetObject("btnEthernetports.Image")));
            this.btnEthernetports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEthernetports.Location = new System.Drawing.Point(7, 19);
            this.btnEthernetports.Margin = new System.Windows.Forms.Padding(2);
            this.btnEthernetports.Name = "btnEthernetports";
            this.btnEthernetports.Size = new System.Drawing.Size(142, 28);
            this.btnEthernetports.TabIndex = 1;
            this.btnEthernetports.Text = " EtherNet Ports";
            this.btnEthernetports.UseVisualStyleBackColor = true;
            this.btnEthernetports.Click += new System.EventHandler(this.btnEthernetports_Click);
            this.btnEthernetports.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEthernetports_MouseDown);
            // 
            // txtCDS
            // 
            this.txtCDS.Enabled = false;
            this.txtCDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCDS.Location = new System.Drawing.Point(8, -2);
            this.txtCDS.Margin = new System.Windows.Forms.Padding(2);
            this.txtCDS.Name = "txtCDS";
            this.txtCDS.Size = new System.Drawing.Size(105, 22);
            this.txtCDS.TabIndex = 0;
            this.txtCDS.Text = ">>>CDS";
            // 
            // panelshowwindowsall
            // 
            this.panelshowwindowsall.AutoSize = true;
            this.panelshowwindowsall.BackColor = System.Drawing.Color.PeachPuff;
            this.panelshowwindowsall.Location = new System.Drawing.Point(431, -2);
            this.panelshowwindowsall.Margin = new System.Windows.Forms.Padding(2);
            this.panelshowwindowsall.Name = "panelshowwindowsall";
            this.panelshowwindowsall.Size = new System.Drawing.Size(869, 511);
            this.panelshowwindowsall.TabIndex = 1;
            // 
            // frmHubConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1342, 509);
            this.Controls.Add(this.panelshowwindowsall);
            this.Controls.Add(this.btnEthernetports);
            this.Controls.Add(this.panHubConfiguration);
            this.Controls.Add(this.txtCDS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmHubConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HubConfiguration";
            this.Load += new System.EventHandler(this.frmHubConfiguration_Load);
            this.panHubConfiguration.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panHubConfiguration;
        private System.Windows.Forms.Button btnEthernetports;
        private System.Windows.Forms.TextBox txtCDS;
        private System.Windows.Forms.Panel panelshowwindowsall;
        private System.Windows.Forms.Panel panPdcPorts;
    }
}