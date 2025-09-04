using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class addCoachDataDb
    {
        private DbConnection dbConnection;

        public addCoachDataDb()
        {
            dbConnection = new DbConnection();
        }
        public DataTable GetCoachData()
        {
            DataTable dt = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dt = (DataTable)DbConnection.ExecuteSps("Config.getcoachesSP", parameters, BaseClass.TypeDataTable);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }
            return dt;
        }

        public DataTable GetCoachDataByRow(int id)
        {

            DataTable dataTable = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("Config.GetCoachDatabyRowSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("Error retrieving data from database: " + ex.Message);
            }
            return dataTable;
        }


        public bool InsertOrUpdateMessage(int pkey, string english, string Hindi, string Bitmap)
        {
            bool result = false;
            try
            {

                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Pkey_Coachid", pkey),
                new SqlParameter("@EnglishCoachName", english),
                new SqlParameter("@HindiCoachName", Hindi),
                new SqlParameter("@Bitmap", Bitmap)
            };
                result = (bool)DbConnection.ExecuteSps("config.insertupdateCoachDataSP", parameters, BaseClass.TypeBool);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message);

            }
            return result;
        }


    }
}
