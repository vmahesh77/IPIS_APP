using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.IO;

namespace ArecaIPIS.Server_Classes
{
    class CCTVController
    {
        public static void CCTVsendData()
        {
            try
            {


                OnlineTrainsDao.SendDataTOCCtv();
                LcdTvDb.UpdatecctvStatus(true);
                UpdateCCTV();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public static void UpdateCCTV()
        {
            try
            {



                System.IO.StreamWriter swExtLogFiles;
                //string vdcfile = "Test";

                DirectoryInfo logDirInfos = null;
                FileInfo logFileInfos;
                string logFilePaths = "C:\\ShareToAll\\CCTV\\";
                logFilePaths = logFilePaths + "CCTV.txt";
                logFileInfos = new FileInfo(logFilePaths);
                logDirInfos = new DirectoryInfo(logFileInfos.DirectoryName);
                if (!logDirInfos.Exists) logDirInfos.Create();
                if (!logFileInfos.Exists)
                {
                    logFileInfos.Create();
                }

                File.WriteAllText(logFilePaths, String.Empty);
                swExtLogFiles = new StreamWriter(logFilePaths, true);

                swExtLogFiles.Write(true);
                swExtLogFiles.Flush();
                swExtLogFiles.Close();
            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
    }
}
