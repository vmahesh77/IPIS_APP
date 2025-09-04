
namespace ArecaIPIS.Forms.CommonForms
{
    partial class frmKeyBoard
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
            this.panKeyBoard = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBackSpace = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panKeyBoard
            // 
            this.panKeyBoard.AutoScroll = true;
            this.panKeyBoard.AutoSize = true;
            this.panKeyBoard.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panKeyBoard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panKeyBoard.Location = new System.Drawing.Point(2, 55);
            this.panKeyBoard.Name = "panKeyBoard";
            this.panKeyBoard.Size = new System.Drawing.Size(705, 384);
            this.panKeyBoard.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnBackSpace);
            this.panel1.Controls.Add(this.cmbLanguage);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 46);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.GhostWhite;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(328, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 47);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClear.Image = global::ArecaIPIS.Properties.Resources._9004772_cross_delete_cancel_remove_icon;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(423, 1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(107, 46);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnBackSpace
            // 
            this.btnBackSpace.BackColor = System.Drawing.Color.AliceBlue;
            this.btnBackSpace.FlatAppearance.BorderSize = 0;
            this.btnBackSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackSpace.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBackSpace.Image = global::ArecaIPIS.Properties.Resources._9110942_arrow_left_icon__2_;
            this.btnBackSpace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackSpace.Location = new System.Drawing.Point(544, 0);
            this.btnBackSpace.Name = "btnBackSpace";
            this.btnBackSpace.Size = new System.Drawing.Size(140, 46);
            this.btnBackSpace.TabIndex = 5;
            this.btnBackSpace.Text = "backspace";
            this.btnBackSpace.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackSpace.UseVisualStyleBackColor = false;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownHeight = 85;
            this.cmbLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanguage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.IntegralHeight = false;
            this.cmbLanguage.ItemHeight = 20;
            this.cmbLanguage.Items.AddRange(new object[] {
            "Hindi",
            "Assamese",
            "Bengali",
            "Farsi",
            "Gujarathi",
            "Devanagari",
            "Kannada",
            "Malayalam",
            "MIsc.Symbols",
            "Marathi",
            "Punjabi",
            "Tamil",
            "Telugu",
            "Oriya",
            "United Kingdom",
            "Urdu",
            "Urdu Phonetic",
            "Us Standard",
            "Us International",
            "English"});
            this.cmbLanguage.Location = new System.Drawing.Point(5, 11);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(164, 28);
            this.cmbLanguage.TabIndex = 4;
            this.cmbLanguage.Text = "English";
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // frmKeyBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(711, 451);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panKeyBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKeyBoard";
            this.Text = "frmKeyBoard";
            this.Load += new System.EventHandler(this.frmKeyBoard_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panKeyBoard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBackSpace;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button btnClose;
    }
}