
namespace ArecaIPIS.Forms
{
    partial class frmBoardDiagnosis
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
            this.panButtons = new System.Windows.Forms.Panel();
            this.btnivdovd = new System.Windows.Forms.Button();
            this.btnCgdb = new System.Windows.Forms.Button();
            this.btnTADB = new System.Windows.Forms.Button();
            this.btnCds = new System.Windows.Forms.Button();
            this.panBoardforms = new System.Windows.Forms.Panel();
            this.lblBoardDiagnosis = new System.Windows.Forms.Label();
            this.panline = new System.Windows.Forms.Panel();
            this.panButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panButtons
            // 
            this.panButtons.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panButtons.Controls.Add(this.btnivdovd);
            this.panButtons.Controls.Add(this.btnCgdb);
            this.panButtons.Controls.Add(this.btnTADB);
            this.panButtons.Controls.Add(this.btnCds);
            this.panButtons.Location = new System.Drawing.Point(8, 34);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(217, 313);
            this.panButtons.TabIndex = 3;
            // 
            // btnivdovd
            // 
            this.btnivdovd.BackColor = System.Drawing.Color.Green;
            this.btnivdovd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnivdovd.ForeColor = System.Drawing.Color.Honeydew;
            this.btnivdovd.Image = global::ArecaIPIS.Properties.Resources._9081024_layout_board_icon;
            this.btnivdovd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnivdovd.Location = new System.Drawing.Point(0, 233);
            this.btnivdovd.Name = "btnivdovd";
            this.btnivdovd.Size = new System.Drawing.Size(216, 76);
            this.btnivdovd.TabIndex = 3;
            this.btnivdovd.Text = "IVD/OVD";
            this.btnivdovd.UseVisualStyleBackColor = false;
            this.btnivdovd.Click += new System.EventHandler(this.btnivdovd_Click);
            // 
            // btnCgdb
            // 
            this.btnCgdb.BackColor = System.Drawing.Color.Green;
            this.btnCgdb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnCgdb.ForeColor = System.Drawing.Color.Honeydew;
            this.btnCgdb.Image = global::ArecaIPIS.Properties.Resources._9081024_layout_board_icon;
            this.btnCgdb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCgdb.Location = new System.Drawing.Point(0, 156);
            this.btnCgdb.Name = "btnCgdb";
            this.btnCgdb.Size = new System.Drawing.Size(216, 76);
            this.btnCgdb.TabIndex = 2;
            this.btnCgdb.Text = "CGDB";
            this.btnCgdb.UseVisualStyleBackColor = false;
            this.btnCgdb.Click += new System.EventHandler(this.btnCgdb_Click);
            // 
            // btnTADB
            // 
            this.btnTADB.BackColor = System.Drawing.Color.Green;
            this.btnTADB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnTADB.ForeColor = System.Drawing.Color.Honeydew;
            this.btnTADB.Image = global::ArecaIPIS.Properties.Resources._9081024_layout_board_icon;
            this.btnTADB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTADB.Location = new System.Drawing.Point(0, 78);
            this.btnTADB.Name = "btnTADB";
            this.btnTADB.Size = new System.Drawing.Size(216, 76);
            this.btnTADB.TabIndex = 1;
            this.btnTADB.Text = "TADDB";
            this.btnTADB.UseVisualStyleBackColor = false;
            this.btnTADB.Click += new System.EventHandler(this.btnTADB_Click);
            // 
            // btnCds
            // 
            this.btnCds.BackColor = System.Drawing.Color.Green;
            this.btnCds.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCds.ForeColor = System.Drawing.Color.Honeydew;
            this.btnCds.Image = global::ArecaIPIS.Properties.Resources.settings;
            this.btnCds.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCds.Location = new System.Drawing.Point(0, 3);
            this.btnCds.Name = "btnCds";
            this.btnCds.Size = new System.Drawing.Size(216, 76);
            this.btnCds.TabIndex = 0;
            this.btnCds.Text = "CDS";
            this.btnCds.UseVisualStyleBackColor = false;
            this.btnCds.Click += new System.EventHandler(this.btnCds_Click);
            // 
            // panBoardforms
            // 
            this.panBoardforms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panBoardforms.Location = new System.Drawing.Point(242, 12);
            this.panBoardforms.Name = "panBoardforms";
            this.panBoardforms.Size = new System.Drawing.Size(1047, 437);
            this.panBoardforms.TabIndex = 2;
            // 
            // lblBoardDiagnosis
            // 
            this.lblBoardDiagnosis.AutoSize = true;
            this.lblBoardDiagnosis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardDiagnosis.ForeColor = System.Drawing.Color.Red;
            this.lblBoardDiagnosis.Location = new System.Drawing.Point(2, 1);
            this.lblBoardDiagnosis.Name = "lblBoardDiagnosis";
            this.lblBoardDiagnosis.Size = new System.Drawing.Size(162, 24);
            this.lblBoardDiagnosis.TabIndex = 4;
            this.lblBoardDiagnosis.Text = "Board Diagnosis";
            // 
            // panline
            // 
            this.panline.BackColor = System.Drawing.Color.RosyBrown;
            this.panline.Location = new System.Drawing.Point(230, 11);
            this.panline.Name = "panline";
            this.panline.Size = new System.Drawing.Size(7, 400);
            this.panline.TabIndex = 5;
            // 
            // frmBoardDiagnosis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1358, 548);
            this.Controls.Add(this.panline);
            this.Controls.Add(this.lblBoardDiagnosis);
            this.Controls.Add(this.panButtons);
            this.Controls.Add(this.panBoardforms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBoardDiagnosis";
            this.Text = "frmBoardDiagnosis";
            this.Load += new System.EventHandler(this.frmBoardDiagnosis_Load);
            this.panButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panButtons;
        private System.Windows.Forms.Button btnivdovd;
        private System.Windows.Forms.Button btnCgdb;
        private System.Windows.Forms.Button btnTADB;
        private System.Windows.Forms.Button btnCds;
        private System.Windows.Forms.Panel panBoardforms;
        private System.Windows.Forms.Label lblBoardDiagnosis;
        private System.Windows.Forms.Panel panline;
    }
}