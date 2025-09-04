
namespace ArecaIPIS.Forms
{
    partial class frmIntensity
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlIntensity = new System.Windows.Forms.Panel();
            this.dGVIntensity = new System.Windows.Forms.DataGridView();
            this.dgvSNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBoardip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBoardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCurrentIntensity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNewIntensity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblSet = new System.Windows.Forms.Label();
            this.txtIntensity = new System.Windows.Forms.TextBox();
            this.trackBarAll = new System.Windows.Forms.TrackBar();
            this.trackBarSingle = new System.Windows.Forms.TrackBar();
            this.btnSetIntensity = new System.Windows.Forms.Button();
            this.pancgdb = new System.Windows.Forms.Panel();
            this.lblcgdb = new System.Windows.Forms.Label();
            this.dgvCgdbPorts = new System.Windows.Forms.DataGridView();
            this.dgvsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCPlatformNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCboardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPDCIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCOldIntensity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCNewIntensity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEditCGDb = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.trackBarCgdb = new System.Windows.Forms.TrackBar();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlIntensity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSingle)).BeginInit();
            this.pancgdb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCgdbPorts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCgdb)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIntensity
            // 
            this.pnlIntensity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlIntensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIntensity.Controls.Add(this.dGVIntensity);
            this.pnlIntensity.ForeColor = System.Drawing.Color.Black;
            this.pnlIntensity.Location = new System.Drawing.Point(12, 59);
            this.pnlIntensity.Name = "pnlIntensity";
            this.pnlIntensity.Size = new System.Drawing.Size(1057, 255);
            this.pnlIntensity.TabIndex = 0;
            // 
            // dGVIntensity
            // 
            this.dGVIntensity.AllowUserToAddRows = false;
            this.dGVIntensity.AllowUserToDeleteRows = false;
            this.dGVIntensity.AllowUserToResizeColumns = false;
            this.dGVIntensity.AllowUserToResizeRows = false;
            this.dGVIntensity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVIntensity.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dGVIntensity.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVIntensity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dGVIntensity.ColumnHeadersHeight = 40;
            this.dGVIntensity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVIntensity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSNo,
            this.dgvLocation,
            this.dgvBoardip,
            this.dgvBoardType,
            this.dgvCurrentIntensity,
            this.dgvNewIntensity,
            this.dgvEdit});
            this.dGVIntensity.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVIntensity.DefaultCellStyle = dataGridViewCellStyle10;
            this.dGVIntensity.EnableHeadersVisualStyles = false;
            this.dGVIntensity.Location = new System.Drawing.Point(12, 10);
            this.dGVIntensity.Name = "dGVIntensity";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVIntensity.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dGVIntensity.RowHeadersVisible = false;
            this.dGVIntensity.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.dGVIntensity.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dGVIntensity.RowTemplate.Height = 46;
            this.dGVIntensity.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVIntensity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGVIntensity.Size = new System.Drawing.Size(1012, 235);
            this.dGVIntensity.TabIndex = 0;
            this.dGVIntensity.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVIntensity_CellClick);
            // 
            // dgvSNo
            // 
            this.dgvSNo.FillWeight = 76.14214F;
            this.dgvSNo.HeaderText = "S.No";
            this.dgvSNo.Name = "dgvSNo";
            this.dgvSNo.ReadOnly = true;
            // 
            // dgvLocation
            // 
            this.dgvLocation.FillWeight = 104.7716F;
            this.dgvLocation.HeaderText = "Location";
            this.dgvLocation.Name = "dgvLocation";
            this.dgvLocation.ReadOnly = true;
            // 
            // dgvBoardip
            // 
            this.dgvBoardip.HeaderText = "IpAddress";
            this.dgvBoardip.Name = "dgvBoardip";
            this.dgvBoardip.ReadOnly = true;
            // 
            // dgvBoardType
            // 
            this.dgvBoardType.FillWeight = 104.7716F;
            this.dgvBoardType.HeaderText = "Board Type";
            this.dgvBoardType.Name = "dgvBoardType";
            this.dgvBoardType.ReadOnly = true;
            // 
            // dgvCurrentIntensity
            // 
            this.dgvCurrentIntensity.FillWeight = 104.7716F;
            this.dgvCurrentIntensity.HeaderText = "Current Intensity";
            this.dgvCurrentIntensity.Name = "dgvCurrentIntensity";
            this.dgvCurrentIntensity.ReadOnly = true;
            // 
            // dgvNewIntensity
            // 
            this.dgvNewIntensity.FillWeight = 104.7716F;
            this.dgvNewIntensity.HeaderText = "New Intensity";
            this.dgvNewIntensity.Name = "dgvNewIntensity";
            this.dgvNewIntensity.ReadOnly = true;
            // 
            // dgvEdit
            // 
            this.dgvEdit.FillWeight = 104.7716F;
            this.dgvEdit.HeaderText = "edit";
            this.dgvEdit.Image = global::ArecaIPIS.Properties.Resources._8666681_edit_icon__1_1;
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.ReadOnly = true;
            // 
            // lblSet
            // 
            this.lblSet.AutoSize = true;
            this.lblSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSet.Location = new System.Drawing.Point(686, 12);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(65, 16);
            this.lblSet.TabIndex = 2;
            this.lblSet.Text = "Set To all";
            // 
            // txtIntensity
            // 
            this.txtIntensity.Location = new System.Drawing.Point(957, 12);
            this.txtIntensity.Name = "txtIntensity";
            this.txtIntensity.Size = new System.Drawing.Size(74, 20);
            this.txtIntensity.TabIndex = 9;
            this.txtIntensity.TextChanged += new System.EventHandler(this.txtIntensity_TextChanged);
            // 
            // trackBarAll
            // 
            this.trackBarAll.BackColor = System.Drawing.Color.PeachPuff;
            this.trackBarAll.Location = new System.Drawing.Point(757, 8);
            this.trackBarAll.Maximum = 100;
            this.trackBarAll.Name = "trackBarAll";
            this.trackBarAll.Size = new System.Drawing.Size(177, 45);
            this.trackBarAll.TabIndex = 10;
            this.trackBarAll.TickFrequency = 10;
            this.trackBarAll.Scroll += new System.EventHandler(this.trackBarAll_Scroll);
            // 
            // trackBarSingle
            // 
            this.trackBarSingle.BackColor = System.Drawing.Color.OrangeRed;
            this.trackBarSingle.Location = new System.Drawing.Point(1093, 147);
            this.trackBarSingle.Maximum = 100;
            this.trackBarSingle.Name = "trackBarSingle";
            this.trackBarSingle.Size = new System.Drawing.Size(177, 45);
            this.trackBarSingle.TabIndex = 11;
            this.trackBarSingle.TickFrequency = 10;
            this.trackBarSingle.Visible = false;
            this.trackBarSingle.Scroll += new System.EventHandler(this.trackBarSingle_Scroll);
            // 
            // btnSetIntensity
            // 
            this.btnSetIntensity.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSetIntensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetIntensity.Location = new System.Drawing.Point(957, 591);
            this.btnSetIntensity.Name = "btnSetIntensity";
            this.btnSetIntensity.Size = new System.Drawing.Size(132, 38);
            this.btnSetIntensity.TabIndex = 12;
            this.btnSetIntensity.Text = "Set Intensity";
            this.btnSetIntensity.UseVisualStyleBackColor = false;
            this.btnSetIntensity.Click += new System.EventHandler(this.btnSetIntensity_Click);
            // 
            // pancgdb
            // 
            this.pancgdb.BackColor = System.Drawing.Color.Chocolate;
            this.pancgdb.Controls.Add(this.lblcgdb);
            this.pancgdb.Location = new System.Drawing.Point(25, 332);
            this.pancgdb.Name = "pancgdb";
            this.pancgdb.Size = new System.Drawing.Size(381, 38);
            this.pancgdb.TabIndex = 13;
            // 
            // lblcgdb
            // 
            this.lblcgdb.AutoSize = true;
            this.lblcgdb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcgdb.Location = new System.Drawing.Point(88, 7);
            this.lblcgdb.Name = "lblcgdb";
            this.lblcgdb.Size = new System.Drawing.Size(137, 24);
            this.lblcgdb.TabIndex = 0;
            this.lblcgdb.Text = "CGDB Boards";
            // 
            // dgvCgdbPorts
            // 
            this.dgvCgdbPorts.AllowUserToAddRows = false;
            this.dgvCgdbPorts.AllowUserToDeleteRows = false;
            this.dgvCgdbPorts.AllowUserToResizeColumns = false;
            this.dgvCgdbPorts.AllowUserToResizeRows = false;
            this.dgvCgdbPorts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCgdbPorts.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCgdbPorts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCgdbPorts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvCgdbPorts.ColumnHeadersHeight = 35;
            this.dgvCgdbPorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCgdbPorts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvsn,
            this.dgvCPlatformNo,
            this.dgcCboardType,
            this.dgvPDCIP,
            this.dgvCOldIntensity,
            this.dgvCNewIntensity,
            this.dgvEditCGDb});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCgdbPorts.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvCgdbPorts.EnableHeadersVisualStyles = false;
            this.dgvCgdbPorts.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCgdbPorts.Location = new System.Drawing.Point(25, 386);
            this.dgvCgdbPorts.Name = "dgvCgdbPorts";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCgdbPorts.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvCgdbPorts.RowHeadersVisible = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCgdbPorts.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvCgdbPorts.Size = new System.Drawing.Size(681, 229);
            this.dgvCgdbPorts.TabIndex = 14;
            this.dgvCgdbPorts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCgdbPorts_CellClick);
            // 
            // dgvsn
            // 
            this.dgvsn.FillWeight = 60.9137F;
            this.dgvsn.HeaderText = "S.no";
            this.dgvsn.Name = "dgvsn";
            this.dgvsn.ReadOnly = true;
            // 
            // dgvCPlatformNo
            // 
            this.dgvCPlatformNo.FillWeight = 107.8173F;
            this.dgvCPlatformNo.HeaderText = "Platform No";
            this.dgvCPlatformNo.Name = "dgvCPlatformNo";
            this.dgvCPlatformNo.ReadOnly = true;
            // 
            // dgcCboardType
            // 
            this.dgcCboardType.FillWeight = 107.8173F;
            this.dgcCboardType.HeaderText = "Board Type";
            this.dgcCboardType.Name = "dgcCboardType";
            this.dgcCboardType.ReadOnly = true;
            // 
            // dgvPDCIP
            // 
            this.dgvPDCIP.HeaderText = "Pdc IPADDRESS";
            this.dgvPDCIP.Name = "dgvPDCIP";
            this.dgvPDCIP.ReadOnly = true;
            // 
            // dgvCOldIntensity
            // 
            this.dgvCOldIntensity.FillWeight = 107.8173F;
            this.dgvCOldIntensity.HeaderText = "Old Intensity";
            this.dgvCOldIntensity.Name = "dgvCOldIntensity";
            // 
            // dgvCNewIntensity
            // 
            this.dgvCNewIntensity.FillWeight = 107.8173F;
            this.dgvCNewIntensity.HeaderText = "New Intensity";
            this.dgvCNewIntensity.Name = "dgvCNewIntensity";
            // 
            // dgvEditCGDb
            // 
            this.dgvEditCGDb.HeaderText = "Update Intensity";
            this.dgvEditCGDb.Image = global::ArecaIPIS.Properties.Resources._8666681_edit_icon__1_2;
            this.dgvEditCGDb.Name = "dgvEditCGDb";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 104.7716F;
            this.dataGridViewImageColumn1.HeaderText = "edit";
            this.dataGridViewImageColumn1.Image = global::ArecaIPIS.Properties.Resources._8666681_edit_icon__1_1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 182;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Column1";
            this.dataGridViewImageColumn2.Image = global::ArecaIPIS.Properties.Resources._8666681_edit_icon__1_2;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 98;
            // 
            // trackBarCgdb
            // 
            this.trackBarCgdb.BackColor = System.Drawing.Color.OrangeRed;
            this.trackBarCgdb.Location = new System.Drawing.Point(741, 386);
            this.trackBarCgdb.Maximum = 100;
            this.trackBarCgdb.Name = "trackBarCgdb";
            this.trackBarCgdb.Size = new System.Drawing.Size(177, 45);
            this.trackBarCgdb.TabIndex = 15;
            this.trackBarCgdb.TickFrequency = 10;
            this.trackBarCgdb.Visible = false;
            this.trackBarCgdb.Scroll += new System.EventHandler(this.trackBarCgdb_Scroll);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Blue;
            this.lblHeader.Location = new System.Drawing.Point(33, 12);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(78, 20);
            this.lblHeader.TabIndex = 17;
            this.lblHeader.Text = "Intensity";
            // 
            // frmIntensity
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1358, 548);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.trackBarCgdb);
            this.Controls.Add(this.dgvCgdbPorts);
            this.Controls.Add(this.pancgdb);
            this.Controls.Add(this.btnSetIntensity);
            this.Controls.Add(this.trackBarSingle);
            this.Controls.Add(this.trackBarAll);
            this.Controls.Add(this.txtIntensity);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.pnlIntensity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmIntensity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIntensity";
            this.Load += new System.EventHandler(this.frmIntensity_Load);
            this.pnlIntensity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSingle)).EndInit();
            this.pancgdb.ResumeLayout(false);
            this.pancgdb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCgdbPorts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCgdb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlIntensity;
        private System.Windows.Forms.Label lblSet;
        private System.Windows.Forms.DataGridView dGVIntensity;
        private System.Windows.Forms.TextBox txtIntensity;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.TrackBar trackBarAll;
        private System.Windows.Forms.TrackBar trackBarSingle;
        private System.Windows.Forms.Button btnSetIntensity;
        private System.Windows.Forms.Panel pancgdb;
        private System.Windows.Forms.Label lblcgdb;
        private System.Windows.Forms.DataGridView dgvCgdbPorts;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.TrackBar trackBarCgdb;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCPlatformNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCboardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPDCIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCOldIntensity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCNewIntensity;
        private System.Windows.Forms.DataGridViewImageColumn dgvEditCGDb;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBoardip;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBoardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCurrentIntensity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNewIntensity;
        private System.Windows.Forms.DataGridViewImageColumn dgvEdit;
        private System.Windows.Forms.Label lblHeader;
    }
}