using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms.AboutUsForms;
using ArecaIPIS.Forms.HomeForms;
using ArecaIPIS.Forms.settingsForms;
using ArecaIPIS.Forms.UserForms;
using ArecaIPIS.Forms.ViewForms;
using ArecaIPIS.Server_Classes;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmHome : Form
    {
        public static frmHome frmhome;
        private Form currentForm;

        public frmHome()
        {
            InitializeComponent();
            // OpenFormInPanel(new frmOnlineTrains(this));
            // panHeader.Dock = DockStyle.Fill;
        }
        private frmIndex parentForm;
        public frmHome(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;


        }

      


        private void NtesTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                UpddateNtesPollTime();


                frmOnlineTrains FrmOnlineTrains;
                Form mainForm = Application.OpenForms["frmOnlineTrains"];

                if (mainForm != null)
                {
                    FrmOnlineTrains = (frmOnlineTrains)mainForm;
                    FrmOnlineTrains.refreshOnlineTrains();

                    //FrmOnlineTrains.autoAnnounce();
                }
                else
                {
                    FrmOnlineTrains = new frmOnlineTrains();
                    FrmOnlineTrains.refreshOnlineTrains();

                }

                DataController.CheckTrainsLeftOrNotAndClaerData();
                if (BaseClass.IsNtesEnabled() && BaseClass.IsNtesAutoMode())
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
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
           
        }

        private void OpenFormInPanel(Form form)
        {
            if (currentForm != null)
            {
                currentForm.Close();
                currentForm.Dispose();
            }

            currentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panForms.Controls.Add(form);
            form.Show();

        }


        internal void ReplaceForm(Form newForm)
        {
            OpenFormInPanel(newForm);
        }
        private void btnFile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            // Check and update menu items based on design names
            CheckMenuItemsAgainstDesignNames(cmsFile, BaseClass.designNames);

            // Show the context menu strip at the location of the button

            cmsFile.Show(btnFile, new Point(0, btnFile.Height));
        }
        private void CheckMenuItemsAgainstDesignNames(ContextMenuStrip cms, List<string> designNames)
        {
            try
            {


                foreach (ToolStripItem item in cms.Items)
                {
                    // Check if the item name is in the list of design names
                    if (designNames.Contains(item.Name))
                    {
                        // Item name matches a design name
                        item.Visible = true; // Make item visible
                    }
                    else
                    {
                        // Item name does not match any design names
                        item.Visible = false; // Hide item if not matching
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateButton(sender);
                // Check and update menu items based on design names
                CheckMenuItemsAgainstDesignNames(cmsView, BaseClass.designNames);
                cmsView.Show(btnView, new Point(0, btnView.Height));
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        private void btnDiagnosis_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);// Check and update menu items based on design names
            CheckMenuItemsAgainstDesignNames(cmsDiagnosis, BaseClass.designNames);
            cmsDiagnosis.Show(btnDiagnosis, new Point(0, btnDiagnosis.Height));
        }

        private void btnVdc_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // Check and update menu items based on design names
            CheckMenuItemsAgainstDesignNames(cmsVDC, BaseClass.designNames);
            cmsVDC.Show(btnDiagnosis, new Point(0, btnFile.Height));
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);// Check and update menu items based on design names
            CheckMenuItemsAgainstDesignNames(cmsUser, BaseClass.designNames);
            cmsUser.Show(btnUser, new Point(0, btnFile.Height));
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);// Check and update menu items based on design names
            CheckMenuItemsAgainstDesignNames(cmsAboutUs, BaseClass.designNames);
            cmsAboutUs.Show(btnAboutUs, new Point(0, btnFile.Height));
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            try
            {
                InternetStatusMonitor.StartMonitoring();


                dateAndTimeTicker.Start();
                OnlineTrainsDao.UpdateAudioPlayStatus("Completed");
                LoadData();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }



        private async void LoadData()
        {
            try
            {


                BaseClass.SelectionRegionalLanguagesDt = StationConfigurationDb.GetRegionalLanguages();
                StationConfigurationDb.GetStationDetails();
                OnlineTrainsDao.UpdateDataTransferTofalse();
                BaseClass.Platforms = StationConfigurationDb.GetPlatforms();
                BaseClass.setLanguages();
                BaseClass.TrainTypes = TrainInformationDb.GetTrainTypes();
                BaseClass.setDisplayEffects();
                BaseClass.setLetterGap();
                BaseClass.setEntryEffect();
                BaseClass.setFontSize();
                BaseClass.setinfoDisplay();
                BaseClass.setFormatType();
                BaseClass.setFormats();
                BaseClass.setIVDOVDSpeed();
                BaseClass.setLetterSpeed();
                BaseClass.setMessageCharacterGap();
                BaseClass.setMessageFontSize();
                BaseClass.setVolume();
                BaseClass.setMediaType();
                BaseClass.setCoachBitMap();
                BaseClass.PacketIdentifier = BaseClassDb.GetPacketIdentifier();
                BaseClass.setCgdbBlank();
                BaseClass.SchedulestatusDt = BaseClassDb.GetScheduleStatus();
                BaseClass.setClearingEffects();
                BaseClass.setAdminRoles();
                BaseClass.setAdminMenu();
                BaseClass.GetAllTrainsNumbers();
                BaseClass.getIntegration();
                VisibleFeatures();
                BaseClass.setipAddress();
                BaseClass.setNtesConfiguration();
                BaseClass.setAutomaticRunning();
                BaseClass.GetLinkedTrainsList();
                MediaDb.DeletePlaylist();
                MediaDb.GetAllPlayLists();


                //frmCommonSettings.SetConfigurationBasedOnTime();

              await  SetConfigurationBasedOnTime();
                setHomePage();

                setCdot();
                PlayListTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public  async void setHomePage()
        {
            try
            {



                lblUserName.Text = BaseClass.UserName + "(" + BaseClass.Userrolename + ")";

                setipAddress();
                setStation();
                setDevices();
                 setNtesConnection();


                SlaveStatus();
                BaseClass.GetIndexForm();
                this.BeginInvoke(new Action(() =>
                {
                    BaseClass.indexForm.OpenFormInPanel(new frmOnlineTrains(BaseClass.indexForm));
                }));

            }
            catch (Exception ex)
            {
               Server.LogError(ex.ToString());
            }

        }
        public void setCdot()
        {
            try
            {


                BaseClass.setCdotData();

                if (BaseClass.IsCdotEnabled())
                {

                    if (CdotTimer.Enabled)
                    {
                        CdotTimer.Stop();
                    }

                    CdotTimer.Interval = Convert.ToInt32(BaseClass.CdotpollingTimeInterval) * 60 * 1000;

                    CdotTimer.Start();

                }
                else
                {
                    if (CdotTimer.Enabled)
                    {
                        CdotTimer.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public void setipAddress()
        {

            try
            {

                // Check if the control requires invoking
                if (ipAddressControlsystemaddress.InvokeRequired)
                {
                    // Use Invoke to marshal the call to the UI thread
                    ipAddressControlsystemaddress.Invoke((MethodInvoker)delegate
                    {
                        ipAddressControlsystemaddress.Text = Server.ipAdress;
                    });
                }
                else
                {
                    // If we're already on the UI thread, update the control directly
                    ipAddressControlsystemaddress.Text = Server.ipAdress;
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public void setStation()
        {
            lblDynamicStationName.Text = BaseClass.StationName;
        }


        frmOnlineTrains online ;


        public void SlaveStatus()
        {

            try
            {
                if (string.IsNullOrEmpty(DbConnection.SlaveconnectionString))
                {
                    LblSlaveStatus.Text = "Redundency(OFF)";
                }
                else
                {
                    LblSlaveStatus.Text = "Redundency(ON)";
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public async void  setNtesConnection()
        {
            try
            {
                Form form = Application.OpenForms["frmHome"];
                if (form != null)
                {
                    frmHome frm = (frmHome)form;
                    frm.UpddateNtesPollTime();
                }

                bool ntesConnection = BaseClass.IsNtesEnabled();

                if (ntesConnection)
                {
                    

                   
                    if (lblNtes.InvokeRequired)
                    {
                        lblNtes.Invoke((MethodInvoker)(() => lblNtes.Text = "NTES Enabled"));
                    }
                    else
                    {
                        lblNtes.Text = "NTES Enabled";
                    }


                    // Check if the timer is already running, and stop it if it is
                    if (NtesTimer.Enabled)
                    {
                        NtesTimer.Stop();
                    }
                    // Check if the timer is already running, and stop it if it is
                    if (LocalAutoModeTimer.Enabled)
                    {
                        LocalAutoModeTimer.Stop();
                    }
                    // Check if the timer is already running, and stop it if it is
                    if (LocalAutoDataDeletionTimer.Enabled)
                    {
                        LocalAutoDataDeletionTimer.Stop();
                    }
                    // Start the timer

                    NtesTimer.Interval = BaseClass.CurrentPollMins*60000;
                    NtesTimer.Start();

                    Form frmonline = Application.OpenForms["frmOnlineTrains"];
                    if(frmonline!=null)
                    {
                        online = (frmOnlineTrains)frmonline;

                        if (!BaseClass.ApllicationStart)
                        {

                            await Task.Run(async () =>
                            {
                                await online.WebRequestAsync(); // your method is already async
                            });
                        }
                    }
                    else
                    {
                        online = new frmOnlineTrains();
                        if (!BaseClass.ApllicationStart)
                        {

                            await Task.Run(async () =>
                            {
                                await online.WebRequestAsync(); // your method is already async
                            });
                        }
                    }


                    // Make the web request
                    
                   

                }
                else
                {
                    setLocalConnection();
                }
            }
            catch (Exception ex)
            {
                 Server.LogError(ex.Message);
            }
            
        }

        public void setLocalConnection()
        {
            try
            {


                if (!BaseClass.ApllicationStart)
                {
                    if(online==null)
                    {
                        Form form = Application.OpenForms["frmOnlineTrains"];

                        online=(frmOnlineTrains)form;
                    }
                    if (online == null)
                        online = new frmOnlineTrains();
                    online.setLocalData();
                }

                lblNtes.Text = "NTES Disabled";
                bool localAutoMode = BaseClass.IsLocalAutoMode();
                if (localAutoMode)
                {
                    // Check if the timer is already running, and stop it if it is
                    if (NtesTimer.Enabled)
                    {
                        NtesTimer.Stop();
                    }
                    if (LocalAutoModeTimer.Enabled)
                    {
                        LocalAutoModeTimer.Stop();
                    }

                    LocalAutoModeTimer.Interval = Convert.ToInt32(BaseClass.LocalAutoModeTimeInterval) * 60 * 1000;
                    LocalAutoModeTimer.Start();

                    bool localAutoDeletion = BaseClass.IsLocalAutoDeletion();
                    if (localAutoDeletion)
                    {

                        if (LocalAutoDataDeletionTimer.Enabled)
                        {
                            LocalAutoDataDeletionTimer.Stop();
                        }

                        LocalAutoDataDeletionTimer.Interval = Convert.ToInt32(BaseClass.LocalAutoDeletionTimeInterval) * 60 * 1000;
                        LocalAutoDataDeletionTimer.Start();
                    }
                }
                else
                {
                    if (NtesTimer.Enabled)
                    {
                        NtesTimer.Stop();
                    }
                    if (LocalAutoModeTimer.Enabled)
                    {
                        LocalAutoModeTimer.Stop();
                    }
                    if (LocalAutoDataDeletionTimer.Enabled)
                    {
                        LocalAutoDataDeletionTimer.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        public void setDevices()
        {

            try
            {
                // Get the total number of devices
                int NoOfDevices = totalDevices();

                // Get the number of currently connected devices
                int connectedDevices = Server._connectedClients.Count;



                // Check if the control requires invoking
                if (lblEtDeviceCount.InvokeRequired)
                {
                    // Use Invoke to marshal the call to the UI thread
                    lblEtDeviceCount.Invoke((MethodInvoker)delegate
                    {
                        // Update the label with the format "connectedDevices/NoOfDevices"
                        lblEtDeviceCount.Text = $"{connectedDevices}/{NoOfDevices}";
                    });
                }
                else
                {
                    // If we're already on the UI thread, update the control directly
                    // Update the label with the format "connectedDevices/NoOfDevices"
                    lblEtDeviceCount.Text = $"{connectedDevices}/{NoOfDevices}";
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        public static int totalDevices()
        {

            // Assuming BaseClassDb.GetNoOfDevices() returns a DataTable
            DataTable dt = BaseClassDb.GetNoOfDevices();

            // Check if the DataTable has data
            if (dt != null && dt.Rows.Count > 0)
            {
                // Assuming the first column contains the total count
                return Convert.ToInt32(dt.Rows[0][0]);
            }

            // Return 0 if the DataTable is empty or null
            return 0;
        }

        public async Task SetConfigurationBasedOnTime()
        {
            try
            {


                // Assuming GetAutoIntensitydt() returns a DataTable
                DataTable autoIntensityTable = CommonSettingsDb.GetAutoIntensitydt();

                // Check if the DataTable has rows
                if (autoIntensityTable.Rows.Count > 0)
                {
                    // Iterate through each row in the DataTable
                    foreach (DataRow row in autoIntensityTable.Rows)
                    {
                        // Extract values from each column
                        int pkey = Convert.ToInt32(row["Pkey"]);
                        bool autoIntensity = Convert.ToBoolean(row["AutoIntensity"]);
                        int dayIntensity = Convert.ToInt32(row["DayIntensity"]);
                        int nightIntensity = Convert.ToInt32(row["NightIntensity"]);
                        string fromTime = row["FromTime"].ToString();
                        string toTime = row["ToTime"].ToString();

                        if (autoIntensity)
                        {
                            // Parse the FromTime and ToTime as TimeSpan objects
                            TimeSpan fromTimeSpan = TimeSpan.Parse(fromTime);
                            TimeSpan toTimeSpan = TimeSpan.Parse(toTime);

                            // Get the current time as a TimeSpan
                            TimeSpan currentTimeSpan = DateTime.Now.TimeOfDay;

                            // Determine if the current time is within the "night" period
                            bool isNightTime = (fromTimeSpan < toTimeSpan)
                                ? (currentTimeSpan >= fromTimeSpan && currentTimeSpan < toTimeSpan) // Night period within the same day
                                : (currentTimeSpan >= fromTimeSpan || currentTimeSpan < toTimeSpan); // Night period crossing midnight

                            TimeSpan timeUntilNextChange;

                            if (isNightTime)
                            {
                                // Apply night intensity
                                BaseClass.SaveAutoIntensitytoAllBoards(nightIntensity);

                                // Calculate the time until the day mode should start
                                timeUntilNextChange = (fromTimeSpan < toTimeSpan)
                                    ? toTimeSpan - currentTimeSpan // Same day, time until night ends
                                    : ((currentTimeSpan < toTimeSpan) ? toTimeSpan : TimeSpan.FromDays(1) + toTimeSpan) - currentTimeSpan; // Crosses midnight
                            }
                            else
                            {
                                // Apply day intensity
                                BaseClass.SaveAutoIntensitytoAllBoards(dayIntensity);

                                // Calculate the time until the night mode should start
                                timeUntilNextChange = (fromTimeSpan < toTimeSpan)
                                    ? fromTimeSpan - currentTimeSpan // Same day, time until night starts
                                    : fromTimeSpan - currentTimeSpan; // Crosses midnight
                            }

                            // Ensure the calculated interval is non-zero and reasonable
                            int interval = (int)Math.Max(timeUntilNextChange.TotalMilliseconds, 1);

                            // Stop the timer if it's already running
                            AutoIntensityTimer.Stop();

                            // Set the timer interval
                            AutoIntensityTimer.Interval = interval;

                            // Start or restart the timer  m
                            AutoIntensityTimer.Start();
                            AutoSetConfigurationForAllBoards();
                        }
                    }
                }
                else
                {
                    // Handle the case where there are no rows in the DataTable
                    //  Console.WriteLine("No data available in AutoIntensity table.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public static void AutoSetConfigurationForAllBoards()
        {
            try
            {


                if (Server.ipAdress == null)
                {
                    return;
                }

                foreach (DataRow row in BaseClass.ipadressTable.Rows)
                {

                    string ipaddress = row["IPAddress"].ToString();
                    int packetIdentifier = Convert.ToInt32(row["PacketIdentifier"].ToString());
                    int cdcid = Convert.ToInt32(row["cdcId"].ToString());
                    if (packetIdentifier == 2)
                    {
                        var config = CgdbController.GetDatatimeoutAndIntensityPdcipCgdb(cdcid);
                        int datatimeout = config.datatimeout;
                        int intensity = config.intensity;
                        byte[] SetConfiguration = null;
                        string pdcip = config.pdcip;
                        if (BaseClass.Getinteroperabilitystatus(pdcip))
                        {

                            SetConfiguration = CgdbController.SetConfigurationCgdb(ipaddress, packetIdentifier, datatimeout, intensity);
                            SetConfiguration = ByteFormation.RemoveFirstAndLast6(SetConfiguration);
                        }
                        else
                        {
                            SetConfiguration = CgdbController.SetConfigurationCgdb(ipaddress, packetIdentifier, datatimeout, intensity);
                        }
                        Server.SendMessageToClient(ipaddress, SetConfiguration);
                    }
                    else if (packetIdentifier == 3 || packetIdentifier == 4 || packetIdentifier == 5)
                    {
                        byte[] SetConfiguration = null;
                        if (BaseClass.Getinteroperabilitystatus(ipaddress))
                        {
                            SetConfiguration = frmBoardDiagnosis.SetConfigurationTadb(ipaddress, packetIdentifier, cdcid);
                            SetConfiguration = ByteFormation.RemoveFirstAndLast6(SetConfiguration);
                        }
                        else
                        {
                            SetConfiguration = frmBoardDiagnosis.SetConfigurationTadb(ipaddress, packetIdentifier, cdcid);
                        }

                        Server.SendMessageToClient(ipaddress, SetConfiguration);
                    }

                    else if (packetIdentifier == 6 || packetIdentifier == 7)
                    {

                        DataTable dt = MediaDb.GetBorderColorConfiguration(cdcid);
                        byte[] SetConfiguration = null;
                        if (dt.Rows.Count > 0)
                        {
                            if (BaseClass.Getinteroperabilitystatus(ipaddress))
                            {
                                SetConfiguration = frmBoardDiagnosis.SetConfigurationOVDIVD(ipaddress, packetIdentifier, cdcid);
                                SetConfiguration = ByteFormation.RemoveFirstAndLast6(SetConfiguration);
                            }
                            else
                            {
                                SetConfiguration = frmBoardDiagnosis.SetConfigurationOVDIVD(ipaddress, packetIdentifier, cdcid);
                            }
                            Server.SendMessageToClient(ipaddress, SetConfiguration);
                        }
                    }
                    else
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }



        private void UpdateTimerInterval(DateTime targetTime)
        {
            try
            {


                // Get the current time
                DateTime currentTime = DateTime.Now;

                // Calculate the time span between current time and target time
                TimeSpan timeDifference = targetTime - currentTime;

                // Ensure the time difference is non-negative
                if (timeDifference.TotalMilliseconds > 0)
                {
                    // Set the timer interval to the time difference in milliseconds
                    AutoIntensityTimer.Interval = (int)timeDifference.TotalMilliseconds;
                }
                else
                {
                    // If the target time is in the past, set a default interval or handle as needed
                    AutoIntensityTimer.Interval = 60000; // Example: default to 60 seconds
                }

                // Restart the timer to apply the new interval
                AutoIntensityTimer.Stop();
                AutoIntensityTimer.Start();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private void dateAndTimeTicker_Tick(object sender, EventArgs e)
        {
            lblDateAndTime.Text = DateTime.Now.ToString("MMM dd, yyyy - HH:mm:ss");
        }

        private void btnOnlineTrains_Click(object sender, EventArgs e)
        {

            ActivateButton(sender);

            BaseClass.indexForm.OpenFormInPanel(new frmOnlineTrains(BaseClass.indexForm));
        }

        private void StationDetailsToolStrip_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmStationDetails(BaseClass.indexForm));
        }
        private void TrainInformationToolStrip_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmTrainInformation(BaseClass.indexForm));
        }

        private void toolStripBoardConfiguration_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmBoardConfiguration(BaseClass.indexForm));
            // OpenFormInPanel(new frmBoardConfiguration(this));

        }

        private void toolStripColorConfiguration_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmColorConfiguration(BaseClass.indexForm));
            // OpenFormInPanel(new frmColorConfiguration(this));

        }

        private void toolStripCCTVSettings_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmLcdTv(BaseClass.indexForm));
            // OpenFormInPanel(new frmLcdTv(this));
        }

        private void btnLcdTV_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //OpenFormInPanel(new frmLcdTv(this));
            BaseClass.indexForm.OpenFormInPanel(new frmLcdTv(BaseClass.indexForm));
        }

        private void btnNetwork_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            BaseClass.indexForm.OpenFormInPanel(new frmNetwork(BaseClass.indexForm));
            // OpenFormInPanel(new frmNetwork(this));

        }

        private void btnInterface_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // OpenFormInPanel(new frmInterface(this));
            BaseClass.indexForm.OpenFormInPanel(new frmInterface(BaseClass.indexForm));
        }

        private void toolStripBoardDiagnosis_Click(object sender, EventArgs e)
        {
            //  OpenFormInPanel(new frmBoardDiagnosis(this));
            BaseClass.indexForm.OpenFormInPanel(new frmBoardDiagnosis(BaseClass.indexForm));
        }

        private void btnCdot_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //OpenFormInPanel(new frmCdot(this));
            BaseClass.indexForm.OpenFormInPanel(new frmCdot(BaseClass.indexForm));
        }

        private void toolStripCreateUser_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmCreateUser(BaseClass.indexForm));
            //OpenFormInPanel(new frmCreateUser(this)); 
        }

        private void btnPA_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // OpenFormInPanel(new frmPa(this));
            BaseClass.indexForm.OpenFormInPanel(new frmPa(BaseClass.indexForm));
        }

        private void toolStripUserGroups_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmUserGroups(BaseClass.indexForm));
            // OpenFormInPanel(new frmUserGroups(this));
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            BaseClass.indexForm.OpenFormInPanel(new frmHelp(BaseClass.indexForm));
            //  OpenFormInPanel(new frmHelp(this));
        }

        private void toolStripAbout_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmAbout(BaseClass.indexForm));
            //OpenFormInPanel(new frmAbout(this));
        }

        private void toolStripIPISHelp_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmHelp(BaseClass.indexForm));
            //OpenFormInPanel(new frmHelp(this));
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            BaseClass.indexForm.OpenFormInPanel(new frmReports(BaseClass.indexForm));
            // OpenFormInPanel(new frmReports(this))
        }

        private void toolStripCommonSettings_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmCommonSettings(BaseClass.indexForm));
            // OpenFormInPanel(new frmCommonSettings(this));
        }

        private void toolStripRegionalLanguage_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmRegionalLanguageStatus(this));
        }

        private void toolStripDefectiveLines_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmDefectiveLinesTaddb(BaseClass.indexForm));
            // OpenFormInPanel(new frmDefectiveLinesTaddb(this));
        }

        private void toolStripAnnouncement_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmAnnounceMentScript(BaseClass.indexForm));
            // OpenFormInPanel(new frmAnnounceMentScript(this));

        }

        private void toolStripMessageScript_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmMessageScript(this));
        }

        private void toolStripPlayListConfiguration_Click(object sender, EventArgs e)
        {
            // OpenFormInPanel(new frmPlaylist(this));
            BaseClass.indexForm.OpenFormInPanel(new frmPlaylist(BaseClass.indexForm));
        }

        private void addStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmAddStation(this));
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            
            ActivateButton(sender);
            BaseClass.indexForm.OpenFormInPanel(new frmMessages(this));
        }

        private void btnIntensity_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            BaseClass.indexForm.OpenFormInPanel(new frmIntensity(BaseClass.indexForm));
            // OpenFormInPanel(new frmIntensity(this));
        }

        private void btnSlogans_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            BaseClass.indexForm.OpenFormInPanel(new frmSlogans(this));
        }

        private void toolStripLanguageSettings_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new FrmLanguageSettings(BaseClass.indexForm));
            // OpenFormInPanel(new FrmLanguageSettings(this));
        }

        private void toolStripRedundancyPc_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmRedundencyPc(BaseClass.indexForm));
            // OpenFormInPanel(new frmRedundencyPc(this));
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            BaseClass.indexForm.OpenFormInPanel(new frmLink(BaseClass.indexForm));
            // OpenFormInPanel(new frmLink(BaseClass.indexForm));
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //OpenFormInPanel(new frmPlaylist(this));
            BaseClass.indexForm.OpenFormInPanel(new frmPlaylist(BaseClass.indexForm));
        }

        private void addCoachDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmAddCoachData(this));
        }

        private void hubConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmHubConfiguration(BaseClass.indexForm));
            // OpenFormInPanel(new frmHubConfiguration(this));
        }

      

       

        private void cmsVDC_Opening(object sender, CancelEventArgs e)
        {

        }



        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // Check and update menu items based on design names
            CheckMenuItemsAgainstDesignNames(cmsSettings, BaseClass.designNames);
            cmsSettings.Show(btnFile, new Point(0, btnFile.Height));
        }

        private void btnLcdTV_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender);
            BaseClass.indexForm.OpenFormInPanel(new frmLcdTv(BaseClass.indexForm));
        }
        private void ActivateButton(object sender)
        {
            // Change the background color of all buttons
            foreach (var button in new[] { btnOnlineTrains, btnNetwork, btnPA, btnLink, btnLcdTV, btnInterface, btnIntensity, btnHelp, btnMedia, btnSetUp, btnSlogans, btnReports, btnCdot, btnMessages })
            {
                button.BackColor = Color.Transparent;
            }
            foreach (var button in new[] { btnFile, btnView, btnSettings, btnDiagnosis, btnVdc, btnUser, btnAboutUs })
            {
                button.BackColor = Color.Transparent;
            }
            // Change the background color of the clicked button
            var clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Gray;
        }

        private void VisibleFeatures()
        {
            try
            {


                int role = BaseClass.Userrole;
                BaseClass.designNames.Clear();
                string fkeyMenus = frmUserGroups.GetFkeysMenuByRole(role);
                List<int> fkeylist = frmUserGroups.GetPkListFromCheckedRows(fkeyMenus);

                DataTable dt = BaseClass.AdminMenussDt;

                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("Pkey_Menu") && int.TryParse(row["Pkey_Menu"].ToString(), out int Pkey_Menu))
                    {
                        if (fkeylist.Contains(Pkey_Menu))
                        {
                            string designname = row["DesignName"].ToString().Trim();
                            BaseClass.designNames.Add(designname);
                            // Assuming `designname` refers to a control's name, find the control and set its visibility
                            Control control = this.Controls.Find(designname, true).FirstOrDefault();
                            if (control != null)
                            {


                                control.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void DisableFeatures()
        {
            try
            {


                int role = BaseClass.Userrole;
                BaseClass.designNames.Clear();
                string fkeyMenus = frmUserGroups.GetFkeysMenuByRole(role);
                List<int> fkeylist = frmUserGroups.GetPkListFromCheckedRows(fkeyMenus);

                DataTable dt = BaseClass.AdminMenussDt;

                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("Pkey_Menu") && int.TryParse(row["Pkey_Menu"].ToString(), out int Pkey_Menu))
                    {

                        string designname = row["DesignName"].ToString().Trim();
                        BaseClass.designNames.Add(designname);
                        // Assuming `designname` refers to a control's name, find the control and set its visibility
                        Control control = this.Controls.Find(designname, true).FirstOrDefault();
                        if (control != null)
                        {


                            control.Visible = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }




        public static bool ContainsValue(List<int> list, int value)
        {
            // Check if the list contains the specified value
            return list.Contains(value);
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            try
            {

                PlayListTimer.Enabled = false;
                ReportDb.ApplogOffReport();
                DisableFeatures();
                // Close the current form (IndexForm)
                // this.Close();
                //frmIndex index = new frmIndex();
                //index.Close();
                //// Show the login form
                //frmLoginPage loginForm = new frmLoginPage();
                //loginForm.Show();
                BaseClass.indexForm.OpenFormInloginPanel(new frmLoginPage(BaseClass.indexForm));
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnSetUp_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            BaseClass.indexForm.OpenFormInPanel(new frmHubConfiguration(BaseClass.indexForm));
        }



        private async void LocalAutoModeTimer_Tick(object sender, EventArgs e)
        {
            try
            {


                // online. UpdateStatus("STOP");
                // online.UpdateAudioPlayStatus("Completed");
          setNtesConnection();


                // Call your method
                frmOnlineTrains FrmOnlineTrains;
                Form mainForm = Application.OpenForms["frmOnlineTrains"];

                if (mainForm != null)
                {
                    FrmOnlineTrains = (frmOnlineTrains)mainForm;
                    FrmOnlineTrains.refreshOnlineTrains();

                    //  FrmOnlineTrains.autoAnnounce();
                }


                DataController.sendAllBoardsData();

                AnnouncementController.UpdateStatus("STOP");
                AnnouncementController.UpdateAudioPlayStatus("Completed");
                AnnouncementController.OtherAudioPlaying = true;
                BaseClass.AnnouncementCount = 1;

                AnnouncementController.playAnnounceMentData();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void LocalAutoDataDeletionTimer_Tick(object sender, EventArgs e)
        {
            DeleteData();


        }


        public void DeleteData()
        {
            try
            {


                List<int> packetIdentifiers = new List<int> { 1, 3, 4, 5, 6, 7 };

                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);



                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in boards.Rows)
                {

                    string ipaddress = row["IPAddress"].ToString();
                    string PacketIdentifier = row["PacketIdentifier"].ToString();

                    if (PacketIdentifier == "1")
                    {
                        string pdcIp = ipaddress;
                        int packetidentifier = Board.CGDB;
                        StopCommand(pdcIp, packetidentifier);
                    }
                    else
                    {

                        byte[] DeleteDataPacket = frmBoardDiagnosis.DeleteData(ipaddress, Convert.ToInt32(PacketIdentifier));
                        Server.SendMessageToClient(ipaddress, DeleteDataPacket);
                    }


                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public void StopCommand(string PdcIp, int packetidentifier)
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

        private void lblEtDeviceCount_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);

            //// Check and update menu items based on design names
            //CheckMenuItemsAgainstDesignNames(cmsFile, BaseClass.designNames);

            //// Show the context menu strip at the location of the button

            //cmsFile.Show(btnFile, new Point(0, btnFile.Height));
        }

        private void btnFile_MouseEnter(object sender, EventArgs e)
        {
            ActivateButton(sender);

            // Check and update menu items based on design names
            CheckMenuItemsAgainstDesignNames(cmsFile, BaseClass.designNames);

            // Show the context menu strip at the location of the button

            cmsFile.Show(btnFile, new Point(0, btnFile.Height));
        }

        private void btnFile_MouseEnter_1(object sender, EventArgs e)
        {
            ActivateButton(sender);

            // Check and update menu items based on design names
            CheckMenuItemsAgainstDesignNames(cmsFile, BaseClass.designNames);

            // Show the context menu strip at the location of the button

            cmsFile.Show(btnFile, new Point(0, btnFile.Height));
        }



        private async void CdotTimer_Tick(object sender, EventArgs e)
        {

            string response = await Cdot.CDotWebRequest();

            HandleReceivedResponse(response);


            string dissmsnationstr = await Cdot.CdotDisseminationStatistics();
            HandleDisseminationResponse(dissmsnationstr);
        }

        public void HandleDisseminationResponse(string response)
        {
            try
            {


                // Remove escape characters (\"), replace <br/> with new lines, and handle True/False check
                response = response.Replace("\\\"", ""); // Removes the escaped double quotes
                response = response.Replace("<br/>", Environment.NewLine); // Replaces <br/> with new line

                if (response.Equals(""))
                {
                    // No need to show the message if "True" is present
                    return;
                }
                else
                {
                    // Show the formatted response in a message box
                    MessageBox.Show(response, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public void HandleReceivedResponse(string response)
        {
            try
            {


                // Remove escape characters (\"), replace <br/> with new lines, and handle True/False check
                response = response.Replace("\\\"", ""); // Removes the escaped double quotes
                response = response.Replace("<br/>", Environment.NewLine); // Replaces <br/> with new line

                if (response.Equals("true") || response.Equals(""))
                {
                    // No need to show the message if "True" is present
                    return;
                }
                else
                {
                    // Show the formatted response in a message box
                    MessageBox.Show(response, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataTable onlineTrainsDt = OnlineTrainsDao.GetTopScheduledTaddbRecords();
            frmOnlineTrains.DeleteTrains(onlineTrainsDt);

            OnlineTrainsDao.InsertScheduledRefreshData();
            BaseClass.indexForm.OpenFormInPanel(new frmOnlineTrains(BaseClass.indexForm));
        }

        private async void AutoIntensityTimer_Tick(object sender, EventArgs e)
        {
            // Call the asynchronous method to set intensity based on the time
            await SetConfigurationBasedOnTime();
        }



        private void PctApplicationClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PctMiniMize_Click(object sender, EventArgs e)
        {

            //  = FormWindowState.Minimized;

        }

        private void lblHeadingIpis_Click(object sender, EventArgs e)
        {

        }

        private void BtnApplicationExit_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
      "Do you want to close the application?",
      "Confirm Exit",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Question
  );

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Closes the application
            }
        }

        private void btnMinize_Click(object sender, EventArgs e)
        {
            frmIndex IndexForm;
            Form mainForm = Application.OpenForms["frmIndex"];

            if (mainForm != null)
            {
                IndexForm = (frmIndex)mainForm;

            }
            else
            {
                IndexForm = new frmIndex();

            }
            IndexForm.miniMizeWindow();
        }

        // HashSet to track sent playlists
        private HashSet<string> sentPlaylists = new HashSet<string>();

        private void PlayListTimer_Tick(object sender, EventArgs e)
        {
            // Get the current time
            DateTime currentDateTime = DateTime.Now;

            // Loop through the data table containing playlist details 
            foreach (DataRow row in BaseClass.MediaPlayListwithusername.Rows)
            {
                // Ensure the required columns exist in the DataTable
                if (BaseClass.MediaPlayListwithusername.Columns.Contains("StartHour") &&
                    BaseClass.MediaPlayListwithusername.Columns.Contains("StartMinute") &&
                    BaseClass.MediaPlayListwithusername.Columns.Contains("EndHour") &&
                    BaseClass.MediaPlayListwithusername.Columns.Contains("EndMinute") &&
                    BaseClass.MediaPlayListwithusername.Columns.Contains("Date"))
                {
                    try
                    {
                        // Extract playlist details
                        int startHour = int.Parse(row["StartHour"].ToString().Trim());
                        int startMinute = int.Parse(row["StartMinute"].ToString().Trim());
                        int endHour = int.Parse(row["EndHour"].ToString().Trim());
                        int endMinute = int.Parse(row["EndMinute"].ToString().Trim());
                        DateTime playlistDate = DateTime.Parse(row["Date"].ToString().Trim());
                        string playlistName = row["PlayListName"].ToString().Trim();
                        string uniqueKey = $"{playlistName}-{playlistDate}";

                        // Create start and end DateTime objects for comparison
                        DateTime startDateTime = new DateTime(playlistDate.Year, playlistDate.Month, playlistDate.Day, startHour, startMinute, 0);
                        DateTime endDateTime = new DateTime(playlistDate.Year, playlistDate.Month, playlistDate.Day, endHour, endMinute, 0);

                        if (currentDateTime >= endDateTime)
                        {
                            // If end time is over, call the delete method
                            string boardId = row["Boardid"].ToString().Trim();
                            string username = row["Username"].ToString().Trim();

                            DeletePlaylist(username, boardId, playlistName, playlistDate);
                            frmPlaylist.clearNormalModePlaylist(boardId);
                            // Remove from sent list since it's deleted
                            sentPlaylists.Remove(uniqueKey);
                            MediaDb.GetAllPlayLists();
                            frmPlaylist.MediaDatabyUsername.Rows.Clear();
                        }
                        else if (currentDateTime >= startDateTime && currentDateTime < endDateTime)
                        {
                            // If within the time range and not sent, send playlist details
                            if (!sentPlaylists.Contains(uniqueKey))
                            {
                                SendPlaylistDetails(row);
                                sentPlaylists.Add(uniqueKey); // Mark as sent
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Server.LogError(ex.Message);
                    }
                }
            }
        }

        // Method to delete a playlist
        private void DeletePlaylist(string username, string boardId, string playlistName, DateTime date)
        {
            // Implement the delete logic, calling the stored procedure or other method
            int rowsAffected = MediaDb.DeletePlaylist(username, boardId, playlistName, date);
            if (rowsAffected > 0)
            {
                Server.LogError($"Playlist '{playlistName}' deleted successfully.");

            }
            else
            {
                Server.LogError($"Failed to delete playlist '{playlistName}'.");

            }
        }

        // Method to send playlist details
        private void SendPlaylistDetails(DataRow row)
        {
            // Implement the logic to send playlist details
            string playlistName = row["PlayListName"].ToString().Trim();
            string boardId = row["Boardid"].ToString().Trim();
            string username = row["Username"].ToString().Trim();


            frmPlaylist.SendPlaylist(username, boardId, playlistName);
        }

       

        public void Checkinternet(bool b)
        {
            if(b)
            {
                OnInternetConnected();
            }
            else
            {
                OnInternetDisconnected();
            }
           

        }

        public bool ValidateDate(string dateTimedata)
        {
            DateTime inputDate;

            bool isValidFormat = DateTime.TryParseExact(
                dateTimedata,
                "dd/MM/yyyy HH:mm:ss",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out inputDate
            );

            if (!isValidFormat)
            {
                return false; // Invalid format
            }

            return inputDate.Date == DateTime.Today;
        }



        public void UpddateNtesPollTime()
        {
            string dateTimedata = OnlineTrainsDao.GetORUpdateLastPollTime();
            try
            {
                if (BaseClass.IsNtesEnabled())
                {
                  

                    string currentTime = DateTime.Now.ToString("HH:mm:ss");
                    string nowDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                  
                        if (lblNtesTime.InvokeRequired)
                        {
                            lblNtesTime.Invoke(new Action(() =>
                            {
                                lblNtesTime.Visible = true;
                                lblLastNtesUpdated.Visible = true;
                                lblNtesTime.Text = currentTime;
                            }));
                        }
                        else
                        {
                            lblLastNtesUpdated.Visible = true;
                            lblNtesTime.Visible = true;
                            lblNtesTime.Text = currentTime;
                        }

                    
                    // Update the LastPollingUpdatedTime column in DB
                    OnlineTrainsDao.GetORUpdateLastPollTime(nowDateTime);
                }
                else
                {
                    
                   
                    if (!string.IsNullOrWhiteSpace(dateTimedata))
                    {
                        DateTime inputDate = DateTime.ParseExact(dateTimedata, "dd/MM/yyyy HH:mm:ss", null);

                        if (ValidateDate(dateTimedata))
                        {
                            if (lblNtesTime.InvokeRequired)
                            {
                                lblNtesTime.Invoke(new Action(() =>
                                {
                                    lblNtesTime.Visible = true;
                                    lblLastNtesUpdated.Visible = true;
                                    lblNtesTime.Text = inputDate.ToString(" HH:mm:ss");
                                }));
                            }
                            else
                            {
                                lblNtesTime.Visible = true;
                                lblLastNtesUpdated.Visible = true;
                                lblNtesTime.Text = inputDate.ToString(" HH:mm:ss");
                            }
                        }
                        else
                        {
                            if (lblNtesTime.InvokeRequired)
                            {
                                lblNtesTime.Invoke(new Action(() =>
                                {
                                    lblNtesTime.Visible = false;
                                    lblLastNtesUpdated.Visible = false;
                                }));
                            }
                            else
                            {
                                lblNtesTime.Visible = false;
                                lblLastNtesUpdated.Visible = false;
                            }
                        }
                    }

                }

               
            }
            catch (Exception ex)
            {
                Server.LogError("UpddateNtesPollTime Error: " + ex.ToString());
            }
        }





        private  void OnInternetConnected()
        {

            if (pctInterNet.InvokeRequired)
            {
                pctInterNet.Invoke((MethodInvoker)delegate
                {
                    pctInterNet.BackgroundImage = Properties.Resources.wifi;
                });
            }
            else
            {
                pctInterNet.BackgroundImage = Properties.Resources.wifi;
            }
        }

        private  void OnInternetDisconnected()
        {
            if (pctInterNet.InvokeRequired)
            {
                pctInterNet.Invoke((MethodInvoker)delegate
                {
                    pctInterNet.BackgroundImage = Properties.Resources.notWifi;
                });
            }
            else
            {
                pctInterNet.BackgroundImage = Properties.Resources.notWifi;
            }

        }

        private void lblNtes_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSoftwareUpdate_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmSoftwareUpdate(BaseClass.indexForm));
        }

        private void toolStripUpdateSoftware_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmSoftwareUpdate(BaseClass.indexForm));
        }

        private void toolStripAdditionalSettings_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmAdditionalSettings(BaseClass.indexForm));
        }

        private void LblSlaveStatus_Click(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
