using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class ReportDb
    {

        public static void InsertDataLogReport(string BoardName, string functionCode, string status)
        {
            try
            {
                var parameters = new List<SqlParameter>
                {
                  new SqlParameter("@BoardName", BoardName),
                  new SqlParameter("@FunctionCode ", functionCode),
                  new SqlParameter("@Status", status)
                };
                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertDataLogReportSP]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());

            }
        }
        public static void InsertTaddbDataReport(string TrainNo, string TrainNameEng, string RArrivalTime, string RDepartureTime, string ArrivingStatus, string StatusName, string LateBy, string LArrivalTime, string LDepartureTime, string PlatformName, string EStation, string HStation, string RStation, string CoachePos, string Terminate_Diverted, string BoardId)
        {
            try
            {
                var parameters = new List<SqlParameter>
                {
                  new SqlParameter("@TrainNo", TrainNo),
                  new SqlParameter("@Name", TrainNameEng),
                  new SqlParameter("@RArrivalTime", RArrivalTime),
                   new SqlParameter("@RDepartureTime", RDepartureTime),
                  new SqlParameter("@ArrivingStatus", ArrivingStatus),
                  new SqlParameter("@StatusName", StatusName),

                new SqlParameter("@LateBy", LateBy),
                new SqlParameter("@LArrivalTime", LArrivalTime),
                new SqlParameter("@LDepartureTime", LDepartureTime),
                new SqlParameter("@PlatformName", PlatformName),
                new SqlParameter("@EStation", EStation),
                new SqlParameter("@HStation", HStation),
                new SqlParameter("@RStation", RStation),
                new SqlParameter("@CoachePos", CoachePos),
                new SqlParameter("@Terminate_Diverted", Terminate_Diverted),
                new SqlParameter("@BoardID", BoardId)

            };


                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertTaddbReportSP]", parameters, BaseClass.TypeInt);




            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
        }

        public static void InsertDatabaseModificationReportData(string Message, string TypeId)
        {


            try
            {
                var parameters = new List<SqlParameter>
                {
                        new SqlParameter("@UserName", BaseClass.UserName),
                        new SqlParameter("@Description", Message),
                        new SqlParameter("@Type",TypeId)
                };
                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertDataBaseModificationReportSP]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());

            }



        }

        public static void InsertTruecolorAgdb(string Boardip, bool truecolorstatus)
        {


            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@UserName", Boardip),
                        new SqlParameter("@Description", truecolorstatus)
                };
                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertDataBaseModificationReportSP]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());

            }



        }

        public static void InsertAgdbDataReport(string TrainNo, string TrainNameEng, string RArrivalTime, string RDepartureTime, string ArrivingStatus, string StatusName, string LateBy, string LArrivalTime, string LDepartureTime, string PlatformName, string EStation, string HStation, string RStation, string CoachePos, string Terminate_Diverted, string BoardId)
        {

            try
            {
                var parameters = new List<SqlParameter>
                {
                  new SqlParameter("@TrainNo", TrainNo),
                       new SqlParameter("@Name", TrainNameEng),
                        new SqlParameter("@RArrivalTime", RArrivalTime),
                        new SqlParameter("@RDepartureTime", RDepartureTime),
                        new SqlParameter("@ArrivingStatus", ArrivingStatus),
                        new SqlParameter("@StatusName", StatusName),
                        new SqlParameter("@LateBy", LateBy),
                        new SqlParameter("@LArrivalTime", LArrivalTime),
                        new SqlParameter("@LDepartureTime", LDepartureTime),
                        new SqlParameter("@PlatformName", PlatformName),
                        new SqlParameter("@EStation", EStation),
                        new SqlParameter("@HStation", HStation),
                       new SqlParameter("@RStation", RStation),
                        new SqlParameter("@CoachePos", CoachePos),
                       new SqlParameter("@Terminate_Diverted", Terminate_Diverted),
                       new SqlParameter("@BoardID", BoardId)
                };
                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertAGDBReportSP]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());

            }
        }
        public static void InsertCgdbDataReport(string TrainNo, string TrainNameEng, string RArrivalTime, string RDepartureTime, string ArrivingStatus, string LateBy, string PlatformName, string CoachePos, string BoardId)
        {

            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@TrainNo", TrainNo),
                         new SqlParameter("@Name", TrainNameEng),
                         new SqlParameter("@RArrivalTime", RArrivalTime),
                        new SqlParameter("@RDepartureTime", RDepartureTime),
                         new SqlParameter("@ArrivingStatus", ArrivingStatus),

                         new SqlParameter("@LateBy", LateBy),

                        new SqlParameter("@PFNO", PlatformName),

                        new SqlParameter("@CoachePos", CoachePos),
                       new SqlParameter("@BoardID", BoardId)
                };
                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertCGDBReportSP]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());

            }
        }

        public static void InsertIVDDataReport(string TrainNo, string TrainNameEng, string RArrivalTime, string RDepartureTime, string ArrivingStatus, string StatusName, string LateBy, string LArrivalTime, string LDepartureTime, string PlatformName, string EStation, string HStation, string RStation, string CoachePos, string Terminate_Diverted, string BoardId)
        {


            try
            {
                var parameters = new List<SqlParameter>
                {
                          new SqlParameter("@TrainNo", TrainNo),
                         new SqlParameter("@Name", TrainNameEng),
                         new SqlParameter("@RArrivalTime", RArrivalTime),
                        new SqlParameter("@RDepartureTime", RDepartureTime),
                         new SqlParameter("@ArrivingStatus", ArrivingStatus),
                         new SqlParameter("@StatusName", StatusName),
                         new SqlParameter("@LateBy", LateBy),
                         new SqlParameter("@LArrivalTime", LArrivalTime),
                         new SqlParameter("@LDepartureTime", LDepartureTime),
                         new SqlParameter("@PlatformName", PlatformName),
                         new SqlParameter("@EStation", EStation),
                        new SqlParameter("@HStation", HStation),
                         new SqlParameter("@RStation", RStation),
                         new SqlParameter("@CoachePos", CoachePos),
                         new SqlParameter("@Terminate_Diverted", Terminate_Diverted),
                        new SqlParameter("@BoardID", BoardId)
                };
                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertIVDReportSP]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());

            }


        }

        public static void InsertOVDDataReport(string TrainNo, string TrainNameEng, string RArrivalTime, string RDepartureTime, string ArrivingStatus, string StatusName, string LateBy, string LArrivalTime, string LDepartureTime, string PlatformName, string EStation, string HStation, string RStation, string CoachePos, string Terminate_Diverted, string BoardId)
        {


            try
            {
                var parameters = new List<SqlParameter>
                {
                              new SqlParameter("@TrainNo", TrainNo),
                        new SqlParameter("@Name", TrainNameEng),
                        new SqlParameter("@RArrivalTime", RArrivalTime),
                        new SqlParameter("@RDepartureTime", RDepartureTime),
                        new SqlParameter("@ArrivingStatus", ArrivingStatus),
                        new SqlParameter("@StatusName", StatusName),
                       new SqlParameter("@LateBy", LateBy),
                      new SqlParameter("@LArrivalTime", LArrivalTime),
                       new SqlParameter("@LDepartureTime", LDepartureTime),
                        new SqlParameter("@PlatformName", PlatformName),
                        new SqlParameter("@EStation", EStation),
                       new SqlParameter("@HStation", HStation),
                        new SqlParameter("@RStation", RStation),
                        new SqlParameter("@CoachePos", CoachePos),
                       new SqlParameter("@Terminate_Diverted", Terminate_Diverted),
                        new SqlParameter("@BoardID", BoardId)
                };
                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertOVDReportSP]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());

            }
        }
        public static void InsertCGDBDataReport()
        {
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertTaddbReportSP]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());

            }

        }


        public static void InsertPlatformChangeReportData(string platformNumber, string trainNo)
        {


            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@TrainNo", trainNo),
                        new SqlParameter("@PlatformNo", platformNumber)
                };
                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertPlatformChangeReportSP]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());

            }



        }


        public static void ApplogInReport(int userid, string LoginUser)
        {

            try
            {
                // Define parameters
                var parameters = new List<SqlParameter>
                {
                  new SqlParameter("@UserId", userid),
                  new SqlParameter("@UserLogin", LoginUser),
                };
                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertAppLoginInfoSP]", parameters, BaseClass.TypeInt);


            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            //try
            //{


            //    using (SqlConnection connection = DbConnection.OpenConnection())
            //    {
            //        using (SqlCommand command = new SqlCommand("[Reports].[InsertAppLoginInfoSP]", connection))
            //        {
            //            command.CommandType = CommandType.StoredProcedure;
            //            command.Parameters.AddWithValue("@UserId", userid);
            //            command.Parameters.AddWithValue("@UserLogin", LoginUser);
            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}
        }




        public static void ApplogOffReport()
        {
            try
            {
                // Define parameters
                var parameters = new List<SqlParameter> { };

                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertAppLogOffInfoSP]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }


        public static void InsertLinkCheckLog(string BoardIP, string commandName, bool status)
        {

            try
            {
                // Define parameters
                var parameters = new List<SqlParameter> {
                  new SqlParameter("@Ipaddress", BoardIP),
                            new SqlParameter("@CommandName", commandName),
                        new SqlParameter("@Status", status)};

                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertLinkCheckReportSP]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }


        public static void InsertErrorLog(string Error, string ErDescription)
        {

            try
            {
                // Define parameters
                var parameters = new List<SqlParameter> {
                        new SqlParameter("@Error", Error),
                        new SqlParameter("@ErrorDesc", ErDescription)

                };

                int Result = (int)DbConnection.ExecuteSps("[Reports].[EnterErrorLog]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        public static void InsertPauseCdotReport(string identifier, int pauseMin)
        {


            try
            {
                // Define parameters
                var parameters = new List<SqlParameter> {
                              new SqlParameter("@identifier", identifier),
                       new SqlParameter("@PauseMin", pauseMin)
                };

                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertPauseReportDataSP]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }




        }

        public static void InsertCdotAlertReport(string identifier)
        {


            try
            {
                // Define parameters
                var parameters = new List<SqlParameter> {
                          new SqlParameter("@identifier", identifier)
            };

                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertCdotAlertReportsSP]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        public static void InsertNtesDataReport(string TrainNo, string TrainName, string STA, string ETA, string delayArrival, string STD, string ETD, string delayDeparture, string Status, string CoachPos, string platformNo, string AD)
        {
            try
            {
                // Define parameters
                var parameters = new List<SqlParameter> {
                            new SqlParameter("@trainNo", TrainNo),
                        new SqlParameter("@trainName", TrainName),
                        new SqlParameter("@STA", STA),
                        new SqlParameter("@ETA", ETA),
                        new SqlParameter("@delayArr", delayArrival),
                        new SqlParameter("@STD", STD),
                        new SqlParameter("@ETD", ETD),
                        new SqlParameter("@delayDep", delayDeparture),
                       new SqlParameter("@trainStatus", Status),
                        new SqlParameter("@coachPosition", CoachPos),
                        new SqlParameter("@platformNo", platformNo),
                        new SqlParameter("@ADFlag", AD)
            };

                int Result = (int)DbConnection.ExecuteSps("[Reports].[InsertNtesDataReportSP]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        //public static void InsertCdotDataReport(string identifier, string category,string Event, string urgency,string severity, string certainty, string headline, string areaDesc, string audioUrl)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = DbConnection.OpenConnection())
        //        {
        //            using (SqlCommand command = new SqlCommand("[Reports].[InsertCdotDataReportSP]", connection))
        //            {
        //                command.CommandType = CommandType.StoredProcedure;
        //                command.Parameters.AddWithValue("@Identifier", identifier);
        //                command.Parameters.AddWithValue("@Category", category);
        //                command.Parameters.AddWithValue("@Event", Event);
        //                command.Parameters.AddWithValue("@Urgency", urgency);
        //                command.Parameters.AddWithValue("@Severity", severity);
        //                command.Parameters.AddWithValue("@Certainty", certainty);
        //                command.Parameters.AddWithValue("@Headline", headline);
        //                command.Parameters.AddWithValue("@AreaDesc", areaDesc);
        //                command.Parameters.AddWithValue("@AudioUrl", audioUrl);

        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred: " + ex.Message);
        //    }
        //}




    }
}
