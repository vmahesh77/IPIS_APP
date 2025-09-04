using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class PDCReportDb
    {

        public PDCReportDb()
        {

        }

        public DataTable GetPDCReports(string fromDate, string toDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                   new SqlParameter("@FromDate", fromDate),
                   new SqlParameter("@ToDate ", toDate)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Reports].[GetPDCReportSP]", parameters, BaseClass.TypeDataTable);

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
