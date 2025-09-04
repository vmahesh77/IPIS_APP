using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class MediaDb
    {

        public static void InsertColorConfiguration(int MasterHubKey, DataTable ColorsDt)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
                      new SqlParameter("@ConfigTable", ColorsDt),
                new SqlParameter("@MasterHubKey", MasterHubKey)

            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertUpdate_TrueColorConfigurationSp]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }


        }
        public static void InsertBorderColorConfiguration(int MasterHubKey, string HorizontalLineColor, string MessageLineColor, string BackgroundColor, string VerticalLineColor)
        {

            try
            {
                var parameters = new List<SqlParameter>
                {
                 new SqlParameter("@HorizontalLineColor", HorizontalLineColor),
                new SqlParameter("@MessageLineColor", MessageLineColor),
                new SqlParameter("@BackgroundColor", BackgroundColor),
                new SqlParameter("@VerticalLineColor", VerticalLineColor),
                new SqlParameter("@Fkey_Masterhub", MasterHubKey)

            };
                int rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertUpdate_TruecolorBordersConfigSp]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }




        }
        public static DataTable GetColorConfiguration(int HubKey)
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@MasterHubKey", HubKey)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetColorConfigurationSp]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;


        }
        public static DataTable GetBorderColorConfiguration(int HubKey)
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@MasterHubKey", HubKey)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetVdcBordersConfigurationSp]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;

        }
        public static int InsertUpdatePlayList(string UserName, string BoardName, string BoardId, string playListName, DataTable playlist, int RepeatCount, string starthour, string startminute, string endhour, string endminute, DateTime date)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
               new SqlParameter("@username", UserName),
                new SqlParameter("@BoardName", BoardName),
                new SqlParameter("@BoardId", BoardId),
                new SqlParameter("@PlayListName", playListName),
                new SqlParameter("@MediaTable", playlist),
                new SqlParameter("@RepeatCount", RepeatCount),
                 new SqlParameter("@starthour", starthour),
                new SqlParameter("@startminute", startminute),
                new SqlParameter("@endhour", endhour),
                new SqlParameter("@endminute", endminute),
                new SqlParameter("@Date", date)

            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertUpdate_PlayListConfigurationSp]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return rowsAffected;
        }


        public static DataTable GetPlayListbyUser(string username, string boardid)
        {
            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@UserName", username),
                new SqlParameter("@BoardId", boardid)
            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetPlayListconfigurationByBoardIdAndUserName]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;


        }
        public static void GetAllPlayLists()
        {

            try
            {
                var parameters = new List<SqlParameter>
                {

                new SqlParameter("@UserName", BaseClass.UserName),

            };
                BaseClass.MediaPlayListwithusername = (DataTable)DbConnection.ExecuteSps("[config].[GetPlayListDataByUserName]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }




        }

        public static DataTable GetPlayListbyUserplaylistname(string username, string boardid, string playlistname)
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
      new SqlParameter("@UserName", username),
                new SqlParameter("@BoardId", boardid),
                new SqlParameter("@playlistname", playlistname)


            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[config].[GetPlayListDataByBoardIdAndUserName]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return dataTable;


        }
        public static void DeletePlaylist()
        {


            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            int rowsAffected = 0;

            try
            {
                var parameters = new List<SqlParameter>
                {

                };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[DeleteOutdatedPlaylists]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

        }
        public static int DeletePlaylist(string username, string boardId, string playlistName, DateTime date)
        {


            SqlParameter returnParameter = new SqlParameter
            {
                Direction = ParameterDirection.ReturnValue
            };


            int rowsAffected = 0;

            try
            {
                var parameters = new List<SqlParameter>
                {
                      new SqlParameter("@UserName", username),
                new SqlParameter("@BoardId", boardId),
               new SqlParameter("@PlayListName", playlistName),
                new SqlParameter("@Date", date),
                returnParameter
                 };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[Delete_PlayListSp]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return rowsAffected; // Or rethrow the exception if preferred
            }
            return rowsAffected;



        }

    }
}
