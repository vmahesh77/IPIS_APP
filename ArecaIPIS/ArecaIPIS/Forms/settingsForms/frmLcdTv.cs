using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmLcdTv : Form
    {
        // private frmHome parentForm;

        public frmLcdTv()
        {
            InitializeComponent();
        }
        LcdTvDb lcdTvDb = new LcdTvDb();

        private frmIndex parentForm;

        public frmLcdTv(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void frmLcdTv_Load(object sender, EventArgs e)
        {

            setCctvsettings();
            SetCctvColorConfigurationSettings();

        }
        private void setCctvsettings()
        {
            try
            {
                // Call the method to get CCTV settings and store the result in a DataTable
                DataTable cctv = LcdTvDb.GetCctvSettings();

                // Check if the DataTable is not null
                if (cctv != null)
                {
                    // Check if the DataTable has any rows
                    if (cctv.Rows.Count > 0)
                    {
                        // Process the data as needed
                        foreach (DataRow row in cctv.Rows)
                        {
                            bool coachInfoChecked = (bool)row["CoachInfoChk"];
                            cbCoachInfoDisplay.Checked = coachInfoChecked;

                            bool messageChecked = (bool)row["MessageChk"];
                            cbMessageDisplay.Checked = messageChecked;

                            bool videoChecked = (bool)row["VideoChk"];
                            cbVideoDisplay.Checked = videoChecked;

                            bool windowChecked = (bool)row["SameWindow"];
                            cbSameWindow.Checked = windowChecked;

                            txtboxDefaultMessage.Text = row["DefaultMsg"].ToString();


                            //if(row["DateFormat"].ToString().Length == 0)
                            //{
                            //    cmbDateFormat.Text = "DD/MM/YY";
                            //}
                            //else
                            //{
                            //    cmbDateFormat.Text = row["DateFormat"].ToString();

                            //}

                            if (string.IsNullOrEmpty(row["DateFormat"].ToString()))
                            {
                                cmbDateFormat.Text = "DD/MM/YY";
                            }
                            else if (row["DateFormat"].ToString() == "1")
                            {
                                cmbDateFormat.SelectedIndex = 0;
                            }
                            else if (row["DateFormat"].ToString() == "2")
                            {
                                cmbDateFormat.SelectedIndex = 1;
                            }


                            int scrollingSpeed = (int)row["ScrollingSpeed1"];

                            if (scrollingSpeed == 300)
                            {
                                cmbScrollingSpeed.Text = "Very Fast";
                            }
                            else if (scrollingSpeed == 250)
                            {
                                cmbScrollingSpeed.Text = "Fast";
                            }
                            else if (scrollingSpeed == 200)
                            {
                                cmbScrollingSpeed.Text = "Normal";
                            }
                            else if (scrollingSpeed == 100)
                            {
                                cmbScrollingSpeed.Text = "Slow";
                            }
                            else if (scrollingSpeed == 50)
                            {
                                cmbScrollingSpeed.Text = "Very Slow";
                            }
                            else
                            {
                                // Default value or error handling if the selected item is not recognized
                                cmbScrollingSpeed.Text = "Default speed"; // Or any other default value
                            }


                            //HEADER

                            txtHeaderBackClr.Text = row["HBGColor"].ToString();
                            string colorString = row["HBGColor"].ToString();
                            txtHeaderBackClr.BackColor = ColorTranslator.FromHtml(colorString);

                            txtHeaderForeClr.Text = row["HFGColor"].ToString();
                            string colorString1 = row["HFGColor"].ToString();
                            txtHeaderForeClr.BackColor = ColorTranslator.FromHtml(colorString1);

                            cmbHeaderFont.Text = row["Hfont"].ToString();

                            cmbHeaderFontSize.Text = row["HfontSize"].ToString();


                            //TRAIN DISPLAY

                            txtTrainDisplayBackClr.Text = row["TBFGColor"].ToString();
                            string colorString9 = row["TBFGColor"].ToString();
                            txtTrainDisplayBackClr.BackColor = ColorTranslator.FromHtml(colorString9);

                            txtTrainDisplayForeClr.Text = row["TFGColor"].ToString();
                            string colorString2 = row["TFGColor"].ToString();
                            txtTrainDisplayForeClr.BackColor = ColorTranslator.FromHtml(colorString2);

                            cmbTrainDisplayFont.Text = row["Tfont"].ToString();

                            cmbTrainDisplayFontSize.Text = row["TfontSize"].ToString();

                            //TRAIN DETAILS

                            txtTrainDetailsForeClr.Text = row["TDFGColor"].ToString();
                            string colorString3 = row["TFGColor"].ToString();
                            txtTrainDetailsForeClr.BackColor = ColorTranslator.FromHtml(colorString3);

                            txtTrainDetailsBackClr.Text = row["TBDFGColor"].ToString();
                            string colorString10 = row["TBDFGColor"].ToString();
                            txtTrainDetailsBackClr.BackColor = ColorTranslator.FromHtml(colorString10);

                            cmbTrainDetailsFont.Text = row["TDfont"].ToString();

                            cmbTrainDetailsFontSize.Text = row["TDfontSize"].ToString();

                            //GENERAL MESSAGE

                            txtGeneralMessageBackClr.Text = row["MBGColor"].ToString();
                            string colorString4 = row["MBGColor"].ToString();
                            txtGeneralMessageBackClr.BackColor = ColorTranslator.FromHtml(colorString4);

                            txtGeneralMessageForeClr.Text = row["MFGColor"].ToString();
                            string colorString5 = row["MFGColor"].ToString();
                            txtGeneralMessageForeClr.BackColor = ColorTranslator.FromHtml(colorString5);

                            cmbGeneralMessageFont.Text = row["Mfgfont"].ToString();

                            cmbGeneralMessageFontSize.Text = row["MfontSize"].ToString();

                            //COACH SETTINGS

                            txtCoachSettingsBackClr.Text = row["CBGColor"].ToString();
                            string colorString6 = row["CBGColor"].ToString();
                            txtCoachSettingsBackClr.BackColor = ColorTranslator.FromHtml(colorString6);

                            txtCoachSettingsForeClr.Text = row["CFGColor"].ToString();
                            string colorString7 = row["CFGColor"].ToString();
                            txtCoachSettingsForeClr.BackColor = ColorTranslator.FromHtml(colorString7);

                            cmbCoachSettingsFont.Text = row["Cfont"].ToString();

                            cmbCoachSettingsFontSize.Text = row["CfontSize"].ToString();


                            //FOOTER

                            txtFooterSettingsBackClr.Text = row["FBGColor"].ToString();
                            string colorString8 = row["FBGColor"].ToString();
                            txtFooterSettingsBackClr.BackColor = ColorTranslator.FromHtml(colorString8);

                            txtFooterSettingsForeClr.Text = row["FFGColor"].ToString();
                            string colorString11 = row["FFGColor"].ToString();
                            txtFooterSettingsForeClr.BackColor = ColorTranslator.FromHtml(colorString11);

                            cmbFooterSettingsFont.Text = row["Ffont"].ToString();

                            cmbFooterSettingsFontSize.Text = row["FfontSize"].ToString();

                        }
                        // Optionally, update UI or perform other operations
                    }
                    else
                    {
                        MessageBox.Show("No CCTV settings found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve CCTV settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        // Method to set button properties (for example, setting the Text or Color of the button)



        public void SetButtonProperties(Button button, string hexColor)
        {
            if (button != null)
            {
                // Set the text of the TextBox to the hex color value
                button.Text = hexColor;

                // Convert the hex color code to a Color and set the back color of the TextBox
                try
                {
                    Color color = ColorTranslator.FromHtml(hexColor);
                    button.BackColor = color;
                }
                catch (Exception ex)
                {
                    // Handle the exception if the hex color code is invalid
                    //  MessageBox.Show($"Invalid color code: {hexColor}. Error: {ex.Message}");
                }
            }
        }
        private void SetCctvColorConfigurationSettings()
        {
            try
            {
                // Assuming LcdTvDb.GetCctvColorSettings() retrieves the color configuration from the database
                DataTable cctvColor = LcdTvDb.GetCctvColorSettings();

                if (cctvColor != null && cctvColor.Rows.Count > 0)
                {
                    foreach (DataRow row in cctvColor.Rows)
                    {
                        int statusFkey = Convert.ToInt32(row["StatusFkey"]);
                        switch (statusFkey)
                        {
                            case 1: // Arrival RRT
                                SetButtonProperties(btnArrRRTTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnArrRRTTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnArrRRTTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnArrRRTTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnArrRRTTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 2: // Arrival WAS
                                SetButtonProperties(btnArrWASTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnArrWASTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnArrWASTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnArrWASTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnArrWASTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 3: // Arrival IAO
                                SetButtonProperties(btnArrIAOTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnArrIAOTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnArrIAOTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnArrIAOTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnArrIAOTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 4: // Arrival HAO
                                SetButtonProperties(btnArrHAOTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnArrHAOTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnArrHAOTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnArrHAOTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnArrHAOTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 5: // Arrival RL
                                SetButtonProperties(btnArrRLTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnArrRLTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnArrRLTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnArrRLTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnArrRLTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 6: // Arrival C
                                SetButtonProperties(btnArrCTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnArrCTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnArrCTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnArrCTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnArrCTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 7: // Arrival IL
                                SetButtonProperties(btnArrILTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnArrILTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnArrILTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnArrILTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnArrILTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 21: // Arrival T
                                SetButtonProperties(btnArrTTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnArrTTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnArrTTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnArrTTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnArrTTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 9: // Arrival PC
                                SetButtonProperties(btnArrPCTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnArrPCTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnArrPCTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnArrPCTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnArrPCTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 8: // Arrival TA
                                SetButtonProperties(btnArrTATrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnArrTATrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnArrTATrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnArrTATrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnArrTATrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 10: // Departure RRT
                                SetButtonProperties(btnDepRRTTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnDepRRTTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnDepRRTTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnDepRRTTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnDepRRTTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 11: // Departure C
                                SetButtonProperties(btnDepCTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnDepCTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnDepCTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnDepCTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnDepCTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 12: // Departure IRTL
                                SetButtonProperties(btnDepIRTLTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnDepIRTLTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnDepIRTLTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnDepIRTLTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnDepIRTLTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 13: // Departure IOP
                                SetButtonProperties(btnDepIOPTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnDepIOPTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnDepIOPTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnDepIOPTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnDepIOPTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 14: // Departure D
                                SetButtonProperties(btnDepDTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnDepDTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnDepDTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnDepDTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnDepDTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 15: // Departure R
                                SetButtonProperties(btnDepRTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnDepRTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnDepRTraintimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnDepRTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnDepRTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 16: // Departure Div
                                SetButtonProperties(btnDepDivTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnDepDivTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnDepDivTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnDepDivTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnDepDivTrainPFCCTV, row["TrainPF"].ToString());
                                break;
                            case 17:
                                SetButtonProperties(btnDepDDTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnDepDDTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnDepDDTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnDepDDTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnDepDDTrainPFCCTV, row["TrainPF"].ToString());
                                break;
                            case 18:
                                SetButtonProperties(btnDepPCTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnDepPCTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnDepPCTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnDepPCTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnDepPCTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 19:
                                SetButtonProperties(btnDepCoSTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnDepCoSTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnDepCoSTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnDepCoSTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnDepCoSTrainPFCCTV, row["TrainPF"].ToString());
                                break;

                            case 20:
                                SetButtonProperties(btnDepRegTrainNumberCCTV, row["TrainNumber"].ToString());
                                SetButtonProperties(btnDepRegTrainNameCCTV, row["TrainName"].ToString());
                                SetButtonProperties(btnDepRegTrainTimeCCTV, row["TrainTime"].ToString());
                                SetButtonProperties(btnDepRegTrainADCCTV, row["TrainAD"].ToString());
                                SetButtonProperties(btnDepRegTrainPFCCTV, row["TrainPF"].ToString());

                                break;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }



        }









        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                if (!string.IsNullOrEmpty(txtboxDefaultMessage.Text))
                {
                    //normalValues
                    bool coachInfoChk = cbCoachInfoDisplay.Checked;
                    bool VideoDisplayChk = cbVideoDisplay.Checked;
                    bool MessageDisplayChk = cbMessageDisplay.Checked;
                    bool SameWindowChk = cbSameWindow.Checked;
                    string DefaultMessage = txtboxDefaultMessage.Text;
                    int DateFormatvalue = 0;

                    string Color00 = btnArrRRTTrainNumberCCTV.Text;
                    string Color10 = btnArrRRTTrainNameCCTV.Text;
                    string Color20 = btnArrRRTTrainTimeCCTV.Text;
                    string Color30 = btnArrRRTTrainADCCTV.Text;
                    string Color40 = btnArrRRTTrainPFCCTV.Text;

                    string Color01 = btnArrWASTrainNumberCCTV.Text;
                    string Color11 = btnArrWASTrainNameCCTV.Text;
                    string Color21 = btnArrWASTrainTimeCCTV.Text;
                    string Color31 = btnArrWASTrainADCCTV.Text;
                    string Color41 = btnArrWASTrainPFCCTV.Text;

                    string Color02 = btnArrIAOTrainNumberCCTV.Text;
                    string Color12 = btnArrIAOTrainNameCCTV.Text;
                    string Color22 = btnArrIAOTrainTimeCCTV.Text;
                    string Color32 = btnArrIAOTrainADCCTV.Text;
                    string Color42 = btnArrIAOTrainPFCCTV.Text;


                    string Color03 = btnArrHAOTrainNumberCCTV.Text;
                    string Color13 = btnArrHAOTrainNameCCTV.Text;
                    string Color23 = btnArrHAOTrainTimeCCTV.Text;
                    string Color33 = btnArrHAOTrainADCCTV.Text;
                    string Color43 = btnArrHAOTrainPFCCTV.Text;

                    string Color04 = btnArrRLTrainNumberCCTV.Text;
                    string Color14 = btnArrRLTrainNameCCTV.Text;
                    string Color24 = btnArrRLTrainTimeCCTV.Text;
                    string Color34 = btnArrRLTrainADCCTV.Text;
                    string Color44 = btnArrRLTrainPFCCTV.Text;

                    string Color05 = btnArrCTrainNumberCCTV.Text;
                    string Color15 = btnArrCTrainNameCCTV.Text;
                    string Color25 = btnArrCTrainTimeCCTV.Text;
                    string Color35 = btnArrCTrainADCCTV.Text;
                    string Color45 = btnArrCTrainPFCCTV.Text;

                    string Color06 = btnArrILTrainNumberCCTV.Text;
                    string Color16 = btnArrILTrainNameCCTV.Text;
                    string Color26 = btnArrILTrainTimeCCTV.Text;
                    string Color36 = btnArrILTrainADCCTV.Text;
                    string Color46 = btnArrILTrainPFCCTV.Text;

                    string Color07 = btnArrTTrainNumberCCTV.Text;
                    string Color17 = btnArrTTrainNameCCTV.Text;
                    string Color27 = btnArrTTrainTimeCCTV.Text;
                    string Color37 = btnArrTTrainADCCTV.Text;
                    string Color47 = btnArrTTrainPFCCTV.Text;

                    string Color08 = btnArrPCTrainNumberCCTV.Text;
                    string Color18 = btnArrPCTrainNameCCTV.Text;
                    string Color28 = btnArrPCTrainTimeCCTV.Text;
                    string Color38 = btnArrPCTrainADCCTV.Text;
                    string Color48 = btnArrPCTrainPFCCTV.Text;


                    string Color09 = btnDepRRTTrainNumberCCTV.Text;
                    string Color19 = btnDepRRTTrainNameCCTV.Text;
                    string Color29 = btnDepRRTTrainTimeCCTV.Text;
                    string Color39 = btnDepRRTTrainADCCTV.Text;
                    string Color49 = btnDepRRTTrainPFCCTV.Text;

                    string Color010 = btnDepCTrainNumberCCTV.Text;
                    string Color110 = btnDepCTrainNameCCTV.Text;
                    string Color210 = btnDepCTrainTimeCCTV.Text;
                    string Color310 = btnDepCTrainADCCTV.Text;
                    string Color410 = btnDepCTrainPFCCTV.Text;

                    string Color011 = btnDepIRTLTrainNumberCCTV.Text;
                    string Color111 = btnDepIRTLTrainNameCCTV.Text;
                    string Color211 = btnDepIRTLTrainTimeCCTV.Text;
                    string Color311 = btnDepIRTLTrainADCCTV.Text;
                    string Color411 = btnDepIRTLTrainPFCCTV.Text;

                    string Color012 = btnDepIOPTrainNumberCCTV.Text;
                    string Color112 = btnDepIOPTrainNameCCTV.Text;
                    string Color212 = btnDepIOPTrainTimeCCTV.Text;
                    string Color312 = btnDepIOPTrainADCCTV.Text;
                    string Color412 = btnDepIOPTrainPFCCTV.Text;

                    string Color013 = btnDepDTrainNumberCCTV.Text;
                    string Color113 = btnDepDTrainNameCCTV.Text;
                    string Color213 = btnDepDTrainTimeCCTV.Text;
                    string Color313 = btnDepDTrainADCCTV.Text;
                    string Color413 = btnDepDTrainPFCCTV.Text;

                    string Color014 = btnDepRTrainNumberCCTV.Text;
                    string Color114 = btnDepRTrainNameCCTV.Text;
                    string Color214 = btnDepRTraintimeCCTV.Text;
                    string Color314 = btnDepRTrainADCCTV.Text;
                    string Color414 = btnDepRTrainPFCCTV.Text;

                    string Color015 = btnDepDivTrainNumberCCTV.Text;
                    string Color115 = btnDepDivTrainNameCCTV.Text;
                    string Color215 = btnDepDivTrainTimeCCTV.Text;
                    string Color315 = btnDepDivTrainADCCTV.Text;
                    string Color415 = btnDepDivTrainPFCCTV.Text;

                    string Color016 = btnDepDDTrainNumberCCTV.Text;
                    string Color116 = btnDepDDTrainNameCCTV.Text;
                    string Color216 = btnDepDDTrainTimeCCTV.Text;
                    string Color316 = btnDepDDTrainADCCTV.Text;
                    string Color416 = btnDepDDTrainPFCCTV.Text;

                    string Color017 = btnDepPCTrainNumberCCTV.Text;
                    string Color117 = btnDepPCTrainNameCCTV.Text;
                    string Color217 = btnDepPCTrainTimeCCTV.Text;
                    string Color317 = btnDepPCTrainADCCTV.Text;
                    string Color417 = btnDepPCTrainPFCCTV.Text;

                    //NewAdded
                    string Color018 = btnArrTATrainNumberCCTV.Text;
                    string Color118 = btnArrTATrainNameCCTV.Text;
                    string Color218 = btnArrTATrainTimeCCTV.Text;
                    string Color318 = btnArrTATrainADCCTV.Text;
                    string Color418 = btnArrTATrainPFCCTV.Text;

                    string Color019 = btnDepCoSTrainNumberCCTV.Text;
                    string Color119 = btnDepCoSTrainNameCCTV.Text;
                    string Color219 = btnDepCoSTrainTimeCCTV.Text;
                    string Color319 = btnDepCoSTrainADCCTV.Text;
                    string Color419 = btnDepCoSTrainPFCCTV.Text;


                    string Color020 = btnDepRegTrainNumberCCTV.Text;
                    string Color120 = btnDepRegTrainNameCCTV.Text;
                    string Color220 = btnDepRegTrainTimeCCTV.Text;
                    string Color320 = btnDepRegTrainADCCTV.Text;
                    string Color420 = btnDepRegTrainPFCCTV.Text;

                    // Check the selected index of the ComboBox
                    if (cmbDateFormat.SelectedIndex == -1)
                    {
                        DateFormatvalue = 1; // Assign value 1 if the combo box is empty
                    }
                    // Check if the first item is selected
                    else if (cmbDateFormat.SelectedIndex == 0)
                    {
                        DateFormatvalue = 1; // Assign value 1 if index 0 is selected
                    }
                    // Check if the second item is selected
                    else if (cmbDateFormat.SelectedIndex == 1)
                    {
                        DateFormatvalue = 2; // Assign value 2 if index 1 is selected
                    }

                    int scrollingSpeed;

                    string selectedSpeed = cmbScrollingSpeed.SelectedItem.ToString();

                    if (selectedSpeed == "Very Slow")
                    {
                        scrollingSpeed = 50;
                    }
                    else if (selectedSpeed == "Slow")
                    {
                        scrollingSpeed = 100;
                    }
                    else if (selectedSpeed == "Normal")
                    {
                        scrollingSpeed = 200;
                    }
                    else if (selectedSpeed == "Fast")
                    {
                        scrollingSpeed = 250;
                    }
                    else if (selectedSpeed == "Very Fast")
                    {
                        scrollingSpeed = 300;
                    }
                    else
                    {

                        scrollingSpeed = 150;
                    }

                    string filepath = txtboxFilePath.Text;

                    //Header Settings
                    string HeaderBackColor = txtHeaderBackClr.Text;
                    string HeaderForeColor = txtHeaderForeClr.Text;
                    string HeaderFont = cmbHeaderFont.Text;
                    int HeaderFontSize = int.Parse(cmbHeaderFontSize.Text);

                    //Train DisplayHeaders
                    string DisplayHeadersBackColor = txtTrainDisplayBackClr.Text;
                    string DisplayHeadersForeColor = txtTrainDisplayForeClr.Text;
                    string DisplayHeadersFont = cmbTrainDisplayFont.Text;
                    int DisplayHeadersFontSize = int.Parse(cmbTrainDisplayFontSize.Text);

                    //TrainDetailsSettings
                    string TrainDetailsBackColor = txtTrainDetailsBackClr.Text;
                    string TrainDetailsForeColor = txtTrainDetailsForeClr.Text;
                    string TrainDetailsFont = cmbTrainDetailsFont.Text;
                    int TrainDetailsFontSize = int.Parse(cmbTrainDetailsFontSize.Text);

                    //GeneralMessageDisplaySettings
                    string GeneralMessageBackColor = txtGeneralMessageBackClr.Text;
                    string GeneralMessageForeColor = txtGeneralMessageForeClr.Text;
                    string GeneralMessageFont = cmbGeneralMessageFont.Text;
                    int GeneralMessageFontSize = int.Parse(cmbGeneralMessageFontSize.Text);

                    //CoachSettings
                    string CoachBackColor = txtCoachSettingsBackClr.Text;
                    string CoachForeColor = txtCoachSettingsForeClr.Text;
                    string CoachFont = cmbCoachSettingsFont.Text;
                    int CoachFontSize = int.Parse(cmbCoachSettingsFontSize.Text);


                    //FooterSettings
                    string FooterBackColor = txtFooterSettingsBackClr.Text;
                    string FooterForeColor = txtFooterSettingsForeClr.Text;
                    string FooterFont = cmbFooterSettingsFont.Text;
                    int FooterFontSize = int.Parse(cmbFooterSettingsFontSize.Text);

                    // Call the insert function and pass the retrieved values
                    //lcdTvDb.InsertcctvSettings(coachInfoChk, VideoDisplay, MessageDisplay, DefaultMessage, DateFormatvalue, scrollingSpeed, filepath,
                    //               HeaderBackColor, HeaderForeColor, HeaderFont, HeaderFontSize,
                    //               DisplayHeadersBackColor, DisplayHeadersForeColor, DisplayHeadersFont, DisplayHeadersFontSize,
                    //               TrainDetailsBackColor, TrainDetailsForeColor, TrainDetailsFont, TrainDetailsFontSize,
                    //               GeneralMessageBackColor, GeneralMessageForeColor, GeneralMessageFont, GeneralMessageFontSize,
                    //               CoachBackColor, CoachForeColor, CoachFont, CoachFontSize,
                    //               FooterBackColor, FooterForeColor, FooterFont, FooterFontSize);

                    int affectedrows = lcdTvDb.updatecctvSettings(1, coachInfoChk, VideoDisplayChk, MessageDisplayChk, DefaultMessage, DateFormatvalue, scrollingSpeed, filepath,
                        HeaderBackColor, HeaderForeColor, HeaderFont, HeaderFontSize,
                        DisplayHeadersBackColor, DisplayHeadersForeColor, DisplayHeadersFont, DisplayHeadersFontSize,
                        TrainDetailsBackColor, TrainDetailsForeColor, TrainDetailsFont, TrainDetailsFontSize,
                        GeneralMessageBackColor, GeneralMessageForeColor, GeneralMessageFont, GeneralMessageFontSize,
                        CoachBackColor, CoachForeColor, CoachFont, CoachFontSize,
                        FooterBackColor, FooterForeColor, FooterFont, FooterFontSize, SameWindowChk);
                    int result = lcdTvDb.SaveCCTVColorInfo(Color00, Color10, Color20, Color30, Color40,
                         Color01, Color11, Color21, Color31, Color41,
                         Color02, Color12, Color22, Color32, Color42,
                         Color03, Color13, Color23, Color33, Color43,
                         Color04, Color14, Color24, Color34, Color44,
                         Color05, Color15, Color25, Color35, Color45,
                         Color06, Color16, Color26, Color36, Color46,
                         Color07, Color17, Color27, Color37, Color47,
                         Color08, Color18, Color28, Color38, Color48,
                         Color018, Color118, Color218, Color318, Color418,

                         Color09, Color19, Color29, Color39, Color49,
                         Color010, Color110, Color210, Color310, Color410,
                         Color011, Color111, Color211, Color311, Color411,
                         Color012, Color112, Color212, Color312, Color412,
                         Color013, Color113, Color213, Color313, Color413,
                         Color014, Color114, Color214, Color314, Color414,
                         Color015, Color115, Color215, Color315, Color415,
                         Color016, Color116, Color216, Color316, Color416,
                         Color017, Color117, Color217, Color317, Color417,
                         Color019, Color119, Color219, Color319, Color419,
                         Color020, Color120, Color220, Color320, Color420);
                    LcdTvDb.UpdatecctvStatus(true);
                    if (affectedrows >= 0 && result >= 0)
                    {
                        // Show success message for 10 seconds
                        lblStatus.Text = "Display Settings saved successfully!";
                        lblStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        // Show failure message for 10 seconds
                        lblStatus.Text = "Failed to  save Display Settings .";
                        lblStatus.ForeColor = Color.Red;
                    }

                    // Make the label visible
                    lblStatus.Visible = true;

                    // Start a timer to clear the label after 10 seconds
                    Timer timer = new Timer();
                    timer.Interval = 5000; // 5 seconds
                    timer.Tick += (s, _) =>
                    {
                        // Clear the label text and hide the label
                        lblStatus.Text = "";
                        lblStatus.Visible = false;

                        // Stop and dispose the timer
                        timer.Stop();
                        timer.Dispose();
                    };
                    timer.Start(); // Start the timer
                }
                else
                {
                    txtboxDefaultMessage.Text = "Welcome";
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        void InsertSettings(bool coachInfoChk, bool VideoDisplay, bool MessageDisplay, bool SameWindow, string DefaultMessage, int DateFormat, int scrollingSpeed, string filepath,
                    string HeaderBackColor, string HeaderForeColor, string HeaderFont, int HeaderFontSize,
                    string DisplayHeadersBackColor, string DisplayHeadersForeColor, string DisplayHeadersFont, int DisplayHeadersFontSize,
                    string TrainDetailsBackColor, string TrainDetailsForeColor, string TrainDetailsFont, int TrainDetailsFontSize,
                    string GeneralMessageBackColor, string GeneralMessageForeColor, string GeneralMessageFont, int GeneralMessageFontSize,
                    string CoachBackColor, string CoachForeColor, string CoachFont, int CoachFontSize,
                    string FooterBackColor, string FooterForeColor, string FooterFont, int FooterFontSize)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnCCTVSettings_Click(object sender, EventArgs e)
        {
            btnCCTVColorConfiguration.BackColor = Color.White;
            btnCCTVSettings.BackColor = Color.MediumSeaGreen;
            pnlCCTVColorConfiguration.Visible = false;
            pnlCCTVSettings.Visible = true;
        }
        private void btnCCTVColorConfiguration_Click(object sender, EventArgs e)
        {
            btnCCTVColorConfiguration.BackColor = Color.MediumSeaGreen;
            btnCCTVSettings.BackColor = Color.White;
            pnlCCTVColorConfiguration.Visible = true;
            pnlCCTVSettings.Visible = false;

            SetCctvColorConfigurationSettings();
        }

        public void CreateColorDialogBox(Button btn)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            btn.BackColor = cd.Color;
            cd.FullOpen = true;
            cd.AnyColor = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btn.BackColor = cd.Color;
                string hexColorhex = ColorTranslator.ToHtml(Color.FromArgb(cd.Color.ToArgb()));
                btn.Text = hexColorhex;

            }
        }

        private void btnArrRRTTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainNumberCCTV);
        }

        private void btnArrRRTTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainNameCCTV);
        }

        private void btnArrRRTTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainTimeCCTV);
        }

        private void btnArrRRTTrainADCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainADCCTV);
        }

        private void btnArrRRTTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainPFCCTV);
        }

        private void btnArrWASTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrWASTrainNumberCCTV);
        }

        private void btnArrWASTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrWASTrainNameCCTV);
        }

        private void btnArrWASTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrWASTrainTimeCCTV);
        }

        private void btnArrWASTrainADCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrWASTrainADCCTV);
        }

        private void btnArrWASTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrWASTrainPFCCTV);
        }

        private void btnArrIAOTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIAOTrainNumberCCTV);
        }

        private void btnArrIAOTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIAOTrainNameCCTV);
        }

        private void btnArrIAOTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIAOTrainTimeCCTV);
        }

        private void btnArrIAOTrainADCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIAOTrainADCCTV);
        }

        private void btnArrIAOTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIAOTrainPFCCTV);
        }

        private void btnArrHAOTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHAOTrainNumberCCTV);
        }

        private void btnArrHAOTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHAOTrainNameCCTV);
        }

        private void btnArrHAOTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrHAOTrainTimeCCTV);

            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    string hexColorhex = ColorTranslator.ToHtml(Color.FromArgb(colorDialog.Color.ToArgb()));
                    btnArrHAOTrainTimeCCTV.BackColor = colorDialog.Color;
                    btnArrHAOTrainTimeCCTV.Text = hexColorhex;
                    btnArrHAOTrainADCCTV.BackColor = colorDialog.Color;
                    btnArrHAOTrainADCCTV.Text = hexColorhex;
                }
            }

        }

        private void btnArrHAOTrainADCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrHAOTrainADCCTV);
        }

        private void btnArrHAOTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHAOTrainPFCCTV);
        }

        private void btnArrRLTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainNumberCCTV);
        }

        private void btnArrRLTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainNameCCTV);
        }

        private void btnArrRLTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainTimeCCTV);
        }

        private void btnArrRLTrainADCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainADCCTV);
        }

        private void btnArrRLTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainPFCCTV);
        }

        private void btnArrCTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCTrainNumberCCTV);
        }

        private void btnArrCTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCTrainNameCCTV);
        }

        private void btnArrCTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrCTrainTimeCCTV);

            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    string hexColorhex = ColorTranslator.ToHtml(Color.FromArgb(colorDialog.Color.ToArgb()));
                    btnArrCTrainTimeCCTV.BackColor = colorDialog.Color;
                    btnArrCTrainTimeCCTV.Text = hexColorhex;
                    btnArrCTrainADCCTV.BackColor = colorDialog.Color;
                    btnArrCTrainADCCTV.Text = hexColorhex;
                    btnArrCTrainPFCCTV.BackColor = colorDialog.Color;
                    btnArrCTrainPFCCTV.Text = hexColorhex;
                }
            }



        }

        private void btnArrCTrainADCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrCTrainADCCTV);
        }

        private void btnArrCTrainPFCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrCTrainPFCCTV);
        }

        private void btnArrILTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrILTrainNumberCCTV);
        }

        private void btnArrILTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrILTrainNameCCTV);
        }

        private void btnArrILTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrILTrainTimeCCTV);

            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    string hexColorhex = ColorTranslator.ToHtml(Color.FromArgb(colorDialog.Color.ToArgb()));
                    btnArrILTrainTimeCCTV.BackColor = colorDialog.Color;
                    btnArrILTrainTimeCCTV.Text = hexColorhex;
                    btnArrILTrainADCCTV.BackColor = colorDialog.Color;
                    btnArrILTrainADCCTV.Text = hexColorhex;
                    btnArrILTrainPFCCTV.BackColor = colorDialog.Color;
                    btnArrILTrainPFCCTV.Text = hexColorhex;
                }
            }
        }

        private void btnArrILTrainADCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrILTrainADCCTV);
        }

        private void btnArrILTrainPFCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrILTrainPFCCTV);
        }

        private void btnArrTTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTTrainNumberCCTV);
        }

        private void btnArrTTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTTrainNameCCTV);
        }

        private void btnArrTTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrTTrainTimeCCTV);
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    string hexColorhex = ColorTranslator.ToHtml(Color.FromArgb(colorDialog.Color.ToArgb()));
                    btnArrTTrainTimeCCTV.BackColor = colorDialog.Color;
                    btnArrTTrainTimeCCTV.Text = hexColorhex;
                    btnArrTTrainADCCTV.BackColor = colorDialog.Color;
                    btnArrTTrainADCCTV.Text = hexColorhex;
                    btnArrTTrainPFCCTV.BackColor = colorDialog.Color;
                    btnArrTTrainPFCCTV.Text = hexColorhex;
                }
            }
        }

        private void btnArrTTrainADCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrTTrainADCCTV);
        }

        private void btnArrTTrainPFCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrTTrainPFCCTV);
        }

        private void btnArrPCTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPCTrainNumberCCTV);
        }

        private void btnArrPCTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPCTrainNameCCTV);
        }

        private void btnArrPCTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPCTrainTimeCCTV);
        }

        private void btnArrPCTrainADCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPCTrainADCCTV);
        }

        private void btnArrPCTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPCTrainPFCCTV);
        }

        private void btnDepRRTTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepRRTTrainNumberCCTV);
        }

        private void btnDepRRTTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepRRTTrainNameCCTV);
        }

        private void btnDepRRTTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepRRTTrainTimeCCTV);
        }

        private void btnDepRRTTrainADCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepRRTTrainADCCTV);
        }

        private void btnDepRRTTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepRRTTrainPFCCTV);
        }

        private void btnDepCTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepCTrainNumberCCTV);
        }

        private void btnDepCTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepCTrainNameCCTV);
        }

        private void btnDepCTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnDepCTrainTimeCCTV);
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    string hexColorhex = ColorTranslator.ToHtml(Color.FromArgb(colorDialog.Color.ToArgb()));
                    btnDepCTrainTimeCCTV.BackColor = colorDialog.Color;
                    btnDepCTrainTimeCCTV.Text = hexColorhex;
                    btnDepCTrainADCCTV.BackColor = colorDialog.Color;
                    btnDepCTrainADCCTV.Text = hexColorhex;
                    btnDepCTrainPFCCTV.BackColor = colorDialog.Color;
                    btnDepCTrainPFCCTV.Text = hexColorhex;
                }
            }
        }

        private void btnDepCTrainADCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnDepCTrainADCCTV);
        }

        private void btnDepCTrainPFCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnDepCTrainPFCCTV);
        }

        private void btnDepIRTLTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepIRTLTrainNumberCCTV);
        }

        private void btnDepIRTLTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepIRTLTrainNameCCTV);
        }

        private void btnDepIRTLTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepIRTLTrainTimeCCTV);
        }

        private void btnDepIRTLTrainADCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepIRTLTrainADCCTV);
        }

        private void btnDepIRTLTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepIRTLTrainPFCCTV);
        }

        private void btnDepIOPTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepIOPTrainNumberCCTV);
        }

        private void btnDepIOPTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepIOPTrainNameCCTV);
        }

        private void btnDepIOPTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepIOPTrainTimeCCTV);
        }

        private void btnDepIOPTrainADCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepIOPTrainADCCTV);
        }

        private void btnDepIOPTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepIOPTrainPFCCTV);
        }

        private void btnDepDTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepDTrainNumberCCTV);
        }

        private void btnDepDTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepDTrainNameCCTV);
        }

        private void btnDepDTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepDTrainTimeCCTV);
        }

        private void btnDepDTrainADCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepDTrainADCCTV);
        }

        private void btnDepDTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepDTrainPFCCTV);
        }

        private void btnDepRTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepRTrainNumberCCTV);
        }

        private void btnDepRTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepRTrainNameCCTV);
        }

        private void btnDepRTraintimeCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnDepRTraintimeCCTV);

            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    string hexColorhex = ColorTranslator.ToHtml(Color.FromArgb(colorDialog.Color.ToArgb()));
                    btnDepRTraintimeCCTV.BackColor = colorDialog.Color;
                    btnDepRTraintimeCCTV.Text = hexColorhex;
                    btnDepRTrainADCCTV.BackColor = colorDialog.Color;
                    btnDepRTrainADCCTV.Text = hexColorhex;
                    btnDepRTrainPFCCTV.BackColor = colorDialog.Color;
                    btnDepRTrainPFCCTV.Text = hexColorhex;
                }
            }
        }

        private void btnDepRTrainADCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnDepRTrainADCCTV);
        }

        private void btnDepRTrainPFCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnDepRTrainPFCCTV);
        }

        private void btnDepDivTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepDivTrainNumberCCTV);
        }

        private void btnDepDivTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepDivTrainNameCCTV);
        }

        private void btnDepDivTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnDepDivTrainTimeCCTV);
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    string hexColorhex = ColorTranslator.ToHtml(Color.FromArgb(colorDialog.Color.ToArgb()));
                    btnDepDivTrainTimeCCTV.BackColor = colorDialog.Color;
                    btnDepDivTrainTimeCCTV.Text = hexColorhex;
                    btnDepDivTrainADCCTV.BackColor = colorDialog.Color;
                    btnDepDivTrainADCCTV.Text = hexColorhex;
                    btnDepDivTrainPFCCTV.BackColor = colorDialog.Color;
                    btnDepDivTrainPFCCTV.Text = hexColorhex;
                }
            }

        }

        private void btnDepDivTrainADCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnDepDivTrainADCCTV);
        }

        private void btnDepDivTrainPFCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnDepDivTrainPFCCTV);
        }

        private void btnDepDDTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepDDTrainNumberCCTV);
        }

        private void btnDepDDTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepDDTrainNameCCTV);
        }

        private void btnDepDDTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepDDTrainTimeCCTV);
        }

        private void btnDepDDTrainADCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepDDTrainADCCTV);
        }

        private void btnDepDDTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepDDTrainPFCCTV);
        }

        private void btnDepPCTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepPCTrainNumberCCTV);
        }

        private void btnDepPCTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepPCTrainNameCCTV);
        }

        private void btnDepPCTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepPCTrainTimeCCTV);
        }

        private void btnDepPCTrainADCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepPCTrainADCCTV);
        }

        private void btnDepPCTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepPCTrainPFCCTV);
        }
        private void btnArrTATrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTATrainNameCCTV);
        }

        private void btnArrTATrainTimeCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrTATrainTimeCCTV);
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    string hexColorhex = ColorTranslator.ToHtml(Color.FromArgb(colorDialog.Color.ToArgb()));
                    btnArrTATrainTimeCCTV.BackColor = colorDialog.Color;
                    btnArrTATrainTimeCCTV.Text = hexColorhex;
                    btnArrTATrainADCCTV.BackColor = colorDialog.Color;
                    btnArrTATrainADCCTV.Text = hexColorhex;
                    btnArrTATrainPFCCTV.BackColor = colorDialog.Color;
                    btnArrTATrainPFCCTV.Text = hexColorhex;
                }
            }
        }

        private void btnArrTATrainADCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrTATrainADCCTV);
        }

        private void btnArrTATrainPFCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnArrTATrainPFCCTV);
        }

        private void btnDepCoSTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepCoSTrainNumberCCTV);
        }

        private void btnDepCoSTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepCoSTrainNameCCTV);
        }

        private void btnDepCoSTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnDepCoSTrainTimeCCTV);

            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    string hexColorhex = ColorTranslator.ToHtml(Color.FromArgb(colorDialog.Color.ToArgb()));
                    btnDepCoSTrainTimeCCTV.BackColor = colorDialog.Color;
                    btnDepCoSTrainTimeCCTV.Text = hexColorhex;
                    btnDepCoSTrainADCCTV.BackColor = colorDialog.Color;
                    btnDepCoSTrainADCCTV.Text = hexColorhex;
                    btnDepCoSTrainPFCCTV.BackColor = colorDialog.Color;
                    btnDepCoSTrainPFCCTV.Text = hexColorhex;
                }
            }
        }

        private void btnDepCoSTrainADCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnDepCoSTrainADCCTV);
        }

        private void btnDepCoSTrainPFCCTV_Click(object sender, EventArgs e)
        {
            //CreateColorDialogBox(btnDepCoSTrainPFCCTV);
        }

        private void btnDepRegTrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepRegTrainNumberCCTV);
        }

        private void btnDepRegTrainNameCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepRegTrainNameCCTV);
        }

        private void btnDepRegTrainTimeCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepRegTrainTimeCCTV);
        }

        private void btnDepRegTrainADCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepRegTrainADCCTV);
        }

        private void btnDepRegTrainPFCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDepRegTrainPFCCTV);
        }


        private void btnArrTATrainNumberCCTV_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTATrainNumberCCTV);
        }

        private void txtHeaderBackClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtHeaderBackClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtHeaderBackClr.Text = hexValue;
            }
        }
        private void txtHeaderForeClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtHeaderForeClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtHeaderForeClr.Text = hexValue;
            }
        }
        private void txtTrainDisplayBackClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtTrainDisplayBackClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtTrainDisplayBackClr.Text = hexValue;
            }
        }

        private void txtTrainDisplayForeClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtTrainDisplayForeClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtTrainDisplayForeClr.Text = hexValue;
            }
        }

        private void txtTrainDetailsBackClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtTrainDetailsBackClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtTrainDetailsBackClr.Text = hexValue;
            }
        }

        private void txtTrainDetailsForeClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtTrainDetailsForeClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtTrainDetailsForeClr.Text = hexValue;
            }
        }

        private void txtGeneralMessageBackClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtGeneralMessageBackClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtGeneralMessageBackClr.Text = hexValue;
            }
        }

        private void txtGeneralMessageForeClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtGeneralMessageForeClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtGeneralMessageForeClr.Text = hexValue;
            }
        }

        private void txtCoachSettingsBackClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtCoachSettingsBackClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtCoachSettingsBackClr.Text = hexValue;
            }
        }

        private void txtCoachSettingsForeClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtCoachSettingsForeClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtCoachSettingsForeClr.Text = hexValue;
            }
        }

        private void txtFooterSettingsBackClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtFooterSettingsBackClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtFooterSettingsBackClr.Text = hexValue;
            }
        }

        private void txtFooterSettingsForeClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtFooterSettingsForeClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtFooterSettingsForeClr.Text = hexValue;
            }
        }

        private void cmbGeneralMessageFont_Click(object sender, EventArgs e)
        {
            PopulateFontComboBox(cmbGeneralMessageFont);
        }
        private void PopulateFontComboBox(ComboBox comboBox)
        {
            // Clear the ComboBox before populating it
            comboBox.Items.Clear();

            // Get all available font families installed on the system
            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                // Add the font name to the ComboBox
                comboBox.Items.Add(fontFamily.Name);
            }
        }

        private void pnlSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trSuccessMsg_Tick(object sender, EventArgs e)
        {

        }

        private void panel45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel35_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlArrTrainStatus_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTrainPf_Click(object sender, EventArgs e)
        {

        }

        private void lblTrainAd_Click(object sender, EventArgs e)
        {

        }

        private void lblTrainStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblTrainNum_Click(object sender, EventArgs e)
        {

        }

        private void lblTrainNam_Click(object sender, EventArgs e)
        {

        }

        private void lblTrainTime_Click(object sender, EventArgs e)
        {

        }

        private void lblAdStatus_Click(object sender, EventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlDepTrainStatus_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDepReascheduled_Click(object sender, EventArgs e)
        {

        }

        private void panel43_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDepRegulated_Click(object sender, EventArgs e)
        {

        }

        private void panel42_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDepChangeOfSource_Click(object sender, EventArgs e)
        {

        }

        private void panel32_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDepPlatformChanged_Click(object sender, EventArgs e)
        {

        }

        private void panel33_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDepDelayDepature_Click(object sender, EventArgs e)
        {

        }

        private void panel34_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDepDiverted_Click(object sender, EventArgs e)
        {

        }

        private void panel36_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDepDeparted_Click(object sender, EventArgs e)
        {

        }

        private void panel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDepIsOnPlatform_Click(object sender, EventArgs e)
        {

        }

        private void panel38_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDepIsReadyToLeave_Click(object sender, EventArgs e)
        {

        }

        private void panel39_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDepCancelled_Click(object sender, EventArgs e)
        {

        }

        private void panel40_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblArrTerminatedAt_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblArrPlatform_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblArrTermin_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblArrIndefinite_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblArrCancel_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblArrRunningLate_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblArrHasArrivedOn_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblArrIsArrivedOn_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblArrWillArriveShortly_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblArrRunningRightTime_Click(object sender, EventArgs e)
        {

        }

        private void pnlArrival_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblArrival_Click(object sender, EventArgs e)
        {

        }

        private void pnlCCTVSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbSameWindow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblSameWindow_Click(object sender, EventArgs e)
        {

        }

        private void cmbScrollingSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbDateFormat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtboxFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbVideoDisplay_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtboxDefaultMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbMessageDisplay_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbCoachInfoDisplay_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblFilePath_Click(object sender, EventArgs e)
        {

        }

        private void lblDateFormat_Click(object sender, EventArgs e)
        {

        }

        private void lblScrollingSpeed_Click(object sender, EventArgs e)
        {

        }

        private void lblVideoDisplay_Click(object sender, EventArgs e)
        {

        }

        private void lblDefaultMessage_Click(object sender, EventArgs e)
        {

        }

        private void lblMessageDisplay_Click(object sender, EventArgs e)
        {

        }

        private void lblCoachInfoDisplay_Click(object sender, EventArgs e)
        {

        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFooterSettingsForeClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFooterSettingsBackClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbFooterSettingsFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbFooterSettingsFont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblFooterSettingsFontSize_Click(object sender, EventArgs e)
        {

        }

        private void lblFooterSettingsFont_Click(object sender, EventArgs e)
        {

        }

        private void lblFooterSettingsForeClr_Click(object sender, EventArgs e)
        {

        }

        private void lblFooterSettingsBackClr_Click(object sender, EventArgs e)
        {

        }

        private void pnlFooterSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblFooterSettings_Click(object sender, EventArgs e)
        {

        }

        private void pnlCoach_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCoachSettingsForeClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCoachSettingsBackClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCoachSettingsFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCoachSettingsFont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCoachSettingsFontSize_Click(object sender, EventArgs e)
        {

        }

        private void lblCoachSettingsFont_Click(object sender, EventArgs e)
        {

        }

        private void lblCoachSettingsForeClr_Click(object sender, EventArgs e)
        {

        }

        private void lblCoachSettingsBackClr_Click(object sender, EventArgs e)
        {

        }

        private void pnlCoachSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCoachSettings_Click(object sender, EventArgs e)
        {

        }

        private void pnlGeneralMessage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtGeneralMessageBackClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGeneralMessageForeClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbGeneralMessageFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbGeneralMessageFont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblGeneralMessageFontSize_Click(object sender, EventArgs e)
        {

        }

        private void lblGeneralMessageFont_Click(object sender, EventArgs e)
        {

        }

        private void lblGeneralMessageForeClr_Click(object sender, EventArgs e)
        {

        }

        private void lblGeneralMessageBackClr_Click(object sender, EventArgs e)
        {

        }

        private void pnlGeneralMessageSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblGeneralMessageDisplaySettings_Click(object sender, EventArgs e)
        {

        }

        private void pnlTrainDetails_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTrainDetailsForeClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTrainDetailsBackClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTrainDetailsFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTrainDetailsFont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTrainDetailsFontSize_Click(object sender, EventArgs e)
        {

        }

        private void lblTrainDetailsFont_Click(object sender, EventArgs e)
        {

        }

        private void lblTrainDetailsForeClr_Click(object sender, EventArgs e)
        {

        }

        private void lblTrainDetailsBackClr_Click(object sender, EventArgs e)
        {

        }

        private void pnlTrainDetailsSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTrainDetailsDisplaySettings_Click(object sender, EventArgs e)
        {

        }

        private void pnlTrainDisplay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTrainDisplayForeClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTrainDisplayBackClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTrainDisplayFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTrainDisplayFont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTrainDisplayFontSize_Click(object sender, EventArgs e)
        {

        }

        private void lblTrainDisplayFont_Click(object sender, EventArgs e)
        {

        }

        private void lblTrainDisplayForeClr_Click(object sender, EventArgs e)
        {

        }

        private void lblTrainDisplayBackClr_Click(object sender, EventArgs e)
        {

        }

        private void pnlTrainDisplaySettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTrainDisplayHeaderSettings_Click(object sender, EventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtHeaderForeClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHeaderBackClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbHeaderFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHeaderFont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblHeaderFontSize_Click(object sender, EventArgs e)
        {

        }

        private void lblHeaderFont_Click(object sender, EventArgs e)
        {

        }

        private void lblHeaderForeClr_Click(object sender, EventArgs e)
        {

        }

        private void lblHeaderBackClr_Click(object sender, EventArgs e)
        {

        }

        private void pnlHeaderSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblHeaderSettings_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }


}
