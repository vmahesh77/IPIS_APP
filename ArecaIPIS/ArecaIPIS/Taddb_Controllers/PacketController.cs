using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms;
using ArecaIPIS.Taddb_Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArecaIPIS.Server_Classes
{
    class PacketController
    {
        public static byte[] finalTaddbETX = new byte[] { 03, 00, 00, 04 };
        public static byte[] stratingBytes = new byte[] { 00, 00, 00, 00, 00, 00 };
        public static byte[] endingBytes = new byte[] { 255, 255 };
        public static byte[] emptyWindow = new byte[] { 255, 255, 255, 255 };
        public static byte[] characterString = new byte[] { 01, 00, 00, 00, 01 };
        public static byte[] Seperators = new byte[] { 231, 00 };
        public static string currentIp = "";
        public static List<int> NormalWindows = new List<int>();
        public static List<int> MessagesWindows = new List<int>();


        public static byte[] firstPacketByte(int startPacket, string SourceipAdress, string destinationIpAdress, int packetSerialNumer, int packetType)
        {
            try
            {


                string[] sourceOctets = SourceipAdress.Split('.');
                string[] destinationOctets = destinationIpAdress.Split('.');
                byte[] b = new byte[12];
                b[0] = Convert.ToByte("AA", 16);
                b[1] = Convert.ToByte("CC", 16);
                b[2] = Convert.ToByte(startPacket);
                b[3] = 0;
                b[4] = 0;
                b[5] = Convert.ToByte(destinationOctets[2]);
                b[6] = Convert.ToByte(destinationOctets[3]);
                b[7] = Convert.ToByte(sourceOctets[2]);
                b[8] = Convert.ToByte(sourceOctets[3]);
                b[9] = Convert.ToByte(packetSerialNumer);
                b[10] = Convert.ToByte(packetType);
                b[11] = Convert.ToByte(02);
                return b;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return null;
            }

        }

        public static void clearBoards(string Boardip)
        {
            int packetidentifier = Board.GetPacketIdentifier(Boardip);

            byte[] DeleteDataPacket = frmBoardDiagnosis.DeleteData(Boardip, packetidentifier);
            Server.SendMessageToClient(Boardip, DeleteDataPacket);
        }

        public static void WindowsPacketFormation(string ipadress)
        {
            try
            {


                int reverseVedio = 0;
                int speed = 0;
                int effectCode = 0;
                int letterSize = 0;
                int gap = 0;
                int timeDelay = 0;
                int noOfLines = 0;

                DataTable boardConfigdt = BoardConfigurationDb.getBoardConfiguration(ipadress);
                foreach (DataRow row in boardConfigdt.Rows)
                {
                    //BaseClass.langSequence = row["DisplaySequence"].ToString();
                    BaseClass.TaddbDisplaySeq = row["DisplaySequence"].ToString();
                    reverseVedio = Convert.ToInt32(row["VideoType"].ToString());
                    speed = Convert.ToInt32(row["LetterSpeed"].ToString());
                    effectCode = Convert.ToInt32(row["DisplayEffect"].ToString());
                    BaseClass.currentfontsize = letterSize = Convert.ToInt32(row["FontSize"]);
                    gap = Convert.ToInt32(row["LetterGap"].ToString());
                    timeDelay = Convert.ToInt32(row["DelayTime"].ToString());
                    noOfLines = Convert.ToInt32(row["NoofLines"].ToString());
                    BaseClass.boardWorkingstatus = Convert.ToBoolean(row["BoardRunning"].ToString());
                    BaseClass.checkedplatforms = row["Checkedplatforms"].ToString();
                    BaseClass.boardMessagesstatus = Convert.ToBoolean(row["MessagesEnble"].ToString());
                    BaseClass.InfoDisplayed = Convert.ToInt32(row["InfoDisplayed"].ToString());
                }
                BaseClass.noOfLines = noOfLines;

                BaseClass.gap = gap;
                BaseClass.timeDelay = timeDelay;
                BaseClass.TaddbWindowsEightbit = reverseVedio + "0000" + BaseClass.convertDecimalToBinary(speed);
                BaseClass.TaddbWindowsNinthbit = "0000" + BaseClass.convertDecimalToBinary(effectCode);

                //BaseClass.TaddbWindowsTenthbit = BaseClass.GetEleventhByte(letterSize.ToString(), gap);


                BaseClass.TaddbWindowsTenthbit = "00" + BaseClass.convertDecimalToBinary(letterSize) + BaseClass.convertDecimalToBinary(gap);

                BaseClass.TaddbWindowsEleventhbit = BaseClass.convertDecimalToBinary(BaseClass.timeDelay);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static int top = 16;
        public static int bottom = 0;


        public static byte[] SingleLineAgdbWindowsColumns(int window)
        {
            byte[] taddbWindows = new byte[8];
            try
            {



                if (BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19 || BaseClass.CurrentStatuCode == 15)
                {


                    if (window == 0) //empty
                    {

                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 128;
                    }
                    else if (window == 1)//train num
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }
                    else if (window == 2)// train name
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 59;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 22;
                    }
                    else if (window == 3)//status
                    {
                        taddbWindows[0] = 01;
                        taddbWindows[1] = 36;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 128;
                    }
                    else if (window == 4) //city or expt
                    {
                        taddbWindows[0] = 01;
                        taddbWindows[1] = 36;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 128;
                    }
                    else if (window == 5) //empty
                    {

                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 128;
                    }
                    else if (window == 6) //train num
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }

                    else if (window == 7) //train num
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 68;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 128;
                    }
                    else if (window == 8) //train num
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 68;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 128;
                    }


                    if (window == 0)//empty
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 1)//tr num
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }

                    else if (window == 2)//train name
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 3)//status
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 4) //city or expt
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 5)//empty
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 6) //tr.no
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 7)//c1
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 09;
                    }
                    else if (window == 8)//c2
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 08;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }




                }
                else
                {
                    if (window == 0) //empty
                    {

                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 128;
                    }
                    else if (window == 1)//train number 
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }
                    else if (window == 2)//train name
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 48;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 22;
                    }
                    else if (window == 3) //expt ad pf
                    {
                        taddbWindows[0] = 01;
                        taddbWindows[1] = 36;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 128;
                    }
                    else if (window == 4)//empty
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 128;
                    }
                    else if (window == 5)//train number
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }
                    else if (window == 6)//c1
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 68;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 128;
                    }
                    else if (window == 7)//c2
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 68;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 128;
                    }


                    if (window == 0)//empty
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 1)//tr no
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 2)//tr name
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 3)//expt ad pf
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 4)//empty
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 5) //tr.no
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 6)//c1
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 09;
                    }
                    else if (window == 7)//c2
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 08;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return taddbWindows;
        }

        public static Byte[] SingleLineAgdbWindowsPacket(int windows)
        {

            List<byte> AllWindows = new List<byte>();
            try
            {


                AllWindows.Clear();
                int count = 0;

                WindowsPacketFormation(currentIp);
                byte[] taddbWindows = new byte[14];
                for (int i = 0; i < windows; i++)
                {
                    // count = count + 1;
                    byte[] columns = SingleLineAgdbWindowsColumns(count);
                    taddbWindows[0] = columns[0];
                    taddbWindows[1] = columns[1];
                    taddbWindows[2] = columns[2];
                    taddbWindows[3] = columns[3];
                    taddbWindows[4] = columns[4];
                    taddbWindows[5] = columns[5];
                    taddbWindows[6] = columns[6];
                    taddbWindows[7] = columns[7];

                    taddbWindows[8] = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEightbit);//revese and speed
                    taddbWindows[9] = changeSingleLineAgdbScrolling(i);
                    taddbWindows[10] = AgdbChangeSingleLineLetterGap(i);
                    taddbWindows[11] = changeAgdbSingleLineDelayTime(i);
                    count++;
                    AllWindows.AddRange(taddbWindows);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            return AllWindows.ToArray();
        }
        public static Byte[] AgdbWindowsPacket(int windows)
        {

            List<byte> AllWindows = new List<byte>();
            try
            {


                AllWindows.Clear();
                int count = 0;

                WindowsPacketFormation(currentIp);
                byte[] taddbWindows = new byte[14];
                for (int i = 0; i < windows; i++)
                {
                    // count = count + 1;
                    byte[] columns = windowsColumns(count);
                    taddbWindows[0] = columns[0];
                    taddbWindows[1] = columns[1];
                    taddbWindows[2] = columns[2];
                    taddbWindows[3] = columns[3];
                    taddbWindows[4] = columns[4];
                    taddbWindows[5] = columns[5];
                    taddbWindows[6] = columns[6];
                    taddbWindows[7] = columns[7];

                    taddbWindows[8] = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEightbit);
                    taddbWindows[9] = changeAgdbScrolling(i);
                    taddbWindows[10] = AgdbChangeLetterGap(i);
                    taddbWindows[11] = changeAgdbCdotDelayTime(i);
                    count++;
                    AllWindows.AddRange(taddbWindows);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            return AllWindows.ToArray();
        }
        public static Byte[] LinkedAgdbWindowsPacket(int windows)
        {

            List<byte> AllWindows = new List<byte>();
            try
            {


                AllWindows.Clear();
                int count = 0;

                WindowsPacketFormation(currentIp);
                byte[] taddbWindows = new byte[14];
                for (int i = 0; i < windows; i++)
                {
                    // count = count + 1;
                    byte[] columns = LinkedwindowsColumns(count);
                    taddbWindows[0] = columns[0];
                    taddbWindows[1] = columns[1];
                    taddbWindows[2] = columns[2];
                    taddbWindows[3] = columns[3];
                    taddbWindows[4] = columns[4];
                    taddbWindows[5] = columns[5];
                    taddbWindows[6] = columns[6];
                    taddbWindows[7] = columns[7];

                    taddbWindows[8] = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEightbit);
                    taddbWindows[9] = LinkedchangeAgdbScrolling(i);
                    taddbWindows[10] = LinkedAgdbChangeLetterGap(i);
                    taddbWindows[11] = LinkedchangeAgdbDelayTime(i);
                    count++;
                    AllWindows.AddRange(taddbWindows);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            return AllWindows.ToArray();
        }
        public static Byte[] AgdbCdotWindowsPacket(int windows)
        {

            List<byte> AllWindows = new List<byte>();
            try
            {


                AllWindows.Clear();
                int count = 0;
                WindowsPacketFormation(currentIp);
                byte[] taddbWindows = new byte[14];
                for (int i = 0; i < windows; i++)
                {
                    // count = count + 1;
                    byte[] columns = windowsColumns(count);
                    taddbWindows[0] = columns[0];
                    taddbWindows[1] = columns[1];
                    taddbWindows[2] = columns[2];
                    taddbWindows[3] = columns[3];
                    taddbWindows[4] = columns[4];
                    taddbWindows[5] = columns[5];
                    taddbWindows[6] = columns[6];
                    taddbWindows[7] = columns[7];
                    taddbWindows[8] = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEightbit);
                    taddbWindows[9] = changeAgdbScrolling(i);
                    taddbWindows[10] = AgdbChangeLetterGap(i);
                    taddbWindows[11] = changeAgdbDelayTime(i);
                    count++;
                    AllWindows.AddRange(taddbWindows);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return AllWindows.ToArray();
        }

        public static Byte[] LinkedWindowsPacket()
        {
            List<byte> AllWindows = new List<byte>();
            try
            {


                AllWindows.Clear();
                int count = 0;
                int windows = 6;
                if (BaseClass.CurrentStatuCode == 15 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {
                    windows = 7;
                }
                if (BaseClass.CurrentStatuCode == 0)
                {
                    windows = 1;
                }
                WindowsPacketFormation(currentIp);
                byte[] taddbWindows = new byte[14];
                for (int i = 0; i < windows; i++)
                {
                    byte[] columns = LinkedwindowsColumns(count);
                    taddbWindows[0] = columns[0];
                    taddbWindows[1] = columns[1];
                    taddbWindows[2] = columns[2];
                    taddbWindows[3] = columns[3];
                    taddbWindows[4] = columns[4];
                    taddbWindows[5] = columns[5];
                    taddbWindows[6] = columns[6];
                    taddbWindows[7] = columns[7];
                    taddbWindows[8] = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEightbit);
                    taddbWindows[9] = LinkedTrainchangeScrolling(i);
                    taddbWindows[10] = LinkedTrainchangeLetterGap(i);
                    taddbWindows[11] = LinkedTrainchangeDelayTime(i);
                    count++;
                    AllWindows.AddRange(taddbWindows);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return AllWindows.ToArray();
        }


        public static Byte[] WindowsPacket()
        {
            List<byte> AllWindows = new List<byte>();
            try
            {


                AllWindows.Clear();
                int count = 0;
                int windows = 4;
                if (BaseClass.CurrentStatuCode == 15 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {
                    windows = 5;
                }
                if (BaseClass.CurrentStatuCode == 0)
                {
                    windows = 1;
                }
                WindowsPacketFormation(currentIp);
                byte[] taddbWindows = new byte[14];
                for (int i = 0; i < windows; i++)
                {
                    byte[] columns = windowsColumns(count);
                    taddbWindows[0] = columns[0];
                    taddbWindows[1] = columns[1];
                    taddbWindows[2] = columns[2];
                    taddbWindows[3] = columns[3];
                    taddbWindows[4] = columns[4];
                    taddbWindows[5] = columns[5];
                    taddbWindows[6] = columns[6];
                    taddbWindows[7] = columns[7];
                    taddbWindows[8] = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEightbit);
                    taddbWindows[9] = changeScrolling(i);
                    taddbWindows[10] = changeLetterGap(i);
                    taddbWindows[11] = changeDelayTime(i);
                    count++;
                    AllWindows.AddRange(taddbWindows);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return AllWindows.ToArray();
        }
        public static byte[] AgdbWindowsColumns(int window)
        {
            byte[] taddbWindows = new byte[8];
            try
            {



                if (BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19 || BaseClass.CurrentStatuCode == 15)
                {
                    // "Terminated"    Diverted   Change of Source      Rescheduled
                    if (window == 0 || window == 3) //train name
                    {

                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 1 || window == 2)// status window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 65;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 4)//train number second window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window >= 5 && window < 7) //coach pos1,2 lines
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 48;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 7) //empty window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window >= 8 && window < 10)//coach pos 3,4 lines
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 48;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }




                    if (window == 3)//train number,ad,expt,pf
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window < 3)
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }

                    else if (window == 4)//train number
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 5)//Coach pos1
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 25;
                    }
                    else if (window == 6) //Coach pos2
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 24;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 7)//Full Window
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 8)//Coach pos3
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 09;
                    }
                    else if (window == 9)//Coach pos4
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 08;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }





                }
                else
                {
                    if (window >= 0 && window < 3) //running right time first window
                    {
                        //   byte[] b=  TaddbController.ConvertDecimalNumberTOByteArray(192);   
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 3)//train number second window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }
                    else if (window >= 4 && window < 6) //coach pos1,2 lines
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 48;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 6) //empty window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window >= 7 && window < 9)//coach pos 3,4 lines
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 48;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    if (window == 0)//train number,ad,expt,pf
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 1)//train name
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 2)//full window
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 3)//train number
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 4)//Coach pos1
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 25;
                    }
                    else if (window == 5) //Coach pos2
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 24;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 6)//Full Window
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 7)//Coach pos3
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 09;
                    }
                    else if (window == 8)//Coach pos4
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 08;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return taddbWindows;
        }
        public static byte[] LinkedAgdbWindowsColumns(int window)
        {
            byte[] taddbWindows = new byte[8];
            try
            {



                if (BaseClass.CurrentStatuCode == 15)
                {
                    // "Terminated"    Diverted   Change of Source      Rescheduled
                    if (window == 0)//EMPTY
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 1 || window == 2)// TRAIN bumbers
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }
                    else if (window == 3)// RESCHEDULED
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 65;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 4)//EMPTY
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 5 || window == 6)// TRAIN numbers
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }
                    else if (window == 7)//Expt ad pf
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 65;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }

                    else if (window >= 8 && window <= 12) //train names,empty 
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 13 || window == 14)// TRAIN numbers
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }

                    else if (window >= 15 && window <= 16)//coach pos 3,4 lines
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 48;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 17) //empty window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window >= 18 && window <= 19)//coach pos 3,4 lines
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 48;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }




                    if (window >= 0 && window <= 2)//empty,trainumbers
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 3)//rescheduled
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 25;
                    }
                    if (window >= 4 && window <= 6)//empty, trainumbers
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }

                    else if (window == 7)//expt ad pf
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 25;
                    }
                    if (window >= 8 && window <= 11)// trainames
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 12)//empty
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    if (window >= 13 && window <= 14)// trainumbers
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }

                    else if (window == 15) //Coach pos1
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 25;
                    }
                    else if (window == 16) //Coach pos2
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 24;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 17)//Full Window
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 18)//Coach pos3
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 09;
                    }
                    else if (window == 19)//Coach pos4
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 08;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }





                }
                else if (BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {
                    // "Terminated"    Diverted   Change of Source      
                    if (window == 0)//EMPTY
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 1)// TRAIN bumbers
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }
                    else if (window == 2)// diverted 
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 65;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 3 || window == 4)// TRAIN bumbers
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }
                    else if (window == 5)// city
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 65;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 6)// TRAIN numbers
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }
                    else if (window >= 7 && window <= 10)// TRAIN numbers
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }




                    if (window >= 0 && window <= 6)//empty,trainumbers ,status,city
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }

                    else if (window >= 7 && window <= 10)//Full Window
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }

                }
                else
                {
                    if (window >= 0 && window <= 4) //running right time first window
                    {
                        //   byte[] b=  TaddbController.ConvertDecimalNumberTOByteArray(192);   
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 5 || window == 6)//train number second window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }

                    else if (window >= 7 && window <= 8) //coach pos1,2 lines
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 48;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 9) //empty window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window >= 10 && window <= 11)//coach pos 3,4 lines
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 48;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    if (window == 0 || window == 1)//train name
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }

                    else if (window == 2 || window == 3)//train number
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 4)//full window
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 5 || window == 6)//train number
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 7)//Coach pos1
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 25;
                    }
                    else if (window == 8) //Coach pos2
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 24;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 9)//Full Window
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 10)//Coach pos3
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 09;
                    }
                    else if (window == 11)//Coach pos4
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 08;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return taddbWindows;
        }
        public static byte[] PfdbWindowsColumns(int window)
        {
            byte[] taddbWindows = new byte[8];
            if (window == 0)
            {
                taddbWindows[0] = 00;
                taddbWindows[1] = 01;
                taddbWindows[2] = 01;
                taddbWindows[3] = 80;
            }
            else if (window == 1)
            {
                taddbWindows[0] = 00;
                taddbWindows[1] = 01;
                taddbWindows[2] = 00;
                taddbWindows[3] = 58;
            }
            else if (window == 2)
            {
                taddbWindows[0] = 00;
                taddbWindows[1] = 59;
                taddbWindows[2] = 00;
                taddbWindows[3] = 240;
            }
            else if (window == 3 || window == 4)
            {
              

                if (BaseClass.PlatformsSize!="3")
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 254;
                    taddbWindows[2] = 01;
                    taddbWindows[3] = 80;
                }
                else
                {


                    taddbWindows[0] = 00;
                    taddbWindows[1] = 244;
                    taddbWindows[2] = 01;
                    taddbWindows[3] = 80;
                }
            }

            taddbWindows[4] = 00;
            taddbWindows[5] = 16;
            taddbWindows[6] = 00;
            taddbWindows[7] = 01;

            return taddbWindows;
        }


    


        public static byte[] LinkedPfdbWindowsColumns(int window)
        {
            byte[] taddbWindows = new byte[8];
            if (window == 0)
            {
                taddbWindows[0] = 00;
                taddbWindows[1] = 01;
                taddbWindows[2] = 01;
                taddbWindows[3] = 80;
            }
            else if (window == 1 || window == 2)
            {
                taddbWindows[0] = 00;
                taddbWindows[1] = 01;
                taddbWindows[2] = 00;
                taddbWindows[3] = 58;
            }
            else if (window == 3 || window == 4)
            {
                taddbWindows[0] = 00;
                taddbWindows[1] = 59;
                taddbWindows[2] = 00;
                taddbWindows[3] = 240;
            }
            else if (window == 5 || window == 6)
            {
                taddbWindows[0] = 00;
                taddbWindows[1] = 244;
                taddbWindows[2] = 01;
                taddbWindows[3] = 80;
            }

            taddbWindows[4] = 00;
            taddbWindows[5] = 16;
            taddbWindows[6] = 00;
            taddbWindows[7] = 01;

            return taddbWindows;
        }
        public static byte[] LinkedMldbWindowsColumns(int window)
        {
            try
            {



                byte[] taddbWindows = new byte[8];
                int trainIndex = BaseClass.CurrentTrainIndex;

                if (trainIndex >= BaseClass.noOfLines)
                {
                    trainIndex = trainIndex % BaseClass.noOfLines;
                }



                if (window == 0)//empty
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 01;
                    taddbWindows[2] = 01;
                    taddbWindows[3] = 80;
                }
                else if (window == 1 || window == 2)//num
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 01;
                    taddbWindows[2] = 00;
                    taddbWindows[3] = 58;
                }
                else if (window == 3 || window == 4)//name
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 59;
                    taddbWindows[2] = 00;
                    taddbWindows[3] = 240;
                }
                else if (window == 5 || window == 6)//status
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 244;
                    taddbWindows[2] = 01;
                    taddbWindows[3] = 80;
                }
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
        public static byte[] MldbWindowsColumns(int window)
        {
            try
            {



                byte[] taddbWindows = new byte[8];
                int trainIndex = BaseClass.CurrentTrainIndex;

                if (trainIndex >= BaseClass.noOfLines)
                {
                    trainIndex = trainIndex % BaseClass.noOfLines;
                }



                if (window == 0)
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 01;
                    taddbWindows[2] = 01;
                    taddbWindows[3] = 80;
                }
                else if (window == 1)
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 01;
                    taddbWindows[2] = 00;
                    taddbWindows[3] = 58;
                }
                else if (window == 2)
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 59;
                    taddbWindows[2] = 00;
                    taddbWindows[3] = 240;
                }
                else if (window == 3 || window == 4)
                {


                    if (BaseClass.PlatformsSize != "3")
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 254;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 80;
                    }
                    else
                    {


                        taddbWindows[0] = 00;
                        taddbWindows[1] = 244;
                        taddbWindows[2] = 01;
                        taddbWindows[3] = 80;
                    }
                }
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
        public static byte[] windowsColumns(int window)
        {



            byte[] taddbWindows = null;

            if (BaseClass.boardType == "AGDB")
            {
                taddbWindows = AgdbWindowsColumns(window);
            }
            else if (BaseClass.boardType == "PFDB")
            {
                taddbWindows = PfdbWindowsColumns(window);
            }
            else if (BaseClass.boardType == "MLDB")
            {

                taddbWindows = MldbWindowsColumns(window);

            }
            else
            {

                taddbWindows = MldbWindowsColumns(window);

            }

            return taddbWindows;
        }
        public static byte[] LinkedwindowsColumns(int window)
        {



            byte[] taddbWindows = null;

            if (BaseClass.boardType == "AGDB")
            {
                taddbWindows = LinkedAgdbWindowsColumns(window);
            }
            else if (BaseClass.boardType == "PFDB")
            {
                taddbWindows = LinkedPfdbWindowsColumns(window);
            }
            else if (BaseClass.boardType == "MLDB")
            {

                taddbWindows = LinkedMldbWindowsColumns(window);

            }
            else
            {

                taddbWindows = LinkedMldbWindowsColumns(window);

            }

            return taddbWindows;
        }
        public static byte LinkedAgdbChangeLetterGap(int i)
        {
            byte eleventhBit = 0;

            eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
            if (checkNormalStatusCode() || BaseClass.CurrentStatuCode == 4)
            {// "Has Arrived On"
                if (i < 7)
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);
                    eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
                }
                else
                {

                    eleventhBit = 01;
                }
            }
            else if (BaseClass.CurrentStatuCode == 15) //only Rescheduled
            {//Rescheduled
                if (i == 0 || i == 4 || i == 12)
                {
                    eleventhBit = 01;
                }
                else if (i < 15)
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);
                    eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
                }
                else
                {
                    eleventhBit = 01;
                }
            }

            if (BaseClass.CurrentStatuCode == 16)
            {
                if (i == 0)
                    eleventhBit = 01;
            }


            return eleventhBit;
        }
        public static byte AgdbChangeSingleLineLetterGap(int i)
        {
            byte eleventh = 0;
            eleventh = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
            try
            {
                if (checkNormalStatusCode() || BaseClass.CurrentStatuCode == 4)
                {
                    if (i == 0 || i == 4 || i == 6 || i == 7)
                    {
                        eleventh = 01;
                    }


                }
                else if (BaseClass.CurrentStatuCode == 15)
                {
                    if (i == 0 || i == 5 || i == 7 || i == 8)
                    {
                        eleventh = 01;
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        eleventh = 01;
                    }
                }


            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return eleventh;
        }
        public static byte AgdbChangeLetterGap(int i)
        {
            byte eleventhBit = 0;
            eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
            if (checkNormalStatusCode() || BaseClass.CurrentStatuCode == 4)
            {// "Has Arrived On"
                if (i < 4)
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);
                    eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
                }
                else
                {
                    eleventhBit = 01;
                }
            }
            else if (BaseClass.CurrentStatuCode == 15) //only Rescheduled
            {//Rescheduled
                if (i < 5)
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);
                    eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
                }
                else
                {
                    eleventhBit = 01;
                }
            }



            return eleventhBit;
        }
        public static byte LinkedchangeAgdbScrolling(int i)
        {

            byte ninthBit = 0;
            try
            {



                ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
                if (checkNormalStatusCode() || BaseClass.CurrentStatuCode == 6 || BaseClass.CurrentStatuCode == 11 || BaseClass.CurrentStatuCode == 4 || BaseClass.CurrentStatuCode == 7)
                {
                    //cancelled     "Has Arrived on"  "Indefinite Late" ""running right time
                    if (i == 0 || i == 1)
                    {
                        if (BaseClass.currentTrainName.Length > 24) //scrolling
                            ninthBit = 5;
                    }
                    if (i == 9 || i == 4)//empty window
                    {
                        ninthBit = 00;
                    }
                }
                else
                {
                    if (BaseClass.CurrentStatuCode == 15)//Rescheduled
                    {
                        if (i >= 8 && i <= 11)
                        {
                            if (BaseClass.currentTrainName.Length > 24) //scrolling
                                ninthBit = 05;
                        }

                    }
                    else if (BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                    {
                        if (i >= 7 && i <= 10)
                            ninthBit = 5;
                    }


                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return ninthBit;
        }
        public static byte changeSingleLineAgdbScrolling(int i)
        {
            byte ninthBit = 0;
            try
            {
                ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
                if (checkNormalStatusCode())
                {


                    if (coachExisted)
                    {
                        if (i == 0 || i == 4 || i == 6 || i == 7)
                            ninthBit = 00;
                    }
                }

                if (i == 2)//tr name
                {
                    if (BaseClass.currentTrainName.Length > 24) //scrolling
                        ninthBit = 5;
                }

                if (i == 3)//special status
                {
                    if (BaseClass.CurrentStatuCode == 7 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 15)
                    {
                        ninthBit = 5;
                    }
                }
                if (i == 4)
                {
                    int length = frmHubConfiguration.GetEnglishBitmapLength(BaseClass.currentCity, BaseClass.currentfontsize);
                    if (length > 100)
                    {
                        ninthBit = 5;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return ninthBit;
        }
        public static byte changeAgdbScrolling(int i)
        {

            byte ninthBit = 0;
            try
            {



                ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
                if (checkNormalStatusCode() || BaseClass.CurrentStatuCode == 6 || BaseClass.CurrentStatuCode == 11 || BaseClass.CurrentStatuCode == 4 || BaseClass.CurrentStatuCode == 7)
                {
                    //cancelled     "Has Arrived on"  "Indefinite Late"
                    if (i == 0)
                    {
                        if (BaseClass.currentTrainName.Length > 24) //scrolling
                            ninthBit = 5;
                    }
                    if (i == 6 || i == 2)//empty window
                    {
                        ninthBit = 00;
                    }
                }
                else
                {
                    if (i == 3)
                    {
                        if (BaseClass.currentTrainName.Length > 24) //scrolling
                            ninthBit = 5;
                    }
                    if (i == 2)
                    {
                        if (BaseClass.currentCity.Length > 10 && BaseClass.CurrentStatuCode != 15) //scrolling  "Rescheduled"
                            ninthBit = 5;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return ninthBit;
        }
        public static byte changeAgdbDelayTime(int i)
        {
            byte tenthBit;
            if (BaseClass.CurrentStatuCode != 15)//"Rescheduled"
            {
                if ((i == 1 || i == 2) && (BaseClass.CurrentStatuCode == 15 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19))
                {//"Rescheduled"  "Terminated" "Diverted" "Change of Source"

                    tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
                }
                else
                {
                    tenthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit);

                }
            }
            else
            {
                if ((i == 1 || i == 2 || i == 5 || i == 6 || i == 8 || i == 9) && (BaseClass.CurrentStatuCode == 15 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19))
                {//"Rescheduled"  "Terminated" "Diverted" "Change of Source"

                    tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
                }
                else
                {
                    tenthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit);

                }
            }
            return tenthBit;
        }

        public static byte LinkedRescheduldeDelayTime(int i)
        {
            byte tenthBit = 0;
            if (i == 0 || i == 3 || i == 4 || i == 7 | i == 13 | i == 14)//empty
            {
                tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 5);
            }
            else if (i == 1 || i == 2 || i == 5 || i == 6 || i == 8 || i == 9 || i == 10 || i == 11)//train numbers
            {
                tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 10);
            }
            else if (i == 12 || i == 15 || i == 16 || i == 17 || i == 18 || i == 19)
            {
                tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
            }
            return tenthBit;
        }
        public static byte LinkedDivertedChangeTrmiDelayTime(int i)
        {
            byte tenthBit = 0;
            if (i == 0)//empty
            {
                tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit));
            }
            else if (i == 1 || i == 3 || i == 4 || i == 6 || i == 7 || i == 8 || i == 9 || i == 10)//train numbers
            {
                tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 5);
            }
            else if (i == 2 || i == 5)
            {
                tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
            }
            return tenthBit;
        }
        public static byte LinkedchangeAgdbDelayTime(int i)
        {
            byte tenthBit;
            if ((BaseClass.CurrentStatuCode == 15 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19))
            {//"Rescheduled" "Diverted" "Change of Source"
                if (BaseClass.CurrentStatuCode == 15)
                {
                    tenthBit = LinkedRescheduldeDelayTime(i);
                }
                else
                {
                    tenthBit = LinkedDivertedChangeTrmiDelayTime(i);
                }
            }
            else
            {
                if (i < 7)
                {
                    if (i == 4)
                        tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit));
                    else
                        tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
                }
                else
                {
                    tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit));
                }
            }


            return tenthBit;
        }
        public static byte changeAgdbSingleLineDelayTime(int i)
        {
            byte tenthBit;
            tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit));
            if (checkNormalStatusCode())
            {
                if (coachExisted)
                    tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
            }
            else
            {
                if (BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 15 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {//change of source ,diverted,terminated,Rescheduled
                    if (coachExisted)
                    {
                        tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
                        if (i == 3 || i == 4)
                            tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 4);
                    }

                    else if (i == 3 || i == 4)
                        tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
                }

            }

            return tenthBit;
        }
        public static byte changeAgdbCdotDelayTime(int i)
        {
            byte tenthBit;
            if ((BaseClass.CurrentStatuCode == 15 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19) && (i == 1 || i == 2))
            {//"Rescheduled" "Diverted" "Change of Source"
                tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
            }
            else if (BaseClass.CurrentStatuCode == 15)
            {//"Rescheduled"
                if (i == 1 || i == 2)
                {
                    tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
                }
                else
                {
                    tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit));
                }
            }
            else
            {
                tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit));
            }


            return tenthBit;
        }
        public static byte changeMessageScrolling()
        {
            byte b = 00;
            if (BaseClass.currentMessage.Length > 40)
            {
                b = 05;
            }
            else
            {
                b = 00;
            }
            return b;
        }


        public static byte ChangeReverseAndSpeed()
        {
            return (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEightbit);
        }

        public static byte changeMessageLetterGap()
        {
            byte eleventhBit = 0;
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
            eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
            return eleventhBit;
        }
        public static byte changeMessageDelayTime()
        {


            return (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit);
        }



        public static byte LinkedTrainchangeScrolling(int i)
        {
            byte ninthBit;
            if (BaseClass.CurrentStatuCode == 0 || i == 0) //EmptyWindow
            {
                return 0;
            }
            else if (i == 3 || i == 4) //TrainNameScrolling
            {
                if (BaseClass.currentTrainName.Length > 22) //scrolling
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else if (BaseClass.CurrentStatuCode == 7 || BaseClass.CurrentStatuCode == 15)//Indefinite Late,,Rescheduled
            {
                if (i == 5 && BaseClass.currentTrainStatusName.Length > 10) //scrolling
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else if (BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 21)// "Terminated"
            {
                if (BaseClass.CurrentLang == "eng" && i == 5)
                    ninthBit = 5;
                else if (i == 3 && BaseClass.currentTrainStatusName.Length > 10) // scrolling tabs
                    ninthBit = 5;
                else if (i == 4 && BaseClass.currentCity.Length > 10)
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else if (BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)//"Diverted",,"Change of Source"
            {
                if (i == 6 && BaseClass.currentCity.Length > 10) //scrolling next tab
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else if (BaseClass.CurrentStatuCode == 4)//has arrived is arriing on
            {
                if (BaseClass.currentTrainStatusName.Length > 14)
                {
                    ninthBit = 5;
                }
                else
                {
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
                }
            }
            else
            {
                if (BaseClass.currentTrainName.Length > 18 && i == 5 && BaseClass.CurrentLang == "reg" && !checkNormalStatusCode())
                {
                    ninthBit = 5;
                }
                else
                {
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
                }
            }

            return ninthBit;
        }



        public static byte changeScrolling(int i)
        {
            byte ninthBit;
            if (BaseClass.CurrentStatuCode == 0 || i == 0) //EmptyWindow
            {
                return 0;
            }
            else if (i == 2) //TrainNameScrolling
            {
                if (BaseClass.currentTrainName.Length > 22) //scrolling
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else if (BaseClass.CurrentStatuCode == 7 || BaseClass.CurrentStatuCode == 15)//Indefinite Late,,Rescheduled
            {
                if (i == 3 && BaseClass.currentTrainStatusName.Length > 10) //scrolling
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else if (BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 21)// "Terminated"
            {
                if (BaseClass.CurrentLang == "eng" && i == 3)
                    ninthBit = 5;
                else if (i == 3 && BaseClass.currentTrainStatusName.Length > 10) // scrolling tabs
                    ninthBit = 5;
                else if (i == 4 && BaseClass.currentCity.Length > 10)
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else if (BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)//"Diverted",,"Change of Source"
            {
                if (i == 4 && BaseClass.currentCity.Length > 10) //scrolling next tab
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else if (BaseClass.CurrentStatuCode == 4)//has arrived is arriing on
            {
                if (BaseClass.currentTrainStatusName.Length > 14)
                {
                    ninthBit = 5;
                }
                else
                {
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
                }
            }
            else
            {
                if (BaseClass.currentTrainName.Length > 18 && i == 3 && BaseClass.CurrentLang == "reg" && !checkNormalStatusCode())
                {
                    ninthBit = 5;
                }
                else
                {
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
                }
            }

            return ninthBit;
        }
        public static byte changeDelayTime(int i)
        {
            byte tenthBit;


            if ((i == 4 || i == 3) && (BaseClass.CurrentStatuCode == 15 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19))
            {
                //"Change of Source"  "Terminated"  "Diverted"  Rescheduled

                tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
            }
            else
            {
                tenthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit);

            }
            return tenthBit;
        }
        public static byte LinkedTrainchangeDelayTime(int i)
        {
            byte tenthBit;


            if ((i == 5 || i == 6) && (BaseClass.CurrentStatuCode == 15 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19))
            {
                //"Change of Source"  "Terminated"  "Diverted"  Rescheduled

                tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
            }
            else
            {
                if (i == 0)
                    tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit));
                else if (i != 5)
                    tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
                else
                    tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit));

            }
            return tenthBit;
        }
        public static byte changeLetterGap(int i)
        {
            byte eleventhBit;
            if (i == 1) //train Number Letter gap in any status
            {
                BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);

            }
            else if (checkStatus(i)) //general statusses
            {
                BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);


            }
            else if (checkSpecialWindowStatuses(i))  //single window statusses and double except reschedule
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
            }
            else if (BaseClass.CurrentStatuCode == 15) //only Rescheduled
            {

                if (i == 2 || i == 3)
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
                }
                else if (i == 4)
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);

                }
            }

            eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
            return eleventhBit;
        }
        public static byte LinkedTrainchangeLetterGap(int i)
        {
            byte eleventhBit;
            if (i == 1 || i == 2) //train Number Letter gap in any status
            {
                BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);

            }
            else if (LinkTraincheckStatus(i)) //general statusses
            {
                BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);


            }
            else if (LinkTraincheckSpecialWindowStatuses(i))  //single window statusses and double except reschedule
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
            }
            else if (BaseClass.CurrentStatuCode == 15) //only Rescheduled
            {

                if (i == 3 || i == 4 || i == 5)//train name and status
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
                }
                else if (i == 6)//secon special status
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);

                }
            }

            eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
            return eleventhBit;
        }

        public static bool checkStatus(int i)
        {
            if ((i == 3) && (BaseClass.CurrentStatuCode == 1
               || BaseClass.CurrentStatuCode == 2 || BaseClass.CurrentStatuCode == 3
               || BaseClass.CurrentStatuCode == 5 || BaseClass.CurrentStatuCode == 12
               || BaseClass.CurrentStatuCode == 18 || BaseClass.CurrentStatuCode == 17
               || BaseClass.CurrentStatuCode == 13 || BaseClass.CurrentStatuCode == 14
               || BaseClass.CurrentStatuCode == 9 || BaseClass.CurrentStatuCode == 20
               || BaseClass.CurrentStatuCode == 10
               ))//running right time hindi letter gap
            {
                return true;
            }
            return false;
        }
        public static bool LinkTraincheckStatus(int i)
        {
            if ((i == 5) && (BaseClass.CurrentStatuCode == 1
               || BaseClass.CurrentStatuCode == 2 || BaseClass.CurrentStatuCode == 3
               || BaseClass.CurrentStatuCode == 5 || BaseClass.CurrentStatuCode == 12
               || BaseClass.CurrentStatuCode == 18 || BaseClass.CurrentStatuCode == 17
               || BaseClass.CurrentStatuCode == 13 || BaseClass.CurrentStatuCode == 14
               || BaseClass.CurrentStatuCode == 9 || BaseClass.CurrentStatuCode == 20
               || BaseClass.CurrentStatuCode == 10
               ))//running right time hindi letter gap
            {
                return true;
            }
            return false;
        }
        public static bool checkSpecialWindowStatuses(int i)
        {
            if ((i == 2 || i == 3 || i == 4) && (BaseClass.CurrentStatuCode != 15))
            {//"Rescheduled"
                return true;
            }
            return false;
        }
        public static bool LinkTraincheckSpecialWindowStatuses(int i)
        {
            if ((i == 3 || i == 4 || i == 5 || i == 6) && (BaseClass.CurrentStatuCode != 15))
            {//"Rescheduled"
                return true;
            }
            return false;
        }
        public static bool checkNormalStatusCode()
        {
            if ((BaseClass.CurrentStatuCode == 1
               || BaseClass.CurrentStatuCode == 2 || BaseClass.CurrentStatuCode == 3
               || BaseClass.CurrentStatuCode == 5 || BaseClass.CurrentStatuCode == 12
               || BaseClass.CurrentStatuCode == 18 || BaseClass.CurrentStatuCode == 17
               || BaseClass.CurrentStatuCode == 13 || BaseClass.CurrentStatuCode == 14
               || BaseClass.CurrentStatuCode == 9 || BaseClass.CurrentStatuCode == 20
               || BaseClass.CurrentStatuCode == 10
               ))
            {
                return true;
            }
            return false;
        }






        public static void clearPrevisiosData()
        {
            BaseClass.SpecialWindows.Clear();
            BaseClass.trainStatusNamesList.Clear();
            NormalWindows.Clear();
            BaseClass.taddbDataPacket.Clear();
            BaseClass.windowsDataPacket.Clear();
            BaseClass.languageSequencepk.Clear();
            BaseClass.specialStatusData.Clear();
            BaseClass.trainsCount = 0;
            CdotController.cdotCount = 0;
            CdotController.CdotPacketPrep = false;
            cdotInsertCount = 0;
            IntegrationPacketComtroller.IntrgrationSpecialStatusList.Clear();
        }
        public static void getLangSeq()
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


        public static void prepareDataPacketAsPerLangSeq()
        {
            foreach (int language in BaseClass.languageSequencepk)
            {
                cdotInsertCount = 0;
                BaseClass.CurrentTrainIndex = 0;
                if (language == 6)//English
                {
                    BaseClass.CurrentLang = "eng";


                    if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                    {

                        PfdbMldbDataPacket("eng");
                    }
                    else
                    {
                        getOvdIvdDataPacket("eng");
                    }

                }
                else if (language == 16)//Hindi
                {
                    BaseClass.CurrentLang = "hin";


                    if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                    {
                        PfdbMldbDataPacket("hin");
                    }
                    else
                    {
                        getOvdIvdDataPacket("hin");
                    }

                }
                else//Regional
                {
                    BaseClass.CurrentLang = "reg";


                    if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                    {
                        PfdbMldbDataPacket("reg");
                    }
                    else
                    {
                        getOvdIvdDataPacket("reg");
                    }

                }

            }
        }

        public static byte[] DataPacket(string ip)
        {

            try
            {
                currentIp = ip;
                WindowsPacketFormation(ip);
                clearPrevisiosData();

                BaseClass.trainsCount = BaseClass.OnlineTrainsTaddbDt.Rows.Count;



                getLangSeq();

                if (BaseClass.boardType == "AGDB")
                {
                    if (BaseClass.Getinteroperabilitystatus(ip))
                    {
                        getAgdbDataPacket();
                    }
                    else
                    {
                        getAgdbDataPacket();
                    }
                }
                else
                {
                    if (BaseClass.Getinteroperabilitystatus(ip))
                    {
                        IntegrationPacketComtroller.prepareDataPacketAsPerLangSeq();
                    }
                    else
                    {

                        prepareDataPacketAsPerLangSeq();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            return (BaseClass.taddbDataPacket.ToArray());
        }

        public static void ClearDefaultData()
        {
            BaseClass.SpecialWindows.Clear();
            BaseClass.trainStatusNamesList.Clear();
            NormalWindows.Clear();
            BaseClass.taddbDataPacket.Clear();
            BaseClass.windowsDataPacket.Clear();
            BaseClass.languageSequencepk.Clear();
            BaseClass.specialStatusData.Clear();
        }

        public static void getBoardLanguageSequence()
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



        public static void MessagesDataPacket(string ip)
        {
            try
            {
                currentIp = ip;
                WindowsPacketFormation(ip);

                ClearDefaultData();

                getBoardLanguageSequence();

                foreach (int language in BaseClass.languageSequencepk)
                {
                    if (language == 6)//English
                    {
                        BaseClass.CurrentLang = "eng";
                        BaseClass.CurrentTrainIndex = 0;
                        if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                        {
                            PfdbMldbMessagePacket("eng");
                        }
                        else if (BaseClass.boardType == "OVDIVD")
                        {
                            OvdMessagePacket("eng");
                        }

                    }
                    else if (language == 16)//Hindi
                    {
                        BaseClass.CurrentLang = "hin";
                        BaseClass.CurrentTrainIndex = 0;
                        if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                        {
                            PfdbMldbMessagePacket("hin");
                        }
                        else
                        {
                            OvdMessagePacket("hin");
                        }

                    }
                    else//Regional
                    {
                        BaseClass.CurrentLang = "reg";
                        BaseClass.CurrentTrainIndex = 0;
                        if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                        {
                            PfdbMldbMessagePacket("reg");
                        }
                        else
                        {
                            OvdMessagePacket("reg");
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }
        public static void createMessagesDataBytes(DataRow checkedRow, string lang)
        {

            string HindiMessage = checkedRow["NationalMsg"].ToString();
            string EnglishMessage = checkedRow["Englishmsg"].ToString();
            string RegMessage = checkedRow["RegionalMSg1"].ToString();

            byte[] EnglishMessageBytes = Encoding.BigEndianUnicode.GetBytes(EnglishMessage);
            byte[] HindiMessageBytes = Encoding.BigEndianUnicode.GetBytes(HindiMessage);

            byte[] RegMessageBytes = Encoding.BigEndianUnicode.GetBytes(RegMessage);


            if (lang == "eng")
            {

                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(EnglishMessageBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                BaseClass.currentMessage = new string(EnglishMessage.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
            }
            else if (lang == "hin")
            {
                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(HindiMessageBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                BaseClass.currentMessage = new string(HindiMessage.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
            }
            else
            {
                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(RegMessageBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                BaseClass.currentMessage = new string(RegMessage.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
            }
            BaseClass.windowsDataPacket.AddRange(pfdbMessagesWindows());
            MessageLine++;

        }

        public static int MessageLine = 1;
        public static void CheckNextMessageLineIsDefectiveOrNot()
        {
            bool b = false;
            try
            {
                int currentLine = 0;
                if (BaseClass.defectiveLines.Count > 0)
                {
                    foreach (int i in BaseClass.defectiveLines)
                    {

                        currentLine = MessageLine + 1;

                        if ((currentLine - i) % (BaseClass.noOfLines) == 0 && i != 0)
                        {
                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            if (BaseClass.boardType == "OVDIVD")
                            {
                                BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdcharacterString);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.IvdOvdEmptyData);
                            }
                            else
                            {
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            }
                            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                            BaseClass.windowsDataPacket.AddRange(pfdbMessagesWindows());

                            BaseClass.CurrentTrainIndex++;
                            MessageLine++;
                            b = true;
                        }

                    }

                }
                if (b)
                    CheckNextLineIsDefectiveOrNot();


            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }



        }
        public static void PfdbMldbMessagePacket(string lang)
        {
            MessageLine = 0;

            foreach (DataRow checkedRow in BaseClass.specialMessages.Rows)
            {
                CheckNextMessageLineIsDefectiveOrNot();
                createMessagesDataBytes(checkedRow, lang);
            }
            CheckMLDBMessagesEmptyWindows(BaseClass.specialMessages.Rows.Count);

        }

        public static void OvdMessagePacket(string lang)
        {
            MessageLine = 0;

            foreach (DataRow checkedRow in BaseClass.specialMessages.Rows)
            {
                string HindiMessage = checkedRow["NationalMsg"].ToString();
                string EnglishMessage = checkedRow["Englishmsg"].ToString();
                string RegMessage = checkedRow["RegionalMSg1"].ToString();

                byte[] EnglishMessageBytes = Encoding.BigEndianUnicode.GetBytes(EnglishMessage);
                byte[] HindiMessageBytes = Encoding.BigEndianUnicode.GetBytes(HindiMessage);

                byte[] RegMessageBytes = Encoding.BigEndianUnicode.GetBytes(RegMessage);


                if (lang == "eng")
                {

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdcharacterString);
                    BaseClass.taddbDataPacket.AddRange(EnglishMessageBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    BaseClass.currentMessage = new string(EnglishMessage.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                }
                else if (lang == "hin")
                {
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdcharacterString);
                    BaseClass.taddbDataPacket.AddRange(HindiMessageBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    BaseClass.currentMessage = new string(HindiMessage.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                }
                else
                {
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdcharacterString);
                    BaseClass.taddbDataPacket.AddRange(RegMessageBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    BaseClass.currentMessage = new string(RegMessage.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                }
                BaseClass.windowsDataPacket.AddRange(pfdbMessagesWindows());
                MessageLine++;
            }
            CheckOvdIvdMessagesEmptyWindows(BaseClass.specialMessages.Rows.Count);

        }

        public static void AgdbMessagesDataPacket(List<DataGridViewRow> CheckedMessages)
        {
            foreach (var checkedRow in CheckedMessages)
            {
                string HindiMessage = checkedRow.Cells["Hindi"].Value.ToString();
                string EnglishMessage = checkedRow.Cells["English"].Value.ToString();
                string RegMessage = checkedRow.Cells["RegionalLanguage"].Value.ToString();

                byte[] EnglishMessageBytes = Encoding.BigEndianUnicode.GetBytes(EnglishMessage);
                //byte[] HindiMessageBytes = Encoding.BigEndianUnicode.GetBytes(HindiMessage);

                //byte[] RegMessageBytes = Encoding.BigEndianUnicode.GetBytes(RegMessage);



                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(EnglishMessageBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);



                //NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                //BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                //BaseClass.taddbDataPacket.AddRange(HindiMessageBytes);
                //BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);



                //NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                //BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                //BaseClass.taddbDataPacket.AddRange(RegMessageBytes);
                //BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);



                //BaseClass.windowsDataPacket.AddRange(pfdbMldbMessagesWindows());
                //BaseClass.windowsDataPacket.AddRange(pfdbMldbMessagesWindows());
                BaseClass.windowsDataPacket.AddRange(pfdbMessagesWindows());

                // BaseClass.windowsDataPacket.AddRange(pfdbMldbMessagesWindows());


            }
        }


        public static int cdotInsertCount = 0;


        public static void CheckNextLineIsDefectiveOrNot()
        {
            bool b = false;
            try
            {
                int currentLine = 0;
                if (BaseClass.defectiveLines.Count > 0)
                {
                    foreach (int i in BaseClass.defectiveLines)
                    {

                        currentLine = BaseClass.CurrentTrainIndex + 1;

                        if ((currentLine - i) % (BaseClass.noOfLines) == 0 && i != 0)
                        {
                            BaseClass.CurrentStatuCode = 0;

                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                            BaseClass.windowsDataPacket.AddRange(WindowsPacket());
                            BaseClass.CurrentTrainIndex++;
                            b = true;
                        }

                    }

                }
                if (b)
                    CheckNextLineIsDefectiveOrNot();


            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }



        }

        public static void PfdbMldbDataPacket(string lang)
        {
            if (BaseClass.defectiveLines.Count < BaseClass.noOfLines)
            {

                try
                {


                    foreach (DataRow row in BaseClass.OnlineTrainsTaddbDt.Rows)
                    {

                        string LinktrainNumber = BaseClass.GetLinktrain(row["TrainNo"].ToString().Trim());
                        bool b = false;
                        CheckNextLineIsDefectiveOrNot();
                        if (BaseClass.LinkedTrainsFilter.Contains(row["TrainNo"].ToString().Trim()))
                        {

                            DataTable LinkedTraindt = OnlineTrainsDao.GetTrainByNumber(LinktrainNumber);
                            b = CreateMLDBPFB_Linked_Train_DataBytes(row, lang, LinkedTraindt);
                        }
                        else
                        {
                            b = CreateMLDBPFBTrainDataBytes(row, lang);
                        }

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

                        CheckMLDBEmptyWindows();
                    }
                    else if (BaseClass.boardType == "PFDB")
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
        public static int findEmptyWindows()
        {
            int n = 0;
            int count = BaseClass.CurrentTrainIndex;

            if ((count % BaseClass.noOfLines != 0) && BaseClass.boardType == "MLDB" || BaseClass.boardType == "OVDIVD")
            {
                BaseClass.CurrentStatuCode = 0;
                if (count < BaseClass.noOfLines)
                {
                    n = BaseClass.noOfLines - count;
                }
                else
                {
                    n = BaseClass.noOfLines - count % BaseClass.noOfLines;
                }
            }
            //n=n-CheckCdotDataInEmptyWindows();
            return n;
        }
        public static int CheckCdotDataInEmptyWindows()
        {
            //if one line is only working all are defective lines then
            if (BaseClass.defectiveLines.Count == BaseClass.noOfLines - 1 && BaseClass.boardType == "MLDB")
            {

                CdotController.CheckMldbCdotAlerts();
                return 0;
            }
            //if only one line is data 
            if (BaseClass.OnlineTrainsTaddbDt.Rows.Count < BaseClass.noOfLines - 1)
            {
                CdotController.CheckMldbCdotAlerts();
                return 0;
            }

            if (BaseClass.IsCdotEnabled())
            {
                return 1;
            }
            return 0;
        }

        public static void CheckMLDBEmptyWindows()
        {

            int n = findEmptyWindows();

            if (BaseClass.IsCdotEnabled())
            {
                if (BaseClass.CurrentTrainIndex == 1)
                {
                    n = n - 1;
                    for (int i = 0; i < n; i++)
                    {
                        AddEmptyWindow();

                    }
                    CdotController.CheckMldbCdotAlerts();
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        AddEmptyWindow();

                    }
                }


            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    AddEmptyWindow();

                }
            }



        }







        public static void AddEmptyWindow()
        {
            if (BaseClass.boardType == "OVDIVD")
            {
                AddOvdIvdEmptyWindows();
            }
            else
            {
                AddPFDBMLDBEmptyWindows();
            }

        }

        public static void AddOvdIvdEmptyWindows()
        {
            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
            BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdcharacterString);
            BaseClass.taddbDataPacket.AddRange(BaseClass.IvdOvdEmptyData);
            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
            BaseClass.windowsDataPacket.AddRange(WindowsPacket());
            BaseClass.CurrentTrainIndex++;
            MessageLine++;
        }

        public static void AddPFDBMLDBEmptyWindows()
        {
            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
            BaseClass.taddbDataPacket.AddRange(BaseClass.PfdbMldbEmptyData);
            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
            BaseClass.windowsDataPacket.AddRange(WindowsPacket());
            BaseClass.CurrentTrainIndex++;
            MessageLine++;
        }
        public static bool CreateMLDBPFB_Linked_Train_DataBytes(DataRow row, string lang, DataTable LinkedTraindt)
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

                string LinkedTrainName = "";


                trainStatus = row["StatusName"].ToString().Trim();
                if (trainStatus == "Terminated At")
                {
                    trainStatus = "Terminated";
                }




                string LinkedtrainNumber = LinkedTraindt.Rows[0]["TrainNumber"].ToString().Trim();


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
                    LinkedTrainName = LinkedTraindt.Rows[0]["EnglishName"].ToString().Trim();

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
                    LinkedTrainName = LinkedTraindt.Rows[0]["HindiName"].ToString().Trim();
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
                    LinkedTrainName = LinkedTraindt.Rows[0]["RegionalName"].ToString().Trim();
                    TrainName = row["LRegional1_Lang"].ToString().Trim();
                    if (row["RStation"].ToString().Trim() != null)
                    {
                        City = row["RStation"].ToString().Trim();
                        BaseClass.currentCity = City;
                        trainCityBytes = Encoding.BigEndianUnicode.GetBytes(City);
                    }
                    name = BaseClass.getStatusName("reg", ad, trainStatus);
                }






                if (CheckPlatforms(pf))
                {
                    if (CheckInfoDisplayed(ad))
                    {

                        BaseClass.characterString[0] = BaseClass.getStatusCode(trainStatus, ad);

                        byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                        byte[] trainNameBytes = Encoding.BigEndianUnicode.GetBytes(TrainName);

                        byte[] LinkedtrainNumberBytes = Encoding.BigEndianUnicode.GetBytes(LinkedtrainNumber);
                        byte[] LinkedtrainNameBytes = Encoding.BigEndianUnicode.GetBytes(LinkedTrainName);

                        byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                        byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                        byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                        byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);

                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);//0
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);

                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);//1
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);//2
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(LinkedtrainNumberBytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);//3
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);//4
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(LinkedtrainNameBytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);



                        BaseClass.specialStatusData.Add(trainStatus);
                        BaseClass.currentTrainStatusName = new string(name.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                        BaseClass.currentTrainName = new string(TrainName.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());


                        BaseClass.CurrentStatuCode = BaseClass.getStatusCode(trainStatus, ad);

                        if (checkNormalStatusCode())
                        {
                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);//5
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.ADSeperators);
                            BaseClass.taddbDataPacket.AddRange(adBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                            BaseClass.taddbDataPacket.AddRange(pfBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                        }
                        else if (BaseClass.CurrentStatuCode == 16)//Diverted
                        {

                            trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            if (lang == "eng")
                            {
                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);//5
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);//6
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                            }
                            else
                            {
                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                            }
                        }
                        else if (BaseClass.CurrentStatuCode == 15)//Rescheduled
                        {

                            //      
                            trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.ADSeperators);
                            BaseClass.taddbDataPacket.AddRange(adBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                            BaseClass.taddbDataPacket.AddRange(pfBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                        }
                        else if (BaseClass.CurrentStatuCode == 6 || BaseClass.CurrentStatuCode == 7 || BaseClass.CurrentStatuCode == 11)//Cancelled  ||  //Indefinite Late
                        {

                            trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                        }
                        else if (BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8)//Terminated
                        {
                            if (lang == "eng")
                            {
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Terminated At");
                            }
                            else
                            {
                                name = BaseClass.getStatusName(lang, ad, trainStatus);
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            }

                            if (lang == "eng")
                            {
                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                            }
                            else
                            {
                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);



                            }
                        }
                        else if (BaseClass.CurrentStatuCode == 4)//Has Arrived On
                        {
                            if (lang == "eng")
                            {
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Arrived");
                            }
                            else
                            {
                                name = BaseClass.getStatusName(lang, ad, trainStatus);
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            }
                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            if (lang == "reg")
                            {
                                if (BaseClass.currentTrainStatusName.Length > 7)
                                {
                                    BaseClass.taddbDataPacket.AddRange(PfdbController.ConvertDecimalNumberTOByteArray(340));
                                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                                }
                                else
                                {
                                    BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                                }
                            }
                            else
                            {
                                BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                                BaseClass.taddbDataPacket.AddRange(pfBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                            }


                        }
                        else if (BaseClass.CurrentStatuCode == 19)//Change of Source
                        {


                            if (lang == "eng")
                            {
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Start at");
                            }
                            else
                            {
                                name = BaseClass.getStatusName(lang, ad, trainStatus);
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            }
                            if (lang == "eng")
                            {
                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                            }
                            else
                            {

                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                            }
                        }

                        BaseClass.windowsDataPacket.AddRange(LinkedWindowsPacket());
                        BaseClass.CurrentTrainIndex++;

                        sucess = true;

                    }
                    else
                    {
                        sucess = false;
                    }
                }
                else
                {
                    sucess = false;
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return sucess;
        }
        public static bool CreateMLDBPFBTrainDataBytes(DataRow row, string lang)
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



                if (CheckPlatforms(pf))
                {
                    if (CheckInfoDisplayed(ad))
                    {

                        BaseClass.characterString[0] = BaseClass.getStatusCode(trainStatus, ad);

                        byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                        byte[] trainNameBytes = Encoding.BigEndianUnicode.GetBytes(TrainName);
                        byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                        byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                        byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                        byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);

                        if(lang=="hin"|| lang=="reg")
                        {
                            trainNameBytes = BaseClass.specialConversion(TrainName,false);
                        }

                       




                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);//1
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);

                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);//2
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);//3
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                        BaseClass.specialStatusData.Add(trainStatus);



                        BaseClass.currentTrainStatusName = new string(name.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                        BaseClass.currentTrainName = new string(TrainName.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());


                        BaseClass.CurrentStatuCode = BaseClass.getStatusCode(trainStatus, ad);

                        if (checkNormalStatusCode())
                        {
                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);//4
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.ADSeperators);
                            BaseClass.taddbDataPacket.AddRange(adBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                            BaseClass.taddbDataPacket.AddRange(pfBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                        }
                        else if (BaseClass.CurrentStatuCode == 16)//Diverted
                        {

                            trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            if (lang == "eng")
                            {
                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                            }
                            else
                            {
                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                            }
                        }
                        else if (BaseClass.CurrentStatuCode == 15)//Rescheduled
                        {

                            //      
                            trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.ADSeperators);
                            BaseClass.taddbDataPacket.AddRange(adBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                            BaseClass.taddbDataPacket.AddRange(pfBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                        }
                        else if (BaseClass.CurrentStatuCode == 6 || BaseClass.CurrentStatuCode == 7 || BaseClass.CurrentStatuCode == 11)//Cancelled  ||  //Indefinite Late
                        {

                            trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                        }
                        else if (BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8)//Terminated
                        {
                            if (lang == "eng")
                            {
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Terminated At");
                            }
                            else
                            {
                                name = BaseClass.getStatusName(lang, ad, trainStatus);
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            }

                            if (lang == "eng")
                            {
                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                            }
                            else
                            {
                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);



                            }
                        }
                        else if (BaseClass.CurrentStatuCode == 4)//Has Arrived On
                        {
                            if (lang == "eng")
                            {
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Arrived");
                            }
                            else
                            {
                                name = BaseClass.getStatusName(lang, ad, trainStatus);
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            }
                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            if (lang == "reg")
                            {
                                if (BaseClass.currentTrainStatusName.Length > 7)
                                {
                                    BaseClass.taddbDataPacket.AddRange(PfdbController.ConvertDecimalNumberTOByteArray(340));
                                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                                }
                                else
                                {
                                    BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                                }
                            }
                            else
                            {
                                BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                                BaseClass.taddbDataPacket.AddRange(pfBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                            }


                        }
                        else if (BaseClass.CurrentStatuCode == 19)//Change of Source
                        {


                            if (lang == "eng")
                            {
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Start at");
                            }
                            else
                            {
                                name = BaseClass.getStatusName(lang, ad, trainStatus);
                                trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                            }
                            if (lang == "eng")
                            {
                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                            }
                            else
                            {

                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                                BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                            }
                        }

                        BaseClass.windowsDataPacket.AddRange(WindowsPacket());
                        BaseClass.CurrentTrainIndex++;

                        sucess = true;

                    }
                    else
                    {
                        sucess = false;
                    }
                }
                else
                {
                    sucess = false;
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return sucess;
        }
        public static void CreateOvdIvdTrainDataBytes(DataRow row, string lang)
        {
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
                    if (TrainName == "")
                    {
                        TrainName = "  ";
                    }
                    if (row["RStation"].ToString().Trim() != null)
                    {
                        City = row["RStation"].ToString().Trim();
                        BaseClass.currentCity = City;
                        trainCityBytes = Encoding.BigEndianUnicode.GetBytes(City);
                    }
                    name = BaseClass.getStatusName("reg", ad, trainStatus);
                }

                BaseClass.CurrentStatuCode = BaseClass.getStatusCode(trainStatus, ad);
                if (BaseClass.CurrentStatuCode == 20)
                    BaseClass.CurrentStatuCode = 10;

                BaseClass.characterString[0] = (byte)BaseClass.CurrentStatuCode;
                if (CheckPlatforms(pf))
                {

                    byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);

                    //byte[] trainEngNameBytes = Encoding.BigEndianUnicode.GetBytes(engTrainName);
                    byte[] trainNameBytes = Encoding.BigEndianUnicode.GetBytes(TrainName);
                    byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                    byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                    byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                    byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);
                    if (!checkNormalStatusCode())
                    {
                        BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);
                        if (City != "")
                        {
                            byte[] cityBytes = Encoding.BigEndianUnicode.GetBytes(City);
                            BaseClass.taddbDataPacket.AddRange(cityBytes);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);
                        }
                    }
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);
                    if (BaseClass.CurrentStatuCode != 15)
                    {
                        BaseClass.taddbDataPacket.AddRange(adBytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);
                    }
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public static void getOvdIvdDataPacket(string lang)
        {

            CheckOvdIvdEmptyWindows();

            foreach (DataRow row in BaseClass.OnlineTrainsTaddbDt.Rows)
            {
                CreateOvdIvdTrainDataBytes(row, lang);


            }
        }


        public static byte[] pfdbMessagesWindows()
        {

            List<byte> AllWindows = new List<byte>();
            AllWindows.Clear();

            WindowsPacketFormation(currentIp);
            byte[] taddbWindows = new byte[14];



            byte[] columns = messagesWindowsBytes();

            taddbWindows[0] = columns[0];
            taddbWindows[1] = columns[1];
            taddbWindows[2] = columns[2];
            taddbWindows[3] = columns[3];
            taddbWindows[4] = columns[4];
            taddbWindows[5] = columns[5];
            taddbWindows[6] = columns[6];
            taddbWindows[7] = columns[7];
            taddbWindows[8] = ChangeReverseAndSpeed();
            taddbWindows[9] = changeMessageScrolling();
            taddbWindows[10] = changeMessageLetterGap();
            taddbWindows[11] = changeMessageDelayTime();

            AllWindows.AddRange(taddbWindows);


            return AllWindows.ToArray();
        }
        public static byte[] messagesWindowsBytes()
        {



            if (MessageLine >= BaseClass.noOfLines)
            {

                MessageLine = MessageLine % BaseClass.noOfLines;
            }

            byte[] taddbWindows = new byte[8];

            taddbWindows[0] = 00;
            taddbWindows[1] = 01;
            taddbWindows[2] = 01;
            taddbWindows[3] = 80;


            if (BaseClass.boardType == "MLDB" || BaseClass.boardType == "OVDIVD")
            {
                byte[] b1 = PfdbController.ConvertDecimalNumberTOByteArray((BaseClass.noOfLines - MessageLine) * 16);
                byte[] b2 = PfdbController.ConvertDecimalNumberTOByteArray((BaseClass.noOfLines - MessageLine) * 16 - 15);

                taddbWindows[4] = b1[0];
                taddbWindows[5] = b1[1];
                taddbWindows[6] = b2[0];
                taddbWindows[7] = b2[1];
            }
            else if (BaseClass.boardType == "PFDB")
            {
                taddbWindows[4] = 00;
                taddbWindows[5] = 16;
                taddbWindows[6] = 00;
                taddbWindows[7] = 01;

            }

            return taddbWindows;
        }

        public static byte[] ovdIvdWindows()
        {
            try
            {


                List<byte> AllWindows = new List<byte>();
                AllWindows.Clear();


                WindowsPacketFormation(currentIp);


                byte[] taddbWindows = new byte[14];

                taddbWindows[0] = 00;
                taddbWindows[1] = 01;
                taddbWindows[2] = 01;
                taddbWindows[3] = 176;

                taddbWindows[4] = 00;
                taddbWindows[5] = 00;
                taddbWindows[6] = 00;
                taddbWindows[7] = 00;

                taddbWindows[8] = 00;
                taddbWindows[9] = 00;
                taddbWindows[10] = 00;
                taddbWindows[11] = changeDelayTime(1);

                AllWindows.AddRange(taddbWindows);

                return AllWindows.ToArray();
            }


            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return null;
            }


        }
        public static void CheckOvdIvdMessagesEmptyWindows(int count)
        {
            int n = 0;
            if ((count % BaseClass.noOfLines != 0) && BaseClass.boardType == "MLDB" || BaseClass.boardType == "OVDIVD")
            {

                BaseClass.CurrentStatuCode = 0;
                if (count < BaseClass.noOfLines)
                {
                    n = BaseClass.noOfLines - count;
                }
                else
                {
                    n = BaseClass.noOfLines - count % BaseClass.noOfLines;
                }
                for (int i = 0; i < n; i++)
                {

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdcharacterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.IvdOvdEmptyData);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    BaseClass.windowsDataPacket.AddRange(pfdbMessagesWindows());

                    BaseClass.CurrentTrainIndex++;
                    MessageLine++;

                }
            }

        }




        public static void CheckMLDBMessagesEmptyWindows(int count)
        {
            int n = 0;
            if ((count % BaseClass.noOfLines != 0) && BaseClass.boardType == "MLDB" || BaseClass.boardType == "OVDIVD")
            {

                BaseClass.CurrentStatuCode = 0;
                if (count < BaseClass.noOfLines)
                {
                    n = BaseClass.noOfLines - count;
                }
                else
                {
                    n = BaseClass.noOfLines - count % BaseClass.noOfLines;
                }
                for (int i = 0; i < n; i++)
                {


                    if (BaseClass.boardType == "OVDIVD")
                    {
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdcharacterString);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.IvdOvdEmptyData);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                        BaseClass.windowsDataPacket.AddRange(pfdbMessagesWindows());
                    }
                    else
                    {
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                        BaseClass.windowsDataPacket.AddRange(pfdbMessagesWindows());
                    }


                    BaseClass.CurrentTrainIndex++;
                    MessageLine++;

                }
            }

        }

        public static int OvdIvdEmptyWindowsCount()
        {
            int n = 0;
            int count = BaseClass.OnlineTrainsTaddbDt.Rows.Count;
            if ((count % BaseClass.noOfLines != 0) && BaseClass.boardType == "OvdIvd")
            {

                BaseClass.CurrentStatuCode = 0;
                if (count < BaseClass.noOfLines)
                {
                    n = BaseClass.noOfLines - count;
                }
                else
                {
                    n = BaseClass.noOfLines - count % BaseClass.noOfLines;
                }

                if (BaseClass.IsCdotEnabled())
                {

                    CdotController.CheckOvdIvdCdotAlerts();
                    BaseClass.CurrentTrainIndex++;
                    n = n - 1;
                }
            }
            return n;
        }

        public static void CheckOvdIvdEmptyWindows()
        {
            int n = OvdIvdEmptyWindowsCount();
            for (int i = 0; i < n; i++)
            {
                AddOvdIvdDataEmptyWindows();
                BaseClass.CurrentTrainIndex++;
            }
        }
        public static void AddOvdIvdDataEmptyWindows()
        {
            byte[] Empty = Encoding.BigEndianUnicode.GetBytes("   ");

            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
            if (!BaseClass.IsCdotEnabled())
                BaseClass.taddbDataPacket.AddRange(Empty);
            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
            BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);//1
            if (!BaseClass.IsCdotEnabled())
                BaseClass.taddbDataPacket.AddRange(Empty);
            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
            BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);//2
            if (!BaseClass.IsCdotEnabled())
                BaseClass.taddbDataPacket.AddRange(Empty);
            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
            BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);//3
            if (!BaseClass.IsCdotEnabled())
                BaseClass.taddbDataPacket.AddRange(Empty);
            BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
            BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdSeperators);//4                   
            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
        }

        public static bool CheckPlatforms(string pf)
        {
            if (pf == "")
                return true;
            string[] platforms = BaseClass.checkedplatforms.Split(',');
            foreach (string platform in platforms)
            {
                if (platform.Trim() == pf.Trim())
                    return true;
            }

            return false;
        }
        public static bool CheckInfoDisplayed(string AD)
        {
            if (BaseClass.InfoDisplayed == 0)
            {
                return true;
            }

            else if (BaseClass.InfoDisplayed == 1)//Ariival
            {
                if (AD == "A")
                    return true;
            }
            else if (BaseClass.InfoDisplayed == 2)//deprture
            {
                if (AD == "D")
                    return true;
            }


            return false;
        }
        public static void CreateSingleLineAGDBTrainDataBytes(DataRow row)
        {
            byte[] trainCityBytes = null;
            string City = "";
            string exptTime = "";
            string trainStatus = row["StatusName"].ToString().Trim();
            if (trainStatus == "Terminated At")
            {
                trainStatus = "Terminated";
            }


            string trainNumber = row["TrainNo"].ToString().Trim();
            string TrainName = row["Name"].ToString().Trim();




            string ad = row["ArrivingStatus"].ToString().Trim();
            if (ad == "A")
            {
                exptTime = row["LArrivalTime"].ToString().Trim();
            }
            else
            {
                exptTime = row["LDepartureTime"].ToString().Trim();
            }


            string pf = row["PlatformName"].ToString().Trim();
            if (pf == "--")
            {
                pf = "";
            }
            if (row["City"].ToString().Trim() != null)
            {
                City = row["City"].ToString().Trim();
                BaseClass.currentCity = City;
                trainCityBytes = Encoding.BigEndianUnicode.GetBytes(City);
            }




            if (CheckPlatforms(pf))
            {

                byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                //byte[] trainEngNameBytes = Encoding.BigEndianUnicode.GetBytes(engTrainName);
                byte[] trainNameBytes = Encoding.BigEndianUnicode.GetBytes(TrainName);
                byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);


                //    string name = BaseClass.getStatusName("eng", ad, trainStatus);
                BaseClass.currentTrainStatusName = trainStatus;
                BaseClass.currentTrainName = TrainName;

                BaseClass.CurrentStatuCode = BaseClass.getStatusCode(trainStatus, ad);

                BaseClass.characterString[0] = BaseClass.getStatusCode(trainStatus, ad);

                if (checkNormalStatusCode())
                {
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.SingleLineAgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.SingleLineAgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);


                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (BaseClass.CurrentStatuCode == 11 || BaseClass.CurrentStatuCode == 6 || BaseClass.CurrentStatuCode == 7)
                {
                    //cancelled  indefiniteLate

                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (BaseClass.CurrentStatuCode == 4)
                {
                    //"Has Arrived On"
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Arrived");

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.SingleLineAgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                }
                else if (BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {
                    //"Terminated"   Diverted  "Change of Source"

                    if (trainStatus != "Change of Source")
                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus + " At");
                    else
                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("start" + " At");

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);



                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                }
                else if (BaseClass.CurrentStatuCode == 15)//"Rescheduled"
                {
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.SingleLineAgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.SingleLineAgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);


                }



                if (BaseClass.CurrentStatuCode == 6 || BaseClass.CurrentStatuCode == 11 || BaseClass.CurrentStatuCode == 7 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {

                    //"Cancelled"  "Indefinite Late" "Terminated" "Diverted" "Change of Source"
                    coachExisted = false;
                }
                else
                {
                    coachExisted = CheckSingleLineCoachPositions(trainNumber);
                }
                if (BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {
                    //Terminated  Diverted  Change of Source"
                    BaseClass.windowsDataPacket.AddRange(SingleLineAgdbWindowsPacket(5));
                }
                else if (coachExisted)
                {
                    if (BaseClass.CurrentStatuCode == 15)//"Rescheduled"
                        BaseClass.windowsDataPacket.AddRange(SingleLineAgdbWindowsPacket(9));
                    else
                        BaseClass.windowsDataPacket.AddRange(SingleLineAgdbWindowsPacket(8));
                }
                else
                {
                    if (BaseClass.CurrentStatuCode == 15)//"Rescheduled"
                        BaseClass.windowsDataPacket.AddRange(SingleLineAgdbWindowsPacket(5));
                    else
                        BaseClass.windowsDataPacket.AddRange(SingleLineAgdbWindowsPacket(4));
                }
            }
        }
        public static void CreateAGDBTrainDataBytes(DataRow row)
        {
            byte[] trainCityBytes = null;
            string City = "";
            string exptTime = "";
            string trainStatus = row["StatusName"].ToString().Trim();
            if (trainStatus == "Terminated At")
            {
                trainStatus = "Terminated";
            }


            string trainNumber = row["TrainNo"].ToString().Trim();
            string TrainName = row["Name"].ToString().Trim();




            string ad = row["ArrivingStatus"].ToString().Trim();
            if (ad == "A")
            {
                exptTime = row["LArrivalTime"].ToString().Trim();
            }
            else
            {
                exptTime = row["LDepartureTime"].ToString().Trim();
            }


            string pf = row["PlatformName"].ToString().Trim();
            if (pf == "--")
            {
                pf = "";
            }
            if (row["City"].ToString().Trim() != null)
            {
                City = row["City"].ToString().Trim();
                BaseClass.currentCity = City;
                trainCityBytes = Encoding.BigEndianUnicode.GetBytes(City);
            }




            if (CheckPlatforms(pf))
            {

                byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                //byte[] trainEngNameBytes = Encoding.BigEndianUnicode.GetBytes(engTrainName);
                byte[] trainNameBytes = Encoding.BigEndianUnicode.GetBytes(TrainName);
                byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);


                //    string name = BaseClass.getStatusName("eng", ad, trainStatus);
                BaseClass.currentTrainStatusName = trainStatus;
                BaseClass.currentTrainName = TrainName;

                BaseClass.CurrentStatuCode = BaseClass.getStatusCode(trainStatus, ad);

                BaseClass.characterString[0] = BaseClass.getStatusCode(trainStatus, ad);

                if (checkNormalStatusCode())
                {
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (BaseClass.CurrentStatuCode == 11 || BaseClass.CurrentStatuCode == 6 || BaseClass.CurrentStatuCode == 7)
                {
                    //cancelled  indefiniteLate

                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);

                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (BaseClass.CurrentStatuCode == 4)
                {
                    //"Has Arrived On"
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Arrived");

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {
                    //"Terminated"   Diverted  "Change of Source"



                    if (trainStatus != "Change of Source")
                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus + " At");
                    else
                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("start" + " At");
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);



                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (BaseClass.CurrentStatuCode == 15)//"Rescheduled"
                {
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }



                if (BaseClass.CurrentStatuCode == 6 || BaseClass.CurrentStatuCode == 11 || BaseClass.CurrentStatuCode == 7 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {

                    //"Cancelled"  "Indefinite Late" "Terminated" "Diverted" "Change of Source"
                    coachExisted = false;
                }
                else
                {
                    coachExisted = CheckCoachPositions(trainNumber);
                }
                if (BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {
                    //Terminated  Diverted  Change of Source"
                    BaseClass.windowsDataPacket.AddRange(AgdbWindowsPacket(4));
                }
                else if (coachExisted)
                {
                    if (BaseClass.CurrentStatuCode == 15)//"Rescheduled"
                        BaseClass.windowsDataPacket.AddRange(AgdbWindowsPacket(10));
                    else
                        BaseClass.windowsDataPacket.AddRange(AgdbWindowsPacket(9));
                }
                else
                {
                    if (BaseClass.CurrentStatuCode == 15)//"Rescheduled"
                        BaseClass.windowsDataPacket.AddRange(AgdbWindowsPacket(4));
                    else
                        BaseClass.windowsDataPacket.AddRange(AgdbWindowsPacket(2));
                }
            }
        }
        public static void Create_Linked_Train_AGDBTrainDataBytes(DataRow row, DataTable LinkedTraindt)
        {
            byte[] trainCityBytes = null;
            string City = "";
            string exptTime = "";
            string trainStatus = row["StatusName"].ToString().Trim();
            if (trainStatus == "Terminated At")
            {
                trainStatus = "Terminated";
            }
            string trainNumber = row["TrainNo"].ToString().Trim();
            string TrainName = row["Name"].ToString().Trim();


            string LinkedTrainName = LinkedTraindt.Rows[0]["EnglishName"].ToString().Trim();
            string LinkedtrainNumber = LinkedTraindt.Rows[0]["TrainNumber"].ToString().Trim();

            string ad = row["ArrivingStatus"].ToString().Trim();
            if (ad == "A")
            {
                exptTime = row["LArrivalTime"].ToString().Trim();
            }
            else
            {
                exptTime = row["LDepartureTime"].ToString().Trim();
            }
            string pf = row["PlatformName"].ToString().Trim();
            if (pf == "--")
            {
                pf = "";
            }
            if (row["City"].ToString().Trim() != null)
            {
                City = row["City"].ToString().Trim();
                BaseClass.currentCity = City;
                trainCityBytes = Encoding.BigEndianUnicode.GetBytes(City);
            }
            if (CheckPlatforms(pf))
            {
                byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                byte[] LinkedtrainNumberBytes = Encoding.BigEndianUnicode.GetBytes(LinkedtrainNumber);
                //byte[] trainEngNameBytes = Encoding.BigEndianUnicode.GetBytes(engTrainName);
                byte[] trainNameBytes = Encoding.BigEndianUnicode.GetBytes(TrainName);
                byte[] LinkedtrainNameBytes = Encoding.BigEndianUnicode.GetBytes(LinkedTrainName);

                //byte[] trainEngNameBytes = Encoding.BigEndianUnicode.GetBytes(engTrainName);


                byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);
                //    string name = BaseClass.getStatusName("eng", ad, trainStatus);
                BaseClass.currentTrainStatusName = trainStatus;
                BaseClass.currentTrainName = TrainName;

                BaseClass.CurrentStatuCode = BaseClass.getStatusCode(trainStatus, ad);

                BaseClass.characterString[0] = BaseClass.getStatusCode(trainStatus, ad);

                if (checkNormalStatusCode())
                {
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//0
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//1
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedtrainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);




                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//2
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//3
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedtrainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);

                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (BaseClass.CurrentStatuCode == 11 || BaseClass.CurrentStatuCode == 6 || BaseClass.CurrentStatuCode == 7)
                {
                    //cancelled  indefiniteLate

                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//1
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedtrainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);

                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedtrainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);

                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (BaseClass.CurrentStatuCode == 4)
                {
                    //"Has Arrived On"
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Arrived");



                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {
                    //"Terminated"   Diverted  "Change of Source"



                    if (trainStatus != "Change of Source")
                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus + " At");
                    else
                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("start" + " At");
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//empty
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//train num
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//diverted at
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//link num
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedtrainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//train num
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);





                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//city
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//link num
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedtrainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//name
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//limk name
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedtrainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//name
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//link name
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedtrainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                }
                else if (BaseClass.CurrentStatuCode == 15)//"Rescheduled"
                {
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//empty
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);


                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//train num
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//linke train num
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedtrainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);




                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//rescheduled
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//empty
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//train num
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//linked train num
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedtrainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//expt ad pf
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);




                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//name
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//link name
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedtrainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//name
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);//link train name
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedtrainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);



                }



                if (BaseClass.CurrentStatuCode == 6 || BaseClass.CurrentStatuCode == 11 || BaseClass.CurrentStatuCode == 7 || BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {

                    //"Cancelled"  "Indefinite Late" "Terminated" "Diverted" "Change of Source"
                    coachExisted = false;
                }
                else
                {
                    coachExisted = LinkedCheckCoachPositions(trainNumber, LinkedtrainNumberBytes);
                }
                if (BaseClass.CurrentStatuCode == 21 || BaseClass.CurrentStatuCode == 8 || BaseClass.CurrentStatuCode == 16 || BaseClass.CurrentStatuCode == 19)
                {
                    //Terminated  Diverted  Change of Source"
                    BaseClass.windowsDataPacket.AddRange(LinkedAgdbWindowsPacket(11));
                }
                else if (coachExisted)
                {
                    if (BaseClass.CurrentStatuCode == 15)//"Rescheduled"
                        BaseClass.windowsDataPacket.AddRange(LinkedAgdbWindowsPacket(20));
                    else
                        BaseClass.windowsDataPacket.AddRange(LinkedAgdbWindowsPacket(12));
                }
                else
                {
                    if (BaseClass.CurrentStatuCode == 15)//"Rescheduled"
                        BaseClass.windowsDataPacket.AddRange(LinkedAgdbWindowsPacket(12));
                    else
                        BaseClass.windowsDataPacket.AddRange(LinkedAgdbWindowsPacket(4));
                }
            }
        }
        public static void getAgdbDataPacket()
        {
            try
            {
                foreach (DataRow row in BaseClass.OnlineTrainsTaddbDt.Rows)
                {
                    string LinktrainNumber = BaseClass.GetLinktrain(row["TrainNo"].ToString().Trim());
                    if (BaseClass.LinkedTrainsFilter.Contains(row["TrainNo"].ToString().Trim()))
                    {

                        DataTable LinkedTraindt = OnlineTrainsDao.GetTrainByNumber(LinktrainNumber);
                        Create_Linked_Train_AGDBTrainDataBytes(row, LinkedTraindt);
                    }
                    else
                    {
                        if (BaseClass.noOfLines > 1)
                        {
                            CreateAGDBTrainDataBytes(row);
                        }
                        else
                        {
                            CreateSingleLineAGDBTrainDataBytes(row);
                        }
                    }



                }
                CdotController.CheckAgdbCdotAlerts();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }


        public static bool checkSingleLineAgdbOrNot()
        {

            string getFormatType = BaseClass.GetFormattype(1);

            return true;
        }









        public static bool coachExisted = false;

        public static bool CheckSingleLineCoachPositions(string trainNumber)
        {
            try
            {
                List<byte[]> Coaches = addSingleLineCoachPositions(trainNumber);
                if (Coaches != null)
                {
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    for (int i = 0; i < Coaches.Count; i++)
                    {
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(Coaches[i]);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
                e.ToString();
            }
        }
        public static bool CheckCoachPositions(string trainNumber)
        {
            try
            {
                List<byte[]> Coaches = addCoachPositions(trainNumber);
                if (Coaches != null)
                {
                    if (BaseClass.CurrentStatuCode != 15)//"Rescheduled"
                    {
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                    }
                    byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(PfdbController.ConvertDecimalNumberTOByteArray(67));
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    for (int i = 0; i < Coaches.Count; i++)
                    {
                        if (i == 2)
                        {
                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                        }
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(Coaches[i]);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
                e.ToString();
            }
        }
        public static bool LinkedCheckCoachPositions(string trainNumber, byte[] LinkedTrainBytes)
        {
            try
            {
                List<byte[]> Coaches = addCoachPositions(trainNumber);
                if (Coaches != null)
                {

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);

                    byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(PfdbController.ConvertDecimalNumberTOByteArray(67));
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(LinkedTrainBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(PfdbController.ConvertDecimalNumberTOByteArray(67));
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    for (int i = 0; i < Coaches.Count; i++)
                    {
                        if (i == 2)
                        {
                            NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                        }
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(Coaches[i]);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
                e.ToString();
            }
        }


        static string FormCoachString(string[] parts)
        {
            // Maximum length of the final string (considering all parts and spaces)
            int maxLength = 50; // Adjust this value as needed                                                              
                                // Calculate the total length of all parts combined
            int totalPartsLength = 0;
            foreach (string part in parts)
            {
                totalPartsLength += part.Length;
            }

            // Calculate the total available space to distribute
            int totalSpaces = maxLength - totalPartsLength;

            // Calculate equal spaces to distribute between parts
            int equalSpaces = totalSpaces / (parts.Length - 1);

            // Remaining spaces if any
            int remainingSpaces = totalSpaces % (parts.Length - 1);

            // Resultant string
            string result = "";

            for (int i = 0; i < parts.Length; i++)
            {
                // Append the current part
                result += parts[i];

                // Append the spaces between parts, except after the last part
                if (i < parts.Length - 1)
                {
                    result += new string(' ', equalSpaces);

                    // Distribute remaining spaces evenly
                    if (remainingSpaces > 0)
                    {
                        result += " ";
                        remainingSpaces--;
                    }
                }
            }

            return result;
        }
        static List<string[]> SplitArray(string[] array, int subArrayLength)
        {
            List<string[]> result = new List<string[]>();
            int arrayLength = array.Length;

            for (int i = 0; i < arrayLength; i += subArrayLength)
            {
                int currentSubArrayLength = Math.Min(subArrayLength, arrayLength - i);
                string[] subArray = new string[currentSubArrayLength];
                Array.Copy(array, i, subArray, 0, currentSubArrayLength);
                result.Add(subArray);
            }

            return result;
        }
        public static List<string> coachList = new List<string>();
        public static List<byte[]> coachBytes = new List<byte[]>();
        public static List<byte> SubcoachBytes = new List<byte>();
        public static List<byte[]> addCoachPositions(string trainNumber)
        {
            coachList.Clear();
            coachBytes.Clear();
            SubcoachBytes.Clear();
            //string[] coachpositions = OnlineTrainsDao.coachPositions(trainNumber).ToArray();
            string[] coachpositions = OnlineTrainsDao.coachPositions(trainNumber)?.ToArray() ?? Array.Empty<string>();

            for (int i = 0; i < coachpositions.Length; i++)
            {
                if (coachpositions[i].Length == 4)
                {
                    // Remove the last letter
                    coachpositions[i] = coachpositions[i].Substring(0, 3);
                }
            }
            int sum = 67;
            int gap = 0;

            coachpositions = coachpositions.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            if (coachpositions.Length > 0)
            {
                string[] coach = coachpositions.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                coachList.AddRange(coach);

                if (coach.Length < 28)
                {
                    for (int i = coach.Length; i < 28; i++)
                    {
                        coachList.Add("  ");
                    }
                }

                for (int i = 0; i < coachList.ToArray().Length; i++)
                {
                    byte[] CoachPositionBytes = Encoding.BigEndianUnicode.GetBytes(coachList.ToArray()[i]);
                    SubcoachBytes.AddRange(CoachPositionBytes);
                    SubcoachBytes.AddRange(BaseClass.Seperators);
                    SubcoachBytes.AddRange(BaseClass.ConvertDecimalNumberTOByteArray(sum = sum + gap));
                    gap = 21;
                    if (i > 0 && (i + 1) % 7 == 0)
                    {
                        coachBytes.Add(SubcoachBytes.ToArray());
                        SubcoachBytes.Clear();
                        sum = 67;
                        gap = 0;
                    }
                }
                if (SubcoachBytes.Count > 0)
                {
                    coachBytes.Add(SubcoachBytes.ToArray());
                    SubcoachBytes.Clear();
                    sum = 0;
                }
                return coachBytes;
            }
            else
            {
                return null;
            }
        }

        public static List<byte[]> addSingleLineCoachPositions(string trainNumber)
        {
            coachList.Clear();
            coachBytes.Clear();
            SubcoachBytes.Clear();
            string[] coachpositions = OnlineTrainsDao.coachPositions(trainNumber).ToArray();

            for (int i = 0; i < coachpositions.Length; i++)
            {
                if (coachpositions[i].Length == 4)
                {
                    // Remove the last letter
                    coachpositions[i] = coachpositions[i].Substring(0, 3);
                }
            }
            int sum = 90;
            int gap = 0;

            coachpositions = coachpositions.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            if (coachpositions.Length > 0)
            {
                string[] coach = coachpositions.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                coachList.AddRange(coach);

                if (coach.Length < 28)
                {
                    for (int i = coach.Length; i < 28; i++)
                    {
                        coachList.Add("  ");
                    }
                }

                for (int i = 0; i < coachList.ToArray().Length; i++)
                {
                    byte[] CoachPositionBytes = Encoding.BigEndianUnicode.GetBytes(coachList.ToArray()[i]);
                    SubcoachBytes.AddRange(CoachPositionBytes);
                    SubcoachBytes.AddRange(BaseClass.Seperators);
                    SubcoachBytes.AddRange(BaseClass.ConvertDecimalNumberTOByteArray(sum = sum + gap));
                    gap = 23;
                    if (i > 0 && (i + 1) % 14 == 0)
                    {
                        coachBytes.Add(SubcoachBytes.ToArray());
                        SubcoachBytes.Clear();
                        sum = 90;
                        gap = 0;
                    }
                }
                if (SubcoachBytes.Count > 0)
                {
                    coachBytes.Add(SubcoachBytes.ToArray());
                    SubcoachBytes.Clear();
                    sum = 0;
                }
                return coachBytes;
            }
            else
            {
                return null;
            }
        }
    }
}
