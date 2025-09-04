
namespace ArecaIPIS
{
    partial class frmKeyboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlLanguage = new System.Windows.Forms.Panel();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.pnlKeyboard = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnlLanguage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlLanguage);
            this.panel1.Controls.Add(this.pnlKeyboard);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 221);
            this.panel1.TabIndex = 4;
            // 
            // pnlLanguage
            // 
            this.pnlLanguage.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlLanguage.Controls.Add(this.cmbLanguage);
            this.pnlLanguage.Location = new System.Drawing.Point(0, -1);
            this.pnlLanguage.Name = "pnlLanguage";
            this.pnlLanguage.Size = new System.Drawing.Size(466, 33);
            this.pnlLanguage.TabIndex = 2;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(6, 5);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 21);
            this.cmbLanguage.TabIndex = 0;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // pnlKeyboard
            // 
            this.pnlKeyboard.Location = new System.Drawing.Point(0, 32);
            this.pnlKeyboard.Name = "pnlKeyboard";
            this.pnlKeyboard.Size = new System.Drawing.Size(466, 186);
            this.pnlKeyboard.TabIndex = 1;
          
            // 
            // frmKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 222);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKeyboard";
            this.Text = "frmKeyboard";
            this.Load += new System.EventHandler(this.frmKeyboard_Load);
            this.panel1.ResumeLayout(false);
            this.pnlLanguage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlLanguage;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Panel pnlKeyboard;
    }
}