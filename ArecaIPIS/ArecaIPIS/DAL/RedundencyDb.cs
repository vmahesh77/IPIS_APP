using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class RedundencyDb
    {

        public static int InsertUpdateServerStatus(bool serverStatus, bool clientStatus, bool applicationStatus, string serverIpAddress, string clientIpAddress)
        {
            // Define parameters
            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@ServerActive", serverStatus),
        new SqlParameter("@ClientActive", clientStatus),
        new SqlParameter("@ApplicationStatus", applicationStatus),
        new SqlParameter("@ServerIp", serverIpAddress),
        new SqlParameter("@ClientIp", clientIpAddress)
    };

            // Execute for primary database
            int result = DbConnection.ExecuteStoredProcedure(DbConnection.MasterconnectionString, "[config].[InsertOrUpdateServer]", parameters);



            return 0; // Failure
        }
        public static int InsertUpdateClientStatus(bool serverStatus, bool clientStatus, bool applicationStatus, string serverIpAddress, string clientIpAddress)
        {
            // Define parameters
            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@ServerActive", serverStatus),
        new SqlParameter("@ClientActive", clientStatus),
        new SqlParameter("@ApplicationStatus", applicationStatus),
        new SqlParameter("@ServerIp", serverIpAddress),
        new SqlParameter("@ClientIp", clientIpAddress)
    };

            // Execute for primary database
            int result = DbConnection.ExecuteStoredProcedure(DbConnection.SlaveconnectionString, "[config].[InsertOrUpdateServer]", parameters);



            return 0; // Failure
        }

        public static DataTable GetClientDetails()
        {
            try
            {
                using (var connection = DbConnection.OpenConnectionSlave())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].[RetrieveServer]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Create a DataTable to hold the result
                        DataTable dataTable = new DataTable();

                        // Execute the command and load the result into the DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        // Return the filled DataTable
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return null;
            }
        }
        public static DataTable GetServerDetails()
        {


            try
            {
                List<SqlParameter> parameters = null;

                // Execute on the master connection
                DataTable masterDataTable = DbConnection.ExecuteStoredProcedureDatatable(DbConnection.MasterconnectionString, "[config].[RetrieveServer]", parameters);



                // Execute on the slave connection
                var slaveDataTable = DbConnection.ExecuteStoredProcedureDatatable(DbConnection.SlaveconnectionString, "[config].[RetrieveServer]", parameters);

                return masterDataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return null;
        }

        public static string GetSlaveConnectionRestoreString(string slaveIp)
        {
            string connectionString = GetSlaveConnectionTOReStore(slaveIp);

            if (IsConnectionValid(connectionString))
            {
                return connectionString;
            }

            return null;
        }
        public static string GetSlaveConnectionString(string slaveIp)
        {
            string connectionString = GetSlaveConnection(slaveIp);

            if (IsConnectionValid(connectionString))
            {
                return connectionString;
            }

            return null;
        }
        public static string GetSlaveConnectionTOReStore(string slaveIp)
        {
            string database = "master";  // Default database to connect
            string userId = "sa";
            string password = "areca@123";

            return $"Server={slaveIp};Database={database};User Id={userId};Password={password};";
        }

        public static string GetSlaveConnection(string slaveIp)
        {
            string database = "ARECA_IPIS_DB";  // Default database to connect
            string userId = "sa";
            string password = "areca@123";

            return $"Server={slaveIp};Database={database};User Id={userId};Password={password};";
        }


        private static bool IsConnectionValid(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true; // Connection succeeded
                }
            }
            catch (SqlException)
            {
                return false; // Connection failed
            }
        }
        public static void BackupDatabase(string connectionString, string databaseName, string backupFilePath)
        {
            try
            {
                // Get the directory path from the backup file path
                string backupDirectory = Path.GetDirectoryName(backupFilePath);

                // Check if the directory exists, and if not, create it
                if (!Directory.Exists(backupDirectory))
                {
                    try
                    {
                        Directory.CreateDirectory(backupDirectory);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Permission denied to create the backup directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Ensure that SQL Server has permission to write to the directory
                if (!HasWritePermission(backupDirectory))
                {
                    MessageBox.Show("SQL Server does not have write permission to the backup directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // SQL query to backup the database
                string backupQuery = $@"
            BACKUP DATABASE [{databaseName}] 
            TO DISK = '{backupFilePath}' 
            WITH INIT;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(backupQuery, connection);

                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show($"Database backup completed successfully. Path: {backupFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error during backup: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to check write permission
        private static bool HasWritePermission(string directoryPath)
        {
            try
            {
                // Attempt to create a temporary file in the directory to check write access
                string tempFilePath = Path.Combine(directoryPath, "temp.txt");
                using (var fs = File.Create(tempFilePath))
                {
                    fs.Close();
                }
                File.Delete(tempFilePath); // Cleanup
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public static void BackupDatabase(string connectionString, string databaseName, string backupFilePath)
        //{  // Get the directory path from the backup file path
        //    string backupDirectory = Path.GetDirectoryName(backupFilePath);

        //    // Check if the directory exists, and if not, create it
        //    if (!Directory.Exists(backupDirectory))
        //    {
        //        Directory.CreateDirectory(backupDirectory);
        //    }

        //    string backupQuery = $@"
        //BACKUP DATABASE [{databaseName}] 
        //TO DISK = '{backupFilePath}' 
        //WITH INIT;";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(backupQuery, connection);

        //        try
        //        {
        //            connection.Open();
        //            command.ExecuteNonQuery();
        //            MessageBox.Show($"Database backup completed successfully. Path: {backupFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            connection.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error during backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        public static bool RestoreDatabaseOnClient(string connectionString, string dbName, string bakFilePath)
        {
            bool status = false;

            string checkDatabaseQuery = $"IF DB_ID('{dbName}') IS NOT NULL SELECT 1 ELSE SELECT 0;";
            string setSingleUserQuery = $"ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
            string dropDatabaseQuery = $"DROP DATABASE [{dbName}];";
            string restoreQuery = $@"
        RESTORE DATABASE [{dbName}]
        FROM DISK = '{bakFilePath}' 
        WITH REPLACE, RECOVERY;
        ALTER DATABASE [{dbName}] SET MULTI_USER;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Step 1: Check if the database exists
                    bool databaseExists = false;
                    using (SqlCommand checkCommand = new SqlCommand(checkDatabaseQuery, connection))
                    {
                        databaseExists = (int)checkCommand.ExecuteScalar() == 1;
                    }

                    // Step 2: If the database exists, set it to single-user mode and drop it
                    if (databaseExists)
                    {
                        using (SqlCommand singleUserCommand = new SqlCommand(setSingleUserQuery, connection))
                        {
                            singleUserCommand.ExecuteNonQuery();
                        }

                        using (SqlCommand dropCommand = new SqlCommand(dropDatabaseQuery, connection))
                        {
                            dropCommand.ExecuteNonQuery();
                        }
                    }

                    // Step 3: Restore the database from the .bak file
                    using (SqlCommand restoreCommand = new SqlCommand(restoreQuery, connection))
                    {
                        restoreCommand.ExecuteNonQuery();
                    }

                    status = true;
                    MessageBox.Show("Database restored successfully on the client.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL Error during restore: " + ex.Message);
                    status = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("General Error during restore: " + ex.Message);
                    status = false;
                }
                finally
                {
                    // Attempt to reset the database to multi-user mode in case of failure
                    try
                    {
                        using (SqlCommand multiUserCommand = new SqlCommand($"ALTER DATABASE [{dbName}] SET MULTI_USER;", connection))
                        {
                            multiUserCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error resetting to multi-user mode: " + ex.Message);
                    }
                }
            }

            return status;
        }
    }
}
