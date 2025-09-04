
namespace ArecaIPIS.Forms.HomeForms
{
    partial class frmAdditionalSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblAdditionalSettings = new System.Windows.Forms.Label();
            this.lblGapCode = new System.Windows.Forms.Label();
            this.lblPlatforms = new System.Windows.Forms.Label();
            this.lblCgdbSize = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grbCoachClass = new System.Windows.Forms.GroupBox();
            this.dgvCoachClasses = new System.Windows.Forms.DataGridView();
            this.rndBtnCoachClass = new ArecaIPIS.MyControls.RoundButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlEdit = new System.Windows.Forms.Panel();
            this.rndClose = new ArecaIPIS.MyControls.RoundButton();
            this.rctAudioPath = new System.Windows.Forms.RichTextBox();
            this.rctCoachCode = new System.Windows.Forms.RichTextBox();
            this.rctAudioName = new System.Windows.Forms.RichTextBox();
            this.rctClassName = new System.Windows.Forms.RichTextBox();
            this.lblAudioPath = new System.Windows.Forms.Label();
            this.rndDeleteClass = new ArecaIPIS.MyControls.RoundButton();
            this.rndSaveClass = new ArecaIPIS.MyControls.RoundButton();
            this.lblCoachCode = new System.Windows.Forms.Label();
            this.lblAudioName = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.Label();
            this.dgvSnoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCoachCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.grbCoachClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoachClasses)).BeginInit();
            this.pnlEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAdditionalSettings
            // 
            this.lblAdditionalSettings.AutoSize = true;
            this.lblAdditionalSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdditionalSettings.Location = new System.Drawing.Point(297, 9);
            this.lblAdditionalSettings.Name = "lblAdditionalSettings";
            this.lblAdditionalSettings.Size = new System.Drawing.Size(183, 24);
            this.lblAdditionalSettings.TabIndex = 0;
            this.lblAdditionalSettings.Text = "Additional Settings";
            // 
            // lblGapCode
            // 
            this.lblGapCode.AutoSize = true;
            this.lblGapCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGapCode.Location = new System.Drawing.Point(467, 57);
            this.lblGapCode.Name = "lblGapCode";
            this.lblGapCode.Size = new System.Drawing.Size(211, 18);
            this.lblGapCode.TabIndex = 1;
            this.lblGapCode.Text = "Regional Language Lettter Gap";
            // 
            // lblPlatforms
            // 
            this.lblPlatforms.AutoSize = true;
            this.lblPlatforms.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlatforms.Location = new System.Drawing.Point(467, 139);
            this.lblPlatforms.Name = "lblPlatforms";
            this.lblPlatforms.Size = new System.Drawing.Size(72, 18);
            this.lblPlatforms.TabIndex = 2;
            this.lblPlatforms.Text = "GapCode";
            // 
            // lblCgdbSize
            // 
            this.lblCgdbSize.AutoSize = true;
            this.lblCgdbSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCgdbSize.Location = new System.Drawing.Point(467, 98);
            this.lblCgdbSize.Name = "lblCgdbSize";
            this.lblCgdbSize.Size = new System.Drawing.Size(115, 18);
            this.lblCgdbSize.TabIndex = 3;
            this.lblCgdbSize.Text = "Cgdb Gap Code";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(684, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // grbCoachClass
            // 
            this.grbCoachClass.Controls.Add(this.dgvCoachClasses);
            this.grbCoachClass.Controls.Add(this.rndBtnCoachClass);
            this.grbCoachClass.Location = new System.Drawing.Point(12, 38);
            this.grbCoachClass.Name = "grbCoachClass";
            this.grbCoachClass.Size = new System.Drawing.Size(391, 368);
            this.grbCoachClass.TabIndex = 5;
            this.grbCoachClass.TabStop = false;
            this.grbCoachClass.Text = "Coach Class";
            // 
            // dgvCoachClasses
            // 
            this.dgvCoachClasses.AllowDrop = true;
            this.dgvCoachClasses.AllowUserToAddRows = false;
            this.dgvCoachClasses.AllowUserToDeleteRows = false;
            this.dgvCoachClasses.AllowUserToResizeColumns = false;
            this.dgvCoachClasses.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            this.dgvCoachClasses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCoachClasses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(139)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCoachClasses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCoachClasses.ColumnHeadersHeight = 40;
            this.dgvCoachClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCoachClasses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSnoColumn,
            this.dgvClassName,
            this.dgvCoachCode,
            this.dgvEdit});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCoachClasses.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCoachClasses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCoachClasses.EnableHeadersVisualStyles = false;
            this.dgvCoachClasses.GridColor = System.Drawing.Color.Aqua;
            this.dgvCoachClasses.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvCoachClasses.Location = new System.Drawing.Point(16, 60);
            this.dgvCoachClasses.MultiSelect = false;
            this.dgvCoachClasses.Name = "dgvCoachClasses";
            this.dgvCoachClasses.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCoachClasses.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCoachClasses.RowHeadersVisible = false;
            this.dgvCoachClasses.RowHeadersWidth = 30;
            this.dgvCoachClasses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCoachClasses.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCoachClasses.RowTemplate.Height = 40;
            this.dgvCoachClasses.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCoachClasses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCoachClasses.Size = new System.Drawing.Size(353, 251);
            this.dgvCoachClasses.TabIndex = 7;
            this.dgvCoachClasses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCoachClasses_CellClick);
            // 
            // rndBtnCoachClass
            // 
            this.rndBtnCoachClass.BackColor = System.Drawing.Color.DodgerBlue;
            this.rndBtnCoachClass.CornerRadius = 20;
            this.rndBtnCoachClass.FlatAppearance.BorderSize = 0;
            this.rndBtnCoachClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rndBtnCoachClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rndBtnCoachClass.ForeColor = System.Drawing.Color.White;
            this.rndBtnCoachClass.Location = new System.Drawing.Point(78, 19);
            this.rndBtnCoachClass.Name = "rndBtnCoachClass";
            this.rndBtnCoachClass.Size = new System.Drawing.Size(89, 28);
            this.rndBtnCoachClass.TabIndex = 1;
            this.rndBtnCoachClass.Text = "Add New";
            this.rndBtnCoachClass.UseVisualStyleBackColor = false;
            this.rndBtnCoachClass.Click += new System.EventHandler(this.rndBtnCoachClass_Click);
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.rndClose);
            this.pnlEdit.Controls.Add(this.rctAudioPath);
            this.pnlEdit.Controls.Add(this.rctCoachCode);
            this.pnlEdit.Controls.Add(this.rctAudioName);
            this.pnlEdit.Controls.Add(this.rctClassName);
            this.pnlEdit.Controls.Add(this.lblAudioPath);
            this.pnlEdit.Controls.Add(this.rndDeleteClass);
            this.pnlEdit.Controls.Add(this.rndSaveClass);
            this.pnlEdit.Controls.Add(this.lblCoachCode);
            this.pnlEdit.Controls.Add(this.lblAudioName);
            this.pnlEdit.Controls.Add(this.lblClassName);
            this.pnlEdit.Location = new System.Drawing.Point(409, 192);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(349, 214);
            this.pnlEdit.TabIndex = 6;
            this.pnlEdit.Visible = false;
            // 
            // rndClose
            // 
            this.rndClose.BackColor = System.Drawing.Color.DodgerBlue;
            this.rndClose.CornerRadius = 20;
            this.rndClose.FlatAppearance.BorderSize = 0;
            this.rndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rndClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rndClose.ForeColor = System.Drawing.Color.White;
            this.rndClose.Location = new System.Drawing.Point(253, 174);
            this.rndClose.Name = "rndClose";
            this.rndClose.Size = new System.Drawing.Size(89, 28);
            this.rndClose.TabIndex = 10;
            this.rndClose.Text = "Close";
            this.rndClose.UseVisualStyleBackColor = false;
            this.rndClose.Click += new System.EventHandler(this.rndClose_Click);
            // 
            // rctAudioPath
            // 
            this.rctAudioPath.Location = new System.Drawing.Point(125, 129);
            this.rctAudioPath.Name = "rctAudioPath";
            this.rctAudioPath.Size = new System.Drawing.Size(196, 28);
            this.rctAudioPath.TabIndex = 9;
            this.rctAudioPath.Text = "";
            // 
            // rctCoachCode
            // 
            this.rctCoachCode.Location = new System.Drawing.Point(125, 96);
            this.rctCoachCode.Name = "rctCoachCode";
            this.rctCoachCode.Size = new System.Drawing.Size(196, 28);
            this.rctCoachCode.TabIndex = 8;
            this.rctCoachCode.Text = "";
            // 
            // rctAudioName
            // 
            this.rctAudioName.Location = new System.Drawing.Point(125, 61);
            this.rctAudioName.Name = "rctAudioName";
            this.rctAudioName.Size = new System.Drawing.Size(196, 28);
            this.rctAudioName.TabIndex = 7;
            this.rctAudioName.Text = "";
            // 
            // rctClassName
            // 
            this.rctClassName.Location = new System.Drawing.Point(125, 24);
            this.rctClassName.Name = "rctClassName";
            this.rctClassName.Size = new System.Drawing.Size(196, 28);
            this.rctClassName.TabIndex = 6;
            this.rctClassName.Text = "";
            // 
            // lblAudioPath
            // 
            this.lblAudioPath.AutoSize = true;
            this.lblAudioPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudioPath.Location = new System.Drawing.Point(16, 141);
            this.lblAudioPath.Name = "lblAudioPath";
            this.lblAudioPath.Size = new System.Drawing.Size(89, 18);
            this.lblAudioPath.TabIndex = 5;
            this.lblAudioPath.Text = "Audio Path";
            // 
            // rndDeleteClass
            // 
            this.rndDeleteClass.BackColor = System.Drawing.Color.DodgerBlue;
            this.rndDeleteClass.CornerRadius = 20;
            this.rndDeleteClass.FlatAppearance.BorderSize = 0;
            this.rndDeleteClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rndDeleteClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rndDeleteClass.ForeColor = System.Drawing.Color.White;
            this.rndDeleteClass.Location = new System.Drawing.Point(149, 174);
            this.rndDeleteClass.Name = "rndDeleteClass";
            this.rndDeleteClass.Size = new System.Drawing.Size(89, 28);
            this.rndDeleteClass.TabIndex = 4;
            this.rndDeleteClass.Text = "Delete";
            this.rndDeleteClass.UseVisualStyleBackColor = false;
            this.rndDeleteClass.Click += new System.EventHandler(this.rndDeleteClass_Click);
            // 
            // rndSaveClass
            // 
            this.rndSaveClass.BackColor = System.Drawing.Color.DodgerBlue;
            this.rndSaveClass.CornerRadius = 20;
            this.rndSaveClass.FlatAppearance.BorderSize = 0;
            this.rndSaveClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rndSaveClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rndSaveClass.ForeColor = System.Drawing.Color.White;
            this.rndSaveClass.Location = new System.Drawing.Point(41, 174);
            this.rndSaveClass.Name = "rndSaveClass";
            this.rndSaveClass.Size = new System.Drawing.Size(89, 28);
            this.rndSaveClass.TabIndex = 3;
            this.rndSaveClass.Text = "Save";
            this.rndSaveClass.UseVisualStyleBackColor = false;
            this.rndSaveClass.Click += new System.EventHandler(this.rndSaveClass_Click);
            // 
            // lblCoachCode
            // 
            this.lblCoachCode.AutoSize = true;
            this.lblCoachCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoachCode.Location = new System.Drawing.Point(16, 101);
            this.lblCoachCode.Name = "lblCoachCode";
            this.lblCoachCode.Size = new System.Drawing.Size(102, 18);
            this.lblCoachCode.TabIndex = 2;
            this.lblCoachCode.Text = "Coach Code";
            // 
            // lblAudioName
            // 
            this.lblAudioName.AutoSize = true;
            this.lblAudioName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudioName.Location = new System.Drawing.Point(16, 61);
            this.lblAudioName.Name = "lblAudioName";
            this.lblAudioName.Size = new System.Drawing.Size(94, 18);
            this.lblAudioName.TabIndex = 1;
            this.lblAudioName.Text = "AudioName";
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.Location = new System.Drawing.Point(16, 21);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(100, 18);
            this.lblClassName.TabIndex = 0;
            this.lblClassName.Text = "Class Name";
            // 
            // dgvSnoColumn
            // 
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.dgvSnoColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSnoColumn.Frozen = true;
            this.dgvSnoColumn.HeaderText = "S.NO";
            this.dgvSnoColumn.Name = "dgvSnoColumn";
            this.dgvSnoColumn.ReadOnly = true;
            this.dgvSnoColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSnoColumn.Width = 40;
            // 
            // dgvClassName
            // 
            this.dgvClassName.Frozen = true;
            this.dgvClassName.HeaderText = "Class Name";
            this.dgvClassName.Name = "dgvClassName";
            this.dgvClassName.Width = 200;
            // 
            // dgvCoachCode
            // 
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCoachCode.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCoachCode.Frozen = true;
            this.dgvCoachCode.HeaderText = "Coach Code";
            this.dgvCoachCode.MaxInputLength = 5;
            this.dgvCoachCode.Name = "dgvCoachCode";
            this.dgvCoachCode.ReadOnly = true;
            this.dgvCoachCode.Width = 50;
            // 
            // dgvEdit
            // 
            this.dgvEdit.FillWeight = 114.8208F;
            this.dgvEdit.Frozen = true;
            this.dgvEdit.HeaderText = "Edit";
            this.dgvEdit.Image = global::ArecaIPIS.Properties.Resources.edit;
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.ReadOnly = true;
            this.dgvEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEdit.Width = 60;
            // 
            // frmAdditionalSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.grbCoachClass);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblCgdbSize);
            this.Controls.Add(this.lblPlatforms);
            this.Controls.Add(this.lblGapCode);
            this.Controls.Add(this.lblAdditionalSettings);
            this.Name = "frmAdditionalSettings";
            this.Text = "AdditionalSettings";
            this.Load += new System.EventHandler(this.frmAdditionalSettings_Load);
            this.grbCoachClass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoachClasses)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAdditionalSettings;
        private System.Windows.Forms.Label lblGapCode;
        private System.Windows.Forms.Label lblPlatforms;
        private System.Windows.Forms.Label lblCgdbSize;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox grbCoachClass;
        private MyControls.RoundButton rndBtnCoachClass;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pnlEdit;
        private System.Windows.Forms.Label lblCoachCode;
        private System.Windows.Forms.Label lblAudioName;
        private System.Windows.Forms.Label lblClassName;
        private MyControls.RoundButton rndDeleteClass;
        private MyControls.RoundButton rndSaveClass;
        private System.Windows.Forms.RichTextBox rctAudioPath;
        private System.Windows.Forms.RichTextBox rctCoachCode;
        private System.Windows.Forms.RichTextBox rctAudioName;
        private System.Windows.Forms.RichTextBox rctClassName;
        private System.Windows.Forms.Label lblAudioPath;
        private System.Windows.Forms.DataGridView dgvCoachClasses;
        private MyControls.RoundButton rndClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSnoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCoachCode;
        private System.Windows.Forms.DataGridViewImageColumn dgvEdit;
    }
}