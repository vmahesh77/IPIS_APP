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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.HomeForms
{

    public partial class frmSlogans : Form
    {
        private DataTable reportData;

        SloganDb sloganDb = new SloganDb();
        private const string PlaceholderText = "Search here...";
        public frmSlogans()
        {
            InitializeComponent();
            reportData = new DataTable();
        }
        private void frmSlogans_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeControls();
                PauseButtonCheck();
                txtSearch.Text = PlaceholderText;
                txtSearch.ForeColor = Color.Gray;
                dgvSlogan.EnableHeadersVisualStyles = false;
                dgvSlogan.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;


                foreach (DataGridViewColumn column in dgvSlogan.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }

                toolTipSlogan.SetToolTip(btnAddSloganMessage, "Add New Message");
                toolTipSlogan.SetToolTip(btnSendMessage, "Send Selected Messages");
                toolTipSlogan.SetToolTip(btnPlayMessage, "Play");
                toolTipSlogan.SetToolTip(btnStopMessage, "Stop");
                toolTipSlogan.SetToolTip(btnPauseMessage, "Pause");
                //toolTipSlogan.IsBalloon = true;
                dgvSlogan.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(dgvSlogan_CellToolTipTextNeeded);
                InitializeForm();
                LoadLanguage();
                SetBoards();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        DataTable boards = new DataTable();
        public void SetBoards()
        {
            List<int> packetIdentifiers = new List<int> { 3, 5, 6, 7 };
            boards.Clear();
            // Fetch data from the database
            boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

            foreach (DataRow row in boards.Rows)
            {
                cmbBoardType.Items.Add(row["Location"]);

            }
            if (cmbBoardType.Items.Count > 0)
            {
                cmbBoardType.SelectedIndex = 0;
            }

        }
        private void dgvSlogan_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            try
            {


                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    if (dgvSlogan.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                    {
                        e.ToolTipText = "Edit";
                    }
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == 3)
                {
                    if (dgvSlogan.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                    {
                        e.ToolTipText = "Delete";
                    }
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                    if (dgvSlogan.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        e.ToolTipText = "Select";
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private frmHome parentForm;

        public frmSlogans(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }



        private void btnAddSloganMessage_Click(object sender, EventArgs e)
        {
            try
            {


                pkey = 0;
                pnlFormShow.Visible = true;
                pnlCreate.Visible = true;
                pnlMessageAnnouncement.Visible = false;
                txtMessage.Text = "";
                lblFile.Text = "";
                lblCreateMessage.Text = "Create Message";
                btnSave.Text = "    Save";
                pbCross.Visible = false;
                //pbTickFile.Visible = false;
                lblShowingAudio.Visible = false;
                lblMessageValidation.Visible = false;
                LoadLanguage();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void UpdateDataGridView(DataTable dt)
        {
            try
            {
                dgvSlogan.AutoGenerateColumns = false;

                dgvSlogan.Columns["Message"].DataPropertyName = "Message";
                dgvSlogan.Columns["dgvSloganLanguage"].DataPropertyName = "Lang_Fkey";

                if (!dgvSlogan.Columns.Contains("Pkey_SpclMsgs"))
                {
                    DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn();
                    pkeyColumn.DataPropertyName = "Pkey_SpclMsgs";
                    pkeyColumn.HeaderText = "Pkey_SpclMsgs";
                    pkeyColumn.Name = "Pkey_SpclMsgs";
                    pkeyColumn.Visible = false;
                    dgvSlogan.Columns.Add(pkeyColumn);
                }
                else
                {
                    dgvSlogan.Columns["Pkey_SpclMsgs"].DataPropertyName = "Pkey_SpclMsgs";
                    dgvSlogan.Columns["Pkey_SpclMsgs"].Visible = false;
                }
                dgvSlogan.DataSource = dt;

                dgvSlogan.AllowUserToAddRows = false;

                //int totalHeight = dgvSlogan.ColumnHeadersHeight;
                //foreach (DataGridViewRow row in dgvSlogan.Rows)
                //{
                //    totalHeight += row.Height;
                //}
                //dgvSlogan.Height = totalHeight;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }






        private void InitializeForm()
        {

            try
            {


                dgvSlogan.RowTemplate.Height = 50;

                DataTable specialMessages = sloganDb.GetSloganMessages();

                reportData = specialMessages.Copy();

                if (specialMessages != null)

                {

                    dgvSlogan.AutoGenerateColumns = true;
                    reportData.Clear();
                    reportData.Columns.Clear();


                    reportData = specialMessages.Copy();

                    chkFilter.Items.Clear();
                    int c = 0;
                    foreach (DataColumn column in reportData.Columns)
                    {

                        if (c > 0)
                        {
                            chkFilter.Items.Add(column.ColumnName);
                        }

                        c++;
                    }

                    for (int i = 0; i < chkFilter.Items.Count; i++)
                    {
                        chkFilter.SetItemChecked(i, true);
                        chkFilter.BackColor = Color.LightSalmon;
                    }
                }
                UpdateDataGridView(specialMessages);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void LoadLanguage()
        {
            try
            {


                DataTable Languge = sloganDb.GetLanguage();
                cmbLanguage.Items.Clear();

                if (Languge.Columns.Count >= 2)
                {


                    //cmbLanguage.Items.Add($"{row[2]}");
                    cmbLanguage.DataSource = Languge;
                    cmbLanguage.DisplayMember = Languge.Columns[2].ColumnName;
                    cmbLanguage.ValueMember = Languge.Columns[1].ColumnName;



                    cmbLanguage.SelectedIndex = 0;

                }
                else
                {
                    MessageBox.Show("The table does not have at least two columns.");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        int pkey;
        private void dgvSlogan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    int pkeyValue = Convert.ToInt32(dgvSlogan.Rows[e.RowIndex].Cells["Pkey_SpclMsgs"].Value);
                    //MessageBox.Show(pkeyValue.ToString());
                    DataTable Slogan = sloganDb.GetSlogansByRow(pkeyValue);

                    if (Slogan != null && Slogan.Rows.Count > 0)
                    {
                        pkey = pkeyValue;
                        string Message = Slogan.Rows[0]["Message"].ToString();
                        string Language = Slogan.Rows[0]["LanguageName"].ToString();
                        string file = Slogan.Rows[0]["AudioFilePath"].ToString();

                        //frmCreateSloganMessage fCSM = new frmCreateSloganMessage();
                        //fCSM.SetSloganDetails(pkey, Message, Language, file);
                        //fCSM.FormClosedEvent += new EventHandler(frmCreateSloganMessage_FormClosed);
                        //OpenFormInPanel(fCSM);
                        pnlFormShow.Visible = true;
                        pnlCreate.Visible = true;
                        txtMessage.Text = Message;
                        cmbLanguage.Text = Language;
                        lblFile.Text = file;
                        lblCreateMessage.Text = "Edit Message";
                        btnSave.Text = "    Update";
                        pnlMessageAnnouncement.Visible = false;
                        //fcsm.Show();
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

            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                try
                {
                    int pkeyValue = Convert.ToInt32(dgvSlogan.Rows[e.RowIndex].Cells["Pkey_SpclMsgs"].Value);
                    DialogResult dResult = MessageBox.Show("Do you want to Delete the slogan?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dResult == DialogResult.No)
                    {
                        return;
                    }
                    string statusMessage = sloganDb.DeleteSlogan(pkeyValue);

                    MessageBox.Show(statusMessage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            UpdateDataGridView(filteredDataTable);
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
                ex.ToString();
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
            InitializeForm();
            btnSearch.Visible = true;
            btnCross.Visible = false;
            lblNoDataToDisplay.Visible = false;
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlFormShow.Visible = false;
            pnlCreate.Visible = false;
            pnlMessageAnnouncement.Visible = true;
        }

        private void txtMessage_Leave(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtMessage.Text))
                {
                    lblMessageValidation.Text = "Please Enter Message.";
                    lblMessageValidation.Visible = true;
                    pbCross.Visible = true;
                    //pbTick.Visible = false;
                    //txtEnglish.Focus();
                }
                else
                {
                    pbCross.Visible = false;
                    lblMessageValidation.Text = "";
                    lblMessageValidation.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtMessage.Text))
                {
                    lblMessageValidation.Text = "Please Enter Message.";
                    lblMessageValidation.Visible = true;
                    //pbTick.Visible = false;
                    pbCross.Visible = true;

                }
                else
                {
                    lblMessageValidation.Visible = false;
                    //pbTick.Visible = true;
                    pbCross.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            openFileDialogs.Filter = "Media Files(*.wav; *.mp3)|*.wav;*.mp3";
            openFileDialogs.Multiselect = false;

            string initialDirectory = @"E:\Audio";


            if (Directory.Exists(initialDirectory))
            {
                openFileDialogs.InitialDirectory = initialDirectory;
            }
            else
            {

                openFileDialogs.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }




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
                    //pbTickFile.Visible = true;
                }
                else
                {
                    lblShowingAudio.Text = "Please choose an audio file.";
                    lblShowingAudio.Visible = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred while selecting the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int pKey_SpecialMessage = pkey;
            string Msg = txtMessage.Text;
            string audioFilePath = lblFile.Text;
            int languageid = Convert.ToInt32(cmbLanguage.SelectedValue);


            //MessageBox.Show("Selected Language Value: " + language);

            try
            {
                if (!string.IsNullOrWhiteSpace(Msg) &&
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

                    bool b = sloganDb.InsertOrUpdateSlogan(pKey_SpecialMessage, Msg, audioFilePath, languageid);

                    if (b)
                    {
                        MessageBox.Show("Data saved/updated successfully");
                        pnlFormShow.Visible = false;
                        SetBoards();
                        pnlMessageAnnouncement.Visible = true;

                    }
                    else
                    {
                        MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(Msg))
                    {
                        lblMessageValidation.Text = "Please Enter Message .";
                        lblMessageValidation.Visible = true;
                        txtMessage.Focus();
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // InitializeForm();
            //    SetBoards();
            UpdateDataGridView(sloganDb.GetSloganMessages());
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
                    //pbTickFile.Visible = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }





        private ConcurrentDictionary<string, WaveOutEvent> activePlayers = new ConcurrentDictionary<string, WaveOutEvent>();
        private ConcurrentDictionary<string, AudioFileReader> activeAudioFiles = new ConcurrentDictionary<string, AudioFileReader>();
        private ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);
        private bool isPaused = false;
        private List<string> audioPaths = new List<string>();

        public static TaskCompletionSource<bool> pauseCompletionSource = new TaskCompletionSource<bool>();


        private async void btnPlayMessage_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dResult = MessageBox.Show("Do you want to play the audio?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dResult == DialogResult.No)
                {
                    return;
                }
                //btnPauseMessage.Text = "Pause";
                int nupMessageValue = (int)nupMessage.Value;
                List<string> selectedPrimaryKeys = new List<string>();

                foreach (DataGridViewRow row in dgvSlogan.Rows)
                {
                    DataGridViewCheckBoxCell chk = row.Cells[2] as DataGridViewCheckBoxCell;

                    if (chk != null && Convert.ToBoolean(chk.Value))
                    {
                        string primaryKey = row.Cells["Pkey_SpclMsgs"].Value.ToString();
                        selectedPrimaryKeys.Add(primaryKey);
                    }
                }

                if (selectedPrimaryKeys.Count == 0)
                {
                    MessageBox.Show("No items selected to play.");
                    return;
                }

                string primaryKeyString = string.Join(",", selectedPrimaryKeys);
                DataTable resultMessage = sloganDb.GetSplMessagestoPlay(primaryKeyString, nupMessageValue);

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
                                audioPaths.Add(stringValue);
                            }
                        }
                    }
                    if (AnnouncementController.OtherAudioPlaying)
                    {
                        MessageBox.Show("Other Audio is Playing");

                    }
                    else
                    {
                        AnnouncementController.OtherAudioPlaying = true;
                        AnnouncementController.cts = new CancellationTokenSource();
                        // await AnnouncementController.PlayAudioSet(audioPaths, nupMessageValue, AnnouncementController.cts.Token);
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
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

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
                            HandleAudioErrors(filePath);
                        }
                    }
                    await Task.Delay(100, token);
                }

                if (completedAudios == audioPaths.Count * playCount)
                {
                    UpdateAudioPlayStatus("Completed");
                }
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error playing audio set: {ex.Message}");
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
                //MessageBox.Show(ex.Message);
            }
        }
        private static void HandleAudioErrors(string filePath)
        {
            MessageBox.Show($"'{filePath}'", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void UpdateAudioPlayStatus(string action)
        {
            try
            {
                bool successAction = sloganDb.UpdateAudioPlayStatus(action);

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
                MessageBox.Show($"Error updating audio play status: {ex.Message}");
            }
        }



        private void btnStopMessage_Click(object sender, EventArgs e)
        {
            AnnouncementController.OtherAudioPlaying = false;
            DialogResult dResult = MessageBox.Show("Do you want to stop the play?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dResult == DialogResult.No)
            {
                return;
            }
            AnnouncementController.UpdateStatus("STOP");
            AnnouncementController.UpdateAudioPlayStatus("Completed");
            btnPauseMessage.Text = "Pause";
        }

        private void btnPauseMessage_Click(object sender, EventArgs e)
        {
            if (AnnouncementController.OtherAudioPlaying)
            {
                AnnouncementController.UpdateStatus("PAUSE");
                AnnouncementController.CheckPauseButtonClick();
                PauseButtonCheck();

            }
        }
        private void PauseButtonCheck()
        {
            if (AnnouncementController.PauseButtonStatus)
            {
                btnPauseMessage.Text = "Resume";

            }
            else
            {

                btnPauseMessage.Text = "Pause";
            }
        }

        public void PauseAudio(string alertValue)
        {
            try
            {


                if (alertValue == "PAUSE")
                {
                    ResumeAllAudio();
                    if (btnPauseMessage != null)
                    {
                        string lowerCaseAlertValue = alertValue.ToLower();

                        string formattedAlertValue = char.ToUpper(lowerCaseAlertValue[0]) + lowerCaseAlertValue.Substring(1);

                        btnPauseMessage.Text = formattedAlertValue;
                    }
                }
                else
                {
                    PauseAllAudio();
                    if (btnPauseMessage != null)
                    {
                        string lowerCaseAlertValue = alertValue.ToLower();

                        string formattedAlertValue = char.ToUpper(lowerCaseAlertValue[0]) + lowerCaseAlertValue.Substring(1);

                        btnPauseMessage.Text = formattedAlertValue;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        public void PauseAllAudio()
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

        public void ResumeAllAudio()
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



        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(650, 150, "Hindi");
        }

        private void InitializeControls()
        {
            txtMessage.Enter += Control_Enter;
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
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public bool checkSlogans()
        {
            try
            {


                SlogansController.CheckedSlogans.Clear();

                foreach (DataGridViewRow row in dgvSlogan.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (Convert.ToBoolean(row.Cells["select"].EditedFormattedValue))
                        {
                            SlogansController.CheckedSlogans.Add(row);
                        }
                    }
                }

                if (SlogansController.CheckedSlogans.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return false;
        }




        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {

                Server.getBoardsIpAdress();
                bool check = checkSlogans();
                if (check)
                {
                    if (Server._connectedClients.Count > 0)
                    {
                        try
                        {
                            sendSlogans();
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Please Click Atleast One Message");
                }
            }
            catch (Exception e1)
            {
                e1.ToString();
            }
        }


        public void sendSlogans()
        {
            if (txtBoardId.Text != "ALL")
            {
                SlogansController.SlogansIp = txtBoardId.Text.ToString().Trim();
                SendSlogansData();
            }
            else
            {
                foreach (string ip in Server.IvdIpAdress)
                {

                    SlogansController.SlogansIp = ip;
                    SendSlogansData();
                }
                foreach (string ip in Server.OvdIpAdress)
                {

                    SlogansController.SlogansIp = ip;
                    SendSlogansData();
                }
                foreach (string ip in Server.PfdbIpAdress)
                {

                    SlogansController.SlogansIp = ip;
                    SendSlogansData();
                }
                foreach (string ip in Server.MldbIpAdress)
                {

                    SlogansController.SlogansIp = ip;
                    SendSlogansData();
                }

            }

        }


        public void SendSlogansData()
        {

            PacketController.currentIp = SlogansController.SlogansIp;
            BaseClass.boardType = SlogansController.getBoard();

            BaseClass.defectiveLines = OnlineTrainsDao.getDefectiveLines(PacketController.currentIp);
            SlogansController.SlogansDataPacket();
            byte[] finalPacket = MessageController.getMessagesFullPacket(SlogansController.boardIdentifier, Server.ipAdress, SlogansController.SlogansIp, BaseClass.GetSerialNumber(), Board.MessageData);
            if (BaseClass.boardWorkingstatus)
                Server.SendMessageToClient(SlogansController.SlogansIp, finalPacket);
            string a = BaseClass.ByteArrayToString(finalPacket);
        }

        private void cmbBoardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                string BoardName = cmbBoardType.Text;
                if (BoardName == "ALL")
                {
                    txtBoardId.Text = "ALL";
                    txtBoardId.BackColor = SystemColors.Window;
                }
                else
                {
                    foreach (DataRow row in boards.Rows)
                    {
                        //cmbBoardName.Items.Add(row["Location"]);
                        if (boards.Columns.Contains("Location"))
                        {

                            string name = row["Location"].ToString().Trim();
                            if (name.Equals(BoardName))
                            {
                                string boardid = row["IPAddress"].ToString().Trim();
                                txtBoardId.Text = boardid;
                                txtBoardId.BackColor = SystemColors.Window;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }


        }

        private void pnlMessageAnnouncement_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

