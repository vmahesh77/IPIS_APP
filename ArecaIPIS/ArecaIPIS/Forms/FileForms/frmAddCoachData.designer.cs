
namespace ArecaIPIS.Forms
{
    partial class frmAddCoachData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblAddCoachData = new System.Windows.Forms.Label();
            this.dgvCoachData = new System.Windows.Forms.DataGridView();
            this.Column = new System.Windows.Forms.DataGridViewImageColumn();
            this.CoachName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HindiLanguage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bitmap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.pnlCoachData = new System.Windows.Forms.Panel();
            this.lblBitmapName = new System.Windows.Forms.Label();
            this.lblHindiCoach = new System.Windows.Forms.Label();
            this.lblEnglishCoach = new System.Windows.Forms.Label();
            this.btnHKeyboard = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNoteDef2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBitmap = new System.Windows.Forms.TextBox();
            this.lblReq2 = new System.Windows.Forms.Label();
            this.lblBitmap = new System.Windows.Forms.Label();
            this.txtHindi = new System.Windows.Forms.TextBox();
            this.lblReq3 = new System.Windows.Forms.Label();
            this.lblHindi = new System.Windows.Forms.Label();
            this.txtEnglish = new System.Windows.Forms.TextBox();
            this.lblReq1 = new System.Windows.Forms.Label();
            this.lblEnglish = new System.Windows.Forms.Label();
            this.pbCross = new System.Windows.Forms.PictureBox();
            this.pbCrossBitmap = new System.Windows.Forms.PictureBox();
            this.pbCrossHindi = new System.Windows.Forms.PictureBox();
            this.pnlCreateCoach = new System.Windows.Forms.Panel();
            this.lblCreateCoach = new System.Windows.Forms.Label();
            this.btnAddMessage = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblNoDataToDisplay = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.chkFilter = new System.Windows.Forms.CheckedListBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnDropdown = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCross = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoachData)).BeginInit();
            this.pnlCoachData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossBitmap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossHindi)).BeginInit();
            this.pnlCreateCoach.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddCoachData
            // 
            this.lblAddCoachData.AutoSize = true;
            this.lblAddCoachData.BackColor = System.Drawing.SystemColors.Control;
            this.lblAddCoachData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddCoachData.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAddCoachData.Location = new System.Drawing.Point(29, -1);
            this.lblAddCoachData.Name = "lblAddCoachData";
            this.lblAddCoachData.Size = new System.Drawing.Size(183, 25);
            this.lblAddCoachData.TabIndex = 1;
            this.lblAddCoachData.Text = "Add Coach Data";
            // 
            // dgvCoachData
            // 
            this.dgvCoachData.AllowUserToAddRows = false;
            this.dgvCoachData.AllowUserToResizeColumns = false;
            this.dgvCoachData.AllowUserToResizeRows = false;
            this.dgvCoachData.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCoachData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvCoachData.ColumnHeadersHeight = 35;
            this.dgvCoachData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCoachData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column,
            this.CoachName,
            this.HindiLanguage,
            this.Bitmap});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCoachData.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgvCoachData.Location = new System.Drawing.Point(35, 32);
            this.dgvCoachData.Name = "dgvCoachData";
            this.dgvCoachData.ReadOnly = true;
            this.dgvCoachData.RowHeadersVisible = false;
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            this.dgvCoachData.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvCoachData.RowTemplate.Height = 30;
            this.dgvCoachData.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvCoachData.Size = new System.Drawing.Size(1237, 213);
            this.dgvCoachData.TabIndex = 2;
            this.dgvCoachData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCoachData_CellClick);
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
            // CoachName
            // 
            this.CoachName.HeaderText = "Coach Name";
            this.CoachName.Name = "CoachName";
            this.CoachName.ReadOnly = true;
            this.CoachName.Width = 370;
            // 
            // HindiLanguage
            // 
            this.HindiLanguage.HeaderText = "Hindi Language";
            this.HindiLanguage.Name = "HindiLanguage";
            this.HindiLanguage.ReadOnly = true;
            this.HindiLanguage.Width = 370;
            // 
            // Bitmap
            // 
            this.Bitmap.HeaderText = "Bitmap";
            this.Bitmap.Name = "Bitmap";
            this.Bitmap.ReadOnly = true;
            this.Bitmap.Width = 400;
            // 
            // pnlPagination
            // 
            this.pnlPagination.BackColor = System.Drawing.Color.Transparent;
            this.pnlPagination.Location = new System.Drawing.Point(35, 248);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1238, 51);
            this.pnlPagination.TabIndex = 28;
            // 
            // pnlCoachData
            // 
            this.pnlCoachData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCoachData.Controls.Add(this.lblBitmapName);
            this.pnlCoachData.Controls.Add(this.lblHindiCoach);
            this.pnlCoachData.Controls.Add(this.lblEnglishCoach);
            this.pnlCoachData.Controls.Add(this.btnHKeyboard);
            this.pnlCoachData.Controls.Add(this.btnClose);
            this.pnlCoachData.Controls.Add(this.btnSave);
            this.pnlCoachData.Controls.Add(this.label1);
            this.pnlCoachData.Controls.Add(this.lblNoteDef2);
            this.pnlCoachData.Controls.Add(this.label2);
            this.pnlCoachData.Controls.Add(this.txtBitmap);
            this.pnlCoachData.Controls.Add(this.lblReq2);
            this.pnlCoachData.Controls.Add(this.lblBitmap);
            this.pnlCoachData.Controls.Add(this.txtHindi);
            this.pnlCoachData.Controls.Add(this.lblReq3);
            this.pnlCoachData.Controls.Add(this.lblHindi);
            this.pnlCoachData.Controls.Add(this.txtEnglish);
            this.pnlCoachData.Controls.Add(this.lblReq1);
            this.pnlCoachData.Controls.Add(this.lblEnglish);
            this.pnlCoachData.Controls.Add(this.pbCross);
            this.pnlCoachData.Controls.Add(this.pbCrossBitmap);
            this.pnlCoachData.Controls.Add(this.pbCrossHindi);
            this.pnlCoachData.Location = new System.Drawing.Point(35, 304);
            this.pnlCoachData.Name = "pnlCoachData";
            this.pnlCoachData.Size = new System.Drawing.Size(1237, 165);
            this.pnlCoachData.TabIndex = 29;
            this.pnlCoachData.Visible = false;
            // 
            // lblBitmapName
            // 
            this.lblBitmapName.AutoSize = true;
            this.lblBitmapName.ForeColor = System.Drawing.Color.Red;
            this.lblBitmapName.Location = new System.Drawing.Point(177, 124);
            this.lblBitmapName.Name = "lblBitmapName";
            this.lblBitmapName.Size = new System.Drawing.Size(102, 13);
            this.lblBitmapName.TabIndex = 85;
            this.lblBitmapName.Text = "Please Enter Bitmap";
            this.lblBitmapName.Visible = false;
            // 
            // lblHindiCoach
            // 
            this.lblHindiCoach.AutoSize = true;
            this.lblHindiCoach.ForeColor = System.Drawing.Color.Red;
            this.lblHindiCoach.Location = new System.Drawing.Point(639, 82);
            this.lblHindiCoach.Name = "lblHindiCoach";
            this.lblHindiCoach.Size = new System.Drawing.Size(170, 13);
            this.lblHindiCoach.TabIndex = 84;
            this.lblHindiCoach.Text = "Please Enter Coach Name in Hindi";
            this.lblHindiCoach.Visible = false;
            // 
            // lblEnglishCoach
            // 
            this.lblEnglishCoach.AutoSize = true;
            this.lblEnglishCoach.ForeColor = System.Drawing.Color.Red;
            this.lblEnglishCoach.Location = new System.Drawing.Point(180, 82);
            this.lblEnglishCoach.Name = "lblEnglishCoach";
            this.lblEnglishCoach.Size = new System.Drawing.Size(180, 13);
            this.lblEnglishCoach.TabIndex = 83;
            this.lblEnglishCoach.Text = "Please Enter Coach Name in English";
            this.lblEnglishCoach.Visible = false;
            // 
            // btnHKeyboard
            // 
            this.btnHKeyboard.FlatAppearance.BorderSize = 0;
            this.btnHKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHKeyboard.Image = global::ArecaIPIS.Properties.Resources._3671786_keyboard_icon__1_;
            this.btnHKeyboard.Location = new System.Drawing.Point(918, 55);
            this.btnHKeyboard.Name = "btnHKeyboard";
            this.btnHKeyboard.Size = new System.Drawing.Size(23, 19);
            this.btnHKeyboard.TabIndex = 72;
            this.btnHKeyboard.UseVisualStyleBackColor = true;
            this.btnHKeyboard.Click += new System.EventHandler(this.btnHKeyboard_Click);
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
            this.btnClose.Location = new System.Drawing.Point(767, 114);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 32);
            this.btnClose.TabIndex = 57;
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
            this.btnSave.Location = new System.Drawing.Point(668, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 32);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(97, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Asterisk (";
            // 
            // lblNoteDef2
            // 
            this.lblNoteDef2.AutoSize = true;
            this.lblNoteDef2.ForeColor = System.Drawing.Color.Black;
            this.lblNoteDef2.Location = new System.Drawing.Point(158, 138);
            this.lblNoteDef2.Name = "lblNoteDef2";
            this.lblNoteDef2.Size = new System.Drawing.Size(105, 13);
            this.lblNoteDef2.TabIndex = 54;
            this.lblNoteDef2.Text = ") Fields Are Required";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(144, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 24);
            this.label2.TabIndex = 53;
            this.label2.Text = "*";
            // 
            // txtBitmap
            // 
            this.txtBitmap.Location = new System.Drawing.Point(180, 101);
            this.txtBitmap.Name = "txtBitmap";
            this.txtBitmap.Size = new System.Drawing.Size(270, 20);
            this.txtBitmap.TabIndex = 3;
            this.txtBitmap.TextChanged += new System.EventHandler(this.txtBitmap_TextChanged);
            // 
            // lblReq2
            // 
            this.lblReq2.AutoSize = true;
            this.lblReq2.BackColor = System.Drawing.Color.Transparent;
            this.lblReq2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq2.ForeColor = System.Drawing.Color.Red;
            this.lblReq2.Location = new System.Drawing.Point(65, 103);
            this.lblReq2.Name = "lblReq2";
            this.lblReq2.Size = new System.Drawing.Size(18, 24);
            this.lblReq2.TabIndex = 50;
            this.lblReq2.Text = "*";
            // 
            // lblBitmap
            // 
            this.lblBitmap.AutoSize = true;
            this.lblBitmap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBitmap.ForeColor = System.Drawing.Color.Black;
            this.lblBitmap.Location = new System.Drawing.Point(85, 105);
            this.lblBitmap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBitmap.Name = "lblBitmap";
            this.lblBitmap.Size = new System.Drawing.Size(56, 16);
            this.lblBitmap.TabIndex = 49;
            this.lblBitmap.Text = "Bitmap";
            // 
            // txtHindi
            // 
            this.txtHindi.Location = new System.Drawing.Point(642, 56);
            this.txtHindi.Name = "txtHindi";
            this.txtHindi.Size = new System.Drawing.Size(270, 20);
            this.txtHindi.TabIndex = 2;
            this.txtHindi.TextChanged += new System.EventHandler(this.txtHindi_TextChanged);
            // 
            // lblReq3
            // 
            this.lblReq3.AutoSize = true;
            this.lblReq3.BackColor = System.Drawing.Color.Transparent;
            this.lblReq3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq3.ForeColor = System.Drawing.Color.Red;
            this.lblReq3.Location = new System.Drawing.Point(542, 58);
            this.lblReq3.Name = "lblReq3";
            this.lblReq3.Size = new System.Drawing.Size(18, 24);
            this.lblReq3.TabIndex = 47;
            this.lblReq3.Text = "*";
            // 
            // lblHindi
            // 
            this.lblHindi.AutoSize = true;
            this.lblHindi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHindi.ForeColor = System.Drawing.Color.Black;
            this.lblHindi.Location = new System.Drawing.Point(562, 60);
            this.lblHindi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHindi.Name = "lblHindi";
            this.lblHindi.Size = new System.Drawing.Size(44, 16);
            this.lblHindi.TabIndex = 46;
            this.lblHindi.Text = "Hindi";
            // 
            // txtEnglish
            // 
            this.txtEnglish.Location = new System.Drawing.Point(180, 56);
            this.txtEnglish.Name = "txtEnglish";
            this.txtEnglish.Size = new System.Drawing.Size(270, 20);
            this.txtEnglish.TabIndex = 1;
            this.txtEnglish.TextChanged += new System.EventHandler(this.txtEnglish_TextChanged);
            // 
            // lblReq1
            // 
            this.lblReq1.AutoSize = true;
            this.lblReq1.BackColor = System.Drawing.Color.Transparent;
            this.lblReq1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq1.ForeColor = System.Drawing.Color.Red;
            this.lblReq1.Location = new System.Drawing.Point(65, 58);
            this.lblReq1.Name = "lblReq1";
            this.lblReq1.Size = new System.Drawing.Size(18, 24);
            this.lblReq1.TabIndex = 44;
            this.lblReq1.Text = "*";
            // 
            // lblEnglish
            // 
            this.lblEnglish.AutoSize = true;
            this.lblEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnglish.ForeColor = System.Drawing.Color.Black;
            this.lblEnglish.Location = new System.Drawing.Point(85, 60);
            this.lblEnglish.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Size = new System.Drawing.Size(59, 16);
            this.lblEnglish.TabIndex = 43;
            this.lblEnglish.Text = "English";
            // 
            // pbCross
            // 
            this.pbCross.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCross.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCross.ImageLocation = "";
            this.pbCross.Location = new System.Drawing.Point(456, 57);
            this.pbCross.Name = "pbCross";
            this.pbCross.Size = new System.Drawing.Size(25, 20);
            this.pbCross.TabIndex = 77;
            this.pbCross.TabStop = false;
            this.pbCross.Visible = false;
            // 
            // pbCrossBitmap
            // 
            this.pbCrossBitmap.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCrossBitmap.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCrossBitmap.ImageLocation = "";
            this.pbCrossBitmap.Location = new System.Drawing.Point(456, 101);
            this.pbCrossBitmap.Name = "pbCrossBitmap";
            this.pbCrossBitmap.Size = new System.Drawing.Size(25, 20);
            this.pbCrossBitmap.TabIndex = 79;
            this.pbCrossBitmap.TabStop = false;
            this.pbCrossBitmap.Visible = false;
            // 
            // pbCrossHindi
            // 
            this.pbCrossHindi.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCrossHindi.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCrossHindi.ImageLocation = "";
            this.pbCrossHindi.Location = new System.Drawing.Point(947, 55);
            this.pbCrossHindi.Name = "pbCrossHindi";
            this.pbCrossHindi.Size = new System.Drawing.Size(25, 20);
            this.pbCrossHindi.TabIndex = 81;
            this.pbCrossHindi.TabStop = false;
            this.pbCrossHindi.Visible = false;
            // 
            // pnlCreateCoach
            // 
            this.pnlCreateCoach.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlCreateCoach.Controls.Add(this.lblCreateCoach);
            this.pnlCreateCoach.Location = new System.Drawing.Point(35, 305);
            this.pnlCreateCoach.Name = "pnlCreateCoach";
            this.pnlCreateCoach.Size = new System.Drawing.Size(1237, 36);
            this.pnlCreateCoach.TabIndex = 56;
            this.pnlCreateCoach.Visible = false;
            // 
            // lblCreateCoach
            // 
            this.lblCreateCoach.AutoSize = true;
            this.lblCreateCoach.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCoach.ForeColor = System.Drawing.Color.Black;
            this.lblCreateCoach.Location = new System.Drawing.Point(15, 4);
            this.lblCreateCoach.Name = "lblCreateCoach";
            this.lblCreateCoach.Size = new System.Drawing.Size(161, 24);
            this.lblCreateCoach.TabIndex = 0;
            this.lblCreateCoach.Text = "Add Coach Data";
            // 
            // btnAddMessage
            // 
            this.btnAddMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddMessage.FlatAppearance.BorderSize = 0;
            this.btnAddMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMessage.ForeColor = System.Drawing.Color.Black;
            this.btnAddMessage.Location = new System.Drawing.Point(69, 36);
            this.btnAddMessage.Name = "btnAddMessage";
            this.btnAddMessage.Size = new System.Drawing.Size(36, 28);
            this.btnAddMessage.TabIndex = 57;
            this.btnAddMessage.Text = "+";
            this.btnAddMessage.UseVisualStyleBackColor = false;
            this.btnAddMessage.Click += new System.EventHandler(this.btnAddMessage_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(1029, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(140, 20);
            this.txtSearch.TabIndex = 58;
            this.txtSearch.Text = "Search Here";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // lblNoDataToDisplay
            // 
            this.lblNoDataToDisplay.AutoSize = true;
            this.lblNoDataToDisplay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblNoDataToDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataToDisplay.ForeColor = System.Drawing.Color.Black;
            this.lblNoDataToDisplay.Location = new System.Drawing.Point(477, 77);
            this.lblNoDataToDisplay.Name = "lblNoDataToDisplay";
            this.lblNoDataToDisplay.Size = new System.Drawing.Size(216, 25);
            this.lblNoDataToDisplay.TabIndex = 62;
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
            this.chkFilter.Location = new System.Drawing.Point(1157, 34);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(101, 49);
            this.chkFilter.TabIndex = 63;
            this.chkFilter.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::ArecaIPIS.Properties.Resources.edit;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.ToolTipText = "Edit";
            // 
            // btnDropdown
            // 
            this.btnDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDropdown.Image = global::ArecaIPIS.Properties.Resources.descending_down;
            this.btnDropdown.Location = new System.Drawing.Point(1212, -1);
            this.btnDropdown.Name = "btnDropdown";
            this.btnDropdown.Size = new System.Drawing.Size(46, 31);
            this.btnDropdown.TabIndex = 61;
            this.btnDropdown.UseVisualStyleBackColor = false;
            this.btnDropdown.Visible = false;
            this.btnDropdown.Click += new System.EventHandler(this.btnDropdown_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::ArecaIPIS.Properties.Resources._352091_search_icon;
            this.btnSearch.Location = new System.Drawing.Point(1169, -1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 31);
            this.btnSearch.TabIndex = 59;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnCross.Location = new System.Drawing.Point(1169, -1);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(46, 31);
            this.btnCross.TabIndex = 60;
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Visible = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // frmAddCoachData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 509);
            this.Controls.Add(this.chkFilter);
            this.Controls.Add(this.lblNoDataToDisplay);
            this.Controls.Add(this.btnDropdown);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAddMessage);
            this.Controls.Add(this.pnlCreateCoach);
            this.Controls.Add(this.pnlPagination);
            this.Controls.Add(this.dgvCoachData);
            this.Controls.Add(this.lblAddCoachData);
            this.Controls.Add(this.pnlCoachData);
            this.Controls.Add(this.btnCross);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddCoachData";
            this.Text = "frmAddCoachData";
            this.Load += new System.EventHandler(this.frmAddCoachData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoachData)).EndInit();
            this.pnlCoachData.ResumeLayout(false);
            this.pnlCoachData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossBitmap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossHindi)).EndInit();
            this.pnlCreateCoach.ResumeLayout(false);
            this.pnlCreateCoach.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddCoachData;
        private System.Windows.Forms.DataGridView dgvCoachData;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Panel pnlCoachData;
        private System.Windows.Forms.TextBox txtEnglish;
        private System.Windows.Forms.Label lblReq1;
        private System.Windows.Forms.Label lblEnglish;
        private System.Windows.Forms.TextBox txtHindi;
        private System.Windows.Forms.Label lblReq3;
        private System.Windows.Forms.Label lblHindi;
        private System.Windows.Forms.TextBox txtBitmap;
        private System.Windows.Forms.Label lblReq2;
        private System.Windows.Forms.Label lblBitmap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNoteDef2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlCreateCoach;
        private System.Windows.Forms.Label lblCreateCoach;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnHKeyboard;
        private System.Windows.Forms.DataGridViewImageColumn Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoachName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HindiLanguage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bitmap;
        private System.Windows.Forms.Button btnAddMessage;
        private System.Windows.Forms.Button btnDropdown;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pbCrossHindi;
        private System.Windows.Forms.PictureBox pbCrossBitmap;
        private System.Windows.Forms.PictureBox pbCross;
        private System.Windows.Forms.Label lblBitmapName;
        private System.Windows.Forms.Label lblHindiCoach;
        private System.Windows.Forms.Label lblEnglishCoach;
        private System.Windows.Forms.Label lblNoDataToDisplay;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckedListBox chkFilter;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}