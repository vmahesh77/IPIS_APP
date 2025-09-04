using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class BoardConfigurationDb
    {
        private DbConnection dbConnection;

        public BoardConfigurationDb()
        {
            dbConnection = new DbConnection();
        }


        public static List<string> GetFormatType()
        {
            List<string> formatTypesList = new List<string>();
            DataTable dataTable = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetFormatTypeSp]", parameters, BaseClass.TypeDataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    // Assuming the column name is "FormatType"
                    string value = row["FormatType"].ToString().Trim();
                    formatTypesList.Add(value);
                }
            }

            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return formatTypesList;


        }

        public static DataTable getBoardConfiguration(string ipAddress)
        {
            DataTable dataTable = new DataTable();

            try
            {

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@IPAddress", ipAddress)
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("config.getBoardConfigurationSP", parameters, BaseClass.TypeDataTable);

            }

            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return dataTable;
        }
        public static int UpsertTADDBConfiguration(string modifiedName, int boardWidth, int displayFieldGap1, int formatType)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
            {

                new SqlParameter("@ModifiedName", modifiedName ),
                new SqlParameter("@BoardWidth", boardWidth),
                new SqlParameter("@DisplayFieldGap1", displayFieldGap1),
                new SqlParameter("@Formattype", formatType)

            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[UpsertTADDBConfiguration]", parameters, BaseClass.TypeInt);

            }


            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show($"Error updating station configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected;
        }

        public static int InsertUpdateDefectiveLinesInTADDB(int pkeyHub, string defectiveLines, string BoardIp)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
            {

                new SqlParameter("@Pkey_Hub", pkeyHub),
                new SqlParameter("@DefectiveLines", defectiveLines),
                new SqlParameter("@BoardIp", BoardIp)

            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertUpdateDefectiveLinesInTADDB]", parameters, BaseClass.TypeInt);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show($"Error updating station configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected;
        }
        public static DataTable GetFormatname(string formatname)
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
            {
                  new SqlParameter("@ModifiedName", formatname)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetTADDBConfigurationByModifiedName]", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }

        public static int DeletePort(string format)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
            {

                new SqlParameter("@ModifiedName", format)

            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].DeleteTADDBConfiguration", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return 0;

            }
            return rowsAffected;
        }
    }
}
