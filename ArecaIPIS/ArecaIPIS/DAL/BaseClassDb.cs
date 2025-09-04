using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class BaseClassDb
    {
        public BaseClassDb()
        {

        }

        public static DataTable GetDisplayEffects()
        {
            DataTable datatable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                datatable = (DataTable)DbConnection.ExecuteSps("[config].GetDisplayEffectsSp", parameters, BaseClass.TypeDataTable);
                return datatable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return datatable;
            }

        }
        public static DataTable GetNoOfDevices()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetNoOfDevicesSp]", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }

            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }
        public static DataTable GetLetterSpeed()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetLetterSpeedSp]", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }
        public static DataTable GetinfoDisplay()
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetInfodisplayedSp", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }

        public static DataTable GetPacketIdentifier()
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetPacketIdentifierSP", parameters, BaseClass.TypeDataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }


        public static DataTable GetFormatType()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetFormatTypeSp", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }

        public static DataTable GetScheduleStatus()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetScheduleStatusSp", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }
        public static DataTable GetFormats()
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetFormatsSp", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }
        public static DataTable GetFontSize()
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetFontSizeSp", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }
        public static DataTable GetLetterGap()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetLetterGapSp", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }
        public static DataTable GetIVDOVDSpeed()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetLetterSpeedIvdOvdSp", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }
        public static DataTable GetClearingEffects()
        {
            DataTable dataTable = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetClearingEffectsSp]", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }

        public static DataTable GetMediaType()
        {
            DataTable dataTable = new DataTable();

            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetIVDOVDMediaTypeSp", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }

        public static DataTable getcgdbBlank()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetFirstRowSp]", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }

            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }
        public static DataTable getCgdbHub()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetCgdbConfigurationSp]", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }

        }


        public static DataTable GetCoachBitMap()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetCoachBitMapSp", parameters, BaseClass.TypeDataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }

        public static DataTable GetIVDOVDMessageFontSize()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetIVDOVDMessageFontSizeSp", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }

        public static DataTable GetIVDOVDVolume()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetIVDOVDVolumeSp", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }

        public static DataTable GetIVDOVDMessageCharacterGap()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetIVDOVDMessageCharacterGapSp", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }
        public static DataTable GetDisplayEffectIVDOVD()
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].GetDisplayEffectIVDOVDSp", parameters, BaseClass.TypeDataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
        }
    }

}
