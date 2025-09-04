
namespace ArecaIPIS.Forms.ViewForms
{
    partial class frmMessageScript
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
            this.btnView = new System.Windows.Forms.Button();
            this.dgvMessageScriptTable = new System.Windows.Forms.DataGridView();
            this.column = new System.Windows.Forms.DataGridViewImageColumn();
            this.MessagePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbPlatform = new System.Windows.Forms.ComboBox();
            this.cmbTrainLanguage = new System.Windows.Forms.ComboBox();
            this.cmbMessages = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblMessages = new System.Windows.Forms.Label();
            this.lblMessageScript = new System.Windows.Forms.Label();
            this.lblNoDataToDisplay = new System.Windows.Forms.Label();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnAddMessage = new System.Windows.Forms.Button();
            this.pnlMessageAudioScript = new System.Windows.Forms.Panel();
            this.lblMessageNameValidation = new System.Windows.Forms.Label();
            this.lblMessagepathValidation = new System.Windows.Forms.Label();
            this.lblStatusValidation = new System.Windows.Forms.Label();
            this.nupSequence = new System.Windows.Forms.NumericUpDown();
            this.lblNoFileChosen = new System.Windows.Forms.Label();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.cmbStatusMessage = new System.Windows.Forms.ComboBox();
            this.lblCPosition = new System.Windows.Forms.Label();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.cmbLanguageName = new System.Windows.Forms.ComboBox();
            this.lblLanguageName = new System.Windows.Forms.Label();
            this.cmbMessageName = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNoteDef2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblReq2 = new System.Windows.Forms.Label();
            this.lblSequence = new System.Windows.Forms.Label();
            this.lblReq3 = new System.Windows.Forms.Label();
            this.lblMessagePath = new System.Windows.Forms.Label();
            this.lblReq1 = new System.Windows.Forms.Label();
            this.lblMessageName = new System.Windows.Forms.Label();
            this.pbCross = new System.Windows.Forms.PictureBox();
            this.pbTick = new System.Windows.Forms.PictureBox();
            this.pbCrossMessagePath = new System.Windows.Forms.PictureBox();
            this.pbTickMessagePath = new System.Windows.Forms.PictureBox();
            this.pbCrossStatus = new System.Windows.Forms.PictureBox();
            this.pbTickStatus = new System.Windows.Forms.PictureBox();
            this.pnlCreateMessageAudioScript = new System.Windows.Forms.Panel();
            this.lblCreateMessageAudioScript = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessageScriptTable)).BeginInit();
            this.pnlMessageAudioScript.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupSequence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossMessagePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickMessagePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickStatus)).BeginInit();
            this.pnlCreateMessageAudioScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnView.Location = new System.Drawing.Point(897, 33);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(101, 34);
            this.btnView.TabIndex = 19;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dgvMessageScriptTable
            // 
            this.dgvMessageScriptTable.AllowUserToAddRows = false;
            this.dgvMessageScriptTable.AllowUserToResizeColumns = false;
            this.dgvMessageScriptTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvMessageScriptTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMessageScriptTable.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMessageScriptTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMessageScriptTable.ColumnHeadersHeight = 35;
            this.dgvMessageScriptTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMessageScriptTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column,
            this.MessagePath,
            this.MessageName,
            this.Sequence});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMessageScriptTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMessageScriptTable.Location = new System.Drawing.Point(12, 71);
            this.dgvMessageScriptTable.Name = "dgvMessageScriptTable";
            this.dgvMessageScriptTable.RowHeadersVisible = false;
            this.dgvMessageScriptTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvMessageScriptTable.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMessageScriptTable.RowTemplate.Height = 28;
            this.dgvMessageScriptTable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvMessageScriptTable.Size = new System.Drawing.Size(1259, 174);
            this.dgvMessageScriptTable.TabIndex = 18;
            this.dgvMessageScriptTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMessageScriptTable_CellClick);
            // 
            // column
            // 
            this.column.HeaderText = "";
            this.column.Image = global::ArecaIPIS.Properties.Resources.edit;
            this.column.Name = "column";
            this.column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MessagePath
            // 
            this.MessagePath.HeaderText = "Message Path";
            this.MessagePath.Name = "MessagePath";
            this.MessagePath.ReadOnly = true;
            this.MessagePath.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MessagePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MessagePath.Width = 400;
            // 
            // MessageName
            // 
            this.MessageName.HeaderText = "Message Name";
            this.MessageName.Name = "MessageName";
            this.MessageName.ReadOnly = true;
            this.MessageName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MessageName.Width = 380;
            // 
            // Sequence
            // 
            this.Sequence.HeaderText = "Sequence";
            this.Sequence.Name = "Sequence";
            this.Sequence.ReadOnly = true;
            this.Sequence.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sequence.Width = 380;
            // 
            // cmbPlatform
            // 
            this.cmbPlatform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlatform.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbPlatform.FormattingEnabled = true;
            this.cmbPlatform.Location = new System.Drawing.Point(701, 38);
            this.cmbPlatform.Name = "cmbPlatform";
            this.cmbPlatform.Size = new System.Drawing.Size(137, 28);
            this.cmbPlatform.TabIndex = 17;
            this.cmbPlatform.Text = "Select";
            // 
            // cmbTrainLanguage
            // 
            this.cmbTrainLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTrainLanguage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbTrainLanguage.FormattingEnabled = true;
            this.cmbTrainLanguage.Location = new System.Drawing.Point(421, 38);
            this.cmbTrainLanguage.Name = "cmbTrainLanguage";
            this.cmbTrainLanguage.Size = new System.Drawing.Size(146, 28);
            this.cmbTrainLanguage.TabIndex = 16;
            this.cmbTrainLanguage.Text = "Select";
            // 
            // cmbMessages
            // 
            this.cmbMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMessages.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbMessages.FormattingEnabled = true;
            this.cmbMessages.Location = new System.Drawing.Point(136, 38);
            this.cmbMessages.Name = "cmbMessages";
            this.cmbMessages.Size = new System.Drawing.Size(159, 28);
            this.cmbMessages.TabIndex = 15;
            this.cmbMessages.Text = "Select";
            this.cmbMessages.SelectedIndexChanged += new System.EventHandler(this.cmbMessages_SelectedIndexChanged);
            this.cmbMessages.Click += new System.EventHandler(this.cmbMessages_Click);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLanguage.Location = new System.Drawing.Point(326, 41);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(89, 20);
            this.lblLanguage.TabIndex = 14;
            this.lblLanguage.Text = "Language :";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPosition.Location = new System.Drawing.Point(619, 41);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(73, 20);
            this.lblPosition.TabIndex = 13;
            this.lblPosition.Text = "Position :";
            // 
            // lblMessages
            // 
            this.lblMessages.AutoSize = true;
            this.lblMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessages.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMessages.Location = new System.Drawing.Point(23, 41);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(90, 20);
            this.lblMessages.TabIndex = 12;
            this.lblMessages.Text = "Messages :";
            // 
            // lblMessageScript
            // 
            this.lblMessageScript.AutoSize = true;
            this.lblMessageScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageScript.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblMessageScript.Location = new System.Drawing.Point(13, 6);
            this.lblMessageScript.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessageScript.Name = "lblMessageScript";
            this.lblMessageScript.Size = new System.Drawing.Size(153, 24);
            this.lblMessageScript.TabIndex = 11;
            this.lblMessageScript.Text = "Message Script";
            // 
            // lblNoDataToDisplay
            // 
            this.lblNoDataToDisplay.AutoSize = true;
            this.lblNoDataToDisplay.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNoDataToDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataToDisplay.ForeColor = System.Drawing.Color.Black;
            this.lblNoDataToDisplay.Location = new System.Drawing.Point(522, 115);
            this.lblNoDataToDisplay.Name = "lblNoDataToDisplay";
            this.lblNoDataToDisplay.Size = new System.Drawing.Size(216, 25);
            this.lblNoDataToDisplay.TabIndex = 63;
            this.lblNoDataToDisplay.Text = "No Data To Display";
            // 
            // pnlPagination
            // 
            this.pnlPagination.BackColor = System.Drawing.Color.Transparent;
            this.pnlPagination.Location = new System.Drawing.Point(12, 243);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1259, 51);
            this.pnlPagination.TabIndex = 64;
            this.pnlPagination.Visible = false;
            // 
            // btnAddMessage
            // 
            this.btnAddMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddMessage.FlatAppearance.BorderSize = 0;
            this.btnAddMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMessage.ForeColor = System.Drawing.Color.Black;
            this.btnAddMessage.Location = new System.Drawing.Point(48, 77);
            this.btnAddMessage.Name = "btnAddMessage";
            this.btnAddMessage.Size = new System.Drawing.Size(36, 28);
            this.btnAddMessage.TabIndex = 65;
            this.btnAddMessage.Text = "+";
            this.btnAddMessage.UseVisualStyleBackColor = false;
            this.btnAddMessage.Click += new System.EventHandler(this.btnAddMessage_Click);
            // 
            // pnlMessageAudioScript
            // 
            this.pnlMessageAudioScript.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMessageAudioScript.Controls.Add(this.lblMessageNameValidation);
            this.pnlMessageAudioScript.Controls.Add(this.lblMessagepathValidation);
            this.pnlMessageAudioScript.Controls.Add(this.lblStatusValidation);
            this.pnlMessageAudioScript.Controls.Add(this.nupSequence);
            this.pnlMessageAudioScript.Controls.Add(this.lblNoFileChosen);
            this.pnlMessageAudioScript.Controls.Add(this.btnAddFile);
            this.pnlMessageAudioScript.Controls.Add(this.cmbPosition);
            this.pnlMessageAudioScript.Controls.Add(this.cmbStatusMessage);
            this.pnlMessageAudioScript.Controls.Add(this.lblCPosition);
            this.pnlMessageAudioScript.Controls.Add(this.lblStatusMessage);
            this.pnlMessageAudioScript.Controls.Add(this.cmbLanguageName);
            this.pnlMessageAudioScript.Controls.Add(this.lblLanguageName);
            this.pnlMessageAudioScript.Controls.Add(this.cmbMessageName);
            this.pnlMessageAudioScript.Controls.Add(this.btnClose);
            this.pnlMessageAudioScript.Controls.Add(this.btnSave);
            this.pnlMessageAudioScript.Controls.Add(this.label1);
            this.pnlMessageAudioScript.Controls.Add(this.lblNoteDef2);
            this.pnlMessageAudioScript.Controls.Add(this.label2);
            this.pnlMessageAudioScript.Controls.Add(this.lblReq2);
            this.pnlMessageAudioScript.Controls.Add(this.lblSequence);
            this.pnlMessageAudioScript.Controls.Add(this.lblReq3);
            this.pnlMessageAudioScript.Controls.Add(this.lblMessagePath);
            this.pnlMessageAudioScript.Controls.Add(this.lblReq1);
            this.pnlMessageAudioScript.Controls.Add(this.lblMessageName);
            this.pnlMessageAudioScript.Controls.Add(this.pbCross);
            this.pnlMessageAudioScript.Controls.Add(this.pbTick);
            this.pnlMessageAudioScript.Controls.Add(this.pbCrossMessagePath);
            this.pnlMessageAudioScript.Controls.Add(this.pbTickMessagePath);
            this.pnlMessageAudioScript.Controls.Add(this.pbCrossStatus);
            this.pnlMessageAudioScript.Controls.Add(this.pbTickStatus);
            this.pnlMessageAudioScript.Location = new System.Drawing.Point(12, 300);
            this.pnlMessageAudioScript.Name = "pnlMessageAudioScript";
            this.pnlMessageAudioScript.Size = new System.Drawing.Size(1259, 164);
            this.pnlMessageAudioScript.TabIndex = 66;
            this.pnlMessageAudioScript.Visible = false;
            // 
            // lblMessageNameValidation
            // 
            this.lblMessageNameValidation.AutoSize = true;
            this.lblMessageNameValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMessageNameValidation.Location = new System.Drawing.Point(175, 107);
            this.lblMessageNameValidation.Name = "lblMessageNameValidation";
            this.lblMessageNameValidation.Size = new System.Drawing.Size(144, 13);
            this.lblMessageNameValidation.TabIndex = 105;
            this.lblMessageNameValidation.Text = "Please Enter Message Name";
            this.lblMessageNameValidation.Visible = false;
            // 
            // lblMessagepathValidation
            // 
            this.lblMessagepathValidation.AutoSize = true;
            this.lblMessagepathValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMessagepathValidation.Location = new System.Drawing.Point(639, 63);
            this.lblMessagepathValidation.Name = "lblMessagepathValidation";
            this.lblMessagepathValidation.Size = new System.Drawing.Size(138, 13);
            this.lblMessagepathValidation.TabIndex = 104;
            this.lblMessagepathValidation.Text = "Please Enter Message Path";
            this.lblMessagepathValidation.Visible = false;
            // 
            // lblStatusValidation
            // 
            this.lblStatusValidation.AutoSize = true;
            this.lblStatusValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStatusValidation.Location = new System.Drawing.Point(175, 146);
            this.lblStatusValidation.Name = "lblStatusValidation";
            this.lblStatusValidation.Size = new System.Drawing.Size(146, 13);
            this.lblStatusValidation.TabIndex = 103;
            this.lblStatusValidation.Text = "Please Enter Status Message";
            this.lblStatusValidation.Visible = false;
            // 
            // nupSequence
            // 
            this.nupSequence.Location = new System.Drawing.Point(642, 84);
            this.nupSequence.Name = "nupSequence";
            this.nupSequence.Size = new System.Drawing.Size(120, 20);
            this.nupSequence.TabIndex = 102;
            this.nupSequence.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNoFileChosen
            // 
            this.lblNoFileChosen.AutoSize = true;
            this.lblNoFileChosen.ForeColor = System.Drawing.Color.Black;
            this.lblNoFileChosen.Location = new System.Drawing.Point(735, 43);
            this.lblNoFileChosen.Name = "lblNoFileChosen";
            this.lblNoFileChosen.Size = new System.Drawing.Size(75, 13);
            this.lblNoFileChosen.TabIndex = 101;
            this.lblNoFileChosen.Text = "No file chosen";
            this.lblNoFileChosen.TextChanged += new System.EventHandler(this.lblNoFileChosen_TextChanged);
            // 
            // btnAddFile
            // 
            this.btnAddFile.ForeColor = System.Drawing.Color.Black;
            this.btnAddFile.Location = new System.Drawing.Point(642, 37);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(86, 23);
            this.btnAddFile.TabIndex = 100;
            this.btnAddFile.Text = "Choose File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(642, 122);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(153, 21);
            this.cmbPosition.TabIndex = 99;
            // 
            // cmbStatusMessage
            // 
            this.cmbStatusMessage.FormattingEnabled = true;
            this.cmbStatusMessage.Location = new System.Drawing.Point(178, 123);
            this.cmbStatusMessage.Name = "cmbStatusMessage";
            this.cmbStatusMessage.Size = new System.Drawing.Size(153, 21);
            this.cmbStatusMessage.TabIndex = 98;
            this.cmbStatusMessage.SelectedValueChanged += new System.EventHandler(this.cmbStatusMessage_SelectedValueChanged);
            // 
            // lblCPosition
            // 
            this.lblCPosition.AutoSize = true;
            this.lblCPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPosition.ForeColor = System.Drawing.Color.Black;
            this.lblCPosition.Location = new System.Drawing.Point(511, 122);
            this.lblCPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCPosition.Name = "lblCPosition";
            this.lblCPosition.Size = new System.Drawing.Size(64, 16);
            this.lblCPosition.TabIndex = 91;
            this.lblCPosition.Text = "Position";
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMessage.ForeColor = System.Drawing.Color.Black;
            this.lblStatusMessage.Location = new System.Drawing.Point(47, 123);
            this.lblStatusMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(123, 16);
            this.lblStatusMessage.TabIndex = 89;
            this.lblStatusMessage.Text = "Status Message ";
            // 
            // cmbLanguageName
            // 
            this.cmbLanguageName.FormattingEnabled = true;
            this.cmbLanguageName.Location = new System.Drawing.Point(178, 42);
            this.cmbLanguageName.Name = "cmbLanguageName";
            this.cmbLanguageName.Size = new System.Drawing.Size(153, 21);
            this.cmbLanguageName.TabIndex = 88;
            // 
            // lblLanguageName
            // 
            this.lblLanguageName.AutoSize = true;
            this.lblLanguageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguageName.ForeColor = System.Drawing.Color.Black;
            this.lblLanguageName.Location = new System.Drawing.Point(47, 42);
            this.lblLanguageName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLanguageName.Name = "lblLanguageName";
            this.lblLanguageName.Size = new System.Drawing.Size(122, 16);
            this.lblLanguageName.TabIndex = 87;
            this.lblLanguageName.Text = "Language Name";
            // 
            // cmbMessageName
            // 
            this.cmbMessageName.FormattingEnabled = true;
            this.cmbMessageName.Items.AddRange(new object[] {
            "Select",
            "Train No.",
            "Platfrom No.",
            "Coaches",
            "Special Message",
            "Position Message"});
            this.cmbMessageName.Location = new System.Drawing.Point(178, 82);
            this.cmbMessageName.Name = "cmbMessageName";
            this.cmbMessageName.Size = new System.Drawing.Size(153, 21);
            this.cmbMessageName.TabIndex = 86;
            this.cmbMessageName.TextChanged += new System.EventHandler(this.cmbMessageName_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(950, 122);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 32);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::ArecaIPIS.Properties.Resources._1564499_accept_added_check_complite_yes_icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(950, 75);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 32);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(546, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Asterisk (";
            // 
            // lblNoteDef2
            // 
            this.lblNoteDef2.AutoSize = true;
            this.lblNoteDef2.ForeColor = System.Drawing.Color.Black;
            this.lblNoteDef2.Location = new System.Drawing.Point(605, 146);
            this.lblNoteDef2.Name = "lblNoteDef2";
            this.lblNoteDef2.Size = new System.Drawing.Size(105, 13);
            this.lblNoteDef2.TabIndex = 54;
            this.lblNoteDef2.Text = ") Fields Are Required";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(592, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 24);
            this.label2.TabIndex = 53;
            this.label2.Text = "*";
            // 
            // lblReq2
            // 
            this.lblReq2.AutoSize = true;
            this.lblReq2.BackColor = System.Drawing.Color.White;
            this.lblReq2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq2.ForeColor = System.Drawing.Color.Red;
            this.lblReq2.Location = new System.Drawing.Point(491, 82);
            this.lblReq2.Name = "lblReq2";
            this.lblReq2.Size = new System.Drawing.Size(18, 24);
            this.lblReq2.TabIndex = 50;
            this.lblReq2.Text = "*";
            // 
            // lblSequence
            // 
            this.lblSequence.AutoSize = true;
            this.lblSequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSequence.ForeColor = System.Drawing.Color.Black;
            this.lblSequence.Location = new System.Drawing.Point(511, 82);
            this.lblSequence.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSequence.Name = "lblSequence";
            this.lblSequence.Size = new System.Drawing.Size(78, 16);
            this.lblSequence.TabIndex = 49;
            this.lblSequence.Text = "Sequence";
            // 
            // lblReq3
            // 
            this.lblReq3.AutoSize = true;
            this.lblReq3.BackColor = System.Drawing.Color.White;
            this.lblReq3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq3.ForeColor = System.Drawing.Color.Red;
            this.lblReq3.Location = new System.Drawing.Point(491, 34);
            this.lblReq3.Name = "lblReq3";
            this.lblReq3.Size = new System.Drawing.Size(18, 24);
            this.lblReq3.TabIndex = 47;
            this.lblReq3.Text = "*";
            // 
            // lblMessagePath
            // 
            this.lblMessagePath.AutoSize = true;
            this.lblMessagePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessagePath.ForeColor = System.Drawing.Color.Black;
            this.lblMessagePath.Location = new System.Drawing.Point(511, 37);
            this.lblMessagePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessagePath.Name = "lblMessagePath";
            this.lblMessagePath.Size = new System.Drawing.Size(107, 16);
            this.lblMessagePath.TabIndex = 46;
            this.lblMessagePath.Text = "Message Path";
            // 
            // lblReq1
            // 
            this.lblReq1.AutoSize = true;
            this.lblReq1.BackColor = System.Drawing.Color.White;
            this.lblReq1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq1.ForeColor = System.Drawing.Color.Red;
            this.lblReq1.Location = new System.Drawing.Point(27, 88);
            this.lblReq1.Name = "lblReq1";
            this.lblReq1.Size = new System.Drawing.Size(18, 24);
            this.lblReq1.TabIndex = 44;
            this.lblReq1.Text = "*";
            // 
            // lblMessageName
            // 
            this.lblMessageName.AutoSize = true;
            this.lblMessageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageName.ForeColor = System.Drawing.Color.Black;
            this.lblMessageName.Location = new System.Drawing.Point(47, 82);
            this.lblMessageName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessageName.Name = "lblMessageName";
            this.lblMessageName.Size = new System.Drawing.Size(117, 16);
            this.lblMessageName.TabIndex = 43;
            this.lblMessageName.Text = "Message Name";
            // 
            // pbCross
            // 
            this.pbCross.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCross.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCross.ImageLocation = "";
            this.pbCross.Location = new System.Drawing.Point(337, 84);
            this.pbCross.Name = "pbCross";
            this.pbCross.Size = new System.Drawing.Size(25, 20);
            this.pbCross.TabIndex = 77;
            this.pbCross.TabStop = false;
            this.pbCross.Visible = false;
            // 
            // pbTick
            // 
            this.pbTick.Location = new System.Drawing.Point(0, 0);
            this.pbTick.Name = "pbTick";
            this.pbTick.Size = new System.Drawing.Size(100, 50);
            this.pbTick.TabIndex = 106;
            this.pbTick.TabStop = false;
            // 
            // pbCrossMessagePath
            // 
            this.pbCrossMessagePath.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCrossMessagePath.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCrossMessagePath.ImageLocation = "";
            this.pbCrossMessagePath.Location = new System.Drawing.Point(816, 56);
            this.pbCrossMessagePath.Name = "pbCrossMessagePath";
            this.pbCrossMessagePath.Size = new System.Drawing.Size(25, 20);
            this.pbCrossMessagePath.TabIndex = 81;
            this.pbCrossMessagePath.TabStop = false;
            this.pbCrossMessagePath.Visible = false;
            // 
            // pbTickMessagePath
            // 
            this.pbTickMessagePath.Location = new System.Drawing.Point(0, 0);
            this.pbTickMessagePath.Name = "pbTickMessagePath";
            this.pbTickMessagePath.Size = new System.Drawing.Size(100, 50);
            this.pbTickMessagePath.TabIndex = 107;
            this.pbTickMessagePath.TabStop = false;
            // 
            // pbCrossStatus
            // 
            this.pbCrossStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCrossStatus.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCrossStatus.ImageLocation = "";
            this.pbCrossStatus.Location = new System.Drawing.Point(337, 124);
            this.pbCrossStatus.Name = "pbCrossStatus";
            this.pbCrossStatus.Size = new System.Drawing.Size(25, 20);
            this.pbCrossStatus.TabIndex = 79;
            this.pbCrossStatus.TabStop = false;
            this.pbCrossStatus.Visible = false;
            // 
            // pbTickStatus
            // 
            this.pbTickStatus.Location = new System.Drawing.Point(0, 0);
            this.pbTickStatus.Name = "pbTickStatus";
            this.pbTickStatus.Size = new System.Drawing.Size(100, 50);
            this.pbTickStatus.TabIndex = 108;
            this.pbTickStatus.TabStop = false;
            // 
            // pnlCreateMessageAudioScript
            // 
            this.pnlCreateMessageAudioScript.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlCreateMessageAudioScript.Controls.Add(this.lblCreateMessageAudioScript);
            this.pnlCreateMessageAudioScript.Location = new System.Drawing.Point(12, 301);
            this.pnlCreateMessageAudioScript.Name = "pnlCreateMessageAudioScript";
            this.pnlCreateMessageAudioScript.Size = new System.Drawing.Size(1259, 29);
            this.pnlCreateMessageAudioScript.TabIndex = 86;
            this.pnlCreateMessageAudioScript.Visible = false;
            // 
            // lblCreateMessageAudioScript
            // 
            this.lblCreateMessageAudioScript.AutoSize = true;
            this.lblCreateMessageAudioScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateMessageAudioScript.ForeColor = System.Drawing.Color.Black;
            this.lblCreateMessageAudioScript.Location = new System.Drawing.Point(15, 4);
            this.lblCreateMessageAudioScript.Name = "lblCreateMessageAudioScript";
            this.lblCreateMessageAudioScript.Size = new System.Drawing.Size(329, 24);
            this.lblCreateMessageAudioScript.TabIndex = 0;
            this.lblCreateMessageAudioScript.Text = "Create New Message Audio Script";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::ArecaIPIS.Properties.Resources.edit;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // frmMessageScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 548);
            this.Controls.Add(this.btnAddMessage);
            this.Controls.Add(this.lblNoDataToDisplay);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.cmbPlatform);
            this.Controls.Add(this.cmbTrainLanguage);
            this.Controls.Add(this.cmbMessages);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblMessages);
            this.Controls.Add(this.lblMessageScript);
            this.Controls.Add(this.pnlCreateMessageAudioScript);
            this.Controls.Add(this.pnlPagination);
            this.Controls.Add(this.dgvMessageScriptTable);
            this.Controls.Add(this.pnlMessageAudioScript);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMessageScript";
            this.Text = "frmMessageScript";
            this.Load += new System.EventHandler(this.frmMessageScript_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessageScriptTable)).EndInit();
            this.pnlMessageAudioScript.ResumeLayout(false);
            this.pnlMessageAudioScript.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupSequence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossMessagePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickMessagePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickStatus)).EndInit();
            this.pnlCreateMessageAudioScript.ResumeLayout(false);
            this.pnlCreateMessageAudioScript.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridView dgvMessageScriptTable;
        private System.Windows.Forms.ComboBox cmbPlatform;
        private System.Windows.Forms.ComboBox cmbTrainLanguage;
        private System.Windows.Forms.ComboBox cmbMessages;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.Label lblMessageScript;
        private System.Windows.Forms.Label lblNoDataToDisplay;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnAddMessage;
        private System.Windows.Forms.Panel pnlMessageAudioScript;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNoteDef2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReq2;
        private System.Windows.Forms.Label lblSequence;
        private System.Windows.Forms.Label lblReq3;
        private System.Windows.Forms.Label lblMessagePath;
        private System.Windows.Forms.Label lblReq1;
        private System.Windows.Forms.Label lblMessageName;
        private System.Windows.Forms.PictureBox pbCross;
        private System.Windows.Forms.PictureBox pbTick;
        private System.Windows.Forms.PictureBox pbCrossMessagePath;
        private System.Windows.Forms.PictureBox pbTickMessagePath;
        private System.Windows.Forms.PictureBox pbTickStatus;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.ComboBox cmbStatusMessage;
        private System.Windows.Forms.Label lblCPosition;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.ComboBox cmbLanguageName;
        private System.Windows.Forms.Label lblLanguageName;
        private System.Windows.Forms.ComboBox cmbMessageName;
        private System.Windows.Forms.PictureBox pbCrossStatus;
        private System.Windows.Forms.Panel pnlCreateMessageAudioScript;
        private System.Windows.Forms.Label lblCreateMessageAudioScript;
        private System.Windows.Forms.Label lblNoFileChosen;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.NumericUpDown nupSequence;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label lblStatusValidation;
        private System.Windows.Forms.Label lblMessageNameValidation;
        private System.Windows.Forms.Label lblMessagepathValidation;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewImageColumn column;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessagePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sequence;
    }
}