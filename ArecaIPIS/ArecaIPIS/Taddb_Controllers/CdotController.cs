using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms.HomeForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ArecaIPIS.Server_Classes
{
    class CdotController
    {
        public static bool pausecdot = false;
        public static void CheckAgdbCdotAlerts()
        {
            try
            {
                if (BaseClass.IsCdotEnabled())
                {
                    DataTable CdotMessages = OnlineTrainsDao.GetCdotMessagesList();

                    foreach (DataRow row in CdotMessages.Rows)
                    {
                        PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                        PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        byte[] CdotMessageBytes = Encoding.BigEndianUnicode.GetBytes(row["CdotAlertMessages"].ToString());
                        CdotMsgLang = row["CdotLanguageCode"].ToString().ToLower().Trim();


                        BaseClass.taddbDataPacket.AddRange(CdotMessageBytes);

                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                        BaseClass.windowsDataPacket.AddRange(CdotAgdbWindowsPacket(2));

                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }



        public static byte cdotDelayTime = 0;

        public static byte cdotLetterSpeedRevese = 0;
        public static void GetCdotConfigData()
        {
            try
            {
                DataSet CdotDataConfig = InterfaceDb.GetCDotConfiguration();
                DataTable CdotDt = CdotDataConfig.Tables[0]; // Access the first table                    
                if (CdotDt.Rows.Count > 0)
                {
                    DataRow row = CdotDt.Rows[0];

                    cdotLetterSpeedRevese = (byte)BaseClass.convertBinaryToDecimal(0 + "0000" + BaseClass.convertDecimalToBinary(row.Field<int>("LetterSpeed")));
                    string delayTime = BaseClass.convertDecimalToBinary(row.Field<int>("DelayTimeInSec"));

                    cdotDelayTime = (byte)BaseClass.convertBinaryToDecimal(delayTime);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static bool CdotPacketPrep = false;
        public static bool CheckMldbCdotAlerts()
        {
            bool b = false;
            try
            {
                if (BaseClass.boardType == "MLDB")
                {

                    PacketController.cdotInsertCount++;
                    if (PacketController.cdotInsertCount == BaseClass.noOfLines - 1 - BaseClass.defectiveLines.Count)
                    {
                        PacketController.cdotInsertCount = 0;
                        if (BaseClass.IsCdotEnabled())
                        {


                            DataTable CdotMessages = OnlineTrainsDao.GetCdotMessagesList();

                            if (CdotMessages.Rows.Count > 0)
                            {
                                foreach (DataRow row in CdotMessages.Rows)
                                {
                                    PacketController.CheckNextLineIsDefectiveOrNot();

                                    PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                    byte[] CdotMessageBytes = Encoding.BigEndianUnicode.GetBytes(row["CdotAlertMessages"].ToString());
                                    CdotMsgLang = row["CdotLanguageCode"].ToString().ToLower().Trim();

                                    BaseClass.taddbDataPacket.AddRange(CdotMessageBytes);
                                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                                    BaseClass.windowsDataPacket.AddRange(CdotMldbWindowsPacket(1));


                                }

                                BaseClass.CurrentTrainIndex++;
                                b = true;
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return b;
        }





        public static void CheckPfdbCdotAlerts()
        {
            try
            {
                if (BaseClass.boardType == "PFDB")
                {
                    if (BaseClass.IsCdotEnabled())
                    {

                        DataTable CdotMessages = OnlineTrainsDao.GetCdotMessagesList();
                        foreach (DataRow row in CdotMessages.Rows)
                        {
                            PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            byte[] CdotMessageBytes = Encoding.BigEndianUnicode.GetBytes(row["CdotAlertMessages"].ToString());
                            CdotMsgLang = row["CdotLanguageCode"].ToString().ToLower().Trim();

                            BaseClass.taddbDataPacket.AddRange(CdotMessageBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                            BaseClass.windowsDataPacket.AddRange(CdotPfdbWindowsPacket(1));
                        }

                        BaseClass.CurrentTrainIndex++;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public static int cdotCount = 0;
        public static void CheckOvdIvdCdotAlerts()
        {
            int i = 0;
            cdotCount++;
            byte[] CdotMessageBytes = null;
            DataTable CdotMessages = null;
            byte[] Empty = Encoding.BigEndianUnicode.GetBytes("   ");
            try
            {
                CdotMessages = OnlineTrainsDao.GetCdotMessagesList();
                if (BaseClass.IsCdotEnabled() && CdotMessages.Rows.Count > 0)
                {

                    if (cdotCount == 3)
                    {
                        PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        Byte[] Cdotmsg = Encoding.BigEndianUnicode.GetBytes("CdotMsg");
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);

                        BaseClass.taddbDataPacket.AddRange(Cdotmsg);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);//1


                        foreach (DataRow row in CdotMessages.Rows)
                        {
                            if (i == 0)
                            {
                                CdotMessageBytes = Encoding.BigEndianUnicode.GetBytes(row["CdotLanguageCode"].ToString().Trim() + "#" + row["CdotAlertMessages"].ToString());
                                i++;
                            }
                            else
                            {
                                CdotMessageBytes = Encoding.BigEndianUnicode.GetBytes(row["CdotAlertMessages"].ToString());
                            }
                            BaseClass.taddbDataPacket.AddRange(CdotMessageBytes);
                            //  BaseClass.windowsDataPacket.AddRange(PacketController.ovdIvdWindows());
                        }
                        BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);//1

                        BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);//2

                        BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);//3
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                        BaseClass.CurrentTrainIndex++;
                        cdotCount = 0;
                    }
                    else
                    {
                        Byte[] Cdotmsg = Encoding.BigEndianUnicode.GetBytes("CdotMsg");
                        PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);

                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(Cdotmsg);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);//1

                        BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);//2

                        BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);//3

                        BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);//4
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        public static Byte[] CdotMldbWindowsPacket(int windows)
        {
            try
            {


                int trainIndex = BaseClass.CurrentTrainIndex;
                byte[] b1 = null;
                byte[] b2 = null;
                if (trainIndex >= BaseClass.noOfLines)
                {
                    trainIndex = trainIndex % BaseClass.noOfLines;
                }
                List<byte> AllWindows = new List<byte>();
                AllWindows.Clear();
                PacketController.WindowsPacketFormation(PacketController.currentIp);


                byte[] taddbWindows = new byte[14];

                taddbWindows[0] = 00;
                taddbWindows[1] = 01;
                taddbWindows[2] = 01;
                taddbWindows[3] = 80;
                if (BaseClass.defectiveLines.Contains(BaseClass.noOfLines))
                {
                    b1 = PfdbController.ConvertDecimalNumberTOByteArray((BaseClass.noOfLines - trainIndex) * 16);
                    b2 = PfdbController.ConvertDecimalNumberTOByteArray((BaseClass.noOfLines - trainIndex) * 16 - 15);
                    taddbWindows[4] = b1[0];
                    taddbWindows[5] = b1[1];
                    taddbWindows[6] = b2[0];
                    taddbWindows[7] = b2[1];
                }
                else
                {
                    taddbWindows[4] = 00;
                    taddbWindows[5] = 16;
                    taddbWindows[6] = 00;
                    taddbWindows[7] = 01;
                }



                taddbWindows[8] = cdotLetterSpeedRevese;
                taddbWindows[9] = 05;
                taddbWindows[10] = changeCdotLetterGap();
                taddbWindows[11] = cdotDelayTime;

                AllWindows.AddRange(taddbWindows);
                return AllWindows.ToArray();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return null;
            }

        }



        public static Byte[] CdotPfdbWindowsPacket(int windows)
        {
            try
            {


                List<byte> AllWindows = new List<byte>();
                AllWindows.Clear();
                PacketController.WindowsPacketFormation(PacketController.currentIp);


                byte[] taddbWindows = new byte[14];

                taddbWindows[0] = 00;
                taddbWindows[1] = 01;
                taddbWindows[2] = 01;
                taddbWindows[3] = 80;
                taddbWindows[4] = 00;
                taddbWindows[5] = 16;
                taddbWindows[6] = 00;
                taddbWindows[7] = 01;
                taddbWindows[8] = cdotLetterSpeedRevese;
                taddbWindows[9] = 05;
                taddbWindows[10] = changeCdotLetterGap();
                taddbWindows[11] = cdotDelayTime;

                AllWindows.AddRange(taddbWindows);
                return AllWindows.ToArray();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return null;
            }

        }
        public static Byte[] CdotAgdbWindowsPacket(int windows)
        {
            try
            {


                List<byte> AllWindows = new List<byte>();
                AllWindows.Clear();
                PacketController.WindowsPacketFormation(PacketController.currentIp);

                for (int i = 0; i < windows; i++)
                {
                    byte[] taddbWindows = new byte[14];

                    taddbWindows[0] = 00;
                    taddbWindows[1] = 01;
                    taddbWindows[2] = 00;
                    taddbWindows[3] = 192;
                    if (i == 0)
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                        taddbWindows[10] = changeCdotLetterGap();
                        taddbWindows[11] = cdotDelayTime;


                    }
                    else
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                        taddbWindows[10] = changeCdotLetterGap();
                        taddbWindows[11] = cdotDelayTime;
                    }

                    taddbWindows[8] = cdotLetterSpeedRevese;
                    taddbWindows[9] = 05;


                    AllWindows.AddRange(taddbWindows);
                }
                return AllWindows.ToArray();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return null;
            }

        }
        public static string CdotMsgLang = "";
        public static byte changeCdotLetterGap()
        {



            byte eleventhBit = 0;
            try
            {


                if (CdotMsgLang == "hi")
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(0);
                }
                else
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);
                }
                eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return eleventhBit;
        }



        public static void AGDBCdotsendData()
        {

            foreach (string ip in Server.AgdbIpAdress)
            {

                BaseClass.boardType = "AGDB";
                DataPacket(ip);
                byte[] finalPacket = AgdbController.getAgdbFullPacket(Board.AGDB, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);
                string a = BaseClass.ByteArrayToString(finalPacket);
                if (BaseClass.boardWorkingstatus && finalPacket.Length > 40)
                {
                    Server.SendMessageToClient(ip, finalPacket);

                }
            }
        }
        public static void PFDBCdotsendData()
        {

            foreach (string ip in Server.PfdbIpAdress)
            {

                BaseClass.boardType = "PFDB";
                DataPacket(ip);
                byte[] finalPacket = AgdbController.getAgdbFullPacket(Board.PFDB, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);
                string a = BaseClass.ByteArrayToString(finalPacket);
                if (BaseClass.boardWorkingstatus && finalPacket.Length > 40)
                {
                    Server.SendMessageToClient(ip, finalPacket);

                }
            }
        }
        public static void MLDBCdotsendData()
        {

            foreach (string ip in Server.MldbIpAdress)
            {

                BaseClass.boardType = "MLDB";
                DataPacket(ip);
                byte[] finalPacket = AgdbController.getAgdbFullPacket(Board.MLDB, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);
                string a = BaseClass.ByteArrayToString(finalPacket);
                if (BaseClass.boardWorkingstatus && finalPacket.Length > 40)
                {
                    Server.SendMessageToClient(ip, finalPacket);

                }
            }
        }
        public static void OVDCdotsendData()
        {

            foreach (string ip in Server.OvdIpAdress)
            {

                BaseClass.boardType = "OVDIVD";
                DataPacket(ip);
                byte[] finalPacket = AgdbController.getAgdbFullPacket(Board.OVD, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);
                string a = BaseClass.ByteArrayToString(finalPacket);
                if (BaseClass.boardWorkingstatus && finalPacket.Length > 40)
                {
                    Server.SendMessageToClient(ip, finalPacket);

                }
            }
        }
        public static void IVDCdotsendData()
        {

            foreach (string ip in Server.IvdIpAdress)
            {

                BaseClass.boardType = "OVDIVD";
                DataPacket(ip);
                byte[] finalPacket = AgdbController.getAgdbFullPacket(Board.IVD, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);
                string a = BaseClass.ByteArrayToString(finalPacket);
                if (BaseClass.boardWorkingstatus && finalPacket.Length > 40)
                {
                    Server.SendMessageToClient(ip, finalPacket);

                }
            }
        }
        public static byte[] DataPacket(string ip)
        {
            try
            {

                PacketController.currentIp = ip;
                PacketController.WindowsPacketFormation(ip);

                BaseClass.SpecialWindows.Clear();
                BaseClass.trainStatusNamesList.Clear();
                PacketController.NormalWindows.Clear();
                BaseClass.taddbDataPacket.Clear();
                BaseClass.windowsDataPacket.Clear();
                BaseClass.languageSequencepk.Clear();
                BaseClass.specialStatusData.Clear();
                BaseClass.trainsCount = 0;
                CdotController.CdotPacketPrep = true;


                if (BaseClass.boardType == "AGDB")
                {

                    CheckAgdbCdotAlerts();
                }
                else if (BaseClass.boardType == "PFDB")
                {
                    CheckPfdbCdotAlerts();
                }
                else if (BaseClass.boardType == "MLDB")
                {
                    CheckMldbCdotAlerts();
                }
                else
                {
                    //  getOvdIvdDataPacket("eng");
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return (BaseClass.taddbDataPacket.ToArray());
        }

        public static void getAgdbCdotDataPacket()
        {
            try
            {
                if (BaseClass.IsCdotEnabled())
                {

                    foreach (var checkedRow in frmCdot.CheckedCdotMessages)
                    {
                        //string HindiMessage = checkedRow.Cells["dgvHindiColumn"].Value.ToString();
                        //string EnglishMessage = checkedRow.Cells["dgvEnglishColumn"].Value.ToString();
                        //string RegMessage = checkedRow.Cells["dgvRegionalColumn"].Value.ToString();

                        //byte[] CdotMessageBytes = Encoding.BigEndianUnicode.GetBytes(row["CdotAlertMessages"].ToString());
                        //CdotMsgLang = row["CdotLanguageCode"].ToString().ToLower().Trim();
                        //PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        //BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        //BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                        //PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        //BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        //BaseClass.taddbDataPacket.AddRange(CdotMessageBytes);
                        //BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                        //BaseClass.windowsDataPacket.AddRange(CdotAgdbWindowsPacket(2));
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
