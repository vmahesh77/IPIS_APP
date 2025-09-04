
namespace ArecaIPIS.Forms
{
    partial class frmNetWorkCds
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
            this.lblCommunication = new System.Windows.Forms.Label();
            this.panCommunication = new System.Windows.Forms.Panel();
            this.dgvCommunication = new System.Windows.Forms.DataGridView();
            this.dgvPDCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPdcIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPlatformNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvConfiguration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panCommunication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCommunication
            // 
            this.lblCommunication.AutoSize = true;
            this.lblCommunication.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommunication.ForeColor = System.Drawing.Color.Ivory;
            this.lblCommunication.Location = new System.Drawing.Point(3, 7);
            this.lblCommunication.Name = "lblCommunication";
            this.lblCommunication.Size = new System.Drawing.Size(347, 25);
            this.lblCommunication.TabIndex = 0;
            this.lblCommunication.Text = "Communication Hub Link Status";
            this.lblCommunication.Click += new System.EventHandler(this.lblCommunication_Click);
            // 
            // panCommunication
            // 
            this.panCommunication.BackColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Controls.Add(this.lblCommunication);
            this.panCommunication.ForeColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Location = new System.Drawing.Point(2, 2);
            this.panCommunication.Name = "panCommunication";
            this.panCommunication.Size = new System.Drawing.Size(1015, 37);
            this.panCommunication.TabIndex = 1;
            this.panCommunication.Paint += new System.Windows.Forms.PaintEventHandler(this.panCommunication_Paint);
            // 
            // dgvCommunication
            // 
            this.dgvCommunication.AllowUserToAddRows = false;
            this.dgvCommunication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommunication.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCommunication.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommunication.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCommunication.ColumnHeadersHeight = 53;
            this.dgvCommunication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPDCName,
            this.dgvPortNo,
            this.dgvPdcIp,
            this.dgvPlatformNo,
            this.dgvConfiguration});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommunication.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCommunication.EnableHeadersVisualStyles = false;
            this.dgvCommunication.Location = new System.Drawing.Point(2, 45);
            this.dgvCommunication.Name = "dgvCommunication";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommunication.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCommunication.RowHeadersVisible = false;
            this.dgvCommunication.Size = new System.Drawing.Size(996, 285);
            this.dgvCommunication.TabIndex = 2;
            this.dgvCommunication.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommunication_CellContentClick);
            // 
            // dgvPDCName
            // 
            this.dgvPDCName.FillWeight = 115.9175F;
            this.dgvPDCName.HeaderText = "PDC Name";
            this.dgvPDCName.Name = "dgvPDCName";
            // 
            // dgvPortNo
            // 
            this.dgvPortNo.FillWeight = 104.7523F;
            this.dgvPortNo.HeaderText = "PORT No";
            this.dgvPortNo.Name = "dgvPortNo";
            // 
            // dgvPdcIp
            // 
            this.dgvPdcIp.FillWeight = 101.5228F;
            this.dgvPdcIp.HeaderText = "PDC IP";
            this.dgvPdcIp.Name = "dgvPdcIp";
            // 
            // dgvPlatformNo
            // 
            this.dgvPlatformNo.FillWeight = 73.43288F;
            this.dgvPlatformNo.HeaderText = "Platform No";
            this.dgvPlatformNo.Name = "dgvPlatformNo";
            // 
            // dgvConfiguration
            // 
            this.dgvConfiguration.FillWeight = 104.3744F;
            this.dgvConfiguration.HeaderText = "Configuration";
            this.dgvConfiguration.Name = "dgvConfiguration";
            this.dgvConfiguration.ReadOnly = true;
            // 
            // frmNetWorkCds
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1010, 418);
            this.Controls.Add(this.dgvCommunication);
            this.Controls.Add(this.panCommunication);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNetWorkCds";
            this.Text = "frmCds";
            this.Load += new System.EventHandler(this.frmNetWorkCds_Load);
            this.panCommunication.ResumeLayout(false);
            this.panCommunication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCommunication;
        private System.Windows.Forms.Panel panCommunication;
        private System.Windows.Forms.DataGridView dgvCommunication;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPDCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPdcIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPlatformNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvConfiguration;
    }
}