using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class NtesDataReportDb
    {
        public static DataTable GetNtesReports(string fromDate, string toDate)
        {

            DataTable dataTable = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
            {

                    new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate ", toDate)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Reports].[GetNtesDataReportSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;


        }


    }






}
