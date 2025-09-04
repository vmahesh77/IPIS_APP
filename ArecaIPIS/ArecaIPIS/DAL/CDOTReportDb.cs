using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class CDOTReportDb
    {
        private DbConnection dbConnection;
        public CDOTReportDb()
        {
            dbConnection = new DbConnection();
        }


        public DataTable GetAllDataCDotReports(string fromDate, string toDate, string status)
        {
            DataTable CDotReports = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate ", toDate),
                    new SqlParameter("@Status", status)
                };
                CDotReports = (DataTable)DbConnection.ExecuteSps("[Reports].[NewGetAllCDotREPORTS_SP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return CDotReports;
        }




    }
}
