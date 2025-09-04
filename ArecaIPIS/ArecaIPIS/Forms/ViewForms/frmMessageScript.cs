using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.ViewForms
{

    public partial class frmMessageScript : Form
    {
        private PaginationHelperClass paginationHelper;
        private DataTable reportData;
        private DataTable statusData;

        messageScriptDb messagescriptDb = new messageScriptDb();
        private int initialDataGridViewHeight;
        public frmMessageScript()
        {
            InitializeComponent();

            reportData = new DataTable();
        }


        private frmHome parentForm;
        public frmMessageScript(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            reportData = new DataTable();
            initialDataGridViewHeight = dgvMessageScriptTable.Height;
        }

        private void frmMessageScript_Load(object sender, EventArgs e)
        {
            try
            {


                //cmbPlatform.Enabled = true;
                dgvMessageScriptTable.EnableHeadersVisualStyles = false;
                dgvMessageScriptTable.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                toolTip1.SetToolTip(btnAddMessage, "Add New Message Script");
                dgvMessageScriptTable.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(dgvMessageScriptTable_CellToolTipTextNeeded);

                LoadMessageStatus();
                LoadTrainPosition();
                LoadLanguage();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void dgvMessageScriptTable_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgvMessageScriptTable.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                {
                    e.ToolTipText = "Edit";
                }
            }

        }

        private void LoadMessageStatus()
        {
            DataTable messagesTable = messagescriptDb.GetAllMessageStatus();

            if (messagesTable.Columns.Count >= 2)
            {
                DataRow selectRow = messagesTable.NewRow();
                selectRow[0] = 0;
                selectRow[1] = "-Select-";
                messagesTable.Rows.InsertAt(selectRow, 0);

                cmbMessages.DataSource = messagesTable;
                //cmbStatusMessage.DataSource = messagesTable;
                //cmbStatusMessage.DisplayMember = messagesTable.Columns[1].ColumnName;
                cmbMessages.DisplayMember = messagesTable.Columns[1].ColumnName;
                cmbMessages.ValueMember = messagesTable.Columns[0].ColumnName;

                statusData = messagesTable.Copy();
            }
            else
            {
                MessageBox.Show("The table does not have a second column.");
            }
        }




        private void LoadTrainPosition()
        {
            try
            {


                DataTable trainPosition = messagescriptDb.GetAllTrainPosition();

                if (trainPosition.Columns.Count >= 0)
                {
                    DataRow selectRow = trainPosition.NewRow();
                    selectRow[0] = 0;
                    selectRow[1] = "-Select-";

                    trainPosition.Rows.InsertAt(selectRow, 0);

                    cmbPlatform.DataSource = trainPosition;
                    cmbPlatform.DisplayMember = trainPosition.Columns[1].ColumnName;
                    cmbPlatform.ValueMember = trainPosition.Columns[1].ColumnName;

                    cmbPosition.DataSource = trainPosition;
                    cmbPosition.DisplayMember = trainPosition.Columns[1].ColumnName;
                    cmbPosition.ValueMember = trainPosition.Columns[1].ColumnName;
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


                DataTable Languge = messageScriptDb.GetLanguage();
                cmbTrainLanguage.Items.Clear();

                if (Languge.Columns.Count >= 2)
                {
                    cmbTrainLanguage.Items.Add("-Select-");
                    cmbLanguageName.Items.Add("-Select-");
                    foreach (DataRow row in Languge.Rows)
                    {

                        cmbTrainLanguage.Items.Add($"{row[2]}");
                        cmbLanguageName.Items.Add($"{row[2]}");
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


        private void cmbMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {



                if (cmbPlatform.Items.Count > 0)
                {
                    if (cmbMessages.SelectedIndex >= 0 && cmbMessages.SelectedIndex <= 4)
                    {
                        cmbPlatform.SelectedIndex = 0;
                        cmbPlatform.Enabled = false;
                    }
                    else if (cmbMessages.SelectedIndex == 5)
                    {
                        cmbPlatform.Enabled = true;
                        if (cmbPlatform.Items.Count > 0)
                        {
                            cmbPlatform.SelectedIndex = 0;
                        }
                    }
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

                dgvMessageScriptTable.AutoGenerateColumns = false;

                dgvMessageScriptTable.Columns["MessagePath"].DataPropertyName = "MessagePath";
                dgvMessageScriptTable.Columns["MessageName"].DataPropertyName = "MessageName";
                dgvMessageScriptTable.Columns["Sequence"].DataPropertyName = "sequence";

                if (!dgvMessageScriptTable.Columns.Contains("Pkey_MessageFormat"))
                {
                    DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Pkey_MessageFormat",
                        HeaderText = "Pkey_MessageFormat",
                        Name = "Pkey_MessageFormat",
                        Visible = false
                    };
                    dgvMessageScriptTable.Columns.Add(pkeyColumn);
                }
                else
                {
                    dgvMessageScriptTable.Columns["Pkey_MessageFormat"].DataPropertyName = "Pkey_MessageFormat";
                    dgvMessageScriptTable.Columns["Pkey_MessageFormat"].Visible = false;
                }
                dgvMessageScriptTable.DataSource = currentPageData;


                int dataGridViewNewHeight;

                // Adjust the height of the DataGridView
                if (currentPageData.Rows.Count < visibleRowsCount)
                {
                    dataGridViewNewHeight = (currentPageData.Rows.Count * dgvMessageScriptTable.RowTemplate.Height)
                                            + dgvMessageScriptTable.ColumnHeadersHeight
                                            + 2;
                }
                else
                {
                    dataGridViewNewHeight = (visibleRowsCount * dgvMessageScriptTable.RowTemplate.Height)
                                            + dgvMessageScriptTable.ColumnHeadersHeight
                                            + 2;
                }


                dgvMessageScriptTable.Height = dataGridViewNewHeight;

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

        private void btnView_Click(object sender, EventArgs e)
        {
            Updategrid();
        }
        public void Updategrid()
        {

            try
            {


                int selectedStatus = cmbMessages.SelectedIndex;
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

                int selectedPosition = cmbPlatform.SelectedIndex;
                showData(selectedStatus, selectedLanguageId, selectedPosition);
                //lblNoDataToDisplay.Visible = false;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        int visibleRowsCount = 0;
        public void showData(int selectedStatus, int selectedLanguageId, int selectedPosition)
        {
            try
            {



                DataTable messsageFormat = messagescriptDb.GetMessageFormat(selectedStatus, selectedLanguageId, selectedPosition);

                if (messsageFormat != null && messsageFormat.Rows.Count > 0)
                {

                    reportData.Clear();
                    reportData.Columns.Clear();

                    reportData = messsageFormat.Copy();
                    dgvMessageScriptTable.Height = initialDataGridViewHeight;

                    visibleRowsCount = (dgvMessageScriptTable.Height / dgvMessageScriptTable.RowTemplate.Height) - 1;

                    paginationHelper = new PaginationHelperClass(reportData, visibleRowsCount);
                    UpdateDataGridView();

                    lblNoDataToDisplay.Visible = false;
                    pnlPagination.Visible = true;
                }
                else
                {
                    lblNoDataToDisplay.Visible = true;
                    pnlPagination.Visible = false;

                    reportData = messsageFormat.Copy();
                    //foreach (DataColumn column in messsageFormat.Columns)
                    //{
                    //    dgvMessageScriptTable.Columns.Add(column.ColumnName, column.ColumnName);
                    //    dgvMessageScriptTable.Columns[column.ColumnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //}
                    dgvMessageScriptTable.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }

        private void btnAddMessage_Click(object sender, EventArgs e)
        {
            try
            {


                pkey = 0;
                cmbStatusMessage.DataSource = statusData;
                cmbStatusMessage.DisplayMember = statusData.Columns[1].ColumnName;
                cmbStatusMessage.ValueMember = statusData.Columns[0].ColumnName;
                pnlMessageAudioScript.Visible = true;
                pnlCreateMessageAudioScript.Visible = true;
                lblCreateMessageAudioScript.Text = "Create New Message Audio Script";
                btnSave.Text = "    Save";
                if (cmbStatusMessage.Items.Count > 1)
                {
                    cmbStatusMessage.SelectedIndex = 0;
                }

                cmbLanguageName.SelectedIndex = 1;
                lblNoFileChosen.Text = "";
                cmbMessageName.SelectedIndex = 0;
                nupSequence.Text = "0";
                cmbPosition.SelectedIndex = 0;

                lblMessagepathValidation.Visible = false;
                pbCrossMessagePath.Visible = false;
                pbCross.Visible = false;
                lblMessageNameValidation.Visible = false;
                lblStatusValidation.Visible = false;
                pbCrossStatus.Visible = false;
                pbTickStatus.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        int pkey;
        private void dgvMessageScriptTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                cmbStatusMessage.DataSource = statusData;
                cmbStatusMessage.DisplayMember = statusData.Columns[1].ColumnName;
                cmbStatusMessage.ValueMember = statusData.Columns[0].ColumnName;
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    try
                    {
                        int pkeyValue = Convert.ToInt32(dgvMessageScriptTable.Rows[e.RowIndex].Cells["Pkey_MessageFormat"].Value);
                        DataTable Message = messagescriptDb.GetMessageFormatByRow(pkeyValue);

                        if (Message != null && Message.Rows.Count > 0)
                        {
                            pkey = pkeyValue;


                            string Language = Message.Rows[0]["LanguageId"].ToString();
                            string MessagePath = Message.Rows[0]["MessagePath"].ToString();
                            string MessageName = Message.Rows[0]["MessageName"].ToString();
                            string Sequence = Message.Rows[0]["sequence"].ToString();
                            string position = Message.Rows[0]["PfStatus"].ToString();
                            string StatusMessage = Message.Rows[0]["StatusMessage"].ToString();

                            pnlMessageAudioScript.Visible = true;
                            pnlCreateMessageAudioScript.Visible = true;
                            lblCreateMessageAudioScript.Text = "Edit Message Audio Script";
                            btnSave.Text = "    Update";


                            int languageIndex = int.Parse(Language);
                            DataTable AnnouncementDatatable = CommonSettingsDb.GetAnnouncement();
                            // Assuming 'AnnouncementDatatable' is your DataTable and you want to get the "AnnouncementText" column
                            List<string> announcementList = AnnouncementDatatable.AsEnumerable().Select(row => row.Field<string>("LanguageName")).ToList();

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

                            int StatusMessageIndex = int.Parse(StatusMessage);
                            if (StatusMessageIndex >= 0 && StatusMessageIndex < cmbStatusMessage.Items.Count)
                            {
                                cmbStatusMessage.SelectedIndex = StatusMessageIndex;
                                //cmbStatusMessage.Text = cmbStatusMessage.SelectedItem.ToString();

                                object selectedItem = cmbStatusMessage.SelectedItem;
                                if (selectedItem != null)
                                {
                                    string displayedText = ((DataRowView)selectedItem).Row[1].ToString();
                                    cmbStatusMessage.Text = displayedText;
                                }
                            }

                            lblNoFileChosen.Text = MessagePath;
                            cmbMessageName.Text = MessageName;
                            nupSequence.Text = Sequence;

                            int positionIndex = int.Parse(position);
                            //if (positionIndex >= 0 && positionIndex < cmbPosition.Items.Count)
                            //{
                            //    cmbPosition.SelectedIndex = positionIndex;
                            //    cmbPosition.Text = cmbPosition.SelectedValue.ToString();
                            //}

                            if (positionIndex == 0)
                            {
                                cmbPosition.Text = "";
                            }
                            else if (positionIndex > 0 && positionIndex < cmbPosition.Items.Count)
                            {
                                cmbPosition.SelectedIndex = positionIndex;
                                cmbPosition.Text = cmbPosition.SelectedValue.ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No data retrieved from the database.");
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
                ex.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlMessageAudioScript.Visible = false;
            pnlCreateMessageAudioScript.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            int LanguageId;


            string selectedLanguage = cmbTrainLanguage.SelectedItem.ToString();
            if (selectedLanguage == "English")
            {
                LanguageId = 1;
            }
            else if (selectedLanguage == "Hindi")
            {
                LanguageId = 2;
            }
            else
            {
                LanguageId = 3;
            }
            string messagePath = lblNoFileChosen.Text;
            string MessageName = cmbMessageName.Text;
            decimal sequence = nupSequence.Value;
            int selectedstatus = cmbStatusMessage.SelectedIndex;
            //int position = cmbPosition.SelectedIndex;
            int position = 0;
            if (cmbPosition.SelectedIndex == -1)
            {
                position = 0;
            }
            else
            {
                position = cmbPosition.SelectedIndex;
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(messagePath) &&
                     MessageName != "Select" && selectedstatus != 0)
                {
                    int pk = pkey;


                    bool b = messagescriptDb.InsertOrUpdateMessageScript(pk, LanguageId, messagePath, MessageName, sequence, selectedstatus, position);

                    if (b)
                    {
                        if (pk == 0)
                        {
                            MessageBox.Show("Data saved successfully");
                        }
                        else
                        {
                            MessageBox.Show("Data updated successfully");

                        }
                        Updategrid();
                        pnlMessageAudioScript.Visible = false;
                        pnlCreateMessageAudioScript.Visible = false;

                    }
                    else
                    {
                        MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(messagePath))
                    {

                        pbCrossMessagePath.Visible = true;
                        lblMessagepathValidation.Visible = true;
                    }
                    if (string.IsNullOrWhiteSpace(MessageName) || MessageName == "Select")
                    {

                        pbCross.Visible = true;
                        lblMessageNameValidation.Visible = true;
                    }

                    if (selectedstatus == 0)
                    {
                        lblStatusValidation.Visible = true;
                        pbCrossStatus.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
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

                lblNoFileChosen.Text = filePath;
            }
        }

        private void cmbMessages_Click(object sender, EventArgs e)
        {
            pnlMessageAudioScript.Visible = false;
            pnlCreateMessageAudioScript.Visible = false;
        }

        private void lblNoFileChosen_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblNoFileChosen.Text))
            {
                pbTickMessagePath.Visible = false;
                pbCrossMessagePath.Visible = true;
                lblMessagepathValidation.Visible = true;
            }
            else
            {
                pbTickMessagePath.Visible = true;
                pbCrossMessagePath.Visible = false;
                lblMessagepathValidation.Visible = false;
            }
        }

        private void cmbMessageName_TextChanged(object sender, EventArgs e)
        {
            if (cmbMessageName.Text == "Select")
            {
                pbTick.Visible = false;
                pbCross.Visible = true;
                lblMessageNameValidation.Visible = true;
            }
            else
            {
                pbTick.Visible = true;
                pbCross.Visible = false;
                lblMessageNameValidation.Visible = false;
            }
        }

        private void cmbStatusMessage_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {


                if (cmbMessageName.Text == "0")
                {
                    pbTickStatus.Visible = false;
                    lblStatusValidation.Visible = true;
                    pbCrossStatus.Visible = true;
                }
                else
                {
                    pbTickStatus.Visible = true;
                    lblStatusValidation.Visible = false;
                    pbCrossStatus.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
