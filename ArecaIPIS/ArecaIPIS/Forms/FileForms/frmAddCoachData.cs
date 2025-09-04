using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmAddCoachData : Form
    {
        private PaginationHelperClass paginationHelper;
        private DataTable reportData;
        private const string PlaceholderText = "Search here...";
        addCoachDataDb addCoachDataDb = new addCoachDataDb();
        private int initialDataGridViewHeight;
        public frmAddCoachData()
        {
            InitializeComponent();
            reportData = new DataTable();
            initialDataGridViewHeight = dgvCoachData.Height;
        }
        private void frmAddCoachData_Load(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = PlaceholderText;
                txtSearch.ForeColor = Color.Gray;
                dgvCoachData.EnableHeadersVisualStyles = false;
                dgvCoachData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                toolTip.SetToolTip(btnAddMessage, "Add New Coach Data");
                dgvCoachData.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(dgvCoachData_CellToolTipTextNeeded);
                //dgvCoachData.RowTemplate.Height = 35;
                showData();
                InitializeControls();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void dgvCoachData_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgvCoachData.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                {
                    e.ToolTipText = "Edit";
                }
            }
        }

        private frmHome parentForm;

        public frmAddCoachData(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void UpdateDataGridView()
        {
            try
            {


                DataTable currentPageData = paginationHelper.GetCurrentPageData();

                dgvCoachData.AutoGenerateColumns = false;

                dgvCoachData.Columns["CoachName"].DataPropertyName = "EnglishCoachName";
                dgvCoachData.Columns["HindiLanguage"].DataPropertyName = "HindiCoachName";
                dgvCoachData.Columns["Bitmap"].DataPropertyName = "Bitmap";

                if (!dgvCoachData.Columns.Contains("Pkey_CoachBitmapid"))
                {
                    DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Pkey_CoachBitmapid",
                        HeaderText = "Pkey_CoachBitmapid",
                        Name = "Pkey_CoachBitmapid",
                        Visible = false
                    };
                    dgvCoachData.Columns.Add(pkeyColumn);
                }
                else
                {
                    dgvCoachData.Columns["Pkey_CoachBitmapid"].DataPropertyName = "Pkey_CoachBitmapid";
                    dgvCoachData.Columns["Pkey_CoachBitmapid"].Visible = false;
                }
                dgvCoachData.DataSource = currentPageData;
                dgvCoachData.AllowUserToAddRows = false;
                int dataGridViewNewHeight;

                // Adjust the height of the DataGridView
                if (currentPageData.Rows.Count < visibleRowsCount)
                {
                    dataGridViewNewHeight = (currentPageData.Rows.Count * dgvCoachData.RowTemplate.Height)
                                            + dgvCoachData.ColumnHeadersHeight
                                            + 2;
                }
                else
                {
                    dataGridViewNewHeight = (visibleRowsCount * dgvCoachData.RowTemplate.Height)
                                            + dgvCoachData.ColumnHeadersHeight
                                            + 2;
                }


                dgvCoachData.Height = dataGridViewNewHeight;

                paginationHelper.UpdatePaginationControls(pnlPagination, OnPageChanged);
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
        private readonly Dictionary<string, string> displayNameMap = new Dictionary<string, string>
    {
        {"EnglishCoachName","Coach Name" },
        { "HindiCoachName", "Hindi Language" },
        { "Bitmap", "Bitmap" }
    };

        int visibleRowsCount = 0;
        public void showData()
        {
            try
            {


                DataTable CoachData = addCoachDataDb.GetCoachData();

                if (CoachData != null)
                {

                    dgvCoachData.AutoGenerateColumns = false;

                    reportData.Clear();
                    reportData.Columns.Clear();

                    dgvCoachData.Height = initialDataGridViewHeight;
                    reportData = CoachData.Copy();

                    visibleRowsCount = (dgvCoachData.Height / dgvCoachData.RowTemplate.Height) - 1;

                    paginationHelper = new PaginationHelperClass(reportData, visibleRowsCount);
                    UpdateDataGridView();

                    lblNoDataToDisplay.Visible = false;
                    pnlPagination.Visible = true;
                }
                else
                {
                    lblNoDataToDisplay.Visible = true;
                    pnlPagination.Visible = false;

                    reportData = CoachData.Copy();
                    foreach (DataColumn column in CoachData.Columns)
                    {
                        dgvCoachData.Columns.Add(column.ColumnName, column.ColumnName);
                        dgvCoachData.Columns[column.ColumnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    dgvCoachData.DataSource = null;

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

                    if (c > 0)
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



        private void btnAddMessage_Click(object sender, EventArgs e)
        {
            try
            {


                pkey = 0;
                pnlCoachData.Visible = true;
                pnlCreateCoach.Visible = true;
                lblCreateCoach.Text = "Add Coach Data";
                btnSave.Text = "Save";
                txtEnglish.Text = "";
                txtHindi.Text = "";
                txtBitmap.Text = "";
                lblBitmapName.Visible = false;
                lblEnglishCoach.Visible = false;
                lblHindiCoach.Visible = false;
                pbCross.Visible = false;
                pbCrossHindi.Visible = false;
                pbCrossBitmap.Visible = false;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        int pkey;
        private void dgvCoachData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    int pkeyValue = Convert.ToInt32(dgvCoachData.Rows[e.RowIndex].Cells["Pkey_CoachBitmapid"].Value);
                    DataTable Message = addCoachDataDb.GetCoachDataByRow(pkeyValue);

                    if (Message != null && Message.Rows.Count > 0)
                    {
                        pkey = pkeyValue;
                        string english = Message.Rows[0]["EnglishCoachName"].ToString();
                        string Hindi = Message.Rows[0]["HindiCoachName"].ToString();
                        string Bitmap = Message.Rows[0]["Bitmap"].ToString();

                        pnlCoachData.Visible = true;
                        pnlCreateCoach.Visible = true;
                        lblCreateCoach.Text = "Edit Coach Data";
                        btnSave.Width = 85;
                        btnSave.Text = "Update";

                        txtEnglish.Text = english;
                        txtHindi.Text = Hindi;
                        txtBitmap.Text = Bitmap;

                    }
                    else
                    {
                        MessageBox.Show("No data retrieved from the database.");
                    }
                }
                catch (Exception ex)
                {
                    Server.LogError(ex.Message);
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlCoachData.Visible = false;
            pnlCreateCoach.Visible = false;
            txtEnglish.Text = "";
            txtHindi.Text = "";
            txtBitmap.Text = "";

        }

        private void txtEnglish_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtEnglish.Text))
                {
                    //lblValidationEnglish.Text = "Please Enter Message in English.";
                    //lblEnglish.Visible = true;
                    lblEnglishCoach.Visible = true;
                    //pbTick.Visible = false;
                    pbCross.Visible = true;

                }
                else
                {

                    lblEnglishCoach.Visible = false;
                    //pbTick.Visible = true;
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
            if (string.IsNullOrWhiteSpace(txtHindi.Text))
            {

                lblHindiCoach.Visible = true;
                //pbTickHindi.Visible = false;
                pbCrossHindi.Visible = true;

            }
            else
            {

                lblHindiCoach.Visible = false;
                //pbTickHindi.Visible = true;
                pbCrossHindi.Visible = false;
            }
        }

        private void txtBitmap_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtBitmap.Text))
                {

                    lblBitmapName.Visible = true;
                    //pbTickBitmap.Visible = false;
                    pbCrossBitmap.Visible = true;

                }
                else
                {

                    lblBitmapName.Visible = false;
                    //pbTickBitmap.Visible = true;
                    pbCrossBitmap.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string english = txtEnglish.Text;
            string Hindi = txtHindi.Text;
            string Bitmap = txtBitmap.Text;

            try
            {
                if (!string.IsNullOrWhiteSpace(english) &&
                    !string.IsNullOrWhiteSpace(Hindi) &&
                    !string.IsNullOrWhiteSpace(Bitmap))
                {
                    int pk = pkey;
                    DialogResult dResult = MessageBox.Show("Do you like to save/Update the Configuration?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dResult == DialogResult.No)
                    {
                        return;
                    }


                    bool b = addCoachDataDb.InsertOrUpdateMessage(pk, english, Hindi, Bitmap);

                    if (b)
                    {
                        MessageBox.Show("Data saved/Update successfully");
                        pnlCoachData.Visible = false;
                        pnlCreateCoach.Visible = false;
                        txtEnglish.Text = "";
                        txtHindi.Text = "";
                        txtBitmap.Text = "";
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
                        txtEnglish.Focus();
                    }
                    if (string.IsNullOrWhiteSpace(Hindi))
                    {
                        lblHindiCoach.Visible = true;
                        pbCrossHindi.Visible = true;
                    }
                    if (string.IsNullOrWhiteSpace(Bitmap))
                    {
                        lblBitmapName.Visible = true;
                        pbCrossBitmap.Visible = true;
                    }
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

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == PlaceholderText)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
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

        private void btnHKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(180, 200, "Hindi");
        }
        private void InitializeControls()
        {
            txtHindi.Enter += Control_Enter;
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
    }
}
