using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArecaIPIS.Server_Classes
{
    class IvdOvdController
    {



        public static void OVDsendData()
        {

            foreach (string ip in Server.OvdIpAdress)
            {
                BaseClass.defectiveLines = OnlineTrainsDao.getDefectiveLines(ip);
                BaseClass.boardType = "OvdIvd";
                PacketController.DataPacket(ip);
                byte[] finalPacket = IvdOvdController.getIvdOvdFullPacket(Board.OVD, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);
                string a = BaseClass.ByteArrayToString(finalPacket);



                string packet1 = "AA CC 07 04 42 00 28 00 FD 0E 81 02 00 00 00 00 00 10 00 01 02 09 29 05 00 FE 00 00 00 00 00 20 00 11 02 09 29 05 01 23 00 00 00 00 00 30 00 21 02 09 29 05 01 48 00 00 00 00 00 40 00 31 02 09 29 05 01 6D 00 00 00 00 00 50 00 41 02 09 29 05 01 92 00 00 00 00 00 60 00 51 02 09 29 05 01 B7 00 00 00 00 00 10 00 01 02 09 29 05 02 1C 00 00 00 00 00 20 00 11 02 09 29 05 02 41 00 00 00 00 00 30 00 21 02 09 29 05 02 66 00 00 00 00 00 40 00 31 02 09 29 05 02 8B 00 00 00 00 00 50 00 41 02 09 29 05 02 B0 00 00 00 00 00 60 00 51 02 09 29 05 02 D5 00 00 00 00 00 10 00 01 02 09 29 05 03 3C 00 00 00 00 00 20 00 11 02 09 29 05 03 61 00 00 00 00 00 30 00 21 02 09 29 05 03 86 00 00 00 00 00 40 00 31 02 09 29 05 03 AB 00 00 00 00 00 50 00 41 02 09 29 05 03 D0 00 00 00 00 00 60 00 51 02 09 29 05 03 F5 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 08 00 00 00 00 00 31 00 32 00 31 00 38 00 33 E7 00 00 03 00 42 00 50 00 4C 00 20 00 50 00 42 00 48 00 20 00 53 00 46 00 20 00 45 00 58 00 50 E7 00 00 03 00 54 00 65 00 72 00 6D 00 69 00 6E 00 61 00 74 00 65 00 64 00 20 00 41 00 74 E7 00 00 03 00 41 00 44 00 52 00 41 E7 00 00 03 00 31 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 08 00 00 00 00 00 31 00 32 00 31 00 38 00 33 E7 00 00 03 09 2D 09 4B 09 2A 09 3E 09 32 00 20 09 2A 09 4D 09 30 09 24 09 2A 09 17 09 23 00 20 09 0F 09 15 09 4D 09 38 E7 00 00 03 09 06 09 26 09 4D 09 30 09 3E E7 00 00 03 09 24 09 15 00 20 09 1C 09 3E 09 2F 09 47 09 17 09 40 E7 00 00 03 00 31 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 00 00 00 00 00 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 00 20 E7 00 00 03 FF FF 08 00 00 00 00 00 31 00 32 00 31 00 38 00 33 E7 00 00 03 00 20 E7 00 00 03 09 06 09 26 09 4D 09 30 09 3E E7 00 00 03 0A B8 0A C1 0A A7 0A C0 00 20 0A 9C 0A B6 0A C7 E7 00 00 03 00 31 E7 00 00 03 FF FF 03 56 BC 04";

                byte[] byteArray = packet1.Split(' ').Select(hex => Convert.ToByte(hex, 16)).ToArray();

                if (BaseClass.boardWorkingstatus && finalPacket.Length > 40)
                {
                    Server.SendMessageToClient(ip, finalPacket);
                    //Server.SendMessageToClient(ip, byteArray);
                }

            }
        }




        public static void IVDsendData()
        {
            foreach (string ip in Server.IvdIpAdress)
            {
                BaseClass.defectiveLines = OnlineTrainsDao.getDefectiveLines(ip);
                BaseClass.boardType = "OvdIvd";
                PacketController.DataPacket(ip);
                byte[] finalPacket = IvdOvdController.getIvdOvdFullPacket(Board.OVD, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);
                if (BaseClass.boardWorkingstatus && finalPacket.Length > 40)
                    Server.SendMessageToClient(ip, finalPacket);
            }
        }


        public static List<byte> finalDataPacket = new List<byte>();
        public static byte[] getIvdOvdFullPacket(int packetIdentifier, string SourceipAdress, string destinationIpAdress, int packetSerialNumer, int packetType)
        {
            try
            {


                finalDataPacket.Clear();
                finalDataPacket.AddRange(BaseClass.stratingBytes);//statrting bytes
                byte[] b1 = PacketController.firstPacketByte(packetIdentifier, SourceipAdress, destinationIpAdress, packetSerialNumer, packetType);
                byte[] b3 = BaseClass.taddbDataPacket.ToArray();
                finalDataPacket.AddRange(b1);
                PrepareOVDIVDWindowsDataPacket();
                finalDataPacket.AddRange(BaseClass.windowsDataPacket.ToArray());
                finalDataPacket.AddRange(PacketController.endingBytes);
                finalDataPacket.AddRange(b3);
                for (int i = 0; i < (PacketController.NormalWindows.Count); i++)
                {
                    int decimalValueOfCharctersting = PacketController.NormalWindows.Count * 14 + (2) + PacketController.NormalWindows[i];
                    byte[] characterStringIndices = BaseClass.ConvertDecimalNumberTOByteArray(decimalValueOfCharctersting);
                    finalDataPacket[5 + 12 + (i + 1) * 13 + i] = characterStringIndices[0];
                    finalDataPacket[5 + 12 + (i + 1) * 14] = characterStringIndices[1];
                }
                finalDataPacket.AddRange(PacketController.finalTaddbETX);
                finalDataPacket.AddRange(PacketController.stratingBytes);
                byte[] packetlengthbytes = BaseClass.ConvertDecimalNumberTOByteArray(finalDataPacket.Count - (6 + 5 + 1 + 6));
                finalDataPacket[9] = packetlengthbytes[0];
                finalDataPacket[10] = packetlengthbytes[1];
                byte[] crc = Server.CheckSum(finalDataPacket.ToArray());
                finalDataPacket[finalDataPacket.Count - 2 - 6 - 1] = crc[0];
                finalDataPacket[finalDataPacket.Count - 1 - 6 - 1] = crc[1];
                string a = BaseClass.ByteArrayToString(finalDataPacket.ToArray());
                return finalDataPacket.ToArray();
            }
            catch (Exception ex)
            {
                return null;
                Server.LogError(ex.Message);
            }

        }

        public static void PrepareOVDIVDWindowsDataPacket()
        {
            try
            {


                BaseClass.CurrentStatuCode = -1;
                BaseClass.windowsDataPacket.Clear();

                int window = BaseClass.OnlineTrainsTaddbDt.Rows.Count / BaseClass.noOfLines;

                if (BaseClass.OnlineTrainsTaddbDt.Rows.Count % BaseClass.noOfLines != 0)
                {
                    window = window + 1;
                }

                int noOfLines = window * BaseClass.noOfLines * BaseClass.languageSequencepk.Count;


                for (int i = 0; i < noOfLines; i++)
                {
                    BaseClass.windowsDataPacket.AddRange(PacketController.ovdIvdWindows());
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
    }
}
