using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace ArecaIPIS.DAL
{
    class ErrorLogReportDb
    {

        private DbConnection dbConnection;
        public ErrorLogReportDb()
        {
            dbConnection = new DbConnection();
        }




        public DataTable GetAllErrorLogReport(string fromDate, string toDate)
        {
            DataTable ErrorLogReport = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate ", toDate)
                };
                ErrorLogReport = (DataTable)DbConnection.ExecuteSps("[Reports].[GetAllERRORLOG_SP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }
            return ErrorLogReport;
        }






    }
}
