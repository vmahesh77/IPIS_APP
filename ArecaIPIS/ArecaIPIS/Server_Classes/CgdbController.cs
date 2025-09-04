using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;


namespace ArecaIPIS.Server_Classes
{
    class CgdbController
    {

        //public static void DataPacket(List<DataGridViewRow> checkedRows)
        //{
        //    foreach (var row in checkedRows)
        //    {
        //        string PlatformNo = row.Cells["dgvPFColumn"].Value.ToString().Trim();
        //        string trainNumber = row.Cells["dgvTrNoColumn"].Value.ToString();
        //        string pdcIp = "192.168." + PlatformNo + ".251";
        //        // DataTable coachPositionsdt = OnlineTrainsDao.getCoachPositionsByTrainNumber(trainNumber);
        //        DataTable coachPositionsdt = OnlineTrainsDao.getTempCoachPositionsByTrainNumber(trainNumber);//temp table
        //        int packetidentifier = Board.CGDB;
        //        string broadCastIp = Server.GetBroadcastIp(pdcIp);
        //        if (Server.ipAdress == null)
        //        {
        //            return;
        //        }

        //        byte[] StopCommand = ByteFormation.StopCommand(broadCastIp, packetidentifier);
        //        Server.SendDataToPdc(pdcIp, StopCommand);

