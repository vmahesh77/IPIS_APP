using ArecaIPIS.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class InterfaceDb
    {
        public static int InsertUpdateNtesConfiguration(bool ntesEnable, string urlType, string stationCode, int nextMins, bool audio, bool autoMode, string custID, string custPass, string custType, string url, string authenticationToken,string PollMins)
        {


            int rowsAffected = 0;
            try
            {
                // Create parameters for the stored procedure
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@NTESEnable", ntesEnable),
            new SqlParameter("@UrlType", urlType),
            new SqlParameter("@StationCode", stationCode),
            new SqlParameter("@NextMins", nextMins),
            new SqlParameter("@Audio", audio),
            new SqlParameter("@AutoMode", autoMode),
            new SqlParameter("@custID", custID),
            new SqlParameter("@custPass", custPass),
            new SqlParameter("@custType", custType),
            new SqlParameter("@url", url),
            new SqlParameter("@authenticationToken", authenticationToken),
            new SqlParameter("@PollMins",PollMins)
            //new SqlParameter("@ReturnVal", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue }
        };

                // Execute stored procedure
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[UpdateinsertNtesWebConfiguration]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {
                // Log the error for further investigation
                Server.LogError($"Error in InsertUpdateNtesConfiguration: {ex}");
            }


            return rowsAffected;
        }

        public static DataTable GetNtesConfiguration()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetNtesWebConfiguration]", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error loading NTES configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }



        public static DataTable GetAllTrains()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetAllTrainsSP]", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                //  MessageBox.Show($"Error loading NTES configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }
        public static DataTable GetNtesWebServiceData()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[SelectTopNtesWebserviceData]", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                // MessageBox.Show($"Error loading NTES configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }


        public static int SaveNtesDataNew(string data, bool readStatus)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {

                 new SqlParameter("@Data", data),
                 new SqlParameter("@ReadStatus", readStatus)
            };
                rowsAffected = (int)DbConnection.ExecuteSps("[Config].[InsertNtesData]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                //MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected;
        }


        public static int InsertSchduleData(int fkeyTrain, string trainNo, string name, string rArrivalTime,
    string rDepartureTime, string arrivingStatus, string statusName, string lateBy, string lArrivalTime, string lDepartureTime,
    string platformName, string terminateDiverted, string lNationalLang, string lRegional1Lang, string coachPositions, bool tadb, bool cgdb, bool ann, bool ntes, string city)
        {
            int rowsAffected = 0;
            try
            {

                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@FKEY_TRAIN", fkeyTrain),
                new SqlParameter("@TrainNo", trainNo),
                new SqlParameter("@Name", name),
                new SqlParameter("@RArrivalTime", rArrivalTime),
                new SqlParameter("@RDepartureTime", rDepartureTime),
                new SqlParameter("@ArrivingStatus", arrivingStatus),
                new SqlParameter("@StatusName", statusName),
                new SqlParameter("@LateBy", lateBy),
                new SqlParameter("@LArrivalTime", lArrivalTime),
                new SqlParameter("@LDepartureTime", lDepartureTime),
                new SqlParameter("@PlatformName", platformName),
                new SqlParameter("@Terminate_Diverted", terminateDiverted),
                new SqlParameter("@LNational_Lang", lNationalLang),
                new SqlParameter("@LRegional1_Lang", lRegional1Lang),
                new SqlParameter("@CoachPositions", coachPositions),
                new SqlParameter("@Tadb", tadb),
                new SqlParameter("@Cgdb", cgdb),
                new SqlParameter("@Ann", ann),
                new SqlParameter("@Ntes", ntes),
                new SqlParameter("@city", city)
            };
                rowsAffected = (int)DbConnection.ExecuteSps("[Scheduled].[InsertNTESScheduledTaddbSp]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                //MessageBox.Show($"Error inserting schedule data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected;
        }


        public static int InsertWebserviceNtesData(
     string trainno, string trainname, string trainNameHindi, string trainType, string trainTypeName, string trainTypeNameHindi,
     string trainStartDate, string src, string srcName, string srcNameHindi, string dstn, string dstnName, string dstnNameHindi,
     string STA, string ETA, bool isArrived, string delayArr, string STD, string ETD, string delayDep, string ADFlag,
     string expectedTime, string expectedDelay, string trainStatus, string platformNo, string coachPosition, string coachClass,
     string schStation, string schStationDate, string schStationEvent, string TerminatedPlace, bool ConfirmedToBoards,
     bool ConfirmedToCoaches, string DivertedRoute, string StationSrno)
        {
            int rowsAffected = 0;

            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@trainno", trainno ?? (object)DBNull.Value),
                new SqlParameter("@trainname", trainname ?? (object)DBNull.Value),
                new SqlParameter("@trainNameHindi", trainNameHindi ?? (object)DBNull.Value),
                new SqlParameter("@trainType", trainType ?? (object)DBNull.Value),
                new SqlParameter("@trainTypeName", trainTypeName ?? (object)DBNull.Value),
                new SqlParameter("@trainTypeNameHindi", trainTypeNameHindi ?? (object)DBNull.Value),
                new SqlParameter("@trainStartDate", trainStartDate ?? (object)DBNull.Value),
                new SqlParameter("@src", src ?? (object)DBNull.Value),
                new SqlParameter("@srcName", srcName ?? (object)DBNull.Value),
                new SqlParameter("@srcNameHindi", srcNameHindi ?? (object)DBNull.Value),
                new SqlParameter("@dstn", dstn ?? (object)DBNull.Value),
                new SqlParameter("@dstnName", dstnName ?? (object)DBNull.Value),
                new SqlParameter("@dstnNameHindi", dstnNameHindi ?? (object)DBNull.Value),
                new SqlParameter("@STA", STA ?? (object)DBNull.Value),
                new SqlParameter("@ETA", ETA ?? (object)DBNull.Value),
                new SqlParameter("@isArrived", isArrived),
                new SqlParameter("@delayArr", delayArr ?? (object)DBNull.Value),
                new SqlParameter("@STD", STD ?? (object)DBNull.Value),
                new SqlParameter("@ETD", ETD ?? (object)DBNull.Value),
                new SqlParameter("@delayDep", delayDep ?? (object)DBNull.Value),
                new SqlParameter("@ADFlag", ADFlag ?? (object)DBNull.Value),
                new SqlParameter("@expectedTime", expectedTime ?? (object)DBNull.Value),
                new SqlParameter("@expectedDelay", expectedDelay ?? (object)DBNull.Value),
                new SqlParameter("@trainStatus", trainStatus ?? (object)DBNull.Value),
                new SqlParameter("@platformNo", platformNo ?? (object)DBNull.Value),
                new SqlParameter("@coachPosition", coachPosition ?? (object)DBNull.Value),
                new SqlParameter("@coachClass", coachClass ?? (object)DBNull.Value),
                new SqlParameter("@schStation", schStation ?? (object)DBNull.Value),
                new SqlParameter("@schStationDate", schStationDate ?? (object)DBNull.Value),
                new SqlParameter("@schStationEvent", schStationEvent ?? (object)DBNull.Value),
                new SqlParameter("@TerminatedPlace", TerminatedPlace ?? (object)DBNull.Value),
                new SqlParameter("@ConfirmedToBoards", ConfirmedToBoards),
                new SqlParameter("@ConfirmedToCoaches", ConfirmedToCoaches),
                new SqlParameter("@DivertedRoute", DivertedRoute ?? (object)DBNull.Value),
                new SqlParameter("@StationSrno", StationSrno ?? (object)DBNull.Value)
            };
                rowsAffected = (int)DbConnection.ExecuteSps("[Config].[InsertWebserviceNtesData]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                //MessageBox.Show($"Error inserting web service data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected;
        }



        public static DataTable ClearNtesWebServiceTable()
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[ClearTableNtesWebServiceDataSp]", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                //MessageBox.Show($"Error clearing table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }
        public static int ClearScheduleTadb()
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {


                };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[ClearScheduleTadbSp]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                //MessageBox.Show($"Error clearing table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected;
        }

        public static int InsertUpdateCdotConfiguration(bool cdotEnable, int speed, int delayTime, int pollingTime, string stationCode, bool autoMode, string userPass, string cdotUrl, string UserName, string Password, string ValidationStatus, string Dissmentationurl)
        {
            int rowsAffected = 0;
            try
            {

                var parameters = new List<SqlParameter>
                {
                 new SqlParameter("@CdotEnable", cdotEnable),
                new SqlParameter("@LetterSpeed ", speed),
                new SqlParameter("@StationCode", stationCode),
                new SqlParameter("@DelayTimeInSec", delayTime),
                new SqlParameter("@PollingTimeInMin", pollingTime),
                new SqlParameter("@AutoMode", autoMode),
                new SqlParameter("@userPass", userPass),
                new SqlParameter("@UrlType", cdotUrl),
                new SqlParameter("@Username", UserName),
                new SqlParameter("@Password", Password),
                new SqlParameter("@validationstatusurl", ValidationStatus),
                new SqlParameter("@Dissemenationurl", Dissmentationurl)
            };


                rowsAffected = (int)DbConnection.ExecuteSps("[config].[SaveCdotSP]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating station configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected;
        }




        public static DataTable GetLetterSpeed()
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetLetterSpeedSp]", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;
        }

        public static void DeleteCdotAlertUrl()
        {
            try
            {


                var parameters = new List<SqlParameter>
                {

                };
                DbConnection.ExecuteSps("[Config].[DeleteCdotAlertUrlSP]", parameters, BaseClass.TypeInt);

                string statusMessage = string.Empty;

                using (var connection = DbConnection.OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand("[Config].[DeleteCdotAlertUrlSP]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }






        public static int InsertUpdateCdotAlertUrl(string cdotUrl, string UserName, string Password, string ValidationStatus, string Dissmentationurl)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@UrlType", cdotUrl),
                new SqlParameter("@Username", UserName),
                new SqlParameter("@Password", Password),
                new SqlParameter("@validationstatusurl", ValidationStatus),
                new SqlParameter("@Dissemenationurl", Dissmentationurl)
            };



                rowsAffected = (int)DbConnection.ExecuteSps("[config].[SaveCdotAlertUrlSP]", parameters, BaseClass.TypeInt);


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                //MessageBox.Show($"Error updating station configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected;
        }





        public static DataSet GetCDotConfiguration()
        {
            DataSet dataSet = new DataSet(); // Create a DataSet to hold multiple tables
            try
            {

                var parameters = new List<SqlParameter>
                {


                };
                dataSet = (DataSet)DbConnection.ExecuteSps("[config].[GetCdotDataSP]", parameters, BaseClass.TypeDataSet);


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                //MessageBox.Show($"Error loading CDOT configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataSet;
            }

            return dataSet;
        }


        public static void InsertCdotInfo(string identifier, int fkeyAlerturl, string language, string category, string XMLevent, string responseType, string urgency, string severity, string certainty, string audience, string effective, string expires, string headline, string description, string instruction, string web, string contact, string infoId, string alertId)
        {
            DataSet dataSet = new DataSet();
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@identifier", identifier),
                new SqlParameter("@Fkey_AlertUrl", fkeyAlerturl),
                new SqlParameter("@language", language),
                new SqlParameter("@category", category),
                new SqlParameter("@event", XMLevent),
                new SqlParameter("@responseType", responseType),
                new SqlParameter("@urgency", urgency),
                new SqlParameter("@severity", severity),
                new SqlParameter("@certainty", certainty),
                new SqlParameter("@audience", audience),
                new SqlParameter("@effective", effective),
                new SqlParameter("@expires", expires),
                new SqlParameter("@headline", headline),
                new SqlParameter("@description", description),
                new SqlParameter("@instruction", instruction),
                new SqlParameter("@web", web),
                new SqlParameter("@contact", contact),
                new SqlParameter("@info_Id", infoId),
                new SqlParameter("@alert_Id", alertId)
            };
                dataSet = (DataSet)DbConnection.ExecuteSps("[Config].[InsertCdotInfo]", parameters, BaseClass.TypeDataSet);


            }
            catch (SqlException sqlEx)
            {
                sqlEx.ToString();
                // Log SQL-specific exceptions
                // Errorlog(sqlEx.ToString(), "Error inserting/updating Cdot Info");
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
                // Log general exceptions
                // Errorlog(ex.ToString(), "Error inserting/updating Cdot Info");
            }
        }

        public static void InsertCdotAlert(string identifier, string sender, string sent, string status, string msgType, string source, string scope, string restriction, string address, string note, string incidents, string alert_Id)
        {
            int rowsAffected = 0; // Initialize rowsAffected to capture any result
            try
            {
                var parameters = new List<SqlParameter>
                {
                 new SqlParameter("@identifier", identifier),
                 new SqlParameter("@sender", sender),
                 new SqlParameter("@sent", sent),
                 new SqlParameter("@status", status),
                 new SqlParameter("@msgType", msgType),
                 new SqlParameter("@source", source),
                 new SqlParameter("@scope", scope),
                 new SqlParameter("@restriction", restriction),
                 new SqlParameter("@address", address),
                 new SqlParameter("@note", note),
                 new SqlParameter("@incidents", incidents),
                 new SqlParameter("@alert_Id", alert_Id)
            };
                var returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                parameters.Add(returnParameter);
                rowsAffected = (int)DbConnection.ExecuteSps("[Config].[InsertCdotAlert]", parameters, BaseClass.TypeInt);

            }
            catch (SqlException sqlEx)
            {
                Server.LogError(sqlEx.ToString());
                sqlEx.ToString();

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();

            }
        }
        public static DataSet UpdateCdotMsgTime(string identifier, DateTime tme, int Type)
        {
            DataSet dataSet = new DataSet();
            try
            {

                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@identifier",identifier ),
                new SqlParameter("@tme",tme),
                new SqlParameter("@Type", Type)
                };
                dataSet = (DataSet)DbConnection.ExecuteSps("[Config].[UpdateCdotMsgTime]", parameters, BaseClass.TypeDataSet);

                return dataSet;


            }
            catch (SqlException sqlEx)
            {
                sqlEx.ToString();

                return null;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());



                return null;
            }
        }
        public static DataSet UpdateCdotDataAudiocount(int id, string identifier)
        {
            DataSet dataSet = new DataSet();
            try
            {
                var parameters = new List<SqlParameter>
                {
                 new SqlParameter("@identifier",identifier),
                 new SqlParameter("@id",id)

                };
                dataSet = (DataSet)DbConnection.ExecuteSps("[Config].[UpdateCdotAudioDatacount]", parameters, BaseClass.TypeDataSet);

                return dataSet;

            }
            catch (SqlException sqlEx)
            {
                sqlEx.ToString();

                return null;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();

                return null;
            }
        }

        public static DataSet GetCdotInfodata(string URI)
        {
            DataSet dataSet = new DataSet();
            try
            {

                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@identifier", SqlDbType.Text)
                {
                   Value = string.IsNullOrEmpty(URI) ? DBNull.Value : (object)URI
                }

                };
                dataSet = (DataSet)DbConnection.ExecuteSps("[Config].[GetCdotInfoData]", parameters, BaseClass.TypeDataSet);

                return dataSet;

            }
            catch (SqlException sqlEx)
            {
                Server.LogError(sqlEx.ToString());

                return null;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());


                return null;
            }
        }



        public static DataSet GetCdotIdentifierStr(string identifier)
        {
            DataSet dataSet = new DataSet(); // Create a DataSet to hold multiple tables

            try
            {

                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@identifier", SqlDbType.VarChar, 50)
                {
                 Value = identifier ?? (object)DBNull.Value
                }

                };
                dataSet = (DataSet)DbConnection.ExecuteSps("[Config].[SelectCdotInfo]", parameters, BaseClass.TypeDataSet);

                return dataSet;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

                return null;
            }

            return dataSet;
        }
        public static void UpdateCdotInfo(string identifier, string resourceDesc, string mimeType, int size, string uri, string derefUri, string areaDesc, string digest, string audiourl, string CapXmlStatus)
        {

            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@identifier", identifier),
                new SqlParameter("@resourceDesc", resourceDesc),
                new SqlParameter("@mimeType", mimeType),
                new SqlParameter("@size", size),
                new SqlParameter("@uri", uri),
                new SqlParameter("@derefUri", derefUri),
                new SqlParameter("@areaDesc", areaDesc),
                new SqlParameter("@digest", digest),
                new SqlParameter("@AudioUrl", audiourl),
                new SqlParameter("@CapXmlStatus", CapXmlStatus)

                };

                int result = (int)DbConnection.ExecuteSps("[Config].[UpdateCdotInfo]", parameters, BaseClass.TypeInt);

            }
            catch (SqlException sqlEx)
            {
                Server.LogError(sqlEx.ToString());
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());


            }
        }
        public static void InsertCdotAlertReports(string identifier)
        {
            DataSet dataSet = new DataSet();
            try
            {

                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@identifier", identifier)

                };
                dataSet = (DataSet)DbConnection.ExecuteSps("[Reports].[InsertCdotAlertReportsSP]", parameters, BaseClass.TypeDataSet);

            }
            catch (SqlException sqlEx)
            {
                Server.LogError(sqlEx.ToString());
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
        }
        public static string InsertintoSendMessages(string identifier, int? id = null)
        {

            string statusMessage = string.Empty;

            try
            {

                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@identifier", string.IsNullOrEmpty(identifier) ? (object)DBNull.Value : identifier),
            new SqlParameter("@id", id.HasValue ? (object)id.Value : DBNull.Value)
        };


                SqlParameter statusMessageParam = new SqlParameter("@statusMessage", SqlDbType.NVarChar, 255)
                {
                    Direction = ParameterDirection.Output
                };


                parameters.Add(statusMessageParam);


                statusMessage = (string)DbConnection.ExecuteSps("[config].[InsertintoCdotSendMessages]", parameters, BaseClass.TypeString);


                statusMessage = statusMessageParam.Value?.ToString();
            }
            catch (SqlException sqlEx)
            {
                Server.LogError(sqlEx.ToString());
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }

            return statusMessage;


        }


        public static DataSet GetCdotsenddata(string identifier)
        {
            DataSet dataSet = new DataSet();
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@identifier", identifier)


                };
                dataSet = (DataSet)DbConnection.ExecuteSps("[Config].[GetCdotSendData]", parameters, BaseClass.TypeDataSet);
                return dataSet;

            }
            catch (SqlException sqlEx)
            {
                sqlEx.ToString();

                return null;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();

                return null;
            }
        }

        public static DataSet GetCdoturl(string identifier)
        {
            DataSet dataSet = new DataSet();
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@identifier", identifier)

                };
                dataSet = (DataSet)DbConnection.ExecuteSps("[config].[GetCdotAlertUrl]", parameters, BaseClass.TypeDataSet);
                return dataSet;

            }
            catch (SqlException sqlEx)
            {
                sqlEx.ToString();

                return null;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();

                return null;
            }
        }
        public static void CDotUpdate(string identifier)
        {
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@SendData", true),
                new SqlParameter("@Tme", DateTime.Today),
                new SqlParameter("@identifier", identifier )
                };
                int result = (int)DbConnection.ExecuteSps("Config.InsertCdotSendData", parameters, BaseClass.TypeInt);

            }
            catch (SqlException sqlEx)
            {
                Server.LogError(sqlEx.ToString());

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());


            }
        }


        public static bool CheckCdotdissmentation(string identifier)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(identifier))
                    throw new ArgumentException("Identifier cannot be null or empty.", nameof(identifier));


                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@identifier", SqlDbType.Text) { Value = identifier }
        };


                DataSet ds = (DataSet)DbConnection.ExecuteSps("Config.GetCdotInfoData", parameters, BaseClass.TypeDataSet);


                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    string expiresStr = ds.Tables[0].Rows[0]["expires"]?.ToString()?.Replace("'", "");


                    if (DateTime.TryParse(expiresStr, out DateTime expiresDateTime))
                    {

                        return DateTime.Now > expiresDateTime;
                    }
                }


                return false;
            }
            catch (Exception ex)
            {

                Server.LogError($"Error in CheckCdotDissmentation: {ex}");
                return false;
            }
        }

        //public static bool CheckCdotdissmentation(string identifier)
        //{
        //    try
        //    {
        //        using (var connection = DbConnection.OpenConnection()) // Open connection using your custom DbConnection class
        //        {
        //            if (connection == null)
        //                throw new InvalidOperationException("Failed to open database connection.");

        //            using (var command = new SqlCommand("Config.GetCdotInfoData", connection))
        //            {
        //                command.CommandType = CommandType.StoredProcedure;

        //                // Set up parameters
        //                var parameters = new SqlParameter[1];
        //                parameters[0] = new SqlParameter("@identifier", SqlDbType.Text) { Value = identifier };
        //                command.Parameters.AddRange(parameters);

        //                // Execute the command and fill a dataset
        //                using (var adapter = new SqlDataAdapter(command))
        //                {
        //                    var ds = new DataSet();
        //                    adapter.Fill(ds);

        //                    // Check if any data is returned
        //                    if (ds.Tables[0].Rows.Count > 0)
        //                    {
        //                        string expiresStr = ds.Tables[0].Rows[0]["expires"].ToString().Replace("'", "");

        //                        // Try to parse the expiration date
        //                        if (DateTime.TryParse(expiresStr, out DateTime expiresDateTime))
        //                        {
        //                            // Compare current time with expiration time
        //                            return DateTime.Now > expiresDateTime;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        // Return false if no rows or invalid datetime format
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //        // Log the exception if needed
        //        // ErrorLog(ex.ToString(), "CheckCdotDissmentation");
        //        return false;
        //    }
        //}
        public static DataSet PlayAnnouncemnet(DataTable announce, int scrollToTexts, string annData)
        {
            try
            {
                // Set up parameters for the stored procedure
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@AudioPaths", SqlDbType.Structured) { Value = announce },
            new SqlParameter("@AnnRepeatCount", SqlDbType.Int) { Value = scrollToTexts },
            new SqlParameter("@AnnData", SqlDbType.VarChar) { Value = annData }
        };

                // Execute the stored procedure and retrieve the DataSet
                DataSet dataSet = (DataSet)DbConnection.ExecuteSps("Scheduled.insertPlay", parameters, BaseClass.TypeDataSet);

                // Convert the DataSet to JSON (optional)
                string convertedData = JsonConvert.SerializeObject(dataSet);

                // Perform an API call using WebClient
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadData("http://127.0.0.1:8080/api/PlayAudio");
                }

                // Return the DataSet
                return dataSet;
            }
            catch (Exception ex)
            {
                // Log the error and return null
                Server.LogError(ex.ToString());
                return null;
            }
        }

        //public static DataSet PlayAnnouncemnet(DataTable Announce, int ScrollToTexts, string AnnData)
        //{

        //    //DataSet dataSet = new DataSet();
        //    try
        //    {

        //        using (var connection = DbConnection.OpenConnection())
        //        {
        //            if (connection == null)
        //                throw new InvalidOperationException("Failed to open database connection.");

        //            // Step 2: Create and set up the SqlCommand object
        //            using (var command = new SqlCommand("Scheduled.insertPlay", connection))
        //            {
        //                command.CommandType = CommandType.StoredProcedure;

        //                // Step 3: Add parameters for the stored procedure
        //                command.Parameters.Add(new SqlParameter("@AudioPaths", SqlDbType.Structured) { Value = Announce });
        //                command.Parameters.Add(new SqlParameter("@AnnRepeatCount", SqlDbType.Int) { Value = ScrollToTexts });
        //                command.Parameters.Add(new SqlParameter("@AnnData", SqlDbType.VarChar) { Value = AnnData });

        //                // Step 4: Execute the stored procedure and fill the DataSet
        //                var dt = new DataSet();
        //                using (var adapter = new SqlDataAdapter(command))
        //                {
        //                    adapter.Fill(dt);
        //                }

        //                // Step 5: Convert DataSet to JSON (if needed)
        //                var convertedData = JsonConvert.SerializeObject(dt);

        //                // Step 6: Perform API call using WebClient
        //                using (WebClient wcs = new WebClient())
        //                {
        //                    // This sends the request to the API endpoint
        //                    wcs.DownloadData("http://127.0.0.1:8080/api/PlayAudio");
        //                }

        //                // Return the DataSet from the stored procedure
        //                return dt;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();

        //        return null;
        //    }
        //}
        public static DataSet GetCdotInfo()
        {
            DataSet dataSet = new DataSet();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                dataSet = (DataSet)DbConnection.ExecuteSps("[Config].[GetCdotData]", parameters, BaseClass.TypeDataSet);

                return dataSet;
            }

            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

                return null;
            }
        }
        public static DataSet DeleteCdotAlertData(string cdotIdentifier)
        {
            DataSet dataSet = new DataSet();
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@identifier", cdotIdentifier)

                };
                dataSet = (DataSet)DbConnection.ExecuteSps("[Config].[DeleteCdotAlert]", parameters, BaseClass.TypeDataSet);

                return dataSet;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

                return null;
            }
        }
        public static void InsertPauseCdotAlertData(int pausetime)
        {
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@PauseMin", pausetime)
                };
                int result = (int)DbConnection.ExecuteSps("[Reports].[InsertPauseReportDataSP]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
        }

        public static void DeleteCdotSendMessages()
        {
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                int result = (int)DbConnection.ExecuteSps("[config].[DeleteAllCdotSendMessages]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

        }

        public static void insertAfterPauseCdotSendMessages()
        {
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                int result = (int)DbConnection.ExecuteSps("[config].InsertintoPauseCdotSendMessages", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }




        }

        public static int InsertUpdateIntegration(int? ipisType, bool? trainData, bool? coachData, bool? messageData, string platformNames, string textFilePath)
        {
            int result = -1;

            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@Front_Back", (object)ipisType ?? DBNull.Value),
                new SqlParameter("@TrainData", (object)trainData ?? DBNull.Value),
                new SqlParameter("@Coachdata", (object)coachData ?? DBNull.Value),
                new SqlParameter("@MessageData", (object)messageData ?? DBNull.Value),
                new SqlParameter("@Platformnames", (object)platformNames ?? DBNull.Value),
                new SqlParameter("@TextFilePath", (object)textFilePath ?? DBNull.Value)


            };

                result = (int)DbConnection.ExecuteSps("[Config].[InsertOrUpdateIntegration]", parameters, BaseClass.TypeInt);

            }
            catch (SqlException sqlEx)
            {
                Server.LogError(sqlEx.ToString());
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());


            }
            return result;
        }


        public static DataTable GetIntegration()
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Config].[GetIntegration]", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;
        }
    }
}
