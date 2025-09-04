
namespace ArecaIPIS
{
    partial class frmCCTV
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
            this.panelCCTVHadder = new System.Windows.Forms.Panel();
            this.lblOVDHadder = new System.Windows.Forms.Label();
            this.btnCCTVSave = new System.Windows.Forms.Button();
            this.lblBoardid = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblcctvip = new System.Windows.Forms.Label();
            this.lblnooflinescctv = new System.Windows.Forms.Label();
            this.cmbCCTVLines = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCCTVLocation = new System.Windows.Forms.TextBox();
            this.txtCCTVBoardId = new System.Windows.Forms.TextBox();
            this.lblIpExist = new System.Windows.Forms.Label();
            this.ipAddressMldb = new IPAddressControlLib.IPAddressControl();
            this.lblICCTVErrorMessage = new System.Windows.Forms.Label();
            this.lblCctvEthernetPortNo = new System.Windows.Forms.Label();
            this.txtcctvEthernetportno = new System.Windows.Forms.TextBox();
            this.errorProviderivovd = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelCCTVHadder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderivovd)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCCTVHadder
            // 
            this.panelCCTVHadder.BackColor = System.Drawing.Color.Red;
            this.panelCCTVHadder.Controls.Add(this.lblOVDHadder);
            this.panelCCTVHadder.Location = new System.Drawing.Point(10, 11);
            this.panelCCTVHadder.Margin = new System.Windows.Forms.Padding(4);
            this.panelCCTVHadder.Name = "panelCCTVHadder";
            this.panelCCTVHadder.Size = new System.Drawing.Size(944, 35);
            this.panelCCTVHadder.TabIndex = 64;
            // 
            // lblOVDHadder
            // 
            this.lblOVDHadder.AutoSize = true;
            this.lblOVDHadder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOVDHadder.ForeColor = System.Drawing.Color.Black;
            this.lblOVDHadder.Location = new System.Drawing.Point(253, 6);
            this.lblOVDHadder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOVDHadder.Name = "lblOVDHadder";
            this.lblOVDHadder.Size = new System.Drawing.Size(447, 24);
            this.lblOVDHadder.TabIndex = 0;
            this.lblOVDHadder.Text = "CCTV (IP Range 192.168.X.191-192.168.X.220)";
            // 
            // btnCCTVSave
            // 
            this.btnCCTVSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCCTVSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCCTVSave.ForeColor = System.Drawing.Color.White;
            this.btnCCTVSave.Location = new System.Drawing.Point(113, 327);
            this.btnCCTVSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnCCTVSave.Name = "btnCCTVSave";
            this.btnCCTVSave.Size = new System.Drawing.Size(113, 43);
            this.btnCCTVSave.TabIndex = 70;
            this.btnCCTVSave.Text = "Save";
            this.btnCCTVSave.UseVisualStyleBackColor = false;
            this.btnCCTVSave.Click += new System.EventHandler(this.btnOVDSave_Click);
            // 
            // lblBoardid
            // 
            this.lblBoardid.AutoSize = true;
            this.lblBoardid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblBoardid.Location = new System.Drawing.Point(37, 68);
            this.lblBoardid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoardid.Name = "lblBoardid";
            this.lblBoardid.Size = new System.Drawing.Size(66, 18);
            this.lblBoardid.TabIndex = 71;
            this.lblBoardid.Text = "Board ID";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblLocation.Location = new System.Drawing.Point(39, 101);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(65, 18);
            this.lblLocation.TabIndex = 72;
            this.lblLocation.Text = "Location";
            // 
            // lblcctvip
            // 
            this.lblcctvip.AutoSize = true;
            this.lblcctvip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblcctvip.Location = new System.Drawing.Point(39, 214);
            this.lblcctvip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblcctvip.Name = "lblcctvip";
            this.lblcctvip.Size = new System.Drawing.Size(65, 18);
            this.lblcctvip.TabIndex = 73;
            this.lblcctvip.Text = "CCTV IP";
            // 
            // lblnooflinescctv
            // 
            this.lblnooflinescctv.AutoSize = true;
            this.lblnooflinescctv.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblnooflinescctv.Location = new System.Drawing.Point(39, 178);
            this.lblnooflinescctv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblnooflinescctv.Name = "lblnooflinescctv";
            this.lblnooflinescctv.Size = new System.Drawing.Size(87, 18);
            this.lblnooflinescctv.TabIndex = 74;
            this.lblnooflinescctv.Text = "No Of Lines";
            // 
            // cmbCCTVLines
            // 
            this.cmbCCTVLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCCTVLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbCCTVLines.FormattingEnabled = true;
            this.cmbCCTVLines.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cmbCCTVLines.Location = new System.Drawing.Point(197, 170);
            this.cmbCCTVLines.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCCTVLines.Name = "cmbCCTVLines";
            this.cmbCCTVLines.Size = new System.Drawing.Size(152, 26);
            this.cmbCCTVLines.TabIndex = 75;
            this.cmbCCTVLines.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCCTVLines_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.textBox1.Location = new System.Drawing.Point(168, 208);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(0, 24);
            this.textBox1.TabIndex = 76;
            this.textBox1.Text = "192.168.0.";
            // 
            // txtCCTVLocation
            // 
            this.txtCCTVLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCTVLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtCCTVLocation.Location = new System.Drawing.Point(197, 98);
            this.txtCCTVLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtCCTVLocation.Name = "txtCCTVLocation";
            this.txtCCTVLocation.Size = new System.Drawing.Size(152, 24);
            this.txtCCTVLocation.TabIndex = 77;
            this.txtCCTVLocation.Enter += new System.EventHandler(this.txtCCTVLocation_Enter);
            // 
            // txtCCTVBoardId
            // 
            this.txtCCTVBoardId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCTVBoardId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtCCTVBoardId.Location = new System.Drawing.Point(197, 62);
            this.txtCCTVBoardId.Margin = new System.Windows.Forms.Padding(2);
            this.txtCCTVBoardId.Name = "txtCCTVBoardId";
            this.txtCCTVBoardId.Size = new System.Drawing.Size(152, 24);
            this.txtCCTVBoardId.TabIndex = 78;
            // 
            // lblIpExist
            // 
            this.lblIpExist.AutoSize = true;
            this.lblIpExist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpExist.ForeColor = System.Drawing.Color.Red;
            this.lblIpExist.Location = new System.Drawing.Point(176, 267);
            this.lblIpExist.Name = "lblIpExist";
            this.lblIpExist.Size = new System.Drawing.Size(111, 13);
            this.lblIpExist.TabIndex = 81;
            this.lblIpExist.Text = "IP ALREADY EXISTS";
            this.lblIpExist.Visible = false;
            // 
            // ipAddressMldb
            // 
            this.ipAddressMldb.AllowInternalTab = false;
            this.ipAddressMldb.AutoHeight = true;
            this.ipAddressMldb.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddressMldb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressMldb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressMldb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ipAddressMldb.Location = new System.Drawing.Point(197, 208);
            this.ipAddressMldb.MinimumSize = new System.Drawing.Size(114, 24);
            this.ipAddressMldb.Name = "ipAddressMldb";
            this.ipAddressMldb.ReadOnly = false;
            this.ipAddressMldb.Size = new System.Drawing.Size(152, 24);
            this.ipAddressMldb.TabIndex = 80;
            this.ipAddressMldb.Text = "192.168.0.";
            this.ipAddressMldb.TextChanged += new System.EventHandler(this.ipAddressMldb_TextChanged);
            this.ipAddressMldb.Enter += new System.EventHandler(this.ipAddressMldb_Enter);
            this.ipAddressMldb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipAddressMldb_KeyPress);
            this.ipAddressMldb.Leave += new System.EventHandler(this.ipAddressMldb_Leave);
            // 
            // lblICCTVErrorMessage
            // 
            this.lblICCTVErrorMessage.AutoSize = true;
            this.lblICCTVErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblICCTVErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblICCTVErrorMessage.Location = new System.Drawing.Point(39, 244);
            this.lblICCTVErrorMessage.Name = "lblICCTVErrorMessage";
            this.lblICCTVErrorMessage.Size = new System.Drawing.Size(305, 13);
            this.lblICCTVErrorMessage.TabIndex = 79;
            this.lblICCTVErrorMessage.Text = "The last octet of the IP address must be between 191 and 220.";
            this.lblICCTVErrorMessage.Visible = false;
            // 
            // lblCctvEthernetPortNo
            // 
            this.lblCctvEthernetPortNo.AutoSize = true;
            this.lblCctvEthernetPortNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCctvEthernetPortNo.Location = new System.Drawing.Point(35, 136);
            this.lblCctvEthernetPortNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCctvEthernetPortNo.Name = "lblCctvEthernetPortNo";
            this.lblCctvEthernetPortNo.Size = new System.Drawing.Size(119, 18);
            this.lblCctvEthernetPortNo.TabIndex = 82;
            this.lblCctvEthernetPortNo.Text = "Ethernet Port No";
            // 
            // txtcctvEthernetportno
            // 
            this.txtcctvEthernetportno.BackColor = System.Drawing.Color.White;
            this.txtcctvEthernetportno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcctvEthernetportno.Enabled = false;
            this.txtcctvEthernetportno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtcctvEthernetportno.Location = new System.Drawing.Point(197, 134);
            this.txtcctvEthernetportno.Margin = new System.Windows.Forms.Padding(2);
            this.txtcctvEthernetportno.Name = "txtcctvEthernetportno";
            this.txtcctvEthernetportno.Size = new System.Drawing.Size(152, 24);
            this.txtcctvEthernetportno.TabIndex = 83;
            // 
            // errorProviderivovd
            // 
            this.errorProviderivovd.ContainerControl = this;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(255, 346);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 16);
            this.lblStatus.TabIndex = 84;
            this.lblStatus.Text = "save";
            this.lblStatus.Visible = false;
            // 
            // frmCCTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 483);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCctvEthernetPortNo);
            this.Controls.Add(this.txtcctvEthernetportno);
            this.Controls.Add(this.lblIpExist);
            this.Controls.Add(this.ipAddressMldb);
            this.Controls.Add(this.lblICCTVErrorMessage);
            this.Controls.Add(this.txtCCTVBoardId);
            this.Controls.Add(this.txtCCTVLocation);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmbCCTVLines);
            this.Controls.Add(this.lblnooflinescctv);
            this.Controls.Add(this.lblcctvip);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblBoardid);
            this.Controls.Add(this.btnCCTVSave);
            this.Controls.Add(this.panelCCTVHadder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCCTV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CCTV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCCTV_FormClosing);
            this.Load += new System.EventHandler(this.frmCCTV_Load);
            this.panelCCTVHadder.ResumeLayout(false);
            this.panelCCTVHadder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderivovd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCCTVHadder;
        private System.Windows.Forms.Label lblOVDHadder;
        private System.Windows.Forms.Button btnCCTVSave;
        private System.Windows.Forms.Label lblBoardid;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblcctvip;
        private System.Windows.Forms.Label lblnooflinescctv;
        private System.Windows.Forms.ComboBox cmbCCTVLines;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCCTVLocation;
        private System.Windows.Forms.TextBox txtCCTVBoardId;
        private System.Windows.Forms.Label lblIpExist;
        private IPAddressControlLib.IPAddressControl ipAddressMldb;
        private System.Windows.Forms.Label lblICCTVErrorMessage;
        private System.Windows.Forms.Label lblCctvEthernetPortNo;
        private System.Windows.Forms.TextBox txtcctvEthernetportno;
        private System.Windows.Forms.ErrorProvider errorProviderivovd;
        private System.Windows.Forms.Label lblStatus;
    }
}