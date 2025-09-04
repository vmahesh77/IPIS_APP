
namespace ArecaIPIS.Forms.HomeForms
{
    partial class frmSlogans
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNormalMessages = new System.Windows.Forms.Label();
            this.pnlSlogan = new System.Windows.Forms.Panel();
            this.chkFilter = new System.Windows.Forms.CheckedListBox();
            this.lblNoDataToDisplay = new System.Windows.Forms.Label();
            this.btnAddSloganMessage = new System.Windows.Forms.Button();
            this.btnDropdown = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtBoardId = new System.Windows.Forms.TextBox();
            this.lblBoardId = new System.Windows.Forms.Label();
            this.cmbBoardType = new System.Windows.Forms.ComboBox();
            this.lblBoardType = new System.Windows.Forms.Label();
            this.dgvSlogan = new System.Windows.Forms.DataGridView();
            this.Column = new System.Windows.Forms.DataGridViewImageColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvSloganLanguage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCross = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlFormShow = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReq2 = new System.Windows.Forms.Label();
            this.lblMessageValidation = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.lblShowingAudio = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAudioFile = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pbCross = new System.Windows.Forms.PictureBox();
            this.pnlCreate = new System.Windows.Forms.Panel();
            this.lblCreateMessage = new System.Windows.Forms.Label();
            this.pnlMessageAnnouncement = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nupMessage = new System.Windows.Forms.NumericUpDown();
            this.btnStopMessage = new System.Windows.Forms.Button();
            this.btnPauseMessage = new System.Windows.Forms.Button();
            this.btnPlayMessage = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.toolTipSlogan = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialogs = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlSlogan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlogan)).BeginInit();
            this.pnlFormShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCross)).BeginInit();
            this.pnlCreate.SuspendLayout();
            this.pnlMessageAnnouncement.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNormalMessages
            // 
            this.lblNormalMessages.AutoSize = true;
            this.lblNormalMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNormalMessages.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNormalMessages.Location = new System.Drawing.Point(37, 9);
            this.lblNormalMessages.Name = "lblNormalMessages";
            this.lblNormalMessages.Size = new System.Drawing.Size(247, 31);
            this.lblNormalMessages.TabIndex = 0;
            this.lblNormalMessages.Text = "Normal Messages";
            // 
            // pnlSlogan
            // 
            this.pnlSlogan.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlSlogan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSlogan.Controls.Add(this.chkFilter);
            this.pnlSlogan.Controls.Add(this.lblNoDataToDisplay);
            this.pnlSlogan.Controls.Add(this.btnAddSloganMessage);
            this.pnlSlogan.Controls.Add(this.btnDropdown);
            this.pnlSlogan.Controls.Add(this.txtSearch);
            this.pnlSlogan.Controls.Add(this.txtBoardId);
            this.pnlSlogan.Controls.Add(this.lblBoardId);
            this.pnlSlogan.Controls.Add(this.cmbBoardType);
            this.pnlSlogan.Controls.Add(this.lblBoardType);
            this.pnlSlogan.Controls.Add(this.btnCross);
            this.pnlSlogan.Controls.Add(this.btnSearch);
            this.pnlSlogan.Controls.Add(this.dgvSlogan);
            this.pnlSlogan.Location = new System.Drawing.Point(38, 48);
            this.pnlSlogan.Name = "pnlSlogan";
            this.pnlSlogan.Size = new System.Drawing.Size(1068, 256);
            this.pnlSlogan.TabIndex = 1;
            // 
            // chkFilter
            // 
            this.chkFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chkFilter.FormattingEnabled = true;
            this.chkFilter.Location = new System.Drawing.Point(961, 35);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(101, 49);
            this.chkFilter.TabIndex = 31;
            this.chkFilter.Visible = false;
            // 
            // lblNoDataToDisplay
            // 
            this.lblNoDataToDisplay.AutoSize = true;
            this.lblNoDataToDisplay.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblNoDataToDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataToDisplay.ForeColor = System.Drawing.Color.Black;
            this.lblNoDataToDisplay.Location = new System.Drawing.Point(431, 98);
            this.lblNoDataToDisplay.Name = "lblNoDataToDisplay";
            this.lblNoDataToDisplay.Size = new System.Drawing.Size(155, 18);
            this.lblNoDataToDisplay.TabIndex = 0;
            this.lblNoDataToDisplay.Text = "No Data To Display";
            this.lblNoDataToDisplay.Visible = false;
            // 
            // btnAddSloganMessage
            // 
            this.btnAddSloganMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddSloganMessage.FlatAppearance.BorderSize = 0;
            this.btnAddSloganMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSloganMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSloganMessage.ForeColor = System.Drawing.Color.Black;
            this.btnAddSloganMessage.Location = new System.Drawing.Point(32, 39);
            this.btnAddSloganMessage.Name = "btnAddSloganMessage";
            this.btnAddSloganMessage.Size = new System.Drawing.Size(40, 31);
            this.btnAddSloganMessage.TabIndex = 23;
            this.btnAddSloganMessage.Text = "+";
            this.btnAddSloganMessage.UseVisualStyleBackColor = false;
            this.btnAddSloganMessage.Click += new System.EventHandler(this.btnAddSloganMessage_Click);
            // 
            // btnDropdown
            // 
            this.btnDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDropdown.Image = global::ArecaIPIS.Properties.Resources.descending_down;
            this.btnDropdown.Location = new System.Drawing.Point(1004, 2);
            this.btnDropdown.Name = "btnDropdown";
            this.btnDropdown.Size = new System.Drawing.Size(46, 31);
            this.btnDropdown.TabIndex = 22;
            this.btnDropdown.UseVisualStyleBackColor = false;
            this.btnDropdown.Visible = false;
            this.btnDropdown.Click += new System.EventHandler(this.btnDropdown_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(821, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(140, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Text = "Search Here";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // txtBoardId
            // 
            this.txtBoardId.Enabled = false;
            this.txtBoardId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoardId.Location = new System.Drawing.Point(603, 6);
            this.txtBoardId.Name = "txtBoardId";
            this.txtBoardId.Size = new System.Drawing.Size(148, 20);
            this.txtBoardId.TabIndex = 2;
            // 
            // lblBoardId
            // 
            this.lblBoardId.AutoSize = true;
            this.lblBoardId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardId.ForeColor = System.Drawing.Color.Black;
            this.lblBoardId.Location = new System.Drawing.Point(515, 7);
            this.lblBoardId.Name = "lblBoardId";
            this.lblBoardId.Size = new System.Drawing.Size(71, 16);
            this.lblBoardId.TabIndex = 3;
            this.lblBoardId.Text = "Board Id:";
            // 
            // cmbBoardType
            // 
            this.cmbBoardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBoardType.FormattingEnabled = true;
            this.cmbBoardType.Items.AddRange(new object[] {
            "ALL"});
            this.cmbBoardType.Location = new System.Drawing.Point(304, 4);
            this.cmbBoardType.Name = "cmbBoardType";
            this.cmbBoardType.Size = new System.Drawing.Size(145, 21);
            this.cmbBoardType.TabIndex = 1;
            this.cmbBoardType.SelectedIndexChanged += new System.EventHandler(this.cmbBoardType_SelectedIndexChanged);
            // 
            // lblBoardType
            // 
            this.lblBoardType.AutoSize = true;
            this.lblBoardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardType.ForeColor = System.Drawing.Color.Black;
            this.lblBoardType.Location = new System.Drawing.Point(185, 8);
            this.lblBoardType.Name = "lblBoardType";
            this.lblBoardType.Size = new System.Drawing.Size(94, 16);
            this.lblBoardType.TabIndex = 1;
            this.lblBoardType.Text = "Board Type:";
            // 
            // dgvSlogan
            // 
            this.dgvSlogan.AllowUserToResizeColumns = false;
            this.dgvSlogan.AllowUserToResizeRows = false;
            this.dgvSlogan.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSlogan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSlogan.ColumnHeadersHeight = 40;
            this.dgvSlogan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSlogan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column,
            this.Message,
            this.Select,
            this.Delete,
            this.dgvSloganLanguage});
            this.dgvSlogan.Location = new System.Drawing.Point(-1, 34);
            this.dgvSlogan.Name = "dgvSlogan";
            this.dgvSlogan.RowHeadersVisible = false;
            this.dgvSlogan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvSlogan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSlogan.RowTemplate.Height = 25;
            this.dgvSlogan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSlogan.Size = new System.Drawing.Size(1068, 221);
            this.dgvSlogan.TabIndex = 0;
            this.dgvSlogan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSlogan_CellClick);
            // 
            // Column
            // 
            this.Column.FillWeight = 37.55868F;
            this.Column.HeaderText = "";
            this.Column.Image = global::ArecaIPIS.Properties.Resources.edit;
            this.Column.Name = "Column";
            this.Column.ReadOnly = true;
            this.Column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Message
            // 
            this.Message.FillWeight = 276.2269F;
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.Width = 735;
            // 
            // Select
            // 
            this.Select.FillWeight = 40.09381F;
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 107;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 46.12057F;
            this.Delete.HeaderText = "Delete";
            this.Delete.Image = global::ArecaIPIS.Properties.Resources.delete_remove_icon;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.Width = 123;
            // 
            // dgvSloganLanguage
            // 
            this.dgvSloganLanguage.HeaderText = "Language";
            this.dgvSloganLanguage.Name = "dgvSloganLanguage";
            this.dgvSloganLanguage.ReadOnly = true;
            this.dgvSloganLanguage.Visible = false;
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnCross.Location = new System.Drawing.Point(961, 2);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(46, 31);
            this.btnCross.TabIndex = 21;
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Visible = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::ArecaIPIS.Properties.Resources._352091_search_icon;
            this.btnSearch.Location = new System.Drawing.Point(961, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 31);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlFormShow
            // 
            this.pnlFormShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormShow.Controls.Add(this.label1);
            this.pnlFormShow.Controls.Add(this.lblReq2);
            this.pnlFormShow.Controls.Add(this.lblMessageValidation);
            this.pnlFormShow.Controls.Add(this.cmbLanguage);
            this.pnlFormShow.Controls.Add(this.btnKeyboard);
            this.pnlFormShow.Controls.Add(this.lblShowingAudio);
            this.pnlFormShow.Controls.Add(this.lblFile);
            this.pnlFormShow.Controls.Add(this.btnAddFile);
            this.pnlFormShow.Controls.Add(this.txtMessage);
            this.pnlFormShow.Controls.Add(this.btnClose);
            this.pnlFormShow.Controls.Add(this.btnSave);
            this.pnlFormShow.Controls.Add(this.label6);
            this.pnlFormShow.Controls.Add(this.lblAudioFile);
            this.pnlFormShow.Controls.Add(this.lblLanguage);
            this.pnlFormShow.Controls.Add(this.lblMessage);
            this.pnlFormShow.Controls.Add(this.pbCross);
            this.pnlFormShow.Controls.Add(this.pnlCreate);
            this.pnlFormShow.Location = new System.Drawing.Point(34, 318);
            this.pnlFormShow.Name = "pnlFormShow";
            this.pnlFormShow.Size = new System.Drawing.Size(1073, 152);
            this.pnlFormShow.TabIndex = 3;
            this.pnlFormShow.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 24);
            this.label1.TabIndex = 99;
            this.label1.Text = "*";
            // 
            // lblReq2
            // 
            this.lblReq2.AutoSize = true;
            this.lblReq2.BackColor = System.Drawing.Color.Transparent;
            this.lblReq2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq2.ForeColor = System.Drawing.Color.Red;
            this.lblReq2.Location = new System.Drawing.Point(543, 58);
            this.lblReq2.Name = "lblReq2";
            this.lblReq2.Size = new System.Drawing.Size(18, 24);
            this.lblReq2.TabIndex = 98;
            this.lblReq2.Text = "*";
            // 
            // lblMessageValidation
            // 
            this.lblMessageValidation.AutoSize = true;
            this.lblMessageValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMessageValidation.Location = new System.Drawing.Point(145, 77);
            this.lblMessageValidation.Name = "lblMessageValidation";
            this.lblMessageValidation.Size = new System.Drawing.Size(19, 13);
            this.lblMessageValidation.TabIndex = 97;
            this.lblMessageValidation.Text = "ee";
            this.lblMessageValidation.Visible = false;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DisplayMember = "6";
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(666, 55);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(92, 21);
            this.cmbLanguage.TabIndex = 2;
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.FlatAppearance.BorderSize = 0;
            this.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyboard.Image = global::ArecaIPIS.Properties.Resources._3671786_keyboard_icon__1_;
            this.btnKeyboard.Location = new System.Drawing.Point(424, 55);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(23, 19);
            this.btnKeyboard.TabIndex = 92;
            this.btnKeyboard.UseVisualStyleBackColor = true;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // lblShowingAudio
            // 
            this.lblShowingAudio.AutoSize = true;
            this.lblShowingAudio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblShowingAudio.Location = new System.Drawing.Point(145, 119);
            this.lblShowingAudio.Name = "lblShowingAudio";
            this.lblShowingAudio.Size = new System.Drawing.Size(13, 13);
            this.lblShowingAudio.TabIndex = 91;
            this.lblShowingAudio.Text = "rr";
            this.lblShowingAudio.Visible = false;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.ForeColor = System.Drawing.Color.Black;
            this.lblFile.Location = new System.Drawing.Point(243, 99);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(75, 13);
            this.lblFile.TabIndex = 90;
            this.lblFile.Text = "No file chosen";
            this.lblFile.TextChanged += new System.EventHandler(this.lblFile_TextChanged);
            // 
            // btnAddFile
            // 
            this.btnAddFile.ForeColor = System.Drawing.Color.Black;
            this.btnAddFile.Location = new System.Drawing.Point(145, 94);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(92, 23);
            this.btnAddFile.TabIndex = 3;
            this.btnAddFile.Text = "Choose File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(148, 54);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(268, 20);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.Leave += new System.EventHandler(this.txtMessage_Leave);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ArecaIPIS.Properties.Resources._9104213_close_cross_remove_delete_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(925, 111);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 87;
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ArecaIPIS.Properties.Resources._1564499_accept_added_check_complite_yes_icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(844, 111);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 86;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(67, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(349, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "* Note: Please Upload Wav/Mp3 files, File size should be less than 2Mb.";
            // 
            // lblAudioFile
            // 
            this.lblAudioFile.AutoSize = true;
            this.lblAudioFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudioFile.ForeColor = System.Drawing.Color.Black;
            this.lblAudioFile.Location = new System.Drawing.Point(22, 98);
            this.lblAudioFile.Name = "lblAudioFile";
            this.lblAudioFile.Size = new System.Drawing.Size(106, 18);
            this.lblAudioFile.TabIndex = 84;
            this.lblAudioFile.Text = "Audio File Path";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.ForeColor = System.Drawing.Color.Black;
            this.lblLanguage.Location = new System.Drawing.Point(560, 58);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(81, 20);
            this.lblLanguage.TabIndex = 83;
            this.lblLanguage.Text = "Language";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Black;
            this.lblMessage.Location = new System.Drawing.Point(31, 57);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(74, 20);
            this.lblMessage.TabIndex = 82;
            this.lblMessage.Text = "Message";
            // 
            // pbCross
            // 
            this.pbCross.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCross.ImageLocation = "";
            this.pbCross.Location = new System.Drawing.Point(458, 55);
            this.pbCross.Name = "pbCross";
            this.pbCross.Size = new System.Drawing.Size(25, 20);
            this.pbCross.TabIndex = 94;
            this.pbCross.TabStop = false;
            this.pbCross.Visible = false;
            // 
            // pnlCreate
            // 
            this.pnlCreate.BackColor = System.Drawing.Color.White;
            this.pnlCreate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCreate.Controls.Add(this.lblCreateMessage);
            this.pnlCreate.Location = new System.Drawing.Point(0, 0);
            this.pnlCreate.Name = "pnlCreate";
            this.pnlCreate.Size = new System.Drawing.Size(1071, 39);
            this.pnlCreate.TabIndex = 81;
            this.pnlCreate.Visible = false;
            this.pnlCreate.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblCreateMessage
            // 
            this.lblCreateMessage.AutoSize = true;
            this.lblCreateMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateMessage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCreateMessage.Location = new System.Drawing.Point(3, 2);
            this.lblCreateMessage.Name = "lblCreateMessage";
            this.lblCreateMessage.Size = new System.Drawing.Size(204, 29);
            this.lblCreateMessage.TabIndex = 0;
            this.lblCreateMessage.Text = "Create Message";
            // 
            // pnlMessageAnnouncement
            // 
            this.pnlMessageAnnouncement.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlMessageAnnouncement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMessageAnnouncement.Controls.Add(this.groupBox1);
            this.pnlMessageAnnouncement.Controls.Add(this.btnSendMessage);
            this.pnlMessageAnnouncement.Location = new System.Drawing.Point(41, 336);
            this.pnlMessageAnnouncement.Name = "pnlMessageAnnouncement";
            this.pnlMessageAnnouncement.Size = new System.Drawing.Size(880, 122);
            this.pnlMessageAnnouncement.TabIndex = 2;
            this.pnlMessageAnnouncement.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMessageAnnouncement_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.nupMessage);
            this.groupBox1.Controls.Add(this.btnStopMessage);
            this.groupBox1.Controls.Add(this.btnPauseMessage);
            this.groupBox1.Controls.Add(this.btnPlayMessage);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(220, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message Announcement";
            // 
            // nupMessage
            // 
            this.nupMessage.Location = new System.Drawing.Point(18, 44);
            this.nupMessage.Name = "nupMessage";
            this.nupMessage.Size = new System.Drawing.Size(88, 26);
            this.nupMessage.TabIndex = 1;
            this.nupMessage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnStopMessage
            // 
            this.btnStopMessage.BackColor = System.Drawing.Color.Red;
            this.btnStopMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnStopMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStopMessage.Image = global::ArecaIPIS.Properties.Resources._9035124_stop_icon;
            this.btnStopMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopMessage.Location = new System.Drawing.Point(231, 38);
            this.btnStopMessage.Name = "btnStopMessage";
            this.btnStopMessage.Size = new System.Drawing.Size(96, 36);
            this.btnStopMessage.TabIndex = 3;
            this.btnStopMessage.Text = "STOP";
            this.btnStopMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStopMessage.UseVisualStyleBackColor = false;
            this.btnStopMessage.Click += new System.EventHandler(this.btnStopMessage_Click);
            // 
            // btnPauseMessage
            // 
            this.btnPauseMessage.BackColor = System.Drawing.Color.Orange;
            this.btnPauseMessage.FlatAppearance.BorderSize = 0;
            this.btnPauseMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPauseMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPauseMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPauseMessage.Image = global::ArecaIPIS.Properties.Resources._9224396_pause_stop_music_multimedia_break_icon;
            this.btnPauseMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPauseMessage.Location = new System.Drawing.Point(342, 38);
            this.btnPauseMessage.Name = "btnPauseMessage";
            this.btnPauseMessage.Size = new System.Drawing.Size(103, 36);
            this.btnPauseMessage.TabIndex = 4;
            this.btnPauseMessage.Text = "PAUSE";
            this.btnPauseMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPauseMessage.UseVisualStyleBackColor = false;
            this.btnPauseMessage.Click += new System.EventHandler(this.btnPauseMessage_Click);
            // 
            // btnPlayMessage
            // 
            this.btnPlayMessage.BackColor = System.Drawing.Color.LawnGreen;
            this.btnPlayMessage.FlatAppearance.BorderSize = 0;
            this.btnPlayMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPlayMessage.Image = global::ArecaIPIS.Properties.Resources._352072_arrow_play_icon__1_;
            this.btnPlayMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlayMessage.Location = new System.Drawing.Point(116, 38);
            this.btnPlayMessage.Name = "btnPlayMessage";
            this.btnPlayMessage.Size = new System.Drawing.Size(100, 36);
            this.btnPlayMessage.TabIndex = 2;
            this.btnPlayMessage.Text = "PLAY";
            this.btnPlayMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlayMessage.UseVisualStyleBackColor = false;
            this.btnPlayMessage.Click += new System.EventHandler(this.btnPlayMessage_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSendMessage.FlatAppearance.BorderSize = 0;
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMessage.ForeColor = System.Drawing.Color.Black;
            this.btnSendMessage.Image = global::ArecaIPIS.Properties.Resources._9042711_page_icon;
            this.btnSendMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendMessage.Location = new System.Drawing.Point(81, 37);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(114, 58);
            this.btnSendMessage.TabIndex = 0;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // openFileDialogs
            // 
            this.openFileDialogs.FileName = "openFileDialogs";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Delete";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 155;
            // 
            // frmSlogans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 509);
            this.Controls.Add(this.pnlSlogan);
            this.Controls.Add(this.lblNormalMessages);
            this.Controls.Add(this.pnlMessageAnnouncement);
            this.Controls.Add(this.pnlFormShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSlogans";
            this.Text = "frmSlogans";
            this.Load += new System.EventHandler(this.frmSlogans_Load);
            this.pnlSlogan.ResumeLayout(false);
            this.pnlSlogan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlogan)).EndInit();
            this.pnlFormShow.ResumeLayout(false);
            this.pnlFormShow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCross)).EndInit();
            this.pnlCreate.ResumeLayout(false);
            this.pnlCreate.PerformLayout();
            this.pnlMessageAnnouncement.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNormalMessages;
        private System.Windows.Forms.Panel pnlSlogan;
        private System.Windows.Forms.Panel pnlMessageAnnouncement;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnStopMessage;
        private System.Windows.Forms.Button btnPauseMessage;
        private System.Windows.Forms.Button btnPlayMessage;
        private System.Windows.Forms.NumericUpDown nupMessage;
        private System.Windows.Forms.TextBox txtBoardId;
        private System.Windows.Forms.Label lblBoardId;
        private System.Windows.Forms.ComboBox cmbBoardType;
        private System.Windows.Forms.Label lblBoardType;
        private System.Windows.Forms.DataGridView dgvSlogan;
        private System.Windows.Forms.Button btnDropdown;
        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddSloganMessage;
        private System.Windows.Forms.Label lblNoDataToDisplay;
        private System.Windows.Forms.Panel pnlFormShow;
        private System.Windows.Forms.ToolTip toolTipSlogan;
        private System.Windows.Forms.Label lblMessageValidation;
        private System.Windows.Forms.PictureBox pbCross;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.Label lblShowingAudio;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAudioFile;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlCreate;
        private System.Windows.Forms.Label lblCreateMessage;
        private System.Windows.Forms.OpenFileDialog openFileDialogs;
        private System.Windows.Forms.CheckedListBox chkFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReq2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSloganLanguage;
    }
}