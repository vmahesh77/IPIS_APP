using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ArecaIPIS
{
    public partial class frmOVD : Form
    {
        public frmOVD()
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
            try
            {


                // Extract the numerical part from the button's name
                board = button;
                string buttonName = button.Name;
                string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

                // Convert the numeric part to an integer

                ethernetPortNo = Convert.ToInt32(numericPart);

                // Optionally, use the value immediately or update some controls with this value
                txtOVDEthernetportno.Text = ethernetPortNo.ToString(); // Assuming you have a textbox to display the value
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
        public void SetPassedValue(Button button, int PortNo)
        {
            try
            {


                // Extract the numerical part from the button's name
                board = button;
                string buttonName = button.Name;
                string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

                // Convert the numeric part to an integer

                PdcPortNo = Convert.ToInt32(numericPart);

                // Optionally, use the value immediately or update some controls with this value
                txtOVDEthernetportno.Text = PortNo.ToString(); // Assuming you have a textbox to display the value
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void btnOVDCommonSettings_Click(object sender, EventArgs e)
        {
            panelOVDCommonSettings.Visible = true;
            panelOVDmediasettings.Hide();
            panelOVDBoardSettings.Hide();
            btnOVDCommonSettings.BackColor = Color.Green;
            btnOVDBoardSettings.BackColor = Color.Black;
            btnovdmediasettings.BackColor = Color.Black;
        }

        private void btnOVDBoardSettings_Click(object sender, EventArgs e)
        {
            panelOVDBoardSettings.Visible = true;
            panelOVDmediasettings.Hide();
            panelOVDCommonSettings.Hide();
            btnOVDBoardSettings.BackColor = Color.Green;
            btnOVDCommonSettings.BackColor = Color.Black;
            btnovdmediasettings.BackColor = Color.Black;
        }

        private void btnovdmediasettings_Click(object sender, EventArgs e)
        {
            panelOVDmediasettings.Visible = true;
            panelOVDCommonSettings.Hide();
            panelOVDBoardSettings.Hide();
            btnovdmediasettings.BackColor = Color.Green;
            btnOVDBoardSettings.BackColor = Color.Black;
            btnOVDCommonSettings.BackColor = Color.Black;
        }

        private void OVD_Load(object sender, EventArgs e)
        {
            try
            {


                panelOVDCommonSettings.Visible = true;
                panelOVDmediasettings.Hide();
                panelOVDBoardSettings.Hide();
                btnOVDCommonSettings.BackColor = Color.Green;
                btnovdmediasettings.BackColor = Color.Black;
                btnOVDBoardSettings.BackColor = Color.Black;
                cmbOVDVideoType.SelectedIndex = 0;
                CmbOVDDelaytime.SelectedIndex = 0;
                cmbDisplayType.SelectedIndex = 0;
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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }








        private void panelMLDBCommonSettings_Paint(object sender, PaintEventArgs e)
        {

        }



        private void lblOVDSec_Click(object sender, EventArgs e)
        {

        }


        private void SetDisplayEffects()
        {
            try
            {


                // Clear existing items in the ComboBox
                CmbOVDDisplayeffect.Items.Clear();
                // Assuming BaseClass.Platforms is a collection of platform names
                foreach (var Effects in BaseClass.DisplayEffects)
                {
                    // Trim the platform name
                    string trimmedEffects = Effects.Trim();

                    // Add the trimmed platform name to the ComboBox
                    CmbOVDDisplayeffect.Items.Add(trimmedEffects);
                }
                // Select the default item "--Select--"
                CmbOVDDisplayeffect.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void frmOVD_FormClosing(object sender, FormClosingEventArgs e)
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
                                txtOVDLocation.Text = row["Location"].ToString();
                                txtOVDEthernetportno.Text = row["EthernetPort"].ToString();
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
                                txtOVDBoardid.Text = row["BoardID"].ToString();
                                CmbOVDNooflines.Text = row["NoofLines"].ToString();
                                int Videovalue = Convert.ToInt32(row["VideoType"].ToString());
                                if (Videovalue == 0)
                                {
                                    cmbOVDVideoType.Text = "Normal";
                                }
                                else
                                {
                                    cmbOVDVideoType.Text = "Reverse";
                                }

                                CmbOVDLetterSpeed.Text = BaseClass.GetLetterSpeed(Convert.ToInt32(row["LetterSpeed"]));
                                CmbOVDFormattype.Text = BaseClass.GetFormattype(Convert.ToInt32(row["FormatType"]));
                                CmbOVDlettergap.Text = BaseClass.GetLetterGap(Convert.ToInt32(row["LetterGap"]));
                                CmbOVDDelaytime.Text = row["DelayTime"].ToString();
                                CmbOVDDisplayeffect.Text = BaseClass.GetDisplayeffect(Convert.ToInt32(row["DisplayEffect"]));
                                CmbOVDfontSize.Text = BaseClass.GetFontSize(Convert.ToInt32(row["FontSize"]));
                                txtOVDErasetime.Text = row["EraseTime"].ToString();

                                CmbOVDinfoDisplayed.Text = BaseClass.GetinfoDisplayed(Convert.ToInt32(row["InfoDisplayed"]));
                                txtOVDEnglish.Text = row["LanEnglish"].ToString();

                                txtOVDHindi.Text = row["LanHindi"].ToString();
                                checkOVDBoxShowMessages.Checked = (bool)row["MessagesEnble"];
                                Boolean value = (bool)row["BoardRunning"];
                                if (value)
                                {
                                    rdbnOVDWorking.Checked = true;
                                }
                                else
                                {
                                    rdbnOVDNotWorking.Checked = true;
                                }
                                ID = Convert.ToInt32(row["FkeyofMasterHub"]);
                                string checkedPlatforms = row["Checkedplatforms"].ToString(); ;
                                setPlatforms(checkedPlatforms);
                                string languages = row["DisplaySequence"].ToString(); ;
                                setDisplayLanguages(dgvLanguage, languages);

                                if (BaseClass.Languages.Count > 2)
                                {
                                    txtOVDRegional.Text = row["LanRegional"].ToString();
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
                                cmbOVDspeed.Text = BaseClass.GetSpeed(Convert.ToInt32(row["Speed"]));
                                cmbmediatypeOVD.Text = BaseClass.GetMediaTypeSpeed(Convert.ToInt32(row["MediaType"].ToString()));
                                cmbOVDvolume.Text = BaseClass.Getvolume(Convert.ToInt32(row["Volumn"]));
                                cmbOVDmediaentryeffectcode.Text = BaseClass.Getmediaentryeffectcode(Convert.ToInt32(row["MediaEntryEffectCode"]));
                                cmbOVDmessagefontsize.Text = BaseClass.Getmessagefontsize(Convert.ToInt32(row["MessageFontSize"]));
                                cmbOVDmessagecharactergap.Text = BaseClass.Getmessagecharactergap(Convert.ToInt32(row["MessageCharacterGap"]));
                                txtOVDstarttime.Text = row["StartHour"].ToString();
                                txtstartminOVD.Text = row["StartMinute"].ToString();

                                txtOVDendhour.Text = row["EndHour"].ToString();
                                txtOVDendmin.Text = row["EndMinute"].ToString();

                                txtOVDtimedelay.Text = row["TimeDelay"].ToString();

                                cmbDisplayType.SelectedIndex = Convert.ToInt32(row["DisplayType"]);

                                string value = row["MessageTopBottom"].ToString().Trim();
                                if (value.Equals("0"))
                                {
                                    radioButtonOVDbottom.Checked = true;
                                }
                                else
                                {
                                    radioButtonOVDtop.Checked = true;
                                }

                                string value1 = row["MessageLine"].ToString().Trim();
                                if (value1.Equals("1"))
                                {
                                    radioButtonOVDEnable.Checked = true;
                                }
                                else
                                {
                                    radioButtonOVDdisable.Checked = true;
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
            try
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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private void setPlatforms(string Platforms)
        {
            try
            {


                var checkedPlatforms = Platforms.Split(',')
                                                          .Select(p => p.Trim())
                                                          .ToList();

                foreach (Control control in grupOVDPlatforms.Controls)
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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void SetDisplaySequence()
        {

            try
            {


                dgvLanguage.Rows.Clear();
                foreach (string value in BaseClass.Languages)
                {

                    dgvLanguage.Rows.Add(value);
                    if (value != "English" && value != "Hindi")
                    {
                        lblOVDRegional.Visible = true;
                        txtOVDRegional.Visible = true;
                        btnRKeyboard.Visible = true;
                        lblOVDRegional.Text = value; // Replace "Some text" with your desired text
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            //lblMLDBRegional.Text = BaseClass.Languages[2];

        }

        private void createPlatforms()
        {
            try
            {


                // Clear existing controls in the GroupBox
                grupOVDPlatforms.Controls.Clear();

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
                    grupOVDPlatforms.Controls.Add(checkBox);

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

        private void SetMediaType()
        {
            try
            {

                // Clear existing items in the ComboBox
                cmbmediatypeOVD.Items.Clear();
                // Assuming BaseClass.Platforms is a collection of platform names
                foreach (var Effects in BaseClass.MediaTypeList)
                {
                    // Trim the platform name
                    string trimmedEffects = Effects.Trim();

                    // Add the trimmed platform name to the ComboBox
                    cmbmediatypeOVD.Items.Add(trimmedEffects);
                }
                // Select the default item "--Select--"
                cmbmediatypeOVD.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void SetEntryEffects()
        {
            try
            {


                // Clear existing items in the ComboBox
                cmbOVDmediaentryeffectcode.Items.Clear();
                // Assuming BaseClass.Platforms is a collection of platform names
                foreach (var Effects in BaseClass.EntryEffectList)
                {
                    // Trim the platform name
                    string trimmedEffects = Effects.Trim();

                    // Add the trimmed platform name to the ComboBox
                    cmbOVDmediaentryeffectcode.Items.Add(trimmedEffects);
                }
                // Select the default item "--Select--"
                cmbOVDmediaentryeffectcode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
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
                            int ethernetvalue = Convert.ToInt32(txtOVDEthernetportno.Text);
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
            try
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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return false;
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
            CmbOVDinfoDisplayed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var infoDisplay in BaseClass.infoDisplayList)
            {
                // Trim the platform name
                string trimmedinfoDisplay = infoDisplay.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbOVDinfoDisplayed.Items.Add(trimmedinfoDisplay);
            }
            // Select the default item "--Select--"
            CmbOVDinfoDisplayed.SelectedIndex = 0;
        }
        private void SetLetterGap()
        {
            // Clear existing items in the ComboBox
            CmbOVDlettergap.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var LetterGap in BaseClass.LetterGapList)
            {
                // Trim the platform name
                string trimmedLetterGap = LetterGap.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbOVDlettergap.Items.Add(trimmedLetterGap);
            }
            // Select the default item "--Select--"
            CmbOVDlettergap.SelectedIndex = 1;
        }
        private void SetIVDOVDLetterGap()
        {
            // Clear existing items in the ComboBox
            cmbOVDmessagecharactergap.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var LetterGap in BaseClass.MessageCharacterGapList)
            {
                // Trim the platform name
                string trimmedLetterGap = LetterGap.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbOVDmessagecharactergap.Items.Add(trimmedLetterGap);
            }
            // Select the default item "--Select--"
            cmbOVDmessagecharactergap.SelectedIndex = 1;
        }
        private void SetLetterSpeed()
        {
            // Clear existing items in the ComboBox
            CmbOVDLetterSpeed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Speed in BaseClass.LetterSpeedlist)
            {
                // Trim the platform name
                string trimmedSpeed = Speed.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbOVDLetterSpeed.Items.Add(trimmedSpeed);
            }
            // Select the default item "--Select--"
            CmbOVDLetterSpeed.SelectedIndex = 0;
        }

        private void SetVolume()
        {
            // Clear existing items in the ComboBox
            cmbOVDvolume.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Speed in BaseClass.VolumeList)
            {
                // Trim the platform name
                string trimmedSpeed = Speed.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbOVDvolume.Items.Add(trimmedSpeed);
            }
            // Select the default item "--Select--"
            cmbOVDvolume.SelectedIndex = 0;
        }

        private void SetFormatType()
        {
            // Clear existing items in the ComboBox
            CmbOVDFormattype.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var FormatType in BaseClass.FormatsList)
            {
                // Trim the platform name
                string trimmedFormatType = FormatType.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbOVDFormattype.Items.Add(trimmedFormatType);
            }
            // Select the default item "--Select--"
            CmbOVDFormattype.SelectedIndex = 3;
        }
        private void SetIvdOvdSpeed()
        {
            // Clear existing items in the ComboBox
            cmbOVDspeed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var FormatType in BaseClass.SpeedList)
            {
                // Trim the platform name
                string trimmedFormatType = FormatType.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbOVDspeed.Items.Add(trimmedFormatType);
            }
            // Select the default item "--Select--"
            cmbOVDspeed.SelectedIndex = 0;
        }

        private void SetFontSize()
        {
            // Clear existing items in the ComboBox
            CmbOVDfontSize.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Font in BaseClass.FontSizeList)
            {
                // Trim the platform name
                string trimmedFont = Font.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbOVDfontSize.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            CmbOVDfontSize.SelectedIndex = 4;
        }

        private void SetIVDOVDFontSize()
        {
            // Clear existing items in the ComboBox
            cmbOVDmessagefontsize.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Font in BaseClass.MessageFontSizeList)
            {
                // Trim the platform name
                string trimmedFont = Font.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbOVDmessagefontsize.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            cmbOVDmessagefontsize.SelectedIndex = 5;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {



                bool hasError = false; // Flag to track if there's any error

                // Check and highlight each required text box
                hasError |= CheckAndHighlightEmptyField(txtOVDBoardid);
                hasError |= ChecktheError(ipAddressMldb);
                hasError |= ChecktheIpError();
                hasError |= CheckAndHighlightEmptyField(txtOVDLocation);
                hasError |= CheckAndHighlightEmptyField(txtOVDEthernetportno);
                //   hasError |= CheckAndHighlightEmptyField(CmbOVDNooflines);
                hasError |= CheckAndHighlightEmptyField(txtOVDEnglish);
                hasError |= CheckAndHighlightEmptyField(txtOVDHindi);
                hasError |= CheckAndHighlightEmptyField(txtOVDstarttime);
                hasError |= CheckAndHighlightEmptyField(txtstartminOVD);
                hasError |= CheckAndHighlightEmptyField(txtOVDendhour);
                hasError |= CheckAndHighlightEmptyField(txtOVDendmin);
                hasError |= CheckAndHighlightEmptyField(txtOVDtimedelay);


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
                    int packetidentifier = 7;
                    int BoardId = Convert.ToInt32(txtOVDBoardid.Text.Trim());
                    string location;
                    if (ID != -1)
                    {
                        location = txtOVDLocation.Text.Trim();
                    }
                    else
                    {
                        location = txtOVDLocation.Text.Trim() + "_Ovd";
                    }

                    int EthernetPort = Convert.ToInt32(txtOVDEthernetportno.Text.Trim());

                    string ipaddress = ipAddressMldb.Text.Trim();
                    string platformNo = GetPlatformbyIp(ipaddress).ToString();

                    int noofLines = Convert.ToInt32(CmbOVDNooflines.Text.Trim());
                    bool message = checkOVDBoxShowMessages.Checked;
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
                    int DelayTime = Convert.ToInt32(CmbOVDDelaytime.Text.Trim());
                    string speed = GetSpeed();
                    string mediaType = GetMediaType();
                    string volumn = Getvolumn();
                    string mediaEntryEffectCode = GetmediaEntryEffectCode();
                    string messageFontSize = GetmessageFontSize();
                    string messageCharacterGap = GetmessageCharacterGap();
                    string messageTopBottom = CheckMsgTOPORBottomRadioButtonIsChecked();//top 1 bottom 0
                    string messageLine = CheckEnableORDisableRadioButtonIsChecked(); //Enable 1 disable 0

                    int EraseTime;
                    if (int.TryParse(txtOVDErasetime.Text, out EraseTime))
                    {

                    }
                    else
                    {
                        // Handle the error, e.g., set a default value or show a message to the user
                        EraseTime = 60; // or any other default value// Optionally, you can inform the user about the incorrect input


                    }

                    int startHour = int.Parse(txtOVDstarttime.Text.Trim());
                    int startMinute = int.Parse(txtstartminOVD.Text.Trim());
                    int endHour = int.Parse(txtOVDendhour.Text.Trim());
                    int endMinute = int.Parse(txtOVDendmin.Text.Trim());
                    int timeDelay = int.Parse(txtOVDtimedelay.Text.Trim());
                    int displayType = cmbDisplayType.SelectedIndex;

                    string defaultEnglish = txtOVDEnglish.Text.Trim();
                    string defaultRegional = txtOVDRegional.Text.Trim();
                    string defaultHindi = txtOVDHindi.Text.Trim();
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
                            ReportDb.InsertDatabaseModificationReportData("ovd Board Added With the Ip " + ipaddress, "4");
                            // Show success message for 10 seconds
                            lblStatus.Text = "Board Configuration saved successfully!";
                            lblStatus.ForeColor = Color.Green;
                            BaseClass.RecallBoards();
                            if (Server._connectedClients.Count > 0)
                            {

                                //board.Text = location;
                                string LangaugeSequence = GetLanguageSequence(DisplaySequence);

                                string[] StArr = new string[6];
                                StArr[0] = defaultEnglish;
                                StArr[1] = defaultHindi;
                                StArr[2] = defaultRegional;
                                StArr[3] = "";
                                StArr[4] = Convert.ToString(message);
                                StArr[5] = volumn.ToString();
                                WriteDefaultText(StArr, ipaddress, message, DelayTime, LangaugeSequence, displayType, noofLines);

                                //string[] StArr = new string[6];
                                //StArr[0] = DefEnglish;
                                //StArr[1] = Defhindi;
                                //StArr[2] = DefaultR1;
                                //StArr[3] = DefaultR2;
                                //StArr[4] = Convert.ToString(MsgTop);
                                //StArr[5] = MediaVolume.ToString();
                                //WriteDefaultText(StArr, IPaddress, Msg, delayTime, Lanstr, DisplayType, NoofLines);


                                // WriteDefaultText(string[] strarr, string Ipaddress, bool Msg, Int32 DispStaytime, String LangSeq, int DisplayType, int NoofLines)


                                byte[] DataTransferPacket = frmHubConfiguration.PfdDefaultPacket(ipaddress, packetidentifier, letterSpeed, noofLines, videoType, DisplayEffect, fontsize, lettergap, DelayTime, defaultEnglish, defaultRegional, defaultHindi, DisplaySequence, FormatType);

                                Server.SendMessageToClient(ipaddress, DataTransferPacket);
                            }


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

        public static StringBuilder WriteDefaultText(string[] strarr, string Ipaddress, bool Msg, Int32 DispStaytime, String LangSeq, int DisplayType, int NoofLines)
        {
            try
            {

                if (Server._connectedClients.TryGetValue(Ipaddress, out TcpClient client))
                {


                    string sep = "~";
                    StringBuilder Textfile = new StringBuilder();
                    //DataTable DataPart = dt.Tables[1];
                    DataTable dr = new DataTable();
                    try
                    {

                        for (int i = 0; i < strarr.Length; i++)
                        {

                            if (strarr[i] != "")
                            {

                                Textfile.Append(strarr[i] + sep);
                            }
                            if (i == 2)
                            {

                                Textfile.Append(strarr[i] + sep);
                            }

                            if (i == strarr.Length - 1)
                            {
                                Textfile.Append(Environment.NewLine);
                            }
                        }
                        Textfile.Append(LangSeq);
                        //CreateVdcFile(Textfile);
                        string displaytype = DispStaytime.ToString() + "#" + LangSeq + "#" + DisplayType.ToString() + "#" + NoofLines;
                        createftpfileDefault(Textfile.ToString(), Ipaddress, "ArecaVdc", "Areca");
                        createftpfileDispStayTime(displaytype.ToString(), Ipaddress, "ArecaVdc", "Areca");
                        string MsgEnable;
                        if (Msg == true)
                        {
                            MsgEnable = "MENABLE#";
                        }
                        else
                        {
                            MsgEnable = "MDISABLE#";
                        }
                        // BusinessLogicLayer.createftpfileMSG(MsgEnable, Ipaddress, "ArecaVdc", "Areca");

                    }
                    catch (Exception ex)
                    {
                        Server.LogError(ex.Message);
                        ///return null;
                    }


                    return Textfile;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }

        public static void createftpfileDefault(string textContent, string ftpUrl, string userName, string password)
        {
            try
            {
                if (Server._connectedClients.TryGetValue(ftpUrl, out TcpClient client))
                {


                    CreateVdcFile(textContent, ftpUrl);

                    string testpath = ftpUrl;
                    string fullpath = "FTP://" + ftpUrl + "/DefaultText.txt";
                    // Get the object used to communicate with the server.
                    //FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(path + "Config.xml");
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fullpath);
                    request.Method = WebRequestMethods.Ftp.UploadFile;

                    //request.Credentials = new NetworkCredential(userName, password);

                    // convert contents to byte.
                    //byte[] fileContents = Encoding.ASCII.GetBytes(textContent); 
                    byte[] fileContents = Encoding.Unicode.GetBytes(textContent);

                    request.ContentLength = fileContents.Length;

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                        requestStream.Close();
                        requestStream.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            //using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            //{
            //    //Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            //}
        }
        public static string GetLanguageSequence(string DisplaySequence)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(DisplaySequence))
                {
                    return string.Empty;
                }

                string[] languages = DisplaySequence.Split(',');
                List<string> languageCodes = new List<string>();

                foreach (string language in languages)
                {
                    switch (language.Trim().ToLower())
                    {
                        case "english":
                            languageCodes.Add("ENG");
                            break;
                        case "hindi":
                            languageCodes.Add("HND");
                            break;
                        default:
                            languageCodes.Add("REG");
                            break;
                    }
                }


                return string.Join(",", languageCodes);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return null;
            }
        }


        public static void CreateVdcFile(string textfile, string IpAddress)
        {
            StreamWriter swExtLogFiles;
            //string vdcfile = "Test";
            try
            {
                if (Server._connectedClients.TryGetValue(IpAddress, out TcpClient client))
                {



                    DirectoryInfo logDirInfos = null;
                    FileInfo logFileInfos;
                    string logFilePaths = "C:\\ShareToAll\\";
                    logFilePaths = logFilePaths + "Default.txt";
                    logFileInfos = new FileInfo(logFilePaths);
                    logDirInfos = new DirectoryInfo(logFileInfos.DirectoryName);
                    if (!logDirInfos.Exists) logDirInfos.Create();
                    if (!logFileInfos.Exists)
                    {
                        logFileInfos.Create();
                    }

                    File.WriteAllText(logFilePaths, String.Empty);
                    swExtLogFiles = new StreamWriter(logFilePaths, true);

                    swExtLogFiles.Write(textfile);
                    swExtLogFiles.Flush();
                    swExtLogFiles.Close();
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        private string ShowColumnValues(string columnName)
        {
            // Retrieve the values from the specified column
            List<object> columnValues = GetColumnValues(columnName);

            // Convert the list of values to a string for display
            string valuesString = string.Join(", ", columnValues);


            return valuesString;
        }
        private string GetVideoType()
        {
            string videotype = "";
            string video = cmbOVDVideoType.Text.Trim();
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
        public static void createftpfileDispStayTime(string textContent, string ftpUrl, string userName, string password)
        {
            try
            {


                string testpath = ftpUrl;
                string fullpath = "FTP://" + ftpUrl + "/DispStayTime/DispStayTime.txt";
                // Get the object used to communicate with the server.
                //FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(path + "Config.xml");
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fullpath);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                //request.Credentials = new NetworkCredential(userName, password);

                // convert contents to byte.
                byte[] fileContents = Encoding.ASCII.GetBytes(textContent); ;

                request.ContentLength = fileContents.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                    requestStream.Close();
                    requestStream.Dispose();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            //using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            //{
            //    //Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            //}
        }

        private List<object> GetColumnValues(string columnName)
        {
            List<object> columnValues = new List<object>();
            try
            {

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

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return columnValues;
        }
        private string GetinfoDisplayed()
        {
            // Get the selected speed from the ComboBox
            string info = CmbOVDinfoDisplayed.Text.Trim();

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
        private string GetmessageCharacterGap()
        {
            // Get the selected speed from the ComboBox
            string format = cmbOVDmessagecharactergap.Text.Trim();

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
            try
            {


                // Get the selected speed from the ComboBox
                string format = cmbOVDmessagefontsize.Text.Trim();

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
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetMediaType()
        {
            try
            {


                // Get the selected speed from the ComboBox
                string format = cmbmediatypeOVD.Text.Trim();

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
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }

        private int GetFontSize()
        {
            try
            {


                // Get the selected font size from the ComboBox
                string selectedFontSize = CmbOVDfontSize.Text.Trim();

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
            try
            {


                // Get the selected speed from the ComboBox
                string lettergap = CmbOVDlettergap.Text.Trim();

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
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetDisplayeffect()
        {
            try
            {


                // Get the selected speed from the ComboBox
                string DisplayEffect = CmbOVDDisplayeffect.Text.Trim();

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
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetFormatType()
        {
            try
            {


                // Get the selected speed from the ComboBox
                string format = CmbOVDFormattype.Text.Trim();

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
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            // Return a default value or handle the case where no match is found
            return "ID not found";
        }

        private string GetmediaEntryEffectCode()
        {
            try
            {


                // Get the selected speed from the ComboBox
                string format = cmbOVDmediaentryeffectcode.Text.Trim();

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
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            // Return a default value or handle the case where no match is found
            return "ID not found";
        }

        private string Getvolumn()
        {
            // Get the selected speed from the ComboBox
            string format = cmbOVDvolume.Text.Trim();

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
            string speed = CmbOVDLetterSpeed.Text.Trim();

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
            string speed = cmbOVDspeed.Text.Trim();

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
            try
            {


                // Loop through each control in the GroupBox
                foreach (Control control in grupOVDPlatforms.Controls)
                {
                    // Check if the control is a CheckBox and if it is checked
                    if (control is CheckBox checkBox && checkBox.Checked)
                    {
                        // Add the text of the checked CheckBox to the list
                        checkedPlatforms.Add(checkBox.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
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
                        // Try to parse the third octet
                        if (int.TryParse(octets[2], out int thirdOctet))
                        {
                            return thirdOctet;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            // Return -1 if the IP address is not valid or other parsing issues occurred
            return -1;
        }

        private bool CheckWhichRadioButtonIsChecked()
        {
            if (rdbnOVDWorking.Checked)
            {
                return true; // rdbnMLDBWorking is checked
            }
            else if (rdbnOVDNotWorking.Checked)
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
            if (radioButtonOVDtop.Checked)
            {
                return "1"; // radioButtonIVDtop is checked
            }
            else if (radioButtonOVDbottom.Checked)
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
            if (radioButtonOVDEnable.Checked)
            {
                return "1"; // rdbnMLDBWorking is checked
            }
            else if (radioButtonOVDdisable.Checked)
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

        private void ipAddressMldb_Leave(object sender, EventArgs e)
        {
            try
            {
                string ipAddress = ipAddressMldb.Text.Trim();

                // Get the result tuple from the method
                var result = IsLastOctetInRangeMLDB(ipAddress, 40, 70);
                bool isInRange = result.Item1;
                int lastOctet = result.Item2;

                if (!isInRange)
                {
                    // Display error icon and message
                    errorProviderivovd.SetError(ipAddressMldb, "The last octet of the IP address must be between 40 and 70.");
                    lblIvdOvdErrorMessage.Visible = true;
                }
                else
                {
                    // Clear any previous error
                    errorProviderivovd.SetError(ipAddressMldb, "");
                    lblIvdOvdErrorMessage.Visible = false;

                    // Use the last octet value if needed
                    txtOVDBoardid.Text = lastOctet.ToString();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
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
                Server.LogError(ex.Message);
            }
            // Return false and -1 if the IP address is not valid or other parsing issues occurred
            return (false, -1);
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
                Server.LogError(ex.Message);
            }
        }

        private void ipAddressMldb_Enter(object sender, EventArgs e)
        {
            ipAddressMldb.BackColor = SystemColors.Window;
            txtOVDBoardid.BackColor = SystemColors.Window;
        }

        private void checkboxOVDAutoerasing_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (checkboxOVDAutoerasing.Checked)
            {
                // If checked, enable the panel
                txtOVDErasetime.Enabled = true;
            }
            else
            {
                // If unchecked, disable the panel
                txtOVDErasetime.Enabled = false;
            }
        }

        private void txtOVDEnglish_Enter(object sender, EventArgs e)
        {
            txtOVDEnglish.BackColor = SystemColors.Window;
        }

        private void txtOVDHindi_Enter(object sender, EventArgs e)
        {
            txtOVDHindi.BackColor = SystemColors.Window;
        }

        private void txtOVDRegional_Enter(object sender, EventArgs e)
        {
            txtOVDRegional.BackColor = SystemColors.Window;
        }

        private void txtOVDNooflines_Enter(object sender, EventArgs e)
        {
            CmbOVDNooflines.BackColor = SystemColors.Window;
        }

        private void txtOVDLocation_Enter(object sender, EventArgs e)
        {
            txtOVDLocation.BackColor = SystemColors.Window;
        }

        private void txtOVDstarttime_KeyPress(object sender, KeyPressEventArgs e)
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
                    string newText = txtOVDstarttime.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 23)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtstartminOVD_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtstartminOVD.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 59)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }


        private void txtOVDendhour_KeyPress(object sender, KeyPressEventArgs e)
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
                    string newText = txtOVDendhour.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 23)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtOVDendmin_KeyPress(object sender, KeyPressEventArgs e)
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
                    string newText = txtOVDendmin.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 59)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtOVDtimedelay_KeyPress(object sender, KeyPressEventArgs e)
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
                    string newText = txtOVDtimedelay.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 59)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtOVDNooflines_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
        }

        private void txtOVDErasetime_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
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
                        break;
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
            txtOVDEnglish.Enter += Control_Enter;
            txtOVDHindi.Enter += Control_Enter;
            txtOVDRegional.Enter += Control_Enter;
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
                ex.ToString();
                MessageBox.Show("The panel or another object was disposed and cannot be accessed. " +
                                "Please check the state of your objects and try again.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
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
                Server.LogError(ex.Message);
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

        private void txtOVDstarttime_Enter(object sender, EventArgs e)
        {
            txtOVDstarttime.BackColor = SystemColors.Window;

        }

        private void txtstartminOVD_Enter(object sender, EventArgs e)
        {
            txtstartminOVD.BackColor = SystemColors.Window;

        }

        private void txtOVDendhour_Enter(object sender, EventArgs e)
        {
            txtOVDendhour.BackColor = SystemColors.Window;

        }

        private void txtOVDendmin_Enter(object sender, EventArgs e)
        {
            txtOVDendmin.BackColor = SystemColors.Window;

        }

        private void txtOVDtimedelay_Enter(object sender, EventArgs e)
        {
            txtOVDtimedelay.BackColor = SystemColors.Window;

        }
    }
}
