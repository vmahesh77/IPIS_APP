using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmAGDBReport : Form
    {
        private PaginationHelperClass paginationHelper;
        private DataTable reportData;
        AGDBReportDb AGDBreportDb = new AGDBReportDb();

        private const string PlaceholderText = "Search here...";
        private string initialText;
        private int initialDataGridViewHeight;
        public frmAGDBReport()
        {
            InitializeComponent();

            dtpFrom.CustomFormat = " ";
            dtpTo.CustomFormat = " ";
            initialText = txtSearch.Text;
            reportData = new DataTable();
            initialDataGridViewHeight = dgvAGDBReport.Height;
        }

        private void frmAGDBReport_Load(object sender, EventArgs e)
        {
            cmbExport.SelectedIndex = 0;
            dgvAGDBReport.EnableHeadersVisualStyles = false;
            dgvAGDBReport.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            LoadMessageStatus();
            cdtpFrom.DateTimeSelected += cdtpFrom_DateTimeSelected;
        }
        private void LoadMessageStatus()
        {
            try
            {
                DataTable messagesTable = AGDBreportDb.GetMessageStatus();

                if (messagesTable.Columns.Count >= 1)
                {
                    DataRow selectRow = messagesTable.NewRow();
                    selectRow[0] = 0;
                    selectRow[0] = "--All--";
                    messagesTable.Rows.InsertAt(selectRow, 0);

                    cmbTrainStatus.DataSource = messagesTable;

                    cmbTrainStatus.DisplayMember = messagesTable.Columns[0].ColumnName;
                    cmbTrainStatus.ValueMember = messagesTable.Columns[0].ColumnName;
                }
                else
                {
                    MessageBox.Show("The table does not have any columns.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                cdtpFrom.Visible = false;
                string fromtxt = txtFromdate.Text;
                string totxt = txtToDate.Text;
                DateTime? fromValue = null;
                DateTime? toValue = null;
                if (!string.IsNullOrEmpty(fromtxt) && !string.IsNullOrEmpty(totxt))
                {
                    fromValue = (DateTime.Parse(fromtxt));
                    toValue = (DateTime.Parse(totxt));
                }


                if (txtFromdate.Text == "" || txtToDate.Text == "")
                {
                    MessageBox.Show("Please Select from and to Date");
                }
                else if (fromValue > toValue)
                {
                    MessageBox.Show("Please Select To-Date greater than From-Date");
                }
                else if (fromValue == toValue)
                {
                    MessageBox.Show("From-DateTime and To-DateTime can't be same");
                }
                else
                {
                    txtSearch.Text = PlaceholderText;
                    txtSearch.ForeColor = Color.Gray;
                    cmbExport.SelectedIndex = 0;
                    dgvAGDBReport.Visible = true;
                    pnlPagination.Visible = true;
                    string fromDate = txtFromdate.Text;
                    string toDate = txtToDate.Text;
                    string selectedStatus = cmbTrainStatus.SelectedValue.ToString();
                    showData(fromDate, toDate, selectedStatus);

                    pnlNoDisplay.Visible = false;
                    txtSearch.Visible = true;
                    btnSearch.Visible = true;
                    //btnDropdown.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private void UpdateDataGridView()
        {
            try
            {

                DataTable currentPageData = paginationHelper.GetCurrentPageData();

                dgvAGDBReport.AutoGenerateColumns = true;
                dgvAGDBReport.DataSource = currentPageData;

                int dataGridViewNewHeight;

                // Adjust the height of the DataGridView
                if (currentPageData.Rows.Count < visibleRowsCount)
                {
                    dataGridViewNewHeight = (currentPageData.Rows.Count * dgvAGDBReport.RowTemplate.Height)
                                            + dgvAGDBReport.ColumnHeadersHeight
                                            + 2;
                }
                else
                {
                    dataGridViewNewHeight = (visibleRowsCount * dgvAGDBReport.RowTemplate.Height)
                                            + dgvAGDBReport.ColumnHeadersHeight
                                            + 2;
                }


                dgvAGDBReport.Height = dataGridViewNewHeight;

                //float widthPercentage = (float)dgvAGDBReport.Width / currentPageData.Columns.Count;

                //foreach (DataGridViewColumn column in dgvAGDBReport.Columns)
                //{
                //    column.Width = (int)widthPercentage;
                //}

                if (dgvAGDBReport.Columns.Count > 0)
                {
                    float totalWidth = dgvAGDBReport.Width;

                    int firstColumnWidth = 80;

                    float remainingWidth = totalWidth - firstColumnWidth;

                    if (dgvAGDBReport.Columns.Count > 2)
                    {
                        float widthPercentage = remainingWidth / (dgvAGDBReport.Columns.Count - 1);

                        dgvAGDBReport.Columns[0].Width = firstColumnWidth;

                        for (int i = 1; i < dgvAGDBReport.Columns.Count; i++)
                        {
                            dgvAGDBReport.Columns[i].Width = (int)widthPercentage;
                        }
                    }
                }

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





        int visibleRowsCount = 0;
        public void showData(string fromDate, string toDate, string selectedStatus)
        {
            try
            {
                DataTable AGDBReports = AGDBreportDb.GetAllAGDBreport(fromDate, toDate, selectedStatus);

                dgvAGDBReport.Columns.Clear();

                if (AGDBReports != null && AGDBReports.Rows.Count > 0)
                {
                    dgvAGDBReport.AutoGenerateColumns = true;
                    reportData.Clear();
                    reportData.Columns.Clear();
                    dgvAGDBReport.Height = initialDataGridViewHeight;

                    reportData = AGDBReports.Copy();
                    visibleRowsCount = (dgvAGDBReport.Height / dgvAGDBReport.RowTemplate.Height) - 1;
                    paginationHelper = new PaginationHelperClass(reportData, visibleRowsCount);
                    UpdateDataGridView();

                    lblNoDataDisplay.Visible = false;
                    pnlPagination.Visible = true;
                }
                else
                {
                    lblNoDataDisplay.Visible = true;
                    pnlPagination.Visible = false;

                    reportData = AGDBReports.Copy();
                    foreach (DataColumn column in AGDBReports.Columns)
                    {
                        dgvAGDBReport.Columns.Add(column.ColumnName, column.ColumnName);
                        dgvAGDBReport.Columns[column.ColumnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    dgvAGDBReport.DataSource = null;

                }

                chkFilter.Items.Clear();
                foreach (DataColumn column in reportData.Columns)
                {
                    chkFilter.Items.Add(column.ColumnName);
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


        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = dtpFrom.Value;
                txtFromdate.Text = dt.ToString("dd-MMM-yy HH:mm:ss");
            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = dtpTo.Value;
                txtToDate.Text = dt.ToString("dd-MMM-yy HH:mm:ss");
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public static bool chkvisible = true;
        private void btnDropdown_Click(object sender, EventArgs e)
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
                    paginationHelper = new PaginationHelperClass(reportData, 8);
                    UpdateDataGridView();
                    lblNoDataDisplay.Visible = false;
                    btnCross.Visible = false;
                    btnSearch.Visible = true;
                }
                else
                {
                    lblNoDataDisplay.Visible = true;
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
                if (txtSearch.Text == PlaceholderText || string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    return;
                }

                if (reportData.Rows.Count == 0)
                {
                    dgvAGDBReport.Columns.Clear();
                    btnCross.Visible = true;
                    btnSearch.Visible = false;

                    lblNoDataDisplay.Visible = true;
                    pnlPagination.Visible = false;

                    foreach (DataColumn column in reportData.Columns)
                    {
                        dgvAGDBReport.Columns.Add(column.ColumnName, column.ColumnName);
                        dgvAGDBReport.Columns[column.ColumnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    dgvAGDBReport.DataSource = null;

                    return;
                }

                string searchText = txtSearch.Text.Trim();
                selectedColumns.Clear();

                foreach (var item in chkFilter.CheckedItems)
                {
                    string columnName = item.ToString();

                    if (!selectedColumns.Contains(columnName))
                    {
                        selectedColumns.Add(columnName);
                    }
                }

                if (searchText != previousSearchText)
                {
                    PerformSearchAndFilter(searchText);
                    previousSearchText = searchText;
                }


                bool matchFound = CheckIfDataMatchesSearch();
                lblNoDataDisplay.Visible = !matchFound;


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



        private void cmbExport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedOption = cmbExport.SelectedItem.ToString().ToUpper();
                switch (selectedOption)
                {
                    case "PDF":
                        SaveFileDialogForPDF();
                        break;
                    case "XLSX":
                        SaveFileDialogForExcel(".xlsx");
                        break;
                    case "XLS":
                        SaveFileDialogForExcel(".xls");
                        break;
                        //default:
                        //    MessageBox.Show("Invalid export option selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    break;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void SaveFileDialogForPDF()
        {
            try
            {

                if (reportData != null && reportData.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF (*.pdf)|*.pdf";


                    string fixedDirectory = @"C:\Reports\";
                    if (!Directory.Exists(fixedDirectory))
                    {
                        Directory.CreateDirectory(fixedDirectory);
                    }


                    sfd.InitialDirectory = fixedDirectory;






                    string fileName = "AGDBReport" + DateTime.Now.ToString("_" + "dd" + "_" + "MM" + "_" + "yyyy" + "_" + "HH" + "_" + "mm" + "_" + "ss") + ".pdf";
                    sfd.FileName = fileName;
                    string header = "AGDB Report";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportPDFClass.ExportToPDF(sfd.FileName, header, reportData);
                    }
                }
                else
                {
                    MessageBox.Show("No data available to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void SaveFileDialogForExcel(string extension)
        {
            try
            {
                if (reportData != null && reportData.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";


                    string fixedDirectory = @"C:\Reports\";
                    if (!Directory.Exists(fixedDirectory))
                    {
                        Directory.CreateDirectory(fixedDirectory);
                    }


                    sfd.InitialDirectory = fixedDirectory;


                    string fileName = "AGDBReport" + DateTime.Now.ToString("_" + "dd" + "_" + "MM" + "_" + "yyyy" + "_" + "HH" + "_" + "mm" + "_" + "ss") + extension; // Change file extension to .xlsx
                    sfd.FileName = fileName;
                    string header = "AGDB Report";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (extension == ".xls")
                        {
                            ExportPDFClass.ExportToExcel(sfd.FileName, header, reportData);
                        }
                        else
                        {
                            ExportPDFClass.ExportToExcel(sfd.FileName, header, reportData);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No data available to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private bool isToDateDMRClicked = false;
        private void txtFromdate_Click(object sender, EventArgs e)
        {
            cdtpFrom.Reset();
            isToDateDMRClicked = false;
            cdtpFrom.Location = new Point(66, 43);
            cdtpFrom.Visible = true;
        }

        private void txtToDate_Click(object sender, EventArgs e)
        {
            cdtpFrom.Reset();
            isToDateDMRClicked = true;
            cdtpFrom.Location = new Point(342, 43);
            cdtpFrom.Visible = true;
        }

        private void cdtpFrom_DateTimeSelected(object sender, string finalDateTimeString)
        {

            if (isToDateDMRClicked)
            {
                txtToDate.Text = finalDateTimeString;
            }
            else
            {
                txtFromdate.Text = finalDateTimeString;
            }
        }

        private void dgvAGDBReport_Click(object sender, EventArgs e)
        {
            cdtpFrom.Visible = false;
        }

        private void cmbExport_Click(object sender, EventArgs e)
        {
            cdtpFrom.Visible = false;
        }

        private void pnlNoDisplay_Click(object sender, EventArgs e)
        {
            cdtpFrom.Visible = false;
        }

        private void pnlAGDBReport_Click(object sender, EventArgs e)
        {
            cdtpFrom.Visible = false;
        }
    }
}
