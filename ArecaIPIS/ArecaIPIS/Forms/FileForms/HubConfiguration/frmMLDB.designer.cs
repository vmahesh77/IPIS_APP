
namespace ArecaIPIS
{
    partial class frmMLDB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMLDBBhadder = new System.Windows.Forms.Panel();
            this.lblMLDBHaddear = new System.Windows.Forms.Label();
            this.btnMLDBBoardSettings = new System.Windows.Forms.Button();
            this.btnMLDBCommonSettings = new System.Windows.Forms.Button();
            this.btnMLDBSave = new System.Windows.Forms.Button();
            this.panelMLDBBoardSettings = new System.Windows.Forms.Panel();
            this.lblinteroperability = new System.Windows.Forms.Label();
            this.tglinteroperability = new ArecaIPIS.MyControls.ToggleButton();
            this.lblIpExist = new System.Windows.Forms.Label();
            this.lblMLDBErrorMessage = new System.Windows.Forms.Label();
            this.ipAddressMldb = new IPAddressControlLib.IPAddressControl();
            this.grupMLDBPlatforms = new System.Windows.Forms.GroupBox();
            this.grupMLDBMessages = new System.Windows.Forms.GroupBox();
            this.checkMLDBBoxShowMessages = new System.Windows.Forms.CheckBox();
            this.grupMLDBBoardRunning = new System.Windows.Forms.GroupBox();
            this.rdbnMLDBNotWorking = new System.Windows.Forms.RadioButton();
            this.rdbnMLDBWorking = new System.Windows.Forms.RadioButton();
            this.lblMLDBNoOfLines = new System.Windows.Forms.Label();
            this.lblMLDBBoardIP = new System.Windows.Forms.Label();
            this.lblMLDBEthernetPortNo = new System.Windows.Forms.Label();
            this.lblMLDBLocation = new System.Windows.Forms.Label();
            this.lblMLDBBoardID = new System.Windows.Forms.Label();
            this.txtMLDBNooflines = new System.Windows.Forms.TextBox();
            this.txtMLDBEthernetportno = new System.Windows.Forms.TextBox();
            this.txtMLDBLocation = new System.Windows.Forms.TextBox();
            this.txtMLDBBoardid = new System.Windows.Forms.TextBox();
            this.grupMLDBDisplaySequence = new System.Windows.Forms.GroupBox();
            this.dgvLanguage = new System.Windows.Forms.DataGridView();
            this.dgvLanguages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUpButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.DgvDown = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelMLDBCommonSettings = new System.Windows.Forms.Panel();
            this.CmbMLDBFormattype = new System.Windows.Forms.ComboBox();
            this.CmbMLDBlettergap = new System.Windows.Forms.ComboBox();
            this.CmbMLDBinfoDisplayed = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.btnHKeyboard = new System.Windows.Forms.Button();
            this.btnRKeyboard = new System.Windows.Forms.Button();
            this.lblMLDBEnglish = new System.Windows.Forms.Label();
            this.txtMLDBRegional = new System.Windows.Forms.TextBox();
            this.lblMLDBRegional = new System.Windows.Forms.Label();
            this.txtMLDBHindi = new System.Windows.Forms.TextBox();
            this.lblMLDBHindi = new System.Windows.Forms.Label();
            this.txtMLDBEnglish = new System.Windows.Forms.TextBox();
            this.cmbMLDBVideoType = new System.Windows.Forms.ComboBox();
            this.CmbMLDBLetterSpeed = new System.Windows.Forms.ComboBox();
            this.lblMLDBRequiredAutoErasing = new System.Windows.Forms.Label();
            this.lblMLDBFormatType = new System.Windows.Forms.Label();
            this.lblMLDBLetterSpeed = new System.Windows.Forms.Label();
            this.lblMLDBVideotype = new System.Windows.Forms.Label();
            this.checkboxMLDBAutoerasing = new System.Windows.Forms.CheckBox();
            this.CmbMLDBDelaytime = new System.Windows.Forms.ComboBox();
            this.lblMLDBDelayTime = new System.Windows.Forms.Label();
            this.lblMLDBSec = new System.Windows.Forms.Label();
            this.lblMLDBLetterGap = new System.Windows.Forms.Label();
            this.lblMLDBDisplayEffect = new System.Windows.Forms.Label();
            this.lblMLDBFontSize = new System.Windows.Forms.Label();
            this.lblMLDBEraseTime = new System.Windows.Forms.Label();
            this.lblMLDBInfoDisplayed = new System.Windows.Forms.Label();
            this.txtMLDBErasetime = new System.Windows.Forms.TextBox();
            this.lblMLDBMin = new System.Windows.Forms.Label();
            this.CmbMLDBfontSize = new System.Windows.Forms.ComboBox();
            this.CmbMLDBDisplayeffect = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.errorProviderMLDB = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelMLDBBhadder.SuspendLayout();
            this.panelMLDBBoardSettings.SuspendLayout();
            this.grupMLDBMessages.SuspendLayout();
            this.grupMLDBBoardRunning.SuspendLayout();
            this.grupMLDBDisplaySequence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguage)).BeginInit();
            this.panelMLDBCommonSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMLDB)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMLDBBhadder
            // 
            this.panelMLDBBhadder.BackColor = System.Drawing.Color.Red;
            this.panelMLDBBhadder.Controls.Add(this.lblMLDBHaddear);
            this.panelMLDBBhadder.Location = new System.Drawing.Point(1, -4);
            this.panelMLDBBhadder.Margin = new System.Windows.Forms.Padding(4);
            this.panelMLDBBhadder.Name = "panelMLDBBhadder";
            this.panelMLDBBhadder.Size = new System.Drawing.Size(855, 33);
            this.panelMLDBBhadder.TabIndex = 5;
            // 
            // lblMLDBHaddear
            // 
            this.lblMLDBHaddear.AutoSize = true;
            this.lblMLDBHaddear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMLDBHaddear.ForeColor = System.Drawing.Color.Black;
            this.lblMLDBHaddear.Location = new System.Drawing.Point(104, 8);
            this.lblMLDBHaddear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBHaddear.Name = "lblMLDBHaddear";
            this.lblMLDBHaddear.Size = new System.Drawing.Size(616, 24);
            this.lblMLDBHaddear.TabIndex = 0;
            this.lblMLDBHaddear.Text = "Multi Line Display Board (IP Range 192.168.X.101-192.168.X.130)";
            this.lblMLDBHaddear.Click += new System.EventHandler(this.lblMLDBHaddear_Click);
            // 
            // btnMLDBBoardSettings
            // 
            this.btnMLDBBoardSettings.BackColor = System.Drawing.Color.Black;
            this.btnMLDBBoardSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnMLDBBoardSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnMLDBBoardSettings.Location = new System.Drawing.Point(293, 31);
            this.btnMLDBBoardSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnMLDBBoardSettings.Name = "btnMLDBBoardSettings";
            this.btnMLDBBoardSettings.Size = new System.Drawing.Size(266, 35);
            this.btnMLDBBoardSettings.TabIndex = 41;
            this.btnMLDBBoardSettings.Text = "Board Settings";
            this.btnMLDBBoardSettings.UseVisualStyleBackColor = false;
            this.btnMLDBBoardSettings.Click += new System.EventHandler(this.btnMLDBBoardSettings_Click);
            // 
            // btnMLDBCommonSettings
            // 
            this.btnMLDBCommonSettings.BackColor = System.Drawing.Color.Black;
            this.btnMLDBCommonSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnMLDBCommonSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnMLDBCommonSettings.Location = new System.Drawing.Point(9, 31);
            this.btnMLDBCommonSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnMLDBCommonSettings.Name = "btnMLDBCommonSettings";
            this.btnMLDBCommonSettings.Size = new System.Drawing.Size(278, 36);
            this.btnMLDBCommonSettings.TabIndex = 40;
            this.btnMLDBCommonSettings.Text = "Common Settings";
            this.btnMLDBCommonSettings.UseVisualStyleBackColor = false;
            this.btnMLDBCommonSettings.Click += new System.EventHandler(this.btnMLDBCommonSettings_Click);
            // 
            // btnMLDBSave
            // 
            this.btnMLDBSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnMLDBSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMLDBSave.ForeColor = System.Drawing.Color.White;
            this.btnMLDBSave.Location = new System.Drawing.Point(241, 435);
            this.btnMLDBSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnMLDBSave.Name = "btnMLDBSave";
            this.btnMLDBSave.Size = new System.Drawing.Size(93, 37);
            this.btnMLDBSave.TabIndex = 4;
            this.btnMLDBSave.Text = "Save";
            this.btnMLDBSave.UseVisualStyleBackColor = false;
            this.btnMLDBSave.Click += new System.EventHandler(this.btnMLDBSave_Click);
            // 
            // panelMLDBBoardSettings
            // 
            this.panelMLDBBoardSettings.Controls.Add(this.lblinteroperability);
            this.panelMLDBBoardSettings.Controls.Add(this.tglinteroperability);
            this.panelMLDBBoardSettings.Controls.Add(this.lblIpExist);
            this.panelMLDBBoardSettings.Controls.Add(this.lblMLDBErrorMessage);
            this.panelMLDBBoardSettings.Controls.Add(this.ipAddressMldb);
            this.panelMLDBBoardSettings.Controls.Add(this.grupMLDBPlatforms);
            this.panelMLDBBoardSettings.Controls.Add(this.grupMLDBMessages);
            this.panelMLDBBoardSettings.Controls.Add(this.grupMLDBBoardRunning);
            this.panelMLDBBoardSettings.Controls.Add(this.lblMLDBNoOfLines);
            this.panelMLDBBoardSettings.Controls.Add(this.lblMLDBBoardIP);
            this.panelMLDBBoardSettings.Controls.Add(this.lblMLDBEthernetPortNo);
            this.panelMLDBBoardSettings.Controls.Add(this.lblMLDBLocation);
            this.panelMLDBBoardSettings.Controls.Add(this.lblMLDBBoardID);
            this.panelMLDBBoardSettings.Controls.Add(this.txtMLDBNooflines);
            this.panelMLDBBoardSettings.Controls.Add(this.txtMLDBEthernetportno);
            this.panelMLDBBoardSettings.Controls.Add(this.txtMLDBLocation);
            this.panelMLDBBoardSettings.Controls.Add(this.txtMLDBBoardid);
            this.panelMLDBBoardSettings.Controls.Add(this.grupMLDBDisplaySequence);
            this.panelMLDBBoardSettings.Location = new System.Drawing.Point(17, 77);
            this.panelMLDBBoardSettings.Margin = new System.Windows.Forms.Padding(2);
            this.panelMLDBBoardSettings.Name = "panelMLDBBoardSettings";
            this.panelMLDBBoardSettings.Size = new System.Drawing.Size(850, 342);
            this.panelMLDBBoardSettings.TabIndex = 43;
            this.panelMLDBBoardSettings.Visible = false;
            // 
            // lblinteroperability
            // 
            this.lblinteroperability.AutoSize = true;
            this.lblinteroperability.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinteroperability.Location = new System.Drawing.Point(12, 298);
            this.lblinteroperability.Name = "lblinteroperability";
            this.lblinteroperability.Size = new System.Drawing.Size(110, 18);
            this.lblinteroperability.TabIndex = 45;
            this.lblinteroperability.Text = "Interoperability :";
            // 
            // tglinteroperability
            // 
            this.tglinteroperability.AutoSize = true;
            this.tglinteroperability.BackColor = System.Drawing.Color.White;
            this.tglinteroperability.Location = new System.Drawing.Point(134, 298);
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
            // lblIpExist
            // 
            this.lblIpExist.AutoSize = true;
            this.lblIpExist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpExist.ForeColor = System.Drawing.Color.Red;
            this.lblIpExist.Location = new System.Drawing.Point(134, 190);
            this.lblIpExist.Name = "lblIpExist";
            this.lblIpExist.Size = new System.Drawing.Size(111, 13);
            this.lblIpExist.TabIndex = 34;
            this.lblIpExist.Text = "IP ALREADY EXISTS";
            this.lblIpExist.Visible = false;
            // 
            // lblMLDBErrorMessage
            // 
            this.lblMLDBErrorMessage.AutoSize = true;
            this.lblMLDBErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMLDBErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMLDBErrorMessage.Location = new System.Drawing.Point(12, 174);
            this.lblMLDBErrorMessage.Name = "lblMLDBErrorMessage";
            this.lblMLDBErrorMessage.Size = new System.Drawing.Size(305, 13);
            this.lblMLDBErrorMessage.TabIndex = 33;
            this.lblMLDBErrorMessage.Text = "The last octet of the IP address must be between 101 and 130.";
            this.lblMLDBErrorMessage.Visible = false;
            // 
            // ipAddressMldb
            // 
            this.ipAddressMldb.AllowInternalTab = false;
            this.ipAddressMldb.AutoHeight = true;
            this.ipAddressMldb.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddressMldb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressMldb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressMldb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressMldb.Location = new System.Drawing.Point(137, 138);
            this.ipAddressMldb.MinimumSize = new System.Drawing.Size(99, 22);
            this.ipAddressMldb.Name = "ipAddressMldb";
            this.ipAddressMldb.ReadOnly = false;
            this.ipAddressMldb.Size = new System.Drawing.Size(150, 22);
            this.ipAddressMldb.TabIndex = 32;
            this.ipAddressMldb.Text = "192.168.0.";
            this.ipAddressMldb.TextChanged += new System.EventHandler(this.ipAddressMldb_TextChanged);
            this.ipAddressMldb.Enter += new System.EventHandler(this.ipAddressMldb_Enter);
            this.ipAddressMldb.Leave += new System.EventHandler(this.ipAddressMldb_Leave);
            // 
            // grupMLDBPlatforms
            // 
            this.grupMLDBPlatforms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupMLDBPlatforms.Location = new System.Drawing.Point(539, 8);
            this.grupMLDBPlatforms.Margin = new System.Windows.Forms.Padding(2);
            this.grupMLDBPlatforms.Name = "grupMLDBPlatforms";
            this.grupMLDBPlatforms.Padding = new System.Windows.Forms.Padding(2);
            this.grupMLDBPlatforms.Size = new System.Drawing.Size(300, 282);
            this.grupMLDBPlatforms.TabIndex = 29;
            this.grupMLDBPlatforms.TabStop = false;
            this.grupMLDBPlatforms.Text = "Platforms";
            // 
            // grupMLDBMessages
            // 
            this.grupMLDBMessages.Controls.Add(this.checkMLDBBoxShowMessages);
            this.grupMLDBMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupMLDBMessages.Location = new System.Drawing.Point(322, 226);
            this.grupMLDBMessages.Margin = new System.Windows.Forms.Padding(2);
            this.grupMLDBMessages.Name = "grupMLDBMessages";
            this.grupMLDBMessages.Padding = new System.Windows.Forms.Padding(2);
            this.grupMLDBMessages.Size = new System.Drawing.Size(226, 47);
            this.grupMLDBMessages.TabIndex = 31;
            this.grupMLDBMessages.TabStop = false;
            this.grupMLDBMessages.Text = "Messages";
            // 
            // checkMLDBBoxShowMessages
            // 
            this.checkMLDBBoxShowMessages.AutoSize = true;
            this.checkMLDBBoxShowMessages.Checked = true;
            this.checkMLDBBoxShowMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMLDBBoxShowMessages.Location = new System.Drawing.Point(58, 20);
            this.checkMLDBBoxShowMessages.Margin = new System.Windows.Forms.Padding(2);
            this.checkMLDBBoxShowMessages.Name = "checkMLDBBoxShowMessages";
            this.checkMLDBBoxShowMessages.Size = new System.Drawing.Size(138, 22);
            this.checkMLDBBoxShowMessages.TabIndex = 0;
            this.checkMLDBBoxShowMessages.Text = "Show Messages";
            this.checkMLDBBoxShowMessages.UseVisualStyleBackColor = true;
            this.checkMLDBBoxShowMessages.CheckedChanged += new System.EventHandler(this.checkMLDBBoxShowMessages_CheckedChanged);
            // 
            // grupMLDBBoardRunning
            // 
            this.grupMLDBBoardRunning.Controls.Add(this.rdbnMLDBNotWorking);
            this.grupMLDBBoardRunning.Controls.Add(this.rdbnMLDBWorking);
            this.grupMLDBBoardRunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupMLDBBoardRunning.Location = new System.Drawing.Point(12, 224);
            this.grupMLDBBoardRunning.Margin = new System.Windows.Forms.Padding(2);
            this.grupMLDBBoardRunning.Name = "grupMLDBBoardRunning";
            this.grupMLDBBoardRunning.Padding = new System.Windows.Forms.Padding(2);
            this.grupMLDBBoardRunning.Size = new System.Drawing.Size(289, 52);
            this.grupMLDBBoardRunning.TabIndex = 30;
            this.grupMLDBBoardRunning.TabStop = false;
            this.grupMLDBBoardRunning.Text = "Board Running";
            // 
            // rdbnMLDBNotWorking
            // 
            this.rdbnMLDBNotWorking.AutoSize = true;
            this.rdbnMLDBNotWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbnMLDBNotWorking.Location = new System.Drawing.Point(160, 25);
            this.rdbnMLDBNotWorking.Margin = new System.Windows.Forms.Padding(2);
            this.rdbnMLDBNotWorking.Name = "rdbnMLDBNotWorking";
            this.rdbnMLDBNotWorking.Size = new System.Drawing.Size(110, 22);
            this.rdbnMLDBNotWorking.TabIndex = 1;
            this.rdbnMLDBNotWorking.Text = "Not Working";
            this.rdbnMLDBNotWorking.UseVisualStyleBackColor = true;
            // 
            // rdbnMLDBWorking
            // 
            this.rdbnMLDBWorking.AutoSize = true;
            this.rdbnMLDBWorking.Checked = true;
            this.rdbnMLDBWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbnMLDBWorking.Location = new System.Drawing.Point(25, 25);
            this.rdbnMLDBWorking.Margin = new System.Windows.Forms.Padding(2);
            this.rdbnMLDBWorking.Name = "rdbnMLDBWorking";
            this.rdbnMLDBWorking.Size = new System.Drawing.Size(82, 22);
            this.rdbnMLDBWorking.TabIndex = 0;
            this.rdbnMLDBWorking.TabStop = true;
            this.rdbnMLDBWorking.Text = "Working";
            this.rdbnMLDBWorking.UseVisualStyleBackColor = true;
            // 
            // lblMLDBNoOfLines
            // 
            this.lblMLDBNoOfLines.AutoSize = true;
            this.lblMLDBNoOfLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMLDBNoOfLines.Location = new System.Drawing.Point(12, 104);
            this.lblMLDBNoOfLines.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMLDBNoOfLines.Name = "lblMLDBNoOfLines";
            this.lblMLDBNoOfLines.Size = new System.Drawing.Size(87, 18);
            this.lblMLDBNoOfLines.TabIndex = 22;
            this.lblMLDBNoOfLines.Text = "No Of Lines";
            // 
            // lblMLDBBoardIP
            // 
            this.lblMLDBBoardIP.AutoSize = true;
            this.lblMLDBBoardIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMLDBBoardIP.Location = new System.Drawing.Point(12, 139);
            this.lblMLDBBoardIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMLDBBoardIP.Name = "lblMLDBBoardIP";
            this.lblMLDBBoardIP.Size = new System.Drawing.Size(65, 18);
            this.lblMLDBBoardIP.TabIndex = 21;
            this.lblMLDBBoardIP.Text = "Board IP";
            // 
            // lblMLDBEthernetPortNo
            // 
            this.lblMLDBEthernetPortNo.AutoSize = true;
            this.lblMLDBEthernetPortNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMLDBEthernetPortNo.Location = new System.Drawing.Point(12, 69);
            this.lblMLDBEthernetPortNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMLDBEthernetPortNo.Name = "lblMLDBEthernetPortNo";
            this.lblMLDBEthernetPortNo.Size = new System.Drawing.Size(119, 18);
            this.lblMLDBEthernetPortNo.TabIndex = 20;
            this.lblMLDBEthernetPortNo.Text = "Ethernet Port No";
            // 
            // lblMLDBLocation
            // 
            this.lblMLDBLocation.AutoSize = true;
            this.lblMLDBLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMLDBLocation.Location = new System.Drawing.Point(12, 36);
            this.lblMLDBLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMLDBLocation.Name = "lblMLDBLocation";
            this.lblMLDBLocation.Size = new System.Drawing.Size(65, 18);
            this.lblMLDBLocation.TabIndex = 19;
            this.lblMLDBLocation.Text = "Location";
            // 
            // lblMLDBBoardID
            // 
            this.lblMLDBBoardID.AutoSize = true;
            this.lblMLDBBoardID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMLDBBoardID.Location = new System.Drawing.Point(12, 9);
            this.lblMLDBBoardID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMLDBBoardID.Name = "lblMLDBBoardID";
            this.lblMLDBBoardID.Size = new System.Drawing.Size(66, 18);
            this.lblMLDBBoardID.TabIndex = 18;
            this.lblMLDBBoardID.Text = "Board ID";
            // 
            // txtMLDBNooflines
            // 
            this.txtMLDBNooflines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMLDBNooflines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMLDBNooflines.Location = new System.Drawing.Point(137, 101);
            this.txtMLDBNooflines.Margin = new System.Windows.Forms.Padding(2);
            this.txtMLDBNooflines.Name = "txtMLDBNooflines";
            this.txtMLDBNooflines.Size = new System.Drawing.Size(152, 23);
            this.txtMLDBNooflines.TabIndex = 24;
            this.txtMLDBNooflines.Text = "5";
            this.txtMLDBNooflines.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMLDBNooflines_KeyPress);
            // 
            // txtMLDBEthernetportno
            // 
            this.txtMLDBEthernetportno.BackColor = System.Drawing.Color.White;
            this.txtMLDBEthernetportno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMLDBEthernetportno.Enabled = false;
            this.txtMLDBEthernetportno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMLDBEthernetportno.Location = new System.Drawing.Point(137, 68);
            this.txtMLDBEthernetportno.Margin = new System.Windows.Forms.Padding(2);
            this.txtMLDBEthernetportno.Name = "txtMLDBEthernetportno";
            this.txtMLDBEthernetportno.Size = new System.Drawing.Size(152, 23);
            this.txtMLDBEthernetportno.TabIndex = 26;
            // 
            // txtMLDBLocation
            // 
            this.txtMLDBLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMLDBLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMLDBLocation.Location = new System.Drawing.Point(137, 37);
            this.txtMLDBLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtMLDBLocation.Name = "txtMLDBLocation";
            this.txtMLDBLocation.Size = new System.Drawing.Size(152, 23);
            this.txtMLDBLocation.TabIndex = 27;
            // 
            // txtMLDBBoardid
            // 
            this.txtMLDBBoardid.BackColor = System.Drawing.Color.White;
            this.txtMLDBBoardid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMLDBBoardid.Enabled = false;
            this.txtMLDBBoardid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMLDBBoardid.Location = new System.Drawing.Point(137, 8);
            this.txtMLDBBoardid.Margin = new System.Windows.Forms.Padding(2);
            this.txtMLDBBoardid.Name = "txtMLDBBoardid";
            this.txtMLDBBoardid.Size = new System.Drawing.Size(152, 23);
            this.txtMLDBBoardid.TabIndex = 23;
            // 
            // grupMLDBDisplaySequence
            // 
            this.grupMLDBDisplaySequence.Controls.Add(this.dgvLanguage);
            this.grupMLDBDisplaySequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupMLDBDisplaySequence.Location = new System.Drawing.Point(316, 9);
            this.grupMLDBDisplaySequence.Margin = new System.Windows.Forms.Padding(2);
            this.grupMLDBDisplaySequence.Name = "grupMLDBDisplaySequence";
            this.grupMLDBDisplaySequence.Padding = new System.Windows.Forms.Padding(2);
            this.grupMLDBDisplaySequence.Size = new System.Drawing.Size(232, 147);
            this.grupMLDBDisplaySequence.TabIndex = 28;
            this.grupMLDBDisplaySequence.TabStop = false;
            this.grupMLDBDisplaySequence.Text = "Display Sequence";
            // 
            // dgvLanguage
            // 
            this.dgvLanguage.AllowUserToAddRows = false;
            this.dgvLanguage.AllowUserToResizeColumns = false;
            this.dgvLanguage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLanguage.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLanguage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLanguage.ColumnHeadersVisible = false;
            this.dgvLanguage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvLanguages,
            this.dgvUpButton,
            this.DgvDown});
            this.dgvLanguage.Location = new System.Drawing.Point(0, 22);
            this.dgvLanguage.Name = "dgvLanguage";
            this.dgvLanguage.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLanguage.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLanguage.RowTemplate.Height = 100;
            this.dgvLanguage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvLanguage.Size = new System.Drawing.Size(218, 121);
            this.dgvLanguage.TabIndex = 0;
            this.dgvLanguage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLanguage_CellContentClick);
            // 
            // dgvLanguages
            // 
            this.dgvLanguages.FillWeight = 152.2843F;
            this.dgvLanguages.HeaderText = "language";
            this.dgvLanguages.Name = "dgvLanguages";
            this.dgvLanguages.ReadOnly = true;
            // 
            // dgvUpButton
            // 
            this.dgvUpButton.FillWeight = 73.85786F;
            this.dgvUpButton.HeaderText = "up";
            this.dgvUpButton.Image = global::ArecaIPIS.Properties.Resources._211624_c_up_arrow_icon;
            this.dgvUpButton.Name = "dgvUpButton";
            this.dgvUpButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DgvDown
            // 
            this.DgvDown.FillWeight = 73.85786F;
            this.DgvDown.HeaderText = "Down";
            this.DgvDown.Image = global::ArecaIPIS.Properties.Resources.DownArrow;
            this.DgvDown.Name = "DgvDown";
            this.DgvDown.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvDown.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panelMLDBCommonSettings
            // 
            this.panelMLDBCommonSettings.Controls.Add(this.CmbMLDBFormattype);
            this.panelMLDBCommonSettings.Controls.Add(this.CmbMLDBlettergap);
            this.panelMLDBCommonSettings.Controls.Add(this.CmbMLDBinfoDisplayed);
            this.panelMLDBCommonSettings.Controls.Add(this.groupBox1);
            this.panelMLDBCommonSettings.Controls.Add(this.cmbMLDBVideoType);
            this.panelMLDBCommonSettings.Controls.Add(this.CmbMLDBLetterSpeed);
            this.panelMLDBCommonSettings.Controls.Add(this.lblMLDBRequiredAutoErasing);
            this.panelMLDBCommonSettings.Controls.Add(this.lblMLDBFormatType);
            this.panelMLDBCommonSettings.Controls.Add(this.lblMLDBLetterSpeed);
            this.panelMLDBCommonSettings.Controls.Add(this.lblMLDBVideotype);
            this.panelMLDBCommonSettings.Controls.Add(this.checkboxMLDBAutoerasing);
            this.panelMLDBCommonSettings.Controls.Add(this.CmbMLDBDelaytime);
            this.panelMLDBCommonSettings.Controls.Add(this.lblMLDBDelayTime);
            this.panelMLDBCommonSettings.Controls.Add(this.lblMLDBSec);
            this.panelMLDBCommonSettings.Controls.Add(this.lblMLDBLetterGap);
            this.panelMLDBCommonSettings.Controls.Add(this.lblMLDBDisplayEffect);
            this.panelMLDBCommonSettings.Controls.Add(this.lblMLDBFontSize);
            this.panelMLDBCommonSettings.Controls.Add(this.lblMLDBEraseTime);
            this.panelMLDBCommonSettings.Controls.Add(this.lblMLDBInfoDisplayed);
            this.panelMLDBCommonSettings.Controls.Add(this.txtMLDBErasetime);
            this.panelMLDBCommonSettings.Controls.Add(this.lblMLDBMin);
            this.panelMLDBCommonSettings.Controls.Add(this.CmbMLDBfontSize);
            this.panelMLDBCommonSettings.Controls.Add(this.CmbMLDBDisplayeffect);
            this.panelMLDBCommonSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMLDBCommonSettings.Location = new System.Drawing.Point(11, 73);
            this.panelMLDBCommonSettings.Margin = new System.Windows.Forms.Padding(2);
            this.panelMLDBCommonSettings.Name = "panelMLDBCommonSettings";
            this.panelMLDBCommonSettings.Size = new System.Drawing.Size(845, 344);
            this.panelMLDBCommonSettings.TabIndex = 41;
            this.panelMLDBCommonSettings.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMLDBCommonSettings_Paint);
            // 
            // CmbMLDBFormattype
            // 
            this.CmbMLDBFormattype.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CmbMLDBFormattype.FormattingEnabled = true;
            this.CmbMLDBFormattype.Location = new System.Drawing.Point(138, 76);
            this.CmbMLDBFormattype.Name = "CmbMLDBFormattype";
            this.CmbMLDBFormattype.Size = new System.Drawing.Size(150, 26);
            this.CmbMLDBFormattype.TabIndex = 35;
            // 
            // CmbMLDBlettergap
            // 
            this.CmbMLDBlettergap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CmbMLDBlettergap.FormattingEnabled = true;
            this.CmbMLDBlettergap.Location = new System.Drawing.Point(536, 6);
            this.CmbMLDBlettergap.Name = "CmbMLDBlettergap";
            this.CmbMLDBlettergap.Size = new System.Drawing.Size(199, 26);
            this.CmbMLDBlettergap.TabIndex = 34;
            // 
            // CmbMLDBinfoDisplayed
            // 
            this.CmbMLDBinfoDisplayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CmbMLDBinfoDisplayed.FormattingEnabled = true;
            this.CmbMLDBinfoDisplayed.Location = new System.Drawing.Point(537, 141);
            this.CmbMLDBinfoDisplayed.Name = "CmbMLDBinfoDisplayed";
            this.CmbMLDBinfoDisplayed.Size = new System.Drawing.Size(121, 26);
            this.CmbMLDBinfoDisplayed.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKeyboard);
            this.groupBox1.Controls.Add(this.btnHKeyboard);
            this.groupBox1.Controls.Add(this.btnRKeyboard);
            this.groupBox1.Controls.Add(this.lblMLDBEnglish);
            this.groupBox1.Controls.Add(this.txtMLDBRegional);
            this.groupBox1.Controls.Add(this.lblMLDBRegional);
            this.groupBox1.Controls.Add(this.txtMLDBHindi);
            this.groupBox1.Controls.Add(this.lblMLDBHindi);
            this.groupBox1.Controls.Add(this.txtMLDBEnglish);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkViolet;
            this.groupBox1.Location = new System.Drawing.Point(6, 238);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 98);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default Data to be Displayed in the Board";
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.FlatAppearance.BorderSize = 0;
            this.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnKeyboard.Image = global::ArecaIPIS.Properties.Resources._3671786_keyboard_icon__1_;
            this.btnKeyboard.Location = new System.Drawing.Point(371, 26);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(23, 19);
            this.btnKeyboard.TabIndex = 75;
            this.btnKeyboard.UseVisualStyleBackColor = true;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // btnHKeyboard
            // 
            this.btnHKeyboard.FlatAppearance.BorderSize = 0;
            this.btnHKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnHKeyboard.Image = global::ArecaIPIS.Properties.Resources._3671786_keyboard_icon__1_;
            this.btnHKeyboard.Location = new System.Drawing.Point(373, 66);
            this.btnHKeyboard.Name = "btnHKeyboard";
            this.btnHKeyboard.Size = new System.Drawing.Size(23, 19);
            this.btnHKeyboard.TabIndex = 74;
            this.btnHKeyboard.UseVisualStyleBackColor = true;
            this.btnHKeyboard.Click += new System.EventHandler(this.btnHKeyboard_Click);
            // 
            // btnRKeyboard
            // 
            this.btnRKeyboard.FlatAppearance.BorderSize = 0;
            this.btnRKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRKeyboard.Image = global::ArecaIPIS.Properties.Resources._3671786_keyboard_icon__1_;
            this.btnRKeyboard.Location = new System.Drawing.Point(797, 26);
            this.btnRKeyboard.Name = "btnRKeyboard";
            this.btnRKeyboard.Size = new System.Drawing.Size(23, 19);
            this.btnRKeyboard.TabIndex = 73;
            this.btnRKeyboard.UseVisualStyleBackColor = true;
            this.btnRKeyboard.Visible = false;
            this.btnRKeyboard.Click += new System.EventHandler(this.btnRKeyboard_Click);
            // 
            // lblMLDBEnglish
            // 
            this.lblMLDBEnglish.AutoSize = true;
            this.lblMLDBEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblMLDBEnglish.ForeColor = System.Drawing.Color.Black;
            this.lblMLDBEnglish.Location = new System.Drawing.Point(5, 25);
            this.lblMLDBEnglish.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBEnglish.Name = "lblMLDBEnglish";
            this.lblMLDBEnglish.Size = new System.Drawing.Size(68, 20);
            this.lblMLDBEnglish.TabIndex = 9;
            this.lblMLDBEnglish.Text = "English";
            // 
            // txtMLDBRegional
            // 
            this.txtMLDBRegional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMLDBRegional.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMLDBRegional.Location = new System.Drawing.Point(538, 19);
            this.txtMLDBRegional.Margin = new System.Windows.Forms.Padding(2);
            this.txtMLDBRegional.Name = "txtMLDBRegional";
            this.txtMLDBRegional.Size = new System.Drawing.Size(257, 26);
            this.txtMLDBRegional.TabIndex = 2;
            this.txtMLDBRegional.Visible = false;
            // 
            // lblMLDBRegional
            // 
            this.lblMLDBRegional.AutoSize = true;
            this.lblMLDBRegional.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblMLDBRegional.ForeColor = System.Drawing.Color.Black;
            this.lblMLDBRegional.Location = new System.Drawing.Point(411, 25);
            this.lblMLDBRegional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBRegional.Name = "lblMLDBRegional";
            this.lblMLDBRegional.Size = new System.Drawing.Size(80, 20);
            this.lblMLDBRegional.TabIndex = 10;
            this.lblMLDBRegional.Text = "Regional";
            this.lblMLDBRegional.Visible = false;
            // 
            // txtMLDBHindi
            // 
            this.txtMLDBHindi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMLDBHindi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMLDBHindi.Location = new System.Drawing.Point(99, 64);
            this.txtMLDBHindi.Margin = new System.Windows.Forms.Padding(2);
            this.txtMLDBHindi.Name = "txtMLDBHindi";
            this.txtMLDBHindi.Size = new System.Drawing.Size(260, 26);
            this.txtMLDBHindi.TabIndex = 3;
            // 
            // lblMLDBHindi
            // 
            this.lblMLDBHindi.AutoSize = true;
            this.lblMLDBHindi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblMLDBHindi.ForeColor = System.Drawing.Color.Black;
            this.lblMLDBHindi.Location = new System.Drawing.Point(8, 64);
            this.lblMLDBHindi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBHindi.Name = "lblMLDBHindi";
            this.lblMLDBHindi.Size = new System.Drawing.Size(50, 20);
            this.lblMLDBHindi.TabIndex = 11;
            this.lblMLDBHindi.Text = "Hindi";
            // 
            // txtMLDBEnglish
            // 
            this.txtMLDBEnglish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMLDBEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMLDBEnglish.Location = new System.Drawing.Point(100, 19);
            this.txtMLDBEnglish.Margin = new System.Windows.Forms.Padding(2);
            this.txtMLDBEnglish.Name = "txtMLDBEnglish";
            this.txtMLDBEnglish.Size = new System.Drawing.Size(260, 26);
            this.txtMLDBEnglish.TabIndex = 1;
            this.txtMLDBEnglish.TextChanged += new System.EventHandler(this.txtMLDBEnglish_TextChanged);
            // 
            // cmbMLDBVideoType
            // 
            this.cmbMLDBVideoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMLDBVideoType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbMLDBVideoType.FormattingEnabled = true;
            this.cmbMLDBVideoType.Items.AddRange(new object[] {
            "Normal",
            "Reverse"});
            this.cmbMLDBVideoType.Location = new System.Drawing.Point(138, 6);
            this.cmbMLDBVideoType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMLDBVideoType.Name = "cmbMLDBVideoType";
            this.cmbMLDBVideoType.Size = new System.Drawing.Size(150, 26);
            this.cmbMLDBVideoType.TabIndex = 19;
            // 
            // CmbMLDBLetterSpeed
            // 
            this.CmbMLDBLetterSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMLDBLetterSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CmbMLDBLetterSpeed.FormattingEnabled = true;
            this.CmbMLDBLetterSpeed.Location = new System.Drawing.Point(138, 40);
            this.CmbMLDBLetterSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.CmbMLDBLetterSpeed.Name = "CmbMLDBLetterSpeed";
            this.CmbMLDBLetterSpeed.Size = new System.Drawing.Size(150, 26);
            this.CmbMLDBLetterSpeed.TabIndex = 21;
            // 
            // lblMLDBRequiredAutoErasing
            // 
            this.lblMLDBRequiredAutoErasing.AutoSize = true;
            this.lblMLDBRequiredAutoErasing.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMLDBRequiredAutoErasing.Location = new System.Drawing.Point(10, 113);
            this.lblMLDBRequiredAutoErasing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBRequiredAutoErasing.Name = "lblMLDBRequiredAutoErasing";
            this.lblMLDBRequiredAutoErasing.Size = new System.Drawing.Size(155, 18);
            this.lblMLDBRequiredAutoErasing.TabIndex = 6;
            this.lblMLDBRequiredAutoErasing.Text = "Required Auto Erasing";
            // 
            // lblMLDBFormatType
            // 
            this.lblMLDBFormatType.AutoSize = true;
            this.lblMLDBFormatType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMLDBFormatType.Location = new System.Drawing.Point(10, 81);
            this.lblMLDBFormatType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBFormatType.Name = "lblMLDBFormatType";
            this.lblMLDBFormatType.Size = new System.Drawing.Size(92, 18);
            this.lblMLDBFormatType.TabIndex = 5;
            this.lblMLDBFormatType.Text = "Format Type";
            // 
            // lblMLDBLetterSpeed
            // 
            this.lblMLDBLetterSpeed.AutoSize = true;
            this.lblMLDBLetterSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMLDBLetterSpeed.Location = new System.Drawing.Point(10, 45);
            this.lblMLDBLetterSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBLetterSpeed.Name = "lblMLDBLetterSpeed";
            this.lblMLDBLetterSpeed.Size = new System.Drawing.Size(91, 18);
            this.lblMLDBLetterSpeed.TabIndex = 4;
            this.lblMLDBLetterSpeed.Text = "Letter Speed";
            // 
            // lblMLDBVideotype
            // 
            this.lblMLDBVideotype.AutoSize = true;
            this.lblMLDBVideotype.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMLDBVideotype.Location = new System.Drawing.Point(10, 11);
            this.lblMLDBVideotype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBVideotype.Name = "lblMLDBVideotype";
            this.lblMLDBVideotype.Size = new System.Drawing.Size(81, 18);
            this.lblMLDBVideotype.TabIndex = 3;
            this.lblMLDBVideotype.Text = "Video Type";
            // 
            // checkboxMLDBAutoerasing
            // 
            this.checkboxMLDBAutoerasing.AutoSize = true;
            this.checkboxMLDBAutoerasing.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.checkboxMLDBAutoerasing.ForeColor = System.Drawing.Color.Lime;
            this.checkboxMLDBAutoerasing.Location = new System.Drawing.Point(218, 117);
            this.checkboxMLDBAutoerasing.Margin = new System.Windows.Forms.Padding(2);
            this.checkboxMLDBAutoerasing.Name = "checkboxMLDBAutoerasing";
            this.checkboxMLDBAutoerasing.Size = new System.Drawing.Size(15, 14);
            this.checkboxMLDBAutoerasing.TabIndex = 22;
            this.checkboxMLDBAutoerasing.UseVisualStyleBackColor = true;
            this.checkboxMLDBAutoerasing.CheckedChanged += new System.EventHandler(this.checkboxMLDBAutoerasing_CheckedChanged);
            // 
            // CmbMLDBDelaytime
            // 
            this.CmbMLDBDelaytime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMLDBDelaytime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CmbMLDBDelaytime.FormattingEnabled = true;
            this.CmbMLDBDelaytime.Items.AddRange(new object[] {
            "10",
            "20",
            "30"});
            this.CmbMLDBDelaytime.Location = new System.Drawing.Point(138, 141);
            this.CmbMLDBDelaytime.Margin = new System.Windows.Forms.Padding(2);
            this.CmbMLDBDelaytime.Name = "CmbMLDBDelaytime";
            this.CmbMLDBDelaytime.Size = new System.Drawing.Size(50, 26);
            this.CmbMLDBDelaytime.TabIndex = 23;
            // 
            // lblMLDBDelayTime
            // 
            this.lblMLDBDelayTime.AutoSize = true;
            this.lblMLDBDelayTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMLDBDelayTime.Location = new System.Drawing.Point(10, 149);
            this.lblMLDBDelayTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBDelayTime.Name = "lblMLDBDelayTime";
            this.lblMLDBDelayTime.Size = new System.Drawing.Size(82, 18);
            this.lblMLDBDelayTime.TabIndex = 7;
            this.lblMLDBDelayTime.Text = "Delay Time";
            // 
            // lblMLDBSec
            // 
            this.lblMLDBSec.AutoSize = true;
            this.lblMLDBSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMLDBSec.Location = new System.Drawing.Point(203, 149);
            this.lblMLDBSec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBSec.Name = "lblMLDBSec";
            this.lblMLDBSec.Size = new System.Drawing.Size(34, 18);
            this.lblMLDBSec.TabIndex = 18;
            this.lblMLDBSec.Text = "Sec";
            // 
            // lblMLDBLetterGap
            // 
            this.lblMLDBLetterGap.AutoSize = true;
            this.lblMLDBLetterGap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMLDBLetterGap.Location = new System.Drawing.Point(346, 14);
            this.lblMLDBLetterGap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBLetterGap.Name = "lblMLDBLetterGap";
            this.lblMLDBLetterGap.Size = new System.Drawing.Size(77, 18);
            this.lblMLDBLetterGap.TabIndex = 12;
            this.lblMLDBLetterGap.Text = "Letter Gap";
            // 
            // lblMLDBDisplayEffect
            // 
            this.lblMLDBDisplayEffect.AutoSize = true;
            this.lblMLDBDisplayEffect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMLDBDisplayEffect.Location = new System.Drawing.Point(346, 48);
            this.lblMLDBDisplayEffect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBDisplayEffect.Name = "lblMLDBDisplayEffect";
            this.lblMLDBDisplayEffect.Size = new System.Drawing.Size(98, 18);
            this.lblMLDBDisplayEffect.TabIndex = 13;
            this.lblMLDBDisplayEffect.Text = "Display Effect";
            // 
            // lblMLDBFontSize
            // 
            this.lblMLDBFontSize.AutoSize = true;
            this.lblMLDBFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMLDBFontSize.Location = new System.Drawing.Point(346, 81);
            this.lblMLDBFontSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBFontSize.Name = "lblMLDBFontSize";
            this.lblMLDBFontSize.Size = new System.Drawing.Size(71, 18);
            this.lblMLDBFontSize.TabIndex = 14;
            this.lblMLDBFontSize.Text = "Font Size";
            // 
            // lblMLDBEraseTime
            // 
            this.lblMLDBEraseTime.AutoSize = true;
            this.lblMLDBEraseTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMLDBEraseTime.Location = new System.Drawing.Point(346, 113);
            this.lblMLDBEraseTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBEraseTime.Name = "lblMLDBEraseTime";
            this.lblMLDBEraseTime.Size = new System.Drawing.Size(84, 18);
            this.lblMLDBEraseTime.TabIndex = 15;
            this.lblMLDBEraseTime.Text = "Erase Time";
            // 
            // lblMLDBInfoDisplayed
            // 
            this.lblMLDBInfoDisplayed.AutoSize = true;
            this.lblMLDBInfoDisplayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMLDBInfoDisplayed.Location = new System.Drawing.Point(346, 149);
            this.lblMLDBInfoDisplayed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBInfoDisplayed.Name = "lblMLDBInfoDisplayed";
            this.lblMLDBInfoDisplayed.Size = new System.Drawing.Size(100, 18);
            this.lblMLDBInfoDisplayed.TabIndex = 16;
            this.lblMLDBInfoDisplayed.Text = "Info Displayed";
            // 
            // txtMLDBErasetime
            // 
            this.txtMLDBErasetime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMLDBErasetime.Enabled = false;
            this.txtMLDBErasetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtMLDBErasetime.Location = new System.Drawing.Point(536, 107);
            this.txtMLDBErasetime.Margin = new System.Windows.Forms.Padding(2);
            this.txtMLDBErasetime.Name = "txtMLDBErasetime";
            this.txtMLDBErasetime.Size = new System.Drawing.Size(60, 24);
            this.txtMLDBErasetime.TabIndex = 31;
            this.txtMLDBErasetime.Text = "34";
            this.txtMLDBErasetime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMLDBErasetime_KeyPress);
            // 
            // lblMLDBMin
            // 
            this.lblMLDBMin.AutoSize = true;
            this.lblMLDBMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMLDBMin.Location = new System.Drawing.Point(536, 113);
            this.lblMLDBMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMLDBMin.Name = "lblMLDBMin";
            this.lblMLDBMin.Size = new System.Drawing.Size(40, 18);
            this.lblMLDBMin.TabIndex = 17;
            this.lblMLDBMin.Text = "Mins";
            // 
            // CmbMLDBfontSize
            // 
            this.CmbMLDBfontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMLDBfontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CmbMLDBfontSize.FormattingEnabled = true;
            this.CmbMLDBfontSize.Location = new System.Drawing.Point(536, 73);
            this.CmbMLDBfontSize.Margin = new System.Windows.Forms.Padding(2);
            this.CmbMLDBfontSize.Name = "CmbMLDBfontSize";
            this.CmbMLDBfontSize.Size = new System.Drawing.Size(199, 26);
            this.CmbMLDBfontSize.TabIndex = 29;
            // 
            // CmbMLDBDisplayeffect
            // 
            this.CmbMLDBDisplayeffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMLDBDisplayeffect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CmbMLDBDisplayeffect.FormattingEnabled = true;
            this.CmbMLDBDisplayeffect.Location = new System.Drawing.Point(536, 40);
            this.CmbMLDBDisplayeffect.Margin = new System.Windows.Forms.Padding(2);
            this.CmbMLDBDisplayeffect.Name = "CmbMLDBDisplayeffect";
            this.CmbMLDBDisplayeffect.Size = new System.Drawing.Size(199, 26);
            this.CmbMLDBDisplayeffect.TabIndex = 28;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 73.85786F;
            this.dataGridViewImageColumn1.HeaderText = "up";
            this.dataGridViewImageColumn1.Image = global::ArecaIPIS.Properties.Resources._211624_c_up_arrow_icon;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.Width = 59;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 73.85786F;
            this.dataGridViewImageColumn2.HeaderText = "Down";
            this.dataGridViewImageColumn2.Image = global::ArecaIPIS.Properties.Resources.DownArrow;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 58;
            // 
            // errorProviderMLDB
            // 
            this.errorProviderMLDB.ContainerControl = this;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(370, 446);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 16);
            this.lblStatus.TabIndex = 44;
            this.lblStatus.Text = "save";
            this.lblStatus.Visible = false;
            // 
            // frmMLDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(898, 483);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnMLDBSave);
            this.Controls.Add(this.btnMLDBBoardSettings);
            this.Controls.Add(this.btnMLDBCommonSettings);
            this.Controls.Add(this.panelMLDBBhadder);
            this.Controls.Add(this.panelMLDBCommonSettings);
            this.Controls.Add(this.panelMLDBBoardSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMLDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MLDB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMLDB_FormClosing);
            this.Load += new System.EventHandler(this.MLDB_Load);
            this.panelMLDBBhadder.ResumeLayout(false);
            this.panelMLDBBhadder.PerformLayout();
            this.panelMLDBBoardSettings.ResumeLayout(false);
            this.panelMLDBBoardSettings.PerformLayout();
            this.grupMLDBMessages.ResumeLayout(false);
            this.grupMLDBMessages.PerformLayout();
            this.grupMLDBBoardRunning.ResumeLayout(false);
            this.grupMLDBBoardRunning.PerformLayout();
            this.grupMLDBDisplaySequence.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguage)).EndInit();
            this.panelMLDBCommonSettings.ResumeLayout(false);
            this.panelMLDBCommonSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMLDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMLDBBhadder;
        private System.Windows.Forms.Label lblMLDBHaddear;
        private System.Windows.Forms.Button btnMLDBBoardSettings;
        private System.Windows.Forms.Button btnMLDBCommonSettings;
        private System.Windows.Forms.Button btnMLDBSave;
        private System.Windows.Forms.Panel panelMLDBBoardSettings;
        private System.Windows.Forms.GroupBox grupMLDBPlatforms;
        private System.Windows.Forms.GroupBox grupMLDBMessages;
        private System.Windows.Forms.CheckBox checkMLDBBoxShowMessages;
        private System.Windows.Forms.GroupBox grupMLDBBoardRunning;
        private System.Windows.Forms.RadioButton rdbnMLDBNotWorking;
        private System.Windows.Forms.RadioButton rdbnMLDBWorking;
        private System.Windows.Forms.Label lblMLDBNoOfLines;
        private System.Windows.Forms.Label lblMLDBBoardIP;
        private System.Windows.Forms.Label lblMLDBEthernetPortNo;
        private System.Windows.Forms.Label lblMLDBLocation;
        private System.Windows.Forms.Label lblMLDBBoardID;
        private System.Windows.Forms.TextBox txtMLDBNooflines;
        private System.Windows.Forms.TextBox txtMLDBEthernetportno;
        private System.Windows.Forms.TextBox txtMLDBLocation;
        private System.Windows.Forms.TextBox txtMLDBBoardid;
        private System.Windows.Forms.GroupBox grupMLDBDisplaySequence;
        private System.Windows.Forms.Panel panelMLDBCommonSettings;
        private System.Windows.Forms.ComboBox cmbMLDBVideoType;
        private System.Windows.Forms.ComboBox CmbMLDBLetterSpeed;
        private System.Windows.Forms.Label lblMLDBRequiredAutoErasing;
        private System.Windows.Forms.Label lblMLDBFormatType;
        private System.Windows.Forms.Label lblMLDBLetterSpeed;
        private System.Windows.Forms.Label lblMLDBVideotype;
        private System.Windows.Forms.CheckBox checkboxMLDBAutoerasing;
        private System.Windows.Forms.ComboBox CmbMLDBDelaytime;
        private System.Windows.Forms.Label lblMLDBDelayTime;
        private System.Windows.Forms.Label lblMLDBSec;
        private System.Windows.Forms.TextBox txtMLDBEnglish;
        private System.Windows.Forms.Label lblMLDBEnglish;
        private System.Windows.Forms.Label lblMLDBHindi;
        private System.Windows.Forms.TextBox txtMLDBHindi;
        private System.Windows.Forms.Label lblMLDBLetterGap;
        private System.Windows.Forms.Label lblMLDBDisplayEffect;
        private System.Windows.Forms.Label lblMLDBFontSize;
        private System.Windows.Forms.Label lblMLDBEraseTime;
        private System.Windows.Forms.Label lblMLDBInfoDisplayed;
        private System.Windows.Forms.Label lblMLDBRegional;
        private System.Windows.Forms.TextBox txtMLDBRegional;
        private System.Windows.Forms.TextBox txtMLDBErasetime;
        private System.Windows.Forms.Label lblMLDBMin;
        private System.Windows.Forms.ComboBox CmbMLDBfontSize;
        private System.Windows.Forms.ComboBox CmbMLDBDisplayeffect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgvLanguage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLanguages;
        private System.Windows.Forms.DataGridViewImageColumn dgvUpButton;
        private System.Windows.Forms.DataGridViewImageColumn DgvDown;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private IPAddressControlLib.IPAddressControl ipAddressMldb;
        private System.Windows.Forms.ErrorProvider errorProviderMLDB;
        private System.Windows.Forms.Label lblMLDBErrorMessage;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox CmbMLDBinfoDisplayed;
        private System.Windows.Forms.ComboBox CmbMLDBFormattype;
        private System.Windows.Forms.ComboBox CmbMLDBlettergap;
        private System.Windows.Forms.Label lblIpExist;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.Button btnHKeyboard;
        private System.Windows.Forms.Button btnRKeyboard;
        private System.Windows.Forms.Label lblinteroperability;
        private MyControls.ToggleButton tglinteroperability;
    }
}