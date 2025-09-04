using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class UserDb
    {
        public static DataTable GetAdminRoles()
        {
            DataTable Result = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                Result = (DataTable)DbConnection.ExecuteSps("[config].[GetAllRolesSP]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return Result; // Or rethrow the exception if preferred
            }
            return Result;
        }
        public static DataTable GetVersion()
        {
            DataTable Result = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                Result = (DataTable)DbConnection.ExecuteSps("getApplicationVersionSP", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return Result; // Or rethrow the exception if preferred
            }
            return Result;
        }

        public static DataTable GetAllUsers()
        {
            DataTable Result = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                Result = (DataTable)DbConnection.ExecuteSps("[config].[GetAllUsersSp]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return Result; // Or rethrow the exception if preferred
            }
            return Result;

        }

        public static DataTable GetMenus()
        {
            DataTable Result = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                Result = (DataTable)DbConnection.ExecuteSps("[Admins].[sp_GetAllMenusSp]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return Result; // Or rethrow the exception if preferred
            }
            return Result;


        }

        public static DataTable GetUsers()
        {


            DataTable Result = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                Result = (DataTable)DbConnection.ExecuteSps("[Admins].[GetUsers]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return Result; // Or rethrow the exception if preferred
            }
            return Result;



        }
        public static int InsertUpdateUserDetails(int userId, string login, string password, int role, string rawPassword, bool active)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@Login", login),
                new SqlParameter("@Password", password),
                new SqlParameter("@Role", role),
                new SqlParameter("@RawPassword", rawPassword),
                new SqlParameter("@Active", active)
            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertOrUpdateUsersp]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return rowsAffected; // Or rethrow the exception if preferred
            }
            return rowsAffected;
        }

        public static int InsertUpdateUserGroups(int pkRole, string pkMenus)
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
                      new SqlParameter("@Fkey_Role", pkRole),
                   new SqlParameter("@Fkeys_Menu", pkMenus),
                   returnParameter
                 };
                rowsAffected = (int)DbConnection.ExecuteSps("[Admins].[sp_InsertOrUpdateAdminResource]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return rowsAffected; // Or rethrow the exception if preferred
            }
            return rowsAffected;


        }

        public static DataTable GetResourcesbyRole(int fKey)
        {


            DataTable dataTable = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                new SqlParameter("@Fkey_Role", fKey)

            };
                dataTable = (DataTable)DbConnection.ExecuteSps("[Admins].[sp_GetAdminResourceByRole]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return dataTable; // Or rethrow the exception if preferred
            }
            return dataTable;


        }
    }
}
