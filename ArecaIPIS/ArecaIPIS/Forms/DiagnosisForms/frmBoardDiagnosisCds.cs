using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Server_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmBoardDiagnosisCds : Form
    {
        public frmBoardDiagnosisCds()
        {
            InitializeComponent();
            dgvCommunication.CellPainting += dgvCommunication_CellPainting;
        }

        private frmHome parentForm;
        List<string> listOfIps = new List<string>();
        public frmBoardDiagnosisCds(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void frmBoardDiagnosisCds_Load(object sender, EventArgs e)
        {
            try
            {
                List<int> packetIdentifiers = new List<int> { 1 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                // Clear existing rows in the DataGridView
                dgvCommunication.Rows.Clear();

                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in boards.Rows)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(dgvCommunication);

                    dgvRow.Cells[dgvCommunication.Columns["dgvBoardIP"].Index].Value = row["IPAddress"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvPDCName"].Index].Value = row["Location"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvPortNo"].Index].Value = row["PortNo"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvPlatformNo"].Index].Value = row["Platform"];
                    //  dgvRow.Cells[dgvCommunication.Columns["dgvTemperature"].Index].Value = row["Temperature"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = row["LinkStatus"];
                    // dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = row["LinkStatus"];
                    if (row["LinkStatus"].ToString().Trim() == "True")
                    {
                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "Active";
                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "InActive";
                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Orange;
                    }
                    //string ipadress = row["IPAddress"].ToString();

                    //if (Server._connectedClients.TryGetValue(ipadress, out TcpClient client))
                    //{
                    //    dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "Active";
                    //    dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Green;
                    //}
                    //else
                    //{
                    //    dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "InActive";
                    //    dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Orange;
                    //}

                    dgvCommunication.Rows.Add(dgvRow);
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

        private void dgvCommunication_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
        private void dgvCommunication_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {


                if (e.ColumnIndex == dgvCommunication.Columns["dgvConfiguration"].Index && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                    // Retrieve the value of the cell
                    string status = dgvCommunication.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    // Determine the background color based on the cell value
                    Color buttonColor = status == "Active" ? Color.Green : Color.Orange;

                    // Calculate the smaller button bounds
                    int buttonWidth = e.CellBounds.Width / 2;
                    int buttonHeight = e.CellBounds.Height - 6;
                    int buttonX = e.CellBounds.X + (e.CellBounds.Width - buttonWidth) / 2;
                    int buttonY = e.CellBounds.Y + 2;

                    Rectangle buttonBounds = new Rectangle(buttonX, buttonY, buttonWidth, buttonHeight);

                    // Draw the button background
                    using (Brush brush = new SolidBrush(buttonColor))
                    {
                        e.Graphics.FillRectangle(brush, buttonBounds);
                    }

                    // Draw the button text
                    TextRenderer.DrawText(e.Graphics, status, e.CellStyle.Font, buttonBounds, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    // Draw the button border
                    e.Graphics.DrawRectangle(Pens.Gray, buttonBounds);

                    // Prevent the default painting
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void dgvCommunication_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (e.ColumnIndex == dgvCommunication.Columns["dgvcheckBox"].Index && e.RowIndex >= 0)
                {
                    // Get the value of the currently changed checkbox
                    bool isChecked = (bool)dgvCommunication.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    if (isChecked)
                    {
                        // Uncheck all other checkboxes in the column
                        foreach (DataGridViewRow row in dgvCommunication.Rows)
                        {
                            if (row.Index != e.RowIndex)
                            {
                                row.Cells["dgvcheckBox"].Value = false;
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

        private void dgvCommunication_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {


                if (dgvCommunication.IsCurrentCellDirty)
                {
                    dgvCommunication.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnLinkCheck_Click(object sender, EventArgs e)
        {
            try
            {
                bool status = false;
                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {
                    if (Server._connectedClients.Count > 0)
                    {

                        // Create and send the LinkCheckPacket
                        byte[] LinkCheckPacket = frmBoardDiagnosis.LinkCheckPacket(BoardIp, packet);

                        Server.SendMessageToClient(BoardIp, LinkCheckPacket);
                        System.Threading.Thread.Sleep(5000);
                        //Task.Delay(5000);
                        // Get the received bytes from the server
                        byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                        // Check if received bytes are empty
                        if (serverReceivedBytes.Length <= 19)
                        {
                            status = false;

                            MessageBox.Show("Link check failed", "Link Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DeActivateLinkCheck(BoardIp);
                        }
                        else
                        {
                            byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);
                            //byte[] trimmedserverReceivedBytes = serverReceivedBytes;
                            bool linkSucess = ByteFormation.validateLinkCheck(trimmedserverReceivedBytes, trimmedLinkCheckPacket);


                            if (!linkSucess)
                            {
                                status = false;

                                MessageBox.Show("Link check failed", "Link Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DeActivateLinkCheck(BoardIp);
                            }
                            else
                            {
                                // Initialize receivedBytes with the same length as serverReceivedBytes
                                byte[] receivedBytes = new byte[trimmedserverReceivedBytes.Length];


                                // Copy data from serverReceivedBytes to receivedBytes
                                Array.Copy(trimmedserverReceivedBytes, receivedBytes, trimmedserverReceivedBytes.Length);
                                string data = splittingpdcData(receivedBytes, receivedBytes[7].ToString());

                                //// Convert received bytes to a string for displaying in a message box
                                //string receivedData = Encoding.ASCII.GetString(receivedBytes);

                                //// Convert received bytes to a hexadecimal string for displaying
                                //string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");

                                //MessageBox.Show("" + receivedHex + "\n" + data);
                                string receivedData = Encoding.ASCII.GetString(receivedBytes);
                                string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");
                                string dataToShow = receivedHex + Environment.NewLine + data;

                                // Truncate the message if it exceeds a certain length
                                int maxLength = 2000; // Adjust this limit based on your needs
                                if (dataToShow.Length > maxLength)
                                {
                                    dataToShow = dataToShow.Substring(0, maxLength) + "\n... (Data truncated)";
                                }

                                MessageBox.Show(dataToShow, "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                status = true;
                                ActivateLinkCheck(BoardIp);


                                // MessageBox.Show(""+ receivedHex);
                                // MessageBox.Show($"Received data from {BoardIp}:\nASCII: {receivedData}\nHex: {receivedHex}", "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                        }
                    }
                    else
                    {
                        MessageBox.Show("Link check failed", "Link Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DeActivateLinkCheck(BoardIp);
                    }

                    ReportDb.InsertLinkCheckLog(BoardIp, "LinkCheck", status);
                    OnlineTrainsDao.UpdateLinkCheckIp(BoardIp, status);



                }
                else
                {
                    MessageBox.Show(BoardIp);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static string splittingpdcData(byte[] receivedBytes, string pf)
        {


            int count = Convert.ToInt32(receivedBytes[12].ToString());

            string DATA = "";
            try
            {
                int j = 0;
                for (int i = 14; j < count;)
                {
                    string id = deviceid(receivedBytes[i++].ToString(), pf);
                    string type = devicetype(receivedBytes[i++].ToString());
                    string status = deviceStatus(receivedBytes[i++].ToString());
                    j++;

                    DATA = DATA + "\n" + "Board Id:" + id + "; " + type + ":" + status;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return DATA;
        }

        public static string devicetype(string type)
        {
            if (type == "2")
            {
                return "CGDB";
            }
            if (type == "3")
            {
                return "PFDB";
            }
            if (type == "4")
            {
                return "AGDB";
            }
            if (type == "5")
            {
                return "MLDB";
            }
            if (type == "6")
            {
                return "IVD";
            }
            if (type == "7")
            {
                return "OVD";
            }
            else
            {
                return "CGDB";
            }
        }
        public static string deviceStatus(string STATUS)
        {
            if (STATUS == "0")
            {
                return "Link Fail.";
            }
            if (STATUS == "1")
            {
                return "Link Ok.";
            }
            if (STATUS == "2")
            {
                return "Link Fail.";
            }
            else
            {
                return "Link Fail.";
            }

        }

        public static string deviceid(string ID, string pf)
        {

            return "192.168." + pf + "." + ID;

        }

        private (bool, string, int) GetBoardIpAndPacket()
        {

            try
            {


                foreach (DataGridViewRow row in dgvCommunication.Rows)
                {
                    if (row.Cells["dgvcheckBox"] is DataGridViewCheckBoxCell checkBoxCell && checkBoxCell.Value != null)
                    {
                        bool isChecked = (bool)checkBoxCell.Value;
                        if (isChecked)
                        {
                            var cell = row.Cells["dgvBoardIP"];
                            if (cell != null && cell.Value != null)
                            {
                                var boardIp = cell.Value.ToString().Trim();
                                int packet = GetPacketIdentifier(boardIp);
                                return (true, boardIp, packet);
                            }
                        }
                    }
                }
                return (false, "No board selected.", -1);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return (false, null, 0);
        }

        public int GetPacketIdentifier(string BoardIp)
        {
            try
            {


                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                    {
                        // Compare the IP address as a string
                        if (row["IPAddress"].ToString() == BoardIp)
                        {
                            // Try to get the PacketIdentifier as an integer
                            if (int.TryParse(row["PacketIdentifier"].ToString(), out int packet))
                            {
                                return packet;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            // Return a default value or throw an exception if the BoardIp is not found
            throw new Exception("PacketIdentifier not found for the provided BoardIp.");
        }

        private void ActivateLinkCheck(string targetIpAddress)
        {
            try
            {


                foreach (DataGridViewRow row in dgvCommunication.Rows)
                {
                    // Ensure the row is not a new row
                    if (!row.IsNewRow)
                    {
                        string ipAddress = row.Cells[dgvCommunication.Columns["dgvBoardIP"].Index].Value?.ToString();

                        if (ipAddress == targetIpAddress)
                        {
                            // Update the cell value in the "dgvConfiguration" column
                            row.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "Active";

                            // Change the cell's background color to green
                            row.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Green;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void DeActivateLinkCheck(string targetIpAddress)
        {

            try
            {
                foreach (DataGridViewRow row in dgvCommunication.Rows)
                {
                    // Ensure the row is not a new row
                    if (!row.IsNewRow)
                    {
                        string ipAddress = row.Cells[dgvCommunication.Columns["dgvBoardIP"].Index].Value?.ToString();

                        if (ipAddress == targetIpAddress)
                        {
                            // Update the cell value in the "dgvConfiguration" column
                            row.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "InActive";

                            // Change the cell's background color to green
                            row.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Orange;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnSoftReset_Click(object sender, EventArgs e)
        {

            try
            {
                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {

                    if (Server._connectedClients.Count > 0)
                    {

                        byte[] SoftResetPacket = frmBoardDiagnosis.SoftResetPacket(BoardIp, packet);
                        Server.SendMessageToClient(BoardIp, SoftResetPacket);
                        System.Threading.Thread.Sleep(5000);
                        // Get the received bytes from the server
                        byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                        // Check if received bytes are empty





                        // Show the received data in a message box
                        MessageBox.Show("" + "Command Excuted Sucessfully", "SOFT RESET", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // MessageBox.Show(""+ receivedHex);
                        // MessageBox.Show($"Received data from {BoardIp}:\nASCII: {receivedData}\nHex: {receivedHex}", "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    }
                    else
                    {
                        MessageBox.Show("" + "Command Excuted Failed", "SOFT RESET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DeActivateLinkCheck(BoardIp);
                    }


                }
                else
                {
                    MessageBox.Show(BoardIp);
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
                (bool hasBoard, string BoardIp, int packet, int cdcid, int portno) = GetBoardIpAndPacketCdcid();

                if (hasBoard)
                {
                    if (Server._connectedClients.Count > 0)
                    {

                        string pdcip = BoardIp;
                        // int portno = Convert.ToInt32(txtportno.Text.Trim());
                        int pdcPacketno = Board.PDC;


                        List<string> listOfIps = CgdbController.GetConfigureBoards(pdcip, portno);

                        int i = 2;

                        byte[] pdcData = new byte[listOfIps.Count * 3 + 2];
                        pdcData[0] = (byte)listOfIps.Count;
                        pdcData[1] = 0;

                        foreach (var eachip in listOfIps)
                        {


                            (int packetno, int Ip, int port) = BaseClass.GetPacketIdentifier(eachip);

                            pdcData[i] = (byte)Ip;
                            pdcData[++i] = (byte)packetno;
                            pdcData[++i] = 0;
                            i++;
                        }
                        string broadCastIp = Server.GetBroadcastIp(pdcip);
                        byte[] SetConfigurationPacket = frmBoardDiagnosis.SetConfigurationPdc(pdcip, pdcPacketno, pdcData);


                        Server.SendDataToPdc(pdcip, SetConfigurationPacket);
                        System.Threading.Thread.Sleep(5000);
                        // Get the received bytes from the server
                        byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                        // Check if received bytes are empty
                        if (serverReceivedBytes.Length <= 19)
                        {

                            MessageBox.Show("SET CONFIGURATION failed", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }
                        else
                        {
                            byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(SetConfigurationPacket);

                            bool linkSucess = ByteFormation.validateSetConfiguration(trimmedserverReceivedBytes, trimmedLinkCheckPacket);


                            if (!linkSucess)
                            {

                                MessageBox.Show("SET CONFIGURATION failed", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



                                // Show the received data in a message box
                                // MessageBox.Show("" + "Response  :" + receivedHex + "\nCommand: Set Configuration Excuted Sucessfully", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // MessageBox.Show(""+ receivedHex);
                                MessageBox.Show($"Received data from {BoardIp}:\nHex: {receivedHex}", "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                        }


                    }
                    else
                    {

                        MessageBox.Show("SET CONFIGURATION failed", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DeActivateLinkCheck(BoardIp);
                    }
                }
                else
                {
                    MessageBox.Show(BoardIp);
                }
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
                bool status = false;
                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {

                    if (Server._connectedClients.Count > 0)
                    {

                        string broadCastIp = Server.GetBroadcastIp(BoardIp);
                        byte[] LinkCheckPacket = frmBoardDiagnosis.GetConfiguration(BoardIp, packet);
                        Server.SendMessageToClient(BoardIp, LinkCheckPacket);
                        System.Threading.Thread.Sleep(5000);
                        // Get the received bytes from the server
                        byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                        // Check if received bytes are empty
                        if (serverReceivedBytes.Length <= 10)
                        {
                            status = false;
                            MessageBox.Show("Get configuration failed", "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);

                            bool linkSucess = ByteFormation.validateGetConfiguration(trimmedserverReceivedBytes, trimmedLinkCheckPacket);


                            if (!linkSucess)
                            {
                                status = false;
                                MessageBox.Show("Get configuration failed", "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                // Initialize receivedBytes with the same length as serverReceivedBytes
                                byte[] receivedBytes = new byte[trimmedserverReceivedBytes.Length];

                                // Copy data from serverReceivedBytes to receivedBytes
                                Array.Copy(trimmedserverReceivedBytes, receivedBytes, trimmedserverReceivedBytes.Length);

                                // Convert received bytes to a string for displaying in a message box
                                string receivedData = Encoding.ASCII.GetString(receivedBytes);

                                string data = splittingpdcData(receivedBytes, receivedBytes[7].ToString());

                                //// Convert received bytes to a string for displaying in a message box
                                //string receivedData = Encoding.ASCII.GetString(receivedBytes);

                                //// Convert received bytes to a hexadecimal string for displaying
                                //string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");

                                //MessageBox.Show("" + receivedHex + "\n" + data);

                                string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");
                                string dataToShow = receivedHex + Environment.NewLine + data;

                                // Truncate the message if it exceeds a certain length
                                int maxLength = 2000; // Adjust this limit based on your needs
                                if (dataToShow.Length > maxLength)
                                {
                                    dataToShow = dataToShow.Substring(0, maxLength) + "\n... (Data truncated)";
                                }

                                MessageBox.Show(dataToShow, "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                status = true;
                                // MessageBox.Show(""+ receivedHex);
                                // MessageBox.Show($"Received data from {BoardIp}:\nASCII: {receivedData}\nHex: {receivedHex}", "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Get configuration failed", "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DeActivateLinkCheck(BoardIp);
                    }

                    ReportDb.InsertLinkCheckLog(BoardIp, "LinkCheck", status);
                    OnlineTrainsDao.UpdateLinkCheckIp(BoardIp, status);


                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }





        }
        private (bool, string, int, int, int) GetBoardIpAndPacketCdcid()
        {
            try
            {


                foreach (DataGridViewRow row in dgvCommunication.Rows)
                {
                    if (row.Cells["dgvcheckBox"] is DataGridViewCheckBoxCell checkBoxCell && checkBoxCell.Value != null)
                    {
                        bool isChecked = (bool)checkBoxCell.Value;
                        if (isChecked)
                        {
                            var ipCell = row.Cells["dgvBoardIP"];
                            if (ipCell != null && ipCell.Value != null)
                            {
                                string boardIp = ipCell.Value.ToString().Trim();
                                (int packet, int cdcid) = GetPacketIdentifierandCdcid(boardIp);

                                var portCell = row.Cells["dgvPortNo"];
                                int portno = Convert.ToInt32(portCell.Value.ToString().Trim());

                                return (true, boardIp, packet, cdcid, portno);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return (false, "No board selected.", -1, -1, -1);
        }


        public (int, int) GetPacketIdentifierandCdcid(string BoardIp)
        {
            try
            {
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                    {
                        // Compare the IP address as a string
                        if (row["IPAddress"].ToString() == BoardIp)
                        {
                            // Try to get the PacketIdentifier as an integer
                            if (int.TryParse(row["PacketIdentifier"].ToString(), out int packet) && int.TryParse(row["PkeyMasterhub"].ToString(), out int cdcid))
                            {
                                return (packet, cdcid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            // Return a default value or throw an exception if the BoardIp is not found
            throw new Exception("PacketIdentifier not found for the provided BoardIp.");
        }





        private void dgvCommunication_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            try
            {

                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {
                    if (Server._connectedClients.Count > 0)
                    {

                        string pdcIp = BoardIp;
                        int packetidentifier = Board.CGDB;
                        StopCommand(pdcIp, packetidentifier);
                    }

                    else
                    {
                        DeActivateLinkCheck(BoardIp);
                    }





                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnLinkCheckAll_Click(object sender, EventArgs e)
        {

        }

        private void btnErrorData_Click(object sender, EventArgs e)
        {
            try
            {

                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {

                    if (Server._connectedClients.Count > 0)
                    {

                        string Error = cmbErrorData.Text;
                        // Create and send the LinkCheckPacket
                        byte[] ErrorPacket = frmBoardDiagnosis.ErrorDataPacket(BoardIp, packet, Error);
                        Server.SendDataToPdc(BoardIp, ErrorPacket);

                        System.Threading.Thread.Sleep(3000);
                        // Get the received bytes from the server
                        byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                        // Check if received bytes are empty
                        if (serverReceivedBytes.Length <= 19)
                        {


                            MessageBox.Show("Error Data failed", "Error Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            string receivedHex = Server.ByteArrayToHexString(trimmedserverReceivedBytes);
                            //string receivedHex = Encoding.ASCII.GetString(trimmedserverReceivedBytes);
                            if (trimmedserverReceivedBytes[10] == 224)
                            {
                                MessageBox.Show("" + receivedHex + "\nCrc Fail", "Error Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (trimmedserverReceivedBytes[10] == 225)
                            {
                                MessageBox.Show("" + receivedHex + "\nInvalid Destination Address", "Error Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (trimmedserverReceivedBytes[10] == 226)
                            {
                                MessageBox.Show("" + receivedHex + "\nInvalid Source Address", "Error Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (trimmedserverReceivedBytes[10] == 227)
                            {
                                MessageBox.Show("" + receivedHex + "\nInvalid Function Code", "Error Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (trimmedserverReceivedBytes[10] == 233)
                            {
                                MessageBox.Show("" + receivedHex + "\nInvalid Data", "Error Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (trimmedserverReceivedBytes[10] == 232)
                            {
                                MessageBox.Show("" + receivedHex + "\nInvalid Data Length", "Error Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }



                        }
                    }
                    else
                    {
                        DeActivateLinkCheck(BoardIp);
                    }





                }
                else
                {
                    MessageBox.Show(BoardIp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
