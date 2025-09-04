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

namespace ArecaIPIS.Forms.HomeForms
{
    public partial class frmPa : Form
    {
        PaDb paDb = new PaDb();
        private WaveInEvent waveIn;
        private WaveFileWriter waveFileWriter;
        private string directoryPath = @"E:\Audio\AudioMessages";
        public frmPa()
        {
            InitializeComponent();


        }

        private frmIndex parentForm;
        public frmPa(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }

        private void frmPa_Load(object sender, EventArgs e)
        {
            PauseButtonCheck();
            LoadMessageStatus();
            LoadPlatformsNumber();
            cmbPosition.SelectedIndex = 0;
            addAudioPath();

            toolTip.SetToolTip(btnChooseFile, "Choose File");
            toolTip.SetToolTip(btnAdd, "Add To Playlist");
            toolTip.SetToolTip(btnPlay, "Play Spl Ann");
            toolTip.SetToolTip(btnStop, "Stop Spl Ann");
            toolTip.SetToolTip(btnRecord, "Record Spl Ann");
            toolTip.SetToolTip(btnStopRecording, "Stop Recording");
            toolTip.SetToolTip(btnPlayMessage, "Play");
            toolTip.SetToolTip(btnStopMessage, "Stop");
            toolTip.SetToolTip(btnPauseMessage, "Pause");
            toolTip.SetToolTip(nudPlaySpecAnnounce, "No of time to play Ann");
        }
        string FileName = "";
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            ofdSpecialAnnouncement.Filter = "Media Files(*.wav; *.mp3)|*.wav;*.mp3";
            ofdSpecialAnnouncement.Multiselect = false;



            string initialDirectory = @"E:\Audio";


            if (Directory.Exists(initialDirectory))
            {
                ofdSpecialAnnouncement.InitialDirectory = initialDirectory;
            }
            else
            {

                ofdSpecialAnnouncement.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }


