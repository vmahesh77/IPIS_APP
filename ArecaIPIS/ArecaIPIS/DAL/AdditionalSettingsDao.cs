using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArecaIPIS.DAL
{
    class AdditionalSettingsDao
    {
        public static DataTable PlatformNumberSize()
        {
            DataTable dt = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dt = (DataTable)DbConnection.ExecuteSps("[dbo].[GetTopPlatformNumberSize]", parameters, BaseClass.TypeDataTable);

               
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return dt;
        }
        public static List<string> getCoachAnnSeq()
        {
            List<string> CoachAnnSeq = new List<string>();


            DataTable dt = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dt = (DataTable)DbConnection.ExecuteSps("[dbo].[getCoachAnnSeqSP]", parameters, BaseClass.TypeDataTable);

                foreach (DataRow row in dt.Rows)
                {

                    CoachAnnSeq.Add(row["Language"].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return CoachAnnSeq;
        }

        public static List<string> getCoachAnnConstants()
        {
            List<string> CoachAnnconst = new List<string>();


            DataTable dt = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dt = (DataTable)DbConnection.ExecuteSps("[dbo].[getCoachAnnConstantsSP]", parameters, BaseClass.TypeDataTable);

                foreach (DataRow row in dt.Rows)
                {

                    CoachAnnconst.Add(row["CoachConstants"].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

            return CoachAnnconst;
        }
        public static DataTable GetCoachClassesData()
        {
            DataTable dt = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                };
                dt = (DataTable)DbConnection.ExecuteSps("[dbo].[GetAllCoachesClasses]", parameters, BaseClass.TypeDataTable);


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            BaseClass.AllCoachesClass = dt;
            return dt;
        }
        public static void DeleteCoachClass(string className)
        {
            int res = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@ClassName", className)
                };
                res = (int)DbConnection.ExecuteSps("[dbo].[DeleteCoachClassByClassName]", parameters, BaseClass.TypeInt);


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
           
        }
        public static void InsertCoachClass(string ClassName,string AudioName,string coachCode,string AudioPath)
        {
            int res = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@ClassName", ClassName),
                     new SqlParameter("@AudioName", AudioName),
                      new SqlParameter("@CoachCode", coachCode),
                     new SqlParameter("@AudioPath", AudioPath)
                };
                res = (int)DbConnection.ExecuteSps("[dbo].[InsertOrUpdateCoachClass]", parameters, BaseClass.TypeInt);


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

        }
        public static DataTable retrieveCoachClass(string ClassName)
        {
            DataTable dt = new DataTable();
            try
            {
                var parameters = new List<SqlParameter>
                {
                     new SqlParameter("@ClassName", ClassName)
                     
                };
                dt = (DataTable)DbConnection.ExecuteSps("[dbo].[GetCoachClassByClassName]", parameters, BaseClass.TypeDataTable);


            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
            return dt;

        }
    }
}
