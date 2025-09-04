using ArecaIPIS.Classes;
using ArecaIPIS.Server_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ArecaIPIS.Taddb_Controllers
{
    class IntegrationPacketComtroller
    {
        public static List<DataRow> IntrgrationSpecialStatusList = new List<DataRow>();

        public static void prepareDataPacketAsPerLangSeq()
        {
            foreach (int language in BaseClass.languageSequencepk)
            {
                PacketController.cdotInsertCount = 0;
                BaseClass.CurrentTrainIndex = 0;
                if (language == 6)//English
                {
                    BaseClass.CurrentLang = "eng";


                    if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                    {

                        IntegrationPfdbMldbDataPacket("eng");
                    }
                    else
                    {
                        PacketController.getOvdIvdDataPacket("eng");
                    }

                }
                else if (language == 16)//Hindi
                {
                    BaseClass.CurrentLang = "hin";


                    if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                    {
                        IntegrationPfdbMldbDataPacket("hin");
                    }
                    else
                    {
                        PacketController.getOvdIvdDataPacket("hin");
                    }

                }
                else//Regional
                {
                    BaseClass.CurrentLang = "reg";


                    if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                    {
                        IntegrationPfdbMldbDataPacket("reg");
                    }
                    else
                    {
                        PacketController.getOvdIvdDataPacket("reg");
                    }

                }

            }
        }



        public static void IntegrationPfdbMldbDataPacket(string lang)
        {
            if (BaseClass.defectiveLines.Count < BaseClass.noOfLines)
            {

                try
                {


                    foreach (DataRow row in BaseClass.OnlineTrainsTaddbDt.Rows)
                    {
                        bool b = false;
                        PacketController.CheckNextLineIsDefectiveOrNot();
                        b = CreateIntegrationMLDBPFBTrainDataBytes(row, lang);
                        if (b)
                        {
                            if (BaseClass.defectiveLines.Count != BaseClass.noOfLines - 1)
                                CdotController.CheckMldbCdotAlerts();
                        }

                    }

                    if (BaseClass.boardType != "PFDB")
                    {
                        if (BaseClass.defectiveLines.Count == BaseClass.noOfLines - 1)
                        {
                            PacketController.cdotInsertCount--;
                            CdotController.CheckMldbCdotAlerts();
                        }

                        PacketController.CheckMLDBEmptyWindows();
                    }


                    if (IntrgrationSpecialStatusList.Count > 0)
                    {
                        foreach (DataRow row in IntrgrationSpecialStatusList)
                        {
                            BaseClass.CurrentTrainIndex = 0;
                            bool b = false;
                            PacketController.CheckNextLineIsDefectiveOrNot();
                            b = CreateIntegrationSpecialStatusSecondWindowMLDBPFBTrainDataBytes(row, lang);
                        }
                        IntrgrationSpecialStatusList.Clear();
                    }
                    if (BaseClass.boardType == "PFDB")
                    {
                        CdotController.CheckPfdbCdotAlerts();
                    }

                }
                catch (Exception ex)
                {
                    Server.LogError(ex.Message);
                }
            }

        }
        public static bool CreateIntegrationSpecialStatusSecondWindowMLDBPFBTrainDataBytes(DataRow row, string lang)
        {
            bool sucess = false;
            try
            {


                string City = "";
                string trainStatus = "";
                string TrainName = "";
                string name = "";
                string exptTime = "";
                byte[] trainCityBytes = null;


                trainStatus = row["StatusName"].ToString().Trim();
                if (trainStatus == "Terminated At")
                {
                    trainStatus = "Terminated";
                }
                string trainNumber = row["TrainNo"].ToString().Trim();
                string ad = row["ArrivingStatus"].ToString().Trim();
                if (ad == "A")
                {
                    exptTime = row["LArrivalTime"].ToString().Trim();
                }
                else
                {
                    exptTime = row["LDepartureTime"].ToString().Trim();
                }
                string pf = "";
                if (row["PlatformName"].ToString().Trim() != null && row["PlatformName"].ToString().Trim() != "--")
                    pf = row["PlatformName"].ToString().Trim();

                if (lang == "eng")
                {
                    TrainName = row["Name"].ToString().Trim();
                    if (row["City"].ToString().Trim() != null)
                    {
                        City = row["City"].ToString().Trim();
                        BaseClass.currentCity = City;
                        trainCityBytes = Encoding.BigEndianUnicode.GetBytes(City);
                    }
                    name = BaseClass.getStatusName("eng", ad, trainStatus);
                }
                else if (lang == "hin")
                {
                    TrainName = row["LNational_Lang"].ToString().Trim();
                    if (row["HStation"].ToString().Trim() != null)
                    {
                        City = row["HStation"].ToString().Trim();
                        BaseClass.currentCity = City;
                        trainCityBytes = Encoding.BigEndianUnicode.GetBytes(City);
                    }
                    name = BaseClass.getStatusName("hin", ad, trainStatus);
                }
                else
                {
                    TrainName = row["LRegional1_Lang"].ToString().Trim();
                    if (row["RStation"].ToString().Trim() != null)
                    {
                        City = row["RStation"].ToString().Trim();
                        BaseClass.currentCity = City;
                        trainCityBytes = Encoding.BigEndianUnicode.GetBytes(City);
                    }
                    name = BaseClass.getStatusName("reg", ad, trainStatus);
                }




                BaseClass.characterString[0] = BaseClass.getStatusCode(trainStatus, ad);
                byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                byte[] trainNameBytes = Encoding.BigEndianUnicode.GetBytes(TrainName);
                byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);
                BaseClass.currentTrainStatusName = new string(name.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                BaseClass.currentTrainName = new string(TrainName.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

                BaseClass.CurrentStatuCode = BaseClass.getStatusCode(trainStatus, ad);
                BaseClass.characterString[0] = BaseClass.getStatusCode(trainStatus, ad);


                PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                BaseClass.taddbDataPacket.AddRange(IntegrationSeperators.PfdbMldbTrainNameSeperators);
                BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                BaseClass.taddbDataPacket.AddRange(IntegrationSeperators.PfdbMldbExptSeperators);

                if (BaseClass.CurrentStatuCode == 15)
                {
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(IntegrationSeperators.PfdbMldbADSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(IntegrationSeperators.PfdbMldbPFSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                }
                else
                {
                    BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                }
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                BaseClass.windowsDataPacket.AddRange(IntegrationWindowsColumns());
                BaseClass.CurrentTrainIndex++;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return sucess;
        }




        public static bool CreateIntegrationMLDBPFBTrainDataBytes(DataRow row, string lang)
        {
            bool sucess = false;
            try
            {


                string City = "";
                string trainStatus = "";
                string TrainName = "";
                string name = "";
                string exptTime = "";
                byte[] trainCityBytes = null;


                trainStatus = row["StatusName"].ToString().Trim();
                if (trainStatus == "Terminated At")
                {
                    trainStatus = "Terminated";
                }
                string trainNumber = row["TrainNo"].ToString().Trim();
                string ad = row["ArrivingStatus"].ToString().Trim();
                if (ad == "A")
                {
                    exptTime = row["LArrivalTime"].ToString().Trim();
                }
                else
                {
                    exptTime = row["LDepartureTime"].ToString().Trim();
                }
                string pf = "";
                if (row["PlatformName"].ToString().Trim() != null && row["PlatformName"].ToString().Trim() != "--")
                    pf = row["PlatformName"].ToString().Trim();

                if (lang == "eng")
                {
                    TrainName = row["Name"].ToString().Trim();
                    if (row["City"].ToString().Trim() != null)
                    {
                        City = row["City"].ToString().Trim();
                        BaseClass.currentCity = City;
                        trainCityBytes = Encoding.BigEndianUnicode.GetBytes(City);
                    }
                    name = BaseClass.getStatusName("eng", ad, trainStatus);
                }
                else if (lang == "hin")
                {
                    TrainName = row["LNational_Lang"].ToString().Trim();
                    if (row["HStation"].ToString().Trim() != null)
                    {
                        City = row["HStation"].ToString().Trim();
                        BaseClass.currentCity = City;
                        trainCityBytes = Encoding.BigEndianUnicode.GetBytes(City);
                    }
                    name = BaseClass.getStatusName("hin", ad, trainStatus);
                }
                else
                {
                    TrainName = row["LRegional1_Lang"].ToString().Trim();
                    if (row["RStation"].ToString().Trim() != null)
                    {
                        City = row["RStation"].ToString().Trim();
                        BaseClass.currentCity = City;
                        trainCityBytes = Encoding.BigEndianUnicode.GetBytes(City);
                    }
                    name = BaseClass.getStatusName("reg", ad, trainStatus);
                }



                if (PacketController.CheckPlatforms(pf))
                {
                    if (PacketController.CheckInfoDisplayed(ad))
                    {
                        BaseClass.characterString[0] = BaseClass.getStatusCode(trainStatus, ad);
                        byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                        byte[] trainNameBytes = Encoding.BigEndianUnicode.GetBytes(TrainName);
                        byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                        byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                        byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                        byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);
                        BaseClass.currentTrainStatusName = new string(name.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                        BaseClass.currentTrainName = new string(TrainName.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

                        BaseClass.CurrentStatuCode = BaseClass.getStatusCode(trainStatus, ad);
                        BaseClass.characterString[0] = BaseClass.getStatusCode(trainStatus, ad);

                        if (PacketController.checkNormalStatusCode() || (BaseClass.CurrentStatuCode == 4 || BaseClass.CurrentStatuCode == 6 || BaseClass.CurrentStatuCode == 7 || BaseClass.CurrentStatuCode == 11))
                        {//has arrived,cancell,indefinite,cancell
                            PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(IntegrationSeperators.PfdbMldbTrainNameSeperators);
                            BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(IntegrationSeperators.PfdbMldbExptSeperators);
                            if (BaseClass.CurrentStatuCode == 4 || BaseClass.CurrentStatuCode == 6 || BaseClass.CurrentStatuCode == 7 || BaseClass.CurrentStatuCode == 11)
                            {
                                if (BaseClass.CurrentStatuCode == 4 && lang == "eng")
                                {
                                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Arrived");
                                }
                                else
                                {
                                    name = BaseClass.getStatusName(lang, ad, trainStatus);
                                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                                }
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                            }
                            else
                            {
                                BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                                BaseClass.taddbDataPacket.AddRange(IntegrationSeperators.PfdbMldbADSeperators);
                                BaseClass.taddbDataPacket.AddRange(adBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                                BaseClass.taddbDataPacket.AddRange(IntegrationSeperators.PfdbMldbPFSeperators);
                                BaseClass.taddbDataPacket.AddRange(pfBytes);
                            }


                        }
                        else
                        {
                            PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(IntegrationSeperators.PfdbMldbTrainNameSeperators);
                            BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(IntegrationSeperators.PfdbMldbExptSeperators);

                            if (lang == "eng")
                            {
                                if (BaseClass.CurrentStatuCode == 15)
                                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);
                                else if (trainStatus != "Change of Source")
                                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus + " At");
                                else
                                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("start" + " At");
                            }
                            else
                            {
                                name = BaseClass.getStatusName(lang, ad, trainStatus);
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            }
                            BaseClass.taddbDataPacket.AddRange(trainStatusbytes);


                            IntrgrationSpecialStatusList.Add(row);



                        }
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                        BaseClass.windowsDataPacket.AddRange(IntegrationWindowsColumns());
                        BaseClass.CurrentTrainIndex++;
                        sucess = true;

                    }

                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return sucess;
        }


        public static byte[] IntegrationWindowsColumns()
        {
            List<byte> AllWindows = new List<byte>();
            try
            {
                AllWindows.Clear();



                PacketController.WindowsPacketFormation(PacketController.currentIp);
                byte[] taddbWindows = new byte[14];

                byte[] columns = windowsColumns();
                taddbWindows[0] = columns[0];
                taddbWindows[1] = columns[1];
                taddbWindows[2] = columns[2];
                taddbWindows[3] = columns[3];
                taddbWindows[4] = columns[4];
                taddbWindows[5] = columns[5];
                taddbWindows[6] = columns[6];
                taddbWindows[7] = columns[7];
                taddbWindows[8] = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEightbit);//speed reverse vedio
                taddbWindows[9] = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);//effect code
                taddbWindows[10] = ChangeIntegrationLetterGap();//letter size and gap
                taddbWindows[11] = changeIntegrationDelayTime();//delayTime


                AllWindows.AddRange(taddbWindows);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return AllWindows.ToArray();
        }
        public static byte changeIntegrationDelayTime()
        {
            byte b = 0;
            b = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit);
            if ((BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 15 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19))
                b = (byte)((int)b / 2);
            return b;
        }
        public static byte ChangeIntegrationLetterGap()
        {
            if (BaseClass.CurrentLang == "eng")
            {
                BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);

            }
            else if (BaseClass.CurrentLang == "hin")
            {
                BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(0);
            }
            else
            {
                BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.regionalGapCode);
            }
            return (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
        }
        public static byte[] MldbWindowsColumns()
        {
            try
            {

                byte[] taddbWindows = new byte[8];
                int trainIndex = BaseClass.CurrentTrainIndex;

                if (trainIndex >= BaseClass.noOfLines)
                {
                    trainIndex = trainIndex % BaseClass.noOfLines;
                }



                taddbWindows[0] = 00;
                taddbWindows[1] = 01;
                taddbWindows[2] = 01;
                taddbWindows[3] = 80;

                byte[] b1 = null;
                byte[] b2 = null;

                b1 = PfdbController.ConvertDecimalNumberTOByteArray((BaseClass.noOfLines - trainIndex) * 16);
                b2 = PfdbController.ConvertDecimalNumberTOByteArray((BaseClass.noOfLines - trainIndex) * 16 - 15);
                taddbWindows[4] = b1[0];
                taddbWindows[5] = b1[1];
                taddbWindows[6] = b2[0];
                taddbWindows[7] = b2[1];
                return taddbWindows;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return null;
            }

        }
        public static byte[] PfdbWindowsColumns()
        {
            byte[] taddbWindows = new byte[8];

            taddbWindows[0] = 00;
            taddbWindows[1] = 01;
            taddbWindows[2] = 01;
            taddbWindows[3] = 80;
            taddbWindows[4] = 00;
            taddbWindows[5] = 16;
            taddbWindows[6] = 00;
            taddbWindows[7] = 01;

            return taddbWindows;
        }
        public static byte[] windowsColumns()
        {

            byte[] taddbWindows = null;

            if (BaseClass.boardType == "AGDB")
            {
                //taddbWindows = AgdbWindowsColumns(window);
            }
            else if (BaseClass.boardType == "PFDB")
            {
                taddbWindows = PfdbWindowsColumns();
            }
            else if (BaseClass.boardType == "MLDB")
            {

                taddbWindows = MldbWindowsColumns();

            }
            else
            {

                // taddbWindows = MldbWindowsColumns(window);

            }

            return taddbWindows;
        }

    }
}
