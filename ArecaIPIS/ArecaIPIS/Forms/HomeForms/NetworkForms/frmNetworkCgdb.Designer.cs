
namespace ArecaIPIS.Forms
{
    partial class frmNetworkCgdb
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCoachGuidance = new System.Windows.Forms.Label();
            this.panCommunication = new System.Windows.Forms.Panel();
            this.dgvCommunication = new System.Windows.Forms.DataGridView();
            this.dgvPortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCoachId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHubId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPdcIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvConfiguration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panCommunication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCoachGuidance
            // 
            this.lblCoachGuidance.AutoSize = true;
            this.lblCoachGuidance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoachGuidance.ForeColor = System.Drawing.Color.Ivory;
            this.lblCoachGuidance.Location = new System.Drawing.Point(3, 7);
            this.lblCoachGuidance.Name = "lblCoachGuidance";
            this.lblCoachGuidance.Size = new System.Drawing.Size(403, 25);
            this.lblCoachGuidance.TabIndex = 0;
            this.lblCoachGuidance.Text = "Coach Guidance Display Board Links";
            // 
            // panCommunication
            // 
            this.panCommunication.BackColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Controls.Add(this.lblCoachGuidance);
            this.panCommunication.ForeColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Location = new System.Drawing.Point(2, 3);
            this.panCommunication.Name = "panCommunication";
            this.panCommunication.Size = new System.Drawing.Size(997, 37);
            this.panCommunication.TabIndex = 3;
            // 
            // dgvCommunication
            // 
            this.dgvCommunication.AllowUserToAddRows = false;
            this.dgvCommunication.AllowUserToResizeColumns = false;
            this.dgvCommunication.AllowUserToResizeRows = false;
            this.dgvCommunication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommunication.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCommunication.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommunication.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCommunication.ColumnHeadersHeight = 35;
            this.dgvCommunication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCommunication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPortNo,
            this.dgvCoachId,
            this.dgvHubId,
            this.dgvPdcIp,
            this.dgvConfiguration});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommunication.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCommunication.EnableHeadersVisualStyles = false;
            this.dgvCommunication.Location = new System.Drawing.Point(2, 38);
            this.dgvCommunication.Name = "dgvCommunication";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommunication.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCommunication.RowHeadersVisible = false;
            this.dgvCommunication.Size = new System.Drawing.Size(997, 296);
            this.dgvCommunication.TabIndex = 7;
            // 
            // dgvPortNo
            // 
            this.dgvPortNo.FillWeight = 76.04433F;
            this.dgvPortNo.HeaderText = "PORT No";
            this.dgvPortNo.Name = "dgvPortNo";
            // 
            // dgvCoachId
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.dgvCoachId.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCoachId.FillWeight = 195.4315F;
            this.dgvCoachId.HeaderText = "Coach ID";
            this.dgvCoachId.Name = "dgvCoachId";
            // 
            // dgvHubId
            // 
            this.dgvHubId.FillWeight = 93.30424F;
            this.dgvHubId.HeaderText = "Hub ID";
            this.dgvHubId.Name = "dgvHubId";
            // 
            // dgvPdcIp
            // 
            this.dgvPdcIp.FillWeight = 93.30424F;
            this.dgvPdcIp.HeaderText = "PDC IP";
            this.dgvPdcIp.Name = "dgvPdcIp";
            // 
            // dgvConfiguration
            // 
            this.dgvConfiguration.FillWeight = 93.30424F;
            this.dgvConfiguration.HeaderText = "Configuration";
            this.dgvConfiguration.Name = "dgvConfiguration";
            this.dgvConfiguration.ReadOnly = true;
            // 
            // frmNetworkCgdb
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1007, 645);
            this.Controls.Add(this.dgvCommunication);
            this.Controls.Add(this.panCommunication);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNetworkCgdb";
            this.Text = "frmNetworkCgdb";
            this.Load += new System.EventHandler(this.frmNetworkCgdb_Load);
            this.panCommunication.ResumeLayout(false);
            this.panCommunication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCoachGuidance;
        private System.Windows.Forms.Panel panCommunication;
        private System.Windows.Forms.DataGridView dgvCommunication;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCoachId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHubId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPdcIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvConfiguration;
    }
}