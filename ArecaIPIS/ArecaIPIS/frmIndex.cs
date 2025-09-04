using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms;
using ArecaIPIS.Classes;
using ArecaIPIS.Forms.settingsForms;
using System.Threading;

namespace ArecaIPIS
{
    public partial class frmIndex : Form
    {
        private Form headerCurrentForm;
        private Form currentForm;
        public frmIndex()
        {
            InitializeComponent();
           
        }
      
        private frmIndex parentForm;
      
        public frmIndex(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }


        public void ChangeStartLocation()
        {
            // Get the screen working area (current monitor's bounds minus taskbar, etc.)
            Rectangle workingArea = Screen.FromControl(this).WorkingArea;

            // Position the form at the top center of the screen
            int x = (workingArea.Width - this.Width) / 2 + workingArea.Left;
            int y = workingArea.Top;

            // Set the form's location
            this.Location = new Point(x, y);

            // Optionally, set the StartPosition to Manual to ensure your location setting takes effect
            this.StartPosition = FormStartPosition.Manual;
        }
        private  void frmIndex_Load(object sender, EventArgs e)
        {
            try
            {
                ChangeStartLocation();

                Server.CheckNetworkAvailability();
               
                timerslavestatus.Enabled = true;
                if (string.IsNullOrEmpty(Server.ipAdress))
                {
                    Server.StartServer();
                  
                    BaseClass.ServerMode = true;

                    BaseClass.ApplicationStatus = true;
                    InsertServerConfiguration();
                    BaseClass.GetIndexForm();
                   
                    loginForm();
                    BaseClass.RecallBoards();
                }
                else
                {
                    Server.GetSlaveip();
                    bool SlaveConnect = Server.IsIpAddressConnected(Server.SlaveipAdress);
                    if (SlaveConnect)
                    {
                        BaseClass.SlaveConnect = true; 
                        DbConnection.SlaveconnectionString = DbConnection.GetSlaveConnectionString(Server.SlaveipAdress);
                        if (!string.IsNullOrEmpty(DbConnection.SlaveconnectionString))
                        {
                            GetClientStatus();
                        }
                       if (BaseClass.SlaveApplicationStatus == false && BaseClass.SlaveServermode == false)
                         {
                                Server.StartServer();

                                BaseClass.ServerMode = true;

                                BaseClass.ApplicationStatus = true;

                                InsertServerConfiguration();
                                BaseClass.GetIndexForm();

                                loginForm();
                                BaseClass.RecallBoards();
                            }
                            else if (BaseClass.SlaveApplicationStatus == true && BaseClass.Slaveclientmode == true)
                            {
                                Server.StartServer();

                                BaseClass.ServerMode = true;

                                BaseClass.ApplicationStatus = true;

                                InsertServerConfiguration();
                                BaseClass.GetIndexForm();

                                loginForm();
                                BaseClass.RecallBoards();
                            }


                            else if (BaseClass.SlaveApplicationStatus == true && BaseClass.SlaveServermode == true)
                            {
                                ClientForm();
                            }


                        
                        

                    }
                    else
                    {
                        Server.StartServer();
                        BaseClass.ServerMode = true;
                        BaseClass.ApplicationStatus = true;

                        InsertServerConfiguration();
                        BaseClass.GetIndexForm();
                     
                        loginForm();
                        BaseClass.RecallBoards();
                    }

                }

            }
            catch(Exception ex)
            {
                Server.LogError("frmIndex_Load :" + ex.ToString());
            }


        }
      
