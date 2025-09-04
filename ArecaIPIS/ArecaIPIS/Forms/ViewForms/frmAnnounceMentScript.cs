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
    public partial class frmAnnounceMentScript : Form
    {

        AnnouncementScriptDb announcementScriptDb = new AnnouncementScriptDb();
        private PaginationHelperClass paginationHelper;
        private DataTable reportData;
        private DataTable statusData;
        private int initialDataGridViewHeight;

        public frmAnnounceMentScript()
        {
            InitializeComponent();
        }

        //public frmAnnounceMentScript(frmHome parentForm)
        //{
        //    InitializeComponent();
        //    this.parentForm = parentForm;
        //    reportData = new DataTable();


        //}
        private frmIndex parentForm;
        public frmAnnounceMentScript(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            reportData = new DataTable();
            initialDataGridViewHeight = dgvAnnScriptTable.Height;
        }

        private void btnAddAudioScript_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedStatus = Convert.ToInt32(cbmTrainStatus.SelectedValue);

                int selectedLanguageId;

                string selectedLanguage = cmbTrainLanguage.SelectedItem.ToString();
                if (selectedLanguage == "English")
                {
                    selectedLanguageId = 1;
                }
                else if (selectedLanguage == "Hindi")
                {
                    selectedLanguageId = 2;
                }
                else
                {
                    selectedLanguageId = 3;
                }
                int selectedPlatform = cmbPlatform.SelectedIndex;
                showData(selectedStatus, selectedLanguageId, selectedPlatform);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        int visibleRowsCount = 0;
        public void showData(int selectedStatus, int selectedLanguageId, int selectedPlatform)
        {

            try
            {


                DataTable AudioFormat = announcementScriptDb.GetAudioFormat(selectedStatus, selectedLanguageId, selectedPlatform);

                if (AudioFormat != null && AudioFormat.Rows.Count > 0)
                {

                    reportData.Clear();
                    reportData.Columns.Clear();
                    dgvAnnScriptTable.Height = initialDataGridViewHeight;
                    reportData = AudioFormat.Copy();

                    visibleRowsCount = (dgvAnnScriptTable.Height / dgvAnnScriptTable.RowTemplate.Height) - 1;

                    paginationHelper = new PaginationHelperClass(reportData, visibleRowsCount);
                    UpdateDataGridView();

                    lblNoDataToDisplay.Visible = false;
                    pnlPagination.Visible = true;
                }
                else
                {
                    lblNoDataToDisplay.Visible = true;
                    pnlPagination.Visible = false;

                    reportData = AudioFormat.Copy();
                    //foreach (DataColumn column in AudioFormat.Columns)
                    //{
                    //    dgvAnnScriptTable.Columns.Add(column.ColumnName, column.ColumnName);
                    //    dgvAnnScriptTable.Columns[column.ColumnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //}
                    dgvAnnScriptTable.DataSource = null;
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

                dgvAnnScriptTable.AutoGenerateColumns = false;

                dgvAnnScriptTable.Columns["AudioPath"].DataPropertyName = "AudioPath";
                dgvAnnScriptTable.Columns["AudioFileName"].DataPropertyName = "AudioName";
                dgvAnnScriptTable.Columns["Sequence"].DataPropertyName = "sequence";

                if (!dgvAnnScriptTable.Columns.Contains("Pkey_AudioFormat"))
                {
                    DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Pkey_AudioFormat",
                        HeaderText = "Pkey_AudioFormat",
                        Name = "Pkey_AudioFormat",
                        Visible = false
                    };
                    dgvAnnScriptTable.Columns.Add(pkeyColumn);
                }
                else
                {
                    dgvAnnScriptTable.Columns["Pkey_AudioFormat"].DataPropertyName = "Pkey_AudioFormat";
                    dgvAnnScriptTable.Columns["Pkey_AudioFormat"].Visible = false;
                }
                dgvAnnScriptTable.DataSource = currentPageData;

                int dataGridViewNewHeight;

                // Adjust the height of the DataGridView
                if (currentPageData.Rows.Count < visibleRowsCount)
                {
                    dataGridViewNewHeight = (currentPageData.Rows.Count * dgvAnnScriptTable.RowTemplate.Height)
                                            + dgvAnnScriptTable.ColumnHeadersHeight
                                            + 2;
                }
                else
                {
                    dataGridViewNewHeight = (visibleRowsCount * dgvAnnScriptTable.RowTemplate.Height)
                                            + dgvAnnScriptTable.ColumnHeadersHeight
                                            + 2;
                }


                dgvAnnScriptTable.Height = dataGridViewNewHeight;


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

        private void btnAddMessage_Click(object sender, EventArgs e)
        {

            try
            {


                pkey = 0;
                cnbTrainStatus.DataSource = statusData;
                cnbTrainStatus.DisplayMember = statusData.Columns[1].ColumnName;
                cnbTrainStatus.ValueMember = statusData.Columns[0].ColumnName;

                pnlAudioScriptCreate.Visible = true;
                lblCreateNewAudioScript.Text = "Create New Audio Script";
                btnSave.Text = "Save";

                txtAudioPath.Text = "";
                txtAudioName.Text = "";
                nudSequence.Text = "0";
                if (cnbTrainStatus.Items.Count > 1)
                {
                    cnbTrainStatus.SelectedIndex = 0;
                }


                pbCrossAudioPath.Visible = false;
                lblAudioPathValidation.Visible = false;
                pbCrossAudioName.Visible = false;
                lblAudioNameValidation.Visible = false;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlAudioScriptCreate.Visible = false;
        }

        private void frmAnnounceMentScript_Load(object sender, EventArgs e)
        {
            try
            {


                LoadStatus();
                LoadLanguage();

                cmbTrainLanguage.SelectedIndex = 0;
                cmbPlatform.SelectedIndex = 1;
                CmbPlatformStatus.SelectedIndex = 1;

                cmbTrainLanguage.SelectedIndex = 1;
                cmbLanguageName.SelectedIndex = 1;

                dgvAnnScriptTable.EnableHeadersVisualStyles = false;
                dgvAnnScriptTable.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                toolTip.SetToolTip(btnAddMessage, "Add New Announcement Script");
                dgvAnnScriptTable.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(dgvAnnScriptTable_CellToolTipTextNeeded);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void dgvAnnScriptTable_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgvAnnScriptTable.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                {
                    e.ToolTipText = "Edit";
                }
            }

        }
        private void LoadStatus()
        {
            try
            {


                DataTable status = announcementScriptDb.GetAllStatus();

                if (status.Columns.Count >= 2)
                {
                    DataRow selectRow = status.NewRow();
                    selectRow[0] = 0;
                    selectRow[1] = "-Select-";
                    status.Rows.InsertAt(selectRow, 0);

                    cbmTrainStatus.DataSource = status;
                    cbmTrainStatus.DisplayMember = status.Columns[1].ColumnName;
                    cbmTrainStatus.ValueMember = status.Columns[0].ColumnName;
                    statusData = status.Copy();
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

        private void LoadLanguage()
        {
            try
            {


                DataTable Languge = announcementScriptDb.GetLanguage();




                cmbTrainLanguage.Items.Clear();
                cmbLanguageName.Items.Clear();
                if (Languge.Columns.Count >= 1)
                {
                    cmbTrainLanguage.Items.Add("-Select-");
                    cmbLanguageName.Items.Add("-Select-");
                    foreach (DataRow row in Languge.Rows)
                    {
                        string languageName = row[2].ToString();
                        cmbTrainLanguage.Items.Add(languageName);
                        cmbLanguageName.Items.Add(languageName);

                    }

                    cmbTrainLanguage.SelectedIndex = 1;
                    cmbLanguageName.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show("The table does not have at least two columns.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        int pkey;
        private void dgvAnnScriptTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {


                cnbTrainStatus.DataSource = statusData;
                cnbTrainStatus.DisplayMember = statusData.Columns[1].ColumnName;
                cnbTrainStatus.ValueMember = statusData.Columns[0].ColumnName;


                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    try
                    {
                        string Language = "";
                        string AudioPath = "";
                        string AudioName = "";
                        string Sequence = "";
                        string platform = "";
                        string Status = "";

                        pkey = Convert.ToInt32(dgvAnnScriptTable.Rows[e.RowIndex].Cells["Pkey_AudioFormat"].Value);
                        //DataTable Message = AnnouncementScriptDb.GetMessageFormatByRow(pkeyValue);

                        if (reportData != null && reportData.Rows.Count > 0)
                        {
                            foreach (DataRow row in reportData.Rows)
                            {
                                if (Convert.ToInt32(row["Pkey_AudioFormat"]) == pkey)
                                {
                                    Language = row["languageid"].ToString();
                                    AudioPath = row["AudioPath"].ToString();
                                    AudioName = row["AudioName"].ToString();
                                    Sequence = row["sequence"].ToString();
                                    platform = row["platformstatus"].ToString();
                                    Status = row["trainstatus"].ToString();

                                    break;
                                }
                            }

                            pnlAudioScriptCreate.Visible = true;
                            pnlCreateNewAudioScript.Visible = true;
                            lblCreateNewAudioScript.Text = "Edit Audio Script";
                            btnSave.Text = "  Update";




                            int languageIndex = int.Parse(Language);
                            DataTable AnnouncementDatatable = CommonSettingsDb.GetAnnouncement();
                            // Assuming 'AnnouncementDatatable' is your DataTable and you want to get the "AnnouncementText" column
                            List<string> announcementList = AnnouncementDatatable.AsEnumerable()
                                                                                  .Select(row => row.Field<string>("LanguageName"))
                                                                                  .ToList();

                            if (languageIndex == 1)
                            {
                                cmbLanguageName.Text = "English";
                            }
                            else if (languageIndex == 2)
                            {
                                cmbLanguageName.Text = "Hindi";
                            }
                            else
                            {
                                foreach (string s in announcementList)
                                {
                                    if (s != "English" && s != "Hindi")
                                        cmbLanguageName.Text = s;
                                }

                            }





                            int StatusMessageIndex = int.Parse(Status);
                            if (StatusMessageIndex >= 0 && StatusMessageIndex < cnbTrainStatus.Items.Count)
                            {

                                foreach (DataRow row in statusData.Rows)
                                {
                                    if (Convert.ToInt32(row["Pkey_Status"]) == StatusMessageIndex)
                                    {
                                        string selectedStatus = row["StatusName"].ToString();
                                        cnbTrainStatus.Text = selectedStatus;
                                        break;
                                    }
                                }
                            }
                            txtAudioPath.Text = AudioPath;
                            txtAudioName.Text = AudioName;
                            nudSequence.Text = Sequence;


                            int platformIndex = int.Parse(platform);
                            if (platformIndex >= 0 && platformIndex < CmbPlatformStatus.Items.Count)
                            {
                                CmbPlatformStatus.SelectedIndex = platformIndex;
                                CmbPlatformStatus.Text = CmbPlatformStatus.SelectedItem.ToString();
                            }



                            //CmbPlatformStatus.Text = platform;
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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static int GetLanguageId(int LanguageId)
        {


            int SequenceId = BaseClass.languageSequencepk[LanguageId];
            //foreach (int language in BaseClass.languageSequencepk)
            //{




            return 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {


            int selectedLanguageId;

            string selectedLanguage = cmbTrainLanguage.SelectedItem.ToString();
            if (selectedLanguage == "English")
            {
                selectedLanguageId = 1;
            }
            else if (selectedLanguage == "Hindi")
            {
                selectedLanguageId = 2;
            }
            else
            {
                selectedLanguageId = 3;
            }
            string audioPath = txtAudioPath.Text;
            string audioName = txtAudioName.Text;
            int sequence = Convert.ToInt32(nudSequence.Value);
            int trainstatus = Convert.ToInt32(cbmTrainStatus.SelectedValue);
            int platformStatus = CmbPlatformStatus.SelectedIndex;


            try
            {
                if (!string.IsNullOrWhiteSpace(audioPath) &&
                    !string.IsNullOrWhiteSpace(audioName) &&
                     sequence != 0)
                {
                    //int pk = pkey;


                    bool b = announcementScriptDb.InsertOrUpdateAudioScript(pkey, selectedLanguageId, audioPath, audioName, sequence, trainstatus, platformStatus);

                    if (b)
                    {
                        if (pkey == 0)
                        {
                            MessageBox.Show("Data saved successfully");
                        }
                        else
                        {
                            MessageBox.Show("Data updated successfully");
                        }


                        pnlAudioScriptCreate.Visible = false;
                        btnAddAudioScript.Refresh();
                        txtAudioName.Text = "";
                        nudSequence.Text = "0";


                    }
                    else
                    {
                        MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(audioPath))
                    {

                        pbCrossAudioPath.Visible = true;
                        lblAudioPathValidation.Visible = true;


                    }
                    if (string.IsNullOrWhiteSpace(audioName))
                    {

                        pbCrossAudioName.Visible = true;
                        lblAudioNameValidation.Visible = true;
                    }
                    if (sequence != 0)
                    {
                        pbCrossSequence.Visible = true;
                        lblSequenceValidation.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }



        }

        private void frmAnnounceMentScript_Click(object sender, EventArgs e)
        {
            pnlAudioScriptCreate.Visible = false;
        }

        private void cbmTrainStatus_Click(object sender, EventArgs e)
        {
            pnlAudioScriptCreate.Visible = false;
        }

        private void txtAudioName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAudioName.Text))
            {
                //lblValidateTrainNo.Text = "Enter a train number.";
                pbTickAudioName.Visible = false;
                lblAudioNameValidation.Visible = true;
                pbCrossAudioName.Visible = true;
            }
            else
            {
                //lblValidateTrainNo.Text = "";
                pbCrossAudioName.Visible = false;
                lblAudioNameValidation.Visible = false;
                pbTickAudioName.Visible = true;
            }
        }

        private void txtAudioName_Leave(object sender, EventArgs e)
        {
            //    if (string.IsNullOrWhiteSpace(txtAudioName.Text))
            //    {
            //        //lblValidateTrainNo.Text = "Enter a train number.";
            //        pbTickAudioName.Visible = false;
            //        lblAudioNameValidation.Visible = true;
            //        pbCrossAudioName.Visible = true;
            //    }
            //    else
            //    {
            //        //lblValidateTrainNo.Text = "";
            //        pbCrossAudioName.Visible = false;
            //        lblAudioNameValidation.Visible = false;
            //        pbTickAudioName.Visible = true;
            //    }
        }

        private void txtAudioPath_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtAudioPath.Text))
                {

                    pbTickAudioPath.Visible = false;
                    lblAudioPathValidation.Visible = true;
                    pbCrossAudioPath.Visible = true;
                }
                else
                {
                    pbCrossAudioPath.Visible = false;
                    lblAudioPathValidation.Visible = false;
                    pbTickAudioPath.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
    }
}
