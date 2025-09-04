using System;
using System.Collections.Generic;

namespace ArecaIPIS.Classes
{
    public class ByteFormation
    {

        public static int AA = 170;
        public static int CC = 204;
        public static int STX = 2; //start of Data
        public static int ETX = 3; //start of Data
        public static int EOT = 4; //start of Data
        public static byte[] GapCode = new byte[] { 0xE7, 0x00 };
        public static byte[] GetTerminationBytes()
        {
            byte[] terminationBytes = { (byte)0xFF, (byte)0xFF };
            return terminationBytes;
        }

        //public static byte[] CommonBytes(string boardIp, int packetidentifier)
        //{
        //    string ipaddress = Server.ipAdress;
        //    string[] SystemIPArr = ipaddress.Split('.');
        //    string[] BoardIPAdress = boardIp.Split('.');

        //    //int thirdOctet = GetOctetbyIp(ipaddress, 3);
        //    //int FourthOctet = GetOctetbyIp(ipaddress, 4);

        //    Byte[] sendbyte = new Byte[10];   //creating an array
        //    sendbyte[0] = 170;    //AA
        //    sendbyte[1] = 204;    //CC
        //                          //  Array.Resize(ref sendbyte, sendbyte.Length + 3);
        //    sendbyte[2] = (byte)packetidentifier;  //startPacket
        //    sendbyte[3] = 0;   //length
        //    sendbyte[4] = 0;     //length
        //                         // Array.Resize(ref sendbyte, sendbyte.Length + 9);
        //    sendbyte[5] = Convert.ToByte(BoardIPAdress[2]);    //3rd octet of destination
        //    sendbyte[6] = Convert.ToByte(BoardIPAdress[3]);     //4th octet of destination
        //    sendbyte[7] = Convert.ToByte(SystemIPArr[2]);          //3rd octet of source
        //    sendbyte[8] = Convert.ToByte(SystemIPArr[3]);          //4th octet of  source
        //    sendbyte[9] = BaseClass.GetSerialNumber();    //serialNumber



        //    return sendbyte;
        //}

