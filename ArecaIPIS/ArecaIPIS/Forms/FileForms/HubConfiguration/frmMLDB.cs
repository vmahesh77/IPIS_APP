using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ArecaIPIS
{
    public partial class frmMLDB : Form
    {
        public frmMLDB()
        {
            InitializeComponent();
        }
        public int ethernetPortNo { get; set; }
        public int PkNumber { get; set; }
        public int PdcPortNo { get; set; }
        Button board;
        int ID;
        public void SetPassedValue(Button button)
        {
            // Extract the numerical part from the button's name
            board = button;
            string buttonName = button.Name;
            string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

            // Convert the numeric part to an integer

            ethernetPortNo = Convert.ToInt32(numericPart);

            // Optionally, use the value immediately or update some controls with this value
            txtMLDBEthernetportno.Text = ethernetPortNo.ToString(); // Assuming you have a textbox to display the value

        }
        public void SetPkHubValue(int pkvalue)
        {
            PkNumber = pkvalue;

        }
        public void SetPassedValue(Button button, int PortNo)
        {
            // Extract the numerical part from the button's name
            board = button;
            string buttonName = button.Name;
            string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

            // Convert the numeric part to an integer

            PdcPortNo = Convert.ToInt32(numericPart);

            // Optionally, use the value immediately or update some controls with this value
            txtMLDBEthernetportno.Text = PortNo.ToString(); // Assuming you have a textbox to display the value

        }
        private void btnMLDBCommonSettings_Click(object sender, EventArgs e)
        {
            panelMLDBCommonSettings.Visible = true;
            panelMLDBBoardSettings.Hide();
            btnMLDBCommonSettings.BackColor = Color.Green;
            btnMLDBBoardSettings.BackColor = Color.Black;
        }

        private void btnMLDBBoardSettings_Click(object sender, EventArgs e)
        {
            panelMLDBCommonSettings.Hide();
            panelMLDBBoardSettings.Visible = true;
            btnMLDBCommonSettings.BackColor = Color.Black;
            btnMLDBBoardSettings.BackColor = Color.Green;
        }

        private void MLDB_Load(object sender, EventArgs e)
        {
            panelMLDBCommonSettings.Visible = true;
            panelMLDBBoardSettings.Hide();
            btnMLDBCommonSettings.BackColor = Color.Green;
            btnMLDBBoardSettings.BackColor = Color.Black;
            cmbMLDBVideoType.SelectedIndex = 0;
            CmbMLDBDelaytime.SelectedIndex = 0;
            SetDisplayEffects();
            SetLetterSpeed();
            SetIPAddress();
            SetFormatType();
            SetLetterGap();
            SetFontSize();
            SetInfoDisplay();
            SetDisplaySequence();
            createPlatforms();
            GetDetailsByPk();
            InitializeControls();





        }

        private void GetDetailsByPk()
        {
            if (PkNumber != 0)
            {
                DataTable boarddetailybyPk = new DataTable();
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("PkeyMasterhub") && int.TryParse(row["PkeyMasterhub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == PkNumber)
                        {
                            boarddetailybyPk = HubConfigurationDb.GetBoardDetails(PkMasterHub);
                            ipAddressMldb.Text = row["IPAddress"].ToString();
                            txtMLDBLocation.Text = row["Location"].ToString();
                            txtMLDBEthernetportno.Text = row["EthernetPort"].ToString();
                            ethernetPortNo = Convert.ToInt32(row["EthernetPort"]);
                            tglinteroperability.Checked = row["interoperability"] != DBNull.Value && (bool)row["interoperability"];

                            PdcPortNo = Convert.ToInt32(row["PdcPortNo"]);

                            //foreach (DataRow rows in BaseClass.EthernetPorts.Rows)
                            //{
                            //    if (BaseClass.EthernetPorts.Columns.Contains("PortNo") && int.TryParse(rows["PortNo"].ToString(), out int port))
                            //    {
                            //        if (port == ethernetPortNo)
                            //        {
                            //            ID = Convert.ToInt32(rows["PkeyMasterhub"]);

                            //        }

                            //    }
                            //}

                        }
                    }
                }

                foreach (DataRow row in boarddetailybyPk.Rows)
                {
                    if (boarddetailybyPk.Columns.Contains("FkeyofMasterHub") && int.TryParse(row["FkeyofMasterHub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == PkNumber)
                        {
                            txtMLDBBoardid.Text = row["BoardID"].ToString();
                            txtMLDBNooflines.Text = row["NoofLines"].ToString();
                            int Videovalue = Convert.ToInt32(row["VideoType"].ToString());
                            if (Videovalue == 0)
                            {
                                cmbMLDBVideoType.Text = "Normal";
                            }
                            else
                            {
                                cmbMLDBVideoType.Text = "Reverse";
                            }

                            CmbMLDBLetterSpeed.Text = BaseClass.GetLetterSpeed(Convert.ToInt32(row["LetterSpeed"]));
                            CmbMLDBFormattype.Text = BaseClass.GetFormattype(Convert.ToInt32(row["FormatType"]));
                            CmbMLDBlettergap.Text = BaseClass.GetLetterGap(Convert.ToInt32(row["LetterGap"]));
                            CmbMLDBDelaytime.Text = row["DelayTime"].ToString();
                            CmbMLDBDisplayeffect.Text = BaseClass.GetDisplayeffect(Convert.ToInt32(row["DisplayEffect"]));
                            CmbMLDBfontSize.Text = BaseClass.GetFontSize(Convert.ToInt32(row["FontSize"]));
                            txtMLDBErasetime.Text = row["EraseTime"].ToString();

                            CmbMLDBinfoDisplayed.Text = BaseClass.GetinfoDisplayed(Convert.ToInt32(row["InfoDisplayed"]));
                            txtMLDBEnglish.Text = row["LanEnglish"].ToString();
                            txtMLDBRegional.Text = row["LanRegional"].ToString();
                            txtMLDBHindi.Text = row["LanHindi"].ToString();
                            checkMLDBBoxShowMessages.Checked = (bool)row["MessagesEnble"];
                            Boolean value = (bool)row["BoardRunning"];
                            if (value)
                            {
                                rdbnMLDBWorking.Checked = true;
                            }
                            else
                            {
                                rdbnMLDBNotWorking.Checked = true;
                            }
                            ID = Convert.ToInt32(row["FkeyofMasterHub"]);
                            string checkedPlatforms = row["Checkedplatforms"].ToString(); ;
                            setPlatforms(checkedPlatforms);
                            string languages = row["DisplaySequence"].ToString(); ;
                            setDisplayLanguages(dgvLanguage, languages);

                        }
                    }
                }


            }
            else
            {

                ID = -1;



            }
        }
        private void setPlatforms(string Platforms)
        {
            var checkedPlatforms = Platforms.Split(',')
                                                      .Select(p => p.Trim())
                                                      .ToList();

            foreach (Control control in grupMLDBPlatforms.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    if (checkedPlatforms.Contains(checkBox.Text.Trim()))
                    {
                        checkBox.Checked = true;
                    }
                    else
                    {
                        checkBox.Checked = false; // Optionally uncheck if not in the list
                    }
                }
            }
        }



        private void createPlatforms()
        {
            // Clear existing controls in the GroupBox
            grupMLDBPlatforms.Controls.Clear();

            int xMargin = 10; // Margin from left
            int yMargin = 20; // Margin from top
            int checkBoxHeight = 20; // Height of each checkbox
            int xSpacing = 10; // Horizontal spacing between checkboxes
            int ySpacing = 10; // Vertical spacing between rows
            int maxColumns = 4; // Number of checkboxes per row
            int fixedCheckBoxWidth = 60; // Fixed width for each checkbox

            int x = xMargin;
            int y = yMargin;
            int columnCount = 0;

            // Loop through each value in the list
            foreach (string value in BaseClass.Platforms)
            {
                // Create a new CheckBox
                CheckBox checkBox = new CheckBox
                {
                    Text = value.Trim(),
                    Font = new Font("Arial", 10),
                    Width = fixedCheckBoxWidth, // Set fixed width for all checkboxes
                    Height = checkBoxHeight,
                    AutoSize = false // Disable AutoSize to use fixed width
                };

                // Set the location of the CheckBox
                checkBox.Location = new Point(x, y);

                // Add CheckBox to the GroupBox
                grupMLDBPlatforms.Controls.Add(checkBox);

                // Adjust x coordinate for the next checkbox
                x += fixedCheckBoxWidth + xSpacing;
                columnCount++;

                // Move to the next row if the maximum number of columns is reached
                if (columnCount % maxColumns == 0)
                {
                    x = xMargin; // Reset x position
                    y += checkBoxHeight + ySpacing; // Move to the next row
                    columnCount = 0;
                }
            }
        }

        private string ShowCheckedPlatforms()
        {
            // Retrieve the checked values
            List<string> checkedPlatforms = GetCheckedPlatforms();

            // Convert the list of values to a string for display
            string checkedValues = string.Join(",", checkedPlatforms);

            // Display the values in a message box
            return checkedValues;
        }

        private List<string> GetCheckedPlatforms()
        {
            List<string> checkedPlatforms = new List<string>();

            // Loop through each control in the GroupBox
            foreach (Control control in grupMLDBPlatforms.Controls)
            {
                // Check if the control is a CheckBox and if it is checked
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    // Add the text of the checked CheckBox to the list
                    checkedPlatforms.Add(checkBox.Text);
                }
            }

            return checkedPlatforms;
        }
        public static void setDisplayLanguages(DataGridView dgvLanguage, string Languages)
        {
            // Clear the DataGridView rows
            dgvLanguage.Rows.Clear();

            // Split the input string into a list of languages, trimming any leading/trailing spaces
            List<string> displayLanguages = Languages.Split(',')
                                                     .Select(p => p.Trim())
                                                     .ToList();

            // Add each language as a new row in the DataGridView
            foreach (string language in displayLanguages)
            {
                dgvLanguage.Rows.Add(language);
            }
        }

        private void SetDisplaySequence()
        {

            foreach (string value in BaseClass.Languages)
            {
                dgvLanguage.Rows.Add(value);
                if (value != "English" && value != "Hindi")
                {
                    lblMLDBRegional.Text = value; // Replace "Some text" with your desired text
                    txtMLDBRegional.Visible = true;
                    btnRKeyboard.Visible = true;
                    lblMLDBRegional.Visible = true;
                }
            }
        }

        private void SetDisplayEffects()
        {
            // Clear existing items in the ComboBox
            CmbMLDBDisplayeffect.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Effects in BaseClass.DisplayEffects)
            {
                // Trim the platform name
                string trimmedEffects = Effects.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbMLDBDisplayeffect.Items.Add(trimmedEffects);
            }
            // Select the default item "--Select--"
            CmbMLDBDisplayeffect.SelectedIndex = 0;
        }
        private void SetInfoDisplay()
        {
            // Clear existing items in the ComboBox
            CmbMLDBinfoDisplayed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var infoDisplay in BaseClass.infoDisplayList)
            {
                // Trim the platform name
                string trimmedinfoDisplay = infoDisplay.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbMLDBinfoDisplayed.Items.Add(trimmedinfoDisplay);
            }
            // Select the default item "--Select--"
            CmbMLDBinfoDisplayed.SelectedIndex = 0;
        }
        private void SetLetterGap()
        {
            // Clear existing items in the ComboBox
            CmbMLDBlettergap.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var LetterGap in BaseClass.LetterGapList)
            {
                // Trim the platform name
                string trimmedLetterGap = LetterGap.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbMLDBlettergap.Items.Add(trimmedLetterGap);
            }
            // Select the default item "--Select--"
            CmbMLDBlettergap.SelectedIndex = 1;
        }
        private void SetLetterSpeed()
        {
            // Clear existing items in the ComboBox
            CmbMLDBLetterSpeed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Speed in BaseClass.LetterSpeedlist)
            {
                // Trim the platform name
                string trimmedSpeed = Speed.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbMLDBLetterSpeed.Items.Add(trimmedSpeed);
            }
            // Select the default item "--Select--"
            CmbMLDBLetterSpeed.SelectedIndex = 0;
        }
        private void SetFormatType()
        {
            // Clear existing items in the ComboBox
            CmbMLDBFormattype.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var FormatType in BaseClass.FormatsList)
            {
                // Trim the platform name
                string trimmedFormatType = FormatType.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbMLDBFormattype.Items.Add(trimmedFormatType);
            }
            // Select the default item "--Select--"
            CmbMLDBFormattype.SelectedIndex = 0;
        }
        private void SetFontSize()
        {
            // Clear existing items in the ComboBox
            CmbMLDBfontSize.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Font in BaseClass.FontSizeList)
            {
                // Trim the platform name
                string trimmedFont = Font.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbMLDBfontSize.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            CmbMLDBfontSize.SelectedIndex = 4;
        }
        private void SetIPAddress()
        {
            if (PkNumber == 0)
            {


                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("PortNo") && int.TryParse(row["PortNo"].ToString(), out int portno))
                    {
                        int ethernetvalue = Convert.ToInt32(txtMLDBEthernetportno.Text);
                        if (portno == ethernetvalue)
                        {
                            string ipaddress = ipAddressMldb.Text;

                            // Split the IP address into its octets
                            string[] octets = ipaddress.Split('.');

                            string platform = BaseClass.ConvertPlatformToIp(row["Platform"].ToString().Trim());

                            if (octets.Length == 4)
                            {
                                // Update the octets as required
                                octets[0] = "192";
                                octets[1] = "168";
                                octets[2] = platform;
                                octets[3] = ""; // Or any appropriate value

                                // Combine the octets back into a single string
                                string updatedIPAddress = string.Join(".", octets);

                                // Assign the updated IP address back to the text box
                                ipAddressMldb.Text = updatedIPAddress;
                            }
                            else
                            {
                                // Handle error: invalid IP address format
                                MessageBox.Show("Invalid IP address format.");
                            }

                            // Since platform matched and IP is updated, we can break the loop
                            break;
                        }
                    }
                }
            }
        }


        private void panelMLDBCommonSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkboxMLDBAutoerasing_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (checkboxMLDBAutoerasing.Checked)
            {
                // If checked, enable the panel
                txtMLDBErasetime.Enabled = true;
            }
            else
            {
                // If unchecked, disable the panel
                txtMLDBErasetime.Enabled = false;
            }
        }
        private bool ChecktheError(IPAddressControlLib.IPAddressControl ipControl)
        {
            if (string.IsNullOrWhiteSpace(ipControl.Text))
            {
                ipControl.BackColor = Color.Red; // Change background color to red to indicate error
                return true; // Indicate that this control has an error
            }
            else
            {
                ipControl.BackColor = SystemColors.Window; // Reset background color
                return false; // No error for this control
            }
        }
        private bool ChecktheIpError()
        {
            if (lblIpExist.Visible)
            {
                return true;
            }
            return false;
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


        private void btnMLDBSave_Click(object sender, EventArgs e)
        {

            try
            {
                bool hasError = false; // Flag to track if there's any error

                // Check and highlight each required text box
                hasError |= CheckAndHighlightEmptyField(txtMLDBBoardid);
                hasError |= ChecktheError(ipAddressMldb);
                hasError |= ChecktheIpError();
                hasError |= CheckAndHighlightEmptyField(txtMLDBLocation);
                hasError |= CheckAndHighlightEmptyField(txtMLDBEthernetportno);
                hasError |= CheckAndHighlightEmptyField(txtMLDBNooflines);
                hasError |= CheckAndHighlightEmptyField(txtMLDBEnglish);
                hasError |= CheckAndHighlightEmptyField(txtMLDBHindi);
                //hasError |= CheckAndHighlightEmptyField(txtMLDBRegional);

                // If any error is found, display error message and exit the method
                if (hasError)
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {

                    int pdcPort = PdcPortNo;
                    int packetidentifier = 5;
                    int BoardId = Convert.ToInt32(txtMLDBBoardid.Text.Trim());
                    //  string location = txtMLDBLocation.Text.Trim();
                    string location;
                    if (ID != -1)
                    {
                        location = txtMLDBLocation.Text.Trim();
                    }
                    else
                    {
                        location = txtMLDBLocation.Text.Trim() + "_Mldb";
                    }
                    int EthernetPort = Convert.ToInt32(txtMLDBEthernetportno.Text.Trim());

                    string ipaddress = ipAddressMldb.Text.Trim();
                    string platformNo = GetPlatformbyIp(ipaddress).ToString();

                    int noofLines = Convert.ToInt32(txtMLDBNooflines.Text.Trim());
                    bool message = checkMLDBBoxShowMessages.Checked;
                    bool boardRunning = CheckWhichRadioButtonIsChecked();
                    string DisplaySequence = ShowColumnValues("dgvLanguages");
                    string CheckedPlatforms = ShowCheckedPlatforms();
                    string videoType = GetVideoType();
                    string letterSpeed = GetletterSpeed();
                    string FormatType = GetFormatType();
                    string lettergap = Getlettergap();
                    string DisplayEffect = GetDisplayeffect();
                    int fontsize = GetFontSize();
                    string infoDisplayed = GetinfoDisplayed();
                    int DelayTime = Convert.ToInt32(CmbMLDBDelaytime.Text.Trim());
                    bool interoperabilitystatus = tglinteroperability.Checked;

                    int EraseTime;
                    if (int.TryParse(txtMLDBErasetime.Text, out EraseTime))
                    {

                    }
                    else
                    {
                        // Handle the error, e.g., set a default value or show a message to the user
                        EraseTime = 60; // or any other default value// Optionally, you can inform the user about the incorrect input


                    }
                    string defaultEnglish = txtMLDBEnglish.Text.Trim();
                    string defaultRegional = txtMLDBRegional.Text.Trim();
                    string defaultHindi = txtMLDBHindi.Text.Trim();
                    int PortNo = GetPortNo(ethernetPortNo, PdcPortNo);

                    // Show confirmation dialog
                    DialogResult result = MessageBox.Show("Do you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // If the user clicks Yes, proceed with saving the data
                    if (result == DialogResult.Yes)
                    {
                        int rows = HubConfigurationDb.SaveTadbBoard(
                                   ID, pdcPort, BoardId, location, EthernetPort, ipaddress, platformNo, noofLines,
                                  message, boardRunning, DisplaySequence, CheckedPlatforms, videoType, letterSpeed,
                                   FormatType, lettergap, DisplayEffect, fontsize, infoDisplayed, DelayTime,
                                  EraseTime, defaultEnglish, defaultRegional, defaultHindi, PortNo, packetidentifier, interoperabilitystatus);

                        if (rows >= 0)
                        {
                            ReportDb.InsertDatabaseModificationReportData("Mldb Board Added With the Ip " + ipaddress, "4");
                            if (Server._connectedClients.Count > 0)
                            {
                                if (interoperabilitystatus)
                                {

                                    byte[] DataTransferPacket = frmHubConfiguration.PfdDefaultPacket(ipaddress, packetidentifier, letterSpeed, noofLines, videoType, DisplayEffect, fontsize, lettergap, DelayTime, defaultEnglish, defaultRegional, defaultHindi, DisplaySequence, FormatType);
                                    DataTransferPacket = ByteFormation.RemoveFirstAndLast6(DataTransferPacket);
                                    Server.SendMessageToClient(ipaddress, DataTransferPacket);
                                    System.Threading.Thread.Sleep(1000);

                                    byte[] SoftResetPacket = frmBoardDiagnosis.SoftResetPacket(ipaddress, packetidentifier);

                                    SoftResetPacket = ByteFormation.RemoveFirstAndLast6(SoftResetPacket);
                                    Server.SendMessageToClient(ipaddress, SoftResetPacket);

                                    System.Threading.Thread.Sleep(5000);

                                }
                                else
                                {
                                    byte[] DataTransferPacket = frmHubConfiguration.PfdDefaultPacket(ipaddress, packetidentifier, letterSpeed, noofLines, videoType, DisplayEffect, fontsize, lettergap, DelayTime, defaultEnglish, defaultRegional, defaultHindi, DisplaySequence, FormatType);

                                    Server.SendMessageToClient(ipaddress, DataTransferPacket);
                                    System.Threading.Thread.Sleep(1000);

                                    byte[] SoftResetPacket = frmBoardDiagnosis.SoftResetPacket(ipaddress, packetidentifier);
                                    Server.SendMessageToClient(ipaddress, SoftResetPacket);

                                    System.Threading.Thread.Sleep(5000);
                                }
                            }
                            // Show success message for 10 seconds
                            lblStatus.Text = "Board Configuration saved successfully!";
                            lblStatus.ForeColor = Color.Green;
                            //board.Text = location;
                            BaseClass.RecallBoards();




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

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private bool CheckWhichRadioButtonIsChecked()
        {
            if (rdbnMLDBWorking.Checked)
            {
                return true; // rdbnMLDBWorking is checked
            }
            else if (rdbnMLDBNotWorking.Checked)
            {
                return false; // rdbnMLDBNotWorking is checked
            }
            else
            {
                // Handle the case where neither radio button is checked
                // Return a default value or throw an exception if appropriate
                throw new InvalidOperationException("Neither radio button is checked.");
                // Alternatively, you could return a default value:
                // return false; // or true, depending on your logic
            }
        }


        private string GetinfoDisplayed()
        {
            // Get the selected speed from the ComboBox
            string info = CmbMLDBinfoDisplayed.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.infoDisplayDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Info_Displayed"].ToString().Trim() == info.Trim())
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pk_Info_Displayed"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
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
            // Get the selected font size from the ComboBox
            string selectedFontSize = CmbMLDBfontSize.Text.Trim();

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

            // Return a default value or handle the case where no match is found
            return -1;
        }

        private string Getlettergap()
        {
            // Get the selected speed from the ComboBox
            string lettergap = CmbMLDBlettergap.Text.Trim();

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
            string DisplayEffect = CmbMLDBDisplayeffect.Text.Trim();

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
            string format = CmbMLDBFormattype.Text.Trim();

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
            string speed = CmbMLDBLetterSpeed.Text.Trim();

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
            string video = cmbMLDBVideoType.Text.Trim();
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


        private void dgvLanguage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                // Check if the current cell is in the up button column and it is not a header cell
                if (e.ColumnIndex == dgvLanguage.Columns["dgvUpButton"].Index && e.RowIndex >= 0)
                {
                    MoveRowUp(e.RowIndex);
                }

                // Check if the current cell is in the down button column and it is not a header cell
                if (e.ColumnIndex == dgvLanguage.Columns["DgvDown"].Index && e.RowIndex >= 0)
                {
                    MoveRowDown(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void MoveRowUp(int rowIndex)
        {
            try
            {
                // Ensure the row is not already at the top
                if (rowIndex > 0)
                {
                    // Get the row to move and the row above it
                    DataGridViewRow rowToMove = dgvLanguage.Rows[rowIndex];
                    DataGridViewRow rowAbove = dgvLanguage.Rows[rowIndex - 1];

                    // Swap the rows
                    dgvLanguage.Rows.RemoveAt(rowIndex);
                    dgvLanguage.Rows.Insert(rowIndex - 1, rowToMove);

                    // Adjust the selection to reflect the move
                    dgvLanguage.ClearSelection();
                    dgvLanguage.Rows[rowIndex - 1].Selected = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        private void MoveRowDown(int rowIndex)
        {
            // Ensure the row is not already at the bottom
            if (rowIndex < dgvLanguage.Rows.Count - 1)
            {
                // Get the row to move and the row below it
                DataGridViewRow rowToMove = dgvLanguage.Rows[rowIndex];
                dgvLanguage.Rows.RemoveAt(rowIndex);
                dgvLanguage.Rows.Insert(rowIndex + 1, rowToMove);

                // Adjust the selection to reflect the move
                dgvLanguage.ClearSelection();
                dgvLanguage.Rows[rowIndex + 1].Selected = true;
            }
        }
        private List<object> GetColumnValues(string columnName)
        {
            List<object> columnValues = new List<object>();

            // Check if the column exists
            if (dgvLanguage.Columns.Contains(columnName))
            {
                // Loop through each row in the DataGridView
                foreach (DataGridViewRow row in dgvLanguage.Rows)
                {
                    // Get the cell in the specified column
                    DataGridViewCell cell = row.Cells[columnName];

                    // Ensure the cell is not null and not a new row placeholder
                    if (cell != null && !row.IsNewRow)
                    {
                        // Add the cell value to the list
                        columnValues.Add(cell.Value);
                    }
                }
            }

            return columnValues;
        }
        private string ShowColumnValues(string columnName)
        {
            // Retrieve the values from the specified column
            List<object> columnValues = GetColumnValues(columnName);

            // Convert the list of values to a string for display
            string valuesString = string.Join(", ", columnValues);


            return valuesString;
        }

        private void txtMLDBNooflines_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a digit or a control key
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not a digit or control key, handle the event (prevent the character from being entered)
                e.Handled = true;
            }
        }


        private void txtMLDBErasetime_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a digit or a control key
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not a digit or control key, handle the event (prevent the character from being entered)
                e.Handled = true;
            }
        }

        private void checkMLDBBoxShowMessages_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ipAddressMldb_Leave(object sender, EventArgs e)
        {
            try
            {

                string ipAddress = ipAddressMldb.Text.Trim();

                // Get the result tuple from the method
                var result = IsLastOctetInRangeMLDB(ipAddress, 101, 130);
                bool isInRange = result.Item1;
                int lastOctet = result.Item2;

                if (!isInRange)
                {
                    // Display error icon and message
                    errorProviderMLDB.SetError(ipAddressMldb, "The last octet of the IP address must be between 101 and 130.");
                    lblMLDBErrorMessage.Visible = true;
                }
                else
                {
                    // Clear any previous error
                    errorProviderMLDB.SetError(ipAddressMldb, "");
                    lblMLDBErrorMessage.Visible = false;

                    // Use the last octet value if needed
                    txtMLDBBoardid.Text = lastOctet.ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        private (bool, int) IsLastOctetInRangeMLDB(string ipAddressMLDB, int startRange, int endRange)
        {
            try
            {


                // Validate that the input is a proper IP address
                if (IPAddress.TryParse(ipAddressMLDB, out IPAddress parsedIpAddress))
                {
                    // Split the IP address into its octets
                    string[] octets = ipAddressMLDB.Split('.');

                    // Ensure there are exactly 4 octets
                    if (octets.Length == 4)
                    {
                        // Try to parse the last octet
                        if (int.TryParse(octets[3], out int lastOctet))
                        {
                            // Check if the last octet is within the specified range
                            bool isInRange = lastOctet >= startRange && lastOctet <= endRange;
                            return (isInRange, lastOctet);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            // Return false and -1 if the IP address is not valid or other parsing issues occurred
            return (false, -1);
        }
        private int GetPlatformbyIp(string ipAddressMLDB)
        {
            // Validate that the input is a proper IP address
            if (IPAddress.TryParse(ipAddressMLDB, out IPAddress parsedIpAddress))
            {
                // Split the IP address into its octets
                string[] octets = ipAddressMLDB.Split('.');

                // Ensure there are exactly 4 octets
                if (octets.Length == 4)
                {
                    // Try to parse the third octet
                    if (int.TryParse(octets[2], out int thirdOctet))
                    {
                        return thirdOctet;
                    }
                }
            }
            // Return -1 if the IP address is not valid or other parsing issues occurred
            return -1;
        }

        private void ipAddressMldb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Get the selected platform from the ComboBox
                string iptext = ipAddressMldb.Text.Trim();
                string ExistedIp = "";
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("PkeyMasterhub") && int.TryParse(row["PkeyMasterhub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == PkNumber)
                        {
                            ExistedIp = row["IPAddress"].ToString();
                        }

                    }
                }
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                    {
                        string Ipaddress = row["IPAddress"].ToString();

                        if (iptext == Ipaddress && iptext != ExistedIp)
                        {
                            lblIpExist.Visible = true;
                            return;
                        }
                        else
                        {
                            lblIpExist.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        private void frmMLDB_FormClosing(object sender, FormClosingEventArgs e)
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
                ex.ToString();
            }

        }

        private void lblMLDBHaddear_Click(object sender, EventArgs e)
        {

        }

        private void ipAddressMldb_Enter(object sender, EventArgs e)
        {
            ipAddressMldb.BackColor = SystemColors.Window;
            txtMLDBBoardid.BackColor = SystemColors.Window;
        }

        private void txtMLDBEnglish_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(300, 60, "English");
        }

        private void btnHKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(300, 60, "Hindi");
        }

        private void btnRKeyboard_Click(object sender, EventArgs e)
        {
            string localLanguage = "";
            DataTable Languge = messageScriptDb.GetLanguage();
            if (Languge.Columns.Count >= 2)
            {
                foreach (DataRow row in Languge.Rows)
                {
                    string languageName = row["LanguageName"].ToString();

                    // Check if the language is not English or Hindi
                    if (languageName != "English" && languageName != "Hindi")
                    {
                        localLanguage = languageName;
                        break; // Stop after finding the first non-English, non-Hindi language
                    }

                }
            }


            Keyboard(250, 60, localLanguage);
        }

        private void InitializeControls()
        {
            txtMLDBEnglish.Enter += Control_Enter;
            txtMLDBHindi.Enter += Control_Enter;
            txtMLDBRegional.Enter += Control_Enter;
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
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
