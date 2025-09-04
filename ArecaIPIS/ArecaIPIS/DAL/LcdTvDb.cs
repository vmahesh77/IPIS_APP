using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class LcdTvDb
    {
        private DbConnection dbConnection;

        public LcdTvDb()
        {
            dbConnection = new DbConnection();
        }

        public void InsertcctvSettings(bool coachInfoChk, bool VideoDisplay, bool MessageDisplay, string DefaultMessage, int DateFormat, int scrollingSpeed, string filepath,
                                    string HeaderBackColor, string HeaderForeColor, string HeaderFont, int HeaderFontSize,
                                    string DisplayHeadersBackColor, string DisplayHeadersForeColor, string DisplayHeadersFont, int DisplayHeadersFontSize,
                                    string TrainDetailsBackColor, string TrainDetailsForeColor, string TrainDetailsFont, int TrainDetailsFontSize,
                                    string GeneralMessageBackColor, string GeneralMessageForeColor, string GeneralMessageFont, int GeneralMessageFontSize,
                                    string CoachBackColor, string CoachForeColor, string CoachFont, int CoachFontSize,
                                    string FooterBackColor, string FooterForeColor, string FooterFont, int FooterFontSize)
        {
            int rowsAffected = 0;
            try
            {
                var parameters = new List<SqlParameter>
                {


                 new SqlParameter("@coachInfoChk", coachInfoChk),
                new SqlParameter("@VideoDisplay", VideoDisplay),
                new SqlParameter("@MessageDisplay", MessageDisplay),
                new SqlParameter("@DefaultMessage", DefaultMessage),
                new SqlParameter("@DateFormat", DateFormat),
                new SqlParameter("@scrollingSpeed", scrollingSpeed),
                new SqlParameter("@filepath", filepath),
                new SqlParameter("@HeaderBackColor", HeaderBackColor),
                new SqlParameter("@HeaderForeColor", HeaderForeColor),
                new SqlParameter("@HeaderFont", HeaderFont),
                new SqlParameter("@HeaderFontSize", HeaderFontSize),
                new SqlParameter("@DisplayHeadersBackColor", DisplayHeadersBackColor),
                new SqlParameter("@DisplayHeadersForeColor", DisplayHeadersForeColor),
                new SqlParameter("@DisplayHeadersFont", DisplayHeadersFont),
                new SqlParameter("@DisplayHeadersFontSize", DisplayHeadersFontSize),
                new SqlParameter("@TrainDetailsBackColor", TrainDetailsBackColor),
                new SqlParameter("@TrainDetailsForeColor", TrainDetailsForeColor),
                new SqlParameter("@TrainDetailsFont", TrainDetailsFont),
                new SqlParameter("@TrainDetailsFontSize", TrainDetailsFontSize),
                new SqlParameter("@GeneralMessageBackColor", GeneralMessageBackColor),
                new SqlParameter("@GeneralMessageForeColor", GeneralMessageForeColor),
                new SqlParameter("@GeneralMessageFont", GeneralMessageFont),
                new SqlParameter("@GeneralMessageFontSize", GeneralMessageFontSize),
                new SqlParameter("@CoachBackColor", CoachBackColor),
                new SqlParameter("@CoachForeColor", CoachForeColor),
                new SqlParameter("@CoachFont", CoachFont),
                new SqlParameter("@CoachFontSize", CoachFontSize),
                new SqlParameter("@FooterBackColor", FooterBackColor),
                new SqlParameter("@FooterForeColor", FooterForeColor),
                new SqlParameter("@FooterFont", FooterFont),
                new SqlParameter("@FooterFontSize", FooterFontSize),

            };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertCCTVSettingsSP]", parameters, BaseClass.TypeInt);




                if (rowsAffected > 0)
                {
                    MessageBox.Show("Settings inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to insert settings.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }
        }


        public int updatecctvSettings(int pkValue, bool coachInfoChk, bool VideoDisplay, bool MessageDisplay, string DefaultMessage, int DateFormat, int scrollingSpeed, string filepath,
                                    string HeaderBackColor, string HeaderForeColor, string HeaderFont, int HeaderFontSize,
                                    string DisplayHeadersBackColor, string DisplayHeadersForeColor, string DisplayHeadersFont, int DisplayHeadersFontSize,
                                    string TrainDetailsBackColor, string TrainDetailsForeColor, string TrainDetailsFont, int TrainDetailsFontSize,
                                    string GeneralMessageBackColor, string GeneralMessageForeColor, string GeneralMessageFont, int GeneralMessageFontSize,
                                    string CoachBackColor, string CoachForeColor, string CoachFont, int CoachFontSize,
                                    string FooterBackColor, string FooterForeColor, string FooterFont, int FooterFontSize, bool SameWindow)
        {
            int rowsAffected = 0;
            DialogResult result = MessageBox.Show("Do you want to save these settings?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MakeCCTVSetingChangesToTrue();

                try
                {
                    var parameters = new List<SqlParameter>
                       {


                        // Add parameters
                        new SqlParameter("@pkValue", pkValue),
                        new SqlParameter("@coachInfoChk", coachInfoChk),
                        new SqlParameter("@VideoDisplay", VideoDisplay),
                        new SqlParameter("@MessageDisplay", MessageDisplay),
                        new SqlParameter("@DefaultMessage", DefaultMessage),
                        new SqlParameter("@DateFormat", DateFormat),
                        new SqlParameter("@scrollingSpeed", scrollingSpeed),
                        new SqlParameter("@filepath", filepath),
                        new SqlParameter("@HeaderBackColor", HeaderBackColor),
                        new SqlParameter("@HeaderForeColor", HeaderForeColor),
                        new SqlParameter("@HeaderFont", HeaderFont),
                        new SqlParameter("@HeaderFontSize", HeaderFontSize),
                        new SqlParameter("@DisplayHeadersBackColor", DisplayHeadersBackColor),
                        new SqlParameter("@DisplayHeadersForeColor", DisplayHeadersForeColor),
                        new SqlParameter("@DisplayHeadersFont", DisplayHeadersFont),
                        new SqlParameter("@DisplayHeadersFontSize", DisplayHeadersFontSize),
                        new SqlParameter("@TrainDetailsBackColor", TrainDetailsBackColor),
                        new SqlParameter("@TrainDetailsForeColor", TrainDetailsForeColor),
                        new SqlParameter("@TrainDetailsFont", TrainDetailsFont),
                        new SqlParameter("@TrainDetailsFontSize", TrainDetailsFontSize),
                        new SqlParameter("@GeneralMessageBackColor", GeneralMessageBackColor),
                        new SqlParameter("@GeneralMessageForeColor", GeneralMessageForeColor),
                        new SqlParameter("@GeneralMessageFont", GeneralMessageFont),
                        new SqlParameter("@GeneralMessageFontSize", GeneralMessageFontSize),
                        new SqlParameter("@CoachBackColor", CoachBackColor),
                        new SqlParameter("@CoachForeColor", CoachForeColor),
                        new SqlParameter("@CoachFont", CoachFont),
                        new SqlParameter("@CoachFontSize", CoachFontSize),
                        new SqlParameter("@FooterBackColor", FooterBackColor),
                        new SqlParameter("@FooterForeColor", FooterForeColor),
                        new SqlParameter("@FooterFont", FooterFont),
                        new SqlParameter("@FooterFontSize", FooterFontSize),
                        new SqlParameter("@SameWindowChk", SameWindow),



                       };
                    rowsAffected = (int)DbConnection.ExecuteSps("[config].[InsertOrUpdateCCTVSettingsSP]", parameters, BaseClass.TypeInt);

                 


                    if (rowsAffected >= 0)
                    {
                        MessageBox.Show("Settings inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return rowsAffected;
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert settings.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return rowsAffected;
                    }

                }
                catch (Exception ex)
                {

                    Server.LogError("Error inserting settings: " + ex.Message);
                    return rowsAffected;
                }
            }
            return rowsAffected;
        }




        public int SaveCCTVColorInfo(
          string Color1, string Color2, string Color3, string Color4, string Color5,
string Color6, string Color7, string Color8, string Color9, string Color10,
string Color11, string Color12, string Color13, string Color14, string Color15,
string Color16, string Color17, string Color18, string Color19, string Color20,
string Color21, string Color22, string Color23, string Color24, string Color25,
string Color26, string Color27, string Color28, string Color29, string Color30,
string Color31, string Color32, string Color33, string Color34, string Color35,
string Color36, string Color37, string Color38, string Color39, string Color40,
string Color41, string Color42, string Color43, string Color44, string Color45,
string Color46, string Color47, string Color48, string Color49, string Color50,
string Color51, string Color52, string Color53, string Color54, string Color55,
string Color56, string Color57, string Color58, string Color59, string Color60,
string Color61, string Color62, string Color63, string Color64, string Color65,
string Color66, string Color67, string Color68, string Color69, string Color70,
string Color71, string Color72, string Color73, string Color74, string Color75,
string Color76, string Color77, string Color78, string Color79, string Color80,
string Color81, string Color82, string Color83, string Color84, string Color85,
string Color86, string Color87, string Color88, string Color89, string Color90,
string Color91, string Color92, string Color93, string Color94, string Color95,
string Color96, string Color97, string Color98, string Color99, string Color100,
string Color101, string Color102, string Color103, string Color104, string Color105
   )
        {
            try
            {
                var parameters = new List<SqlParameter>();

                // Create a list of all color parameters
                string[] colorParameters = new[]
                {
            Color1, Color2, Color3, Color4, Color5,
Color6, Color7, Color8, Color9, Color10,
Color11, Color12, Color13, Color14, Color15,
Color16, Color17, Color18, Color19, Color20,
Color21, Color22, Color23, Color24, Color25,
Color26, Color27, Color28, Color29, Color30,
Color31, Color32, Color33, Color34, Color35,
Color36, Color37, Color38, Color39, Color40,
Color41, Color42, Color43, Color44, Color45,
Color46, Color47, Color48, Color49, Color50,
Color51, Color52, Color53, Color54, Color55,
Color56, Color57, Color58, Color59, Color60,
Color61, Color62, Color63, Color64, Color65,
Color66, Color67, Color68, Color69, Color70,
Color71, Color72, Color73, Color74, Color75,
Color76, Color77, Color78, Color79, Color80,
Color81, Color82, Color83, Color84, Color85,
Color86, Color87, Color88, Color89, Color90,
Color91, Color92, Color93, Color94, Color95,
Color96, Color97, Color98, Color99, Color100,
Color101,Color102,Color103,Color104,Color105

        };

                for (int i = 0; i < colorParameters.Length; i++)
                {
                    parameters.Add(new SqlParameter($"@Color{i + 1}", colorParameters[i]));
                }

                // Execute the stored procedure                     [config].[SaveColorCofigurationInfo]
                int rowsAffected = (int)DbConnection.ExecuteSps("[config].[SaveColorCofigurationInfo]", parameters, BaseClass.TypeInt);

                return rowsAffected;
            }
            catch (Exception ex)
            {

                Server.LogError(ex.ToString());
                return -1;
            }
        }


        public static DataTable GetCctvColorSettings()
        {

            DataTable Result = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                Result = (DataTable)DbConnection.ExecuteSps("[config].[GetCCTVColorInfo]", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return Result; // Or rethrow the exception if preferred
            }
            return Result;


        }

        public static void MakeCCTVSetingChangesToTrue()
        {

            
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                
               string result=(string)DbConnection.ExecuteSps("[dbo].[InsertcctvTrueIntoSettingsStatusSP]", parameters, BaseClass.TypeString);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
               
            }
          


        }

        public static DataTable GetCctvSettings()
        {


            DataTable Result = new DataTable();
            try
            {

                var parameters = new List<SqlParameter>
                {

                };
                Result = (DataTable)DbConnection.ExecuteSps("[config].GetCctvsettingsSp", parameters, BaseClass.TypeDataTable);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                return Result; // Or rethrow the exception if preferred
            }
            return Result;


        }


        public static void UpdatecctvStatus(bool status)
        {
            int rowsAffected = 0;

            try
            {
                var parameters = new List<SqlParameter>
                {
                      new SqlParameter("@Status", status)


                 };
                rowsAffected = (int)DbConnection.ExecuteSps("[config].[CCTVUpdateStatusNew]", parameters, BaseClass.TypeInt);

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());

            }

        }


    }
}
