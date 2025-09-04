using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ArecaIPIS
{
    public partial class frmIVD : Form
    {
        public frmIVD()
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
            txtIVDEthernetportno.Text = ethernetPortNo.ToString(); // Assuming you have a textbox to display the value

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
            txtIVDEthernetportno.Text = PortNo.ToString(); // Assuming you have a textbox to display the value

        }
        private void btnIVDCommonSettings_Click(object sender, EventArgs e)
        {
            panelIVDCommonSettings.Visible = true;
            panelIVDBoardSettings.Hide();
            panelIVDmediasettings.Hide();
            btnIVDCommonSettings.BackColor = Color.Green;
            btnIVDBoardSettings.BackColor = Color.Black;
            btnIVDmediasettings.BackColor = Color.Black;
        }

        private void btnIVDBoardSettings_Click(object sender, EventArgs e)
        {
            panelIVDBoardSettings.Visible = true;
            panelIVDCommonSettings.Hide();
            panelIVDmediasettings.Hide();
            btnIVDBoardSettings.BackColor = Color.Green;
            btnIVDCommonSettings.BackColor = Color.Black;
            btnIVDmediasettings.BackColor = Color.Black;
        }

        private void btnIVDmediasettings_Click(object sender, EventArgs e)
        {
            panelIVDmediasettings.Visible = true;
            panelIVDCommonSettings.Hide();
            panelIVDBoardSettings.Hide();
            btnIVDmediasettings.BackColor = Color.Green;
            btnIVDCommonSettings.BackColor = Color.Black;
            btnIVDBoardSettings.BackColor = Color.Black;

        }

        private void IVD_Load(object sender, EventArgs e)
        {
            panelIVDCommonSettings.Visible = true;
            panelIVDBoardSettings.Hide();
            panelIVDmediasettings.Hide();
            btnIVDCommonSettings.BackColor = Color.Green;
            btnIVDBoardSettings.BackColor = Color.Black;
            btnIVDmediasettings.BackColor = Color.Black;
            cmbIVDVideoType.SelectedIndex = 0;
            CmbIVDDelaytime.SelectedIndex = 0;
            cmbDisplayType.SelectedIndex = 0;
            cmbIVDNooflines.SelectedIndex = 0;
            SetDisplayEffects();
            SetLetterSpeed();
            SetVolume();
            SetFontSize();
            SetIPAddress();
            SetFormatType();
            SetLetterGap();
            SetIVDOVDLetterGap();
            SetIVDOVDFontSize();
            SetInfoDisplay();
            SetDisplaySequence();
            createPlatforms();
            SetMediaType();
            SetEntryEffects();
            SetIvdOvdSpeed();
            GetDetailsByPk();
            InitializeControls();
        }

        private void GetDetailsByPk()
        {
            try
            {


                if (PkNumber != 0)
                {
                    DataTable boarddetailybyPk = new DataTable();
                    DataTable MediadetailybyPk = new DataTable();
                    foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                    {
                        if (BaseClass.EthernetPorts.Columns.Contains("PkeyMasterhub") && int.TryParse(row["PkeyMasterhub"].ToString(), out int PkMasterHub))
                        {
                            if (PkMasterHub == PkNumber)
                            {
                                boarddetailybyPk = HubConfigurationDb.GetBoardDetails(PkMasterHub);
                                MediadetailybyPk = HubConfigurationDb.GetMediaDetails(PkMasterHub);

                                ipAddressMldb.Text = row["IPAddress"].ToString();
                                txtIVDLocation.Text = row["Location"].ToString();
                                txtIVDEthernetportno.Text = row["EthernetPort"].ToString();
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
                                txtIVDBoardid.Text = row["BoardID"].ToString();
                                cmbIVDNooflines.Text = row["NoofLines"].ToString();
                                int Videovalue = Convert.ToInt32(row["VideoType"].ToString());
                                if (Videovalue == 0)
                                {
                                    cmbIVDVideoType.Text = "Normal";
                                }
                                else
                                {
                                    cmbIVDVideoType.Text = "Reverse";
                                }

                                CmbIVDLetterSpeed.Text = BaseClass.GetLetterSpeed(Convert.ToInt32(row["LetterSpeed"]));
                                CmbIVDFormattype.Text = BaseClass.GetFormattype(Convert.ToInt32(row["FormatType"]));
                                CmbIVDlettergap.Text = BaseClass.GetLetterGap(Convert.ToInt32(row["LetterGap"]));
                                CmbIVDDelaytime.Text = row["DelayTime"].ToString();
                                CmbIVDDisplayeffect.Text = BaseClass.GetDisplayeffect(Convert.ToInt32(row["DisplayEffect"]));
                                CmbIVDfontSize.Text = BaseClass.GetFontSize(Convert.ToInt32(row["FontSize"]));
                                txtIVDErasetime.Text = row["EraseTime"].ToString();

                                CmbIVDinfoDisplayed.Text = BaseClass.GetinfoDisplayed(Convert.ToInt32(row["InfoDisplayed"]));
                                txtIvdEnglish.Text = row["LanEnglish"].ToString();

                                txtIvdHindi.Text = row["LanHindi"].ToString();
                                checkIVDBoxShowMessages.Checked = (bool)row["MessagesEnble"];
                                Boolean value = (bool)row["BoardRunning"];
                                if (value)
                                {
                                    rdbnIVDWorking.Checked = true;
                                }
                                else
                                {
                                    rdbnIVDNotWorking.Checked = true;
                                }
                                ID = Convert.ToInt32(row["FkeyofMasterHub"]);
                                string checkedPlatforms = row["Checkedplatforms"].ToString(); ;
                                setPlatforms(checkedPlatforms);
                                string languages = row["DisplaySequence"].ToString(); ;
                                setDisplayLanguages(dgvLanguage, languages);

                                if (BaseClass.Languages.Count > 2)
                                {
                                    txtIvdRegional.Text = row["LanRegional"].ToString();
                                }

                            }
                        }
                    }
                    foreach (DataRow row in MediadetailybyPk.Rows)
                    {
                        if (MediadetailybyPk.Columns.Contains("fkey_masterHub") && int.TryParse(row["fkey_masterHub"].ToString(), out int PkMasterHub))
                        {
                            if (PkMasterHub == PkNumber)
                            {
                                cmbIVDspeed.Text = BaseClass.GetSpeed(Convert.ToInt32(row["Speed"]));
                                cmbmediatypeIVD.Text = BaseClass.GetMediaTypeSpeed(Convert.ToInt32(row["MediaType"].ToString()));
                                cmbIVDvolume.Text = BaseClass.Getvolume(Convert.ToInt32(row["Volumn"]));
                                cmbIVDmediaentryeffectcode.Text = BaseClass.Getmediaentryeffectcode(Convert.ToInt32(row["MediaEntryEffectCode"]));
                                cmbIVDmessagefontsize.Text = BaseClass.Getmessagefontsize(Convert.ToInt32(row["MessageFontSize"]));
                                cmbIVDmessagecharactergap.Text = BaseClass.Getmessagecharactergap(Convert.ToInt32(row["MessageCharacterGap"]));
                                txtIVDstarttime.Text = row["StartHour"].ToString();
                                txtstartminIVD.Text = row["StartMinute"].ToString();

                                txtIVDendhour.Text = row["EndHour"].ToString();
                                txtIVDendmin.Text = row["EndMinute"].ToString();

                                txtIVDtimedelay.Text = row["TimeDelay"].ToString();
                                cmbDisplayType.SelectedIndex = Convert.ToInt32(row["DisplayType"]);

                                string value = row["MessageTopBottom"].ToString().Trim();
                                if (value.Equals("0"))
                                {
                                    radioButtonIVDbottom.Checked = true;
                                }
                                else
                                {
                                    radioButtonIVDtop.Checked = true;
                                }

                                string value1 = row["MessageLine"].ToString().Trim();
                                if (value1.Equals("1"))
                                {
                                    radioButtonIVDEnable.Checked = true;
                                }
                                else
                                {
                                    radioButtonIVDdisable.Checked = true;
                                }

                            }
                        }
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
        public static void setDisplayLanguages(DataGridView dgvLanguage, string Languages)
        {
            // Clear the DataGridView rows
            dgvLanguage.Rows.Clear();

            // Split the input string into a list of languages, trimming any leading/trailing spaces
            List<string> displaySequence = Languages.Split(',')
                                                     .Select(p => p.Trim())
                                                     .ToList();

            // Base list of display languages
            List<string> displayLanguages = BaseClass.Languages;

            // Find the common languages in both lists
            List<string> commonLanguages = displaySequence.Intersect(displayLanguages).ToList();

            // Find additional languages that are in displayLanguages but not in displaySequence
            List<string> additionalLanguages = displayLanguages.Except(displaySequence).ToList();

            // Add each common language as a new row in the DataGridView
            foreach (string language in commonLanguages)
            {
                dgvLanguage.Rows.Add(language);
            }

            // Add each additional language as a new row in the DataGridView
            foreach (string language in additionalLanguages)
            {
                dgvLanguage.Rows.Add(language);
            }
        }


        private void setPlatforms(string Platforms)
        {
            var checkedPlatforms = Platforms.Split(',')
                                                      .Select(p => p.Trim())
                                                      .ToList();

            foreach (Control control in grupIvdPlatforms.Controls)
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
        private void SetDisplaySequence()
        {
            dgvLanguage.Rows.Clear();
            foreach (string value in BaseClass.Languages)
            {

                dgvLanguage.Rows.Add(value);
                if (value != "English" && value != "Hindi")
                {
                    lblIvdRegional.Visible = true;
                    txtIvdRegional.Visible = true;
                    btnRKeyboard.Visible = true;
                    lblIvdRegional.Text = value; // Replace "Some text" with your desired text
                }
            }


            //lblMLDBRegional.Text = BaseClass.Languages[2];

        }

        private void createPlatforms()
        {
            try
            {


                // Clear existing controls in the GroupBox
                grupIvdPlatforms.Controls.Clear();

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
                    grupIvdPlatforms.Controls.Add(checkBox);

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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void SetDisplayEffects()
        {
            // Clear existing items in the ComboBox
            CmbIVDDisplayeffect.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Effects in BaseClass.DisplayEffects)
            {
                // Trim the platform name
                string trimmedEffects = Effects.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbIVDDisplayeffect.Items.Add(trimmedEffects);
            }
            // Select the default item "--Select--"
            CmbIVDDisplayeffect.SelectedIndex = 0;
        }
        private void SetMediaType()
        {
            // Clear existing items in the ComboBox
            cmbmediatypeIVD.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Effects in BaseClass.MediaTypeList)
            {
                // Trim the platform name
                string trimmedEffects = Effects.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbmediatypeIVD.Items.Add(trimmedEffects);
            }
            // Select the default item "--Select--"
            cmbmediatypeIVD.SelectedIndex = 0;
        }

        private void SetEntryEffects()
        {
            // Clear existing items in the ComboBox
            cmbIVDmediaentryeffectcode.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Effects in BaseClass.EntryEffectList)
            {
                // Trim the platform name
                string trimmedEffects = Effects.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbIVDmediaentryeffectcode.Items.Add(trimmedEffects);
            }
            // Select the default item "--Select--"
            cmbIVDmediaentryeffectcode.SelectedIndex = 0;
        }
        private void SetIPAddress()
        {
            try
            {


                if (PkNumber == 0)
                {


                    foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                    {
                        if (BaseClass.EthernetPorts.Columns.Contains("PortNo") && int.TryParse(row["PortNo"].ToString(), out int portno))
                        {
                            int ethernetvalue = Convert.ToInt32(txtIVDEthernetportno.Text);
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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
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
        private void SetInfoDisplay()
        {
            // Clear existing items in the ComboBox
            CmbIVDinfoDisplayed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var infoDisplay in BaseClass.infoDisplayList)
            {
                // Trim the platform name
                string trimmedinfoDisplay = infoDisplay.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbIVDinfoDisplayed.Items.Add(trimmedinfoDisplay);
            }
            // Select the default item "--Select--"
            CmbIVDinfoDisplayed.SelectedIndex = 0;
        }
        private void SetLetterGap()
        {
            // Clear existing items in the ComboBox
            CmbIVDlettergap.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var LetterGap in BaseClass.LetterGapList)
            {
                // Trim the platform name
                string trimmedLetterGap = LetterGap.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbIVDlettergap.Items.Add(trimmedLetterGap);
            }
            // Select the default item "--Select--"
            CmbIVDlettergap.SelectedIndex = 1;
        }
        private void SetIVDOVDLetterGap()
        {
            // Clear existing items in the ComboBox
            cmbIVDmessagecharactergap.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var LetterGap in BaseClass.MessageCharacterGapList)
            {
                // Trim the platform name
                string trimmedLetterGap = LetterGap.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbIVDmessagecharactergap.Items.Add(trimmedLetterGap);
            }
            // Select the default item "--Select--"
            cmbIVDmessagecharactergap.SelectedIndex = 1;
        }
        private void SetLetterSpeed()
        {
            // Clear existing items in the ComboBox
            CmbIVDLetterSpeed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Speed in BaseClass.LetterSpeedlist)
            {
                // Trim the platform name
                string trimmedSpeed = Speed.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbIVDLetterSpeed.Items.Add(trimmedSpeed);
            }
            // Select the default item "--Select--"
            CmbIVDLetterSpeed.SelectedIndex = 0;
        }

        private void SetVolume()
        {
            // Clear existing items in the ComboBox
            cmbIVDvolume.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Speed in BaseClass.VolumeList)
            {
                // Trim the platform name
                string trimmedSpeed = Speed.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbIVDvolume.Items.Add(trimmedSpeed);
            }
            // Select the default item "--Select--"
            cmbIVDvolume.SelectedIndex = 0;
        }

        private void SetFormatType()
        {
            // Clear existing items in the ComboBox
            CmbIVDFormattype.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var FormatType in BaseClass.FormatsList)
            {
                // Trim the platform name
                string trimmedFormatType = FormatType.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbIVDFormattype.Items.Add(trimmedFormatType);
            }
            // Select the default item "--Select--"
            CmbIVDFormattype.SelectedIndex = 3;
        }
        private void SetIvdOvdSpeed()
        {
            // Clear existing items in the ComboBox
            cmbIVDspeed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var FormatType in BaseClass.SpeedList)
            {
                // Trim the platform name
                string trimmedFormatType = FormatType.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbIVDspeed.Items.Add(trimmedFormatType);
            }
            // Select the default item "--Select--"
            cmbIVDspeed.SelectedIndex = 0;
        }

        private void SetFontSize()
        {
            // Clear existing items in the ComboBox
            CmbIVDfontSize.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Font in BaseClass.FontSizeList)
            {
                // Trim the platform name
                string trimmedFont = Font.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbIVDfontSize.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            CmbIVDfontSize.SelectedIndex = 4;
        }

        private void SetIVDOVDFontSize()
        {
            // Clear existing items in the ComboBox
            cmbIVDmessagefontsize.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Font in BaseClass.MessageFontSizeList)
            {
                // Trim the platform name
                string trimmedFont = Font.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbIVDmessagefontsize.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            cmbIVDmessagefontsize.SelectedIndex = 5;
        }

     


        private void checkboxIVDAutoerasing_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (checkboxIVDAutoerasing.Checked)
            {
                // If checked, enable the panel
                txtIVDErasetime.Enabled = true;
            }
            else
            {
                // If unchecked, disable the panel
                txtIVDErasetime.Enabled = false;
            }
        }

        private void frmIVD_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmHubConfiguration frmhub;
            Form mainForm = Application.OpenForms["frmHubConfiguration"];

            if (mainForm != null)
            {
                frmhub = (frmHubConfiguration)mainForm;
                frmhub.ClearPanel();


            }
        }

       

      

      
        private void txtIVDendmin_TextChanged(object sender, EventArgs e)
        {
            // Get the sender as a TextBox
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                // Check if the input is a valid integer
                if (int.TryParse(textBox.Text, out int input))
                {
                    // Check if the input is within the range of 0 to 23
                    if (input >= 0 && input <= 59)
                    {
                        // Input is valid, set the background color to default
                        textBox.BackColor = SystemColors.Window;
                    }
                    else
                    {
                        // Input is out of range, set the background color to red
                        textBox.BackColor = Color.Red;
                    }
                }
                else
                {
                    // Input is not a valid number, set the background color to red
                    textBox.BackColor = Color.Red;
                }
            }
        }

        private void txtIVDendhour_TextChanged(object sender, EventArgs e)
        {
            try
            {


                // Get the sender as a TextBox
                TextBox textBox = sender as TextBox;

                if (textBox != null)
                {
                    // Check if the input is a valid integer
                    if (int.TryParse(textBox.Text, out int input))
                    {
                        // Check if the input is within the range of 0 to 23
                        if (input >= 0 && input <= 23)
                        {
                            // Input is valid, set the background color to default
                            textBox.BackColor = SystemColors.Window;
                        }
                        else
                        {
                            // Input is out of range, set the background color to red
                            textBox.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        // Input is not a valid number, set the background color to red
                        textBox.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtstartminIVD_TextChanged(object sender, EventArgs e)
        {
            try
            {


                // Get the sender as a TextBox
                TextBox textBox = sender as TextBox;

                if (textBox != null)
                {
                    // Check if the input is a valid integer
                    if (int.TryParse(textBox.Text, out int input))
                    {
                        // Check if the input is within the range of 0 to 23
                        if (input >= 0 && input <= 59)
                        {
                            // Input is valid, set the background color to default
                            textBox.BackColor = SystemColors.Window;
                        }
                        else
                        {
                            // Input is out of range, set the background color to red
                            textBox.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        // Input is not a valid number, set the background color to red
                        textBox.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtIVDstarttime_TextChanged(object sender, EventArgs e)
        {
            try
            {


                // Get the sender as a TextBox
                TextBox textBox = sender as TextBox;

                if (textBox != null)
                {
                    // Check if the input is a valid integer
                    if (int.TryParse(textBox.Text, out int input))
                    {
                        // Check if the input is within the range of 0 to 23
                        if (input >= 0 && input <= 23)
                        {
                            // Input is valid, set the background color to default
                            textBox.BackColor = SystemColors.Window;
                        }
                        else
                        {
                            // Input is out of range, set the background color to red
                            textBox.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        // Input is not a valid number, set the background color to red
                        textBox.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }




        private void txtIVDstarttime_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtIVDstarttime.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 23)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }

        }

        private void txtstartminIVD_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtstartminIVD.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 59)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtIVDendhour_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtIVDendhour.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 23)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtIVDendmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtIVDendmin.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 59)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtIVDtimedelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
        }

        private void txtIVDErasetime_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
        }

        private void ipAddressMldb_Leave(object sender, EventArgs e)
        {

            string ipAddress = ipAddressMldb.Text.Trim();

            // Get the result tuple from the method
            var result = IsLastOctetInRangeMLDB(ipAddress, 71, 100);
            bool isInRange = result.Item1;
            int lastOctet = result.Item2;

            if (!isInRange)
            {
                // Display error icon and message
                errorProviderivovd.SetError(ipAddressMldb, "The last octet of the IP address must be between 71 and 100.");
                lblIvdOvdErrorMessage.Visible = true;
            }
            else
            {
                // Clear any previous error
                errorProviderivovd.SetError(ipAddressMldb, "");
                lblIvdOvdErrorMessage.Visible = false;

                // Use the last octet value if needed
                txtIVDBoardid.Text = lastOctet.ToString();
            }
        }

        private (bool, int) IsLastOctetInRangeMLDB(string ipAddressMLDB, int startRange, int endRange)
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
            // Return false and -1 if the IP address is not valid or other parsing issues occurred
            return (false, -1);
        }

        private void ipAddressMldb_TextChanged(object sender, EventArgs e)
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

        private void dgvLanguage_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private string GetVideoType()
        {
            string videotype = "";
            string video = cmbIVDVideoType.Text.Trim();
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
        private void MoveRowUp(int rowIndex)
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



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                bool hasError = false; // Flag to track if there's any error

                // Check and highlight each required text box
                hasError |= CheckAndHighlightEmptyField(txtIVDBoardid);
                hasError |= ChecktheError(ipAddressMldb);

                hasError |= CheckAndHighlightEmptyField(txtIVDLocation);
                hasError |= CheckAndHighlightEmptyField(txtIVDEthernetportno);
                // hasError |= CheckAndHighlightEmptyField(cmbIVDNooflines);
                hasError |= CheckAndHighlightEmptyField(txtIvdEnglish);
                hasError |= CheckAndHighlightEmptyField(txtIvdHindi);
                hasError |= CheckAndHighlightEmptyField(txtIVDstarttime);
                hasError |= CheckAndHighlightEmptyField(txtstartminIVD);
                hasError |= CheckAndHighlightEmptyField(txtIVDendhour);
                hasError |= CheckAndHighlightEmptyField(txtIVDendmin);
                hasError |= CheckAndHighlightEmptyField(txtIVDtimedelay);


                // hasError |= CheckAndHighlightEmptyField(txtPfdRegional);

                // If any error is found, display error message and exit the method
                if (hasError)
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {

                    int pdcPort = PdcPortNo;
                    int packetidentifier = 6;
                    int BoardId = Convert.ToInt32(txtIVDBoardid.Text.Trim());
                    string location;
                    if (ID != -1)
                    {
                        location = txtIVDLocation.Text.Trim();
                    }
                    else
                    {
                        location = txtIVDLocation.Text.Trim() + "_Ivd";
                    }

                    int EthernetPort = Convert.ToInt32(txtIVDEthernetportno.Text.Trim());

                    string ipaddress = ipAddressMldb.Text.Trim();
                    string platformNo = GetPlatformbyIp(ipaddress).ToString();

                    int noofLines = Convert.ToInt32(cmbIVDNooflines.Text.Trim());
                    bool message = checkIVDBoxShowMessages.Checked;
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
                    int DelayTime = Convert.ToInt32(CmbIVDDelaytime.Text.Trim());
                    string speed = GetSpeed();
                    string mediaType = GetMediaType();
                    string volumn = Getvolumn();
                    string mediaEntryEffectCode = GetmediaEntryEffectCode();
                    string messageFontSize = GetmessageFontSize();
                    string messageCharacterGap = GetmessageCharacterGap();
                    string messageTopBottom = CheckMsgTOPORBottomRadioButtonIsChecked();//top 1 bottom 0
                    string messageLine = CheckEnableORDisableRadioButtonIsChecked(); //Enable 1 disable 0

                    int EraseTime;
                    if (int.TryParse(txtIVDErasetime.Text, out EraseTime))
                    {

                    }
                    else
                    {
                        // Handle the error, e.g., set a default value or show a message to the user
                        EraseTime = 60; // or any other default value// Optionally, you can inform the user about the incorrect input


                    }

                    int startHour = int.Parse(txtIVDstarttime.Text.Trim());
                    int startMinute = int.Parse(txtstartminIVD.Text.Trim());
                    int endHour = int.Parse(txtIVDendhour.Text.Trim());
                    int endMinute = int.Parse(txtIVDendmin.Text.Trim());
                    int timeDelay = int.Parse(txtIVDtimedelay.Text.Trim());
                    int displayType = cmbDisplayType.SelectedIndex;
                    string defaultEnglish = txtIvdEnglish.Text.Trim();
                    string defaultRegional = txtIvdRegional.Text.Trim();
                    string defaultHindi = txtIvdHindi.Text.Trim();
                    int PortNo = GetPortNo(ethernetPortNo, PdcPortNo);
                    bool interoperabilitystatus = tglinteroperability.Checked;

                    // Show confirmation dialog
                    DialogResult result = MessageBox.Show("Do you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // If the user clicks Yes, proceed with saving the data
                    if (result == DialogResult.Yes)
                    {
                        int rows = HubConfigurationDb.SaveIvdOvdboard(
                                ID, pdcPort, BoardId, location, EthernetPort, ipaddress, platformNo, noofLines,
                              message, boardRunning, DisplaySequence, CheckedPlatforms, videoType, letterSpeed,
                               FormatType, lettergap, DisplayEffect, fontsize, infoDisplayed, DelayTime,
                             EraseTime, defaultEnglish, defaultRegional, defaultHindi, PortNo, packetidentifier,
                            speed, mediaType, volumn, mediaEntryEffectCode, messageFontSize, messageCharacterGap,
                                startHour, startMinute, endHour, endMinute, timeDelay, displayType, messageLine, messageTopBottom, interoperabilitystatus);


                        if (rows >= 0)
                        {
                            ReportDb.InsertDatabaseModificationReportData("IVd Board Added With the Ip " + ipaddress, "4");
                            BaseClass.RecallBoards();
                            if (Server._connectedClients.Count > 0)
                            {



                                //board.Text = location;
                                string LangaugeSequence = frmOVD.GetLanguageSequence(DisplaySequence);

                                string[] StArr = new string[6];
                                StArr[0] = defaultEnglish;
                                StArr[1] = defaultHindi;
                                StArr[2] = defaultRegional;
                                StArr[3] = "";
                                StArr[4] = Convert.ToString(message);
                                StArr[5] = volumn.ToString();
                                frmOVD.WriteDefaultText(StArr, ipaddress, message, DelayTime, LangaugeSequence, displayType, noofLines);



                                byte[] DataTransferPacket = frmHubConfiguration.PfdDefaultPacket(ipaddress, packetidentifier, letterSpeed, noofLines, videoType, DisplayEffect, fontsize, lettergap, DelayTime, defaultEnglish, defaultRegional, defaultHindi, DisplaySequence, FormatType);

                                Server.SendMessageToClient(ipaddress, DataTransferPacket);
                            }
                            // Show success message for 10 seconds
                            lblStatus.Text = "Board Configuration saved successfully!";
                            lblStatus.ForeColor = Color.Green;
                            //board.Text = location;




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
                Server.LogError(ex.Message);
            }



        }
        private string GetinfoDisplayed()
        {
            try
            {
                // Get the selected speed from the ComboBox
                string info = CmbIVDinfoDisplayed.Text.Trim();

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
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetmessageCharacterGap()
        {
            // Get the selected speed from the ComboBox
            string format = cmbIVDmessagecharactergap.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.MessageCharacterGapDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Message_Character_Gap"].ToString().Trim() == format)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pk_Message_Character_Gap"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetmessageFontSize()
        {
            // Get the selected speed from the ComboBox
            string format = cmbIVDmessagefontsize.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.MessageFontSizeDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Message_Font_Size"].ToString().Trim() == format)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pk_Message_Font_Size"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetMediaType()
        {
            // Get the selected speed from the ComboBox
            string format = cmbmediatypeIVD.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.MediaTypeDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Media_Type"].ToString().Trim() == format)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pk_IVDOVD_Mediatype"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }

        private int GetFontSize()
        {
            // Get the selected font size from the ComboBox
            string selectedFontSize = CmbIVDfontSize.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.FontSizeDt.Rows)
            {
                // Check if the current row's Size column matches the selected font size
                if (row["Size"].ToString().Trim() == selectedFontSize)
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
            string lettergap = CmbIVDlettergap.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.LetterGapDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["LetterGap"].ToString().Trim() == lettergap)
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
            string DisplayEffect = CmbIVDDisplayeffect.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.DisplayEffectsDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Name"].ToString().Trim() == DisplayEffect)
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
            string format = CmbIVDFormattype.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.FormatsDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Format"].ToString().Trim() == format)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pkey_FormatName"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }

        private string GetmediaEntryEffectCode()
        {
            // Get the selected speed from the ComboBox
            string format = cmbIVDmediaentryeffectcode.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.EntryEffectDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Name"].ToString().Trim() == format)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pkey_DisplayEffect"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }

        private string Getvolumn()
        {
            // Get the selected speed from the ComboBox
            string format = cmbIVDvolume.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.VolumeDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Volume"].ToString().Trim() == format)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pk_IVDOVD_Volume"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }


        private string GetletterSpeed()
        {
            // Get the selected speed from the ComboBox
            string speed = CmbIVDLetterSpeed.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.LetterSpeedDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["LetterSpeed"].ToString().Trim() == speed)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pkey_LetterSpeed"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetSpeed()
        {
            // Get the selected speed from the ComboBox
            string speed = cmbIVDspeed.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.SpeedDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["LetterSpeed"].ToString().Trim() == speed)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Value"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
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
            foreach (Control control in grupIvdPlatforms.Controls)
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

        private bool CheckWhichRadioButtonIsChecked()
        {
            if (rdbnIVDWorking.Checked)
            {
                return true; // rdbnMLDBWorking is checked
            }
            else if (rdbnIVDNotWorking.Checked)
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

        private string CheckMsgTOPORBottomRadioButtonIsChecked()
        {
            if (radioButtonIVDtop.Checked)
            {
                return "1"; // radioButtonIVDtop is checked
            }
            else if (radioButtonIVDbottom.Checked)
            {
                return "0"; // radioButtonIVDbottom is checked
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

        private string CheckEnableORDisableRadioButtonIsChecked()
        {
            if (radioButtonIVDEnable.Checked)
            {
                return "1"; // rdbnMLDBWorking is checked
            }
            else if (radioButtonIVDdisable.Checked)
            {
                return "0"; // rdbnMLDBNotWorking is checked
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

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void txtIvdEnglish_Enter(object sender, EventArgs e)
        {
            txtIvdEnglish.BackColor = SystemColors.Window;
        }

        private void txtIvdHindi_Enter(object sender, EventArgs e)
        {
            txtIvdHindi.BackColor = SystemColors.Window;
        }

        private void txtIvdRegional_Enter(object sender, EventArgs e)
        {
            txtIvdRegional.BackColor = SystemColors.Window;
        }

        private void txtIVDNooflines_Enter(object sender, EventArgs e)
        {
            cmbIVDNooflines.BackColor = SystemColors.Window;
        }

        private void txtIVDLocation_Enter(object sender, EventArgs e)
        {
            txtIVDLocation.BackColor = SystemColors.Window;
        }

        private void ipAddressMldb_Enter(object sender, EventArgs e)
        {
            ipAddressMldb.BackColor = SystemColors.Window;
            txtIVDBoardid.BackColor = SystemColors.Window;
        }

        private void txtIVDstarttime_Enter(object sender, EventArgs e)
        {
            txtIVDstarttime.BackColor = SystemColors.Window;
        }

        private void txtstartminIVD_Enter(object sender, EventArgs e)
        {
            txtstartminIVD.BackColor = SystemColors.Window;
        }

        private void txtIVDendhour_Enter(object sender, EventArgs e)
        {
            txtIVDendhour.BackColor = SystemColors.Window;
        }

        private void txtIVDendmin_Enter(object sender, EventArgs e)
        {
            txtIVDendmin.BackColor = SystemColors.Window;
        }

        private void txtIVDtimedelay_Enter(object sender, EventArgs e)
        {
            txtIVDtimedelay.BackColor = SystemColors.Window;
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(300, 50, "English");
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

            Keyboard(250, 50, localLanguage);
        }

        private void btnHKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(280, 50, "Hindi");
        }


        private void InitializeControls()
        {
            txtIvdEnglish.Enter += Control_Enter;
            txtIvdHindi.Enter += Control_Enter;
            txtIvdRegional.Enter += Control_Enter;
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
