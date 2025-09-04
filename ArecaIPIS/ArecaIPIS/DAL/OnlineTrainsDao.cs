using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace ArecaIPIS.DAL
{
    class OnlineTrainsDao
    {
        public static string GetORUpdateLastPollTime(string dateTime = null)
        {
            string LastPollTime = "";

            try
            {
                List<SqlParameter> parameters;

                if (dateTime == null)
                {
                    // No parameter: fetch last polling time
                    parameters = new List<SqlParameter>(); // Empty list
                }
                else
                {
                    // Update last polling time
                    parameters = new List<SqlParameter>
            {
                new SqlParameter("@LastPollingUpdatedTime", dateTime)
            };
                }

                object result = DbConnection.ExecuteSps("[config].[updateNtesPollingTiming]", parameters, BaseClass.TypeString);

                // If result is datetime, convert to string
                LastPollTime = result?.ToString();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }

            return LastPollTime;
        }


        public static int GetTopRegGapCode()
        {
            int regGapCode = 0; // Default or invalid value

            //try
            //{

            //    using (SqlConnection connection = DbConnection.OpenConnection())
            //    {
            //        SqlCommand command = new SqlCommand("GetTopRegGapCode", connection);
            //        command.CommandType = CommandType.StoredProcedure;



            //        // Execute the command
            //        SqlDataReader reader = command.ExecuteReader();

            //        if (reader.HasRows)
            //        {
            //            while (reader.Read())
            //            {
            //                regGapCode = Convert.ToInt32(reader["REG_GAPCODE"]);
            //            }
            //        }

            //        reader.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}


            try
            {
                var parameters = new List<SqlParameter>
                {




                };
                regGapCode = (int)DbConnection.ExecuteSps("GetTopRegGapCode", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


            return regGapCode;


        }
        public static bool InsertLinkedTrains(string trainNumber1, string trainNumber2)
        {
            bool result = false;
            try
            {

                var parameters = new List<SqlParameter>
                {
                  new SqlParameter("@LinkTrain1", trainNumber1),

                  new SqlParameter("@LinkTrain2", trainNumber2)

            };
                result = (bool)DbConnection.ExecuteSps("dbo.[InsertLinkTrainDataSP]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return result;


        }


        public static bool DeleteTrainByNumber(string trainNumber)
        {
            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>
                {
                  new SqlParameter("@TrainNumber", trainNumber)



            };
                result = (bool)DbConnection.ExecuteSps("config.[DeleteTrainByNumberFromTrainsSP]", parameters, BaseClass.TypeBool);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return result;


        }


        public static DataTable GetLinkedTrainsbycategory()
        {
            DataTable datatable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {




                };
                datatable = (DataTable)DbConnection.ExecuteSps("[config].[GetTrainNumbersByCategory]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return datatable;


        }
        public static DataTable GetLinkedTrainsDetails()
        {
            DataTable datatable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {




                };
                datatable = (DataTable)DbConnection.ExecuteSps("[config].[GetLinkedTrainDetails]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return datatable;


        }
        public static DataTable GetLinkedTrainsDetailsbyTrainNo(string trainno)
        {
            DataTable datatable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                      new SqlParameter("@TrainNo", trainno),
                };
                datatable = (DataTable)DbConnection.ExecuteSps("[config].[GetLinkedTrainDetailsByTrainNo]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return datatable;


        }

        public static DataTable GetLinkedTrains()
        {
            DataTable datatable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {




                };
                datatable = (DataTable)DbConnection.ExecuteSps("dbo.[GetLinkTrainsData]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return datatable;


        }
        public static List<int> getDefectiveLines(string BoardIp)
        {
            List<int> defectiveLines = new List<int>();
            try
            {
                DataTable specialSlogan = new DataTable();

                var parameters = new List<SqlParameter>
                    {

                    new SqlParameter("@DefectiveBoardIp", BoardIp),

                     };
                specialSlogan = (DataTable)DbConnection.ExecuteSps("[dbo].[GetDefectiveLinesByBoardIPSP]", parameters, BaseClass.TypeDataTable);


                foreach (DataRow row in specialSlogan.Rows)
                {
                    string[] Lines = row["DefectiveLines"].ToString().Trim().Split(',');
                    defectiveLines.AddRange(Array.ConvertAll(Lines, int.Parse));
                }
                defectiveLines.RemoveAll(x => x == 0);
                if (defectiveLines.Count > 0)
                    defectiveLines.Sort();
                return defectiveLines;
            }
            catch (Exception e)
            {
                return defectiveLines;
                Server.LogError(e.ToString());
            }
        }
        public static void InsertRefreshData()
        {

            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };

            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                DbConnection.ExecuteSps("[config].InsertRefreshDataSp", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

        }
        public static void InsertScheduledRefreshData()
        {
            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };

            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                DbConnection.ExecuteSps("[config].InsertScheduledRefreshDataSp", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
        }


        public static DataTable getTrainNumber(string searchQuery)
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                  new SqlParameter("@SearchQuery", searchQuery),



            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetTrainNumberSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;

        }



        public static DataTable UpdateDataTransferIp(string ipaddress, bool status)
        {



            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                    new SqlParameter("@ipAddress", ipaddress),
                new SqlParameter("@status", status)


            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[UpdateDataTransferSp]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;

        }

        public static DataTable UpdateLinkCheckIp(string ipaddress, bool status)
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                    new SqlParameter("@ipAddress", ipaddress),
                new SqlParameter("@status", status)


            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[UpdateLinkCheckSp]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;
        }


        public static string[] coachPositions(string trainNumber)
        {
            string[] coachValues = null;
            try
            {
                DataTable coachPositionsdt = OnlineTrainsDao.getTempCoachPositionsByTrainNumber(trainNumber);


                foreach (DataRow coachRow in coachPositionsdt.Rows)
                {
                    string coachpositions = coachRow["coachPositions"].ToString();
                    coachValues = coachpositions.Split(',');

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return coachValues;
        }

        public DataTable GetStatusByNameAndFor(string statusName, string statusFor)
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                    new SqlParameter("@StatusName", statusName),
                new SqlParameter("@StatusFor", statusFor)


            };
                dataTable = (DataTable)DbConnection.ExecuteSps("GetStatusTableByStatusNamesSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;

        }
        public static DataTable GetCdotMessagesList()
        {



            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].getListCdotMessagesSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;

        }




        public static DataTable GetDivertedToTerminatedStationsNames()
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[dbo].GetDivetedToTerminatedStationNamesSp", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;



        }



        public static DataTable GetAllIpAddress()
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[getAllIpAddressSp]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;

        }
        public static DataTable GetTopScheduledTaddbRecords()
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Scheduled].getScheduledRunningTrainsTADDBSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;
        }

        public static DataTable GetPlatformNumberSize()
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[dbo].[GetTopPlatformNumberSize]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;
        }


        public static void SendDataTOCCtv()
        {

            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            int rowsAffected = 0;

            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                rowsAffected = (int)DbConnection.ExecuteSps("[dbo].CopyDataFromScheduledTaddbToCCTVSP", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


        }


        public static void UpdateAnnToTrue()
        {

            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            int rowsAffected = 0;

            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].UpdateAnnToTrueSp", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

        }
        public static void UpdateDataTransferTofalse()
        {
            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            int rowsAffected = 0;

            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[UpdateDataTransferAllSp]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

        }
        public static DataTable GetScheduledTaddbTrains()
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[getScheduleTrainsTadbSp]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;

        }


        public static DataTable GetScheduledRefreshTaddbTrains()
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[getScheduleRefreshTrainsTadbSp]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;

        }
        public static DataTable GetScheduledCgdbTrains()
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[getScheduleTrainscgdbSp]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;



        }
        public static DataTable GetScheduledAnnouncementTrains()
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[getScheduleTrainsAnnouncementSp]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;


        }
        public static void DeleteTrainFromRunningTrains(string trainNumber)
        {

            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            int rowsAffected = 0;

            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@TrainNumber", trainNumber)
            };
                rowsAffected = (int)DbConnection.ExecuteSps("config.DeleteTrainFromRunningTrainsSP", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

        }

        public static void DeleteTrainFromRunningTrainsNtes(string trainNumber)
        {

            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            int rowsAffected = 0;

            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@TrainNumber", trainNumber)
            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[DeleteTrainByNumberfromScheduleTrains]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

        }

        public static void Deletescheduletadb()
        {


            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


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

            }


        }


        public static bool DeleteTrainByNumberinTempTrains(string trainNumber)
        {



            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            bool status = false;

            try
            {
                var parameters = new List<SqlParameter>
                {
                   new SqlParameter("@TrainNumber", trainNumber)
            };
                status = (bool)DbConnection.ExecuteSps("[Scheduled].[DeleteTempTrainByNumber]", parameters, BaseClass.TypeBool);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


            return status;



        }
        public static bool DeleteTrainNumberInTEMPANDScheduleTadb(string trainNumber)
        {



            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            bool status = false;

            try
            {
                var parameters = new List<SqlParameter>
                {
                   new SqlParameter("@TrainNumber", trainNumber)
            };
                status = (bool)DbConnection.ExecuteSps("[Scheduled].[DeleteTempTrainByNumber]", parameters, BaseClass.TypeBool);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


            return status;

        }


        public static DataTable GetArrivalAndDepartureStatus()
        {



            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetArrivalAndDepartureStatusSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;


        }

        public static int UpdateChanges(
     string trainNo, string ADStatus, string Tstatus, string delayArr, string eta, string etd,
     string platformNo, bool tadb, bool cgdb, bool ann, bool ntes, string city, string EStation, string HStation, string RStation)
        {
            int rowsAffected = 0;



            try
            {
                var parameters = new List<SqlParameter>
                {
                  new SqlParameter("@TrainNo", trainNo ?? (object)DBNull.Value),
                  new SqlParameter("@ADStatus", ADStatus ?? (object)DBNull.Value),
                new SqlParameter("@Tstatus", Tstatus ?? (object)DBNull.Value),
                new SqlParameter("@DelayArr", delayArr ?? (object)DBNull.Value),
                new SqlParameter("@ETA", eta ?? (object)DBNull.Value),
                new SqlParameter("@ETD", etd ?? (object)DBNull.Value),
                new SqlParameter("@PlatformNo", platformNo ?? (object)DBNull.Value),
                new SqlParameter("@TADB", tadb),
                new SqlParameter("@CGDB", cgdb),
                new SqlParameter("@Ann", ann),
                new SqlParameter("@NTES", ntes),
                new SqlParameter("@City", city ?? (object)DBNull.Value),
                new SqlParameter("@EStation", EStation ?? (object)DBNull.Value),
                new SqlParameter("@HStation", HStation ?? (object)DBNull.Value),
                new SqlParameter("@RStation", RStation ?? (object)DBNull.Value)
            };
                rowsAffected = (int)DbConnection.ExecuteSps("[Scheduled].[UpdateTrainSchedule]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return rowsAffected; // Or rethrow the exception if preferred
            }
            return rowsAffected;


        }

        public static bool InsertUpdateMainCoaches(string trainNumber, List<string> coachPositionList)
        {



            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            bool status = false;

            try
            {
                string coachPositions = string.Join(",", coachPositionList);
                var parameters = new List<SqlParameter>
                {

                   new SqlParameter("@TrainNumber", trainNumber),
                new SqlParameter("@coachPositions", coachPositions)

            };
                int rowsAffected = (int)DbConnection.ExecuteSps("[Scheduled].[InsertOrUpdateMainCoachPosition]", parameters, BaseClass.TypeInt);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


            return status;


        }
        public static bool InsertUpdateTempCoaches(string trainNumber, List<string> coachPositionList)
        {



            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            bool status = false;

            try
            {
                string coachPositions = string.Join(",", coachPositionList);
                var parameters = new List<SqlParameter>
                {

                   new SqlParameter("@TrainNumber", trainNumber),
                new SqlParameter("@coachPositions", coachPositions)

            };
                int rowsAffected = (int)DbConnection.ExecuteSps("[Scheduled].[InsertOrUpdateTempCoachPosition]", parameters, BaseClass.TypeInt);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


            return status;


        }

        public static bool InsertTempTrains(string trainNumber)
        {


            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            bool status = false;

            try
            {

                var parameters = new List<SqlParameter>
                {

                   new SqlParameter("@TrainNumber", trainNumber)


            };
                int rowsAffected = (int)DbConnection.ExecuteSps("[Scheduled].[InsertTempTrain]", parameters, BaseClass.TypeInt);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


            return status;

        }
        public static void DeleteAllMessages()
        {

            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                { };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[DeleteAllFromSendSpecialMessagesSp]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
        }

        public static void InsertCCTVMessages(string englishMsg, string nationalMsg, string regionalMsg1)
        {

            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
               new SqlParameter("@Englishmsg", englishMsg),
                new SqlParameter("@NationalMsg", nationalMsg),
                new SqlParameter("@RegionalMsg1", regionalMsg1)


            };
                rowsAffected = (int)DbConnection.ExecuteSps("config.InsertCCTVMessagesSp", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }



        }


        public static DataTable GetAllTempTrains()
        {



            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Scheduled].[GetTop1000TempTrains]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;


        }

        public static bool InsertUpdateTrainCoaches(string trainNumber, List<string> coachPositionList)
        {

            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            bool status = false;

            try
            {
                string coachPositions = string.Join(",", coachPositionList);
                var parameters = new List<SqlParameter>
                {

                  new SqlParameter("@TrainNumber", trainNumber),

                new SqlParameter("@CoachPositions", coachPositions)

            };
                int rowsAffected = (int)DbConnection.ExecuteSps("[Config].[InsertUpdateCoachPostionsSp]", parameters, BaseClass.TypeInt);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


            return status;


        }
        public static bool InsertUpdateLinkedTrains(string trainNumber, string Linkedtrain)
        {

            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            bool status = false;

            try
            {

                var parameters = new List<SqlParameter>
                {

                  new SqlParameter("@TrainNo", trainNumber),

                new SqlParameter("@LinkedTrainNo", Linkedtrain)

            };
                int rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertOrUpdateLinkedTrainDetails]", parameters, BaseClass.TypeInt);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


            return status;


        }


        public static bool InsertUpdateLinkedTrainsCoaches(string trainNumber, List<string> coachPositionList)
        {

            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            bool status = false;

            try
            {
                string coachPositions = string.Join(",", coachPositionList);
                var parameters = new List<SqlParameter>
                {

                  new SqlParameter("@TrainNumber", trainNumber),

                new SqlParameter("@coachPositions", coachPositions)

            };
                int rowsAffected = (int)DbConnection.ExecuteSps("[Scheduled].[InsertOrUpdateTempLinkedTrainsCoachPositions]", parameters, BaseClass.TypeInt);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


            return status;


        }

        public static bool InsertUpdateTrainDetails(int id, string trainNumber, string trainType, string category, string source, string destination,
            string via, string englishName, string hindiName, string regionalName, string arrivalTime, string departureTime, string platform,
         string status, DataTable RunningTrainDirections, List<string> coachPositionList)
        {


            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            bool restatus = false;

            try
            {

                string coachPositions = string.Join(",", coachPositionList);
                var parameters = new List<SqlParameter>
                {

                 // Create and add parameters to the command
                         new SqlParameter("@ID", id),
                new SqlParameter("@TrainNumber", trainNumber),
                new SqlParameter("@TrainType", trainType),
                new SqlParameter("@Category", category),
                new SqlParameter("@Source", source.ToUpper()),
                new SqlParameter("@Destination", destination.ToUpper()),
                new SqlParameter("@Via", via.ToUpper()),
                new SqlParameter("@EnglishName", englishName.ToUpper()),
                new SqlParameter("@HindiName", hindiName),
                new SqlParameter("@RegionalName", regionalName),
                new SqlParameter("@ArrivalTime", arrivalTime),
                new SqlParameter("@DepartureTime", departureTime),
                new SqlParameter("@Platform", platform),
                new SqlParameter("@Status", status),
                new SqlParameter("@TrainInfo", RunningTrainDirections),
               new SqlParameter("@CoachPositions", coachPositions.ToUpper())



            };
                int rowsAffected = (int)DbConnection.ExecuteSps("[Config].[InsertUpdateTrainsInformationSp]", parameters, BaseClass.TypeInt);
                return rowsAffected >= 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


            return restatus;


        }

        private static DataTable ConvertListToDataTable(List<string> coachPositionList)
        {


            DataTable dt = new DataTable();

            try
            {

                dt.Columns.Add("CoachPosition", typeof(string));

                foreach (string coach in coachPositionList)
                {
                    dt.Rows.Add(coach);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dt;
        }


        public static bool CheckTrainExisted(string trainNumber)
        {


            try
            {
                using (SqlConnection connection = DbConnection.OpenConnection())
                {
                    string query = "SELECT COUNT(1) FROM [config].[TrainDetails] WHERE TrainNumber = @TrainNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainNumber", trainNumber);


                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return false;
        }

        public static bool DeleteTrainDetails(string trainID)
        {


            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            bool status = false;

            try
            {

                var parameters = new List<SqlParameter>
                {



                new SqlParameter("@TrainID", trainID)

            };
                int rowsAffected = (int)DbConnection.ExecuteSps("[config].[DeleteTrainInformationSp]", parameters, BaseClass.TypeInt);
                return rowsAffected >= 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


            return status;




        }
        public static DataTable GetTrainByNumber(string trainNumber)
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@TrainNumber", trainNumber)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetTrainByNumberSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;
        }

        public static DataTable GetTrainDetails(string trainNumber)
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@TrainNumber", trainNumber)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetTrainPlatformAndStatus]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;
        }


        public static DataTable GetTrainByTrainDirtections(string trainNumber)
        {



            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@TrainNumber", trainNumber)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetTrainDirectionsByTrainNumberSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
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

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;



        }

        public static DataTable GetTrains()
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {


                };
                dataTable = (DataTable)DbConnection.ExecuteSps("GetTrainsSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;



        }

        public static DataTable getCoachPositionsByTrainNumber(string trainNumber)
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@TrainNumber", trainNumber)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetCoachPositionsByTrainNumberSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;



        }

        public static DataTable getTempCoachPositionsByTrainNumber(string trainNumber)
        {



            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@TrainNo", trainNumber)

            };
                if (BaseClass.IsNtesEnabled())
                {
                    dataTable = (DataTable)DbConnection.ExecuteSps("[Scheduled].[GetTempCoachesByTrainNumberSp]", parameters, BaseClass.TypeDataTable);
                }
                else
                {
                    dataTable = (DataTable)DbConnection.ExecuteSps("[Scheduled].[GetMainCoachesByTrainNumberSp]", parameters, BaseClass.TypeDataTable);
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;


        }
        public static DataTable getLinkedTempCoachPositionsByTrainNumber(string trainNumber)
        {



            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@TrainNumber", trainNumber)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Scheduled].[GetTempLinkedTrainsCoachPositions]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;


        }


        public static DataTable GetStatusByName(string statusName)
        {



            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@StatusName", statusName)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Scheduled].[GetStatusByNameSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;

        }


        public static DataTable GetAllStatus()
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {


                };
                dataTable = (DataTable)DbConnection.ExecuteSps("GetAllStatusSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;
        }
        public static DataTable SendToAnnouncement(string trainNo)
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                     new SqlParameter("@TrainNo", trainNo)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetScheduledAudioFormatsSPtrying]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;

        }



        public static DataTable PlayAnnouncemnet(DataTable Announce, int repeat, string trainNo)
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@AudioPaths", Announce),
                new SqlParameter("@AnnRepeatCount", repeat),
                new SqlParameter("@AnnData", trainNo),

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Scheduled].[insertPlaySP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable;
            }
            return dataTable;

        }




        public static bool UpdateAudioPlayStatus(string action)
        {

            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            int rowsAffected = 0;

            try
            {
                var parameters = new List<SqlParameter>
                {
                      new SqlParameter("@Status", action),


                 };
                rowsAffected = (int)DbConnection.ExecuteSps("Scheduled.SetAnnCompleted", parameters, BaseClass.TypeInt);
                if (rowsAffected >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return false;
            }

        }
        public static DataTable getUpdatedStatus(string status)
        {



            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                     new SqlParameter("@PlayStatus", status)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("Config.UpdateAnnouncementStatus", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;

        }



        public static DataTable GetTrainUpDownStatus(string trainNo)
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                     new SqlParameter("@TrainNo", trainNo)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Scheduled].[GetUPDOWNStatusSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;



        }

    }
}
