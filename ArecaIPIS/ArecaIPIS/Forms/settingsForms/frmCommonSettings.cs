using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms.HomeForms;
using ArecaIPIS.Server_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.settingsForms
{
    public partial class frmCommonSettings : Form
    {
        //private DataTable LanguageTable;
        public frmCommonSettings()
        {
            InitializeComponent();
        }
        private frmIndex parentForm;

        public frmCommonSettings(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void chkintensity_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void validatetime(TextBox textBox, Label label)
        {
            try
            {


                // Get the text from the TextBox
                string input = textBox.Text;

                // Check if the input matches the 24-hour time format (HH:mm)
                if (!Regex.IsMatch(input, @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$"))
                {
                    label.Visible = true;
                    label.Text = "Please enter a valid time ";
                    // If the input doesn't match the format, show an error message
                    // MessageBox.Show("Please enter a valid time in 24-hour format (HH:mm).", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // e.Cancel = true; // Cancel the event to prevent focus change
                }
                else
                {
                    label.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }



        private void txtToTIme_TextChanged(object sender, EventArgs e)
        {
            try
            {


                // Get the text from the TextBox
                string input = txtToTIme.Text;

                // Check if the input contains only digits
                if (Regex.IsMatch(input, @"^\d+$"))
                {
                    // If the input length is 3 and the 3rd character is not a colon, insert a colon after the first two digits
                    if (input.Length == 3 && input[2] != ':')
                    {
                        txtToTIme.Text = input.Insert(2, ":");
                        txtToTIme.SelectionStart = txtToTIme.Text.Length; // Move the cursor to the end of the text
                    }
                }

                // If the input length is greater than 5, truncate the input to 5 characters
                if (input.Length > 5)
                {
                    txtToTIme.Text = input.Substring(0, 5);
                    txtToTIme.SelectionStart = txtToTIme.Text.Length; // Move the cursor to the end of the truncated text
                }
                if (input.Length == 5)
                {
                    validatetime(txtToTIme, lbltoTimeError);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtfromTime_TextChanged(object sender, EventArgs e)
        {
            try
            {


                // Get the text from the TextBox
                string input = txtfromTime.Text;

                // Check if the input contains only digits
                if (Regex.IsMatch(input, @"^\d+$"))
                {
                    // If the input length is 3 and the 3rd character is not a colon, insert a colon after the first two digits
                    if (input.Length == 3 && input[2] != ':')
                    {
                        txtfromTime.Text = input.Insert(2, ":");
                        txtfromTime.SelectionStart = txtfromTime.Text.Length; // Move the cursor to the end of the text
                    }
                }

                // If the input length is greater than 5, truncate the input to 5 characters
                if (input.Length > 5)
                {
                    txtfromTime.Text = input.Substring(0, 5);
                    txtfromTime.SelectionStart = txtfromTime.Text.Length; // Move the cursor to the end of the truncated text
                }
                if (input.Length == 5)
                {
                    validatetime(txtfromTime, lblfromtimeError);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtfromTime_Leave(object sender, EventArgs e)
        {
            validateSametime();
        }

        private void validateSametime()
        {
            // Get the text from the Arrival Time TextBox
            string arrivalTime = txtfromTime.Text;

            // Get the text from the Departure Time TextBox
            string departureTime = txtfromTime.Text;

            // Check if both arrival and departure times are not empty and are the same
            if (arrivalTime == departureTime)
            {
                // Show an error message
                lblfromtimeError.Text = "From And TO times cannot be the same.";
                lblfromtimeError.Visible = true;
            }
            else
            {
                // Hide the error label if the times are different or one of them is empty
                lblfromtimeError.Visible = false;
            }
        }

        private void txtNightIntensity_Leave(object sender, EventArgs e)
        {
            validateSametime();
        }

        private void txtfromTime_Validating(object sender, CancelEventArgs e)
        {
            validatetime(txtfromTime, lblfromtimeError);

        }

        private void txtToTIme_Validating(object sender, CancelEventArgs e)
        {
            validatetime(txtToTIme, lbltoTimeError);

        }

        private void txtToTIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing digits, backspace, and colon
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ':')
            {
                // Prevent the character from being entered into the TextBox
                e.Handled = true;
            }
        }

        private void txtfromTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing digits, backspace, and colon
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ':')
            {
                // Prevent the character from being entered into the TextBox
                e.Handled = true;
            }
        }

        private void trackBarNight_Scroll(object sender, EventArgs e)
        {
            txtNightIntensity.Text = trackBarNight.Value.ToString();

        }

        private void trackBarDay_Scroll(object sender, EventArgs e)
        {
            txtDayintensity.Text = trackBarDay.Value.ToString();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {



                DialogResult dialogResult = MessageBox.Show(" Do you want to Save The Details?", "Save Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bool languageSequence = saveLanguageSequence();
                    bool AutoIntensity = SaveAutoIntensity();
                   bool AutomaticRunnning = await SaveAutomaticRunning();
                    if (languageSequence && AutoIntensity && AutomaticRunnning)
                    {
                        sendAutoModeData();
                    }
                    else
                    {
                        MessageBox.Show("Please fill in the details properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }




        }
        public static void sendAutoModeData()
        {
            if (!BaseClass.IsNtesEnabled())
            {
                if (BaseClass.IsLocalAutoMode())
                {

                    DataController.sendAllBoardsData();
                    AnnouncementController.UpdateStatus("STOP");
                    AnnouncementController.UpdateAudioPlayStatus("Completed");
                    AnnouncementController.OtherAudioPlaying = true;
                    BaseClass.AnnouncementCount = 1;

                    AnnouncementController.playAnnounceMentData();

                }
            }

        }

        frmHome Hometab = new frmHome();
        // frmOnlineTrains online = new frmOnlineTrains();

        public async Task<bool> SaveAutomaticRunning()
        {
            bool saveSucess = false;
            try
            {
                if (GrbTimeSchedule.Enabled == true)
                {

                    if (chkTimeSelect.Checked)
                    {
                        ValidateTimeRange();
                    }

                    // Check for errors and return if any are visible
                    if (lblErrorTimeSchudeuleToTime.Visible || lblErrorTimeSchudeuleFromTime.Visible)
                    {

                        return false;
                    }
                    // Check for errors and return if any are visible
                    if (lblErrorTimeSchudeuleToTime.Visible || lblErrorTimeSchudeuleFromTime.Visible)
                    {

                        return false;
                    }
                    // Retrieve values from form controls
                    bool autoMode = chkAutoMode.Checked;
                    bool manualMode = chkManualMode.Checked;
                    bool selectTime = chkTimeSelect.Checked;
                    bool selectRange = chkRangeSelect.Checked;

                    // Handle nullable values
                    string timeFrom = string.IsNullOrEmpty(txtfrmtimeSchedule.Text) ? null : txtfrmtimeSchedule.Text;
                    string timeTo = string.IsNullOrEmpty(txtTOTimeSchedule.Text) ? null : txtTOTimeSchedule.Text;
                    string nexthrs = string.IsNullOrEmpty(Cmbselectedhrs.Text) ? null : Cmbselectedhrs.Text;
                    string DataMins = string.IsNullOrEmpty(txtDataSentMins.Text) ? null : txtDataSentMins.Text;
                    bool? deletion = chkAutoDeletion.Checked;
                    int? timeDeletion = string.IsNullOrEmpty(CmbAutoDeltionMins.Text) ? (int?)null : int.Parse(CmbAutoDeltionMins.Text);

                    // Call the method to insert or update the record
                    CommonSettingsDb.InsertUpdateAutomaticRunning(
                        autoMode,
                        manualMode,
                        selectTime,
                        timeFrom,
                        timeTo,
                        selectRange,
                        nexthrs,
                        DataMins,
                        deletion,
                        timeDeletion
                    );
                    saveSucess = true;
                    AnnouncementController.UpdateStatus("STOP");
                    AnnouncementController.UpdateAudioPlayStatus("Completed");

                    BaseClass.setAutomaticRunning();
                    DataTable existedtrains = InterfaceDb.ClearNtesWebServiceTable();//clearing ntes webservice and scheduled tadb where ntes check not true


                    frmOnlineTrains.DeleteTrains(existedtrains);
                    Form form = Application.OpenForms["frmHome"];
                    if (form != null)
                    {
                        frmHome homeForm = (frmHome)form;

                        homeForm.setNtesConnection();
                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return saveSucess;
        }

        public bool saveLanguageSequence()
        {


            bool saveSucess = false;
            int pkey = pValue;
            bool checkedData;
            if (chkActivePASystem.Checked)
            {
                checkedData = true;
            }
            else
            {
                checkedData = false;
            }

            List<string> languages = new List<string>();



            foreach (DataGridViewRow row in dgvLanguageSequence.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string language = row.Cells[0].Value.ToString();
                    languages.Add(language);
                }
            }



            String languageSequence = string.Join(",", languages);
            try
            {
                bool Save = CommonSettingsDb.InsertUpdateAnnouncementsettings(pkey, checkedData, languageSequence);

                if (Save)
                {
                    //  MessageBox.Show("Announcement settings saved successfully");
                    saveSucess = true;
                    //this.Close();
                    //BaseClass.indexForm.OpenFormInPanel(new frmCommonSettings(BaseClass.indexForm));
                }
                else
                {

                    //  MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return saveSucess;
        }

        public bool SaveAutoIntensity()
        {



            bool saveSucess = false;

            try
            {


                // Retriev values from controls
                bool autoIntensity = chkintensity.Checked;
                string dayIntensity1 = txtDayintensity.Text;
                string nightIntensity1 = txtNightIntensity.Text;
                if (int.TryParse(dayIntensity1, out int dayIntensity) &&
                    int.TryParse(nightIntensity1, out int nightIntensity))
                {
                    string fromTime = txtfromTime.Text;
                    string toTime = txtToTIme.Text;

                    // Check if error labels are not visible
                    if (!lblfromtimeError.Visible && !lbltoTimeError.Visible)
                    {
                        // Call the method to save or update the data
                        CommonSettingsDb.InsertOrUpdateAutoIntensity(autoIntensity, dayIntensity, nightIntensity, fromTime, toTime);

                        // Optionally, you can display a success message or perform other actions
                        //  MessageBox.Show("Auto intensity settings saved successfully.");
                        saveSucess = true;
                        frmHome home = new frmHome();
                        home.SetConfigurationBasedOnTime();
                    }
                    else
                    {
                        // Handle the case where there are validation errors
                        MessageBox.Show("Please correct AutoIntensity errors before saving.");
                    }
                }
                else
                {
                    // Handle invalid input cases
                    MessageBox.Show("Please enter valid numeric values for Day and Night Intensity.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return saveSucess;
        }
        public void GetAutoIntensity()
        {
            try
            {


                // Assuming GetAutoIntensitydt() returns a DataTable
                DataTable autoIntensityTable = CommonSettingsDb.GetAutoIntensitydt();

                // Check if the DataTable has rows
                if (autoIntensityTable.Rows.Count > 0)
                {
                    // Iterate through each row in the DataTable
                    foreach (DataRow row in autoIntensityTable.Rows)
                    {
                        // Extract values from each column
                        //int pkey = Convert.ToInt32(row["Pkey"]);
                        chkintensity.Checked = Convert.ToBoolean(row["AutoIntensity"]);
                        txtDayintensity.Text = row["DayIntensity"].ToString();
                        txtNightIntensity.Text = (row["NightIntensity"]).ToString();
                        txtfromTime.Text = row["FromTime"].ToString();
                        txtToTIme.Text = row["ToTime"].ToString();


                    }
                }
                else
                {
                    // Handle the case where there are no rows in the DataTable
                    //  Console.WriteLine("No data available in AutoIntensity table.");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void GetAutomaticRunning()
        {
            try
            {


                // Assuming GetAutoIntensitydt() returns a DataTable
                DataTable automaticRunningdt = BaseClass.AutomaticRunningdt;

                // Check if the DataTable has rows
                if (automaticRunningdt.Rows.Count > 0)
                {
                    // Iterate through each row in the DataTable
                    foreach (DataRow row in automaticRunningdt.Rows)
                    {
                        // Extract values from each column
                        //int pkey = Convert.ToInt32(row["Pkey"]);
                        chkManualMode.Checked = Convert.ToBoolean(row["ManualMode"]);
                        chkAutoMode.Checked = Convert.ToBoolean(row["AutoMode"]);
                        chkTimeSelect.Checked = Convert.ToBoolean(row["selectTime"]);
                        chkRangeSelect.Checked = Convert.ToBoolean(row["selectRange"]);
                        chkAutoDeletion.Checked = Convert.ToBoolean(row["Deletion"]);

                        txtfrmtimeSchedule.Text = (row["Time_from"]).ToString();
                        txtTOTimeSchedule.Text = row["Time_to"].ToString();
                        Cmbselectedhrs.Text = row["Nexthrs"].ToString();
                        txtDataSentMins.Text = (row["DataSentToBorads"]).ToString();
                        CmbAutoDeltionMins.Text = row["Time_Deletion"].ToString();




                    }
                }
                else
                {
                    // Handle the case where there are no rows in the DataTable

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }



        public static void AutoSetConfigurationForAllBoards()
        {
            try
            {


                foreach (DataRow row in BaseClass.ipadressTable.Rows)
                {

                    string ipaddress = row["IPAddress"].ToString();
                    int packetIdentifier = Convert.ToInt32(row["PacketIdentifier"].ToString());
                    int cdcid = Convert.ToInt32(row["cdcId"].ToString());
                    if (packetIdentifier == 2)
                    {
                        var config = CgdbController.GetDatatimeoutAndIntensityCgdb(cdcid);
                        int datatimeout = config.datatimeout;
                        int intensity = config.intensity;
                        byte[] SetConfiguration = CgdbController.SetConfigurationCgdb(ipaddress, packetIdentifier, datatimeout, intensity);
                        Server.SendMessageToClient(ipaddress, SetConfiguration);
                    }
                    else if (packetIdentifier == 3 || packetIdentifier == 4 || packetIdentifier == 5)
                    {
                        byte[] SetConfiguration = frmBoardDiagnosis.SetConfigurationTadb(ipaddress, packetIdentifier, cdcid);


                        Server.SendMessageToClient(ipaddress, SetConfiguration);
                    }

                    else if (packetIdentifier == 3 || packetIdentifier == 4 || packetIdentifier == 5)
                    {
                        DataTable dt = MediaDb.GetBorderColorConfiguration(cdcid);
                        if (dt.Rows.Count > 0)
                        {

                            byte[] SetConfiguration = frmBoardDiagnosis.SetConfigurationOVDIVD(ipaddress, packetIdentifier, cdcid);

                            Server.SendMessageToClient(ipaddress, SetConfiguration);
                        }
                    }
                    else
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }



        private void frmCommonSettings_Load(object sender, EventArgs e)
        {





            try
            {


                GetAutoIntensity();
                LoadAnnouncementSettings();
                Cmbselectedhrs.SelectedIndex = 0;
                GetAutomaticRunning();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }



        private void dgvLanguageSequence_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewColumn column = dgvLanguageSequence.Columns[e.ColumnIndex];
                    if (column is DataGridViewImageColumn)
                    {
                        if (column.Name == "dgvUpColumn")
                        {
                            MoveRowUp(e.RowIndex);
                        }
                        else if (column.Name == "dgvDownColumn")
                        {
                            MoveRowDown(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void MoveRowUp(int rowIndex)
        {
            if (rowIndex > 0)
            {
                SwappingRows(rowIndex, rowIndex - 1);
            }
        }

        private void MoveRowDown(int rowIndex)
        {
            if (rowIndex < dgvLanguageSequence.Rows.Count - 1)
            {
                SwappingRows(rowIndex, rowIndex + 1);
            }
        }

        private void SwappingRows(int firstRowIndex, int secondRowIndex)
        {
            try
            {


                DataGridViewRow firstRow = dgvLanguageSequence.Rows[firstRowIndex];
                DataGridViewRow secondRow = dgvLanguageSequence.Rows[secondRowIndex];


                dgvLanguageSequence.Rows.RemoveAt(firstRowIndex);
                dgvLanguageSequence.Rows.Insert(secondRowIndex, firstRow);


                if (firstRowIndex < secondRowIndex)
                {
                    secondRowIndex--;
                }

                dgvLanguageSequence.Rows[firstRowIndex].Selected = false;
                dgvLanguageSequence.Rows[secondRowIndex].Selected = false;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        int pValue;
        private void LoadAnnouncementSettings()
        {
            try
            {


                DataTable AnnouncementDatatable = CommonSettingsDb.GetAnnouncement();
                // Assuming 'AnnouncementDatatable' is your DataTable and you want to get the "AnnouncementText" column
                List<string> announcementList = AnnouncementDatatable.AsEnumerable()
                                                                      .Select(row => row.Field<string>("LanguageName"))
                                                                      .ToList();

                if (dgvLanguageSequence.Columns.Count > 0)
                {

                    foreach (DataRow row in AnnouncementDatatable.Rows)
                    {
                        pValue = Convert.ToInt32(row[0]);
                        if (row[1] is bool)
                        {
                            bool annonce = (bool)row[1];
                            chkActivePASystem.Checked = annonce;
                        }
                        else
                        {
                            throw new InvalidCastException("row[1] is not a boolean value.");
                        }
                        int rowIndex = dgvLanguageSequence.Rows.Add();

                        dgvLanguageSequence.Rows[rowIndex].Cells["dgvLanguageColumn"].Value = row["LanguageName"].ToString();

                    }
                }
                else
                {
                    MessageBox.Show("The DataGridView does not have any columns.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }




        private void txtDayintensity_TextChanged(object sender, EventArgs e)
        {

            try
            {


                // Temporarily detach the event handler to prevent recursive calls
                txtDayintensity.TextChanged -= txtDayintensity_TextChanged;

                // Try to parse the text to an integer
                if (int.TryParse(txtDayintensity.Text, out int value))
                {
                    // Ensure the value is within the allowed range (0 to 100)
                    if (value > 100)
                    {
                        value = 100; // Cap the value at 100
                    }

                    // Set the adjusted value to the TextBox
                    txtDayintensity.Text = value.ToString();
                    txtDayintensity.SelectionStart = txtDayintensity.Text.Length; // Move cursor to end

                    // Ensure the value is within the TrackBar's range and update the TrackBar
                    if (value >= trackBarDay.Minimum && value <= trackBarDay.Maximum)
                    {
                        trackBarDay.Value = value;
                    }
                }
                else
                {
                    // Optionally clear the text if parsing fails or handle invalid input
                    txtDayintensity.Text = "";
                    // Optionally reset TrackBar value or handle invalid input
                    // trackBarDay.Value = trackBarDay.Minimum;
                }

                // Reattach the event handler
                txtDayintensity.TextChanged += txtDayintensity_TextChanged;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        private void txtNightIntensity_TextChanged(object sender, EventArgs e)
        {
            try
            {


                // Temporarily detach the event handler to prevent recursive calls
                txtNightIntensity.TextChanged -= txtNightIntensity_TextChanged;

                if (int.TryParse(txtNightIntensity.Text, out int value))
                {
                    // Ensure the value is within the allowed range (0 to 100)
                    if (value > 100)
                    {
                        value = 100; // Cap the value at 100
                    }

                    // Set the adjusted value to the TextBox
                    txtNightIntensity.Text = value.ToString();

                    // Move the cursor to the end of the text
                    txtNightIntensity.SelectionStart = txtNightIntensity.Text.Length;

                    // Ensure the value is within the TrackBar's range and update the TrackBar
                    if (value >= trackBarNight.Minimum && value <= trackBarNight.Maximum)
                    {
                        trackBarNight.Value = value;
                    }
                }
                else
                {
                    // Optionally clear the text if parsing fails
                    txtNightIntensity.Text = "";

                    // Optionally reset TrackBar value or handle invalid input
                    // trackBarNight.Value = trackBarNight.Minimum;
                }

                // Reattach the event handler
                txtNightIntensity.TextChanged += txtNightIntensity_TextChanged;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtDayintensity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {


                // Allow digits, backspace, and control keys
                if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Enter)
                {
                    // Check if the current length of the text is less than 3
                    if (txtDayintensity.Text.Length >= 3 && !char.IsControl(e.KeyChar))
                    {
                        // Prevent the character from being entered into the TextBox
                        e.Handled = true;
                    }
                }
                else
                {
                    // Prevent any non-numeric characters from being entered into the TextBox
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtNightIntensity_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Allow digits, backspace, and control keys
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Enter)
            {
                // Check if the current length of the text is less than 3
                if (txtNightIntensity.Text.Length >= 3 && !char.IsControl(e.KeyChar))
                {
                    // Prevent the character from being entered into the TextBox
                    e.Handled = true;
                }
            }
            else
            {
                // Prevent any non-numeric characters from being entered into the TextBox
                e.Handled = true;
            }
        }

        private void CmbAutominutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits (0-9) and backspace (key code 8)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }

        private void chkTimeSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTimeSelect.Checked)
            {
                Cmbselectedhrs.SelectedIndex = 0;
                txtDataSentMins.Text = "2";
                chkRangeSelect.Checked = false;
                EnablechkTimeSelectControls(true);
                EnablechkRangeSelectControls(false);
            }
            else
            {
                chkRangeSelect.Checked = true;
                txtTOTimeSchedule.Text = "00:00";
                txtfrmtimeSchedule.Text = "00:00";
                chkTimeSelect.Checked = false;
                EnablechkTimeSelectControls(false);
                EnablechkRangeSelectControls(true);
            }

        }

        private void chkRangeSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRangeSelect.Checked)
            {
                txtTOTimeSchedule.Text = "00:00";
                txtfrmtimeSchedule.Text = "00:00";
                chkTimeSelect.Checked = false;
                EnablechkTimeSelectControls(false);
                EnablechkRangeSelectControls(true);
            }
            else
            {
                chkTimeSelect.Checked = true;
                Cmbselectedhrs.SelectedIndex = 0;
                txtDataSentMins.Text = "2";
                chkRangeSelect.Checked = false;
                EnablechkTimeSelectControls(true);
                EnablechkRangeSelectControls(false);
            }

        }

        private void EnablechkTimeSelectControls(bool enable)
        {
            txtfrmtimeSchedule.Enabled = enable;
            txtTOTimeSchedule.Enabled = enable;
            lblerrordatasend.Visible = false;
        }


        private void EnablechkRangeSelectControls(bool enable)
        {
            Cmbselectedhrs.Enabled = enable;
            lblErrorTimeSchudeuleFromTime.Visible = false;
            lblErrorTimeSchudeuleToTime.Visible = false;

        }

        private void chkManualMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManualMode.Checked)
            {
                chkAutoMode.Checked = false;
                GrbTimeSchedule.Enabled = true;
                grbTrainSchedule.Enabled = false;
                VisableModeControls(false);
            }
            else
            {
                chkAutoMode.Checked = true;
            }

        }

        private void chkAutoMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoMode.Checked)
            {
                chkManualMode.Checked = false;
                GrbTimeSchedule.Enabled = true;
                grbTrainSchedule.Enabled = true;
                VisableModeControls(true);
            }
            else
            {
                chkManualMode.Checked = true;
            }

        }


        private void VisableModeControls(bool enable)
        {

            lblDatasent.Visible = enable;
            txtDataSentMins.Visible = enable;
            lblAutoMins.Visible = enable;



        }

        private void chkAutoDeletion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoDeletion.Checked)
            {
                CmbAutoDeltionMins.Enabled = true;

            }
            else
            {
                CmbAutoDeltionMins.Enabled = false;
            }

        }



        private void txtTOTimeSchedule_Validating(object sender, CancelEventArgs e)
        {
            validatetime(txtTOTimeSchedule, lblErrorTimeSchudeuleFromTime);
        }



        private void txtTOTimeSchedule_TextChanged(object sender, EventArgs e)
        {
            try
            {


                // Get the text from the TextBox
                string input = txtTOTimeSchedule.Text;

                // Check if the input contains only digits
                if (Regex.IsMatch(input, @"^\d+$"))
                {
                    // If the input length is 3 and the 3rd character is not a colon, insert a colon after the first two digits
                    if (input.Length == 3 && input[2] != ':')
                    {
                        txtTOTimeSchedule.Text = input.Insert(2, ":");
                        txtTOTimeSchedule.SelectionStart = txtTOTimeSchedule.Text.Length; // Move the cursor to the end of the text
                    }
                }

                // If the input length is greater than 5, truncate the input to 5 characters
                if (input.Length > 5)
                {
                    txtTOTimeSchedule.Text = input.Substring(0, 5);
                    txtTOTimeSchedule.SelectionStart = txtTOTimeSchedule.Text.Length; // Move the cursor to the end of the truncated text
                }
                if (input.Length == 5)
                {
                    validatetime(txtTOTimeSchedule, lblErrorTimeSchudeuleToTime);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtfrmtimeSchedule_TextChanged(object sender, EventArgs e)
        {
            try
            {


                // Get the text from the TextBox
                string input = txtfrmtimeSchedule.Text;

                // Check if the input contains only digits
                if (Regex.IsMatch(input, @"^\d+$"))
                {
                    // If the input length is 3 and the 3rd character is not a colon, insert a colon after the first two digits
                    if (input.Length == 3 && input[2] != ':')
                    {
                        txtfrmtimeSchedule.Text = input.Insert(2, ":");
                        txtfrmtimeSchedule.SelectionStart = txtfrmtimeSchedule.Text.Length; // Move the cursor to the end of the text
                    }
                }

                // If the input length is greater than 5, truncate the input to 5 characters
                if (input.Length > 5)
                {
                    txtfrmtimeSchedule.Text = input.Substring(0, 5);
                    txtfrmtimeSchedule.SelectionStart = txtfrmtimeSchedule.Text.Length; // Move the cursor to the end of the truncated text
                }
                if (input.Length == 5)
                {
                    validatetime(txtfrmtimeSchedule, lblErrorTimeSchudeuleFromTime);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtfrmtimeSchedule_Validating(object sender, CancelEventArgs e)
        {
            validatetime(txtfrmtimeSchedule, lblErrorTimeSchudeuleFromTime);
        }

        private void txtDataSentMins_TextChanged(object sender, EventArgs e)
        {
            // Check if the text in txtDataSentMins is empty
            if (string.IsNullOrWhiteSpace(txtDataSentMins.Text))
            {
                // Show the error label if the text is empty
                lblerrordatasend.Visible = true;
            }
            else
            {
                // Hide the error label if there is text
                lblerrordatasend.Visible = false;
            }
        }

        private void txtDataSentMins_TextChanged_1(object sender, EventArgs e)
        {
            // Check if the text in txtDataSentMins is empty
            if (string.IsNullOrWhiteSpace(txtDataSentMins.Text))
            {
                // Show the error label if the text is empty
                lblerrordatasend.Visible = true;
            }
            else
            {
                // Hide the error label if there is text
                lblerrordatasend.Visible = false;
            }
        }

        private void txtDataSentMins_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Allow only digits and control characters like backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Suppress the key press event for non-digit characters
                e.Handled = true;
            }
        }

        private void CmbAutoDeltionMins_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Allow only digits and control characters like backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Suppress the key press event for non-digit characters
                e.Handled = true;
            }
        }

        private void txtfrmtimeSchedule_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing digits, backspace, and colon
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ':')
            {
                // Prevent the character from being entered into the TextBox
                e.Handled = true;
            }
        }

        private void txtTOTimeSchedule_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing digits, backspace, and colon
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ':')
            {
                // Prevent the character from being entered into the TextBox
                e.Handled = true;
            }
        }

        private void txtfrmtimeSchedule_Leave(object sender, EventArgs e)
        {
            ValidateTimeRange();
        }

        private void txtTOTimeSchedule_Leave(object sender, EventArgs e)
        {
            ValidateTimeRange();
        }

        // Method to validate that To Time is greater than From Time
        private void ValidateTimeRange()
        {

            try
            {


                DateTime fromTime;
                DateTime toTime;

                bool fromTimeParsed = DateTime.TryParse(txtfrmtimeSchedule.Text, out fromTime);
                bool toTimeParsed = DateTime.TryParse(txtTOTimeSchedule.Text, out toTime);

                if (fromTimeParsed && toTimeParsed)
                {
                    if (toTime <= fromTime)
                    {
                        // Show error messages if the validation fails
                        lblErrorTimeSchudeuleToTime.Visible = true;
                        lblErrorTimeSchudeuleToTime.Text = "To Time must be greater than From Time.";
                        lblErrorTimeSchudeuleFromTime.Visible = true;
                        lblErrorTimeSchudeuleFromTime.Text = "From Time must be less than To Time.";
                    }
                    else
                    {
                        // Hide error messages if the validation passes
                        lblErrorTimeSchudeuleToTime.Visible = false;
                        lblErrorTimeSchudeuleFromTime.Visible = false;
                    }
                }
                else
                {
                    // Handle cases where time parsing fails
                    lblErrorTimeSchudeuleToTime.Visible = false;
                    lblErrorTimeSchudeuleFromTime.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void Cmbselectedhrs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                // Assuming Cmbselectedhrs contains the number of hours to add (e.g., 1, 2, 3, etc.)
                // Assuming Cmbselectedhrs contains the number of hours to add (e.g., 1, 2, 3, etc.)
                if (int.TryParse(Cmbselectedhrs.SelectedItem.ToString(), out int hoursToAdd))
                {
                    // Get the current time
                    DateTime currentTime = DateTime.Now;

                    // Calculate the new time by adding the selected hours
                    DateTime newTime = currentTime.AddHours(hoursToAdd);

                    // Check if the new time exceeds midnight (24 hours)
                    if (newTime.TimeOfDay >= TimeSpan.FromHours(24))
                    {
                        // If the time exceeds 24 hours, reset to 1 hour from now
                        newTime = currentTime.AddHours(1);
                    }

                    // Update the ComboBox to show the new time (if needed)
                    // Example: setting the selected hour to the new hour (if the ComboBox only contains hours)
                    Cmbselectedhrs.SelectedItem = newTime.Hour.ToString();

                    // Optionally, you can update another control with the exact minute if needed
                    // Example: lblTime.Text = newTime.ToString("HH:mm");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        private void grbTrainSchedule_Enter(object sender, EventArgs e)
        {


        }

        private void grbAutomaticRunning_Enter(object sender, EventArgs e)
        {

        }
    }
}
