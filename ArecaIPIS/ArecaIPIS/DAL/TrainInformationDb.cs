using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class TrainInformationDb
    {


        public TrainInformationDb()
        {

        }

        public static List<string> GetTrainTypes()
        {
            List<string> Result = new List<string>();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                Result = (List<string>)DbConnection.ExecuteSps("[config].[GetTrainTypes]", parameters, BaseClass.Type_List_String);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return Result; // Or rethrow the exception if preferred
            }
            return Result;
        }

        public static bool InsertUpdateTrainDetails(int id, string trainNumber, string trainType, string category, string source, string destination,
          string via, string englishName, string hindiName, string regionalName, string arrivalTime, string departureTime, string platform,
       string status, DataTable RunningTrainDirections, List<string> coachPositionList)
        {


            bool Result = false;
            string coachPositions = string.Join(",", coachPositionList);
            try
            {
                var parameters = new List<SqlParameter>
                {
                      new SqlParameter("@ID", id),
               new SqlParameter("@TrainNumber", trainNumber),
                new SqlParameter("@TrainType", trainType),
                new SqlParameter("@Category", category),
                new SqlParameter("@Source", source),
               new SqlParameter("@Destination", destination),
              new SqlParameter("@Via", via),
                 new SqlParameter("@EnglishName", englishName),
              new SqlParameter("@HindiName", hindiName),
                new SqlParameter("@RegionalName", regionalName),
                new SqlParameter("@ArrivalTime", arrivalTime),
                new SqlParameter("@DepartureTime", departureTime),
                new SqlParameter("@Platform", platform),
              new SqlParameter("@Status", status),
                new SqlParameter("@TrainInfo", RunningTrainDirections),
                new SqlParameter("@CoachPositions", coachPositions)

            };
                Result = (bool)DbConnection.ExecuteSps("[Config].[InsertUpdateTrainsInformationSp]", parameters, BaseClass.TypeBool);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return Result; // Or rethrow the exception if preferred
            }
            return Result;

        }

        public static int ClearTrainInformationTable()
        {

            int Result = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                Result = (int)DbConnection.ExecuteSps("[config].[ClearTrainInformationSp]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return Result; // Or rethrow the exception if preferred
            }
            return Result;


        }


    }
}
