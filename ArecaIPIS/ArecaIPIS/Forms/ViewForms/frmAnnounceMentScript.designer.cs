
namespace ArecaIPIS.Forms.ViewForms
{
    partial class frmAnnounceMentScript
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblAnnouncementScript = new System.Windows.Forms.Label();
            this.lblTrainStatus = new System.Windows.Forms.Label();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cbmTrainStatus = new System.Windows.Forms.ComboBox();
            this.cmbTrainLanguage = new System.Windows.Forms.ComboBox();
            this.cmbPlatform = new System.Windows.Forms.ComboBox();
            this.dgvAnnScriptTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.AudioPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddAudioScript = new System.Windows.Forms.Button();
            this.pnlAudioScriptCreate = new System.Windows.Forms.Panel();
            this.lblAudioPathValidation = new System.Windows.Forms.Label();
            this.lblSequenceValidation = new System.Windows.Forms.Label();
            this.lblAudioNameValidation = new System.Windows.Forms.Label();
            this.nudSequence = new System.Windows.Forms.NumericUpDown();
            this.lblNoteDef1 = new System.Windows.Forms.Label();
            this.CmbPlatformStatus = new System.Windows.Forms.ComboBox();
            this.cnbTrainStatus = new System.Windows.Forms.ComboBox();
            this.cmbLanguageName = new System.Windows.Forms.ComboBox();
            this.lblPlatformStatus = new System.Windows.Forms.Label();
            this.lblLanguageName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblNoteDef2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCreateNewAudioScript = new System.Windows.Forms.Panel();
            this.lblCreateNewAudioScript = new System.Windows.Forms.Label();
            this.lblReq3 = new System.Windows.Forms.Label();
            this.lblReq1 = new System.Windows.Forms.Label();
            this.lblReq2 = new System.Windows.Forms.Label();
            this.txtAudioName = new System.Windows.Forms.TextBox();
            this.txtAudioPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSequence = new System.Windows.Forms.Label();
            this.lblAudioName = new System.Windows.Forms.Label();
            this.lblAudioPath = new System.Windows.Forms.Label();
            this.pbCrossAudioName = new System.Windows.Forms.PictureBox();
            this.pbCrossAudioPath = new System.Windows.Forms.PictureBox();
            this.pbCrossSequence = new System.Windows.Forms.PictureBox();
            this.pbTickSequence = new System.Windows.Forms.PictureBox();
            this.pbTickAudioName = new System.Windows.Forms.PictureBox();
            this.pbTickAudioPath = new System.Windows.Forms.PictureBox();
            this.btnAddMessage = new System.Windows.Forms.Button();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.lblNoDataToDisplay = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnScriptTable)).BeginInit();
            this.pnlAudioScriptCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSequence)).BeginInit();
            this.pnlCreateNewAudioScript.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossAudioName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossAudioPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossSequence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickSequence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickAudioName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickAudioPath)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAnnouncementScript
            // 
            this.lblAnnouncementScript.AutoSize = true;
            this.lblAnnouncementScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnouncementScript.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAnnouncementScript.Location = new System.Drawing.Point(121, 6);
            this.lblAnnouncementScript.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnnouncementScript.Name = "lblAnnouncementScript";
            this.lblAnnouncementScript.Size = new System.Drawing.Size(212, 24);
            this.lblAnnouncementScript.TabIndex = 2;
            this.lblAnnouncementScript.Text = "Announcement Script";
            // 
            // lblTrainStatus
            // 
            this.lblTrainStatus.AutoSize = true;
            this.lblTrainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTrainStatus.Location = new System.Drawing.Point(118, 40);
            this.lblTrainStatus.Name = "lblTrainStatus";
            this.lblTrainStatus.Size = new System.Drawing.Size(107, 20);
            this.lblTrainStatus.TabIndex = 3;
            this.lblTrainStatus.Text = "Train Status  :";
            // 
            // lblPlatform
            // 
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlatform.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPlatform.Location = new System.Drawing.Point(714, 40);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(76, 20);
            this.lblPlatform.TabIndex = 4;
            this.lblPlatform.Text = "Platform :";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLanguage.Location = new System.Drawing.Point(422, 39);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(89, 20);
            this.lblLanguage.TabIndex = 5;
            this.lblLanguage.Text = "Language :";
            // 
            // cbmTrainStatus
            // 
            this.cbmTrainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmTrainStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbmTrainStatus.FormattingEnabled = true;
            this.cbmTrainStatus.Location = new System.Drawing.Point(231, 37);
            this.cbmTrainStatus.Name = "cbmTrainStatus";
            this.cbmTrainStatus.Size = new System.Drawing.Size(159, 28);
            this.cbmTrainStatus.TabIndex = 1;
            this.cbmTrainStatus.Text = "Select";
            this.cbmTrainStatus.Click += new System.EventHandler(this.cbmTrainStatus_Click);
            // 
            // cmbTrainLanguage
            // 
            this.cmbTrainLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTrainLanguage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbTrainLanguage.FormattingEnabled = true;
            this.cmbTrainLanguage.Location = new System.Drawing.Point(517, 36);
            this.cmbTrainLanguage.Name = "cmbTrainLanguage";
            this.cmbTrainLanguage.Size = new System.Drawing.Size(146, 28);
            this.cmbTrainLanguage.TabIndex = 2;
            this.cmbTrainLanguage.Text = "Select";
            // 
            // cmbPlatform
            // 
            this.cmbPlatform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlatform.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbPlatform.FormattingEnabled = true;
            this.cmbPlatform.Items.AddRange(new object[] {
            "Without Platform",
            "With Platform",
            "Not Required"});
            this.cmbPlatform.Location = new System.Drawing.Point(796, 36);
            this.cmbPlatform.Name = "cmbPlatform";
            this.cmbPlatform.Size = new System.Drawing.Size(137, 28);
            this.cmbPlatform.TabIndex = 3;
            this.cmbPlatform.Text = "Select";
            // 
            // dgvAnnScriptTable
            // 
            this.dgvAnnScriptTable.AllowUserToAddRows = false;
            this.dgvAnnScriptTable.AllowUserToResizeColumns = false;
            this.dgvAnnScriptTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgvAnnScriptTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAnnScriptTable.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvAnnScriptTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAnnScriptTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAnnScriptTable.ColumnHeadersHeight = 34;
            this.dgvAnnScriptTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAnnScriptTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.AudioPath,
            this.AudioFileName,
            this.Sequence});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAnnScriptTable.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvAnnScriptTable.Location = new System.Drawing.Point(121, 68);
            this.dgvAnnScriptTable.Name = "dgvAnnScriptTable";
            this.dgvAnnScriptTable.ReadOnly = true;
            this.dgvAnnScriptTable.RowHeadersVisible = false;
            this.dgvAnnScriptTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dgvAnnScriptTable.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAnnScriptTable.RowTemplate.Height = 27;
            this.dgvAnnScriptTable.RowTemplate.ReadOnly = true;
            this.dgvAnnScriptTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvAnnScriptTable.Size = new System.Drawing.Size(1139, 173);
            this.dgvAnnScriptTable.TabIndex = 9;
            this.dgvAnnScriptTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnnScriptTable_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Image = global::ArecaIPIS.Properties.Resources.edit;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AudioPath
            // 
            this.AudioPath.HeaderText = "Audio Path";
            this.AudioPath.Name = "AudioPath";
            this.AudioPath.ReadOnly = true;
            this.AudioPath.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AudioPath.Width = 370;
            // 
            // AudioFileName
            // 
            this.AudioFileName.HeaderText = "Audio File Name";
            this.AudioFileName.Name = "AudioFileName";
            this.AudioFileName.ReadOnly = true;
            this.AudioFileName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AudioFileName.Width = 370;
            // 
            // Sequence
            // 
            this.Sequence.HeaderText = "Sequence";
            this.Sequence.Name = "Sequence";
            this.Sequence.ReadOnly = true;
            this.Sequence.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sequence.Width = 295;
            // 
            // btnAddAudioScript
            // 
            this.btnAddAudioScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddAudioScript.FlatAppearance.BorderSize = 0;
            this.btnAddAudioScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddAudioScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAudioScript.Location = new System.Drawing.Point(988, 34);
            this.btnAddAudioScript.Name = "btnAddAudioScript";
            this.btnAddAudioScript.Size = new System.Drawing.Size(89, 32);
            this.btnAddAudioScript.TabIndex = 4;
            this.btnAddAudioScript.Text = "View";
            this.btnAddAudioScript.UseVisualStyleBackColor = false;
            this.btnAddAudioScript.Click += new System.EventHandler(this.btnAddAudioScript_Click);
            // 
            // pnlAudioScriptCreate
            // 
            this.pnlAudioScriptCreate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlAudioScriptCreate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAudioScriptCreate.Controls.Add(this.lblAudioPathValidation);
            this.pnlAudioScriptCreate.Controls.Add(this.lblSequenceValidation);
            this.pnlAudioScriptCreate.Controls.Add(this.lblAudioNameValidation);
            this.pnlAudioScriptCreate.Controls.Add(this.nudSequence);
            this.pnlAudioScriptCreate.Controls.Add(this.lblNoteDef1);
            this.pnlAudioScriptCreate.Controls.Add(this.CmbPlatformStatus);
            this.pnlAudioScriptCreate.Controls.Add(this.cnbTrainStatus);
            this.pnlAudioScriptCreate.Controls.Add(this.cmbLanguageName);
            this.pnlAudioScriptCreate.Controls.Add(this.lblPlatformStatus);
            this.pnlAudioScriptCreate.Controls.Add(this.lblLanguageName);
            this.pnlAudioScriptCreate.Controls.Add(this.btnClose);
            this.pnlAudioScriptCreate.Controls.Add(this.btnSave);
            this.pnlAudioScriptCreate.Controls.Add(this.lblNoteDef2);
            this.pnlAudioScriptCreate.Controls.Add(this.label2);
            this.pnlAudioScriptCreate.Controls.Add(this.pnlCreateNewAudioScript);
            this.pnlAudioScriptCreate.Controls.Add(this.lblReq3);
            this.pnlAudioScriptCreate.Controls.Add(this.lblReq1);
            this.pnlAudioScriptCreate.Controls.Add(this.lblReq2);
            this.pnlAudioScriptCreate.Controls.Add(this.txtAudioName);
            this.pnlAudioScriptCreate.Controls.Add(this.txtAudioPath);
            this.pnlAudioScriptCreate.Controls.Add(this.label1);
            this.pnlAudioScriptCreate.Controls.Add(this.lblSequence);
            this.pnlAudioScriptCreate.Controls.Add(this.lblAudioName);
            this.pnlAudioScriptCreate.Controls.Add(this.lblAudioPath);
            this.pnlAudioScriptCreate.Controls.Add(this.pbCrossAudioName);
            this.pnlAudioScriptCreate.Controls.Add(this.pbCrossAudioPath);
            this.pnlAudioScriptCreate.Controls.Add(this.pbCrossSequence);
            this.pnlAudioScriptCreate.Location = new System.Drawing.Point(122, 294);
            this.pnlAudioScriptCreate.Name = "pnlAudioScriptCreate";
            this.pnlAudioScriptCreate.Size = new System.Drawing.Size(1138, 180);
            this.pnlAudioScriptCreate.TabIndex = 11;
            this.pnlAudioScriptCreate.Visible = false;
            // 
            // lblAudioPathValidation
            // 
            this.lblAudioPathValidation.AutoSize = true;
            this.lblAudioPathValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAudioPathValidation.Location = new System.Drawing.Point(684, 72);
            this.lblAudioPathValidation.Name = "lblAudioPathValidation";
            this.lblAudioPathValidation.Size = new System.Drawing.Size(122, 13);
            this.lblAudioPathValidation.TabIndex = 100;
            this.lblAudioPathValidation.Text = "Please Enter Audio Path";
            this.lblAudioPathValidation.Visible = false;
            // 
            // lblSequenceValidation
            // 
            this.lblSequenceValidation.AutoSize = true;
            this.lblSequenceValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSequenceValidation.Location = new System.Drawing.Point(684, 112);
            this.lblSequenceValidation.Name = "lblSequenceValidation";
            this.lblSequenceValidation.Size = new System.Drawing.Size(159, 13);
            this.lblSequenceValidation.TabIndex = 99;
            this.lblSequenceValidation.Text = "Please Enter Sequence Number";
            this.lblSequenceValidation.Visible = false;
            // 
            // lblAudioNameValidation
            // 
            this.lblAudioNameValidation.AutoSize = true;
            this.lblAudioNameValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAudioNameValidation.Location = new System.Drawing.Point(171, 109);
            this.lblAudioNameValidation.Name = "lblAudioNameValidation";
            this.lblAudioNameValidation.Size = new System.Drawing.Size(128, 13);
            this.lblAudioNameValidation.TabIndex = 98;
            this.lblAudioNameValidation.Text = "Please Enter Audio Name";
            this.lblAudioNameValidation.Visible = false;
            // 
            // nudSequence
            // 
            this.nudSequence.Location = new System.Drawing.Point(687, 89);
            this.nudSequence.Name = "nudSequence";
            this.nudSequence.Size = new System.Drawing.Size(230, 20);
            this.nudSequence.TabIndex = 4;
            // 
            // lblNoteDef1
            // 
            this.lblNoteDef1.AutoSize = true;
            this.lblNoteDef1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteDef1.Location = new System.Drawing.Point(171, 157);
            this.lblNoteDef1.Name = "lblNoteDef1";
            this.lblNoteDef1.Size = new System.Drawing.Size(63, 16);
            this.lblNoteDef1.TabIndex = 61;
            this.lblNoteDef1.Text = "Asterisk (";
            // 
            // CmbPlatformStatus
            // 
            this.CmbPlatformStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPlatformStatus.FormattingEnabled = true;
            this.CmbPlatformStatus.Items.AddRange(new object[] {
            "Without Platform",
            "With Platform",
            "Not Required"});
            this.CmbPlatformStatus.Location = new System.Drawing.Point(687, 128);
            this.CmbPlatformStatus.Name = "CmbPlatformStatus";
            this.CmbPlatformStatus.Size = new System.Drawing.Size(230, 28);
            this.CmbPlatformStatus.TabIndex = 6;
            // 
            // cnbTrainStatus
            // 
            this.cnbTrainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnbTrainStatus.FormattingEnabled = true;
            this.cnbTrainStatus.Location = new System.Drawing.Point(174, 128);
            this.cnbTrainStatus.Name = "cnbTrainStatus";
            this.cnbTrainStatus.Size = new System.Drawing.Size(230, 28);
            this.cnbTrainStatus.TabIndex = 5;
            // 
            // cmbLanguageName
            // 
            this.cmbLanguageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanguageName.FormattingEnabled = true;
            this.cmbLanguageName.Location = new System.Drawing.Point(174, 38);
            this.cmbLanguageName.Name = "cmbLanguageName";
            this.cmbLanguageName.Size = new System.Drawing.Size(230, 28);
            this.cmbLanguageName.TabIndex = 1;
            // 
            // lblPlatformStatus
            // 
            this.lblPlatformStatus.AutoSize = true;
            this.lblPlatformStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlatformStatus.Location = new System.Drawing.Point(533, 136);
            this.lblPlatformStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlatformStatus.Name = "lblPlatformStatus";
            this.lblPlatformStatus.Size = new System.Drawing.Size(139, 20);
            this.lblPlatformStatus.TabIndex = 67;
            this.lblPlatformStatus.Text = "PlatForm Status";
            // 
            // lblLanguageName
            // 
            this.lblLanguageName.AutoSize = true;
            this.lblLanguageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguageName.Location = new System.Drawing.Point(20, 36);
            this.lblLanguageName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLanguageName.Name = "lblLanguageName";
            this.lblLanguageName.Size = new System.Drawing.Size(140, 20);
            this.lblLanguageName.TabIndex = 66;
            this.lblLanguageName.Text = "Language Name";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1022, 109);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 32);
            this.btnClose.TabIndex = 65;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ArecaIPIS.Properties.Resources._1564499_accept_added_check_complite_yes_icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1022, 63);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 32);
            this.btnSave.TabIndex = 64;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblNoteDef2
            // 
            this.lblNoteDef2.AutoSize = true;
            this.lblNoteDef2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteDef2.Location = new System.Drawing.Point(238, 157);
            this.lblNoteDef2.Name = "lblNoteDef2";
            this.lblNoteDef2.Size = new System.Drawing.Size(135, 16);
            this.lblNoteDef2.TabIndex = 63;
            this.lblNoteDef2.Text = ") Fields Are Required";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(229, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 62;
            this.label2.Text = "*";
            // 
            // pnlCreateNewAudioScript
            // 
            this.pnlCreateNewAudioScript.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlCreateNewAudioScript.Controls.Add(this.lblCreateNewAudioScript);
            this.pnlCreateNewAudioScript.Location = new System.Drawing.Point(0, 0);
            this.pnlCreateNewAudioScript.Name = "pnlCreateNewAudioScript";
            this.pnlCreateNewAudioScript.Size = new System.Drawing.Size(1137, 31);
            this.pnlCreateNewAudioScript.TabIndex = 57;
            // 
            // lblCreateNewAudioScript
            // 
            this.lblCreateNewAudioScript.AutoSize = true;
            this.lblCreateNewAudioScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateNewAudioScript.Location = new System.Drawing.Point(2, 3);
            this.lblCreateNewAudioScript.Name = "lblCreateNewAudioScript";
            this.lblCreateNewAudioScript.Size = new System.Drawing.Size(239, 24);
            this.lblCreateNewAudioScript.TabIndex = 0;
            this.lblCreateNewAudioScript.Text = "Create New Audio Script";
            // 
            // lblReq3
            // 
            this.lblReq3.AutoSize = true;
            this.lblReq3.BackColor = System.Drawing.Color.Transparent;
            this.lblReq3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq3.ForeColor = System.Drawing.Color.Red;
            this.lblReq3.Location = new System.Drawing.Point(513, 85);
            this.lblReq3.Name = "lblReq3";
            this.lblReq3.Size = new System.Drawing.Size(18, 24);
            this.lblReq3.TabIndex = 60;
            this.lblReq3.Text = "*";
            // 
            // lblReq1
            // 
            this.lblReq1.AutoSize = true;
            this.lblReq1.BackColor = System.Drawing.Color.Transparent;
            this.lblReq1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq1.ForeColor = System.Drawing.Color.Red;
            this.lblReq1.Location = new System.Drawing.Point(513, 42);
            this.lblReq1.Name = "lblReq1";
            this.lblReq1.Size = new System.Drawing.Size(18, 24);
            this.lblReq1.TabIndex = 59;
            this.lblReq1.Text = "*";
            // 
            // lblReq2
            // 
            this.lblReq2.AutoSize = true;
            this.lblReq2.BackColor = System.Drawing.Color.Transparent;
            this.lblReq2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq2.ForeColor = System.Drawing.Color.Red;
            this.lblReq2.Location = new System.Drawing.Point(0, 80);
            this.lblReq2.Name = "lblReq2";
            this.lblReq2.Size = new System.Drawing.Size(18, 24);
            this.lblReq2.TabIndex = 58;
            this.lblReq2.Text = "*";
            // 
            // txtAudioName
            // 
            this.txtAudioName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAudioName.Location = new System.Drawing.Point(174, 83);
            this.txtAudioName.Name = "txtAudioName";
            this.txtAudioName.Size = new System.Drawing.Size(230, 26);
            this.txtAudioName.TabIndex = 3;
            this.txtAudioName.TextChanged += new System.EventHandler(this.txtAudioName_TextChanged);
            this.txtAudioName.Leave += new System.EventHandler(this.txtAudioName_Leave);
            // 
            // txtAudioPath
            // 
            this.txtAudioPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAudioPath.Location = new System.Drawing.Point(687, 40);
            this.txtAudioPath.Name = "txtAudioPath";
            this.txtAudioPath.Size = new System.Drawing.Size(230, 26);
            this.txtAudioPath.TabIndex = 2;
            this.txtAudioPath.TextChanged += new System.EventHandler(this.txtAudioPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 136);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Train Status";
            // 
            // lblSequence
            // 
            this.lblSequence.AutoSize = true;
            this.lblSequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSequence.Location = new System.Drawing.Point(533, 89);
            this.lblSequence.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSequence.Name = "lblSequence";
            this.lblSequence.Size = new System.Drawing.Size(90, 20);
            this.lblSequence.TabIndex = 52;
            this.lblSequence.Text = "Sequence";
            // 
            // lblAudioName
            // 
            this.lblAudioName.AutoSize = true;
            this.lblAudioName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudioName.Location = new System.Drawing.Point(20, 89);
            this.lblAudioName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAudioName.Name = "lblAudioName";
            this.lblAudioName.Size = new System.Drawing.Size(106, 20);
            this.lblAudioName.TabIndex = 51;
            this.lblAudioName.Text = "Audio Name";
            // 
            // lblAudioPath
            // 
            this.lblAudioPath.AutoSize = true;
            this.lblAudioPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudioPath.Location = new System.Drawing.Point(533, 46);
            this.lblAudioPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAudioPath.Name = "lblAudioPath";
            this.lblAudioPath.Size = new System.Drawing.Size(97, 20);
            this.lblAudioPath.TabIndex = 50;
            this.lblAudioPath.Text = "Audio Path";
            // 
            // pbCrossAudioName
            // 
            this.pbCrossAudioName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCrossAudioName.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCrossAudioName.ImageLocation = "";
            this.pbCrossAudioName.Location = new System.Drawing.Point(410, 89);
            this.pbCrossAudioName.Name = "pbCrossAudioName";
            this.pbCrossAudioName.Size = new System.Drawing.Size(25, 20);
            this.pbCrossAudioName.TabIndex = 106;
            this.pbCrossAudioName.TabStop = false;
            this.pbCrossAudioName.Visible = false;
            // 
            // pbCrossAudioPath
            // 
            this.pbCrossAudioPath.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCrossAudioPath.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCrossAudioPath.ImageLocation = "";
            this.pbCrossAudioPath.Location = new System.Drawing.Point(937, 46);
            this.pbCrossAudioPath.Name = "pbCrossAudioPath";
            this.pbCrossAudioPath.Size = new System.Drawing.Size(25, 20);
            this.pbCrossAudioPath.TabIndex = 104;
            this.pbCrossAudioPath.TabStop = false;
            this.pbCrossAudioPath.Visible = false;
            // 
            // pbCrossSequence
            // 
            this.pbCrossSequence.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCrossSequence.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCrossSequence.ImageLocation = "";
            this.pbCrossSequence.Location = new System.Drawing.Point(937, 88);
            this.pbCrossSequence.Name = "pbCrossSequence";
            this.pbCrossSequence.Size = new System.Drawing.Size(25, 20);
            this.pbCrossSequence.TabIndex = 101;
            this.pbCrossSequence.TabStop = false;
            this.pbCrossSequence.Visible = false;
            // 
            // pbTickSequence
            // 
            this.pbTickSequence.Location = new System.Drawing.Point(12, 238);
            this.pbTickSequence.Name = "pbTickSequence";
            this.pbTickSequence.Size = new System.Drawing.Size(100, 50);
            this.pbTickSequence.TabIndex = 101;
            this.pbTickSequence.TabStop = false;
            this.pbTickSequence.Visible = false;
            // 
            // pbTickAudioName
            // 
            this.pbTickAudioName.Location = new System.Drawing.Point(12, 301);
            this.pbTickAudioName.Name = "pbTickAudioName";
            this.pbTickAudioName.Size = new System.Drawing.Size(100, 50);
            this.pbTickAudioName.TabIndex = 0;
            this.pbTickAudioName.TabStop = false;
            this.pbTickAudioName.Visible = false;
            // 
            // pbTickAudioPath
            // 
            this.pbTickAudioPath.Location = new System.Drawing.Point(12, 367);
            this.pbTickAudioPath.Name = "pbTickAudioPath";
            this.pbTickAudioPath.Size = new System.Drawing.Size(100, 50);
            this.pbTickAudioPath.TabIndex = 1;
            this.pbTickAudioPath.TabStop = false;
            this.pbTickAudioPath.Visible = false;
            // 
            // btnAddMessage
            // 
            this.btnAddMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddMessage.FlatAppearance.BorderSize = 0;
            this.btnAddMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMessage.ForeColor = System.Drawing.Color.Black;
            this.btnAddMessage.Location = new System.Drawing.Point(155, 72);
            this.btnAddMessage.Name = "btnAddMessage";
            this.btnAddMessage.Size = new System.Drawing.Size(36, 28);
            this.btnAddMessage.TabIndex = 66;
            this.btnAddMessage.Text = "+";
            this.btnAddMessage.UseVisualStyleBackColor = false;
            this.btnAddMessage.Click += new System.EventHandler(this.btnAddMessage_Click);
            // 
            // pnlPagination
            // 
            this.pnlPagination.BackColor = System.Drawing.Color.Transparent;
            this.pnlPagination.Location = new System.Drawing.Point(121, 238);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1139, 51);
            this.pnlPagination.TabIndex = 67;
            this.pnlPagination.Visible = false;
            // 
            // lblNoDataToDisplay
            // 
            this.lblNoDataToDisplay.AutoSize = true;
            this.lblNoDataToDisplay.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNoDataToDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataToDisplay.ForeColor = System.Drawing.Color.Black;
            this.lblNoDataToDisplay.Location = new System.Drawing.Point(503, 115);
            this.lblNoDataToDisplay.Name = "lblNoDataToDisplay";
            this.lblNoDataToDisplay.Size = new System.Drawing.Size(216, 25);
            this.lblNoDataToDisplay.TabIndex = 68;
            this.lblNoDataToDisplay.Text = "No Data To Display";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::ArecaIPIS.Properties.Resources.edit;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmAnnounceMentScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 509);
            this.Controls.Add(this.lblNoDataToDisplay);
            this.Controls.Add(this.pnlPagination);
            this.Controls.Add(this.btnAddMessage);
            this.Controls.Add(this.btnAddAudioScript);
            this.Controls.Add(this.dgvAnnScriptTable);
            this.Controls.Add(this.cmbPlatform);
            this.Controls.Add(this.cmbTrainLanguage);
            this.Controls.Add(this.cbmTrainStatus);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblPlatform);
            this.Controls.Add(this.lblTrainStatus);
            this.Controls.Add(this.lblAnnouncementScript);
            this.Controls.Add(this.pnlAudioScriptCreate);
            this.Controls.Add(this.pbTickSequence);
            this.Controls.Add(this.pbTickAudioName);
            this.Controls.Add(this.pbTickAudioPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAnnounceMentScript";
            this.Text = "frmAnnounceMentScript";
            this.Load += new System.EventHandler(this.frmAnnounceMentScript_Load);
            this.Click += new System.EventHandler(this.frmAnnounceMentScript_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnScriptTable)).EndInit();
            this.pnlAudioScriptCreate.ResumeLayout(false);
            this.pnlAudioScriptCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSequence)).EndInit();
            this.pnlCreateNewAudioScript.ResumeLayout(false);
            this.pnlCreateNewAudioScript.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossAudioName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossAudioPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossSequence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickSequence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickAudioName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickAudioPath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAnnouncementScript;
        private System.Windows.Forms.Label lblTrainStatus;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cbmTrainStatus;
        private System.Windows.Forms.ComboBox cmbTrainLanguage;
        private System.Windows.Forms.ComboBox cmbPlatform;
        private System.Windows.Forms.DataGridView dgvAnnScriptTable;
        private System.Windows.Forms.Button btnAddAudioScript;
        private System.Windows.Forms.Panel pnlAudioScriptCreate;
        private System.Windows.Forms.Label lblNoteDef1;
        private System.Windows.Forms.ComboBox CmbPlatformStatus;
        private System.Windows.Forms.ComboBox cnbTrainStatus;
        private System.Windows.Forms.ComboBox cmbLanguageName;
        private System.Windows.Forms.Label lblPlatformStatus;
        private System.Windows.Forms.Label lblLanguageName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblNoteDef2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReq3;
        private System.Windows.Forms.Label lblReq1;
        private System.Windows.Forms.Label lblReq2;
        private System.Windows.Forms.TextBox txtAudioName;
        private System.Windows.Forms.TextBox txtAudioPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSequence;
        private System.Windows.Forms.Label lblAudioName;
        private System.Windows.Forms.Label lblAudioPath;
        private System.Windows.Forms.Panel pnlCreateNewAudioScript;
        private System.Windows.Forms.Label lblCreateNewAudioScript;
        private System.Windows.Forms.Button btnAddMessage;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.NumericUpDown nudSequence;
        private System.Windows.Forms.Label lblNoDataToDisplay;
        private System.Windows.Forms.Label lblAudioPathValidation;
        private System.Windows.Forms.Label lblSequenceValidation;
        private System.Windows.Forms.Label lblAudioNameValidation;
        private System.Windows.Forms.PictureBox pbCrossSequence;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.PictureBox pbCrossAudioName;
        private System.Windows.Forms.PictureBox pbTickSequence;
        private System.Windows.Forms.PictureBox pbCrossAudioPath;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox pbTickAudioPath;
        private System.Windows.Forms.PictureBox pbTickAudioName;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sequence;
    }
}