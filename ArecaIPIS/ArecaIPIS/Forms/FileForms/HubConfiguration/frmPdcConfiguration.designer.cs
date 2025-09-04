
namespace ArecaIPIS
{
    partial class frmPdcConfiguration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelPDChedder = new System.Windows.Forms.Panel();
            this.lblpdcipdisplay = new System.Windows.Forms.Label();
            this.lblPlatformNo = new System.Windows.Forms.Label();
            this.lblPDCPortNo = new System.Windows.Forms.Label();
            this.lblNoOfPorts = new System.Windows.Forms.Label();
            this.lblActionList = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblPDCIPaddress = new System.Windows.Forms.Label();
            this.btnSetConfiguration = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGetConfiguration = new System.Windows.Forms.Button();
            this.cmbSelectPfno = new System.Windows.Forms.ComboBox();
            this.cmbNoofports = new System.Windows.Forms.ComboBox();
            this.txtportno = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.dgvPdcPorts = new System.Windows.Forms.DataGridView();
            this.PortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoardIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipAddressControlplatform = new IPAddressControlLib.IPAddressControl();
            this.lblPlatformError = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblinteroperability = new System.Windows.Forms.Label();
            this.tglinteroperability = new ArecaIPIS.MyControls.ToggleButton();
            this.panelPDChedder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPdcPorts)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPDChedder
            // 
            this.panelPDChedder.BackColor = System.Drawing.Color.Red;
            this.panelPDChedder.Controls.Add(this.lblpdcipdisplay);
            this.panelPDChedder.Location = new System.Drawing.Point(4, 2);
            this.panelPDChedder.Margin = new System.Windows.Forms.Padding(2);
            this.panelPDChedder.Name = "panelPDChedder";
            this.panelPDChedder.Size = new System.Drawing.Size(819, 29);
            this.panelPDChedder.TabIndex = 0;
            // 
            // lblpdcipdisplay
            // 
            this.lblpdcipdisplay.AutoSize = true;
            this.lblpdcipdisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpdcipdisplay.Location = new System.Drawing.Point(280, 0);
            this.lblpdcipdisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblpdcipdisplay.Name = "lblpdcipdisplay";
            this.lblpdcipdisplay.Size = new System.Drawing.Size(290, 24);
            this.lblpdcipdisplay.TabIndex = 0;
            this.lblpdcipdisplay.Text = "PDC (IP Address 192.168.PF.251)";
            // 
            // lblPlatformNo
            // 
            this.lblPlatformNo.AutoSize = true;
            this.lblPlatformNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblPlatformNo.Location = new System.Drawing.Point(11, 53);
            this.lblPlatformNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlatformNo.Name = "lblPlatformNo";
            this.lblPlatformNo.Size = new System.Drawing.Size(88, 18);
            this.lblPlatformNo.TabIndex = 1;
            this.lblPlatformNo.Text = "Platform No";
            // 
            // lblPDCPortNo
            // 
            this.lblPDCPortNo.AutoSize = true;
            this.lblPDCPortNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblPDCPortNo.Location = new System.Drawing.Point(11, 105);
            this.lblPDCPortNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPDCPortNo.Name = "lblPDCPortNo";
            this.lblPDCPortNo.Size = new System.Drawing.Size(96, 18);
            this.lblPDCPortNo.TabIndex = 2;
            this.lblPDCPortNo.Text = "PDC Port No";
            // 
            // lblNoOfPorts
            // 
            this.lblNoOfPorts.AutoSize = true;
            this.lblNoOfPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblNoOfPorts.Location = new System.Drawing.Point(11, 152);
            this.lblNoOfPorts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoOfPorts.Name = "lblNoOfPorts";
            this.lblNoOfPorts.Size = new System.Drawing.Size(88, 18);
            this.lblNoOfPorts.TabIndex = 3;
            this.lblNoOfPorts.Text = "No Of Ports";
            // 
            // lblActionList
            // 
            this.lblActionList.AutoSize = true;
            this.lblActionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblActionList.ForeColor = System.Drawing.Color.DarkViolet;
            this.lblActionList.Location = new System.Drawing.Point(48, 219);
            this.lblActionList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActionList.Name = "lblActionList";
            this.lblActionList.Size = new System.Drawing.Size(83, 20);
            this.lblActionList.TabIndex = 4;
            this.lblActionList.Text = "Action List";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblLocation.Location = new System.Drawing.Point(365, 94);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(65, 18);
            this.lblLocation.TabIndex = 5;
            this.lblLocation.Text = "Location";
            // 
            // lblPDCIPaddress
            // 
            this.lblPDCIPaddress.AutoSize = true;
            this.lblPDCIPaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblPDCIPaddress.Location = new System.Drawing.Point(365, 49);
            this.lblPDCIPaddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPDCIPaddress.Name = "lblPDCIPaddress";
            this.lblPDCIPaddress.Size = new System.Drawing.Size(115, 18);
            this.lblPDCIPaddress.TabIndex = 6;
            this.lblPDCIPaddress.Text = "PDC IP Address";
            // 
            // btnSetConfiguration
            // 
            this.btnSetConfiguration.BackColor = System.Drawing.Color.Gray;
            this.btnSetConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSetConfiguration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSetConfiguration.Location = new System.Drawing.Point(11, 241);
            this.btnSetConfiguration.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetConfiguration.Name = "btnSetConfiguration";
            this.btnSetConfiguration.Size = new System.Drawing.Size(151, 35);
            this.btnSetConfiguration.TabIndex = 7;
            this.btnSetConfiguration.Text = "Set Configuration";
            this.btnSetConfiguration.UseVisualStyleBackColor = false;
            this.btnSetConfiguration.Click += new System.EventHandler(this.btnSetConfiguration_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(257, 434);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 36);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGetConfiguration
            // 
            this.btnGetConfiguration.BackColor = System.Drawing.Color.Gray;
            this.btnGetConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGetConfiguration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGetConfiguration.Location = new System.Drawing.Point(11, 280);
            this.btnGetConfiguration.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetConfiguration.Name = "btnGetConfiguration";
            this.btnGetConfiguration.Size = new System.Drawing.Size(151, 34);
            this.btnGetConfiguration.TabIndex = 9;
            this.btnGetConfiguration.Text = "Get Configuration";
            this.btnGetConfiguration.UseVisualStyleBackColor = false;
            this.btnGetConfiguration.Click += new System.EventHandler(this.btnGetConfiguration_Click);
            // 
            // cmbSelectPfno
            // 
            this.cmbSelectPfno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectPfno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbSelectPfno.FormattingEnabled = true;
            this.cmbSelectPfno.Location = new System.Drawing.Point(126, 45);
            this.cmbSelectPfno.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSelectPfno.Name = "cmbSelectPfno";
            this.cmbSelectPfno.Size = new System.Drawing.Size(134, 26);
            this.cmbSelectPfno.TabIndex = 10;
            this.cmbSelectPfno.SelectedIndexChanged += new System.EventHandler(this.cmbSelectPfno_SelectedIndexChanged);
            // 
            // cmbNoofports
            // 
            this.cmbNoofports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoofports.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbNoofports.FormattingEnabled = true;
            this.cmbNoofports.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.cmbNoofports.Location = new System.Drawing.Point(126, 144);
            this.cmbNoofports.Margin = new System.Windows.Forms.Padding(2);
            this.cmbNoofports.Name = "cmbNoofports";
            this.cmbNoofports.Size = new System.Drawing.Size(134, 26);
            this.cmbNoofports.TabIndex = 11;
            this.cmbNoofports.SelectedIndexChanged += new System.EventHandler(this.cmbNoofports_SelectedIndexChanged);
            // 
            // txtportno
            // 
            this.txtportno.BackColor = System.Drawing.Color.White;
            this.txtportno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtportno.Enabled = false;
            this.txtportno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtportno.ForeColor = System.Drawing.SystemColors.Info;
            this.txtportno.Location = new System.Drawing.Point(126, 99);
            this.txtportno.Margin = new System.Windows.Forms.Padding(2);
            this.txtportno.Name = "txtportno";
            this.txtportno.Size = new System.Drawing.Size(134, 24);
            this.txtportno.TabIndex = 12;
            this.txtportno.Text = "1";
            // 
            // txtLocation
            // 
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtLocation.Location = new System.Drawing.Point(543, 88);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(155, 24);
            this.txtLocation.TabIndex = 14;
            this.txtLocation.TextChanged += new System.EventHandler(this.txtLocation_TextChanged);
            // 
            // dgvPdcPorts
            // 
            this.dgvPdcPorts.AllowUserToAddRows = false;
            this.dgvPdcPorts.AllowUserToDeleteRows = false;
            this.dgvPdcPorts.AllowUserToResizeColumns = false;
            this.dgvPdcPorts.AllowUserToResizeRows = false;
            this.dgvPdcPorts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPdcPorts.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPdcPorts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPdcPorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPdcPorts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PortNo,
            this.BoardIP,
            this.BoardType});
            this.dgvPdcPorts.Location = new System.Drawing.Point(369, 129);
            this.dgvPdcPorts.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPdcPorts.Name = "dgvPdcPorts";
            this.dgvPdcPorts.RowHeadersVisible = false;
            this.dgvPdcPorts.RowHeadersWidth = 51;
            this.dgvPdcPorts.RowTemplate.Height = 24;
            this.dgvPdcPorts.Size = new System.Drawing.Size(341, 285);
            this.dgvPdcPorts.TabIndex = 15;
            // 
            // PortNo
            // 
            this.PortNo.FillWeight = 69.12408F;
            this.PortNo.HeaderText = "Port No";
            this.PortNo.MinimumWidth = 6;
            this.PortNo.Name = "PortNo";
            // 
            // BoardIP
            // 
            this.BoardIP.FillWeight = 162.348F;
            this.BoardIP.HeaderText = "Board IP";
            this.BoardIP.MinimumWidth = 6;
            this.BoardIP.Name = "BoardIP";
            // 
            // BoardType
            // 
            this.BoardType.FillWeight = 68.52792F;
            this.BoardType.HeaderText = "Board Type";
            this.BoardType.MinimumWidth = 6;
            this.BoardType.Name = "BoardType";
            // 
            // ipAddressControlplatform
            // 
            this.ipAddressControlplatform.AllowInternalTab = false;
            this.ipAddressControlplatform.AutoHeight = true;
            this.ipAddressControlplatform.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddressControlplatform.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressControlplatform.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressControlplatform.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ipAddressControlplatform.Location = new System.Drawing.Point(543, 43);
            this.ipAddressControlplatform.MinimumSize = new System.Drawing.Size(114, 24);
            this.ipAddressControlplatform.Name = "ipAddressControlplatform";
            this.ipAddressControlplatform.ReadOnly = true;
            this.ipAddressControlplatform.Size = new System.Drawing.Size(155, 24);
            this.ipAddressControlplatform.TabIndex = 16;
            this.ipAddressControlplatform.Text = "...";
            this.ipAddressControlplatform.TextChanged += new System.EventHandler(this.ipAddressControlplatform_TextChanged);
            // 
            // lblPlatformError
            // 
            this.lblPlatformError.AutoSize = true;
            this.lblPlatformError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlatformError.ForeColor = System.Drawing.Color.Red;
            this.lblPlatformError.Location = new System.Drawing.Point(136, 76);
            this.lblPlatformError.Name = "lblPlatformError";
            this.lblPlatformError.Size = new System.Drawing.Size(132, 15);
            this.lblPlatformError.TabIndex = 17;
            this.lblPlatformError.Text = "* Platform alredy Exists";
            this.lblPlatformError.Visible = false;
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblSave.Location = new System.Drawing.Point(424, 447);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(32, 13);
            this.lblSave.TabIndex = 18;
            this.lblSave.Text = "Save";
            this.lblSave.Visible = false;
            // 
            // lblinteroperability
            // 
            this.lblinteroperability.AutoSize = true;
            this.lblinteroperability.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinteroperability.Location = new System.Drawing.Point(11, 189);
            this.lblinteroperability.Name = "lblinteroperability";
            this.lblinteroperability.Size = new System.Drawing.Size(110, 18);
            this.lblinteroperability.TabIndex = 45;
            this.lblinteroperability.Text = "Interoperability :";
            // 
            // tglinteroperability
            // 
            this.tglinteroperability.AutoSize = true;
            this.tglinteroperability.BackColor = System.Drawing.Color.White;
            this.tglinteroperability.Location = new System.Drawing.Point(133, 189);
            this.tglinteroperability.MinimumSize = new System.Drawing.Size(35, 18);
            this.tglinteroperability.Name = "tglinteroperability";
            this.tglinteroperability.OffBackColor = System.Drawing.Color.Gray;
            this.tglinteroperability.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tglinteroperability.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.tglinteroperability.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tglinteroperability.Size = new System.Drawing.Size(35, 18);
            this.tglinteroperability.TabIndex = 44;
            this.tglinteroperability.UseVisualStyleBackColor = false;
            // 
            // frmPdcConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(898, 483);
            this.Controls.Add(this.lblinteroperability);
            this.Controls.Add(this.tglinteroperability);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.lblPlatformError);
            this.Controls.Add(this.ipAddressControlplatform);
            this.Controls.Add(this.dgvPdcPorts);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtportno);
            this.Controls.Add(this.cmbNoofports);
            this.Controls.Add(this.cmbSelectPfno);
            this.Controls.Add(this.btnGetConfiguration);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSetConfiguration);
            this.Controls.Add(this.lblPDCIPaddress);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblActionList);
            this.Controls.Add(this.lblNoOfPorts);
            this.Controls.Add(this.lblPDCPortNo);
            this.Controls.Add(this.lblPlatformNo);
            this.Controls.Add(this.panelPDChedder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPdcConfiguration";
            this.Text = "PdcConfiguration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPdcConfiguration_FormClosing);
            this.Load += new System.EventHandler(this.PdcConfiguration_Load);
            this.panelPDChedder.ResumeLayout(false);
            this.panelPDChedder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPdcPorts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPDChedder;
        private System.Windows.Forms.Label lblpdcipdisplay;
        private System.Windows.Forms.Label lblPlatformNo;
        private System.Windows.Forms.Label lblPDCPortNo;
        private System.Windows.Forms.Label lblNoOfPorts;
        private System.Windows.Forms.Label lblActionList;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblPDCIPaddress;
        private System.Windows.Forms.Button btnSetConfiguration;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGetConfiguration;
        private System.Windows.Forms.ComboBox cmbSelectPfno;
        private System.Windows.Forms.ComboBox cmbNoofports;
        private System.Windows.Forms.TextBox txtportno;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.DataGridView dgvPdcPorts;
        private IPAddressControlLib.IPAddressControl ipAddressControlplatform;
        private System.Windows.Forms.Label lblPlatformError;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoardIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoardType;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Label lblinteroperability;
        private MyControls.ToggleButton tglinteroperability;
    }
}