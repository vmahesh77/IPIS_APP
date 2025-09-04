using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;

namespace ArecaIPIS.Server_Classes
{
    class MessageController
    {
        public static List<byte> finalDataPacket = new List<byte>();
        public static byte[] getMessagesFullPacket(int packetIdentifier, string SourceipAdress, string destinationIpAdress, int packetSerialNumer, int packetType)
        {
            try
            {


                finalDataPacket.Clear();

                finalDataPacket.AddRange(BaseClass.stratingBytes);//statrting bytes
                byte[] b1 = PacketController.firstPacketByte(packetIdentifier, SourceipAdress, destinationIpAdress, packetSerialNumer, packetType);

                byte[] b3 = BaseClass.taddbDataPacket.ToArray();


                finalDataPacket.AddRange(b1);
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
                Server.LogError(ex.Message);
                return null;
            }


        }



    }
}
