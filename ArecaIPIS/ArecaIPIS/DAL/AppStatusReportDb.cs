using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class AppStatusReportDb
    {
        private DbConnection dbConnection;
        public AppStatusReportDb()
        {
            dbConnection = new DbConnection();
        }

        public DataTable GetAppStatusReports(string fromDate, string toDate)
        {


            DataTable AppStatusReports = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate ", toDate)

            };
                AppStatusReports = (DataTable)DbConnection.ExecuteSps("[Reports].[AppStatusSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }
            return AppStatusReports;
        }


    }
}
