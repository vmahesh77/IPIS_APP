
namespace ArecaIPIS.Forms
{
    partial class frmBoardConfiguration
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
            this.lblBoardConfiguration = new System.Windows.Forms.Label();
            this.lblAvailableFormats = new System.Windows.Forms.Label();
            this.lblFormatType = new System.Windows.Forms.Label();
            this.lblDisplayFormat = new System.Windows.Forms.Label();
            this.panFormats = new System.Windows.Forms.Panel();
            this.llblFormatName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDisplayFieldGap = new System.Windows.Forms.Label();
            this.lblDisplayFormatType = new System.Windows.Forms.Label();
            this.rtxtformatName = new System.Windows.Forms.RichTextBox();
            this.rtxtDisplayFieldGap = new System.Windows.Forms.RichTextBox();
            this.rtxtBoardWidth = new System.Windows.Forms.RichTextBox();
            this.cmbFormatType = new System.Windows.Forms.ComboBox();
            this.panFormatType = new System.Windows.Forms.Panel();
            this.txtPfType = new System.Windows.Forms.TextBox();
            this.txtADType = new System.Windows.Forms.TextBox();
            this.txtExpTimeType = new System.Windows.Forms.TextBox();
            this.txtTrainNameType = new System.Windows.Forms.TextBox();
            this.txtTrainNumberType = new System.Windows.Forms.TextBox();
            this.txtpfWidth = new System.Windows.Forms.TextBox();
            this.txtADWidth = new System.Windows.Forms.TextBox();
            this.txtExpTimeWidth = new System.Windows.Forms.TextBox();
            this.txtTrainNameWidth = new System.Windows.Forms.TextBox();
            this.txtTrainNumberWidth = new System.Windows.Forms.TextBox();
            this.txtExpTime = new System.Windows.Forms.TextBox();
            this.txtAD = new System.Windows.Forms.TextBox();
            this.txtTrainName = new System.Windows.Forms.TextBox();
            this.txtPfNo = new System.Windows.Forms.TextBox();
            this.txtTrainNumber = new System.Windows.Forms.TextBox();
            this.panFieldType = new System.Windows.Forms.Panel();
            this.lblFieldType = new System.Windows.Forms.Label();
            this.panFieldWidth = new System.Windows.Forms.Panel();
            this.lblFieldWidth = new System.Windows.Forms.Label();
            this.panFieldName = new System.Windows.Forms.Panel();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panFormatType.SuspendLayout();
            this.panFieldType.SuspendLayout();
            this.panFieldWidth.SuspendLayout();
            this.panFieldName.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBoardConfiguration
            // 
            this.lblBoardConfiguration.AutoSize = true;
            this.lblBoardConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardConfiguration.ForeColor = System.Drawing.Color.Red;
            this.lblBoardConfiguration.Location = new System.Drawing.Point(22, 10);
            this.lblBoardConfiguration.Name = "lblBoardConfiguration";
            this.lblBoardConfiguration.Size = new System.Drawing.Size(274, 31);
            this.lblBoardConfiguration.TabIndex = 0;
            this.lblBoardConfiguration.Text = "Board Configuration";
            // 
            // lblAvailableFormats
            // 
            this.lblAvailableFormats.AutoSize = true;
            this.lblAvailableFormats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableFormats.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblAvailableFormats.Location = new System.Drawing.Point(585, 77);
            this.lblAvailableFormats.Name = "lblAvailableFormats";
            this.lblAvailableFormats.Size = new System.Drawing.Size(224, 24);
            this.lblAvailableFormats.TabIndex = 1;
            this.lblAvailableFormats.Text = "Available Display Formats";
            this.lblAvailableFormats.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblFormatType
            // 
            this.lblFormatType.AutoSize = true;
            this.lblFormatType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormatType.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblFormatType.Location = new System.Drawing.Point(48, 77);
            this.lblFormatType.Name = "lblFormatType";
            this.lblFormatType.Size = new System.Drawing.Size(117, 24);
            this.lblFormatType.TabIndex = 2;
            this.lblFormatType.Text = "Format Type";
            this.lblFormatType.Visible = false;
            // 
            // lblDisplayFormat
            // 
            this.lblDisplayFormat.AutoSize = true;
            this.lblDisplayFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayFormat.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblDisplayFormat.Location = new System.Drawing.Point(196, 77);
            this.lblDisplayFormat.Name = "lblDisplayFormat";
            this.lblDisplayFormat.Size = new System.Drawing.Size(250, 24);
            this.lblDisplayFormat.TabIndex = 3;
            this.lblDisplayFormat.Text = "Display Format Configuration";
          
