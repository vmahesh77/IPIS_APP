using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArecaIPIS.Server_Classes
{
    class SlogansController
    {
        public static int boardIdentifier = 0;

        public static String getBoard()
        {
            string ipadress = SlogansController.SlogansIp;

            String board = "";

            if (Server.TryGetLastOctet(ipadress, out int lastOctet))
            {
                if (lastOctet >= 40 && lastOctet <= 70)
                {
                    board = "OVDIVD";
                    boardIdentifier = Board.OVD;

                }
                else if (lastOctet >= 71 && lastOctet <= 100)
                {
                    board = "OVDIVD";
                    boardIdentifier = Board.IVD;
                }
                else if (lastOctet >= 101 && lastOctet <= 130)
                {
                    board = "MLDB";
                    boardIdentifier = Board.MLDB;
                }
                else if (lastOctet >= 131 && lastOctet <= 160)
                {
                    board = "AGDB";
                    boardIdentifier = Board.AGDB;
                }
                else if (lastOctet >= 161 && lastOctet <= 190)
                {
                    board = "PFDB";
                    boardIdentifier = Board.PFDB;
                }

            }
            return board;

        }

        public static List<DataGridViewRow> CheckedSlogans = new List<DataGridViewRow>();
        public static string SlogansIp = "";

        public static void ClearDefaultData()
        {
            BaseClass.SpecialWindows.Clear();
            BaseClass.trainStatusNamesList.Clear();
            PacketController.NormalWindows.Clear();
            BaseClass.taddbDataPacket.Clear();
            BaseClass.windowsDataPacket.Clear();
            BaseClass.languageSequencepk.Clear();
            BaseClass.specialStatusData.Clear();
        }
        public static void SlogansDataPacket()
        {
            try
            {

                PacketController.WindowsPacketFormation(SlogansIp);

                ClearDefaultData();

                if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                {
                    PfdbMldbSloganPacket(SlogansController.CheckedSlogans);
                }
                else if (BaseClass.boardType == "OVDIVD")
                {
                    OvdIvdSloganPacket(SlogansController.CheckedSlogans);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static void OvdIvdSloganPacket(List<DataGridViewRow> CheckedSlogans)
        {
            PacketController.MessageLine = 0;


            foreach (var checkedRow in CheckedSlogans)
            {
                string SloganMessage = checkedRow.Cells["Message"].Value.ToString().Trim();
                string Language = checkedRow.Cells["dgvSloganLanguage"].Value.ToString().Trim();
                if (Language == "16")
                    BaseClass.CurrentLang = "hin";
                else if (Language == "6")
                    BaseClass.CurrentLang = "eng";
                else
                    BaseClass.CurrentLang = "reg";


                byte[] SloganMessageBytes = Encoding.BigEndianUnicode.GetBytes(SloganMessage);



                PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.OvdIvdcharacterString);
                BaseClass.taddbDataPacket.AddRange(SloganMessageBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                BaseClass.currentMessage = new string(SloganMessage.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

                BaseClass.windowsDataPacket.AddRange(PacketController.pfdbMessagesWindows());
                PacketController.MessageLine++;


            }
            PacketController.CheckOvdIvdMessagesEmptyWindows(SlogansController.CheckedSlogans.Count);

        }

        public static void SlogansCheckNextLineIsDefectiveOrNot()
        {
            bool b = false;
            try
            {
                int currentLine = 0;
                if (BaseClass.defectiveLines.Count > 0)
                {
                    foreach (int i in BaseClass.defectiveLines)
                    {

                        currentLine = PacketController.MessageLine + 1;

                        if ((currentLine - i) % (BaseClass.noOfLines) == 0 && i != 0)
                        {

                            BaseClass.CurrentStatuCode = 0;
                            PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                            BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                            BaseClass.windowsDataPacket.AddRange(PacketController.pfdbMessagesWindows());
                            PacketController.MessageLine++;
                            b = true;
                        }
                    }
                }
                if (b)
                    SlogansCheckNextLineIsDefectiveOrNot();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public static void createSloganPacket(DataGridViewRow checkedRow)
        {
            string SloganMessage = checkedRow.Cells["Message"].Value.ToString().Trim();
            string Language = checkedRow.Cells["dgvSloganLanguage"].Value.ToString().Trim();
            if (Language == "16")
                BaseClass.CurrentLang = "hin";
            else if (Language == "6")
                BaseClass.CurrentLang = "eng";
            else
                BaseClass.CurrentLang = "rreg";


            byte[] SloganMessageBytes = Encoding.BigEndianUnicode.GetBytes(SloganMessage);


            PacketController.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
            BaseClass.taddbDataPacket.AddRange(SloganMessageBytes);
            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


            BaseClass.windowsDataPacket.AddRange(PacketController.pfdbMessagesWindows());
            PacketController.MessageLine++;
        }

        public static void PfdbMldbSloganPacket(List<DataGridViewRow> CheckedSlogans)
        {
            PacketController.MessageLine = 0;
            foreach (var checkedRow in CheckedSlogans)
            {
                SlogansCheckNextLineIsDefectiveOrNot();
                createSloganPacket(checkedRow);
            }
            PacketController.CheckMLDBMessagesEmptyWindows(PacketController.MessageLine);
        }
    }
}