            public void ClientForm()
        {

            try
            {
            
                BaseClass.ServerMode = false;

                BaseClass.clientMode = true;
             

                BaseClass.ApplicationStatus = true;


                OpenFormInloginPanel(new frmClientMode(this));
                InsertServerConfiguration();
                //Server.StopServer();
            }catch(Exception ex)
            {
                ex.ToString();
            }
          
        }
        public void LoadingServer()
        {

            try
            {

                OpenFormInloginPanel(new FrmLoading(this));

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }

        }
        public async void loginForm()
        {


             LoadingServer();
          await Task.Delay(30000);
            OpenFormInloginPanel(new frmLoginPage(this));

           
        }
        public void LoadForms()
        {
            // Debugging: Check if the panels are not null
            if (panLogin == null || panForms == null || panHeader == null)
            {
                MessageBox.Show("Panels not initialized.");
                return;
            }

            // Debugging: Ensure the panels are visible and in the correct order
            panLogin.Visible = false;
            panLogin.SendToBack();
            panForms.BringToFront();
            panHeader.BringToFront();
            panForms.Visible = true;
            panHeader.Visible = true;

            // Debugging: Check if the form is being created and loaded properly
            var homeForm = new frmHome(this);
            if (homeForm == null)
            {
                MessageBox.Show("Home form is not initialized.");
                return;
            }

            OpenFormInHeaderPanel(homeForm);
        }





        public void OpenFormInHeaderPanel(Form form)
        {
            if (headerCurrentForm != null)
            {
                headerCurrentForm.Close();
                headerCurrentForm.Dispose();
            }

            headerCurrentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panHeader.Controls.Add(form);
            form.Show();

        }

        public void OpenFormInloginPanel(Form form)
        {



            panLogin.Visible = true;
            panHeader.Visible = false;
            panForms.Visible = false;

            if (headerCurrentForm != null)
            {
                headerCurrentForm.Close();
                headerCurrentForm.Dispose();
            }

            headerCurrentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panLogin.Controls.Add(form);
            form.Show();

        }
        public void OpenFormInPanel(Form form)
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

     
                        
