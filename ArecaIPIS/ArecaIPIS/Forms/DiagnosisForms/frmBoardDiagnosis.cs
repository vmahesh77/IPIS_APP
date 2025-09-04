using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmBoardDiagnosis : Form
    {
        public frmBoardDiagnosis()
        {
            InitializeComponent();
        }
        private Form currentForm = null;

        private frmIndex parentForm;
        public frmBoardDiagnosis(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }

        private void ActivateButton(object sender)
        {
            // Change the background color of all buttons
            foreach (var button in new[] { btnCds, btnTADB, btnCgdb, btnivdovd })
            {
                button.BackColor = Color.Green;
            }

            // Change the background color of the clicked button
            var clickedButton = (Button)sender;
            clickedButton.BackColor = Color.DeepSkyBlue;
        }

        private void OpenFormInPanel(Form form)
        {
            try
            {


                // Close and dispose of the current form if it exists
                if (currentForm != null)
                {
                    currentForm.Close();
                    currentForm.Dispose();
                }

                // Set the new form as the current form
                currentForm = form;

                // Configure the new form
                form.TopLevel = false; // Make it a child form
                form.FormBorderStyle = FormBorderStyle.None; // Remove border
                form.Dock = DockStyle.Fill; // Dock to fill the panel

                // Add the form to the panel's controls and show it
                panBoardforms.Controls.Add(form);
                panBoardforms.Tag = form; // Optional: Keep a reference to the form in the panel's Tag property
                form.BringToFront(); // Bring the form to the front
                form.Show();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void btnCds_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmBoardDiagnosisCds());
        }

        private void btnTADB_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmBoardDiagnosisTadb());
        }

        private void btnCgdb_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmBoardDiagnosisCgdb());
        }

        private void btnivdovd_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmBoardDiagnosisIvdOvd());
        }

        public static byte[] LinkCheckPacket(string boardIp, int packet)
        {
            try
            {


                Byte[] sendbyte = ByteFormation.CommonBytes(boardIp, packet);
                if (sendbyte == null)
                {
                    return null;
                }
                Array.Resize(ref sendbyte, sendbyte.Length + 4);
                sendbyte[10] = 128;   //packet Type

                sendbyte[13] = 4;  //end of data
                int packetLength = sendbyte.Length - 6;
                byte[] packetLengthBytes = GetTwoBytesFromInt(packetLength);
                sendbyte[3] = packetLengthBytes[0];
                sendbyte[4] = packetLengthBytes[1];
                Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);
                finalPacket[17] = value[0];   //crc msb
                finalPacket[18] = value[1];    //crc lsb



                return finalPacket;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
        public static byte[] GetTwoBytesFromInt(int input)
        {
            try
            {


                // Ensure the input is within the range that can be represented by two bytes
                if (input < 0 || input > 65535)
                {
                    throw new ArgumentOutOfRangeException(nameof(input), "Input must be between 0 and 65535.");
                }

                // Create a byte array to hold the result
                byte[] resultBytes = new byte[2];

                // Store the higher byte in the first position
                resultBytes[0] = (byte)((input >> 8) & 0xFF);

                // Store the lower byte in the second position
                resultBytes[1] = (byte)(input & 0xFF);

                return resultBytes;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;

        }
        public static byte[] SoftResetPacket(string boardIp, int packet)
        {

            try
            {


                Byte[] sendbyte = ByteFormation.CommonBytes(boardIp, packet);
                if (sendbyte == null)
                {
                    return null;
                }
                Array.Resize(ref sendbyte, sendbyte.Length + 4);
                sendbyte[10] = (byte)Board.SoftReset;   //packet Type

                sendbyte[13] = 4;  //end of data
                int packetLength = sendbyte.Length - 6;
                byte[] packetLengthBytes = GetTwoBytesFromInt(packetLength);
                sendbyte[3] = packetLengthBytes[0];
                sendbyte[4] = packetLengthBytes[1];
                Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);
                finalPacket[17] = value[0];   //crc msb
                finalPacket[18] = value[1];    //crc lsb


                return finalPacket;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;

        }
        public static byte[] GetConfiguration(string boardIp, int packet)
        {
            try
            {


                Byte[] sendbyte = ByteFormation.CommonBytes(boardIp, packet);
                if (sendbyte == null)
                {
                    return null;
                }
                Array.Resize(ref sendbyte, sendbyte.Length + 4);
                sendbyte[10] = (byte)Board.GetConfiguration;   //packet Type

                sendbyte[13] = 4;  //end of data
                int packetLength = sendbyte.Length - 6;
                byte[] packetLengthBytes = GetTwoBytesFromInt(packetLength);
                sendbyte[3] = packetLengthBytes[0];
                sendbyte[4] = packetLengthBytes[1];

                Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);
                finalPacket[17] = value[0];   //crc msb
                finalPacket[18] = value[1];    //crc lsb



                return finalPacket;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
        public static byte[] SetConfigurationTadb(string boardIp, int packet, int cdcid)
        {

            try
            {


                var config = GetDatatimeoutAndIntensityTadb(cdcid);


                int datatimeout = config.datatimeout;
                int intensity = config.intensity;



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
                byte[] packetLengthBytes = GetTwoBytesFromInt(packetLength);
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
                ex.ToString();
            }
            return null;
        }

        public static byte[] SetConfigurationtruecolorAgdb(string boardIp, int packet, int cdcid)
        {

            try
            {


                var config = GetDatatimeoutAndIntensityTadb(cdcid);
                byte[] BorderColors = getBorderBytes(cdcid);
                byte[] DataColors = getDataColorBytestruecolorAgdb(cdcid);

                int datatimeout = config.datatimeout;
                int intensity = config.intensity;


                Byte[] sendbyte = ByteFormation.CommonBytes(boardIp, packet);

                Array.Resize(ref sendbyte, sendbyte.Length + 8 + DataColors.Length + BorderColors.Length);
                sendbyte[10] = (byte)Board.SetConfiguration;   //packet Type
                sendbyte[11] = 02;    //sod
                sendbyte[12] = (byte)intensity;   //intensity
                sendbyte[13] = (byte)datatimeout;    //datatimeout

                int i = 14;
                foreach (byte b in BorderColors)
                {
                    sendbyte[i] = b;
                    i++;
                }
                foreach (byte b in DataColors)
                {
                    sendbyte[i] = b;
                    i++;
                }



                sendbyte[i] = 3;    //Eod 
                sendbyte[sendbyte.Length - 1] = 4;  //end of transmission

                int packetLength = sendbyte.Length - 6;
                byte[] packetLengthBytes = frmHubConfiguration.GetTwoBytesFromInt(packetLength);
                sendbyte[3] = packetLengthBytes[0];
                sendbyte[4] = packetLengthBytes[1];

                Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);

                finalPacket[finalPacket.Length - 9] = value[0];   //crc msb
                finalPacket[finalPacket.Length - 8] = value[1];    //crc lsb

                return finalPacket;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return null;
        }
        public static byte[] SetConfigurationOVDIVD(string boardIp, int packet, int cdcid)
        {

            try
            {


                var config = GetDatatimeoutAndIntensityTadb(cdcid);
                byte[] BorderColors = getBorderBytes(cdcid);
                byte[] DataColors = getDataColorBytes(cdcid);

                int datatimeout = config.datatimeout;
                int intensity = config.intensity;


                Byte[] sendbyte = ByteFormation.CommonBytes(boardIp, packet);

                Array.Resize(ref sendbyte, sendbyte.Length + 8 + DataColors.Length + BorderColors.Length);
                sendbyte[10] = (byte)Board.SetConfiguration;   //packet Type
                sendbyte[11] = 02;    //sod
                sendbyte[12] = (byte)intensity;   //intensity
                sendbyte[13] = (byte)datatimeout;    //datatimeout

                int i = 14;
                foreach (byte b in BorderColors)
                {
                    sendbyte[i] = b;
                    i++;
                }
                foreach (byte b in DataColors)
                {
                    sendbyte[i] = b;
                    i++;
                }



                sendbyte[i] = 3;    //Eod 
                sendbyte[sendbyte.Length - 1] = 4;  //end of transmission

                int packetLength = sendbyte.Length - 6;
                byte[] packetLengthBytes = frmHubConfiguration.GetTwoBytesFromInt(packetLength);
                sendbyte[3] = packetLengthBytes[0];
                sendbyte[4] = packetLengthBytes[1];

                Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);

                finalPacket[finalPacket.Length - 9] = value[0];   //crc msb
                finalPacket[finalPacket.Length - 8] = value[1];    //crc lsb

                return finalPacket;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return null;
        }

        public static byte[] getBorderBytes(int cdcid)
        {
            DataTable dt = MediaDb.GetBorderColorConfiguration(cdcid);

            // List<int> resultBytes = new List<int>();
            List<byte> resultBytes = new List<byte>();

            try
            {



                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("Fkey_Masterhub") && int.TryParse(row["Fkey_Masterhub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == cdcid)
                        {
                            resultBytes.AddRange(HexToRgb(row["HorizontalLineColor"].ToString()));
                            resultBytes.AddRange(HexToRgb(row["VerticalLineColor"].ToString()));
                            resultBytes.AddRange(HexToRgb(row["BackgroundColor"].ToString()));
                            resultBytes.AddRange(HexToRgb(row["MessageLineColor"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }


            return resultBytes.ToArray();
        }


        public static byte[] HexToRgb(string hexColor)
        {
            try
            {


                if (hexColor.StartsWith("#"))
                {
                    hexColor = hexColor.Substring(1);
                }

                byte red = byte.Parse(hexColor.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                byte green = byte.Parse(hexColor.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                byte blue = byte.Parse(hexColor.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

                return new byte[] { red, green, blue };
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return null;
        }

        public static byte[] getDataColorBytestruecolorAgdb(int MusterHubkey)
        {
            DataTable dt = MediaDb.GetColorConfiguration(MusterHubkey);
            // List<int> resultBytes = new List<int>();
            List<byte> resultBytes = new List<byte>();

            try
            {


                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("fKey_CDC_MasterHub") && int.TryParse(row["fKey_CDC_MasterHub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == MusterHubkey)
                        {
                            byte statusCode = Convert.ToByte(row["fkey_SchudleStatus"].ToString());

                            // Add status code to the result list
                            resultBytes.Add(statusCode);
                            // Add RGB values for various button colors to the result list
                            switch (statusCode)
                            {
                                case 1:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 2:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 3:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 4:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 5:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 6:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 7:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 8:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 9:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 10:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 11:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 12:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 13:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 14:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 15:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 16:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 17:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 18:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 19:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return resultBytes.ToArray();
        }


        public static byte[] getDataColorBytes(int MusterHubkey)
        {
            DataTable dt = MediaDb.GetColorConfiguration(MusterHubkey);
            // List<int> resultBytes = new List<int>();
            List<byte> resultBytes = new List<byte>();

            try
            {


                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("fKey_CDC_MasterHub") && int.TryParse(row["fKey_CDC_MasterHub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == MusterHubkey)
                        {
                            byte statusCode = Convert.ToByte(row["fkey_SchudleStatus"].ToString());

                            // Add status code to the result list
                            resultBytes.Add(statusCode);
                            // Add RGB values for various button colors to the result list
                            switch (statusCode)
                            {
                                case 1:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    //resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 2:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    //resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 3:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 4:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 5:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 6:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 7:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 8:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 9:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 10:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 11:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    //  resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 12:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 13:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 14:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 15:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 16:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 17:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 18:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                case 19:
                                    resultBytes.AddRange(HexToRgb(row["TrainNo"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainName"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainTime"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainAD"].ToString()));
                                    resultBytes.AddRange(HexToRgb(row["TrainPf"].ToString()));
                                    // resultBytes.AddRange(HexToRgb(row["TrainCoach"].ToString()));
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return resultBytes.ToArray();
        }


        public static byte[] SetConfiguration(string boardIp, int packet)
        {
            try
            {



                string ipaddress = Server.ipAdress;
                string[] SystemIPArr = ipaddress.Split('.');
                string[] BoardIPAdress = boardIp.Split('.');



                Byte[] sendbyte = ByteFormation.CommonBytes(boardIp, packet);
                Array.Resize(ref sendbyte, sendbyte.Length + 8);
                sendbyte[10] = (byte)Board.SetConfiguration;   //packet Type
                sendbyte[11] = 02;    //sod
                sendbyte[12] = 4;   //intensity
                sendbyte[13] = 28;    //datatimeout
                sendbyte[14] = 3;    //Eod
                sendbyte[17] = 4;  //end of transmission
                int packetLength = sendbyte.Length - 6;
                byte[] packetLengthBytes = GetTwoBytesFromInt(packetLength);
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
                Server.LogError(ex.ToString());
            }
            return null;

        }
        public static byte[] SetConfigurationPdc(string ipaddress, int packetidentifier, byte[] pdcData)
        {
            try
            {



                Byte[] sendbyte = ByteFormation.CommonBytes(ipaddress, packetidentifier);

                if (sendbyte == null)
                {
                    return null;
                }
                Array.Resize(ref sendbyte, sendbyte.Length + pdcData.Length + 6);


                sendbyte[10] = (byte)Board.SetConfiguration;   //packet Type
                sendbyte[11] = 02;    //sod
                int i = 12;
                foreach (byte b in pdcData)
                {
                    sendbyte[i] = b;
                    i++;
                }



                sendbyte[i] = 3;    //Eod 
                sendbyte[sendbyte.Length - 1] = 4;  //end of transmission

                int packetLength = sendbyte.Length - 6;
                byte[] packetLengthBytes = frmHubConfiguration.GetTwoBytesFromInt(packetLength);
                sendbyte[3] = packetLengthBytes[0];
                sendbyte[4] = packetLengthBytes[1];

                Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);

                finalPacket[finalPacket.Length - 9] = value[0];   //crc msb
                finalPacket[finalPacket.Length - 8] = value[1];    //crc lsb

                return finalPacket;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return null;
        }


        public static (int datatimeout, int intensity) GetDatatimeoutAndIntensityTadb(int cdcid)
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
                DataTable dt = HubConfigurationDb.GetBoardDetails(cdcid);
                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("FkeyofMasterHub") && int.TryParse(row["FkeyofMasterHub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == cdcid)
                        {
                            if (row["EraseTime"] != DBNull.Value)
                            {
                                datatimeout = Convert.ToInt32(row["EraseTime"]);
                            }

                            if (row["Intensity"] != DBNull.Value)
                            {
                                intensity = Convert.ToInt32(row["Intensity"]);
                                intensity = GetIntensityRanges(intensity);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }

            return (datatimeout, intensity);

        }
        public static int GetIntensityRanges(int intensity)
        {
            if (intensity >= 0 && intensity <= 25)
            {
                return 1;
            }
            else if (intensity >= 26 && intensity <= 50)
            {
                return 2;
            }
            else if (intensity >= 51 && intensity <= 75)
            {
                return 3;
            }
            else if (intensity >= 76 && intensity <= 100)
            {
                return 4;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Intensity must be between 0 and 100.");
            }
        }

        public static int GetIntensityTadb(int cdcid)
        {

            int defaultIntensity = 50;

            if (cdcid == null)
            {
                return defaultIntensity;
            }


            int intensity = defaultIntensity;
            try
            {



                DataTable dt = HubConfigurationDb.GetBoardDetails(cdcid);
                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("FkeyofMasterHub") && int.TryParse(row["FkeyofMasterHub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == cdcid)
                        {


                            if (row["Intensity"] != DBNull.Value)
                            {
                                intensity = Convert.ToInt32(row["Intensity"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }

            return intensity;
        }



        public static byte[] DeleteData(string boardIp, int packet)
        {
            try
            {
                Byte[] sendbyte = ByteFormation.CommonBytes(boardIp, packet);
                if (sendbyte == null)
                {
                    return null;
                }
                Array.Resize(ref sendbyte, sendbyte.Length + 4);
                sendbyte[10] = (byte)Board.DeleteData;   //packet Type

                sendbyte[13] = 4;  //end of data
                int packetLength = sendbyte.Length - 6;
                byte[] packetLengthBytes = GetTwoBytesFromInt(packetLength);
                sendbyte[3] = packetLengthBytes[0];
                sendbyte[4] = packetLengthBytes[1];
                Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
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
            return null;
        }
        public static int GetOctetbyIp(string ipaddress, int value)
        {

            try
            {


                // Validate that the input is a proper IP address
                if (IPAddress.TryParse(ipaddress, out IPAddress parsedIpAddress))
                {
                    // Split the IP address into its octets
                    string[] octets = ipaddress.Split('.');

                    // Ensure there are exactly 4 octets
                    if (octets.Length == 4)
                    {
                        // Try to parse the third octet
                        if (int.TryParse(octets[value - 1], out int Octetno))
                        {
                            return Octetno;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            // Return -1 if the IP address is not valid or other parsing issues occurred
            return -1;
        }


        public static string GetIntensity(byte intensityByte)
        {
            //// Implement logic to convert intensity byte to a meaningful string
            switch (intensityByte)
            {
                case 1:
                    return "25%";
                case 2:
                    return "50%";
                case 3:
                    return "75%";
                case 4:
                    return "100%";
                default:
                    return "100%";
            }
            // Implement logic to convert timeout byte to a meaningful string
            return $"{intensityByte} %";

        }

        public static string GetDataTimeout(byte timeoutByte)
        {
            // Implement logic to convert timeout byte to a meaningful string
            return $"{timeoutByte} Minutes";
        }

        private void frmBoardDiagnosis_Load(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmBoardDiagnosisCds());
        }

        public static byte[] ErrorDataPacket(string boardIp, int packet, string Error)
        {
            try
            {


                Byte[] sendbyte = ByteFormation.CommonBytes(boardIp, packet);
                if (sendbyte == null)
                {
                    return null;
                }
                Array.Resize(ref sendbyte, sendbyte.Length + 4);
                sendbyte[10] = (byte)Board.LinkCheck;   //packet Type

                sendbyte[13] = 4;  //end of data
                int packetLength = sendbyte.Length - 6;
                byte[] packetLengthBytes = GetTwoBytesFromInt(packetLength);
                sendbyte[3] = packetLengthBytes[0];
                sendbyte[4] = packetLengthBytes[1];

                sendbyte = ErrorPacketFormation(sendbyte, Error);
                Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);



                Byte[] value = Server.CheckSum(finalPacket);
                finalPacket[17] = value[0];   //crc msb
                finalPacket[18] = value[1];    //crc lsb

                if (Error == "Crc Fail")
                {
                    finalPacket[18] = (byte)(finalPacket[18] + 1);
                }
                return finalPacket;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return null;
        }
        public static byte[] ErrorPacketFormation(byte[] sendByte, string error)
        {
            // Trim whitespace from the error string
            error = error.Trim();

            // Create a base error response structure
            byte[] errorResponse = new byte[sendByte.Length]; // Ensure this matches your protocol

            // Copy the original byte array into the error response
            Array.Copy(sendByte, errorResponse, sendByte.Length);

            // Set the specific byte in the errorResponse based on the error type
            switch (error)
            {

                case "Invalid Des Add":
                    errorResponse[5] = (byte)0;
                    errorResponse[6] = (byte)(errorResponse[8]);
                    // Increment for Invalid Destination Address
                    break;
                case "Invalid Src Add":
                    errorResponse[8] = (byte)(errorResponse[8] + 1);  // Reset for Invalid Source Address
                    break;
                case "Invalid Fc":
                    errorResponse[10] = 180; // Set specific value for Invalid Function Code
                    break;
                case "invalid Data Length":
                    errorResponse[3] = 35; // Reset for Invalid Data Length
                    break;
                default:
                    return errorResponse; // If the error is unrecognized, return null
            }

            return errorResponse;
        }


    }
}
