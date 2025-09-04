using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms;
using ArecaIPIS.Server_Classes;

namespace ArecaIPIS
{
    class BaseClass
    {
        public static int CurrentPollMins = 3;
        public static DataTable specialMessages = new DataTable();
        public static bool ManualStart = false;
        public static bool SlaveApplicationStatus = false;
        public static bool SlaveServermode = false;
        public static bool Slaveclientmode = false;
        public static bool ApplicationStatus = false;
        public static bool ServerMode = false;
        public static bool clientMode = false;
        public static DataTable AllCoachesClass = new DataTable();

        public static bool SlaveConnect = false;

        public static int TypeInt = 0;
        public static int TypeBool =1;
        public static int TypeDataTable = 2;
        public static int TypeDataSet = 3;
        public static int TypeString = 4;
        public static int Type_List_String = 5;


        public static int SchStatCode = 0;
        public static int CurrentStatuCode=1;
        public static List<int> defectiveLines;
        // frmHome frmhome = new frmHome();
        public static string currentMessage = "";
        public static string boardType = "";
        public static int regionalGapCode = OnlineTrainsDao.GetTopRegGapCode();
        public static string PlatformsSize = GetPlatformSize();
        public static int gap = 10;
        public static int noOfLines = 1;
        public static int InfoDisplayed = 0;
        public static bool boardWorkingstatus = true;
        public static bool boardMessagesstatus = true;
        public static string checkedplatforms = "";
        public static int currentfontsize = 4;
        public static int timeDelay = 10;
        public static string CurrentLang = "";
        public static int trainsCount = 0;
        public static string trainStatus = "";
        public static DataGridViewRow currentdatgridRow;
        public static List<byte> windowsDataPacket = new List<byte>();

        public static DataTable OnlineTrainsTaddbDt;
        public static DataTable OnlineTrainsCgdbDt;

        public static DataTable OldOnlineTrainsTaddbDt;
        public static DataTable OldOnlineTrainsCgdbDt;

        public static string currentTrainStatusName = "";
        public static string currentTrainName = "";
       
        public static string currentCity = "";
        public static List<string> trainStatusNamesList = new List<string>();
        public static List<int> trainStatusPkeysList = new List<int>();
        public static string langSequence = "";
        public static List<int> NormalWindows = new List<int>();
        public static List<int> SpecialWindows = new List<int>();
        public static byte[] finalTaddbETX = new byte[] { 03, 00, 00, 04 };
        public static byte[] stratingBytes = new byte[] { 00, 00, 00, 00, 00, 00 };
        public static byte[] endingBytes = new byte[] { 255, 255 };
        public static byte[] emptyWindow = new byte[] { 255, 255, 255, 255 };
        public static byte[] characterString = new byte[] { 00, 00, 00, 00, 01 };
        public static byte[] Seperators = new byte[] { 231, 00 };
        public static byte[] OvdIvdSeperators = new byte[] { 00, 04 };
        public static byte[] PfdbMldbEmptyData = new byte[] { 00, 32, 00, 32, 00, 32 };
        public static byte[] OvdIvdcharacterString = new byte[] { 00, 00, 00, 01 };
        public static byte[] AgdbExptSeperators = PfdbController.ConvertDecimalNumberTOByteArray(67);
        public static byte[] SingleLineAgdbAdSeperators = PfdbController.ConvertDecimalNumberTOByteArray(340);
        public static byte[] AgdbAdSeperators = PfdbController.ConvertDecimalNumberTOByteArray(125);
        public static byte[] AgdbPfSeperators = PfdbController.ConvertDecimalNumberTOByteArray(154);
        public static byte[] AgdbEndBoardSeperators = PfdbController.ConvertDecimalNumberTOByteArray(192);
        public static byte[] SingleLineAgdbPfSeperators = PfdbController.ConvertDecimalNumberTOByteArray(358);

        public static byte[] IvdOvdEmptyData = new byte[] { 00, 32, 00, 32, 00, 32 };
        public static List<string> specialStatusData = new List<string>();
        public static byte[] ExptTimeSeperators = PfdbController.ConvertDecimalNumberTOByteArray(250);
        public static byte[] ADSeperators = PfdbController.ConvertDecimalNumberTOByteArray(295);
        public static byte[] PFSeperators = PfdbController.ConvertDecimalNumberTOByteArray(310);
        public static string TaddbWindowsEightbit;
        public static string TaddbWindowsNinthbit;
        public static string TaddbWindowsTenthbit;
        public static string TaddbWindowsEleventhbit;
        public static int SelectedTDBRows = 0;
        public static List<byte> taddbDataPacket = new List<byte>();
        public static List<byte> hindiTaddbDataPacket = new List<byte>();
        public static List<DataGridViewRow> TaddbRows = new List<DataGridViewRow>();
        public static List<string> stationCodes = new List<string>();
        public static List<string> trainNumbers = new List<string>();

        public static List<string> allowedDuplicates = new List<string> { "GEN", "ENG", "SLRD", "SLR", "" };
        public static DataTable IntegrationData = new DataTable();

        public static string TaddbDisplaySeq = "";
        public static string UserName { get; set; }
        public static int Userrole { get; set; }
        public static string Userrolename { get; set; }
       
        public static List<DataGridViewRow> CgdbRows = new List<DataGridViewRow>();
       
        public static int SelectedCGDBRows = 0;

        public static string btnPause = "";

        public static int AnnouncementCount = 0;


        public static DataTable SelectionRegionalLanguagesDt = new DataTable();
        public static DataTable DisplayEffectsDt = new DataTable();
        public static DataTable LetterSpeedDt = new DataTable();

        public static DataTable AnnouncementDt = new DataTable();

        public static DataTable FormatTypeDt = new DataTable();
        public static DataTable FormatsDt = new DataTable();
        public static DataTable FontSizeDt = new DataTable();
        public static DataTable LetterGapDt = new DataTable();
        public static DataTable infoDisplayDt = new DataTable();
        public static DataTable SpeedDt = new DataTable();
        public static DataTable MediaTypeDt = new DataTable();
        public static DataTable VolumeDt = new DataTable();
        public static DataTable EntryEffectDt = new DataTable();
        public static DataTable MessageFontSizeDt = new DataTable();
        public static DataTable MessageCharacterGapDt = new DataTable();
        public static DataTable EthernetPorts = new DataTable();
        public static DataTable CgdbPorts = new DataTable();
        public static DataTable PacketIdentifier = new DataTable();
        public static DataTable coachBitmap = new DataTable();
        public static DataTable CgdbHubPorts = new DataTable();
        public static DataTable SchedulestatusDt = new DataTable();
        public static DataTable ClearingEffectsDt = new DataTable();
        public static DataTable AdminRolesDt = new DataTable();
        public static DataTable AdminMenussDt = new DataTable();
        public static DataTable ipadressTable = new DataTable();
        public static DataTable AutomaticRunningdt = new DataTable();

        public static DataTable NTESCONFIGURATIONdt = new DataTable();

        public static DataTable MediaPlayListwithusername = new DataTable();

        public static bool NtesEnable { get; private set; }

        public static bool NtesAutoMode { get; private set; }

        public static bool NtesAudio { get; private set; }

        public static bool CdotEnable { get; private set; }

        public static bool CdotAutoMode { get; private set; }

        public static string CdotpollingTimeInterval { get; private set; }

