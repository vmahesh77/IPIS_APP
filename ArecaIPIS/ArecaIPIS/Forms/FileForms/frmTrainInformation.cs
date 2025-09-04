using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms.HomeForms;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{

    public partial class frmTrainInformation : Form
    {
        public static List<string> CoachDetailsList = new List<string>();
        public frmTrainInformation()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // Correct setting for license context
        }

        private frmIndex parentForm;

        public frmTrainInformation(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }







        private void btnCoachDetails_Click(object sender, EventArgs e)
        {
            panTrainDetails.Visible = false;
            panCoachDetails.Visible = true;
        }

        private void btnTrainDetails_Click(object sender, EventArgs e)
        {
            panTrainDetails.Visible = true;
            panCoachDetails.Visible = false;
        }


        public void RegionalLangExistedOrNotMakeVisible()
        {
            if (BaseClass.Languages.Count >= 3)
            {
                btnRegionalKeyboard.Visible = true;
                txtRegional.Visible = true;
                lblRegional.Visible = true;
            }
            else
            {
                btnRegionalKeyboard.Visible = false;
                txtRegional.Visible = false;
                lblRegional.Visible = false;
            }
        }
        private void frmTrainInformation_Load(object sender, EventArgs e)
        {
            try
            {
                cmbLinkTrain.Items.Clear();
                cmbLinkTrain.Visible = false;
                lblLinkTrains.Visible = false;

                RegionalLangExistedOrNotMakeVisible();
                countTextBoxValidations = 0;
                setWeekstable();
                SetTrainTypes();

                SetPlatforms();
                InitializeControls();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void SetPlatforms()
        {
            // Clear existing items in the ComboBox
            cmbPlatform.Items.Clear();

            // Add the default item "--Select--"
            // cmbPlatform.Items.Add("--Select--");

            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var platform in BaseClass.Platforms)
            {

                string trimmedPlatform = platform.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbPlatform.Items.Add(trimmedPlatform);
            }

            // Select the default item "--Select--"
            cmbPlatform.SelectedIndex = 0;
        }




        //public static Panel panel = new Panel();
        private void SetTrainTypes()
        {

            cmbTrainType.Items.Clear();
            cmbTrainType.Items.Add("--Select--");
            // Add languages from BaseClass.Languages to the ComboBox
            foreach (string language in BaseClass.TrainTypes)
            {
                cmbTrainType.Items.Add(language);
            }

            if (cmbTrainType.Items.Count > 0)
            {
                cmbTrainType.SelectedIndex = 0;
            }
            cmbCategory.SelectedIndex = 0;
        }

        private void setWeekstable()
        {
            try
            {


                // Prevent users from manually adding rows
                dataGridViewTrainInfo.AllowUserToAddRows = false;

                // Clear existing rows in the DataGridView
                dataGridViewTrainInfo.Rows.Clear();

                // Add rows with default values for the "Days" column
                string[] daysOfWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
                foreach (string day in daysOfWeek)
                {
                    int rowIndex = dataGridViewTrainInfo.Rows.Add(false, day);
                    // Set checkbox column value to false for each row
                    dataGridViewTrainInfo.Rows[rowIndex].Cells["select"].Value = false;
                }

                // Adjust row height to fit entire grid
                int totalRowHeight = dataGridViewTrainInfo.ColumnHeadersHeight; // Include header height
                foreach (DataGridViewRow row in dataGridViewTrainInfo.Rows)
                {
                    totalRowHeight += row.Height; // Add height of each row
                }
                dataGridViewTrainInfo.Height = totalRowHeight + 2; // Adjusting by a small margin
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void InitializeControls()
        {
            txtHindi.Enter += Control_Enter;
            txtRegional.Enter += Control_Enter;
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
                //// MessageBox.Show("The panel or another object was disposed and cannot be accessed. " +
                //                 "Please check the state of your objects and try again.",
                //                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }



        private void frmTrainInformation_MouseClick(object sender, MouseEventArgs e)
        {
            //try
            //{


            //    panel.Controls.Clear();
            //    panel.Visible = false;

            //    Form mainForm = Application.OpenForms["frmScheduledTrains"];

            //    if (mainForm != null)
            //    {
            //        frmScheduledTrains frmScheduled = (frmScheduledTrains)mainForm;
            //        frmScheduled.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Server.LogError(ex.Message);
            //}

        }

        private void btnKeyBoardHindi_Click(object sender, EventArgs e)
        {
            Keyboard(700, 150, "Hindi");
        }

        private void btnkeyboardRegional_Click(object sender, EventArgs e)
        {
            //Keyboard(700, 150);
        }
        private void btnRegionalKeyboard_Click(object sender, EventArgs e)
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

            Keyboard(700, 150, localLanguage);
        }

        private void rctbTrainNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control character (e.g., Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If the pressed key is not a digit or a control character, suppress it
                e.Handled = true;
            }
        }

        private void rctbSource_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not a letter or a control character (like backspace), suppress the key press
                e.Handled = true;
            }
        }

        private void rctbDestination_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not a letter or a control character (like backspace), suppress the key press
                e.Handled = true;
            }
        }

        private void rctbVia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not a letter or a control character (like backspace), suppress the key press
                e.Handled = true;
            }
        }

        private void rctbEnglish_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(rctbEnglish.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                rctbEnglish.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                rctbEnglish.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                rctbEnglish.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                rctbEnglish.BackColor = SystemColors.Window;
            }
        }

        private void rctbSource_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(rctbSource.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                rctbSource.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                rctbSource.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                rctbSource.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                rctbSource.BackColor = SystemColors.Window;
            }
        }

        private void rctbDestination_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(rctbDestination.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                rctbDestination.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                rctbDestination.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                rctbDestination.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                rctbDestination.BackColor = SystemColors.Window;
            }
        }

        private void rctbVia_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(rctbVia.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                rctbVia.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                rctbVia.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                rctbVia.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                rctbVia.BackColor = SystemColors.Window;
            }
        }

        private void txtHindi_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(txtHindi.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                txtHindi.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                txtHindi.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                txtHindi.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                txtHindi.BackColor = SystemColors.Window;
            }
        }


        private void txtRegional_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(txtRegional.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                txtRegional.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                txtRegional.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                txtRegional.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                txtRegional.BackColor = SystemColors.Window;
            }
        }

        private void rctbTrainNumber_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(rctbTrainNumber.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                rctbTrainNumber.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                rctbTrainNumber.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                rctbTrainNumber.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                rctbTrainNumber.BackColor = SystemColors.Window;
                if (BaseClass.trainNumbers.Contains(rctbTrainNumber.Text.ToString().Trim()))
                {
                    MessageBox.Show("Train Number Already Exit");
                    rctbTrainNumber.BackColor = Color.Red;
                }
                else
                {
                    String TRAINNUMBERLENGTH = rctbTrainNumber.Text;
                    if (TRAINNUMBERLENGTH.Length != 5)
                    {
                        // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                        rctbTrainNumber.BorderStyle = BorderStyle.FixedSingle;
                        // Set the back color to red to further indicate a warning
                        rctbTrainNumber.BackColor = Color.Red;
                    }
                }
            }


        }



        private void chkCgdb_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (chkCgdb.Checked)
            {
                // If checked, enable the panel
                pnlCoachPositions.Enabled = true;
            }
            else
            {
                // If unchecked, disable the panel
                pnlCoachPositions.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtArrivalTime_TextChanged(object sender, EventArgs e)
        {
            try
            {


                // Get the text from the TextBox
                string input = txtArrivalTime.Text;

                // Check if the input contains only digits
                if (Regex.IsMatch(input, @"^\d+$"))
                {
                    // If the input length is 3 and the 3rd character is not a colon, insert a colon after the first two digits
                    if (input.Length == 3 && input[2] != ':')
                    {
                        txtArrivalTime.Text = input.Insert(2, ":");
                        txtArrivalTime.SelectionStart = txtArrivalTime.Text.Length; // Move the cursor to the end of the text
                    }
                }

                // If the input length is greater than 5, truncate the input to 5 characters
                if (input.Length > 5)
                {
                    txtArrivalTime.Text = input.Substring(0, 5);
                    txtArrivalTime.SelectionStart = txtArrivalTime.Text.Length; // Move the cursor to the end of the truncated text
                }
                if (input.Length == 5)
                {
                    validatetime(txtArrivalTime, lblArrivalError);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        private void txtArrivalTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing digits, backspace, and colon
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ':')
            {
                // Prevent the character from being entered into the TextBox
                e.Handled = true;
            }
            lblSameTimeError.Visible = false;
            lblArrivalError.Visible = false;
            lblDepatureError.Visible = false;
        }

        private void txtArrivalTime_Validating(object sender, CancelEventArgs e)
        {
            validatetime(txtArrivalTime, lblArrivalError);

            //// Get the text from the TextBox
            //string input = txtArrivalTime.Text;

            //// Check if the input matches the 24-hour time format (HH:mm)
            //if (!Regex.IsMatch(input, @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$"))
            //{
            //    lblArrivalError.Visible = true;
            //    lblArrivalError.Text = "Please enter a valid time in 24-hour format (HH:mm).";
            //    // If the input doesn't match the format, show an error message
            //   // MessageBox.Show("Please enter a valid time in 24-hour format (HH:mm).", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //   // e.Cancel = true; // Cancel the event to prevent focus change
            //}
            //else
            //{
            //    lblArrivalError.Visible = false;
            //}
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

        private void txtDepatureTime_TextChanged(object sender, EventArgs e)
        {
            try
            {



                // Get the text from the TextBox
                string input = txtDepatureTime.Text;

                // Check if the input contains only digits
                if (Regex.IsMatch(input, @"^\d+$"))
                {
                    // If the input length is 3 and the 3rd character is not a colon, insert a colon after the first two digits
                    if (input.Length == 3 && input[2] != ':')
                    {
                        txtDepatureTime.Text = input.Insert(2, ":");
                        txtDepatureTime.SelectionStart = txtDepatureTime.Text.Length; // Move the cursor to the end of the text
                    }
                }

                // If the input length is greater than 5, truncate the input to 5 characters
                if (input.Length > 5)
                {
                    txtDepatureTime.Text = input.Substring(0, 5);
                    txtDepatureTime.SelectionStart = txtDepatureTime.Text.Length; // Move the cursor to the end of the truncated text
                }
                if (input.Length == 5)
                {
                    validatetime(txtDepatureTime, lblDepatureError);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtDepatureTime_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Allowing digits, backspace, and colon
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ':')
            {
                // Prevent the character from being entered into the TextBox
                e.Handled = true;
            }
            lblSameTimeError.Visible = false;
            lblArrivalError.Visible = false;
            lblDepatureError.Visible = false;
        }

        private void txtArrivalTime_Leave(object sender, EventArgs e)
        {
            validateSametime();
            txtArrivalTime.Text = FormatValidTime(txtArrivalTime.Text);

        }
        private void validateSametime()
        {
            // Get the text from the Arrival Time TextBox
            string arrivalTime = txtArrivalTime.Text;

            // Get the text from the Departure Time TextBox
            string departureTime = txtDepatureTime.Text;

            // Check if both arrival and departure times are not empty and are the same
            if (arrivalTime == departureTime)
            {
                // Show an error message
                lblSameTimeError.Text = "Arrival and departure times cannot be the same.";
                lblSameTimeError.Visible = true;
            }
            else
            {
                // Hide the error label if the times are different or one of them is empty
                lblSameTimeError.Visible = false;
            }
        }
        public static DataTable ConvertDataGridViewToDataTable(DataGridView dataGridView)
        {


            DataTable dataTable = new DataTable();
            try
            {



                // Add columns to DataTable

                foreach (DataGridViewColumn column in dataGridView.Columns)
                {

                    dataTable.Columns.Add(column.Name, column.ValueType ?? typeof(string));

                }


                // Add rows to DataTable
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.IsNewRow) continue; // Skip the new row placeholder

                    DataRow dataRow = dataTable.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dataRow[cell.OwningColumn.Name] = cell.Value ?? DBNull.Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return dataTable;
        }





        public void saveLinkedTrains()
        {
            string LinkedTrain1 = cmbLinkTrain.Text.ToString().Trim();
            string LinkedTrain2 = rctbTrainNumber.Text.ToString().Trim();
            if (!string.IsNullOrEmpty(LinkedTrain1))
                OnlineTrainsDao.InsertLinkedTrains(LinkedTrain1, LinkedTrain2);
            cmbLinkTrain.Items.Clear();
            cmbLinkTrain.Visible = false;
            lblLinkTrains.Visible = false;
        }

        public void SaveNewTrainInfo(string Trnum,string EngName,string HinName,string LocalName,string Sta,string Std,String pf,string Coaches,string UpDown,string days)
        {
            var train = new TrainInfo
            {
                TrainNumber = Trnum,
                TrainNameEN = EngName,
                TrainNameHI = HinName,
                TrainNameL = LocalName,
                STA = Sta,
                STD = Std,
               
                PF = pf,
                Coaches = Coaches,
                StatUpDown=UpDown,
                Days=days
            };
            BaseClass.InsertOrUpdateTrainData(train);
        }

        


        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                // saveLinkedTrains();

                vaidateAllControls();
                if (countTextBoxValidations == 0)
                {
                    bool checkTrainNumber = OnlineTrainsDao.CheckTrainExisted(rctbTrainNumber.Text);
                    checkTrainNumber = false;
                    if (!checkTrainNumber)
                    {
                        AddCoachDetailsList();


                        DataTable RunningTrainDirections = ConvertDataGridViewToDataTable(dataGridViewTrainInfo);

                        string coachString = string.Join(",", CoachDetailsList);
                        string Days = string.Join(",",
                   RunningTrainDirections.AsEnumerable()
                       .Where(row => row[0].ToString().Trim().Equals("True", StringComparison.OrdinalIgnoreCase))
                       .Select(row => row[1].ToString().Trim())
               );
                        SaveNewTrainInfo(rctbTrainNumber.Text, rctbEnglish.Text, txtHindi.Text, txtRegional.Text, txtArrivalTime.Text, txtDepatureTime.Text, cmbPlatform.Text, coachString, CmbStatus.Text,Days);




                        bool sucess = OnlineTrainsDao.InsertUpdateTrainDetails(-1, rctbTrainNumber.Text, cmbTrainType.Text, cmbCategory.Text, rctbSource.Text, rctbDestination.Text,
                             rctbVia.Text, rctbEnglish.Text, txtHindi.Text, txtRegional.Text, txtArrivalTime.Text, txtDepatureTime.Text, cmbPlatform.Text,
                             CmbStatus.Text, RunningTrainDirections, CoachDetailsList);


                        ReportDb.InsertDatabaseModificationReportData("Train Information Updated  Train No " + rctbTrainNumber.Text, "2");
                        if (sucess)
                        {
                            if (cmbCategory.Text.Trim() == "Link")
                            {
                                OnlineTrainsDao.InsertUpdateLinkedTrains(rctbTrainNumber.Text, cmbLinkTrain.Text.Trim());
                                List<string> trainCoachDetailsList = AddLinkedCoachDetailsList(CoachDetailsList, rctbTrainNumber.Text.Trim());
                                OnlineTrainsDao.InsertUpdateLinkedTrainsCoaches(rctbTrainNumber.Text, trainCoachDetailsList);

                            }
                            MessageBox.Show("Train data Saved Sucessfully.");
                            clearAllControls();
                            BaseClass.GetAllTrainsNumbers();
                            BaseClass.GetLinkedTrainsList();
                        }
                        else
                        {
                            MessageBox.Show("Failed to Insert Train!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Train Number Already Existed");
                    }
                }
                else
                {
                    countTextBoxValidations = 0;
                    MessageBox.Show("please fix the errors");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public static List<string> AddLinkedCoachDetailsList(List<string> coachPositionList, string trainnumber)
        {

            // Initialize the result list
            List<string> trainCoachDetailsList = new List<string>();

            // Loop through the coach positions and create TrainCoachDetails objects
            foreach (var coachPosition in coachPositionList)
            {


                trainCoachDetailsList.Add(trainnumber + "-" + coachPosition);



            }

            // Return the list
            return trainCoachDetailsList;
        }


        public void AddCoachDetailsList()
        {
            try
            {



                CoachDetailsList.Clear();

                CoachDetailsList.Add(txtCoach1.Text);
                CoachDetailsList.Add(txtCoach2.Text);
                CoachDetailsList.Add(txtCoach3.Text);
                CoachDetailsList.Add(txtCoach4.Text);
                CoachDetailsList.Add(txtCoach5.Text);
                CoachDetailsList.Add(txtCoach6.Text);
                CoachDetailsList.Add(txtCoach7.Text);
                CoachDetailsList.Add(txtCoach8.Text);
                CoachDetailsList.Add(txtCoach9.Text);
                CoachDetailsList.Add(txtCoach10.Text);
                CoachDetailsList.Add(txtCoach11.Text);
                CoachDetailsList.Add(txtCoach12.Text);
                CoachDetailsList.Add(txtCoach13.Text);
                CoachDetailsList.Add(txtCoach14.Text);
                CoachDetailsList.Add(txtCoach15.Text);
                CoachDetailsList.Add(txtCoach16.Text);
                CoachDetailsList.Add(txtCoach17.Text);
                CoachDetailsList.Add(txtCoach18.Text);
                CoachDetailsList.Add(txtCoach19.Text);
                CoachDetailsList.Add(txtCoach20.Text);
                CoachDetailsList.Add(txtCoach21.Text);
                CoachDetailsList.Add(txtCoach22.Text);
                CoachDetailsList.Add(txtCoach23.Text);
                CoachDetailsList.Add(txtCoach24.Text);
                CoachDetailsList.Add(txtCoach25.Text);
                CoachDetailsList.Add(txtCoach26.Text);
                CoachDetailsList.Add(txtCoach27.Text);
                CoachDetailsList.Add(txtCoach28.Text);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void rctbDestination_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                dataGridViewTrainInfo.Rows[i].Cells["Destination"].Value = rctbDestination.Text;
            }
        }

        private void rctbVia_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                dataGridViewTrainInfo.Rows[i].Cells["Via"].Value = rctbVia.Text;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(rctbTrainNumber.Text))
                {



                    bool deleted = OnlineTrainsDao.DeleteTrainDetails(rctbTrainNumber.Text);
                    if (deleted)
                    {
                        MessageBox.Show("deleted Sucessfully");
                        clearAllControls();
                        BaseClass.GetAllTrainsNumbers();
                        BaseClass.GetLinkedTrainsList();
                    }
                    else
                    {
                        MessageBox.Show("Failed !");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Train");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {


                frmScheduledTrains frmscheduled;
                BaseClass.selectTrainsDatabase = "AllTrains";
                Form mainForm = Application.OpenForms["frmScheduledTrains"];

                if (mainForm != null)
                {
                    frmscheduled = (frmScheduledTrains)mainForm;
                    frmscheduled.Show();
                }
                else
                {
                    frmscheduled = new frmScheduledTrains();
                    frmscheduled.Show();
                }
                frmscheduled.BringToFront();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        public void fillAllTextBoxes()
        {
            rctbTrainNumber.Text = "e";

        }

        private void frmTrainInformation_Leave(object sender, EventArgs e)
        {
            try
            {



                Form mainForm = Application.OpenForms["frmScheduledTrains"];

                if (mainForm != null)
                {
                    frmScheduledTrains frmScheduled = (frmScheduledTrains)mainForm;
                    frmScheduled.Close();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        public static int countTextBoxValidations = 0;
        public void ValidatRichTextBox(RichTextBox text)
        {
            if (string.IsNullOrWhiteSpace(text.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                text.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                text.BackColor = Color.Red;
                countTextBoxValidations++;
            }
            else
            {
                // Reset the border style to its default
                text.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                text.BackColor = SystemColors.Window;
            }
        }
        public void Validatlabel(Label label)
        {
            if (label.Visible == true)
            {
                countTextBoxValidations++;
            }
        }

        public void ValidatTextBox(TextBox text)
        {
            if (string.IsNullOrWhiteSpace(text.Text))
            {
                text.BorderStyle = BorderStyle.FixedSingle;
                text.BackColor = Color.Red;
                
            }
            else
            {
                text.BorderStyle = BorderStyle.Fixed3D;
                text.BackColor = SystemColors.Window;
            }
        }


        public void vaidateAllControls()
        {


            ValidatRichTextBox(rctbTrainNumber);
            ValidatRichTextBox(rctbSource);
            ValidatRichTextBox(rctbDestination);
            ValidatRichTextBox(rctbVia);
            ValidatRichTextBox(rctbEnglish);
            ValidatTextBox(txtHindi);
            ValidatTextBox(txtRegional);
            ValidatTextBox(txtArrivalTime);
            ValidatTextBox(txtDepatureTime);
            Validatlabel(lblSameTimeError);
            Validatlabel(lblArrivalError);
            Validatlabel(lblDepatureError);
            String TRAINNUMBERLENGTH = rctbTrainNumber.Text;
            if (TRAINNUMBERLENGTH.Length != 5)
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                rctbTrainNumber.BorderStyle = BorderStyle.FixedSingle;
                countTextBoxValidations++;
                // Set the back color to red to further indicate a warning
                rctbTrainNumber.BackColor = Color.Red;
            }


        }

        public void fillTrainInformation(string trainNumber)
        {
            try
            {


                DataTable Traindt = OnlineTrainsDao.GetTrainByNumber(trainNumber);

                DataTable TrainDirctionsdt = OnlineTrainsDao.GetTrainByTrainDirtections(trainNumber);

                dataGridViewTrainInfo.Rows.Clear();
                foreach (DataRow row in TrainDirctionsdt.Rows)
                {
                    int rowIndex = dataGridViewTrainInfo.Rows.Add();
                    dataGridViewTrainInfo.Rows[rowIndex].Cells["select"].Value = (Boolean)row["Checked"];
                    dataGridViewTrainInfo.Rows[rowIndex].Cells["Days"].Value = row["Days"].ToString();
                    dataGridViewTrainInfo.Rows[rowIndex].Cells["Via"].Value = row["Via"].ToString();
                    dataGridViewTrainInfo.Rows[rowIndex].Cells["Destination"].Value = row["Destination"].ToString();
                }


                foreach (DataRow row in Traindt.Rows)
                {
                    rctbTrainNumber.Text = row["TrainNumber"].ToString();
                    cmbTrainType.Text = row["TrainType"].ToString();
                    cmbCategory.Text = row["Category"].ToString();
                    rctbSource.Text = row["Source"].ToString();
                    rctbDestination.Text = row["Destination"].ToString();
                    rctbVia.Text = row["Via"].ToString();
                    rctbEnglish.Text = row["EnglishName"].ToString();
                    txtHindi.Text = row["HindiName"].ToString();
                    txtRegional.Text = row["RegionalName"].ToString();
                    txtArrivalTime.Text = row["ArrivalTime"].ToString();
                    txtDepatureTime.Text = row["DepartureTime"].ToString();
                    cmbPlatform.Text = row["Platform"].ToString();
                    CmbStatus.Text = row["Status"].ToString();
                    chkCgdb.Checked = true;
                    string coachpositions = row["coachPositions"].ToString();
                    string[] coachValues = coachpositions.Split(',');


                    txtCoach1.Text = coachValues.Length > 0 ? coachValues[0] : string.Empty;
                    txtCoach2.Text = coachValues.Length > 1 ? coachValues[1] : string.Empty;
                    txtCoach3.Text = coachValues.Length > 2 ? coachValues[2] : string.Empty;
                    txtCoach4.Text = coachValues.Length > 3 ? coachValues[3] : string.Empty;
                    txtCoach5.Text = coachValues.Length > 4 ? coachValues[4] : string.Empty;
                    txtCoach6.Text = coachValues.Length > 5 ? coachValues[5] : string.Empty;
                    txtCoach7.Text = coachValues.Length > 6 ? coachValues[6] : string.Empty;
                    txtCoach8.Text = coachValues.Length > 7 ? coachValues[7] : string.Empty;
                    txtCoach9.Text = coachValues.Length > 8 ? coachValues[8] : string.Empty;
                    txtCoach10.Text = coachValues.Length > 9 ? coachValues[9] : string.Empty;
                    txtCoach11.Text = coachValues.Length > 10 ? coachValues[10] : string.Empty;
                    txtCoach12.Text = coachValues.Length > 11 ? coachValues[11] : string.Empty;
                    txtCoach13.Text = coachValues.Length > 12 ? coachValues[12] : string.Empty;
                    txtCoach14.Text = coachValues.Length > 13 ? coachValues[13] : string.Empty;
                    txtCoach15.Text = coachValues.Length > 14 ? coachValues[14] : string.Empty;
                    txtCoach16.Text = coachValues.Length > 15 ? coachValues[15] : string.Empty;
                    txtCoach17.Text = coachValues.Length > 16 ? coachValues[16] : string.Empty;
                    txtCoach18.Text = coachValues.Length > 17 ? coachValues[17] : string.Empty;
                    txtCoach19.Text = coachValues.Length > 18 ? coachValues[18] : string.Empty;
                    txtCoach20.Text = coachValues.Length > 19 ? coachValues[19] : string.Empty;
                    txtCoach21.Text = coachValues.Length > 20 ? coachValues[20] : string.Empty;
                    txtCoach22.Text = coachValues.Length > 21 ? coachValues[21] : string.Empty;
                    txtCoach23.Text = coachValues.Length > 22 ? coachValues[22] : string.Empty;
                    txtCoach24.Text = coachValues.Length > 23 ? coachValues[23] : string.Empty;
                    txtCoach25.Text = coachValues.Length > 24 ? coachValues[24] : string.Empty;
                    txtCoach26.Text = coachValues.Length > 25 ? coachValues[25] : string.Empty;
                    txtCoach27.Text = coachValues.Length > 26 ? coachValues[26] : string.Empty;
                    txtCoach28.Text = coachValues.Length > 27 ? coachValues[27] : string.Empty;


                    DataTable Linkedtrainsdt = OnlineTrainsDao.GetLinkedTrainsDetailsbyTrainNo(rctbTrainNumber.Text.Trim());


                    if (Linkedtrainsdt.Rows.Count > 0)
                    {
                        foreach (DataRow Linkedtrainsrow in Linkedtrainsdt.Rows)
                        {

                            if (rctbTrainNumber.Text.Trim() == Linkedtrainsrow["TrainNo"].ToString())
                            {
                                string Linkedtrain = Linkedtrainsrow["LinkedTrainNo"].ToString();

                                cmbLinkTrain.Text = (Linkedtrain);


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

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                clearAllControls();
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error retrieving data from database: " + ex.Message);
                Server.LogError("Error retrieving data from database:" + ex.Message);

            }

        }


        public void clearAllControls()
        {
            cmbLinkTrain.Text = "";
            cmbLinkTrain.Items.Clear();
            rctbTrainNumber.Text = "";
            rctbTrainNumber.BackColor = SystemColors.Window;
            cmbTrainType.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            rctbSource.Text = "";
            rctbSource.BackColor = SystemColors.Window;

            rctbDestination.Text = "";
            rctbDestination.BackColor = SystemColors.Window;

            rctbVia.Text = "";
            rctbVia.BackColor = SystemColors.Window;

            rctbEnglish.Text = "";
            rctbEnglish.BackColor = SystemColors.Window;

            txtHindi.Text = "";
            txtHindi.BackColor = SystemColors.Window;

            txtRegional.Text = "";
            txtRegional.BackColor = SystemColors.Window;


            txtArrivalTime.Text = "00:00";
            txtArrivalTime.BackColor = SystemColors.Window;

            txtDepatureTime.Text = "00:00";
            txtDepatureTime.BackColor = SystemColors.Window;


            cmbPlatform.SelectedIndex = 0;
            CmbStatus.SelectedIndex = 0;

            lblLinkTrains.Visible = false;
            cmbLinkTrain.Visible = false;
            lblSameTimeError.Visible = false;
            lblArrivalError.Visible = false;
            lblDepatureError.Visible = false;


            chkCgdb.Checked = false;
            txtCoach1.Text = "";
            txtCoach2.Text = "";
            txtCoach3.Text = "";
            txtCoach4.Text = "";
            txtCoach5.Text = "";
            txtCoach6.Text = "";
            txtCoach7.Text = "";
            txtCoach8.Text = "";
            txtCoach9.Text = "";
            txtCoach10.Text = "";
            txtCoach11.Text = "";
            txtCoach12.Text = "";
            txtCoach13.Text = "";
            txtCoach14.Text = "";
            txtCoach15.Text = "";
            txtCoach16.Text = "";
            txtCoach17.Text = "";
            txtCoach18.Text = "";
            txtCoach19.Text = "";
            txtCoach20.Text = "";
            txtCoach21.Text = "";
            txtCoach22.Text = "";
            txtCoach23.Text = "";
            txtCoach24.Text = "";
            txtCoach25.Text = "";
            txtCoach26.Text = "";
            txtCoach27.Text = "";
            txtCoach28.Text = "";

            setWeekstable();


        }
        DataTable ExcelData = new DataTable();
        private void BtnExcelImport_Click(object sender, EventArgs e)
        {

            try
            {


                // Create an OpenFileDialog to select the Excel file
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog.Title = "Select an Excel File";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;

                        // Read the Excel file
                        ExcelData = ReadExcelFile(filePath);

                        // Display the data or use it as needed
                        MessageBox.Show($"{ExcelData.Rows.Count - 1} Trains read from the file.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveData();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private DataTable ReadExcelFile(string filePath)
        {
            DataTable dataTable = new DataTable();

            try
            {



                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Get the first worksheet

                    // Read column headers
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        dataTable.Columns.Add(worksheet.Cells[1, col].Text);
                    }

                    // Read rows
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            dataRow[col - 1] = worksheet.Cells[row, col].Text;
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            return dataTable;
        }



        private void SaveData()
        {
            try
            {
                TrainInformationDb.ClearTrainInformationTable();
                foreach (DataRow row in ExcelData.Rows)
                {
                    // Convert DataGridView to DataTable
                    //  DataTable runningTrainDirections = ConvertDataGridViewToDataTable(dataGridViewTrainInfo);

                    // Prepare parameters from DataRow

                    string trainNumber = CleanString(row["TRAINNO"].ToString());
                    string trainType = GetTrainType(CleanString(row["TrainType"].ToString()));
                    string category = Getcategory(CleanString(row["Category"].ToString()));
                    string source = CleanString(row["SOURCE"].ToString());
                    string destination = CleanString(row["DESTINATION"].ToString());
                    string via = CleanString(row["VIA"].ToString());
                    string englishName = CleanString(row["EnglishName"].ToString());
                    string hindiName = CleanString(row["HindiName"].ToString());
                    string regionalName = CleanString(row["RegionalName"].ToString().Trim());
                    string arrivalTime = CleanString(row["ARR"].ToString().Trim());
                    if (arrivalTime == "")
                    {
                        arrivalTime = "00:00";
                    }
                    else
                    {
                        arrivalTime = FormatValidTime(arrivalTime);
                    }

                    string departureTime = CleanString(row["DEP"].ToString().Trim());
                    if (departureTime == "")
                    {
                        departureTime = "00:00";
                    }
                    else
                    {
                        departureTime = FormatValidTime(departureTime);
                    }
                    string platform = GetPlatform(CleanString(row["Platform No"].ToString()));
                    string status = GetStatus(CleanString(row["Status"].ToString()));
                    string Days = CleanString(row["Days"].ToString());
                    // Split the CoachPostions string and convert to List<string>
                    string coachPositionsStr = CleanString(row["CoachPostions"].ToString());
                    List<string> coachPositionsList = coachPositionsStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                                      .Select(s => s.Trim()) // Remove any extra whitespace
                                                                      .ToList();


                    DataTable runningTrainDirections = CreateTrainDirectionDataTable(via, destination, Days);
                    // Call the InsertUpdateTrainDetails method
                    bool success = OnlineTrainsDao.InsertUpdateTrainDetails(
                        -1, // Assuming ID is auto-generated or not needed
                        trainNumber,
                        trainType,
                        category,
                        source,
                        destination,
                        via,
                        englishName,
                        hindiName,
                        regionalName,
                        arrivalTime,
                        departureTime,
                        platform,
                        status,
                        runningTrainDirections, // TrainDirections data
                        coachPositionsList // CoachPositions data as a List<string>
                    );

                    // Check the result and show appropriate message
                    if (success)
                    {
                        //  MessageBox.Show("Data Saved Successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to Insert Train!");
                    }


                }
                MessageBox.Show("Data Saved Successfully.");
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private string CleanString(string input)
        {
            // Check if the input is not null and contains the characters to be replaced
            if (string.IsNullOrEmpty(input) || (!input.Contains("\r") && !input.Contains("\n")))
            {
                return input;  // Return the original string if no replacements are needed
            }

            // Perform the replacement only if \r or \n exists
            return input.Replace("\r", "").Replace("\n", "");
        }

        static string FormatValidTime(string time)
        {
            if (TimeSpan.TryParseExact(time, "h\\:m", CultureInfo.InvariantCulture, out TimeSpan parsedTime) ||
                TimeSpan.TryParseExact(time, "hh\\:mm", CultureInfo.InvariantCulture, out parsedTime))
            {
                return parsedTime.ToString(@"hh\:mm");
            }

            throw new FormatException("Invalid time format.");
        }
        public static DataTable CreateTrainDirectionDataTable(string via, string destination, string daysString)
        {
            // Create a DataTable with the same structure as the TrainDirection table type
            DataTable trainDirectionTable = new DataTable();
            trainDirectionTable.Columns.Add("Checked", typeof(bool));
            trainDirectionTable.Columns.Add("Days", typeof(string));
            trainDirectionTable.Columns.Add("Via", typeof(string)); // Assuming Via will be empty or predefined
            trainDirectionTable.Columns.Add("Destination", typeof(string)); // Assuming Destination will be empty or predefined

            // Define the days of the week in a consistent casing (e.g., title case)
            string[] allDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            // Normalize the input string to handle case-insensitive comparison
            var normalizedDaysString = daysString.ToLower();
            var daysArray = allDays
                .Select(day => day.ToLower())
                .ToHashSet(); // Create a HashSet for fast lookup

            bool allTrue = string.IsNullOrEmpty(daysString); // Check if daysString is empty

            // Populate the DataTable
            foreach (var day in allDays)
            {
                DataRow row = trainDirectionTable.NewRow();
                bool isChecked = allTrue || daysArray.Contains(day.ToLower()); // Convert day to lowercase for comparison
                row["Checked"] = isChecked;
                row["Days"] = day;
                row["Via"] = via; // Set to null or default value if necessary
                row["Destination"] = destination; // Set to null or default value if necessary
                trainDirectionTable.Rows.Add(row);
            }

            return trainDirectionTable;
        }

        public static string GetTrainType(string trainType)
        {
            // Check if trainType is null or empty
            if (string.IsNullOrWhiteSpace(trainType))
            {
                return "Express";
            }

            return trainType;
        }

        public static string Getcategory(string category)
        {
            // Check if trainType is null or empty
            if (string.IsNullOrWhiteSpace(category))
            {
                return "Normal";
            }

            return category;
        }
        public static string GetPlatform(string pf)
        {
            // Check if trainType is null or empty
            if (string.IsNullOrWhiteSpace(pf))
            {
                return "1";
            }

            return pf;
        }

        public static string GetStatus(string status)
        {
            // Check if trainType is null or empty
            if (string.IsNullOrWhiteSpace(status))
            {
                return "UP";
            }

            return status;
        }

        private void lblTrainNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblHeadTrainInformation_Click(object sender, EventArgs e)
        {

        }

        private void cmbTrainType_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTrainType_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cmbCategory.SelectedItem.ToString();
            if (selectedItem == "Link")
            {
                cmbLinkTrain.Visible = true;
                lblLinkTrains.Visible = true;
                GetTrainsbycategeory();
                // LoadLinkedTrains();
            }
            else
            {
                lblLinkTrains.Visible = false;
                cmbLinkTrain.Visible = false;
            }

        }





        public void GetTrainsbycategeory()
        {

            DataTable dt = OnlineTrainsDao.GetLinkedTrainsbycategory();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string trainNo = (row["TrainNumber"].ToString());
                    if (rctbTrainNumber.Text.Trim() != trainNo)
                    {



                        DataTable Linkedtrainsdt = OnlineTrainsDao.GetLinkedTrainsDetailsbyTrainNo(trainNo);
                        if (Linkedtrainsdt.Rows.Count > 0)
                        {
                            foreach (DataRow Linkedtrainsrow in Linkedtrainsdt.Rows)
                            {

                                if (trainNo == Linkedtrainsrow["TrainNo"].ToString())
                                {
                                    string Linkedtrain = Linkedtrainsrow["LinkedTrainNo"].ToString();
                                    if (string.IsNullOrEmpty(Linkedtrain) || Linkedtrain == "0")
                                    {

                                        if (!cmbLinkTrain.Items.Contains(trainNo))
                                        {
                                            cmbLinkTrain.Items.Add(trainNo);
                                        }


                                    }

                                }

                            }
                        }
                    }


                    //        cmbLinkTrain.Items.Add("" + row["LinkTrain2"]);
                    //cmbLinkTrain.Items.Add("" + row["LinkTrain1"]);
                }
            }
        }

        public void LoadLinkedTrains()
        {

            DataTable dt = OnlineTrainsDao.GetLinkedTrains();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    cmbLinkTrain.Items.Add("" + row["LinkTrain2"]);
                    cmbLinkTrain.Items.Add("" + row["LinkTrain1"]);
                }
            }
        }

        private void CheckForDuplicates(object sender, EventArgs e)
        {
            try
            {

                TextBox currentTextBox = sender as TextBox;
                string newValue = currentTextBox.Text.ToString().ToUpper();
                // Check for duplicates within the TextBoxes in pnlCoachPositions only
                foreach (Control ctrl in pnlCoachPositions.Controls) // Iterate only through the pnlCoachPositions controls
                {
                    if (ctrl is TextBox textBox && textBox != currentTextBox)
                    {
                        // Check for duplicates (skip allowed duplicates)
                        if (textBox.Text.Trim().ToUpper() == newValue.Trim().ToUpper() &&
                            !BaseClass.allowedDuplicates.Contains(newValue.Trim().ToUpper())) // Only block non-allowed duplicates
                        {
                            // Duplicate found, block input
                            currentTextBox.Text = "";
                            currentTextBox.Focus();
                            MessageBox.Show("Coach alredy Existed");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {


                TextBox currentTextBox = sender as TextBox;

                // Allow backspace for corrections
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }

                // Check if the character is a letter or digit
                if (char.IsLetterOrDigit(e.KeyChar))
                {
                    // Convert to uppercase
                    string newValue = currentTextBox.Text + e.KeyChar.ToString().ToUpper();

                    // If the new value is in the allowed duplicates list, allow it without checking for duplicates
                    if (BaseClass.allowedDuplicates.Contains(newValue.Trim().ToUpper()))
                    {
                        e.KeyChar = char.ToUpper(e.KeyChar); // Convert to uppercase
                        return; // Allow the input
                    }



                    // Convert lowercase letters to uppercase
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else
                {
                    // Block non-letter/non-digit characters
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void txtCoach1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCoach4_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach5_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach6_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach7_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach8_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach9_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach10_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach11_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach12_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach13_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach14_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach15_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach16_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach17_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach18_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach19_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach20_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach21_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach22_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach23_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach24_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach25_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach26_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach27_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach28_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach28_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach27_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach26_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach25_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach24_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach23_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach22_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach21_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach20_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach19_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach18_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach17_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach16_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach15_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach14_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach13_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach12_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach11_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach10_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach9_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach8_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach7_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach6_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach5_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach4_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach3_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach2_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach1_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void cmbTrainType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rctbTrainNumber_TextChanged(object sender, EventArgs e)
        {
            cmbLinkTrain.Text = "";
        }

        private void txtDepatureTime_Leave(object sender, EventArgs e)
        {
            txtDepatureTime.Text = FormatValidTime(txtDepatureTime.Text);
            validateSametime();
        }

        private void rctbTrainNumber_Enter(object sender, EventArgs e)
        {

        }
    }
}
