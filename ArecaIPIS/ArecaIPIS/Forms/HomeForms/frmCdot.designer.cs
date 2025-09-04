
namespace ArecaIPIS.Forms.HomeForms
{
    partial class frmCdot
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCdot));
            this.lblCdot = new System.Windows.Forms.Label();
            this.dgvCdot = new System.Windows.Forms.DataGridView();
            this.dgvSelectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvfkeyidentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAlertMessageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUrgencyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSeverityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCertaintyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStartTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEndTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAudioAvailabilityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbCdotMessage = new System.Windows.Forms.GroupBox();
            this.btnAudio = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.grbCdotPause = new System.Windows.Forms.GroupBox();
            this.lblCdotMin = new System.Windows.Forms.Label();
            this.numericUpDownCdot = new System.Windows.Forms.NumericUpDown();
            this.btnCdotPause = new System.Windows.Forms.Button();
            this.CdotPauseTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCdot)).BeginInit();
            this.grbCdotMessage.SuspendLayout();
            this.grbCdotPause.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCdot)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCdot
            // 
            this.lblCdot.AutoSize = true;
            this.lblCdot.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCdot.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCdot.Location = new System.Drawing.Point(12, 7);
            this.lblCdot.Name = "lblCdot";
            this.lblCdot.Size = new System.Drawing.Size(76, 31);
            this.lblCdot.TabIndex = 0;
            this.lblCdot.Text = "Cdot";
            // 
            // dgvCdot
            // 
            this.dgvCdot.AllowUserToAddRows = false;
            this.dgvCdot.AllowUserToResizeColumns = false;
            this.dgvCdot.AllowUserToResizeRows = false;
            this.dgvCdot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCdot.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCdot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCdot.ColumnHeadersHeight = 30;
            this.dgvCdot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCdot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSelectColumn,
            this.dgvfkeyidentifier,
            this.dgvAlertMessageColumn,
            this.dgvUrgencyColumn,
            this.dgvSeverityColumn,
            this.dgvCertaintyColumn,
            this.dgvStartTimeColumn,
            this.dgvEndTimeColumn,
            this.dgvAudioAvailabilityColumn});
            this.dgvCdot.EnableHeadersVisualStyles = false;
            this.dgvCdot.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvCdot.Location = new System.Drawing.Point(2, 45);
            this.dgvCdot.MultiSelect = false;
            this.dgvCdot.Name = "dgvCdot";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCdot.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCdot.RowHeadersVisible = false;
            this.dgvCdot.RowTemplate.Height = 30;
            this.dgvCdot.Size = new System.Drawing.Size(1240, 276);
            this.dgvCdot.TabIndex = 1;
            // 
            // dgvSelectColumn
            // 
            this.dgvSelectColumn.FillWeight = 73.09645F;
            this.dgvSelectColumn.HeaderText = "Select";
            this.dgvSelectColumn.Name = "dgvSelectColumn";
            // 
            // dgvfkeyidentifier
            // 
            this.dgvfkeyidentifier.HeaderText = "fkeyidentifier";
            this.dgvfkeyidentifier.Name = "dgvfkeyidentifier";
            this.dgvfkeyidentifier.ReadOnly = true;
            this.dgvfkeyidentifier.Visible = false;
            // 
            // dgvAlertMessageColumn
            // 
            this.dgvAlertMessageColumn.FillWeight = 125.9426F;
            this.dgvAlertMessageColumn.HeaderText = "AlertMessage";
            this.dgvAlertMessageColumn.Name = "dgvAlertMessageColumn";
            this.dgvAlertMessageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlertMessageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvUrgencyColumn
            // 
            this.dgvUrgencyColumn.FillWeight = 83.26526F;
            this.dgvUrgencyColumn.HeaderText = "Urgency";
            this.dgvUrgencyColumn.Name = "dgvUrgencyColumn";
            // 
            // dgvSeverityColumn
            // 
            this.dgvSeverityColumn.FillWeight = 84.01775F;
            this.dgvSeverityColumn.HeaderText = "Severity";
            this.dgvSeverityColumn.Name = "dgvSeverityColumn";
            // 
            // dgvCertaintyColumn
            // 
            this.dgvCertaintyColumn.FillWeight = 84.99004F;
            this.dgvCertaintyColumn.HeaderText = "Certainty";
            this.dgvCertaintyColumn.Name = "dgvCertaintyColumn";
            // 
            // dgvStartTimeColumn
            // 
            this.dgvStartTimeColumn.FillWeight = 115.0187F;
            this.dgvStartTimeColumn.HeaderText = "StartTime";
            this.dgvStartTimeColumn.Name = "dgvStartTimeColumn";
            // 
            // dgvEndTimeColumn
            // 
            this.dgvEndTimeColumn.FillWeight = 113.2089F;
            this.dgvEndTimeColumn.HeaderText = "EndTime";
            this.dgvEndTimeColumn.Name = "dgvEndTimeColumn";
            // 
            // dgvAudioAvailabilityColumn
            // 
            this.dgvAudioAvailabilityColumn.FillWeight = 120.4604F;
            this.dgvAudioAvailabilityColumn.HeaderText = "AudioAvailability";
            this.dgvAudioAvailabilityColumn.Name = "dgvAudioAvailabilityColumn";
            // 
            // grbCdotMessage
            // 
            this.grbCdotMessage.BackColor = System.Drawing.Color.Tan;
            this.grbCdotMessage.Controls.Add(this.btnAudio);
            this.grbCdotMessage.Controls.Add(this.btnData);
            this.grbCdotMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbCdotMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCdotMessage.Location = new System.Drawing.Point(18, 333);
            this.grbCdotMessage.Name = "grbCdotMessage";
            this.grbCdotMessage.Size = new System.Drawing.Size(329, 124);
            this.grbCdotMessage.TabIndex = 2;
            this.grbCdotMessage.TabStop = false;
            this.grbCdotMessage.Text = "Cdot Message";
            // 
            // btnAudio
            // 
            this.btnAudio.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAudio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAudio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAudio.Location = new System.Drawing.Point(179, 61);
            this.btnAudio.Name = "btnAudio";
            this.btnAudio.Size = new System.Drawing.Size(97, 37);
            this.btnAudio.TabIndex = 1;
            this.btnAudio.Text = "Audio";
            this.btnAudio.UseVisualStyleBackColor = false;
            this.btnAudio.Click += new System.EventHandler(this.btnAudio_Click);
            // 
            // btnData
            // 
            this.btnData.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnData.Location = new System.Drawing.Point(33, 61);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(93, 37);
            this.btnData.TabIndex = 0;
            this.btnData.Text = "Data";
            this.btnData.UseVisualStyleBackColor = false;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // grbCdotPause
            // 
            this.grbCdotPause.BackColor = System.Drawing.Color.Silver;
            this.grbCdotPause.Controls.Add(this.lblCdotMin);
            this.grbCdotPause.Controls.Add(this.numericUpDownCdot);
            this.grbCdotPause.Controls.Add(this.btnCdotPause);
            this.grbCdotPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbCdotPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCdotPause.Location = new System.Drawing.Point(422, 336);
            this.grbCdotPause.Name = "grbCdotPause";
            this.grbCdotPause.Size = new System.Drawing.Size(226, 100);
            this.grbCdotPause.TabIndex = 3;
            this.grbCdotPause.TabStop = false;
            this.grbCdotPause.Text = "Cdot Pause";
            // 
            // lblCdotMin
            // 
            this.lblCdotMin.AutoSize = true;
            this.lblCdotMin.Location = new System.Drawing.Point(160, 43);
            this.lblCdotMin.Name = "lblCdotMin";
            this.lblCdotMin.Size = new System.Drawing.Size(37, 20);
            this.lblCdotMin.TabIndex = 29;
            this.lblCdotMin.Text = "Min";
            // 
            // numericUpDownCdot
            // 
            this.numericUpDownCdot.Location = new System.Drawing.Point(123, 41);
            this.numericUpDownCdot.Name = "numericUpDownCdot";
            this.numericUpDownCdot.Size = new System.Drawing.Size(37, 26);
            this.numericUpDownCdot.TabIndex = 28;
            this.numericUpDownCdot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCdotPause
            // 
            this.btnCdotPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCdotPause.FlatAppearance.BorderSize = 0;
            this.btnCdotPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCdotPause.Image = ((System.Drawing.Image)(resources.GetObject("btnCdotPause.Image")));
            this.btnCdotPause.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCdotPause.Location = new System.Drawing.Point(32, 34);
            this.btnCdotPause.Name = "btnCdotPause";
            this.btnCdotPause.Padding = new System.Windows.Forms.Padding(1);
            this.btnCdotPause.Size = new System.Drawing.Size(79, 33);
            this.btnCdotPause.TabIndex = 27;
            this.btnCdotPause.Text = "Pause";
            this.btnCdotPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCdotPause.UseVisualStyleBackColor = false;
            this.btnCdotPause.Click += new System.EventHandler(this.btnCdotPause_Click);
            // 
            // CdotPauseTimer
            // 
            this.CdotPauseTimer.Tick += new System.EventHandler(this.CdotPauseTimer_Tick);
            // 
            // frmCdot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 548);
            this.Controls.Add(this.grbCdotPause);
            this.Controls.Add(this.grbCdotMessage);
            this.Controls.Add(this.dgvCdot);
            this.Controls.Add(this.lblCdot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCdot";
            this.Text = "frmCdot";
            this.Load += new System.EventHandler(this.frmCdot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCdot)).EndInit();
            this.grbCdotMessage.ResumeLayout(false);
            this.grbCdotPause.ResumeLayout(false);
            this.grbCdotPause.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCdot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCdot;
        private System.Windows.Forms.DataGridView dgvCdot;
        private System.Windows.Forms.GroupBox grbCdotMessage;
        private System.Windows.Forms.Button btnAudio;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvSelectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvfkeyidentifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAlertMessageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUrgencyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSeverityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCertaintyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStartTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEndTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAudioAvailabilityColumn;
        private System.Windows.Forms.GroupBox grbCdotPause;
        private System.Windows.Forms.Label lblCdotMin;
        private System.Windows.Forms.NumericUpDown numericUpDownCdot;
        private System.Windows.Forms.Button btnCdotPause;
        private System.Windows.Forms.Timer CdotPauseTimer;
    }
}