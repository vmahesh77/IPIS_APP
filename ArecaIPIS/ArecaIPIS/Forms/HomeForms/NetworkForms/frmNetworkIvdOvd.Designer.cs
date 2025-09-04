
namespace ArecaIPIS.Forms
{
    partial class frmNetworkIvdOvd
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
            this.lblIvdOvd = new System.Windows.Forms.Label();
            this.panCommunication = new System.Windows.Forms.Panel();
            this.dgvCommunication = new System.Windows.Forms.DataGridView();
            this.dgvBoardLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBoardIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvConfiguration = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panCommunication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIvdOvd
            // 
            this.lblIvdOvd.AutoSize = true;
            this.lblIvdOvd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIvdOvd.ForeColor = System.Drawing.Color.Ivory;
            this.lblIvdOvd.Location = new System.Drawing.Point(3, 7);
            this.lblIvdOvd.Name = "lblIvdOvd";
            this.lblIvdOvd.Size = new System.Drawing.Size(340, 25);
            this.lblIvdOvd.TabIndex = 0;
            this.lblIvdOvd.Text = "IVD /OVD Display Boards Links";
            // 
            // panCommunication
            // 
            this.panCommunication.BackColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Controls.Add(this.lblIvdOvd);
            this.panCommunication.ForeColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Location = new System.Drawing.Point(2, 1);
            this.panCommunication.Name = "panCommunication";
            this.panCommunication.Size = new System.Drawing.Size(1007, 37);
            this.panCommunication.TabIndex = 5;
            // 
            // dgvCommunication
            // 
            this.dgvCommunication.AllowUserToAddRows = false;
            this.dgvCommunication.AllowUserToDeleteRows = false;
            this.dgvCommunication.AllowUserToResizeColumns = false;
            this.dgvCommunication.AllowUserToResizeRows = false;
            this.dgvCommunication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommunication.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommunication.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCommunication.ColumnHeadersHeight = 42;
            this.dgvCommunication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCommunication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvBoardLocation,
            this.dgvLines,
            this.dgvPortNo,
            this.dgvId,
            this.dgvBoardIP,
            this.dgvConfiguration});
            this.dgvCommunication.EnableHeadersVisualStyles = false;
            this.dgvCommunication.Location = new System.Drawing.Point(2, 44);
            this.dgvCommunication.Name = "dgvCommunication";
            this.dgvCommunication.RowHeadersVisible = false;
            this.dgvCommunication.Size = new System.Drawing.Size(1007, 305);
            this.dgvCommunication.TabIndex = 9;
            // 
            // dgvBoardLocation
            // 
            this.dgvBoardLocation.HeaderText = "Board Location";
            this.dgvBoardLocation.Name = "dgvBoardLocation";
            this.dgvBoardLocation.ReadOnly = true;
            // 
            // dgvLines
            // 
            this.dgvLines.HeaderText = "Lines";
            this.dgvLines.Name = "dgvLines";
            // 
            // dgvPortNo
            // 
            this.dgvPortNo.HeaderText = "PORT No";
            this.dgvPortNo.Name = "dgvPortNo";
            // 
            // dgvId
            // 
            this.dgvId.HeaderText = "ID";
            this.dgvId.Name = "dgvId";
            this.dgvId.ReadOnly = true;
            // 
            // dgvBoardIP
            // 
            this.dgvBoardIP.HeaderText = "Board IP";
            this.dgvBoardIP.Name = "dgvBoardIP";
            // 
            // dgvConfiguration
            // 
            this.dgvConfiguration.HeaderText = "Configuration";
            this.dgvConfiguration.Name = "dgvConfiguration";
            this.dgvConfiguration.ReadOnly = true;
            this.dgvConfiguration.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConfiguration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmNetworkIvdOvd
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1020, 408);
            this.Controls.Add(this.dgvCommunication);
            this.Controls.Add(this.panCommunication);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNetworkIvdOvd";
            this.Text = "frmNetworkIVDOVD";
            this.Load += new System.EventHandler(this.frmNetworkIvdOvd_Load);
            this.panCommunication.ResumeLayout(false);
            this.panCommunication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIvdOvd;
        private System.Windows.Forms.Panel panCommunication;
        private System.Windows.Forms.DataGridView dgvCommunication;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBoardLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBoardIP;
        private System.Windows.Forms.DataGridViewButtonColumn dgvConfiguration;
    }
}