
namespace ArecaIPIS.Forms.HomeForms
{
    partial class frmPa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPa));
            this.lblSelectSpecialAnnouncementFile = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lbFileSpecialAnnouncement = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTrainNo = new System.Windows.Forms.Label();
            this.lblCoachId = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPlatformNo = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtTrainNo = new System.Windows.Forms.TextBox();
            this.txtCoachId = new System.Windows.Forms.TextBox();
            this.cmbPlatFormNo = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.nudPlaySpecAnnounce = new System.Windows.Forms.NumericUpDown();
            this.ofdSpecialAnnouncement = new System.Windows.Forms.OpenFileDialog();
            this.lblValidateCoachId = new System.Windows.Forms.Label();
            this.lblValidateTrainNo = new System.Windows.Forms.Label();
            this.pnlSavingFile = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblSpeclMessage = new System.Windows.Forms.Label();
            this.PnlSpcialMessage = new System.Windows.Forms.Panel();
            this.btnDelete = new ArecaIPIS.MyControls.RoundButton();
            this.btnStopRecording = new ArecaIPIS.MyControls.RoundButton();
            this.btnRecord = new ArecaIPIS.MyControls.RoundButton();
            this.btnStop = new ArecaIPIS.MyControls.RoundButton();
            this.btnPlay = new ArecaIPIS.MyControls.RoundButton();
            this.btnPauseMessage = new ArecaIPIS.MyControls.RoundButton();
            this.btnStopMessage = new ArecaIPIS.MyControls.RoundButton();
            this.btnPlayMessage = new ArecaIPIS.MyControls.RoundButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlaySpecAnnounce)).BeginInit();
            this.pnlSavingFile.SuspendLayout();
            this.PnlSpcialMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelectSpecialAnnouncementFile
            // 
            this.lblSelectSpecialAnnouncementFile.AutoSize = true;
            this.lblSelectSpecialAnnouncementFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectSpecialAnnouncementFile.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSelectSpecialAnnouncementFile.Location = new System.Drawing.Point(16, 22);
            this.lblSelectSpecialAnnouncementFile.Name = "lblSelectSpecialAnnouncementFile";
            this.lblSelectSpecialAnnouncementFile.Size = new System.Drawing.Size(413, 29);
            this.lblSelectSpecialAnnouncementFile.TabIndex = 1;
            this.lblSelectSpecialAnnouncementFile.Text = "Select Special Announcement File";
            this.lblSelectSpecialAnnouncementFile.Click += new System.EventHandler(this.lblSelectSpecialAnnouncementFile_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.BackColor = System.Drawing.Color.Teal;
            this.btnChooseFile.FlatAppearance.BorderSize = 0;
            this.btnChooseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFile.ForeColor = System.Drawing.Color.White;
            this.btnChooseFile.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseFile.Image")));
            this.btnChooseFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChooseFile.Location = new System.Drawing.Point(12, 79);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(113, 28);
            this.btnChooseFile.TabIndex = 2;
            this.btnChooseFile.Text = "Choose File";
            this.btnChooseFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChooseFile.UseVisualStyleBackColor = false;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFileName.Location = new System.Drawing.Point(142, 86);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(108, 16);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = "No File Choosen";
            // 
            // lbFileSpecialAnnouncement
            // 
            this.lbFileSpecialAnnouncement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFileSpecialAnnouncement.FormattingEnabled = true;
            this.lbFileSpecialAnnouncement.ItemHeight = 16;
            this.lbFileSpecialAnnouncement.Location = new System.Drawing.Point(12, 113);
            this.lbFileSpecialAnnouncement.Name = "lbFileSpecialAnnouncement";
            this.lbFileSpecialAnnouncement.Size = new System.Drawing.Size(732, 148);
            this.lbFileSpecialAnnouncement.TabIndex = 5;
            this.lbFileSpecialAnnouncement.SelectedIndexChanged += new System.EventHandler(this.lbFileSpecialAnnouncement_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Play Ann :";
            // 
            // lblTrainNo
            // 
            this.lblTrainNo.AutoSize = true;
            this.lblTrainNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTrainNo.Location = new System.Drawing.Point(31, 6);
            this.lblTrainNo.Name = "lblTrainNo";
            this.lblTrainNo.Size = new System.Drawing.Size(68, 20);
            this.lblTrainNo.TabIndex = 13;
            this.lblTrainNo.Text = "Train No";
            // 
            // lblCoachId
            // 
            this.lblCoachId.AutoSize = true;
            this.lblCoachId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoachId.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCoachId.Location = new System.Drawing.Point(606, 6);
            this.lblCoachId.Name = "lblCoachId";
            this.lblCoachId.Size = new System.Drawing.Size(76, 20);
            this.lblCoachId.TabIndex = 14;
            this.lblCoachId.Text = "Coach ID";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStatus.Location = new System.Drawing.Point(432, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 20);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Status";
            // 
            // lblPlatformNo
            // 
            this.lblPlatformNo.AutoSize = true;
            this.lblPlatformNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlatformNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPlatformNo.Location = new System.Drawing.Point(217, 6);
            this.lblPlatformNo.Name = "lblPlatformNo";
            this.lblPlatformNo.Size = new System.Drawing.Size(97, 20);
            this.lblPlatformNo.TabIndex = 16;
            this.lblPlatformNo.Text = "PlatForm No";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPosition.Location = new System.Drawing.Point(800, 6);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(65, 20);
            this.lblPosition.TabIndex = 17;
            this.lblPosition.Text = "Position";
            this.lblPosition.Click += new System.EventHandler(this.lblPosition_Click);
            // 
            // txtTrainNo
            // 
            this.txtTrainNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTrainNo.Location = new System.Drawing.Point(100, 6);
            this.txtTrainNo.Name = "txtTrainNo";
            this.txtTrainNo.Size = new System.Drawing.Size(106, 20);
            this.txtTrainNo.TabIndex = 18;
            this.txtTrainNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTrainNo_KeyPress);
            this.txtTrainNo.Leave += new System.EventHandler(this.txtTrainNo_Leave);
            this.txtTrainNo.Validated += new System.EventHandler(this.txtTrainNo_Validated);
            // 
            // txtCoachId
            // 
            this.txtCoachId.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCoachId.Location = new System.Drawing.Point(688, 6);
            this.txtCoachId.Name = "txtCoachId";
            this.txtCoachId.Size = new System.Drawing.Size(91, 20);
            this.txtCoachId.TabIndex = 19;
            this.txtCoachId.TextChanged += new System.EventHandler(this.txtCoachId_TextChanged);
            this.txtCoachId.Enter += new System.EventHandler(this.txtCoachId_Enter);
            this.txtCoachId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCoachId_KeyPress);
            this.txtCoachId.Validated += new System.EventHandler(this.txtCoachId_Validated);
            // 
            // cmbPlatFormNo
            // 
            this.cmbPlatFormNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbPlatFormNo.FormattingEnabled = true;
            this.cmbPlatFormNo.Location = new System.Drawing.Point(318, 5);
            this.cmbPlatFormNo.Name = "cmbPlatFormNo";
            this.cmbPlatFormNo.Size = new System.Drawing.Size(98, 21);
            this.cmbPlatFormNo.TabIndex = 20;
            // 
            // cmbStatus
            // 
            this.cmbStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(494, 5);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(91, 21);
            this.cmbStatus.TabIndex = 21;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // cmbPosition
            // 
            this.cmbPosition.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Items.AddRange(new object[] {
            "-Select-",
            "Front",
            "Rear"});
            this.cmbPosition.Location = new System.Drawing.Point(868, 5);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(91, 21);
            this.cmbPosition.TabIndex = 22;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Teal;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(652, 79);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 28);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // nudPlaySpecAnnounce
            // 
            this.nudPlaySpecAnnounce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPlaySpecAnnounce.Location = new System.Drawing.Point(99, 288);
            this.nudPlaySpecAnnounce.Name = "nudPlaySpecAnnounce";
            this.nudPlaySpecAnnounce.Size = new System.Drawing.Size(61, 22);
            this.nudPlaySpecAnnounce.TabIndex = 1;
            this.nudPlaySpecAnnounce.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ofdSpecialAnnouncement
            // 
            this.ofdSpecialAnnouncement.FileName = "openFileDialog1";
            // 
            // lblValidateCoachId
            // 
            this.lblValidateCoachId.AutoSize = true;
            this.lblValidateCoachId.ForeColor = System.Drawing.Color.Red;
            this.lblValidateCoachId.Location = new System.Drawing.Point(885, 32);
            this.lblValidateCoachId.Name = "lblValidateCoachId";
            this.lblValidateCoachId.Size = new System.Drawing.Size(78, 13);
            this.lblValidateCoachId.TabIndex = 27;
            this.lblValidateCoachId.Text = "Enter Coach Id";
            this.lblValidateCoachId.Visible = false;
            // 
            // lblValidateTrainNo
            // 
            this.lblValidateTrainNo.AutoSize = true;
            this.lblValidateTrainNo.ForeColor = System.Drawing.Color.Red;
            this.lblValidateTrainNo.Location = new System.Drawing.Point(117, 30);
            this.lblValidateTrainNo.Name = "lblValidateTrainNo";
            this.lblValidateTrainNo.Size = new System.Drawing.Size(76, 13);
            this.lblValidateTrainNo.TabIndex = 28;
            this.lblValidateTrainNo.Text = "Enter Train No";
            this.lblValidateTrainNo.Visible = false;
            // 
            // pnlSavingFile
            // 
            this.pnlSavingFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSavingFile.Controls.Add(this.btnCancel);
            this.pnlSavingFile.Controls.Add(this.btnSave);
            this.pnlSavingFile.Controls.Add(this.txtFileName);
            this.pnlSavingFile.Controls.Add(this.lblFile);
            this.pnlSavingFile.Location = new System.Drawing.Point(775, 113);
            this.pnlSavingFile.Name = "pnlSavingFile";
            this.pnlSavingFile.Size = new System.Drawing.Size(295, 102);
            this.pnlSavingFile.TabIndex = 29;
            this.pnlSavingFile.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Teal;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(196, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Teal;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(196, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(7, 60);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(142, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.Location = new System.Drawing.Point(3, 26);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(123, 20);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "Enter File Name";
            // 
            // lblSpeclMessage
            // 
            this.lblSpeclMessage.AutoSize = true;
            this.lblSpeclMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeclMessage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSpeclMessage.Location = new System.Drawing.Point(7, 353);
            this.lblSpeclMessage.Name = "lblSpeclMessage";
            this.lblSpeclMessage.Size = new System.Drawing.Size(413, 29);
            this.lblSpeclMessage.TabIndex = 12;
            this.lblSpeclMessage.Text = "Special Message Announcements ";
            this.lblSpeclMessage.Click += new System.EventHandler(this.lblSpeclMessage_Click);
            // 
            // PnlSpcialMessage
            // 
            this.PnlSpcialMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlSpcialMessage.Controls.Add(this.btnPauseMessage);
            this.PnlSpcialMessage.Controls.Add(this.btnStopMessage);
            this.PnlSpcialMessage.Controls.Add(this.btnPlayMessage);
            this.PnlSpcialMessage.Controls.Add(this.lblPlatformNo);
            this.PnlSpcialMessage.Controls.Add(this.lblCoachId);
            this.PnlSpcialMessage.Controls.Add(this.lblStatus);
            this.PnlSpcialMessage.Controls.Add(this.lblValidateTrainNo);
            this.PnlSpcialMessage.Controls.Add(this.lblPosition);
            this.PnlSpcialMessage.Controls.Add(this.lblValidateCoachId);
            this.PnlSpcialMessage.Controls.Add(this.txtCoachId);
            this.PnlSpcialMessage.Controls.Add(this.cmbPlatFormNo);
            this.PnlSpcialMessage.Controls.Add(this.txtTrainNo);
            this.PnlSpcialMessage.Controls.Add(this.cmbStatus);
            this.PnlSpcialMessage.Controls.Add(this.lblTrainNo);
            this.PnlSpcialMessage.Controls.Add(this.cmbPosition);
            this.PnlSpcialMessage.Location = new System.Drawing.Point(12, 385);
            this.PnlSpcialMessage.Name = "PnlSpcialMessage";
            this.PnlSpcialMessage.Size = new System.Drawing.Size(984, 107);
            this.PnlSpcialMessage.TabIndex = 30;
            this.PnlSpcialMessage.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlSpcialMessage_Paint);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Teal;
            this.btnDelete.CornerRadius = 20;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(638, 277);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 33);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.BackColor = System.Drawing.Color.Teal;
            this.btnStopRecording.CornerRadius = 20;
            this.btnStopRecording.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopRecording.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopRecording.ForeColor = System.Drawing.Color.White;
            this.btnStopRecording.Location = new System.Drawing.Point(523, 277);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(112, 33);
            this.btnStopRecording.TabIndex = 34;
            this.btnStopRecording.Text = "Stop Record";
            this.btnStopRecording.UseVisualStyleBackColor = false;
            this.btnStopRecording.Click += new System.EventHandler(this.btnStopRecording_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.Color.Teal;
            this.btnRecord.CornerRadius = 20;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecord.ForeColor = System.Drawing.Color.White;
            this.btnRecord.Location = new System.Drawing.Point(408, 277);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(112, 33);
            this.btnRecord.TabIndex = 33;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Teal;
            this.btnStop.CornerRadius = 20;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(293, 277);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 33);
            this.btnStop.TabIndex = 32;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Teal;
            this.btnPlay.CornerRadius = 20;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Location = new System.Drawing.Point(178, 277);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(112, 33);
            this.btnPlay.TabIndex = 31;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPauseMessage
            // 
            this.btnPauseMessage.BackColor = System.Drawing.Color.Teal;
            this.btnPauseMessage.CornerRadius = 20;
            this.btnPauseMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPauseMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPauseMessage.ForeColor = System.Drawing.Color.White;
            this.btnPauseMessage.Location = new System.Drawing.Point(260, 57);
            this.btnPauseMessage.Name = "btnPauseMessage";
            this.btnPauseMessage.Size = new System.Drawing.Size(112, 34);
            this.btnPauseMessage.TabIndex = 36;
            this.btnPauseMessage.Text = "Pause";
            this.btnPauseMessage.UseVisualStyleBackColor = false;
            this.btnPauseMessage.Click += new System.EventHandler(this.btnPauseMessage_Click);
            // 
            // btnStopMessage
            // 
            this.btnStopMessage.BackColor = System.Drawing.Color.Teal;
            this.btnStopMessage.CornerRadius = 20;
            this.btnStopMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopMessage.ForeColor = System.Drawing.Color.White;
            this.btnStopMessage.Location = new System.Drawing.Point(148, 57);
            this.btnStopMessage.Name = "btnStopMessage";
            this.btnStopMessage.Size = new System.Drawing.Size(112, 34);
            this.btnStopMessage.TabIndex = 35;
            this.btnStopMessage.Text = "Stop";
            this.btnStopMessage.UseVisualStyleBackColor = false;
            this.btnStopMessage.Click += new System.EventHandler(this.btnStopMessage_Click);
            // 
            // btnPlayMessage
            // 
            this.btnPlayMessage.BackColor = System.Drawing.Color.Teal;
            this.btnPlayMessage.CornerRadius = 20;
            this.btnPlayMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayMessage.ForeColor = System.Drawing.Color.White;
            this.btnPlayMessage.Location = new System.Drawing.Point(36, 57);
            this.btnPlayMessage.Name = "btnPlayMessage";
            this.btnPlayMessage.Size = new System.Drawing.Size(112, 34);
            this.btnPlayMessage.TabIndex = 34;
            this.btnPlayMessage.Text = "Play";
            this.btnPlayMessage.UseVisualStyleBackColor = false;
            this.btnPlayMessage.Click += new System.EventHandler(this.btnPlayMessage_Click);
            // 
            // frmPa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 509);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnStopRecording);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.PnlSpcialMessage);
            this.Controls.Add(this.pnlSavingFile);
            this.Controls.Add(this.nudPlaySpecAnnounce);
            this.Controls.Add(this.lblSpeclMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbFileSpecialAnnouncement);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.lblSelectSpecialAnnouncementFile);
            this.Name = "frmPa";
            this.Text = "frmPa";
            this.Load += new System.EventHandler(this.frmPa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPlaySpecAnnounce)).EndInit();
            this.pnlSavingFile.ResumeLayout(false);
            this.pnlSavingFile.PerformLayout();
            this.PnlSpcialMessage.ResumeLayout(false);
            this.PnlSpcialMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSelectSpecialAnnouncementFile;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbFileSpecialAnnouncement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTrainNo;
        private System.Windows.Forms.Label lblCoachId;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPlatformNo;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtTrainNo;
        private System.Windows.Forms.TextBox txtCoachId;
        private System.Windows.Forms.ComboBox cmbPlatFormNo;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.NumericUpDown nudPlaySpecAnnounce;
        private System.Windows.Forms.OpenFileDialog ofdSpecialAnnouncement;
        private System.Windows.Forms.Label lblValidateCoachId;
        private System.Windows.Forms.Label lblValidateTrainNo;
        private System.Windows.Forms.Panel pnlSavingFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblSpeclMessage;
        private System.Windows.Forms.Panel PnlSpcialMessage;
        private MyControls.RoundButton btnPauseMessage;
        private MyControls.RoundButton btnStopMessage;
        private MyControls.RoundButton btnPlayMessage;
        private MyControls.RoundButton btnPlay;
        private MyControls.RoundButton btnStop;
        private MyControls.RoundButton btnRecord;
        private MyControls.RoundButton btnStopRecording;
        private MyControls.RoundButton btnDelete;
    }
}