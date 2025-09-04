
namespace ArecaIPIS.Forms
{
    partial class frmDataLogReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dGVDataLogReport = new System.Windows.Forms.DataGridView();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.txtFromdate = new System.Windows.Forms.TextBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbExport = new System.Windows.Forms.ComboBox();
            this.lblExport = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.lblNoData = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlNoDisplay = new System.Windows.Forms.Panel();
            this.pnlMenuOption = new System.Windows.Forms.Panel();
            this.pnlDataLogReport = new System.Windows.Forms.Panel();
            this.cdtpFrom = new CustomDateTimePicker();
            this.chkFilter = new System.Windows.Forms.CheckedListBox();
            this.lblNoDataDisplay = new System.Windows.Forms.Label();
            this.btnDropdown = new System.Windows.Forms.Button();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnCross = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDataLogReport)).BeginInit();
            this.pnlNoDisplay.SuspendLayout();
            this.pnlMenuOption.SuspendLayout();
            this.pnlDataLogReport.SuspendLayout();
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
            // dGVDataLogReport
            // 
            this.dGVDataLogReport.AllowUserToAddRows = false;
            this.dGVDataLogReport.AllowUserToResizeColumns = false;
            this.dGVDataLogReport.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            this.dGVDataLogReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVDataLogReport.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDataLogReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVDataLogReport.ColumnHeadersHeight = 30;
            this.dGVDataLogReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVDataLogReport.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGVDataLogReport.Location = new System.Drawing.Point(3, 86);
            this.dGVDataLogReport.MultiSelect = false;
            this.dGVDataLogReport.Name = "dGVDataLogReport";
            this.dGVDataLogReport.ReadOnly = true;
            this.dGVDataLogReport.RowHeadersVisible = false;
            this.dGVDataLogReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dGVDataLogReport.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVDataLogReport.RowTemplate.Height = 29;
            this.dGVDataLogReport.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dGVDataLogReport.Size = new System.Drawing.Size(1296, 270);
            this.dGVDataLogReport.TabIndex = 9;
            this.dGVDataLogReport.Visible = false;
            this.dGVDataLogReport.Click += new System.EventHandler(this.dGVDataLogReport_Click);
            // 
            // txtToDate
            // 
            this.txtToDate.Location = new System.Drawing.Point(416, 23);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(169, 20);
            this.txtToDate.TabIndex = 16;
            this.txtToDate.Click += new System.EventHandler(this.txtToDate_Click);
            // 
            // txtFromdate
            // 
            this.txtFromdate.Location = new System.Drawing.Point(79, 22);
            this.txtFromdate.Name = "txtFromdate";
            this.txtFromdate.Size = new System.Drawing.Size(169, 20);
            this.txtFromdate.TabIndex = 15;
            this.txtFromdate.Click += new System.EventHandler(this.txtFromdate_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(583, 23);
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
            this.cmbExport.Location = new System.Drawing.Point(1080, 22);
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
            this.lblExport.Location = new System.Drawing.Point(1015, 22);
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
            this.btnViewReport.Location = new System.Drawing.Point(779, 12);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(102, 31);
            this.btnViewReport.TabIndex = 6;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // lblNoData
            // 
            this.lblNoData.AutoSize = true;
            this.lblNoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoData.Location = new System.Drawing.Point(626, 13);
            this.lblNoData.Name = "lblNoData";
            this.lblNoData.Size = new System.Drawing.Size(155, 18);
            this.lblNoData.TabIndex = 0;
            this.lblNoData.Text = "No Data To Display";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(379, 22);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(31, 20);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::ArecaIPIS.Properties.Resources._352091_search_icon;
            this.btnSearch.Location = new System.Drawing.Point(1193, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 31);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(1054, 60);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(140, 20);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.Text = "Search Here";
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // pnlNoDisplay
            // 
            this.pnlNoDisplay.BackColor = System.Drawing.Color.FloralWhite;
            this.pnlNoDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNoDisplay.Controls.Add(this.lblNoData);
            this.pnlNoDisplay.Location = new System.Drawing.Point(0, 45);
            this.pnlNoDisplay.Name = "pnlNoDisplay";
            this.pnlNoDisplay.Size = new System.Drawing.Size(1299, 43);
            this.pnlNoDisplay.TabIndex = 1;
            this.pnlNoDisplay.Click += new System.EventHandler(this.pnlNoDisplay_Click);
         
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
            this.pnlMenuOption.Controls.Add(this.lblTo);
            this.pnlMenuOption.Controls.Add(this.lblFrom);
            this.pnlMenuOption.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuOption.Name = "pnlMenuOption";
            this.pnlMenuOption.Size = new System.Drawing.Size(1299, 46);
            this.pnlMenuOption.TabIndex = 0;
            // 
            // pnlDataLogReport
            // 
            this.pnlDataLogReport.Controls.Add(this.cdtpFrom);
            this.pnlDataLogReport.Controls.Add(this.chkFilter);
            this.pnlDataLogReport.Controls.Add(this.lblNoDataDisplay);
            this.pnlDataLogReport.Controls.Add(this.btnDropdown);
            this.pnlDataLogReport.Controls.Add(this.pnlPagination);
            this.pnlDataLogReport.Controls.Add(this.dGVDataLogReport);
            this.pnlDataLogReport.Controls.Add(this.txtSearch);
            this.pnlDataLogReport.Controls.Add(this.pnlMenuOption);
            this.pnlDataLogReport.Controls.Add(this.btnSearch);
            this.pnlDataLogReport.Controls.Add(this.btnCross);
            this.pnlDataLogReport.Controls.Add(this.pnlNoDisplay);
            this.pnlDataLogReport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlDataLogReport.Location = new System.Drawing.Point(0, 0);
            this.pnlDataLogReport.Name = "pnlDataLogReport";
            this.pnlDataLogReport.Size = new System.Drawing.Size(1299, 425);
            this.pnlDataLogReport.TabIndex = 6;
            this.pnlDataLogReport.Click += new System.EventHandler(this.pnlDataLogReport_Click);
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
            this.chkFilter.BackColor = System.Drawing.Color.DarkOrange;
            this.chkFilter.FormattingEnabled = true;
            this.chkFilter.Location = new System.Drawing.Point(1193, 88);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(101, 49);
            this.chkFilter.TabIndex = 29;
            this.chkFilter.Visible = false;
            this.chkFilter.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkDatalogFilter_ItemCheck);
            this.chkFilter.BackColorChanged += new System.EventHandler(this.chkDatalogFilter_BackColorChanged);
            this.chkFilter.Leave += new System.EventHandler(this.chkDatalogFilter_Leave);
            // 
            // lblNoDataDisplay
            // 
            this.lblNoDataDisplay.AutoSize = true;
            this.lblNoDataDisplay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblNoDataDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataDisplay.Location = new System.Drawing.Point(620, 134);
            this.lblNoDataDisplay.Name = "lblNoDataDisplay";
            this.lblNoDataDisplay.Size = new System.Drawing.Size(163, 20);
            this.lblNoDataDisplay.TabIndex = 28;
            this.lblNoDataDisplay.Text = "No Data To Display";
            this.lblNoDataDisplay.Visible = false;
            // 
            // btnDropdown
            // 
            this.btnDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDropdown.Image = global::ArecaIPIS.Properties.Resources.descending_down;
            this.btnDropdown.Location = new System.Drawing.Point(1236, 53);
            this.btnDropdown.Name = "btnDropdown";
            this.btnDropdown.Size = new System.Drawing.Size(46, 31);
            this.btnDropdown.TabIndex = 18;
            this.btnDropdown.UseVisualStyleBackColor = false;
            this.btnDropdown.Visible = false;
            this.btnDropdown.Click += new System.EventHandler(this.btnDropdown_Click);
            // 
            // pnlPagination
            // 
            this.pnlPagination.BackColor = System.Drawing.Color.Transparent;
            this.pnlPagination.Location = new System.Drawing.Point(3, 362);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1299, 66);
            this.pnlPagination.TabIndex = 11;
            this.pnlPagination.Visible = false;
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnCross.Location = new System.Drawing.Point(1193, 53);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(46, 31);
            this.btnCross.TabIndex = 19;
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Visible = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // frmDataLogReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 420);
            this.Controls.Add(this.pnlDataLogReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDataLogReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDataLogReport";
            this.Load += new System.EventHandler(this.frmDataLogReport_Load);
            this.Leave += new System.EventHandler(this.frmDataLogReport_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDataLogReport)).EndInit();
            this.pnlNoDisplay.ResumeLayout(false);
            this.pnlNoDisplay.PerformLayout();
            this.pnlMenuOption.ResumeLayout(false);
            this.pnlMenuOption.PerformLayout();
            this.pnlDataLogReport.ResumeLayout(false);
            this.pnlDataLogReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DataGridView dGVDataLogReport;
        private System.Windows.Forms.TextBox txtToDate;
        private System.Windows.Forms.TextBox txtFromdate;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.ComboBox cmbExport;
        private System.Windows.Forms.Label lblExport;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Label lblNoData;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlNoDisplay;
        private System.Windows.Forms.Panel pnlMenuOption;
        private System.Windows.Forms.Panel pnlDataLogReport;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnDropdown;
        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.Label lblNoDataDisplay;
        private System.Windows.Forms.CheckedListBox chkFilter;
        private CustomDateTimePicker cdtpFrom;
    }
}