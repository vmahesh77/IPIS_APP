using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class AnnouncementReportDb
    {
        private DbConnection dbConnection;
        public AnnouncementReportDb()
        {
            dbConnection = new DbConnection();
        }
        public DataTable GetMessageStatus()
        {
            DataTable dataTable = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Config].[GetStatusName_Status_SP]", parameters, BaseClass.TypeDataTable);


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }
            return dataTable;
        }

        public DataTable GetAnnouncementReports(string fromDate, string toDate, string status)
        {
            DataTable AnnouncementReport = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate ", toDate),
                new SqlParameter("@Status", status)

            };
                AnnouncementReport = (DataTable)DbConnection.ExecuteSps("[Reports].[GetAnnouncementSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }
            return AnnouncementReport;
        }



    }
}
