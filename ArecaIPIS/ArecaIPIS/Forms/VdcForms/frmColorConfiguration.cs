using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmColorConfiguration : Form
    {

        public frmColorConfiguration()
        {
            InitializeComponent();

        }

        private frmIndex parentForm;

        public frmColorConfiguration(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }
        DataTable Colorsdt = new DataTable();

        private void lblTrainNumber_Click(object sender, EventArgs e)
        {

        }

        private void btnTrainNumber_Click(object sender, EventArgs e)
        {


            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            //pnltrainNumber.BackColor =  cd.Color;
            cd.FullOpen = true;
            cd.AnyColor = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                //pnltrainNumber.BackColor=cd.Color;
            }

        }

        private void grbTrainInfo_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public int GetPk(string ip)
        {
            // Ensure the DataTable and the "IPAddress" column exist
            if (BaseClass.EthernetPorts != null && BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
            {
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    // Get the IP address from the current row
                    string ipAddress = row["IPAddress"].ToString();

                    // Check if the IP address matches the input IP
                    if (ipAddress == ip)
                    {
                        // Retrieve and return the primary key (FkeyofMasterHub)
                        int pk = Convert.ToInt32(row["PkeyMasterhub"]);
                        return pk;
                    }
                }
            }

            // Return 0 if no matching IP address is found
            return 0;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                DialogResult dialogResult = MessageBox.Show("Settings saved successfully. Do you want to continue?", "Save Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // User clicked 'Yes', continue with the process

                    string Boardip = cmbBoardId.Text;

                    int PkMasterId = 0;

                    PkMasterId = GetPk(Boardip);

                    Colorsdt.Rows.Clear();

                    //Arrival
                    string arrival = "A";
                    List<string> ArrRunningRightTimevalues = GetTextBoxValues(btnArrRRTTrainNumber, btnArrRRTTrainName, btnArrRRTTrainTime, btnArrRRTTrainAD, btnArrRRTTrainPF, btnArrRRTCpos);
                    List<string> ArrWillArriveShortlyvalues = GetTextBoxValues(btnArrWATrainNumber, btnWATraiName, btnWATrainTime, btnWATrainAd, btnWATrainPf, btnWATrainCpos);
                    List<string> ArrIsArrivedOnvalues = GetTextBoxValues(btnArrIsArriveTraiNumber, btnArrIsArriveTrainName, btnArrIsArriveTrainTime, btnArrIsArriveTrainAd, btnArrIsArriveTrainPf, btnArrIsArriveCpos);
                    List<string> ArrHasArrivedOnvalues = GetTextBoxValues(btnArrHasArriveTrainNumber, btnArrHasArriveTrainName, btnArrHasArriveTrainTime, btnArrHasArriveTrainAd, btnArrHasArriveTrainPf, btnArrHasArriveCpos);
                    List<string> ArrRunningLatevalues = GetTextBoxValues(btnArrRLTrainNumber, btnArrRLTrainName, btnArrRLTrainTime, btnArrRLTrainAd, btnArrRLTrainPf, btnArrRLCpos);
                    List<string> ArrCancelledvalues = GetTextBoxValues(btnArrCancelTrainNumber, btnArrCancelTrainName, btnArrCancelTrainTime, btnArrCancelTrainAd, btnArrCancelTrainPf, btnArrCancelCpos);
                    List<string> ArrindefiniteLatevalues = GetTextBoxValues(btnArrIDFTrainNumber, btnArrIDFTrainName, btnArrIDFTrainTime, btnArrIDFTrainAd, btnArrIDFTrainPf, btnArrIDFCpos);
                    List<string> ArrTerminatedvalues = GetTextBoxValues(btnArrTerminTrainNumber, btnArrTerminTrainName, btnArrTerminTrainTime, btnArrTerminTrainAd, btnArrTerminTrainPf, btnArrTerminCpos);
                    List<string> ArrPlatformChangedvalues = GetTextBoxValues(btnArrPlatformChangeTrainNumber, btnArrPlatformChangeTrainName, btnArrPlatformChangeTrainTime, btnArrPlatformChangeTrainAd, btnArrPlatformChangeTrainPf, btnArrPlatformChangeCpos);

                    AddRowToDataTable(Colorsdt, ArrRunningRightTimevalues, arrival, BaseClass.ARunningRightTime);
                    AddRowToDataTable(Colorsdt, ArrWillArriveShortlyvalues, arrival, BaseClass.WillArriveShortly);
                    AddRowToDataTable(Colorsdt, ArrIsArrivedOnvalues, arrival, BaseClass.IsArrivingOn);

                    AddRowToDataTable(Colorsdt, ArrHasArrivedOnvalues, arrival, BaseClass.HasArrivedOn);
                    AddRowToDataTable(Colorsdt, ArrRunningLatevalues, arrival, BaseClass.RunningLate);
                    AddRowToDataTable(Colorsdt, ArrCancelledvalues, arrival, BaseClass.ACancelled);
                    AddRowToDataTable(Colorsdt, ArrindefiniteLatevalues, arrival, BaseClass.IndefiniteLate);
                    AddRowToDataTable(Colorsdt, ArrTerminatedvalues, arrival, BaseClass.TerminatedAt);
                    AddRowToDataTable(Colorsdt, ArrPlatformChangedvalues, arrival, BaseClass.APlatformChanged);


                    //Departure
                    string Departure = "D";

                    List<string> DRunningRightTimevalues = GetTextBoxValues(btnDRRTTNo, btnDRRTTName, btnDRRTTime, btnDRRTAD, btnDRRTPF, btnDRRTCpos);
                    List<string> DCancelledvalues = GetTextBoxValues(btnDCanTNo, btnDCanTName, btnDCanTime, btnDCanAD, btnDCanPF, btnDCanCpos);
                    List<string> DReadyToLeavevalues = GetTextBoxValues(btnDReadyLeaveTNo, btnDReadyLeaveTName, btnDReadyLeaveTime, btnDReadyLeaveAD, btnDReadyLeavePF, btnDReadyLeaveCpos);
                    List<string> DISOnPlatfomvalues = GetTextBoxValues(btnDIsonPFTNo, btnDIsonPFTName, btnDIsonPFTime, btnDIsonPFAD, btnDIsonPF, btnDIsonPFCpos);
                    List<string> DDepartedvalues = GetTextBoxValues(btnDDepTNo, btnDDepTName, btnDDepTime, btnDDepTAD, btnDDepPF, btnDDepCpos);
                    List<string> DReschudledvalues = GetTextBoxValues(btnDResTNo, btnDResTName, btnDResTime, btnDResAD, btnDResPF, btnDResCpos);
                    List<string> DDivertedvalues = GetTextBoxValues(btnDDivTNo, btnDDivTName, btnDDivTime, btnDDivTAD, btnDDivPF, btnDDivCpos);
                    List<string> DDelayDeparturevalues = GetTextBoxValues(btnDDelayDepTNo, btnDDelayDepTName, btnDDelayDepTime, btnDDelayDepAD, btnDDelayDepPF, btnDDelayDepCpos);
                    List<string> DPlatformChangedvalues = GetTextBoxValues(btnDPFChangTNo, btnDPFChangTName, btnDPFChangTime, btnDPFChangAD, btnDPFChangPF, btnDPFChangCpos);
                    List<string> DChangeOFSourcevalues = GetTextBoxValues(btnDCosChangTNo, btnDCosChangTName, btnDCosChangTime, btnDCosChangAD, btnDCosChangPF, btnDCosChangCpos);

                    AddRowToDataTable(Colorsdt, DRunningRightTimevalues, Departure, BaseClass.DRunningRightTime);
                    AddRowToDataTable(Colorsdt, DCancelledvalues, Departure, BaseClass.DCancelled);
                    AddRowToDataTable(Colorsdt, DReadyToLeavevalues, Departure, BaseClass.IsReadyToLeave);
                    AddRowToDataTable(Colorsdt, DISOnPlatfomvalues, Departure, BaseClass.IsOnPlatform);
                    AddRowToDataTable(Colorsdt, DDepartedvalues, Departure, BaseClass.Departed);
                    AddRowToDataTable(Colorsdt, DReschudledvalues, Departure, BaseClass.Rescheduled);
                    AddRowToDataTable(Colorsdt, DDivertedvalues, Departure, BaseClass.Diverted);
                    AddRowToDataTable(Colorsdt, DDelayDeparturevalues, Departure, BaseClass.DelayDeparture);
                    AddRowToDataTable(Colorsdt, DPlatformChangedvalues, Departure, BaseClass.DPlatformChanged);
                    AddRowToDataTable(Colorsdt, DChangeOFSourcevalues, Departure, BaseClass.ChangeOfSource);


                    MediaDb.InsertColorConfiguration(PkMasterId, Colorsdt);


                    string VerticalLineColor = ColorToHex(btnVerticalline.BackColor);
                    string BackgroundColor = ColorToHex(btnColorBackground.BackColor);
                    string MessageLineColor = ColorToHex(btnMessageLine.BackColor);
                    string HorizontalLineColor = ColorToHex(btnHorZontalLine.BackColor);

                    MediaDb.InsertBorderColorConfiguration(PkMasterId, HorizontalLineColor, MessageLineColor, BackgroundColor, VerticalLineColor);
                }
                else if (dialogResult == DialogResult.No)
                {
                    // User clicked 'No', handle accordingly
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public void AddRowToDataTable(DataTable dataTable, List<string> values, string arrivalOrDeparture, int fkeySchudleStatus)
        {
            try
            {


                DataRow row = dataTable.NewRow();

                row["ArrivalORDeparture"] = arrivalOrDeparture;
                row["fkey_SchudleStatus"] = fkeySchudleStatus;
                row["TrainNo"] = values[0];
                row["TrainName"] = values[1];
                row["TrainTime"] = values[2];
                row["TrainAD"] = values[3];
                row["TrainPf"] = values[4];
                row["TrainCoach"] = values[5];

                dataTable.Rows.Add(row);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        public List<string> GetTextBoxValues(Button trainNumber, Button trainName, Button trainTime, Button trainAOrD, Button trainPf, Button trainCoach)
        {
            // Create a list to hold the text values
            List<string> valuesList = new List<string>
        {
           ColorToHex(trainNumber.BackColor),
          ColorToHex(trainName.BackColor),
           ColorToHex(trainTime.BackColor),
          ColorToHex(trainAOrD.BackColor),
          ColorToHex(trainPf.BackColor),
          ColorToHex(trainCoach.BackColor)
        };

            // Return the list of text values
            return valuesList;
        }

        private string ColorToHex(Color color)
        {
            // Convert the color to hexadecimal format
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        public void SetBoards()
        {
            try
            {
                List<int> packetIdentifiers = new List<int> { 6, 7 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                // Clear existing rows in the DataGridView


                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in boards.Rows)
                {

                    string ipadress = row["IPAddress"].ToString();


                    cmbBoardId.Items.Add(ipadress);
                }

                List<int> packetIdentifiers1 = new List<int> { 4 };

                // Fetch data from the database
                DataTable boards2 = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers1);

                // Clear existing rows in the DataGridView


                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in boards2.Rows)
                {

                    string ipadress = row["IPAddress"].ToString();
                    if (BaseClass.GettruecolorAgdbstatus(ipadress))
                    {
                        cmbBoardId.Items.Add(ipadress);
                    }
                }


                if (cmbBoardId.Items.Count > 0)
                {
                    cmbBoardId.SelectedIndex = 0;
                }



            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Null reference error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }










        private static bool IsNamedColor(string input)
        {
            // Check if the input is a named color
            foreach (KnownColor color in Enum.GetValues(typeof(KnownColor)))
            {
                if (string.Equals(color.ToString(), input, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        public void SetTextBoxProperties(TextBox textBox, string hexColor)
        {
            if (textBox != null)
            {
                // Set the text of the TextBox to the hex color value
                textBox.Text = hexColor;

                // Convert the hex color code to a Color and set the back color of the TextBox
                try
                {
                    Color color = ColorTranslator.FromHtml(hexColor);
                    textBox.BackColor = color;
                }
                catch (Exception ex)
                {
                    // Handle the exception if the hex color code is invalid
                    MessageBox.Show($"Invalid color code: {hexColor}. Error: {ex.Message}");
                }
            }
        }
        private static bool IsHexValue(string input)
        {
            // Check if the input is a hexadecimal value
            return Regex.IsMatch(input, "^#(?:[0-9a-fA-F]{3}){1,2}$");
        }

        public static Color ConvertToColor(string input)
        {
            // Check if the input is a named color
            if (IsNamedColor(input))
            {
                return Color.FromName(input);
            }
            // Check if the input is a hexadecimal value
            else if (IsHexValue(input))
            {
                return ColorTranslator.FromHtml(input);
            }
            else
            {
                // Default to black if the input is not recognized
                return Color.Black;
            }
        }

        public void setColorsToAgdb()
        {



            //string trainNumberColor = ColorTranslator.ToHtml(pnltrainNumber.BackColor);
            //string trainNameColor = ColorTranslator.ToHtml(pnlTrainName.BackColor);
            //string ExptArrivalColor = ColorTranslator.ToHtml(pnlExpectArrival.BackColor);
            //string ADColor = ColorTranslator.ToHtml(pnlAD.BackColor);
            //string Pf = ColorTranslator.ToHtml(pnlPf.BackColor);

            //string RescheduleColor = ColorTranslator.ToHtml(pnlRescheduled.BackColor);
            //string CancelColor = ColorTranslator.ToHtml(pnlCancelled.BackColor);
            //string divertedColor = ColorTranslator.ToHtml(pnlDiverted.BackColor);
            //string Terminatedcolor = ColorTranslator.ToHtml(pnlTerminated.BackColor);
            //string arrivedcolor = ColorTranslator.ToHtml(pnlArrived.BackColor);
            //string IndefiniteLate = ColorTranslator.ToHtml(pnlIndefiniteLate.BackColor);

            //string ScreenColor = ColorTranslator.ToHtml(pnlScreenColor.BackColor);
            //string LinesColor = ColorTranslator.ToHtml(pnlLinesColor.BackColor);
            //string coachColor = ColorTranslator.ToHtml(pnlCoachColor.BackColor);




            //DataSet ScreenColorSet = TruecolorDAO.GetAgdbColors();


            //pnltrainNumber.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["trainNumberColor"].ToString());
            //pnlTrainName.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["trainNameColor"].ToString());
            //pnlExpectArrival.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["ExptArrivalColor"].ToString());
            //pnlAD.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["ADColor"].ToString());
            //pnlPf.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["PFColor"].ToString());

            //pnlRescheduled.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["RescheduleColor"].ToString());
            //pnlCancelled.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["CancelColor"].ToString());
            //pnlDiverted.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["divertedColor"].ToString());
            //pnlTerminated.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["Terminatedcolor"].ToString());
            //pnlArrived.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["arrivedcolor"].ToString());
            //pnlScreenColor.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["ScreenColor"].ToString());


            //pnlIndefiniteLate.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["IndefiniteLate"].ToString());
            //pnlLinesColor.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["LinesColor"].ToString());
            //pnlCoachColor.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["CoachColor"].ToString());

        }









        public void ColorButton(Button btn, string _Color)
        {


            // Convert hexadecimal color value to Color object
            string hexValue = _Color; // Example hexadecimal color value (red)
            Color color = ColorTranslator.FromHtml(hexValue);

            // Set the background color of the button
            btn.BackColor = color;
            btn.Text = _Color;
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

        private void btnArrRRTTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainNumber);
        }

        private void btnArrRRTTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainName);
        }

        private void btnArrRRTTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainTime);
        }

        private void btnlArrRRTTrainAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainAD);
        }

        private void btnArrRRTTrainAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainAD);
        }

        private void btnArrRRTTrainPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainPF);
        }



        private void btnArrWATrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrWATrainNumber);
        }

        private void btnWATraiName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnWATraiName);
        }

        private void btnWATrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnWATrainTime);
        }

        private void btnWATrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnWATrainAd);
        }

        private void btnWATrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnWATrainPf);
        }



        private void btnArrIsArriveTraiNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveTraiNumber);
        }

        private void btnArrIsArriveTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveTrainName);
        }

        private void btnArrIsArriveTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveTrainTime);
        }

        private void btnArrIsArriveTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveTrainAd);
        }


        private void btnArrIsArriveTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveTrainPf);
        }

        private void btnArrHasArriveTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHasArriveTrainNumber);
        }

        private void btnArrHasArriveTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHasArriveTrainName);
        }

        private void btnArrHasArriveTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHasArriveTrainTime);
        }

        private void btnArrHasArriveTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHasArriveTrainAd);
        }

        private void btnArrHasArriveTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHasArriveTrainPf);
        }


        private void btnArrRLTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainNumber);
        }

        private void btnArrRLTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainName);
        }

        private void btnArrRLTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainTime);
        }

        private void btnArrRLTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainAd);
        }

        private void btnArrRLTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainPf);
        }

        private void btnArrRLCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLCpos);
        }

        private void btnArrCancelTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCancelTrainNumber);
        }

        private void btnArrCancelTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCancelTrainName);
        }

        private void btnArrCancelTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCancelTrainTime);
        }

        private void btnArrCancelTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCancelTrainAd);
        }

        private void btnArrCancelTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCancelTrainPf);
        }

        private void btnArrCancelCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCancelCpos);
        }

        private void btnArrIDFTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIDFTrainNumber);
        }

        private void btnArrIDFTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIDFTrainName);
        }

        private void btnArrIDFTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIDFTrainTime);
        }

        private void btnArrIDFTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIDFTrainAd);
        }

        private void btnArrIDFTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIDFTrainPf);
        }

        private void btnArrIDFCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIDFCpos);
        }

        private void btnArrTerminTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTerminTrainNumber);
        }

        private void btnArrTerminTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTerminTrainName);
        }

        private void btnArrTerminTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTerminTrainTime);
        }

        private void btnArrTerminTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTerminTrainAd);
        }

        private void btnArrTerminTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTerminTrainPf);
        }

        private void btnArrTerminCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTerminCpos);
        }

        private void btnArrPlatformChangeTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPlatformChangeTrainNumber);
        }

        private void btnArrPlatformChangeTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPlatformChangeTrainName);
        }

        private void btnArrPlatformChangeTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPlatformChangeTrainTime);
        }

        private void btnArrPlatformChangeTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPlatformChangeTrainAd);
        }

        private void btnArrPlatformChangeTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPlatformChangeTrainPf);
        }

        private void btnArrPlatformChangeCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPlatformChangeCpos);
        }



        private void btnDRRTTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDRRTTNo);
        }

        private void btnDRRTTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDRRTTName);
        }

        private void btnDRRTTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDRRTTime);
        }

        private void btnDRRTAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDRRTAD);
        }

        private void btnDRRTPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDRRTPF);
        }

        private void btnDRRTCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDRRTCpos);
        }

        private void btnDCanTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCanTNo);
        }

        private void btnDCanTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCanTName);
        }

        private void btnDCanTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCanTime);
        }

        private void btnDCanAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCanAD);
        }

        private void btnDCanPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCanPF);
        }

        private void btnDCanCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCanCpos);
        }

        private void btnDReadyLeaveTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDReadyLeaveTNo);
        }

        private void btnDReadyLeaveTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDReadyLeaveTName);
        }

        private void btnDReadyLeaveTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDReadyLeaveTime);
        }

        private void btnDReadyLeaveAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDReadyLeaveAD);
        }

        private void btnDReadyLeavePF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDReadyLeavePF);
        }

        private void btnDReadyLeaveCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDReadyLeaveCpos);
        }

        private void btnDIsonPFTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDIsonPFTNo);
        }

        private void btnDIsonPFTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDIsonPFTName);
        }

        private void btnDIsonPFTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDIsonPFTime);
        }

        private void btnDIsonPFAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDIsonPFAD);
        }

        private void btnDIsonPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDIsonPF);
        }

        private void btnDIsonPFCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDIsonPFCpos);
        }

        private void btnDDepTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDepTNo);
        }

        private void btnDDepTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDepTName);
        }

        private void btnDDepTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDepTime);
        }

        private void btnDDepTAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDepTAD);
        }

        private void btnDDepPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDepPF);
        }

        private void btnDDepCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDepCpos);
        }

        private void btnDResTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDResTNo);
        }

        private void btnDResTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDResTName);
        }

        private void btnDResTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDResTime);
        }

        private void btnDResAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDResAD);
        }

        private void btnDResPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDResPF);
        }

        private void btnDResCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDResCpos);

        }

        private void btnDDivTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDivTNo);
        }

        private void btnDDivTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDivTName);
        }

        private void btnDDivTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDivTime);
        }

        private void btnDDivTAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDivTAD);
        }

        private void btnDDivPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDivPF);
        }

        private void btnDDivCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDivCpos);
        }

        private void btnDDelayDepTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDelayDepTNo);
        }

        private void btnDDelayDepTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDelayDepTName);
        }

        private void btnDDelayDepTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDelayDepTime);
        }

        private void btnDDelayDepAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDelayDepAD);
        }

        private void btnDDelayDepPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDelayDepPF);
        }

        private void btnDDelayDepCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDelayDepCpos);
        }

        private void btnDPFChangTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDPFChangTNo);
        }

        private void btnDPFChangTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDPFChangTName);
        }

        private void btnDPFChangTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDPFChangTime);
        }

        private void btnDPFChangAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDPFChangAD);
        }

        private void btnDPFChangPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDPFChangPF);
        }

        private void btnDPFChangCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDPFChangCpos);
        }

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {


        //    string Tno = "";
        //    string TName = "";
        //    string TExTime = "";
        //    string TAD = "";
        //    string TPF = "";
        //    string TCpos = "";
        //    int statusCode=0;
        //    //Status=1 AD=A
        //    statusCode = 1;
        //    Tno = btnArrRRTTrainNumber.Text;
        //    TName = btnArrRRTTrainName.Text;
        //    TExTime = btnArrRRTTrainTime.Text;
        //    TAD = btnArrRRTTrainAD.Text;
        //    TPF = btnArrRRTTrainPF.Text;
        //    TCpos = btnArrRRTCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
        //    //Status=2 AD=A
        //    statusCode = 2;
        //    Tno = btnArrWATrainNumber.Text;
        //    TName = btnWATraiName.Text;
        //    TExTime = btnWATrainTime .Text;
        //    TAD = btnWATrainAd.Text;
        //    TPF = btnWATrainPf.Text;
        //    TCpos = btnWATrainCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
        //    //Status=3 AD=A
        //    statusCode = 3;
        //    Tno = btnArrIsArriveTraiNumber.Text;
        //    TName = btnArrIsArriveTrainName.Text;
        //    TExTime = btnArrIsArriveTrainTime.Text;
        //    TAD = btnArrIsArriveTrainAd.Text;
        //    TPF = btnArrIsArriveTrainPf.Text;
        //    TCpos = btnArrIsArriveCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
        //    //Status=4 AD=A
        //    statusCode = 4;
        //    Tno = btnArrHasArriveTrainNumber.Text;
        //    TName = btnArrHasArriveTrainName.Text;
        //    TExTime = btnArrHasArriveTrainTime.Text;
        //    TAD = btnArrHasArriveTrainAd.Text;
        //    TPF = btnArrHasArriveTrainPf.Text;
        //    TCpos = btnArrHasArriveCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
        //    //Status=5 AD=A
        //    statusCode = 5;
        //    Tno = btnArrRLTrainNumber.Text;
        //    TName = btnArrRLTrainName.Text;
        //    TExTime = btnArrRLTrainTime.Text;
        //    TAD = btnArrRLTrainAd.Text;
        //    TPF = btnArrRLTrainPf.Text;
        //    TCpos = btnArrRLCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
        //    //Status=6 AD=A
        //    statusCode = 6;
        //    Tno = btnArrCancelTrainNumber.Text;
        //    TName = btnArrCancelTrainName.Text;
        //    TExTime = btnArrCancelTrainTime.Text;
        //    TAD = btnArrCancelTrainAd.Text;
        //    TPF = btnArrCancelTrainPf.Text;
        //    TCpos = btnArrCancelCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
        //    //Status=7 AD=A
        //    statusCode = 7;
        //    Tno = btnArrIDFTrainNumber.Text;
        //    TName = btnArrIDFTrainName.Text;
        //    TExTime = btnArrIDFTrainTime.Text;
        //    TAD = btnArrIDFTrainAd.Text;
        //    TPF = btnArrIDFTrainPf.Text;
        //    TCpos = btnArrIDFCpos.Text;
        //     SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
        //    //Status=8 AD=A
        //     statusCode = 8;
        //    Tno = btnArrTerminTrainNumber.Text;
        //    TName = btnArrTerminTrainName.Text;
        //    TExTime = btnArrTerminTrainTime.Text;
        //    TAD = btnArrTerminTrainAd.Text;
        //    TPF = btnArrTerminTrainPf.Text;
        //    TCpos = btnArrTerminCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
        //    //Status=9 AD=A
        //    statusCode = 9;
        //    Tno = btnArrPlatformChangeTrainNumber.Text;
        //    TName = btnArrPlatformChangeTrainName.Text;
        //    TExTime = btnArrPlatformChangeTrainTime.Text;
        //    TAD = btnArrPlatformChangeTrainAd.Text;
        //    TPF = btnArrPlatformChangeTrainPf.Text;
        //    TCpos = btnArrPlatformChangeCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


        //    //D

        //    //Status=10 AD=D
        //    statusCode = 10;
        //    Tno = btnDRRTTNo.Text;
        //    TName = btnDRRTTName.Text;
        //    TExTime = btnDRRTTime.Text;
        //    TAD = btnDRRTAD.Text;
        //    TPF = btnDRRTPF.Text;
        //    TCpos = btnDRRTCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


        //    //Status=11 AD=D
        //    statusCode = 11;
        //    Tno = btnDCanTNo.Text;
        //    TName = btnDCanTName.Text;
        //    TExTime = btnDCanTime.Text;
        //    TAD = btnDCanAD.Text;
        //    TPF = btnDCanPF.Text;
        //    TCpos = btnDCanCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);

        //    //Status=12 AD=D
        //    statusCode = 12;
        //    Tno = btnDReadyLeaveTNo.Text;
        //    TName = btnDReadyLeaveTName.Text;
        //    TExTime = btnDReadyLeaveTime.Text;
        //    TAD = btnDReadyLeaveAD.Text;
        //    TPF = btnDReadyLeavePF.Text;
        //    TCpos = btnDReadyLeaveCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


        //    //Status=13 AD=D
        //    statusCode = 13;
        //    Tno = btnDIsonPFTNo.Text;
        //    TName = btnDIsonPFTName.Text;
        //    TExTime = btnDIsonPFTime.Text;
        //    TAD = btnDIsonPFAD.Text;
        //    TPF = btnDIsonPF.Text;
        //    TCpos = btnDIsonPFCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


        //    //Status=14 AD=D
        //    statusCode = 14;
        //    Tno = btnDDepTNo.Text;
        //    TName = btnDDepTName.Text;
        //    TExTime = btnDDepTime.Text;
        //    TAD = btnDDepTAD.Text;
        //    TPF = btnDDepPF.Text;
        //    TCpos = btnDDepCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


        //    //Status=15 AD=D
        //    statusCode = 15;
        //    Tno = btnDResTNo.Text;
        //    TName = btnDResTName.Text;
        //    TExTime = btnDResTime.Text;
        //    TAD = btnDResAD.Text;
        //    TPF = btnDResPF.Text;
        //    TCpos = btnDResCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


        //    //Status=16 AD=D
        //    statusCode = 16;
        //    Tno = btnDDivTNo.Text;
        //    TName = btnDDivTName.Text;
        //    TExTime = btnDDivTime.Text;
        //    TAD = btnDDivTAD.Text;
        //    TPF = btnDDivPF.Text;
        //    TCpos = btnDDivCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


        //    //Status=17 AD=D
        //    statusCode = 17;
        //    Tno = btnDDelayDepTNo.Text;
        //    TName = btnDDelayDepTName.Text;
        //    TExTime = btnDDelayDepTime.Text;
        //    TAD = btnDDelayDepAD.Text;
        //    TPF = btnDDelayDepPF.Text;
        //    TCpos = btnDDelayDepCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);

        //    //Status=18 AD=D
        //    statusCode = 18;
        //    Tno = btnDPFChangTNo.Text;
        //    TName = btnDPFChangTName.Text;
        //    TExTime = btnDPFChangTime.Text;
        //    TAD = btnDPFChangAD.Text;
        //    TPF = btnDPFChangPF.Text;
        //    TCpos = btnDPFChangCpos.Text;
        //    SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);

        //    string boardercolor = btnMessageLine.Text;
        //    string backcolor = btnColorBackground.Text;
        //    SaveBoarderLInes(boardercolor, backcolor);
        //    MessageBox.Show("Updated Successfully");
        //    }
        //    catch (Exception ex)
        //    {

        //        ex.ToString();
        //    }

        //  }



        //public void SaveConfigSettingsColor(int StatusCode, string TNColor, string TNaColor, string TTmeColor, string TADColor, string TPFColor,string Cpos)
        //{
        //    //DataSet ds = new DataSet();
        //    //OleDbConnection con = new OleDbConnection(cls.connstr);

        //    //string sql = "update ColorSettings set TrainNo = '" + TNColor + "',TrainName = '" + TNaColor + "',TrainTime = '" + TTmeColor + "',TrainAD = '" + TADColor + "',TrainPF ='" + TPFColor + "',Cpos='" + Cpos + "' where Status= " + StatusCode + "";
        //    //OleDbCommand cmd = new OleDbCommand(sql, con);
        //    //con.Open();
        //    //cmd.ExecuteNonQuery();
        //    //con.Close();
        //}

        //public void SaveBoarderLInes( string BoarderColor, string Backgroundolcor)
        //{
        //    //DataSet ds = new DataSet();
        //    //OleDbConnection con = new OleDbConnection(cls.connstr);

        //    //string sql = "update AGDBBoardColors set BorderColor = '" + BoarderColor + "',BackGroundColor = '" + Backgroundolcor + "'";
        //    //OleDbCommand cmd = new OleDbCommand(sql, con);
        //    //con.Open();
        //    //cmd.ExecuteNonQuery();
        //    //con.Close();
        //}



        //private void FillColorsettings()
        //{
        //    DataTable dt = GetAgdbColorSetting();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {

        //        try
        //        {


        //        string Tno = "";
        //        string TName = "";
        //        string ExpTime = "";
        //        string AD = "";
        //        string PF = "";
        //        string Cpos = "";
        //        switch (i)
        //        {
        //            case 0:

        //                Tno = dt.Rows[i]["TrainNo"].ToString();
        //                TName = dt.Rows[i]["TrainName"].ToString();
        //                ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                AD = dt.Rows[i]["TrainAD"].ToString();
        //                PF = dt.Rows[i]["TrainPF"].ToString();
        //                Cpos = dt.Rows[i]["Cpos"].ToString();

        //                ColorButton(btnArrRRTTrainNumber, Tno);
        //                ColorButton(btnArrRRTTrainName, TName);
        //                ColorButton(btnArrRRTTrainTime, ExpTime);
        //                ColorButton(btnArrRRTTrainAD, AD);
        //                ColorButton(btnArrRRTTrainPF, PF);
        //                ColorButton(btnArrRRTCpos, Cpos);

        //                  break;
        //            case 1:
        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        //                  ColorButton(btnArrWATrainNumber,Tno);
        //                  ColorButton(btnWATraiName,TName);
        //                  ColorButton(btnWATrainTime,ExpTime);
        //                  ColorButton(btnWATrainAd,AD);
        //                  ColorButton(btnWATrainPf,PF);
        //                  ColorButton(btnWATrainCpos,Cpos);
        //                  break;

        //            case 2:
        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        //                  ColorButton(btnArrIsArriveTraiNumber,Tno);
        //                  ColorButton(btnArrIsArriveTrainName,TName);
        //                  ColorButton(btnArrIsArriveTrainTime,ExpTime);
        //                  ColorButton(btnArrIsArriveTrainAd,AD);
        //                  ColorButton(btnArrIsArriveTrainPf,PF);
        //                  ColorButton(btnArrIsArriveCpos,Cpos);
        //                  break;

        //            case 3:
        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        //                  ColorButton(btnArrHasArriveTrainNumber, Tno);
        //                  ColorButton(btnArrHasArriveTrainName, TName);
        //                  ColorButton(btnArrHasArriveTrainTime, ExpTime);
        //                  ColorButton(btnArrHasArriveTrainAd, AD);
        //                  ColorButton(btnArrHasArriveTrainPf, PF);
        //                  ColorButton(btnArrHasArriveCpos, Cpos);
        //                  break;
        //            case 4:
        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        //                   ColorButton(btnArrRLTrainNumber, Tno);
        //                  ColorButton(btnArrRLTrainName, TName);
        //                  ColorButton(btnArrRLTrainTime, ExpTime);
        //                  ColorButton(btnArrRLTrainAd, AD);
        //                  ColorButton(btnArrRLTrainPf, PF);
        //                  ColorButton(btnArrRLCpos, Cpos);
        //                  break;
        //            case 5:
        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();


        //                  ColorButton(btnArrCancelTrainNumber, Tno);
        //                  ColorButton(btnArrCancelTrainName, TName);
        //                  ColorButton(btnArrCancelTrainTime, ExpTime);
        //                  ColorButton(btnArrCancelTrainAd, AD);
        //                  ColorButton(btnArrCancelTrainPf, PF);
        //                  ColorButton(btnArrCancelCpos, Cpos);
        //                  break;
        //            case 6:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        //                  ColorButton(btnArrIDFTrainNumber, Tno);
        //                  ColorButton(btnArrIDFTrainName, TName);
        //                  ColorButton(btnArrIDFTrainTime, ExpTime);
        //                  ColorButton(btnArrIDFTrainAd, AD);
        //                  ColorButton(btnArrIDFTrainPf, PF);
        //                  ColorButton(btnArrIDFCpos, Cpos);
        //                  break;
        //            case 7:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();



        //                  ColorButton(btnArrTerminTrainNumber, Tno);
        //                  ColorButton(btnArrTerminTrainName, TName);
        //                  ColorButton(btnArrTerminTrainTime, ExpTime);
        //                  ColorButton(btnArrTerminTrainAd, AD);
        //                  ColorButton(btnArrTerminTrainPf, PF);
        //                  ColorButton(btnArrTerminCpos, Cpos);
        //                  break;
        //            case 8:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();



        //                  ColorButton(btnArrPlatformChangeTrainNumber, Tno);
        //                  ColorButton(btnArrPlatformChangeTrainName, TName);
        //                  ColorButton(btnArrPlatformChangeTrainTime, ExpTime);
        //                  ColorButton(btnArrPlatformChangeTrainAd, AD);
        //                  ColorButton(btnArrPlatformChangeTrainPf, PF);
        //                  ColorButton(btnArrPlatformChangeCpos, Cpos);
        //                  break;
        //            case 9:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();


        //                  ColorButton(btnDRRTTNo, Tno);
        //                  ColorButton(btnDRRTTName, TName);
        //                  ColorButton(btnDRRTTime, ExpTime);
        //                  ColorButton(btnDRRTAD, AD);
        //                  ColorButton(btnDRRTPF, PF);
        //                  ColorButton(btnDRRTCpos, Cpos);
        //                  break;
        //            case 10:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        //                  ColorButton(btnDCanTNo, Tno);
        //                  ColorButton(btnDCanTName, TName);
        //                  ColorButton(btnDCanTime, ExpTime);
        //                  ColorButton(btnDCanAD, AD);
        //                  ColorButton(btnDCanPF, PF);
        //                  ColorButton(btnDCanCpos, Cpos);
        //                  break;
        //            case 11:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();


        //                  ColorButton(btnDReadyLeaveTNo, Tno);
        //                  ColorButton(btnDReadyLeaveTName, TName);
        //                  ColorButton(btnDReadyLeaveTime, ExpTime);
        //                  ColorButton(btnDReadyLeaveAD, AD);
        //                  ColorButton(btnDReadyLeavePF, PF);
        //                  ColorButton(btnDReadyLeaveCpos, Cpos);
        //                  break;
        //            case 12:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();


        //                  ColorButton(btnDIsonPFTNo, Tno);
        //                  ColorButton(btnDIsonPFTName, TName);
        //                  ColorButton(btnDIsonPFTime, ExpTime);
        //                  ColorButton(btnDIsonPFAD, AD);
        //                  ColorButton(btnDIsonPF, PF);
        //                  ColorButton(btnDIsonPFCpos, Cpos);
        //                  break;
        //            case 13:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();


        //                  ColorButton(btnDDepTNo, Tno);
        //                  ColorButton(btnDDepTName, TName);
        //                  ColorButton(btnDDepTime, ExpTime);
        //                  ColorButton(btnDDepTAD, AD);
        //                  ColorButton(btnDDepPF, PF);
        //                  ColorButton(btnDDepCpos, Cpos);
        //                  break;
        //            case 14:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();


        //                  ColorButton(btnDResTNo, Tno);
        //                  ColorButton(btnDResTName, TName);
        //                  ColorButton(btnDResTime, ExpTime);
        //                  ColorButton(btnDResAD, AD);
        //                  ColorButton(btnDResPF, PF);
        //                  ColorButton(btnDResCpos, Cpos);
        //                  break;
        //            case 15:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();


        //                  ColorButton(btnDDivTNo, Tno);
        //                  ColorButton(btnDDivTName, TName);
        //                  ColorButton(btnDDivTime, ExpTime);
        //                  ColorButton(btnDDivTAD, AD);
        //                  ColorButton(btnDDivPF, PF);
        //                  ColorButton(btnDDivCpos, Cpos);
        //                  break;
        //            case 16:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();


        //                  ColorButton(btnDDelayDepTNo, Tno);
        //                  ColorButton(btnDDelayDepTName, TName);
        //                  ColorButton(btnDDelayDepTime, ExpTime);
        //                  ColorButton(btnDDelayDepAD, AD);
        //                  ColorButton(btnDDelayDepPF, PF);
        //                  ColorButton(btnDDelayDepCpos, Cpos);
        //                  break;
        //            case 17:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();


        //                  ColorButton(btnDPFChangTNo, Tno);
        //                  ColorButton(btnDPFChangTName, TName);
        //                  ColorButton(btnDPFChangTime, ExpTime);
        //                  ColorButton(btnDPFChangAD, AD);
        //                  ColorButton(btnDPFChangPF, PF);
        //                  ColorButton(btnDPFChangCpos, Cpos);
        //                  break;




        //        }

        //        }
        //        catch (Exception ex)
        //        {

        //            ex.ToString();
        //        } 
        //    }

        //        DataTable dtboarder = GetBorderDetails();
        //        if (dtboarder.Rows.Count>0)
        //        {
        //            string bordercolor=dtboarder.Rows[0]["BorderColor"].ToString();
        //           string backcolor= dtboarder.Rows[0]["BackGroundColor"].ToString();
        //           ColorButton(btnColorBackground, backcolor);
        //           ColorButton(btnBorderlInes, bordercolor);

        //        }



        //}
        //public DataTable GetAgdbColorSetting()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {


        //    DataSet ds = new DataSet();
        //    OleDbConnection con = new OleDbConnection(cls.connstr);
        //    string Sql = "select * from ColorSettings";
        //    OleDbDataAdapter da = new OleDbDataAdapter(Sql, con);
        //    da.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {

        //        ex.ToString();
        //    }
        //    return dt;

        //}

        //public DataTable GetBorderDetails()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {


        //        DataSet ds = new DataSet();
        //        OleDbConnection con = new OleDbConnection(cls.connstr);
        //        string Sql = "select * from AGDBBoardColors";
        //        OleDbDataAdapter da = new OleDbDataAdapter(Sql, con);
        //        da.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {

        //        ex.ToString();
        //    }
        //    return dt;

        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnColorBackground_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnColorBackground);
        }

        private void btnBorderlInes_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnMessageLine);
        }

        

        

        private void btnArrRRTTrainNumber_Click_1(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainNumber);
        }

      

        private void btnArrRRTTrainName_Click_1(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainNumber);
        }

        private void btnDCosChangTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCosChangTNo);
        }

        private void btnDCosChangTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCosChangTName);
        }

        private void btnDCosChangTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCosChangTime);
        }

        private void btnDCosChangAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCosChangAD);
        }

        private void btnDCosChangPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCosChangPF);
        }

        private void btnDCosChangCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCosChangCpos);
        }

        private void btnHorZontalLine_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnHorZontalLine);
        }

        private void btnVertical_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnVerticalline);
        }

        private void btnArrRRTCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTCpos);
        }

        private void btnWATrainCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnWATrainCpos);
        }

        private void btnArrIsArriveCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveCpos);
        }

        private void btnArrHasArriveCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHasArriveCpos);
        }

        private void frmColorConfiguration_Load(object sender, EventArgs e)
        {
            SetBoards();
            AddColumns();
            GetDetails();
        }
        public void GetDetails()
        {
            string boardaddress = cmbBoardId.Text;
            int MusterHubkey = GetPk(boardaddress);

            SetColors(MusterHubkey);
            SetBordersColors(MusterHubkey);
        }
        public void SetBordersColors(int MusterHubkey)
        {
            DataTable dt = MediaDb.GetBorderColorConfiguration(MusterHubkey);


            foreach (DataRow row in dt.Rows)
            {
                // Check if the row contains the "fKey_CDC_MasterHub" column and parse its value
                if (dt.Columns.Contains("Fkey_Masterhub") && int.TryParse(row["Fkey_Masterhub"].ToString(), out int PkMasterHub))
                {
                    // If the parsed value matches the provided MusterHubkey
                    if (PkMasterHub == MusterHubkey)
                    {
                        SetButttonProperties(btnVerticalline, row["VerticalLineColor"].ToString());
                        SetButttonProperties(btnColorBackground, row["BackgroundColor"].ToString());
                        SetButttonProperties(btnMessageLine, row["MessageLineColor"].ToString());
                        SetButttonProperties(btnHorZontalLine, row["HorizontalLineColor"].ToString());
                    }
                }
            }


        }

        public void SetButttonProperties(Button button, string hexColor)
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
                    MessageBox.Show($"Invalid color code: {hexColor}. Error: {ex.Message}");
                }
            }
        }
        public void SetColors(int MusterHubkey)
        {
            try
            {


                // Retrieve the color configuration from the database
                DataTable dt = MediaDb.GetColorConfiguration(MusterHubkey);

                if (dt.Rows.Count > 0)
                {

                    // Loop through each row in the data table
                    foreach (DataRow row in dt.Rows)
                    {
                        // Check if the row contains the "fKey_CDC_MasterHub" column and parse its value
                        if (dt.Columns.Contains("fKey_CDC_MasterHub") && int.TryParse(row["fKey_CDC_MasterHub"].ToString(), out int PkMasterHub))
                        {
                            // If the parsed value matches the provided MusterHubkey
                            if (PkMasterHub == MusterHubkey)
                            {
                                // Extract other necessary values for setting colors
                                //string statusName = row["StatusName"].ToString();
                                int statusCode = Convert.ToInt32(row["fkey_SchudleStatus"].ToString()); // Assuming there is a column "ColorCode"
                                                                                                        //string ArrivalDepature = row["ColorCode"].ToString();

                                switch (statusCode)
                                {
                                    case 1: //Arrival Running right Time 
                                        SetButttonProperties(btnArrRRTTrainNumber, row["TrainNo"].ToString());
                                        SetButttonProperties(btnArrRRTTrainName, row["TrainName"].ToString());
                                        SetButttonProperties(btnArrRRTTrainTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnArrRRTTrainAD, row["TrainAD"].ToString());
                                        SetButttonProperties(btnArrRRTTrainPF, row["TrainPf"].ToString());
                                        SetButttonProperties(btnArrRRTCpos, row["TrainCoach"].ToString());

                                        break;
                                    case 2: //will arrrive shortly
                                        SetButttonProperties(btnArrWATrainNumber, row["TrainNo"].ToString());
                                        SetButttonProperties(btnWATraiName, row["TrainName"].ToString());
                                        SetButttonProperties(btnWATrainTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnWATrainAd, row["TrainAD"].ToString());
                                        SetButttonProperties(btnWATrainPf, row["TrainPf"].ToString());
                                        SetButttonProperties(btnWATrainCpos, row["TrainCoach"].ToString());

                                        break;

                                    case 3: //is Arriving on
                                        SetButttonProperties(btnArrIsArriveTraiNumber, row["TrainNo"].ToString());
                                        SetButttonProperties(btnArrIsArriveTrainName, row["TrainName"].ToString());
                                        SetButttonProperties(btnArrIsArriveTrainTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnArrIsArriveTrainAd, row["TrainAD"].ToString());
                                        SetButttonProperties(btnArrIsArriveTrainPf, row["TrainPf"].ToString());
                                        SetButttonProperties(btnArrIsArriveCpos, row["TrainCoach"].ToString());

                                        break;

                                    case 4: //Has Arrived On
                                        SetButttonProperties(btnArrHasArriveTrainNumber, row["TrainNo"].ToString());
                                        SetButttonProperties(btnArrHasArriveTrainName, row["TrainName"].ToString());
                                        SetButttonProperties(btnArrHasArriveTrainTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnArrHasArriveTrainAd, row["TrainAD"].ToString());
                                        SetButttonProperties(btnArrHasArriveTrainPf, row["TrainPf"].ToString());
                                        SetButttonProperties(btnArrHasArriveCpos, row["TrainCoach"].ToString());

                                        break;
                                    case 5://RunningLate
                                        SetButttonProperties(btnArrRLTrainNumber, row["TrainNo"].ToString());
                                        SetButttonProperties(btnArrRLTrainName, row["TrainName"].ToString());
                                        SetButttonProperties(btnArrRLTrainTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnArrRLTrainAd, row["TrainAD"].ToString());
                                        SetButttonProperties(btnArrRLTrainPf, row["TrainPf"].ToString());
                                        SetButttonProperties(btnArrRLCpos, row["TrainCoach"].ToString());

                                        break;
                                    case 6: //arrival Cancelled
                                        SetButttonProperties(btnArrCancelTrainNumber, row["TrainNo"].ToString());
                                        SetButttonProperties(btnArrCancelTrainName, row["TrainName"].ToString());
                                        SetButttonProperties(btnArrCancelTrainTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnArrCancelTrainAd, row["TrainAD"].ToString());
                                        SetButttonProperties(btnArrCancelTrainPf, row["TrainPf"].ToString());
                                        SetButttonProperties(btnArrCancelCpos, row["TrainCoach"].ToString());

                                        break;
                                    case 7://indefinite Late
                                        SetButttonProperties(btnArrIDFTrainNumber, row["TrainNo"].ToString());
                                        SetButttonProperties(btnArrIDFTrainName, row["TrainName"].ToString());
                                        SetButttonProperties(btnArrIDFTrainTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnArrIDFTrainAd, row["TrainAD"].ToString());
                                        SetButttonProperties(btnArrIDFTrainPf, row["TrainPf"].ToString());
                                        SetButttonProperties(btnArrIDFCpos, row["TrainCoach"].ToString());

                                        break;
                                    case 8: //terminated at
                                        SetButttonProperties(btnArrTerminTrainNumber, row["TrainNo"].ToString());
                                        SetButttonProperties(btnArrTerminTrainName, row["TrainName"].ToString());
                                        SetButttonProperties(btnArrTerminTrainTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnArrTerminTrainAd, row["TrainAD"].ToString());
                                        SetButttonProperties(btnArrTerminTrainPf, row["TrainPf"].ToString());
                                        SetButttonProperties(btnArrTerminCpos, row["TrainCoach"].ToString());

                                        break;
                                    case 9: //arrival Platform Changed
                                        SetButttonProperties(btnArrPlatformChangeTrainNumber, row["TrainNo"].ToString());
                                        SetButttonProperties(btnArrPlatformChangeTrainName, row["TrainName"].ToString());
                                        SetButttonProperties(btnArrPlatformChangeTrainTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnArrPlatformChangeTrainAd, row["TrainAD"].ToString());
                                        SetButttonProperties(btnArrPlatformChangeTrainPf, row["TrainPf"].ToString());
                                        SetButttonProperties(btnArrPlatformChangeCpos, row["TrainCoach"].ToString());

                                        break;
                                    case 10://departure Running Right time
                                        SetButttonProperties(btnDRRTTNo, row["TrainNo"].ToString());
                                        SetButttonProperties(btnDRRTTName, row["TrainName"].ToString());
                                        SetButttonProperties(btnDRRTTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnDRRTAD, row["TrainAD"].ToString());
                                        SetButttonProperties(btnDRRTPF, row["TrainPf"].ToString());
                                        SetButttonProperties(btnDRRTCpos, row["TrainCoach"].ToString());

                                        break;
                                    case 11: //departue Cancelled
                                        SetButttonProperties(btnDCanTNo, row["TrainNo"].ToString());
                                        SetButttonProperties(btnDCanTName, row["TrainName"].ToString());
                                        SetButttonProperties(btnDCanTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnDCanAD, row["TrainAD"].ToString());
                                        SetButttonProperties(btnDCanPF, row["TrainPf"].ToString());
                                        SetButttonProperties(btnDCanCpos, row["TrainCoach"].ToString());

                                        break;

                                    case 12: //Is Ready to Leave
                                        SetButttonProperties(btnDReadyLeaveTNo, row["TrainNo"].ToString());
                                        SetButttonProperties(btnDReadyLeaveTName, row["TrainName"].ToString());
                                        SetButttonProperties(btnDReadyLeaveTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnDReadyLeaveAD, row["TrainAD"].ToString());
                                        SetButttonProperties(btnDReadyLeavePF, row["TrainPf"].ToString());
                                        SetButttonProperties(btnDReadyLeaveCpos, row["TrainCoach"].ToString());

                                        break;
                                    case 13:  //Is On Platform
                                        SetButttonProperties(btnDIsonPFTNo, row["TrainNo"].ToString());
                                        SetButttonProperties(btnDIsonPFTName, row["TrainName"].ToString());
                                        SetButttonProperties(btnDIsonPFTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnDIsonPFAD, row["TrainAD"].ToString());
                                        SetButttonProperties(btnDIsonPF, row["TrainPf"].ToString());
                                        SetButttonProperties(btnDIsonPFCpos, row["TrainCoach"].ToString());

                                        break;
                                    case 14:  // Departed
                                        SetButttonProperties(btnDDepTNo, row["TrainNo"].ToString());
                                        SetButttonProperties(btnDDepTName, row["TrainName"].ToString());
                                        SetButttonProperties(btnDDepTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnDDepTAD, row["TrainAD"].ToString());
                                        SetButttonProperties(btnDDepPF, row["TrainPf"].ToString());
                                        SetButttonProperties(btnDDepCpos, row["TrainCoach"].ToString());

                                        break;

                                    case 15: //Rescheduled
                                        SetButttonProperties(btnDResTNo, row["TrainNo"].ToString());
                                        SetButttonProperties(btnDResTName, row["TrainName"].ToString());
                                        SetButttonProperties(btnDResTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnDResAD, row["TrainAD"].ToString());
                                        SetButttonProperties(btnDResPF, row["TrainPf"].ToString());
                                        SetButttonProperties(btnDResCpos, row["TrainCoach"].ToString());

                                        break;



                                    case 16:  //Diverted
                                        SetButttonProperties(btnDDivTNo, row["TrainNo"].ToString());
                                        SetButttonProperties(btnDDivTName, row["TrainName"].ToString());
                                        SetButttonProperties(btnDDivTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnDDivTAD, row["TrainAD"].ToString());
                                        SetButttonProperties(btnDDivPF, row["TrainPf"].ToString());
                                        SetButttonProperties(btnDDivCpos, row["TrainCoach"].ToString());

                                        break;



                                    case 17: //Delay Departure
                                        SetButttonProperties(btnDDelayDepTNo, row["TrainNo"].ToString());
                                        SetButttonProperties(btnDDelayDepTName, row["TrainName"].ToString());
                                        SetButttonProperties(btnDDelayDepTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnDDelayDepAD, row["TrainAD"].ToString());
                                        SetButttonProperties(btnDDelayDepPF, row["TrainPf"].ToString());
                                        SetButttonProperties(btnDDelayDepCpos, row["TrainCoach"].ToString());

                                        break;



                                    case 18: //departure Platform Change
                                        SetButttonProperties(btnDPFChangTNo, row["TrainNo"].ToString());
                                        SetButttonProperties(btnDPFChangTName, row["TrainName"].ToString());
                                        SetButttonProperties(btnDPFChangTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnDPFChangAD, row["TrainAD"].ToString());
                                        SetButttonProperties(btnDPFChangPF, row["TrainPf"].ToString());
                                        SetButttonProperties(btnDPFChangCpos, row["TrainCoach"].ToString());

                                        break;

                                    case 19: //change of source
                                        SetButttonProperties(btnDCosChangTNo, row["TrainNo"].ToString());
                                        SetButttonProperties(btnDCosChangTName, row["TrainName"].ToString());
                                        SetButttonProperties(btnDCosChangTime, row["TrainTime"].ToString());
                                        SetButttonProperties(btnDCosChangAD, row["TrainAD"].ToString());
                                        SetButttonProperties(btnDCosChangPF, row["TrainPf"].ToString());
                                        SetButttonProperties(btnDCosChangCpos, row["TrainCoach"].ToString());

                                        break;



                                }

                            }
                        }
                    }
                }
                else
                {
                    setToNormal();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public void AddColumns()
        {
            Colorsdt.Columns.Add("ArrivalORDeparture", typeof(string));
            Colorsdt.Columns.Add("fkey_SchudleStatus", typeof(int));
            Colorsdt.Columns.Add("TrainNo", typeof(string));
            Colorsdt.Columns.Add("TrainName", typeof(string));
            Colorsdt.Columns.Add("TrainTime", typeof(string));
            Colorsdt.Columns.Add("TrainAD", typeof(string));
            Colorsdt.Columns.Add("TrainPf", typeof(string));
            Colorsdt.Columns.Add("TrainCoach", typeof(string));
        }

        private void cmbBoardId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string boardaddress = cmbBoardId.Text;


            int MusterHubkey = GetPk(boardaddress);

            SetColors(MusterHubkey);
            SetBordersColors(MusterHubkey);


            int lastOctet = int.Parse(boardaddress.Split('.').Last());

            if (lastOctet >= 130 && lastOctet <= 160)
            {
                pnlHideCpos.Visible = false;
            }
            else
            {
                pnlHideCpos.Visible = true;
            }
        }







        public string[] allTextBoxNames;
        public void addTextBoxes()
        {
            // String array containing names of all TextBoxes
            allTextBoxNames = new string[]
            {
        // D Running Right Time
        "btnDRRTTNo", "btnDRRTTName", "btnDRRTTime", "btnDRRTAD", "btnDRRTPF", "btnDRRTCpos",
        
        // D Cancelled
        "btnDCanTNo", "btnDCanTName", "btnDCanTime", "btnDCanAD", "btnDCanPF", "btnDCanCpos",
        
        // D Ready To Leave
        "btnDReadyLeaveTNo", "btnDReadyLeaveTName", "btnDReadyLeaveTime", "btnDReadyLeaveAD", "btnDReadyLeavePF", "btnDReadyLeaveCpos",
        
        // D Is On Platform
        "btnDIsonPFTNo", "btnDIsonPFTName", "btnDIsonPFTime", "btnDIsonPFAD", "btnDIsonPF", "btnDIsonPFCpos",
        
        // D Departed
        "btnDDepTNo", "btnDDepTName", "btnDDepTime", "btnDDepTAD", "btnDDepPF", "btnDDepCpos",
        
        // D Rescheduled
        "btnDResTNo", "btnDResTName", "btnDResTime", "btnDResAD", "btnDResPF", "btnDResCpos",
        
        // D Diverted
        "btnDDivTNo", "btnDDivTName", "btnDDivTime", "btnDDivTAD", "btnDDivPF", "btnDDivCpos",
        
        // D Delay Departure
        "btnDDelayDepTNo", "btnDDelayDepTName", "btnDDelayDepTime", "btnDDelayDepAD", "btnDDelayDepPF", "btnDDelayDepCpos",
        
        // D Platform Changed
        "btnDPFChangTNo", "btnDPFChangTName", "btnDPFChangTime", "btnDPFChangAD", "btnDPFChangPF", "btnDPFChangCpos",

        // Arr Running Right Time
        "btnArrRRTTrainNumber", "btnArrRRTTrainName", "btnArrRRTTrainTime", "btnArrRRTTrainAD", "btnArrRRTTrainPF", "btnArrRRTCpos",
        
        // Arr Will Arrive Shortly
        "btnArrWATrainNumber", "btnWATraiName", "btnWATrainTime", "btnWATrainAd", "btnWATrainPf", "btnWATrainCpos",
        
        // Arr Is Arrived On
        "btnArrIsArriveTraiNumber", "btnArrIsArriveTrainName", "btnArrIsArriveTrainTime", "btnArrIsArriveTrainAd", "btnArrIsArriveTrainPf", "btnArrIsArriveCpos",
        
        // Arr Has Arrived On
        "btnArrHasArriveTrainNumber", "btnArrHasArriveTrainName", "btnArrHasArriveTrainTime", "btnArrHasArriveTrainAd", "btnArrHasArriveTrainPf", "btnArrHasArriveCpos",
        
        // Arr Running Late
        "btnArrRLTrainNumber", "btnArrRLTrainName", "btnArrRLTrainTime", "btnArrRLTrainAd", "btnArrRLTrainPf", "btnArrRLCpos",
        
        // Arr Cancelled
        "btnArrCancelTrainNumber", "btnArrCancelTrainName", "btnArrCancelTrainTime", "btnArrCancelTrainAd", "btnArrCancelTrainPf", "btnArrCancelCpos",
        
        // Arr Indefinite Late
        "btnArrIDFTrainNumber", "btnArrIDFTrainName", "btnArrIDFTrainTime", "btnArrIDFTrainAd", "btnArrIDFTrainPf", "btnArrIDFCpos",
        
        // Arr Terminated
        "btnArrTerminTrainNumber", "btnArrTerminTrainName", "btnArrTerminTrainTime", "btnArrTerminTrainAd", "btnArrTerminTrainPf", "btnArrTerminCpos",
        
        // Arr Platform Changed
        "btnArrPlatformChangeTrainNumber", "btnArrPlatformChangeTrainName", "btnArrPlatformChangeTrainTime", "btnArrPlatformChangeTrainAd", "btnArrPlatformChangeTrainPf", "btnArrPlatformChangeCpos",

        //change of source
         "btnDCosChangTNo", "btnDCosChangTName",   "btnDCosChangTime",   "btnDCosChangAD", "btnDCosChangPF", "btnDCosChangCpos",

        "btnVerticalline","btnColorBackground","btnMessageLine","btnHorZontalLine"
            };
        }

        public void setToNormal()
        {
            addTextBoxes();
            foreach (string textname in allTextBoxNames)
            {
                // Find the TextBox control by name
                Button textbox = this.Controls.Find(textname, true).FirstOrDefault() as Button;
                if (textbox != null) // Check if the TextBox was found
                {
                    textbox.BackColor = SystemColors.Window; // Reset to default background color
                    textbox.Text = "change color"; // Update text as needed
                }
            }
        }


    }
}
