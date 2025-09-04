using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    public class AddStationDb
    {


        private DbConnection dbConnection;

        public AddStationDb()
        {
            dbConnection = new DbConnection();
        }



        public DataTable GetAllStationNames()
        {
            DataTable dt = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dt = (DataTable)DbConnection.ExecuteSps("[Config].[GetStationNamesSP]", parameters, BaseClass.TypeDataTable);

                foreach (DataRow row in dt.Rows)
                {
                    BaseClass.stationCodes.Add(row["StationCode"].ToString().Trim());
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return dt;
        }


        public bool InsertOrUpdateStationNames(int pkeyStationNames, string stationCode, string stationEng, string stationHind, string stationReg1, string stationReg2, string audioFile = null)
        {
            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Pkey_stationnames", pkeyStationNames),
                new SqlParameter("@StationCode", stationCode),
                new SqlParameter("@stationeng", stationEng),
                new SqlParameter("@stationhind", stationHind),
                new SqlParameter("@stationreg1", stationReg1),
                new SqlParameter("@stationreg2", stationReg2),
                new SqlParameter("@AudoFile", audioFile)
            };
                result = (bool)DbConnection.ExecuteSps("[config].[insertupdatestationnamesSP]", parameters, BaseClass.TypeBool);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message);

            }
            return result;
        }



        public DataTable GetStationNameByRow(int id)
        {
            DataTable dataTable = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@StationId", id)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("Config.GetStationNamebyRowSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("Error retrieving data from database: " + ex.Message);
            }

            return dataTable;
        }


    }
}
