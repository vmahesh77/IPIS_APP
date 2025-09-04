using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{

    class HubConfigurationDb
    {
        private DbConnection dbConnection;

        public HubConfigurationDb()
        {
            dbConnection = new DbConnection();
        }

        public static DataSet DScLocal = new DataSet();
        public static DataSet DSmLocal = new DataSet();
        public static DataSet DSvLocal = new DataSet();
        public static SqlDataAdapter DALocal;
        public static void FillAllDatasetLocal()
        {
            try
            {
                //sqlConnstr = @"Data Source=.;Initial Catalog=IPIS_DB;User ID=sa;Password=areca@123";
                string sql1 = "select * from [Config].[TeluguConstrants]";
                SqlConnection con = new SqlConnection(DbConnection.MasterconnectionString);
                DALocal = new SqlDataAdapter(sql1, con);
                DScLocal = new DataSet();
                DALocal.Fill(DScLocal);


                string sql2 = "select * from [Config].[TMatras]";

                DALocal = new SqlDataAdapter(sql2, con);
                DSmLocal = new DataSet();
                DALocal.Fill(DSmLocal);


                string sql3 = "select * from [Config].[TVirama]";

                DALocal = new SqlDataAdapter(sql3, con);
                DSvLocal = new DataSet();
                DALocal.Fill(DSvLocal);

            }
            catch (Exception ex)
            {

                ex.ToString();
            }
        }

        public static int SavePdcData(int id, string platformNo, int etherNetPort, string noOfPorts, string ipAddress, string location, int portNo, int packetidentifier, bool interoperabilitystatus)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@ID", id),
                new SqlParameter("@Platform", platformNo),
                new SqlParameter("@EtherNetPort", etherNetPort),
                new SqlParameter("@NoOfPorts", noOfPorts),
                new SqlParameter("@IpAddress", ipAddress),
                new SqlParameter("@Location", location),
                new SqlParameter("@portNo", portNo),
                new SqlParameter("@packetIdentifier", packetidentifier),
                new SqlParameter("@interoperability", interoperabilitystatus)

                };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertUpdatePdcConfigurationSp]", parameters, BaseClass.TypeInt);

                return rowsAffected;
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());
                // MessageBox.Show("An error occurred: " + ex.Message);
                return rowsAffected;
            }
        }

        public static int SaveCCTVconfiguration(int id, int BoardID, string location, int etherNetPort, string ipAddress, int noOfLines, int portNo, int packetidentifier)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@ID", id),
                new SqlParameter("@BoardId", BoardID),
                 new SqlParameter("@NOOFLines", noOfLines),
                new SqlParameter("@Location", location),
                new SqlParameter("@EtherNetPort", etherNetPort),
                new SqlParameter("@IpAddress", ipAddress),
                new SqlParameter("@Port", portNo),
                new SqlParameter("@packetIdentifier", packetidentifier)

            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertUpdateCCTVConfigurationSp]", parameters, BaseClass.TypeInt);

                return rowsAffected;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message);
                return rowsAffected;
            }
        }



        public static int SaveTadbBoard(
       int id, int pdcPort, int boardId, string location, int ethernetPort, string ipAddress, string platform, int noOfLines,
       bool message, bool boardRunning, string displaySequence, string platforms, string videoType, string letterSpeed,
       string formatType, string letterGap, string displayEffect, int fontSize, string infoDisplayed, int delayTime,
       int eraseTime, string defaultEnglish, string defaultRegional, string defaultHindi, int portno, int packetidentifier, bool interoperabilitystatus)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@ID", id),
                new SqlParameter("@PdcPort", pdcPort),
                new SqlParameter("@portNo", portno),
                new SqlParameter("@Location", location),
                new SqlParameter("@EtherNetPort", ethernetPort),
                new SqlParameter("@IpAddress", ipAddress),
                new SqlParameter("@Platform", platform),
                new SqlParameter("@packetIdentifier", packetidentifier),
                new SqlParameter("@BoardId", boardId),
                new SqlParameter("@NoOfLines", noOfLines),
                new SqlParameter("@MessagesEnble", message),
                new SqlParameter("@BoardRunning", boardRunning),
                new SqlParameter("@DisplaySequence", displaySequence),
                new SqlParameter("@checkedplatformNumbers", platforms),
                new SqlParameter("@VideoType", videoType),
                new SqlParameter("@LetterSpeed", letterSpeed),
                new SqlParameter("@FormatType", formatType),
                new SqlParameter("@LetterGap", letterGap),
                new SqlParameter("@DisplayEffect", displayEffect),
                new SqlParameter("@FontSize", fontSize),
                new SqlParameter("@InfoDisplayed", infoDisplayed),
                new SqlParameter("@DelayTime", delayTime),
                new SqlParameter("@EraseTime", eraseTime),
                new SqlParameter("@LanEnglish", defaultEnglish),
                new SqlParameter("@LanRegional", defaultRegional),
                new SqlParameter("@LanHindi", defaultHindi),
                new SqlParameter("@interoperability", interoperabilitystatus)

            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertUpdateHUBConfigurationSp]", parameters, BaseClass.TypeInt);

                return 1;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show($"An error occurred while saving data: {ex.Message}");
                return rowsAffected;
            }
        }
        public static void InsertTruecolorAgdb(string Boardip, bool truecolorstatus)
        {


            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@IpAddress", Boardip),
                        new SqlParameter("@Truecolorstatus", truecolorstatus)
                };
                int Result = (int)DbConnection.ExecuteSps("[config].[InsertOrUpdateTruecolorAgdb]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());

            }



        }


        public static void getbitmaplength(int font, DataTable dt, int lang)
        {


            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@Chars", dt),
                        new SqlParameter("@Ling", lang),
                          new SqlParameter("@Font", font)
                };
                DataTable dts = (DataTable)DbConnection.ExecuteSps("[Config].[MultiLingualCharLength]", parameters, BaseClass.TypeDataTable);
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());

            }



        }

        public static int SaveIvdOvdboard(
    int id, int pdcPort, int boardId, string location, int ethernetPort, string ipAddress, string platform, int noOfLines,
    bool message, bool boardRunning, string displaySequence, string platforms, string videoType, string letterSpeed,
    string formatType, string letterGap, string displayEffect, int fontSize, string infoDisplayed, int delayTime,
    int eraseTime, string defaultEnglish, string defaultRegional, string defaultHindi, int portno, int packetidentifier,
    string speed, string mediaType, string volumn, string mediaEntryEffectCode, string messageFontSize,
    string messageCharacterGap, int startHour, int startMinute, int endHour, int endMinute, int timeDelay, int displayType,
    string messageLine, string messageTopBottom, bool interoperabilitystatus)
        {
            int rowsAffected = 0;
            try
            {

                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@ID", id),
                new SqlParameter("@PdcPort", pdcPort),
                new SqlParameter("@portNo", portno),
                new SqlParameter("@Location", location),
                new SqlParameter("@EtherNetPort", ethernetPort),
                new SqlParameter("@IpAddress", ipAddress),
                new SqlParameter("@Platform", platform),
                new SqlParameter("@packetIdentifier", packetidentifier),
                new SqlParameter("@BoardId", boardId),
                new SqlParameter("@NoOfLines", noOfLines),
                new SqlParameter("@MessagesEnble", message),
                new SqlParameter("@BoardRunning", boardRunning),
                new SqlParameter("@DisplaySequence", displaySequence),
                new SqlParameter("@checkedplatformNumbers", platforms),
                new SqlParameter("@VideoType", videoType),
                new SqlParameter("@LetterSpeed", letterSpeed),
                new SqlParameter("@FormatType", formatType),
                new SqlParameter("@LetterGap", letterGap),
                new SqlParameter("@DisplayEffect", displayEffect),
                new SqlParameter("@FontSize", fontSize),
                new SqlParameter("@InfoDisplayed", infoDisplayed),
                new SqlParameter("@DelayTime", delayTime),
                new SqlParameter("@EraseTime", eraseTime),
                new SqlParameter("@LanEnglish", defaultEnglish),
                new SqlParameter("@LanRegional", defaultRegional),
                new SqlParameter("@LanHindi", defaultHindi),
                new SqlParameter("@Speed", speed),
                new SqlParameter("@MediaType", mediaType),
                new SqlParameter("@Volumn", volumn),
                new SqlParameter("@MediaEntryEffectCode", mediaEntryEffectCode),
                new SqlParameter("@MessageFontSize", messageFontSize),
                new SqlParameter("@MessageCharacterGap", messageCharacterGap),
                new SqlParameter("@StartHour", startHour),
                new SqlParameter("@StartMinute", startMinute),
                new SqlParameter("@EndHour", endHour),
                new SqlParameter("@EndMinute", endMinute),
                new SqlParameter("@TimeDelay", timeDelay),
                new SqlParameter("@DisplayType", displayType),
                new SqlParameter("@MessageLine", messageLine),
                new SqlParameter("@MessageTopBottom", messageTopBottom),
                new SqlParameter("@interoperability", interoperabilitystatus)
            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertUpdateMediaHUBConfigurationSp]", parameters, BaseClass.TypeInt);

                return rowsAffected;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show($"An error occurred while saving data: {ex.Message}");
                return 0;
            }
        }

        public static DataTable GetEthernetPorts()
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {


                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetPortsSp", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                //MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable GetCgdbConfiguration()
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {


                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetCoachConfigurationSp", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable GetMediaDetails(int HubKey)
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {
                       new SqlParameter("@MasterHubKey", HubKey)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetMediaSettingsSp]", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable GetBoardDetails(int HubKey)
        {
            DataTable dataTable = new DataTable();
            try
            {


                var parameters = new List<SqlParameter>
                {
                   new SqlParameter("@MasterHubKey", HubKey)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetChildHubSettingsSp]", parameters, BaseClass.TypeDataTable);//[config].[GetChildHubSettingsSp]

                return dataTable;


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable GettruecolorBoardDetails(string ipaddress)
        {
            DataTable dataTable = new DataTable();
            try
            {


                var parameters = new List<SqlParameter>
                {
                   new SqlParameter("@IpAddress ", ipaddress)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetTruecolorAgdbByIpAddress]", parameters, BaseClass.TypeDataTable);//[config].[GetChildHubSettingsSp]

                return dataTable;


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable GetCCTVConfiguration(int HubKey)
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {
                  new SqlParameter("@MasterHubKey", HubKey)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetCctvConfigurationSp]", parameters, BaseClass.TypeDataTable);

                return dataTable;


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                // MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable GetEnglishBitMap(int fontSize)
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@fontSize", fontSize)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetEnglishBitMap]", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable GetHindiBitMap(int fontSize)
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                    new SqlParameter("@fontSize", fontSize)
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetHindiBitMap]", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable GetRegionalBitMap(int fontSize)
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {
                       new SqlParameter("@fontSize", fontSize)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetRegionalBitMapSp]", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                //MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public static int DeletePort(int ethernetPort, int pk)
        {
            int rowsAffected = 0;
            try
            {

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Port", ethernetPort),
                    new SqlParameter("@pk", pk)

                };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].DeletePortSp", parameters, BaseClass.TypeInt);

                if (rowsAffected >= 0)
                {
                    return rowsAffected;
                }
                else
                {
                    return 0;


                }


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return 0;

            }
        }
        public static int DeletePdcPort(int pkKey, int btnpdcPort, int MainPort)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Pk", pkKey),
                    new SqlParameter("@pdcPort", btnpdcPort),
                    new SqlParameter("@MainPort", MainPort)

                };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].DeletePdcPortSp", parameters, BaseClass.TypeInt);

                if (rowsAffected > 0)
                {
                    return rowsAffected;
                }
                else
                {
                    return 0;


                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return 0;
                // Handle exceptions (logging, rethrowing, etc.)
                // throw new Exception("Error deleting port: " + ex.Message);
            }
        }
        public static DataTable GetCoaches(int cdcid)
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MasterHubKey", cdcid)


                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetCgdbHubConfigurationSp", parameters, BaseClass.TypeDataTable);
                return dataTable;


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Or throw the exception further
            }
        }

        public static bool CheckCdcAndPdcPort(string cdcpk, string pdcPort)
        {
            bool result = false;
            try
            {

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@cdcpk", cdcpk),
                    new SqlParameter("@pdcPort", pdcPort)


                };
                result = (bool)DbConnection.ExecuteSps("[config].[CheckCgdbCdcAndPdcPort]", parameters, BaseClass.TypeBool);
                return result;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        public static int SaveCoachConfiguration(
      int pkeyCoachConfig, int fkeyCDCID, int pdcPort, string videoType, string letterGap, string letterSpeed, string displayEffect,
      int fontSize, string formatType, int noOfCoaches, string defaultPlatformNo,
      int eraseTime, int delayTime, string defaultEnglish, string defaultHindi, string divCode, int packetIdentifier, string pdcIp, int mainEthernetPort, DataTable cgdbIp)
        {
            try
            {
                // Define the list of SQL parameters
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@Pkey_CoachConfig", SqlDbType.Int)
            {
                Direction = ParameterDirection.InputOutput,
                Value = pkeyCoachConfig == 0 ? (object)DBNull.Value : pkeyCoachConfig
            },
            new SqlParameter("@Fkey_CDCID", fkeyCDCID),
            new SqlParameter("@PdcPortNo", pdcPort),
            new SqlParameter("@VideoType", videoType),
            new SqlParameter("@LetterGap", letterGap),
            new SqlParameter("@LetterSpeed", letterSpeed),
            new SqlParameter("@DisplayEffect", displayEffect),
            new SqlParameter("@Fontsize", fontSize),
            new SqlParameter("@FormatType", formatType),
            new SqlParameter("@No_Of_Coaches", noOfCoaches),
            new SqlParameter("@default_platformno", defaultPlatformNo),
            new SqlParameter("@Erase_time", eraseTime),
            new SqlParameter("@DelayTime", delayTime),
            new SqlParameter("@DefaultEnglish", defaultEnglish),
            new SqlParameter("@DefaultHindi", defaultHindi),
            new SqlParameter("@DivCode", divCode),
            new SqlParameter("@PDCIp", pdcIp),
            new SqlParameter("@PacketiDENTIFIER", packetIdentifier),
            new SqlParameter("@MainEthernetPortNo", mainEthernetPort),
            new SqlParameter("@CGDBHubConfigData", SqlDbType.Structured) { Value = cgdbIp }
        };

                // Execute the stored procedure
                int result = (int)DbConnection.ExecuteSps("[Config].[InsertOrUpdateCoachConfigurationSp]", parameters, BaseClass.TypeInt);

                // Retrieve the output parameter value
                if (parameters[0].Value != DBNull.Value)
                {
                    pkeyCoachConfig = Convert.ToInt32(parameters[0].Value);
                }

                // Return the primary key value
                return pkeyCoachConfig;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return 0;
            }
        }


    }
}
