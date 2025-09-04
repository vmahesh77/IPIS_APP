using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms.HomeForms;
using ArecaIPIS.Server_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmInterface : Form
    {
        public frmInterface()
        {
            InitializeComponent();
        }
        DataTable NtesData = new DataTable();

        private frmIndex parentForm;
        frmOnlineTrains online = new frmOnlineTrains();
        public frmInterface(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }
        public static DataSet dscdotconfg = new DataSet();

        private void frmInterface_Load(object sender, EventArgs e)
        {
            try
            {
                NtesData = BaseClass.NTESCONFIGURATIONdt;
                PopulateUIFromDataTable(NtesData);
                LoadLetterSpeed();
                btnNtes.BackColor = Color.SteelBlue;
                btnCdot.BackColor = Color.SteelBlue;
                panCdot.Visible = false;
                panNtes.Visible = false;
                btnIntegrationTab.BackColor = Color.DarkGreen;
                panIntegrationTab.Visible = true;
                panIntegrationTab.BringToFront();
                createPlatforms();
                cmbIPISType.SelectedIndex = 0;
                GetIntegrationDataTable();

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            panIntegrationTab.Visible = true;
        }

        private void btnNtes_Click(object sender, EventArgs e)
        {
            try
            {

                btnNtes.BackColor = Color.DarkGreen;
                btnCdot.BackColor = Color.SteelBlue;
                btnIntegrationTab.BackColor = Color.SteelBlue;
                panIntegrationTab.Visible = false;
                panCdot.Visible = false;
                panNtes.Visible = true;
                cmbDataType.SelectedIndex = 0;

                NtesData = BaseClass.NTESCONFIGURATIONdt;
                PopulateUIFromDataTable(NtesData);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void btnCdot_Click(object sender, EventArgs e)
        {
            try
            {

                btnNtes.BackColor = Color.SteelBlue;
                btnCdot.BackColor = Color.DarkGreen;
                btnIntegrationTab.BackColor = Color.SteelBlue;
                panIntegrationTab.Visible = false;
                panCdot.Visible = true;
                panNtes.Visible = false;
                GetCdotData();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        private void cmbNextMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {


                // Check if the key pressed is a digit or backspace
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    // If not, ignore the input
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        // frmHome Hometab = new frmHome();
        private async void  btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BaseClass.CurrentPollMins = Convert.ToInt32(cmbPollReqTimeMins.Text);
                AnnouncementController.UpdateStatus("STOP");
                AnnouncementController.UpdateAudioPlayStatus("Completed");
                AnnouncementController.OtherAudioPlaying = false;
                // Capture the values from the form controls
                bool ntesEnable = tglNtesEnable.Checked;
                string urlType = cmbDataType.SelectedItem?.ToString();
                string stationCode = txtStationCode.Text.Trim();
                int nextMins;
                bool audio = tglAudio.Checked;
                bool autoMode = tglAutoMode.Checked;
                string custID = txtCustId.Text.Trim();
                string custPass = txtCustPass.Text.Trim(); // Ensure this field is present on your form
                string custType = txtCustType.Text.Trim();
                string url = txtNtestUrl.Text;
                string authtenticationToken = txtNtesAutenticationToken.Text;
                string pollMins = cmbPollReqTimeMins.Text;
                // Validate the inputs
                if (string.IsNullOrEmpty(urlType) ||
                    string.IsNullOrEmpty(stationCode) ||
                    !int.TryParse(cmbNextMinutes.Text, out nextMins) ||
                    string.IsNullOrEmpty(custID) ||
                    string.IsNullOrEmpty(custPass) ||
                    string.IsNullOrEmpty(custType))
                {
                    MessageBox.Show("Please fill out all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataTable existedtrains = InterfaceDb.ClearNtesWebServiceTable();//clearing ntes webservice and scheduled tadb where ntes check not true


                frmOnlineTrains.DeleteTrains(existedtrains);

                //InterfaceDb.ClearScheduleTadb();


                // Call the InsertUpdateNtesConfiguration method with the validated values
                int result = InterfaceDb.InsertUpdateNtesConfiguration(ntesEnable, urlType, stationCode, nextMins, audio, autoMode, custID, custPass, custType, url, authtenticationToken,pollMins);

                // Show a message based on the result
                if (result >= 0)
                {

                    BaseClass.setNtesConfiguration();
                    Form mainForm = Application.OpenForms["frmHome"];

                    if (mainForm != null)
                    {
                        frmHome frmScheduled = (frmHome)mainForm;
                       frmScheduled.setNtesConnection();
                    }
                    //Hometab.setNtesConnection();
                    MessageBox.Show("NTES configuration updated successfully.");

                    if (BaseClass.IsNtesEnabled())
                    {
                        //online.WebRequest();
                        if (BaseClass.IsNtesAutoMode())
                        {
                            DataController.sendAllBoardsData();
                        }

                        if (BaseClass.IsNtesAudio())
                        {
                            AnnouncementController.UpdateStatus("STOP");
                            AnnouncementController.UpdateAudioPlayStatus("Completed");
                            AnnouncementController.OtherAudioPlaying = true;
                            BaseClass.AnnouncementCount = 1;

                            AnnouncementController.playAnnounceMentData();
                        }

                    }

                }
                else
                {
                    MessageBox.Show("No rows affected. Configuration might not have been updated.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            DataController.CheckTrainsLeftOrNotAndClaerData();
        }

        public void ChangeTglNtesMode(bool click)
        {

        }
        public void ChangeTglAudioMode(bool click)
        {

        }
        public void ChangeTglAuto(bool click)
        {

        }


        public void PopulateUIFromDataTable(DataTable dataTable)
        {
            try
            {

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];

                    tglNtesEnable.Checked = row.Field<bool>("NTESEnable");
                    cmbDataType.SelectedItem = row.Field<string>("UrlType");
                    txtStationCode.Text = row.Field<string>("StationCode");
                    cmbNextMinutes.Text = row.Field<int>("NextMins").ToString();
                    tglAudio.Checked = row.Field<bool>("Audio");
                    tglAutoMode.Checked = row.Field<bool>("AutoMode");
                    txtCustId.Text = row.Field<string>("custID");
                    txtCustPass.Text = row.Field<string>("custPass");
                    txtCustType.Text = row.Field<string>("custType");
                    txtNtestUrl.Text = row.Field<string>("NtesUrl");
                    txtNtesAutenticationToken.Text = row.Field<string>("AuthenticationToken");
                    cmbPollReqTimeMins.Text = row.Field<string>("PollingInterval");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public void LoadLetterSpeed()
        {
            try
            {
                DataTable letterSpeed = InterfaceDb.GetLetterSpeed();

                if (letterSpeed.Columns.Count >= 2)
                {

                    cmbSpeed.DataSource = letterSpeed;
                    cmbSpeed.DisplayMember = letterSpeed.Columns[1].ColumnName;
                    cmbSpeed.ValueMember = letterSpeed.Columns[0].ColumnName;
                }
                else
                {
                    MessageBox.Show("The table does not have a second column.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private void btnSaveCdot_Click(object sender, EventArgs e)
        {
            try
            {

                bool cdotEnable = chkCdotEnable.Checked;
                int speed, delayTime, pollingTime;
                bool isSpeedValid = int.TryParse(cmbSpeed.SelectedValue?.ToString(), out speed);
                bool isDelayTimeValid = int.TryParse(txtDelayTime.Text, out delayTime);
                bool isPollingTimeValid = int.TryParse(txtPollingTime.Text, out pollingTime);
                bool autoMode = chkAutoModeCdot.Checked;
                string stationCode = txtStationCodeCdot.Text.Trim();
                string userPass = txtUserPass.Text.Trim();
                string cdotUrl = txtCdotUrl.Text.Trim();
                string userName = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();
                string validationStatus = txtValidationStatus.Text.Trim();
                string disseminationUrl = txtDissmentationurl.Text.Trim();

                // Validate the inputs
                if (string.IsNullOrEmpty(stationCode) ||
                    string.IsNullOrEmpty(userPass) ||
                    string.IsNullOrEmpty(cdotUrl) ||
                    string.IsNullOrEmpty(userName) ||
                    string.IsNullOrEmpty(password) ||
                    string.IsNullOrEmpty(validationStatus) ||
                    string.IsNullOrEmpty(disseminationUrl))
                {
                    MessageBox.Show("Please fill out all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!isSpeedValid || !isDelayTimeValid || !isPollingTimeValid)
                {
                    MessageBox.Show("Please enter valid numbers for Speed, Delay Time, and Polling Time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call the InsertUpdateNtesConfiguration method with the validated values
                int resultCdotConfiguration = InterfaceDb.InsertUpdateCdotConfiguration(cdotEnable, speed, delayTime, pollingTime, stationCode, autoMode, userPass, cdotUrl, userName, password, validationStatus, disseminationUrl);

                InterfaceDb.DeleteCdotAlertUrl();



                int resultCdotAlert = 0;
                int tableCount;
                bool isTableCountValid = int.TryParse(txtAlertCount.Text.Trim(), out tableCount);

                if (isTableCountValid && tableCount > 0)
                {
                    // Loop through each TableLayoutPanel for each "Alert"
                    for (int i = 1; i <= tableCount; i++)
                    {
                        // Find each TextBox by name within the panel
                        TextBox txtCdotUrl = panAlert.Controls.Find($"txtCdotUrl_{i}", true).FirstOrDefault() as TextBox;
                        TextBox txtUserName = panAlert.Controls.Find($"txtUserName_{i}", true).FirstOrDefault() as TextBox;
                        TextBox txtPassWord = panAlert.Controls.Find($"txtPassWord_{i}", true).FirstOrDefault() as TextBox;
                        TextBox txtValidationStatusUrl = panAlert.Controls.Find($"txtValidationStatusUrl_{i}", true).FirstOrDefault() as TextBox;
                        TextBox txtDissmentationUrl = panAlert.Controls.Find($"txtDissmentationUrl_{i}", true).FirstOrDefault() as TextBox;

                        // Ensure all textboxes are not null and contain valid data
                        if (txtCdotUrl != null && txtUserName != null && txtPassWord != null &&
                            txtValidationStatusUrl != null && txtDissmentationUrl != null &&
                            !string.IsNullOrEmpty(txtCdotUrl.Text.Trim()) &&
                            !string.IsNullOrEmpty(txtUserName.Text.Trim()) &&
                            !string.IsNullOrEmpty(txtPassWord.Text.Trim()) &&
                            !string.IsNullOrEmpty(txtValidationStatusUrl.Text.Trim()) &&
                            !string.IsNullOrEmpty(txtDissmentationUrl.Text.Trim()))
                        {
                            // Call your insert/update method here with the values
                            resultCdotAlert += InterfaceDb.InsertUpdateCdotAlertUrl(
                                txtCdotUrl.Text.Trim(),
                                txtUserName.Text.Trim(),
                                txtPassWord.Text.Trim(),
                                txtValidationStatusUrl.Text.Trim(),
                                txtDissmentationUrl.Text.Trim()
                            );
                        }
                        else
                        {

                            MessageBox.Show("Please Fill the details Correctly");
                            return;
                        }
                    }

                    // Check the result of the insert/update
                    if (resultCdotAlert > 0)
                    {
                        Form mainForm = Application.OpenForms["frmHome"];

                        if (mainForm != null)
                        {
                            frmHome frmScheduled = (frmHome)mainForm;
                            frmScheduled.setCdot();
                        }
                        MessageBox.Show("Cdot configuration and alert URLs updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No rows affected. Configuration or alert URLs might not have been updated.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for Alert Count.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void CreateDynamicTablesWithOrderedHeaders(int tableCount)
        {
            try
            {


                // Clear the existing controls on the panel
                panAlert.Controls.Clear();

                // Loop through the number of tables (1-based indexing for "Alert" numbering)
                for (int i = 1; i <= tableCount; i++)
                {
                    // Create a TableLayoutPanel for each table (with a header and 3 rows of labels and textboxes)
                    TableLayoutPanel tableLayout = new TableLayoutPanel

                    {
                        Name = $"tableLayout_{i}",
                        ColumnCount = 2, // Two columns: one for labels and one for textboxes
                        RowCount = 6,    // 1 row for the header, 5 rows for the fields (label-textbox pairs)
                        AutoSize = true,
                        Dock = DockStyle.Top, // Stack tables vertically
                        Padding = new Padding(10), // Add some space between tables
                        CellBorderStyle = TableLayoutPanelCellBorderStyle.Single // Optional: adds borders between cells
                    };

                    // Create the header for the first column (ordered by "Alert 1", "Alert 2", ...)
                    Label header = new Label
                    {
                        Text = $"Alert {i}:", // Set the header text dynamically (Alert 1, Alert 2, etc.)
                        Anchor = AnchorStyles.None,
                        AutoSize = true,
                        Font = new Font("Arial", 10, FontStyle.Bold), // Optional: bold font for the header
                        TextAlign = ContentAlignment.MiddleCenter // Center-align the header text
                    };

                    // Create a blank space for the second column in the header row
                    Label emptyHeader = new Label
                    {
                        Width = 200,
                        Text = "", // No text for the second column
                        Anchor = AnchorStyles.None,
                        AutoSize = true
                    };

                    // Add the header to the first row (row 0)
                    tableLayout.Controls.Add(header, 0, 0); // First column (Header)
                    tableLayout.Controls.Add(emptyHeader, 1, 0); // Second column (empty)

                    // Create the first row: Cdot Url
                    Label lblCdotUrl = new Label
                    {
                        Text = "Cdot Url:",
                        Anchor = AnchorStyles.Right,
                        AutoSize = true
                    };
                    TextBox txtCdotUrl = new TextBox
                    {
                        Name = $"txtCdotUrl_{i}",
                        Width = 200,
                        Anchor = AnchorStyles.Left
                    };
                    tableLayout.Controls.Add(lblCdotUrl, 0, 1);
                    tableLayout.Controls.Add(txtCdotUrl, 1, 1);

                    // Create the second row: User Name
                    Label lblUserName = new Label
                    {
                        Text = "User Name:",
                        Anchor = AnchorStyles.Right,
                        AutoSize = true
                    };
                    TextBox txtUserName = new TextBox
                    {
                        Name = $"txtUserName_{i}",
                        Width = 200,
                        Anchor = AnchorStyles.Left
                    };
                    tableLayout.Controls.Add(lblUserName, 0, 2);
                    tableLayout.Controls.Add(txtUserName, 1, 2);

                    // Create the third row: PassWord
                    Label lblPassWord = new Label
                    {
                        Text = "PassWord:",
                        Anchor = AnchorStyles.Right,
                        AutoSize = true
                    };
                    TextBox txtPassWord = new TextBox
                    {
                        Name = $"txtPassWord_{i}",
                        Width = 200,
                        Anchor = AnchorStyles.Left
                    };
                    tableLayout.Controls.Add(lblPassWord, 0, 3);
                    tableLayout.Controls.Add(txtPassWord, 1, 3);

                    // Create the fourth row: ValidationStatusUrl
                    Label lblValidationStatusUrl = new Label
                    {
                        Text = "ValidationStatusUrl:",
                        Anchor = AnchorStyles.Right,
                        AutoSize = true
                    };
                    TextBox txtValidationStatusUrl = new TextBox
                    {
                        Name = $"txtValidationStatusUrl_{i}",
                        Width = 200,
                        Anchor = AnchorStyles.Left
                    };
                    tableLayout.Controls.Add(lblValidationStatusUrl, 0, 4);
                    tableLayout.Controls.Add(txtValidationStatusUrl, 1, 4);

                    // Create the fifth row: DissmentationUrl
                    Label lblDissmentationUrl = new Label
                    {
                        Text = "DissmentationUrl:",
                        Anchor = AnchorStyles.Right,
                        AutoSize = true
                    };
                    TextBox txtDissmentationUrl = new TextBox
                    {
                        Name = $"txtDissmentationUrl_{i}",
                        Width = 200,
                        Anchor = AnchorStyles.Left
                    };
                    tableLayout.Controls.Add(lblDissmentationUrl, 0, 5);
                    tableLayout.Controls.Add(txtDissmentationUrl, 1, 5);

                    // Insert the table at the start of the panel controls to ensure it's displayed in the right order
                    panAlert.Controls.Add(tableLayout);
                    panAlert.Controls.SetChildIndex(tableLayout, 0); // Ensure correct display order
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        public void GetCdotData()
        {
            try
            {


                dscdotconfg = InterfaceDb.GetCDotConfiguration();

                DataSet CdotConfigurationdt = dscdotconfg;

                if (CdotConfigurationdt != null)
                {
                    if (CdotConfigurationdt.Tables.Count >= 2)
                    {


                        DataTable datatable1 = CdotConfigurationdt.Tables[0]; // Access the first table
                        DataTable datatable2 = CdotConfigurationdt.Tables[1]; // Access the second table


                        if (datatable1.Rows.Count > 0)
                        {
                            DataRow row = datatable1.Rows[0];

                            chkCdotEnable.Checked = row.Field<bool>("CdotEnable");
                            cmbSpeed.SelectedValue = row.Field<int>("LetterSpeed");
                            txtDelayTime.Text = row.Field<int>("DelayTimeInSec").ToString();
                            txtPollingTime.Text = row.Field<int>("PollingTimeInMin").ToString();
                            chkAutoModeCdot.Checked = row.Field<bool>("AutoMode");
                            txtStationCodeCdot.Text = row.Field<string>("StationCode");
                            txtUserPass.Text = row.Field<string>("userPass");
                            txtCdotUrl.Text = row.Field<string>("UrlType");
                            txtUserName.Text = row.Field<string>("Username");
                            txtPassword.Text = row.Field<string>("Password");
                            txtValidationStatus.Text = row.Field<string>("validationstatusurl");
                            txtDissmentationurl.Text = row.Field<string>("Dissemenationurl");
                        }

                        PopulateFieldsFromDataTable(datatable2);

                    }
                    else
                    {
                        MessageBox.Show("DataSet does not contain the expected number of tables.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void PopulateFieldsFromDataTable(DataTable dataTable)
        {
            try
            {
                CreateDynamicTablesWithOrderedHeaders(dataTable.Rows.Count);
                txtAlertCount.Text = dataTable.Rows.Count.ToString();
                for (int i = 1; i <= dataTable.Rows.Count; i++)
                {
                    // Find the TableLayoutPanel by name
                    var tableLayout = panAlert.Controls.OfType<TableLayoutPanel>().FirstOrDefault(t => t.Name == $"tableLayout_{i}");
                    if (tableLayout != null)
                    {
                        var row = dataTable.Rows[i - 1];

                        // Find and update each TextBox
                        TextBox txtCdotUrl = tableLayout.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == $"txtCdotUrl_{i}");
                        if (txtCdotUrl != null) txtCdotUrl.Text = row.Field<string>("CdotUrl");

                        TextBox txtUserName = tableLayout.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == $"txtUserName_{i}");
                        if (txtUserName != null) txtUserName.Text = row.Field<string>("Username");

                        TextBox txtPassWord = tableLayout.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == $"txtPassWord_{i}");
                        if (txtPassWord != null) txtPassWord.Text = row.Field<string>("Password");

                        TextBox txtValidationStatusUrl = tableLayout.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == $"txtValidationStatusUrl_{i}");
                        if (txtValidationStatusUrl != null) txtValidationStatusUrl.Text = row.Field<string>("validationstatusurl");

                        TextBox txtDissmentationUrl = tableLayout.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == $"txtDissmentationUrl_{i}");
                        if (txtDissmentationUrl != null) txtDissmentationUrl.Text = row.Field<string>("Dissemenationurl");
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void txtAlertCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int alertCount;
                // Try to parse the alert count from the text box input
                if (int.TryParse(txtAlertCount.Text.Trim(), out alertCount) && alertCount > 0)
                {
                    // Pass the parsed alertCount to the method to dynamically create the tables
                    CreateDynamicTablesWithOrderedHeaders(alertCount);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void txtStationCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtStationCodeCdot_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void btnIntegrationTab_Click(object sender, EventArgs e)
        {
            btnNtes.BackColor = Color.SteelBlue;
            btnCdot.BackColor = Color.SteelBlue;
            panCdot.Visible = false;
            panNtes.Visible = false;
            btnIntegrationTab.BackColor = Color.DarkGreen;
            panIntegrationTab.Visible = true;
            panIntegrationTab.BringToFront();
            createPlatforms();
            cmbIPISType.SelectedIndex = 0;
            GetIntegrationDataTable();

        }
        public void GetIntegrationDataTable()
        {
            try
            {
                DataTable IntegrationData = BaseClass.IntegrationData;

                if (IntegrationData.Rows.Count > 0)
                {
                    DataRow row = IntegrationData.Rows[0];

                    // Extract values from the row
                    cmbIPISType.SelectedIndex = row.Field<int>("Front_Back");
                    chkTrainData.Checked = row.Field<bool>("TrainData");
                    chkCoachData.Checked = row.Field<bool>("Coachdata");
                    chkMessageData.Checked = row.Field<bool>("MessageData");
                    string platformNames = row.Field<string>("Platformnames");
                    string textFilePath = row.Field<string>("TextFilePath");
                    txtTextfilePath.Text = textFilePath;
                    setPlatforms(platformNames);


                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void btnSaveIntegration_Click(object sender, EventArgs e)
        {
            int ipisType = cmbIPISType.SelectedIndex;//is 0 frontend 1 is backend
            bool TrainData = chkTrainData.Checked;
            bool CoachData = chkCoachData.Checked;
            bool messageData = chkMessageData.Checked;
            string CheckedPlatforms = ShowCheckedPlatforms();
            if (string.IsNullOrEmpty(txtTextfilePath.Text))

            {
                MessageBox.Show("Please Choose the Text File Path.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int resultConfiguration = InterfaceDb.InsertUpdateIntegration(ipisType, TrainData, CoachData, messageData, CheckedPlatforms, txtTextfilePath.Text.Trim());

            if (resultConfiguration >= 0)
            {
                MessageBox.Show("Integration configuration  updated successfully.");
                BaseClass.getIntegration();
            }
            else
            {
                MessageBox.Show("Integration configuration  Failed!.");
            }

        }

        private void setPlatforms(string Platforms)
        {
            try
            {
                var checkedPlatforms = Platforms.Split(',')
                                                      .Select(p => p.Trim())
                                                      .ToList();

                foreach (Control control in grpintegrationPlatforms.Controls)
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

        private void createPlatforms()
        {
            try
            {

                grpintegrationPlatforms.Controls.Clear();

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
                    grpintegrationPlatforms.Controls.Add(checkBox);

                    // Adjust x and y coordinates for the next checkbox
                    x += checkBoxWidth + xSpacing;

                    // Start a new row if the maximum number of columns is reached
                    if (grpintegrationPlatforms.Controls.Count % maxColumns == 0)
                    {
                        x = xMargin; // Reset x position
                        y += checkBoxHeight + ySpacing; // Move to the next row
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);

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

            }
            return null;
        }

        private List<string> GetCheckedPlatforms()
        {

            List<string> checkedPlatforms = new List<string>();
            try
            {
                // Loop through each control in the GroupBox
                foreach (Control control in grpintegrationPlatforms.Controls)
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

        private void btnFileChoose_Click(object sender, EventArgs e)
        {
            // Create a FolderBrowserDialog instance
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // Set properties for the dialog
                folderBrowserDialog.Description = "Select a Folder";
                folderBrowserDialog.ShowNewFolderButton = true; // Allow the user to create new folders
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer; // Set the root folder (e.g., My Computer)

                // Show the dialog and check if the user selected a folder
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Set the selected folder path in the TextBox
                    txtTextfilePath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

      

        private void chkCdotEnable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblbTrainData_Click(object sender, EventArgs e)
        {

        }

        private void txtTextfilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblALert_Click(object sender, EventArgs e)
        {

        }

       

        private void tglNtesEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (!tglNtesEnable.Checked)
            {
                tglAutoMode.Checked = false;
                tglAudio.Checked = false;

            }
        }
    }
}
