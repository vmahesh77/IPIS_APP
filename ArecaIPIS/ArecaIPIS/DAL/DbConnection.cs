using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class DbConnection
    {
        public static string MasterconnectionString = "Data Source=.;Initial Catalog=ARECA_IPIS_DB;User Id=sa;Password=areca@123;";
        public static string SlaveconnectionString;
      private static bool isRestarting = false;



        public static SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(MasterconnectionString);

            try
            {
                if (connection != null)
                    connection.Open();
                // MessageBox.Show("Connection successfully opened.");
                return connection;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return null;
            }
        }
        public static SqlConnection OpenConnectionSlave()
        {
            var connection = new SqlConnection(SlaveconnectionString);

            try
            {
                connection.Open();
                // MessageBox.Show("Connection successfully opened.");
                return connection;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return null;
            }
        }

        public static void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }

        public static void Dispose(SqlConnection connection)
        {
            try
            {
                CloseConnection(connection);
                if (connection != null)
                {
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }

        public int ExecuteNonQuery(string query)
        {
            try
            {
                using (var connection = OpenConnection())
                {
                    if (connection == null)
                        return -1;

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }

            return -1;
        }





        public object ExecuteScalar(string query)
        {
            try
            {
                using (var connection = OpenConnection())
                {
                    if (connection == null)
                        return null;

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return null;
        }

        public DataTable ExecuteQuery(string query)
        {
            try
            {
                using (var connection = OpenConnection())
                {
                    if (connection == null)
                        return null;

                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return null;
        }


        public void Dispose()
        {
            try
            {
                Dispose(null);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
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

        //public static string GetSlaveConnection(string slaveIp)
        //{
        //    string database = "ARECA_IPIS_DB";
        //    string userId = "sa";
        //    string password = "areca@123";

        //    return $"Data Source={slaveIp};Initial Catalog={database};User Id={userId};Password={password};";
        //}

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

        public static object ExecuteSps(string storedProcedureName, List<SqlParameter> parameters, int returnTpeOfData)
        {

            if (returnTpeOfData == 0)//int 
            {
                int result = DbConnection.ExecuteStoredProcedure(DbConnection.MasterconnectionString, storedProcedureName, parameters);

                if (result >= 0)
                {
                    // Create and execute new parameters for the slave database
                    var slaveParameters = parameters.Select(param => new SqlParameter(param.ParameterName, param.Value)).ToList();
                    DbConnection.ExecuteStoredProcedure(DbConnection.SlaveconnectionString, storedProcedureName, slaveParameters);
                }
                return result;
            }
            else if (returnTpeOfData == 1)//bool
            {
                bool result = DbConnection.ExecuteStoredProcedureBoolean(DbConnection.MasterconnectionString, storedProcedureName, parameters);

                // Create and execute new parameters for the slave database
                var slaveParameters = parameters.Select(param => new SqlParameter(param.ParameterName, param.Value)).ToList();
                DbConnection.ExecuteStoredProcedureBoolean(DbConnection.SlaveconnectionString, storedProcedureName, slaveParameters);

                return result;
            }
            else if (returnTpeOfData == 2)//DataTable
            {
                DataTable result = DbConnection.ExecuteStoredProcedureDatatable(DbConnection.MasterconnectionString, storedProcedureName, parameters);

                // Create and execute new parameters for the slave database
                var slaveParameters = parameters.Select(param => new SqlParameter(param.ParameterName, param.Value)).ToList();
                DbConnection.ExecuteStoredProcedureDatatable(DbConnection.SlaveconnectionString, storedProcedureName, slaveParameters);

                return result;
            }
            else if (returnTpeOfData == 3)//DataSet
            {
                DataSet result = DbConnection.ExecuteStoredProcedureDataSet(DbConnection.MasterconnectionString, storedProcedureName, parameters);


                // Create and execute new parameters for the slave database
                var slaveParameters = parameters.Select(param => new SqlParameter(param.ParameterName, param.Value)).ToList();
                DbConnection.ExecuteStoredProcedureDataSet(DbConnection.SlaveconnectionString, storedProcedureName, slaveParameters);

                return result;
            }
            else if (returnTpeOfData == 4)//string
            {
                string result = DbConnection.ExecuteStoredProcedurestring(DbConnection.MasterconnectionString, storedProcedureName, parameters);


                // Create and execute new parameters for the slave database
                var slaveParameters = parameters.Select(param => new SqlParameter(param.ParameterName, param.Value)).ToList();
                DbConnection.ExecuteStoredProcedure(DbConnection.SlaveconnectionString, storedProcedureName, slaveParameters);

                return result;
            }
            else if (returnTpeOfData == 5)//List<string>
            {
                List<string> result = DbConnection.Execute_List_String_StoredProcedure(DbConnection.MasterconnectionString, storedProcedureName, parameters);

                if (result.Count > 0)
                {
                    // Create and execute new parameters for the slave database
                    var slaveParameters = parameters.Select(param => new SqlParameter(param.ParameterName, param.Value)).ToList();
                    DbConnection.Execute_List_String_StoredProcedure(DbConnection.SlaveconnectionString, storedProcedureName, slaveParameters);
                }
                return result;
            }

            return 0;

        }

        public static int ExecuteStoredProcedure(string connectionString, string storedProcedureName, List<SqlParameter> parameters)
        {
            try
            {
                if (!string.IsNullOrEmpty(connectionString)) // Check for null or empty connection string
                {


                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (var command = new SqlCommand(storedProcedureName, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Safely handle parameters
                            if (parameters != null && parameters.Any())
                            {
                                command.Parameters.AddRange(parameters.ToArray());
                            }

                            // Add a parameter to capture the return value
                            var returnValue = new SqlParameter("@ReturnVal", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.ReturnValue
                            };
                            command.Parameters.Add(returnValue);

                            // Execute the command
                            command.ExecuteNonQuery();

                            // Retrieve the return value
                            if (returnValue.Value != DBNull.Value)
                            {
                                if (returnValue.Value != null)
                                    return (int)returnValue.Value;
                                else
                                    return 1;
                            }


                        }
                    }
                }
                // Default return if no value is returned
                return 1;
            }

            catch (Exception ex)
            {
                Server.LogError($"{ex.ToString()} {storedProcedureName}");
                return 1;
            }
        }


        public static List<String> Execute_List_String_StoredProcedure(string connectionString, string storedProcedureName, List<SqlParameter> parameters)
        {
            List<string> trainTypes = new List<string>();

            try
            {
                if (connectionString != null && connectionString != "")
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (var command = new SqlCommand(storedProcedureName, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            // Execute the command and retrieve the  
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                // Check if the reader has rows
                                if (reader.HasRows)
                                {
                                    // Iterate over the rows and add train types to the list
                                    while (reader.Read())
                                    {
                                        // Assuming the train type is stored in the first column
                                        string trainType = reader.GetString(0);
                                        trainTypes.Add(trainType);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    return trainTypes;
                }
            }
            catch (Exception ex)
            {

                Server.LogError($"{ex.ToString()} {storedProcedureName}");
                return trainTypes;
            }
            return trainTypes;
        }
        public static bool ExecuteStoredProcedureBoolean(string connectionString, string storedProcedureName, List<SqlParameter> parameters)
        {
            try
            {
                if (!string.IsNullOrEmpty(connectionString)) // Check for null or empty connection string
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (var command = new SqlCommand(storedProcedureName, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Add parameters to the command
                            if (parameters != null && parameters.Count > 0)
                            {
                                command.Parameters.AddRange(parameters.ToArray());
                            }

                            // Execute the command
                            command.ExecuteNonQuery();
                            return true; // Success
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Server.LogError($"{ex.ToString()} {storedProcedureName}");
                return false;
            }
        }
        public static DataTable ExecuteStoredProcedureDatatable(string connectionString, string storedProcedureName, List<SqlParameter> parameters = null, bool isQuery = true)
        {
            DataTable dataTable = new DataTable();
            try
            {


                if (!string.IsNullOrEmpty(connectionString))
                {

                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var command = new SqlCommand(storedProcedureName, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Add parameters to the command if provided
                            if (parameters != null && parameters.Count > 0)
                            {
                                command.Parameters.AddRange(parameters.ToArray());
                            }

                            // Check if the operation is a query (for retrieval)
                            if (isQuery)
                            {
                                dataTable = new DataTable(); // Create a new DataTable for the results

                                // Fill the DataTable with the results
                                using (var adapter = new SqlDataAdapter(command))
                                {
                                    adapter.Fill(dataTable);
                                }
                            }
                            else
                            {
                                // Execute the command for insertion/update
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                else
                {
                    //ReduendencyCheck();
                }
            }
            catch (Exception ex)
            {
                Server.LogError($"{ex.ToString()} {storedProcedureName}");
            }

            return dataTable; // Return the DataTable (or null) depending on the operation
        }


        public static string ExecuteStoredProcedurestring(string connectionString, string storedProcedureName, List<SqlParameter> parameters = null)
        {
            string result = null;

            try
            {
                if (!string.IsNullOrEmpty(connectionString))
                {

                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (var command = new SqlCommand(storedProcedureName, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Add parameters to the command if provided
                            if (parameters != null && parameters.Count > 0)
                            {
                                command.Parameters.AddRange(parameters.ToArray());
                            }

                            // Execute the command and read the result
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read()) // Read the first row of the result
                                {
                                    result = reader[0]?.ToString(); // Get the first column value as a string
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError($"{ex.ToString()} {storedProcedureName}");
            }

            return result; // Return the result (or null if an error occurred)
        }

        public static DataSet ExecuteStoredProcedureDataSet(string connectionString, string storedProcedureName, List<SqlParameter> parameters = null, bool isQuery = true)
        {
            DataSet dataSet = null;
            try
            {


                if (!string.IsNullOrEmpty(connectionString))
                {

                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var command = new SqlCommand(storedProcedureName, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Add parameters to the command if provided
                            if (parameters != null && parameters.Count > 0)
                            {
                                command.Parameters.AddRange(parameters.ToArray());
                            }

                            // Check if the operation is a query (for retrieval)
                            if (isQuery)
                            {
                                dataSet = new DataSet(); // Create a new DataTable for the results

                                // Fill the DataTable with the results
                                using (var adapter = new SqlDataAdapter(command))
                                {
                                    adapter.Fill(dataSet);
                                }
                            }
                            else
                            {
                                // Execute the command for insertion/update
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                else
                {
                    //ReduendencyCheck();
                }
            }
            catch (Exception ex)
            {
                Server.LogError($"{ex.ToString()} {storedProcedureName}");
            }

            return dataSet; // Return the DataTable (or null) depending on the operation
        }

        public static void ReduendencyCheck()
        {

            if (string.IsNullOrEmpty(Server.ipAdress))
            {


            }
            else
            {
                bool SlaveConnect = Server.IsIpAddressConnected("192.168.0.253");
                if (SlaveConnect)
                {
                    if (Server.ipAdress != "192.168.0.253")
                    {
                        RestartApplication();
                    }

                }


            }
        }
        public static void RestartApplication()
        {
            //if (!isRestarting)
            //{
            //    isRestarting = true;
            //    Application.Restart();
            //}


            Form mainForm = Application.OpenForms["frmIndex"];
            if (mainForm != null)
            {
                frmIndex frmindex = (frmIndex)mainForm;

                frmindex.ClientForm();

            }
        }
    }
}
