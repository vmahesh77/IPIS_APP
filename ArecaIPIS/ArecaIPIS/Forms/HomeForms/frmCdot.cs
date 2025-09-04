using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Server_Classes;
using NAudio.Wave;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.HomeForms
{
    public partial class frmCdot : Form
    {


        private frmIndex parentForm;
        public frmCdot(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }
        public frmCdot()
        {

        }

        public void GetCdot()
        {
            DataTable cdotDt = CdotDb.GetCdotInfoData();

            dgvCdot.Rows.Clear();

            foreach (DataRow row in cdotDt.Rows)
            {
                int rowIndex = dgvCdot.Rows.Add();

                dgvCdot.Rows[rowIndex].Cells["dgvSelectColumn"].Value = Convert.ToBoolean(row["Select"].ToString());
                dgvCdot.Rows[rowIndex].Cells["dgvfkeyidentifier"].Value = row["Fkey_identifier"].ToString();
                dgvCdot.Rows[rowIndex].Cells["dgvAlertMessageColumn"].Value = row["headline"].ToString();
                dgvCdot.Rows[rowIndex].Cells["dgvAudioAvailabilityColumn"].Value = row["AudioUrl"].ToString();
                dgvCdot.Rows[rowIndex].Cells["dgvUrgencyColumn"].Value = row["urgency"].ToString();
                dgvCdot.Rows[rowIndex].Cells["dgvSeverityColumn"].Value = row["severity"].ToString();
                dgvCdot.Rows[rowIndex].Cells["dgvCertaintyColumn"].Value = row["certainty"].ToString();
                dgvCdot.Rows[rowIndex].Cells["dgvStartTimeColumn"].Value = row["effective"].ToString();
                dgvCdot.Rows[rowIndex].Cells["dgvEndTimeColumn"].Value = row["expires"].ToString();
            }
        }

        private void frmCdot_Load(object sender, EventArgs e)
        {
            GetCdot();
        }




        private static ConcurrentDictionary<string, WaveOutEvent> activePlayers = new ConcurrentDictionary<string, WaveOutEvent>();
        private ConcurrentDictionary<string, AudioFileReader> activeAudioFiles = new ConcurrentDictionary<string, AudioFileReader>();
        private ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);
        private static bool isPaused = false;
        private List<string> audioPaths = new List<string>();

        public static TaskCompletionSource<bool> pauseCompletionSource = new TaskCompletionSource<bool>();
        public static List<DataGridViewRow> AnnCheckedRows = new List<DataGridViewRow>();
        public static bool playStatus = true;
        private async void btnAudio_Click(object sender, EventArgs e)
        {
            DialogResult dResult = MessageBox.Show("Do you want to Play the Audio?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dResult == DialogResult.No)
            {
                return;
            }

            //UpdateAudioPlayStatus("Stop");
            //UpdateAudioPlayStatus("Completed");
            AnnouncementController.OtherAudioPlaying = false;
            AnnouncementController.UpdateStatus("STOP");
            AnnouncementController.UpdateAudioPlayStatus("Completed");

            if (AnnouncementController.OtherAudioPlaying)
            {
                MessageBox.Show("Other Audio is Playing");

            }
            else
            {
                AnnouncementController.OtherAudioPlaying = true;
                await PlayCdot();
            }

        }

        public async Task PlayCdot()
        {
            try
            {

                DataTable audioDt = CdotDb.GetCdotInfoAudioTrains();
                List<int> selectedPkey = new List<int>();

                if (audioDt == null || audioDt.Rows.Count == 0)
                {
                    MessageBox.Show("No audio items found.");
                    return;
                }

                foreach (DataRow row in audioDt.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row["Select"]);
                    int pkey = Convert.ToInt32(row["Pkey"]);

                    if (isSelected)
                    {
                        selectedPkey.Add(pkey);
                    }
                }

                if (selectedPkey.Count == 0)
                {
                    MessageBox.Show("Please select at least one audio.");
                    return;
                }

                DataTable updatedFile = new DataTable();
                updatedFile.Columns.Add("LanguageID", typeof(int));
                updatedFile.Columns.Add("Sequence", typeof(int));
                updatedFile.Columns.Add("AudioFile", typeof(string));

                int newSeq = 1;
                string cdotPathStr = "";
                string finalCdotPath = "";

                for (int i = 0; i < selectedPkey.Count; i++)
                {
                    string chimeCdot = "E:\\Audio\\English\\Numbers\\chimes.wav";
                    updatedFile.Rows.Add(1, newSeq++, chimeCdot);

                    cdotPathStr = audioDt.Rows[i % audioDt.Rows.Count]["AudioUrl"].ToString();
                    finalCdotPath = "E:\\Audio\\CDOT\\" + cdotPathStr.Trim();

                    updatedFile.Rows.Add(1, newSeq++, finalCdotPath);
                    updatedFile.Rows.Add(1, newSeq++, chimeCdot);

                    CdotDb.UpdateCdotDataAudiocount(2, "");
                }

                if (updatedFile.Rows.Count > 0)
                {
                    DataTable dt = CdotDb.PlayAnnouncemnet(updatedFile, 1, "");

                    if (dt.Rows.Count > 0)
                    {
                        string statusMessage = dt.Rows[0]["Alert"].ToString();

                        if (statusMessage.Contains("Audio play started"))
                        {
                            string logFilePath = "C:\\ShareToAll\\Announcement.txt";
                            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

                            using (StreamWriter sw = new StreamWriter(logFilePath))
                            {
                                foreach (DataRow row in updatedFile.Rows)
                                {
                                    sw.WriteLine(row["AudioFile"].ToString());
                                }
                            }

                            AnnouncementController.cts = new CancellationTokenSource();
                            List<string> audioPaths = updatedFile.AsEnumerable()
                                .Select(r => r.Field<string>("AudioFile"))
                                .ToList();
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


                if (selectedPkey.Count == 0)
                {
                    DataSet dt1 = new DataSet();
                    string identifier = "";
                    dt1 = CdotDb.GetCdotInfoData(identifier);
                    if (dt1.Tables.Count > 0 && dt1.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in dt1.Tables[0].Rows)
                        {
                            if (row["Select"].ToString() == "True")
                            {
                                identifier = row["identifier"].ToString();
                                await SendToAnn_Cdot(identifier);
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

        public async Task SendToAnn_Cdot(string Identifier)
        {
            try
            {
                AnnouncementController.OtherAudioPlaying = false;
                AnnouncementController.UpdateStatus("STOP");
                AnnouncementController.UpdateAudioPlayStatus("Completed");
                //var dt = "";
                DataTable UpdatedFile = new DataTable();
                DataSet DTcdot = CdotDb.GetCdotInfoData(Identifier);
                string[] dotstr = new string[DTcdot.Tables[0].Rows.Count];
                string cdotpathstr = "";
                string Finalcdotpath = "";
                int newseq = 1;
                UpdatedFile.Columns.Add("LanguageID", typeof(int));
                UpdatedFile.Columns.Add("Sequence", typeof(int));
                UpdatedFile.Columns.Add("AudioFile", typeof(string));

                DataSet DTcdotsenddata = CdotDb.GetCdotsenddata(Identifier);


                bool cdotsenddata = Convert.ToBoolean(DTcdotsenddata.Tables[0].Rows[0]["CdotSendaData"].ToString());
                if (DTcdot.Tables[0].Rows.Count > 0 && cdotsenddata == true)
                {
                    for (int i = 0; i < DTcdot.Tables[0].Rows.Count; i++)
                    {
                        string Chimecdot = "E:\\Audio\\English\\Numbers\\chimes.wav";
                        UpdatedFile.Rows.Add(1, newseq, Chimecdot);
                        newseq = newseq + 1;
                        cdotpathstr = DTcdot.Tables[0].Rows[i]["AudioUrl"].ToString();
                        Finalcdotpath = "E:\\Audio\\CDOT\\" + cdotpathstr;
                        UpdatedFile.Rows.Add(1, newseq, Finalcdotpath);

                        newseq = newseq + 1;


                        UpdatedFile.Rows.Add(1, newseq, Chimecdot);

                        newseq = newseq + 1;
                    }
                    CdotDb.UpdateCdotDataAudiocount(2, "");

                }
                if (UpdatedFile != null && UpdatedFile.Rows.Count > 0)
                {


                    DataTable dt = CdotDb.PlayAnnouncemnet(UpdatedFile, 1, "");

                    if (dt.Rows.Count > 0)
                    {
                        string statusMessage = dt.Rows[0]["Alert"].ToString();

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
                            List<string> audioPaths = UpdatedFile.AsEnumerable()
                                .Select(r => r.Field<string>("AudioFile"))
                                .ToList();

                            AnnouncementController.OtherAudioPlaying = true;
                            await PlayAudioSet(audioPaths, 1, AnnouncementController.cts.Token);
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

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
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

        private static void HandleAudioErrors(string filePath)
        {
            MessageBox.Show($"'{filePath}'", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


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
                MessageBox.Show($"Error updating audio play status: {ex.Message}");
            }
        }
        public static List<DataGridViewRow> CheckedCdotMessages = new List<DataGridViewRow>();
        private void btnData_Click(object sender, EventArgs e)
        {
            InterfaceDb.DeleteCdotSendMessages();
            bool messages = checkMessages();
            if (messages)
            {
                insertSendMessages();

                sendCdotDataToBoards();
            }
            else
            {
                MessageBox.Show("Please Click Atleast One Message");
            }
        }
        public static void sendCdotMessagesToBoards()
        {

        }

        public static void sendCdotDataToBoards()
        {
            CdotController.GetCdotConfigData();
            CdotController.PFDBCdotsendData();
            CdotController.AGDBCdotsendData();
            CdotController.MLDBCdotsendData();
            //CdotController.OVDCdotsendData();
            //CdotController.IVDCdotsendData();

        }


        public bool checkMessages()
        {
            CheckedCdotMessages.Clear();

            foreach (DataGridViewRow row in dgvCdot.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (Convert.ToBoolean(row.Cells["dgvSelectColumn"].EditedFormattedValue))
                    {
                        CheckedCdotMessages.Add(row);
                    }
                }
            }

            if (CheckedCdotMessages.Count > 0)
                return true;
            else
                return false;
        }


        public void insertSendMessages()
        {

            foreach (var checkedRow in CheckedCdotMessages)
            {
                int fkeyidentifier = Convert.ToInt32(checkedRow.Cells["dgvfkeyidentifier"].Value.ToString());

                string status = InterfaceDb.InsertintoSendMessages("", fkeyidentifier);
            }
        }

        private void btnCdotPause_Click(object sender, EventArgs e)
        {
            try
            {
                string pausetime = numericUpDownCdot.Value.ToString();
                btnCdotPause.Enabled = false;
                CdotController.pausecdot = true;

                if (BaseClass.IsCdotEnabled())
                {
                    if (CdotPauseTimer.Enabled)
                    {
                        CdotPauseTimer.Stop();
                    }

                    CdotPauseTimer.Interval = Convert.ToInt32(pausetime) * 60 * 1000;

                    CdotPauseTimer.Start();

                    InterfaceDb.InsertPauseCdotAlertData(Convert.ToInt32(pausetime));
                    InterfaceDb.DeleteCdotSendMessages();
                    DataController.sendDataToBoards();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void CdotPauseTimer_Tick(object sender, EventArgs e)
        {
            btnCdotPause.Enabled = true;
            if (CdotPauseTimer.Enabled)
            {
                CdotPauseTimer.Stop();
            }
            CdotController.pausecdot = false;
            InterfaceDb.insertAfterPauseCdotSendMessages();
            DataController.sendDataToBoards();
        }
    }
}
