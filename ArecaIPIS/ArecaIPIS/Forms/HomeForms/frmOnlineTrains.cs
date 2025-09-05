using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Server_Classes;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.HomeForms
{
    public partial class frmOnlineTrains : Form
    {
        private List<Dictionary<string, object>> selectedRowsData;
        public static string CurrentTrainNumber = "";


        public frmOnlineTrains()
        {
            selectedRowsData = new List<Dictionary<string, object>>();
            //  dgvOnlineTrains.CellContentClick += storeTaddbData;
            //   InitializeComponent();
            //dgvOnlineTrains.AllowUserToResizeRows = false;
        }
        private frmIndex parentForm;
        public frmOnlineTrains(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }
        private static frmOnlineTrains _instance;

        public static frmOnlineTrains GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmOnlineTrains();
            }
            return _instance;
        }

        public void fillRunningTrains()
        {
            if (dgvOnlineTrains != null)
            {
                ChangeTdbColor(true);
                try
                {

                    DataTable onlineTrainsDt = OnlineTrainsDao.GetTopScheduledTaddbRecords();

                    dgvOnlineTrains.Rows.Clear();



                    foreach (DataRow row in onlineTrainsDt.Rows)
                    {
                        int rowIndex = dgvOnlineTrains.Rows.Add();

                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvSnoColumn"].Value = "" + (rowIndex + 1);
                        string trainNum = BaseClass.GetLinktrain(row["TrainNo"].ToString().Trim());

                        if (trainNum != null)
                        {
                            dgvOnlineTrains.Rows[rowIndex].Cells["dgvTrNoColumn"].Value = row["TrainNo"].ToString() + "\n" + "[" + trainNum + "]";

                        }
                        else
                        {
                            dgvOnlineTrains.Rows[rowIndex].Cells["dgvTrNoColumn"].Value = row["TrainNo"].ToString();
                        }
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvTrainNameColumn"].Value = row["Name"].ToString();
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvHindiTrainNameColumn"].Value = row["LNational_Lang"].ToString();
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvRegionalLangColumn"].Value = row["LRegional1_Lang"].ToString();

                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvStaColumn"].Value = row["RArrivalTime"].ToString();
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvSTDColumn"].Value = row["RDepartureTime"].ToString();
                        string ad = row["ArrivingStatus"].ToString();
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvAdColumn"].Value = row["ArrivingStatus"].ToString();
                        // dgvOnlineTrains.Rows[rowIndex].Cells["dgvAdColumn"].Value = GetDataTransferBasedOnipadress( row["ArrivingStatus"].ToString());
                        //if (ad.Trim().ToUpper() == "A")
                        //{
                        //    dgvOnlineTrains.Rows[rowIndex].Cells["dgvAdColumn"].Value = Image.FromFile(@"assets\your_image_file.png");
                        //}
                        bool lateenable = DataController.LateEnabled(row["StatusName"].ToString());


                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvLateColumn"].ReadOnly = lateenable;
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvLateColumn"].Value = row["LateBy"].ToString();
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvEtaColumn"].Value = row["LArrivalTime"].ToString();
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvETDColumn"].Value = row["LDepartureTime"].ToString();



                        //dgvOnlineTrains.Rows[rowIndex].Cells["dgvPFColumn"].Value = row["PlatformName"].ToString();
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvTrainStatusColumn"].Value = row["StatusName"].ToString();

                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvTdbColumn"].Value = Convert.ToBoolean(row["Tadb"].ToString());
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvCdbColumn"].Value = Convert.ToBoolean(row["Cgdb"].ToString());
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvAnnColumn"].Value = Convert.ToBoolean(row["Ann"].ToString());


                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvCityColumn"].Value = row["City"].ToString();
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvHindiCityName"].Value = row["HStation"].ToString();
                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvRegCityName"].Value = row["RStation"].ToString();

                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvNtesColumn"].Value = Convert.ToBoolean(row["Ntes"].ToString());


                        dgvOnlineTrains.Rows[rowIndex].Cells["dgvNtesColumn"].ReadOnly = !BaseClass.IsNtesEnabled();

                        if (row["PlatformName"].ToString() == "")
                        {
                            dgvOnlineTrains.Rows[rowIndex].Cells["dgvPFColumn"].Value = "--";
                        }
                        else
                        {
                            dgvOnlineTrains.Rows[rowIndex].Cells["dgvPFColumn"].Value = row["PlatformName"].ToString();
                        }
                        DataGridViewComboBoxCell comboBoxPF = dgvOnlineTrains.Rows[rowIndex].Cells["dgvPFColumn"] as DataGridViewComboBoxCell;
                        comboBoxPF.Items.Clear();
                        comboBoxPF.Items.Add("--");
                        foreach (string pf in BaseClass.Platforms)
                        {
                            comboBoxPF.Items.Add(pf);
                        }





                        DataGridViewComboBoxCell comboBoxCell = dgvOnlineTrains.Rows[rowIndex].Cells["dgvTrainStatusColumn"] as DataGridViewComboBoxCell;
                        comboBoxCell.Items.Clear();
                        if (ad == "A")
                        {
                            foreach (string status in BaseClass.arrivalStatus)
                            {
                                comboBoxCell.Items.Add(status);
                            }

                            //   comboBoxCell.Value = row["StatusName"].ToString();
                        }
                        else
                        {
                            foreach (string status in BaseClass.DepatureStatus)
                            {
                                comboBoxCell.Items.Add(status);
                            }

                            comboBoxCell.Value = row["StatusName"].ToString();
                        }


                    }


                    AddEmptyLastRow();

                    // dgvOnlineTrains.Rows[dgvOnlineTrains.Rows.Count - 1].Cells["dgvSnoColumn"].Value = "" + (dgvOnlineTrains.Rows.Count);
                }
                catch (Exception ex)
                {
                    Server.LogError(ex.Message);
                }
            }
        }
        public void ChackNtesConfiguration()
        {
            if (BaseClass.ApllicationStart)
            {


                if (BaseClass.IsNtesEnabled())
                {
                    if (BaseClass.IsNtesAutoMode())
                    {
                        // DataController.sendAllBoardsData();
                    }


                    if (BaseClass.IsNtesAudio())
                    {
                        //autoAnnounce();
                    }
                }
                else if (BaseClass.IsLocalAutoMode())
                {
                    // autoAnnounce();
                    //DataController.sendAllBoardsData();
                }



                BaseClass.ApllicationStart = false;
            }
        }
        public void CposTextBoxesInit()
        {

            TextBox[] textBoxes = new TextBox[]
            {
             txtCoach1, txtCoach2, txtCoach3, txtCoach4, txtCoach5,
             txtCoach6, txtCoach7, txtCoach8, txtCoach9, txtCoach10,
             txtCoach11, txtCoach12, txtCoach13, txtCoach14, txtCoach15,
             txtCoach16, txtCoach17, txtCoach18, txtCoach19, txtCoach20,
             txtCoach21, txtCoach22, txtCoach23, txtCoach24, txtCoach25,
              txtCoach26, txtCoach27, txtCoach28
            };

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Enter += TextBox_Enter; // Subscribe to Enter event
            }
        }
        public void FillFirstTainDetails()
        {
            if (dgvOnlineTrains != null)
            {
                DataGridViewRow firstRow = dgvOnlineTrains.Rows[0];

                // Access the cell values
                string TrainNumber = firstRow.Cells["dgvTrNoColumn"].Value?.ToString() ?? string.Empty;
                string TrainName = firstRow.Cells["dgvTrainNameColumn"].Value?.ToString() ?? string.Empty;
                string PF = firstRow.Cells["dgvPFColumn"].Value?.ToString() ?? string.Empty;

                string[] trainNumbers = TrainNumber.Split('\n');
                TrainNumber = trainNumbers[0];


                SetCoachesValues(TrainNumber, TrainName, PF);
            }
        }

        private void frmOnlineTrains_Load(object sender, EventArgs e)
        {

            LoadData();
            _instance = this;
        }
        public static void LoadFillrunningTrains()
        {
            Form mainForm = Application.OpenForms["frmOnlineTrains"];

            if (mainForm != null)
            {
                frmOnlineTrains frmonline = (frmOnlineTrains)mainForm;

                frmonline.fillRunningTrains();
            }
        }

        public void LoadData()
        {

            ChangeTdbColor(true);
            PauseButtonCheck();
            SetStatus();
            LoadFillrunningTrains();
            SetPlatforms();
            SetntesButton();
            SetStations();
            ChackNtesConfiguration();
            CposTextBoxesInit();
            FillFirstTainDetails();

        }



        private void TextBox_Enter(object sender, EventArgs e)
        {
            lastFocusedTextBox = sender as TextBox; // Update the last focused TextBox
        }
        public void setLocalData()
        {
            try
            {


                OnlineTrainsDao.Deletescheduletadb();

                DataTable LocalMode = BaseClass.AutomaticRunningdt;
                DataTable TrainDetailsdt = OnlineTrainsDao.GetAllTrains();



                if (LocalMode.Rows.Count > 0)
                {
                    DataRow row = LocalMode.Rows[0];
                    bool ManualMode = row.Field<bool>("ManualMode");
                    bool AutoMode = row.Field<bool>("AutoMode");


                    bool selectTime = row.Field<bool>("selectTime");
                    bool selectRange = row.Field<bool>("selectRange");

                    if (selectTime)
                    {
                        string fromtime = row.Field<string>("Time_from");
                        string toTime = row.Field<string>("Time_to");
                        DataTable ARRIVALTRAINS = FilterTimeArrivalRange(TrainDetailsdt, fromtime, toTime);
                        DataTable DEPARTURETRAINS = FilterTimeDepartureRange(TrainDetailsdt, fromtime, toTime);

                        DataTable FilteredTrainsBasedOntime = MergeAndRemoveDuplicates(ARRIVALTRAINS, DEPARTURETRAINS);

                        // DataTable FilteredTrainsBasedOntime = FilterTimeRange(TrainDetailsdt, fromtime, toTime);

                        DataTable Latesttrains = SortTrainsByArrival(FilteredTrainsBasedOntime);

                        DataTable platformAssigningforCgdb = CheckPlatformAssignment(Latesttrains);

                        if (AutoMode)
                            InsertSchudeleTadb(platformAssigningforCgdb, "Auto");
                        else
                        {
                            InsertSchudeleTadb(platformAssigningforCgdb, "Manual");
                        }
                    }
                    else
                    {
                        // Handle next hours logic
                        int nextHrs = int.Parse(row.Field<string>("Nexthrs")); // Convert NextHrs to integer

                        // Get current time
                        DateTime currentTime = DateTime.Now;

                        // Calculate the end time by adding nextHrs to current time
                        DateTime endTime = currentTime.AddHours(nextHrs);

                        // If the end time exceeds 23:59, limit it to 23:59
                        if (endTime.TimeOfDay >= TimeSpan.FromHours(24))
                        {
                            endTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
                        }

                        // Filter trains based on the time range from currentTime to endTime
                        DataTable ARRIVALTRAINS = FilterTimeArrivalRange(TrainDetailsdt, currentTime.ToString("HH:mm"), endTime.ToString("HH:mm"));
                        DataTable DEPARTURETRAINS = FilterTimeDepartureRange(TrainDetailsdt, currentTime.ToString("HH:mm"), endTime.ToString("HH:mm"));

                        DataTable FilteredTrainsBasedOnNextHours = MergeAndRemoveDuplicates(ARRIVALTRAINS, DEPARTURETRAINS);

                        DataTable Latesttrains = SortTrainsByArrival(FilteredTrainsBasedOnNextHours);

                        DataTable platformAssigningforCgdb = CheckPlatformAssignment(Latesttrains);

                        if (AutoMode)
                            InsertSchudeleTadb(platformAssigningforCgdb, "Auto");
                        else
                        {
                            InsertSchudeleTadb(platformAssigningforCgdb, "Manual");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        public void InsertSchudeleTadb(DataTable dt, string Mode)
        {
            // Add the new column for platform assignment check if it doesn't exist
            try
            {


                if (dt != null)
                {



                    // Loop through each DataRow in the DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        // Extract values from the DataRow
                        int Fkey_trainNumber = Convert.ToInt32(row["Pkey_TrainNumber"]);
                        string trainNo = row["TrainNumber"].ToString();
                        string[] trainNumbers = trainNo.Split('\n');
                        trainNo = trainNumbers[0];

                        string trainName = row["EnglishName"].ToString();
                        string sta = row["ArrivalTime"].ToString();  // Scheduled Time of Arrival      
                        string std = row["DepartureTime"].ToString();  // Scheduled Time of Departure

                        string Tstatus = "Running Right Time";  // Train Status
                        string delayArr = "00:00";  // Delay in Arrival
                        string eta = row["ArrivalTime"].ToString();  // Estimated Time of Arrival
                        string etd = row["DepartureTime"].ToString();  // Estimated Time of Departure
                        string platformNo = row["Platform"].ToString();  // Platform Number
                        string terminatedPlace = "";  // Terminated Place
                        string trainNameHindi = row["HindiName"].ToString();  // Train Name in Hindi
                        string LocalRegionalName = row["RegionalName"].ToString();  // Local/Regional Name
                        string coachPosition = "";  // Coach Position

                        // Initialize the variables for InsertSchduleData
                        bool tadb, cgdb, ann, ntes;
                        string city = ""; // Initialize city as an empty string

                        if (Mode == "Auto")
                        {
                            tadb = true;
                            cgdb = row.Field<bool>("cgdb");
                            ann = row.Field<bool>("ann");
                            ntes = false;
                        }
                        else if (Mode == "Manual")
                        {
                            tadb = false;
                            cgdb = false;
                            ann = false;
                            ntes = false;
                        }
                        else
                        {
                            // Default values if Mode is not recognized
                            tadb = false;
                            cgdb = false;
                            ann = false;
                            ntes = false;
                        }
                        string ADStatus;  // Arrival/Departure Status
                                          // Check if the platform is already assigned
                        ADStatus = GetAdStatus(sta);



                        // Call the InsertSchduleData method to insert the data
                        InterfaceDb.InsertSchduleData(Fkey_trainNumber, trainNo, trainName, sta, std, ADStatus, Tstatus, delayArr, eta, etd, platformNo, terminatedPlace, trainNameHindi, LocalRegionalName, coachPosition, tadb, cgdb, ann, ntes, city);
                    }
                }
            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        private string GetAdStatus(string arrivaltime)
        {

            try
            {

                // Define the acceptable time formats
                string[] formats = { "H:mm", "HH:mm" };

                // Attempt to parse the arrival time string to a DateTime object
                DateTime arrivalTime;
                bool isValidTime = DateTime.TryParseExact(arrivaltime, formats, null, System.Globalization.DateTimeStyles.None, out arrivalTime);

                if (!isValidTime)
                {
                    // Handle the invalid time format scenario
                    return "Invalid Time Format"; // You can handle this as per your requirement
                }

                // Get the current time
                DateTime currentTime = DateTime.Now;

                // Check if the arrival time is exactly midnight (00:00)
                if (arrivalTime.TimeOfDay == TimeSpan.Zero)
                {
                    return "D";
                }
                // Check if the arrival time is later than the current time
                else if (arrivalTime.TimeOfDay > currentTime.TimeOfDay)
                {
                    return "D";
                }
                // If the arrival time is earlier than or equal to the current time
                else
                {
                    return "A";
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }



        public DataTable CheckPlatformAssignment(DataTable dt)
        {
            try
            {

                if (dt != null)
                {


                    // Add the new column for platform assignment check
                    dt.Columns.Add("cgdb", typeof(bool));
                    dt.Columns.Add("ann", typeof(bool));

                    // Create a dictionary to track platform assignments
                    List<string> platformAssignment = new List<string>();

                    // Iterate through each row to check platform assignment
                    foreach (DataRow row in dt.Rows)
                    {
                        var platform = row["Platform"].ToString();

                        if (!string.IsNullOrEmpty(platform))
                        {
                            if (platformAssignment.Contains(platform))
                            {
                                row["cgdb"] = false;
                                row["ann"] = true;

                            }
                            else
                            {
                                row["cgdb"] = true;
                                row["ann"] = true;
                                platformAssignment.Add(platform);
                            }
                        }
                        else
                        {
                            row["cgdb"] = false;
                            row["ann"] = true;
                        }
                    }


                    return dt;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }
        public DataTable SortTrainsByArrival(DataTable dt)
        {
            try
            {

                if (dt != null)
                {


                    // Clone the structure of the original DataTable to create a new DataTable
                    DataTable SortedTrainsDt = dt.Clone();

                    // Use LINQ to sort the rows based on ArrivalTime in ascending order
                    var sortedRows = dt.AsEnumerable()
                        .OrderBy(row =>
                        {
                            // Try to parse ArrivalTime to DateTime for sorting
                            DateTime arrivalTime;
                            return DateTime.TryParseExact(row["DepartureTime"].ToString(), "HH:mm", null, System.Globalization.DateTimeStyles.None, out arrivalTime)
                                ? arrivalTime
                                : DateTime.MaxValue; // Handle parsing errors
                        });

                    // Import sorted rows into the new DataTable
                    foreach (var row in sortedRows)
                    {
                        SortedTrainsDt.ImportRow(row);
                    }

                    return SortedTrainsDt;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }
        public void SetntesButton()
        {
            try
            {
                if (BaseClass.IsNtesEnabled())
                {
                    tglNtesEnableDisable.Checked = true;
                    lblntesstatus.Text = "Ntes Enabled";

                    ;
                }
                else
                {
                    tglNtesEnableDisable.Checked = false;
                    lblntesstatus.Text = "Ntes Disabled";
                }

            }
            catch (Exception Ex)
            {

            }

        }



        public void SetStatus()
        {
            try
            {


                DataTable ArrivalAndDepartureStatuses = OnlineTrainsDao.GetArrivalAndDepartureStatus();

                BaseClass.arrivalStatus.Clear();
                BaseClass.DepatureStatus.Clear();
                for (int i = 0; i < ArrivalAndDepartureStatuses.Rows.Count; i++)
                {
                    if (ArrivalAndDepartureStatuses.Rows[i][1].ToString() == "A")
                        BaseClass.arrivalStatus.Add(ArrivalAndDepartureStatuses.Rows[i][0].ToString());
                    else
                        BaseClass.DepatureStatus.Add(ArrivalAndDepartureStatuses.Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        public async void refreshOnlineTrains()
        {
            try
            {

                bool ntesConnection = BaseClass.IsNtesEnabled();
                if (ntesConnection)
                {
                    await Task.Run(async () =>
                    {
                        await WebRequestAsync(); // your method is already async
                    });
                }
                BaseClass.OnlineTrainsTaddbDt = OnlineTrainsDao.GetScheduledTaddbTrains();

                LoadFillrunningTrains();
                FillFirstTainDetails();


            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public void resetArrivalStatus(DataGridViewCell cell)
        {
            try
            {
                DataTable onlineTrainsDt = OnlineTrainsDao.GetTopScheduledTaddbRecords();

                DataGridViewComboBoxCell comboBoxCell = dgvOnlineTrains.Rows[cell.RowIndex].Cells["dgvTrainStatusColumn"] as DataGridViewComboBoxCell;
                comboBoxCell.Items.Clear();

                foreach (string status in BaseClass.arrivalStatus)
                {
                    comboBoxCell.Items.Add(status);
                }

                comboBoxCell.Value = "Will Arrive Shortly";

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        public void resetDepatureStatus(DataGridViewCell cell)
        {
            try
            {
                DataTable onlineTrainsDt = OnlineTrainsDao.GetTopScheduledTaddbRecords();
                DataGridViewComboBoxCell comboBoxCell = dgvOnlineTrains.Rows[cell.RowIndex].Cells["dgvTrainStatusColumn"] as DataGridViewComboBoxCell;
                comboBoxCell.Items.Clear();

                foreach (string status in BaseClass.DepatureStatus)
                {
                    comboBoxCell.Items.Add(status);
                }
                comboBoxCell.Value = "Running Right Time";
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }




        public void AddEmptyLastRow()
        {
            // Add an empty last row
            int lastRowIndex = dgvOnlineTrains.Rows.Add();

            // Iterate through the columns and set them to text boxes for the last row
            foreach (DataGridViewColumn column in dgvOnlineTrains.Columns)
            {
                if (column is DataGridViewButtonColumn)
                {
                    // For button column, keep the button but set its text
                    DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                    dgvOnlineTrains.Rows[lastRowIndex].Cells[column.Index] = buttonCell;
                    buttonCell.Value = "";  // Set the button text to an empty string or some default value
                }
                else
                {
                    // For other columns, replace with a TextBox cell
                    DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
                    dgvOnlineTrains.Rows[lastRowIndex].Cells[column.Index] = textBoxCell;
                    textBoxCell.Value = "";  // Set the cell value to an empty string
                }
            }

            // Optionally, set serial number for the last row (if needed)
            dgvOnlineTrains.Rows[lastRowIndex].Cells["dgvSnoColumn"].Value = dgvOnlineTrains.Rows.Count; // Set row number
        }
        public Image GetDataTransferBasedOnipadress(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                // Handle null or empty string by returning a default image (e.g., green icon)
                return Properties.Resources._34214_circle_green_icon;
            }

            // Handle specific cases for "A" and "D"
            if (value.Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                return Properties.Resources._34211_green_icon1; // Image for "A"
            }
            else if (value.Equals("D", StringComparison.OrdinalIgnoreCase))
            {
                return Properties.Resources._34211_green_icon1; // Image for "D"
            }

            // Default case: Return a default image for other input values
            return Properties.Resources._34214_circle_green_icon; // Default image
        }


        private void DgvOnlineTrains_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Handle the data error gracefully
            if (e.Exception != null)
            {
                //  MessageBox.Show("An error occurred: " + e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.ThrowException = false; // Prevent the exception from propagating
            }
        }

        //   static List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
        //private void storeTaddbData(object sender, DataGridViewCellEventArgs e)
        //{ // Check if the clicked cell is in the dgvTdbColumn
        //    if (e.ColumnIndex == dgvOnlineTrains.Columns["dgvTdbColumn"].Index && e.RowIndex >= 0)
        //    {
        //        // Check if the clicked cell's value is a checkbox
        //        if (dgvOnlineTrains.Rows.Count > e.RowIndex &&
        //            dgvOnlineTrains.Rows[e.RowIndex].Cells.Count > e.ColumnIndex &&
        //            dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
        //        {
        //            // Get the value of the checkbox
        //            bool isChecked = false;
        //            if(dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
        //            {
        //                isChecked = (bool)dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        //            }

        //            DataGridViewRow row = dgvOnlineTrains.Rows[e.RowIndex];

        //            string trainName = row.Cells["dgvTrainNameColumn"].Value.ToString();
        //            // Continue retrieving data from other columns as needed...

        //            // Now you have access to the row's data, do whatever you need with it
        //            // Example: Print the train name if the checkbox is checked
        //            if (isChecked)
        //            {
        //                Console.WriteLine("Train Name: " + trainName);
        //            }
        //        }
        //    }
        //}


        public void ScheludeFormOpen()
        {

            try
            {
                BaseClass.selectTrainsDatabase = "ScheduledTrains";
                //frmScheduledTrains frmSch = new frmScheduledTrains();
                //frmSch.Show();
                frmScheduledTrains frmscheduled;

                Form mainForm = Application.OpenForms["frmScheduledTrains"];

                if (mainForm != null)
                {
                    frmscheduled = (frmScheduledTrains)mainForm;
                    frmscheduled.Show();

                }
                else
                {
                    frmscheduled = new frmScheduledTrains();
                    frmscheduled.Show();
                }
                frmscheduled.BringToFront();

                frmscheduled.fillScheduledTrains();
                ChangeTdbColor(true);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public void deleteTrainRow(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvOnlineTrains.Rows[e.RowIndex];
            string trainNumber = row.Cells["dgvTrNoColumn"].Value.ToString();
            string[] trainNumbers = trainNumber.Split('\n');
            trainNumber = trainNumbers[0];


            if (BaseClass.trainNumbers.Contains(trainNumber))
            {
                OnlineTrainsDao.DeleteTrainFromRunningTrains(trainNumber);
            }
            else
            {
                OnlineTrainsDao.DeleteTrainFromRunningTrainsNtes(trainNumber);
            }

            LoadFillrunningTrains();

        }

        public void ChangeAorDStatusButtonGrid(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex];

            DataGridViewCell statuscell = dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];


            // Check if the clicked cell is the column you want to change
            if (dgvOnlineTrains.Columns[e.ColumnIndex].Name == "dgvAdColumn")
            {
                // Check if the cell is initialized and not null
                if (cell != null && cell.Value != null)
                {
                    string currentValue = cell.Value.ToString();

                    // Change text
                    if (currentValue == "A")
                    {
                        cell.Value = "D";
                        resetDepatureStatus(statuscell);

                    }
                    else if (currentValue == "D")
                    {
                        cell.Value = "A";
                        resetArrivalStatus(statuscell);
                    }
                    //dgvOnlineTrains.CurrentRow.Cells["dgvAnnColumn"].Value = false;
                    //dgvOnlineTrains.CurrentRow.Cells["dgvTdbColumn"].Value = false;
                    //dgvOnlineTrains.CurrentRow.Cells["dgvCdbColumn"].Value = false;
                    dgvOnlineTrains.CurrentRow.Cells["dgvCityColumn"].Value = "";
                }

            }

            //this.dgvOnlineTrains.CurrentRow.Cells["dgvLateColumn"].Value = "00:00";

            //this.dgvOnlineTrains.CurrentRow.Cells["dgvEtaColumn"].Value = this.dgvOnlineTrains.CurrentRow.Cells["dgvStaColumn"].Value.ToString();
            //this.dgvOnlineTrains.CurrentRow.Cells["dgvETDColumn"].Value = this.dgvOnlineTrains.CurrentRow.Cells["dgvSTDColumn"].Value.ToString();

            SaveChanges(BaseClass.currentdatgridRow);
        }



        public void SetEmptyToCoaches()
        {
            txtCoach1.Text = string.Empty;
            txtCoach2.Text = string.Empty;
            txtCoach3.Text = string.Empty;
            txtCoach4.Text = string.Empty;
            txtCoach5.Text = string.Empty;
            txtCoach6.Text = string.Empty;
            txtCoach7.Text = string.Empty;
            txtCoach8.Text = string.Empty;
            txtCoach9.Text = string.Empty;
            txtCoach10.Text = string.Empty;
            txtCoach11.Text = string.Empty;
            txtCoach12.Text = string.Empty;
            txtCoach13.Text = string.Empty;
            txtCoach14.Text = string.Empty;
            txtCoach15.Text = string.Empty;
            txtCoach16.Text = string.Empty;
            txtCoach17.Text = string.Empty;
            txtCoach18.Text = string.Empty;
            txtCoach19.Text = string.Empty;
            txtCoach20.Text = string.Empty;
            txtCoach21.Text = string.Empty;
            txtCoach22.Text = string.Empty;
            txtCoach23.Text = string.Empty;
            txtCoach24.Text = string.Empty;
            txtCoach25.Text = string.Empty;
            txtCoach26.Text = string.Empty;
            txtCoach27.Text = string.Empty;
            txtCoach28.Text = string.Empty;
        }
        public void SetTrainsToLinkedCoachesCombo(string trainNumber)
        {
            string ltrainNum = BaseClass.GetLinktrain(trainNumber);

            for (int i = 1; i <= 28; i++)
            {
                var trainControl = this.Controls.Find($"cmbtrainno{i}", true).FirstOrDefault() as ComboBox;

                if (trainControl != null)
                {
                    trainControl.Items.Clear();


                    trainControl.Items.Add(trainNumber);
                    trainControl.Items.Add(ltrainNum);
                    trainControl.SelectedIndex = 0;

                }

            }
        }
        public void SetEmptyToLinkedCoaches()
        {
            txtLCoach1.Text = string.Empty;
            txtLCoach2.Text = string.Empty;
            txtLCoach3.Text = string.Empty;
            txtLCoach4.Text = string.Empty;
            txtLCoach5.Text = string.Empty;
            txtLCoach6.Text = string.Empty;
            txtLCoach7.Text = string.Empty;
            txtLCoach8.Text = string.Empty;
            txtLCoach9.Text = string.Empty;
            txtLCoach10.Text = string.Empty;
            txtLCoach11.Text = string.Empty;
            txtLCoach12.Text = string.Empty;
            txtLCoach13.Text = string.Empty;
            txtLCoach14.Text = string.Empty;
            txtLCoach15.Text = string.Empty;
            txtLCoach16.Text = string.Empty;
            txtLCoach17.Text = string.Empty;
            txtLCoach18.Text = string.Empty;
            txtLCoach19.Text = string.Empty;
            txtLCoach20.Text = string.Empty;
            txtLCoach21.Text = string.Empty;
            txtLCoach22.Text = string.Empty;
            txtLCoach23.Text = string.Empty;
            txtLCoach24.Text = string.Empty;
            txtLCoach25.Text = string.Empty;
            txtLCoach26.Text = string.Empty;
            txtLCoach27.Text = string.Empty;
            txtLCoach28.Text = string.Empty;
        }

        public void SetvaluesToLinkedCoaches(DataTable LinkedcoachPositionsdt)
        {
            foreach (DataRow coachRow in LinkedcoachPositionsdt.Rows)
            {
                string coachpositions = coachRow["coachPositions"].ToString();
                string[] coachValues = coachpositions.Split(',');



                int i = 1;
                foreach (string coach in coachValues)
                {
                    string[] eachCoach = coach.Split('-');
                    string trainnumber = eachCoach[0];
                    string CoachPostion = eachCoach[1];


                    // Find the predefined TextBox dynamically by its name
                    var trainControl = this.Controls.Find($"cmbtrainno{i }", true).FirstOrDefault() as ComboBox;
                    var coachControl = this.Controls.Find($"txtLCoach{i }", true).FirstOrDefault() as TextBox;

                    if (trainControl != null)
                    {
                        trainControl.Text = trainnumber; // Set train number
                    }

                    if (coachControl != null)
                    {
                        coachControl.Text = CoachPostion; // Set coach position
                    }

                    i++;
                }



            }
        }
        List<string> linkedCoachList = new List<string>();
        public void AddLinkedCoachDetailsList()
        {
            try
            {

                linkedCoachList.Clear();
                CoachDetailsList.Clear();

                for (int i = 1; i <= 28; i++)
                {
                    // Find the predefined TextBox dynamically by its name
                    var trainControl = this.Controls.Find($"cmbtrainno{i }", true).FirstOrDefault() as ComboBox;
                    var coachControl = this.Controls.Find($"txtLCoach{i }", true).FirstOrDefault() as TextBox;
                    string trainnumber = "";
                    string CoachPostion = "";
                    if (trainControl != null)
                    {
                        trainnumber = trainControl.Text; // Set train number
                    }

                    if (coachControl != null)
                    {
                        CoachPostion = coachControl.Text; // Set coach position
                    }

                    linkedCoachList.Add(trainnumber + "-" + CoachPostion);
                    CoachDetailsList.Add(CoachPostion);

                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public void SetCoachesValues(string trainNumber, string TrainName, string Pf)
        {


            activateOrDeactivateButtons(false);

            (string pf, string status) = BaseClass.GetStationStatus(trainNumber);




            CurrentTrainNumber = trainNumber;
            LblCgdbTrainNo.Visible = true;
            lblAppendedPlatform.Visible = true;
            lblAStatus.Visible = true;
            LblCgdbTrainNo.Text = CurrentTrainNumber;
            lblAppendedTrainName.Text = TrainName;
            lblAppendedPlatform.Text = pf;
            lblAStatus.Text = status;
            lblAppendedTrainName.Visible = true;

            SetEmptyToLinkedCoaches();
            SetEmptyToCoaches();

            if (BaseClass.LinkedTrainsList.Contains(trainNumber))
            {
                pnlCoachPositions.Visible = false;
                panlinkedCgdb.Visible = true;
                DataTable LinkedcoachPositionsdt = OnlineTrainsDao.getLinkedTempCoachPositionsByTrainNumber(trainNumber);
                SetTrainsToLinkedCoachesCombo(trainNumber);
                if (LinkedcoachPositionsdt.Rows.Count == 0)
                {
                    // SetEmptyToLinkedCoaches();

                }
                else
                {
                    SetvaluesToLinkedCoaches(LinkedcoachPositionsdt);
                }

            }
            else
            {
                panlinkedCgdb.Visible = false;
                pnlCoachPositions.Visible = true;


                DataTable coachPositionsdt = OnlineTrainsDao.getTempCoachPositionsByTrainNumber(trainNumber);//temp table

                if (coachPositionsdt.Rows.Count == 0)
                {
                    SetEmptyToCoaches();
                }
                else
                {
                    foreach (DataRow coachRow in coachPositionsdt.Rows)
                    {
                        string coachpositions = coachRow["coachPositions"].ToString();
                        string[] coachValues = coachpositions.Split(',');


                        txtCoach1.Text = coachValues.Length > 0 ? coachValues[0] : string.Empty;
                        txtCoach2.Text = coachValues.Length > 1 ? coachValues[1] : string.Empty;
                        txtCoach3.Text = coachValues.Length > 2 ? coachValues[2] : string.Empty;
                        txtCoach4.Text = coachValues.Length > 3 ? coachValues[3] : string.Empty;
                        txtCoach5.Text = coachValues.Length > 4 ? coachValues[4] : string.Empty;
                        txtCoach6.Text = coachValues.Length > 5 ? coachValues[5] : string.Empty;
                        txtCoach7.Text = coachValues.Length > 6 ? coachValues[6] : string.Empty;
                        txtCoach8.Text = coachValues.Length > 7 ? coachValues[7] : string.Empty;
                        txtCoach9.Text = coachValues.Length > 8 ? coachValues[8] : string.Empty;
                        txtCoach10.Text = coachValues.Length > 9 ? coachValues[9] : string.Empty;
                        txtCoach11.Text = coachValues.Length > 10 ? coachValues[10] : string.Empty;
                        txtCoach12.Text = coachValues.Length > 11 ? coachValues[11] : string.Empty;
                        txtCoach13.Text = coachValues.Length > 12 ? coachValues[12] : string.Empty;
                        txtCoach14.Text = coachValues.Length > 13 ? coachValues[13] : string.Empty;
                        txtCoach15.Text = coachValues.Length > 14 ? coachValues[14] : string.Empty;
                        txtCoach16.Text = coachValues.Length > 15 ? coachValues[15] : string.Empty;
                        txtCoach17.Text = coachValues.Length > 16 ? coachValues[16] : string.Empty;
                        txtCoach18.Text = coachValues.Length > 17 ? coachValues[17] : string.Empty;
                        txtCoach19.Text = coachValues.Length > 18 ? coachValues[18] : string.Empty;
                        txtCoach20.Text = coachValues.Length > 19 ? coachValues[19] : string.Empty;
                        txtCoach21.Text = coachValues.Length > 20 ? coachValues[20] : string.Empty;
                        txtCoach22.Text = coachValues.Length > 21 ? coachValues[21] : string.Empty;
                        txtCoach23.Text = coachValues.Length > 22 ? coachValues[22] : string.Empty;
                        txtCoach24.Text = coachValues.Length > 23 ? coachValues[23] : string.Empty;
                        txtCoach25.Text = coachValues.Length > 24 ? coachValues[24] : string.Empty;
                        txtCoach26.Text = coachValues.Length > 25 ? coachValues[25] : string.Empty;
                        txtCoach27.Text = coachValues.Length > 26 ? coachValues[26] : string.Empty;
                        txtCoach28.Text = coachValues.Length > 27 ? coachValues[27] : string.Empty;

                    }

                }
            }
        }

        private void dgvOnlineTrains_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex == dgvOnlineTrains.Rows.Count - 1) && (e.ColumnIndex == 2))
            {
                ScheludeFormOpen();
            }

        }



        private void frmOnlineTrains_Leave(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["frmScheduledTrains"];
            if (mainForm != null)
            {
                frmScheduledTrains frmScheduled = (frmScheduledTrains)mainForm;
                frmScheduled.Close();
            }
        }

        private void frmOnlineTrains_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {


                Form mainForm = Application.OpenForms["frmScheduledTrains"];
                if (mainForm != null)
                {
                    frmScheduledTrains frmScheduled = (frmScheduledTrains)mainForm;
                    frmScheduled.Close();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public void activateOrDeactivateButtons(bool trueOrFalse)
        {
            try
            {

                btnRight.Enabled = trueOrFalse;
                btnInsert.Enabled = trueOrFalse;
                btnLeft.Enabled = trueOrFalse;
                btnReverse.Enabled = trueOrFalse;
                btnRemove.Enabled = trueOrFalse;
                btnCancel.Enabled = trueOrFalse;
                btnTrainRevesal.Enabled = trueOrFalse;
                btnSingleRemoval.Enabled = trueOrFalse;
                btnSave.Enabled = trueOrFalse;
                btnTrainRevesal.Enabled = trueOrFalse;
                foreach (Control ctrl in pnlCoachPositions.Controls)
                {
                    if (ctrl is TextBox textBox)
                    {

                        textBox.Enabled = trueOrFalse;

                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public void activateOrDeactivateLinkedCoachesButtons(bool trueOrFalse)
        {
            try
            {

                btnRight.Enabled = trueOrFalse;
                btnInsert.Enabled = trueOrFalse;
                btnLeft.Enabled = trueOrFalse;
                btnReverse.Enabled = trueOrFalse;
                btnRemove.Enabled = trueOrFalse;
                btnCancel.Enabled = trueOrFalse;
                btnTrainRevesal.Enabled = trueOrFalse;
                btnSingleRemoval.Enabled = trueOrFalse;
                btnSave.Enabled = trueOrFalse;
                btnTrainRevesal.Enabled = trueOrFalse;
                panlinkedCgdb.Enabled = trueOrFalse;


                foreach (Control ctrl in panlinkedCgdb.Controls)
                {
                    if (ctrl is TextBox textBox)
                    {

                        textBox.Enabled = trueOrFalse;

                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {


            if (BaseClass.LinkedTrainsList.Contains(CurrentTrainNumber))
            {
                activateOrDeactivateLinkedCoachesButtons(true);

            }
            else
            {
                activateOrDeactivateButtons(true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {




                if (BaseClass.LinkedTrainsList.Contains(CurrentTrainNumber))
                {
                    activateOrDeactivateLinkedCoachesButtons(false);
                    AddLinkedCoachDetailsList();
                    OnlineTrainsDao.InsertUpdateLinkedTrainsCoaches(CurrentTrainNumber, linkedCoachList);
                    OnlineTrainsDao.InsertUpdateTempCoaches(CurrentTrainNumber, CoachDetailsList);
                    OnlineTrainsDao.InsertUpdateMainCoaches(CurrentTrainNumber, CoachDetailsList);
                }
                else
                {
                    activateOrDeactivateButtons(false);
                    AddCoachDetailsList();
                    OnlineTrainsDao.InsertUpdateTempCoaches(CurrentTrainNumber, CoachDetailsList);
                    OnlineTrainsDao.InsertUpdateMainCoaches(CurrentTrainNumber, CoachDetailsList);

                    //OnlineTrainsDao.InsertUpdateTrainCoaches(CurrentTrainNumber, CoachDetailsList);
                }


            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            curretTextBoxTab = 0;
        }



        public void fillCoaches(string a)
        {
            try
            {


                //  string a = "ENG,GEN,S1,S2,S3,S4,S5,A1,A2,A3,A4,B1,B2,B1,C1,C2,C3,B2,B2,B2,S5,A1,A2,A3,GEN,GEN,GEN,PWR";
                string[] parts = a.Split(',');

                // Ensure we do not exceed the array bounds
                TextBox[] textBoxes = {
            txtCoach1, txtCoach2, txtCoach3, txtCoach4, txtCoach5,
            txtCoach6, txtCoach7, txtCoach8, txtCoach9, txtCoach10,
            txtCoach11, txtCoach12, txtCoach13, txtCoach14, txtCoach15,
            txtCoach16, txtCoach17, txtCoach18, txtCoach19, txtCoach20,
             txtCoach21, txtCoach22, txtCoach23, txtCoach24, txtCoach25,
            txtCoach26, txtCoach27, txtCoach28,
        };

                for (int i = 0; i < textBoxes.Length && i < parts.Length; i++)
                {
                    textBoxes[i].Text = parts[i];
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {

            if (BaseClass.LinkedTrainsList.Contains(CurrentTrainNumber))
            {
                trainReverselinkedCoaches();

            }
            else
            {
                trainReverse();
            }

        }

        private void trainReverselinkedCoaches()
        {
            try
            {


                // Define the array of TextBoxes
                TextBox[] textBoxes = {
                txtLCoach1, txtLCoach2, txtLCoach3, txtLCoach4, txtLCoach5,
            txtLCoach6, txtLCoach7, txtLCoach8, txtLCoach9, txtLCoach10,
            txtLCoach11, txtLCoach12, txtLCoach13, txtLCoach14, txtLCoach15,
            txtLCoach16, txtLCoach17, txtLCoach18, txtLCoach19, txtLCoach20,
            txtLCoach21, txtLCoach22, txtLCoach23, txtLCoach24, txtLCoach25,
            txtLCoach26, txtLCoach27, txtLCoach28
            };

                // Swap the values in the TextBoxes
                int leftIndex = 0;
                int rightIndex = textBoxes.Length - 1;
                while (leftIndex < rightIndex)
                {
                    // Swap text
                    string temp = textBoxes[leftIndex].Text;
                    textBoxes[leftIndex].Text = textBoxes[rightIndex].Text;
                    textBoxes[rightIndex].Text = temp;

                    // Move indices towards the center
                    leftIndex++;
                    rightIndex--;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        private void trainReverse()
        {
            try
            {


                // Define the array of TextBoxes
                TextBox[] textBoxes = {
                txtCoach1, txtCoach2, txtCoach3, txtCoach4, txtCoach5,
                txtCoach6, txtCoach7, txtCoach8, txtCoach9, txtCoach10,
                txtCoach11, txtCoach12, txtCoach13, txtCoach14, txtCoach15,
                txtCoach16, txtCoach17, txtCoach18, txtCoach19, txtCoach20,
                txtCoach21, txtCoach22, txtCoach23, txtCoach24, txtCoach25,
                txtCoach26, txtCoach27, txtCoach28
            };

                // Swap the values in the TextBoxes
                int leftIndex = 0;
                int rightIndex = textBoxes.Length - 1;
                while (leftIndex < rightIndex)
                {
                    // Swap text
                    string temp = textBoxes[leftIndex].Text;
                    textBoxes[leftIndex].Text = textBoxes[rightIndex].Text;
                    textBoxes[rightIndex].Text = temp;

                    // Move indices towards the center
                    leftIndex++;
                    rightIndex--;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {


            if (BaseClass.LinkedTrainsList.Contains(CurrentTrainNumber))
            {
                ClearTextBoxesInPanel(panlinkedCgdb);

            }
            else
            {
                ClearTextBoxesInPanel(pnlCoachPositions);
            }


        }
        private void ClearTextBoxesInPanel(Panel panel)
        {
            try
            {


                // Iterate through all controls within the panel
                foreach (Control control in panel.Controls)
                {
                    // Check if the control is a TextBox
                    if (control is TextBox textBox)
                    {
                        // Clear the text of the TextBox
                        textBox.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private TextBox lastFocusedTextBox;
        private void btnSingleRemoval_Click(object sender, EventArgs e)
        {


            if (BaseClass.LinkedTrainsList.Contains(CurrentTrainNumber))
            {

                ClearNextTextBoxLinkedCoaches();
            }
            else
            {
                ClearNextTextBox();
            }

        }
        private void InsertTextBoxLinked()
        {
            try
            {
                TextBox[] textBoxes = new TextBox[]
                {
           txtLCoach1, txtLCoach2, txtLCoach3, txtLCoach4, txtLCoach5,
            txtLCoach6, txtLCoach7, txtLCoach8, txtLCoach9, txtLCoach10,
            txtLCoach11, txtLCoach12, txtLCoach13, txtLCoach14, txtLCoach15,
            txtLCoach16, txtLCoach17, txtLCoach18, txtLCoach19, txtLCoach20,
            txtLCoach21, txtLCoach22, txtLCoach23, txtLCoach24, txtLCoach25,
            txtLCoach26, txtLCoach27, txtLCoach28
                };

                // Ensure that a TextBox was focused
                if (lastFocusedTextBox != null)
                {
                    // Find the index of the last focused TextBox
                    int currentIndex = Array.IndexOf(textBoxes, lastFocusedTextBox);

                    // Ensure the index is valid
                    if (currentIndex >= 0 && currentIndex < textBoxes.Length - 1)
                    {
                        // Shift the text from the next TextBox to the current one
                        for (int i = textBoxes.Length - 1; i > currentIndex; i--)
                        {
                            textBoxes[i].Text = textBoxes[i - 1].Text;
                        }

                        // Clear the current TextBox
                        lastFocusedTextBox.Clear();

                        // Keep focus on the current TextBox
                        lastFocusedTextBox.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Cannot shift text from this TextBox.");
                    }
                }
                else
                {
                    MessageBox.Show("No TextBox was focused.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private void InsertTextBox()
        {
            try
            {
                TextBox[] textBoxes = new TextBox[]
                {
            txtCoach1, txtCoach2, txtCoach3, txtCoach4, txtCoach5,
            txtCoach6, txtCoach7, txtCoach8, txtCoach9, txtCoach10,
            txtCoach11, txtCoach12, txtCoach13, txtCoach14, txtCoach15,
            txtCoach16, txtCoach17, txtCoach18, txtCoach19, txtCoach20,
            txtCoach21, txtCoach22, txtCoach23, txtCoach24, txtCoach25,
            txtCoach26, txtCoach27, txtCoach28
                };

                // Ensure that a TextBox was focused
                if (lastFocusedTextBox != null)
                {
                    // Find the index of the last focused TextBox
                    int currentIndex = Array.IndexOf(textBoxes, lastFocusedTextBox);

                    // Ensure the index is valid
                    if (currentIndex >= 0 && currentIndex < textBoxes.Length - 1)
                    {
                        // Shift the text from the next TextBox to the current one
                        for (int i = textBoxes.Length - 1; i > currentIndex; i--)
                        {
                            textBoxes[i].Text = textBoxes[i - 1].Text;
                        }

                        // Clear the current TextBox
                        lastFocusedTextBox.Clear();

                        // Keep focus on the current TextBox
                        lastFocusedTextBox.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Cannot shift text from this TextBox.");
                    }
                }
                else
                {
                    MessageBox.Show("No TextBox was focused.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private int currentTextBoxIndex = 0;

        private void ClearNextTextBoxLinkedCoaches()
        {
            try
            {


                TextBox[] textBoxes = { txtLCoach1, txtLCoach2, txtLCoach3, txtLCoach4, txtLCoach5,
            txtLCoach6, txtLCoach7, txtLCoach8, txtLCoach9, txtLCoach10,
            txtLCoach11, txtLCoach12, txtLCoach13, txtLCoach14, txtLCoach15,
            txtLCoach16, txtLCoach17, txtLCoach18, txtLCoach19, txtLCoach20,
            txtLCoach21, txtLCoach22, txtLCoach23, txtLCoach24, txtLCoach25,
            txtLCoach26, txtLCoach27, txtLCoach28 };

                // Check if there are TextBoxes left to clear
                if (currentTextBoxIndex < textBoxes.Length - 1)
                {
                    // Iterate over each TextBox from the current index to the second last one
                    for (int i = currentTextBoxIndex; i < textBoxes.Length - 1; i++)
                    {
                        // Assign the text of the next TextBox to the current TextBox
                        textBoxes[i].Text = textBoxes[i + 1].Text;
                    }

                    // Clear the text of the last TextBox
                    textBoxes[textBoxes.Length - 1].Clear();

                    // Reset the currentTextBoxIndex to 0 to start from the beginning
                    currentTextBoxIndex = 0;
                }
                else
                {
                    // Clear the text of the last TextBox if all TextBoxes have been cleared
                    textBoxes[textBoxes.Length - 1].Clear();

                    MessageBox.Show("All text boxes have been cleared.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public static int curretTextBoxTab = 0;
        private void ClearNextTextBox()
        {
            try
            {
                TextBox[] textBoxes = {txtCoach1, txtCoach2, txtCoach3, txtCoach4, txtCoach5, txtCoach6, txtCoach7, txtCoach8, txtCoach9, txtCoach10,
                txtCoach11, txtCoach12, txtCoach13, txtCoach14, txtCoach15, txtCoach16, txtCoach17, txtCoach18, txtCoach19, txtCoach20,
                txtCoach21, txtCoach22, txtCoach23, txtCoach24, txtCoach25, txtCoach26, txtCoach27, txtCoach28 };
                // Ensure the index is within bounds
                if (curretTextBoxTab >= 0 && currentTextBoxIndex < textBoxes.Length)
                {
                    // Clear the current TextBox
                    textBoxes[curretTextBoxTab-1].Clear();

                    // Shift all values from the next TextBox forward
                    for (int i = curretTextBoxTab-1; i < textBoxes.Length - 1; i++)
                    {
                        textBoxes[i].Text = textBoxes[i+1].Text;
                    }

                    // Clear the last TextBox since it's now duplicated
                    textBoxes[textBoxes.Length - 1].Clear();
                }
                else
                {
                    MessageBox.Show("Invalid index or no more text boxes to clear.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            curretTextBoxTab = 0;
        }
        private void btnSingleRemoval_Leave(object sender, EventArgs e)
        {
            currentTextBoxIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (BaseClass.LinkedTrainsList.Contains(CurrentTrainNumber))
            {
                activateOrDeactivateLinkedCoachesButtons(true);

            }
            else
            {
                activateOrDeactivateButtons(true);
            }
            // activateOrDeactivateButtons(false);
            curretTextBoxTab = 0;
        }
        public static List<DataGridViewRow> checkedRows = new List<DataGridViewRow>();
        private bool CheckCheckedRows()
        {
            bool b = false;
            try
            {

                checkedRows.Clear();
                foreach (DataGridViewRow row in dgvOnlineTrains.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (Convert.ToBoolean(row.Cells["dgvTdbColumn"].EditedFormattedValue))
                        {
                            checkedRows.Add(row);
                        }
                    }
                }
                BaseClass.SelectedTDBRows = checkedRows.Count;
                if (checkedRows.Count > 0)
                {
                    b = true;
                    foreach (var row in checkedRows)
                    {
                        if (row.Cells["dgvPFColumn"].Value == null)
                        {
                            b = false;
                        }
                    }
                    if (b)
                    {

                    }
                    else
                    {
                        MessageBox.Show("please Select PlatForm");
                    }
                }
                else
                {
                    if (!BaseClass.IsNtesAutoMode() && !BaseClass.IsLocalAutoMode())
                        MessageBox.Show("please Select Atleast one Train");
                }
                BaseClass.TaddbRows = checkedRows;



            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return b;

        }

        public static List<string> CoachDetailsList = new List<string>();

        public void AddCoachDetailsList()
        {
            try
            {


                CoachDetailsList.Clear();

                CoachDetailsList.Add(txtCoach1.Text);
                CoachDetailsList.Add(txtCoach2.Text);
                CoachDetailsList.Add(txtCoach3.Text);
                CoachDetailsList.Add(txtCoach4.Text);
                CoachDetailsList.Add(txtCoach5.Text);
                CoachDetailsList.Add(txtCoach6.Text);
                CoachDetailsList.Add(txtCoach7.Text);
                CoachDetailsList.Add(txtCoach8.Text);
                CoachDetailsList.Add(txtCoach9.Text);
                CoachDetailsList.Add(txtCoach10.Text);
                CoachDetailsList.Add(txtCoach11.Text);
                CoachDetailsList.Add(txtCoach12.Text);
                CoachDetailsList.Add(txtCoach13.Text);
                CoachDetailsList.Add(txtCoach14.Text);
                CoachDetailsList.Add(txtCoach15.Text);
                CoachDetailsList.Add(txtCoach16.Text);
                CoachDetailsList.Add(txtCoach17.Text);
                CoachDetailsList.Add(txtCoach18.Text);
                CoachDetailsList.Add(txtCoach19.Text);
                CoachDetailsList.Add(txtCoach20.Text);
                CoachDetailsList.Add(txtCoach21.Text);
                CoachDetailsList.Add(txtCoach22.Text);
                CoachDetailsList.Add(txtCoach23.Text);
                CoachDetailsList.Add(txtCoach24.Text);
                CoachDetailsList.Add(txtCoach25.Text);
                CoachDetailsList.Add(txtCoach26.Text);
                CoachDetailsList.Add(txtCoach27.Text);
                CoachDetailsList.Add(txtCoach28.Text);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public void ShowDataSucessfullyMessage(bool sucess)
        {
            if (sucess)
            {

                this.BeginInvoke(new Action(() =>
                {
                    lblDataSentMessage.Text = "Data Sent Successfully....";
                    lblDataSentMessage.ForeColor = Color.Green;

                }));

            }
            else
            {
                this.BeginInvoke(new Action(() =>
                {
                    // Show failure message for 10 seconds
                    lblDataSentMessage.Text = "Failed to Send Data..";
                    lblDataSentMessage.ForeColor = Color.Red;

                }));


            }

            // Make the label visible
            lblDataSentMessage.Visible = true;

            // Start a timer to clear the label after 10 seconds
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000; // 5 seconds
            timer.Tick += (s, _) =>
            {
                // Clear the label text and hide the label
                lblDataSentMessage.Text = "";
                lblDataSentMessage.Visible = false;

                // Stop and dispose the timer
                timer.Stop();
                timer.Dispose();


            };
            timer.Start(); // Start the timer
        }



        private async void btnTdb_Click(object sender, EventArgs e)
        {
           
            try
            {

                DialogResult dialogResult = MessageBox.Show("Do you want to Transfer Data to TADDB Boards", "Send Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ChangeTdbColor(false);
                    bool sucess = DataController.sendTaddbData();
                    ShowDataSucessfullyMessage(sucess);
                }

                else if (dialogResult == DialogResult.No)
                {
                    // User clicked 'No', handle accordingly djdjorjo oooeo
                }

              //  await SharedIpFailover.ForceTakeoverSharedIP();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void dgvOnlineTrains_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            // Check if the pressed key is a digit or backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                // If the key is not a digit or backspace, cancel the input
                e.Handled = true;
            }

            TextBox textBox = sender as TextBox;

            if (textBox.Text.Length >= 5 && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Maximum 5 characters allowed.",
                                "Validation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                e.Handled = true; // stops further typing
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if the Enter key was pressed
            if (keyData == Keys.Enter)
            {
                // Get the currently active control
                if (dgvOnlineTrains.IsCurrentCellInEditMode)
                {
                    // Get the text entered in the current cell
                    string enteredText = dgvOnlineTrains.EditingControl.Text;

                    // Show message box with the entered text if it's not empty
                    if (!string.IsNullOrEmpty(enteredText))
                    {
                        //MessageBox.Show("Entered text: " + enteredText);
                        if (enteredText.Length == 5)
                        {
                            bool existed = false;
                            DataTable onlineTrainsDt = OnlineTrainsDao.GetTopScheduledTaddbRecords();
                            if(onlineTrainsDt!=null && onlineTrainsDt.Rows.Count>0)
                            {
                                 existed = onlineTrainsDt.AsEnumerable().Any(row => row.Field<string>("TrainNo") == enteredText);
                            }

                            if (!existed)
                            {
                                //string trainum=Row
                                bool trainexists = OnlineTrainsDao.DeleteTrainByNumber(enteredText.Trim());
                                if (!trainexists)
                                {
                                    enteredText = "";
                                    MessageBox.Show("Please Enter Valid Train Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }
                                LoadFillrunningTrains();
                            }
                            else
                            {
                                MessageBox.Show("Train Number Already Existed");
                                LoadFillrunningTrains();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Valid Train Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        // End the editing process in DataGridView after showing the message
                        dgvOnlineTrains.EndEdit();
                    }

                    // Prevent the default Enter key behavior
                    return true;
                }
            }

            // Pass the key on to the base method
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void dgvOnlineTrains_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key was pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Suppress the default Enter key behavior
                e.SuppressKeyPress = true;


                // Get the text entered in the cell
                TextBox tb = sender as TextBox;
                if (tb != null)
                {
                    string enteredText = tb.Text;

                    // Show message box with the entered text if it's not empty
                    if (!string.IsNullOrEmpty(enteredText))
                    {
                        MessageBox.Show("Entered text: " + enteredText);

                        // End the editing process in DataGridView after showing the message
                        dgvOnlineTrains.EndEdit();
                    }
                }
            }
        }
        private void TimeColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            var currentCell = dgvOnlineTrains.CurrentCell;


            try
            {
                if (currentCell != null && currentCell.OwningColumn.Name == "dgvLateColumn")
                {
                    TextBox tb = sender as TextBox;
                    // Allow digits only
                    if (char.IsDigit(e.KeyChar) && tb.Text.Replace(":", "").Length < 4)
                    {
                        tb.Text += e.KeyChar;
                        tb.SelectionStart = tb.Text.Length;
                        e.Handled = true; // Mark the event as handled
                    }
                    // Handle backspace input
                    else if (e.KeyChar == (char)Keys.Back && tb.Text.Length > 0)
                    {
                        tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
                        if (tb.Text.Length == 2)
                        {
                            tb.Text = tb.Text.Substring(0, 1); // Remove the colon if it exists
                        }
                        tb.SelectionStart = tb.Text.Length;
                        e.Handled = true; // Mark the event as handled
                    }
                    // Allow only digits and backspace
                    else if (!char.IsControl(e.KeyChar)) // Block non-control characters (other than backspace)
                    {
                        e.Handled = true; // Prevent any other characters
                    }
                    // Automatically insert the colon when the length reaches 4 digits
                    if (tb.Text.Replace(":", "").Length == 4 && !tb.Text.Contains(":"))
                    {
                        tb.Text = tb.Text.Insert(2, ":");
                        tb.SelectionStart = tb.Text.Length;

                        // Validate the time after inserting the colon
                        ValidateTimeInput(tb);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        // Method to validate the time input
        private void ValidateTimeInput(TextBox tb)
        {
            string[] timeParts = tb.Text.Split(':');
            int hours = int.Parse(timeParts[0]);
            int minutes = int.Parse(timeParts[1]);

            // Check if the hours are within the valid range
            if (hours > 23 || minutes > 59)
            {
                // MessageBox.Show("Invalid time format. Please enter a time within 00:00 to 23:59.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Text = "00:00"; // Clear the text or reset to a default value
                tb.SelectionStart = 5;
            }
            else
            {

            }
        }

        private void Tb_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string input = textBox.Text;

                // Check if the input is in HH:mm format
                if (TimeSpan.TryParse(input, out TimeSpan time))
                {
                    // Optional: You can format or process the valid time here
                    textBox.Text = time.ToString(@"hh\:mm");
                }
                else
                {
                    // Handle invalid time input
                    MessageBox.Show("Please enter a valid time in HH:mm format.");
                    textBox.Text = "00:00"; // Reset to default
                }
            }
        }
        private void Tb_TextChanged(object sender, EventArgs e)
        {
        }
        private void validatetime(TextBox textBox)
        {
            try
            {


                string input = textBox.Text;

                // Check if the input matches the HH:mm format
                if (TimeSpan.TryParseExact(input, @"hh\:mm", null, out TimeSpan time))
                {
                    // If valid, clear the error label
                    textBox.Text = input;


                }
                else
                {
                    // If invalid, display an error message and reset the TextBox to "00:00"

                    textBox.Text = "00:00";
                    textBox.SelectionStart = textBox.Text.Length; // Move the cursor to the end of the text
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;



            if (checkBox != null)
            {
                // Example: Show a message with the checkbox state
                MessageBox.Show($"Checkbox is now {(checkBox.Checked ? "Checked" : "Unchecked")}",
                                "Checkbox Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Additional logic for when the checkbox state changes
                // For example, you might want to update a database or perform other actions
            }
        }




        private void dgvOnlineTrains_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void ShowInvalidTimeMessage(int rowIndex, int columnIndex)
        {
            MessageBox.Show("Please enter a valid time in HHmm or HH:mm format.");
            ResetCellToDefault(rowIndex, columnIndex);
        }


        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            var currentCell = dgvOnlineTrains.CurrentCell;
            String TrainNumber = "";
            if (dgvOnlineTrains.CurrentRow.Index < dgvOnlineTrains.Rows.Count - 1)
                TrainNumber = dgvOnlineTrains.CurrentRow.Cells["dgvTrNoColumn"].Value?.ToString();
            try
            {
                if (sender is ComboBox comboBox)
                {
                    string selectedValue = comboBox.SelectedItem.ToString();
                    if (TrainNumber != null)
                        CheckCgdbValidation(comboBox, selectedValue, TrainNumber);
                    CheckTrainStatusColumn(comboBox, selectedValue, TrainNumber);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public void CheckSamePlatformExistedOrNot(ComboBox comboBox, string selectedValue, String TrainNumber)
        {

            var currentCell = dgvOnlineTrains.CurrentCell;


            TrainNumber = BaseClass.currentdatgridRow.Cells["dgvTrNoColumn"].Value?.ToString();
            bool CgdbChecked = Convert.ToBoolean(dgvOnlineTrains.CurrentRow.Cells["dgvCdbColumn"].Value.ToString());
            if (CgdbChecked)
            {
                selectedValue = comboBox.SelectedItem.ToString();
                TrainNumber = BaseClass.currentdatgridRow.Cells["dgvTrNoColumn"].Value?.ToString();


                foreach (DataGridViewRow row in checkedCgDbRows)
                {
                    if (TrainNumber != row.Cells["dgvTrNoColumn"].Value?.ToString())
                    {

                        if (selectedValue == row.Cells["dgvPFColumn"].Value?.ToString())
                        {

                            this.dgvOnlineTrains.CurrentRow.Cells["dgvPFColumn"].Value = "--";
                            BaseClass.currentdatgridRow.Cells["dgvCdbColumn"].Value = false;
                            MessageBox.Show("already Existed");
                        }


                    }

                }
            }
        }
        public void CheckCgdbValidation(ComboBox comboBox, string selectedValue, String TrainNumber)
        {

            var currentCell = dgvOnlineTrains.CurrentCell;



            if (currentCell != null && currentCell.OwningColumn.Name == "dgvPFColumn" || dgvOnlineTrains.CurrentCell.RowIndex > dgvOnlineTrains.Rows.Count - 1)
            {
                CheckSamePlatformExistedOrNot(comboBox, selectedValue, TrainNumber);



                CheckCgdbReportData(comboBox, selectedValue, TrainNumber);




            }
        }
        public void CheckCgdbReportData(ComboBox comboBox, string selectedValue, String TrainNumber)
        {
            var currentCell = dgvOnlineTrains.CurrentCell;
            String Pf = BaseClass.currentdatgridRow.Cells["dgvPFColumn"].Value?.ToString();

            if (Pf != selectedValue)
            {
                // this.dgvOnlineTrains.CurrentRow.Cells["dgvCdbColumn"].Value = false;
                ReportDb.InsertPlatformChangeReportData(selectedValue, TrainNumber);

                if (BaseClass.NtesplatformUpdate)
                {


                    if (BaseClass.IsNtesEnabled())
                    {

                        DialogResult dialogResult = MessageBox.Show("Do you want to Change In NTES Server", "Send Confirmation", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            DynamicPFUpdation(TrainNumber, selectedValue);

                        }
                    }
                }

            }
        }


        public void CheckRunningLateTime(string selectedValue)
        {
            try
            {
                bool isRequireLateTime = DataController.checklatetime(selectedValue);
                if (isRequireLateTime)
                {
                    //  if (!BaseClass.IsNtesEnabled() && !BaseClass.IsLocalAutoMode())
                    if (checkLatetimeMesage)
                    {
                        MessageBox.Show("Please Enter Late Time");

                        int columnIndex = dgvOnlineTrains.Columns["dgvLateColumn"].Index;

                        dgvOnlineTrains.CurrentRow.Cells["dgvLateColumn"].Value = "";

                        this.BeginInvoke(new Action(() =>
                        {
                            if (dgvOnlineTrains.CurrentRow != null && columnIndex >= 0 && columnIndex < dgvOnlineTrains.ColumnCount)
                            {
                                dgvOnlineTrains.CurrentCell = dgvOnlineTrains.CurrentRow.Cells[columnIndex];
                            }
                        }));


                        dgvOnlineTrains.CurrentRow.Cells["dgvTrainStatusColumn"].Value = selectedValue;
                        checkLatetimeMesage = false;

                    }
                    // this.dgvOnlineTrains.CurrentCell = this.dgvOnlineTrains.CurrentRow.Cells["dgvLateColumn"];
                }
                else
                {
                    var currentCell = dgvOnlineTrains.CurrentCell;
                    string columnName = "";
                    if (currentCell != null)
                    {
                         columnName = dgvOnlineTrains.Columns[currentCell.ColumnIndex].Name;
                        
                    }
                    if (columnName != "dgvPFColumn")
                    {
                        //this.dgvOnlineTrains.CurrentRow.Cells["dgvLateColumn"].Value = "00:00";
                        //this.dgvOnlineTrains.CurrentRow.Cells["dgvEtaColumn"].Value = this.dgvOnlineTrains.CurrentRow.Cells["dgvStaColumn"].Value.ToString();
                        //this.dgvOnlineTrains.CurrentRow.Cells["dgvETDColumn"].Value = this.dgvOnlineTrains.CurrentRow.Cells["dgvSTDColumn"].Value.ToString();
                    }
                }

            }
            catch (Exception e)
            {
                Server.LogError("CheckRunningLateTime   " + e.ToString());
            }
        }

        public void CheckStationFormRequiredrNot(string selectedValue, ComboBox comboBox)
        {
            try
            {
                var currentCell = dgvOnlineTrains.CurrentCell;


                if (currentCell != null && currentCell.OwningColumn.Name == "dgvTrainStatusColumn")
                {


                    //this.dgvOnlineTrains.CurrentRow.Cells["dgvEtaColumn"].Value = this.dgvOnlineTrains.CurrentRow.Cells["dgvStaColumn"].Value;
                    //this.dgvOnlineTrains.CurrentRow.Cells["dgvETDColumn"].Value = this.dgvOnlineTrains.CurrentRow.Cells["dgvSTDColumn"].Value;

                    selectedValue = comboBox.SelectedItem.ToString();

                    bool isenablelate = DataController.LateEnabled(selectedValue);
                    this.dgvOnlineTrains.CurrentRow.Cells["dgvLateColumn"].ReadOnly = isenablelate;


                    string AD = dgvOnlineTrains.CurrentRow.Cells["dgvAdColumn"].Value?.ToString();
                    BaseClass.SchStatCode = BaseClass.getStatusCode(selectedValue, AD);
                    if (BaseClass.SchStatCode == 21 || BaseClass.SchStatCode == 8 || BaseClass.SchStatCode == 16 || BaseClass.SchStatCode == 19)
                    {
                        //terminated    terminated at  diverted  change of source
                        frmStations frmstations;
                        Form mainForm = Application.OpenForms["frmStations"];

                        if (mainForm != null)
                        {
                            frmstations = (frmStations)mainForm;
                            frmstations.Show();
                        }
                        else
                        {
                            frmstations = new frmStations();
                            frmstations.Show();
                        }
                        frmstations.BringToFront();


                    }
                    else
                    {
                        dgvOnlineTrains.CurrentRow.Cells["dgvCityColumn"].Value = "";
                        dgvOnlineTrains.CurrentRow.Cells["dgvRegCityName"].Value = "";
                        dgvOnlineTrains.CurrentRow.Cells["dgvHindiCityName"].Value = "";
                        SaveChangesInScheduleTrains(dgvOnlineTrains.CurrentRow);
                    }
                }
            }
            catch (Exception e)
            {
                Server.LogError("CheckStationFormRequiredrNot   " + e.ToString());
            }

        }

        public void CheckTrainStatusColumn(ComboBox comboBox, string selectedValue, String TrainNumber)
        {
            try
            {
                string Status = dgvOnlineTrains.CurrentRow.Cells["dgvTrainStatusColumn"].Value.ToString();

                if (Status != selectedValue)
                {
                    CheckRunningLateTime(selectedValue);
                }
                CheckStationFormRequiredrNot(selectedValue, comboBox);
                CheckplatformrequiredStatus(selectedValue, comboBox);
             
                if (Status != selectedValue)
                {
                    //dgvOnlineTrains.CurrentRow.Cells["dgvAnnColumn"].Value = false;
                    //dgvOnlineTrains.CurrentRow.Cells["dgvTdbColumn"].Value = false;
                    //dgvOnlineTrains.CurrentRow.Cells["dgvCdbColumn"].Value = false;
                    dgvOnlineTrains.CurrentRow.Cells["dgvCityColumn"].Value = "";
                }
            }
            catch (Exception e)
            {
                Server.LogError("CheckTrainStatusColumn:" + e.ToString());
            }
        }
        public void CheckplatformrequiredStatus(string selectedValue, ComboBox comboBox)
        {
            var currentCell = dgvOnlineTrains.CurrentCell;
            if (currentCell != null && currentCell.OwningColumn.Name == "dgvTrainStatusColumn")
            {
                // Verify if platformMessage is true before processing
                if (platformeMesage)
                {
                    var currentRow = dgvOnlineTrains.CurrentRow;
                    if (currentRow == null) return; // Safeguard against null row

                    // Get necessary values from the current row
                    string TrainStatus = currentRow.Cells["dgvTrainStatusColumn"].Value?.ToString();
                    string PF = currentRow.Cells["dgvPFColumn"].Value?.ToString().Trim();
                    string AD = currentRow.Cells["dgvAdColumn"].Value?.ToString();

                    // Get status code based on TrainStatus and AD
                    int statusCode = BaseClass.getStatusCode(selectedValue, AD);

                    // Check if the status code requires a platform check
                    if (statusCode == 2 || statusCode == 3 || statusCode == 4 || statusCode == 9 ||
                        statusCode == 12 || statusCode == 13 || statusCode == 14 || statusCode == 17 || statusCode == 18)
                    {
                        if (string.IsNullOrEmpty(PF) || PF == "--")
                        {
                            // Show warning if PF is not selected
                            MessageBox.Show("Please Select PF");

                            // Reset specific columns based on logic
                            //currentRow.Cells["dgvTdbColumn"].Value = statusCode == 2 ? false : currentRow.Cells["dgvTdbColumn"].Value;
                            //  currentRow.Cells["dgvAnnColumn"].Value = false;

                            // Set platformeMesage to false to prevent repeated prompts
                            platformeMesage = false;

                            // Refresh DataGridView to apply changes
                            // dgvOnlineTrains.RefreshEdit();
                        }
                    }
                }
            }
        }

        public static string DynamicPFUpdation(string TrainNo, string NewPFNo)
        {
            try
            {


                string trainNo = "", startDate = "", jStation = "", jStationSrNo = "", NTES_OLD_PF = "", NTES_NEW_PF = "";
                string WEBSERVICE_URL = "";
                var result = "";
                string resultstr = "";
                DateTime jStationSTA = DateTime.Now, jStationSTD = DateTime.Now;





                DataTable schdata = InterfaceDb.GetNtesWebServiceData();
                for (int i = 0; i < schdata.Rows.Count; i++)
                {
                    if (TrainNo == schdata.Rows[i]["trainno"].ToString())
                    {
                        trainNo = schdata.Rows[i]["trainno"].ToString();
                        startDate = schdata.Rows[i]["trainStartDate"].ToString();
                        jStation = schdata.Rows[i]["schStation"].ToString();
                        jStationSrNo = schdata.Rows[i]["StationSrno"].ToString();
                        jStationSTA = Convert.ToDateTime(schdata.Rows[i]["STA"].ToString());
                        jStationSTD = Convert.ToDateTime(schdata.Rows[i]["STD"].ToString());
                        NTES_OLD_PF = schdata.Rows[i]["platformNo"].ToString();
                        NTES_NEW_PF = NewPFNo;
                    }
                }


                WEBSERVICE_URL = "https://enquiry.indianrail.gov.in/ntessrvc/UpdatePFTesting";

                System.Net.ServicePointManager.Expect100Continue = false;
                var httpWebRequest = System.Net.HttpWebRequest.Create(WEBSERVICE_URL);//(HttpWebRequest).Create(WEBSERVICE_URL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("authToken", "51c47c2c3606791db113c89ddf52bc5b");
                //httpWebRequest.Headers.Add("HeaderValue: RF085DKA5215");
                using (var streamWriter = new

                StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        trainNo = trainNo,
                        startDate = startDate,
                        jStation = jStation,
                        jStationSrNo = jStationSrNo,
                        jStationSTA = jStationSTA,
                        jStationSTD = jStationSTD,
                        NTES_OLD_PF = NTES_OLD_PF,
                        NTES_NEW_PF = NTES_NEW_PF

                        //station = "NZM"
                        //Username = "myusername",
                        //Password = "password"
                    });

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string JsonString;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                    JsonString = result.ToString();

                    resultstr = JsonString.Replace(",", ",\n");
                }

                return resultstr;
            }
            catch (Exception ex)
            {

                Server.LogError(ex.Message);
                return null;
            }
        }



        private void ResetCellToDefault(int rowIndex, int columnIndex)
        {
            dgvOnlineTrains.Rows[rowIndex].Cells[columnIndex].Value = "00:00";
        }


        public static void ChangeCity(DataGridViewRow currentRow, List<DataGridViewRow> stationRows)
        {

            try
            {


                String engStationNames = "";
                String hinStationNames = "";
                String regStationNames = "";
                if (stationRows.Count > 0)
                {
                    foreach (DataGridViewRow row in stationRows)
                    {
                        if (row.Cells["dgvEnglishcolumn"].Value != null)
                        {
                            engStationNames += row.Cells["dgvEnglishcolumn"].Value.ToString() + ",";
                            hinStationNames += row.Cells["dgvHindiColumn"].Value.ToString() + ",";
                            regStationNames += row.Cells["dgvRegional"].Value.ToString() + ",";

                        }
                    }

                    // Optionally, remove the trailing comma
                    if (engStationNames.EndsWith(","))
                    {
                        engStationNames = engStationNames.TrimEnd(',');
                        hinStationNames = hinStationNames.TrimEnd(',');
                        regStationNames = regStationNames.TrimEnd(',');
                    }
                }
                if (currentRow != null)
                {

                    currentRow.Cells["dgvCityColumn"].Value = engStationNames;
                    currentRow.Cells["dgvHindiCityName"].Value = hinStationNames;
                    currentRow.Cells["dgvRegCityName"].Value = regStationNames;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnCdb_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" Do you want to Transfer Data to CGDB Boards?", "Send Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ChangeTdbColor(false);
                DataController.sendCgdbData();
            }
            else if (dialogResult == DialogResult.No)
            {
                // User clicked 'No', handle accordingly
            }

        }







        public static List<DataGridViewRow> checkedCgDbRows = new List<DataGridViewRow>();
        private bool CheckCheckedCgdbRows()
        {


            bool b = false;
            try
            {
                checkedCgDbRows.Clear();
                foreach (DataGridViewRow row in dgvOnlineTrains.Rows)
                {
                    if (row.Index != dgvOnlineTrains.Rows.Count - 1)
                    {
                        if (!row.IsNewRow)
                        {
                            if (Convert.ToBoolean(row.Cells["dgvCdbColumn"].EditedFormattedValue))
                            {
                                checkedCgDbRows.Add(row);
                            }
                        }
                    }
                }

                BaseClass.SelectedCGDBRows = checkedCgDbRows.Count;
                if (checkedCgDbRows.Count > 0)
                {
                    b = true;
                    foreach (var row in checkedCgDbRows)
                    {
                        if (row.Cells["dgvPFColumn"].Value == null || row.Cells["dgvPFColumn"].Value == "--")
                        {
                            b = false;
                        }
                    }
                    if (b)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please Select PlatForm");
                    }
                }

                BaseClass.CgdbRows = checkedCgDbRows;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return b;
        }

        private void txtCoach1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClearPlatform_Click(object sender, EventArgs e)
        {

            try
            {

                if (Server._connectedClients.Count > 0)
                {

                    string platformNo = cmbClearPlatform.Text.Trim();
                    string platform = BaseClass.ConvertPlatformToIp(platformNo);


                    if (platform != "--")
                    {
                        string pdcIp = "192.168." + platform + ".251";
                        int packetidentifier = Board.CGDB;
                        //  StopCommand(pdcIp, packetidentifier);
                        Deletecgdbdata(pdcIp);
                    }
                    else
                    {
                        MessageBox.Show("Please Choose PlatForm");
                    }


                }



            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            BaseClass.WritingThirdpartyTextfile();
        }

        private void cmbClearPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public static void StopCommand(string PdcIp, int packetidentifier)
        {
            try
            {


                string broadCastIp = Server.GetBroadcastIp(PdcIp);

                byte[] StopCommand = ByteFormation.StopCommand(broadCastIp, packetidentifier);
                Server.SendDataToPdc(PdcIp, StopCommand);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public void SetPlatforms()
        {
            try
            {

                foreach (string pf in BaseClass.Platforms)
                {

                    cmbClearPlatform.Items.Add(pf);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public void SetStations()
        {
            try
            {


                dgvUpStation.Text = BaseClass.UpStationCode;
                dgvDownStation.Text = BaseClass.DownStationCode;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        public void ChangeTdbColor(bool click)
        {
            if (btnTdb != null)
            {
                if (click)
                {
                    btnTdb.BackColor = Color.FromArgb(242, 213, 224);
                    btnTdb.ForeColor = Color.Maroon;
                }
                else
                {
                    btnTdb.BackColor = Color.FromArgb(242, 213, 224);
                    btnTdb.ForeColor = Color.Black;
                }
            }
            else
            {
                //MessageBox.Show("btnTdb is not initialized!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SaveChangesInScheduleTrains(DataGridViewRow changedRow)
        {
            ChangeTdbColor(true);
            try
            {


                if (changedRow != null)
                {
                    // Access the changed value
                    var trainStatus = changedRow.Cells["dgvTrainStatusColumn"].Value?.ToString();

                    // Perform your save logic here
                    // Example: save the trainStatus to the database
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (AnnouncementController.OtherAudioPlaying)
                {
                   MessageBox.Show("Other Audio is playing");
                }
                else
                {


                    DialogResult dResult = MessageBox.Show("Do you want to play the audio?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dResult == DialogResult.No)
                    {
                        return;
                    }
                    BaseClass.AnnouncementCount = (int)nudAnnouncement.Value;

                    AnnouncementController.playAnnounceMentData();
                    //BtnPause.Text = "Pause";
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }



        private static void HandleAudioErrors(string filePath)
        {
            MessageBox.Show($"Error with audio file '{filePath}'", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {


                DialogResult dResult = MessageBox.Show("Do you want to stop the play?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dResult == DialogResult.No)
                {
                    return;
                }
                AnnouncementController.OtherAudioPlaying = false;
                AnnouncementController.UpdateStatus("STOP");
                AnnouncementController.UpdateAudioPlayStatus("Completed");
                BtnPause.Text = "Pause";

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (AnnouncementController.OtherAudioPlaying)
            {
                try
                {


                    AnnouncementController.UpdateStatus("PAUSE");
                    AnnouncementController.CheckPauseButtonClick();
                    PauseButtonCheck();
                }
                catch (Exception ex)
                {
                    Server.LogError(ex.Message);
                }
            }
        }
        private void PauseButtonCheck()
        {

            try
            {


                if (AnnouncementController.PauseButtonStatus)
                {
                    BtnPause.Text = "Resume";


                }
                else
                {

                    BtnPause.Text = "Pause";

                }
            }

            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }

        public static DataTable MergeAndRemoveDuplicates(DataTable table1, DataTable table2)
        {
            try
            {


                if (table1.Rows.Count > 0 || table2.Rows.Count > 0)
                {


                    // Clone the structure of the first DataTable
                    DataTable mergedTable = table1.Clone();

                    // Import rows from the first table
                    foreach (DataRow row in table1.Rows)
                    {
                        mergedTable.ImportRow(row);
                    }

                    // Import rows from the second table
                    foreach (DataRow row in table2.Rows)
                    {
                        mergedTable.ImportRow(row);
                    }

                    // Remove duplicate rows based on all columns
                    var distinctRows = mergedTable.AsEnumerable()
                        .Distinct(DataRowComparer.Default)
                        .CopyToDataTable();

                    return distinctRows;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }

        public static DataTable FilterTimeArrivalRange(DataTable dataTable, string fromTime, string toTime)
        {
            try
            {


                // Parse the from and to times
                TimeSpan fromTimeSpan = TimeSpan.Parse(fromTime);
                TimeSpan toTimeSpan = TimeSpan.Parse(toTime);

                // Clone the structure of the original DataTable
                DataTable filteredTable = dataTable.Clone();

                // Filter the rows based on the time range
                var filteredRows = dataTable.AsEnumerable()
                    .Where(row =>
                    {
                        TimeSpan rowTime = TimeSpan.Parse(row["ArrivalTime"].ToString());
                        return (fromTimeSpan <= rowTime) && (rowTime <= toTimeSpan);
                    });

                // Import the filtered rows into the new DataTable
                foreach (var row in filteredRows)
                {
                    filteredTable.ImportRow(row);
                }

                return filteredTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }
        public static DataTable FilterTimeDepartureRange(DataTable dataTable, string fromTime, string toTime)
        {
            try
            {


                if (BaseClass.IsLocalAutoDeletion())
                {
                    string deletionTime = BaseClass.LocalAutoDeletionTimeInterval;

                    // Parse the fromTime and deletionTime strings to TimeSpan objects
                    TimeSpan fromSpan = TimeSpan.Parse(fromTime);
                    TimeSpan deletionTimeSpan = TimeSpan.FromMinutes(double.Parse(deletionTime));

                    // Subtract deletionTimeSpan from fromTimeSpan
                    fromSpan = fromSpan - deletionTimeSpan;

                    // Convert the modified TimeSpan back to string
                    fromTime = fromSpan.ToString();
                }

                // Parse the from and to times
                TimeSpan fromTimeSpan = TimeSpan.Parse(fromTime);
                TimeSpan toTimeSpan = TimeSpan.Parse(toTime);

                // Clone the structure of the original DataTable
                DataTable filteredTable = dataTable.Clone();

                // Filter the rows based on the time range
                var filteredRows = dataTable.AsEnumerable()
                    .Where(row =>
                    {
                        TimeSpan rowTime = TimeSpan.Parse(row["DepartureTime"].ToString());
                        return (fromTimeSpan <= rowTime) && (rowTime <= toTimeSpan);
                    });

                // Import the filtered rows into the new DataTable
                foreach (var row in filteredRows)
                {
                    filteredTable.ImportRow(row);
                }

                return filteredTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }

        //public void WebRequest()
        //{
        //    bool internet = true;

        //    try
        //    {
        //        // Retrieve NTES configuration from the database
        //        DataTable dsNtesConfig = InterfaceDb.GetNtesConfiguration();
        //        if (dsNtesConfig == null || dsNtesConfig.Rows.Count == 0)
        //        {
        //            MessageBox.Show("NTES configuration not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        DataRow row = dsNtesConfig.Rows[0];
        //        string stationCode = row.Field<string>("StationCode");
        //        string nextMins = row.Field<int>("NextMins").ToString();
        //        string urlType = row.Field<string>("UrlType");
        //        bool audio = row.Field<bool>("Audio");
        //        bool autoMode = row.Field<bool>("AutoMode");
        //        string ntesurl = row.Field<string>("NtesUrl").ToString();
        //        string AuthenticationToken = row.Field<string>("AuthenticationToken").ToString();


        //        string WEBSERVICE_URL = ""; //"https://enquiry.indianrail.gov.in/ntessrvc/TrainService?action=LiveStation ";
        //        if (urlType == "Internet")
        //        {
        //            // WEBSERVICE_URL = "https://enquiry.indianrail.gov.in/ntessrvc/TrainService?action=LiveStation ";
        //            WEBSERVICE_URL = ntesurl;
        //        }
        //        else
        //        {
        //            WEBSERVICE_URL = ntesurl;
        //            // WEBSERVICE_URL = "http://10.64.26.75/ntessrvc/TrainService?action=LiveStation";
        //        }

        //        // Prepare the web request
        //        System.Net.ServicePointManager.Expect100Continue = false;

        //        var httpWebRequest = System.Net.HttpWebRequest.Create(WEBSERVICE_URL);
        //        httpWebRequest.ContentType = "application/json";
        //        httpWebRequest.Method = "POST";
        //        // httpWebRequest.Headers.Add("authToken", "RF085DKA5215");
        //        httpWebRequest.Headers.Add("authToken", AuthenticationToken);

        //        // Create JSON payload
        //        string jsonPayload = new JavaScriptSerializer().Serialize(new
        //        {
        //            station = stationCode,
        //            nextMins = nextMins
        //        });

        //        // Send the request
        //        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //        {
        //            streamWriter.Write(jsonPayload);
        //        }

        //        // Get the response
        //        using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
        //        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //        {
        //            string jsonResponse = streamReader.ReadToEnd();

        //            // Convert JSON response to DataTable
        //            DataTable dt = JsonStringToDataTable(jsonResponse);
        //            InterfaceDb.SaveNtesDataNew(jsonResponse, false);

        //            DataTable existedtrains = InterfaceDb.ClearNtesWebServiceTable();//clearing ntes webservice and scheduled tadb where ntes check not true


        //            DeleteTrains(existedtrains);


        //            ProcessTrainData(dt);


        //            InsertintoTraindetailstableSchuduledTadb();
        //        }
        //    }
        //    catch (WebException webEx)
        //    {
        //        internet = false;

        //        // Handle web exceptions (like 404, 500)
        //        //MessageBox.Show($"Web error: Please Connect Internet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception ex)
        //    {
        //        Server.LogError(ex.Message);
        //    }
        //    BaseClass.displayInternetStaus(internet);


        //}


        public async Task WebRequestAsync()
        {
            bool internet = true;
            int timeoutSeconds = 20;

            try
            {
                // Retrieve NTES configuration from the database
                DataTable dsNtesConfig = InterfaceDb.GetNtesConfiguration();
                if (dsNtesConfig == null || dsNtesConfig.Rows.Count == 0)
                {
                    MessageBox.Show("NTES configuration not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = dsNtesConfig.Rows[0];
                string stationCode = row.Field<string>("StationCode");
                string nextMins = row.Field<int>("NextMins").ToString();
                string urlType = row.Field<string>("UrlType");
                bool audio = row.Field<bool>("Audio");
                bool autoMode = row.Field<bool>("AutoMode");
                string ntesurl = row.Field<string>("NtesUrl").ToString();
                string authenticationToken = row.Field<string>("AuthenticationToken").ToString();

                string webServiceUrl = ntesurl;

                using (var client = new HttpClient())
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeoutSeconds)))
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("authToken", authenticationToken);

                    var payload = new
                    {
                        station = stationCode,
                        nextMins = nextMins
                    };

                    var jsonPayload = new StringContent(
                        new JavaScriptSerializer().Serialize(payload),
                        Encoding.UTF8,
                        "application/json"
                    );

                    HttpResponseMessage response = await client.PostAsync(webServiceUrl, jsonPayload, cts.Token).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();

                    // Read stream manually to avoid charset errors
                    string jsonResponse = "";
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var reader = new StreamReader(responseStream, Encoding.UTF8, true))
                    {
                        jsonResponse = await reader.ReadToEndAsync().ConfigureAwait(false);
                    }

                    // Process JSON result
                    DataTable dt = JsonStringToDataTable(jsonResponse);
                    InterfaceDb.SaveNtesDataNew(jsonResponse, false);

                    DataTable existedTrains = InterfaceDb.ClearNtesWebServiceTable();
                    DeleteTrains(existedTrains);
                    ProcessTrainData(dt);
                    InsertintoTraindetailstableSchuduledTadb();

                    Form mainForm = Application.OpenForms["frmOnlineTrains"];

                    if (mainForm != null)
                    {
                        frmOnlineTrains frmonline = (frmOnlineTrains)mainForm;

                        if (frmonline.InvokeRequired)
                        {
                            frmonline.Invoke((MethodInvoker)(() => frmonline.fillRunningTrains()));
                        }
                        else
                        {
                            frmonline.fillRunningTrains();
                        }
                    }





                }
            }
            catch (TaskCanceledException)
            {
                internet = false;
              //  MessageBox.Show("InterNet Speed Very slow");
               // MessageBox.Show($"The request timed out after {timeoutSeconds} seconds.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (HttpRequestException httpEx)
            {
                internet = false;
                //MessageBox.Show($"Internet Error: {httpEx.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            BaseClass.displayInternetStaus(internet);
        }










        public static void DeleteTrains(DataTable dt)
        {
            try
            {


                foreach (DataRow row in dt.Rows)
                {
                    string trainNo = row["TrainNo"].ToString();
                    if (BaseClass.trainNumbers.Contains(trainNo))
                    {
                        OnlineTrainsDao.DeleteTrainFromRunningTrains(trainNo);
                    }
                    else
                    {
                        OnlineTrainsDao.DeleteTrainFromRunningTrainsNtes(trainNo);
                    }


                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        public void ProcessTrainData(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {

                    string trainStatus = dt.Rows[i]["trainStatus"].ToString();
                    string englishTrainName = dt.Rows[i]["trainName"].ToString();
                    string hindiTrainName = CleanHindiTrainName(dt.Rows[i]["trainNameHindi"].ToString());

                    string totalEngName = Regex.Replace(englishTrainName, @"[^0-9a-zA-Z:,]+", " ");
                    string schArrStr = GetFormattedTime(dt.Rows[i]["STA"]);
                    string schDepStr = GetFormattedTime(dt.Rows[i]["STD"]);
                    string expArrStr = GetFormattedTime(dt.Rows[i]["ETA"]);
                    string expDepStr = GetFormattedTime(dt.Rows[i]["ETD"]);
                   string AdFlag= dt.Rows[i]["ADFlag"].ToString().Trim();

                  

                    if (trainStatus == "Cancelled")
                    {
                        bool isArrivedFlag = false;
                        string lateTime = "";
                        string pfNo ="";
                        expArrStr = expDepStr = DateTime.Today.ToString("HH:mm");
                        InsertWebserviceNtesData(dt.Rows[i], totalEngName, hindiTrainName, schArrStr, schDepStr, expArrStr, expDepStr, isArrivedFlag, lateTime, true, false,  AdFlag,trainStatus, pfNo);
                    }
                    else
                    {
                        bool isArrivedFlag = dt.Rows[i]["isArrived"].ToString() == "1";
                        string lateTime = GetLateTime(dt.Rows[i]["delayArr"]);
                        var trainStatus_AD = DetermineTrainStatus(dt.Rows[i], trainStatus);
                            trainStatus= trainStatus_AD.status;
                            AdFlag = trainStatus_AD.AdFlag;
                        string pfNo = GetPlatformNumber(dt.Rows[i]["platformNo"]);

                        InsertWebserviceNtesData(dt.Rows[i], totalEngName, hindiTrainName, schArrStr, schDepStr, expArrStr, expDepStr, isArrivedFlag, lateTime, true, true, AdFlag, trainStatus, pfNo);
                    }
                }
                catch (Exception ex)
                {
                    Server.LogError(ex.Message);
                }
            }
        }

        //private string DetermineTrainStatus(DataRow row, string trainStatus)
        //{
        //    try
        //    {


        //        if (!string.IsNullOrEmpty(trainStatus)) return trainStatus;

        //        string adFlag = row["ADFlag"].ToString();
        //        string delayArr = row["delayArr"].ToString();
        //        string delayDep = row["delayDep"].ToString();

        //        if (adFlag == "A" && delayArr == "00:00" && delayDep == "00:00")
        //            return "Has Arrived On";
        //        if (adFlag == "D" && delayArr == "00:00" && delayDep == "00:00")
        //            return "Delay Departure";
        //        if (adFlag == "A" && delayArr != "00:00" && delayDep != "00:00")
        //            return "Running Late";
        //        if (adFlag == "D" && delayArr != "00:00" && delayDep != "00:00")
        //            return "Regulated";

        //        return adFlag == "A" ? "Has Arrived On" : "Delay Departure";
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //    return null;
        //}

        static int CompareTimeDifference(string hhmm1, string hhmm2)
        {
            try
            {
                // Updated format string to match hh:mm
                TimeSpan t1 = TimeSpan.ParseExact(hhmm1, "hh\\:mm", CultureInfo.InvariantCulture);
                TimeSpan t2 = TimeSpan.ParseExact(hhmm2, "hh\\:mm", CultureInfo.InvariantCulture);

                if (t1 > t2)
                    return 1;
                else if (t1 < t2)
                    return -1;
                else
                    return 0;
            }
            catch (Exception e)
            {
                Server.LogError("CompareTimeDifference Error: " + e.ToString());
                return 0;
            }
        }

        private (string status,string AdFlag) DetermineTrainStatus(DataRow row, string trainStatus)
          {
            string adFlag = "A";
            try
            {
               adFlag = row["ADFlag"].ToString().Trim();
                if (!string.IsNullOrEmpty(trainStatus)) 
                    return (trainStatus, adFlag);

                string ETA = "";
                string ETD = "";
               
                string delayArr = row["delayArr"].ToString();
                string delayDep = row["delayDep"].ToString();
                string CurrentTime = DateTime.Now.ToString("HH:mm", CultureInfo.InvariantCulture);
                string TrainNumber = row["trainNo"].ToString().Trim();

                DataTable TrainsDt = OnlineTrainsDao.GetTrainByNumber(TrainNumber);
                if (TrainsDt != null && TrainsDt.Rows.Count > 0)
                {
                    ETA = TrainsDt.Rows[0].Field<string>("ArrivalTime").ToString().Trim();
                    ETD = TrainsDt.Rows[0].Field<string>("DepartureTime").ToString().Trim();
                }
                else
                {
                    ETA = row["ETA_HHMM"].ToString().Trim();
                    ETD = row["ETD_HHMM"].ToString().Trim();
                    if (!TimeSpan.TryParseExact(ETA, "hh\\:mm", CultureInfo.InvariantCulture, out TimeSpan etaTime))
                    {
                        ETA = "00:00";
                    }
                    
                    if (!TimeSpan.TryParseExact(ETD, "hh\\:mm", CultureInfo.InvariantCulture, out TimeSpan etdTime))
                    {
                        ETD = "00:00";
                    }

                    if(ETA=="00:00"&&ETD=="00:00")
                    {
                        Server.LogError("Ntest ETA And ETD are ZEro");
                    }
                }

                if (ETA.Trim()==""||ETA.Trim()=="00:00")
                {
                    adFlag = "D";
                    return ("Running Right Time",adFlag);
                }
                if(delayArr.Trim() == "00:00" && delayDep.Trim() == "00:00")
                {
                   
                        int result = CompareTimeDifference(CurrentTime, ETA);
                        adFlag = "A";
                        if (result == -1)
                        {
                        return ("Running Right Time", adFlag);
                        }
                        else if (result == 0)
                        {
                            return ("Running Right Time", adFlag);
                        }
                        else if (result == 1)
                        {
                        return ("Running Right Time", "D");
                       
                        }
                    
                    
                }
                else if(delayArr.Trim()!="00:00")
                {
                        adFlag = "A";
                           ETA = AddTwoTimes(ETA, delayArr);
                        int result = CompareTimeDifference(CurrentTime, ETA);
                        if (result == -1)
                        {
                            return ("Running Late", adFlag);
                        }
                        else if (result == 0)
                        {
                            return ("Running Right Time",adFlag);
                        }
                        else if (result == 1)
                        {
                        return ("Running Right Time", "D");
                        }
                }
                else if(delayDep!="00:00")
                {
                    
                        ETD = AddTwoTimes(ETD, delayDep);
                        adFlag = "D";
                        int result = CompareTimeDifference(CurrentTime, ETD);
                        if (result == -1)
                        {
                            return ("Delay Departure",adFlag);
                        }
                        else if (result == 0)
                        {
                            return ("Is Ready To Leave",adFlag);
                        }
                        else if (result == 1)
                        {
                            return  ("Departed",adFlag);
                        }
                }
                else if ((adFlag == "D" || adFlag == "A") && (delayArr != "00:00" || delayDep != "00:00"))
                {
                    if (adFlag == "D")
                        return ("Delay Departure","D");
                    else
                        return ("Running Late","A");
                }

                return ("Running Right Time",adFlag);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(trainStatus))
                    return (trainStatus, adFlag);
                return ("Running Right Time", adFlag);
                ex.ToString();
            }        
        }
        private void InsertWebserviceNtesData(DataRow row, string totalEngName, string hindiTrainName, string schArrStr, string schDepStr, string expArrStr, string expDepStr, bool isArrivedFlag, string lateTime, bool confirmedToBoards, bool confirmedToCoaches, string AdFlag, string trainStatus, string pfNo)
        {

            try
            {


                int rowsAffected = InterfaceDb.InsertWebserviceNtesData(
                    row["trainNo"].ToString(),
                    totalEngName,
                    hindiTrainName,
                    row["trainType"].ToString(),
                    row["trainTypeName"].ToString(),
                    row["trainTypeNameHindi"].ToString(),
                    row["trainStartDate"].ToString(),
                    row["src"].ToString(),
                    row["srcName"].ToString(),
                    row["srcNameHindi"].ToString(),
                    row["dstn"].ToString(),
                    row["dstnName"].ToString(),
                    row["dstnNameHindi"].ToString(),
                    schArrStr,
                    expArrStr,
                    isArrivedFlag,
                    lateTime,
                    schDepStr,
                    expDepStr,
                    lateTime,
                    AdFlag,
                    row["expectedTime"].ToString(),
                    row["expectedDelay"].ToString(),
                    trainStatus,
                    pfNo,
                    row["coachPosition"].ToString(),
                    row["coachClass"].ToString(),
                    row["schStation"].ToString(),
                    row["schStationDate"].ToString(),
                    row["schStationEvent"].ToString(),
                    "",
                    confirmedToBoards,
                    confirmedToCoaches,
                    "",
                    ""
                );

                ReportDb.InsertNtesDataReport(row["trainNo"].ToString(), totalEngName, schArrStr, expArrStr, lateTime, schDepStr, expDepStr, lateTime, trainStatus, row["coachPosition"].ToString(), pfNo, row["ADFlag"].ToString());
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private string CleanHindiTrainName(string hindiTrainName)
        {
            return hindiTrainName.Replace("_", " ").Replace("-", " ");
        }

        private string GetFormattedTime(object timeValue)
        {
            return string.IsNullOrEmpty(timeValue.ToString()) ? DateTime.Today.ToString("HH:mm") : Convert.ToDateTime(timeValue).ToString("HH:mm");
        }

        private string GetLateTime(object delayArr)
        {
            return string.IsNullOrEmpty(delayArr.ToString()) ? "00:00" : delayArr.ToString();
        }

        private string GetPlatformNumber(object platformNo)
        {
            return platformNo.ToString();
        }


        public DataTable JsonStringToDataTable(string jsonString)
        {
            try
            {


                InterfaceDb.SaveNtesDataNew(jsonString, false);
                DataTable dt = new DataTable();
                DataTable dt_copy = new DataTable();
                string str = jsonString.Replace("{\"vTrainList\":[", "").Replace("],\"vCancelledTrainList\":[", "").Replace("],\"vRescheduledTrainList\":[", "");
                string[] jsonStringArray = Regex.Split(str.Replace("[", "").Replace("]", "").Replace("}{", "},{"), "},{");
                List<string> ColumnsName = new List<string>();
                foreach (string jSA in jsonStringArray)
                {
                    string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                    foreach (string ColumnsNameData in jsonStringData)
                    {
                        try
                        {

                            int idx = ColumnsNameData.IndexOf(":");
                            if (idx != -1)
                            {
                                string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                                if (!ColumnsName.Contains(ColumnsNameString))
                                {
                                    ColumnsName.Add(ColumnsNameString);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                        }
                    }
                    break;
                }
                foreach (string AddColumnName in ColumnsName)
                {
                    dt.Columns.Add(AddColumnName);
                }
                foreach (string jSA in jsonStringArray)
                {
                    string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                    DataRow nr = dt.NewRow();
                    foreach (string rowData in RowData)
                    {
                        try
                        {
                            int idx = rowData.IndexOf(":");
                            if (idx!= - 1)
                            {
                                string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");

                                //  str11 = str11 + "," + RowColumns;
                                string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                                if (RowColumns == "trainNameHindi" || RowColumns == "srcNameHindi" || RowColumns == "dstnNameHindi" || RowColumns == "trainTypeNameHindi")
                                {
                                    string RowDataStr = rowData.Substring(idx + 1).Replace("\\", "").Replace("\"", "");
                                    str = RowDataStr.Replace("u0026", "&");
                                    var Hindistr = System.Net.WebUtility.HtmlDecode(str);
                                    nr[RowColumns] = Hindistr;
                                }
                                else
                                {
                                    if (RowColumns!= "vCancelTrainDueToCS"&& RowColumns != "vCancelTrainDueToCD" && RowColumns != "vCancelTrainDueToDiversion" 
                                        && RowColumns != "vTrainListDueToCS"&& RowColumns != "vTrainListDueToCD" && RowColumns != "vTrainListDueToCD"
                                        && RowColumns != "vTrainListDueToDV" && RowColumns != "restServiceMessage"&&RowColumns != "serviceDataFoundFlag" 
                                        && RowColumns != "serviceDataFoundFlag" && RowColumns != "serviceDataResultFlag" && RowColumns != "serviceInputValidFlag"
                                         && RowColumns != "serviceMessage" && RowColumns != "cacheUpdateTime" && RowColumns != "MM" && RowColumns != "YYYY"
                                         && RowColumns != "serviceMessage" && RowColumns != "HH" && RowColumns != "MI" && RowColumns != "SECONDS" && RowColumns != "format"
                                          && RowColumns != "calendar" && RowColumns != "month" && RowColumns != "dayOfMonth" && RowColumns != "hourOfDay" 
                                          && RowColumns != "minute" && RowColumns != "second"&& RowColumns != "cacheDataFlag" 
                                        )
                                    {
                                        nr[RowColumns] = RowDataString;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // continue;
                        }
                    }
                    dt.Rows.Add(nr);

                }
                //DeletePrevData();
                //DeletePrevCoachData();
                //InsertData(dt);

                return dt;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }
        public static (bool exists, int pkey, string localEnglishName, string trainNameHindi, string trainNameRegional) GetTrainDetails(DataTable dataTable, string trainNo)
        {

            // Default values to return in case no match is found
            int pkey = -1;
            string localEnglishName = string.Empty;
            string trainNameHindi = string.Empty;
            string trainNameRegional = string.Empty;
            bool exists = false;
            try
            {


                // Check if the DataTable has any rows
                if (dataTable.Rows.Count > 0)
                {
                    // Iterate through each row in the DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Check if the current row matches the trainNo
                        if (row["TrainNumber"].ToString() == trainNo)
                        {
                            // Retrieve values from the matched row
                            pkey = Convert.ToInt32(row["Pkey_TrainNumber"]); // Use correct column name for primary key

                            localEnglishName = row["EnglishName"].ToString();
                            trainNameHindi = row["HindiName"].ToString(); // Use correct column name
                            trainNameRegional = row["RegionalName"].ToString(); // Use correct column name

                            // Set exists to true and break the loop once the match is found
                            exists = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            // Return the result as a tuple
            return (exists, pkey, localEnglishName, trainNameHindi, trainNameRegional);
        }

        public DataTable CreateTrainDetailsTable()
        {
            try
            {


                // Create a new DataTable instance
                DataTable trainDetailsTable = new DataTable("TrainDetails");

                // Add columns to the DataTable
                trainDetailsTable.Columns.Add("Pkey_TrainNumber", typeof(int));
                trainDetailsTable.Columns.Add("TrainNumber", typeof(string));
                trainDetailsTable.Columns.Add("TrainType", typeof(string));

                trainDetailsTable.Columns.Add("EnglishName", typeof(string));
                trainDetailsTable.Columns.Add("HindiName", typeof(string));
                trainDetailsTable.Columns.Add("RegionalName", typeof(string));
                trainDetailsTable.Columns.Add("ArrivalTime", typeof(string));
                trainDetailsTable.Columns.Add("DepartureTime", typeof(string));
                trainDetailsTable.Columns.Add("Platform", typeof(string));
                trainDetailsTable.Columns.Add("Status", typeof(string));
                trainDetailsTable.Columns.Add("ADStatus", typeof(string));
                trainDetailsTable.Columns.Add("LateBy", typeof(string));
                trainDetailsTable.Columns.Add("LArrivalTime", typeof(string));
                trainDetailsTable.Columns.Add("LDepartureTime", typeof(string));
                trainDetailsTable.Columns.Add("city", typeof(string));
                trainDetailsTable.Columns.Add("Coaches", typeof(string));

                // Return the empty DataTable with the defined columns
                return trainDetailsTable;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }
        private void InsertSchuduledTadb()
        {

            try
            {


                // Retrieve the data from the database
                DataTable NtesDataServiceData = InterfaceDb.GetNtesWebServiceData();
                DataTable LocalData = InterfaceDb.GetAllTrains();
                DataTable trainDetails = CreateTrainDetailsTable();
                // Check if the DataTable has any rows
                if (NtesDataServiceData.Rows.Count > 0)
                {

                    // Iterate through each row in the DataTable
                    foreach (DataRow row in NtesDataServiceData.Rows)
                    {



                        // Access each column value using column names
                        int pkey = Convert.ToInt32(row["pkey"]);
                        string trainNo = row["trainno"].ToString();

                        string trainName;
                        string trainNameHindi;
                        string city;

                        (bool Hastrain, int Fkey_trainNumber, string localEnglishName, string LocalHindiName, string LocalRegionalName) = GetTrainDetails(LocalData, trainNo);
                        if (Hastrain)
                        {
                            trainName = localEnglishName;
                            trainNameHindi = LocalHindiName;
                        }
                        else
                        {
                            trainName = row["trainname"].ToString();
                            trainNameHindi = row["trainNameHindi"].ToString();
                        }




                        string trainType = row["trainType"].ToString();
                        string trainTypeName = row["trainTypeName"].ToString();
                        string trainTypeNameHindi = row["trainTypeNameHindi"].ToString();
                        DateTime trainStartDate = Convert.ToDateTime(row["trainStartDate"]);
                        string src = row["src"].ToString();
                        string srcName = row["srcName"].ToString();
                        string srcNameHindi = row["srcNameHindi"].ToString();
                        string dstn = row["dstn"].ToString();
                        string dstnName = row["dstnName"].ToString();
                        string dstnNameHindi = row["dstnNameHindi"].ToString();
                        string sta = row["STA"].ToString();
                        string eta = row["ETA"].ToString();
                        bool isArrived = Convert.ToBoolean(row["isArrived"]);
                        string delayArr = row["delayArr"].ToString();
                        string std = row["STD"].ToString();
                        string etd = row["ETD"].ToString();
                        string delayDep = row["delayDep"].ToString();
                        string adFlag = row["ADFlag"].ToString();
                        TimeSpan expectedTime = TimeSpan.Parse(row["expectedTime"].ToString());
                        string expectedDelay = row["expectedDelay"].ToString();
                        string trainStatus = row["trainStatus"].ToString();



                        string platformNo = row["platformNo"].ToString();
                        string coaches = row["coachPosition"].ToString();
                        string coachPosition = coaches.Replace("-", ",");


                        string coachClass = row["coachClass"].ToString();

                        string schStation = row["schStation"].ToString();
                        DateTime schStationDate = Convert.ToDateTime(row["schStationDate"]);
                        string schStationEvent = row["schStationEvent"].ToString();
                        string terminatedPlace = row["TerminatedPlace"].ToString();
                        string confirmedToBoards = row["ConfirmedToBoards"].ToString();
                        string confirmedToCoaches = row["ConfirmedToCoaches"].ToString();
                        string divertedRoute = row["DivertedRoute"].ToString();


                        bool tadb, cgdb, ann, ntes;

                        tadb = true;
                        cgdb = row.Field<bool>("cgdb");
                        ann = row.Field<bool>("ann");
                        ntes = false;

                        tadb = false;
                        cgdb = false;
                        ann = false;
                        ntes = false;


                        //int stationSrno = Convert.ToInt32(row["StationSrno"]);

                        (string Tstatus, string ADStatus) = Gettrainstatus(trainStatus);


                        city = Getcity(Tstatus, terminatedPlace, divertedRoute);





                        // InterfaceDb.InsertSchduleData(Fkey_trainNumber, trainNo, trainName, sta, std, ADStatus, Tstatus, delayArr, eta, etd, platformNo, terminatedPlace, trainNameHindi, LocalRegionalName, coachPosition);

                        // Process each value as needed
                        // For example, you might want to display them in a message box or add them to a list
                        //MessageBox.Show($"Train No: {trainNo}, Train Name: {trainName}, Station Serial No: {stationSrno}");
                    }
                }
                else
                {
                    Server.LogError("No Trains Availble.");
                    // MessageBox.Show("No data found.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public static List<string> GetTrainNumbers(DataTable TempTrains)
        {
            // Create a new list to store the train numbers
            List<string> trainNumbers = new List<string>();

            // Iterate through each row in the DataTable
            foreach (DataRow row in TempTrains.Rows)
            {
                // Add the value of the "TrainNumber" column to the list
                trainNumbers.Add(row["TrainNumber"].ToString().Trim());
            }

            // Return the list of train numbers
            return trainNumbers;
        }


        public void SaveNewTrainInfo(string Trnum, string EngName, string HinName, string LocalName)
        {
            var train = new TrainInfo
            {
                TrainNumber = Trnum,
                TrainNameEN = EngName,
                TrainNameHI = HinName,
                TrainNameL = LocalName
               
            };
            BaseClass.InsertOrUpdateTrainData(train);
        }

        private void InsertintoTraindetailstableSchuduledTadb()
        {
            try
            {


                // Retrieve the data from the database
                DataTable NtesDataServiceData = InterfaceDb.GetNtesWebServiceData();
                DataTable LocalData = InterfaceDb.GetAllTrains();
                DataTable trainDetails = CreateTrainDetailsTable();

                // Check if the DataTable has any rows
                if (NtesDataServiceData.Rows.Count > 0)
                {

                    // Iterate through each row in the DataTable
                    foreach (DataRow row in NtesDataServiceData.Rows)
                    {



                        // Access each column value using column names
                        int pkey = Convert.ToInt32(row["pkey"]);
                        string trainNo = row["trainno"].ToString();



                        string trainNameHindi;
                        string trainName;
                        string city;

                        (bool Hastrain, int Fkey_trainNumber, string localEnglishName, string LocalHindiName, string LocalRegionalName) = GetTrainDetails(LocalData, trainNo);
                        if (Hastrain)
                        {
                            trainName = localEnglishName;
                            trainNameHindi = LocalHindiName;
                        }
                        else
                        {


                            trainName = row["trainname"].ToString();
                            trainNameHindi = row["trainNameHindi"].ToString();


                            SaveNewTrainInfo(trainNo, trainName, trainNameHindi,"");
                        }




                        string trainType = row["trainType"].ToString();
                        string trainTypeName = row["trainTypeName"].ToString();
                        string trainTypeNameHindi = row["trainTypeNameHindi"].ToString();
                        DateTime trainStartDate = Convert.ToDateTime(row["trainStartDate"]);
                        string src = row["src"].ToString();
                        string srcName = row["srcName"].ToString();
                        string srcNameHindi = row["srcNameHindi"].ToString();
                        string dstn = row["dstn"].ToString();
                        string dstnName = row["dstnName"].ToString();
                        string dstnNameHindi = row["dstnNameHindi"].ToString();
                        string sta = row["STA"].ToString();
                        string eta = row["ETA"].ToString();
                        bool isArrived = Convert.ToBoolean(row["isArrived"]);
                        string delayArr = row["delayArr"].ToString();

                        if (delayArr == "")
                        {
                            delayArr = "00:00";
                        }



                        string std = row["STD"].ToString();
                        string etd = row["ETD"].ToString();
                        string delayDep = row["delayDep"].ToString();
                        string adFlag = row["ADFlag"].ToString();
                        // TimeSpan expectedTime = TimeSpan.Parse(row["expectedTime"].ToString());
                        string expectedDelay = row["expectedDelay"].ToString();
                        string trainStatus = row["trainStatus"].ToString();



                        string platformNo = row["platformNo"].ToString();
                        string coaches = row["coachPosition"].ToString();
                        string coachPosition = coaches.Replace("-", ",");


                        string coachClass = row["coachClass"].ToString();

                        string schStation = row["schStation"].ToString();
                        //DateTime schStationDate = Convert.ToDateTime(row["schStationDate"]);
                        string schStationEvent = row["schStationEvent"].ToString();
                        string terminatedPlace = row["TerminatedPlace"].ToString();
                        string confirmedToBoards = row["ConfirmedToBoards"].ToString();
                        string confirmedToCoaches = row["ConfirmedToCoaches"].ToString();
                        string divertedRoute = row["DivertedRoute"].ToString();




                        //int stationSrno = Convert.ToInt32(row["StationSrno"]);

                        (string Tstatus, string ADStatus) = Gettrainstatus(trainStatus);


                        city = Getcity(Tstatus, terminatedPlace, divertedRoute);

                        DataRow newRow = trainDetails.NewRow();

                        // Populate the DataRow with values
                        newRow["Pkey_TrainNumber"] = Fkey_trainNumber;
                        newRow["TrainNumber"] = trainNo;
                        newRow["TrainType"] = trainType;


                        newRow["EnglishName"] = trainName;
                        newRow["HindiName"] = trainNameHindi;
                        newRow["RegionalName"] = LocalRegionalName;
                        newRow["ArrivalTime"] = sta;
                        newRow["DepartureTime"] = std;
                        newRow["Platform"] = platformNo;
                        newRow["Status"] = Tstatus;
                        newRow["ADStatus"] = ADStatus;
                        newRow["LateBy"] = delayArr;
                        newRow["LArrivalTime"] = eta;
                        newRow["LDepartureTime"] = etd;
                        newRow["city"] = city;
                        newRow["Coaches"] = coachPosition;


                        // Add the DataRow to the DataTable
                        trainDetails.Rows.Add(newRow);



                        // InterfaceDb.InsertSchduleData(Fkey_trainNumber, trainNo, trainName, sta, std, ADStatus, Tstatus, delayArr, eta, etd, platformNo, terminatedPlace, trainNameHindi, LocalRegionalName, coachPosition);

                        // Process each value as needed
                        // For example, you might want to display them in a message box or add them to a list
                        //MessageBox.Show($"Train No: {trainNo}, Train Name: {trainName}, Station Serial No: {stationSrno}");

                    }



                    DataTable Latesttrains = SortTrainsByArrival(trainDetails);

                    DataTable platformAssigningforCgdb = CheckPlatformAssignment(Latesttrains);

                    if (BaseClass.IsNtesAutoMode())
                    {
                        InsertNtesSchudeleTadb(platformAssigningforCgdb, "Auto");

                    }
                    else
                    {

                        InsertNtesSchudeleTadb(platformAssigningforCgdb, "none");

                    }



                }
                else
                {
                    Server.LogError("No Trains Availble.");
                    //  MessageBox.Show("No data found.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public void InsertNtesSchudeleTadb(DataTable dt, string Mode)
        {
            // Add the new column for platform assignment check if it doesn't exist
            try
            {

                DataTable TempTrains = OnlineTrainsDao.GetAllTempTrains();
                List<string> TemptrainNumbersList = GetTrainNumbers(TempTrains);
                DeleteExpiredTrains(dt, TemptrainNumbersList);

                // Loop through each DataRow in the DataTable
                foreach (DataRow row in dt.Rows)
                {
                    // Extract values from the DataRow
                    int Fkey_trainNumber = Convert.ToInt32(row["Pkey_TrainNumber"]);
                    string trainNo = row["TrainNumber"].ToString();
                    string trainName = row["EnglishName"].ToString();
                    string sta = row["ArrivalTime"].ToString();  // Scheduled Time of Arrival      
                    string std = row["DepartureTime"].ToString();  // Scheduled Time of Departure
                    string ADStatus = row["ADStatus"].ToString();
                    string Tstatus = row["Status"].ToString();  // Train Status
                    string delayArr = row["LateBy"].ToString();  // Delay in Arrival
                    string eta = row["LArrivalTime"].ToString(); // Estimated Time of Arrival
                    string etd = row["LDepartureTime"].ToString();  // Estimated Time of Departure
                    string platformNo = row["Platform"].ToString();  // Platform Number
                    string terminatedPlace = "";  // Terminated Place
                    string trainNameHindi = row["HindiName"].ToString();  // Train Name in Hindi
                    string LocalRegionalName = row["RegionalName"].ToString();  // Local/Regional Name
                    string coachPosition = row["Coaches"].ToString();  // Coach Position

                    // Initialize the variables for InsertSchduleData
                    bool tadb, cgdb, ann, ntes;
                    string city = ""; // Initialize city as an empty string

                    if (Mode == "Auto")
                    {
                        tadb = true;
                        cgdb = row.Field<bool>("cgdb");
                        ann = row.Field<bool>("ann");
                        ntes = false;
                    }
                    else if (Mode == "Manual")
                    {
                        tadb = false;
                        cgdb = false;
                        ann = false;
                        ntes = false;
                    }
                    else
                    {
                        // Default values if Mode is not recognized
                        tadb = false;
                        cgdb = false;
                        ann = false;
                        ntes = false;
                    }

                    if (BaseClass.IsNtesEnabled() && BaseClass.IsNtesAudio())
                    {
                        ann = true;
                    }
                    if (BaseClass.IsNtesEnabled() && !BaseClass.IsNtesAudio())
                    {
                        ann = false;
                    }
                    // Arrival/Departure Status
                    // Check if the platform is already assigned


                    if (TemptrainNumbersList.Contains(trainNo))
                    {

                        InterfaceDb.InsertSchduleData(Fkey_trainNumber, trainNo, trainName, sta, std, ADStatus, Tstatus, delayArr, eta, etd, platformNo, terminatedPlace, trainNameHindi, LocalRegionalName, coachPosition, tadb, cgdb, ann, ntes, city);

                    }
                    else
                    {
                        OnlineTrainsDao.InsertTempTrains(trainNo);
                        // Call the InsertSchduleData method to insert the data
                        InterfaceDb.InsertSchduleData(Fkey_trainNumber, trainNo, trainName, sta, std, ADStatus, Tstatus, delayArr, eta, etd, platformNo, terminatedPlace, trainNameHindi, LocalRegionalName, coachPosition, tadb, cgdb, ann, ntes, city);

                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public static List<string> GetNtesTrainNumbers(DataTable NtesTrains)
        {
            // Create a new list to store the train numbers
            List<string> trainNumbers = new List<string>();

            // Iterate through each row in the DataTable
            foreach (DataRow row in NtesTrains.Rows)
            {
                // Add the value of the "TrainNumber" column to the list
                trainNumbers.Add(row["TrainNumber"].ToString().Trim());
            }

            // Return the list of train numbers
            return trainNumbers;
        }

        private void DeleteExpiredTrains(DataTable dt, List<string> TemptrainNumbersList)
        {
            try
            {


                // Get the list of current train numbers
                List<string> NtesTrainNumbers = GetNtesTrainNumbers(dt);

                // Iterate over the list of train numbers
                foreach (string trainNumber in TemptrainNumbersList)
                {
                    // Check if the train number is not in the list of current train numbers
                    if (!NtesTrainNumbers.Contains(trainNumber))
                    {
                        // Delete the train number from both TEMP and Schedule TADB
                        OnlineTrainsDao.DeleteTrainNumberInTEMPANDScheduleTadb(trainNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        private string Getcity(string trainstatus, string divertedRoute, string terminatedPlace)
        {
            string city = "";
            try
            {



                if (trainstatus == "Terminated At")
                {
                    city = terminatedPlace;

                }
                else if (trainstatus == "Diverted")
                {
                    city = divertedRoute;

                }
                else if (trainstatus == "Change of Source")
                {
                    city = divertedRoute;

                }
                else
                {
                    city = divertedRoute;

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return city;


        }



        private (string, string) Gettrainstatus(string trainstatus)
        {
            string status;
            string adFlag;
            if (trainstatus == "Arrived")
            {
                status = "Has Arrived On";
                adFlag = "A";
            }
            else if (BaseClass.arrivalStatus.Contains(trainstatus))
            {
                status = trainstatus;
                adFlag = "A";
            }
            else if (BaseClass.DepatureStatus.Contains(trainstatus))
            {
                status = trainstatus;
                adFlag = "D";
            }
            else
            {
                status = "Running Right Time";
                adFlag = "A";
            }



            return (status, adFlag);
        }

        private void dgvOnlineTrains_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void dgvOnlineTrains_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvOnlineTrains.CurrentCell.RowIndex < dgvOnlineTrains.RowCount - 1)
            {
                try
                {
                    // Check if the current cell is dirty (i.e., it has unsaved changes)
                    if (dgvOnlineTrains.IsCurrentCellDirty)
                    {
                        // Commit the edit to trigger the CellValueChanged event
                        dgvOnlineTrains.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        dgvOnlineTrains.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        dgvOnlineTrains.RefreshEdit();
                        if (dgvOnlineTrains.CurrentCell.ColumnIndex == dgvAnnColumn.Index && dgvOnlineTrains.CurrentCell.ColumnIndex != 2)
                        {
                            var currentRow = dgvOnlineTrains.CurrentRow;
                            bool AnnChecked = Convert.ToBoolean(currentRow.Cells["dgvAnnColumn"].Value);
                            if (AnnChecked)
                                CheckAnnStatus();

                        }
                        if (dgvOnlineTrains.CurrentCell.ColumnIndex == dgvTdbColumn.Index && dgvOnlineTrains.CurrentCell.ColumnIndex != 2)
                        {
                            var currentRow = dgvOnlineTrains.CurrentRow;

                            bool TdbChecked = Convert.ToBoolean(currentRow.Cells["dgvTdbColumn"].Value);
                            if (TdbChecked)
                                CheckAnnStatus();
                        }
                        // Check if the current column is the checkbox column (e.g., dgvCdbColumn)
                        if (dgvOnlineTrains.CurrentCell.ColumnIndex == dgvCdbColumn.Index && dgvOnlineTrains.CurrentCell.ColumnIndex != 2)
                        {
                            // Get the current row

                            var currentRow = dgvOnlineTrains.CurrentRow;
                            if (currentRow != null)
                            {
                                // SaveChanges(currentRow);
                                bool wasChecked = Convert.ToBoolean(currentRow.Cells["dgvCdbColumn"].Value);
                                // Uncheck condition
                                if (!wasChecked)
                                {
                                    string platformNo = currentRow.Cells["dgvPFColumn"].Value?.ToString();
                                    string platform = BaseClass.ConvertPlatformToIp(platformNo);

                                    string pdcIp = "192.168." + platform + ".251";

                                    if (Server._connectedClients.Count > 0)
                                    {
                                        Deletecgdbdata(pdcIp);

                                    }
                                    else
                                    {
                                        BaseClass.WritingThirdpartyTextfile();
                                    }
                                }
                                else
                                {
                                    CheckCgdbStatus();

                                    bool check = CheckCheckedCgdbRows();
                                    if (check)
                                    {
                                        bool checkedplatform = CheckPlatformCgdbRows(checkedCgDbRows);
                                        // bool checkedhub = CheckHubPlatformCgdbRows(checkedCgDbRows);
                                        bool checkedhub = CheckHubSINGLEPlatformCgdbRows(currentRow);
                                        if (checkedplatform)
                                        {
                                            currentRow.Cells["dgvCdbColumn"].Value = false;
                                            dgvOnlineTrains.RefreshEdit();
                                            MessageBox.Show("Same Platform cannot be assigned.");
                                            //  SaveChanges(currentRow);
                                            // Uncheck the checkbox if the platform condition is true
                                        }
                                        else if (!checkedhub)
                                        {
                                            currentRow.Cells["dgvCdbColumn"].Value = false;
                                            dgvOnlineTrains.RefreshEdit();
                                            // if(!BaseClass.IsNtesEnabled()|| !BaseClass.IsLocalAutoMode())
                                            MessageBox.Show("Hub Not Configured.");
                                            //  SaveChanges(currentRow);
                                        }
                                        else
                                        {
                                            //SaveChanges(currentRow);  // Save changes only if all checks pass
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            //if (dgvOnlineTrains.CurrentCell.ColumnIndex != 2)
                            // SaveChanges();  // Handle other column changes
                        }
                        dgvOnlineTrains.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        dgvOnlineTrains.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        dgvOnlineTrains.RefreshEdit();
                    }
                }
                catch (Exception ex)
                {
                    Server.LogError(ex.Message);
                }
                SaveChanges(dgvOnlineTrains.CurrentRow);
            }


        }

        public static void Deletecgdbdata(string pdcIp)
        {
            int packetidentifier = Board.CGDB;
            if (BaseClass.Getinteroperabilitystatus(pdcIp))
            {


                int PkKeyMasterHub = 0;
                List<string> CgdbIpAddressPositions = new List<string>();
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("IPAddress") &&
                        row["IPAddress"] != null &&
                        row["IPAddress"].ToString().Trim() == pdcIp.Trim())
                    {
                        PkKeyMasterHub = Convert.ToInt32(row["PkeyMasterhub"]);

                        DataTable cgdbIp = HubConfigurationDb.GetCoaches(PkKeyMasterHub);

                        foreach (DataRow eachrow in cgdbIp.Rows)
                        {
                            string cgdbIpAddress = eachrow.Field<string>("Cgdb_IpAddress");
                            CgdbIpAddressPositions.Add(cgdbIpAddress);
                        }
                    }
                }
                foreach (string ipaddress in CgdbIpAddressPositions)
                {


                    byte[] LinkCheckPacket = frmBoardDiagnosis.DeleteData(ipaddress, packetidentifier);

                    byte[] trimmedstopBytes = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);



                    Server.SendMessageToClient(ipaddress, trimmedstopBytes);


                }
            }
            else
            {
                StopCommand(pdcIp, packetidentifier);
            }
            BaseClass.ButtonStatus = "Cgdb";
            BaseClass.WritingThirdpartyTextfile();
        }
        public void CheckCgdbStatus()
        {
            var currentRow = dgvOnlineTrains.CurrentRow;
            dgvOnlineTrains.RefreshEdit();
            dgvOnlineTrains.RefreshEdit();
            string PF = currentRow.Cells["dgvPFColumn"].Value?.ToString().Trim();

            if (PF == "" || PF == "--")
            {
                currentRow.Cells["dgvCdbColumn"].Value = false;
                dgvOnlineTrains.RefreshEdit();
                MessageBox.Show("Please Select PF");

            }



        }
        public void CheckAnnStatus()
        {
            var currentRow = dgvOnlineTrains.CurrentRow;
            string TrainStatus = currentRow.Cells["dgvTrainStatusColumn"].Value?.ToString();
            string PF = currentRow.Cells["dgvPFColumn"].Value?.ToString().Trim();
            string AD = currentRow.Cells["dgvAdColumn"].Value?.ToString();
            int statusCode = BaseClass.getStatusCode(TrainStatus, AD);
            if (statusCode == 2 || statusCode == 3 || statusCode == 4 || statusCode == 9 || statusCode == 12 || statusCode == 13 || statusCode == 14 || statusCode == 17 || statusCode == 18)
            {
                if (PF == "" || PF == "--")
                {

                    MessageBox.Show("Please Select PF");
                    string columnName = dgvOnlineTrains.CurrentCell.OwningColumn.Name;
                    if (columnName == "dgvTdbColumn" || statusCode == 2)
                        currentRow.Cells["dgvTdbColumn"].Value = false;
                    currentRow.Cells["dgvAnnColumn"].Value = false;

                    dgvOnlineTrains.RefreshEdit();
                    dgvOnlineTrains.RefreshEdit();




                }
            }


        }
        private bool CheckHubPlatformCgdbRows(List<DataGridViewRow> checkedRows)
        {
            try
            {


                var platforms = new HashSet<string>();
                int count = 0;
                foreach (var row in checkedRows)
                {
                    string PlatformNo = row.Cells["dgvPFColumn"].Value.ToString().Trim();

                    if (platforms.Add(PlatformNo))
                    {
                        // Duplicate platform found, check for IP address mismatch
                        string pdcIp = "192.168." + PlatformNo + ".251";

                        foreach (DataRow onerow in BaseClass.EthernetPorts.Rows)
                        {
                            if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                            {
                                string ipAddressStr = onerow["IPAddress"].ToString().Trim();


                                if (pdcIp == ipAddressStr)
                                {
                                    count++;

                                }

                            }
                        }
                    }
                }

                if (count == BaseClass.SelectedCGDBRows)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            // No duplicates found with mismatched IP addresses
            return false;
        }

        private bool CheckHubSINGLEPlatformCgdbRows(DataGridViewRow checkedRows)
        {
            try
            {


                var platforms = new HashSet<string>();
                int count = 0;

                string PlatformNo = checkedRows.Cells["dgvPFColumn"].Value.ToString().Trim();

                if (platforms.Add(PlatformNo))
                {
                    // Duplicate platform found, check for IP address mismatch
                    string pdcIp = "192.168." + PlatformNo + ".251";

                    foreach (DataRow onerow in BaseClass.EthernetPorts.Rows)
                    {
                        if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                        {
                            string ipAddressStr = onerow["IPAddress"].ToString().Trim();


                            if (pdcIp == ipAddressStr)
                            {
                                count++;

                            }

                        }
                    }
                }


                //if (count == BaseClass.SelectedCGDBRows)
                //{
                //    return true;
                //}

                if (count == 1)
                {
                    return true;
                }


            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            // No duplicates found with mismatched IP addresses
            return false;
        }
        private bool CheckPlatformCgdbRows(List<DataGridViewRow> checkedRows)
        {

            try
            {


                var platforms = new HashSet<string>();

                foreach (var row in checkedRows)
                {
                    string PlatformNo = row.Cells["dgvPFColumn"].Value.ToString().Trim();

                    if (!platforms.Add(PlatformNo))
                    {
                        // If Add returns false, it means the platform already exists in the HashSet
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            // No duplicates found
            return false;
        }


        public void SaveChanges(DataGridViewRow changedRow)
        {
            ChangeTdbColor(true);
            try
            {


                // Ensure that the row is valid
                if (changedRow != null)
                {


                    // Retrieve the row index
                    int rowIndex = changedRow.Index;

                    // Retrieve values from specific cells in the changed row
                    string trainNo = changedRow.Cells["dgvTrNoColumn"].Value?.ToString();
                    string[] trainNumbers = trainNo.Split('\n');
                    trainNo = trainNumbers[0];

                    string ADStatus = changedRow.Cells["dgvAdColumn"].Value?.ToString();
                    string Tstatus = changedRow.Cells["dgvTrainStatusColumn"].Value?.ToString();
                    string delayArr = changedRow.Cells["dgvLateColumn"].Value?.ToString();
                    string eta = changedRow.Cells["dgvEtaColumn"].Value?.ToString();
                    string etd = changedRow.Cells["dgvETDColumn"].Value?.ToString();
                    string platformNo = changedRow.Cells["dgvPFColumn"].Value?.ToString();

                    // Handle boolean values, ensure conversion is correct
                    bool tadb = changedRow.Cells["dgvTdbColumn"].Value != DBNull.Value && Convert.ToBoolean(changedRow.Cells["dgvTdbColumn"].Value);
                    bool cgdb = changedRow.Cells["dgvCdbColumn"].Value != DBNull.Value && Convert.ToBoolean(changedRow.Cells["dgvCdbColumn"].Value);
                    bool ann = changedRow.Cells["dgvAnnColumn"].Value != DBNull.Value && Convert.ToBoolean(changedRow.Cells["dgvAnnColumn"].Value);
                    bool ntes = changedRow.Cells["dgvNtesColumn"].Value != DBNull.Value && Convert.ToBoolean(changedRow.Cells["dgvNtesColumn"].Value);

                    // Retrieve the city value
                    string city = changedRow.Cells["dgvCityColumn"].Value?.ToString();

                    string EStation = changedRow.Cells["dgvCityColumn"].Value?.ToString();
                    string HStation = changedRow.Cells["dgvHindiCityName"].Value?.ToString();
                    string RStation = changedRow.Cells["dgvRegCityName"].Value?.ToString();

                    // Call the UpdateChanges method with the retrieved values
                    int rowsAffected = OnlineTrainsDao.UpdateChanges(
                        trainNo, ADStatus, Tstatus, delayArr, eta, etd, platformNo,
                        tadb, cgdb, ann, ntes, city, EStation, HStation, RStation
                    );

                    //if (!cgdb)
                    //{
                    //    string pdcIp = "192.168." + platformNo + ".251";
                    //    int packetidentifier = Board.CGDB;
                    //    StopCommand(pdcIp, packetidentifier);
                    //}


                    // Display a confirmation message or handle further processing
                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show($"Changes saved for row {rowIndex}: New Value = {Tstatus}", "Changes Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // MessageBox.Show($"No changes saved for row {rowIndex}.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void dgvOnlineTrains_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // Check if the column is the 'dgvLateColumn'
                if (dgvOnlineTrains.Columns[e.ColumnIndex].Name == "dgvLateColumn" && e.RowIndex != dgvOnlineTrains.Rows.Count - 1)
                {
                    var cellValue = dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    // Check if the cell value is null or an invalid string
                    if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()) || cellValue.ToString().Length != 5)
                    {
                        this.dgvOnlineTrains.CurrentRow.Cells["dgvLateColumn"].Value = "00:00";
                        MessageBox.Show("Please enter a proper time in the format HH:mm.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Stop further execution if the time is invalid
                    }

                    // Process only if the time format is correct
                    string LateTime = cellValue.ToString();
                    string StaTime = this.dgvOnlineTrains.CurrentRow.Cells["dgvStaColumn"].Value?.ToString();
                    string StdTime = this.dgvOnlineTrains.CurrentRow.Cells["dgvSTDColumn"].Value?.ToString();

                    // Check if StaTime and StdTime are not null before processing
                    if (!string.IsNullOrWhiteSpace(StaTime) && !string.IsNullOrWhiteSpace(StdTime))
                    {
                        string EtaTime = AddTwoTimes(LateTime, StaTime);
                        string EtdTime = AddTwoTimes(LateTime, StdTime);

                        this.dgvOnlineTrains.CurrentRow.Cells["dgvEtaColumn"].Value = EtaTime;
                        this.dgvOnlineTrains.CurrentRow.Cells["dgvETDColumn"].Value = EtdTime;
                        if (this.dgvOnlineTrains.CurrentRow.Cells["dgvTrainStatusColumn"].Value?.ToString() == "Running Right Time")
                        {
                            string currentValue = this.dgvOnlineTrains.CurrentRow.Cells["dgvAdColumn"].Value?.ToString();

                            DataGridViewCell statuscell = dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];



                            dgvOnlineTrains.CurrentRow.Cells["dgvCityColumn"].Value = "";



                            if (LateTime != "00:00")
                            {
                                this.dgvOnlineTrains.CurrentRow.Cells["dgvAdColumn"].Value = "A";
                                resetArrivalStatus(statuscell);

                                this.dgvOnlineTrains.CurrentRow.Cells["dgvTrainStatusColumn"].Value = "Running Late";
                            }
                        }

                        // Save changes to the row
                        SaveChanges(this.dgvOnlineTrains.CurrentRow);
                    }
                    else
                    {
                        this.dgvOnlineTrains.CurrentRow.Cells["dgvLateColumn"].Value = "00:00";
                        MessageBox.Show("STA or STD time is missing.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        public static string AddTwoTimes(string FirstTime, string LastTime)
        {
            TimeSpan time1 = TimeSpan.Parse(FirstTime);
            TimeSpan time2 = TimeSpan.Parse(LastTime);

            TimeSpan totalTime = time1 + time2;


            string result = totalTime.ToString(@"hh\:mm");
            return result;
        }

        private void txtCoach1_Leave(object sender, EventArgs e)
        {
            changeTextBoxUpperCase(txtCoach1);
        }


        public void changeTextBoxUpperCase(TextBox currentTextBox)
        {
            try
            {


                // Convert to uppercase
                int selectionStart = currentTextBox.SelectionStart;
                currentTextBox.Text = currentTextBox.Text.ToUpper();
                currentTextBox.SelectionStart = selectionStart;

                // Limit the text to 4 characters
                if (currentTextBox.Text.Length > 4)
                {
                    currentTextBox.Text = currentTextBox.Text.Substring(0, 4);
                    currentTextBox.SelectionStart = 4; // Keep cursor at the end
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void txtCoach2_Leave(object sender, EventArgs e)
        {
            changeTextBoxUpperCase(txtCoach2);
        }

        private void txtCoach3_TextChanged(object sender, EventArgs e)
        {
            changeTextBoxUpperCase(txtCoach3);
        }

        private void pnlAnnounceMent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvOnlineTrains_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void lblSingle_Click(object sender, EventArgs e)
        {

        }

        private void lblMulti_Click(object sender, EventArgs e)
        {

        }

       


        private List<string> allowedDuplicates = new List<string> { "GEN", "ENG", "SLRD", "SLR", "", "VP", "GS" };
        private void txtCoach1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }
        private void AllowOnlyLettersAndDigitsInCaps(object sender, KeyPressEventArgs e)
        {
            // Check if the character is a letter or digit
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                // Convert lowercase letters to uppercase
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            else
            {
                // Ignore other characters
                e.Handled = true; // Block non-letter/non-digit characters
            }
        }
        private void CheckForDuplicates(object sender, EventArgs e)
        {
            try
            {

                TextBox currentTextBox = sender as TextBox;
                string newValue = currentTextBox.Text.ToString().ToUpper();
                // Check for duplicates within the TextBoxes in pnlCoachPositions only
                foreach (Control ctrl in pnlCoachPositions.Controls) // Iterate only through the pnlCoachPositions controls
                {
                    if (ctrl is TextBox textBox && textBox != currentTextBox)
                    {
                        // Check for duplicates (skip allowed duplicates)
                        if (textBox.Text.Trim().ToUpper() == newValue.Trim().ToUpper() &&
                            !allowedDuplicates.Contains(newValue.Trim().ToUpper())) // Only block non-allowed duplicates
                        {
                            // Duplicate found, block input
                            currentTextBox.Text = "";
                            currentTextBox.Focus();
                            MessageBox.Show("Coach alredy Existed");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void CheckForDuplicatesLinkedCoaches(object sender, EventArgs e)
        {
            try
            {

                TextBox currentTextBox = sender as TextBox;
                string newValue = currentTextBox.Text.ToString().ToUpper();
                // Check for duplicates within the TextBoxes in pnlCoachPositions only
                foreach (Control ctrl in panlinkedCgdb.Controls) // Iterate only through the pnlCoachPositions controls
                {
                    if (ctrl is TextBox textBox && textBox != currentTextBox)
                    {
                        // Check for duplicates (skip allowed duplicates)
                        if (textBox.Text.Trim().ToUpper() == newValue.Trim().ToUpper() &&
                            !allowedDuplicates.Contains(newValue.Trim().ToUpper())) // Only block non-allowed duplicates
                        {
                            // Duplicate found, block input
                            currentTextBox.Text = "";
                            currentTextBox.Focus();
                            MessageBox.Show("Coach alredy Existed");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {


                TextBox currentTextBox = sender as TextBox;

                // Allow backspace for corrections
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }

                // Check if the character is a letter or digit
                if (char.IsLetterOrDigit(e.KeyChar))
                {
                    // Convert to uppercase
                    string newValue = currentTextBox.Text + e.KeyChar.ToString().ToUpper();

                    // If the new value is in the allowed duplicates list, allow it without checking for duplicates
                    if (allowedDuplicates.Contains(newValue.Trim().ToUpper()))
                    {
                        e.KeyChar = char.ToUpper(e.KeyChar); // Convert to uppercase
                        return; // Allow the input
                    }



                    // Convert lowercase letters to uppercase
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else
                {
                    // Block non-letter/non-digit characters
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void txtCoach1_Leave_1(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach4_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach5_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach6_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach7_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach8_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach9_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach10_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach11_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach12_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach13_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach14_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach15_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach16_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach17_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach18_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach19_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach20_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach21_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach22_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach23_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach24_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach25_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach26_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach27_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtCoach28_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        //private void CdotPauseTimer_Tick(object sender, EventArgs e)
        //{

        //    btnCdotPause.Enabled = true;
        //    if (CdotPauseTimer.Enabled)
        //    {
        //        CdotPauseTimer.Stop();
        //    }
        //    CdotController.pausecdot = false;
        //    InterfaceDb.insertAfterPauseCdotSendMessages();
        //    DataController.sendDataToBoards();
        //}

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        public static bool FirstClickMulti = true;
        private void lblMulti_Click_1(object sender, EventArgs e)
        {
            if (FirstClickMulti)
            {
                pnlMultiGrid.Visible = true;
                FirstClickMulti = false;
            }
            else
            {
                pnlMultiGrid.Visible = false;
                FirstClickMulti = true;
            }
        }

        private void btnMultiGridClose_Click(object sender, EventArgs e)
        {
            pnlMultiGrid.Visible = false;
            FirstClickMulti = true;
        }

        private void chkTimeSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTimeSelect.Checked)
            {
                Cmbselectedhrs.SelectedIndex = 0;

                chkRangeSelect.Checked = false;
                EnablechkTimeSelectControls(true);
                EnablechkRangeSelectControls(false);
            }
            else
            {
                chkRangeSelect.Checked = true;
                txtTOTimeSchedule.Text = "00:00";
                txtfrmtimeSchedule.Text = "00:00";
                chkTimeSelect.Checked = false;
                EnablechkTimeSelectControls(false);
                EnablechkRangeSelectControls(true);
            }
        }

        private void chkRangeSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRangeSelect.Checked)
            {
                txtTOTimeSchedule.Text = "00:00";
                txtfrmtimeSchedule.Text = "00:00";
                chkTimeSelect.Checked = false;
                EnablechkTimeSelectControls(false);
                EnablechkRangeSelectControls(true);
            }
            else
            {
                chkTimeSelect.Checked = true;
                Cmbselectedhrs.SelectedIndex = 0;

                chkRangeSelect.Checked = false;
                EnablechkTimeSelectControls(true);
                EnablechkRangeSelectControls(false);
            }

        }
        private void EnablechkTimeSelectControls(bool enable)
        {
            txtfrmtimeSchedule.Enabled = enable;
            txtTOTimeSchedule.Enabled = enable;

        }


        private void EnablechkRangeSelectControls(bool enable)
        {
            Cmbselectedhrs.Enabled = enable;
            lblErrorTimeSchudeuleFromTime.Visible = false;
            lblErrorTimeSchudeuleToTime.Visible = false;

        }

        private void btnGetTrains_Click(object sender, EventArgs e)
        {
            DataTable onlineTrainsDt = OnlineTrainsDao.GetTopScheduledTaddbRecords();
            frmOnlineTrains.DeleteTrains(onlineTrainsDt);
            setMultiTrainsData();
            pnlMultiGrid.Visible = false;
            LoadFillrunningTrains();
            FirstClickMulti = true;
        }
        public void setMultiTrainsData()
        {
            try
            {


                OnlineTrainsDao.Deletescheduletadb();


                DataTable TrainDetailsdt = OnlineTrainsDao.GetAllTrains();


                bool selectTime = chkTimeSelect.Checked;
                bool selectRange = chkTimeSelect.Checked;

                if (selectTime)
                {
                    string fromtime = txtfrmtimeSchedule.Text;
                    string toTime = txtTOTimeSchedule.Text;
                    DataTable ARRIVALTRAINS = FilterTimeArrivalRange(TrainDetailsdt, fromtime, toTime);
                    DataTable DEPARTURETRAINS = FilterTimeDepartureRange(TrainDetailsdt, fromtime, toTime);

                    DataTable FilteredTrainsBasedOntime = MergeAndRemoveDuplicates(ARRIVALTRAINS, DEPARTURETRAINS);

                    // DataTable FilteredTrainsBasedOntime = FilterTimeRange(TrainDetailsdt, fromtime, toTime);

                    DataTable Latesttrains = SortTrainsByArrival(FilteredTrainsBasedOntime);

                    DataTable platformAssigningforCgdb = CheckPlatformAssignment(Latesttrains);
                    InsertSchudeleTadb(platformAssigningforCgdb, "Manual");
                }
                else
                {
                    // Handle next hours logic
                    int nextHrs = Convert.ToInt32(Cmbselectedhrs.Text); // Convert NextHrs to integer
                                                                        // Get cur-rent time
                    DateTime currentTime = DateTime.Now;

                    // Calculate the end time by adding nextHrs to current time
                    DateTime endTime = currentTime.AddHours(nextHrs);

                    // If the end time exceeds 23:59, limit it to 23:59
                    if (endTime.TimeOfDay >= TimeSpan.FromHours(24))
                    {
                        endTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
                    }

                    // Filter trains based on the time range from currentTime to endTime
                    DataTable ARRIVALTRAINS = FilterTimeArrivalRange(TrainDetailsdt, currentTime.ToString("HH:mm"), endTime.ToString("HH:mm"));
                    DataTable DEPARTURETRAINS = FilterTimeDepartureRange(TrainDetailsdt, currentTime.ToString("HH:mm"), endTime.ToString("HH:mm"));

                    DataTable FilteredTrainsBasedOnNextHours = MergeAndRemoveDuplicates(ARRIVALTRAINS, DEPARTURETRAINS);

                    DataTable Latesttrains = SortTrainsByArrival(FilteredTrainsBasedOnNextHours);

                    DataTable platformAssigningforCgdb = CheckPlatformAssignment(Latesttrains);


                    InsertSchudeleTadb(platformAssigningforCgdb, "Manual");

                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void btnSingle_Click(object sender, EventArgs e)
        {
            BaseClass.selectTrainsDatabase = "ScheduledTrains";
            //frmScheduledTrains frmSch = new frmScheduledTrains();
            //frmSch.Show();
            frmScheduledTrains frmscheduled;

            Form mainForm = Application.OpenForms["frmScheduledTrains"];

            if (mainForm != null)
            {
                frmscheduled = (frmScheduledTrains)mainForm;
                frmscheduled.Show();
            }
            else
            {
                frmscheduled = new frmScheduledTrains();
                frmscheduled.Show();
            }
            frmscheduled.BringToFront();

        }

        private void numericUpDownCdot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblCdotMin_Click(object sender, EventArgs e)
        {

        }

        private void lblCdot_Click(object sender, EventArgs e)
        {

        }

        private void txtCoach2_Leave_1(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach3_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach4_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach5_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach6_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach7_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach8_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach9_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach10_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach11_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach12_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach13_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach14_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach15_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach16_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach17_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach18_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach19_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach20_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach21_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach22_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach23_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach24_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach25_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach26_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach27_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void txtCoach28_Leave(object sender, EventArgs e)
        {
            CheckForDuplicates(sender, e);
        }

        private void btnTrainRevesal_Click(object sender, EventArgs e)
        {
            // trainReverse();

            if (BaseClass.LinkedTrainsList.Contains(CurrentTrainNumber))
            {
                trainReversalLinkedCoaches();
                trainReverselinkedCoaches();
                btnTrainRevesal.Enabled = false;

            }
            else
            {
                trainReversal();
                trainReverse();
                btnTrainRevesal.Enabled = false;
            }



        }
        private void trainReversal()
        {
            try
            {
                TextBox[] textBoxes = new TextBox[]
                {
            txtCoach1, txtCoach2, txtCoach3, txtCoach4, txtCoach5,
            txtCoach6, txtCoach7, txtCoach8, txtCoach9, txtCoach10,
            txtCoach11, txtCoach12, txtCoach13, txtCoach14, txtCoach15,
            txtCoach16, txtCoach17, txtCoach18, txtCoach19, txtCoach20,
            txtCoach21, txtCoach22, txtCoach23, txtCoach24, txtCoach25,
            txtCoach26, txtCoach27, txtCoach28
                };

                // Store the text of the first text box
                string firstText = textBoxes[0].Text.Trim(); // Keep the first text box value

                // Create a list to hold the values from the other text boxes
                List<string> values = new List<string>();

                // Collect values from the second text box onward, ignoring whitespace or empty strings
                for (int i = 1; i < textBoxes.Length; i++)
                {
                    string currentText = textBoxes[i].Text.Trim(); // Trim whitespace
                    if (!string.IsNullOrWhiteSpace(currentText))
                    {
                        values.Add(currentText);
                    }
                }

                // Clear all text boxes first
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    textBoxes[i].Clear(); // Clear each text box first
                }

                // Assign the collected values back to the text boxes, starting from the first position
                for (int i = 0; i < values.Count; i++)
                {
                    textBoxes[i].Text = values[i]; // Fill in the collected values
                }

                // Place the first text box value at the end
                if (values.Count < textBoxes.Length) // Check to ensure there is space
                {
                    textBoxes[values.Count].Text = firstText; // Place the first text box value at the end
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void trainReversalLinkedCoaches()
        {
            try
            {
                TextBox[] textBoxes = new TextBox[]
                {
            txtLCoach1, txtLCoach2, txtLCoach3, txtLCoach4, txtLCoach5,
            txtLCoach6, txtLCoach7, txtLCoach8, txtLCoach9, txtLCoach10,
            txtLCoach11, txtLCoach12, txtLCoach13, txtLCoach14, txtLCoach15,
            txtLCoach16, txtLCoach17, txtLCoach18, txtLCoach19, txtLCoach20,
            txtLCoach21, txtLCoach22, txtLCoach23, txtLCoach24, txtLCoach25,
            txtLCoach26, txtLCoach27, txtLCoach28
                };

                // Store the text of the first text box
                string firstText = textBoxes[0].Text.Trim(); // Keep the first text box value

                // Create a list to hold the values from the other text boxes
                List<string> values = new List<string>();

                // Collect values from the second text box onward, ignoring whitespace or empty strings
                for (int i = 1; i < textBoxes.Length; i++)
                {
                    string currentText = textBoxes[i].Text.Trim(); // Trim whitespace
                    if (!string.IsNullOrWhiteSpace(currentText))
                    {
                        values.Add(currentText);
                    }
                }

                // Clear all text boxes first
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    textBoxes[i].Clear(); // Clear each text box first
                }

                // Assign the collected values back to the text boxes, starting from the first position
                for (int i = 0; i < values.Count; i++)
                {
                    textBoxes[i].Text = values[i]; // Fill in the collected values
                }

                // Place the first text box value at the end
                if (values.Count < textBoxes.Length) // Check to ensure there is space
                {
                    textBoxes[values.Count].Text = firstText; // Place the first text box value at the end
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        private void btnInsert_Click(object sender, EventArgs e)
        {


            if (BaseClass.LinkedTrainsList.Contains(CurrentTrainNumber))
            {

                InsertTextBoxLinked();
            }
            else
            {
                InsertTextBox();

            }

        }

        private void dgvOnlineTrains_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            checkLatetimeMesage = true;

            try
            {

                BaseClass.currentdatgridRow = dgvOnlineTrains.CurrentRow;



                if ((e.RowIndex >= 0 && (dgvOnlineTrains.Columns[e.ColumnIndex].Name == "dgvTrNoColumn" || dgvOnlineTrains.Columns[e.ColumnIndex].Name == "dgvTrainColumn") && e.RowIndex <= dgvOnlineTrains.Rows.Count - 2))
                {
                    string TrainNumber = dgvOnlineTrains.CurrentRow.Cells["dgvTrNoColumn"].Value.ToString();
                    string TrainName = dgvOnlineTrains.CurrentRow.Cells["dgvTrainNameColumn"].Value.ToString();
                    string PF = dgvOnlineTrains.CurrentRow.Cells["dgvPFColumn"].Value.ToString();

                    string[] trainNumbers = TrainNumber.Split('\n');
                    TrainNumber = trainNumbers[0];
                    SetCoachesValues(TrainNumber, TrainName, PF);

                }
                // Check if the clicked cell is in the last row
                if ((e.RowIndex == dgvOnlineTrains.Rows.Count - 1) && (e.ColumnIndex == 1))
                {
                    ScheludeFormOpen();
                }
                if (dgvOnlineTrains.Columns[e.ColumnIndex].Name == "dgvDeleteColumn" && e.RowIndex != dgvOnlineTrains.Rows.Count - 1)
                {
                    string TrainNumber = dgvOnlineTrains.CurrentRow.Cells["dgvTrNoColumn"].Value.ToString();
                    BaseClass.OnlineTrainsTaddbDt = OnlineTrainsDao.GetScheduledTaddbTrains();

                    BaseClass.OnlineTrainsTaddbDt = BaseClass.ModifiedOnlinetrainsdt(BaseClass.OnlineTrainsTaddbDt);

                    if (dgvOnlineTrains.CurrentRow.Cells["dgvCdbColumn"].Value != null &&
                 bool.TryParse(dgvOnlineTrains.CurrentRow.Cells["dgvCdbColumn"].Value.ToString(), out bool cgdbChecked) &&
                 cgdbChecked)
                    {
                        string PF = dgvOnlineTrains.CurrentRow.Cells["dgvPFColumn"].Value.ToString();
                        string platform = BaseClass.ConvertPlatformToIp(PF);


                        if (platform != "--")
                        {
                            string pdcIp = "192.168." + platform + ".251";
                            int packetidentifier = Board.CGDB;
                            //  StopCommand(pdcIp, packetidentifier);
                            Deletecgdbdata(pdcIp);
                        }

                    }
                    if (dgvOnlineTrains.CurrentRow.Cells["dgvTdbColumn"].Value != null &&
               bool.TryParse(dgvOnlineTrains.CurrentRow.Cells["dgvTdbColumn"].Value.ToString(), out bool TaddbChecked) &&
               TaddbChecked)
                    {

                        if (CheckTrainNumberExistedOrNot(TrainNumber))
                        {

                            if (BaseClass.OnlineTrainsTaddbDt.Rows.Count > 1)
                            {
                                deleteTrainRow(sender, e);
                                FillFirstTainDetails();
                                DataController.sendTaddbData();
                            }
                            else if (BaseClass.OnlineTrainsTaddbDt.Rows.Count == 1)
                            {
                                if (TrainNumber == BaseClass.OnlineTrainsTaddbDt.Rows[0].Field<String>("TrainNo").ToString())
                                {
                                    deleteTrainRow(sender, e);

                                    FillFirstTainDetails();
                                    DataController.ClearAllBoards();
                                    MessageBox.Show("All Boards Data Cleared");
                                }
                                else
                                {
                                    deleteTrainRow(sender, e);
                                    FillFirstTainDetails();
                                }
                            }
                            else
                            {
                                deleteTrainRow(sender, e);
                                FillFirstTainDetails();
                            }
                        }
                        else
                        {
                            deleteTrainRow(sender, e);
                            FillFirstTainDetails();
                        }

                    }
                    else
                    {
                        deleteTrainRow(sender, e);
                        FillFirstTainDetails();
                    }



                }
                if (dgvOnlineTrains.Columns[e.ColumnIndex].Name == "dgvAdColumn" && e.RowIndex != dgvOnlineTrains.Rows.Count - 1)
                {
                    ChangeAorDStatusButtonGrid(sender, e);
                }


                // Check if the clicked row is the last row and it is not a new row
                if (e.RowIndex == dgvOnlineTrains.Rows.Count - 1 && !dgvOnlineTrains.Rows[e.RowIndex].IsNewRow)
                {
                    // Check if the clicked column is the one you want to allow editing (column index 2 in this case)
                    if (e.ColumnIndex == 2)
                    {
                        // Make the specific cell editable (set ReadOnly = false for that cell)
                        dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;

                        // Begin editing the specified cell
                        dgvOnlineTrains.BeginEdit(true);
                    }
                    else
                    {
                        // Make all other cells in the row read-only
                        dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        public static bool CheckTrainNumberExistedOrNot(String TrainNumber)
        {
            bool b = false;
            DataTable RefreshonlineTrainsDt = OnlineTrainsDao.GetScheduledRefreshTaddbTrains();
            foreach (DataRow row in RefreshonlineTrainsDt.Rows)
            {
                if (row["TrainNo"].ToString() == TrainNumber)
                {
                    b = true;
                }
            }
            return b;
        }

        private void dgvOnlineTrains_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {


            if (BaseClass.LinkedTrainsList.Contains(CurrentTrainNumber))
            {
                // Create an array of TextBoxes
                TextBox[] textBoxes = new TextBox[]
                {
        txtLCoach1, txtLCoach2, txtLCoach3, txtLCoach4, txtLCoach5,
            txtLCoach6, txtLCoach7, txtLCoach8, txtLCoach9, txtLCoach10,
            txtLCoach11, txtLCoach12, txtLCoach13, txtLCoach14, txtLCoach15,
            txtLCoach16, txtLCoach17, txtLCoach18, txtLCoach19, txtLCoach20,
            txtLCoach21, txtLCoach22, txtLCoach23, txtLCoach24, txtLCoach25,
            txtLCoach26, txtLCoach27, txtLCoach28
                };

                // Shift values to the left
                for (int i = 0; i < textBoxes.Length - 1; i++)
                {
                    textBoxes[i].Text = textBoxes[i + 1].Text; // Move the value from the right TextBox to the left
                }

                // Clear the last TextBox or set it to a default value
                textBoxes[textBoxes.Length - 1].Text = ""; // You can
            }
            else
            {
                // Create an array of TextBoxes
                TextBox[] textBoxes = new TextBox[]
                {
        txtCoach1, txtCoach2, txtCoach3, txtCoach4, txtCoach5,
        txtCoach6, txtCoach7, txtCoach8, txtCoach9, txtCoach10,
        txtCoach11, txtCoach12, txtCoach13, txtCoach14, txtCoach15,
        txtCoach16, txtCoach17, txtCoach18, txtCoach19, txtCoach20,
        txtCoach21, txtCoach22, txtCoach23, txtCoach24, txtCoach25,
        txtCoach26, txtCoach27, txtCoach28
                };

                // Shift values to the left
                for (int i = 0; i < textBoxes.Length - 1; i++)
                {
                    textBoxes[i].Text = textBoxes[i + 1].Text; // Move the value from the right TextBox to the left
                }

                // Clear the last TextBox or set it to a default value
                textBoxes[textBoxes.Length - 1].Text = ""; // You can


            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {


            if (BaseClass.LinkedTrainsList.Contains(CurrentTrainNumber))
            {

                // Create an array of TextBoxes
                TextBox[] textBoxes = new TextBox[]
                {
              txtLCoach1, txtLCoach2, txtLCoach3, txtLCoach4, txtLCoach5,
            txtLCoach6, txtLCoach7, txtLCoach8, txtLCoach9, txtLCoach10,
            txtLCoach11, txtLCoach12, txtLCoach13, txtLCoach14, txtLCoach15,
            txtLCoach16, txtLCoach17, txtLCoach18, txtLCoach19, txtLCoach20,
            txtLCoach21, txtLCoach22, txtLCoach23, txtLCoach24, txtLCoach25,
            txtLCoach26, txtLCoach27, txtLCoach28
                };

                // Store the last value in a temporary variable
                string tempValue = textBoxes[textBoxes.Length - 1].Text;

                // Shift values to the right
                for (int i = textBoxes.Length - 1; i > 0; i--)
                {
                    textBoxes[i].Text = textBoxes[i - 1].Text; // Move the value from the left TextBox to the right
                }

                // Set the first TextBox to an empty string or a default value
                textBoxes[0].Text = ""; // You can set it to a default value if needed

            }
            else
            {

                // Create an array of TextBoxes
                TextBox[] textBoxes = new TextBox[]
                {
        txtCoach1, txtCoach2, txtCoach3, txtCoach4, txtCoach5,
        txtCoach6, txtCoach7, txtCoach8, txtCoach9, txtCoach10,
        txtCoach11, txtCoach12, txtCoach13, txtCoach14, txtCoach15,
        txtCoach16, txtCoach17, txtCoach18, txtCoach19, txtCoach20,
        txtCoach21, txtCoach22, txtCoach23, txtCoach24, txtCoach25,
        txtCoach26, txtCoach27, txtCoach28
                };

                // Store the last value in a temporary variable
                string tempValue = textBoxes[textBoxes.Length - 1].Text;

                // Shift values to the right
                for (int i = textBoxes.Length - 1; i > 0; i--)
                {
                    textBoxes[i].Text = textBoxes[i - 1].Text; // Move the value from the left TextBox to the right
                }

                // Set the first TextBox to an empty string or a default value
                textBoxes[0].Text = ""; // You can set it to a default value if needed
            }


        }



     

       
        private static bool checkLatetimeMesage = true;
        private static bool platformeMesage = true;
        private void dgvOnlineTrains_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            try
            {
                if (dgvOnlineTrains.CurrentCell.ColumnIndex == 2 && e.Control is TextBox textBox)
                {
                    textBox.MaxLength = 5;  // Limit input to 5 characters
                }
                else if (e.Control is TextBox tb)
                {
                    tb.MaxLength = 0; // Reset for other columns (no limit)
                }

                if (dgvOnlineTrains.CurrentCell.ColumnIndex == 2) // Replace with your column index
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress -= dgvOnlineTrains_KeyPress;
                        tb.KeyDown -= dgvOnlineTrains_KeyDown;

                        // Subscribe KeyPress event to restrict input to digits and backspace
                        tb.KeyPress += dgvOnlineTrains_KeyPress;

                        // Subscribe KeyDown event to listen for the Enter key
                        tb.KeyDown += dgvOnlineTrains_KeyDown;
                    }
                }

                if (dgvOnlineTrains.IsCurrentCellDirty)
                {
                    // Commit the edit to trigger the CellEndEdit event
                    dgvOnlineTrains.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    // Now handle saving the changes




                    if (dgvOnlineTrains.CurrentCell.ColumnIndex == dgvCdbColumn.Index)
                    {
                        if (e.Control is CheckBox chk)
                        {
                            // Unsubscribe the event to avoid multiple subscriptions
                            chk.CheckedChanged -= CheckBox_CheckedChanged;

                            // Subscribe to the CheckedChanged event
                            chk.CheckedChanged += CheckBox_CheckedChanged;
                        }
                    }


                }

                if (dgvOnlineTrains.CurrentCell.ColumnIndex == 8) // Assuming the time column is at index 1
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress -= new KeyPressEventHandler(TimeColumn_KeyPress);
                        tb.KeyPress += new KeyPressEventHandler(TimeColumn_KeyPress);
                    }



                }


                if (e.Control is ComboBox comboBox)
                {
                    // Remove any existing event handlers
                    comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;

                    // Add the SelectedIndexChanged event handler
                    comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void dgvOnlineTrains_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtLCoach1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach4_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach5_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach6_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach7_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach8_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach9_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach10_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach11_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach12_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach13_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach14_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach15_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach16_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach17_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach18_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach19_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach20_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach21_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach22_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach23_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach24_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach25_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach26_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach27_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach28_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForDuplicatesAndAllowOnlyLettersAndDigits_KeyPress(sender, e);
        }

        private void txtLCoach1_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach2_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach3_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach4_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach5_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach6_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach7_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach8_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach9_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach10_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach11_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach12_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach13_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach14_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach28_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach27_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach26_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach25_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach24_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach23_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach22_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach21_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach20_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach19_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach18_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach17_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach16_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void txtLCoach15_Leave(object sender, EventArgs e)
        {
            CheckForDuplicatesLinkedCoaches(sender, e);
        }

        private void tglNtesEnableDisable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async  void rbSave_Click(object sender, EventArgs e)
        {

            if (tglNtesEnableDisable.Checked)
            {

                

               NtesConfigurationSave(true);

               


            }
            else
            {
                NtesConfigurationSave(false);

            }
        

        }

        public async void NtesConfigurationSave(bool ntesEnabletrueorfalse)
        {
            try
            {
                AnnouncementController.UpdateStatus("STOP");
                AnnouncementController.UpdateAudioPlayStatus("Completed");
                AnnouncementController.OtherAudioPlaying = false;
                // Capture the values from the form controls






                bool ntesEnable = ntesEnabletrueorfalse;


                string urlType = "";
                string stationCode = "";
                int nextMins = 0;
                bool audio = false;
                bool autoMode = false;
                string custID = "";
                string custPass = ""; // Ensure this field is present on your form
                string custType = "";
                string url = "";
                string authtenticationToken = "";
                string PollMins = "";


                if (BaseClass.NTESCONFIGURATIONdt.Rows.Count > 0)
                {
                    DataRow row = BaseClass.NTESCONFIGURATIONdt.Rows[0];


                    urlType = row.Field<string>("UrlType");
                    stationCode = row.Field<string>("StationCode");
                    nextMins = Convert.ToInt32(row.Field<int>("NextMins").ToString());
                    audio = row.Field<bool>("Audio");
                    autoMode = row.Field<bool>("AutoMode");
                    custID = row.Field<string>("custID");
                    custPass = row.Field<string>("custPass");
                    custType = row.Field<string>("custType");
                    url = row.Field<string>("NtesUrl");
                    authtenticationToken = row.Field<string>("AuthenticationToken");
                    PollMins = row.Field<string>("PollingInterval");
                }

                // Validate the inputs
                if (string.IsNullOrEmpty(urlType) ||
                    string.IsNullOrEmpty(stationCode) ||

                    string.IsNullOrEmpty(custID) ||
                    string.IsNullOrEmpty(custPass) ||
                    string.IsNullOrEmpty(custType))
                {
                    MessageBox.Show("Please fill out all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataTable existedtrains = InterfaceDb.ClearNtesWebServiceTable();//clearing ntes webservice and scheduled tadb where ntes check not true


                frmOnlineTrains.DeleteTrains(existedtrains);

                //InterfaceDb.ClearScheduleTadb();


                // Call the InsertUpdateNtesConfiguration method with the validated values
                int result = InterfaceDb.InsertUpdateNtesConfiguration(ntesEnable, urlType, stationCode, nextMins, audio, autoMode, custID, custPass, custType, url, authtenticationToken,PollMins);

                // Show a message based on the result
                if (result >= 0)
                {

                    BaseClass.setNtesConfiguration();
                    Form mainForm = Application.OpenForms["frmHome"];

                    if (mainForm != null)
                    {
                        frmHome frmScheduled = (frmHome)mainForm;
                        frmScheduled.setNtesConnection();



                    }
                    //Hometab.setNtesConnection();


                    MessageBox.Show("NTES configuration updated successfully.");



                    if (BaseClass.IsNtesEnabled())
                    {
                        //online.WebRequest();
                        if (BaseClass.IsNtesAutoMode())
                        {
                            DataController.sendAllBoardsData();
                        }

                        if (BaseClass.IsNtesAudio())
                        {
                            AnnouncementController.UpdateStatus("STOP");
                            AnnouncementController.UpdateAudioPlayStatus("Completed");
                            AnnouncementController.OtherAudioPlaying = true;
                            BaseClass.AnnouncementCount = 1;

                            AnnouncementController.playAnnounceMentData();
                        }

                    }

                }
                else
                {
                    MessageBox.Show("No rows affected. Configuration might not have been updated.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            DataController.CheckTrainsLeftOrNotAndClaerData();
        }

        private void tglNtesEnableDisable_Click(object sender, EventArgs e)
        {

        }

        private void grbDisplayController_Enter(object sender, EventArgs e)
        {

        }

       

        private void dgvOnlineTrains_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Check if the editing cell is in the PF column
            if (e.ColumnIndex == dgvPFColumn.Index)
            {
                var currentRow = dgvOnlineTrains.Rows[e.RowIndex];

                // Ensure the CGDB checkbox exists and is checked
                if (currentRow.Cells["dgvCdbColumn"].Value != null &&
                    bool.TryParse(currentRow.Cells["dgvCdbColumn"].Value.ToString(), out bool cgdbChecked) &&
                    cgdbChecked)
                {
                    // Cancel editing
                    e.Cancel = true;

                    // Notify the user
                    MessageBox.Show("Platform cannot be changed when CGDB is selected.");

                    return;
                }
            }

            if ((e.RowIndex >= 0 && (dgvOnlineTrains.Columns[e.ColumnIndex].Name == "dgvTrNoColumn" || dgvOnlineTrains.Columns[e.ColumnIndex].Name == "dgvTrainColumn") && e.RowIndex <= dgvOnlineTrains.Rows.Count - 2))
            {
                e.Cancel = true;
            }
              
        }

        private void txtCoach1_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 1;
        }

       

        private void txtCoach2_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 2;
        }

        private void txtCoach3_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 3;
        }

        private void txtCoach4_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 4;
        }

        private void txtCoach5_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 5;
        }

        private void txtCoach6_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 6;
        }

        private void txtCoach7_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 7;
        }

        private void txtCoach8_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 8;
        }

        private void txtCoach9_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 9;
        }

        private void txtCoach10_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 10;
        }

        private void txtCoach11_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 11;
        }

        private void txtCoach12_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 12;
        }

        private void txtCoach13_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 13;
        }

        private void txtCoach14_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 14;
        }

        private void txtCoach15_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 15;
        }

        private void txtCoach16_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 16;
        }

        private void txtCoach17_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 17;
        }

        private void txtCoach18_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 18;
        }

        private void txtCoach19_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 19;
        }

        private void txtCoach20_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 20;
        }

        private void txtCoach21_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 21;
        }

        private void txtCoach22_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 22;
        }

        private void txtCoach23_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 23;
        }

        private void txtCoach24_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 24;
        }

        private void txtCoach25_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 25;
        }

        private void txtCoach26_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 26;
        }

        private void txtCoach27_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 27;
        }

        private void txtCoach28_Click(object sender, EventArgs e)
        {
            curretTextBoxTab = 28;
        }

        private void dgvOnlineTrains_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPlayCoaches_Click(object sender, EventArgs e)
        {
            try
            {


                if (AnnouncementController.OtherAudioPlaying)
                {
                    MessageBox.Show("Other Audio is playing");
                }
                else
                {


                    DialogResult dResult = MessageBox.Show("Do you want to play the audio?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dResult == DialogResult.No)
                    {
                        return;
                    }
                    BaseClass.AnnouncementCount = (int)nudAnnouncement.Value;

                    AnnouncementController.playAnnounceMentCoachesClassData(CurrentTrainNumber);
                    //BtnPause.Text = "Pause";
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void dgvOnlineTrains_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Check if it's the second column (index 1)
            if (e.ColumnIndex == 2)
            {
                string newValue = e.FormattedValue?.ToString() ?? "";

                if (newValue.Length > 5)
                {
                    MessageBox.Show("Only 5 characters are allowed .",
                                    "Validation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    e.Cancel = true; // Prevents leaving the cell until corrected
                }
            }
        }
    }
}

