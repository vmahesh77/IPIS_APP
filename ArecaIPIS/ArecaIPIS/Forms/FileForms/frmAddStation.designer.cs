
namespace ArecaIPIS.Forms
{
    partial class frmAddStation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblAddStation = new System.Windows.Forms.Label();
            this.dgvAddStation = new System.Windows.Forms.DataGridView();
            this.Column = new System.Windows.Forms.DataGridViewImageColumn();
            this.StationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.English = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hindi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionalLanguage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDropdown = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnCross = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnAddMessage = new System.Windows.Forms.Button();
            this.pnlCreateStation = new System.Windows.Forms.Panel();
            this.btnHKeyboard = new System.Windows.Forms.Button();
            this.btnRKeyboard = new System.Windows.Forms.Button();
            this.txtRegionalName = new System.Windows.Forms.TextBox();
            this.txtEnglishName = new System.Windows.Forms.TextBox();
            this.pnlSCreate = new System.Windows.Forms.Panel();
            this.lblCreateStation = new System.Windows.Forms.Label();
            this.txtHindiName = new System.Windows.Forms.TextBox();
            this.txtStationCode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblNoteDef2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoteDef1 = new System.Windows.Forms.Label();
            this.lblReq4 = new System.Windows.Forms.Label();
            this.lblReq3 = new System.Windows.Forms.Label();
            this.lblReq1 = new System.Windows.Forms.Label();
            this.lblReq2 = new System.Windows.Forms.Label();
            this.lblNoFileChoosen = new System.Windows.Forms.Label();
            this.btnAudioPath = new System.Windows.Forms.Button();
            this.lblAudioPath = new System.Windows.Forms.Label();
            this.lblRegional = new System.Windows.Forms.Label();
            this.lblHindi = new System.Windows.Forms.Label();
            this.lblEnglish = new System.Windows.Forms.Label();
            this.lblStationCode = new System.Windows.Forms.Label();
            this.lblNoDataToDisplay = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.chkFilter = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddStation)).BeginInit();
            this.pnlCreateStation.SuspendLayout();
            this.pnlSCreate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddStation
            // 
            this.lblAddStation.AutoSize = true;
            this.lblAddStation.BackColor = System.Drawing.SystemColors.Control;
            this.lblAddStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddStation.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAddStation.Location = new System.Drawing.Point(26, 2);
            this.lblAddStation.Name = "lblAddStation";
            this.lblAddStation.Size = new System.Drawing.Size(127, 24);
            this.lblAddStation.TabIndex = 0;
            this.lblAddStation.Text = "Add Stations";
            // 
            // dgvAddStation
            // 
            this.dgvAddStation.AllowUserToAddRows = false;
            this.dgvAddStation.AllowUserToResizeColumns = false;
            this.dgvAddStation.AllowUserToResizeRows = false;
            this.dgvAddStation.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAddStation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAddStation.ColumnHeadersHeight = 35;
            this.dgvAddStation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAddStation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column,
            this.StationCode,
            this.English,
            this.Hindi,
            this.RegionalLanguage});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAddStation.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAddStation.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvAddStation.Location = new System.Drawing.Point(30, 33);
            this.dgvAddStation.Name = "dgvAddStation";
            this.dgvAddStation.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAddStation.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAddStation.RowHeadersVisible = false;
            this.dgvAddStation.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvAddStation.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAddStation.RowTemplate.Height = 29;
            this.dgvAddStation.RowTemplate.ReadOnly = true;
            this.dgvAddStation.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAddStation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvAddStation.Size = new System.Drawing.Size(1251, 187);
            this.dgvAddStation.TabIndex = 3;
            this.dgvAddStation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddStation_CellClick);
            // 
            // Column
            // 
            this.Column.HeaderText = "";
            this.Column.Image = global::ArecaIPIS.Properties.Resources.edit;
            this.Column.Name = "Column";
            this.Column.ReadOnly = true;
            this.Column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column.ToolTipText = "Edit";
            // 
            // StationCode
            // 
            this.StationCode.HeaderText = "Station Code";
            this.StationCode.Name = "StationCode";
            this.StationCode.ReadOnly = true;
            this.StationCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StationCode.Width = 150;
            // 
            // English
            // 
            this.English.HeaderText = "English";
            this.English.Name = "English";
            this.English.ReadOnly = true;
            this.English.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.English.Width = 320;
            // 
            // Hindi
            // 
            this.Hindi.HeaderText = "Hindi";
            this.Hindi.Name = "Hindi";
            this.Hindi.ReadOnly = true;
            this.Hindi.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Hindi.Width = 320;
            // 
            // RegionalLanguage
            // 
            this.RegionalLanguage.HeaderText = "Regional Language";
            this.RegionalLanguage.Name = "RegionalLanguage";
            this.RegionalLanguage.ReadOnly = true;
            this.RegionalLanguage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RegionalLanguage.Width = 358;
            // 
            // btnDropdown
            // 
            this.btnDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDropdown.Image = global::ArecaIPIS.Properties.Resources.descending_down;
            this.btnDropdown.Location = new System.Drawing.Point(1226, 0);
            this.btnDropdown.Name = "btnDropdown";
            this.btnDropdown.Size = new System.Drawing.Size(46, 31);
            this.btnDropdown.TabIndex = 26;
            this.btnDropdown.UseVisualStyleBackColor = false;
            this.btnDropdown.Visible = false;
            this.btnDropdown.Click += new System.EventHandler(this.btnDropdown_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(1044, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(140, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search Here";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnCross.Location = new System.Drawing.Point(1183, 0);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(46, 31);
            this.btnCross.TabIndex = 25;
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Visible = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::ArecaIPIS.Properties.Resources._352091_search_icon;
            this.btnSearch.Location = new System.Drawing.Point(1183, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 31);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlPagination
            // 
            this.pnlPagination.BackColor = System.Drawing.Color.Transparent;
            this.pnlPagination.Location = new System.Drawing.Point(30, 221);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1252, 51);
            this.pnlPagination.TabIndex = 27;
            // 
            // btnAddMessage
            // 
            this.btnAddMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddMessage.FlatAppearance.BorderSize = 0;
            this.btnAddMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMessage.ForeColor = System.Drawing.Color.Black;
            this.btnAddMessage.Location = new System.Drawing.Point(65, 37);
            this.btnAddMessage.Name = "btnAddMessage";
            this.btnAddMessage.Size = new System.Drawing.Size(36, 28);
            this.btnAddMessage.TabIndex = 28;
            this.btnAddMessage.Text = "+";
            this.btnAddMessage.UseVisualStyleBackColor = false;
            this.btnAddMessage.Click += new System.EventHandler(this.btnAddMessage_Click);
            // 
            // pnlCreateStation
            // 
            this.pnlCreateStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCreateStation.Controls.Add(this.label1);
            this.pnlCreateStation.Controls.Add(this.btnHKeyboard);
            this.pnlCreateStation.Controls.Add(this.btnRKeyboard);
            this.pnlCreateStation.Controls.Add(this.txtRegionalName);
            this.pnlCreateStation.Controls.Add(this.txtEnglishName);
            this.pnlCreateStation.Controls.Add(this.pnlSCreate);
            this.pnlCreateStation.Controls.Add(this.txtHindiName);
            this.pnlCreateStation.Controls.Add(this.txtStationCode);
            this.pnlCreateStation.Controls.Add(this.btnClose);
            this.pnlCreateStation.Controls.Add(this.btnSave);
            this.pnlCreateStation.Controls.Add(this.lblNoteDef2);
            this.pnlCreateStation.Controls.Add(this.label2);
            this.pnlCreateStation.Controls.Add(this.lblNoteDef1);
            this.pnlCreateStation.Controls.Add(this.lblReq4);
            this.pnlCreateStation.Controls.Add(this.lblReq3);
            this.pnlCreateStation.Controls.Add(this.lblReq1);
            this.pnlCreateStation.Controls.Add(this.lblReq2);
            this.pnlCreateStation.Controls.Add(this.lblNoFileChoosen);
            this.pnlCreateStation.Controls.Add(this.btnAudioPath);
            this.pnlCreateStation.Controls.Add(this.lblAudioPath);
            this.pnlCreateStation.Controls.Add(this.lblRegional);
            this.pnlCreateStation.Controls.Add(this.lblHindi);
            this.pnlCreateStation.Controls.Add(this.lblEnglish);
            this.pnlCreateStation.Controls.Add(this.lblStationCode);
            this.pnlCreateStation.Location = new System.Drawing.Point(30, 307);
            this.pnlCreateStation.Name = "pnlCreateStation";
            this.pnlCreateStation.Size = new System.Drawing.Size(1251, 190);
            this.pnlCreateStation.TabIndex = 29;
            this.pnlCreateStation.Visible = false;
            // 
            // btnHKeyboard
            // 
            this.btnHKeyboard.FlatAppearance.BorderSize = 0;
            this.btnHKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHKeyboard.Image = global::ArecaIPIS.Properties.Resources._3671786_keyboard_icon__1_;
            this.btnHKeyboard.Location = new System.Drawing.Point(471, 71);
            this.btnHKeyboard.Name = "btnHKeyboard";
            this.btnHKeyboard.Size = new System.Drawing.Size(23, 19);
            this.btnHKeyboard.TabIndex = 75;
            this.btnHKeyboard.UseVisualStyleBackColor = true;
            this.btnHKeyboard.Click += new System.EventHandler(this.btnHKeyboard_Click);
            // 
            // btnRKeyboard
            // 
            this.btnRKeyboard.FlatAppearance.BorderSize = 0;
            this.btnRKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRKeyboard.Image = global::ArecaIPIS.Properties.Resources._3671786_keyboard_icon__1_;
            this.btnRKeyboard.Location = new System.Drawing.Point(946, 72);
            this.btnRKeyboard.Name = "btnRKeyboard";
            this.btnRKeyboard.Size = new System.Drawing.Size(23, 19);
            this.btnRKeyboard.TabIndex = 74;
            this.btnRKeyboard.UseVisualStyleBackColor = true;
            this.btnRKeyboard.Click += new System.EventHandler(this.btnRKeyboard_Click);
            // 
            // txtRegionalName
            // 
            this.txtRegionalName.Location = new System.Drawing.Point(670, 72);
            this.txtRegionalName.Name = "txtRegionalName";
            this.txtRegionalName.Size = new System.Drawing.Size(270, 20);
            this.txtRegionalName.TabIndex = 4;
            this.txtRegionalName.TextChanged += new System.EventHandler(this.txtRegionalName_TextChanged);
            // 
            // txtEnglishName
            // 
            this.txtEnglishName.Location = new System.Drawing.Point(670, 42);
            this.txtEnglishName.Name = "txtEnglishName";
            this.txtEnglishName.Size = new System.Drawing.Size(270, 20);
            this.txtEnglishName.TabIndex = 2;
            this.txtEnglishName.TextChanged += new System.EventHandler(this.txtEnglishName_TextChanged);
            this.txtEnglishName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEnglishName_KeyPress);
            // 
            // pnlSCreate
            // 
            this.pnlSCreate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlSCreate.Controls.Add(this.lblCreateStation);
            this.pnlSCreate.Location = new System.Drawing.Point(0, 0);
            this.pnlSCreate.Name = "pnlSCreate";
            this.pnlSCreate.Size = new System.Drawing.Size(1251, 37);
            this.pnlSCreate.TabIndex = 46;
            this.pnlSCreate.Visible = false;
            // 
            // lblCreateStation
            // 
            this.lblCreateStation.AutoSize = true;
            this.lblCreateStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateStation.ForeColor = System.Drawing.Color.White;
            this.lblCreateStation.Location = new System.Drawing.Point(3, 5);
            this.lblCreateStation.Name = "lblCreateStation";
            this.lblCreateStation.Size = new System.Drawing.Size(140, 24);
            this.lblCreateStation.TabIndex = 0;
            this.lblCreateStation.Text = "Create Station";
            // 
            // txtHindiName
            // 
            this.txtHindiName.Location = new System.Drawing.Point(195, 72);
            this.txtHindiName.Name = "txtHindiName";
            this.txtHindiName.Size = new System.Drawing.Size(270, 20);
            this.txtHindiName.TabIndex = 3;
            this.txtHindiName.TextChanged += new System.EventHandler(this.txtHindiName_TextChanged);
            // 
            // txtStationCode
            // 
            this.txtStationCode.Location = new System.Drawing.Point(195, 42);
            this.txtStationCode.Name = "txtStationCode";
            this.txtStationCode.Size = new System.Drawing.Size(270, 20);
            this.txtStationCode.TabIndex = 1;
            this.txtStationCode.TextChanged += new System.EventHandler(this.txtStationCode_TextChanged);
            this.txtStationCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStationCode_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(776, 135);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 32);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::ArecaIPIS.Properties.Resources._1564499_accept_added_check_complite_yes_icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(684, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 32);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblNoteDef2
            // 
            this.lblNoteDef2.AutoSize = true;
            this.lblNoteDef2.ForeColor = System.Drawing.Color.Black;
            this.lblNoteDef2.Location = new System.Drawing.Point(210, 162);
            this.lblNoteDef2.Name = "lblNoteDef2";
            this.lblNoteDef2.Size = new System.Drawing.Size(105, 13);
            this.lblNoteDef2.TabIndex = 39;
            this.lblNoteDef2.Text = ") Fields Are Required";
            this.lblNoteDef2.Click += new System.EventHandler(this.lblNoteDef2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(198, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 24);
            this.label2.TabIndex = 38;
            this.label2.Text = "*";
            // 
            // lblNoteDef1
            // 
            this.lblNoteDef1.AutoSize = true;
            this.lblNoteDef1.ForeColor = System.Drawing.Color.Black;
            this.lblNoteDef1.Location = new System.Drawing.Point(152, 135);
            this.lblNoteDef1.Name = "lblNoteDef1";
            this.lblNoteDef1.Size = new System.Drawing.Size(340, 39);
            this.lblNoteDef1.TabIndex = 37;
            this.lblNoteDef1.Text = "Please Upload Wav/Mp3 files,&nbsp; File Size Should be lessthan 2Mb.\r\n\r\nAsterisk " +
    "(";
            // 
            // lblReq4
            // 
            this.lblReq4.AutoSize = true;
            this.lblReq4.BackColor = System.Drawing.Color.White;
            this.lblReq4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq4.ForeColor = System.Drawing.Color.Red;
            this.lblReq4.Location = new System.Drawing.Point(66, 135);
            this.lblReq4.Name = "lblReq4";
            this.lblReq4.Size = new System.Drawing.Size(80, 24);
            this.lblReq4.TabIndex = 36;
            this.lblReq4.Text = "* Note :";
            // 
            // lblReq3
            // 
            this.lblReq3.AutoSize = true;
            this.lblReq3.BackColor = System.Drawing.Color.Transparent;
            this.lblReq3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq3.ForeColor = System.Drawing.Color.Red;
            this.lblReq3.Location = new System.Drawing.Point(44, 73);
            this.lblReq3.Name = "lblReq3";
            this.lblReq3.Size = new System.Drawing.Size(18, 24);
            this.lblReq3.TabIndex = 35;
            this.lblReq3.Text = "*";
            // 
            // lblReq1
            // 
            this.lblReq1.AutoSize = true;
            this.lblReq1.BackColor = System.Drawing.Color.Transparent;
            this.lblReq1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq1.ForeColor = System.Drawing.Color.Red;
            this.lblReq1.Location = new System.Drawing.Point(44, 45);
            this.lblReq1.Name = "lblReq1";
            this.lblReq1.Size = new System.Drawing.Size(18, 24);
            this.lblReq1.TabIndex = 34;
            this.lblReq1.Text = "*";
            // 
            // lblReq2
            // 
            this.lblReq2.AutoSize = true;
            this.lblReq2.BackColor = System.Drawing.Color.Transparent;
            this.lblReq2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq2.ForeColor = System.Drawing.Color.Red;
            this.lblReq2.Location = new System.Drawing.Point(542, 42);
            this.lblReq2.Name = "lblReq2";
            this.lblReq2.Size = new System.Drawing.Size(18, 24);
            this.lblReq2.TabIndex = 33;
            this.lblReq2.Text = "*";
            // 
            // lblNoFileChoosen
            // 
            this.lblNoFileChoosen.AutoSize = true;
            this.lblNoFileChoosen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoFileChoosen.ForeColor = System.Drawing.Color.Black;
            this.lblNoFileChoosen.Location = new System.Drawing.Point(296, 107);
            this.lblNoFileChoosen.Name = "lblNoFileChoosen";
            this.lblNoFileChoosen.Size = new System.Drawing.Size(100, 16);
            this.lblNoFileChoosen.TabIndex = 32;
            this.lblNoFileChoosen.Text = "No File Chosen";
            // 
            // btnAudioPath
            // 
            this.btnAudioPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAudioPath.ForeColor = System.Drawing.Color.Black;
            this.btnAudioPath.Location = new System.Drawing.Point(194, 107);
            this.btnAudioPath.Name = "btnAudioPath";
            this.btnAudioPath.Size = new System.Drawing.Size(96, 22);
            this.btnAudioPath.TabIndex = 5;
            this.btnAudioPath.Text = "Choose File";
            this.btnAudioPath.UseVisualStyleBackColor = true;
            this.btnAudioPath.Click += new System.EventHandler(this.btnAudioPath_Click);
            // 
            // lblAudioPath
            // 
            this.lblAudioPath.AutoSize = true;
            this.lblAudioPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudioPath.ForeColor = System.Drawing.Color.Black;
            this.lblAudioPath.Location = new System.Drawing.Point(63, 107);
            this.lblAudioPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAudioPath.Name = "lblAudioPath";
            this.lblAudioPath.Size = new System.Drawing.Size(83, 16);
            this.lblAudioPath.TabIndex = 30;
            this.lblAudioPath.Text = "Audio Path";
            // 
            // lblRegional
            // 
            this.lblRegional.AutoSize = true;
            this.lblRegional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegional.ForeColor = System.Drawing.Color.Black;
            this.lblRegional.Location = new System.Drawing.Point(562, 73);
            this.lblRegional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegional.Name = "lblRegional";
            this.lblRegional.Size = new System.Drawing.Size(71, 16);
            this.lblRegional.TabIndex = 25;
            this.lblRegional.Text = "Regional";
            // 
            // lblHindi
            // 
            this.lblHindi.AutoSize = true;
            this.lblHindi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHindi.ForeColor = System.Drawing.Color.Black;
            this.lblHindi.Location = new System.Drawing.Point(64, 76);
            this.lblHindi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHindi.Name = "lblHindi";
            this.lblHindi.Size = new System.Drawing.Size(44, 16);
            this.lblHindi.TabIndex = 24;
            this.lblHindi.Text = "Hindi";
            // 
            // lblEnglish
            // 
            this.lblEnglish.AutoSize = true;
            this.lblEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnglish.ForeColor = System.Drawing.Color.Black;
            this.lblEnglish.Location = new System.Drawing.Point(562, 42);
            this.lblEnglish.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Size = new System.Drawing.Size(59, 16);
            this.lblEnglish.TabIndex = 23;
            this.lblEnglish.Text = "English";
            // 
            // lblStationCode
            // 
            this.lblStationCode.AutoSize = true;
            this.lblStationCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationCode.ForeColor = System.Drawing.Color.Black;
            this.lblStationCode.Location = new System.Drawing.Point(64, 46);
            this.lblStationCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStationCode.Name = "lblStationCode";
            this.lblStationCode.Size = new System.Drawing.Size(97, 16);
            this.lblStationCode.TabIndex = 22;
            this.lblStationCode.Text = "Station Code";
            // 
            // lblNoDataToDisplay
            // 
            this.lblNoDataToDisplay.AutoSize = true;
            this.lblNoDataToDisplay.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblNoDataToDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataToDisplay.ForeColor = System.Drawing.Color.Black;
            this.lblNoDataToDisplay.Location = new System.Drawing.Point(510, 74);
            this.lblNoDataToDisplay.Name = "lblNoDataToDisplay";
            this.lblNoDataToDisplay.Size = new System.Drawing.Size(216, 25);
            this.lblNoDataToDisplay.TabIndex = 47;
            this.lblNoDataToDisplay.Text = "No Data To Display";
            this.lblNoDataToDisplay.Visible = false;
            // 
            // toolTip
            // 
            this.toolTip.ForeColor = System.Drawing.SystemColors.Window;
            // 
            // chkFilter
            // 
            this.chkFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chkFilter.FormattingEnabled = true;
            this.chkFilter.Location = new System.Drawing.Point(1162, 32);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(116, 64);
            this.chkFilter.TabIndex = 48;
            this.chkFilter.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(542, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 24);
            this.label1.TabIndex = 76;
            this.label1.Text = "*";
            // 
            // frmAddStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 509);
            this.Controls.Add(this.pnlPagination);
            this.Controls.Add(this.pnlCreateStation);
            this.Controls.Add(this.chkFilter);
            this.Controls.Add(this.lblNoDataToDisplay);
            this.Controls.Add(this.btnAddMessage);
            this.Controls.Add(this.btnDropdown);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblAddStation);
            this.Controls.Add(this.btnCross);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvAddStation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddStation";
            this.Text = "frmStationDeatils";
            this.Load += new System.EventHandler(this.frmStationDeatils_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddStation)).EndInit();
            this.pnlCreateStation.ResumeLayout(false);
            this.pnlCreateStation.PerformLayout();
            this.pnlSCreate.ResumeLayout(false);
            this.pnlSCreate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddStation;
        private System.Windows.Forms.DataGridView dgvAddStation;
        private System.Windows.Forms.Button btnDropdown;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnAddMessage;
        private System.Windows.Forms.Panel pnlCreateStation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblNoteDef2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNoteDef1;
        private System.Windows.Forms.Label lblReq4;
        private System.Windows.Forms.Label lblReq3;
        private System.Windows.Forms.Label lblReq1;
        private System.Windows.Forms.Label lblReq2;
        private System.Windows.Forms.Label lblNoFileChoosen;
        private System.Windows.Forms.Button btnAudioPath;
        private System.Windows.Forms.Label lblAudioPath;
        private System.Windows.Forms.Label lblRegional;
        private System.Windows.Forms.Label lblHindi;
        private System.Windows.Forms.Label lblEnglish;
        private System.Windows.Forms.Label lblStationCode;
        private System.Windows.Forms.TextBox txtHindiName;
        private System.Windows.Forms.TextBox txtStationCode;
        private System.Windows.Forms.TextBox txtRegionalName;
        private System.Windows.Forms.TextBox txtEnglishName;
        private System.Windows.Forms.Panel pnlSCreate;
        private System.Windows.Forms.Label lblCreateStation;
        private System.Windows.Forms.Label lblNoDataToDisplay;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckedListBox chkFilter;
        private System.Windows.Forms.DataGridViewImageColumn Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn English;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hindi;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionalLanguage;
        private System.Windows.Forms.Button btnHKeyboard;
        private System.Windows.Forms.Button btnRKeyboard;
        private System.Windows.Forms.Label label1;
    }
}