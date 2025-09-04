using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class AnnouncementScriptDb
    {
        private DbConnection dbConnection;

        public AnnouncementScriptDb()
        {
            dbConnection = new DbConnection();
        }

        public DataTable GetAllStatus()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[dbo].[GetAllStatusSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }

            return dataTable;
        }

        public DataTable GetLanguage()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Config].[SelectedLanguagesSP]", parameters, BaseClass.TypeDataTable);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }

            return dataTable;
        }

        public DataTable GetAudioFormat(int selectedStatus, int selectedLanguage, int selectedPlatform)
        {
            DataTable audioFormat = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@trainstatus", selectedStatus),
                new SqlParameter("@languageid", selectedLanguage),
                new SqlParameter("@Platformstatus", selectedPlatform)

            };
                audioFormat = (DataTable)DbConnection.ExecuteSps("[config].[GetAudioFormatsSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                ex.ToString();
            }

            return audioFormat;
        }


        public bool InsertOrUpdateAudioScript(int pkey, int LanguageName, string audioPath, string AudioName, decimal sequence, int trainstatus, int platformStatus)
        {
            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Pkey_AudioFormat", pkey),
                new SqlParameter("@languageid", LanguageName),
                new SqlParameter("@AudioPath", audioPath),
                new SqlParameter("@AudioName", AudioName),
                new SqlParameter("@sequence", sequence),
                new SqlParameter("@trainstatus", trainstatus),
                new SqlParameter("@platformstatus", platformStatus)

            };
                result = (bool)DbConnection.ExecuteSps("[config].[insertupdateAudioSP]", parameters, BaseClass.TypeBool);

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