        private void frmIndex_FormClosing(object sender, FormClosingEventArgs e)
        {

          
                    BaseClass.clientMode = false;
                    BaseClass.ApplicationStatus = false;
                   BaseClass.ServerMode = false;

                    InsertServerConfiguration();
                   Server.StopServer();
            Task.Delay(10000);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void GetClientConfiguration()
        {
            try
            {

                DataTable Dt = RedundencyDb.GetClientDetails();

                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    BaseClass.ApplicationStatus = row.Field<bool>("ApplicationStatus");
                  

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public static void GetServerConfiguration()
        {
            try
            {

                DataTable Dt = RedundencyDb.GetServerDetails();

                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                  //  BaseClass.ServerStatus = row.Field<bool>("ServerActive");
                   

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public static void InsertIntoServerConfiguration()
        {
            try
            {
              
                RedundencyDb.InsertUpdateServerStatus(BaseClass.ServerMode, BaseClass.clientMode, BaseClass.ApplicationStatus,Server.ipAdress, Server.SlaveipAdress);
            }
            catch (Exception ex)
            {
                Server.LogError($"Error inserting server configuration: {ex.Message}");
            }
        }


        public static void InsertServerConfiguration()
        {
            try
            {
                // Get the slave IP address
                string clientIp = Server.SlaveipAdress;

               
                string serverIp = Server.ipAdress;
                if (string.IsNullOrEmpty(serverIp))
                {
                    serverIp = "192.168.0.254"; 
                }
                if (string.IsNullOrEmpty(clientIp))
                {
                    clientIp = "192.168.0.253"; 
                }


               
                RedundencyDb.InsertUpdateServerStatus(BaseClass.ServerMode, BaseClass.clientMode,BaseClass.ApplicationStatus, serverIp, clientIp);
            }
            catch (Exception ex)
            {
                Server.LogError($"Error inserting server configuration: {ex.Message}");
            }
        }

      



        public async void masterSlaveChecking()
        {
            bool serverConnect = Server.IsIpAddressConnected(Server.ipAdress);

            if (serverConnect)
            {
                Server.GetSlaveip();

                if (!BaseClass.clientMode)
                {


                    bool slaveConnect = Server.IsIpAddressConnected(Server.SlaveipAdress);


                    if (!slaveConnect)
                    {
                        DbConnection.SlaveconnectionString = "";
                        GetSlaveStatusUpdate();
                        BaseClass.SlaveConnect = false;

                    }
                    else
                    {
                        if (BaseClass.SlaveConnect)
                        {

                            DbConnection.SlaveconnectionString = DbConnection.GetSlaveConnectionString(Server.SlaveipAdress);
                            GetClientStatus();

                            if (BaseClass.SlaveApplicationStatus)
                            {
                                if (BaseClass.Slaveclientmode)
                                {

                                }
                                else if (BaseClass.SlaveServermode)
                                {
                                    DbConnection.SlaveconnectionString = "";
                                    if (Server.ipAdress == "192.168.0.254")
                                    {
                                        OpenFormInloginPanel(new frmClientMode(this));
                                        BaseClass.clientMode = true;
                                        BaseClass.ServerMode = false;
                                    }
                                    else
                                    {

                                        GetSlaveStatusUpdate();

                                        if (string.IsNullOrEmpty(BaseClass.UserName))
                                        {
                                            OpenFormInloginPanel(new frmLoginPage(this));
                                            BaseClass.clientMode = false;
                                            BaseClass.ServerMode = true;

                                        }
                                        else
                                        {
                                            if (Server._isRunning)
                                            {
                                                BaseClass.indexForm.OpenFormInPanel(new frmRedundencyPc(BaseClass.indexForm));
                                                BaseClass.clientMode = false;
                                                BaseClass.ServerMode = true;
                                            }
                                            else
                                            {

                                            }
                                           


                                        }
                                    }
                                    InsertServerConfiguration();
                                }

                            }

                        }
                        else
                        {
                            DbConnection.SlaveconnectionString = "";
                            BaseClass.SlaveConnect = true;
                            GetClientStatus();
                            GetSlaveStatusUpdate();
                            if (Server._isRunning)
                            {
                                BaseClass.indexForm.OpenFormInPanel(new frmRedundencyPc(BaseClass.indexForm));
                                BaseClass.clientMode = false;
                                BaseClass.ServerMode = true;
                            }
                            else
                            {
                                Server.StartServer();
                            }
                        }


                    }

                }
                else
                {
                    GetClientStatus();
                    if (!BaseClass.SlaveApplicationStatus)
                    {


                        BaseClass.ApplicationStatus = true;
                        BaseClass.ServerMode = true;
                        BaseClass.clientMode = false;
                        DbConnection.SlaveconnectionString = DbConnection.GetSlaveConnectionString(Server.SlaveipAdress);

                        await Task.Delay(30000);
                        Server.StartServer();
                        LoadingServer();
                        await Task.Delay(30000);
                        OpenFormInloginPanel(new frmLoginPage(this));
                        BaseClass.clientMode = false;
                        BaseClass.ServerMode = true;


                        InsertServerConfiguration();




                    }

                }

            }
            else
            {

                DbConnection.SlaveconnectionString = "";
                GetSlaveStatusUpdate();
            }

        }

        private  void timerslavestatus_Tick(object sender, EventArgs e)
        {
            
            try
            {
                masterSlaveChecking();
             // Offload the work to a background thread
             //  await Task.Run(() => masterSlaveChecking());
            }
            catch (Exception ex)
            {
                // Handle exceptions to prevent crashes
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        public static bool GetClientApplicationStatus()
        {
            bool status = true;
            try
            {

                DataTable Dt = RedundencyDb.GetClientDetails();


                

                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    status = row.Field<bool>("ApplicationStatus");

                }
                return status;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return status;
            }
        }

        public static void GetSlaveStatusUpdate()
        {

            Form mainForm = Application.OpenForms["frmHome"];

            if (mainForm != null)
            {
                frmHome frmhome = (frmHome)mainForm;
                frmhome.SlaveStatus();
            }
        }



            public static void GetClientStatus()
        {
   
            try
            {

                DataTable Dt = RedundencyDb.GetClientDetails();
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        DataRow row = Dt.Rows[0];
                        BaseClass.SlaveApplicationStatus = row.Field<bool>("ApplicationStatus");
                        BaseClass.Slaveclientmode = row.Field<bool>("ClientActive");
                        BaseClass.SlaveServermode = row.Field<bool>("ServerActive");

                    }
                }
                
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
               
            }
        }

        private void PctApplicationClose_Click(object sender, EventArgs e)
        {
           
        }

        private void PctMiniMize_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMinize_Click(object sender, EventArgs e)
        {
            miniMizeWindow();
        }
        public void miniMizeWindow()
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void BtnApplicationExit_Click(object sender, EventArgs e)
        {
        }

      

        private void picLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
