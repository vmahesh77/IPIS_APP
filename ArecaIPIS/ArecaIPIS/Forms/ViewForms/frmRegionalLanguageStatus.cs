using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.ViewForms
{
    public partial class frmRegionalLanguageStatus : Form
    {

        private PaginationHelperClass paginationHelper;
        private DataTable reportData;
        private const string PlaceholderText = "Search here...";
        regionalLanguageStatusDb regionallanguageStatusDb = new regionalLanguageStatusDb();
        private int initialDataGridViewHeight;


        public frmRegionalLanguageStatus()
        {
            InitializeComponent();

        }
        private frmHome parentForm;
        public frmRegionalLanguageStatus(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            reportData = new DataTable();
            initialDataGridViewHeight = dgvLanguageSettingsTable.Height;

        }

        private void frmRegionalLanguageStatus_Load(object sender, EventArgs e)
        {
            txtSearch.Text = PlaceholderText;
            txtSearch.ForeColor = Color.Gray;
            dgvLanguageSettingsTable.EnableHeadersVisualStyles = false;
            dgvLanguageSettingsTable.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dgvLanguageSettingsTable.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(dgvLanguageSettingsTable_CellToolTipTextNeeded);
            //dgvLanguageSettingsTable.RowTemplate.Height = 36;
            showData();
            InitializeControls();

        }
        private void dgvLanguageSettingsTable_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgvLanguageSettingsTable.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                {
                    e.ToolTipText = "Edit";
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



                if (languagesCount > 2)
                {
                    dgvLanguageSettingsTable.AutoGenerateColumns = false;
                    dgvLanguageSettingsTable.Columns["English"].DataPropertyName = "StatusName";
                    dgvLanguageSettingsTable.Columns["Hindi"].DataPropertyName = "HStatus";
                    dgvLanguageSettingsTable.Columns["RegionalLanguage"].DataPropertyName = "RStatus";

                    if (!dgvLanguageSettingsTable.Columns.Contains("Pkey_Status"))
                    {
                        DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Pkey_Status",
                            HeaderText = "Pkey_Status",
                            Name = "Pkey_Status",
                            Visible = false
                        };
                        dgvLanguageSettingsTable.Columns.Add(pkeyColumn);
                    }
                    else
                    {
                        dgvLanguageSettingsTable.Columns["Pkey_Status"].DataPropertyName = "Pkey_Status";
                        dgvLanguageSettingsTable.Columns["Pkey_Status"].Visible = false;
                    }
                    dgvLanguageSettingsTable.DataSource = currentPageData;
                    dgvLanguageSettingsTable.AllowUserToAddRows = false;

                    int dataGridViewNewHeight;

                    // Adjust the height of the DataGridView
                    if (currentPageData.Rows.Count < visibleRowsCount)
                    {
                        dataGridViewNewHeight = (currentPageData.Rows.Count * dgvLanguageSettingsTable.RowTemplate.Height)
                                                + dgvLanguageSettingsTable.ColumnHeadersHeight
                                                + 2;
                    }
                    else
                    {
                        dataGridViewNewHeight = (visibleRowsCount * dgvLanguageSettingsTable.RowTemplate.Height)
                                                + dgvLanguageSettingsTable.ColumnHeadersHeight
                                                + 2;
                    }


                    dgvLanguageSettingsTable.Height = dataGridViewNewHeight;


                    paginationHelper.UpdatePaginationControls(pnlPagination, OnPageChanged);
                }
                else
                {
                    if (dgvLanguageSettingsTable.Columns.Contains("RegionalLanguage"))
                    {

                        var existingColumn = dgvLanguageSettingsTable.Columns["RegionalLanguage"];
                        existingColumn.DataPropertyName = "RStatus";
                        existingColumn.Width = 50;
                        existingColumn.Visible = false;
                    }

                    dgvLanguageSettingsTable.AutoGenerateColumns = false;
                    dgvLanguageSettingsTable.Columns["English"].DataPropertyName = "StatusName";
                    dgvLanguageSettingsTable.Columns["Hindi"].DataPropertyName = "HStatus";


                    if (!dgvLanguageSettingsTable.Columns.Contains("Pkey_Status"))
                    {
                        DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Pkey_Status",
                            HeaderText = "Pkey_Status",
                            Name = "Pkey_Status",
                            Visible = false
                        };
                        dgvLanguageSettingsTable.Columns.Add(pkeyColumn);
                    }
                    else
                    {
                        dgvLanguageSettingsTable.Columns["Pkey_Status"].DataPropertyName = "Pkey_Status";
                        dgvLanguageSettingsTable.Columns["Pkey_Status"].Visible = false;
                    }
                    dgvLanguageSettingsTable.DataSource = currentPageData;
                    dgvLanguageSettingsTable.Columns["English"].Width = 570;
                    dgvLanguageSettingsTable.Columns["Hindi"].Width = 570;


                    dgvLanguageSettingsTable.AllowUserToAddRows = false;

                    int dataGridViewNewHeight;

                    // Adjust the height of the DataGridView
                    if (currentPageData.Rows.Count < visibleRowsCount)
                    {
                        dataGridViewNewHeight = (currentPageData.Rows.Count * dgvLanguageSettingsTable.RowTemplate.Height)
                                                + dgvLanguageSettingsTable.ColumnHeadersHeight
                                                + 2;
                    }
                    else
                    {
                        dataGridViewNewHeight = (visibleRowsCount * dgvLanguageSettingsTable.RowTemplate.Height)
                                                + dgvLanguageSettingsTable.ColumnHeadersHeight
                                                + 2;
                    }


                    dgvLanguageSettingsTable.Height = dataGridViewNewHeight;


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
        private readonly Dictionary<string, string> displayNameMap = new Dictionary<string, string>
    {
        {"StatusName","English" },
        { "HStatus", "Hindi" },
        { "RStatus", "Regional Language" },
    };

        int visibleRowsCount = 0;
        public void showData()
        {
            try
            {


                DataTable regionalLanguageStatus = regionallanguageStatusDb.GetRegionalLanguageStatus();

                if (regionalLanguageStatus != null)
                {
                    reportData.Clear();
                    reportData.Columns.Clear();
                    dgvLanguageSettingsTable.Height = initialDataGridViewHeight;

                    reportData = regionalLanguageStatus.Copy();
                    visibleRowsCount = (dgvLanguageSettingsTable.Height / dgvLanguageSettingsTable.RowTemplate.Height) - 1;
                    paginationHelper = new PaginationHelperClass(reportData, visibleRowsCount);
                    UpdateDataGridView();

                    lblNoDataToDisplay.Visible = false;
                    pnlPagination.Visible = true;
                }
                else
                {
                    lblNoDataToDisplay.Visible = true;
                    pnlPagination.Visible = false;

                    reportData = regionalLanguageStatus.Copy();
                    foreach (DataColumn column in regionalLanguageStatus.Columns)
                    {
                        dgvLanguageSettingsTable.Columns.Add(column.ColumnName, column.ColumnName);
                        dgvLanguageSettingsTable.Columns[column.ColumnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    dgvLanguageSettingsTable.DataSource = null;

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

        private void dgvLanguageSettingsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    try
                    {
                        int pkeyValue = Convert.ToInt32(dgvLanguageSettingsTable.Rows[e.RowIndex].Cells["Pkey_Status"].Value);
                        DataTable Message = regionallanguageStatusDb.GetLanguageStatusByRow(pkeyValue);
                        if (languagesCount > 2)
                        {
                            if (Message != null && Message.Rows.Count > 0)
                            {

                                string english = Message.Rows[0]["StatusName"].ToString();
                                string Hindi = Message.Rows[0]["HStatus"].ToString();
                                string RLanguage = Message.Rows[0]["RStatus"].ToString();

                                pnlCreateLanguageStatus.Visible = true;
                                pnlCreateCoach.Visible = true;
                                //lblCreateCoach.Text = "Edit Coach Data";
                                //btnSave.Text = "    Update";
                                txtEnglish.Text = english;
                                txtHindi.Text = Hindi;
                                txtRLanguage.Text = RLanguage;

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

                                string english = Message.Rows[0]["StatusName"].ToString();
                                string Hindi = Message.Rows[0]["HStatus"].ToString();
                                //string RLanguage = Message.Rows[0]["RStatus"].ToString();

                                pnlCreateLanguageStatus.Visible = true;
                                pnlCreateCoach.Visible = true;
                                //lblCreateCoach.Text = "Edit Coach Data";
                                //btnSave.Text = "    Update";
                                txtEnglish.Text = english;
                                txtHindi.Text = Hindi;
                                //txtRLanguage.Text = RLanguage;
                                txtRLanguage.Visible = false;
                                lblRLanguage.Visible = false;
                                lblRegionalName.Visible = false;
                                pbCrossRegional.Visible = false;
                                btnRKeyBoard.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("No data retrieved from the database.");
                            }
                        }


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlCreateLanguageStatus.Visible = false;
            pnlCreateCoach.Visible = false;
            txtEnglish.Text = "";
            txtHindi.Text = "";
            txtRLanguage.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string english = txtEnglish.Text;
            string Hindi = txtHindi.Text;
            string RLanguage = txtRLanguage.Text;

            try
            {
                if (!string.IsNullOrWhiteSpace(english))
                {


                    bool b = regionallanguageStatusDb.InsertOrUpdateMessage(english, Hindi, RLanguage);

                    if (b)
                    {
                        ReportDb.InsertDatabaseModificationReportData("Regional status updated" + english, "3");
                        MessageBox.Show("Data Updated successfully");
                        pnlCreateLanguageStatus.Visible = false;
                        pnlCreateCoach.Visible = false;
                        txtEnglish.Text = "";
                        txtHindi.Text = "";
                        txtRLanguage.Text = "";
                        showData();
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(english))
                    {
                        lblEnglishCoach.Visible = true;
                        pbCross.Visible = true;
                    }

                }

                dgvLanguageSettingsTable.RefreshEdit();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnCross.Visible = true;
            btnSearch.Visible = false;
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

                paginationHelper = new PaginationHelperClass(filteredDataTable, visibleRowsCount);
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

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = PlaceholderText;
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtEnglish_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnglish.Text))
            {

                lblEnglishCoach.Visible = true;
                pbTick.Visible = false;
                pbCross.Visible = true;

            }
            else
            {
                lblEnglishCoach.Visible = false;
                pbTick.Visible = true;
                pbCross.Visible = false;
            }
            CheckAndSetReadOnly(txtEnglish);
        }
        private void CheckAndSetReadOnly(TextBox txtEnglish)
        {
            // Check if the TextBox already has text
            if (!string.IsNullOrEmpty(txtEnglish.Text))
            {

                txtEnglish.ReadOnly = true;
            }
            else
            {

                txtEnglish.ReadOnly = false;
            }
        }

        private void btnHKeyBoard_Click(object sender, EventArgs e)
        {
            Keyboard(350, 150, "Hindi");
        }

        private void btnRKeyBoard_Click(object sender, EventArgs e)
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

            Keyboard(650, 200, localLanguage);
        }

        private void InitializeControls()
        {
            txtEnglish.Enter += Control_Enter;
            txtHindi.Enter += Control_Enter;
            txtRLanguage.Enter += Control_Enter;
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



    }
}
