
namespace ArecaIPIS.Forms
{
    partial class frmCreateStation
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
            this.lblStationCode = new System.Windows.Forms.Label();
            this.lblEnglish = new System.Windows.Forms.Label();
            this.lblHindi = new System.Windows.Forms.Label();
            this.lblRegional = new System.Windows.Forms.Label();
            this.txtStationCode = new System.Windows.Forms.TextBox();
            this.txtHindiName = new System.Windows.Forms.TextBox();
            this.txtEnglishName = new System.Windows.Forms.TextBox();
            this.txtRegionalName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCreateStation = new System.Windows.Forms.Label();
            this.lblAudioPath = new System.Windows.Forms.Label();
            this.btnAudioPath = new System.Windows.Forms.Button();
            this.lblNoFileChoosen = new System.Windows.Forms.Label();
            this.lblReq2 = new System.Windows.Forms.Label();
            this.lblReq1 = new System.Windows.Forms.Label();
            this.lblReq3 = new System.Windows.Forms.Label();
            this.lblReq4 = new System.Windows.Forms.Label();
            this.lblNoteDef1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoteDef2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStationCode
            // 
            this.lblStationCode.AutoSize = true;
            this.lblStationCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationCode.Location = new System.Drawing.Point(32, 53);
            this.lblStationCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStationCode.Name = "lblStationCode";
            this.lblStationCode.Size = new System.Drawing.Size(114, 20);
            this.lblStationCode.TabIndex = 0;
            this.lblStationCode.Text = "Station Code";
            // 
            // lblEnglish
            // 
            this.lblEnglish.AutoSize = true;
            this.lblEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnglish.Location = new System.Drawing.Point(32, 107);
            this.lblEnglish.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Size = new System.Drawing.Size(68, 20);
            this.lblEnglish.TabIndex = 1;
            this.lblEnglish.Text = "English";
            // 
            // lblHindi
            // 
            this.lblHindi.AutoSize = true;
            this.lblHindi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHindi.Location = new System.Drawing.Point(32, 157);
            this.lblHindi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHindi.Name = "lblHindi";
            this.lblHindi.Size = new System.Drawing.Size(50, 20);
            this.lblHindi.TabIndex = 2;
            this.lblHindi.Text = "Hindi";
            // 
            // lblRegional
            // 
            this.lblRegional.AutoSize = true;
            this.lblRegional.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegional.Location = new System.Drawing.Point(32, 219);
            this.lblRegional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegional.Name = "lblRegional";
            this.lblRegional.Size = new System.Drawing.Size(80, 20);
            this.lblRegional.TabIndex = 4;
            this.lblRegional.Text = "Regional";
            // 
            // txtStationCode
            // 
            this.txtStationCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStationCode.Location = new System.Drawing.Point(163, 53);
            this.txtStationCode.MaxLength = 4;
            this.txtStationCode.Name = "txtStationCode";
            this.txtStationCode.Size = new System.Drawing.Size(270, 29);
            this.txtStationCode.TabIndex = 1;
            this.txtStationCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStationCode_KeyPress);
            // 
            // txtHindiName
            // 
            this.txtHindiName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHindiName.Location = new System.Drawing.Point(163, 157);
            this.txtHindiName.Name = "txtHindiName";
            this.txtHindiName.Size = new System.Drawing.Size(270, 35);
            this.txtHindiName.TabIndex = 3;
            this.txtHindiName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHindiName_KeyPress);
            // 
            // txtEnglishName
            // 
            this.txtEnglishName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnglishName.Location = new System.Drawing.Point(163, 107);
            this.txtEnglishName.Name = "txtEnglishName";
            this.txtEnglishName.Size = new System.Drawing.Size(270, 35);
            this.txtEnglishName.TabIndex = 2;
            this.txtEnglishName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEnglishName_KeyPress);
            // 
            // txtRegionalName
            // 
            this.txtRegionalName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegionalName.Location = new System.Drawing.Point(163, 207);
            this.txtRegionalName.Name = "txtRegionalName";
            this.txtRegionalName.Size = new System.Drawing.Size(270, 35);
            this.txtRegionalName.TabIndex = 4;
            this.txtRegionalName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegional_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.lblCreateStation);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 32);
            this.panel1.TabIndex = 9;
            // 
            // lblCreateStation
            // 
            this.lblCreateStation.AutoSize = true;
            this.lblCreateStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateStation.Location = new System.Drawing.Point(9, 5);
            this.lblCreateStation.Name = "lblCreateStation";
            this.lblCreateStation.Size = new System.Drawing.Size(140, 24);
            this.lblCreateStation.TabIndex = 0;
            this.lblCreateStation.Text = "Create Station";
            // 
            // lblAudioPath
            // 
            this.lblAudioPath.AutoSize = true;
            this.lblAudioPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudioPath.Location = new System.Drawing.Point(32, 260);
            this.lblAudioPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAudioPath.Name = "lblAudioPath";
            this.lblAudioPath.Size = new System.Drawing.Size(97, 20);
            this.lblAudioPath.TabIndex = 10;
            this.lblAudioPath.Text = "Audio Path";
            // 
            // btnAudioPath
            // 
            this.btnAudioPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAudioPath.Location = new System.Drawing.Point(163, 253);
            this.btnAudioPath.Name = "btnAudioPath";
            this.btnAudioPath.Size = new System.Drawing.Size(107, 29);
            this.btnAudioPath.TabIndex = 5;
            this.btnAudioPath.Text = "Choose File";
            this.btnAudioPath.UseVisualStyleBackColor = true;
            this.btnAudioPath.Click += new System.EventHandler(this.btnAudioPath_Click);
            // 
            // lblNoFileChoosen
            // 
            this.lblNoFileChoosen.AutoSize = true;
            this.lblNoFileChoosen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoFileChoosen.Location = new System.Drawing.Point(285, 263);
            this.lblNoFileChoosen.Name = "lblNoFileChoosen";
            this.lblNoFileChoosen.Size = new System.Drawing.Size(108, 16);
            this.lblNoFileChoosen.TabIndex = 12;
            this.lblNoFileChoosen.Text = "No File Choosen";
            // 
            // lblReq2
            // 
            this.lblReq2.AutoSize = true;
            this.lblReq2.BackColor = System.Drawing.Color.White;
            this.lblReq2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq2.ForeColor = System.Drawing.Color.Red;
            this.lblReq2.Location = new System.Drawing.Point(12, 107);
            this.lblReq2.Name = "lblReq2";
            this.lblReq2.Size = new System.Drawing.Size(18, 24);
            this.lblReq2.TabIndex = 13;
            this.lblReq2.Text = "*";
            // 
            // lblReq1
            // 
            this.lblReq1.AutoSize = true;
            this.lblReq1.BackColor = System.Drawing.Color.White;
            this.lblReq1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq1.ForeColor = System.Drawing.Color.Red;
            this.lblReq1.Location = new System.Drawing.Point(12, 53);
            this.lblReq1.Name = "lblReq1";
            this.lblReq1.Size = new System.Drawing.Size(18, 24);
            this.lblReq1.TabIndex = 14;
            this.lblReq1.Text = "*";
            this.lblReq1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblReq3
            // 
            this.lblReq3.AutoSize = true;
            this.lblReq3.BackColor = System.Drawing.Color.White;
            this.lblReq3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq3.ForeColor = System.Drawing.Color.Red;
            this.lblReq3.Location = new System.Drawing.Point(12, 154);
            this.lblReq3.Name = "lblReq3";
            this.lblReq3.Size = new System.Drawing.Size(18, 24);
            this.lblReq3.TabIndex = 15;
            this.lblReq3.Text = "*";
            // 
            // lblReq4
            // 
            this.lblReq4.AutoSize = true;
            this.lblReq4.BackColor = System.Drawing.Color.White;
            this.lblReq4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq4.ForeColor = System.Drawing.Color.Red;
            this.lblReq4.Location = new System.Drawing.Point(12, 333);
            this.lblReq4.Name = "lblReq4";
            this.lblReq4.Size = new System.Drawing.Size(80, 24);
            this.lblReq4.TabIndex = 16;
            this.lblReq4.Text = "* Note :";
            // 
            // lblNoteDef1
            // 
            this.lblNoteDef1.AutoSize = true;
            this.lblNoteDef1.Location = new System.Drawing.Point(98, 339);
            this.lblNoteDef1.Name = "lblNoteDef1";
            this.lblNoteDef1.Size = new System.Drawing.Size(493, 48);
            this.lblNoteDef1.TabIndex = 17;
            this.lblNoteDef1.Text = "Please Upload Wav/Mp3 files,&nbsp; File Size Should be lessthan 2Mb.\r\n\r\nAsterisk " +
    "(";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(168, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "*";
            // 
            // lblNoteDef2
            // 
            this.lblNoteDef2.AutoSize = true;
            this.lblNoteDef2.Location = new System.Drawing.Point(183, 372);
            this.lblNoteDef2.Name = "lblNoteDef2";
            this.lblNoteDef2.Size = new System.Drawing.Size(156, 16);
            this.lblNoteDef2.TabIndex = 19;
            this.lblNoteDef2.Text = ") Fields Are Required";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(347, 402);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 32);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(449, 402);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 32);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCreateStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(622, 446);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblNoteDef2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNoteDef1);
            this.Controls.Add(this.lblReq4);
            this.Controls.Add(this.lblReq3);
            this.Controls.Add(this.lblReq1);
            this.Controls.Add(this.lblReq2);
            this.Controls.Add(this.lblNoFileChoosen);
            this.Controls.Add(this.btnAudioPath);
            this.Controls.Add(this.lblAudioPath);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRegionalName);
            this.Controls.Add(this.txtEnglishName);
            this.Controls.Add(this.txtHindiName);
            this.Controls.Add(this.txtStationCode);
            this.Controls.Add(this.lblRegional);
            this.Controls.Add(this.lblHindi);
            this.Controls.Add(this.lblEnglish);
            this.Controls.Add(this.lblStationCode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCreateStation";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCreateStation";
            this.Load += new System.EventHandler(this.frmCreateStation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStationCode;
        private System.Windows.Forms.Label lblEnglish;
        private System.Windows.Forms.Label lblHindi;
        private System.Windows.Forms.Label lblRegional;
        private System.Windows.Forms.TextBox txtStationCode;
        private System.Windows.Forms.TextBox txtHindiName;
        private System.Windows.Forms.TextBox txtEnglishName;
        private System.Windows.Forms.TextBox txtRegionalName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCreateStation;
        private System.Windows.Forms.Label lblAudioPath;
        private System.Windows.Forms.Button btnAudioPath;
        private System.Windows.Forms.Label lblNoFileChoosen;
        private System.Windows.Forms.Label lblReq2;
        private System.Windows.Forms.Label lblReq1;
        private System.Windows.Forms.Label lblReq3;
        private System.Windows.Forms.Label lblReq4;
        private System.Windows.Forms.Label lblNoteDef1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNoteDef2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}