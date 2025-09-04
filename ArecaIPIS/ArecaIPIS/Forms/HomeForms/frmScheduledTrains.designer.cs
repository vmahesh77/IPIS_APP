
namespace ArecaIPIS.Forms.HomeForms
{
    partial class frmScheduledTrains
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduledTrains));
            this.dgvScheduledRunningTrains = new System.Windows.Forms.DataGridView();
            this.dgvTrainNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTrainName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvArrTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDeptTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblSelectTrain = new System.Windows.Forms.Label();
            this.rtxtSerachHere = new System.Windows.Forms.RichTextBox();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduledRunningTrains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvScheduledRunningTrains
            // 
            this.dgvScheduledRunningTrains.AllowUserToResizeColumns = false;
            this.dgvScheduledRunningTrains.AllowUserToResizeRows = false;
            this.dgvScheduledRunningTrains.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScheduledRunningTrains.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScheduledRunningTrains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScheduledRunningTrains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvTrainNo,
            this.dgvCategory,
            this.dgvTrainName,
            this.dgvSource,
            this.dgvDestination,
            this.dgvArrTime,
            this.dgvDeptTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvScheduledRunningTrains.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScheduledRunningTrains.Location = new System.Drawing.Point(12, 112);
            this.dgvScheduledRunningTrains.Name = "dgvScheduledRunningTrains";
            this.dgvScheduledRunningTrains.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScheduledRunningTrains.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvScheduledRunningTrains.RowHeadersVisible = false;
            this.dgvScheduledRunningTrains.Size = new System.Drawing.Size(1054, 302);
            this.dgvScheduledRunningTrains.TabIndex = 0;
            this.dgvScheduledRunningTrains.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScheduledRunningTrains_CellClick);
            this.dgvScheduledRunningTrains.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScheduledRunningTrains_CellContentClick);
            // 
            // dgvTrainNo
            // 
            this.dgvTrainNo.HeaderText = "Train No";
            this.dgvTrainNo.Name = "dgvTrainNo";
            this.dgvTrainNo.ReadOnly = true;
            this.dgvTrainNo.Width = 150;
            // 
            // dgvCategory
            // 
            this.dgvCategory.HeaderText = "Category";
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.ReadOnly = true;
            this.dgvCategory.Width = 150;
            // 
            // dgvTrainName
            // 
            this.dgvTrainName.HeaderText = "Train Name";
            this.dgvTrainName.Name = "dgvTrainName";
            this.dgvTrainName.ReadOnly = true;
            this.dgvTrainName.Width = 150;
            // 
            // dgvSource
            // 
            this.dgvSource.HeaderText = "Source";
            this.dgvSource.Name = "dgvSource";
            this.dgvSource.ReadOnly = true;
            this.dgvSource.Width = 150;
            // 
            // dgvDestination
            // 
            this.dgvDestination.HeaderText = "Destination";
            this.dgvDestination.Name = "dgvDestination";
            this.dgvDestination.ReadOnly = true;
            this.dgvDestination.Width = 150;
            // 
            // dgvArrTime
            // 
            this.dgvArrTime.HeaderText = "Arr.Time";
            this.dgvArrTime.Name = "dgvArrTime";
            this.dgvArrTime.ReadOnly = true;
            this.dgvArrTime.Width = 150;
            // 
            // dgvDeptTime
            // 
            this.dgvDeptTime.HeaderText = "Dept.Time";
            this.dgvDeptTime.Name = "dgvDeptTime";
            this.dgvDeptTime.ReadOnly = true;
            this.dgvDeptTime.Width = 150;
            // 
            // trainsBindingSource
            // 
            this.trainsBindingSource.DataMember = "Trains";
            // 
            // lblSelectTrain
            // 
            this.lblSelectTrain.AutoSize = true;
            this.lblSelectTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectTrain.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSelectTrain.Location = new System.Drawing.Point(29, 58);
            this.lblSelectTrain.Name = "lblSelectTrain";
            this.lblSelectTrain.Size = new System.Drawing.Size(142, 24);
            this.lblSelectTrain.TabIndex = 1;
            this.lblSelectTrain.Text = "Select A Train";
            // 
            // rtxtSerachHere
            // 
            this.rtxtSerachHere.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtSerachHere.Location = new System.Drawing.Point(776, 49);
            this.rtxtSerachHere.Name = "rtxtSerachHere";
            this.rtxtSerachHere.Size = new System.Drawing.Size(151, 33);
            this.rtxtSerachHere.TabIndex = 2;
            this.rtxtSerachHere.Text = "Search Here";
            this.rtxtSerachHere.Click += new System.EventHandler(this.rtxtSerachHere_Click);
            this.rtxtSerachHere.TextChanged += new System.EventHandler(this.rtxtSerachHere_TextChanged);
            // 
            // pnlImage
            // 
            this.pnlImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlImage.BackgroundImage")));
            this.pnlImage.Location = new System.Drawing.Point(931, 49);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(33, 33);
            this.pnlImage.TabIndex = 3;
            this.pnlImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlImage_Paint);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnClose.Location = new System.Drawing.Point(1094, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 21);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmScheduledTrains
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1121, 426);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlImage);
            this.Controls.Add(this.rtxtSerachHere);
            this.Controls.Add(this.lblSelectTrain);
            this.Controls.Add(this.dgvScheduledRunningTrains);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmScheduledTrains";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmScheduledTrains";
            this.Deactivate += new System.EventHandler(this.frmScheduledTrains_Deactivate);
            this.Load += new System.EventHandler(this.frmScheduledTrains_Load);
            this.Leave += new System.EventHandler(this.frmScheduledTrains_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduledRunningTrains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvScheduledRunningTrains;
       // private ARECA_IPIS_DBDataSet aRECA_IPIS_DBDataSet;
        private System.Windows.Forms.BindingSource trainsBindingSource;
      //  private ARECA_IPIS_DBDataSetTableAdapters.TrainsTableAdapter trainsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTrainNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTrainName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvArrTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDeptTime;
        private System.Windows.Forms.Label lblSelectTrain;
        private System.Windows.Forms.RichTextBox rtxtSerachHere;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.Button btnClose;
    }
}