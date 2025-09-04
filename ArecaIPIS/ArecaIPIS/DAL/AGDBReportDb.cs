using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class AGDBReportDb
    {
        private DbConnection dbConnection;
        public AGDBReportDb()
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




        public DataTable GetAllAGDBreport(string fromDate, string toDate, string Status)
        {
            DataTable AGDBreport = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate ", toDate),
                new SqlParameter("@Status", Status)

            };
                AGDBreport = (DataTable)DbConnection.ExecuteSps("[Reports].[GetAllDataAGDBREPORTS_SP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }
            return AGDBreport;
        }




    }
}
