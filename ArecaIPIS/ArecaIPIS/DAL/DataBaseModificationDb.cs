using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class DataBaseModificationDb
    {
        public static DataTable GetdatabaseModificationReports(string TypeDatabaseModification, string fromDate, string toDate)
        {

            DataTable dataTable = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Type", TypeDatabaseModification),
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate ", toDate)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Reports].[GetDataBaseModificationReportSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;


        }



    }
}