            try
            {
                if (ofdSpecialAnnouncement.ShowDialog() == DialogResult.OK)
                {
                    lblFileName.Text = "";
                    lblFileName.Tag = null;
                    foreach (string file in ofdSpecialAnnouncement.FileNames)
                    {
                        string fileName = Path.GetFileName(file);

                        lblFileName.Text += file;
                        lblFileName.Tag = file;
                        FileName = fileName;

                    }
                }
                else
                {

                    lblFileName.Text = "No file chosen.";
                    lblFileName.Tag = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred while selecting the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = lblFileName.Text.Trim();
                string[] audioExtensions = { ".mp3", ".wav", ".aac", ".flac", ".ogg" };

                if (fileName != "No File Chosen" && audioExtensions.Any(ext => fileName.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                {
                    string filePath = lblFileName.Tag as string;

                    string name = FileName;
                    bool dt = paDb.insertToCreatedataRecording(filePath, name, "0");

                    if (dt)
                    {
                        MessageBox.Show("Data Uploaded successfully");
                        addAudioPath();
                        lblFileName.Text = "No File Chosen";
                    }
                    else
                    {
                        MessageBox.Show("Upload error");
                    }
                }
                else
                {
                    MessageBox.Show("Please choose a file first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataTable audioPathDataTable;
        private void addAudioPath()
        {
            try
            {


                DataTable dataTable = paDb.GET_AudioNames();
                lbFileSpecialAnnouncement.Items.Clear();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string audioName = row["Data"].ToString();
                        lbFileSpecialAnnouncement.Items.Add(audioName);
                    }
                    audioPathDataTable = dataTable;
                }
                else
                {
                    lbFileSpecialAnnouncement.Items.Add("No Data");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        private ConcurrentDictionary<string, WaveOutEvent> activePlayers = new ConcurrentDictionary<string, WaveOutEvent>();
        private ConcurrentDictionary<string, AudioFileReader> activeAudioFiles = new ConcurrentDictionary<string, AudioFileReader>();
        private ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);
        private static bool isPaused = false;

        public static TaskCompletionSource<bool> pauseCompletionSource = new TaskCompletionSource<bool>();
        private List<string> audioPaths = new List<string>();
        private async void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {


                DialogResult dResult = MessageBox.Show("Do you want to play the audio?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dResult == DialogResult.No)
                {
                    return;
                }
                if (AnnouncementController.OtherAudioPlaying)
                {
                    MessageBox.Show("Other Audio is playing");
                }
                else
                {
                    AnnouncementController.OtherAudioPlaying = true;
                    audioPaths.Clear();
                    string pkeysplmsg = "";
                    int playNoofAnn = (int)nudPlaySpecAnnounce.Value;
                    string AudioFiles = "";
                    bool playflag = false;
                    string name = "";
                    try
                    {
                        if (lbFileSpecialAnnouncement.SelectedItem != null)
                        {
                            name = lbFileSpecialAnnouncement.SelectedItem.ToString();

                        }
                        else
                        {
                            MessageBox.Show("No items selected to play.");
                            return;
                        }

                        if (audioPathDataTable != null && audioPathDataTable.Rows.Count > 0)
                        {
                            foreach (DataRow row in audioPathDataTable.Rows)
                            {
                                if (row["Data"].ToString() == name)
                                {
                                    pkeysplmsg = row["Pkey_SpclMessages"].ToString();
                                    break;
                                }
                            }
                        }

                        DataTable ds = paDb.CheckSplAnn(Convert.ToInt16(pkeysplmsg.ToString()));
                        string AudioPath = ds.Rows[0]["Audio_String"].ToString();

                        if (!File.Exists(AudioPath))
                        {
                            playflag = true;
                        }
                        else
                        {
                            audioPaths.Add(AudioPath);
                        }

                        if (!playflag)
                        {
                            string pkeySplmsg = string.Join(",", pkeysplmsg);
                            DataTable announcement = paDb.PlaySplAnnouc(pkeySplmsg, playNoofAnn);
                            if (announcement.Rows.Count > 0)
                            {
                                string status = announcement.Rows[0]["Alert"].ToString();
                                if (status.Contains("Audio is started playing"))
                                {
                                    AnnouncementController.cts = new CancellationTokenSource();



                                    // await AnnouncementController.PlayAudioSet(audioPaths, playNoofAnn, AnnouncementController.cts.Token);

                                    AudioManager.PlayAudioSet(audioPaths, playNoofAnn, AnnouncementController.cts.Token);
                                    
                                    //AnnouncementController.UpdateAudioPlayStatus("Completed");
                                }
                                else if (status.Contains("Other audio is Playing"))
                                {
                                    MessageBox.Show("Other audio is playing.");
                                }
                                else
                                {
                                    MessageBox.Show("Unexpected status: " + status);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No status information returned.");
                            }

                        }
                        else
                        {
                            string localstr = AudioFiles + " Audio Files don't exist.";

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
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dResult = MessageBox.Show("Do you want to stop the play?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dResult == DialogResult.No)
                {
                    return;
                }
                AnnouncementController.OtherAudioPlaying = false;
                AnnouncementController.UpdateStatus("STOP");
                AnnouncementController.UpdateAudioPlayStatus("Completed");
                btnPauseMessage.Text = "   Pause";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while stopping playback: {ex.Message}");
            }

        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dResult = MessageBox.Show("Do you want to record audio?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dResult == DialogResult.No)
                {
                    return;
                }

                waveIn = new WaveInEvent
                {
                    DeviceNumber = 0,
                    WaveFormat = new WaveFormat(44100, 16, 1)
                };

                string logDirectory = Path.GetDirectoryName(Path.Combine(directoryPath, "temp.wav"));
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                waveIn.DataAvailable += OnDataAvailable;
                waveIn.RecordingStopped += OnRecordingStopped;
                waveFileWriter = new WaveFileWriter(Path.Combine(directoryPath, "temp.wav"), waveIn.WaveFormat);
                waveIn.StartRecording();
                btnRecord.Enabled = false;
                btnStopRecording.Enabled = true;
                MessageBox.Show("Recording started.");
            }
            catch (Exception ex)
            {

                ex.ToString();
                //MessageBox.Show($"An error occurred while starting the recording: {ex.Message}");
            }
        }
        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            try
            {
                if (waveFileWriter != null)
                {
                    //Console.WriteLine($"Received {e.BytesRecorded} bytes of audio data.");

                    waveFileWriter.Write(e.Buffer, 0, e.BytesRecorded);
                    waveFileWriter.Flush();
                }
                else
                {
                    MessageBox.Show("WaveFileWriter is not initialized.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing audio data: {ex.Message}");
            }

        }

        private void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            try
            {
                waveFileWriter.Dispose();
                waveFileWriter = null;
                waveIn.Dispose();
                btnRecord.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while stopping the recording: {ex.Message}");
            }
        }

        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            try
            {
                waveIn.StopRecording();
                pnlSavingFile.Visible = true;
                MessageBox.Show("Recording stopped.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while stopping the recording: {ex.Message}");
            }
        }

        private void LoadMessageStatus()
        {
            DataTable messagesTable = paDb.GetAllMessageStatus();

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

        private void LoadPlatformsNumber()
        {
            foreach (string value in BaseClass.Platforms)
            {
                cmbPlatFormNo.Items.Add(value);
            }
            cmbPlatFormNo.SelectedIndex = 0;
        }

        private async void btnPlayMessage_Click(object sender, EventArgs e)
        {

            try
            {

                string TrainNum = txtTrainNo.Text;
                string Pfno = cmbPlatFormNo.SelectedItem.ToString();
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
                    MessageBox.Show("Other Audio is playing");
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

                    DataTable UpdatedFile = new DataTable();
                    var dt = "";
                    UpdatedFile.Columns.Add("LanguageID", typeof(int));
                    UpdatedFile.Columns.Add("Sequence", typeof(int));
                    UpdatedFile.Columns.Add("AudioFile", typeof(string));

                    var data = paDb.PlayTrainInfo(Convert.ToInt32(Status), Convert.ToInt32(Position));

                    foreach (DataRow row in data.Rows)
                    {
                        var fileName = row["MessageName"].ToString();
                        var LanguageID = row["LanguageId"].ToString();
                        var sequence = row["sequence"].ToString();
                        var AudioPath = row["MessagePath"].ToString();

                        string TrainNamepath = "";
                        string[] TrainNoAudiopath = new string[6];

                        var Traintype = paDb.GetTrainUpDownStatus(TrainNum);
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
                            //for (int j = 0; j < TrainNum.Length; j++)
                            //{
                            //    //TrainNoAudiopath[j] = pathstr + TrainNo[j] + ".wav";
                            //    TrainNoAudiopath[j] = AudioPath + TrainNum[j] + ".wav";
                            //}


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
                        DataTable dtAnnounce = paDb.PlayMsgAnnouncemnet(UpdatedFile, 1);

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
                                AnnouncementController.cts = new CancellationTokenSource();
                                List<string> audioPaths = UpdatedFile.AsEnumerable().Select(r => r.Field<string>("AudioFile")).ToList();
                                // await AnnouncementController.PlayAudioSet(audioPaths, 1, AnnouncementController.cts.Token);

                                AudioManager.PlayAudioSet(audioPaths, 1, AnnouncementController.cts.Token);
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
                        if (!BaseClass.IsNtesAudio() && !BaseClass.IsLocalAutoMode())
                            MessageBox.Show("No valid audio files found to update.");
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
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
            catch (OperationCanceledException)
            {
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
        private void UpdateAudioPlayStatus(string action)
        {
            try
            {
                bool successAction = paDb.UpdateAudioPlayStatus(action);

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

        private void txtTrainNo_Validated(object sender, EventArgs e)
        {
            string trainNum = txtTrainNo.Text;

            if (string.IsNullOrWhiteSpace(trainNum))
            {
                lblValidateTrainNo.Visible = true;
                txtTrainNo.BackColor = SystemColors.Window;
                cmbPlatFormNo.Items.Clear();
                LoadPlatformsNumber();
                return;

            }

            DataTable trainNo = paDb.ValidateTrainNo();

            bool trainExists = false;

            foreach (DataRow row in trainNo.Rows)
            {
                string existingTrainNum = row["TrainNo"].ToString();
                string platformNo = row["PlatformName"].ToString();
                if (existingTrainNum == trainNum)
                {
                    trainExists = true;
                    cmbPlatFormNo.Items.Clear();
                    cmbPlatFormNo.Items.Add(platformNo);
                    cmbPlatFormNo.SelectedIndex = 0;
                    break;
                }

            }

            if (trainExists)
            {
                txtTrainNo.BackColor = Color.LightGreen;

            }
            else
            {
                txtTrainNo.BackColor = SystemColors.Window;
                lblValidateTrainNo.Text = "Train No is not available";
                lblValidateTrainNo.Visible = true;
                cmbPlatFormNo.Items.Clear();
                LoadPlatformsNumber();
                txtTrainNo.Text = "";
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
            if (string.IsNullOrWhiteSpace(txtTrainNo.Text))
            {
                lblValidateTrainNo.Text = "Enter a train number.";
                lblValidateTrainNo.Visible = true;
                //txtTrainNo.Focus();
            }
            else
            {
                lblValidateTrainNo.Text = "";
                lblValidateTrainNo.Visible = false;
            }
        }
        private void Validation()
        {
            try
            {


                string coachId = txtCoachId.Text.Trim();
                string trainNum = txtTrainNo.Text.Trim();

                if (!string.IsNullOrEmpty(coachId) && !string.IsNullOrEmpty(trainNum))
                {
                    DataTable coach = paDb.ValidateCoachId(trainNum, coachId);

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
                ex.ToString();
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
                ex.ToString();
            }
        }

        private void btnStopMessage_Click(object sender, EventArgs e)
        {
            DialogResult dResult = MessageBox.Show("Do you want to stop the play?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dResult == DialogResult.No)
            {
                return;
            }
            AnnouncementController.OtherAudioPlaying = false;
            AnnouncementController.UpdateStatus("STOP");
            AnnouncementController.UpdateAudioPlayStatus("Completed");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                DialogResult result = MessageBox.Show("Do you want to save the file?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
                string fileName = txtFileName.Text;
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    MessageBox.Show("File name cannot be empty.");
                    return;
                }
                if (!Directory.Exists(directoryPath))
                {
                    try
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to create directory: {ex.Message}");
                    }
                }
                string outputFilePath = Path.Combine(directoryPath, $"{fileName}.wav");

                try
                {
                    File.Move(Path.Combine(directoryPath, "temp.wav"), outputFilePath);

                    bool dt = paDb.insertToCreatedataRecording(outputFilePath, fileName, "0");
                    if (dt)
                    {
                        //MessageBox.Show("Data Uploaded successfully");
                        addAudioPath();
                    }
                    else
                    {
                        MessageBox.Show("Upload error");
                    }
                    txtFileName.Text = "";
                    pnlSavingFile.Visible = false;
                    MessageBox.Show("Recording saved successfully.");
                    btnStopRecording.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save recording: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to close the file without saving?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            pnlSavingFile.Visible = false;
            btnStopRecording.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {


                DialogResult dResult = MessageBox.Show("Do you want to Delete the audiofile?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dResult == DialogResult.No)
                {
                    return;
                }
                string audioId = "";
                if (lbFileSpecialAnnouncement.SelectedItem != null)
                {
                    string audio = lbFileSpecialAnnouncement.SelectedItem.ToString();
                    foreach (DataRow row in audioPathDataTable.Rows)
                    {
                        if (row["Data"].ToString() == audio)
                        {
                            audioId = row["Pkey_SpclMessages"].ToString();
                        }

                    }
                    string statusPa = paDb.DeleteAudioFile(Convert.ToInt32(audioId));

                    MessageBox.Show(statusPa);
                    addAudioPath();
                }
                else
                {
                    MessageBox.Show("No items selected to play.");
                    return;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        private void txtCoachId_Enter(object sender, EventArgs e)
        {
            try
            {


                string trainNum = txtTrainNo.Text.Trim();
                if (string.IsNullOrEmpty(trainNum))
                {
                    MessageBox.Show("Please enter train number");
                    txtCoachId.Text = "";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void txtCoachId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCoachId_KeyPress(object sender, KeyPressEventArgs e)
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
                ex.ToString();
            }
        }

        private void lblPosition_Click(object sender, EventArgs e)
        {

        }

        private void PnlSpcialMessage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSpeclMessage_Click(object sender, EventArgs e)
        {

        }

        private void lbFileSpecialAnnouncement_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblSelectSpecialAnnouncementFile_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
