using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class taddbReportDb
    {
        private DbConnection dbConnection;
        public taddbReportDb()
        {
            dbConnection = new DbConnection();
        }



        public DataTable GetAllTADDBreport(string fromDate, string toDate, string Status)
        {
            DataTable TADDBreport = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate ", toDate),
                new SqlParameter("@Status", Status)
                };
                TADDBreport = (DataTable)DbConnection.ExecuteSps("[Reports].[GetAllTADDBREPORTS_SP]", parameters, BaseClass.TypeDataTable);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return TADDBreport; // Or rethrow the exception if preferred
            }
            return TADDBreport;
        }



        public DataTable GetAllMessageStatus()
        {
            DataTable TADDBreport = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                TADDBreport = (DataTable)DbConnection.ExecuteSps("[Config].[GetStatusName_Status_SP]", parameters, BaseClass.TypeDataTable);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return TADDBreport; // Or rethrow the exception if preferred
            }
            return TADDBreport;
        }


    }
}
