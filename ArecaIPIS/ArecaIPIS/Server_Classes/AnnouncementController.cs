using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using NAudio.Wave;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Server_Classes
{
    class AnnouncementController
    {
        public static bool PauseButtonStatus = false;
        public static bool OtherAudioPlaying = false;
        private static ConcurrentDictionary<string, WaveOutEvent> activePlayers = new ConcurrentDictionary<string, WaveOutEvent>();
        private ConcurrentDictionary<string, AudioFileReader> activeAudioFiles = new ConcurrentDictionary<string, AudioFileReader>();
        private ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);
        private static bool isPaused = false;
        private List<string> audioPaths = new List<string>();
        public static CancellationTokenSource cts = new CancellationTokenSource();
        public static TaskCompletionSource<bool> pauseCompletionSource = new TaskCompletionSource<bool>();
        public static List<DataGridViewRow> AnnCheckedRows = new List<DataGridViewRow>();
        public static bool playStatus = true;
        //public static void playAnnounceMentData()
        //{




        //    BaseClass.AnnouncementDt = OnlineTrainsDao.GetScheduledAnnouncementTrains();



        //    List<string> selectedTrainNo = new List<string>();

        //    if (BaseClass.AnnouncementDt.Rows.Count == 0)
        //    {
        //        if (!BaseClass.IsNtesAudio() && !BaseClass.IsLocalAutoMode())
        //            MessageBox.Show("Please Select atleast One Train");
        //        return;
        //    }


        //    AnnouncementController.OtherAudioPlaying = true;
        //    isPaused = false;
        //    announce();


        //}

        public static string GetCoachClass(string coachCode)
        {
            try
            {
                // Retrieve all coaches as DataTable
                DataTable coachClassDataTable = AdditionalSettingsDao.GetCoachClassesData();

                // Direct match
                foreach (DataRow row in coachClassDataTable.Rows)
                {
                    if (row["CoachCode"].ToString() == coachCode)
                    {
                        return row["AudioName"].ToString();
                    }
                }

                // Match dynamic coach numbers (e.g., S10, A5, B12)
                foreach (DataRow row in coachClassDataTable.Rows)
                {
                    if (Regex.IsMatch(coachCode, $"^{row["CoachCode"]}[0-9]+$"))
                    {
                        return row["AudioName"].ToString();
                    }
                }
            }catch(Exception e)
            {
                Server.LogError(e.ToString());
            }
            return null;
        }



        public static string getBasicPaths(string PathName,string LangugeId)
        {
            string Path = "";
            if (PathName== "CoachesPath")
            {
                if(LangugeId=="eng")
                Path = "E:\\Audio\\CoachAnn\\CoachIDs_E\\Coaches\\";
                else if(LangugeId == "hin")
                Path = "E:\\Audio\\CoachAnn\\CoachIDs_H\\Coaches\\";
                else
                Path = "E:\\Audio\\CoachAnn\\CoachIDs_L\\Coaches\\";
            }
            else if(PathName== "NumbersPath")
            {
               

                if (LangugeId == "eng")
                    Path = "E:\\Audio\\CoachAnn\\CoachIDs_E\\Numbers\\";
                else if (LangugeId == "hin")
                    Path = "E:\\Audio\\CoachAnn\\CoachIDs_H\\Numbers\\";
                else
                    Path = "E:\\Audio\\CoachAnn\\CoachIDs_L\\Numbers\\";

            }
            else if(PathName== "ClassesPath")
            {
               
                if (LangugeId == "eng")
                    Path = "E:\\Audio\\CoachAnn\\CoachIDs_E\\Classes\\";
                else if (LangugeId == "hin")
                    Path = "E:\\Audio\\CoachAnn\\CoachIDs_H\\Classes\\";
                else
                    Path = "E:\\Audio\\CoachAnn\\CoachIDs_L\\Classes\\";
            }
            else if(PathName=="TrainNamePath")
            {
                if (LangugeId == "eng")
                {
                    Path = "E:\\Audio\\English\\TrainNames\\";
                }
                else if (LangugeId == "hin")
                {
                    Path = "E:\\Audio\\Hindi\\TrainNames\\";
                }
                else
                {
                    Path = "E:\\Audio\\Local\\TrainNames\\";
                }
            }
            else if(PathName=="Chimes")
            {
                Path = "E:\\Audio\\English\\Numbers\\chimes.wav";
            }
            else if(PathName=="Attention")
            {
                if (LangugeId == "eng")
                    Path ="E:\\Audio\\English\\StatusMessages\\Attention.wav";
                else if (LangugeId == "hin")
                    Path = "E:\\Audio\\Hindi\\StatusMessages\\Attention.wav";
                else
                    Path = "E:\\Audio\\Local\\StatusMessages\\Attention.wav";
            }
            else if (PathName == "CoachAnnPath")
            {
                if (LangugeId == "eng")
                    Path = "E:\\Audio\\CoachAnn\\CoachIDs_E\\CoachPositions.wav";
                else if (LangugeId == "hin")
                    Path = "E:\\Audio\\CoachAnn\\CoachIDs_H\\CoachPositions.wav";
                else
                    Path = "E:\\Audio\\CoachAnn\\CoachIDs_L\\CoachPositions.wav";
            }


            return Path;
        }

        public static string[] getTrainumberPaths(string trainNumber,string NumbersPath, string Lang)
        {
           string pathstr = getBasicPaths(NumbersPath, Lang);

            string[] TrainNoaudiopath = new string[5];

            for (int j = 0; j < trainNumber.Length; j++)
            {
                TrainNoaudiopath[j] = pathstr + trainNumber[j] + ".wav";
            }
            return TrainNoaudiopath;
        }

        public static string[] GETCoachPaths(string input,string Lang)
        {
            List<string> audioPaths = new List<string>();
            try
            {
               
                if (ConstatntCoaches.Contains(input))
                {
                    string CoachPath = getBasicPaths("CoachesPath", Lang) + input + ".wav";
                    audioPaths.Add(CoachPath);
                }
                else
                {



                    Match match = Regex.Match(input, @"([a-zA-Z]*)(\d*)");

                    string strPart = null;   // Just use 'string' without '?'
                    int? numPart = null;     // 'int?' is allowed in C# 7.3

                    if (match.Success)
                    {
                        if (!string.IsNullOrEmpty(match.Groups[1].Value))
                            strPart = match.Groups[1].Value;

                        if (!string.IsNullOrEmpty(match.Groups[2].Value))
                            numPart = int.Parse(match.Groups[2].Value);


                        string[] letterArray = new string[strPart.Length];
                            for (int i = 0; i < strPart.Length; i++)
                            {
                                letterArray[i] = strPart[i].ToString();
                            }

                            foreach (string letter in letterArray)
                            {
                                if (letter != null && letter != "")
                                    audioPaths.Add("E:\\Audio\\CoachAnn\\CoachLetters\\" + letter+".wav");
                            }
                        if (numPart != null)
                        {
                            string pathstr = getBasicPaths("NumbersPath", Lang);
                            audioPaths.Add(pathstr + numPart + ".wav");
                        }
                       

                    }
                }

            }
            catch(Exception e)
            {
                e.ToString();
            }
            return audioPaths.ToArray();

        }





        public static List<string> ConstatntCoaches = new List<string> { "ENG","GEN"};

        public static List<string> GetCoachListANN(string TrainNUmber, string Lang)
        {
            ConstatntCoaches.Clear();
            ConstatntCoaches.AddRange(AdditionalSettingsDao.getCoachAnnConstants());


            string ChimesAudio = getBasicPaths("Chimes", Lang);
            string AttentionAudio = getBasicPaths("Attention", Lang);
            string pathstr = "";
            string TrainNameAudioPath = "";
            List<String> CoachPaths = new List<string>();
            string[] TrainNumberPaths = new string[5];
            List<String> AudioPaths = new List<string>();
                TrainNumberPaths= getTrainumberPaths(TrainNUmber, "NumbersPath",Lang);
                string TrainamePath = getBasicPaths("TrainNamePath",Lang);
                TrainNameAudioPath = TrainamePath + TrainNUmber + ".wav";
                DataTable coachPositionsdt = OnlineTrainsDao.getTempCoachPositionsByTrainNumber(TrainNUmber);//temp table
                String CoachesData = coachPositionsdt.Rows[0].Field<string>("coachPositions").ToString();
                String[] Coaches = CoachesData.Split(',');
                int CoachNumber = 0;
                foreach (string coach in Coaches)
                {
                    CoachNumber++;
                    if (coach.Trim() != "")
                    {
                       string NumPath= getBasicPaths("NumbersPath", Lang)+ CoachNumber + ".wav";

                    string[] SubCoaches = GETCoachPaths(coach, Lang);


                        if(File.Exists(NumPath) && SubCoaches.Length > 0)
                        {
                      
                        CoachPaths.Add(NumPath);
                        CoachPaths.Add("E:\\Audio\\CoachAnn\\SPACES\\1S.WAV");
                        CoachPaths.AddRange(SubCoaches);
                        string isClass=GetCoachClass(coach);

                            
                            if (isClass != null)
                            {
                            string ClassPathPath = getBasicPaths("ClassesPath", Lang) + isClass + ".wav";
                            CoachPaths.Add(ClassPathPath);
                            }

                       
                        CoachPaths.Add("E:\\Audio\\CoachAnn\\SPACES\\1S.WAV");
                        CoachPaths.Add("E:\\Audio\\CoachAnn\\SPACES\\0.25S.WAV");
                    }
                    }
                    
                }
                AudioPaths.Add(ChimesAudio);
                AudioPaths.Add(ChimesAudio);
                AudioPaths.Add(AttentionAudio);
                AudioPaths.AddRange(TrainNumberPaths);
                AudioPaths.Add(TrainNameAudioPath);
                AudioPaths.Add(getBasicPaths("CoachAnnPath",Lang)); 
                AudioPaths.AddRange(CoachPaths);
       
            return AudioPaths;
        }

        



        public async static void playAnnounceMentCoachesClassData(String TrainNUmber)
        {

            List<string> audioEngPaths = new List<string>();
            List<string> audiohinPaths = new List<string>();

            List<string> audioregPaths = new List<string>();

            List<string> TotalPaths = new List<string>();

            UpdateAudioPlayStatus("PLAY");

            List<string> audCoachAnnseq = AdditionalSettingsDao.getCoachAnnSeq();
            if(audCoachAnnseq.Count==0)
            {
                audioEngPaths = GetCoachListANN(TrainNUmber, "eng");
                TotalPaths.AddRange(audioEngPaths);
            }

            foreach(string lang in audCoachAnnseq)
            {
                if(lang=="eng")
                {
                    audioEngPaths = GetCoachListANN(TrainNUmber, "eng");
                    TotalPaths.AddRange(audioEngPaths);
                }
                else if(lang =="hin")
                {
                  audiohinPaths = GetCoachListANN(TrainNUmber, "hin");
                    TotalPaths.AddRange(audiohinPaths);
                }
                else
                {
                     audioregPaths = GetCoachListANN(TrainNUmber, "reg");
                    TotalPaths.AddRange(audioregPaths);
                }
            }

            AnnouncementController.OtherAudioPlaying = true;
            isPaused = false;
            cts = new CancellationTokenSource();
            //await Task.Run(async () =>
            // {
            //     await PlayAudioSet(TotalPaths, BaseClass.AnnouncementCount, cts.Token);

            // });
            //UpdateAudioPlayStatus("Completed");

            AudioManager.PlayAudioSet(TotalPaths, BaseClass.AnnouncementCount, cts.Token);
        }

        public async static void playAnnounceMentData()
        {
            BaseClass.AnnouncementDt = OnlineTrainsDao.GetScheduledAnnouncementTrains();

            List<string> selectedTrainNo = new List<string>();

            if (BaseClass.AnnouncementDt.Rows.Count == 0)
            {
                if (!BaseClass.IsNtesAudio() && !BaseClass.IsLocalAutoMode())
                    MessageBox.Show("Please Select atleast One Train");
                return;
            }

            bool status = DataController.CheckPlatformedrequiredexists(BaseClass.AnnouncementDt);
            if (!status)
            {
                AnnouncementController.OtherAudioPlaying = true;
                isPaused = false;
                await Task.Run(() => announce());
                //announce();
            }
        }
        public static List<string> Selectedtrainno = new List<string>();
        public static String GetAnnounceMentTrainNumbers()
        {

            Selectedtrainno.Clear();
            string trainNumbers = "";
            try
            {
                foreach (DataRow row in BaseClass.AnnouncementDt.Rows)
                {
                    Selectedtrainno.Add(row["TrainNo"].ToString().Trim());
                    trainNumbers = trainNumbers + row["TrainNo"].ToString() + ",";
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return trainNumbers;
        }
        public async void autoAnnounce()
        {
            try
            {


                DataTable AllTrain = OnlineTrainsDao.GetAllTrains();
                HashSet<string> validTrainNumbers = new HashSet<string>();
                foreach (DataRow row in AllTrain.Rows)
                {
                    string trainNumber = row["TrainNumber"].ToString();
                    validTrainNumbers.Add(trainNumber);
                }
                BaseClass.AnnouncementCount = 1;
                List<string> AllTrainNumbers = new List<string>();
                foreach (string trainNumber in Selectedtrainno)
                {
                    if (validTrainNumbers.Contains(trainNumber))
                    {
                        AllTrainNumbers.Add(trainNumber);
                    }
                }

                Selectedtrainno = AllTrainNumbers;

                await Task.Run(() => announce());
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public static void PauseAllAudio()
        {
            try
            {
                isPaused = true;
                pauseCompletionSource = new TaskCompletionSource<bool>();

                foreach (var player in activePlayers.Values)
                {
                    if (player.PlaybackState == PlaybackState.Playing)
                    {
                        player.Pause();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError("PauseAllAudio: " + ex.Message);
            }
        }


        public static void ResumeAllAudio()
        {
            try
            {
                isPaused = false;
                pauseCompletionSource?.TrySetResult(true);

                foreach (var player in activePlayers.Values)
                {
                    if (player.PlaybackState == PlaybackState.Paused)
                    {
                        player.Play();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError("ResumeAllAudio: " + ex.Message);
            }
        }


        public static void StopAllAudio()
        {
            try
            {
                if (cts != null && !cts.IsCancellationRequested)
                {
                    cts.Cancel();
                }

                foreach (var kvp in activePlayers)
                {
                    try
                    {
                        kvp.Value?.Stop(); // Will trigger dispose via PlaybackStopped
                    }
                    catch { }
                }

                activePlayers.Clear();
                isPaused = false;

                pauseCompletionSource?.TrySetCanceled();
            }
            catch (Exception ex)
            {
                Server.LogError("StopAllAudio: " + ex.Message);
            }
        }

        public static async Task PlayAudioSet(List<string> audioPaths, int playCount, CancellationToken token)
        {
            try
            {
                for (int count = 0; count < playCount; count++)
                {
                    foreach (string filePath in audioPaths)
                    {
                        token.ThrowIfCancellationRequested();

                        if (File.Exists(filePath))
                        {
                            await PlaySingleAudio(filePath, token);
                        }
                        else
                        {
                            Console.WriteLine($"Audio file not found: {filePath}");
                            Server.LogError($"Audio file not found: {filePath}");
                        }
                    }

                    // Optional delay between sets (adjust if needed)
                    // await Task.Delay(100, token);
                }

                UpdateAudioPlayStatus("Completed");
            }
            catch (OperationCanceledException)
            {

                UpdateAudioPlayStatus("Completed");
            }
            catch (Exception ex)
            {
                Server.LogError("PlayAudioSet error: " + ex.ToString());
                UpdateAudioPlayStatus("Error");
            }
        }


        public static async Task PlaySingleAudio(string filePath, CancellationToken token)
        {
            WaveOutEvent player = null;
            AudioFileReader audioFile = null;

            try
            {
                audioFile = new AudioFileReader(filePath);
                player = new WaveOutEvent();

                var tcs = new TaskCompletionSource<bool>();

                player.Init(audioFile);

                // Register before playing
                player.PlaybackStopped += (sender, args) =>
                {
                    tcs.TrySetResult(true);
                    activePlayers.TryRemove(filePath, out _);
                    player.Dispose();
                    audioFile.Dispose();
                };

                activePlayers[filePath] = player;
                player.Play();

                while (player.PlaybackState == PlaybackState.Playing)
                {
                    token.ThrowIfCancellationRequested();

                    if (isPaused)
                    {
                        var localPauseTcs = pauseCompletionSource;
                        if (localPauseTcs != null)
                        {
                            await localPauseTcs.Task;
                        }
                    }

                    await Task.Delay(100, token);
                }

                await tcs.Task;
            }
            catch (OperationCanceledException)
            {
                player?.Stop();
                // Will trigger PlaybackStopped and dispose
            }
            catch (Exception ex)
            {
                Server.LogError("PlaySingleAudio() " + ex.ToString());
                player?.Dispose();
                audioFile?.Dispose();
            }
        }


        public static void UpdateAudioPlayStatus(string action)
        {
            try
            {
                bool successAction = OnlineTrainsDao.UpdateAudioPlayStatus(action);

                if (successAction)
                {
                    //MessageBox.Show("Audio play status updated successfully.");
                    AnnouncementController.OtherAudioPlaying = false;
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
        
        public async static void announce()
        {
            try
            {


                string trainNo = GetAnnounceMentTrainNumbers();
                DataTable UpdatedFile = new DataTable();
                UpdatedFile.Columns.Add("LanguageID", typeof(int));
                UpdatedFile.Columns.Add("Sequence", typeof(int));
                UpdatedFile.Columns.Add("AudioFile", typeof(string));

                foreach (string trainNumber in Selectedtrainno)
                {
                    var data = OnlineTrainsDao.SendToAnnouncement(trainNumber);
                    int newseq = 1;

                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        var fileName = data.Rows[i]["AudioName"].ToString();
                        var LanguageID = data.Rows[i]["LanguageId"].ToString();
                        var sequence = data.Rows[i]["sequence"].ToString();
                        var AudioPath = data.Rows[i]["AudioPath"].ToString();
                        var TrainNo = data.Rows[i]["TrainNo"].ToString();
                        var RAH = Convert.ToInt32(data.Rows[i]["RArrivalTime"].ToString().Split(':')[0]);
                        var RAM = Convert.ToInt32(data.Rows[i]["RArrivalTime"].ToString().Split(':')[1]);
                        var RDH = Convert.ToInt32(data.Rows[i]["RDepartureTime"].ToString().Split(':')[0]);
                        var RDM = Convert.ToInt32(data.Rows[i]["RDepartureTime"].ToString().Split(':')[1]);
                        var LAH = Convert.ToInt32(data.Rows[i]["LArrivalTime"].ToString().Split(':')[0]);
                        var LAM = Convert.ToInt32(data.Rows[i]["LArrivalTime"].ToString().Split(':')[1]);
                        var LDTH = Convert.ToInt32(data.Rows[i]["LDepartureTime"].ToString().Split(':')[0]);
                        var LDTM = Convert.ToInt32(data.Rows[i]["LDepartureTime"].ToString().Split(':')[1]);
                        var LATEH = Convert.ToInt32(data.Rows[i]["LateBy"].ToString().Split(':')[0]);
                        var LATEM = Convert.ToInt32(data.Rows[i]["LateBy"].ToString().Split(':')[1]);
                        var StatusName = data.Rows[i]["StatusName"].ToString();
                        var PFNO = data.Rows[i]["PFNO"].ToString();

                        string[] TrainNoaudiopath = new string[5];
                        string pathstr = "";
                        string PathTrainnamestr = "";
                        //var Traintype = OnlineTrainsDao.GetTrainUpDownStatus(TrainNo);
                        //string TrainTypestatus = Traintype.Rows[0]["TrainType"].ToString();
                        string TrainNamestr = "";


                        if (fileName.ToLower() == "train number")
                        {

                            if (LanguageID == "1")
                            {
                                pathstr = "E:\\Audio\\English\\Numbers\\";
                            }
                            else if (LanguageID == "2")
                            {
                                pathstr = "E:\\Audio\\Hindi\\Numbers\\";
                            }
                            else if (LanguageID == "3")
                            {
                                pathstr = "E:\\Audio\\Local\\Numbers\\";
                            }
                            for (int j = 0; j < TrainNo.Length; j++)
                            {
                                TrainNoaudiopath[j] = pathstr + TrainNo[j] + ".wav";
                            }
                            //}

                            if (LanguageID == "1")
                            {
                                PathTrainnamestr = "E:\\Audio\\English\\TrainNames\\";
                            }
                            else if (LanguageID == "2")
                            {
                                PathTrainnamestr = "E:\\Audio\\Hindi\\TrainNames\\";
                            }
                            else if (LanguageID == "3")
                            {
                                PathTrainnamestr = "E:\\Audio\\Local\\TrainNames\\";
                            }

                            TrainNamestr = PathTrainnamestr + TrainNo + ".wav";

                        }


                        var Diverted = data.Rows[i]["StationCode"].ToString();

                        if (StatusName.ToLower() == "diverted")
                        {
                            string[] tokens = Diverted.Split(',');
                            if (fileName.ToLower() == "stn0")
                            {
                                AudioPath = AudioPath.Replace("{0}", tokens[0]);
                            }
                            else if (fileName.ToLower() == "stn1" && (tokens.Length == 2 || tokens.Length == 3))
                            {
                                AudioPath = AudioPath.Replace("{1}", tokens[1]);
                            }
                            else if (fileName.ToLower() == "stn2" && tokens.Length == 3)
                            {
                                AudioPath = AudioPath.Replace("{2}", tokens[2]);
                            }

                        }
                        if (StatusName.ToLower() == "change of source")
                        {
                            if (fileName.ToLower() == "stn")
                            {
                                AudioPath = AudioPath.Replace("{0}", Diverted);
                            }
                        }
                        if (StatusName.ToLower() == "terminated")
                        {
                            if (fileName.ToLower() == "stn")
                            {
                                AudioPath = AudioPath.Replace("{0}", Diverted);
                            }
                        }
                        if (StatusName.ToLower() == "terminated at")
                        {
                            if (fileName.ToLower() == "stn")
                            {
                                AudioPath = AudioPath.Replace("{0}", Diverted);
                            }
                        }
                        if (fileName.ToLower() == "stah hours" && LanguageID == "3" && RAH == 1 && RAM != 0)
                        {

                            AudioPath = "E:\\Audio\\Local\\StatusMessages\\Hour_T.wav";

                        }

                        else if (fileName.ToLower() == "stdh hours" && LanguageID == "3" && RAH == 1 && RAM != 0)
                        {

                            AudioPath = "E:\\Audio\\Local\\StatusMessages\\Hour_T.wav";

                        }
                        else if (fileName.ToLower() == "etah hours" && LanguageID == "3" && LAH == 1 && LAM != 0)
                        {

                            AudioPath = "E:\\Audio\\Local\\StatusMessages\\Hour_T.wav";

                        }
                        else if (fileName.ToLower() == "etdh hours" && LanguageID == "3" && LDTH == 1 && LDTH != 0)
                        {
                            AudioPath = "E:\\Audio\\Local\\StatusMessages\\Hour_T.wav";

                        }

                        else if (fileName.ToLower() == "stah hours" && LanguageID == "1" && RAH == 1 && RAM != 0)
                        {
                            AudioPath = "E:\\Audio\\English\\StatusMessages\\Hour.wav";

                        }
                        else if (fileName.ToLower() == "stdh hours" && LanguageID == "1" && RDH == 1 && RDM != 0)
                        {
                            AudioPath = "E:\\Audio\\English\\StatusMessages\\Hour.wav";
                        }
                        else if (fileName.ToLower() == "etah hours" && LanguageID == "1" && LAH == 1 && LAM != 0)
                        {
                            AudioPath = "E:\\Audio\\English\\StatusMessages\\Hour.wav";
                        }
                        else if (fileName.ToLower() == "etdh hours" && LanguageID == "1" && LDTH == 1 && LDTM != 0)
                        {
                            AudioPath = "E:\\Audio\\English\\StatusMessages\\Hour.wav";
                        }


                        else if (fileName.ToLower() == "stah hours" && LanguageID == "1" && RAH != 0 && RAM == 0)
                        {
                            if (RAH == 1)
                            {
                                AudioPath = "E:\\Audio\\English\\StatusMessages\\Hour.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\English\\StatusMessages\\Hours.wav";
                            }
                        }
                        else if (fileName.ToLower() == "stah hours" && LanguageID == "2" && RAH != 0 && RAM == 0)
                        {
                            if (RAH >= 1)
                            {
                                AudioPath = "E:\\Audio\\Hindi\\StatusMessages\\Hour_H.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\Hindi\\StatusMessages\\Hours_H.wav";
                            }
                        }
                        else if (fileName.ToLower() == "stah hours" && LanguageID == "3" && RAH != 0 && RAM == 0)
                        {
                            if (RAH == 1)
                            {
                                AudioPath = "E:\\Audio\\Local\\StatusMessages\\Hour_T.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\Local\\StatusMessages\\Gantalaku_T.wav";
                            }
                        }
                        else if (fileName.ToLower() == "stam minutes" && LanguageID == "3" && RAH == 0 && RAM != 0)
                        {
                            AudioPath = "E:\\Audio\\Local\\StatusMessages\\Minutes Ku_T.wav";
                        }
                        else if (fileName.ToLower() == "stam minutes" && (LanguageID == "1" || LanguageID == "2" || LanguageID == "3") && RAM == 0)
                        {
                            AudioPath = "";
                        }




                        else if (fileName.ToLower() == "stdh hours" && LanguageID == "1" && RDH != 0 && RDM == 0)
                        {
                            if (RDH == 1)
                            {
                                AudioPath = "E:\\Audio\\English\\StatusMessages\\Hour.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\English\\StatusMessages\\Hours.wav";
                            }
                        }
                        else if (fileName.ToLower() == "stdh hours" && LanguageID == "2" && RDH != 0 && RDM == 0)
                        {
                            if (RDH >= 1)
                            {
                                AudioPath = "E:\\Audio\\Hindi\\StatusMessages\\Hour_H.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\Hindi\\StatusMessages\\Hours_H.wav";
                            }
                        }

                        else if (fileName.ToLower() == "stdh hours" && LanguageID == "3" && RDH != 0 && RDM == 0)
                        {
                            if (RDH == 1)
                            {
                                AudioPath = "E:\\Audio\\Local\\StatusMessages\\Hour_T.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\Local\\StatusMessages\\Gantalaku_T.wav";
                            }
                        }
                        else if (fileName.ToLower() == "stdm minutes" && LanguageID == "3" && RDH == 0 && RDM != 0)
                        {
                            AudioPath = "E:\\Audio\\Local\\StatusMessages\\Minutes Ku_T.wav";
                        }
                        else if (fileName.ToLower() == "stdm minutes" && (LanguageID == "1" || LanguageID == "2" || LanguageID == "3") && RDM == 0)
                        {
                            AudioPath = "";
                        }



                        else if (fileName.ToLower() == "etah hours" && LanguageID == "1" && LAH != 0 && LAM == 0)
                        {
                            if (LAH == 1)
                            {
                                AudioPath = "E:\\Audio\\English\\StatusMessages\\Hour.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\English\\StatusMessages\\Hours.wav";
                            }
                        }
                        else if (fileName.ToLower() == "etah hours" && LanguageID == "2" && LAH != 0 && LAM == 0)
                        {
                            if (LAH >= 1)
                            {
                                AudioPath = "E:\\Audio\\Hindi\\StatusMessages\\Hour_H.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\Hindi\\StatusMessages\\Hours_H.wav";
                            }
                        }

                        else if (fileName.ToLower() == "etah hours" && LanguageID == "3" && LAH != 0 && LAM == 0)
                        {
                            if (LAH == 1)
                            {
                                AudioPath = "E:\\Audio\\Local\\StatusMessages\\Gantaku_T.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\Local\\StatusMessages\\Gantalaku_T.wav";
                            }
                        }
                        else if (fileName.ToLower() == "etah hours" && LanguageID == "3" && LAH == 1 && LAM != 0)
                        {
                            AudioPath = "E:\\Audio\\Local\\StatusMessages\\Hour_T.wav";
                        }
                        else if (fileName.ToLower() == "etam minutes" && LanguageID == "3" && LAH == 0 && LAM != 0)
                        {
                            AudioPath = "E:\\Audio\\Local\\StatusMessages\\Minutes Ku_T.wav";
                        }
                        else if (fileName.ToLower() == "etam minutes" && (LanguageID == "1" || LanguageID == "2" || LanguageID == "3") && LAM == 0)
                        {
                            AudioPath = "";
                        }


                        else if (fileName.ToLower() == "etdh hours" && LanguageID == "1" && LDTH != 0 && LDTM == 0)
                        {
                            if (LDTH == 1)
                            {
                                AudioPath = "E:\\Audio\\English\\StatusMessages\\Hour.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\English\\StatusMessages\\Hours.wav";
                            }
                        }
                        else if (fileName.ToLower() == "etdh hours" && LanguageID == "2" && LDTH != 0 && LDTM == 0)
                        {
                            if (LDTH >= 1)
                            {
                                AudioPath = "E:\\Audio\\Hindi\\StatusMessages\\Hour_H.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\Hindi\\StatusMessages\\Hours_H.wav";
                            }
                        }

                        else if (fileName.ToLower() == "etdh hours" && LanguageID == "3" && LDTH != 0 && LDTM == 0)
                        {
                            if (RDH == 1)
                            {
                                AudioPath = "E:\\Audio\\Local\\StatusMessages\\Gantaku.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\Local\\StatusMessages\\Gantalaku_T.wav";
                            }
                        }
                        else if (fileName.ToLower() == "etdm minutes" && LanguageID == "3" && LDTH == 0 && LDTM != 0)
                        {
                            AudioPath = "E:\\Audio\\Local\\StatusMessages\\Minutes Ku_T.wav";
                        }
                        else if (fileName.ToLower() == "etam minutes" && (LanguageID == "1" || LanguageID == "2" || LanguageID == "3") && LAM == 0)
                        {
                            AudioPath = "";
                        }



                        else if (fileName.ToLower() == "lateh hours" && LanguageID == "1" && LATEH != 0 && LATEM == 0)
                        {
                            if (LATEH == 1)
                            {
                                AudioPath = "E:\\Audio\\English\\StatusMessages\\Hour.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\English\\StatusMessages\\Hours.wav";
                            }
                        }
                        else if (fileName.ToLower() == "lateh hours" && LanguageID == "2" && LATEH != 0 && LATEM == 0)
                        {

                            AudioPath = "E:\\Audio\\Hindi\\StatusMessages\\Ganta_H.wav";

                        }

                        else if (fileName.ToLower() == "lateh hours" && LanguageID == "3" && LATEH != 0 && LATEM == 0)
                        {
                            if (LATEH == 1)
                            {
                                AudioPath = "E:\\Audio\\Local\\StatusMessages\\Ganta_T.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\Local\\StatusMessages\\Gantalu_T.wav";
                            }
                        }

                        else if (fileName.ToLower() == "lateh hours" && LanguageID == "1" && LATEH == 1 && LATEM != 0)
                        {

                            AudioPath = "E:\\Audio\\English\\StatusMessages\\Hour.wav";
                        }

                        else if (fileName.ToLower() == "lateh hours" && LanguageID == "3" && LATEH == 1 && LATEM != 0)
                        {

                            AudioPath = "E:\\Audio\\Local\\StatusMessages\\Ganta_T.wav";
                        }




                        else if (fileName.ToLower() == "latem minutes" && LanguageID == "3" && (LATEH == 0 || LATEH == 1) && LATEM != 0)
                        {
                            if (LATEM == 1)
                            {
                                AudioPath = "E:\\Audio\\Local\\StatusMessages\\Minute_T.wav";
                            }
                            else
                            {
                                AudioPath = "E:\\Audio\\Local\\StatusMessages\\Minutes_T.wav";
                            }


                        }

                        else if (fileName.ToLower() == "latem minutes" && (LanguageID == "1" || LanguageID == "2" || LanguageID == "3") && LATEM == 0)
                        {
                            AudioPath = "";
                        }


                        else if (fileName.ToLower() == "stah" && RAH != 0)
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(RAH));
                        }
                        else if (fileName.ToLower() == "stah" && RAH == 0)
                        {
                            AudioPath = "";
                        }

                        else if (fileName.ToLower() == "stah hours" && RAH == 0)
                        {
                            AudioPath = "";
                        }

                        else if (fileName.ToLower() == "stam" && RAM != 0)
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(RAM));
                        }
                        else if (fileName.ToLower() == "stam" && RAM == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "stam minutes" && RAM == 0)
                        {
                            AudioPath = "";
                        }


                        else if (fileName.ToLower() == "lateh" && LATEH != 0)
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(LATEH));
                        }
                        else if (fileName.ToLower() == "lateh" && LATEH == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "lateh hours" && LATEH == 0)
                        {
                            AudioPath = "";
                        }

                        else if (fileName.ToLower() == "latem" && LATEM != 0)
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(LATEM));
                        }
                        else if (fileName.ToLower() == "latem" && LATEM == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "latem minutes" && LATEM == 0)
                        {
                            AudioPath = "";
                        }


                        else if (fileName.ToLower() == "etah" && LAH != 0)
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(LAH));
                        }
                        else if (fileName.ToLower() == "etah" && LAH == 0)
                        {
                            AudioPath = "";
                        }

                        else if (fileName.ToLower() == "etam" && LAM != 0)
                        {

                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(LAM));
                        }
                        else if (fileName.ToLower() == "etam")
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "etdh" && LDTH != 0)
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(LDTH));
                        }
                        else if (fileName.ToLower() == "etdh" && LDTH == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "etdm" && LDTM != 0)
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(LDTM));
                        }
                        else if (fileName.ToLower() == "etdm" && LDTM == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "stdh" && RDH != 0)
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(RDH));
                        }
                        else if (fileName.ToLower() == "stdh" && RDH == 0)
                        {
                            AudioPath = "";
                        }

                        else if (fileName.ToLower() == "stdm" && RDM != 0)
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(RDM));
                        }
                        else if (fileName.ToLower() == "stdm" && RDM == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "etdm minutes" && LDTM == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "etdh hours" && LDTH == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "stdh hours" && RDH == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "stdm minutes" && RDM == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "stah hours" && RAH == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "stam minutes" && RAM == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "etah hours" && LAH == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "etah hours" && LAH == 1 && LanguageID == "1")
                        {

                            AudioPath = "E:\\Audio\\English\\StatusMessages\\Hour.wav";
                        }
                        else if (fileName.ToLower() == "lateh hours" && LAH == 1 && LanguageID == "2")
                        {
                            AudioPath = "E:\\Audio\\Hindi\\StatusMessages\\Ganta_H.wav";
                        }
                        else if (fileName.ToLower() == "lateh hours" && LAH == 1 && LanguageID == "3")
                        {
                            AudioPath = "E:\\Audio\\Local\\StatusMessages\\Ganta_T.wav";
                        }

                        else if (fileName.ToLower() == "etam minutes" && LAM == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "etdm minutes" && LDTM == 0)
                        {
                            AudioPath = "";
                        }
                        else if (fileName.ToLower() == "etdh hours" && LDTH == 0)
                        {
                            AudioPath = "";
                        }

                        else if (fileName.ToLower() == "hours")
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(RAH));
                        }

                        else if (fileName.ToLower() == "minutes")
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(RAM));
                        }

                        else if (fileName.ToLower() == "platform number")
                        {
                            if (PFNO != null)
                            {
                                AudioPath = AudioPath.Replace("{0}", PFNO);
                            }
                        }

                        else if (fileName.ToLower() == "late hrs" || fileName.ToLower() == "l hr")
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(LAH));
                        }

                        else if (fileName.ToLower() == "late minutes" || fileName.ToLower() == "late min")
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(LAM));
                        }
                        else if (fileName.ToLower() == "{scadh}" || fileName.ToLower() == "scadh")
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(RDH));
                        }
                        else if (fileName.ToLower() == "{scadm}")
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(RDM));
                        }
                        else if (fileName.ToLower() == "{schadm}")
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(LDTM));
                        }
                        else if (fileName.ToLower() == "{schadh}")
                        {
                            AudioPath = AudioPath.Replace("{0}", Convert.ToString(LDTH));
                        }



                        if (AudioPath.IndexOf("{1}") > -1 || AudioPath.IndexOf("{2}") > -1 || AudioPath.IndexOf("{3}") > -1 || AudioPath == "")
                        {
                        }
                        else
                            if (fileName.ToLower() == "train number")
                        {
                            for (int c = 0; c < TrainNoaudiopath.Length; c++)
                            {
                                UpdatedFile.Rows.Add(Convert.ToInt32(LanguageID), newseq, TrainNoaudiopath[c]);
                                newseq++;

                            }
                            UpdatedFile.Rows.Add(Convert.ToInt32(LanguageID), newseq, TrainNamestr);
                            newseq++;

                        }

                        else
                        {
                            UpdatedFile.Rows.Add(Convert.ToInt32(LanguageID), newseq, AudioPath);

                            newseq = newseq + 1;
                        }
                    }

                }

                if (UpdatedFile.Rows.Count > 0)
                {

                    DataTable dt = OnlineTrainsDao.PlayAnnouncemnet(UpdatedFile, BaseClass.AnnouncementCount, trainNo);

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
                                    string st = row["AudioFile"].ToString();
                                    sw.WriteLine(row["AudioFile"].ToString());
                                }
                            }
                            cts = new CancellationTokenSource();
                            //List<string> audioPaths = UpdatedFile.AsEnumerable().Select(r => r.Field<string>("AudioFile")).ToList();
                            List<string> audioPaths = UpdatedFile.AsEnumerable()
    .Select(r => r.Field<string>("AudioFile")
        .Replace("\r\n", "")
        .Replace("\n", "")  // Optional, if newlines without carriage return are also present
        .Replace("\r", ""))  // Optional, if carriage returns alone are present
    .ToList();

                            // await PlayAudioSet(audioPaths, BaseClass.AnnouncementCount, cts.Token);
                             AudioManager.PlayAudioSet(audioPaths, BaseClass.AnnouncementCount, cts.Token);
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

                    //cts = new CancellationTokenSource();
                    //IEnumerable<DataRow> rows = UpdatedFile.AsEnumerable();
                    //IEnumerable<string> audioFileValues = rows.Select(r => r.Field<string>("AudioFile"));
                    //List<string> audioPaths = audioFileValues.ToList();
                    //await PlayAudioSet(audioPaths, nupMessageValue, cts.Token);

                }
                else
                {
                    if (!BaseClass.IsNtesAudio() || !BaseClass.IsLocalAutoMode())
                        MessageBox.Show("No valid audio files found to update.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static void CheckPauseButtonClick()
        {
            if (AnnouncementController.PauseButtonStatus)
            {
                AnnouncementController.PauseButtonStatus = false;
            }
            else
            {
                AnnouncementController.PauseButtonStatus = true;
            }
        }
        public static void UpdateStatus(string action)
        {
            try
            {
                DataTable status = OnlineTrainsDao.getUpdatedStatus(action);

                if (status != null && status.Rows.Count > 0)
                {
                    string alertValue = status.Rows[0]["ALERT"].ToString();

                    if ((alertValue == "RESUME") || (alertValue == "PAUSE"))
                    {
                        PauseAudio(alertValue);
                    }
                    else if (alertValue == "STOP")
                    {
                        //StopAllAudio();

                        AudioManager.StopAllAudio();
                    }
                    else if (alertValue == "INSERTED")
                    {
                        //  MessageBox.Show("Handling action: " + alertValue);

                        AudioManager.StopAllAudio();
                    }
                    else
                    {
                        MessageBox.Show("Unknown action: " + alertValue);
                        AudioManager.StopAllAudio();
                    }
                }
                else
                {
                    MessageBox.Show("No data returned from database for action: " + action);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }
        public static void PauseAudio(string alertValue)
        {
            try
            {


                if (alertValue == "PAUSE")
                {
                    AudioManager.ResumeAllAudio();
                   // ResumeAllAudio();
                    if (BaseClass.btnPause != null)
                    {
                        string lowerCaseAlertValue = alertValue.ToLower();

                        string formattedAlertValue = char.ToUpper(lowerCaseAlertValue[0]) + lowerCaseAlertValue.Substring(1);

                        BaseClass.btnPause = formattedAlertValue;
                    }
                }
                else
                {
                    AudioManager.PauseAllAudio();
                    //PauseAllAudio();
                    if (BaseClass.btnPause != null)
                    {
                        string lowerCaseAlertValue = alertValue.ToLower();

                        string formattedAlertValue = char.ToUpper(lowerCaseAlertValue[0]) + lowerCaseAlertValue.Substring(1);

                        BaseClass.btnPause = formattedAlertValue;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
    }
}
