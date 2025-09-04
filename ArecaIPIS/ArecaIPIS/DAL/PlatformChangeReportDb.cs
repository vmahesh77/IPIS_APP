using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class PlatformChangeReportDb
    {
        private DbConnection dbConnection;
        public PlatformChangeReportDb()
        {
            dbConnection = new DbConnection();
        }



        public DataTable GetPlatformChangeReport(string fromDate, string toDate)
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate ", toDate)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Reports].[GetAllDataPlatformChangeSP]", parameters, BaseClass.TypeDataTable);

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
