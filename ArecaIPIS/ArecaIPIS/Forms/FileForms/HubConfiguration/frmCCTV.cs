using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ArecaIPIS
{
    public partial class frmCCTV : Form
    {
        public frmCCTV()
        {
            InitializeComponent();
        }
        public int ethernetPortNo { get; set; }
        public int PkNumber { get; set; }
        public int PdcPortNo { get; set; }
        Button board;
        int ID;
        public void SetPassedValue(Button button)
        {
            // Extract the numerical part from the button's name
            board = button;
            string buttonName = button.Name;
            string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

            // Convert the numeric part to an integer

            ethernetPortNo = Convert.ToInt32(numericPart);

            // Optionally, use the value immediately or update some controls with this value
            txtcctvEthernetportno.Text = ethernetPortNo.ToString(); // Assuming you have a textbox to display the value

        }
        public void SetPkHubValue(int pkvalue)
        {
            PkNumber = pkvalue;

        }
        public void SetPassedValue(Button button, int PortNo)
        {
            // Extract the numerical part from the button's name
            board = button;
            string buttonName = button.Name;
            string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

            // Convert the numeric part to an integer

            PdcPortNo = Convert.ToInt32(numericPart);

            // Optionally, use the value immediately or update some controls with this value
            txtcctvEthernetportno.Text = PortNo.ToString(); // Assuming you have a textbox to display the value

        }
        private void frmCCTV_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmHubConfiguration frmhub;
            Form mainForm = Application.OpenForms["frmHubConfiguration"];

            if (mainForm != null)
            {
                frmhub = (frmHubConfiguration)mainForm;
                frmhub.ClearPanel();


            }
        }

        private void btnOVDSave_Click(object sender, EventArgs e)
        {


            try
            {



                bool hasError = false; // Flag to track if there's any error

                // Check and highlight each required text box
                hasError |= CheckAndHighlightEmptyField(txtCCTVBoardId);
                hasError |= ChecktheError(ipAddressMldb);


                hasError |= CheckAndHighlightEmptyField(txtcctvEthernetportno);
                hasError |= CheckAndHighlightEmptyField(txtCCTVLocation);



                // hasError |= CheckAndHighlightEmptyField(txtPfdRegional);

                // If any error is found, display error message and exit the method
                if (hasError)
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {

                    // Define your variables and ensure proper type conversions
                    int boardId = int.Parse(txtCCTVBoardId.Text);
                    int noOfLines = int.Parse(cmbCCTVLines.Text);
                    string ipAddress = ipAddressMldb.Text;
                    string location;
                    if (ID != -1)
                    {
                        location = txtCCTVLocation.Text.Trim();
                    }
                    else
                    {
                        location = txtCCTVLocation.Text.Trim() + "_cctv";
                    }
                    // string location = txtCCTVLocation.Text;
                    int ethernetPort = int.Parse(txtcctvEthernetportno.Text);

                    int packetIdentifier = 8; // Static value as given
                    int PortNo = GetPortNo(ethernetPortNo, PdcPortNo);


                    // Show confirmation dialog
                    DialogResult result = MessageBox.Show("Do you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // If the user clicks Yes, proceed with saving the data
                    if (result == DialogResult.Yes)
                    {
                        int rows = HubConfigurationDb.SaveCCTVconfiguration(
                                ID, boardId, location, ethernetPort, ipAddress, noOfLines, PortNo, packetIdentifier);


                        if (rows >= 0)
                        {
                            ReportDb.InsertDatabaseModificationReportData("CCTV Board Added With the Ip " + ipAddress, "4");
                            // Show success message for 10 seconds
                            lblStatus.Text = "Board Configuration saved successfully!";
                            lblStatus.ForeColor = Color.Green;

                            BaseClass.RecallBoards();


                        }
                        else
                        {
                            // Show failure message for 10 seconds
                            lblStatus.Text = "Failed to save Board configuration.";
                            lblStatus.ForeColor = Color.Red;
                        }

                        // Make the label visible
                        lblStatus.Visible = true;

                        // Start a timer to clear the label after 10 seconds
                        Timer timer = new Timer();
                        timer.Interval = 2000; // 5 seconds
                        timer.Tick += (s, _) =>
                        {
                            // Clear the label text and hide the label
                            lblStatus.Text = "";
                            lblStatus.Visible = false;

                            // Stop and dispose the timer
                            timer.Stop();
                            timer.Dispose();
                            this.Close();

                        };
                        timer.Start(); // Start the timer

                    }



                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }

        }

        private int GetPortNo(int ethernetPortNo, int PdcPortNo)
        {
            int portno;
            if (PdcPortNo == 0)
            {
                portno = ethernetPortNo;
            }
            else
            {
                portno = 0;
            }


            return portno;
        }
        private bool CheckAndHighlightEmptyField(TextBox TextBox)
        {

            if (string.IsNullOrWhiteSpace(TextBox.Text))
            {
                TextBox.BackColor = Color.Red; // Change background color to red to indicate error
                return true; // Indicate that this text box has an error
            }
            else
            {
                TextBox.BackColor = SystemColors.Window; // Reset background color
                return false; // No error for this text box
            }
        }

        private bool ChecktheError(IPAddressControlLib.IPAddressControl ipControl)
        {
            if (string.IsNullOrWhiteSpace(ipControl.Text))
            {
                ipControl.BackColor = Color.Red; // Change background color to red to indicate error
                return true; // Indicate that this control has an error
            }
            else
            {
                ipControl.BackColor = SystemColors.Window; // Reset background color
                return false; // No error for this control
            }
        }
        private void ipAddressMldb_Enter(object sender, EventArgs e)
        {

            ipAddressMldb.BackColor = SystemColors.Window;
            txtCCTVBoardId.BackColor = SystemColors.Window;
        }

        private void ipAddressMldb_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
        }

        private void cmbCCTVLines_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
        }

        private void ipAddressMldb_Leave(object sender, EventArgs e)
        {
            string ipAddress = ipAddressMldb.Text.Trim();

            // Get the result tuple from the method
            var result = IsLastOctetInRangeMLDB(ipAddress, 191, 220);
            bool isInRange = result.Item1;
            int lastOctet = result.Item2;

            if (!isInRange)
            {
                // Display error icon and message
                errorProviderivovd.SetError(ipAddressMldb, "The last octet of the IP address must be between 191 and 220.");
                lblICCTVErrorMessage.Visible = true;
            }
            else
            {
                // Clear any previous error
                errorProviderivovd.SetError(ipAddressMldb, "");
                lblICCTVErrorMessage.Visible = false;

                // Use the last octet value if needed
                txtCCTVBoardId.Text = lastOctet.ToString();
            }
        }
        private (bool, int) IsLastOctetInRangeMLDB(string ipAddressMLDB, int startRange, int endRange)
        {
            try
            {


                // Validate that the input is a proper IP address
                if (IPAddress.TryParse(ipAddressMLDB, out IPAddress parsedIpAddress))
                {
                    // Split the IP address into its octets
                    string[] octets = ipAddressMLDB.Split('.');

                    // Ensure there are exactly 4 octets
                    if (octets.Length == 4)
                    {
                        // Try to parse the last octet
                        if (int.TryParse(octets[3], out int lastOctet))
                        {
                            // Check if the last octet is within the specified range
                            bool isInRange = lastOctet >= startRange && lastOctet <= endRange;
                            return (isInRange, lastOctet);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            // Return false and -1 if the IP address is not valid or other parsing issues occurred
            return (false, -1);
        }
        private void ipAddressMldb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Get the selected platform from the ComboBox
                string iptext = ipAddressMldb.Text.Trim();
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
                            lblIpExist.Visible = true;
                            return;
                        }
                        else
                        {
                            lblIpExist.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                ex.ToString();
            }
        }

        private void txtCCTVLocation_Enter(object sender, EventArgs e)
        {
            txtCCTVLocation.BackColor = SystemColors.Window;

        }

        private void GetDetailsByPk()
        {
            try
            {
                if (PkNumber != 0)
                {
                    DataTable boarddetailybyPk = new DataTable();
                    foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                    {
                        if (BaseClass.EthernetPorts.Columns.Contains("PkeyMasterhub") && int.TryParse(row["PkeyMasterhub"].ToString(), out int PkMasterHub))
                        {
                            if (PkMasterHub == PkNumber)
                            {
                                boarddetailybyPk = HubConfigurationDb.GetCCTVConfiguration(PkMasterHub);
                                ipAddressMldb.Text = row["IPAddress"].ToString();
                                txtCCTVLocation.Text = row["Location"].ToString();
                                txtcctvEthernetportno.Text = row["EthernetPort"].ToString();


                            }
                        }
                    }

                    foreach (DataRow row in boarddetailybyPk.Rows)
                    {
                        if (boarddetailybyPk.Columns.Contains("Fk_MasterHub") && int.TryParse(row["Fk_MasterHub"].ToString(), out int PkMasterHub))
                        {
                            if (PkMasterHub == PkNumber)
                            {
                                txtCCTVBoardId.Text = row["BoardId"].ToString();
                                cmbCCTVLines.Text = row["NoOfLines"].ToString();

                                ID = Convert.ToInt32(row["Fk_MasterHub"]);
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
                ex.ToString();
            }
        }

        private void frmCCTV_Load(object sender, EventArgs e)
        {
            cmbCCTVLines.SelectedIndex = 4;
            GetDetailsByPk();
        }
    }
}
