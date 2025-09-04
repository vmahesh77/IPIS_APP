
namespace ArecaIPIS.Forms.settingsForms
{
    partial class frmRedundencyPc
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
            this.lblRedundencyPc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHost1 = new System.Windows.Forms.Label();
            this.lblHost2 = new System.Windows.Forms.Label();
            this.lblhost1ip = new System.Windows.Forms.Label();
            this.lblHost2ip = new System.Windows.Forms.Label();
            this.pbMaster = new System.Windows.Forms.PictureBox();
            this.pbSlave = new System.Windows.Forms.PictureBox();
            this.lbMasterlHostId = new System.Windows.Forms.Label();
            this.lblSlaveDestopId = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ipAddressControlsystemaddressMaster = new IPAddressControlLib.IPAddressControl();
            this.ipAddressControlSlave = new IPAddressControlLib.IPAddressControl();
            this.btnGetDatabase = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlave)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRedundencyPc
            // 
            this.lblRedundencyPc.AutoSize = true;
            this.lblRedundencyPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedundencyPc.ForeColor = System.Drawing.Color.Red;
            this.lblRedundencyPc.Location = new System.Drawing.Point(1, 8);
            this.lblRedundencyPc.Name = "lblRedundencyPc";
            this.lblRedundencyPc.Size = new System.Drawing.Size(225, 31);
            this.lblRedundencyPc.TabIndex = 0;
            this.lblRedundencyPc.Text = "Redundancy PC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Master";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(374, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Slave";
            // 
            // lblHost1
            // 
            this.lblHost1.AutoSize = true;
            this.lblHost1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblHost1.ForeColor = System.Drawing.Color.Navy;
            this.lblHost1.Location = new System.Drawing.Point(40, 270);
            this.lblHost1.Name = "lblHost1";
            this.lblHost1.Size = new System.Drawing.Size(89, 16);
            this.lblHost1.TabIndex = 5;
            this.lblHost1.Text = "Host Name:";
            // 
            // lblHost2
            // 
            this.lblHost2.AutoSize = true;
            this.lblHost2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblHost2.ForeColor = System.Drawing.Color.Navy;
            this.lblHost2.Location = new System.Drawing.Point(325, 270);
            this.lblHost2.Name = "lblHost2";
            this.lblHost2.Size = new System.Drawing.Size(89, 16);
            this.lblHost2.TabIndex = 6;
            this.lblHost2.Text = "Host Name:";
            // 
            // lblhost1ip
            // 
            this.lblhost1ip.AutoSize = true;
            this.lblhost1ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblhost1ip.ForeColor = System.Drawing.Color.Navy;
            this.lblhost1ip.Location = new System.Drawing.Point(48, 316);
            this.lblhost1ip.Name = "lblhost1ip";
            this.lblhost1ip.Size = new System.Drawing.Size(88, 16);
            this.lblhost1ip.TabIndex = 7;
            this.lblhost1ip.Text = "IP Address:";
            // 
            // lblHost2ip
            // 
            this.lblHost2ip.AutoSize = true;
            this.lblHost2ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblHost2ip.ForeColor = System.Drawing.Color.Navy;
            this.lblHost2ip.Location = new System.Drawing.Point(325, 316);
            this.lblHost2ip.Name = "lblHost2ip";
            this.lblHost2ip.Size = new System.Drawing.Size(88, 16);
            this.lblHost2ip.TabIndex = 8;
            this.lblHost2ip.Text = "IP Address:";
            // 
            // pbMaster
            // 
            this.pbMaster.Image = global::ArecaIPIS.Properties.Resources.desktop_2_128;
            this.pbMaster.Location = new System.Drawing.Point(328, 107);
            this.pbMaster.Name = "pbMaster";
            this.pbMaster.Size = new System.Drawing.Size(127, 130);
            this.pbMaster.TabIndex = 9;
            this.pbMaster.TabStop = false;
            // 
            // pbSlave
            // 
            this.pbSlave.Image = global::ArecaIPIS.Properties.Resources.monitor_2_128;
            this.pbSlave.Location = new System.Drawing.Point(68, 107);
            this.pbSlave.Name = "pbSlave";
            this.pbSlave.Size = new System.Drawing.Size(131, 130);
            this.pbSlave.TabIndex = 10;
            this.pbSlave.TabStop = false;
            // 
            // lbMasterlHostId
            // 
            this.lbMasterlHostId.AutoSize = true;
            this.lbMasterlHostId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbMasterlHostId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMasterlHostId.Location = new System.Drawing.Point(127, 270);
            this.lbMasterlHostId.Name = "lbMasterlHostId";
            this.lbMasterlHostId.Size = new System.Drawing.Size(151, 16);
            this.lbMasterlHostId.TabIndex = 11;
            this.lbMasterlHostId.Text = "Master SystemName";
            // 
            // lblSlaveDestopId
            // 
            this.lblSlaveDestopId.AutoSize = true;
            this.lblSlaveDestopId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSlaveDestopId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSlaveDestopId.Location = new System.Drawing.Point(410, 270);
            this.lblSlaveDestopId.Name = "lblSlaveDestopId";
            this.lblSlaveDestopId.Size = new System.Drawing.Size(144, 16);
            this.lblSlaveDestopId.TabIndex = 14;
            this.lblSlaveDestopId.Text = "Slave SystemName";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ipAddressControlsystemaddressMaster
            // 
            this.ipAddressControlsystemaddressMaster.AllowInternalTab = false;
            this.ipAddressControlsystemaddressMaster.AutoHeight = true;
            this.ipAddressControlsystemaddressMaster.BackColor = System.Drawing.Color.White;
            this.ipAddressControlsystemaddressMaster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressControlsystemaddressMaster.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressControlsystemaddressMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ipAddressControlsystemaddressMaster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ipAddressControlsystemaddressMaster.Location = new System.Drawing.Point(131, 310);
            this.ipAddressControlsystemaddressMaster.MinimumSize = new System.Drawing.Size(111, 22);
            this.ipAddressControlsystemaddressMaster.Name = "ipAddressControlsystemaddressMaster";
            this.ipAddressControlsystemaddressMaster.ReadOnly = false;
            this.ipAddressControlsystemaddressMaster.Size = new System.Drawing.Size(132, 22);
            this.ipAddressControlsystemaddressMaster.TabIndex = 25;
            this.ipAddressControlsystemaddressMaster.Text = "...";
            // 
            // ipAddressControlSlave
            // 
            this.ipAddressControlSlave.AllowInternalTab = false;
            this.ipAddressControlSlave.AutoHeight = true;
            this.ipAddressControlSlave.BackColor = System.Drawing.Color.White;
            this.ipAddressControlSlave.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressControlSlave.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressControlSlave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ipAddressControlSlave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ipAddressControlSlave.Location = new System.Drawing.Point(413, 310);
            this.ipAddressControlSlave.MinimumSize = new System.Drawing.Size(111, 22);
            this.ipAddressControlSlave.Name = "ipAddressControlSlave";
            this.ipAddressControlSlave.ReadOnly = false;
            this.ipAddressControlSlave.Size = new System.Drawing.Size(132, 22);
            this.ipAddressControlSlave.TabIndex = 26;
            this.ipAddressControlSlave.Text = "...";
            // 
            // btnGetDatabase
            // 
            this.btnGetDatabase.Location = new System.Drawing.Point(726, 12);
            this.btnGetDatabase.Name = "btnGetDatabase";
            this.btnGetDatabase.Size = new System.Drawing.Size(108, 23);
            this.btnGetDatabase.TabIndex = 27;
            this.btnGetDatabase.Text = "BackUp DataBase";
            this.btnGetDatabase.UseVisualStyleBackColor = true;
            this.btnGetDatabase.Click += new System.EventHandler(this.btnGetDatabase_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Enabled = false;
            this.btnRestore.Location = new System.Drawing.Point(840, 12);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(146, 23);
            this.btnRestore.TabIndex = 28;
            this.btnRestore.Text = "Restore DataBase In Slave";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // frmRedundencyPc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 548);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnGetDatabase);
            this.Controls.Add(this.ipAddressControlSlave);
            this.Controls.Add(this.ipAddressControlsystemaddressMaster);
            this.Controls.Add(this.lblSlaveDestopId);
            this.Controls.Add(this.lbMasterlHostId);
            this.Controls.Add(this.lblHost2ip);
            this.Controls.Add(this.lblhost1ip);
            this.Controls.Add(this.lblHost2);
            this.Controls.Add(this.lblHost1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbMaster);
            this.Controls.Add(this.pbSlave);
            this.Controls.Add(this.lblRedundencyPc);
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRedundencyPc";
            this.Text = "frmRedundencyPc";
            this.Load += new System.EventHandler(this.frmRedundencyPc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRedundencyPc;
        private System.Windows.Forms.PictureBox pbSlave;
        private System.Windows.Forms.PictureBox pbMaster;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHost1;
        private System.Windows.Forms.Label lblHost2;
        private System.Windows.Forms.Label lblhost1ip;
        private System.Windows.Forms.Label lblHost2ip;
        private System.Windows.Forms.Label lbMasterlHostId;
        private System.Windows.Forms.Label lblSlaveDestopId;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private IPAddressControlLib.IPAddressControl ipAddressControlsystemaddressMaster;
        private IPAddressControlLib.IPAddressControl ipAddressControlSlave;
        private System.Windows.Forms.Button btnGetDatabase;
        private System.Windows.Forms.Button btnRestore;
    }
}