        public static byte[] CommonBytes(string boardIp, int packetidentifier)
        {
            try
            {
                string ipaddress = Server.ipAdress;
                if (ipaddress == null|| ipaddress=="")
                {
                    return null;
                }
                string[] SystemIPArr = ipaddress.Split('.');
                string[] BoardIPAdress = boardIp.Split('.');

                Byte[] sendbyte = new Byte[10];   // Creating an array
                sendbyte[0] = 170;    // AA
                sendbyte[1] = 204;    // CC
                sendbyte[2] = (byte)packetidentifier;  // StartPacket
                sendbyte[3] = 0;   // Length
                sendbyte[4] = 0;   // Length
                sendbyte[5] = Convert.ToByte(BoardIPAdress[2]);    // 3rd octet of destination
                sendbyte[6] = Convert.ToByte(BoardIPAdress[3]);    // 4th octet of destination
                sendbyte[7] = Convert.ToByte(SystemIPArr[2]);      // 3rd octet of source
                sendbyte[8] = Convert.ToByte(SystemIPArr[3]);      // 4th octet of source
                sendbyte[9] = BaseClass.GetSerialNumber();         // SerialNumber

                return sendbyte;
            }
            catch (FormatException ex)
            {
                Server.LogError(ex.ToString());

            }
            catch (IndexOutOfRangeException ex)
            {
                Server.LogError(ex.ToString());

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


            return new byte[0];
        }


        public static byte[] ConvertListToBytes(List<byte[]> byteArrayList)
        {
            // Calculate the total length of the resulting byte array
            int totalLength = 0;
            foreach (byte[] byteArray in byteArrayList)
            {
                totalLength += byteArray.Length;
            }

            // Create a new byte array to hold the concatenated result
            byte[] resultBytes = new byte[totalLength];

            // Copy each byte array from the list into the new array
            int offset = 0;
            foreach (byte[] byteArray in byteArrayList)
            {
                Array.Copy(byteArray, 0, resultBytes, offset, byteArray.Length);
                offset += byteArray.Length;
            }

            return resultBytes;
        }
        public static byte[] RemoveFirstAndLast6(byte[] inputArray)
        {
            // Ensure the array has at least 13 elements
            if (inputArray == null || inputArray.Length <= 12)
            {
                return inputArray;
            }

            // Calculate the length of the new array
            int newLength = inputArray.Length - 12;

            // Create the new array
            byte[] resultArray = new byte[newLength];

            // Copy the middle portion of the original array to the new array
            Array.Copy(inputArray, 6, resultArray, 0, newLength);

            return resultArray;
        }
        // Method to clear the byte array
        public static bool validateLinkCheck(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if (
                serverReceivedBytes[0] == 170 &&
                serverReceivedBytes[1] == 204 &&
                //serverReceivedBytes[2] == 170 &&
                //serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[7] &&
                serverReceivedBytes[6] == LinkCheckPacket[8] &&
                serverReceivedBytes[7] == LinkCheckPacket[5] &&
                serverReceivedBytes[8] == LinkCheckPacket[6] &&
                 //serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 192 &&
                serverReceivedBytes[11] == 2
                  // serverReceivedBytes[serverReceivedBytes.Length - 2] == 4
                  )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool validateTruecolorLinkCheck(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if (
                serverReceivedBytes[0] == 170 &&
                serverReceivedBytes[1] == 204 &&
                //serverReceivedBytes[2] == 170 &&
                //serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[5] &&
                serverReceivedBytes[6] == LinkCheckPacket[6] &&
                serverReceivedBytes[7] == LinkCheckPacket[7] &&
                serverReceivedBytes[8] == LinkCheckPacket[8] &&
                  serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 192 &&
                serverReceivedBytes[11] == 2
                  // serverReceivedBytes[serverReceivedBytes.Length - 2] == 4
                  )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool validateGetConfiguration(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if (
                serverReceivedBytes[0] == 170 &&
                serverReceivedBytes[1] == 204 &&
                //serverReceivedBytes[2] == 170 &&
                //serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[7] &&
                serverReceivedBytes[6] == LinkCheckPacket[8] &&
                serverReceivedBytes[7] == LinkCheckPacket[5] &&
                serverReceivedBytes[8] == LinkCheckPacket[6] &&
                  serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 197
                //serverReceivedBytes[11] == 2 &&
                // serverReceivedBytes[serverReceivedBytes.Length - 2] == 4
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool validatetruecolorGetConfiguration(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if (
                serverReceivedBytes[0] == 170 &&
                serverReceivedBytes[1] == 204 &&
                //serverReceivedBytes[2] == 170 &&
                //serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[5] &&
                serverReceivedBytes[6] == LinkCheckPacket[6] &&
                serverReceivedBytes[7] == LinkCheckPacket[7] &&
                serverReceivedBytes[8] == LinkCheckPacket[8] &&
                  serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 197
                //serverReceivedBytes[11] == 2 &&
                // serverReceivedBytes[serverReceivedBytes.Length - 2] == 4
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public static bool validatePdcGetConfiguration(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if (
                serverReceivedBytes[0] == 170 &&
                serverReceivedBytes[1] == 204 &&
                //serverReceivedBytes[2] == 170 &&
                serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[7] &&
                serverReceivedBytes[6] == LinkCheckPacket[8] &&
                serverReceivedBytes[7] == LinkCheckPacket[5] &&
                serverReceivedBytes[8] == LinkCheckPacket[6] &&
                  serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 197
                //serverReceivedBytes[11] == 2 &&
                //  serverReceivedBytes[serverReceivedBytes.Length - 2] == 4
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool validateDeleteData(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if (
                serverReceivedBytes[0] == 170 &&
                serverReceivedBytes[1] == 204 &&
                //serverReceivedBytes[2] == 170 &&
                serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[7] &&
                serverReceivedBytes[6] == LinkCheckPacket[8] &&
                serverReceivedBytes[7] == LinkCheckPacket[5] &&
                serverReceivedBytes[8] == LinkCheckPacket[6] &&
                  serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 201)

            //serverReceivedBytes[serverReceivedBytes.Length - 2] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool validatetruecolorAgdbDeleteData(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if (
                serverReceivedBytes[0] == 170 &&
                serverReceivedBytes[1] == 204 &&
                //serverReceivedBytes[2] == 170 &&
                serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[5] &&
                serverReceivedBytes[6] == LinkCheckPacket[6] &&
                serverReceivedBytes[7] == LinkCheckPacket[7] &&
                serverReceivedBytes[8] == LinkCheckPacket[8] &&
                  serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 201)

            //serverReceivedBytes[serverReceivedBytes.Length - 2] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool validateSetConfiguration(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if (
                serverReceivedBytes[0] == 170 &&
                serverReceivedBytes[1] == 204 &&
                //serverReceivedBytes[2] == 170 &&
                serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[7] &&
                serverReceivedBytes[6] == LinkCheckPacket[8] &&
                serverReceivedBytes[7] == LinkCheckPacket[5] &&
                serverReceivedBytes[8] == LinkCheckPacket[6] &&
                 // serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 196)
            //serverReceivedBytes[11] == 2 &&
            //serverReceivedBytes[serverReceivedBytes.Length - 2] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool validateTruecolorAgdbSetConfiguration(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if (
                serverReceivedBytes[0] == 170 &&
                serverReceivedBytes[1] == 204 &&
                //serverReceivedBytes[2] == 170 &&
                serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[5] &&
                serverReceivedBytes[6] == LinkCheckPacket[6] &&
                serverReceivedBytes[7] == LinkCheckPacket[7] &&
                serverReceivedBytes[8] == LinkCheckPacket[8] &&
                  serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 196)
            //serverReceivedBytes[11] == 2 &&
            //serverReceivedBytes[serverReceivedBytes.Length - 2] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static byte[] StartCommand(string boardIp, int packet)
        {
            try
            {


                Byte[] sendbyte = CommonBytes(boardIp, packet);
                if (sendbyte == null)
                {
                    return null;
                }
                sendbyte[4] = 8;
                Array.Resize(ref sendbyte, sendbyte.Length + 4);

                sendbyte[10] = (byte)Board.Start; ;   //packet Type//start command

                sendbyte[13] = (byte)EOT;   //packet Type

                Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);
                finalPacket[17] = value[0];   //crc msb
                finalPacket[18] = value[1];    //crc lsb

                Server.SerialNumber++;
                if (Server.SerialNumber > 255)
                {
                    Server.SerialNumber = 0;
                }

                return finalPacket;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return null;
        }

        public static byte[] BStopCommand(string boardIp, int packet)
        {
            Byte[] finalPacket = null;
            try
            {


                Byte[] sendbyte = CommonBytes(boardIp, packet);
                if (sendbyte == null)
                {
                    return null;
                }
                sendbyte[4] = 8;
                sendbyte[6] = 255;

                Array.Resize(ref sendbyte, sendbyte.Length + 4);

                sendbyte[10] = (byte)Board.Stop;   //packet Type//start command

                sendbyte[13] = (byte)EOT;   //packet Type

                finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);
                finalPacket[17] = value[0];   //crc msb
                finalPacket[18] = value[1];    //crc lsb


                return finalPacket;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return finalPacket;
        }

        public static byte[] BStartCommand(string boardIp, int packet)
        {
            Byte[] finalPacket = null;
            try
            {


                Byte[] sendbyte = CommonBytes(boardIp, packet);
                if (sendbyte == null)
                {
                    return null;
                }
                sendbyte[4] = 8;
                sendbyte[6] = 255;

                Array.Resize(ref sendbyte, sendbyte.Length + 4);

                sendbyte[10] = (byte)Board.Start;   //packet Type//start command

                sendbyte[13] = (byte)EOT;   //packet Type

                finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);
                finalPacket[17] = value[0];   //crc msb
                finalPacket[18] = value[1];    //crc lsb


                return finalPacket;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return finalPacket;
        }


        public static byte[] StopCommand(string boardIp, int packet)
        {
            Byte[] finalPacket = null;
            try
            {


                Byte[] sendbyte = CommonBytes(boardIp, packet);
                if (sendbyte == null)
                {
                    return null;
                }
                sendbyte[4] = 8;
                Array.Resize(ref sendbyte, sendbyte.Length + 4);

                sendbyte[10] = (byte)Board.Stop;   //packet Type//start command

                sendbyte[13] = (byte)EOT;   //packet Type

                finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);
                finalPacket[17] = value[0];   //crc msb
                finalPacket[18] = value[1];    //crc lsb


                return finalPacket;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return finalPacket;
        }


        public static string convertDecimalToBinary(int decimalValue)
        {

            string binaryValue = Convert.ToString(decimalValue, 2); // Convert decimal to binary

            // Ensure the binary string is at least 3 characters wide
            string paddedBinaryValue = binaryValue.PadLeft(3, '0');

            return paddedBinaryValue;


        }
        public static string convertDecimalToBinary1Value(int decimalValue)
        {

            string binaryValue = Convert.ToString(decimalValue, 2); // Convert decimal to binary

            // Ensure the binary string is at least 3 characters wide
            string paddedBinaryValue = binaryValue.PadLeft(1, '0');

            return paddedBinaryValue;


        }
        public static string convertDecimalToBinary2VALUES(int decimalValue)
        {

            string binaryValue = Convert.ToString(decimalValue, 2); // Convert decimal to binary

            // Ensure the binary string is at least 3 characters wide
            string paddedBinaryValue = binaryValue.PadLeft(2, '0');

            return paddedBinaryValue;


        }
        public static string AppendBinaryValueRightToLeft(string originalBinary, string binaryValue, int position)
        {
            // Ensure the original binary string is at least 8 characters wide
            string paddedOriginalBinary = originalBinary.PadLeft(8, '0');

            // Create a character array to modify the original binary string
            char[] binaryArray = paddedOriginalBinary.ToCharArray();

            // Calculate the starting position for appending the binary value
            int start = Math.Max(0, 8 - position - binaryValue.Length);

            // Append the binary value from right to left within the 8-bit representation
            for (int i = 0; i < binaryValue.Length; i++)
            {
                binaryArray[start + i] = binaryValue[i];
            }

            // Convert the modified character array back to a string
            string resultBinaryValue = new string(binaryArray);

            return resultBinaryValue;
        }

        public static int convertBinaryToDecimal(string binaryValue)
        {


            int decimalValue = Convert.ToInt32(binaryValue, 2); // Convert binary to decimal

            return decimalValue;


        }


    }
}