        //        CgdbDataPacket(PlatformNo, trainNumber, coachPositionsdt, pdcIp, packetidentifier);
        //        byte[] StartCommand = ByteFormation.StartCommand(broadCastIp, packetidentifier);
        //        Server.SendDataToPdc(pdcIp, StartCommand);
        //    }
        //}
        public static void DataPacket()
        {

            try
            {


                DataTable onlineCgdb = OnlineTrainsDao.GetScheduledCgdbTrains();
                foreach (DataRow row in onlineCgdb.Rows)
                {
                    string PlatformNo = row["PlatformName"].ToString().Trim();
                    string trainNumber = row["TrainNo"].ToString().Trim();
                    string pdcIp = "192.168." + PlatformNo + ".251";
                    // DataTable coachPositionsdt = OnlineTrainsDao.getCoachPositionsByTrainNumber(trainNumber);
                    DataTable coachPositionsdt = OnlineTrainsDao.getTempCoachPositionsByTrainNumber(trainNumber);//temp table
                    int packetidentifier = Board.CGDB;
                    string broadCastIp = Server.GetBroadcastIp(pdcIp);
                    if (Server.ipAdress == null)
                    {
                        return;
                    }
                    if (!BaseClass.Getinteroperabilitystatus(pdcIp))
                    {


                        byte[] StopCommand = ByteFormation.StopCommand(broadCastIp, packetidentifier);
                        Server.SendDataToPdc(pdcIp, StopCommand);
                        if (BaseClass.LinkedTrainsList.Contains(trainNumber))
                        {
                            CgdbDataPacketforLinkedTrains(PlatformNo, trainNumber, pdcIp, packetidentifier);
                        }
                        else
                        {
                            CgdbDataPacket(PlatformNo, trainNumber, coachPositionsdt, pdcIp, packetidentifier);
                        }


                        byte[] StartCommand = ByteFormation.StartCommand(broadCastIp, packetidentifier);
                        Server.SendDataToPdc(pdcIp, StartCommand);
                    }
                    else
                    {
                        Cgdbinteroperability(PlatformNo, trainNumber, pdcIp, packetidentifier, coachPositionsdt);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public static void Cgdbinteroperability(string PlatformNo, string trainNumber, string pdcIp, int packetidentifier, DataTable coachPositionsdt)
        {
            try
            {
                if (BaseClass.LinkedTrainsList.Contains(trainNumber))
                {
                    CgdbDataPacketforLinkedTrainsinteroperability(PlatformNo, trainNumber, pdcIp, packetidentifier);
                }
                else
                {
                    CgdbDataPacketinteroperability(PlatformNo, trainNumber, coachPositionsdt, pdcIp, packetidentifier);
                }


            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public static void CgdbDataPacketinteroperability(string PlatformNo, string trainNumber, DataTable coachPositionsdt, string pdcIp, int packetidentifier)
        {
            try
            {


                int PkKeyMasterHub = 0;
                List<string> coachPositions = new List<string>();
                List<string> CgdbIpAddressPositions = new List<string>();

                (string pf, string status) = BaseClass.GetStationStatus(trainNumber);
                // Outside the loop: Declare the variables
                string platformNo = string.Empty;
                string videoType = string.Empty;
                string letterSpeed = string.Empty;
                string formatType = string.Empty;
                string letterGap = string.Empty;
                string displayEffect = string.Empty;
                int fontSize = 0;
                int delayTime = 0;
                int eraseTime = 0;
                int noOfCoaches = 0;
                string defaultEnglish = string.Empty;
                string defaultHindi = string.Empty;
                string divisionOrPf = string.Empty;

                if (coachPositionsdt.Rows.Count > 0)
                {
                    DataRow firstRow = coachPositionsdt.Rows[0];
                    string coachPosition = firstRow["coachPositions"]?.ToString() ?? string.Empty;

                    coachPositions.AddRange(coachPosition.Split(','));

                    foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                    {
                        if (BaseClass.EthernetPorts.Columns.Contains("IPAddress") &&
                            row["IPAddress"] != null &&
                            row["IPAddress"].ToString().Trim() == pdcIp.Trim())
                        {
                            PkKeyMasterHub = Convert.ToInt32(row["PkeyMasterhub"]);

                            DataTable cgdbIp = HubConfigurationDb.GetCoaches(PkKeyMasterHub);

                            foreach (DataRow eachrow in cgdbIp.Rows)
                            {
                                string cgdbIpAddress = eachrow.Field<string>("Cgdb_IpAddress");
                                CgdbIpAddressPositions.Add(cgdbIpAddress);
                            }
                        }
                    }
                }





                // Inside the loop: Assign values to the variables
                foreach (DataRow row in BaseClass.CgdbPorts.Rows)
                {
                    if (BaseClass.CgdbPorts.Columns.Contains("Fkey_CDCID") && int.TryParse(row["Fkey_CDCID"].ToString(), out int PkCdcid))
                    {
                        if (PkCdcid == PkKeyMasterHub)
                        {
                            platformNo = row["default_platformno"].ToString().Trim();
                            videoType = row["VideoType"].ToString().Trim();
                            letterSpeed = row["LetterSpeed"].ToString().Trim();
                            formatType = row["FormatType"].ToString().Trim();
                            letterGap = row["LetterGap"].ToString().Trim();
                            displayEffect = row["DisplayEffect"].ToString().Trim();
                            fontSize = Convert.ToInt32(row["Fontsize"]);
                            delayTime = Convert.ToInt32(row["DelayTime"]);
                            eraseTime = Convert.ToInt32(row["Erase_time"]);
                            noOfCoaches = Convert.ToInt32(row["No_Of_Coaches"]);
                            defaultEnglish = row["DefaultEnglish"].ToString().Trim();
                            defaultHindi = row["DefaultHindi"].ToString().Trim();
                            divisionOrPf = row["DivCode"].ToString().Trim();
                        }
                    }
                }
                List<string> CgdbIpAddresslist = ProcessListBasedOnStatus(CgdbIpAddressPositions, status);


                CgdbPacketPreparationinteroperability(CgdbIpAddresslist, coachPositions, trainNumber, packetidentifier, platformNo, videoType, letterSpeed, formatType, letterGap, displayEffect, fontSize, delayTime, eraseTime, noOfCoaches, defaultEnglish, defaultHindi, divisionOrPf, pdcIp);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static void CgdbDataPacket(string PlatformNo, string trainNumber, DataTable coachPositionsdt, string pdcIp, int packetidentifier)
        {
            try
            {


                int PkKeyMasterHub = 0;
                List<string> coachPositions = new List<string>();
                List<string> CgdbIpAddressPositions = new List<string>();

                (string pf, string status) = BaseClass.GetStationStatus(trainNumber);
                // Outside the loop: Declare the variables
                string platformNo = string.Empty;
                string videoType = string.Empty;
                string letterSpeed = string.Empty;
                string formatType = string.Empty;
                string letterGap = string.Empty;
                string displayEffect = string.Empty;
                int fontSize = 0;
                int delayTime = 0;
                int eraseTime = 0;
                int noOfCoaches = 0;
                string defaultEnglish = string.Empty;
                string defaultHindi = string.Empty;
                string divisionOrPf = string.Empty;

                if (coachPositionsdt.Rows.Count > 0)
                {
                    DataRow firstRow = coachPositionsdt.Rows[0];
                    string coachPosition = firstRow["coachPositions"]?.ToString() ?? string.Empty;

                    coachPositions.AddRange(coachPosition.Split(','));

                    foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                    {
                        if (BaseClass.EthernetPorts.Columns.Contains("IPAddress") &&
                            row["IPAddress"] != null &&
                            row["IPAddress"].ToString().Trim() == pdcIp.Trim())
                        {
                            PkKeyMasterHub = Convert.ToInt32(row["PkeyMasterhub"]);

                            DataTable cgdbIp = HubConfigurationDb.GetCoaches(PkKeyMasterHub);

                            foreach (DataRow eachrow in cgdbIp.Rows)
                            {
                                string cgdbIpAddress = eachrow.Field<string>("Cgdb_IpAddress");
                                CgdbIpAddressPositions.Add(cgdbIpAddress);
                            }
                        }
                    }
                }





                // Inside the loop: Assign values to the variables
                foreach (DataRow row in BaseClass.CgdbPorts.Rows)
                {
                    if (BaseClass.CgdbPorts.Columns.Contains("Fkey_CDCID") && int.TryParse(row["Fkey_CDCID"].ToString(), out int PkCdcid))
                    {
                        if (PkCdcid == PkKeyMasterHub)
                        {
                            platformNo = row["default_platformno"].ToString().Trim();
                            videoType = row["VideoType"].ToString().Trim();
                            letterSpeed = row["LetterSpeed"].ToString().Trim();
                            formatType = row["FormatType"].ToString().Trim();
                            letterGap = row["LetterGap"].ToString().Trim();
                            displayEffect = row["DisplayEffect"].ToString().Trim();
                            fontSize = Convert.ToInt32(row["Fontsize"]);
                            delayTime = Convert.ToInt32(row["DelayTime"]);
                            eraseTime = Convert.ToInt32(row["Erase_time"]);
                            noOfCoaches = Convert.ToInt32(row["No_Of_Coaches"]);
                            defaultEnglish = row["DefaultEnglish"].ToString().Trim();
                            defaultHindi = row["DefaultHindi"].ToString().Trim();
                            divisionOrPf = row["DivCode"].ToString().Trim();
                        }
                    }
                }
                List<string> CgdbIpAddresslist = ProcessListBasedOnStatus(CgdbIpAddressPositions, status);


                CgdbPacketPreparation(CgdbIpAddresslist, coachPositions, trainNumber, packetidentifier, platformNo, videoType, letterSpeed, formatType, letterGap, displayEffect, fontSize, delayTime, eraseTime, noOfCoaches, defaultEnglish, defaultHindi, divisionOrPf);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public static void CgdbDataPacketforLinkedTrainsinteroperability(string PlatformNo, string trainNumber, string pdcIp, int packetidentifier)
        {
            try
            {

                DataTable LinkedcoachPositionsdt = OnlineTrainsDao.getLinkedTempCoachPositionsByTrainNumber(trainNumber);
                int PkKeyMasterHub = 0;
                List<string> coachPositions = new List<string>();
                List<string> coaches = new List<string>();
                List<string> coachtrainNumbers = new List<string>();

                List<string> CgdbIpAddressPositions = new List<string>();

                (string pf, string status) = BaseClass.GetStationStatus(trainNumber);
                // Outside the loop: Declare the variables
                string platformNo = string.Empty;
                string videoType = string.Empty;
                string letterSpeed = string.Empty;
                string formatType = string.Empty;
                string letterGap = string.Empty;
                string displayEffect = string.Empty;
                int fontSize = 0;
                int delayTime = 0;
                int eraseTime = 0;
                int noOfCoaches = 0;
                string defaultEnglish = string.Empty;
                string defaultHindi = string.Empty;
                string divisionOrPf = string.Empty;

                if (LinkedcoachPositionsdt.Rows.Count > 0)
                {
                    DataRow firstRow = LinkedcoachPositionsdt.Rows[0];
                    string coachPosition = firstRow["coachPositions"]?.ToString() ?? string.Empty;

                    coachPositions.AddRange(coachPosition.Split(','));


                    foreach (string coach in coachPositions)
                    {
                        string[] input = coach.Split('-');
                        coachtrainNumbers.Add(input[0].ToString().Trim());
                        coaches.Add(input[1].ToString().Trim());
                    }






                    foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                    {
                        if (BaseClass.EthernetPorts.Columns.Contains("IPAddress") &&
                            row["IPAddress"] != null &&
                            row["IPAddress"].ToString().Trim() == pdcIp.Trim())
                        {
                            PkKeyMasterHub = Convert.ToInt32(row["PkeyMasterhub"]);

                            DataTable cgdbIp = HubConfigurationDb.GetCoaches(PkKeyMasterHub);

                            foreach (DataRow eachrow in cgdbIp.Rows)
                            {
                                string cgdbIpAddress = eachrow.Field<string>("Cgdb_IpAddress");
                                CgdbIpAddressPositions.Add(cgdbIpAddress);
                            }
                        }
                    }
                }





                // Inside the loop: Assign values to the variables
                foreach (DataRow row in BaseClass.CgdbPorts.Rows)
                {
                    if (BaseClass.CgdbPorts.Columns.Contains("Fkey_CDCID") && int.TryParse(row["Fkey_CDCID"].ToString(), out int PkCdcid))
                    {
                        if (PkCdcid == PkKeyMasterHub)
                        {
                            platformNo = row["default_platformno"].ToString().Trim();
                            videoType = row["VideoType"].ToString().Trim();
                            letterSpeed = row["LetterSpeed"].ToString().Trim();
                            formatType = row["FormatType"].ToString().Trim();
                            letterGap = row["LetterGap"].ToString().Trim();
                            displayEffect = row["DisplayEffect"].ToString().Trim();
                            fontSize = Convert.ToInt32(row["Fontsize"]);
                            delayTime = Convert.ToInt32(row["DelayTime"]);
                            eraseTime = Convert.ToInt32(row["Erase_time"]);
                            noOfCoaches = Convert.ToInt32(row["No_Of_Coaches"]);
                            defaultEnglish = row["DefaultEnglish"].ToString().Trim();
                            defaultHindi = row["DefaultHindi"].ToString().Trim();
                            divisionOrPf = row["DivCode"].ToString().Trim();
                        }
                    }
                }
                List<string> CgdbIpAddresslist = ProcessListBasedOnStatus(CgdbIpAddressPositions, status);


                CgdbPacketPreparationLinkedtraininteroperability(CgdbIpAddresslist, coaches, coachtrainNumbers, trainNumber, packetidentifier, platformNo, videoType, letterSpeed, formatType, letterGap, displayEffect, fontSize, delayTime, eraseTime, noOfCoaches, defaultEnglish, defaultHindi, divisionOrPf);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static void CgdbDataPacketforLinkedTrains(string PlatformNo, string trainNumber, string pdcIp, int packetidentifier)
        {
            try
            {

                DataTable LinkedcoachPositionsdt = OnlineTrainsDao.getLinkedTempCoachPositionsByTrainNumber(trainNumber);
                int PkKeyMasterHub = 0;
                List<string> coachPositions = new List<string>();
                List<string> coaches = new List<string>();
                List<string> coachtrainNumbers = new List<string>();

                List<string> CgdbIpAddressPositions = new List<string>();

                (string pf, string status) = BaseClass.GetStationStatus(trainNumber);
                // Outside the loop: Declare the variables
                string platformNo = string.Empty;
                string videoType = string.Empty;
                string letterSpeed = string.Empty;
                string formatType = string.Empty;
                string letterGap = string.Empty;
                string displayEffect = string.Empty;
                int fontSize = 0;
                int delayTime = 0;
                int eraseTime = 0;
                int noOfCoaches = 0;
                string defaultEnglish = string.Empty;
                string defaultHindi = string.Empty;
                string divisionOrPf = string.Empty;

                if (LinkedcoachPositionsdt.Rows.Count > 0)
                {
                    DataRow firstRow = LinkedcoachPositionsdt.Rows[0];
                    string coachPosition = firstRow["coachPositions"]?.ToString() ?? string.Empty;

                    coachPositions.AddRange(coachPosition.Split(','));


                    foreach (string coach in coachPositions)
                    {
                        string[] input = coach.Split('-');
                        coachtrainNumbers.Add(input[0].ToString().Trim());
                        coaches.Add(input[1].ToString().Trim());
                    }






                    foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                    {
                        if (BaseClass.EthernetPorts.Columns.Contains("IPAddress") &&
                            row["IPAddress"] != null &&
                            row["IPAddress"].ToString().Trim() == pdcIp.Trim())
                        {
                            PkKeyMasterHub = Convert.ToInt32(row["PkeyMasterhub"]);

                            DataTable cgdbIp = HubConfigurationDb.GetCoaches(PkKeyMasterHub);

                            foreach (DataRow eachrow in cgdbIp.Rows)
                            {
                                string cgdbIpAddress = eachrow.Field<string>("Cgdb_IpAddress");
                                CgdbIpAddressPositions.Add(cgdbIpAddress);
                            }
                        }
                    }
                }





                // Inside the loop: Assign values to the variables
                foreach (DataRow row in BaseClass.CgdbPorts.Rows)
                {
                    if (BaseClass.CgdbPorts.Columns.Contains("Fkey_CDCID") && int.TryParse(row["Fkey_CDCID"].ToString(), out int PkCdcid))
                    {
                        if (PkCdcid == PkKeyMasterHub)
                        {
                            platformNo = row["default_platformno"].ToString().Trim();
                            videoType = row["VideoType"].ToString().Trim();
                            letterSpeed = row["LetterSpeed"].ToString().Trim();
                            formatType = row["FormatType"].ToString().Trim();
                            letterGap = row["LetterGap"].ToString().Trim();
                            displayEffect = row["DisplayEffect"].ToString().Trim();
                            fontSize = Convert.ToInt32(row["Fontsize"]);
                            delayTime = Convert.ToInt32(row["DelayTime"]);
                            eraseTime = Convert.ToInt32(row["Erase_time"]);
                            noOfCoaches = Convert.ToInt32(row["No_Of_Coaches"]);
                            defaultEnglish = row["DefaultEnglish"].ToString().Trim();
                            defaultHindi = row["DefaultHindi"].ToString().Trim();
                            divisionOrPf = row["DivCode"].ToString().Trim();
                        }
                    }
                }
                List<string> CgdbIpAddresslist = ProcessListBasedOnStatus(CgdbIpAddressPositions, status);


                CgdbPacketPreparationLinkedtrain(CgdbIpAddresslist, coaches, coachtrainNumbers, trainNumber, packetidentifier, platformNo, videoType, letterSpeed, formatType, letterGap, displayEffect, fontSize, delayTime, eraseTime, noOfCoaches, defaultEnglish, defaultHindi, divisionOrPf);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public static List<string> ProcessListBasedOnStatus(List<string> inputList, string status)
        {
            try
            {

                if (status.ToLower() == "down")
                {
                    // Return the list as it is if status is "up"
                    inputList.Reverse();
                    return inputList;
                }
                else
                {
                    // Reverse the list if the status is anything else

                    return inputList;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return inputList;
        }
        public static (int datatimeout, int intensity, string pdcip) GetDatatimeoutAndIntensityPdcipCgdb(int? cdcid)
        {

            int defaultTimeout = 60;
            int defaultIntensity = 50;
            string pdcip = "";


            if (cdcid == null)
            {
                return (defaultTimeout, defaultIntensity, pdcip);
            }

            int datatimeout = defaultTimeout;
            int intensity = defaultIntensity;
            try
            {
                DataTable dt = HubConfigurationDb.GetCgdbConfiguration();
                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("Fkey_CDCID") && int.TryParse(row["Fkey_CDCID"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == cdcid)
                        {
                            if (row["Erase_time"] != DBNull.Value)
                            {
                                datatimeout = Convert.ToInt32(row["Erase_time"]);
                            }

                            if (row["Intensity"] != DBNull.Value)
                            {
                                intensity = Convert.ToInt32(row["Intensity"]);
                                intensity = frmBoardDiagnosis.GetIntensityRanges(intensity);
                            }
                            if (row["Pdcip"] != DBNull.Value)
                            {
                                pdcip = row["Pdcip"].ToString().Trim();

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return (datatimeout, intensity, pdcip);
        }
        public static (int datatimeout, int intensity) GetDatatimeoutAndIntensityCgdb(int? cdcid)
        {

            int defaultTimeout = 60;
            int defaultIntensity = 50;


            if (cdcid == null)
            {
                return (defaultTimeout, defaultIntensity);
            }

            int datatimeout = defaultTimeout;
            int intensity = defaultIntensity;
            try
            {
                DataTable dt = HubConfigurationDb.GetCgdbConfiguration();
                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("Fkey_CDCID") && int.TryParse(row["Fkey_CDCID"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == cdcid)
                        {
                            if (row["Erase_time"] != DBNull.Value)
                            {
                                datatimeout = Convert.ToInt32(row["Erase_time"]);
                            }

                            if (row["Intensity"] != DBNull.Value)
                            {
                                intensity = Convert.ToInt32(row["Intensity"]);
                                intensity = frmBoardDiagnosis.GetIntensityRanges(intensity);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return (datatimeout, intensity);
        }

        public static int GetIntensityCgdbboard(int cdcid)
        {


            int defaultIntensity = 50;
            int intensity = defaultIntensity;
            try
            {



                DataTable dt = HubConfigurationDb.GetCgdbConfiguration();

                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("Fkey_CDCID") && int.TryParse(row["Fkey_CDCID"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == cdcid)
                        {
                            if (row["Intensity"] != DBNull.Value)
                            {
                                intensity = Convert.ToInt32(row["Intensity"]);
                            }
                            break; // Found the matching row, exit the loop
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            return intensity;
        }
        public static void CgdbPacketPreparationLinkedtraininteroperability(List<string> CgdbIpAddressPositions, List<string> coachPositions, List<string> coachtrainNumber, string trainNumber, int packetidentifier, string platformNo, string videoType, string letterSpeed, string formatType, string letterGap, string displayEffect, int fontSize, int delayTime, int eraseTime, int noOfCoaches, string defaultEnglish, string defaultHindi, string divisionOrPf)
        {
            try
            {
                int PostionId = 0;
                // Example output of the list (for debugging purposes)
                foreach (string ipaddress in CgdbIpAddressPositions)
                {



                    Byte[] sendbyte = ByteFormation.CommonBytes(ipaddress, packetidentifier);
                    Array.Resize(ref sendbyte, sendbyte.Length + 2);
                    // int sodDataType = 2; //sod and defult and window
                    sendbyte[10] = (byte)ArecaIPIS.Classes.Board.DataTransfer;  //packet Type
                    sendbyte[11] = 2;  //Sod
                    string CoachName;

                    if (PostionId < coachPositions.Count)
                    {
                        CoachName = coachPositions[PostionId];
                        trainNumber = coachtrainNumber[PostionId];

                    }
                    else
                    {
                        CoachName = "";
                    }


                    string CoachEnglish = GetEnglishCoach(CoachName, defaultEnglish);
                    string CoachHindi = GetHindiCoach(CoachName, defaultHindi);

                    byte[] DataPacket = CgdbWindowFormation(packetidentifier, letterSpeed, videoType,
                                                    displayEffect, fontSize, letterGap, delayTime,
                            defaultEnglish, divisionOrPf, defaultHindi, trainNumber, CoachEnglish, CoachHindi);


                    Array.Resize(ref sendbyte, sendbyte.Length + DataPacket.Length + 4);

                    int z = 12;
                    for (int i = 0; i < DataPacket.Length; i++)
                    {
                        sendbyte[z] = DataPacket[i];
                        z++;

                    }

                    sendbyte[sendbyte.Length - 4] = 3;
                    sendbyte[sendbyte.Length - 3] = 0;
                    sendbyte[sendbyte.Length - 2] = 0;
                    sendbyte[sendbyte.Length - 1] = 4;

                    int packetLength = sendbyte.Length - 6;
                    byte[] packetLengthBytes = frmHubConfiguration.GetTwoBytesFromInt(packetLength);
                    sendbyte[3] = packetLengthBytes[0];
                    sendbyte[4] = packetLengthBytes[1];

                    Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                    Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                    Byte[] value = Server.CheckSum(finalPacket);
                    finalPacket[finalPacket.Length - 9] = value[0];   //crc msb
                    finalPacket[finalPacket.Length - 8] = value[1];    //crc lsb

                    if (ipaddress == "192.168.2.2")
                    {
                        Server.SendMessageToClient(ipaddress, finalPacket);
                    }
                    else
                    {
                        Server.SendMessageToClient(ipaddress, finalPacket);
                    }


                    PostionId++;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        public static void CgdbPacketPreparationLinkedtrain(List<string> CgdbIpAddressPositions, List<string> coachPositions, List<string> coachtrainNumber, string trainNumber, int packetidentifier, string platformNo, string videoType, string letterSpeed, string formatType, string letterGap, string displayEffect, int fontSize, int delayTime, int eraseTime, int noOfCoaches, string defaultEnglish, string defaultHindi, string divisionOrPf)
        {
            try
            {
                int PostionId = 0;
                // Example output of the list (for debugging purposes)
                foreach (string ipaddress in CgdbIpAddressPositions)
                {



                    Byte[] sendbyte = ByteFormation.CommonBytes(ipaddress, packetidentifier);
                    Array.Resize(ref sendbyte, sendbyte.Length + 2);
                    // int sodDataType = 2; //sod and defult and window
                    sendbyte[10] = (byte)ArecaIPIS.Classes.Board.DataTransfer;  //packet Type
                    sendbyte[11] = 2;  //Sod
                    string CoachName;

                    if (PostionId < coachPositions.Count)
                    {
                        CoachName = coachPositions[PostionId];
                        trainNumber = coachtrainNumber[PostionId];

                    }
                    else
                    {
                        CoachName = "";
                    }


                    string CoachEnglish = GetEnglishCoach(CoachName, defaultEnglish);
                    string CoachHindi = GetHindiCoach(CoachName, defaultHindi);

                    byte[] DataPacket = CgdbWindowFormation(packetidentifier, letterSpeed, videoType,
                                                    displayEffect, fontSize, letterGap, delayTime,
                            defaultEnglish, divisionOrPf, defaultHindi, trainNumber, CoachEnglish, CoachHindi);


                    Array.Resize(ref sendbyte, sendbyte.Length + DataPacket.Length + 4);

                    int z = 12;
                    for (int i = 0; i < DataPacket.Length; i++)
                    {
                        sendbyte[z] = DataPacket[i];
                        z++;

                    }

                    sendbyte[sendbyte.Length - 4] = 3;
                    sendbyte[sendbyte.Length - 3] = 0;
                    sendbyte[sendbyte.Length - 2] = 0;
                    sendbyte[sendbyte.Length - 1] = 4;

                    int packetLength = sendbyte.Length - 6;
                    byte[] packetLengthBytes = frmHubConfiguration.GetTwoBytesFromInt(packetLength);
                    sendbyte[3] = packetLengthBytes[0];
                    sendbyte[4] = packetLengthBytes[1];

                    Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                    Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                    Byte[] value = Server.CheckSum(finalPacket);
                    finalPacket[finalPacket.Length - 9] = value[0];   //crc msb
                    finalPacket[finalPacket.Length - 8] = value[1];    //crc lsb

                    if (ipaddress == "192.168.2.2")
                    {
                        Server.SendMessageToClient(ipaddress, finalPacket);
                    }
                    else
                    {
                        Server.SendMessageToClient(ipaddress, finalPacket);
                    }


                    PostionId++;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static void CgdbPacketPreparationinteroperability(List<string> CgdbIpAddressPositions, List<string> coachPositions, string trainNumber, int packetidentifier, string platformNo, string videoType, string letterSpeed, string formatType, string letterGap, string displayEffect, int fontSize, int delayTime, int eraseTime, int noOfCoaches, string defaultEnglish, string defaultHindi, string divisionOrPf, string pdcip)
        {
            try
            {
                int PostionId = 0;

                foreach (string ipaddress in CgdbIpAddressPositions)
                {


                    byte[] StopCommand = ByteFormation.StopCommand(ipaddress, packetidentifier);
                    byte[] trimmedstopBytes = ByteFormation.RemoveFirstAndLast6(StopCommand);



                    Server.SendMessageToClient(ipaddress, trimmedstopBytes);


                }

                byte[] BStopCommand = ByteFormation.BStopCommand(pdcip, packetidentifier);
                byte[] BtrimmedstopBytes = ByteFormation.RemoveFirstAndLast6(BStopCommand);
                string pdcbroadCastIp = Server.GetBroadcastIp(pdcip);

                Send_UDPClientData(BtrimmedstopBytes, 14, pdcbroadCastIp);






                foreach (string ipaddress in CgdbIpAddressPositions)
                {



                    Byte[] sendbyte = ByteFormation.CommonBytes(ipaddress, packetidentifier);
                    Array.Resize(ref sendbyte, sendbyte.Length + 2);
                    // int sodDataType = 2; //sod and defult and window
                    sendbyte[10] = (byte)ArecaIPIS.Classes.Board.DataTransfer;  //packet Type
                    sendbyte[11] = 2;  //Sod
                    string CoachName;
                    string trainname;
                    if (PostionId < coachPositions.Count)
                    {
                        CoachName = coachPositions[PostionId];
                        // trainname=
                    }
                    else
                    {
                        CoachName = "";
                    }


                    string CoachEnglish = GetEnglishCoach(CoachName, defaultEnglish);
                    string CoachHindi = GetHindiCoach(CoachName, defaultHindi);

                    byte[] DataPacket = CgdbWindowFormation(packetidentifier, letterSpeed, videoType,
                                                    displayEffect, fontSize, letterGap, delayTime,
                            defaultEnglish, divisionOrPf, defaultHindi, trainNumber, CoachEnglish, CoachHindi);


                    Array.Resize(ref sendbyte, sendbyte.Length + DataPacket.Length + 4);

                    int z = 12;
                    for (int i = 0; i < DataPacket.Length; i++)
                    {
                        sendbyte[z] = DataPacket[i];
                        z++;

                    }

                    sendbyte[sendbyte.Length - 4] = 3;
                    sendbyte[sendbyte.Length - 3] = 0;
                    sendbyte[sendbyte.Length - 2] = 0;
                    sendbyte[sendbyte.Length - 1] = 4;

                    int packetLength = sendbyte.Length - 6;
                    byte[] packetLengthBytes = frmHubConfiguration.GetTwoBytesFromInt(packetLength);
                    sendbyte[3] = packetLengthBytes[0];
                    sendbyte[4] = packetLengthBytes[1];

                    Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                    Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                    Byte[] value = Server.CheckSum(finalPacket);
                    finalPacket[finalPacket.Length - 9] = value[0];   //crc msb
                    finalPacket[finalPacket.Length - 8] = value[1];    //crc lsb

                    // string pdcbroadCastIp = Server.GetBroadcastIp(pdcip);




                    byte[] trimmedBytes = ByteFormation.RemoveFirstAndLast6(finalPacket);
                    Server.SendMessageToClient(ipaddress, trimmedBytes);




                    PostionId++;
                }


                foreach (string ipaddress in CgdbIpAddressPositions)
                {

                    byte[] StartCommand = ByteFormation.StartCommand(ipaddress, packetidentifier);
                    byte[] trimmedstartBytes = ByteFormation.RemoveFirstAndLast6(StartCommand);
                    Server.SendMessageToClient(ipaddress, trimmedstartBytes);
                }

                byte[] BStartCommand = ByteFormation.BStartCommand(pdcip, packetidentifier);
                byte[] BStartCommandtrimmedstopBytes = ByteFormation.RemoveFirstAndLast6(BStartCommand);


                Send_UDPClientData(BStartCommandtrimmedstopBytes, 14, pdcbroadCastIp);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static void Send_UDPClientData(byte[] DataToSend, int LengthOfData, string Broadcast_Addr)
        {


            try
            {
                using (UdpClient udpClient = new UdpClient(Server.udpPort))
                {
                    udpClient.Send(DataToSend, LengthOfData, Broadcast_Addr, Server.udpPort);
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;

            }
        }

        public static void CgdbPacketPreparation(List<string> CgdbIpAddressPositions, List<string> coachPositions, string trainNumber, int packetidentifier, string platformNo, string videoType, string letterSpeed, string formatType, string letterGap, string displayEffect, int fontSize, int delayTime, int eraseTime, int noOfCoaches, string defaultEnglish, string defaultHindi, string divisionOrPf)
        {
            try
            {
                int PostionId = 0;
                // Example output of the list (for debugging purposes)
                foreach (string ipaddress in CgdbIpAddressPositions)
                {



                    Byte[] sendbyte = ByteFormation.CommonBytes(ipaddress, packetidentifier);
                    Array.Resize(ref sendbyte, sendbyte.Length + 2);
                    // int sodDataType = 2; //sod and defult and window
                    sendbyte[10] = (byte)ArecaIPIS.Classes.Board.DataTransfer;  //packet Type
                    sendbyte[11] = 2;  //Sod
                    string CoachName;
                    string trainname;
                    if (PostionId < coachPositions.Count)
                    {
                        CoachName = coachPositions[PostionId];
                        // trainname=
                    }
                    else
                    {
                        CoachName = "";
                    }


                    string CoachEnglish = GetEnglishCoach(CoachName, defaultEnglish);
                    string CoachHindi = GetHindiCoach(CoachName, defaultHindi);

                    byte[] DataPacket = CgdbWindowFormation(packetidentifier, letterSpeed, videoType,
                                                    displayEffect, fontSize, letterGap, delayTime,
                            defaultEnglish, divisionOrPf, defaultHindi, trainNumber, CoachEnglish, CoachHindi);


                    Array.Resize(ref sendbyte, sendbyte.Length + DataPacket.Length + 4);

                    int z = 12;
                    for (int i = 0; i < DataPacket.Length; i++)
                    {
                        sendbyte[z] = DataPacket[i];
                        z++;

                    }

                    sendbyte[sendbyte.Length - 4] = 3;
                    sendbyte[sendbyte.Length - 3] = 0;
                    sendbyte[sendbyte.Length - 2] = 0;
                    sendbyte[sendbyte.Length - 1] = 4;

                    int packetLength = sendbyte.Length - 6;
                    byte[] packetLengthBytes = frmHubConfiguration.GetTwoBytesFromInt(packetLength);
                    sendbyte[3] = packetLengthBytes[0];
                    sendbyte[4] = packetLengthBytes[1];

                    Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                    Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                    Byte[] value = Server.CheckSum(finalPacket);
                    finalPacket[finalPacket.Length - 9] = value[0];   //crc msb
                    finalPacket[finalPacket.Length - 8] = value[1];    //crc lsb

                    if (ipaddress == "192.168.2.2")
                    {
                        Server.SendMessageToClient(ipaddress, finalPacket);
                    }
                    else
                    {
                        Server.SendMessageToClient(ipaddress, finalPacket);
                    }




                    PostionId++;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public static string GetEnglishCoach(string coachName, string defaultEnglish)
        {
            try
            {

                if (string.IsNullOrEmpty(coachName))
                {
                    return BaseClass.blankCgdb ? "" : defaultEnglish;
                }


                var letters = new StringBuilder();
                var digits = new StringBuilder();

                foreach (var ch in coachName)
                {
                    if (char.IsLetter(ch))
                        letters.Append(ch);
                    else if (char.IsDigit(ch))
                        digits.Append(ch);
                }
                var formattedName = $"{letters}-{digits}";
                if (string.IsNullOrEmpty(letters.ToString()))
                {
                    formattedName = $"{digits}";
                }

                if (string.IsNullOrEmpty(digits.ToString()))
                {
                    formattedName = $"{letters}";
                }



                if (char.IsDigit(coachName.Last()))
                {

                    return formattedName;
                }
                else
                {
                    return coachName;
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions for debugging
                Server.LogError(ex.Message);
            }

            // Default return if an exception occurs
            return coachName;
        }

        //public static string GetEnglishCoach(string coachName,string defaultEnglish)
        //{
        //    try
        //    {

        //    if (string.IsNullOrEmpty(coachName))
        //    {
        //        if (BaseClass.blankCgdb)
        //        {
        //            return "";
        //        }
        //        return defaultEnglish;
        //    }



        //    // Check if the coach name ends with a digit
        //    if (char.IsDigit(coachName.Last()))
        //    {
        //        // Insert a hyphen before the last digit
        //        return coachName.Substring(0, coachName.Length - 1) + "-" + coachName.Last();
        //    }
        //    else
        //    {
        //        return coachName;
        //    }
        //    }
        //    catch (Exception ex)
        //    {
        //        Server.LogError(ex.Message);
        //    }

        //    return coachName;

        //}

        public static string GetHindiCoach(string coachName, string defaultHindi)
        {
            try
            {


                DataTable coachBitmap = BaseClass.coachBitmap;

                if (string.IsNullOrEmpty(coachName))
                {
                    if (BaseClass.blankCgdb)
                    {
                        return "";
                    }
                    return defaultHindi;
                }

                // Helper function to look up the Hindi equivalent in the DataTable
                string GetHindiEquivalent(string english)
                {
                    foreach (DataRow row in coachBitmap.Rows)
                    {
                        if (row["EnglishCoachName"].ToString().Trim().Equals(english, StringComparison.OrdinalIgnoreCase))
                        {
                            return row["HindiCoachName"].ToString().Trim();
                        }
                    }
                    return english; // Return the original if no match is found
                }

                // Separate letters and digits
                string letters = new string(coachName.TakeWhile(char.IsLetter).ToArray());
                string digits = new string(coachName.SkipWhile(char.IsLetter).ToArray());

                // Translate the letters part
                string translatedLetters = GetHindiEquivalent(letters);

                // Format with hyphen if there are digits

                var formattedName = $"{translatedLetters}-{digits}";

                if (string.IsNullOrEmpty(translatedLetters.ToString()))
                {
                    formattedName = $"{digits}";
                }

                if (string.IsNullOrEmpty(digits.ToString()))
                {
                    formattedName = $"{translatedLetters}";
                }

                //if (!string.IsNullOrEmpty(digits))
                //{
                //    return translatedLetters + "-" + digits;
                //}

                return formattedName;
            }
            catch (Exception ex)
            {

                Server.LogError(ex.Message);
                return null;
            }

        }


        public static byte[] CgdbWindowFormation(
                      int packetidentifier, string letterSpeed, string videoType,
                 string DisplayEffect, int fontsize, string lettergap, int DelayTime,
                     string defaultEnglish, string divOrPf, string defaultHindi, string trainNumber, string CoachEnglish, string CoachHindi)
        {
            try
            {



                byte byte1 = 1;
                byte byte2 = 48;
                byte byte3 = 16;
                byte byte4 = 1;
                byte byte5 = frmHubConfiguration.GetNineByte(videoType, letterSpeed);
                byte byte6 = frmHubConfiguration.GetTenthByte(DisplayEffect);
                byte byte7 = frmHubConfiguration.GetEleventhByte(lettergap, fontsize);
                byte byte8 = frmHubConfiguration.GetTwelvethByte(DelayTime);

                List<byte> sendbyte = new List<byte>();

                // Add individual bytes
                sendbyte.Add(byte1);
                sendbyte.Add(byte2);
                sendbyte.Add(byte3);
                sendbyte.Add(byte4);
                sendbyte.Add(byte5);
                sendbyte.Add(byte6);
                sendbyte.Add(byte7);
                sendbyte.Add(byte8);

                // Add trainBits
                byte[] trainBits = frmHubConfiguration.Get10bits(trainNumber);
                sendbyte.AddRange(trainBits);

                // Add EnglishCoach
                byte[] EnglishCoach = frmHubConfiguration.Get10bits(CoachEnglish);
                sendbyte.AddRange(EnglishCoach);

                // Add fieldSeparator
                byte[] fieldSeparator = ByteFormation.GapCode;
                sendbyte.AddRange(fieldSeparator);

                // Add HindiBits
                byte[] HindiBits = frmHubConfiguration.GetCgdbHindibits(CoachHindi);
                sendbyte.AddRange(HindiBits);

                // Add the final byte
                sendbyte.Add(236);

                return sendbyte.ToArray();

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return null;
            }

        }

        public static byte[] SetConfigurationCgdb(string boardIp, int packet, int datatimeout, int intensity)
        {

            try
            {



                Byte[] sendbyte = ByteFormation.CommonBytes(boardIp, packet);
                if (sendbyte == null)
                {
                    return null;
                }
                Array.Resize(ref sendbyte, sendbyte.Length + 8);
                sendbyte[10] = (byte)Board.SetConfiguration;   //packet Type
                sendbyte[11] = 02;    //sod
                sendbyte[12] = (byte)intensity;   //intensity
                sendbyte[13] = (byte)datatimeout;    //datatimeout
                sendbyte[14] = 3;    //Eod
                sendbyte[17] = 4;  //end of data

                int packetLength = sendbyte.Length - 6;
                byte[] packetLengthBytes = frmBoardDiagnosis.GetTwoBytesFromInt(packetLength);
                sendbyte[3] = packetLengthBytes[0];
                sendbyte[4] = packetLengthBytes[1];

                Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);
                finalPacket[21] = value[0];   //crc ms
                finalPacket[22] = value[1];    //crc lsb



                return finalPacket;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return null;
        }

        public static List<string> GetConfigureBoards(string pdcip, int portno)
        {

            int CdcId = 0;
            List<string> listOfIps = new List<string>();
            listOfIps.Clear();
            try
            {
                //getTadb Boards
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("EthernetPort") && int.TryParse(row["EthernetPort"].ToString(), out int ethernetport))
                    {
                        if (ethernetport == portno)
                        {

                            string ipadress = row["IPAddress"].ToString();


                            listOfIps.Add(ipadress);
                        }
                    }

                    if (BaseClass.EthernetPorts.Columns.Contains("IPAddress") && row["IPAddress"] != null)
                    {
                        string ip = row["IPAddress"].ToString();

                        if (ip == pdcip)
                        {
                            if (int.TryParse(row["PkeyMasterhub"].ToString(), out int cdcId))
                            {
                                CdcId = cdcId;
                            }
                        }
                    }

                }

                DataTable cgdbIp = HubConfigurationDb.GetCoaches(CdcId);

                foreach (DataRow row in cgdbIp.Rows)
                {

                    string cgdbIpAddress = row.Field<string>("Cgdb_IpAddress");
                    listOfIps.Add(cgdbIpAddress);

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return listOfIps;
        }

    }
}
