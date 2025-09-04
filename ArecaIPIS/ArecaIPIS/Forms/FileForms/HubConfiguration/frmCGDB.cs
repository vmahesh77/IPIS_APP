using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Server_Classes;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArecaIPIS
{
    public partial class frmCGDB : Form
    {

        public int MainEthernetPortNo { get; set; }
        public int PkNumber { get; set; }
        public int PdcPortNo { get; set; }
        public int CdcId { get; set; }

        string pdcIpaddress { get; set; }

        Button board;

        int ID;
        public frmCGDB()
        {
            InitializeComponent();
        }

        private void txtCGDBnoofcoaches_MouseLeave(object sender, EventArgs e)
        {


        }

        public void SetPassedValue(Button button, int MainPortNo)
        {
            // Extract the numerical part from the button's name
            board = button;
            string buttonName = button.Name;
            string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

            // Convert the numeric part to an integer

            PdcPortNo = Convert.ToInt32(numericPart);

            MainEthernetPortNo = MainPortNo;

        }
        private void GenerateCoaches(int numberOfRows, int thirdOctet)
        {
            dgvCgdbCoaches.Rows.Clear();

            // Populate the rows.
            for (int i = 0; i < numberOfRows; i++)
            {
                int portNo = i + 1;
                string ipAddress = $"192.168.{thirdOctet}.{i + 2}";
                dgvCgdbCoaches.Rows.Add(portNo, ipAddress);
            }

            if (numberOfRows != dgvCgdbCoaches.Rows.Count)
            {
                dgvCgdbCoaches.Rows.Clear();
            }
        }


        private void SetDisplayEffects()
        {
            try
            {


                // Clear existing items in the ComboBox
                CmbCGDBDisplayeffect.Items.Clear();
                // Assuming BaseClass.Platforms is a collection of platform names
                foreach (var Effects in BaseClass.DisplayEffects)
                {
                    // Trim the platform name
                    string trimmedEffects = Effects.Trim();

                    // Add the trimmed platform name to the ComboBox
                    CmbCGDBDisplayeffect.Items.Add(trimmedEffects);
                }
                // Select the default item "--Select--"
                CmbCGDBDisplayeffect.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void SetLetterGap()
        {
            // Clear existing items in the ComboBox
            CmbCGDBlettergap.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var LetterGap in BaseClass.LetterGapList)
            {
                // Trim the platform name
                string trimmedLetterGap = LetterGap.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbCGDBlettergap.Items.Add(trimmedLetterGap);
            }
            // Select the default item "--Select--"
            CmbCGDBlettergap.SelectedIndex = 1;
        }
        private void SetLetterSpeed()
        {
            // Clear existing items in the ComboBox
            CmbCGDBLetterSpeed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Speed in BaseClass.LetterSpeedlist)
            {
                // Trim the platform name
                string trimmedSpeed = Speed.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbCGDBLetterSpeed.Items.Add(trimmedSpeed);
            }
            // Select the default item "--Select--"
            CmbCGDBLetterSpeed.SelectedIndex = 0;
        }
        private void SetFormatType()
        {
            // Clear existing items in the ComboBox
            CmbCGDBFormattype.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var FormatType in BaseClass.FormatsList)
            {
                // Trim the platform name
                string trimmedFormatType = FormatType.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbCGDBFormattype.Items.Add(trimmedFormatType);
            }
            // Select the default item "--Select--"
            CmbCGDBFormattype.SelectedIndex = 2;
        }
        private void SetFontSize()
        {
            // Clear existing items in the ComboBox
            CmbCGDBfontSize.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Font in BaseClass.FontSizeList)
            {
                // Trim the platform name
                string trimmedFont = Font.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbCGDBfontSize.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            CmbCGDBfontSize.SelectedIndex = 4;
        }

        






        private void checkboxCGDBAutoerasing_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (checkboxCGDBAutoerasing.Checked)
            {
                // If checked, enable the panel
                txtCGDBErasetime.Enabled = true;
            }
            else
            {
                // If unchecked, disable the panel
                txtCGDBErasetime.Enabled = false;
            }
        }

        private void frmCGDB_Load(object sender, EventArgs e)
        {
            cmbCGDBVideoType.SelectedIndex = 0;
            CmbCGDBDelaytime.SelectedIndex = 0;
            SetDisplayEffects();
            SetLetterSpeed();
            SetFormatType();
            SetLetterGap();
            SetFontSize();
            SetPlatForm();
            SetCdcId();
            GetDetailsByPk();
            InitializeControls();
        }

        private void GetDetailsByPk()
        {
            try
            {


                if (PkNumber != 0)
                {
                    foreach (DataRow row in BaseClass.CgdbPorts.Rows)
                    {
                        if (BaseClass.CgdbPorts.Columns.Contains("Pkey_CoachConfig") && int.TryParse(row["Pkey_CoachConfig"].ToString(), out int PkcoachConfigHub))
                        {
                            if (PkcoachConfigHub == PkNumber)
                            {

                                int Videovalue = Convert.ToInt32(row["VideoType"].ToString());
                                if (Videovalue == 0)
                                {
                                    cmbCGDBVideoType.Text = "Normal";
                                }
                                else
                                {
                                    cmbCGDBVideoType.Text = "Reverse";
                                }

                                CmbCGDBLetterSpeed.Text = BaseClass.GetLetterSpeed(Convert.ToInt32(row["LetterSpeed"]));
                                CmbCGDBFormattype.Text = BaseClass.GetFormattype(Convert.ToInt32(row["FormatType"]));
                                CmbCGDBlettergap.Text = BaseClass.GetLetterGap(Convert.ToInt32(row["LetterGap"]));

                                //int indexno = Convert.ToInt32(row["DelayTime"]);

                                CmbCGDBDelaytime.Text = row["DelayTime"].ToString();
                                CmbCGDBDisplayeffect.Text = BaseClass.GetDisplayeffect(Convert.ToInt32(row["DisplayEffect"]));
                                CmbCGDBfontSize.Text = BaseClass.GetFontSize(Convert.ToInt32(row["Fontsize"]));
                                txtCGDBErasetime.Text = row["Erase_time"].ToString();


                                txtCGDBDefaultEnglish.Text = row["DefaultEnglish"].ToString();

                                txtCGDBDefaultHindi.Text = row["DefaultHindi"].ToString();
                                txtDefaultPlatformOrDiv.Text = row["DivCode"].ToString();
                                txtCGDBnoofcoaches.Text = row["No_Of_Coaches"].ToString();
                                txtCGDBplatformno.Text = row["default_platformno"].ToString();

                                ID = Convert.ToInt32(row["Pkey_CoachConfig"]);

                                pdcIpaddress = row["PDCIp"].ToString();
                                PdcPortNo = Convert.ToInt32(row["pdcPortNo"].ToString());
                                MainEthernetPortNo = Convert.ToInt32(row["MainEthernetPortNo"].ToString());
                                CdcId = Convert.ToInt32(row["Fkey_CDCID"].ToString());

                            }
                        }
                    }



                    DataTable cgdbIp = HubConfigurationDb.GetCoaches(CdcId);

                    dgvCgdbCoaches.Rows.Clear();

                    foreach (DataRow row in cgdbIp.Rows)
                    {
                        int? portNo = row.Field<int?>("PortNo");
                        string cgdbIpAddress = row.Field<string>("Cgdb_IpAddress");

                        // Add rows to the DataGridView
                        dgvCgdbCoaches.Rows.Add(portNo, cgdbIpAddress);
                    }

                }
                else
                {

                    ID = -1;



                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void SetPlatForm()
        {
            try
            {


                if (PkNumber == 0)
                {


                    foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                    {
                        if (BaseClass.EthernetPorts.Columns.Contains("PortNo") && int.TryParse(row["PortNo"].ToString(), out int ethernet))
                        {
                            int ethernetvalue = Convert.ToInt32(MainEthernetPortNo);
                            if (ethernet == ethernetvalue)
                            {
                                pdcIpaddress = row["IPAddress"].ToString().Trim();

                                // Split the IP address into its octets
                                string[] octets = pdcIpaddress.Split('.');

                                txtCGDBplatformno.Text = octets[2];

                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public void SetPkHubValue(int pkvalue)
        {
            PkNumber = pkvalue;

        }
        public void SetCdcId()
        {
            foreach (DataRow row in BaseClass.EthernetPorts.Rows)
            {
                if (BaseClass.EthernetPorts.Columns.Contains("PortNo") && int.TryParse(row["PortNo"].ToString(), out int port))
                {

                    if (port == MainEthernetPortNo)
                    {
                        CdcId = Convert.ToInt32(row["PkeyMasterhub"]);
                    }
                }
            }
        }
        private void CmbCGDBfontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCGDBsave_Click(object sender, EventArgs e)
        {
            try
            {


                bool hasError = false; // Flag to track if there's any error

                // Check and highlight each required text box         
                hasError |= CheckAndHighlightEmptyField(txtCGDBnoofcoaches);
                hasError |= CheckAndHighlightEmptyField(txtDefaultPlatformOrDiv);
                hasError |= CheckAndHighlightEmptyField(txtCGDBDefaultEnglish);
                hasError |= CheckAndHighlightEmptyField(txtCGDBDefaultHindi);
                // hasError |= CheckAndHighlightEmptyField(txtPfdRegional);
                hasError |= CheckAndHighlightLabelCoaches(lblCoachError);
                // If any error is found, display error message and exit the method
                if (hasError)
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    bool NotExists = HubConfigurationDb.CheckCdcAndPdcPort(CdcId.ToString(), PdcPortNo.ToString());
                    if (NotExists)
                    {



                        int pdcPort = PdcPortNo;
                        int packetidentifier = 2;
                        string platformNo = txtCGDBplatformno.Text.Trim();

                        string videoType = GetVideoType();
                        string letterSpeed = GetletterSpeed();
                        string FormatType = GetFormatType();
                        string lettergap = Getlettergap();
                        string DisplayEffect = GetDisplayeffect();
                        int fontsize = GetFontSize();

                        int DelayTime = Convert.ToInt32(CmbCGDBDelaytime.Text);

                        int EraseTime;
                        if (int.TryParse(txtCGDBErasetime.Text, out EraseTime))
                        {

                        }
                        else
                        {
                            // Handle the error, e.g., set a default value or show a message to the user
                            EraseTime = 60; // or any other default value// Optionally, you can inform the user about the incorrect input


                        }
                        int noOfCoaches = Convert.ToInt32(txtCGDBnoofcoaches.Text.Trim());
                        string defaultEnglish = txtCGDBDefaultEnglish.Text.Trim();
                        string defaultHindi = txtCGDBDefaultHindi.Text.Trim();
                        string divisionOrPf = txtDefaultPlatformOrDiv.Text.Trim();
                        DataTable CgdbIp = GetDataTableFromDataGridView(dgvCgdbCoaches);


                        // Show confirmation dialog
                        DialogResult result = MessageBox.Show("Do you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // If the user clicks Yes, proceed with saving the data
                        if (result == DialogResult.Yes)
                        {
                            int rows = HubConfigurationDb.SaveCoachConfiguration(
                                       ID, CdcId, pdcPort,
                                     videoType, lettergap, letterSpeed, DisplayEffect, fontsize, FormatType, noOfCoaches, platformNo,
                                      EraseTime, DelayTime, defaultEnglish, defaultHindi, divisionOrPf, packetidentifier, pdcIpaddress, MainEthernetPortNo, CgdbIp);

                            if (rows >= 0)
                            {
                                ReportDb.InsertDatabaseModificationReportData("CGDB Boards Added for Platform " + platformNo, "4");
                                // Show success message for 10 seconds
                                lblStatus.Text = "Board Configuration saved successfully!";
                                lblStatus.ForeColor = Color.Green;
                                //board.Text = location;
                                string[] SystemIPArr = pdcIpaddress.Split('.');
                                string broadCastIp = "";
                                if (SystemIPArr.Length == 4)
                                {
                                    // Change the 4th octet to 255
                                    SystemIPArr[3] = "255";

                                    // Join the octets back into an IP address string
                                    broadCastIp = string.Join(".", SystemIPArr);

                                    //Console.WriteLine("Modified IP address: " + broadCastIp);
                                }

                                if (Server._connectedClients.Count >=0)
                                {
                                    if (BaseClass.Getinteroperabilitystatus(pdcIpaddress))
                                    {
                                        byte[] BStopCommand = ByteFormation.BStopCommand(pdcIpaddress, packetidentifier);
                                        byte[] BtrimmedstopBytes = ByteFormation.RemoveFirstAndLast6(BStopCommand);
                                        string pdcbroadCastIp = Server.GetBroadcastIp(pdcIpaddress);

                                        CgdbController.Send_UDPClientData(BtrimmedstopBytes, 14, pdcbroadCastIp);
                                        frmHubConfiguration.CGDBDefaultDataPacketINTERAPROBALITY(
                                             ID, CdcId, pdcPort,
                                           videoType, lettergap, letterSpeed, DisplayEffect, fontsize, FormatType, noOfCoaches, platformNo,
                                            EraseTime, DelayTime, defaultEnglish, defaultHindi, divisionOrPf, packetidentifier, pdcIpaddress, MainEthernetPortNo, CgdbIp);

                                        byte[] BStartCommand = ByteFormation.BStartCommand(pdcIpaddress, packetidentifier);
                                        byte[] BStartCommandtrimmedstopBytes = ByteFormation.RemoveFirstAndLast6(BStartCommand);


                                        CgdbController.Send_UDPClientData(BStartCommandtrimmedstopBytes, 14, pdcbroadCastIp);
                                    }
                                    else
                                    {
                                        byte[] StopCommand = ByteFormation.StopCommand(broadCastIp, packetidentifier);
                                        Server.SendDataToPdc(pdcIpaddress, StopCommand);

                                        frmHubConfiguration.CGDBDefaultDataPacket(
                                               ID, CdcId, pdcPort,
                                             videoType, lettergap, letterSpeed, DisplayEffect, fontsize, FormatType, noOfCoaches, platformNo,
                                              EraseTime, DelayTime, defaultEnglish, defaultHindi, divisionOrPf, packetidentifier, pdcIpaddress, MainEthernetPortNo, CgdbIp);
                                        byte[] StartCommand = ByteFormation.StartCommand(broadCastIp, packetidentifier);
                                        Server.SendDataToPdc(pdcIpaddress, StartCommand);
                                    }

                                }

                                BaseClass.RecallBoards();


                                //  Server.SendMessageToClient(pdcIpaddress, LinkCheckPacket);
                            }
                            else
                            {
                                // Show failure message for 10 seconds
                                lblStatus.Text = "Failed to save Board configuration.";
                                lblStatus.ForeColor = Color.Red;
                            }

                            // Make the label visible
                            lblStatus.Visible = true;

                            // Start a timer to clear the label after 10 seconds
                            Timer timer = new Timer();
                            timer.Interval = 2000; // 5 seconds
                            timer.Tick += (s, _) =>
                            {
                                // Clear the label text and hide the label
                                lblStatus.Text = "";
                                lblStatus.Visible = false;

                                // Stop and dispose the timer
                                timer.Stop();
                                timer.Dispose();
                                this.Close();

                            };
                            timer.Start(); // Start the timer

                        }
                    }
                    else
                    {
                        MessageBox.Show("Coaches Exists In  this Platform ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }

        }


        public DataTable GetDataTableFromDataGridView(DataGridView dataGridView)
        {

            DataTable dataTable = new DataTable();
            try
            {


                // Add columns to DataTable
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    // Check for null ValueType and assign default type
                    Type columnType = column.ValueType ?? typeof(string);
                    dataTable.Columns.Add(column.Name, columnType);
                }

                // Add rows to DataTable
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    // Skip rows that are not added to the DataGridView (e.g., new row for input)
                    if (row.IsNewRow) continue;

                    DataRow dataRow = dataTable.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dataRow[cell.ColumnIndex] = cell.Value ?? DBNull.Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }

            return dataTable;
        }

        private bool CheckAndHighlightEmptyField(TextBox TextBox)
        {

            if (string.IsNullOrWhiteSpace(TextBox.Text))
            {
                TextBox.BackColor = Color.Red; // Change background color to red to indicate error
                return true; // Indicate that this text box has an error
            }
            else
            {
                TextBox.BackColor = SystemColors.Window; // Reset background color
                return false; // No error for this text box
            }
        }
        private bool CheckAndHighlightLabelCoaches(Label label)
        {

            if (label.Visible)
            {
                // Change background color to red to indicate error
                return true; // Indicate that this text box has an error
            }
            else
            {
                label.Visible = false;
                return false; // No error for this text box
            }
        }
        private void txtCGDBnoofcoaches_Enter(object sender, EventArgs e)
        {
            lblCoachError.Visible = false;
            txtCGDBnoofcoaches.BackColor = SystemColors.Window;
        }

        private void txtCGDBDefaultEnglish_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPressValidation(txtCGDBDefaultEnglish, e, 2, 4);
        }
        private void HandleKeyPressValidation(TextBox textBox, KeyPressEventArgs e, int minLength, int maxLength)
        {
            // Allow only letters and control keys
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                SetTextBoxErrorStyle(textBox);
                return;
            }


        }

        private void SetTextBoxErrorStyle(TextBox textBox)
        {
            textBox.BackColor = Color.Red;
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private void SetTextBoxNormalStyle(TextBox textBox)
        {
            textBox.BackColor = SystemColors.Window;
            textBox.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtCGDBDefaultHindi_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPressValidation(txtCGDBDefaultHindi, e, 2, 4);
        }

        private void txtDefaultPlatformOrDiv_KeyPress(object sender, KeyPressEventArgs e)
        {
            // HandleKeyPressValidation(txtDefaultPlatformOrDiv, e, 2, 4);
        }



        private int GetPortNo(int ethernetPortNo, int PdcPortNo)
        {
            int portno;
            if (PdcPortNo == 0)
            {
                portno = ethernetPortNo;
            }
            else
            {
                portno = 0;
            }


            return portno;
        }
        private int GetFontSize()
        {
            try
            {


                // Get the selected font size from the ComboBox
                string selectedFontSize = CmbCGDBfontSize.Text.Trim();

                // Iterate through each row in the DataTable
                foreach (DataRow row in BaseClass.FontSizeDt.Rows)
                {
                    // Check if the current row's Size column matches the selected font size
                    if (row["Size"].ToString() == selectedFontSize)
                    {
                        // Return the corresponding Pkey_Fonts value after casting it to int
                        return Convert.ToInt32(row["Pkey_Fonts"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            // Return a default value or handle the case where no match is found
            return -1;
        }

        private string Getlettergap()
        {
            // Get the selected speed from the ComboBox
            string lettergap = CmbCGDBlettergap.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.LetterGapDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["LetterGap"].ToString() == lettergap)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pkey_LetterGap"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetDisplayeffect()
        {
            // Get the selected speed from the ComboBox
            string DisplayEffect = CmbCGDBDisplayeffect.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.DisplayEffectsDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Name"].ToString() == DisplayEffect)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pkey_DisplayEffect"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetFormatType()
        {
            // Get the selected speed from the ComboBox
            string format = CmbCGDBFormattype.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.FormatsDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Format"].ToString() == format)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pkey_FormatName"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetletterSpeed()
        {
            // Get the selected speed from the ComboBox
            string speed = CmbCGDBLetterSpeed.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.LetterSpeedDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["LetterSpeed"].ToString() == speed)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pkey_LetterSpeed"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }

        private string GetVideoType()
        {
            string videotype = "";
            string video = cmbCGDBVideoType.Text.Trim();
            if (video.Equals("Normal"))
            {
                videotype = "0";
            }
            else
            {
                videotype = "1";
            }
            return videotype;
        }

        private void frmCGDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {


                frmHubConfiguration frmhub;
                Form mainForm = Application.OpenForms["frmHubConfiguration"];

                if (mainForm != null)
                {
                    frmhub = (frmHubConfiguration)mainForm;
                    frmhub.ClearPanel();


                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtCGDBnoofcoaches_Leave(object sender, EventArgs e)
        {

        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(300, 50, "English");
        }

        private void btnPKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(250, 50, "English");
        }

        private void btnHKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(280, 50, "Hindi");
        }
        private void InitializeControls()
        {
            txtCGDBDefaultEnglish.Enter += Control_Enter;
            txtCGDBDefaultHindi.Enter += Control_Enter;
            txtDefaultPlatformOrDiv.Enter += Control_Enter;
        }
        private void Control_Enter(object sender, EventArgs e)
        {
            frmKeyboard.focusedControl = (Control)sender;

        }
        public static Panel panel;

        private void InitializePanel()
        {
            if (panel == null || panel.IsDisposed)
            {
                panel = new Panel
                {
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new Size(450, 180),
                    AutoSize = true
                };
            }
        }
        private void Keyboard(int x, int y, string language)
        {
            try
            {
                InitializePanel();

                panel.Location = new Point(x, y);
                panel.Visible = true;

                frmKeyboard keyBoard = new frmKeyboard(panel, language);
                keyBoard.TopLevel = false;
                keyBoard.FormBorderStyle = FormBorderStyle.None;

                panel.Controls.Add(keyBoard);
                keyBoard.Show();

                if (!this.Controls.Contains(panel))
                {
                    this.Controls.Add(panel);
                }
                panel.BringToFront();

            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show("The panel or another object was disposed and cannot be accessed. " +
                                "Please check the state of your objects and try again.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtCGDBnoofcoaches_TextChanged(object sender, EventArgs e)
        {
            // Check if the text boxes are not null or empty
            if (!string.IsNullOrWhiteSpace(txtCGDBnoofcoaches.Text) && !string.IsNullOrWhiteSpace(txtCGDBplatformno.Text))
            {
                // Try to parse the values from the text boxes
                if (int.TryParse(txtCGDBnoofcoaches.Text, out int numberOfCoaches) && int.TryParse(txtCGDBplatformno.Text, out int thirdOctet))
                {
                    if (numberOfCoaches <= 32)
                    {
                        lblCoachError.Visible = false;
                        txtCGDBnoofcoaches.BackColor = SystemColors.Window;
                        // Generate the rows based on the parsed values
                        GenerateCoaches(numberOfCoaches, thirdOctet);
                    }
                    else
                    {
                        txtCGDBnoofcoaches.BackColor = Color.Red;
                        lblCoachError.Visible = true;
                    }

                }

            }
        }

        private void txtCGDBnoofcoaches_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered key is not a digit and not a backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // If it's not a valid key, prevent the keypress from being processed
                e.Handled = true;
            }
        }

        private void txtCGDBDefaultEnglish_Enter(object sender, EventArgs e)
        {
            txtCGDBDefaultEnglish.BackColor = SystemColors.Window;
        }

        private void txtCGDBDefaultHindi_Enter(object sender, EventArgs e)
        {
            txtCGDBDefaultHindi.BackColor = SystemColors.Window;
        }

        private void txtDefaultPlatformOrDiv_Enter(object sender, EventArgs e)
        {
            txtDefaultPlatformOrDiv.BackColor = SystemColors.Window;
        }

        private void txtCGDBDefaultEnglish_TextChanged(object sender, EventArgs e)
        {
            ChangeTextboxLetterSmallToCapital(txtCGDBDefaultEnglish);
        }
        public void ChangeTextboxLetterSmallToCapital(TextBox richTextBox)
        {
            // Preserve the cursor position to avoid reset issues while typing
            int selectionStart = richTextBox.SelectionStart;

            // Convert the text to uppercase
            richTextBox.Text = richTextBox.Text.ToUpper();

            // Restore the cursor position
            richTextBox.SelectionStart = selectionStart;
        }

        private void txtDefaultPlatformOrDiv_TextChanged(object sender, EventArgs e)
        {
            ChangeTextboxLetterSmallToCapital(txtDefaultPlatformOrDiv);
        }

        private void txtCGDBDefaultHindi_TextChanged(object sender, EventArgs e)
        {
            ChangeTextboxLetterSmallToCapital(txtCGDBDefaultHindi);
        }
    }
}