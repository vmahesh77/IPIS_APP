
namespace ArecaIPIS.Forms
{
    partial class frmIVDReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dGVIVDReport = new System.Windows.Forms.DataGridView();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.txtFromdate = new System.Windows.Forms.TextBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbExport = new System.Windows.Forms.ComboBox();
            this.lblExport = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.cmbTrainStatus = new System.Windows.Forms.ComboBox();
            this.lblTrainStatus = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblNoData = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.pnlMenuOption = new System.Windows.Forms.Panel();
            this.pnlNoDisplay = new System.Windows.Forms.Panel();
            this.pnlIVDReport = new System.Windows.Forms.Panel();
            this.cdtpFrom = new CustomDateTimePicker();
            this.chkFilter = new System.Windows.Forms.CheckedListBox();
            this.lblNoDataDisplay = new System.Windows.Forms.Label();
            this.btnDropdown = new System.Windows.Forms.Button();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnCross = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVIVDReport)).BeginInit();
            this.pnlMenuOption.SuspendLayout();
            this.pnlNoDisplay.SuspendLayout();
            this.pnlIVDReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(23, 22);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(50, 20);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            // 
            // dGVIVDReport
            // 
            this.dGVIVDReport.AllowUserToAddRows = false;
            this.dGVIVDReport.AllowUserToResizeColumns = false;
            this.dGVIVDReport.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dGVIVDReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVIVDReport.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVIVDReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVIVDReport.ColumnHeadersHeight = 33;
            this.dGVIVDReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVIVDReport.Location = new System.Drawing.Point(0, 88);
            this.dGVIVDReport.MultiSelect = false;
            this.dGVIVDReport.Name = "dGVIVDReport";
            this.dGVIVDReport.ReadOnly = true;
            this.dGVIVDReport.RowHeadersVisible = false;
            this.dGVIVDReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dGVIVDReport.RowTemplate.Height = 29;
            this.dGVIVDReport.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dGVIVDReport.Size = new System.Drawing.Size(1303, 270);
            this.dGVIVDReport.TabIndex = 10;
            this.dGVIVDReport.Visible = false;
            this.dGVIVDReport.Click += new System.EventHandler(this.dGVIVDReport_Click);
            // 
            // txtToDate
            // 
            this.txtToDate.Location = new System.Drawing.Point(340, 22);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(169, 20);
            this.txtToDate.TabIndex = 14;
            this.txtToDate.Click += new System.EventHandler(this.txtToDate_Click);
            // 
            // txtFromdate
            // 
            this.txtFromdate.Location = new System.Drawing.Point(79, 22);
            this.txtFromdate.Name = "txtFromdate";
            this.txtFromdate.Size = new System.Drawing.Size(169, 20);
            this.txtFromdate.TabIndex = 13;
            this.txtFromdate.Click += new System.EventHandler(this.txtFromdate_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(505, 22);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(20, 20);
            this.dtpTo.TabIndex = 10;
            this.dtpTo.Visible = false;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(246, 22);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(20, 20);
            this.dtpFrom.TabIndex = 9;
            this.dtpFrom.Visible = false;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // cmbExport
            // 
            this.cmbExport.BackColor = System.Drawing.Color.FloralWhite;
            this.cmbExport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExport.FormattingEnabled = true;
            this.cmbExport.Items.AddRange(new object[] {
            "-Select-",
            "XLS",
            "XLSX",
            "PDF"});
            this.cmbExport.Location = new System.Drawing.Point(1123, 22);
            this.cmbExport.Name = "cmbExport";
            this.cmbExport.Size = new System.Drawing.Size(65, 21);
            this.cmbExport.TabIndex = 8;
            this.cmbExport.SelectedIndexChanged += new System.EventHandler(this.cmbExport_SelectedIndexChanged);
            this.cmbExport.Click += new System.EventHandler(this.cmbExport_Click);
            // 
            // lblExport
            // 
            this.lblExport.AutoSize = true;
            this.lblExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExport.Location = new System.Drawing.Point(1058, 22);
            this.lblExport.Name = "lblExport";
            this.lblExport.Size = new System.Drawing.Size(59, 20);
            this.lblExport.TabIndex = 7;
            this.lblExport.Text = "Export:";
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.DarkOrange;
            this.btnViewReport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnViewReport.FlatAppearance.BorderSize = 0;
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnViewReport.Location = new System.Drawing.Point(871, 11);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(102, 32);
            this.btnViewReport.TabIndex = 6;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // cmbTrainStatus
            // 
            this.cmbTrainStatus.BackColor = System.Drawing.Color.FloralWhite;
            this.cmbTrainStatus.FormattingEnabled = true;
            this.cmbTrainStatus.Location = new System.Drawing.Point(688, 22);
            this.cmbTrainStatus.Name = "cmbTrainStatus";
            this.cmbTrainStatus.Size = new System.Drawing.Size(124, 21);
            this.cmbTrainStatus.TabIndex = 5;
            this.cmbTrainStatus.Click += new System.EventHandler(this.cmbTrainStatus_Click);
            // 
            // lblTrainStatus
            // 
            this.lblTrainStatus.AutoSize = true;
            this.lblTrainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainStatus.Location = new System.Drawing.Point(581, 22);
            this.lblTrainStatus.Name = "lblTrainStatus";
            this.lblTrainStatus.Size = new System.Drawing.Size(99, 20);
            this.lblTrainStatus.TabIndex = 4;
            this.lblTrainStatus.Text = "Train Status:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::ArecaIPIS.Properties.Resources._352091_search_icon;
            this.btnSearch.Location = new System.Drawing.Point(1181, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 31);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(1042, 61);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(140, 20);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.Text = "Search Here";
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // lblNoData
            // 
            this.lblNoData.AutoSize = true;
            this.lblNoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoData.Location = new System.Drawing.Point(523, 12);
            this.lblNoData.Name = "lblNoData";
            this.lblNoData.Size = new System.Drawing.Size(155, 18);
            this.lblNoData.TabIndex = 0;
            this.lblNoData.Text = "No Data To Display";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(303, 22);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(31, 20);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            // 
            // pnlMenuOption
            // 
            this.pnlMenuOption.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlMenuOption.Controls.Add(this.txtToDate);
            this.pnlMenuOption.Controls.Add(this.txtFromdate);
            this.pnlMenuOption.Controls.Add(this.dtpTo);
            this.pnlMenuOption.Controls.Add(this.dtpFrom);
            this.pnlMenuOption.Controls.Add(this.cmbExport);
            this.pnlMenuOption.Controls.Add(this.lblExport);
            this.pnlMenuOption.Controls.Add(this.btnViewReport);
            this.pnlMenuOption.Controls.Add(this.cmbTrainStatus);
            this.pnlMenuOption.Controls.Add(this.lblTrainStatus);
            this.pnlMenuOption.Controls.Add(this.lblTo);
            this.pnlMenuOption.Controls.Add(this.lblFrom);
            this.pnlMenuOption.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuOption.Name = "pnlMenuOption";
            this.pnlMenuOption.Size = new System.Drawing.Size(1304, 46);
            this.pnlMenuOption.TabIndex = 0;
            // 
            // pnlNoDisplay
            // 
            this.pnlNoDisplay.BackColor = System.Drawing.Color.FloralWhite;
            this.pnlNoDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNoDisplay.Controls.Add(this.lblNoData);
            this.pnlNoDisplay.Location = new System.Drawing.Point(0, 45);
            this.pnlNoDisplay.Name = "pnlNoDisplay";
            this.pnlNoDisplay.Size = new System.Drawing.Size(1304, 40);
            this.pnlNoDisplay.TabIndex = 1;
            this.pnlNoDisplay.Click += new System.EventHandler(this.pnlNoDisplay_Click);
            // 
            // pnlIVDReport
            // 
            this.pnlIVDReport.Controls.Add(this.cdtpFrom);
            this.pnlIVDReport.Controls.Add(this.chkFilter);
            this.pnlIVDReport.Controls.Add(this.lblNoDataDisplay);
            this.pnlIVDReport.Controls.Add(this.btnDropdown);
            this.pnlIVDReport.Controls.Add(this.pnlPagination);
            this.pnlIVDReport.Controls.Add(this.dGVIVDReport);
            this.pnlIVDReport.Controls.Add(this.txtSearch);
            this.pnlIVDReport.Controls.Add(this.pnlMenuOption);
            this.pnlIVDReport.Controls.Add(this.btnCross);
            this.pnlIVDReport.Controls.Add(this.btnSearch);
            this.pnlIVDReport.Controls.Add(this.pnlNoDisplay);
            this.pnlIVDReport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlIVDReport.Location = new System.Drawing.Point(1, 1);
            this.pnlIVDReport.Name = "pnlIVDReport";
            this.pnlIVDReport.Size = new System.Drawing.Size(1305, 424);
            this.pnlIVDReport.TabIndex = 4;
            this.pnlIVDReport.Click += new System.EventHandler(this.pnlIVDReport_Click);
            // 
            // cdtpFrom
            // 
            this.cdtpFrom.Location = new System.Drawing.Point(65, 44);
            this.cdtpFrom.Name = "cdtpFrom";
            this.cdtpFrom.Size = new System.Drawing.Size(201, 153);
            this.cdtpFrom.TabIndex = 17;
            this.cdtpFrom.Visible = false;
            // 
            // chkFilter
            // 
            this.chkFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chkFilter.FormattingEnabled = true;
            this.chkFilter.Location = new System.Drawing.Point(1187, 87);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(101, 124);
            this.chkFilter.TabIndex = 33;
            this.chkFilter.Visible = false;
            // 
            // lblNoDataDisplay
            // 
            this.lblNoDataDisplay.AutoSize = true;
            this.lblNoDataDisplay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblNoDataDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataDisplay.Location = new System.Drawing.Point(524, 135);
            this.lblNoDataDisplay.Name = "lblNoDataDisplay";
            this.lblNoDataDisplay.Size = new System.Drawing.Size(163, 20);
            this.lblNoDataDisplay.TabIndex = 23;
            this.lblNoDataDisplay.Text = "No Data To Display";
            this.lblNoDataDisplay.Visible = false;
            // 
            // btnDropdown
            // 
            this.btnDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDropdown.Image = global::ArecaIPIS.Properties.Resources.descending_down;
            this.btnDropdown.Location = new System.Drawing.Point(1223, 54);
            this.btnDropdown.Name = "btnDropdown";
            this.btnDropdown.Size = new System.Drawing.Size(46, 31);
            this.btnDropdown.TabIndex = 16;
            this.btnDropdown.UseVisualStyleBackColor = false;
            this.btnDropdown.Visible = false;
            this.btnDropdown.Click += new System.EventHandler(this.btnDropdown_Click);
            // 
            // pnlPagination
            // 
            this.pnlPagination.BackColor = System.Drawing.Color.Transparent;
            this.pnlPagination.Location = new System.Drawing.Point(0, 364);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1304, 66);
            this.pnlPagination.TabIndex = 11;
            this.pnlPagination.Visible = false;
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnCross.Location = new System.Drawing.Point(1181, 54);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(46, 31);
            this.btnCross.TabIndex = 14;
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Visible = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // frmIVDReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 426);
            this.Controls.Add(this.pnlIVDReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmIVDReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIVDReport";
            this.Load += new System.EventHandler(this.frmIVDReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVIVDReport)).EndInit();
            this.pnlMenuOption.ResumeLayout(false);
            this.pnlMenuOption.PerformLayout();
            this.pnlNoDisplay.ResumeLayout(false);
            this.pnlNoDisplay.PerformLayout();
            this.pnlIVDReport.ResumeLayout(false);
            this.pnlIVDReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DataGridView dGVIVDReport;
        private System.Windows.Forms.TextBox txtToDate;
        private System.Windows.Forms.TextBox txtFromdate;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.ComboBox cmbExport;
        private System.Windows.Forms.Label lblExport;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.ComboBox cmbTrainStatus;
        private System.Windows.Forms.Label lblTrainStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblNoData;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Panel pnlMenuOption;
        private System.Windows.Forms.Panel pnlNoDisplay;
        private System.Windows.Forms.Panel pnlIVDReport;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.Button btnDropdown;
        private System.Windows.Forms.Label lblNoDataDisplay;
        private System.Windows.Forms.CheckedListBox chkFilter;
        private CustomDateTimePicker cdtpFrom;
    }
}