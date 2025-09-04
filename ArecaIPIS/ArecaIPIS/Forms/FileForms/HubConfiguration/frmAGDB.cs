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
    public partial class frmAGDB : Form
    {
        public string dynamicPortNo { get; set; }

        public int ethernetPortNo { get; set; }
        public int PkNumber { get; set; }
        public int PdcPortNo { get; set; }
        Button board;
        int ID;
        public frmAGDB()
        {
            InitializeComponent();
        }



        public void SetPassedValue(Button button)
        {
            try
            {

                board = button;
                string buttonName = button.Name;
                string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());
                ethernetPortNo = Convert.ToInt32(numericPart);


                txtAGDBEthernetportno.Text = ethernetPortNo.ToString();
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



                board = button;
                string buttonName = button.Name;
                string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());
                PdcPortNo = Convert.ToInt32(numericPart);

                txtAGDBEthernetportno.Text = PortNo.ToString();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }
        }
        private void btnAGDBCommonSettings_Click(object sender, EventArgs e)
        {
            panelAGDBCommonSettings.Visible = true;
            panelAGDBBoardSettings.Hide();
            btnAGDBCommonSettings.BackColor = Color.Green;
            btnAGDBBoardSettings.BackColor = Color.Black;
        }

        private void AGDB_Load(object sender, EventArgs e)
        {
            try
            {
                panelAGDBCommonSettings.Visible = true;
                panelAGDBBoardSettings.Hide();
                btnAGDBCommonSettings.BackColor = Color.Green;
                cmbAGDBVideoType.SelectedIndex = 0;
                CmbAGDBDelaytime.SelectedIndex = 0;
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
                Settruecoloragdbornot();
                InitializeControls();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                // ex.ToString();
            }
        }



        private void btnAGDBBoardSettings_Click(object sender, EventArgs e)
        {
            panelAGDBCommonSettings.Hide();
            panelAGDBBoardSettings.Visible = true;
            btnAGDBBoardSettings.BackColor = Color.Green;
            btnAGDBCommonSettings.BackColor = Color.Black;
        }
        private void Settruecoloragdbornot()
        {
            try
            {
                if (PkNumber != 0)
                {
                    tgltruecolorstatus.Checked = BaseClass.GettruecolorAgdbstatus(ipAddressAgdb.Text.Trim());
                }



            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);

            }
        }
        private void SetDisplayEffects()
        {
            try
            {



                CmbAGDBDisplayeffect.Items.Clear();

                foreach (var Effects in BaseClass.DisplayEffects)
                {

                    string trimmedEffects = Effects.Trim();


                    CmbAGDBDisplayeffect.Items.Add(trimmedEffects);
                }

                CmbAGDBDisplayeffect.SelectedIndex = 0;
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
                foreach (string value in BaseClass.Languages)
                {
                    dgvLanguage.Rows.Add(value);
                    if (value != "English" && value != "Hindi")
                    {
                        lblAGDBRegional.Visible = false;
                        txtAGDBRegional.Visible = false;
                        btnRKeyboard.Visible = false;
                        lblAGDBRegional.Text = value;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }


        }
        private void SetInfoDisplay()
        {
            try
            {


                // Clear existing items in the ComboBox
                CmbAGDBinfoDisplayed.Items.Clear();

                foreach (var infoDisplay in BaseClass.infoDisplayList)
                {
                    string trimmedinfoDisplay = infoDisplay.Trim();


                    CmbAGDBinfoDisplayed.Items.Add(trimmedinfoDisplay);
                }
                // Select the default item "--Select--"
                CmbAGDBinfoDisplayed.SelectedIndex = 0;
            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);

            }
        }
        private void SetLetterGap()
        {
            try
            {



                CmbAGDBlettergap.Items.Clear();

                foreach (var LetterGap in BaseClass.LetterGapList)
                {

                    string trimmedLetterGap = LetterGap.Trim();


                    CmbAGDBlettergap.Items.Add(trimmedLetterGap);
                }

                CmbAGDBlettergap.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);

            }
        }
        private void SetLetterSpeed()
        {
            try
            {



                CmbAGDBLetterSpeed.Items.Clear();

                foreach (var Speed in BaseClass.LetterSpeedlist)
                {

                    string trimmedSpeed = Speed.Trim();


                    CmbAGDBLetterSpeed.Items.Add(trimmedSpeed);
                }

                CmbAGDBLetterSpeed.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);

            }
        }
        private void SetFormatType()
        {
            try
            {

                CmbAGDBFormattype.Items.Clear();

                foreach (var FormatType in BaseClass.FormatsList)
                {
                    string trimmedFormatType = FormatType.Trim();
                    CmbAGDBFormattype.Items.Add(trimmedFormatType);
                }
                // Select the default item "--Select--"
                CmbAGDBFormattype.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void SetFontSize()
        {
            try
            {

                CmbAGDBfontSize.Items.Clear();

                foreach (var Font in BaseClass.FontSizeList)
                {

                    string trimmedFont = Font.Trim();


                    CmbAGDBfontSize.Items.Add(trimmedFont);
                }
                // Select the default item "--Select--"
                CmbAGDBfontSize.SelectedIndex = 4;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);

            }
        }



        private void chkAGDBAutoerasing_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (chkAGDBAutoerasing.Checked)
                {

                    txtAGDBErasetime.Enabled = true;
                }
                else
                {
                    // If unchecked, disable the panel
                    txtAGDBErasetime.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }
        }

        private void GetDetailsByPk()
        {

            try
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
                                ipAddressAgdb.Text = row["IPAddress"].ToString();
                                txtAGDBLocation.Text = row["Location"].ToString();
                                txtAGDBEthernetportno.Text = row["EthernetPort"].ToString();
                                ethernetPortNo = Convert.ToInt32(row["EthernetPort"]);
                                tglinteroperability.Checked = row["interoperability"] != DBNull.Value && (bool)row["interoperability"];

                                PdcPortNo = Convert.ToInt32(row["PdcPortNo"]);

                            }
                        }
                    }

                    foreach (DataRow row in boarddetailybyPk.Rows)
                    {
                        if (boarddetailybyPk.Columns.Contains("FkeyofMasterHub") && int.TryParse(row["FkeyofMasterHub"].ToString(), out int PkMasterHub))
                        {
                            if (PkMasterHub == PkNumber)
                            {
                                txtAGDBBoardid.Text = row["BoardID"].ToString();
                                txtAGDBNooflines.Text = row["NoofLines"].ToString();
                                int Videovalue = Convert.ToInt32(row["VideoType"].ToString());
                                if (Videovalue == 0)
                                {
                                    cmbAGDBVideoType.Text = "Normal";
                                }
                                else
                                {
                                    cmbAGDBVideoType.Text = "Reverse";
                                }

                                CmbAGDBLetterSpeed.Text = BaseClass.GetLetterSpeed(Convert.ToInt32(row["LetterSpeed"]));
                                CmbAGDBFormattype.Text = BaseClass.GetFormattype(Convert.ToInt32(row["FormatType"]));
                                CmbAGDBlettergap.Text = BaseClass.GetLetterGap(Convert.ToInt32(row["LetterGap"]));
                                CmbAGDBDelaytime.Text = row["DelayTime"].ToString();
                                CmbAGDBDisplayeffect.Text = BaseClass.GetDisplayeffect(Convert.ToInt32(row["DisplayEffect"]));
                                CmbAGDBfontSize.Text = BaseClass.GetFontSize(Convert.ToInt32(row["FontSize"]));
                                txtAGDBErasetime.Text = row["EraseTime"].ToString();

                                CmbAGDBinfoDisplayed.Text = BaseClass.GetinfoDisplayed(Convert.ToInt32(row["InfoDisplayed"]));
                                txtAGDBEnglish.Text = row["LanEnglish"].ToString();
                                txtAGDBRegional.Text = row["LanRegional"].ToString();
                                txtAGDBHindi.Text = row["LanHindi"].ToString();
                                checkAGDBBoxShowMessages.Checked = (bool)row["MessagesEnble"];
                                Boolean value = (bool)row["BoardRunning"];
                                if (value)
                                {
                                    rdbnAGDBWorking.Checked = true;
                                }
                                else
                                {
                                    rdbnAGDBNotWorking.Checked = true;
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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }
        }
        private void setPlatforms(string Platforms)
        {
            try
            {
                var checkedPlatforms = Platforms.Split(',')
                                                      .Select(p => p.Trim())
                                                      .ToList();

                foreach (Control control in grupAGDBPlatforms.Controls)
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
                ex.ToString();
            }
        }



        private void createPlatforms()
        {
            try
            {
                // Clear existing controls in the GroupBox
                grupAGDBPlatforms.Controls.Clear();

                int xMargin = 10; // Margin from left
                int yMargin = 20; // Margin from top
                int checkBoxWidth = 40; // Width of each checkbox
                int checkBoxHeight = 20; // Height of each checkbox
                int xSpacing = 20; // Horizontal spacing between checkboxes
                int ySpacing = 10; // Vertical spacing between rows
                int maxColumns = 4; // Maximum number of checkboxes in a row

                int x = xMargin;
                int y = yMargin;

                // Loop through each value in the list
                foreach (string value in BaseClass.Platforms)
                {
                    // Create a new CheckBox
                    CheckBox checkBox = new CheckBox();

                    // Set CheckBox properties
                    checkBox.Text = value;
                    checkBox.Font = new Font("Arial", 10);
                    checkBox.AutoSize = true;

                    // Set the location of the CheckBox
                    checkBox.Location = new Point(x, y);

                    // Add CheckBox to the GroupBox
                    grupAGDBPlatforms.Controls.Add(checkBox);

                    // Adjust x and y coordinates for the next checkbox
                    x += checkBoxWidth + xSpacing;

                    // Start a new row if the maximum number of columns is reached
                    if (grupAGDBPlatforms.Controls.Count % maxColumns == 0)
                    {
                        x = xMargin; // Reset x position
                        y += checkBoxHeight + ySpacing; // Move to the next row
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }
        }

        private string ShowCheckedPlatforms()
        {

            try
            {


                // Retrieve the checked values
                List<string> checkedPlatforms = GetCheckedPlatforms();

                // Convert the list of values to a string for display
                string checkedValues = string.Join(",", checkedPlatforms);

                // Display the values in a message box
                return checkedValues;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }
            return null;
        }

        private List<string> GetCheckedPlatforms()
        {

            List<string> checkedPlatforms = new List<string>();
            try
            {
                // Loop through each control in the GroupBox
                foreach (Control control in grupAGDBPlatforms.Controls)
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
                ex.ToString();
            }

            return checkedPlatforms;
        }
        public static void setDisplayLanguages(DataGridView dgvLanguage, string Languages)
        {
            try
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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
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
                            int ethernetvalue = Convert.ToInt32(txtAGDBEthernetportno.Text);
                            if (portno == ethernetvalue)
                            {
                                string ipaddress = ipAddressAgdb.Text;

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
                                    ipAddressAgdb.Text = updatedIPAddress;
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
                ex.ToString();
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
                ex.ToString();
            }
            return false;
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

        private void MoveRowDown(int rowIndex)
        {
            try
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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }
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
                ex.ToString();
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
                ex.ToString();
            }
            // Return false and -1 if the IP address is not valid or other parsing issues occurred
            return (false, -1);
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
                ex.ToString();
            }
            // Return -1 if the IP address is not valid or other parsing issues occurred
            return -1;
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
                Server.LogError(ex.Message);
                ex.ToString();
            }
        }

        private void btnAGDBSave_Click(object sender, EventArgs e)
        {
            txtAGDBHindi.Text = "ABC";
            try
            {
                bool hasError = false; // Flag to track if there's any error

                // Check and highlight each required text box
                hasError |= CheckAndHighlightEmptyField(txtAGDBBoardid);
                hasError |= ChecktheError(ipAddressAgdb);
                hasError |= ChecktheIpError();
                hasError |= CheckAndHighlightEmptyField(txtAGDBLocation);
                hasError |= CheckAndHighlightEmptyField(txtAGDBEthernetportno);
                hasError |= CheckAndHighlightEmptyField(txtAGDBNooflines);
                hasError |= CheckAndHighlightEmptyField(txtAGDBEnglish);
                hasError |= CheckAndHighlightEmptyField(txtAGDBHindi);
                // hasError |= CheckAndHighlightEmptyField(txtAGDBRegional);

                // If any error is found, display error message and exit the method
                if (hasError)
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {

                    int pdcPort = PdcPortNo;
                    int packetidentifier = 4;
                    int BoardId = Convert.ToInt32(txtAGDBBoardid.Text.Trim());
                    //  string location = txtAGDBLocation.Text.Trim();
                    string location;
                    if (ID != -1)
                    {
                        location = txtAGDBLocation.Text.Trim();
                    }
                    else
                    {
                        location = txtAGDBLocation.Text.Trim() + "_Agdb";
                    }
                    int EthernetPort = Convert.ToInt32(txtAGDBEthernetportno.Text.Trim());

                    string ipaddress = ipAddressAgdb.Text.Trim();
                    string platformNo = GetPlatformbyIp(ipaddress).ToString();

                    int noofLines = Convert.ToInt32(txtAGDBNooflines.Text.Trim());
                    bool message = checkAGDBBoxShowMessages.Checked;
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
                    int DelayTime = Convert.ToInt32(CmbAGDBDelaytime.Text.Trim());
                    bool truecolorstatus = tgltruecolorstatus.Checked;
                    bool interoperabilitystatus = tglinteroperability.Checked;

                    int EraseTime;
                    if (int.TryParse(txtAGDBErasetime.Text, out EraseTime))
                    {

                    }
                    else
                    {

                        EraseTime = 60;


                    }
                    string defaultEnglish = txtAGDBEnglish.Text.Trim();
                    string defaultRegional = txtAGDBRegional.Text.Trim();
                    string defaultHindi = txtAGDBHindi.Text.Trim();
                    int PortNo = GetPortNo(ethernetPortNo, PdcPortNo);


                    DialogResult result = MessageBox.Show("Do you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.Yes)
                    {

                        int rows = HubConfigurationDb.SaveTadbBoard(
                                   ID, pdcPort, BoardId, location, EthernetPort, ipaddress, platformNo, noofLines,
                                  message, boardRunning, DisplaySequence, CheckedPlatforms, videoType, letterSpeed,
                                   FormatType, lettergap, DisplayEffect, fontsize, infoDisplayed, DelayTime,
                                  EraseTime, defaultEnglish, defaultRegional, defaultHindi, PortNo, packetidentifier, interoperabilitystatus);

                        if (rows >= 0)
                        {
                            HubConfigurationDb.InsertTruecolorAgdb(ipaddress, truecolorstatus);
                            ReportDb.InsertDatabaseModificationReportData("Agdb Board Added With the Ip " + ipaddress, "4");

                            if (Server._connectedClients.Count >= 0)
                            {
                                if (interoperabilitystatus)
                                {
                                    byte[] DefaultPacket = frmHubConfiguration.AgdbDefaultPacket(ipaddress, packetidentifier, letterSpeed, noofLines, videoType, DisplayEffect, fontsize, lettergap, DelayTime, defaultEnglish, defaultRegional, defaultHindi, DisplaySequence, FormatType);
                                    DefaultPacket = ByteFormation.RemoveFirstAndLast6(DefaultPacket);
                                    Server.SendMessageToClient(ipaddress, DefaultPacket);

                                    System.Threading.Thread.Sleep(1000);

                                    byte[] SoftResetPacket = frmBoardDiagnosis.SoftResetPacket(ipaddress, packetidentifier);
                                    SoftResetPacket = ByteFormation.RemoveFirstAndLast6(SoftResetPacket);
                                    Server.SendMessageToClient(ipaddress, SoftResetPacket);


                                }
                                else
                                {
                                    byte[] DefaultPacket = frmHubConfiguration.AgdbDefaultPacket(ipaddress, packetidentifier, letterSpeed, noofLines, videoType, DisplayEffect, fontsize, lettergap, DelayTime, defaultEnglish, defaultRegional, defaultHindi, DisplaySequence, FormatType);

                                    Server.SendMessageToClient(ipaddress, DefaultPacket);

                                    System.Threading.Thread.Sleep(1000);

                                    byte[] SoftResetPacket = frmBoardDiagnosis.SoftResetPacket(ipaddress, packetidentifier);

                                    Server.SendMessageToClient(ipaddress, SoftResetPacket);


                                }
                                //pbpleasewait.Visible = true;
                                // pbpleasewait.BringToFront();

                                System.Threading.Thread.Sleep(5000);
                            }
                            // Show success message for 10 seconds
                            lblStatus.Text = "Board Configuration saved successfully!";
                            lblStatus.ForeColor = Color.Green;
                            //board.Text = location;
                            BaseClass.RecallBoards();


                            // frmHubConfiguration.PfdDefaultPacket(ipaddress, packetidentifier);


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
                ex.ToString();
            }
        }
        private string GetinfoDisplayed()
        {
            try
            {
                // Get the selected speed from the ComboBox
                string info = CmbAGDBinfoDisplayed.Text.Trim();

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
                Server.LogError(ex.Message);
                ex.ToString();
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
        private bool CheckWhichRadioButtonIsChecked()
        {
            try
            {
                if (rdbnAGDBWorking.Checked)
                {
                    return true; // rdbnMLDBWorking is checked
                }
                else if (rdbnAGDBNotWorking.Checked)
                {
                    return false; // rdbnMLDBNotWorking is checked
                }
                else
                {
                    // Handle the case where neither radio button is checked
                    // Return a default value or throw an exception if appropriate
                    throw new InvalidOperationException("Neither radio button is checked.");

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }
            return false;
        }

        private int GetFontSize()
        {
            try
            {
                // Get the selected font size from the ComboBox
                string selectedFontSize = CmbAGDBfontSize.Text.Trim();

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
                ex.ToString();
            }

            // Return a default value or handle the case where no match is found
            return -1;
        }

        private string Getlettergap()
        {
            try
            {


                // Get the selected speed from the ComboBox
                string lettergap = CmbAGDBlettergap.Text.Trim();

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
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetDisplayeffect()
        {
            try
            {
                // Get the selected speed from the ComboBox
                string DisplayEffect = CmbAGDBDisplayeffect.Text.Trim();

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
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }
            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetFormatType()
        {
            try
            {
                // Get the selected speed from the ComboBox
                string format = CmbAGDBFormattype.Text.Trim();

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
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }
            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetletterSpeed()
        {
            try
            {


                // Get the selected speed from the ComboBox
                string speed = CmbAGDBLetterSpeed.Text.Trim();

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
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }
            // Return a default value or handle the case where no match is found
            return "ID not found";
        }

        private string GetVideoType()
        {
            string videotype = "";
            string video = cmbAGDBVideoType.Text.Trim();
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




        private void txtAGDBEnglish_Enter(object sender, EventArgs e)
        {
            txtAGDBEnglish.BackColor = SystemColors.Window;
        }

        private void txtAGDBRegional_Enter(object sender, EventArgs e)
        {
            txtAGDBEnglish.BackColor = SystemColors.Window;
        }

        private void txtAGDBHindi_Enter(object sender, EventArgs e)
        {
            txtAGDBEnglish.BackColor = SystemColors.Window;
        }

        private void ipAddressAgdb_Enter(object sender, EventArgs e)
        {
            ipAddressAgdb.BackColor = SystemColors.Window;
            txtAGDBBoardid.BackColor = SystemColors.Window;
        }

        private void txtAGDBLocation_Enter(object sender, EventArgs e)
        {
            txtAGDBLocation.BackColor = SystemColors.Window;
        }

        private void txtAGDBNooflines_Enter(object sender, EventArgs e)
        {
            txtAGDBNooflines.BackColor = SystemColors.Window;
        }

        private void ipAddressAgdb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Get the selected platform from the ComboBox
                string iptext = ipAddressAgdb.Text.Trim();
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
                ex.ToString();
            }

        }

        private void ipAddressAgdb_Leave(object sender, EventArgs e)
        {
            try
            {
                string ipAddress = ipAddressAgdb.Text.Trim();

                // Get the result tuple from the method
                var result = IsLastOctetInRangeMLDB(ipAddress, 131, 160);
                bool isInRange = result.Item1;
                int lastOctet = result.Item2;

                if (!isInRange)
                {
                    // Display error icon and message
                    errorProviderAGDB.SetError(ipAddressAgdb, "The last octet of the IP address must be between 161 and 190.");
                    lblAGDBErrorMessage.Visible = true;
                }
                else
                {
                    // Clear any previous error
                    errorProviderAGDB.SetError(ipAddressAgdb, "");
                    lblAGDBErrorMessage.Visible = false;

                    // Use the last octet value if needed
                    txtAGDBBoardid.Text = lastOctet.ToString();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }
        }

        private void frmAGDB_FormClosing(object sender, FormClosingEventArgs e)
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
                ex.ToString();
            }
        }

        private void btnHKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(330, 50, "Hindi");
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

            Keyboard(120, 50, localLanguage);
        }

        private void InitializeControls()
        {
            txtAGDBEnglish.Enter += Control_Enter;
            txtAGDBHindi.Enter += Control_Enter;
            txtAGDBRegional.Enter += Control_Enter;
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
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
