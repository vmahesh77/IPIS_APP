using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms.HomeForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ArecaIPIS.Server_Classes
{
    class DataController
    {




        public static void SplitingTadbScheduleData()
        {
            try
            {


                foreach (DataRow row in BaseClass.OnlineTrainsTaddbDt.Rows)
                {

                    bool tadb = Convert.ToBoolean(row["Tadb"].ToString().Trim());
                    if (tadb)
                    {


                        string TrainNo = row["TrainNo"].ToString().Trim();
                        string TrainNameEng = row["Name"].ToString().Trim();
                        string RArrivalTime = row["RArrivalTime"].ToString().Trim();


                        string RDepartureTime = row["RDepartureTime"].ToString().Trim();
                        string ArrivingStatus = row["ArrivingStatus"].ToString().Trim();
                        string StatusName = row["StatusName"].ToString().Trim();
                        string LateBy = row["LateBy"].ToString().Trim();
                        string LArrivalTime = row["LArrivalTime"].ToString().Trim();
                        string LDepartureTime = row["LDepartureTime"].ToString().Trim();
                        string Pf = row["PlatformName"].ToString().Trim();
                        string PlatformName = "";
                        if (Pf != "--")
                        {
                            PlatformName = row["PlatformName"].ToString().Trim();
                        }
                        string EStation = row["EStation"].ToString().Trim();
                        string HStation = row["HStation"].ToString().Trim();
                        string RStation = row["RStation"].ToString().Trim();
                        string CoachePos = "";
                        string Terminate_Diverted = row["Terminate_Diverted"].ToString().Trim();

                        prepareReportData(TrainNo, TrainNameEng, RArrivalTime, RDepartureTime, ArrivingStatus, StatusName, LateBy, LArrivalTime, LDepartureTime, PlatformName, EStation, HStation, RStation, CoachePos, Terminate_Diverted);
                    }


                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public static void SplitingCgdbScheduleData()
        {
            try
            {

                if (BaseClass.OnlineTrainsCgdbDt != null)
                {
                    foreach (DataRow row in BaseClass.OnlineTrainsCgdbDt.Rows)
                    {

                        bool tadb = Convert.ToBoolean(row["Cgdb"].ToString().Trim());
                        if (tadb)
                        {


                            string TrainNo = row["TrainNo"].ToString().Trim();
                            string TrainNameEng = row["Name"].ToString().Trim();
                            string RArrivalTime = row["RArrivalTime"].ToString().Trim();


                            string RDepartureTime = row["RDepartureTime"].ToString().Trim();
                            string ArrivingStatus = row["ArrivingStatus"].ToString().Trim();

                            string LateBy = row["LateBy"].ToString().Trim();

                            string PlatformName = row["PlatformName"].ToString().Trim();

                            string CoachePos = "";


                            prepareCgdbReportData(TrainNo, TrainNameEng, RArrivalTime, RDepartureTime, ArrivingStatus, LateBy, PlatformName, CoachePos);
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        public static void prepareReportData(string TrainNo, string TrainNameEng, string RArrivalTime, string RDepartureTime, string ArrivingStatus, string StatusName, string LateBy, string LArrivalTime, string LDepartureTime, string PlatformName, string EStation, string HStation, string RStation, string CoachePos, string Terminate_Diverted)
        {
            preparePfdbReportData(TrainNo, TrainNameEng, RArrivalTime, RDepartureTime, ArrivingStatus, StatusName, LateBy, LArrivalTime, LDepartureTime, PlatformName, EStation, HStation, RStation, CoachePos, Terminate_Diverted);

            prepareAgdbReportData(TrainNo, TrainNameEng, RArrivalTime, RDepartureTime, ArrivingStatus, StatusName, LateBy, LArrivalTime, LDepartureTime, PlatformName, EStation, HStation, RStation, CoachePos, Terminate_Diverted);
            prepareIVDReportData(TrainNo, TrainNameEng, RArrivalTime, RDepartureTime, ArrivingStatus, StatusName, LateBy, LArrivalTime, LDepartureTime, PlatformName, EStation, HStation, RStation, CoachePos, Terminate_Diverted);

            prepareOVDReportData(TrainNo, TrainNameEng, RArrivalTime, RDepartureTime, ArrivingStatus, StatusName, LateBy, LArrivalTime, LDepartureTime, PlatformName, EStation, HStation, RStation, CoachePos, Terminate_Diverted);

        }
        public static void preparePfdbReportData(string TrainNo, string TrainNameEng, string RArrivalTime, string RDepartureTime, string ArrivingStatus, string StatusName, string LateBy, string LArrivalTime, string LDepartureTime, string PlatformName, string EStation, string HStation, string RStation, string CoachePos, string Terminate_Diverted)

        {
            try
            {


                List<int> packetIdentifiers = new List<int> { 3, 5 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                foreach (DataRow row in boards.Rows)
                {
                    string ipaddress = row["IPAddress"].ToString().Trim();

                    ReportDb.InsertTaddbDataReport(TrainNo, TrainNameEng, RArrivalTime, RDepartureTime, ArrivingStatus, StatusName, LateBy, LArrivalTime, LDepartureTime, PlatformName, EStation, HStation, RStation, CoachePos, Terminate_Diverted, ipaddress);



                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }
        public static void prepareOVDReportData(string TrainNo, string TrainNameEng, string RArrivalTime, string RDepartureTime, string ArrivingStatus, string StatusName, string LateBy, string LArrivalTime, string LDepartureTime, string PlatformName, string EStation, string HStation, string RStation, string CoachePos, string Terminate_Diverted)

        {
            try
            {


                List<int> packetIdentifiers = new List<int> { 7 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                foreach (DataRow row in boards.Rows)
                {
                    string ipaddress = row["IPAddress"].ToString().Trim();

                    ReportDb.InsertOVDDataReport(TrainNo, TrainNameEng, RArrivalTime, RDepartureTime, ArrivingStatus, StatusName, LateBy, LArrivalTime, LDepartureTime, PlatformName, EStation, HStation, RStation, CoachePos, Terminate_Diverted, ipaddress);



                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }
        public static void prepareIVDReportData(string TrainNo, string TrainNameEng, string RArrivalTime, string RDepartureTime, string ArrivingStatus, string StatusName, string LateBy, string LArrivalTime, string LDepartureTime, string PlatformName, string EStation, string HStation, string RStation, string CoachePos, string Terminate_Diverted)

        {
            try
            {


                List<int> packetIdentifiers = new List<int> { 6 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                foreach (DataRow row in boards.Rows)
                {
                    string ipaddress = row["IPAddress"].ToString().Trim();

                    ReportDb.InsertIVDDataReport(TrainNo, TrainNameEng, RArrivalTime, RDepartureTime, ArrivingStatus, StatusName, LateBy, LArrivalTime, LDepartureTime, PlatformName, EStation, HStation, RStation, CoachePos, Terminate_Diverted, ipaddress);



                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }
        public static void prepareAgdbReportData(string TrainNo, string TrainNameEng, string RArrivalTime, string RDepartureTime, string ArrivingStatus, string StatusName, string LateBy, string LArrivalTime, string LDepartureTime, string PlatformName, string EStation, string HStation, string RStation, string CoachePos, string Terminate_Diverted)

        {
            try
            {


                List<int> packetIdentifiers = new List<int> { 4 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                foreach (DataRow row in boards.Rows)
                {
                    string ipaddress = row["IPAddress"].ToString().Trim();
                    DataTable coachPositionsdt = OnlineTrainsDao.getTempCoachPositionsByTrainNumber(TrainNo);

                    string coachpositions = "";
                    foreach (DataRow coachRow in coachPositionsdt.Rows)
                    {
                        coachpositions = coachRow["coachPositions"].ToString();


                    }
                    CoachePos = coachpositions;

                    ReportDb.InsertAgdbDataReport(TrainNo, TrainNameEng, RArrivalTime, RDepartureTime, ArrivingStatus, StatusName, LateBy, LArrivalTime, LDepartureTime, PlatformName, EStation, HStation, RStation, CoachePos, Terminate_Diverted, ipaddress);



                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }
        public static void prepareCgdbReportData(string TrainNo, string TrainNameEng, string RArrivalTime, string RDepartureTime, string ArrivingStatus, string LateBy, string PlatformName, string CoachePos)
        {
            try
            {


                List<int> packetIdentifiers = new List<int> { 1 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);


                foreach (DataRow row in boards.Rows)
                {
                    string ipaddress = row["IPAddress"].ToString().Trim();
                    string Platform = row["Platform"].ToString().Trim();

                    if (PlatformName == Platform)
                    {
                        DataTable coachPositionsdt = OnlineTrainsDao.getTempCoachPositionsByTrainNumber(TrainNo);

                        string coachpositions = "";
                        foreach (DataRow coachRow in coachPositionsdt.Rows)
                        {
                            coachpositions = coachRow["coachPositions"].ToString();


                        }
                        CoachePos = coachpositions;

                        ReportDb.InsertCgdbDataReport(TrainNo, TrainNameEng, RArrivalTime, RDepartureTime, ArrivingStatus, LateBy, PlatformName, CoachePos, ipaddress);


                    }



                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }
        public static bool LateEnabled(string currentStatus)
        {


            if (currentStatus == "Running Right Time" || currentStatus == "Running Late" || currentStatus == "Delay Departure" || currentStatus == "Regulated" || currentStatus == "Rescheduled" || currentStatus == "Change of Source")
            {
                return false;
            }

            return true;

        }

        public static bool checklatetime(string currentStatus)
        {


            if (currentStatus == "Running Late" || currentStatus == "Delay Departure" || currentStatus == "Regulated" || currentStatus == "Rescheduled")
            {
                return true;
            }

            return false;

        }
        public static bool ValidateTadbStatus()
        {
            try
            {

                if (!BaseClass.IsNtesEnabled() && BaseClass.IsLocalAutoMode())
                {


                    foreach (DataRow row in BaseClass.OnlineTrainsTaddbDt.Rows)
                    {

                        bool tadb = Convert.ToBoolean(row["Tadb"].ToString().Trim());
                        if (tadb)
                        {


                            string StatusName = row["StatusName"].ToString().Trim();

                            bool isLateRequired = checklatetime(StatusName);
                            if (isLateRequired)
                            {
                                if (row["LateBy"].ToString().Trim() == "00:00")
                                {
                                    return false;
                                }

                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return true;
        }

        public static bool CheckPlatformedrequiredexists(DataTable onlinetrainsdt)
        {
            bool valid = false;
            foreach (DataRow row in onlinetrainsdt.Rows)
            {
                string trainStatus = row["StatusName"]?.ToString();
                string platform = row["PlatformName"]?.ToString()?.Trim();
                string ad = row["ArrivingStatus"]?.ToString();
                string trainno = row["TrainNo"]?.ToString();

                int statusCode = BaseClass.getStatusCode(trainStatus, ad);

                // Check if the platform is required and not provided
                if ((statusCode == 2 || statusCode == 3 || statusCode == 4 || statusCode == 9 ||
                     statusCode == 12 || statusCode == 13 || statusCode == 14 || statusCode == 17 || statusCode == 18) &&
                    (string.IsNullOrEmpty(platform) || platform == "--"))
                {
                    MessageBox.Show(trainStatus + " Required A Platform Number for the Train No " + trainno);
                    valid = true;
                    break;
                }
            }
            return valid;
        }






        public static bool sendTaddbData()
        {
            BaseClass.ButtonStatus = "Taddb";
            bool status = false;
            bool DataStatus = false;
            try
            {
                BaseClass.OnlineTrainsTaddbDt = OnlineTrainsDao.GetScheduledTaddbTrains();

                BaseClass.OnlineTrainsTaddbDt = BaseClass.ModifiedOnlinetrainsdt(BaseClass.OnlineTrainsTaddbDt);

                BaseClass.OldOnlineTrainsTaddbDt = BaseClass.OnlineTrainsTaddbDt;

                bool sucess = ValidateTadbStatus();
                if (sucess)
                {
                    Server.getBoardsIpAdress();

                    bool check = BaseClass.OnlineTrainsTaddbDt.Rows.Count > 0 ? true : false;
                    if (check)
                    {
                        if(!BaseClass.IsNtesEnabled())
                         status = DataController.CheckPlatformedrequiredexists(BaseClass.OnlineTrainsTaddbDt);
                        if (!status)
                        {

                            if (Server.isLanConnected)
                            {

                                if (Server._connectedClients.Count > 0)
                                {
                                    BaseClass.GetAllStatusDt = OnlineTrainsDao.GetAllStatus();
                                    sendDataToBoards();
                                    OnlineTrainsDao.InsertRefreshData();

                                    DataStatus = true;
                                }
                                else
                                {
                                    CCTVController.CCTVsendData();
                                    string Error = "Sending Failed To Board ";
                                    string ErDescription = "Boards Not Connected";
                                    ReportDb.InsertErrorLog(Error, ErDescription);
                                    if (!BaseClass.IsNtesAutoMode() && !BaseClass.IsLocalAutoMode())
                                        MessageBox.Show("Wait Boards are Connecting ....");
                                }
                                SplitingTadbScheduleData();

                            }
                            else
                            {
                                if (!BaseClass.IsNtesAutoMode() && !BaseClass.IsLocalAutoMode())
                                    MessageBox.Show("Lan disconnected");
                                CCTVController.CCTVsendData();
                            }
                          
                        }

                    }
                    else
                    {
                        if (!BaseClass.IsNtesAutoMode() && !BaseClass.IsLocalAutoMode())
                        {
                            DialogResult dialogResult = MessageBox.Show("Do you want to Clear All TADDB Boards", "Send Confirmation", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                ClearAllBoards();
                            }
                            else
                            {
                                MessageBox.Show("please Select Atleast One Train");
                            }
                        }
                    }
                }
                else
                {

                    if (!BaseClass.IsNtesAutoMode() && !BaseClass.IsLocalAutoMode())
                        MessageBox.Show("Plesae Enter Late Time");
                }

                frmOnlineTrains frmOnline;

                Form mainForm = Application.OpenForms["frmOnlineTrains"];

                if (mainForm != null)
                {
                    frmOnline = (frmOnlineTrains)mainForm;
                }
                else
                {
                    frmOnline = new frmOnlineTrains();
                }
                frmOnline.ShowDataSucessfullyMessage(DataStatus);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }



            BaseClass.WritingThirdpartyTextfile();

            return DataStatus;

        }



        public static void sendDataToBoards()
        {
            try
            {

                BaseClass.regionalGapCode = OnlineTrainsDao.GetTopRegGapCode();
                BaseClass.PlatformsSize = BaseClass.GetPlatformSize();
                BaseClass.getLanguageSequence();
                CdotController.GetCdotConfigData();

                MldbController.MLDBsendData();
                AgdbController.AGDBsendData();
                PfdbController.PFDBsendData();
               IvdOvdController.OVDsendData();
                IvdOvdController.IVDsendData();
                CCTVController.CCTVsendData();
                //  AgdbController.AGDBTrueColorsendData();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public static void ClearAllBoards()
        {
            try
            {
                CCTVController.CCTVsendData();
                List<int> packetIdentifiers = new List<int> { 3, 4, 5, 6, 7 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);



                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in boards.Rows)
                {

                    string ipaddress = row["IPAddress"].ToString();
                    PacketController.clearBoards(ipaddress);

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            BaseClass.OnlineTrainsTaddbDt = OnlineTrainsDao.GetScheduledTaddbTrains();
           
        }
        public static bool sendCgdbData()
        {
            BaseClass.ButtonStatus = "Cgdb";
            bool DataStatus = false;
            try
            {
                SplitingCgdbScheduleData();

                BaseClass.OnlineTrainsCgdbDt = OnlineTrainsDao.GetScheduledCgdbTrains();
                BaseClass.OldOnlineTrainsCgdbDt = BaseClass.OnlineTrainsCgdbDt;
                bool check = BaseClass.OnlineTrainsCgdbDt.Rows.Count > 0 ? true : false;
                if (check)
                {
                    SplitingCgdbScheduleData();
                    bool checkedplatform = CheckPlatformCgdbRows();
                    bool checkedhub = CheckHubPlatformCgdbRows();

                    if (checkedplatform)
                    {
                        MessageBox.Show("Same PlatForm cannot be assigned");
                    }
                    else
                    {
                        if (Server._connectedClients.Count > 0)
                        {
                            CgdbController.DataPacket();
                           
                            DataStatus = true;
                        }

                    }


                }
                else
                {
                    if (!BaseClass.IsNtesAutoMode() && !BaseClass.IsLocalAutoMode())
                        MessageBox.Show("please Select Atleast One Train");
                }

                frmOnlineTrains frmOnline;

                Form mainForm = Application.OpenForms["frmOnlineTrains"];

                if (mainForm != null)
                {
                    frmOnline = (frmOnlineTrains)mainForm;
                }
                else
                {
                    frmOnline = new frmOnlineTrains();
                }
                frmOnline.ShowDataSucessfullyMessage(DataStatus);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            BaseClass.WritingThirdpartyTextfile();
            return DataStatus;
        }
        public static bool CheckPlatformCgdbRows()
        {
            try
            {


                var platforms = new HashSet<string>();


                foreach (DataRow row in BaseClass.OnlineTrainsCgdbDt.Rows)
                {
                    string PlatformNo = row["PlatformName"].ToString().Trim();

                    if (!platforms.Add(PlatformNo))
                    {
                        // If Add returns false, it means the platform already exists in the HashSet
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            // No duplicates found
            return false;
        }
        public static bool CheckHubPlatformCgdbRows()
        {
            try
            {


                var platforms = new HashSet<string>();
                int count = 0;
                foreach (DataRow row in BaseClass.OnlineTrainsCgdbDt.Rows)
                {
                    string PlatformNo = row["PlatformName"].ToString().Trim();

                    if (platforms.Add(PlatformNo))
                    {
                        // Duplicate platform found, check for IP address mismatch
                        string pdcIp = "192.168." + PlatformNo + ".251";

                        foreach (DataRow onerow in BaseClass.EthernetPorts.Rows)
                        {
                            if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                            {
                                string ipAddressStr = onerow["IPAddress"].ToString().Trim();


                                if (pdcIp == ipAddressStr)
                                {
                                    count++;

                                }

                            }
                        }
                    }
                }

                if (count == BaseClass.OnlineTrainsCgdbDt.Rows.Count)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            // No duplicates found with mismatched IP addresses
            return false;
        }

        public static void SendNtesData()
        {

            bool sucess = DataController.sendTaddbData();
            if (sucess)
            {
                MessageBox.Show("Data Sent SucessFully");
            }
            else
            {
                if (BaseClass.OnlineTrainsTaddbDt.Rows.Count == 0)
                {
                    if (!BaseClass.IsNtesEnabled() && BaseClass.IsLocalAutoMode())
                        MessageBox.Show("please Select Atleast One Train");
                }
                else
                {
                    if (!BaseClass.IsNtesEnabled() && BaseClass.IsLocalAutoMode())
                        MessageBox.Show("Wait Boards are Connecting ....");

                }
            }

        }
        public static void CheckTrainsLeftOrNotAndClaerData()
        {

            DataTable NewOnlineTrainsTADDBdt= OnlineTrainsDao.GetScheduledTaddbTrains();

            DataTable NewOnlineTrainsCGDBdt = OnlineTrainsDao.GetScheduledCgdbTrains();

            DataTable Taddbdt = BaseClass.CompareDataTablesGiveMeSameData(BaseClass.OldOnlineTrainsTaddbDt, NewOnlineTrainsTADDBdt);

            DataTable cgdbdt = BaseClass.CompareDataTablesGiveMeDifferentData(BaseClass.OldOnlineTrainsCgdbDt, NewOnlineTrainsCGDBdt);

            AutomaticClearCgdbTaddbData(cgdbdt, Taddbdt);

            ClearAllWithOutPlatformCgdbData(NewOnlineTrainsCGDBdt);
        }


        public static void ClearAllWithOutPlatformCgdbData(DataTable NewCgdt)
        {
            if(NewCgdt==null || NewCgdt.Rows.Count==0)
            {
                foreach(string PlatformNo in BaseClass.Platforms)
                {
                    string platform = BaseClass.ConvertPlatformToIp(PlatformNo);
                    if (platform != "--")
                    {
                        string pdcIp = "192.168." + platform + ".251";
                        int packetidentifier = Board.CGDB;
                        //  StopCommand(pdcIp, packetidentifier);
                        frmOnlineTrains.Deletecgdbdata(pdcIp);


                    }

                }
            }
        }


        public static void AutomaticClearCgdbTaddbData(DataTable Cgdbdt, DataTable Taddbdt)
        {
            if (Cgdbdt != null && Cgdbdt.Rows.Count > 0)
            {
                foreach (DataRow row in Cgdbdt.Rows)
                {
                    string PlatformNo = row["PlatformName"].ToString().Trim();


                    string platform = BaseClass.ConvertPlatformToIp(PlatformNo);
                    if (platform != "--")
                    {
                        string pdcIp = "192.168." + platform + ".251";
                        int packetidentifier = Board.CGDB;
                        //  StopCommand(pdcIp, packetidentifier);
                        frmOnlineTrains.Deletecgdbdata(pdcIp);
                        

                    }

                }
            }
            if (Taddbdt != null && Taddbdt.Rows.Count > 0)
            {
                if (!BaseClass.IsNtesAutoMode())
                    DataController.sendTaddbData();
            }
            else
            {
                
            }

        }

        public static void sendAllBoardsData()
        {
            try
            {


                sendTaddbData();
                sendCgdbData();

                if (BaseClass.IsNtesEnabled())
                {

                    if (BaseClass.IsNtesAudio())
                    {
                        AnnouncementController.UpdateStatus("STOP");
                        AnnouncementController.UpdateAudioPlayStatus("Completed");
                        OnlineTrainsDao.UpdateAnnToTrue();
                        AnnouncementController.playAnnounceMentData();
                    }
                }
                else if (BaseClass.IsLocalAutoMode())
                {
                    AnnouncementController.UpdateStatus("STOP");
                    AnnouncementController.UpdateAudioPlayStatus("Completed");
                    AnnouncementController.playAnnounceMentData();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }













    }
}
