
namespace ArecaIPIS.Forms
{
    partial class frmNetworkTadb
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
            this.lblTrainArrival = new System.Windows.Forms.Label();
            this.panCommunication = new System.Windows.Forms.Panel();
            this.dgvCommunication = new System.Windows.Forms.DataGridView();
            this.dgvBoardLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBoardIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvConfiguration = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panCommunication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTrainArrival
            // 
            this.lblTrainArrival.AutoSize = true;
            this.lblTrainArrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainArrival.ForeColor = System.Drawing.Color.Ivory;
            this.lblTrainArrival.Location = new System.Drawing.Point(3, 7);
            this.lblTrainArrival.Name = "lblTrainArrival";
            this.lblTrainArrival.Size = new System.Drawing.Size(481, 25);
            this.lblTrainArrival.TabIndex = 0;
            this.lblTrainArrival.Text = "Train Arrival Departure Display Boards Links";
            // 
            // panCommunication
            // 
            this.panCommunication.BackColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Controls.Add(this.lblTrainArrival);
            this.panCommunication.ForeColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Location = new System.Drawing.Point(0, 3);
            this.panCommunication.Name = "panCommunication";
            this.panCommunication.Size = new System.Drawing.Size(1238, 37);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommunication.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCommunication.ColumnHeadersHeight = 35;
            this.dgvCommunication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCommunication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvBoardLocation,
            this.dgvLines,
            this.dgvPortNo,
            this.dgvID,
            this.dgvBoardIP,
            this.dgvConfiguration});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommunication.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCommunication.EnableHeadersVisualStyles = false;
            this.dgvCommunication.Location = new System.Drawing.Point(0, 38);
            this.dgvCommunication.MultiSelect = false;
            this.dgvCommunication.Name = "dgvCommunication";
            this.dgvCommunication.RowHeadersVisible = false;
            this.dgvCommunication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommunication.Size = new System.Drawing.Size(1018, 290);
            this.dgvCommunication.TabIndex = 7;
            // 
            // dgvBoardLocation
            // 
            this.dgvBoardLocation.FillWeight = 182.7411F;
            this.dgvBoardLocation.HeaderText = "Board Location";
            this.dgvBoardLocation.Name = "dgvBoardLocation";
            this.dgvBoardLocation.ReadOnly = true;
            // 
            // dgvLines
            // 
            this.dgvLines.FillWeight = 59.74849F;
            this.dgvLines.HeaderText = "Lines";
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.ReadOnly = true;
            // 
            // dgvPortNo
            // 
            this.dgvPortNo.FillWeight = 115.5867F;
            this.dgvPortNo.HeaderText = "PORT No";
            this.dgvPortNo.Name = "dgvPortNo";
            this.dgvPortNo.ReadOnly = true;
            // 
            // dgvID
            // 
            this.dgvID.FillWeight = 53.68833F;
            this.dgvID.HeaderText = "ID";
            this.dgvID.Name = "dgvID";
            this.dgvID.ReadOnly = true;
            // 
            // dgvBoardIP
            // 
            this.dgvBoardIP.FillWeight = 114.9353F;
            this.dgvBoardIP.HeaderText = "Board IP";
            this.dgvBoardIP.Name = "dgvBoardIP";
            this.dgvBoardIP.ReadOnly = true;
            // 
            // dgvConfiguration
            // 
            this.dgvConfiguration.FillWeight = 96.09003F;
            this.dgvConfiguration.HeaderText = "Configuration";
            this.dgvConfiguration.Name = "dgvConfiguration";
            this.dgvConfiguration.ReadOnly = true;
            this.dgvConfiguration.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConfiguration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmNetworkTadb
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1242, 645);
            this.Controls.Add(this.dgvCommunication);
            this.Controls.Add(this.panCommunication);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNetworkTadb";
            this.Text = "frmNetworkTadb";
            this.Load += new System.EventHandler(this.frmNetworkTadb_Load);
            this.panCommunication.ResumeLayout(false);
            this.panCommunication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTrainArrival;
        private System.Windows.Forms.Panel panCommunication;
        private System.Windows.Forms.DataGridView dgvCommunication;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBoardLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBoardIP;
        private System.Windows.Forms.DataGridViewButtonColumn dgvConfiguration;
    }
}