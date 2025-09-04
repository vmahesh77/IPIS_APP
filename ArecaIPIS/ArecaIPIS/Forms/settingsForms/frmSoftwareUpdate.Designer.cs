
namespace ArecaIPIS.Forms.settingsForms
{
    partial class frmSoftwareUpdate
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSoftwareUpdate = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.rctVersion = new System.Windows.Forms.RichTextBox();
            this.rndUpdate = new ArecaIPIS.MyControls.RoundButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSoftwareUpdate);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 49);
            this.panel1.TabIndex = 0;
            // 
            // lblSoftwareUpdate
            // 
            this.lblSoftwareUpdate.AutoSize = true;
            this.lblSoftwareUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoftwareUpdate.Location = new System.Drawing.Point(309, 11);
            this.lblSoftwareUpdate.Name = "lblSoftwareUpdate";
            this.lblSoftwareUpdate.Size = new System.Drawing.Size(162, 24);
            this.lblSoftwareUpdate.TabIndex = 0;
            this.lblSoftwareUpdate.Text = "Software Update";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(227, 100);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(70, 20);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version";
            // 
            // rctVersion
            // 
            this.rctVersion.Location = new System.Drawing.Point(358, 94);
            this.rctVersion.Name = "rctVersion";
            this.rctVersion.Size = new System.Drawing.Size(237, 26);
            this.rctVersion.TabIndex = 5;
            this.rctVersion.Text = "1.0.0.0";
            // 
            // rndUpdate
            // 
            this.rndUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.rndUpdate.CornerRadius = 20;
            this.rndUpdate.FlatAppearance.BorderSize = 0;
            this.rndUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rndUpdate.ForeColor = System.Drawing.Color.White;
            this.rndUpdate.Location = new System.Drawing.Point(358, 210);
            this.rndUpdate.Name = "rndUpdate";
            this.rndUpdate.Size = new System.Drawing.Size(90, 35);
            this.rndUpdate.TabIndex = 7;
            this.rndUpdate.Text = "Update";
            this.rndUpdate.UseVisualStyleBackColor = false;
            this.rndUpdate.Click += new System.EventHandler(this.rndUpdate_Click);
            // 
            // frmSoftwareUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rndUpdate);
            this.Controls.Add(this.rctVersion);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSoftwareUpdate";
            this.Text = "SoftwareUpdate";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSoftwareUpdate;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.RichTextBox rctVersion;
        private MyControls.RoundButton rndUpdate;
    }
}