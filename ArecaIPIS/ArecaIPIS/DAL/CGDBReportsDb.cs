using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class CGDBReportsDb
    {

        private DbConnection dbConnection;
        public CGDBReportsDb()
        {
            dbConnection = new DbConnection();
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
                ex.ToString();
            }
            return dataTable;
        }


        public DataTable GetCGDBReports(string fromDate, string toDate, string pfno)
        {
            DataTable CGDBReport = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate ", toDate),
                    new SqlParameter("@PlatformNo", pfno)
                };
                CGDBReport = (DataTable)DbConnection.ExecuteSps("[Reports].[GetCGDBReports]", parameters, BaseClass.TypeDataTable);


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }
            return CGDBReport;
        }


    }
}
