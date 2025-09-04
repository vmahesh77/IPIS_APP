using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class DatalogReportDb
    {
        private DbConnection dbConnection;
        public DatalogReportDb()
        {
            dbConnection = new DbConnection();
        }



        public DataTable GetDataLogReport(string fromDate, string toDate)
        {
            DataTable DataLogReport = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate ", toDate)

                };
                DataLogReport = (DataTable)DbConnection.ExecuteSps("[Reports].[GetAllDATALOG_SP]", parameters, BaseClass.TypeDataTable);


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }
            return DataLogReport;
        }

    }
}
