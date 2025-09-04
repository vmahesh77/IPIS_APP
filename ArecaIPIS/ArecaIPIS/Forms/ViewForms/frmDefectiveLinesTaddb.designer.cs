
namespace ArecaIPIS.Forms.ViewForms
{
    partial class frmDefectiveLinesTaddb
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
            this.lblDefectiveLinesTaddb = new System.Windows.Forms.Label();
            this.pnlDefevtiveLines = new System.Windows.Forms.Panel();
            this.panelCheckboxes = new System.Windows.Forms.Panel();
            this.txtNoOfLines = new System.Windows.Forms.TextBox();
            this.txtboardaddress = new System.Windows.Forms.TextBox();
            this.cmbtadb = new System.Windows.Forms.ComboBox();
            this.lblAdress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTaddb = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDefectiveLinesTable = new System.Windows.Forms.DataGridView();
            this.DgvDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlDefevtiveLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectiveLinesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDefectiveLinesTaddb
            // 
            this.lblDefectiveLinesTaddb.AutoSize = true;
            this.lblDefectiveLinesTaddb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectiveLinesTaddb.ForeColor = System.Drawing.Color.Red;
            this.lblDefectiveLinesTaddb.Location = new System.Drawing.Point(18, 12);
            this.lblDefectiveLinesTaddb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefectiveLinesTaddb.Name = "lblDefectiveLinesTaddb";
            this.lblDefectiveLinesTaddb.Size = new System.Drawing.Size(216, 31);
            this.lblDefectiveLinesTaddb.TabIndex = 1;
            this.lblDefectiveLinesTaddb.Text = "Defective Lines";
            // 
            // pnlDefevtiveLines
            // 
            this.pnlDefevtiveLines.Controls.Add(this.panelCheckboxes);
            this.pnlDefevtiveLines.Controls.Add(this.txtNoOfLines);
            this.pnlDefevtiveLines.Controls.Add(this.txtboardaddress);
            this.pnlDefevtiveLines.Controls.Add(this.cmbtadb);
            this.pnlDefevtiveLines.Controls.Add(this.lblAdress);
            this.pnlDefevtiveLines.Controls.Add(this.label1);
            this.pnlDefevtiveLines.Controls.Add(this.lblTaddb);
            this.pnlDefevtiveLines.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlDefevtiveLines.Location = new System.Drawing.Point(13, 70);
            this.pnlDefevtiveLines.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlDefevtiveLines.Name = "pnlDefevtiveLines";
            this.pnlDefevtiveLines.Size = new System.Drawing.Size(877, 145);
            this.pnlDefevtiveLines.TabIndex = 2;
            // 
            // panelCheckboxes
            // 
            this.panelCheckboxes.Location = new System.Drawing.Point(454, 3);
            this.panelCheckboxes.Name = "panelCheckboxes";
            this.panelCheckboxes.Size = new System.Drawing.Size(420, 139);
            this.panelCheckboxes.TabIndex = 7;
            // 
            // txtNoOfLines
            // 
            this.txtNoOfLines.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtNoOfLines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNoOfLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfLines.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNoOfLines.Location = new System.Drawing.Point(163, 111);
            this.txtNoOfLines.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNoOfLines.Name = "txtNoOfLines";
            this.txtNoOfLines.Size = new System.Drawing.Size(143, 19);
            this.txtNoOfLines.TabIndex = 5;
            // 
            // txtboardaddress
            // 
            this.txtboardaddress.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtboardaddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtboardaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboardaddress.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtboardaddress.Location = new System.Drawing.Point(161, 76);
            this.txtboardaddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtboardaddress.Name = "txtboardaddress";
            this.txtboardaddress.Size = new System.Drawing.Size(143, 19);
            this.txtboardaddress.TabIndex = 4;
            // 
            // cmbtadb
            // 
            this.cmbtadb.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cmbtadb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbtadb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtadb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbtadb.FormattingEnabled = true;
            this.cmbtadb.Location = new System.Drawing.Point(163, 31);
            this.cmbtadb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbtadb.Name = "cmbtadb";
            this.cmbtadb.Size = new System.Drawing.Size(141, 24);
            this.cmbtadb.TabIndex = 3;
            this.cmbtadb.SelectedIndexChanged += new System.EventHandler(this.cmbtadb_SelectedIndexChanged);
            // 
            // lblAdress
            // 
            this.lblAdress.AutoSize = true;
            this.lblAdress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdress.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAdress.Location = new System.Drawing.Point(36, 78);
            this.lblAdress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdress.Name = "lblAdress";
            this.lblAdress.Size = new System.Drawing.Size(68, 20);
            this.lblAdress.TabIndex = 2;
            this.lblAdress.Text = "Address";
            this.lblAdress.Click += new System.EventHandler(this.lblAdress_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(36, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "No Of Lines";
            // 
            // lblTaddb
            // 
            this.lblTaddb.AutoSize = true;
            this.lblTaddb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTaddb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaddb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTaddb.Location = new System.Drawing.Point(36, 35);
            this.lblTaddb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaddb.Name = "lblTaddb";
            this.lblTaddb.Size = new System.Drawing.Size(64, 20);
            this.lblTaddb.TabIndex = 0;
            this.lblTaddb.Text = "TADDB";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(38, 245);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvDefectiveLinesTable
            // 
            this.dgvDefectiveLinesTable.AllowUserToAddRows = false;
            this.dgvDefectiveLinesTable.AllowUserToDeleteRows = false;
            this.dgvDefectiveLinesTable.AllowUserToResizeColumns = false;
            this.dgvDefectiveLinesTable.AllowUserToResizeRows = false;
            this.dgvDefectiveLinesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDefectiveLinesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefectiveLinesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvDelete});
            this.dgvDefectiveLinesTable.Location = new System.Drawing.Point(132, 290);
            this.dgvDefectiveLinesTable.Name = "dgvDefectiveLinesTable";
            this.dgvDefectiveLinesTable.ReadOnly = true;
            this.dgvDefectiveLinesTable.RowHeadersVisible = false;
            this.dgvDefectiveLinesTable.Size = new System.Drawing.Size(766, 180);
            this.dgvDefectiveLinesTable.TabIndex = 4;
            this.dgvDefectiveLinesTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDefectiveLinesTable_CellClick);
            // 
            // DgvDelete
            // 
            this.DgvDelete.HeaderText = "";
            this.DgvDelete.Name = "DgvDelete";
            this.DgvDelete.ReadOnly = true;
            // 
            // frmDefectiveLinesTaddb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 548);
            this.Controls.Add(this.dgvDefectiveLinesTable);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlDefevtiveLines);
            this.Controls.Add(this.lblDefectiveLinesTaddb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDefectiveLinesTaddb";
            this.Text = "frmDefectiveLinesTaddb";
            this.Load += new System.EventHandler(this.frmDefectiveLinesTaddb_Load);
            this.pnlDefevtiveLines.ResumeLayout(false);
            this.pnlDefevtiveLines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectiveLinesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDefectiveLinesTaddb;
        private System.Windows.Forms.Panel pnlDefevtiveLines;
        private System.Windows.Forms.ComboBox cmbtadb;
        private System.Windows.Forms.Label lblAdress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTaddb;
        private System.Windows.Forms.TextBox txtNoOfLines;
        private System.Windows.Forms.TextBox txtboardaddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvDefectiveLinesTable;
        private System.Windows.Forms.Panel panelCheckboxes;
        private System.Windows.Forms.DataGridViewImageColumn DgvDelete;
    }
}