        public static bool LocalAutoMode { get; private set; }

       
        public static bool LocalAutoDeletion { get; private set; }
        public static void getLanguageSequence()
        {
            List<string> languageSequence = new List<string>(BaseClass.TaddbDisplaySeq.Split(','));
            foreach (string language in languageSequence)
            {
                string trimmedLanguage = language.Trim();
                var result = BaseClass.SelectionRegionalLanguagesDt.AsEnumerable()
                    .Where(row => row.Field<string>("LanguageName") == trimmedLanguage)
                    .Select(row => row.Field<int>("Pkey_Language"))
                    .FirstOrDefault();
                if (result != 0)
                {
                    BaseClass.languageSequencepk.Add(result);
                }
            }
        }
        public static string LocalAutoModeTimeInterval { get; private set; }

        public static string LocalAutoDeletionTimeInterval { get; private set; }

        //public static bool ModeType { get; private set; }

        //public static bool AutoDeletion { get; private set; }
        public static bool ApllicationStart = true;


        public static bool blankCgdb = true;

        public static bool CgdbHAbove16 = true;

        public static bool NtesplatformUpdate = true;

        public static int StationPkId { get; set; }
        public static string StationName { get; set; }

        public static string StationCode { get; set; }
        public static string DivisionCode { get; set; }
        public static string RegionalLanguage1pk { get; set; }
        public static string UpStationCode { get; set; }
        public static string DownStationCode { get; set; }
        public static int OnlineRows { get; set; }
        public static int PortNo { get; set; }
        public static int MainsCoachDisplay { get; set; }
        public static int NoOfPlatforms { get; set; }



     //Arrival
  
        public static int ARunningRightTime = 1;    
        public static int WillArriveShortly = 2;
        public static int IsArrivingOn = 3;
        public static int HasArrivedOn = 4;
        public static int RunningLate = 5;
        public static int ACancelled = 6;
        public static int IndefiniteLate = 7;
        public static int TerminatedAt = 8;
        public static int APlatformChanged = 9;

        //Departure

        public static int DRunningRightTime = 10;
        public static int DCancelled = 11;
        public static int IsReadyToLeave = 12;
        public static int IsOnPlatform = 13;
        public static int Departed = 14;
        public static int Rescheduled = 15;
        public static int Diverted = 16;
        public static int DelayDeparture = 17;
        public static int DPlatformChanged = 18;
        public static int ChangeOfSource = 19;
        public static int Regulated = 20;
       
 




        public static List<string> Languages { get; set; } = new List<string>();
        public static List<string> Platforms { get; set; } = new List<string>();
        public static List<string> DisplayEffects { get; set; } = new List<string>();
        public static List<string> LetterSpeedlist { get; set; } = new List<string>();
    
        public static List<string> TrainTypes { get; set; } = new List<string>();
        public static List<string> FormatTypeList { get; set; } = new List<string>();

        public static List<string> FormatsList { get; set; } = new List<string>();
        public static List<string> infoDisplayList { get; set; } = new List<string>();
        public static List<string> FontSizeList { get; set; } = new List<string>();

        public static List<string> LetterGapList { get; set; } = new List<string>();

        public static List<string> SpeedList { get; set; } = new List<string>();
        public static List<string> MediaTypeList { get; set; } = new List<string>();

        public static List<string> VolumeList { get; set; } = new List<string>();
        public static List<string> EntryEffectList { get; set; } = new List<string>();
        public static List<string> MessageFontSizeList { get; set; } = new List<string>();

        public static List<string> MessageCharacterGapList { get; set; } = new List<string>();
        public static List<string> ClearingEffectsList { get; set; } = new List<string>();
        public static List<string> AdminRolesList { get; set; } = new List<string>();

        public static List<string> LinkedTrainsList { get; set; } = new List<string>();


        public static List<int> languageSequencepk = new List<int>();

        public static List<string> designNames = new List<string>();
        public static int CurrentTrainIndex = 0;

        public static DataTable GetAllStatusDt = OnlineTrainsDao.GetAllStatus();



        static BaseClass()
        {
            // Initialize the Languages list here if needed
            // Example: Languages = new List<string>();
        }

