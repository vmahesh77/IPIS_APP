using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms;
using ArecaIPIS.Server_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArecaIPIS
{
    public partial class frmPdcConfiguration : Form
    {
        public string dynamicPortNo { get; set; }
        public int PkNumber { get; set; }
        int ID;


        public frmPdcConfiguration()
        {
            InitializeComponent();


        }
        public void SetPkHubValue(int pkvalue)
        {
            PkNumber = pkvalue;
        }
        private void PdcConfiguration_Load(object sender, EventArgs e)
        {
            cmbNoofports.SelectedIndex = 0;
            SetPlatforms();
            GetDetailsByPk();

        }
        private void GetDetailsByPk()
        {
            try
            {


                if (PkNumber != 0)
                {

                    foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                    {
                        if (BaseClass.EthernetPorts.Columns.Contains("PkeyMasterhub") && int.TryParse(row["PkeyMasterhub"].ToString(), out int PkMasterHub))
                        {
                            if (PkMasterHub == PkNumber)
                            {
                                cmbSelectPfno.Text = row["Platform"].ToString();
                                cmbNoofports.Text = row["NoofPorts"].ToString();
                                ipAddressControlplatform.Text = row["IPAddress"].ToString();
                                txtLocation.Text = row["Location"].ToString();
                                txtportno.Text = row["PortNo"].ToString();
                                tglinteroperability.Checked = row["interoperability"] != DBNull.Value && (bool)row["interoperability"];

                                ID = PkNumber;
                            }
                        }
                    }
                }
                else
                {
                    ID = -1;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {

        }
        public void SetPassedValue(Button button)
        {
            try
            {


                // Extract the numerical part from the button's name
                string buttonName = button.Name;
                string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

                // Convert the numeric part to an integer

                dynamicPortNo = numericPart;

                // Optionally, use the value immediately or update some controls with this value
                txtportno.Text = dynamicPortNo; // Assuming you have a textbox to display the value

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        private void SetPlatforms()
        {
            try
            {


                // Clear existing items in the ComboBox
                cmbSelectPfno.Items.Clear();

                // Add the default item "--Select--"
                cmbSelectPfno.Items.Add("--Select--");

                // Assuming BaseClass.Platforms is a collection of platform names
                foreach (var platform in BaseClass.Platforms)
                {
                    // Trim the platform name
                    string trimmedPlatform = platform.Trim();

                    // Add the trimmed platform name to the ComboBox
                    cmbSelectPfno.Items.Add(trimmedPlatform);
                }

                // Select the default item "--Select--"
                cmbSelectPfno.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void cmbSelectPfno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                // Get the selected platform from the ComboBox
                string platform = cmbSelectPfno.Text.Trim();


                // Check if the selected item is not the default "--Select--"
                if (platform != "--Select--")
                {

                    string thirdOctet = BaseClass.ConvertPlatformToIp(platform);


                    string ipAddress = $"192.168.{thirdOctet}.251";


                    ipAddressControlplatform.Text = ipAddress;

                }
                else
                {
                    // Handle the case where the default item "--Select--" is selected
                    ipAddressControlplatform.Text = string.Empty; // Clear the IP address field
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



                string PlatformNo = cmbSelectPfno.Text;
                string noOfPorts = cmbNoofports.Text;
                string ipAddress = ipAddressControlplatform.Text;
                string Location;
                int packetidentifier = 1;
                bool interoperabilitystatus = tglinteroperability.Checked;
                const string defaultSelection = "--Select--";
                if (ID != -1)
                {
                    Location = txtLocation.Text.Trim();
                }
                else
                {
                    Location = txtLocation.Text.Trim() + "_Pdc";
                }

                // Check for null, empty, or default selection fields
                if (string.IsNullOrEmpty(PlatformNo) || PlatformNo == defaultSelection || lblPlatformError.Visible == true)
                {
                    MessageBox.Show("Please select a valid platform number.");
                    return;
                }

                if (string.IsNullOrEmpty(txtportno.Text))
                {
                    MessageBox.Show("Please enter a port number.");
                    return;
                }

                int PortNo;
                if (!int.TryParse(txtportno.Text, out PortNo))
                {
                    MessageBox.Show("Please enter a valid port number.");
                    return;
                }

                if (string.IsNullOrEmpty(noOfPorts) || noOfPorts == defaultSelection)
                {
                    MessageBox.Show("Please select the number of ports.");
                    return;
                }

                if (string.IsNullOrEmpty(ipAddress))
                {
                    MessageBox.Show("Please enter an IP address.");
                    return;
                }

                if (string.IsNullOrEmpty(Location))
                {
                    MessageBox.Show("Please enter a location.");
                    return;
                }

                // Show confirmation dialog
                DialogResult result = MessageBox.Show("Do you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user clicks Yes, proceed with saving the data
                if (result == DialogResult.Yes)
                {
                    int rows = HubConfigurationDb.SavePdcData(ID, PlatformNo, 0, noOfPorts, ipAddress, Location, PortNo, packetidentifier, interoperabilitystatus);

                    if (rows >= 0)
                    {
                        ReportDb.InsertDatabaseModificationReportData("Pdc Added For Platform " + PlatformNo, "4");
                        BaseClass.RecallBoards();
                        this.Close();
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


        private void cmbNoofports_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmPdcConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {


                frmHubConfiguration frmhub;
                Form mainForm = Application.OpenForms["frmHubConfiguration"];

                if (mainForm != null)
                {
                    frmhub = (frmHubConfiguration)mainForm;
                    frmhub.ClearPanel();


                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        private void ipAddressControlplatform_TextChanged(object sender, EventArgs e)
        {

            try
            {


                // Get the selected platform from the ComboBox
                string iptext = ipAddressControlplatform.Text.Trim();
                string ExistedIp = "";
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("PkeyMasterhub") && int.TryParse(row["PkeyMasterhub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == PkNumber)
                        {
                            ExistedIp = row["IPAddress"].ToString();
                        }

                    }
                }
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                    {
                        string Ipaddress = row["IPAddress"].ToString();

                        if (iptext == Ipaddress && iptext != ExistedIp)
                        {
                            lblPlatformError.Visible = true;
                            return;
                        }
                        else
                        {
                            lblPlatformError.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        private void btnSetConfiguration_Click(object sender, EventArgs e)
        {

            try
            {


                string pdcip = ipAddressControlplatform.Text.Trim();
                int portno = Convert.ToInt32(txtportno.Text.Trim());
                int pdcPacketno = Board.PDC;


                List<string> listOfIps = CgdbController.GetConfigureBoards(pdcip, portno);

                int i = 2;

                byte[] pdcData = new byte[listOfIps.Count * 3 + 2];
                pdcData[0] = (byte)listOfIps.Count;
                pdcData[1] = 0;

                foreach (var BoardIp in listOfIps)
                {


                    (int packet, int Ip, int port) = BaseClass.GetPacketIdentifier(BoardIp);

                    pdcData[i] = (byte)Ip;
                    pdcData[++i] = (byte)packet;
                    pdcData[++i] = 0;
                    i++;
                }
                if (Server._connectedClients.Count > 0)
                {
                    string broadCastIp = Server.GetBroadcastIp(pdcip);
                    byte[] SetConfigurationPacket = frmBoardDiagnosis.SetConfigurationPdc(pdcip, pdcPacketno, pdcData);


                    Server.SendDataToPdc(pdcip, SetConfigurationPacket);
                    System.Threading.Thread.Sleep(5000);
                    // Get the received bytes from the server
                    byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                    // Check if received bytes are empty
                    if (serverReceivedBytes.Length <= 19)
                    {

                        // MessageBox.Show("SET CONFIGURATION failed", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        lblSave.Text = "SET CONFIGURATION failed";
                    }
                    else
                    {
                        byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                        byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(SetConfigurationPacket);

                        bool linkSucess = ByteFormation.validateSetConfiguration(trimmedserverReceivedBytes, trimmedLinkCheckPacket);


                        if (!linkSucess)
                        {
                            lblSave.Text = "SET CONFIGURATION failed";
                            lblSave.ForeColor = Color.Red;
                            //  MessageBox.Show("SET CONFIGURATION failed", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Initialize receivedBytes with the same length as serverReceivedBytes
                            byte[] receivedBytes = new byte[trimmedserverReceivedBytes.Length];

                            // Copy data from serverReceivedBytes to receivedBytes
                            Array.Copy(trimmedserverReceivedBytes, receivedBytes, trimmedserverReceivedBytes.Length);

                            // Convert received bytes to a string for displaying in a message box
                            string receivedData = Encoding.ASCII.GetString(receivedBytes);

                            // Convert received bytes to a hexadecimal string for displaying
                            string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");


                            lblSave.Text = "Set Configuration Excuted Sucessfully";
                            lblSave.ForeColor = Color.Green;

                        }
                    }


                }

                // Make the label visible
                lblSave.Visible = true;

                // Start a timer to clear the label after 10 seconds
                Timer timer = new Timer();
                timer.Interval = 2000; // 5 seconds
                timer.Tick += (s, _) =>
                {
                    // Clear the label text and hide the label
                    lblSave.Text = "";
                    lblSave.Visible = false;

                    // Stop and dispose the timer
                    timer.Stop();
                    timer.Dispose();
                    //this.Close();

                };
                timer.Start(); // Start the timer

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }



        private void btnGetConfiguration_Click(object sender, EventArgs e)
        {
            try
            {


                string pdcip = ipAddressControlplatform.Text.Trim();
                int portno = Convert.ToInt32(txtportno.Text.Trim());
                int pdcPacketno = Board.PDC;

                List<string> listOfIps = CgdbController.GetConfigureBoards(pdcip, portno);


                int serialno = 0;
                foreach (string ip in listOfIps)
                {
                    (int packet, int Ip, int port) = BaseClass.GetPacketIdentifier(ip);

                    int portNo = port;
                    string cgdbIpAddress = ip;
                    // int packetIdentifier = packet;
                    string BoardType = BaseClass.GetPacketname(packet);
                    // Add rows to the DataGridView
                    dgvPdcPorts.Rows.Add(portNo, cgdbIpAddress, BoardType);
                }



                try
                {

                    // (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                    //if (hasBoard)
                    //{
                    if (Server._connectedClients.Count > 0)
                    {
                        string broadCastIp = Server.GetBroadcastIp(pdcip);
                        byte[] LinkCheckPacket = frmBoardDiagnosis.GetConfiguration(pdcip, pdcPacketno);
                        Server.SendMessageToClient(pdcip, LinkCheckPacket);
                        System.Threading.Thread.Sleep(5000);
                        // Get the received bytes from the server
                        byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                        // Check if received bytes are empty
                        if (serverReceivedBytes.Length <= 10)
                        {
                            lblSave.Text = "GET CONFIGURATION failed";
                            //MessageBox.Show("Get configuration failed", "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);

                            bool linkSucess = ByteFormation.validateGetConfiguration(trimmedserverReceivedBytes, trimmedLinkCheckPacket);


                            if (!linkSucess)
                            {
                                lblSave.Text = "GET CONFIGURATION failed";
                                //MessageBox.Show("Get configuration failed", "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                // Initialize receivedBytes with the same length as serverReceivedBytes
                                byte[] receivedBytes = new byte[trimmedserverReceivedBytes.Length];

                                // Copy data from serverReceivedBytes to receivedBytes
                                Array.Copy(trimmedserverReceivedBytes, receivedBytes, trimmedserverReceivedBytes.Length);

                                // Convert received bytes to a string for displaying in a message box
                                string receivedData = Encoding.ASCII.GetString(receivedBytes);

                                // Convert received bytes to a hexadecimal string for displaying
                                string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");
                                string intensity = frmBoardDiagnosis.GetIntensity(receivedBytes[12]);
                                string dataTimeout = frmBoardDiagnosis.GetDataTimeout(receivedBytes[13]);
                                lblSave.Text = "Get Command Excuted Sucessfully";

                            }

                        }


                        // Make the label visible
                        lblSave.Visible = true;

                        // Start a timer to clear the label after 10 seconds
                        Timer timer = new Timer();
                        timer.Interval = 2000; // 5 seconds
                        timer.Tick += (s, _) =>
                        {
                            // Clear the label text and hide the label
                            lblSave.Text = "";
                            lblSave.Visible = false;

                            // Stop and dispose the timer
                            timer.Stop();
                            timer.Dispose();

                        };
                        timer.Start(); // Start the timer

                    }
                }
                catch (Exception ex)
                {
                    Server.LogError(ex.Message);
                }


            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }



    }
}
