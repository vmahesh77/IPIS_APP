
namespace ArecaIPIS.Forms.UserForms
{
    partial class frmUserGroups
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
            this.lblUserGroups = new System.Windows.Forms.Label();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvgroups = new System.Windows.Forms.DataGridView();
            this.dgvCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvMenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btndropdown = new System.Windows.Forms.Button();
            this.btnSearch1 = new System.Windows.Forms.Button();
            this.btnCross = new System.Windows.Forms.Button();
            this.chkFilter = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvgroups)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserGroups
            // 
            this.lblUserGroups.AutoSize = true;
            this.lblUserGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserGroups.ForeColor = System.Drawing.Color.Red;
            this.lblUserGroups.Location = new System.Drawing.Point(12, 3);
            this.lblUserGroups.Name = "lblUserGroups";
            this.lblUserGroups.Size = new System.Drawing.Size(192, 33);
            this.lblUserGroups.TabIndex = 0;
            this.lblUserGroups.Text = "User Groups";
            // 
            // cmbRoles
            // 
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(12, 41);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(121, 21);
            this.cmbRoles.TabIndex = 1;
            this.cmbRoles.SelectedIndexChanged += new System.EventHandler(this.cmbRoles_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(615, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(164, 26);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1455, 59);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(37, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::ArecaIPIS.Properties.Resources._3844432_magnifier_search_zoom_icon;
            this.btnSearch.Location = new System.Drawing.Point(1418, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(31, 30);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dgvgroups
            // 
            this.dgvgroups.AllowUserToAddRows = false;
            this.dgvgroups.AllowUserToDeleteRows = false;
            this.dgvgroups.AllowUserToResizeColumns = false;
            this.dgvgroups.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Aqua;
            this.dgvgroups.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvgroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvgroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvgroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvgroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCheckBox,
            this.dgvMenu,
            this.dgvForm});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvgroups.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvgroups.EnableHeadersVisualStyles = false;
            this.dgvgroups.Location = new System.Drawing.Point(12, 68);
            this.dgvgroups.Name = "dgvgroups";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvgroups.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvgroups.RowHeadersVisible = false;
            this.dgvgroups.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvgroups.RowTemplate.Height = 50;
            this.dgvgroups.Size = new System.Drawing.Size(859, 300);
            this.dgvgroups.TabIndex = 5;
            // 
            // dgvCheckBox
            // 
            this.dgvCheckBox.FillWeight = 38.07107F;
            this.dgvCheckBox.HeaderText = "";
            this.dgvCheckBox.Name = "dgvCheckBox";
            // 
            // dgvMenu
            // 
            this.dgvMenu.FillWeight = 130.9645F;
            this.dgvMenu.HeaderText = "Menu";
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.ReadOnly = true;
            // 
            // dgvForm
            // 
            this.dgvForm.FillWeight = 130.9645F;
            this.dgvForm.HeaderText = "Form Name";
            this.dgvForm.Name = "dgvForm";
            this.dgvForm.ReadOnly = true;
            this.dgvForm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvForm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(941, 322);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 46);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btndropdown
            // 
            this.btndropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btndropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndropdown.Image = global::ArecaIPIS.Properties.Resources.descending_down;
            this.btndropdown.Location = new System.Drawing.Point(825, 31);
            this.btndropdown.Name = "btndropdown";
            this.btndropdown.Size = new System.Drawing.Size(46, 31);
            this.btndropdown.TabIndex = 8;
            this.btndropdown.UseVisualStyleBackColor = false;
            this.btndropdown.Click += new System.EventHandler(this.btndropdown_Click);
            // 
            // btnSearch1
            // 
            this.btnSearch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch1.Image = global::ArecaIPIS.Properties.Resources._352091_search_icon;
            this.btnSearch1.Location = new System.Drawing.Point(779, 31);
            this.btnSearch1.Name = "btnSearch1";
            this.btnSearch1.Size = new System.Drawing.Size(46, 31);
            this.btnSearch1.TabIndex = 9;
            this.btnSearch1.UseVisualStyleBackColor = false;
            this.btnSearch1.Click += new System.EventHandler(this.btnSearch1_Click);
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnCross.Location = new System.Drawing.Point(779, 31);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(46, 31);
            this.btnCross.TabIndex = 10;
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Visible = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // chkFilter
            // 
            this.chkFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chkFilter.FormattingEnabled = true;
            this.chkFilter.Location = new System.Drawing.Point(770, 68);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(101, 49);
            this.chkFilter.TabIndex = 32;
            this.chkFilter.Visible = false;
            // 
            // frmUserGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 509);
            this.Controls.Add(this.chkFilter);
            this.Controls.Add(this.btndropdown);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvgroups);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbRoles);
            this.Controls.Add(this.lblUserGroups);
            this.Controls.Add(this.btnSearch1);
            this.Controls.Add(this.btnCross);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserGroups";
            this.Text = "frmUserGroups";
            this.Load += new System.EventHandler(this.frmUserGroups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvgroups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserGroups;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridView dgvgroups;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvForm;
        private System.Windows.Forms.Button btndropdown;
        private System.Windows.Forms.Button btnSearch1;
        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.CheckedListBox chkFilter;
    }
}