            // 
            // panFormats
            // 
            this.panFormats.AutoScroll = true;
            this.panFormats.BackColor = System.Drawing.Color.White;
            this.panFormats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panFormats.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panFormats.Location = new System.Drawing.Point(599, 107);
            this.panFormats.Name = "panFormats";
            this.panFormats.Size = new System.Drawing.Size(234, 284);
            this.panFormats.TabIndex = 4;
           
            // 
            // llblFormatName
            // 
            this.llblFormatName.AutoSize = true;
            this.llblFormatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblFormatName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.llblFormatName.Location = new System.Drawing.Point(41, 142);
            this.llblFormatName.Name = "llblFormatName";
            this.llblFormatName.Size = new System.Drawing.Size(100, 18);
            this.llblFormatName.TabIndex = 5;
            this.llblFormatName.Text = "Format Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(41, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Board Width";
            // 
            // lblDisplayFieldGap
            // 
            this.lblDisplayFieldGap.AutoSize = true;
            this.lblDisplayFieldGap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayFieldGap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDisplayFieldGap.Location = new System.Drawing.Point(41, 254);
            this.lblDisplayFieldGap.Name = "lblDisplayFieldGap";
            this.lblDisplayFieldGap.Size = new System.Drawing.Size(123, 18);
            this.lblDisplayFieldGap.TabIndex = 7;
            this.lblDisplayFieldGap.Text = "Display Field Gap";
            // 
            // lblDisplayFormatType
            // 
            this.lblDisplayFormatType.AutoSize = true;
            this.lblDisplayFormatType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayFormatType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDisplayFormatType.Location = new System.Drawing.Point(41, 310);
            this.lblDisplayFormatType.Name = "lblDisplayFormatType";
            this.lblDisplayFormatType.Size = new System.Drawing.Size(92, 18);
            this.lblDisplayFormatType.TabIndex = 8;
            this.lblDisplayFormatType.Text = "Format Type";
            // 
            // rtxtformatName
            // 
            this.rtxtformatName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtxtformatName.Location = new System.Drawing.Point(200, 136);
            this.rtxtformatName.Name = "rtxtformatName";
            this.rtxtformatName.Size = new System.Drawing.Size(232, 30);
            this.rtxtformatName.TabIndex = 1;
            this.rtxtformatName.Text = "";
            // 
            // rtxtDisplayFieldGap
            // 
            this.rtxtDisplayFieldGap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtxtDisplayFieldGap.Location = new System.Drawing.Point(200, 248);
            this.rtxtDisplayFieldGap.Name = "rtxtDisplayFieldGap";
            this.rtxtDisplayFieldGap.Size = new System.Drawing.Size(232, 30);
            this.rtxtDisplayFieldGap.TabIndex = 3;
            this.rtxtDisplayFieldGap.Text = "";
            // 
            // rtxtBoardWidth
            // 
            this.rtxtBoardWidth.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtxtBoardWidth.Location = new System.Drawing.Point(200, 192);
            this.rtxtBoardWidth.Name = "rtxtBoardWidth";
            this.rtxtBoardWidth.Size = new System.Drawing.Size(232, 30);
            this.rtxtBoardWidth.TabIndex = 2;
            this.rtxtBoardWidth.Text = "";
            // 
            // cmbFormatType
            // 
            this.cmbFormatType.DropDownHeight = 130;
            this.cmbFormatType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormatType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbFormatType.FormattingEnabled = true;
            this.cmbFormatType.IntegralHeight = false;
            this.cmbFormatType.ItemHeight = 20;
            this.cmbFormatType.Location = new System.Drawing.Point(200, 308);
            this.cmbFormatType.Name = "cmbFormatType";
            this.cmbFormatType.Size = new System.Drawing.Size(232, 28);
            this.cmbFormatType.TabIndex = 4;
            // 
            // panFormatType
            // 
            this.panFormatType.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panFormatType.Controls.Add(this.txtPfType);
            this.panFormatType.Controls.Add(this.txtADType);
            this.panFormatType.Controls.Add(this.txtExpTimeType);
            this.panFormatType.Controls.Add(this.txtTrainNameType);
            this.panFormatType.Controls.Add(this.txtTrainNumberType);
            this.panFormatType.Controls.Add(this.txtpfWidth);
            this.panFormatType.Controls.Add(this.txtADWidth);
            this.panFormatType.Controls.Add(this.txtExpTimeWidth);
            this.panFormatType.Controls.Add(this.txtTrainNameWidth);
            this.panFormatType.Controls.Add(this.txtTrainNumberWidth);
            this.panFormatType.Controls.Add(this.txtExpTime);
            this.panFormatType.Controls.Add(this.txtAD);
            this.panFormatType.Controls.Add(this.txtTrainName);
            this.panFormatType.Controls.Add(this.txtPfNo);
            this.panFormatType.Controls.Add(this.txtTrainNumber);
            this.panFormatType.Controls.Add(this.panFieldType);
            this.panFormatType.Controls.Add(this.panFieldWidth);
            this.panFormatType.Controls.Add(this.panFieldName);
            this.panFormatType.Location = new System.Drawing.Point(921, 117);
            this.panFormatType.Name = "panFormatType";
            this.panFormatType.Size = new System.Drawing.Size(354, 211);
            this.panFormatType.TabIndex = 13;
            this.panFormatType.Visible = false;
            // 
            // txtPfType
            // 
            this.txtPfType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPfType.Location = new System.Drawing.Point(257, 171);
            this.txtPfType.Name = "txtPfType";
            this.txtPfType.Size = new System.Drawing.Size(81, 26);
            this.txtPfType.TabIndex = 17;
            // 
            // txtADType
            // 
            this.txtADType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtADType.Location = new System.Drawing.Point(257, 140);
            this.txtADType.Name = "txtADType";
            this.txtADType.Size = new System.Drawing.Size(81, 26);
            this.txtADType.TabIndex = 16;
            // 
            // txtExpTimeType
            // 
            this.txtExpTimeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtExpTimeType.Location = new System.Drawing.Point(257, 108);
            this.txtExpTimeType.Name = "txtExpTimeType";
            this.txtExpTimeType.Size = new System.Drawing.Size(81, 26);
            this.txtExpTimeType.TabIndex = 15;
            // 
            // txtTrainNameType
            // 
            this.txtTrainNameType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTrainNameType.Location = new System.Drawing.Point(257, 77);
            this.txtTrainNameType.Name = "txtTrainNameType";
            this.txtTrainNameType.Size = new System.Drawing.Size(81, 26);
            this.txtTrainNameType.TabIndex = 14;
            // 
            // txtTrainNumberType
            // 
            this.txtTrainNumberType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTrainNumberType.Location = new System.Drawing.Point(257, 45);
            this.txtTrainNumberType.Name = "txtTrainNumberType";
            this.txtTrainNumberType.Size = new System.Drawing.Size(81, 26);
            this.txtTrainNumberType.TabIndex = 13;
            // 
            // txtpfWidth
            // 
            this.txtpfWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtpfWidth.Location = new System.Drawing.Point(151, 171);
            this.txtpfWidth.Name = "txtpfWidth";
            this.txtpfWidth.Size = new System.Drawing.Size(86, 26);
            this.txtpfWidth.TabIndex = 12;
            // 
            // txtADWidth
            // 
            this.txtADWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtADWidth.Location = new System.Drawing.Point(151, 140);
            this.txtADWidth.Name = "txtADWidth";
            this.txtADWidth.Size = new System.Drawing.Size(86, 26);
            this.txtADWidth.TabIndex = 11;
            // 
            // txtExpTimeWidth
            // 
            this.txtExpTimeWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtExpTimeWidth.Location = new System.Drawing.Point(151, 108);
            this.txtExpTimeWidth.Name = "txtExpTimeWidth";
            this.txtExpTimeWidth.Size = new System.Drawing.Size(86, 26);
            this.txtExpTimeWidth.TabIndex = 10;
            this.txtExpTimeWidth.Visible = false;
            // 
            // txtTrainNameWidth
            // 
            this.txtTrainNameWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTrainNameWidth.Location = new System.Drawing.Point(151, 77);
            this.txtTrainNameWidth.Name = "txtTrainNameWidth";
            this.txtTrainNameWidth.Size = new System.Drawing.Size(86, 26);
            this.txtTrainNameWidth.TabIndex = 9;
            // 
            // txtTrainNumberWidth
            // 
            this.txtTrainNumberWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTrainNumberWidth.Location = new System.Drawing.Point(151, 45);
            this.txtTrainNumberWidth.Name = "txtTrainNumberWidth";
            this.txtTrainNumberWidth.Size = new System.Drawing.Size(86, 26);
            this.txtTrainNumberWidth.TabIndex = 8;
            this.txtTrainNumberWidth.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // txtExpTime
            // 
            this.txtExpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpTime.Location = new System.Drawing.Point(3, 108);
            this.txtExpTime.Name = "txtExpTime";
            this.txtExpTime.ReadOnly = true;
            this.txtExpTime.Size = new System.Drawing.Size(136, 26);
            this.txtExpTime.TabIndex = 7;
            this.txtExpTime.Text = "Exp.Time";
            // 
            // txtAD
            // 
            this.txtAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAD.Location = new System.Drawing.Point(3, 140);
            this.txtAD.Name = "txtAD";
            this.txtAD.ReadOnly = true;
            this.txtAD.Size = new System.Drawing.Size(136, 26);
            this.txtAD.TabIndex = 6;
            this.txtAD.Text = "A/D";
            // 
            // txtTrainName
            // 
            this.txtTrainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrainName.Location = new System.Drawing.Point(3, 77);
            this.txtTrainName.Name = "txtTrainName";
            this.txtTrainName.ReadOnly = true;
            this.txtTrainName.Size = new System.Drawing.Size(136, 26);
            this.txtTrainName.TabIndex = 5;
            this.txtTrainName.Text = "Train Name";
            // 
            // txtPfNo
            // 
            this.txtPfNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPfNo.Location = new System.Drawing.Point(3, 172);
            this.txtPfNo.Name = "txtPfNo";
            this.txtPfNo.ReadOnly = true;
            this.txtPfNo.Size = new System.Drawing.Size(136, 26);
            this.txtPfNo.TabIndex = 4;
            this.txtPfNo.Text = "PF.NO";
            // 
            // txtTrainNumber
            // 
            this.txtTrainNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrainNumber.Location = new System.Drawing.Point(3, 45);
            this.txtTrainNumber.Name = "txtTrainNumber";
            this.txtTrainNumber.ReadOnly = true;
            this.txtTrainNumber.Size = new System.Drawing.Size(136, 26);
            this.txtTrainNumber.TabIndex = 3;
            this.txtTrainNumber.Text = "Train Number";
            this.txtTrainNumber.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panFieldType
            // 
            this.panFieldType.BackColor = System.Drawing.Color.HotPink;
            this.panFieldType.Controls.Add(this.lblFieldType);
            this.panFieldType.Location = new System.Drawing.Point(247, 3);
            this.panFieldType.Name = "panFieldType";
            this.panFieldType.Size = new System.Drawing.Size(105, 36);
            this.panFieldType.TabIndex = 2;
            // 
            // lblFieldType
            // 
            this.lblFieldType.AutoSize = true;
            this.lblFieldType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldType.Location = new System.Drawing.Point(15, 9);
            this.lblFieldType.Name = "lblFieldType";
            this.lblFieldType.Size = new System.Drawing.Size(91, 20);
            this.lblFieldType.TabIndex = 1;
            this.lblFieldType.Text = "Field Type";
            // 
            // panFieldWidth
            // 
            this.panFieldWidth.BackColor = System.Drawing.Color.HotPink;
            this.panFieldWidth.Controls.Add(this.lblFieldWidth);
            this.panFieldWidth.Location = new System.Drawing.Point(141, 3);
            this.panFieldWidth.Name = "panFieldWidth";
            this.panFieldWidth.Size = new System.Drawing.Size(105, 36);
            this.panFieldWidth.TabIndex = 1;
            // 
            // lblFieldWidth
            // 
            this.lblFieldWidth.AutoSize = true;
            this.lblFieldWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldWidth.Location = new System.Drawing.Point(6, 9);
            this.lblFieldWidth.Name = "lblFieldWidth";
            this.lblFieldWidth.Size = new System.Drawing.Size(99, 20);
            this.lblFieldWidth.TabIndex = 1;
            this.lblFieldWidth.Text = "Field Width";
            // 
            // panFieldName
            // 
            this.panFieldName.BackColor = System.Drawing.Color.HotPink;
            this.panFieldName.Controls.Add(this.lblFieldName);
            this.panFieldName.Location = new System.Drawing.Point(2, 3);
            this.panFieldName.Name = "panFieldName";
            this.panFieldName.Size = new System.Drawing.Size(136, 36);
            this.panFieldName.TabIndex = 0;
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldName.Location = new System.Drawing.Point(18, 8);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(99, 20);
            this.lblFieldName.TabIndex = 0;
            this.lblFieldName.Text = "Field Name";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::ArecaIPIS.Properties.Resources._6497919_communication_computer_delete_home_internet_icon3;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(395, 367);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(109, 36);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::ArecaIPIS.Properties.Resources._510912_add_more_new_plus_icon;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(228, 367);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 36);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ArecaIPIS.Properties.Resources._3688505_check_done_right_accept_ok_icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(42, 365);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 38);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(49, 419);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(30, 13);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "save";
            this.lblStatus.Visible = false;
            // 
            // frmBoardConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 509);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panFormatType);
            this.Controls.Add(this.cmbFormatType);
            this.Controls.Add(this.rtxtBoardWidth);
            this.Controls.Add(this.rtxtDisplayFieldGap);
            this.Controls.Add(this.rtxtformatName);
            this.Controls.Add(this.lblDisplayFormatType);
            this.Controls.Add(this.lblDisplayFieldGap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llblFormatName);
            this.Controls.Add(this.panFormats);
            this.Controls.Add(this.lblDisplayFormat);
            this.Controls.Add(this.lblFormatType);
            this.Controls.Add(this.lblAvailableFormats);
            this.Controls.Add(this.lblBoardConfiguration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBoardConfiguration";
            this.Text = "BoardConfiguration";
            this.Load += new System.EventHandler(this.frmBoardConfiguration_Load);
            this.panFormatType.ResumeLayout(false);
            this.panFormatType.PerformLayout();
            this.panFieldType.ResumeLayout(false);
            this.panFieldType.PerformLayout();
            this.panFieldWidth.ResumeLayout(false);
            this.panFieldWidth.PerformLayout();
            this.panFieldName.ResumeLayout(false);
            this.panFieldName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBoardConfiguration;
        private System.Windows.Forms.Label lblAvailableFormats;
        private System.Windows.Forms.Label lblFormatType;
        private System.Windows.Forms.Label lblDisplayFormat;
        private System.Windows.Forms.Panel panFormats;
        private System.Windows.Forms.Label llblFormatName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDisplayFieldGap;
        private System.Windows.Forms.Label lblDisplayFormatType;
        private System.Windows.Forms.RichTextBox rtxtformatName;
        private System.Windows.Forms.RichTextBox rtxtDisplayFieldGap;
        private System.Windows.Forms.RichTextBox rtxtBoardWidth;
        private System.Windows.Forms.ComboBox cmbFormatType;
        private System.Windows.Forms.Panel panFormatType;
        private System.Windows.Forms.Panel panFieldType;
        private System.Windows.Forms.Label lblFieldType;
        private System.Windows.Forms.Panel panFieldWidth;
        private System.Windows.Forms.Label lblFieldWidth;
        private System.Windows.Forms.Panel panFieldName;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.TextBox txtTrainNumberWidth;
        private System.Windows.Forms.TextBox txtExpTime;
        private System.Windows.Forms.TextBox txtAD;
        private System.Windows.Forms.TextBox txtTrainName;
        private System.Windows.Forms.TextBox txtPfNo;
        private System.Windows.Forms.TextBox txtTrainNumber;
        private System.Windows.Forms.TextBox txtPfType;
        private System.Windows.Forms.TextBox txtADType;
        private System.Windows.Forms.TextBox txtExpTimeType;
        private System.Windows.Forms.TextBox txtTrainNameType;
        private System.Windows.Forms.TextBox txtTrainNumberType;
        private System.Windows.Forms.TextBox txtpfWidth;
        private System.Windows.Forms.TextBox txtADWidth;
        private System.Windows.Forms.TextBox txtExpTimeWidth;
        private System.Windows.Forms.TextBox txtTrainNameWidth;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblStatus;
    }
}