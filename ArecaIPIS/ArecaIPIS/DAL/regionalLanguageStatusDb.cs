using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace ArecaIPIS.DAL
{
    class regionalLanguageStatusDb
    {
        private DbConnection dbConnection;

        public regionalLanguageStatusDb()
        {
            dbConnection = new DbConnection();
        }

        public DataTable GetRegionalLanguageStatus()
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Define parameters
                var parameters = new List<SqlParameter>
                {

                };

                dataTable = (DataTable)DbConnection.ExecuteSps("Config.GetRegionalMessagesSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return dataTable;
        }


        public DataTable GetLanguageStatusByRow(int id)
        {

            DataTable dataTable = new DataTable();
            try
            {
                // Define parameters
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id", id)
            };

                dataTable = (DataTable)DbConnection.ExecuteSps("Config.GetLanguageStatusbyRowSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return dataTable;

        }

        public bool InsertOrUpdateMessage(string english, string Hindi, string RLanguage)
        {
            bool result = false;
            try
            {
                // Define parameters
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@EStatusName", english),
                 new SqlParameter("@HStatus", Hindi),
                 new SqlParameter("@RStatus", RLanguage)
            };

                result = (bool)DbConnection.ExecuteSps("config.InsertUpdateStatusSP", parameters, BaseClass.TypeBool);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return result;
        }

    }
}
