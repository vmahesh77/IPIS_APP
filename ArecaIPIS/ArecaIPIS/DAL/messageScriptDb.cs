using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class messageScriptDb
    {
        private DbConnection dbConnection;

        public messageScriptDb()
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



        public DataTable GetAllTrainPosition()
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {


                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Config].[GetTrainPositionSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;


        }



        public static DataTable GetLanguage()
        {

            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {


                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Config].[SelectedLanguagesSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;



        }

        public DataTable GetMessageFormat(int selectedStatus, int selectedLanguage, int selectedPosition)
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {  new SqlParameter("@StatusMessage", selectedStatus),
                   new SqlParameter("@languageid", selectedLanguage),
                  new SqlParameter("@PfStatus", selectedPosition)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetMessageFormatsSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;


        }

        public DataTable GetMessageFormatByRow(int id)
        {
            DataTable dataTable = new DataTable();



            try
            {
                var parameters = new List<SqlParameter>
                {
                   new SqlParameter("@pKeyValue", id)

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("Config.GetMessageFormatbyRowSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;



        }

        public bool InsertOrUpdateMessageScript(int pkey, int LanguageName, string messagePath, string MessageName, decimal sequence, int selectedstatus, int position)
        {

            bool status = false;

            try
            {
                var parameters = new List<SqlParameter>
                {
                   new SqlParameter("@Pkey_MessageFormat", pkey),
                new SqlParameter("@languageid", LanguageName),
                 new SqlParameter("@MessagePath", messagePath),
               new SqlParameter("@MessageName ", MessageName),
                  new SqlParameter("@sequence", sequence),
                  new SqlParameter("@StatusMessage", selectedstatus),
               new SqlParameter("@PfStatus", position)

            };
                status = (bool)DbConnection.ExecuteSps("config.insertupdateMessageSP", parameters, BaseClass.TypeBool);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return status;

        }

    }
}
