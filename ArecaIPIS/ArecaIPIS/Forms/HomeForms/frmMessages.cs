using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Server_Classes;
using NAudio.Wave;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmMessages : Form
    {
        private static List<CancellationTokenSource> cancellationTokenSources = new List<CancellationTokenSource>();
        private PaginationHelperClass paginationHelper;
        private DataTable reportData;
        private const string PlaceholderText = "Search here...";
        MessagesDb messagesDb = new MessagesDb();
        private frmHome parentForm;
        private int initialDataGridViewHeight;
        public frmMessages(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;

        }

        public frmMessages()
        {
            InitializeComponent();
            reportData = new DataTable();
            initialDataGridViewHeight = dgvMessages.Height;
        }


        private void LoadMessageStatus()
        {
            try
            {


                DataTable messagesTable = messagesDb.GetAllMessageStatus();

                if (messagesTable.Columns.Count >= 2)
                {
                    DataRow selectRow = messagesTable.NewRow();
                    selectRow[0] = 0;
                    selectRow[1] = "-Select-";
                    messagesTable.Rows.InsertAt(selectRow, 0);

                    cmbStatus.DataSource = messagesTable;
                    cmbStatus.DisplayMember = messagesTable.Columns[1].ColumnName;
                    cmbStatus.ValueMember = messagesTable.Columns[0].ColumnName;
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
        private void LoadPlatformsNumber()
        {
            foreach (string value in BaseClass.Platforms)
            {
                cmbPlatformNo.Items.Add(value);
            }
            cmbPlatformNo.SelectedIndex = 0;

        }

        private void PauseButtonCheck()
        {
            if (AnnouncementController.PauseButtonStatus)
            {
                btnPause.Text = "Resume";

                btnPauseSpecial.Text = "Resume";
            }
            else
            {

                btnPause.Text = "Pause";
                btnPauseSpecial.Text = "Pause";
            }
        }

        private void frmMessages_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeControls();
                PauseButtonCheck();

                LoadPlatformsNumber();
                LoadMessageStatus();
                txtSearch.Text = PlaceholderText;
                txtSearch.ForeColor = Color.Gray;
                dgvMessages.EnableHeadersVisualStyles = false;
                dgvMessages.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                dgvMessages.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvMessages.AllowUserToResizeRows = false;

                foreach (DataGridViewColumn column in dgvMessages.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }

                cmbPosition.SelectedIndex = 0;

                toolTip.SetToolTip(btnAddMessage, "Add New Message");
                toolTip.SetToolTip(btnSendMessage, "Send Selected Messages");
                toolTip.SetToolTip(btnPlay, "Play");
                toolTip.SetToolTip(btnStop, "Stop");
                toolTip.SetToolTip(btnPause, "Pause");
                toolTip.SetToolTip(btnPlaySpecial, "Play");
                toolTip.SetToolTip(btnStopSpecial, "Stop");
                toolTip.SetToolTip(btnPauseSpecial, "Pause");

                dgvMessages.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(dGVMessages_CellToolTipTextNeeded);
                showData();

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void dGVMessages_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    if (dgvMessages.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        e.ToolTipText = "Edit";
                    }
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    if (dgvMessages.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        e.ToolTipText = "Select";
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void btnAddMessage_Click(object sender, EventArgs e)
        {

            try
            {


                pkey = 0;

                if (languagesCount > 2)
                {
                    pnlCreateMessage.Visible = true;
                    pnlCMessage.Visible = true;
                    pnlShowForm.Visible = false;

                    txtEnglish.Text = "";
                    txtHindi.Text = "";
                    txtRegional.Text = "";
                    lblFile.Text = "No file chosen";
                }
                else
                {
                    pnlCreateMessage.Visible = true;
                    pnlCMessage.Visible = true;
                    pnlShowForm.Visible = false;
                    txtRegional.Visible = false;
                    lblRegionalLanguage.Visible = false;
                    lblStar2.Visible = false;
                    btnRKeyboard.Visible = false;
                    pbCrossRegional.Visible = false;
                    lblValidationRegional.Visible = false;
                    txtEnglish.Text = "";
                    txtHindi.Text = "";
                    txtRegional.Text = "";
                    lblFile.Text = "No file chosen";
                }

                lblShowingAudio.Visible = false;
                lblFile.Visible = true;
                pbCross.Visible = false;
                pbTick.Visible = false;
                pbCrossHindi.Visible = false;
                pbTickHindi.Visible = false;
                pbCrossRegional.Visible = false;
                pbTickRegional.Visible = false;
                pbTickFile.Visible = false;
                lblValidationEnglish.Visible = false;
                lblValidationHindi.Visible = false;
                lblValidationRegional.Visible = false;
                lblShowingAudio.Visible = false;
                lblCreateMessage.Text = "Create Message";
                btnSave.Text = "    Save";
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        int pkey;
        string rMessage;
        string rMessage1;
        private void dGVMessages_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {


                    int pkeyValue = Convert.ToInt32(dgvMessages.Rows[e.RowIndex].Cells["Pkey_SpclMessages"].Value);
                    DataTable Message = messagesDb.GetMessagesByRow(pkeyValue);
                    if (languagesCount > 2)
                    {
                        if (Message != null && Message.Rows.Count > 0)
                        {
                            pkey = pkeyValue;
                            string englishMessage = Message.Rows[0]["Englishmsg"].ToString();
                            string nationalMessage = Message.Rows[0]["NationalMsg"].ToString();
                            string regionalMessage = Message.Rows[0]["RegionalMSg1"].ToString();
                            rMessage1 = Message.Rows[0]["RegionalMsg2"].ToString();
                            string file = Message.Rows[0]["AudioFilePath"].ToString();



                            pnlCreateMessage.Visible = true;
                            pnlCMessage.Visible = true;
                            lblCreateMessage.Text = "Edit Message";
                            btnSave.Text = "    Update";
                            txtEnglish.Text = englishMessage;
                            txtHindi.Text = nationalMessage;
                            txtRegional.Text = regionalMessage;
                            lblFile.Text = file;
                            pnlShowForm.Visible = false;
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
                            string englishMessage = Message.Rows[0]["Englishmsg"].ToString();
                            string nationalMessage = Message.Rows[0]["NationalMsg"].ToString();
                            rMessage = Message.Rows[0]["RegionalMSg1"].ToString();
                            rMessage1 = Message.Rows[0]["RegionalMsg2"].ToString();
                            string file = Message.Rows[0]["AudioFilePath"].ToString();



                            pnlCreateMessage.Visible = true;
                            pnlCMessage.Visible = true;
                            lblCreateMessage.Text = "Edit Message";
                            btnSave.Text = "    Update";
                            txtEnglish.Text = englishMessage;
                            txtHindi.Text = nationalMessage;
                            //txtRegional.Text = regionalMessage;
                            lblFile.Text = file;
                            pnlShowForm.Visible = false;
                            lblRegionalLanguage.Visible = false;
                            pbCrossRegional.Visible = false;
                            txtRegional.Visible = false;
                            btnRKeyboard.Visible = false;
                            lblStar2.Visible = false;
                            lblValidationRegional.Visible = false;
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

                dgvMessages.Columns["select"].DataPropertyName = "Checked";
                if (languagesCount > 2)
                {

                    dgvMessages.Columns["dgvEnglishColumn"].DataPropertyName = "Englishmsg";
                    dgvMessages.Columns["dgvHindiColumn"].DataPropertyName = "NationalMsg";

                    dgvMessages.Columns["dgvRegionalColumn"].DataPropertyName = "RegionalMsg1";


                    if (!dgvMessages.Columns.Contains("Pkey_SpclMessages"))
                    {
                        DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Pkey_SpclMessages",
                            HeaderText = "Pkey_SpclMessages",
                            Name = "Pkey_SpclMessages",
                            Visible = false
                        };
                        dgvMessages.Columns.Add(pkeyColumn);
                    }
                    else
                    {
                        dgvMessages.Columns["Pkey_SpclMessages"].DataPropertyName = "Pkey_SpclMessages";
                        dgvMessages.Columns["Pkey_SpclMessages"].Visible = false;
                    }

                    dgvMessages.DataSource = currentPageData;

                    dgvMessages.Columns["dgvEnglishColumn"].Width = 382;
                    dgvMessages.Columns["dgvHindiColumn"].Width = 375;
                    dgvMessages.Columns["dgvRegionalColumn"].Width = 378;

                    dgvMessages.AllowUserToAddRows = false;

                    int dataGridViewNewHeight;

                    // Adjust the height of the DataGridView
                    if (currentPageData.Rows.Count < visibleRowsCount)
                    {
                        dataGridViewNewHeight = (currentPageData.Rows.Count * dgvMessages.RowTemplate.Height)
                                                + dgvMessages.ColumnHeadersHeight
                                                + 2;
                    }
                    else
                    {
                        dataGridViewNewHeight = (visibleRowsCount * dgvMessages.RowTemplate.Height)
                                                + dgvMessages.ColumnHeadersHeight
                                                + 2;
                    }


                    dgvMessages.Height = dataGridViewNewHeight;


                    paginationHelper.UpdatePaginationControls(pnlPagination, OnPageChanged);
                }
                else
                {
                    if (dgvMessages.Columns.Contains("dgvRegionalColumn"))
                    {

                        var existingColumn = dgvMessages.Columns["dgvRegionalColumn"];
                        existingColumn.DataPropertyName = "RegionalMsg1";
                        existingColumn.Width = 50;
                        existingColumn.Visible = false;
                    }
                    dgvMessages.AutoGenerateColumns = false;


                    dgvMessages.Columns["dgvEnglishColumn"].DataPropertyName = "Englishmsg";
                    dgvMessages.Columns["dgvHindiColumn"].DataPropertyName = "NationalMsg";




                    if (!dgvMessages.Columns.Contains("Pkey_SpclMessages"))
                    {
                        DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Pkey_SpclMessages",
                            HeaderText = "Pkey_SpclMessages",
                            Name = "Pkey_SpclMessages",
                            Visible = false
                        };
                        dgvMessages.Columns.Add(pkeyColumn);
                    }
                    else
                    {
                        dgvMessages.Columns["Pkey_SpclMessages"].DataPropertyName = "Pkey_SpclMessages";
                        dgvMessages.Columns["Pkey_SpclMessages"].Visible = false;
                    }

                    dgvMessages.DataSource = currentPageData;

                    dgvMessages.Columns["dgvEnglishColumn"].Width = 568;
                    dgvMessages.Columns["dgvHindiColumn"].Width = 568;
                    //RemoveColumn("RegionalMsg1");


                    dgvMessages.AllowUserToAddRows = false;


                    int dataGridViewNewHeight;


                    if (currentPageData.Rows.Count < visibleRowsCount)
                    {
                        dataGridViewNewHeight = (currentPageData.Rows.Count * dgvMessages.RowTemplate.Height)
                                                + dgvMessages.ColumnHeadersHeight
                                                + 2;
                    }
                    else
                    {
                        dataGridViewNewHeight = (visibleRowsCount * dgvMessages.RowTemplate.Height)
                                                + dgvMessages.ColumnHeadersHeight
                                                + 2;
                    }


                    dgvMessages.Height = dataGridViewNewHeight;

                    paginationHelper.UpdatePaginationControls(pnlPagination, OnPageChanged);

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        //private void RemoveColumn(string columnName)
        //{
        //    if (dgvMessages.Columns.Contains(columnName))
        //    {
        //        dgvMessages.Columns.Remove(columnName);
        //    }
        //}
        private void OnPageChanged(int page)
        {
            DataTable specialMessages = messagesDb.GetSpecialMessagesData();
            reportData = specialMessages.Copy();
            paginationHelper = new PaginationHelperClass(reportData, visibleRowsCount);
            paginationHelper.LoadDataForPage(page);
            UpdateDataGridView();


        }
        private readonly Dictionary<string, string> displayNameMap = new Dictionary<string, string>
    {
        { "Englishmsg", "English" },
        { "NationalMsg", "Hindi" },
        { "RegionalMSg1", "Regional Language" }
    };

        int visibleRowsCount = 0;
        public void showData()
        {
            try
            {
                DataTable specialMessages = messagesDb.GetSpecialMessagesData();

                if (specialMessages != null && specialMessages.Rows.Count > 0)
                {
                    dgvMessages.AutoGenerateColumns = true;
                    reportData.Clear();
                    reportData.Columns.Clear();
                    dgvMessages.Height = initialDataGridViewHeight;

                    reportData = specialMessages.Copy();


                    visibleRowsCount = (dgvMessages.Height / dgvMessages.RowTemplate.Height) - 1;
                    paginationHelper = new PaginationHelperClass(reportData, visibleRowsCount);
                    UpdateDataGridView();

                    lblNoDataToDisplay.Visible = false;
                    pnlPagination.Visible = true;
                }
                else
                {
                    dgvMessages.Columns.Clear();

                    dgvMessages.AutoGenerateColumns = false;

                    reportData = specialMessages.Copy();

                    DataGridViewTextBoxColumn englishColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Englishmsg",
                        HeaderText = "English",
                        Name = "English",
                        Width = 370
                    };
                    dgvMessages.Columns.Add(englishColumn);

                    DataGridViewTextBoxColumn hindiColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "NationalMsg",
                        HeaderText = "Hindi",
                        Name = "Hindi",
                        Width = 370
                    };
                    dgvMessages.Columns.Add(hindiColumn);

                    DataGridViewTextBoxColumn regionalColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "RegionalMsg1",
                        HeaderText = "Regional Language",
                        Name = "RegionalLanguage",
                        Width = 370
                    };
                    dgvMessages.Columns.Add(regionalColumn);


                    if (!dgvMessages.Columns.Contains("Pkey_SpclMessages"))
                    {
                        DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Pkey_SpclMessages",
                            HeaderText = "Pkey_SpclMessages",
                            Name = "Pkey_SpclMessages",
                            Visible = false
                        };
                        dgvMessages.Columns.Add(pkeyColumn);
                    }
                    else
                    {

                        dgvMessages.Columns["Pkey_SpclMessages"].DataPropertyName = "Pkey_SpclMessages";
                        dgvMessages.Columns["Pkey_SpclMessages"].Visible = false;
                    }


                    dgvMessages.DataSource = reportData;


                    dgvMessages.AllowUserToAddRows = false;


                    if (reportData == null || reportData.Rows.Count == 0)
                    {
                        lblNoDataToDisplay.Visible = true;
                    }


                }

                chkFilter.Items.Clear();
                int c = 0;
                foreach (DataColumn column in reportData.Columns)
                {

                    if (c > 0 && c <= languagesCount)
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

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public static bool chkvisible = true;
        private void btndropdown_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnCross.Visible = true;
            btnSearch.Visible = false;
        }

        private void btnCross_Click(object sender, EventArgs e)
        {

            try
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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private List<string> selectedColumns = new List<string>();
        private void PerformSearchAndFilter(string searchText)
        {
            try
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
                paginationHelper = new PaginationHelperClass(filteredDataTable, 9);
                UpdateDataGridView();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

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

                string searchText = txtSearch.Text.Trim();
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
            try
            {


                if (txtSearch.Text == PlaceholderText)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = PlaceholderText;
                    txtSearch.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private void txtTrainNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;
            }
        }

        private void txtTrainNo_Leave(object sender, EventArgs e)
        {

            try
            {


                if (string.IsNullOrWhiteSpace(txtTrainNo.Text))
                {
                    //lblValidateTrainNo.Text = "Enter a train number.";
                    lblValidateTrainNo.Visible = true;
                    //txtTrainNo.Focus();
                }
                else
                {
                    lblValidateTrainNo.Text = "";
                    lblValidateTrainNo.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void dGVMessages_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {


                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    if (dgvMessages.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                        e.Value == null)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                        e.Graphics.DrawImage(Properties.Resources.edit, e.CellBounds.Location);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            openFileDialogs.Filter = "Media Files(*.wav; *.mp3)|*.wav;*.mp3";
            openFileDialogs.Multiselect = false;

            try
            {
                if (openFileDialogs.ShowDialog() == DialogResult.OK)
                {
                    lblFile.Text = "";
                    foreach (string file in openFileDialogs.FileNames)
                    {
                        string fileName = Path.GetFileName(file);
                        lblFile.Text += file;
                    }
                    lblShowingAudio.Visible = false;
                    pbTickFile.Visible = true;
                }
                else
                {
                    lblShowingAudio.Text = "Please choose an audio file.";
                    lblShowingAudio.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {


                pnlCreateMessage.Visible = false;
                pnlShowForm.Visible = true;
                txtEnglish.Text = "";
                txtHindi.Text = "";
                txtRegional.Text = "";
                lblFile.Text = "No file chosen";
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void txtEnglish_Leave(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtEnglish.Text))
                {
                    lblValidationEnglish.Text = "Please Enter Message in English.";
                    lblValidationEnglish.Visible = true;
                    pbCross.Visible = true;
                    pbTick.Visible = false;

                }
                else
                {
                    pbCross.Visible = false;
                    lblValidationEnglish.Text = "";
                    lblValidationEnglish.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void txtEnglish_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtEnglish.Text))
                {
                    lblValidationEnglish.Text = "Please Enter Message in English.";
                    lblValidationEnglish.Visible = true;
                    pbTick.Visible = false;
                    pbCross.Visible = true;

                }
                else
                {
                    lblValidationEnglish.Visible = false;
                    pbTick.Visible = true;
                    pbCross.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private void txtHindi_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtHindi.Text))
                {
                    lblValidationHindi.Text = "Please Enter Message in Hindi.";
                    lblValidationHindi.Visible = true;
                    pbCrossHindi.Visible = true;
                    pbTickHindi.Visible = false;

                }
                else
                {
                    pbCrossHindi.Visible = false;
                    lblValidationHindi.Text = "";
                    lblValidationHindi.Visible = false;
                    pbTickHindi.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void txtHindi_Leave(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtHindi.Text))
                {
                    lblValidationHindi.Text = "Please Enter Message in Hindi.";
                    lblValidationHindi.Visible = true;
                    pbCrossHindi.Visible = true;
                    pbTickHindi.Visible = false;

                }
                else
                {
                    pbCrossHindi.Visible = false;
                    lblValidationHindi.Text = "";
                    lblValidationHindi.Visible = false;
                    pbTickHindi.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void txtRegional_Enter(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtRegional.Text))
                {
                    lblValidationRegional.Text = "Please Enter Message in Regional Language.";
                    lblValidationRegional.Visible = true;
                    pbCrossRegional.Visible = true;
                    pbTickRegional.Visible = false;

                }
                else
                {
                    pbTickRegional.Visible = true;
                    pbCrossRegional.Visible = false;
                    lblValidationRegional.Text = "";
                    lblValidationRegional.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void txtRegional_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtRegional.Text))
                {
                    lblValidationRegional.Text = "Please Enter Message in Regional Language.";
                    lblValidationRegional.Visible = true;
                    pbTickRegional.Visible = false;
                    pbCrossRegional.Visible = true;

                }
                else
                {
                    lblValidationRegional.Visible = false;
                    pbTickRegional.Visible = true;
                    pbCrossRegional.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {



                if (languagesCount > 2)
                {
                    int pKey_SpecialMessage = pkey;
                    string englishMsg;
                    string nationalMsg;
                    string regionalMsg1;
                    string regionalMsg2;
                    string audioFilePath;
                    if (pKey_SpecialMessage == 0)
                    {
                        englishMsg = txtEnglish.Text;
                        nationalMsg = txtHindi.Text;
                        regionalMsg1 = txtRegional.Text;
                        regionalMsg2 = txtEnglish.Text;
                        audioFilePath = lblFile.Text;
                    }
                    else
                    {
                        englishMsg = txtEnglish.Text;
                        nationalMsg = txtHindi.Text;
                        regionalMsg1 = txtRegional.Text;
                        regionalMsg2 = rMessage1;
                        audioFilePath = lblFile.Text;
                    }




                    if (!string.IsNullOrWhiteSpace(englishMsg) &&
                        !string.IsNullOrWhiteSpace(nationalMsg) &&
                        !string.IsNullOrWhiteSpace(regionalMsg1) &&
                        !string.IsNullOrWhiteSpace(audioFilePath))
                    {
                        if (!File.Exists(audioFilePath) || !IsValidAudioFile(audioFilePath))
                        {
                            lblShowingAudio.Text = "Please choose an audio file.";
                            lblShowingAudio.Visible = true;
                            return;
                        }

                        DialogResult dResult = MessageBox.Show("Do you like to save/Update the save Configuration?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dResult == DialogResult.No)
                        {
                            return;
                        }


                        bool b = messagesDb.InsertOrUpdateMessage(pKey_SpecialMessage, englishMsg, nationalMsg, regionalMsg1, regionalMsg2, audioFilePath);

                        if (b)
                        {
                            MessageBox.Show("Data saved/update successfully");
                            pnlCreateMessage.Visible = false;
                            pnlShowForm.Visible = true;
                            txtEnglish.Text = "";
                            txtHindi.Text = "";
                            txtRegional.Text = "";
                            lblFile.Text = "No file chosen";
                            showData();

                        }
                        else
                        {
                            MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(englishMsg))
                        {
                            lblValidationEnglish.Text = "Please Enter Message in English.";
                            lblValidationEnglish.Visible = true;
                            pbCross.Visible = true;
                            txtEnglish.Focus();
                        }
                        if (string.IsNullOrWhiteSpace(nationalMsg))
                        {
                            lblValidationHindi.Text = "Please Enter Message in Hindi.";
                            lblValidationHindi.Visible = true;
                            pbCrossHindi.Visible = true;
                        }
                        if (string.IsNullOrWhiteSpace(regionalMsg1) && languagesCount > 2)
                        {
                            lblValidationRegional.Text = "Please Enter Message in Regional Language.";
                            lblValidationRegional.Visible = true;
                            pbCrossRegional.Visible = true;
                        }
                    }
                }
                else
                {
                    int pKey_SpecialMessage = pkey;
                    string englishMsg;
                    string nationalMsg;
                    string regionalMsg1;
                    string regionalMsg2;
                    string audioFilePath;
                    if (pKey_SpecialMessage == 0)
                    {
                        englishMsg = txtEnglish.Text;
                        nationalMsg = txtHindi.Text;
                        regionalMsg1 = "";
                        regionalMsg2 = txtEnglish.Text;
                        audioFilePath = lblFile.Text;
                    }
                    else
                    {
                        englishMsg = txtEnglish.Text;
                        nationalMsg = txtHindi.Text;
                        regionalMsg1 = rMessage;
                        regionalMsg2 = rMessage1;
                        audioFilePath = lblFile.Text;
                    }

                    if (!string.IsNullOrWhiteSpace(englishMsg) &&
                        !string.IsNullOrWhiteSpace(nationalMsg) &&
                        !string.IsNullOrWhiteSpace(audioFilePath))
                    {
                        if (!File.Exists(audioFilePath) || !IsValidAudioFile(audioFilePath))
                        {
                            lblShowingAudio.Text = "Please choose an audio file.";
                            lblShowingAudio.Visible = true;
                            return;
                        }
                        DialogResult dResult = MessageBox.Show("Do you like to save/Update the Configuration?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dResult == DialogResult.No)
                        {
                            return;
                        }

                        bool b = messagesDb.InsertOrUpdateMessage(pKey_SpecialMessage, englishMsg, nationalMsg, regionalMsg1, regionalMsg2, audioFilePath);

                        if (b)
                        {
                            ReportDb.InsertDatabaseModificationReportData("Message Updated" + englishMsg, "5");
                            MessageBox.Show("Data saved/update successfully");
                            pnlCreateMessage.Visible = false;
                            pnlShowForm.Visible = true;
                            txtEnglish.Text = "";
                            txtHindi.Text = "";
                            txtRegional.Text = "";
                            lblFile.Text = "No file chosen";
                            showData();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(englishMsg))
                        {
                            lblValidationEnglish.Text = "Please Enter Message in English.";
                            lblValidationEnglish.Visible = true;
                            pbCross.Visible = true;
                            txtEnglish.Focus();
                        }
                        if (string.IsNullOrWhiteSpace(nationalMsg))
                        {
                            lblValidationHindi.Text = "Please Enter Message in Hindi.";
                            lblValidationHindi.Visible = true;
                            pbCrossHindi.Visible = true;
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidAudioFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return !string.IsNullOrEmpty(extension) && (extension.Equals(".wav", StringComparison.OrdinalIgnoreCase) || extension.Equals(".mp3", StringComparison.OrdinalIgnoreCase));
        }

        private void lblFile_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lblFile.Text) || !IsValidAudioFile(lblFile.Text))
                {
                    lblShowingAudio.Text = "Please choose an audio file.";
                    lblShowingAudio.Visible = true;

                }
                else
                {
                    lblShowingAudio.Visible = false;
                    pbTickFile.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }





        private static ConcurrentDictionary<string, WaveOutEvent> activePlayers = new ConcurrentDictionary<string, WaveOutEvent>();
        private ConcurrentDictionary<string, AudioFileReader> activeAudioFiles = new ConcurrentDictionary<string, AudioFileReader>();
        private ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);
        private static bool isPaused = false;
        private List<string> audioPaths = new List<string>();

        public static TaskCompletionSource<bool> pauseCompletionSource = new TaskCompletionSource<bool>();


        //----------------------------code start here-----------------------------------------    



        public static void PlayMessages()
        {

        }
        private async void btnPlay_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dResult = MessageBox.Show("Do you want to play the audio?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dResult == DialogResult.No)
                {
                    return;
                }


                int nupMessageValue = (int)nupMessage.Value;
                List<string> selectedPrimaryKeys = new List<string>();

                //foreach (DataGridViewRow row in dgvMessages.Rows)
                //{
                //    DataGridViewCheckBoxCell chk = row.Cells[1] as DataGridViewCheckBoxCell;

                //    if (chk != null && Convert.ToBoolean(chk.Value))
                //    {
                //        string primaryKey = row.Cells["Pkey_SpclMessages"].Value.ToString();
                //        selectedPrimaryKeys.Add(primaryKey);
                //    }
                //}
                DataTable specialMessages = messagesDb.GetSpecialMessagesData();
                foreach (DataRow row in specialMessages.Rows)
                {
                    if (row["Checked"].ToString() != null && row["Checked"].ToString() != "")
                    {
                        bool status = Convert.ToBoolean(row["Checked"].ToString());
                        if (status)
                        {
                            string primaryKey = row["Pkey_SpclMessages"].ToString();
                            selectedPrimaryKeys.Add(primaryKey);
                        }
                    }
                }
                if (selectedPrimaryKeys.Count == 0)
                {
                    MessageBox.Show("No items selected to play.");
                    return;
                }

                string primaryKeyString = string.Join(",", selectedPrimaryKeys);
                DataTable resultMessage = messagesDb.CallGetSplMessages1(primaryKeyString, nupMessageValue);

                if (resultMessage != null && resultMessage.Rows.Count > 0)
                {
                    audioPaths.Clear();
                    foreach (DataRow row in resultMessage.Rows)
                    {
                        foreach (DataColumn col in resultMessage.Columns)
                        {
                            if (col.DataType == typeof(string))
                            {
                                string stringValue = row.Field<string>(col);

                                DataTable languageSequence = CommonSettingsDb.GetAnnouncement();


                                string originalPath = stringValue;

                                if (Directory.Exists("E:\\Audio\\AudioMessages\\ENGLISH") && Directory.Exists("E:\\Audio\\AudioMessages\\HINDI") && Directory.Exists("E:\\Audio\\AudioMessages\\LOCAL"))
                                {
                                    foreach (DataRow lang in languageSequence.Rows)
                                    {


                                        if (lang["LanguageName"].ToString() == "English")
                                        {
                                            string eng = originalPath;
                                            eng = eng.Insert(originalPath.LastIndexOf("\\") + 1, "ENGLISH\\");
                                            audioPaths.Add(eng);
                                        }
                                        else if (lang["LanguageName"].ToString() == "Hindi")
                                        {
                                            string hin = originalPath;
                                            hin = hin.Insert(originalPath.LastIndexOf("\\") + 1, "HINDI\\");
                                            audioPaths.Add(hin);
                                        }
                                        else
                                        {
                                            string reg = originalPath;
                                            reg = reg.Insert(originalPath.LastIndexOf("\\") + 1, "LOCAL\\");
                                            audioPaths.Add(reg);
                                        }


                                    }
                                }
                                else
                                {
                                    audioPaths.Add(originalPath);
                                }

                            }
                        }
                    }



                    if (AnnouncementController.OtherAudioPlaying)
                    {
                        MessageBox.Show("Other Audio is Playing");


                    }
                    else
                    {

                        AnnouncementController.cts = new CancellationTokenSource();
                        AnnouncementController.OtherAudioPlaying = true;
                        //   await AnnouncementController.PlayAudioSet(audioPaths, nupMessageValue, AnnouncementController.cts.Token);
                        AudioManager.PlayAudioSet(audioPaths, nupMessageValue, AnnouncementController.cts.Token);
                    }
                }
                else
                {
                    MessageBox.Show("No data returned from the database");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        //private async void btnPlay_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        DialogResult dResult = MessageBox.Show("Do you want to play the audio?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //        if (dResult == DialogResult.No)
        //        {
        //            return;
        //        }


        //        int nupMessageValue = (int)nupMessage.Value;
        //        List<string> selectedPrimaryKeys = new List<string>();

        //        foreach (DataGridViewRow row in dgvMessages.Rows)
        //        {
        //            DataGridViewCheckBoxCell chk = row.Cells[1] as DataGridViewCheckBoxCell;

        //            if (chk != null && Convert.ToBoolean(chk.Value))
        //            {
        //                string primaryKey = row.Cells["Pkey_SpclMessages"].Value.ToString();
        //                selectedPrimaryKeys.Add(primaryKey);
        //            }
        //        }

        //        if (selectedPrimaryKeys.Count == 0)
        //        {
        //            MessageBox.Show("No items selected to play.");
        //            return;
        //        }

        //        string primaryKeyString = string.Join(",", selectedPrimaryKeys);
        //        DataTable resultMessage = messagesDb.CallGetSplMessages1(primaryKeyString, nupMessageValue);

        //        if (resultMessage != null && resultMessage.Rows.Count > 0)
        //        {
        //            audioPaths.Clear();
        //            foreach (DataRow row in resultMessage.Rows)
        //            {
        //                foreach (DataColumn col in resultMessage.Columns)
        //                {
        //                    if (col.DataType == typeof(string))
        //                    {
        //                        string stringValue = row.Field<string>(col);
        //                        audioPaths.Add(stringValue);


        //                    }
        //                }
        //            }



        //            if (AnnouncementController.OtherAudioPlaying)
        //            {
        //                MessageBox.Show("Other Audio is Playing");


        //            }
        //            else
        //            {

        //                AnnouncementController.cts = new CancellationTokenSource();
        //                AnnouncementController.OtherAudioPlaying = true;
        //                await AnnouncementController.PlayAudioSet(audioPaths, nupMessageValue, AnnouncementController.cts.Token);

        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("No data returned from the database");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Server.LogError(ex.Message);
        //    }

        //}

        public async Task PlayAudioSet(List<string> audioPaths, int playCount, CancellationToken token)
        {
            try
            {
                int completedAudios = 0;
                for (int count = 0; count < playCount; count++)
                {
                    foreach (string filePath in audioPaths)
                    {
                        token.ThrowIfCancellationRequested();

                        if (File.Exists(filePath))
                        {
                            await PlaySingleAudio(filePath, token);
                            completedAudios++;
                        }
                        else
                        {
                            //HandleAudioErrors(filePath);
                        }
                    }
                    await Task.Delay(100, token);
                }

                if (completedAudios == audioPaths.Count * playCount)
                {
                    UpdateAudioPlayStatus("Completed");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public async Task PlaySingleAudio(string filePath, CancellationToken token)
        {
            try
            {
                using (var audioFile = new AudioFileReader(filePath))
                {
                    var player = new WaveOutEvent();
                    activePlayers[filePath] = player;

                    player.Init(audioFile);
                    player.Play();

                    while (player.PlaybackState == PlaybackState.Playing)
                    {
                        await Task.Delay(100, token);
                        if (isPaused)
                        {
                            await pauseCompletionSource.Task;
                        }
                        token.ThrowIfCancellationRequested();
                    }
                    player.PlaybackStopped += (sender, args) =>
                    {
                        activePlayers.TryRemove(filePath, out _);
                    };
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }




        private void btnPause_Click(object sender, EventArgs e)
        {
            if (AnnouncementController.OtherAudioPlaying)
            {
                AnnouncementController.UpdateStatus("PAUSE");
                // UpdateStatus("PAUSE", btnPause);
                AnnouncementController.CheckPauseButtonClick();
                PauseButtonCheck();
            }
        }

        public void PauseAudio(string alertValue, Button clickedButton)
        {
            try
            {


                if (alertValue == "PAUSE")
                {

                    ResumeAllAudio();
                    //btnPause.Text = "Pause";
                    if (clickedButton != null)
                    {
                        string lowerCaseAlertValue = alertValue.ToLower();

                        string formattedAlertValue = char.ToUpper(lowerCaseAlertValue[0]) + lowerCaseAlertValue.Substring(1);

                        clickedButton.Text = formattedAlertValue;
                        clickedButton.TextAlign = ContentAlignment.MiddleCenter;
                    }
                }
                else
                {

                    PauseAllAudio();
                    //btnPause.Text = " Resume";
                    if (clickedButton != null)
                    {
                        string lowerCaseAlertValue = alertValue.ToLower();

                        string formattedAlertValue = char.ToUpper(lowerCaseAlertValue[0]) + lowerCaseAlertValue.Substring(1);

                        clickedButton.Text = formattedAlertValue;
                        clickedButton.TextAlign = ContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public void PauseAllAudio()
        {
            try
            {


                isPaused = true;
                foreach (var player in activePlayers.Values)
                {
                    if (player.PlaybackState == PlaybackState.Playing)
                    {
                        player.Pause();
                    }
                }
                pauseCompletionSource = new TaskCompletionSource<bool>();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public void ResumeAllAudio()
        {
            try
            {


                isPaused = false;
                foreach (var player in activePlayers.Values)
                {
                    if (player.PlaybackState == PlaybackState.Paused)
                    {
                        player.Play();
                    }
                }
                pauseCompletionSource.SetResult(true);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                AnnouncementController.OtherAudioPlaying = false;

                DialogResult dResult = MessageBox.Show("Do you want to stop the play?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dResult == DialogResult.No)
                {
                    return;
                }
                //UpdateStatus("STOP", btnStop);
                //UpdateAudioPlayStatus("Completed");
                AnnouncementController.UpdateStatus("STOP");
                AnnouncementController.UpdateAudioPlayStatus("Completed");

                btnPause.Text = "Pause";
                btnPause.TextAlign = ContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        private static void HandleAudioErrors(string filePath)
        {
            MessageBox.Show($"'{filePath}'", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        //-----------------------code end here------------------------------------------------

        private void UpdateAudioPlayStatus(string action)
        {
            try
            {
                bool successAction = MessagesDb.UpdateAudioPlayStatus(action);

                if (successAction)
                {
                    //MessageBox.Show("Audio play status updated successfully.");

                }
                else
                {
                    MessageBox.Show("No rows affected. Audio play status may not have been updated.");

                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }





        private void txtCoachId_TextChanged(object sender, EventArgs e)
        {


        }

        private void Validation()
        {

            try
            {


                string coachId = txtCoachId.Text.Trim();
                string trainNum = txtTrainNo.Text.Trim();

                if (!string.IsNullOrEmpty(coachId) && !string.IsNullOrEmpty(trainNum))
                {
                    DataTable coach = messagesDb.ValidateCoachId(trainNum, coachId);

                    if (coach != null && coach.Rows.Count > 0)
                    {
                        string coachePos = coach.Rows[0]["CoachPosition"].ToString();
                        txtCoachId.Text = coachePos;
                        txtCoachId.BackColor = Color.LightGreen;
                        lblValidateCoachId.Visible = false;
                    }
                    else
                    {
                        lblValidateCoachId.Text = "Enter correct Coach Id";
                        lblValidateCoachId.Visible = true;
                        txtCoachId.BackColor = Color.White;
                        //MessageBox.Show("Enter correct Coach Id");
                        txtCoachId.Text = "";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(coachId))
                    //{
                    //    MessageBox.Show("Please enter train number");
                    //    txtCoachId.Text = "";
                    //}
                    //else
                    {
                        lblValidateCoachId.Text = "Coach Id cannot be empty";
                        txtCoachId.BackColor = Color.White;
                        lblValidateCoachId.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }




        private void txtCoachId_Validated(object sender, EventArgs e)
        {
            Validation();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (cmbPosition.Items.Count > 0)
                {
                    if (cmbStatus.SelectedIndex >= 0 && cmbStatus.SelectedIndex <= 4)
                    {
                        cmbPosition.SelectedIndex = 0;
                        cmbPosition.Enabled = false;
                    }
                    else if (cmbStatus.SelectedIndex == 5)
                    {
                        cmbPosition.Enabled = true;
                        if (cmbPosition.Items.Count > 0)
                        {
                            cmbPosition.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void txtTrainNo_Validated(object sender, EventArgs e)
        {
            try
            {


                string trainNum = txtTrainNo.Text;

                if (string.IsNullOrWhiteSpace(trainNum))
                {
                    //lblValidateTrainNo.Text = "Train No cannot be empty";
                    lblValidateTrainNo.Visible = true;
                    txtTrainNo.BackColor = SystemColors.Window;
                    cmbPlatformNo.Items.Clear();
                    LoadPlatformsNumber();
                    return;
                }

                DataTable trainNo = messagesDb.ValidateTrainNo();

                bool trainExists = false;

                foreach (DataRow row in trainNo.Rows)
                {
                    string existingTrainNum = row["TrainNo"].ToString();
                    string platformNo = row["PlatformName"].ToString();
                    if (existingTrainNum == trainNum)
                    {
                        trainExists = true;
                        cmbPlatformNo.Items.Clear();
                        cmbPlatformNo.Items.Add(platformNo);
                        cmbPlatformNo.SelectedIndex = 0;
                        break;
                    }

                }

                if (trainExists)
                {
                    txtTrainNo.BackColor = Color.LightGreen;

                }
                else
                {
                    //MessageBox.Show("No train available with number: " + trainNum);
                    txtTrainNo.BackColor = SystemColors.Window;
                    lblValidateTrainNo.Text = "Train No is not available";
                    lblValidateTrainNo.Visible = true;
                    cmbPlatformNo.Items.Clear();
                    LoadPlatformsNumber();
                    txtTrainNo.Text = "";
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private async void btnPlaySpecial_Click(object sender, EventArgs e)
        {
            try
            {



                //btnPauseSpecial.Text = "Pause";
                //btnPauseSpecial.TextAlign = ContentAlignment.MiddleCenter;
                string TrainNum = txtTrainNo.Text;
                string Pfno = cmbPlatformNo.SelectedItem.ToString();
                string coachid = txtCoachId.Text;
                string Status = cmbStatus.SelectedIndex.ToString();
                if (string.IsNullOrWhiteSpace(TrainNum) || string.IsNullOrWhiteSpace(Pfno) || string.IsNullOrWhiteSpace(coachid) || string.IsNullOrWhiteSpace(Status))
                {
                    MessageBox.Show("Train Number, Platform Number, Coach ID, and Status must be provided.");
                    lblValidateTrainNo.Visible = true;
                    lblValidateCoachId.Visible = true;
                    txtTrainNo.Focus();
                    return;
                }
                DialogResult dResult = MessageBox.Show("Do you want to play the audio?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dResult == DialogResult.No)
                {
                    return;
                }

                if (AnnouncementController.OtherAudioPlaying)
                {
                    MessageBox.Show("Other Audio is Playing");

                }
                else
                {

                    AnnouncementController.OtherAudioPlaying = true;
                    int posvar;
                    switch (cmbPosition.SelectedIndex)
                    {
                        //case -1:
                        //    posvar = 0;
                        //    break;
                        case 0:
                            posvar = 0;
                            break;
                        case 1:
                            posvar = 1;
                            break;
                        case 2:
                            posvar = 2;
                            break;
                        default:
                            posvar = 0;
                            break;
                    }

                    string Position = posvar.ToString();

                    try
                    {
                        DataTable UpdatedFile = new DataTable();
                        UpdatedFile.Columns.Add("LanguageID", typeof(int));
                        UpdatedFile.Columns.Add("Sequence", typeof(int));
                        UpdatedFile.Columns.Add("AudioFile", typeof(string));

                        var data = messagesDb.PlayTrainInfo(Convert.ToInt32(Status), Convert.ToInt32(Position));

                        foreach (DataRow row in data.Rows)
                        {
                            var fileName = row["MessageName"].ToString();
                            var LanguageID = row["LanguageId"].ToString();
                            var sequence = row["sequence"].ToString();
                            var AudioPath = row["MessagePath"].ToString();

                            string TrainNamepath = "";
                            string[] TrainNoAudiopath = new string[6];

                            var Traintype = messagesDb.GetTrainUpDownStatus(TrainNum);

                            if (fileName.ToLower() == "train no.")
                            {
                                if (LanguageID == "1")
                                {
                                    //pathstr = "E:\\Audio\\English\\Numbers\\";
                                    AudioPath = "E:\\Audio\\English\\Numbers\\";
                                    TrainNamepath = "E:\\Audio\\English\\TrainNames\\";
                                }
                                else if (LanguageID == "2")
                                {
                                    //pathstr = "E:\\Audio\\Hindi\\Numbers\\";
                                    AudioPath = "E:\\Audio\\Hindi\\Numbers\\";
                                    TrainNamepath = "E:\\Audio\\Hindi\\TrainNames\\";
                                }
                                else if (LanguageID == "3")
                                {
                                    //pathstr = "E:\\Audio\\Local\\NUMBERS\\";
                                    AudioPath = "E:\\Audio\\Local\\Numbers\\";
                                    TrainNamepath = "E:\\Audio\\Local\\TrainNames\\";
                                }


                                for (int j = 0; j < TrainNum.Length; j++)
                                {
                                    //TrainNoAudiopath[j] = pathstr + TrainNo[j] + ".wav";
                                    TrainNoAudiopath[j] = AudioPath + TrainNum[j] + ".wav";

                                }
                                TrainNoAudiopath[5] = TrainNamepath + TrainNum + ".wav";//AudioPath.Replace("{0}", TrainNum);
                                AudioPath = TrainNamepath + TrainNum + ".wav"; //AudioPath.Replace("{0}", TrainNum);
                            }
                            if (fileName.ToLower() == "platfrom no.")
                            {
                                AudioPath = AudioPath.Replace("{0}", Pfno);
                            }
                            if (fileName.ToLower() == "coaches")
                            {
                                AudioPath = AudioPath.Replace("{0}", coachid);
                            }
                            if (fileName.ToLower() == "train number")
                            {


                                if (LanguageID == "1")
                                {
                                    //pathstr = "E:\\Audio\\English\\Numbers\\";
                                    AudioPath = "E:\\Audio\\English\\Numbers\\";
                                }
                                else if (LanguageID == "2")
                                {
                                    //pathstr = "E:\\Audio\\Hindi\\Numbers\\";
                                    AudioPath = "E:\\Audio\\Hindi\\Numbers\\";
                                }
                                else if (LanguageID == "3")
                                {
                                    //pathstr = "E:\\Audio\\Local\\NUMBERS\\";
                                    AudioPath = "E:\\Audio\\Local\\Numbers\\";
                                }

                            }


                            if (AudioPath.IndexOf("{1}") > -1 || AudioPath.IndexOf("{2}") > -1)
                            {
                            }
                            else
                            {
                                var path = "";



                                if (File.Exists(AudioPath))
                                {
                                    path = "1";
                                    if (fileName.ToLower() == "train no.")
                                    {
                                        for (int index = 0; index < TrainNoAudiopath.Length; index++)
                                        {
                                            UpdatedFile.Rows.Add(Convert.ToInt32(LanguageID), Convert.ToInt32(sequence), TrainNoAudiopath[index]);
                                        }
                                    }
                                    else
                                    {
                                        UpdatedFile.Rows.Add(Convert.ToInt32(LanguageID), Convert.ToInt32(sequence), AudioPath);
                                    }
                                }

                            }
                        }

                        if (UpdatedFile.Rows.Count > 0)
                        {
                            DataTable dtAnnounce = messagesDb.PlayMsgAnnouncemnet(UpdatedFile, 1);
                            if (dtAnnounce.Rows.Count > 0)
                            {
                                string statusMessage = dtAnnounce.Rows[0]["Alert"].ToString();
                                if (statusMessage.Contains("Audio play started"))
                                {
                                    string logFilePath = "C:\\ShareToAll\\Announcement.txt";
                                    Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

                                    using (StreamWriter sw = new StreamWriter(logFilePath))
                                    {
                                        foreach (DataRow row in UpdatedFile.Rows)
                                        {
                                            sw.WriteLine(row["AudioFile"].ToString());
                                        }
                                    }

                                    List<string> audioPaths = UpdatedFile.AsEnumerable().Select(r => r.Field<string>("AudioFile")).ToList();
                                    AnnouncementController.cts = new CancellationTokenSource();
                                    await AnnouncementController.PlayAudioSet(audioPaths, 1, AnnouncementController.cts.Token);
                                }
                                else if (statusMessage.Contains("Other audio is Playing"))
                                {
                                    MessageBox.Show("Other audio is playing.");
                                }
                                else
                                {
                                    MessageBox.Show("Unexpected status: " + statusMessage);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No status information returned.");
                            }

                        }

                        else
                        {
                            MessageBox.Show("No valid audio files found to update.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private void btnStopSpecial_Click(object sender, EventArgs e)
        {
            try
            {


                DialogResult dResult = MessageBox.Show("Do you want to stop the play?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dResult == DialogResult.No)
                {
                    return;
                }
                AnnouncementController.UpdateStatus("STOP");
                AnnouncementController.UpdateAudioPlayStatus("Completed");
                btnPauseSpecial.Text = "Pause";
                btnPauseSpecial.TextAlign = ContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void btnPauseSpecial_Click(object sender, EventArgs e)
        {
            if (AnnouncementController.OtherAudioPlaying)
            {
                AnnouncementController.UpdateStatus("PAUSE");
                AnnouncementController.CheckPauseButtonClick();
                PauseButtonCheck();
            }

        }

        private void txtCoachId_Enter(object sender, EventArgs e)
        {
            string trainNum = txtTrainNo.Text.Trim();
            if (string.IsNullOrEmpty(trainNum))
            {
                MessageBox.Show("Please enter train number");
                txtCoachId.Text = "";
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                sendCCTVMessages();

                Server.getBoardsIpAdress();

                bool check = CheckMessages();
                if (check)
                {
                    if (Server._connectedClients.Count > 0)
                    {
                        sendMessagesData();
                    }

                }
                else
                {
                    MessageBox.Show("Please Click Atleast One Message");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        public static List<DataGridViewRow> CheckedMessages = new List<DataGridViewRow>();

        public bool CheckMessages()
        {
            BaseClass.specialMessages.Rows.Clear();
            int c = 0;
            try
            {
                // Get special messages from the database
                DataTable dt = messagesDb.GetSpecialMessagesData();
                BaseClass.specialMessages = dt.Clone();
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToBoolean(row["Checked"]))
                    {
                        BaseClass.specialMessages.ImportRow(row);
                        c++;
                    }
                }

                return c > 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return false;
            }
        }



        public static void sendMessagesData()
        {
            try
            {

                sendOVDMessages();
                sendIvdMessages();
                sendMldbMessages();
                sendPfdbMessages();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public static void sendCCTVMessages()
        {
            try
            {
                OnlineTrainsDao.DeleteAllMessages();

                foreach (DataRow checkedRow in BaseClass.specialMessages.Rows)
                {
                    string HindiMessage = checkedRow["NationalMsg"].ToString();
                    string EnglishMessage = checkedRow["Englishmsg"].ToString();
                    string RegMessage = checkedRow["RegionalMSg1"].ToString();


                    OnlineTrainsDao.InsertCCTVMessages(EnglishMessage, HindiMessage, RegMessage);
                }
                if (BaseClass.IsCdotAutoMode())
                {
                    OnlineTrainsDao.InsertCCTVMessages("Strong Likely to Occur ", "", "");
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
        public static void sendOVDMessages()
        {
            foreach (string ip in Server.OvdIpAdress)
            {
                BaseClass.defectiveLines = OnlineTrainsDao.getDefectiveLines(ip);
                BaseClass.boardType = "OVDIVD";
                PacketController.MessagesDataPacket(ip);
                byte[] finalPacket = MessageController.getMessagesFullPacket(Board.OVD, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.MessageData);
                if (BaseClass.boardWorkingstatus && BaseClass.boardMessagesstatus)
                    Server.SendMessageToClient(ip, finalPacket);
                string a = BaseClass.ByteArrayToString(finalPacket);
            }
        }
        public static void sendPfdbMessages()
        {

            foreach (string ip in Server.PfdbIpAdress)
            {
                BaseClass.defectiveLines = OnlineTrainsDao.getDefectiveLines(ip);
                BaseClass.boardType = "PFDB";
                PacketController.MessagesDataPacket(ip);
                byte[] finalPacket = MessageController.getMessagesFullPacket(Board.AGDB, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.MessageData);
                if (BaseClass.Getinteroperabilitystatus(ip))
                    finalPacket = ByteFormation.RemoveFirstAndLast6(finalPacket);
                if (BaseClass.boardWorkingstatus && BaseClass.boardMessagesstatus)
                    Server.SendMessageToClient(ip, finalPacket);

                string a = BaseClass.ByteArrayToString(finalPacket);
            }
        }
        public static void sendIvdMessages()
        {
            foreach (string ip in Server.IvdIpAdress)
            {
                BaseClass.boardType = "MLDB";
                PacketController.MessagesDataPacket(ip);
                byte[] finalPacket = MessageController.getMessagesFullPacket(Board.IVD, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.MessageData);
                if (BaseClass.boardWorkingstatus && BaseClass.boardMessagesstatus)
                    Server.SendMessageToClient(ip, finalPacket);
                string a = BaseClass.ByteArrayToString(finalPacket);
            }
        }
        public static void sendMldbMessages()
        {
            foreach (string ip in Server.MldbIpAdress)
            {
                BaseClass.defectiveLines = OnlineTrainsDao.getDefectiveLines(ip);
                BaseClass.boardType = "MLDB";
                PacketController.MessagesDataPacket(ip);
                byte[] finalPacket = MessageController.getMessagesFullPacket(Board.AGDB, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.MessageData);
                if (BaseClass.Getinteroperabilitystatus(ip))
                    finalPacket = ByteFormation.RemoveFirstAndLast6(finalPacket);
                if (BaseClass.boardWorkingstatus && BaseClass.boardMessagesstatus)
                    Server.SendMessageToClient(ip, finalPacket);
                string a = BaseClass.ByteArrayToString(finalPacket);
            }
        }
        public static void sendAgdbMessages()
        {
            //foreach (string ip in Server.AgdbIpAdress)
            //{
            //    BaseClass.boardType = "AGDB";
            //    PacketController.MessagesDataPacket(CheckedMessages, ip);
            //    byte[] finalPacket = MessageController.getMessagesFullPacket(Board.AGDB, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);               
            //    Server.SendMessageToClient(ip, finalPacket);
            //    string a = PfdbController.ByteArrayToString(finalPacket);
            //}
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(190, 150, "Hindi");
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

                    if (languageName != "English" && languageName != "Hindi")
                    {
                        localLanguage = languageName;
                        break;
                    }

                }
            }


            Keyboard(550, 150, localLanguage);
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

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void pnlSendMessage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtEnglish_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtHindi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtRegional_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void dgvMessages_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvMessages.IsCurrentCellDirty)
            {
                // Commit the edit to trigger the CellValueChanged event
                dgvMessages.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvMessages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int pkeyValue = Convert.ToInt32(dgvMessages.Rows[e.RowIndex].Cells["Pkey_SpclMessages"].Value);
            if (dgvMessages.Columns[e.ColumnIndex].Name == "select")
            {
                dgvMessages.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // int pkeyValue = Convert.ToInt32(dgvMessages.Rows[e.RowIndex].Cells["Pkey_SpclMessages"].Value);
                bool CheckStatus = Convert.ToBoolean(dgvMessages.CurrentRow.Cells["select"].Value);
                messagesDb.SaveMessagesStatus(pkeyValue, CheckStatus);
            }

        }
    }

}



