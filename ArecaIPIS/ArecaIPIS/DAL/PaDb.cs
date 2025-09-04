using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace ArecaIPIS.DAL
{
    class PaDb
    {
        public DataTable GetAllMessageStatus()
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Config].[Get_STATUS_DROPDOWN_MESSAGES_SP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;

        }
        public DataTable GetPlatforms()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Config].[GetPlatformsSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;


        }
        public DataTable PlayTrainInfo(int Status, int Position)
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@Status", Status),
                new SqlParameter("@Position", Position)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetMessagescript]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;


        }


        public DataTable GetTrainUpDownStatus(string trainNum)
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                       new SqlParameter("@TrainNo", trainNum)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Scheduled].[GetUPDOWNStatus]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;

        }

        public DataTable ValidateCoachId(string TrainNum, string coachid)
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@TrainNo", TrainNum),
                new SqlParameter("@CoachePos", coachid)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[CheckCoachIdAvail]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;
        }

        public DataTable ValidateTrainNo()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[CheckTrainNumAvail]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;
        }




        public DataTable PlayMsgAnnouncemnet(DataTable Announce, int repeat)
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@AudioPaths", Announce),
                new SqlParameter("@AnnRepeatCount", repeat)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Scheduled].[insertMsgPlaySP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;
        }

        public bool insertToCreatedataRecording(string SavingLocation, string AudioName, string ID)
        {

            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@Audio_String", SavingLocation),
               new SqlParameter("@Audio_Name", AudioName),
                new SqlParameter("@ID", ID)
            };
                result = (bool)DbConnection.ExecuteSps("[Scheduled].[CREATE_AUDIO_STRING_SCHEDULED_SP]", parameters, BaseClass.TypeBool);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return result; // Or rethrow the exception if preferred
            }
            return result;


        }
        public DataTable GET_AudioNames()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetAudioNamesScheduled]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;


        }
        public bool UpdateAudioPlayStatus(string action)
        {
            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>
                {
                       new SqlParameter("@Status", action)
            };
                result = (bool)DbConnection.ExecuteSps("Scheduled.SetAnnCompleted", parameters, BaseClass.TypeBool);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return result; // Or rethrow the exception if preferred
            }
            return result;

        }
        public DataTable CheckSplAnn(int pkeysplmsg)
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                  new SqlParameter("@AudioID", pkeysplmsg)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[CheckSpecialAnnMsgSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;


        }

        public DataTable PlaySplAnnouc(string pkeysplmsg, int ScrollToTexts)
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                      new SqlParameter("@AudioPathID", pkeysplmsg),
                          new SqlParameter("@RepeatSplAnn", ScrollToTexts)
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[InsertSpecialAnnMsgSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; //
            }
            return dataTable;

        }


        public DataTable getUpdatedStatus(string status)
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
                return dataTable;
            }
            return dataTable;
        }


        public DataTable getUpdatedAction()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetAnnouncementStatus]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable;
            }
            return dataTable;
        }

        public string DeleteAudioFile(int pkey)
        {
            string statusMessage = string.Empty;
            try
            {
                // Define the list of SQL parameters
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@audioId", pkey) { Value = pkey },

        };

                // Execute the stored procedure
                statusMessage = (string)DbConnection.ExecuteSps("[config].[DeletePaAudiofileSP]", parameters, BaseClass.TypeString);


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return statusMessage;

        }



    }
}
