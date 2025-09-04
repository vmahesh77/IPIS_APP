using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class SloganDb
    {

        private DbConnection dbConnection;

        public SloganDb()
        {
            dbConnection = new DbConnection();
        }

        public DataTable GetSloganMessages()
        {

            DataTable datatable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                datatable = (DataTable)DbConnection.ExecuteSps("Config.GetSlogansSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return datatable;
        }



        public DataTable GetSlogansByRow(int id)
        {
            DataTable datatable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@pKeyValue", id)
            };
                datatable = (DataTable)DbConnection.ExecuteSps("Config.GetSlogansbyRowSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return datatable;

        }



        public bool InsertOrUpdateSlogan(int pKey_SpecialMessage, string Msg, string audioFilePath, int Language)
        {

            bool b = false;
            try
            {
                var parameters = new List<SqlParameter>
                {
                   new SqlParameter("@Pkey_SpclMessages", pKey_SpecialMessage),
                new SqlParameter("@Message", Msg),
                 new SqlParameter("@AudioFilePath", audioFilePath),
                 new SqlParameter("@LangdID", Language)
            };
                b = (bool)DbConnection.ExecuteSps("Config.GetSlogansbyRowSP", parameters, BaseClass.TypeBool);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return b;

        }

        public DataTable GetLanguage()
        {

            DataTable datatable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                datatable = (DataTable)DbConnection.ExecuteSps("[Config].[SelectedLanguagesSP]", parameters, BaseClass.TypeDataTable);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return datatable;
        }



        public string DeleteSlogan(int pkey)
        {
            string statusMessage = string.Empty;
            try
            {
                // Define the list of SQL parameters
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@Pkey_SpclMsgs", SqlDbType.Int) { Value = pkey },

        };

                // Execute the stored procedure
                statusMessage = (string)DbConnection.ExecuteSps("[config].[DeleteSloganMessage]", parameters, BaseClass.TypeString);


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return statusMessage;

        }

        public DataTable GetSplMessagestoPlay(string PrimaryKeys, int AnnRepeatCount)
        {

            DataTable datatable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@ID", PrimaryKeys),
                     new SqlParameter("@AnnRepeatCount", AnnRepeatCount)
                };
                datatable = (DataTable)DbConnection.ExecuteSps("Config.GetSplMsgstoplay", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return datatable;
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
            }
            return result;
        }

        public DataTable getUpdatedStatus(string status)
        {

            DataTable datatable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                     new SqlParameter("@PlayStatus", status)
                };
                datatable = (DataTable)DbConnection.ExecuteSps("Config.UpdateAnnouncementStatus", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return datatable;
        }

    }
}
