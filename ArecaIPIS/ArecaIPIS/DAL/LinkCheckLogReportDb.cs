using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class LinkCheckLogReportDb
    {
        private DbConnection dbConnection;
        public LinkCheckLogReportDb()
        {

        }



        public DataTable GetAllLinkCheckReport(string fromDate, string toDate)
        {
            DataTable LinkCheckReport = new DataTable();



            try
            {
                var parameters = new List<SqlParameter>
                {
            new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate ", toDate)

            };
                LinkCheckReport = (DataTable)DbConnection.ExecuteSps("[Reports].[GetAllLinkCheckReportSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }



            return LinkCheckReport;
        }




    }
}
