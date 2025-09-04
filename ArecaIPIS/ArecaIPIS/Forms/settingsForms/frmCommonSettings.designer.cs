
namespace ArecaIPIS.Forms.settingsForms
{
    partial class frmCommonSettings
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
            this.grpAnnouncementSettings = new System.Windows.Forms.GroupBox();
            this.dgvLanguageSequence = new System.Windows.Forms.DataGridView();
            this.dgvLanguageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUpColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvDownColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnStopAnn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkActivePASystem = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grbIntensity = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbltoTimeError = new System.Windows.Forms.Label();
            this.lblfromtimeError = new System.Windows.Forms.Label();
            this.txtNightIntensity = new System.Windows.Forms.TextBox();
            this.lblnight = new System.Windows.Forms.Label();
            this.txtDayintensity = new System.Windows.Forms.TextBox();
            this.lblday = new System.Windows.Forms.Label();
            this.chkintensity = new System.Windows.Forms.CheckBox();
            this.trackBarDay = new System.Windows.Forms.TrackBar();
            this.trackBarNight = new System.Windows.Forms.TrackBar();
            this.lblToTime = new System.Windows.Forms.Label();
            this.txtToTIme = new System.Windows.Forms.TextBox();
            this.txtfromTime = new System.Windows.Forms.TextBox();
            this.grbAutomaticRunning = new System.Windows.Forms.GroupBox();
            this.grbTrainSchedule = new System.Windows.Forms.GroupBox();
            this.txtDataSentMins = new System.Windows.Forms.TextBox();
            this.lblerrordatasend = new System.Windows.Forms.Label();
            this.lblDatasent = new System.Windows.Forms.Label();
            this.lblAutoMins = new System.Windows.Forms.Label();
            this.lblTimeinterval = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbAutoDeltionMins = new System.Windows.Forms.ComboBox();
            this.chkAutoDeletion = new System.Windows.Forms.CheckBox();
            this.GrbTimeSchedule = new System.Windows.Forms.GroupBox();
            this.lblErrorTimeSchudeuleToTime = new System.Windows.Forms.Label();
            this.lblErrorTimeSchudeuleFromTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNexthrs = new System.Windows.Forms.Label();
            this.Cmbselectedhrs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkRangeSelect = new System.Windows.Forms.CheckBox();
            this.txtTOTimeSchedule = new System.Windows.Forms.TextBox();
            this.chkTimeSelect = new System.Windows.Forms.CheckBox();
            this.txtfrmtimeSchedule = new System.Windows.Forms.TextBox();
            this.chkAutoMode = new System.Windows.Forms.CheckBox();
            this.chkManualMode = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpAnnouncementSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguageSequence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grbIntensity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNight)).BeginInit();
            this.grbAutomaticRunning.SuspendLayout();
            this.grbTrainSchedule.SuspendLayout();
            this.GrbTimeSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAnnouncementSettings
            // 
            this.grpAnnouncementSettings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.grpAnnouncementSettings.Controls.Add(this.dgvLanguageSequence);
            this.grpAnnouncementSettings.Controls.Add(this.btnStopAnn);
            this.grpAnnouncementSettings.Controls.Add(this.pictureBox1);
            this.grpAnnouncementSettings.Controls.Add(this.chkActivePASystem);
            this.grpAnnouncementSettings.Controls.Add(this.label2);
            this.grpAnnouncementSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.grpAnnouncementSettings.ForeColor = System.Drawing.Color.Brown;
            this.grpAnnouncementSettings.Location = new System.Drawing.Point(12, 17);
            this.grpAnnouncementSettings.Name = "grpAnnouncementSettings";
            this.grpAnnouncementSettings.Size = new System.Drawing.Size(560, 205);
            this.grpAnnouncementSettings.TabIndex = 0;
            this.grpAnnouncementSettings.TabStop = false;
            this.grpAnnouncementSettings.Text = "Announcement Settings";
            // 
            // dgvLanguageSequence
            // 
            this.dgvLanguageSequence.AllowUserToAddRows = false;
            this.dgvLanguageSequence.AllowUserToResizeColumns = false;
            this.dgvLanguageSequence.AllowUserToResizeRows = false;
            this.dgvLanguageSequence.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvLanguageSequence.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLanguageSequence.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvLanguageSequence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLanguageSequence.ColumnHeadersVisible = false;
            this.dgvLanguageSequence.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvLanguageColumn,
            this.dgvUpColumn,
            this.dgvDownColumn});
            this.dgvLanguageSequence.Location = new System.Drawing.Point(323, 49);
            this.dgvLanguageSequence.MultiSelect = false;
            this.dgvLanguageSequence.Name = "dgvLanguageSequence";
            this.dgvLanguageSequence.RowHeadersVisible = false;
            this.dgvLanguageSequence.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLanguageSequence.RowTemplate.Height = 30;
            this.dgvLanguageSequence.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvLanguageSequence.Size = new System.Drawing.Size(231, 121);
            this.dgvLanguageSequence.TabIndex = 9;
            this.dgvLanguageSequence.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLanguageSequence_CellClick);
            // 
            // dgvLanguageColumn
            // 
            this.dgvLanguageColumn.HeaderText = "Language";
            this.dgvLanguageColumn.Name = "dgvLanguageColumn";
            this.dgvLanguageColumn.Width = 130;
            // 
            // dgvUpColumn
            // 
            this.dgvUpColumn.HeaderText = "Up";
            this.dgvUpColumn.Image = global::ArecaIPIS.Properties.Resources._211624_c_up_arrow_icon;
            this.dgvUpColumn.Name = "dgvUpColumn";
            this.dgvUpColumn.Width = 50;
            // 
            // dgvDownColumn
            // 
            this.dgvDownColumn.HeaderText = "Down";
            this.dgvDownColumn.Image = global::ArecaIPIS.Properties.Resources._216440_down_arrow_icon;
            this.dgvDownColumn.Name = "dgvDownColumn";
            this.dgvDownColumn.Width = 50;
            // 
            // btnStopAnn
            // 
            this.btnStopAnn.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnStopAnn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStopAnn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopAnn.ForeColor = System.Drawing.Color.White;
            this.btnStopAnn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopAnn.Location = new System.Drawing.Point(85, 88);
            this.btnStopAnn.Name = "btnStopAnn";
            this.btnStopAnn.Size = new System.Drawing.Size(103, 29);
            this.btnStopAnn.TabIndex = 2;
            this.btnStopAnn.Text = "   STOPANN";
            this.btnStopAnn.UseVisualStyleBackColor = false;
            this.btnStopAnn.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ArecaIPIS.Properties.Resources._8103339_office_megaphone_speaker_loudspeaker_announce_icon;
            this.pictureBox1.Location = new System.Drawing.Point(10, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 21);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // chkActivePASystem
            // 
            this.chkActivePASystem.AutoSize = true;
            this.chkActivePASystem.BackColor = System.Drawing.SystemColors.Control;
            this.chkActivePASystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivePASystem.ForeColor = System.Drawing.Color.Black;
            this.chkActivePASystem.Location = new System.Drawing.Point(50, 47);
            this.chkActivePASystem.Name = "chkActivePASystem";
            this.chkActivePASystem.Size = new System.Drawing.Size(256, 20);
            this.chkActivePASystem.TabIndex = 1;
            this.chkActivePASystem.Text = "Active Platform Announcement System";
            this.chkActivePASystem.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Annc Language Sequence";
            // 
            // grbIntensity
            // 
            this.grbIntensity.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.grbIntensity.Controls.Add(this.label1);
            this.grbIntensity.Controls.Add(this.lbltoTimeError);
            this.grbIntensity.Controls.Add(this.lblfromtimeError);
            this.grbIntensity.Controls.Add(this.txtNightIntensity);
            this.grbIntensity.Controls.Add(this.lblnight);
            this.grbIntensity.Controls.Add(this.txtDayintensity);
            this.grbIntensity.Controls.Add(this.lblday);
            this.grbIntensity.Controls.Add(this.chkintensity);
            this.grbIntensity.Controls.Add(this.trackBarDay);
            this.grbIntensity.Controls.Add(this.trackBarNight);
            this.grbIntensity.Controls.Add(this.lblToTime);
            this.grbIntensity.Controls.Add(this.txtToTIme);
            this.grbIntensity.Controls.Add(this.txtfromTime);
            this.grbIntensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.grbIntensity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.grbIntensity.Location = new System.Drawing.Point(12, 239);
            this.grbIntensity.Name = "grbIntensity";
            this.grbIntensity.Size = new System.Drawing.Size(560, 208);
            this.grbIntensity.TabIndex = 1;
            this.grbIntensity.TabStop = false;
            this.grbIntensity.Text = "Automatic Intensity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(21, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "From Time  :";
            // 
            // lbltoTimeError
            // 
            this.lbltoTimeError.AutoSize = true;
            this.lbltoTimeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltoTimeError.ForeColor = System.Drawing.Color.Red;
            this.lbltoTimeError.Location = new System.Drawing.Point(267, 184);
            this.lbltoTimeError.Name = "lbltoTimeError";
            this.lbltoTimeError.Size = new System.Drawing.Size(34, 15);
            this.lbltoTimeError.TabIndex = 18;
            this.lbltoTimeError.Text = "Error";
            this.lbltoTimeError.Visible = false;
            // 
            // lblfromtimeError
            // 
            this.lblfromtimeError.AutoSize = true;
            this.lblfromtimeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfromtimeError.ForeColor = System.Drawing.Color.Red;
            this.lblfromtimeError.Location = new System.Drawing.Point(32, 184);
            this.lblfromtimeError.Name = "lblfromtimeError";
            this.lblfromtimeError.Size = new System.Drawing.Size(34, 15);
            this.lblfromtimeError.TabIndex = 17;
            this.lblfromtimeError.Text = "Error";
            this.lblfromtimeError.Visible = false;
            // 
            // txtNightIntensity
            // 
            this.txtNightIntensity.Location = new System.Drawing.Point(290, 89);
            this.txtNightIntensity.Name = "txtNightIntensity";
            this.txtNightIntensity.Size = new System.Drawing.Size(79, 26);
            this.txtNightIntensity.TabIndex = 6;
            this.txtNightIntensity.TextChanged += new System.EventHandler(this.txtNightIntensity_TextChanged);
            this.txtNightIntensity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNightIntensity_KeyPress);
            this.txtNightIntensity.Leave += new System.EventHandler(this.txtNightIntensity_Leave);
            // 
            // lblnight
            // 
            this.lblnight.AutoSize = true;
            this.lblnight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnight.Location = new System.Drawing.Point(304, 59);
            this.lblnight.Name = "lblnight";
            this.lblnight.Size = new System.Drawing.Size(39, 16);
            this.lblnight.TabIndex = 16;
            this.lblnight.Text = "Night";
            // 
            // txtDayintensity
            // 
            this.txtDayintensity.Location = new System.Drawing.Point(10, 89);
            this.txtDayintensity.Name = "txtDayintensity";
            this.txtDayintensity.Size = new System.Drawing.Size(79, 26);
            this.txtDayintensity.TabIndex = 4;
            this.txtDayintensity.TextChanged += new System.EventHandler(this.txtDayintensity_TextChanged);
            this.txtDayintensity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDayintensity_KeyPress);
            // 
            // lblday
            // 
            this.lblday.AutoSize = true;
            this.lblday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblday.Location = new System.Drawing.Point(24, 59);
            this.lblday.Name = "lblday";
            this.lblday.Size = new System.Drawing.Size(33, 16);
            this.lblday.TabIndex = 14;
            this.lblday.Text = "Day";
            // 
            // chkintensity
            // 
            this.chkintensity.AutoSize = true;
            this.chkintensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkintensity.ForeColor = System.Drawing.Color.Maroon;
            this.chkintensity.Location = new System.Drawing.Point(147, 25);
            this.chkintensity.Name = "chkintensity";
            this.chkintensity.Size = new System.Drawing.Size(216, 22);
            this.chkintensity.TabIndex = 3;
            this.chkintensity.Text = "Automatic Intensity Checking";
            this.chkintensity.UseVisualStyleBackColor = true;
            this.chkintensity.CheckedChanged += new System.EventHandler(this.chkintensity_CheckedChanged);
            // 
            // trackBarDay
            // 
            this.trackBarDay.BackColor = System.Drawing.Color.PeachPuff;
            this.trackBarDay.Location = new System.Drawing.Point(103, 79);
            this.trackBarDay.Maximum = 100;
            this.trackBarDay.Name = "trackBarDay";
            this.trackBarDay.Size = new System.Drawing.Size(130, 45);
            this.trackBarDay.TabIndex = 4;
            this.trackBarDay.TickFrequency = 10;
            this.trackBarDay.Scroll += new System.EventHandler(this.trackBarDay_Scroll);
            // 
            // trackBarNight
            // 
            this.trackBarNight.BackColor = System.Drawing.Color.PeachPuff;
            this.trackBarNight.Location = new System.Drawing.Point(408, 79);
            this.trackBarNight.Maximum = 100;
            this.trackBarNight.Name = "trackBarNight";
            this.trackBarNight.Size = new System.Drawing.Size(132, 45);
            this.trackBarNight.TabIndex = 7;
            this.trackBarNight.TickFrequency = 10;
            this.trackBarNight.Scroll += new System.EventHandler(this.trackBarNight_Scroll);
            // 
            // lblToTime
            // 
            this.lblToTime.AutoSize = true;
            this.lblToTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblToTime.Location = new System.Drawing.Point(254, 154);
            this.lblToTime.Name = "lblToTime";
            this.lblToTime.Size = new System.Drawing.Size(68, 16);
            this.lblToTime.TabIndex = 7;
            this.lblToTime.Text = "To Time  :";
            // 
            // txtToTIme
            // 
            this.txtToTIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToTIme.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtToTIme.Location = new System.Drawing.Point(342, 146);
            this.txtToTIme.MaxLength = 5;
            this.txtToTIme.Name = "txtToTIme";
            this.txtToTIme.Size = new System.Drawing.Size(85, 26);
            this.txtToTIme.TabIndex = 9;
            this.txtToTIme.Text = "00:00";
            this.txtToTIme.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtToTIme.TextChanged += new System.EventHandler(this.txtToTIme_TextChanged);
            this.txtToTIme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToTIme_KeyPress);
            this.txtToTIme.Validating += new System.ComponentModel.CancelEventHandler(this.txtToTIme_Validating);
            // 
            // txtfromTime
            // 
            this.txtfromTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfromTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtfromTime.Location = new System.Drawing.Point(120, 148);
            this.txtfromTime.MaxLength = 5;
            this.txtfromTime.Name = "txtfromTime";
            this.txtfromTime.Size = new System.Drawing.Size(85, 26);
            this.txtfromTime.TabIndex = 8;
            this.txtfromTime.Text = "00:00";
            this.txtfromTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfromTime.TextChanged += new System.EventHandler(this.txtfromTime_TextChanged);
            this.txtfromTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfromTime_KeyPress);
            this.txtfromTime.Leave += new System.EventHandler(this.txtfromTime_Leave);
            this.txtfromTime.Validating += new System.ComponentModel.CancelEventHandler(this.txtfromTime_Validating);
            // 
            // grbAutomaticRunning
            // 
            this.grbAutomaticRunning.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.grbAutomaticRunning.Controls.Add(this.grbTrainSchedule);
            this.grbAutomaticRunning.Controls.Add(this.GrbTimeSchedule);
            this.grbAutomaticRunning.Controls.Add(this.chkAutoMode);
            this.grbAutomaticRunning.Controls.Add(this.chkManualMode);
            this.grbAutomaticRunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbAutomaticRunning.ForeColor = System.Drawing.Color.Maroon;
            this.grbAutomaticRunning.Location = new System.Drawing.Point(591, 17);
            this.grbAutomaticRunning.Name = "grbAutomaticRunning";
            this.grbAutomaticRunning.Size = new System.Drawing.Size(641, 296);
            this.grbAutomaticRunning.TabIndex = 3;
            this.grbAutomaticRunning.TabStop = false;
            this.grbAutomaticRunning.Text = "Automatic Running";
            this.grbAutomaticRunning.Enter += new System.EventHandler(this.grbAutomaticRunning_Enter);
            // 
            // grbTrainSchedule
            // 
            this.grbTrainSchedule.Controls.Add(this.txtDataSentMins);
            this.grbTrainSchedule.Controls.Add(this.lblerrordatasend);
            this.grbTrainSchedule.Controls.Add(this.lblDatasent);
            this.grbTrainSchedule.Controls.Add(this.lblAutoMins);
            this.grbTrainSchedule.Controls.Add(this.lblTimeinterval);
            this.grbTrainSchedule.Controls.Add(this.label5);
            this.grbTrainSchedule.Controls.Add(this.CmbAutoDeltionMins);
            this.grbTrainSchedule.Controls.Add(this.chkAutoDeletion);
            this.grbTrainSchedule.Enabled = false;
            this.grbTrainSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grbTrainSchedule.Location = new System.Drawing.Point(8, 110);
            this.grbTrainSchedule.Name = "grbTrainSchedule";
            this.grbTrainSchedule.Size = new System.Drawing.Size(270, 169);
            this.grbTrainSchedule.TabIndex = 4;
            this.grbTrainSchedule.TabStop = false;
            this.grbTrainSchedule.Text = "Train Schedule";
            this.grbTrainSchedule.Enter += new System.EventHandler(this.grbTrainSchedule_Enter);
            // 
            // txtDataSentMins
            // 
            this.txtDataSentMins.Location = new System.Drawing.Point(167, 26);
            this.txtDataSentMins.MaxLength = 2;
            this.txtDataSentMins.Name = "txtDataSentMins";
            this.txtDataSentMins.Size = new System.Drawing.Size(46, 26);
            this.txtDataSentMins.TabIndex = 17;
            this.txtDataSentMins.Text = "2";
            // 
            // lblerrordatasend
            // 
            this.lblerrordatasend.AutoSize = true;
            this.lblerrordatasend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblerrordatasend.Location = new System.Drawing.Point(22, 63);
            this.lblerrordatasend.Name = "lblerrordatasend";
            this.lblerrordatasend.Size = new System.Drawing.Size(196, 15);
            this.lblerrordatasend.TabIndex = 36;
            this.lblerrordatasend.Text = "Please Enter a Data Sending Time";
            this.lblerrordatasend.Visible = false;
            // 
            // lblDatasent
            // 
            this.lblDatasent.AutoSize = true;
            this.lblDatasent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatasent.ForeColor = System.Drawing.Color.Black;
            this.lblDatasent.Location = new System.Drawing.Point(0, 32);
            this.lblDatasent.Name = "lblDatasent";
            this.lblDatasent.Size = new System.Drawing.Size(159, 20);
            this.lblDatasent.TabIndex = 35;
            this.lblDatasent.Text = "Data Sent To Boards";
            this.lblDatasent.Visible = false;
            // 
            // lblAutoMins
            // 
            this.lblAutoMins.AutoSize = true;
            this.lblAutoMins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoMins.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAutoMins.Location = new System.Drawing.Point(220, 32);
            this.lblAutoMins.Name = "lblAutoMins";
            this.lblAutoMins.Size = new System.Drawing.Size(42, 20);
            this.lblAutoMins.TabIndex = 34;
            this.lblAutoMins.Text = "Mins";
            this.lblAutoMins.Visible = false;
            // 
            // lblTimeinterval
            // 
            this.lblTimeinterval.AutoSize = true;
            this.lblTimeinterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeinterval.ForeColor = System.Drawing.Color.Black;
            this.lblTimeinterval.Location = new System.Drawing.Point(8, 136);
            this.lblTimeinterval.Name = "lblTimeinterval";
            this.lblTimeinterval.Size = new System.Drawing.Size(82, 16);
            this.lblTimeinterval.TabIndex = 26;
            this.lblTimeinterval.Text = "TimeInterval";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(197, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Mins";
            // 
            // CmbAutoDeltionMins
            // 
            this.CmbAutoDeltionMins.Enabled = false;
            this.CmbAutoDeltionMins.FormattingEnabled = true;
            this.CmbAutoDeltionMins.Items.AddRange(new object[] {
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
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90"});
            this.CmbAutoDeltionMins.Location = new System.Drawing.Point(105, 129);
            this.CmbAutoDeltionMins.MaxLength = 2;
            this.CmbAutoDeltionMins.Name = "CmbAutoDeltionMins";
            this.CmbAutoDeltionMins.Size = new System.Drawing.Size(87, 28);
            this.CmbAutoDeltionMins.TabIndex = 20;
            this.CmbAutoDeltionMins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbAutoDeltionMins_KeyPress);
            // 
            // chkAutoDeletion
            // 
            this.chkAutoDeletion.AutoSize = true;
            this.chkAutoDeletion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoDeletion.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkAutoDeletion.Location = new System.Drawing.Point(23, 94);
            this.chkAutoDeletion.Name = "chkAutoDeletion";
            this.chkAutoDeletion.Size = new System.Drawing.Size(125, 24);
            this.chkAutoDeletion.TabIndex = 18;
            this.chkAutoDeletion.Text = "Auto Deletion";
            this.chkAutoDeletion.UseVisualStyleBackColor = true;
            this.chkAutoDeletion.CheckedChanged += new System.EventHandler(this.chkAutoDeletion_CheckedChanged);
            // 
            // GrbTimeSchedule
            // 
            this.GrbTimeSchedule.Controls.Add(this.lblErrorTimeSchudeuleToTime);
            this.GrbTimeSchedule.Controls.Add(this.lblErrorTimeSchudeuleFromTime);
            this.GrbTimeSchedule.Controls.Add(this.label6);
            this.GrbTimeSchedule.Controls.Add(this.lblNexthrs);
            this.GrbTimeSchedule.Controls.Add(this.Cmbselectedhrs);
            this.GrbTimeSchedule.Controls.Add(this.label3);
            this.GrbTimeSchedule.Controls.Add(this.label4);
            this.GrbTimeSchedule.Controls.Add(this.chkRangeSelect);
            this.GrbTimeSchedule.Controls.Add(this.txtTOTimeSchedule);
            this.GrbTimeSchedule.Controls.Add(this.chkTimeSelect);
            this.GrbTimeSchedule.Controls.Add(this.txtfrmtimeSchedule);
            this.GrbTimeSchedule.Enabled = false;
            this.GrbTimeSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GrbTimeSchedule.Location = new System.Drawing.Point(284, 28);
            this.GrbTimeSchedule.Name = "GrbTimeSchedule";
            this.GrbTimeSchedule.Size = new System.Drawing.Size(354, 251);
            this.GrbTimeSchedule.TabIndex = 3;
            this.GrbTimeSchedule.TabStop = false;
            this.GrbTimeSchedule.Text = "TimeSchedule";
            // 
            // lblErrorTimeSchudeuleToTime
            // 
            this.lblErrorTimeSchudeuleToTime.AutoSize = true;
            this.lblErrorTimeSchudeuleToTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorTimeSchudeuleToTime.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTimeSchudeuleToTime.Location = new System.Drawing.Point(212, 95);
            this.lblErrorTimeSchudeuleToTime.Name = "lblErrorTimeSchudeuleToTime";
            this.lblErrorTimeSchudeuleToTime.Size = new System.Drawing.Size(34, 15);
            this.lblErrorTimeSchudeuleToTime.TabIndex = 31;
            this.lblErrorTimeSchudeuleToTime.Text = "Error";
            this.lblErrorTimeSchudeuleToTime.Visible = false;
            // 
            // lblErrorTimeSchudeuleFromTime
            // 
            this.lblErrorTimeSchudeuleFromTime.AutoSize = true;
            this.lblErrorTimeSchudeuleFromTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorTimeSchudeuleFromTime.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTimeSchudeuleFromTime.Location = new System.Drawing.Point(35, 95);
            this.lblErrorTimeSchudeuleFromTime.Name = "lblErrorTimeSchudeuleFromTime";
            this.lblErrorTimeSchudeuleFromTime.Size = new System.Drawing.Size(34, 15);
            this.lblErrorTimeSchudeuleFromTime.TabIndex = 30;
            this.lblErrorTimeSchudeuleFromTime.Text = "Error";
            this.lblErrorTimeSchudeuleFromTime.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(86, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Next Selected";
            // 
            // lblNexthrs
            // 
            this.lblNexthrs.AutoSize = true;
            this.lblNexthrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNexthrs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblNexthrs.Location = new System.Drawing.Point(310, 165);
            this.lblNexthrs.Name = "lblNexthrs";
            this.lblNexthrs.Size = new System.Drawing.Size(31, 20);
            this.lblNexthrs.TabIndex = 28;
            this.lblNexthrs.Text = "hrs";
            // 
            // Cmbselectedhrs
            // 
            this.Cmbselectedhrs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmbselectedhrs.Enabled = false;
            this.Cmbselectedhrs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Cmbselectedhrs.FormattingEnabled = true;
            this.Cmbselectedhrs.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.Cmbselectedhrs.Location = new System.Drawing.Point(215, 157);
            this.Cmbselectedhrs.MaxLength = 2;
            this.Cmbselectedhrs.Name = "Cmbselectedhrs";
            this.Cmbselectedhrs.Size = new System.Drawing.Size(87, 28);
            this.Cmbselectedhrs.TabIndex = 16;
            this.Cmbselectedhrs.SelectedIndexChanged += new System.EventHandler(this.Cmbselectedhrs_SelectedIndexChanged);
            this.Cmbselectedhrs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbAutominutes_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(19, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "From Time  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(184, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "To Time  :";
            // 
            // chkRangeSelect
            // 
            this.chkRangeSelect.AutoSize = true;
            this.chkRangeSelect.Checked = true;
            this.chkRangeSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRangeSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chkRangeSelect.Location = new System.Drawing.Point(43, 118);
            this.chkRangeSelect.Name = "chkRangeSelect";
            this.chkRangeSelect.Size = new System.Drawing.Size(137, 24);
            this.chkRangeSelect.TabIndex = 15;
            this.chkRangeSelect.Text = "Select Range";
            this.chkRangeSelect.UseVisualStyleBackColor = true;
            this.chkRangeSelect.CheckedChanged += new System.EventHandler(this.chkRangeSelect_CheckedChanged);
            // 
            // txtTOTimeSchedule
            // 
            this.txtTOTimeSchedule.Enabled = false;
            this.txtTOTimeSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTOTimeSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtTOTimeSchedule.Location = new System.Drawing.Point(258, 61);
            this.txtTOTimeSchedule.MaxLength = 5;
            this.txtTOTimeSchedule.Name = "txtTOTimeSchedule";
            this.txtTOTimeSchedule.Size = new System.Drawing.Size(85, 26);
            this.txtTOTimeSchedule.TabIndex = 14;
            this.txtTOTimeSchedule.Text = "00:00";
            this.txtTOTimeSchedule.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTOTimeSchedule.TextChanged += new System.EventHandler(this.txtTOTimeSchedule_TextChanged);
            this.txtTOTimeSchedule.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTOTimeSchedule_KeyPress);
            this.txtTOTimeSchedule.Leave += new System.EventHandler(this.txtTOTimeSchedule_Leave);
            this.txtTOTimeSchedule.Validating += new System.ComponentModel.CancelEventHandler(this.txtTOTimeSchedule_Validating);
            // 
            // chkTimeSelect
            // 
            this.chkTimeSelect.AutoSize = true;
            this.chkTimeSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chkTimeSelect.Location = new System.Drawing.Point(43, 30);
            this.chkTimeSelect.Name = "chkTimeSelect";
            this.chkTimeSelect.Size = new System.Drawing.Size(122, 24);
            this.chkTimeSelect.TabIndex = 12;
            this.chkTimeSelect.Text = "Select Time";
            this.chkTimeSelect.UseVisualStyleBackColor = true;
            this.chkTimeSelect.CheckedChanged += new System.EventHandler(this.chkTimeSelect_CheckedChanged);
            // 
            // txtfrmtimeSchedule
            // 
            this.txtfrmtimeSchedule.Enabled = false;
            this.txtfrmtimeSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfrmtimeSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtfrmtimeSchedule.Location = new System.Drawing.Point(107, 63);
            this.txtfrmtimeSchedule.MaxLength = 5;
            this.txtfrmtimeSchedule.Name = "txtfrmtimeSchedule";
            this.txtfrmtimeSchedule.Size = new System.Drawing.Size(64, 26);
            this.txtfrmtimeSchedule.TabIndex = 13;
            this.txtfrmtimeSchedule.Text = "00:00";
            this.txtfrmtimeSchedule.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfrmtimeSchedule.TextChanged += new System.EventHandler(this.txtfrmtimeSchedule_TextChanged);
            this.txtfrmtimeSchedule.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfrmtimeSchedule_KeyPress);
            this.txtfrmtimeSchedule.Leave += new System.EventHandler(this.txtfrmtimeSchedule_Leave);
            this.txtfrmtimeSchedule.Validating += new System.ComponentModel.CancelEventHandler(this.txtfrmtimeSchedule_Validating);
            // 
            // chkAutoMode
            // 
            this.chkAutoMode.AutoSize = true;
            this.chkAutoMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoMode.ForeColor = System.Drawing.Color.Olive;
            this.chkAutoMode.Location = new System.Drawing.Point(34, 76);
            this.chkAutoMode.Name = "chkAutoMode";
            this.chkAutoMode.Size = new System.Drawing.Size(106, 24);
            this.chkAutoMode.TabIndex = 11;
            this.chkAutoMode.Text = "Auto Mode";
            this.chkAutoMode.UseVisualStyleBackColor = true;
            this.chkAutoMode.CheckedChanged += new System.EventHandler(this.chkAutoMode_CheckedChanged);
            // 
            // chkManualMode
            // 
            this.chkManualMode.AutoSize = true;
            this.chkManualMode.Checked = true;
            this.chkManualMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManualMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManualMode.ForeColor = System.Drawing.Color.Olive;
            this.chkManualMode.Location = new System.Drawing.Point(34, 41);
            this.chkManualMode.Name = "chkManualMode";
            this.chkManualMode.Size = new System.Drawing.Size(124, 24);
            this.chkManualMode.TabIndex = 10;
            this.chkManualMode.Text = "Manual Mode";
            this.chkManualMode.UseVisualStyleBackColor = true;
            this.chkManualMode.CheckedChanged += new System.EventHandler(this.chkManualMode_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(644, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 45);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmCommonSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1342, 509);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grbAutomaticRunning);
            this.Controls.Add(this.grbIntensity);
            this.Controls.Add(this.grpAnnouncementSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCommonSettings";
            this.Text = "frmCommonSettings";
            this.Load += new System.EventHandler(this.frmCommonSettings_Load);
            this.grpAnnouncementSettings.ResumeLayout(false);
            this.grpAnnouncementSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguageSequence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grbIntensity.ResumeLayout(false);
            this.grbIntensity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNight)).EndInit();
            this.grbAutomaticRunning.ResumeLayout(false);
            this.grbAutomaticRunning.PerformLayout();
            this.grbTrainSchedule.ResumeLayout(false);
            this.grbTrainSchedule.PerformLayout();
            this.GrbTimeSchedule.ResumeLayout(false);
            this.GrbTimeSchedule.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAnnouncementSettings;
        private System.Windows.Forms.GroupBox grbIntensity;
        private System.Windows.Forms.GroupBox grbAutomaticRunning;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblToTime;
        private System.Windows.Forms.TextBox txtToTIme;
        private System.Windows.Forms.TextBox txtfromTime;
        private System.Windows.Forms.TextBox txtNightIntensity;
        private System.Windows.Forms.Label lblnight;
        private System.Windows.Forms.TextBox txtDayintensity;
        private System.Windows.Forms.Label lblday;
        private System.Windows.Forms.CheckBox chkintensity;
        private System.Windows.Forms.TrackBar trackBarDay;
        private System.Windows.Forms.TrackBar trackBarNight;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbltoTimeError;
        private System.Windows.Forms.Label lblfromtimeError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStopAnn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkActivePASystem;
        private System.Windows.Forms.CheckBox chkAutoMode;
        private System.Windows.Forms.CheckBox chkManualMode;
        private System.Windows.Forms.GroupBox GrbTimeSchedule;
        private System.Windows.Forms.ComboBox Cmbselectedhrs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRangeSelect;
        private System.Windows.Forms.TextBox txtTOTimeSchedule;
        private System.Windows.Forms.CheckBox chkTimeSelect;
        private System.Windows.Forms.TextBox txtfrmtimeSchedule;
        private System.Windows.Forms.GroupBox grbTrainSchedule;
        private System.Windows.Forms.Label lblTimeinterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbAutoDeltionMins;
        private System.Windows.Forms.CheckBox chkAutoDeletion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNexthrs;
        private System.Windows.Forms.Label lblErrorTimeSchudeuleToTime;
        private System.Windows.Forms.Label lblErrorTimeSchudeuleFromTime;
        private System.Windows.Forms.TextBox txtDataSentMins;
        private System.Windows.Forms.Label lblerrordatasend;
        private System.Windows.Forms.Label lblDatasent;
        private System.Windows.Forms.Label lblAutoMins;
        private System.Windows.Forms.DataGridView dgvLanguageSequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLanguageColumn;
        private System.Windows.Forms.DataGridViewImageColumn dgvUpColumn;
        private System.Windows.Forms.DataGridViewImageColumn dgvDownColumn;
    }
}