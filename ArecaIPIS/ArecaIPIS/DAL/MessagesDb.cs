using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class MessagesDb
    {

        private DbConnection dbConnection;

        public MessagesDb()
        {
            dbConnection = new DbConnection();
        }

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

            }

            return dataTable;




        }
        public DataTable GetSpecialMessagesData()
        {
            DataTable dataTable = new DataTable();



            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("Config.GetallSpecialMessagesDataSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

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

            }

            return dataTable;
        }



        public DataTable GetMessagesByRow(int id)
        {

            DataTable dataTable = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
                {
                   new SqlParameter("@pKeyValue", id)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("Config.GetSpecialMessagesbyRowSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;

        }


        public bool InsertOrUpdateMessage(int pkey, string englishMsg, string nationalMsg, string regionalMsg1, string regionalMsg2, string audioFilePath = null)
        {


            bool status = false;

            try
            {
                var parameters = new List<SqlParameter>
                {
                   new SqlParameter("@Pkey_SpclMessages", pkey),
                new SqlParameter("@Englishmsg", englishMsg),
                new SqlParameter("@NationalMsg", nationalMsg),
                new SqlParameter("@RegionalMSg1", regionalMsg1),
                new SqlParameter("@RegionalMsg2", regionalMsg2),
                new SqlParameter("@AudioFilePath", audioFilePath)

            };
                status = (bool)DbConnection.ExecuteSps("config.insertupdateMessagesSP", parameters, BaseClass.TypeBool);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return status;

        }





        public DataTable CallGetSplMessages1(string PrimaryKeys, int AnnRepeatCount)
        {


            DataTable dataTable = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
            {

               new SqlParameter("@ID", PrimaryKeys),
            new SqlParameter("@AnnRepeatCount", AnnRepeatCount)
             };
                dataTable = (DataTable)DbConnection.ExecuteSps("Config.GetSplMessages1", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

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

               new SqlParameter("@PlayStatus", status),

             };
                dataTable = (DataTable)DbConnection.ExecuteSps("Config.UpdateAnnouncementStatus", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;

        }




        public static bool UpdateAudioPlayStatus(string action)
        {

            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@Status", action)

            };
                int rowsAffected = (int)DbConnection.ExecuteSps("Scheduled.SetAnnCompleted", parameters, BaseClass.TypeInt);

                if (rowsAffected > 0)
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

            }

            return false;
        }
        public void SaveMessagesStatus(int pkey, bool status)
        {

            try
            {
                var parameters = new List<SqlParameter>
            {

                          new SqlParameter("@Pkey_SpclMessages", pkey),
                new SqlParameter("@CheckedStat", status)
            };
                bool RESULT = (bool)DbConnection.ExecuteSps("[config].[updateCheckedsplMessages]", parameters, BaseClass.TypeBool);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }



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

            }

            return dataTable;

        }

    }
}
