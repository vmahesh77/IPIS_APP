using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class BoardDiagnosisDb
    {

        private DbConnection dbConnection;

        public BoardDiagnosisDb()
        {
            dbConnection = new DbConnection();
        }

        public static DataTable GetDiagnosisBoards(List<int> PacketIdentifiers)
        {
            DataTable dataTable = new DataTable();
            try
            {


                DataTable packetIdsTable = new DataTable();
                packetIdsTable.Columns.Add("PacketIdentifier", typeof(int));

                // Add the packet identifiers to the DataTable
                foreach (int id in PacketIdentifiers)
                {
                    packetIdsTable.Rows.Add(id);
                }

                var parameters = new List<SqlParameter>
            {

                new SqlParameter("@PacketIdentifiers", packetIdsTable)


            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetDiagnosisSp]", parameters, BaseClass.TypeDataTable);


                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

                return dataTable;
            }
            return dataTable;
        }
        public static int UpdateDatabaseWithNewIntensity(string ipAddress, int intensity)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
            {

                new SqlParameter("@IpAddress", ipAddress),
                new SqlParameter("@Intensity", intensity)

            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertUpdateIntensitySp]", parameters, BaseClass.TypeInt);


                return rowsAffected;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show($"An error occurred while saving data: {ex.Message}");
                return 0;
            }
        }

        public static DataTable GetEthernetPorts()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].sp_GetAllDefectiveLines", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static int DeleteBoard(int pkhub)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
                 new SqlParameter("@Pkey_Hub", pkhub)
                };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[DeleteDefectiveLinesInTADDB]", parameters, BaseClass.TypeInt);

                return rowsAffected;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show($"An error occurred while saving data: {ex.Message}");
                return 0;
            }
        }

        public static int DeleteBoardNotInMasterHub()
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[DeletedefectiveBoards]", parameters, BaseClass.TypeInt);

                return rowsAffected;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show($"An error occurred while saving data: {ex.Message}");
                return 0;
            }
        }
    }
}
