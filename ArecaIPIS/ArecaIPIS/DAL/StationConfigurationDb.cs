using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class StationConfigurationDb
    {
        private DbConnection dbConnection;

        public StationConfigurationDb()
        {
            dbConnection = new DbConnection();
        }

        public void SaveStationConfiguration(string stationName, string stationCode, string upStationCode, string downStationCode,
            string divisionCode, int noOfPlatforms, int portNo, int noOfRowsToDisplay, string ipAddress, List<string> regionalLanguages,
            int MainScreenDisplay)
        {


            try
            {
                var parameters = new List<SqlParameter>
                {
                        new SqlParameter("@StationName", stationName),
                        new SqlParameter("@StationCode", stationCode),
                        new SqlParameter("@UpStationcode", upStationCode),
                        new SqlParameter("@DownStationCode", downStationCode),
                        new SqlParameter("@DivisionCode", divisionCode),
                        new SqlParameter("@NoOfPlatforms", noOfPlatforms),
                        new SqlParameter("@PortNo", portNo),
                        new SqlParameter("@OnlineRows", noOfRowsToDisplay),
                        new SqlParameter("@IpAddress", ipAddress),
                        new SqlParameter("@RegionalLanguages", string.Join(",", regionalLanguages)),
                        new SqlParameter("@MainScreenDisplay", MainScreenDisplay)
                };
                int result = (int)DbConnection.ExecuteSps("[config].[SaveStationConfigurationSp]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

        }

        public int UpdateStationConfiguration(string stationName, string stationCode, string upStationCode, string downStationCode,
            string divisionCode, int noOfPlatforms, int portNo, int noOfRowsToDisplay, string ipAddress, List<string> regionalLanguages,
            int mainScreenDisplay)
        {


            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
                         new SqlParameter("@StationName", stationName),
                         new SqlParameter("@StationCode", stationCode),
                         new SqlParameter("@UpStationcode", upStationCode),
                         new SqlParameter("@DownStationCode", downStationCode),
                         new SqlParameter("@DivisionCode", divisionCode),
                         new SqlParameter("@NoOfPlatforms", noOfPlatforms),
                         new SqlParameter("@PortNo", portNo),
                         new SqlParameter("@OnlineRows", noOfRowsToDisplay),
                         new SqlParameter("@IpAddress", ipAddress),
                         new SqlParameter("@RegionalLanguages", string.Join(",", regionalLanguages)),
                         new SqlParameter("@MainScreenDisplay", mainScreenDisplay)

            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[UpdateStationConfigurationSp]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return rowsAffected;
        }

        public int InsertUpdateStationConfiguration(string stationName, string stationCode, string upStationCode, string downStationCode,
          string divisionCode, int noOfPlatforms, int portNo, int noOfRowsToDisplay, string ipAddress, string regionalLanguages,
          int mainScreenDisplay, DataTable dt)
        {

            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
                        new SqlParameter("@ID", 1),
                            new SqlParameter("@StationName", stationName),
                            new SqlParameter("@StationCode", stationCode),
                            new SqlParameter("@UpStationcode", upStationCode),
                            new SqlParameter("@DownStationCode", downStationCode),
                            new SqlParameter("@DivisionCode", divisionCode),
                            new SqlParameter("@NoOfPlatforms", noOfPlatforms),
                            new SqlParameter("@PortNo", portNo),
                            new SqlParameter("@OnlineRows", noOfRowsToDisplay),
                            new SqlParameter("@IpAddress", ipAddress),
                            new SqlParameter("@MainScreenDisplay", mainScreenDisplay),
                            new SqlParameter("@platformNames", dt),
                            new SqlParameter("@RegionalLanguages", regionalLanguages)

            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertUpdateStationConfigurationSp]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return rowsAffected;



        }
        public int InsertUpdatereggapcodeConfiguration(int reggapcode)
        {

            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {

                            new SqlParameter("@GapCode", reggapcode),
            };
                rowsAffected = (int)DbConnection.ExecuteSps("[dbo].[updateOrInsertRegGapCode]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return rowsAffected;



        }
        public static int InsertUpdatelanguagesettings(string code, string languageName, string font, string fontFamily, int fontSize)
        {

            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
                        new SqlParameter("@Code", code),
                        new SqlParameter("@Language_Name", languageName),
                        new SqlParameter("@Font", font),
                        new SqlParameter("@Font_Family", fontFamily),
                        new SqlParameter("@Font_Size", fontSize)

            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertUpdateLanguageSettings]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return rowsAffected;
        }

        public static DataTable GetRegionalLanguages()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {


                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetRegionalLanguagesSp", parameters, BaseClass.TypeDataTable);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return dataTable;
        }

        public static void GetStationDetails()
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("config.GetAllStationDetailsSp", parameters, BaseClass.TypeDataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    BaseClass.StationPkId = (int)row["Pkey_StationID"];
                    BaseClass.StationName = (string)row["StationName"];
                    BaseClass.StationCode = (string)row["StationCode"];
                    BaseClass.DivisionCode = (string)row["DivisionCode"];
                    BaseClass.RegionalLanguage1pk = (string)row["RegionalLanguage1"];
                    BaseClass.UpStationCode = (string)row["UpStationcode"];
                    BaseClass.DownStationCode = (string)row["DownStationCode"];
                    BaseClass.OnlineRows = (int)row["OnlineRows"];
                    BaseClass.PortNo = (int)row["PortNo"];
                    BaseClass.MainsCoachDisplay = (int)row["MainsCoachdispaly"];
                    BaseClass.NoOfPlatforms = (int)row["Platforms"];

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }
        public static List<string> GetPlatforms()
        {
            List<string> platformNames = new List<string>();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                DataTable dt = (DataTable)DbConnection.ExecuteSps("config.[GetAllPlatformsSp]", parameters, BaseClass.TypeDataTable);
                foreach (DataRow row in dt.Rows)
                {
                    string platformName = row["PlatformName"].ToString();
                    platformNames.Add(platformName);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return platformNames;


        }


    }
}