        public static int convertBinaryToDecimal(string binaryValue)
        {


            int decimalValue = Convert.ToInt32(binaryValue, 2); // Convert binary to decimal

            return decimalValue;


        }
        public static List<string> LinkedTrainsFilter = new List<string>();
        public static DataTable ModifiedOnlinetrainsdt(DataTable onlinetrainsdt)
        {
            try
            {
                LinkedTrainsFilter.Clear();

                // List to store rows to delete
                List<DataRow> rowsToDelete = new List<DataRow>();
                List<string> selectedtrains = new List<string>();

                HashSet<string> processedTrains = new HashSet<string>();

                // Collect train numbers from the DataTable
                foreach (DataRow row in onlinetrainsdt.Rows)
                {
                    string trainNo = row["TrainNo"].ToString().Trim();
                    selectedtrains.Add(trainNo);
                }

                // Iterate over train numbers
                foreach (string train in selectedtrains)
                {
                    if (BaseClass.LinkedTrainsList.Contains(train))
                    {
                        string linkedtrainNum = BaseClass.GetLinktrain(train);

                        if (!processedTrains.Contains(train))
                        {



                            if (selectedtrains.Contains(linkedtrainNum))
                            {
                                // Find rows for the train and linked train
                                DataRow trainRow = null;
                                DataRow linkedTrainRow = null;

                                foreach (DataRow row in onlinetrainsdt.Rows)
                                {
                                    string trainNo = row["TrainNo"].ToString().Trim();

                                    if (train == trainNo)
                                    {
                                        trainRow = row;
                                    }

                                    if (linkedtrainNum == trainNo)
                                    {
                                        linkedTrainRow = row;
                                    }
                                }

                                // Check if both rows have AD status "D" and mark for deletion
                                if (trainRow != null && linkedTrainRow != null)
                                {
                                    string trainADstatus = trainRow["ArrivingStatus"].ToString().Trim();
                                    string linkedTrainADstatus = linkedTrainRow["ArrivingStatus"].ToString().Trim();
                                    string trainstatus = trainRow["StatusName"].ToString().Trim();
                                    string linkedTrainstatus = linkedTrainRow["StatusName"].ToString().Trim();

                                    if (trainADstatus == "D" && linkedTrainADstatus == "D" && trainstatus== linkedTrainstatus)
                                    {
                                        LinkedTrainsFilter.Add(train);
                                        // rowsToDelete.Add(trainRow);
                                        rowsToDelete.Add(linkedTrainRow);
                                        processedTrains.Add(linkedtrainNum);
                                    }
                                }
                            }
                        }
                    }
                }

                // Remove rows marked for deletion
                foreach (DataRow row in rowsToDelete)
                {
                    onlinetrainsdt.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            // Return the modified DataTable
            return onlinetrainsdt;
        }


        public static void GetAllTrainsNumbers()
        {
            try
            {
               DataTable AllTrainsdt = OnlineTrainsDao.GetAllTrains();

                trainNumbers.Clear();

                if (AllTrainsdt.Rows.Count > 0)
                {
                    foreach (DataRow row in AllTrainsdt.Rows)
                    {
                        string trainno = row.Field<string>("TrainNumber");
                        trainNumbers.Add(trainno);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        public static void setAutomaticRunning()
        {
            try
            {

            
            AutomaticRunningdt = CommonSettingsDb.GetAutomaticRunning();

            if (AutomaticRunningdt.Rows.Count > 0)
            {
                DataRow row = AutomaticRunningdt.Rows[0];
               //ManualMode = row.Field<bool>("ManualMode");
               LocalAutoMode = row.Field<bool>("AutoMode");
               LocalAutoModeTimeInterval = row.Field<string>("DataSentToBorads");
                LocalAutoDeletion = row.Field<bool>("Deletion");
                LocalAutoDeletionTimeInterval = row.Field<int>("Time_Deletion").ToString();
            }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public static bool GettruecolorAgdbstatus(string ipaddress)
        {
            bool status = false;
            try
            {
               

                DataTable dt=  HubConfigurationDb.GettruecolorBoardDetails(ipaddress);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    status = row.Field<bool>("Truecolorstatus");
                
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return status;
        }
        public static bool Getinteroperabilitystatus(string ipaddress)
        {
            bool status = false;
            try
            {


                DataTable dt = BaseClass.EthernetPorts;

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                    {
                        string ip = row["IPAddress"].ToString();
                        if(ip== ipaddress)
                        {
                            status = row.Field<bool>("interoperability");
                        }

                        
                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return status;
        }

        public static void setNtesConfiguration()
        {
            try
            {

            
            NTESCONFIGURATIONdt = InterfaceDb.GetNtesConfiguration();

            if (NTESCONFIGURATIONdt.Rows.Count > 0)
            {
                DataRow row = NTESCONFIGURATIONdt.Rows[0];
                NtesEnable = row.Field<bool>("NTESEnable");
                NtesAutoMode = row.Field<bool>("AutoMode");
                NtesAudio = row.Field<bool>("Audio");
                BaseClass.CurrentPollMins =Convert.ToInt32(row.Field<string>("PollingInterval"));
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public static bool IsNtesEnabled()
        {
            return NtesEnable;
        }
        public static bool IsNtesAutoMode()
        {
            return NtesAutoMode;
        }
        public static bool IsNtesAudio()
        {
            return NtesAudio;
        }
        public static bool IsLocalAutoMode()
        {
            return LocalAutoMode;
        }
        public static bool IsLocalAutoDeletion()
        {
            return LocalAutoDeletion;
        }

        public static string convertDecimalToBinary(int decimalValue)
        {
            try
            {

            string binaryValue = Convert.ToString(decimalValue, 2); // Convert decimal to binary

            // Ensure the binary string is at least 3 characters wide
            string paddedBinaryValue = binaryValue.PadLeft(3, '0');

            return paddedBinaryValue;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
        public static string getStatusName(string lang, string AD, string status)
        {
            string langStatus = "";
            string statusfor = "";
            string StatusNa = "";
            try
            {
            foreach (DataRow row in GetAllStatusDt.Rows)
            {
                statusfor = row["StatusFor"].ToString();
                StatusNa = row["StatusName"].ToString();
                if (statusfor == AD && StatusNa == status)
                {
                    if (lang == "eng")
                    {
                        langStatus = row["StatusName"].ToString();
                    }
                    else if (lang == "hin")
                    {
                        langStatus = row["HStatus"].ToString();
                    }
                    else if (lang == "reg")
                    {
                        langStatus = row["RStatus"].ToString();
                    }


                }
            }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return langStatus;
        }

      

        public static byte getStatusCode(string status, string AD)
        {
            string statusCode = "0";
            string StatusAD = "";
            string StatusName = "";

            try
            {
                foreach (DataRow row in GetAllStatusDt.Rows)
                {
                    StatusName = row["StatusName"].ToString();
                    StatusAD = row["StatusFor"].ToString();
                    if (StatusAD == AD && StatusName == status)
                    {
                        statusCode = row["StatusCode"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return (byte)Convert.ToInt32(statusCode);
                Server.LogError(ex.Message);
            }

            return (byte)Convert.ToInt32(statusCode);
        }
        public static string GetPacketname(int packetIdentifier)
        {
            try
            {

            foreach (DataRow row in BaseClass.PacketIdentifier.Rows)
            {
                if (BaseClass.PacketIdentifier.Columns.Contains("pk") && int.TryParse(row["pk"].ToString(), out int packetno))
                {
                    if (packetno == packetIdentifier)
                    {
                        return row["Packet_name"].ToString();
                    }
                }
            }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }

        public static void setipAddress()
        {
            try
            {
                // Ensure the DataTable is instantiated if it hasn't been already
                if (ipadressTable != null)
                {
                    ipadressTable = new DataTable();
                    // Add columns to the DataTable
                   
                }

                ipadressTable.Columns.Add("IPAddress", typeof(string));
                ipadressTable.Columns.Add("PacketIdentifier", typeof(int));
                ipadressTable.Columns.Add("cdcId", typeof(int));

                // Call the method to get all boards
                GetAllBoards();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                // Log or handle the exception as needed
                //MessageBox.Show($"An error occurred while setting the IP address: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string GetPlatformSize()
        {
            string pfSize = "";
            try
            {

                DataTable size = OnlineTrainsDao.GetPlatformNumberSize();
                pfSize = size.Rows[0].Field<string>("PlatformNumberSize").ToString().Trim();

                if(PlatformsSize!="3")
                {
                    BaseClass.ExptTimeSeperators = PfdbController.ConvertDecimalNumberTOByteArray(254);
                    BaseClass.ADSeperators = PfdbController.ConvertDecimalNumberTOByteArray(304);
                    BaseClass.PFSeperators= PfdbController.ConvertDecimalNumberTOByteArray(317);
                }
                else
                {
                    BaseClass.ExptTimeSeperators = PfdbController.ConvertDecimalNumberTOByteArray(250);
                    BaseClass.ADSeperators = PfdbController.ConvertDecimalNumberTOByteArray(295);
                    BaseClass.PFSeperators = PfdbController.ConvertDecimalNumberTOByteArray(310);
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return pfSize;

        }
        public static void GetAllBoards()
        {
            try
            {
               

                // Adding Cgdb Ipaddress
                BaseClass.setCgdbHub();
                int packetIdentifier = 2;

                // Iterate through each row in the DataTable and add to the new DataTable
                foreach (DataRow eachrow in BaseClass.CgdbHubPorts.Rows)
                {
                    string ipAddress = eachrow["Cgdb_IpAddress"].ToString();
                    string cdcid = eachrow["fkey_CDC"].ToString();

                    // Add a new row to the DataTable
                    DataRow newRow = ipadressTable.NewRow();
                    newRow["IPAddress"] = ipAddress;
                    newRow["PacketIdentifier"] = packetIdentifier;
                    newRow["cdcId"] = cdcid;
                    ipadressTable.Rows.Add(newRow);
                }


                foreach (DataRow eachrow in BaseClass.EthernetPorts.Rows)
                {
                    string ipAddress = eachrow["IPAddress"].ToString();
                    string packetid = eachrow["PacketIdentifier"].ToString();
                    string cdcid = eachrow["PkeyMasterhub"].ToString();
                    // Add a new row to the DataTable
                    DataRow newRow = ipadressTable.NewRow();
                    newRow["IPAddress"] = ipAddress;
                    newRow["PacketIdentifier"] = packetid;
                    newRow["cdcId"] = cdcid;
                    ipadressTable.Rows.Add(newRow);
                }


            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
               // MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }

        public static (int Hours, int Minutes) GetCurrentHoursAndMinutes()
        {
            DateTime now = DateTime.Now;
            int hours = now.Hour;
            int minutes = now.Minute;
            return (hours, minutes);
        }
        public static (int Hours, int Minutes) GetHoursAndMinutes(string time)
        {
            if (TimeSpan.TryParse(time, out TimeSpan parsedTime))
            {
                int hours = parsedTime.Hours;
                int minutes = parsedTime.Minutes;
                return (hours, minutes);
            }
            else
            {
                throw new ArgumentException("Invalid time format. Please provide a time in the format HH:mm.");
            }
        }

        public  static void SaveAutoIntensitytoAllBoards(int Intensity)
        {
            try
            {

            
            List<int> packetIdentifiers = new List<int> { 1, 3, 4, 5, 6, 7 };

            // Fetch data from the database
            DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);



            // Import the data from the original DataTable to the new DataTable
            foreach (DataRow row in boards.Rows)
            {

                string ipaddress = row["IPAddress"].ToString();
                BoardDiagnosisDb.UpdateDatabaseWithNewIntensity(ipaddress, Intensity);

            }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }


        public static void GetIndexForm()
            {
            frmIndex frmIndex=null;
            Form form = Application.OpenForms["frmIndex"];

            if (form != null)
            {
                frmIndex = (frmIndex)form;
               
            }
            indexForm = frmIndex;
        }

        public static frmIndex indexForm=null;
        public static void setLanguages()
        {
            try
            {

            
            Languages.Clear();

           
            // Split the comma-separated string of primary key IDs into an array of integers
            int[] regionalLanguageIds = RegionalLanguage1pk.Split(',').Select(int.Parse).ToArray();

            // Populate the Languages list with language names from the DataTable
            foreach (DataRow row in SelectionRegionalLanguagesDt.Rows)
            {
                // Assuming "Pkey_Language" is the name of your primary key column for languages
                int languagePK = Convert.ToInt32(row["Pkey_Language"]);

                // Check if the language primary key is present in the regionalLanguageIds array
                if (regionalLanguageIds.Contains(languagePK))
                {
                    string language = row["LanguageName"].ToString();
                        if(language!= "Devanagari")
                           Languages.Add(language);
                }
            }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        public static void setAdminRoles()
        {
            AdminRolesList.Clear();

            AdminRolesDt = UserDb.GetAdminRoles();
            foreach (DataRow row in BaseClass.AdminRolesDt.Rows)
            {
                AdminRolesList.Add(row["AppRole"].ToString());
            }

        }
        public static void setAdminMenu()
        {

            AdminMenussDt = UserDb.GetMenus();

        }

        public static int GetAdminMenupk(string menuname)
        {


            try
            {

            foreach (DataRow row in AdminMenussDt.Rows)
            {
                string name = row["Menu"].ToString();
                if (name == menuname)
                {
                    return Convert.ToInt32(row["Pkey_Menu"].ToString());
                }


            }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return 0;

        }
        public static string GetAdminMenuDesignName(int menupk)
        {
            try
            {

            foreach (DataRow row in AdminMenussDt.Rows)
            {
                int pk  = Convert.ToInt32(row["Pkey_Menu"].ToString());
                if (pk == menupk)
                {
                    return row["designName"].ToString().Trim();
                }

            }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return "";

        }

        public static int GetAdminRolesPk(string role)
        {
            try
            {

            foreach (DataRow row in BaseClass.AdminRolesDt.Rows)
            {
                string approle = row["AppRole"].ToString();
                if (approle== role)
                {
                    return Convert.ToInt32(row["Pkey_AdminRole"].ToString());
                }

               
            }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return 0;
        }


     
        public static void setDisplayEffects()
        {
            DisplayEffects.Clear();
            DisplayEffectsDt = BaseClassDb.GetDisplayEffects();

            foreach (DataRow row in DisplayEffectsDt.Rows)
            {
                DisplayEffects.Add(row["Name"].ToString());
            }
        }
        public static void setClearingEffects()
        {
            ClearingEffectsList.Clear();
            ClearingEffectsDt = BaseClassDb.GetClearingEffects();

            foreach (DataRow row in ClearingEffectsDt.Rows)
            {
                ClearingEffectsList.Add(row["Name"].ToString());
            }
        }
        public static void setLetterSpeed()
        {
            LetterSpeedlist.Clear();
            LetterSpeedDt = BaseClassDb.GetLetterSpeed();

            foreach (DataRow row in LetterSpeedDt.Rows)
            {
                LetterSpeedlist.Add(row["LetterSpeed"].ToString());
            }
        }
        public static void setinfoDisplay()
        {
            infoDisplayList.Clear();
            infoDisplayDt = BaseClassDb.GetinfoDisplay();

            foreach (DataRow row in infoDisplayDt.Rows)
            {
                infoDisplayList.Add(row["Info_Displayed"].ToString());
            }
        }
        public static void setIVDOVDSpeed()
        {
            SpeedList.Clear();
            SpeedDt = BaseClassDb.GetIVDOVDSpeed();

            foreach (DataRow row in SpeedDt.Rows)
            {
                SpeedList.Add(row["LetterSpeed"].ToString());
            }
        }
        public static void setFormatType()
        {
            FormatTypeList.Clear();
            FormatTypeDt = BaseClassDb.GetFormatType();

            foreach (DataRow row in FormatTypeDt.Rows)
            {
                FormatTypeList.Add(row["FormatType"].ToString());
            }
        }

        public static void setFormats()
        {
            FormatsList.Clear();
            FormatsDt = BaseClassDb.GetFormats();

            foreach (DataRow row in FormatsDt.Rows)
            {
                FormatsList.Add(row["Format"].ToString());
            }
        }
        public static void setFontSize()
        {
            FontSizeList.Clear();
            FontSizeDt = BaseClassDb.GetFontSize();

            foreach (DataRow row in FontSizeDt.Rows)
            {
                FontSizeList.Add(row["Size"].ToString());
            }
        }

        public static void setCgdbBlank()
        {
            try
            {
                DataTable dt = BaseClassDb.getcgdbBlank();

                if (dt.Rows.Count > 0)
                {
                    // Assuming you only need the first row
                    DataRow row = dt.Rows[0];
                    blankCgdb = Convert.ToBoolean(row["Cgdb_Blank"]);
                    CgdbHAbove16 = Convert.ToBoolean(row["cgdb_HAbove16"]);
                    NtesplatformUpdate = Convert.ToBoolean(row["NtesPlatformUpdate"]);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                
            }
        }
        public static void setCgdbHub()
        {
            try
            {
                CgdbHubPorts = BaseClassDb.getCgdbHub();

               
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
               
            }
        }

        public static string GetFontSize(int fontPrimaryKey)
        {
            //DataTable FontSizeDt = BaseClassDb.GetFontSize();

            foreach (DataRow row in FontSizeDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pkey_Fonts"]);

                // Check if the primary key matches the provided key
                if (PK == fontPrimaryKey)
                {
                    string value = row["Size"].ToString();
                    return value;
                }
            }
            return null;
        }
        public static string GetLetterGap(int Key)
        {
           

            foreach (DataRow row in LetterGapDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pkey_LetterGap"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["LetterGap"].ToString();
                    return value;
                }
            }
            return null;
        }

        public static string GetLetterSpeed(int Key)
        {


            foreach (DataRow row in LetterSpeedDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pkey_LetterSpeed"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["LetterSpeed"].ToString();
                    return value;
                }
            }
            return null;
        }
        public static string GetSpeed(int Key)
        {


            foreach (DataRow row in SpeedDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Value"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["LetterSpeed"].ToString();
                    return value;
                }
            }
            return null;
        }

        public static string GetMediaTypeSpeed(int Key)
        {


            foreach (DataRow row in MediaTypeDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pk_IVDOVD_Mediatype"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["Media_Type"].ToString();
                    return value;
                }
            }
            return null;
        }
        public static string Getvolume(int Key)
        {


            foreach (DataRow row in VolumeDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pk_IVDOVD_Volume"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["Volume"].ToString();
                    return value;
                }
            }
            return null;
        }
        public static string Getmediaentryeffectcode(int Key)
        {


            foreach (DataRow row in EntryEffectDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pkey_DisplayEffect"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["Name"].ToString();
                    return value;
                }
            }
            return null;
        }
        public static string GetLinktrain(string trainNumber)
        {
           
            if (BaseClass.LinkedTrainsList.Contains(trainNumber))
            {

                DataTable dt = OnlineTrainsDao.GetLinkedTrainsDetailsbyTrainNo(trainNumber);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        if (trainNumber == row["TrainNo"].ToString())
                        {
                            return row["LinkedTrainNo"].ToString();
                        }

                        else
                        {
                            return null;
                        }

                    }
                }
                return null;
            }

            return null;

        }
        public static string Getmessagefontsize(int Key)
        {


            foreach (DataRow row in MessageFontSizeDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pk_Message_Font_Size"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["Message_Font_Size"].ToString();
                    return value;
                }
            }
            return null;
        }
        public static string GetIVDOVD_Media_Type(int Key)
        {


            foreach (DataRow row in MediaTypeDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pk_IVDOVD_Mediatype"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["Media_Type"].ToString();
                    return value;
                }
            }
            return null;
        }
        public static string Getmessagecharactergap(int Key)
        {


            foreach (DataRow row in MessageCharacterGapDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pk_Message_Character_Gap"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["Message_Character_Gap"].ToString();
                    return value;
                }
            }
            return null;
        }


        public static  void displayInternetStaus(bool b)
        {
            Form form = Application.OpenForms["frmHome"];
            if (form != null)
            {
                frmHome frm = (frmHome)form;
                frm.Checkinternet(b);
            }
        }

        public static string GetFormattype(int Key)
        {
            try
            {

            foreach (DataRow row in FormatsDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pkey_FormatName"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["Format"].ToString();
                    return value;
                }
            }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }

        public static string GetDisplayeffect(int Key)
        {
            try
            {
                foreach (DataRow row in DisplayEffectsDt.Rows)
                {
                    // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                    int PK = Convert.ToInt32(row["Pkey_DisplayEffect"]);

                    // Check if the primary key matches the provided key
                    if (PK == Key)
                    {
                        string value = row["Name"].ToString();
                        return value;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }

        public static string GetinfoDisplayed(int Key)
        {
            try
            {
            foreach (DataRow row in infoDisplayDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pk_Info_Displayed"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["Info_Displayed"].ToString();
                    return value;
                }
            }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }

        public static void RecallBoards()
        {
            try
            {
                EthernetPorts = HubConfigurationDb.GetEthernetPorts();
            CgdbPorts = HubConfigurationDb.GetCgdbConfiguration();
            Form mainForm = Application.OpenForms["frmHome"];

            if (mainForm != null)
            {
                frmHome frmScheduled = (frmHome)mainForm;
                frmScheduled.setDevices();
            }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static byte[] specialConversion(string Data, bool isspl)
        {
            byte[] CNV = new byte[0];
            int tl = 2;

            var chararray = Data.ToCharArray();
            var UNIC = Encoding.Unicode.GetBytes(Data);

            string a = ByteArrayToString(UNIC);

            if (UNIC.Length > 1)
                if (UNIC[1] == 9)
                    tl = 5;
            for (int i = 0; i < chararray.Length; i++)
            {
                bool nonzerofalg = false;
                var bytes = Encoding.Unicode.GetBytes(chararray[i].ToString());
                if (bytes[0] == 12 && bytes[1] == 32)
                {
                    nonzerofalg = true;
                }

                if (nonzerofalg == false)
                {
                    Array.Resize(ref CNV, CNV.Length + 2);

                    if (bytes.Length < 2)
                    {


                        CNV[CNV.Length - 2] = 00;
                        CNV[CNV.Length - 1] = bytes[0];
                        if (bytes[0] == 32)
                        {
                            for (int z = 0; z < tl; z++)
                            {
                                Array.Resize(ref CNV, CNV.Length + 2);
                                CNV[CNV.Length - 2] = 00;
                                CNV[CNV.Length - 1] = bytes[0];
                            }
                        }
                    }
                    else
                    {
                        CNV[CNV.Length - 2] = bytes[1];
                        CNV[CNV.Length - 1] = bytes[0];
                        if (bytes[0] == 32)
                        {
                            for (int z = 0; z < tl; z++)
                            {
                                Array.Resize(ref CNV, CNV.Length + 2);
                                CNV[CNV.Length - 2] = 00;
                                CNV[CNV.Length - 1] = bytes[0];
                            }
                        }
                    }

                    if (isspl)
                    {
                        Array.Resize(ref CNV, CNV.Length + 2);
                        CNV[CNV.Length - 2] = 00;
                        CNV[CNV.Length - 1] = 32;
                    }
                }

            }
            a = ByteArrayToString(CNV);
            return CNV;
        }

        public static string ByteArrayToString(byte[] byteArray)
        {
            return BitConverter.ToString(byteArray).Replace("-", " ");
        }
        public static byte[] ConvertDecimalNumberTOByteArray(int decimalNumber)
        {
            string hexString = decimalNumber.ToString("X4");
            byte[] byteArray = new byte[2];
            byteArray[0] = Convert.ToByte(hexString.Substring(0, 2), 16);
            byteArray[1] = Convert.ToByte(hexString.Substring(2, 2), 16);
            return byteArray;
        }
        public static (string Platform, string Status) GetStationStatus(string tNumber)
        {
            try
            {
                // Call the method to retrieve train details
                DataTable traindetailsdt = OnlineTrainsDao.GetTrainDetails(tNumber);

                // Check if the DataTable has rows
                if (traindetailsdt != null && traindetailsdt.Rows.Count > 0)
                {
                    // Extract the Platform and Status from the first row
                    string platform = traindetailsdt.Rows[0]["Platform"].ToString();
                    string status = traindetailsdt.Rows[0]["Status"].ToString();

                    // Return the platform and status as a tuple
                    return (platform, status);
                }
                else
                {
                    // Return default values if no data is found
                    return (string.Empty, string.Empty);
                }
            }
             
          catch(Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return (string.Empty, string.Empty);
        }
        public static void setLetterGap()
        {
            LetterGapList.Clear();
            LetterGapDt = BaseClassDb.GetLetterGap();

            foreach (DataRow row in LetterGapDt.Rows)
            {
                LetterGapList.Add(row["LetterGap"].ToString());
            }
        }
        public static void setMediaType()
        {
            MediaTypeList.Clear();
            MediaTypeDt = BaseClassDb.GetMediaType();

            foreach (DataRow row in MediaTypeDt.Rows)
            {
                MediaTypeList.Add(row["Media_Type"].ToString());
            }
        }


        public static void setCoachBitMap()
        {

            coachBitmap = BaseClassDb.GetCoachBitMap();

           
        }

        public static void setVolume()
        {
            VolumeList.Clear();
            VolumeDt = BaseClassDb.GetIVDOVDVolume();

            foreach (DataRow row in VolumeDt.Rows)
            {
                VolumeList.Add(row["Volume"].ToString());
            }
        }

      
        public static void setEntryEffect()
        {
            EntryEffectList.Clear();
            EntryEffectDt = BaseClassDb.GetDisplayEffectIVDOVD();

            foreach (DataRow row in EntryEffectDt.Rows)
            {
                EntryEffectList.Add(row["Name"].ToString());
            }
        }
        public static void setMessageFontSize()
        {
            MessageFontSizeList.Clear();
            MessageFontSizeDt = BaseClassDb.GetIVDOVDMessageFontSize();

            foreach (DataRow row in MessageFontSizeDt.Rows)
            {
                MessageFontSizeList.Add(row["Message_Font_Size"].ToString());
            }
        }
        public static void setMessageCharacterGap()
        {
            MessageCharacterGapList.Clear();
            MessageCharacterGapDt = BaseClassDb.GetIVDOVDMessageCharacterGap();

            foreach (DataRow row in MessageCharacterGapDt.Rows)
            {
                MessageCharacterGapList.Add(row["Message_Character_Gap"].ToString());
            }
        }

        public static string selectTrainsDatabase;

        public static List<string> arrivalStatus = new List<string>();
        public static List<string> DepatureStatus = new List<string>();


        public static Byte GetSerialNumber()
        {
            int Sno = Server.SerialNumber;
            Server.SerialNumber++;
            if (Server.SerialNumber > 255)
            {
                Server.SerialNumber = 0;
            }
            return (byte)Sno;
        }





        public static DataTable CompareDataTablesGiveMeSameData(DataTable oldTable, DataTable newTable)
        {
            try
            {
               
                    if ((oldTable == null || oldTable.Rows.Count == 0) || (newTable != null || newTable.Rows.Count == 0))
                    {
                        return null;
                    }
                    

                // Extract train numbers from both tables
                var oldTrainNumbers = oldTable.AsEnumerable().Select(row => row["TrainNo"].ToString()).ToHashSet();
                    var newTrainNumbers = newTable.AsEnumerable().Select(row => row["TrainNo"].ToString()).ToHashSet();

                    // If both tables have the same data, return null
                    if (oldTrainNumbers.SetEquals(newTrainNumbers))
                    {
                        return null;
                    }

                    // Find matching train numbers
                    var sameTrains = newTable.AsEnumerable()
                        .Where(row => oldTrainNumbers.Contains(row["TrainNo"].ToString()));

                    return sameTrains.Any() ? sameTrains.CopyToDataTable() : newTable.Clone();
                
               
            }
            catch (Exception e)
            {
                
                return null;
            }
        }




        public static DataTable CompareDataTablesGiveMeDifferentData(DataTable oldTable, DataTable newTable)
        {
            try
            {
                if (oldTable == null || oldTable.Rows.Count == 0)
                {
                    return null;

                }
                if (newTable == null || newTable.Rows.Count ==0)
                {
                    if (oldTable != null || oldTable.Rows.Count == 0)
                    {
                        return oldTable;
                    }
                }

                // Extract train numbers from oldTable
                var oldTrainNumbers = oldTable.AsEnumerable().Select(row => row["TrainNo"].ToString()).ToHashSet();

                // Find trains in newTable that are not in oldTable
                var differentTrains = newTable.AsEnumerable()
                    .Where(row => !oldTrainNumbers.Contains(row["TrainNo"].ToString()));

                return differentTrains.Any() ? differentTrains.CopyToDataTable() : newTable.Clone();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in CompareDataTables: " + e.Message);
                return null;
            }
        }



        public static (int packet, int fourthOctet, int port) GetPacketIdentifier(string BoardIp)
        {
            try
            {
            int fourthOctet = Server.GetFourthOctet(BoardIp);

            if (fourthOctet >= 39)
            {
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                    {
                        // Compare the IP address as a string
                        if (row["IPAddress"].ToString() == BoardIp)
                        {
                            // Try to get the PacketIdentifier and PdcPortNo as integers
                            if (int.TryParse(row["PacketIdentifier"].ToString(), out int packet) &&
                                int.TryParse(row["PdcPortNo"].ToString(), out int pdcPort))
                            {
                                return (packet, fourthOctet, pdcPort);
                            }
                        }
                    }
                }
            }
            else
            {
                BaseClass.setCgdbHub();

                foreach (DataRow row in BaseClass.CgdbHubPorts.Rows)
                {
                    if (BaseClass.CgdbHubPorts.Columns.Contains("Cgdb_IpAddress"))
                    {
                        // Compare the IP address as a string
                        if (row["Cgdb_IpAddress"].ToString() == BoardIp)
                        {
                            // Try to get the PortNo as an integer
                            if (int.TryParse(row["PortNo"].ToString(), out int port))
                            {
                                // Assuming Board.CGDB is an integer value or you have a method to get it
                                int cgdb = Board.CGDB; // Replace this with the correct way to get CGDB value
                                return (cgdb, fourthOctet, port);
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
            // Return a default value or throw an exception if the BoardIp is not found
            throw new Exception("PacketIdentifier not found for the provided BoardIp.");
        }



        public static void setCdotData()
        {
            try
            {
                frmInterface.dscdotconfg = InterfaceDb.GetCDotConfiguration();

                if (frmInterface.dscdotconfg.Tables[0].Rows.Count > 0)
                {
                    DataRow row = frmInterface.dscdotconfg.Tables[0].Rows[0];
                    //ManualMode = row.Field<bool>("ManualMode");
                    CdotEnable = row.Field<bool>("CdotEnable");

                    CdotAutoMode = row.Field<bool>("AutoMode");

                    CdotpollingTimeInterval = row.Field<int>("PollingTimeInMin").ToString();
                }
            }
             
            catch(Exception ex)
            {
                Server.LogError(ex.ToString());
            }

        }


        public static bool IsCdotEnabled()
        {
           
            return CdotEnable;
        }
        public static bool IsCdotAutoMode()
        {
            return CdotAutoMode;
        }

        public string ConvertNumberToPlatform(int input)
        {
            // Subtract 100 from the input to get the original number
            int originalNumber = input - 100;

            // Check if the result is non-negative
            if (originalNumber >= 0)
            {
                // Return the result as a string with "A" appended
                return originalNumber.ToString();
            }
            else
            {
                throw new ArgumentException("Input should be 100 or greater.");
            }
        }
        public static string ConvertPlatformToIp(string input)
        {
            // Extract the numeric part from the input string
            string numericPart = new string(input.Where(char.IsDigit).ToArray());
            string letterPart = new string(input.Where(char.IsLetter).ToArray());
            int letterDecimalvalue = 0;
            if (!string.IsNullOrEmpty(letterPart))
            {
              letterDecimalvalue = HexToDecimal(letterPart);
            }
            

            // Check if numericPart is not empty and is a valid number
            if (!string.IsNullOrEmpty(numericPart) && int.TryParse(numericPart, out int thirdOctet))
            {
                // If input contains any alphabetic character, add 100 to the numeric part
                if (input.Any(char.IsLetter))
                {
                    thirdOctet += 100+ letterDecimalvalue;
                }

                // Return the modified (or unmodified) third octet as a string
                return thirdOctet.ToString();
            }
            else
            {
                throw new ArgumentException("Invalid input format. Input should contain at least one digit.");
            }
        }
        public static string GetCoachClass(string coachCode)
        {
            // Dictionary with expanded coach classes
            Dictionary<string, string> coachMapping = new Dictionary<string, string>
            {
            { "H", "First AC" },
            { "A", "Second AC" },
            { "B", "Third AC" },
            { "S", "Sleeper Class" },
            { "SL", "Sleeper Class" },
            { "CC", "AC Chair Car" },
            { "EC", "Executive Chair Car (Shatabdi)" },
            { "EV", "Vistadome Executive Class" },
            { "VS", "Vistadome Chair Car" },
            { "D", "Second Seating" },
            { "GN", "General Class (Unreserved)" },
            { "FC", "First Class (Non-AC)" },
            { "2S", "Second Seating (Non-AC)" },
            { "3E", "AC 3 Economy" },
            { "UR", "Unreserved" }
            };

            // Direct match
            if (coachMapping.TryGetValue(coachCode, out string directMatch))
                return directMatch;

            // Match dynamic coach numbers (S10, A5, B12, etc.)
            foreach (var key in coachMapping.Keys)
            {
                if (Regex.IsMatch(coachCode, $"^{key}[0-9]+$"))
                    return coachMapping[key];
            }

            return "Unknown Coach";
        }

        public static int HexToDecimal(string hexString)
        {
            return Convert.ToInt32(hexString, 16);
        }
        public static DataTable MergeAndRemoveDuplicates(DataTable dt1, DataTable dt2)
        {try
            {
                // Merge both DataTables
                DataTable mergedTable = new DataTable();
                mergedTable.Merge(dt1);
                mergedTable.Merge(dt2);
                if (dt1 != null || dt2 != null)
                {
                    if (dt1.Rows.Count != 0 || dt1.Rows.Count != 0)
                    {
                        // Remove duplicates based on TrainNumber
                        DataTable resultTable = mergedTable.AsEnumerable()
                            .GroupBy(row => row.Field<string>("TrainNo")) // Group by TrainNumber
                            .Select(group => group.First()) // Take the first occurrence
                            .CopyToDataTable();
                        return resultTable;
                    }
                }
                return null;
            }
            catch(Exception e){
                Server.LogError("MergeAndRemoveDuplicates()" + e.ToString());
                return null;
                
            }
        }

        public static string ButtonStatus = "Taddb";

        public static void ClearThirdpartyTextfile()
        {
            List<string> trainNumbersList = new List<string>();

            try
            {
                DataTable onlinetrainsdt = new DataTable();

                BaseClass.OnlineTrainsCgdbDt = OnlineTrainsDao.GetScheduledCgdbTrains();
                BaseClass.OnlineTrainsTaddbDt = OnlineTrainsDao.GetScheduledTaddbTrains();


                trainNumbersList = BaseClass.OnlineTrainsCgdbDt.AsEnumerable().Select(row => row.Field<string>("TrainNo")).ToList();
                onlinetrainsdt = MergeAndRemoveDuplicates(BaseClass.OnlineTrainsTaddbDt, BaseClass.OnlineTrainsCgdbDt);





                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo;
                FileInfo logFileInfo1;
                DataTable Integration = BaseClass.IntegrationData;
                if (Integration.Rows[0]["Front_Back"].ToString() == "0" && Integration.Rows[0]["TrainData"].ToString() == "True")
                {
                    string logFilePath1 = Integration.Rows[0]["TextFilePath"].ToString();
                    logFilePath1 = logFilePath1 + "\\TP_DATA.txt";
                    logFileInfo1 = new FileInfo(logFilePath1);
                    logDirInfo = new DirectoryInfo(logFileInfo1.DirectoryName);

                    string Finalvdcstr = "";
                    string final1 = (char)1 + "" + (char)2 + DateTime.Now.ToString("dd'/'MM'/'yyyy") + (char)32 + DateTime.Now.ToString("hh:mm:ss") + (char)03 + "" + (char)13 + "" + (char)10;
                    DataTable dt = onlinetrainsdt;
                    if (dt != null && dt.Rows.Count > 0)
                    {

                        foreach (DataRow row in dt.Rows)
                        {
                            int i = 30;
                            string trainname = row["Name"].ToString();
                            int j = trainname.Count();


                            if (trainname.Length > 30)
                            {
                                trainname = trainname.Substring(0, 30);
                            }
                            else
                            {
                                while (j < i)
                                {
                                    trainname += (char)32;
                                    j++;
                                }
                            }
                            string platfrom = row["PlatformName"].ToString();
                            int ii = 2;
                            int jj = platfrom.Count();

                            if (jj == 1)
                            {
                                platfrom = "0" + platfrom;
                            }
                            if (platfrom == "")
                            {
                                platfrom = "  ";
                            }

                            string[] la = row["LArrivalTime"].ToString().Split(':');
                            string[] ld = row["LDepartureTime"].ToString().Split(':');
                            string[] late = row["LateBy"].ToString().Split(':');

                            if (late[0].ToString() == "00" && late[1].ToString() == "00")
                            {
                                late[0] = "--";
                                late[1] = "--";
                            }

                            string[] ra = row["RArrivalTime"].ToString().Split(':');

                            string[] rd = row["RDepartureTime"].ToString().Split(':');
                            string coachpos = "";
                            //  DataSet Ds = BusinessLogicLayer.GetCgdbNooBoards(Convert.ToInt32(row["FKEY_TRAIN"].ToString()));

                            string[] coachpositions = OnlineTrainsDao.coachPositions(row["TrainNo"].ToString()).ToArray();
                            (string pf, string status) = BaseClass.GetStationStatus(row["TrainNo"].ToString());
                            //  DataTable Traintype = BusinessLogicLayer.GetTrainUpDownStatus(row["TrainNo"].ToString());

                           
                            int statusid = Convert.ToInt32(BaseClass.getStatusCode(row["StatusName"].ToString().Trim(), row["ArrivingStatus"].ToString().Trim()));
                            string trainrow = (char)1 + "" + (char)2 + row["TrainNo"].ToString() + trainname + la[0] + la[1] + ld[0] + ld[1] + row["ArrivingStatus"].ToString().Trim() + (char)statusid + late[0] + late[1] + ra[0] + ra[1] + rd[0] + rd[1] + platfrom  + (char)250;
                            //int statusid = Convert.ToInt32(GetStatusID(row["StatusName"].ToString(), row["ArrivingStatus"].ToString()));

                            string stname = "";
                            if (statusid == 8 || statusid == 16 || statusid == 19)
                            {


                                if (row["EStation"].ToString() != "")
                                {
                                    string stnstr = row["EStation"].ToString();
                                    stname = stnstr;
                                    string[] strarr = stnstr.Split(',');

                                }
                            }


                            string vdcstr = "";
                            vdcstr = "#" + row["TrainNo"].ToString() + "~" + row["Name"].ToString() + "~" + row["LArrivalTime"].ToString() + "~" + row["LDepartureTime"].ToString() + "~" + row["ArrivingStatus"].ToString() + "~" + statusid + "~" + platfrom + "~" + coachpos + "~" + stname;
                            int count = trainrow.Count();

                            while (count <= 260)
                            {
                                trainrow += (char)32;
                                count++;
                            }
                            final1 += trainrow + (char)03 + "" + (char)13 + "" + (char)10;
                            Finalvdcstr = Finalvdcstr + vdcstr;

                        }
                    }
                    byte[] byteArr = Encoding.Default.GetBytes(final1);
                    Encoding ascii = Encoding.Default;
                    if (!File.Exists(logFilePath1))
                    {
                        File.Create(logFilePath1).Dispose(); // ✅
                    }
                    if (File.Exists(logFilePath1))
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(logFilePath1, FileMode.Create), ascii))
                        {
                            // File.WriteAllText(logFilePath1, String.Empty);
                            writer.Write(byteArr, 0, byteArr.Length);
                            writer.Flush();
                            writer.Close();
                        }

                       
                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }










        public static void WritingThirdpartyTextfile()
        {
            List<string> trainNumbersList = new List<string>();

            try
            {
                DataTable onlinetrainsdt = new DataTable();

                BaseClass.OnlineTrainsCgdbDt = OnlineTrainsDao.GetScheduledCgdbTrains();
                BaseClass.OnlineTrainsTaddbDt = OnlineTrainsDao.GetScheduledTaddbTrains();

            
              trainNumbersList = BaseClass.OnlineTrainsCgdbDt.AsEnumerable().Select(row => row.Field<string>("TrainNo")).ToList();
              onlinetrainsdt = MergeAndRemoveDuplicates(BaseClass.OnlineTrainsTaddbDt, BaseClass.OnlineTrainsCgdbDt);
                




                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo;
                FileInfo logFileInfo1;
                DataTable Integration = BaseClass.IntegrationData;
                if (Integration.Rows[0]["Front_Back"].ToString() == "0" && Integration.Rows[0]["TrainData"].ToString() == "True")
                {
                    string logFilePath1 = Integration.Rows[0]["TextFilePath"].ToString();
                    logFilePath1 = logFilePath1 + "\\TP_DATA.txt";
                    logFileInfo1 = new FileInfo(logFilePath1);
                    logDirInfo = new DirectoryInfo(logFileInfo1.DirectoryName);
                    
                    string Finalvdcstr = "";
                    string final1 = (char)1 + "" + (char)2 + DateTime.Now.ToString("dd'/'MM'/'yyyy") + (char)32 + DateTime.Now.ToString("hh:mm:ss") + (char)03 + "" + (char)13 + "" + (char)10;
                    DataTable dt = onlinetrainsdt;
                    if (dt != null && dt.Rows.Count > 0)
                    {

                        foreach (DataRow row in dt.Rows)
                        {
                            int i = 30;
                            string trainname = row["Name"].ToString();
                            int j = trainname.Count();


                            if (trainname.Length > 30)
                            {
                                trainname = trainname.Substring(0, 30);
                            }
                            else
                            {
                                while (j < i)
                                {
                                    trainname += (char)32;
                                    j++;
                                }
                            }
                            string platfrom = row["PlatformName"].ToString();
                            int ii = 2;
                            int jj = platfrom.Count();

                            if (jj == 1)
                            {
                                platfrom = "0" + platfrom;
                            }
                            if (platfrom == "")
                            {
                                platfrom = "  ";
                            }

                            string[] la = row["LArrivalTime"].ToString().Split(':');
                            string[] ld = row["LDepartureTime"].ToString().Split(':');
                            string[] late = row["LateBy"].ToString().Split(':');

                            if (late[0].ToString() == "00" && late[1].ToString() == "00")
                            {
                                late[0] = "--";
                                late[1] = "--";
                            }

                            string[] ra = row["RArrivalTime"].ToString().Split(':');

                            string[] rd = row["RDepartureTime"].ToString().Split(':');
                            string coachpos = "";
                            //  DataSet Ds = BusinessLogicLayer.GetCgdbNooBoards(Convert.ToInt32(row["FKEY_TRAIN"].ToString()));

                            string[] coachpositions = (OnlineTrainsDao.coachPositions(row["TrainNo"].ToString()) ?? Enumerable.Empty<string>()).ToArray();

                            (string pf, string status) = BaseClass.GetStationStatus(row["TrainNo"].ToString());
                            //  DataTable Traintype = BusinessLogicLayer.GetTrainUpDownStatus(row["TrainNo"].ToString());

                            if (trainNumbersList.Contains(row["TrainNo"].ToString().Trim()))
                            {

                                if (status == "UP")
                                {
                                    // Append with commas as-is
                                    coachpos = String.Join(",", coachpositions);
                                }
                                else
                                {
                                    // Reverse the array and then append with commas
                                    //Array.Reverse(coachpositions);
                                    coachpos = String.Join(",", coachpositions);
                                }


                            }
                            else
                            {
                                coachpos = "";
                            }
                            int statusid = Convert.ToInt32(BaseClass.getStatusCode(row["StatusName"].ToString().Trim(), row["ArrivingStatus"].ToString().Trim()));
                            string trainrow = (char)1 + "" + (char)2 + row["TrainNo"].ToString() + trainname + ra[0] + ra[1] + rd[0] + rd[1] + row["ArrivingStatus"].ToString().Trim() + (char)statusid + late[0] + late[1] + la[0] + la[1] + ld[0] + ld[1]+  platfrom + coachpos + (char)250;
                            //int statusid = Convert.ToInt32(GetStatusID(row["StatusName"].ToString(), row["ArrivingStatus"].ToString()));

                            string stname = "";
                            if (statusid == 8 || statusid == 16 || statusid == 19)
                            {


                                if (row["EStation"].ToString() != "")
                                {
                                    string stnstr = row["EStation"].ToString();
                                    stname = stnstr;
                                    string[] strarr = stnstr.Split(',');

                                }
                            }


                            string vdcstr = "";
                            vdcstr = "#" + row["TrainNo"].ToString() + "~" + row["Name"].ToString() + "~" + row["LArrivalTime"].ToString() + "~" + row["LDepartureTime"].ToString() + "~" + row["ArrivingStatus"].ToString() + "~" + statusid + "~" + platfrom + "~" + coachpos + "~" + stname;
                            int count = trainrow.Count();

                            while (count <= 260)
                            {
                                trainrow += (char)32;
                                count++;
                            }
                            final1 += trainrow + (char)03 + "" + (char)13 + "" + (char)10;
                            Finalvdcstr = Finalvdcstr + vdcstr;

                        }
                    }
                    byte[] byteArr = Encoding.Default.GetBytes(final1);
                    Encoding ascii = Encoding.Default;

                    string folderPath = Path.GetDirectoryName(logFilePath1);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    if (!File.Exists(logFilePath1))
                    {
                        File.Create(logFilePath1).Dispose(); // ✅
                    }
                    if (File.Exists(logFilePath1))
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(logFilePath1, FileMode.Create), ascii))
                        {
                            // File.WriteAllText(logFilePath1, String.Empty);
                            writer.Write(byteArr, 0, byteArr.Length);
                            writer.Flush();
                            writer.Close();
                        }

                        //string str =Integration.Rows[0]["TextFilePath"].ToString();
                        string str = "C:\\ThirdParty";


                        string logFilePath2 = str + "\\Traindata.txt";
                        if (!File.Exists(logFilePath2))
                        {
                            File.Create(logFilePath2).Dispose(); // ✅
                        }

                        Encoding asciinew = Encoding.ASCII;
                        using (BinaryWriter writer = new BinaryWriter(File.Open(logFilePath2, FileMode.Create), asciinew))
                        {
                            // File.WriteAllText(logFilePath1, String.Empty);
                            writer.Write(Finalvdcstr);
                            writer.Flush();
                            writer.Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }
        

        public static void InsertOrUpdateTrainData(TrainInfo newTrain)
        {
            string FolderPath = @"C:\ThirdParty";
            string FilePath = @"C:\ThirdParty\NewAddTrains.txt";
            // Create folder if it doesn't exist
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            // Create file if it doesn't exist
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close(); // Close to release the lock
            }

            var lines = File.ReadAllLines(FilePath).ToList();
            bool updated = false;

            for (int i = 0; i < lines.Count; i++)
            {
                var train = TrainInfo.FromString(lines[i]);
                if (train.TrainNumber == newTrain.TrainNumber)
                {
                    lines[i] = newTrain.ToString(); // update existing
                    updated = true;
                    break;
                }
            }

            if (!updated)
            {
                lines.Add(newTrain.ToString()); // insert new
            }

            File.WriteAllLines(FilePath, lines);
        }
    













    public static void getIntegration()
        {

            IntegrationData = InterfaceDb.GetIntegration();


        }
        public static void GetLinkedTrainsList()
        {
            BaseClass.LinkedTrainsList.Clear();
            DataTable dt = OnlineTrainsDao.GetLinkedTrainsbycategory();

            foreach (DataRow row in dt.Rows)
            {
                string trainNo = (row["TrainNumber"].ToString());
                BaseClass.LinkedTrainsList.Add(trainNo);
            }
        }
    }
}
