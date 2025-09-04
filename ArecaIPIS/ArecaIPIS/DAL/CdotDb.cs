using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class CdotDb
    {

        public static DataTable GetCdotInfoData()
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetCdotInfoDataAllSP]", parameters, BaseClass.TypeDataTable);

                return dataTable;


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }
            return dataTable;
        }
        public static DataTable GetCdotInfoAudioTrains()
        {
            DataTable dataTable = new DataTable();

            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[getCdotInfoAudioDataSp]", parameters, BaseClass.TypeDataTable);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }
            return dataTable;
        }


        public static DataTable UpdateCdotDataAudiocount(int id, string identifier)
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", id),
                    new SqlParameter("@identifier", identifier)
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[UpdateCdotAudioDatacountSP]", parameters, BaseClass.TypeDataTable);

                //return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("Error retrieving data from database: " + ex.Message);

            }

            return dataTable;
        }

        public static DataTable PlayAnnouncemnet(DataTable Announce, int ScrollToTexts, string AnnData)
        {

            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@AudioPaths", Announce),
                    new SqlParameter("@AnnRepeatCount", ScrollToTexts),
                    new SqlParameter("@AnnData", AnnData)
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Scheduled].[insertPlaySP]", parameters, BaseClass.TypeDataTable);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("Error retrieving data from database: " + ex.Message);

            }

            return dataTable;
        }

        public static DataSet GetCdotInfoData(string indentifier)
        {
            DataSet dataSet = new DataSet();
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@identifier", indentifier)
                };
                dataSet = (DataSet)DbConnection.ExecuteSps("[config].[GetCdotInfoData]", parameters, BaseClass.TypeDataSet);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("Error retrieving data from database: " + ex.Message);

            }

            return dataSet;
        }


        public static DataSet GetCdotsenddata(string identifier)
        {
            DataSet dataSet = new DataSet();
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@identifier",identifier)
                };
                dataSet = (DataSet)DbConnection.ExecuteSps("[config].[GetCdotSendDataSP]", parameters, BaseClass.TypeDataSet);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
            return dataSet;
        }


    }
}
