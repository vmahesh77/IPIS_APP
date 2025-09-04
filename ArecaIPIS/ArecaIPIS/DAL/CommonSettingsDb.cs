using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class CommonSettingsDb
    {

        public static int InsertOrUpdateAutoIntensity(bool autoIntensity, int dayIntensity, int nightIntensity, string fromTime, string toTime)
        {
            int rowsAffected = 0;
            try
            {

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@AutoIntensity", autoIntensity),
                    new SqlParameter("@DayIntensity", dayIntensity),
                    new SqlParameter("@NightIntensity", nightIntensity),
                    new SqlParameter("@FromTime", fromTime),
                    new SqlParameter("@ToTime", toTime)
                };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].InsertOrUpdateAutoIntensitySP", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show($"Error updating station configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected;
        }
        public static DataTable GetAutoIntensitydt()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetAutoIntensityTableSp", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }


        public static DataTable GetAnnouncement()
        {

            DataTable dataTable = new DataTable();

            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetAnnouncementValueSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return dataTable;
        }
        public static bool InsertUpdateAnnouncementsettings(int pValue, bool isChecked, string language)
        {
            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Pkey_announcementSettings", pValue),
                    new SqlParameter("@Announce", isChecked),
                    new SqlParameter("@LanguageSequence", language)
                };
                result = (bool)DbConnection.ExecuteSps("[config].[InsertUpdateAnnSettings]", parameters, BaseClass.TypeBool);

            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return result;
        }

        public static DataTable GetAutomaticRunning()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetAutomaticRunning]", parameters, BaseClass.TypeDataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }
        public static int InsertUpdateAutomaticRunning(bool autoMode, bool manualMode, bool selectTime,
           string timeFrom,
           string timeTo,
            bool selectRange,
            string nexthrs,
             string DataMins,
            bool? deletion,
            int? timeDeletion)
        {
            int rowsAffected = 0;
            try
            {

                var parameters = new List<SqlParameter>
                {

                 new SqlParameter("@AutoMode", autoMode),
                 new SqlParameter("@ManualMode", manualMode),
                 new SqlParameter("@selectTime", selectTime),
                 new SqlParameter("@Time_from", (object)timeFrom ?? DBNull.Value),
                 new SqlParameter("@Time_to", (object)timeTo ?? DBNull.Value),
                 new SqlParameter("@selectRange", selectRange),
                 new SqlParameter("@Nexthrs", (object)nexthrs ?? DBNull.Value),
                 new SqlParameter("@DataMins", (object)DataMins ?? DBNull.Value),
                 new SqlParameter("@Deletion", (object)deletion ?? DBNull.Value),
                 new SqlParameter("@Time_Deletion", (object)timeDeletion ?? DBNull.Value)
            };
                rowsAffected = (int)DbConnection.ExecuteSps("[Config].[InsertUpdateAutomaticRunning]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show($"Error updating station configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected;
        }

    }
}
