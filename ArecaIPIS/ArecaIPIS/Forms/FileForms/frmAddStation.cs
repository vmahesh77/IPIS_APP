using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmAddStation : Form
    {
        private PaginationHelperClass paginationHelper;
        private DataTable reportData;
        private const string PlaceholderText = "Search here...";
        AddStationDb addstationDb = new AddStationDb();
        private int initialDataGridViewHeight;
        public frmAddStation()
        {
            InitializeComponent();

            reportData = new DataTable();
            initialDataGridViewHeight = dgvAddStation.Height;
        }
        private void dgvAddStation_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgvAddStation.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                {
                    e.ToolTipText = "Edit";
                }
            }

        }


        private frmHome parentForm;
        public frmAddStation(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void frmStationDeatils_Load(object sender, EventArgs e)
        {
            txtSearch.Text = PlaceholderText;
            txtSearch.ForeColor = Color.Gray;

            dgvAddStation.EnableHeadersVisualStyles = false;
            dgvAddStation.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dgvAddStation.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvAddStation.AllowUserToResizeRows = false;

            toolTip.SetToolTip(btnAddMessage, "Add New Station");
            dgvAddStation.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(dgvAddStation_CellToolTipTextNeeded);
            showData();
            InitializeControls();
        }
        public static int languagesCount = 0;
        public static void changeLanguesCount()
        {
            List<string> uniqueLanguages = new List<string>();

            foreach (var language in BaseClass.Languages)
            {
                string normalizedLanguage = language.Equals("Devanagari", StringComparison.OrdinalIgnoreCase) ? "Hindi" : language;

                if (!uniqueLanguages.Contains(normalizedLanguage, StringComparer.OrdinalIgnoreCase))
                {
                    uniqueLanguages.Add(normalizedLanguage);
                }
            }

            languagesCount = uniqueLanguages.Count;
        }

        private void UpdateDataGridView()
        {
            try
            {


                changeLanguesCount();
                DataTable currentPageData = paginationHelper.GetCurrentPageData();
                if (languagesCount > 2)
                {
                    dgvAddStation.AutoGenerateColumns = false;
                    dgvAddStation.Columns["StationCode"].DataPropertyName = "StationCode";
                    dgvAddStation.Columns["English"].DataPropertyName = "stationeng";
                    dgvAddStation.Columns["Hindi"].DataPropertyName = "stationhind";
                    dgvAddStation.Columns["RegionalLanguage"].DataPropertyName = "stationreg1";

                    if (!dgvAddStation.Columns.Contains("Pkey_stationnames"))
                    {
                        DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Pkey_stationnames",
                            HeaderText = "Pkey_stationnames",
                            Name = "Pkey_stationnames",
                            Visible = false
                        };
                        dgvAddStation.Columns.Add(pkeyColumn);
                    }
                    else
                    {
                        dgvAddStation.Columns["Pkey_stationnames"].DataPropertyName = "Pkey_stationnames";
                        dgvAddStation.Columns["Pkey_stationnames"].Visible = false;
                    }
                    dgvAddStation.DataSource = currentPageData;
                    dgvAddStation.AllowUserToAddRows = false;

                    int dataGridViewNewHeight;

                    // Adjust the height of the DataGridView
                    if (currentPageData.Rows.Count < visibleRowsCount)
                    {
                        dataGridViewNewHeight = (currentPageData.Rows.Count * dgvAddStation.RowTemplate.Height)
                                                + dgvAddStation.ColumnHeadersHeight
                                                + 2;
                    }
                    else
                    {
                        dataGridViewNewHeight = (visibleRowsCount * dgvAddStation.RowTemplate.Height)
                                                + dgvAddStation.ColumnHeadersHeight
                                                + 2;
                    }


                    dgvAddStation.Height = dataGridViewNewHeight;

                    paginationHelper.UpdatePaginationControls(pnlPagination, OnPageChanged);

                }
                else
                {
                    if (dgvAddStation.Columns.Contains("RegionalLanguage"))
                    {

                        var existingColumn = dgvAddStation.Columns["RegionalLanguage"];
                        existingColumn.DataPropertyName = "stationreg1";
                        existingColumn.Width = 50;
                        existingColumn.Visible = false;
                    }

                    dgvAddStation.AutoGenerateColumns = false;
                    dgvAddStation.Columns["StationCode"].DataPropertyName = "StationCode";
                    dgvAddStation.Columns["English"].DataPropertyName = "stationeng";
                    dgvAddStation.Columns["Hindi"].DataPropertyName = "stationhind";
                    //dgvAddStation.Columns["RegionalLanguage"].DataPropertyName = "stationreg1";

                    if (!dgvAddStation.Columns.Contains("Pkey_stationnames"))
                    {
                        DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Pkey_stationnames",
                            HeaderText = "Pkey_stationnames",
                            Name = "Pkey_stationnames",
                            Visible = false
                        };
                        dgvAddStation.Columns.Add(pkeyColumn);
                    }
                    else
                    {
                        dgvAddStation.Columns["Pkey_stationnames"].DataPropertyName = "Pkey_stationnames";
                        dgvAddStation.Columns["Pkey_stationnames"].Visible = false;
                    }
                    dgvAddStation.DataSource = currentPageData;
                    dgvAddStation.Columns["StationCode"].Width = 382;
                    dgvAddStation.Columns["English"].Width = 382;
                    dgvAddStation.Columns["Hindi"].Width = 384;
                    dgvAddStation.AllowUserToAddRows = false;

                    int dataGridViewNewHeight;

                    // Adjust the height of the DataGridView
                    if (currentPageData.Rows.Count < visibleRowsCount)
                    {
                        dataGridViewNewHeight = (currentPageData.Rows.Count * dgvAddStation.RowTemplate.Height)
                                                + dgvAddStation.ColumnHeadersHeight
                                                + 2;
                    }
                    else
                    {
                        dataGridViewNewHeight = (visibleRowsCount * dgvAddStation.RowTemplate.Height)
                                                + dgvAddStation.ColumnHeadersHeight
                                                + 2;
                    }


                    dgvAddStation.Height = dataGridViewNewHeight;

                    paginationHelper.UpdatePaginationControls(pnlPagination, OnPageChanged);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        private void OnPageChanged(int page)
        {
            paginationHelper.LoadDataForPage(page);
            UpdateDataGridView();

        }


        private void btnAddStations_Click(object sender, EventArgs e)
        {
            frmCreateStation crtStation = new frmCreateStation();
            crtStation.Show();

        }
        private readonly Dictionary<string, string> displayNameMap = new Dictionary<string, string>
    {
        {"StationCode","Station Code" },
        { "stationeng", "English" },
        { "stationhind", "Hindi" },
        { "stationreg1", "Regional Language" }
    };
        int visibleRowsCount = 0;
        public void showData()
        {
            try
            {


                DataTable stationName = addstationDb.GetAllStationNames();

                if (stationName != null)
                {
                    //dgvAddStation.AutoGenerateColumns = true;
                    reportData.Clear();
                    reportData.Columns.Clear();

                    dgvAddStation.Height = initialDataGridViewHeight;
                    reportData = stationName.Copy();
                    visibleRowsCount = (dgvAddStation.Height / dgvAddStation.RowTemplate.Height) - 1;
                    paginationHelper = new PaginationHelperClass(reportData, visibleRowsCount);
                    UpdateDataGridView();

                    lblNoDataToDisplay.Visible = false;
                    pnlPagination.Visible = true;
                }
                else
                {
                    lblNoDataToDisplay.Visible = true;
                    pnlPagination.Visible = false;

                    reportData = stationName.Copy();
                    foreach (DataColumn column in stationName.Columns)
                    {
                        dgvAddStation.Columns.Add(column.ColumnName, column.ColumnName);
                        dgvAddStation.Columns[column.ColumnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    dgvAddStation.DataSource = null;

                }

                chkFilter.Items.Clear();
                int c = 0;
                //foreach (DataColumn column in reportData.Columns)
                //{

                //    if (c > 0)
                //    {
                //        chkFilter.Items.Add(column.ColumnName);
                //    }

                //    c++;
                //}
                foreach (DataColumn column in reportData.Columns)
                {

                    if (c > 0 && c <= languagesCount + 1)
                    {
                        string displayName;
                        string cleanColumnName = column.ColumnName.Trim();

                        if (displayNameMap.TryGetValue(cleanColumnName, out displayName))
                        {
                            chkFilter.Items.Add(displayName);
                        }
                        else
                        {
                            chkFilter.Items.Add(column.ColumnName);
                        }
                    }
                    c++;
                }

                for (int i = 0; i < chkFilter.Items.Count; i++)
                {
                    chkFilter.SetItemChecked(i, true);
                    chkFilter.BackColor = Color.LightSalmon;
                }

                //else
                //{

                //    MessageBox.Show("Failed to retrieve Station Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        private bool validateEnglishStationName()
        {
            if (string.IsNullOrWhiteSpace(txtEnglishName.Text))
            {
                txtEnglishName.BackColor = Color.Red;
                return false;
            }
            else
            {
                txtEnglishName.BackColor = SystemColors.Window;
                return true;
            }
        }

        private bool validateHindiStationName()
        {
            if (string.IsNullOrWhiteSpace(txtHindiName.Text))
            {
                txtHindiName.BackColor = Color.Red;
                return false;
            }
            else
            {
                txtHindiName.BackColor = SystemColors.Window;
                return true;
            }
        }

        private bool validateRegionalStationName()
        {
            if (string.IsNullOrWhiteSpace(txtRegionalName.Text))
            {
                txtRegionalName.BackColor = Color.Red;
                return false;
            }
            else
            {
                txtRegionalName.BackColor = SystemColors.Window;
                return true;
            }
        }
        private bool validateStationCodeExist()
        {
            string stationCode = txtStationCode.Text.Trim();


            if (btnSave.Text.ToUpper().Trim() == "SAVE")
            {
                if (BaseClass.stationCodes.Contains(stationCode))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private bool validateStationCode()
        {
            string stationCode = txtStationCode.Text.Trim();
            int textLength = stationCode.Length;

            if (textLength < 2 || textLength > 4)
            {

                txtStationCode.BackColor = Color.Red;
                return false;
            }
            else
            {

                txtStationCode.BackColor = SystemColors.Window;
                txtStationCode.BorderStyle = BorderStyle.Fixed3D;

                return true;
            }
        }

        private bool ValidateFilePath()
        {

            string filePath = lblNoFileChoosen.Text.Trim();


            if (string.IsNullOrEmpty(filePath))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void txtStationCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                txtStationCode.BackColor = Color.Red;
                txtStationCode.BorderStyle = BorderStyle.FixedSingle;
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isStationCodeExist = validateStationCodeExist();
                if (!isStationCodeExist)
                {



                    if (languagesCount > 2)
                    {

                        bool isValidStationCode = validateStationCode();
                        bool isValidEnglishStationName = validateEnglishStationName();
                        bool isValidHindiStationName = validateHindiStationName();
                        bool isValidRegionalStationName = validateRegionalStationName();
                        bool isValidFilePath = ValidateFilePath();

                        if (isValidStationCode && isValidEnglishStationName && isValidHindiStationName && isValidRegionalStationName && isValidFilePath)
                        {
                            string stationCode = txtStationCode.Text;
                            string englishStationName = txtEnglishName.Text;
                            string hindiStationName = txtHindiName.Text;
                            string regionalStationName = txtRegionalName.Text;
                            string regional2 = "";
                            string filePath = lblNoFileChoosen.Text;
                            int pk = pkey;

                            DialogResult dResult = MessageBox.Show("Do you like to save/Update the Configuration?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dResult == DialogResult.No)
                            {
                                return;
                            }
                            bool result = addstationDb.InsertOrUpdateStationNames(pk, stationCode, englishStationName, hindiStationName, regionalStationName, regional2, filePath);

                            if (result)
                            {
                                ReportDb.InsertDatabaseModificationReportData("Station Updated  " + stationCode, "6");
                                MessageBox.Show("Data saved/updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                pnlCreateStation.Visible = false;
                                pnlSCreate.Visible = false;
                                showData();
                            }
                            else
                            {
                                MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Can not leave empty text", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtStationCode.Focus();
                        }
                    }
                    else
                    {
                        bool isValidStationCode = validateStationCode();
                        bool isValidEnglishStationName = validateEnglishStationName();
                        bool isValidHindiStationName = validateHindiStationName();
                        //bool isValidRegionalStationName = validateRegionalStationName();
                        bool isValidFilePath = ValidateFilePath();

                        if (isValidStationCode && isValidEnglishStationName && isValidHindiStationName && isValidFilePath)
                        {
                            int pk = pkey;
                            string stationCode = null;
                            string englishStationName = null;
                            string hindiStationName = null;
                            string regionalStationName = null;
                            string regional2 = null;
                            string filePath = null;
                            if (pk == 0)
                            {
                                stationCode = txtStationCode.Text;
                                englishStationName = txtEnglishName.Text;
                                hindiStationName = txtHindiName.Text;
                                regionalStationName = "";
                                regional2 = "";
                                filePath = lblNoFileChoosen.Text;
                            }
                            else
                            {
                                stationCode = txtStationCode.Text;
                                englishStationName = txtEnglishName.Text;
                                hindiStationName = txtHindiName.Text;
                                regionalStationName = regionalStation;
                                regional2 = "";
                                filePath = lblNoFileChoosen.Text;

                            }
                            DialogResult dResult = MessageBox.Show("Do you like to save/Update the Configuration?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dResult == DialogResult.No)
                            {
                                return;
                            }

                            bool result = addstationDb.InsertOrUpdateStationNames(pk, stationCode, englishStationName, hindiStationName, regionalStationName, regional2, filePath);

                            if (result)
                            {
                                MessageBox.Show("Data saved/updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                pnlCreateStation.Visible = false;
                                pnlSCreate.Visible = false;
                                showData();
                            }
                            else
                            {
                                MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Some data is not valid", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtStationCode.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Station Code Already Exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnAudioPath_Click(object sender, EventArgs e)
        {
            try
            {


                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Title = "Choose Audio File";
                openFileDialog.Filter = "Audio Files|*.wav;*.mp3;*.ogg|All Files|*.*";
                //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Multiselect = false;

                string initialDirectory = @"E:\Audio";


                if (Directory.Exists(initialDirectory))
                {
                    openFileDialog.InitialDirectory = initialDirectory;
                }
                else
                {

                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    lblNoFileChoosen.Text = filePath;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlCreateStation.Visible = false;
            pnlSCreate.Visible = false;
        }

        private void btnAddMessage_Click(object sender, EventArgs e)
        {
            pkey = 0;
            if (languagesCount > 2)
            {
                pnlCreateStation.Visible = true;
                pnlSCreate.Visible = true;
                txtStationCode.Text = "";
                txtStationCode.BackColor = SystemColors.Window;
                txtEnglishName.Text = "";
                txtEnglishName.BackColor = SystemColors.Window;
                txtHindiName.Text = "";
                txtHindiName.BackColor = SystemColors.Window;
                txtRegionalName.Text = "";
                txtRegionalName.BackColor = SystemColors.Window;
                lblNoFileChoosen.Text = "No File Chosen";

            }
            else
            {
                pnlCreateStation.Visible = true;
                pnlSCreate.Visible = true;
                txtStationCode.Text = "";
                txtStationCode.BackColor = SystemColors.Window;
                txtEnglishName.Text = "";
                txtEnglishName.BackColor = SystemColors.Window;
                txtHindiName.Text = "";
                txtHindiName.BackColor = SystemColors.Window;
                txtRegionalName.Text = "";
                txtRegionalName.BackColor = SystemColors.Window;
                txtRegionalName.Visible = false;
                lblRegional.Visible = false;
                lblNoFileChoosen.Text = "No File Chosen";
                btnRKeyboard.Visible = false;
            }

            lblCreateStation.Text = "Create Station";
            btnSave.Text = "Save";

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

        private void txtStationCode_TextChanged(object sender, EventArgs e)
        {
            string text = txtStationCode.Text;

            // Regex: allow only letters (any language) and spaces
            if (System.Text.RegularExpressions.Regex.IsMatch(text, @"[^ \p{L}]"))
            {
                txtStationCode.Text = System.Text.RegularExpressions.Regex.Replace(text, @"[^ \p{L}]", "");
                txtStationCode.SelectionStart = txtHindiName.Text.Length; // keep cursor at end
                txtStationCode.BackColor = Color.Red;
                txtStationCode.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                txtStationCode.BackColor = Color.White;
                txtStationCode.BorderStyle = BorderStyle.Fixed3D;
            }

            ChangeTextboxLetterSmallToCapital(txtStationCode);
            string stationCode = txtStationCode.Text.Trim();
            int textLength = stationCode.Length;

            if (textLength < 2 || textLength > 4)
            {

                txtStationCode.BackColor = Color.Red;
                txtStationCode.ForeColor = SystemColors.WindowText;
            }
            else
            {

                txtStationCode.BackColor = SystemColors.Window;
                txtStationCode.BorderStyle = BorderStyle.Fixed3D;
                txtStationCode.ForeColor = Color.Green;
            }
        }

        private void txtEnglishName_TextChanged(object sender, EventArgs e)
        {
            string text = txtEnglishName.Text;

            // Regex: allow only letters (any language) and spaces
            if (System.Text.RegularExpressions.Regex.IsMatch(text, @"[^ \p{L}]"))
            {
                txtEnglishName.Text = System.Text.RegularExpressions.Regex.Replace(text, @"[^ \p{L}]", "");
                txtEnglishName.SelectionStart = txtHindiName.Text.Length; // keep cursor at end
                txtEnglishName.BackColor = Color.Red;
                txtEnglishName.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                txtEnglishName.BackColor = Color.White;
                txtEnglishName.BorderStyle = BorderStyle.Fixed3D;
            }
            if (string.IsNullOrWhiteSpace(txtEnglishName.Text))
            {
                txtEnglishName.BackColor = Color.Red;
                txtEnglishName.ForeColor = SystemColors.WindowText;

            }
            else
            {
                txtEnglishName.BackColor = SystemColors.Window;
                txtEnglishName.BorderStyle = BorderStyle.Fixed3D;
                txtEnglishName.ForeColor = Color.Green;
            }
        }

        private void txtHindiName_TextChanged(object sender, EventArgs e)
        {
          
            string text = txtHindiName.Text;

            // Regex: allow only letters (any language) and spaces
            if (System.Text.RegularExpressions.Regex.IsMatch(text, @"[^ \p{L}]"))
            {
                txtHindiName.Text = System.Text.RegularExpressions.Regex.Replace(text, @"[^ \p{L}]", "");
                txtHindiName.SelectionStart = txtHindiName.Text.Length; // keep cursor at end
                txtHindiName.BackColor = Color.Red;
                txtHindiName.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                txtHindiName.BackColor = Color.White;
                txtHindiName.BorderStyle = BorderStyle.Fixed3D;
            }


            if (string.IsNullOrWhiteSpace(txtHindiName.Text))
            {
                txtHindiName.BackColor = Color.Red;
                txtHindiName.ForeColor = SystemColors.WindowText;

            }
            else
            {
                txtHindiName.BackColor = SystemColors.Window;
                txtHindiName.BorderStyle = BorderStyle.Fixed3D;
                txtHindiName.ForeColor = Color.Green;
            }
        }

        private void txtRegionalName_TextChanged(object sender, EventArgs e)
        {
            string text = txtRegionalName.Text;

            // Regex: allow only letters (any language) and spaces
            if (System.Text.RegularExpressions.Regex.IsMatch(text, @"[^ \p{L}]"))
            {
                txtRegionalName.Text = System.Text.RegularExpressions.Regex.Replace(text, @"[^ \p{L}]", "");
                txtRegionalName.SelectionStart = txtHindiName.Text.Length; // keep cursor at end
                txtRegionalName.BackColor = Color.Red;
                txtRegionalName.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                txtRegionalName.BackColor = Color.White;
                txtRegionalName.BorderStyle = BorderStyle.Fixed3D;
            }


            if (string.IsNullOrWhiteSpace(txtRegionalName.Text))
            {
                txtRegionalName.BackColor = Color.Red;
                txtRegionalName.ForeColor = SystemColors.WindowText;

            }
            else
            {
                txtRegionalName.BackColor = SystemColors.Window;
                txtRegionalName.BorderStyle = BorderStyle.Fixed3D;
                txtRegionalName.ForeColor = Color.Green;
            }
        }
        int pkey;
        string regionalStation;
        private void dgvAddStation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    int pkeyValue = Convert.ToInt32(dgvAddStation.Rows[e.RowIndex].Cells["Pkey_stationnames"].Value);
                    DataTable Message = addstationDb.GetStationNameByRow(pkeyValue);
                    if (languagesCount > 2)
                    {
                        if (Message != null && Message.Rows.Count > 0)
                        {
                            pkey = pkeyValue;
                            string SCode = Message.Rows[0]["StationCode"].ToString();
                            string english = Message.Rows[0]["stationeng"].ToString();
                            string Hindi = Message.Rows[0]["stationhind"].ToString();
                            string regional = Message.Rows[0]["stationreg1"].ToString();
                            string file = Message.Rows[0]["AudoFile"].ToString();



                            pnlCreateStation.Visible = true;
                            pnlSCreate.Visible = true;
                            lblCreateStation.Text = "Edit Station";
                            btnSave.Text = "Update";
                            txtStationCode.Text = SCode;
                            txtEnglishName.Text = english;
                            txtHindiName.Text = Hindi;
                            txtRegionalName.Text = regional;
                            lblNoFileChoosen.Text = file;

                        }
                        else
                        {
                            MessageBox.Show("No data retrieved from the database.");
                        }
                    }
                    else
                    {
                        if (Message != null && Message.Rows.Count > 0)
                        {
                            pkey = pkeyValue;
                            string SCode = Message.Rows[0]["StationCode"].ToString();
                            string english = Message.Rows[0]["stationeng"].ToString();
                            string Hindi = Message.Rows[0]["stationhind"].ToString();
                            regionalStation = Message.Rows[0]["stationreg1"].ToString();
                            string file = Message.Rows[0]["AudoFile"].ToString();



                            pnlCreateStation.Visible = true;
                            pnlSCreate.Visible = true;
                            lblCreateStation.Text = "Edit Station";
                            btnSave.Text = "    Update";
                            lblRegional.Visible = false;
                            txtRegionalName.Visible = false;
                            txtStationCode.Text = SCode;
                            txtEnglishName.Text = english;
                            txtHindiName.Text = Hindi;
                            //txtRegionalName.Text = regional;
                            lblNoFileChoosen.Text = file;

                        }
                        else
                        {
                            MessageBox.Show("No data retrieved from the database.");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Server.LogError(ex.Message);
                }

            }
        }
        public static bool chkvisible = true;
        private void btnDropdown_Click(object sender, EventArgs e)
        {
            if (chkvisible)
            {
                chkFilter.Visible = true;
                chkvisible = false;
            }
            else
            {
                chkFilter.Visible = false;
                chkvisible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnCross.Visible = true;
            btnSearch.Visible = false;
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            txtSearch.Text = PlaceholderText;
            txtSearch.ForeColor = Color.Gray;
            if (reportData.Rows.Count != 0)
            {
                paginationHelper = new PaginationHelperClass(reportData, 9);
                UpdateDataGridView();
                lblNoDataToDisplay.Visible = false;
                btnCross.Visible = false;
                btnSearch.Visible = true;
            }
            else
            {
                lblNoDataToDisplay.Visible = true;
                btnCross.Visible = false;
                btnSearch.Visible = true;
            }
        }

        private List<string> selectedColumns = new List<string>();
        private void PerformSearchAndFilter(string searchText)
        {
            DataTable filteredDataTable = reportData.Clone();

            string searchLowerCase = searchText.ToLower();

            foreach (DataRow row in reportData.Rows)
            {
                bool matchFound = false;

                foreach (string column in selectedColumns)
                {
                    string cellValue = row[column].ToString().ToLower();

                    if (cellValue.Contains(searchLowerCase))
                    {
                        matchFound = true;
                        break;
                    }
                }

                if (matchFound)
                {
                    filteredDataTable.ImportRow(row);

                }
            }
            paginationHelper = new PaginationHelperClass(filteredDataTable, visibleRowsCount);
            UpdateDataGridView();
        }

        private string previousSearchText = string.Empty;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            try
            {


                if (txtSearch.Text == PlaceholderText)
                {
                    return;
                }

                String searchText = txtSearch.Text.Trim();
                selectedColumns.Clear();

                //foreach (var item in chkFilter.CheckedItems)
                //{
                //    string columnName = item.ToString();

                //    if (!selectedColumns.Contains(columnName))
                //    {
                //        selectedColumns.Add(columnName);
                //    }
                //}
                foreach (var item in chkFilter.CheckedItems)
                {

                    foreach (var kvp in displayNameMap)
                    {
                        if (kvp.Value == item.ToString())
                        {
                            selectedColumns.Add(kvp.Key);
                            break;
                        }
                    }
                }

                if (searchText != previousSearchText)
                {
                    PerformSearchAndFilter(searchText);
                    previousSearchText = searchText;
                }

                bool matchFound = CheckIfDataMatchesSearch();
                lblNoDataToDisplay.Visible = !matchFound;

                btnCross.Visible = true;
                btnSearch.Visible = false;

                bool CheckIfDataMatchesSearch()
                {
                    if (string.IsNullOrWhiteSpace(searchText))
                    {
                        return true;
                    }
                    searchText = searchText.ToLower();

                    foreach (DataRow row in reportData.Rows)
                    {
                        foreach (string column in selectedColumns)
                        {
                            string cellValue = row[column].ToString().ToLower();

                            if (cellValue.Contains(searchText))
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == PlaceholderText)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = PlaceholderText;
                txtSearch.ForeColor = Color.Gray;
            }
        }



        private void btnHKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(550, 150, "Hindi");
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

            Keyboard(500, 50, localLanguage);
        }

        private void InitializeControls()
        {
            txtEnglishName.Enter += Control_Enter;
            txtHindiName.Enter += Control_Enter;
            txtRegionalName.Enter += Control_Enter;
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

        private void lblNoteDef2_Click(object sender, EventArgs e)
        {

        }

        private void txtEnglishName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
