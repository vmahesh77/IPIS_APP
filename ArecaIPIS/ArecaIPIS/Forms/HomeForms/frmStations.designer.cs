
namespace ArecaIPIS.Forms.HomeForms
{
    partial class frmStations
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
            this.dgvStations = new System.Windows.Forms.DataGridView();
            this.DgvSelectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvEnglishcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHindiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRegional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHeader = new System.Windows.Forms.Label();
            this.rtxtSearchBox = new System.Windows.Forms.RichTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStations
            // 
            this.dgvStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvSelectColumn,
            this.dgvEnglishcolumn,
            this.dgvHindiColumn,
            this.dgvRegional});
            this.dgvStations.Location = new System.Drawing.Point(12, 89);
            this.dgvStations.Name = "dgvStations";
            this.dgvStations.RowHeadersVisible = false;
            this.dgvStations.Size = new System.Drawing.Size(354, 192);
            this.dgvStations.TabIndex = 0;
            this.dgvStations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStations_CellContentClick);
            this.dgvStations.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvStations_CurrentCellDirtyStateChanged);
            // 
            // DgvSelectColumn
            // 
            this.DgvSelectColumn.HeaderText = "Select";
            this.DgvSelectColumn.Name = "DgvSelectColumn";
            this.DgvSelectColumn.Width = 50;
            // 
            // dgvEnglishcolumn
            // 
            this.dgvEnglishcolumn.HeaderText = "English";
            this.dgvEnglishcolumn.Name = "dgvEnglishcolumn";
            // 
            // dgvHindiColumn
            // 
            this.dgvHindiColumn.HeaderText = "Hindi";
            this.dgvHindiColumn.Name = "dgvHindiColumn";
            // 
            // dgvRegional
            // 
            this.dgvRegional.HeaderText = "Regional";
            this.dgvRegional.Name = "dgvRegional";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(8, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(181, 24);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Terminated-Diverted";
            // 
            // rtxtSearchBox
            // 
            this.rtxtSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtSearchBox.Location = new System.Drawing.Point(226, 43);
            this.rtxtSearchBox.Name = "rtxtSearchBox";
            this.rtxtSearchBox.Size = new System.Drawing.Size(100, 25);
            this.rtxtSearchBox.TabIndex = 1;
            this.rtxtSearchBox.Text = "";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::ArecaIPIS.Properties.Resources.search_icon;
            this.btnSearch.Location = new System.Drawing.Point(332, 43);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.BackgroundImage = global::ArecaIPIS.Properties.Resources.descending_down;
            this.btnFilter.Location = new System.Drawing.Point(372, 44);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(24, 23);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(288, 297);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(194, 297);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 30);
            this.btnclose.TabIndex = 4;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // frmStations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(412, 341);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.rtxtSearchBox);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.dgvStations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStations";
            this.Deactivate += new System.EventHandler(this.frmStations_Deactivate);
            this.Load += new System.EventHandler(this.frmStations_Load);
            this.Leave += new System.EventHandler(this.frmStations_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStations;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.RichTextBox rtxtSearchBox;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgvSelectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEnglishcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHindiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRegional;
    }
}