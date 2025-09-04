using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmBoardDiagnosisIvdOvd : Form
    {
        public frmBoardDiagnosisIvdOvd()
        {
            InitializeComponent();
        }

        private void dgvIVDOVD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                // Check if the clicked cell is in the checkbox column and not the header
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && dgvCommunication.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    DataGridViewCheckBoxCell clickedCell = dgvCommunication.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                    // Uncheck all other checkboxes in the same column
                    foreach (DataGridViewRow row in dgvCommunication.Rows)
                    {
                        if (row.Index != e.RowIndex) // Skip the clicked row
                        {
                            DataGridViewCheckBoxCell cell = row.Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                            cell.Value = false;
                        }
                    }

                    // Ensure the clicked checkbox is checked
                    clickedCell.Value = true;
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
                            //byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);

                            bool linkSucess = ByteFormation.validateLinkCheck(serverReceivedBytes, trimmedLinkCheckPacket);


                            if (!linkSucess)
                            {
                                status = false;
                                MessageBox.Show("Link check failed", "Link Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DeActivateLinkCheck(BoardIp);
                            }
                            else
                            {
                                // Initialize receivedBytes with the same length as serverReceivedBytes
                                byte[] receivedBytes = new byte[serverReceivedBytes.Length];

                                // Copy data from serverReceivedBytes to receivedBytes
                                Array.Copy(serverReceivedBytes, receivedBytes, serverReceivedBytes.Length);

                                // Convert received bytes to a string for displaying in a message box
                                string receivedData = Encoding.ASCII.GetString(receivedBytes);

                                // Convert received bytes to a hexadecimal string for displaying
                                string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");
                                string intensity = frmBoardDiagnosis.GetIntensity(receivedBytes[12]);
                                string dataTimeout = frmBoardDiagnosis.GetDataTimeout(receivedBytes[13]);
                                // Show the received data in a message box

                                MessageBox.Show("" + "Response: " + receivedHex + "\nIntensity:  " + intensity + "\nData Timeout: " + dataTimeout, "lINK CHECK SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    // Clear the static byte array after processing
                    //Server.ClearReceivedBytes();
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
                                int packet = Board.GetPacketIdentifier(boardIp);
                                return (true, boardIp, packet);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return (false, "No board selected.", -1);
        }

        private void frmBoardDiagnosisIvdOvd_Load(object sender, EventArgs e)
        {
            try
            {
                List<int> packetIdentifiers = new List<int> { 6, 7 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                // Clear existing rows in the DataGridView
                dgvCommunication.Rows.Clear();

                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in boards.Rows)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(dgvCommunication);

                    (string id, string Lines) = GetLinesAndId(Convert.ToInt32(row["PkeyMasterhub"].ToString()));



                    dgvRow.Cells[dgvCommunication.Columns["dgvBoardIP"].Index].Value = row["IPAddress"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvBoardLocation"].Index].Value = row["Location"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvPortNo"].Index].Value = row["EthernetPort"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvId"].Index].Value = id;
                    dgvRow.Cells[dgvCommunication.Columns["dgvLines"].Index].Value = Lines;
                    //dgvRow.Cells[dgvCommunication.Columns["dgvId"].Index].Value = row["PkeyMasterhub"];

                    dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = row["LinkStatus"];
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

                // dgvCommunication.ClearSelection();
                dgvCommunication.CurrentCell = null;
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
        public static (string, string) GetLinesAndId(int PkMasterHub)
        {
            DataTable boarddetailybyPk = new DataTable();
            string lines = "";
            string id = "";

            boarddetailybyPk = HubConfigurationDb.GetBoardDetails(PkMasterHub);

            foreach (DataRow row in boarddetailybyPk.Rows)
            {

                id = row["BoardID"].ToString();
                lines = row["NoofLines"].ToString();

            }

            return (id, lines);
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

        private void btnGetConfiguration_Click(object sender, EventArgs e)
        {
            try
            {

                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {

                    if (Server._connectedClients.Count > 0)
                    {

                        byte[] LinkCheckPacket = frmBoardDiagnosis.GetConfiguration(BoardIp, packet);
                        Server.SendMessageToClient(BoardIp, LinkCheckPacket);
                        System.Threading.Thread.Sleep(5000);
                        // Get the received bytes from the server
                        byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                        // Check if received bytes are empty
                        if (serverReceivedBytes.Length <= 19)
                        {
                            MessageBox.Show("Get configuration failed", "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);

                            bool linkSucess = ByteFormation.validateGetConfiguration(serverReceivedBytes, trimmedLinkCheckPacket);


                            if (!linkSucess)
                            {
                                MessageBox.Show("Get configuration failed", "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                // Initialize receivedBytes with the same length as serverReceivedBytes
                                byte[] receivedBytes = new byte[serverReceivedBytes.Length];

                                // Copy data from serverReceivedBytes to receivedBytes
                                Array.Copy(serverReceivedBytes, receivedBytes, serverReceivedBytes.Length);

                                // Convert received bytes to a string for displaying in a message box
                                string receivedData = Encoding.ASCII.GetString(receivedBytes);

                                // Convert received bytes to a hexadecimal string for displaying
                                string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");
                                string intensity = frmBoardDiagnosis.GetIntensity(receivedBytes[12]);
                                string dataTimeout = frmBoardDiagnosis.GetDataTimeout(receivedBytes[13]);
                                // Show the received data in a message box
                                MessageBox.Show("" + receivedHex + "\nIntensity:  " + intensity + "\nData Timeout: " + dataTimeout, "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActivateLinkCheck(BoardIp);
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

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            try
            {
                bool status = false;
                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {

                    if (Server._connectedClients.Count > 0)
                    {

                        byte[] LinkCheckPacket = frmBoardDiagnosis.DeleteData(BoardIp, packet);
                        Server.SendMessageToClient(BoardIp, LinkCheckPacket);
                        System.Threading.Thread.Sleep(5000);
                        // Get the received bytes from the server
                        byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                        // Check if received bytes are empty
                        if (serverReceivedBytes.Length <= 13)
                        {
                            status = false;
                            MessageBox.Show("Delete Data failed", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);

                            bool linkSucess = ByteFormation.validateDeleteData(serverReceivedBytes, trimmedLinkCheckPacket);


                            if (!linkSucess)
                            {
                                status = false;
                                MessageBox.Show("Delete Data failed", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                // Initialize receivedBytes with the same length as serverReceivedBytes
                                byte[] receivedBytes = new byte[serverReceivedBytes.Length];

                                // Copy data from serverReceivedBytes to receivedBytes
                                Array.Copy(serverReceivedBytes, receivedBytes, serverReceivedBytes.Length);

                                // Convert received bytes to a string for displaying in a message box
                                string receivedData = Encoding.ASCII.GetString(receivedBytes);

                                // Convert received bytes to a hexadecimal string for displaying
                                string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");

                                // Show the received data in a message box
                                MessageBox.Show("" + "Response :" + receivedHex + "\nCommand :Delete Data Excuted Sucessfully ", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActivateLinkCheck(BoardIp);
                                status = true;
                                // MessageBox.Show(""+ receivedHex);
                                // MessageBox.Show($"Received data from {BoardIp}:\nASCII: {receivedData}\nHex: {receivedHex}", "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Delete Data failed", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void btnLinkCheckAll_Click(object sender, EventArgs e)
        {
            try
            {


                string label = "";
                foreach (DataGridViewRow row in dgvCommunication.Rows)
                {
                    bool status = false;
                    if (row.Cells["dgvcheckBox"] is DataGridViewCheckBoxCell checkBoxCell && checkBoxCell.Value != null)
                    {
                        var cell = row.Cells["dgvBoardIP"];
                        if (cell != null && cell.Value != null)
                        {


                            var boardIp = cell.Value.ToString().Trim();

                            if (Server._connectedClients.Count > 0)
                            {

                                // Assuming the IP address is always after the last underscore

                                int packet = Board.GetPacketIdentifier(boardIp);




                                // Create and send the LinkCheckPacket
                                byte[] linkCheckPacket = frmBoardDiagnosis.LinkCheckPacket(boardIp, packet);
                                Server.SendMessageToClient(boardIp, linkCheckPacket);

                                System.Threading.Thread.Sleep(5000);

                                // Get the received bytes from the server
                                byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                                // Check if received bytes are empty
                                if (serverReceivedBytes.Length <= 19)
                                {
                                    status = false;
                                    label += "\nLINK CHECK Fail: " + boardIp;
                                    DeActivateLinkCheck(boardIp);
                                }
                                else
                                {
                                    // byte[] trimmedServerReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                                    byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(linkCheckPacket);

                                    bool linkSuccess = ByteFormation.validateLinkCheck(serverReceivedBytes, trimmedLinkCheckPacket);

                                    if (!linkSuccess)
                                    {
                                        status = false;
                                        label += "\nLINK CHECK Fail: " + boardIp;
                                        DeActivateLinkCheck(boardIp);
                                    }
                                    else
                                    {
                                        // Initialize receivedBytes with the same length as serverReceivedBytes
                                        byte[] receivedBytes = new byte[serverReceivedBytes.Length];

                                        // Copy data from serverReceivedBytes to receivedBytes
                                        Array.Copy(serverReceivedBytes, receivedBytes, serverReceivedBytes.Length);

                                        // Convert received bytes to a string for displaying in a message box
                                        string receivedData = Encoding.ASCII.GetString(receivedBytes);

                                        // Convert received bytes to a hexadecimal string for displaying
                                        string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");
                                        string intensity = frmBoardDiagnosis.GetIntensity(receivedBytes[12]);
                                        string dataTimeout = frmBoardDiagnosis.GetDataTimeout(receivedBytes[13]);

                                        // Show the received data in a message box
                                        label += "\n" + receivedHex + "\nIntensity: " + intensity + "\nData Timeout: " + dataTimeout + "\nLINK CHECK SUCCESS of: " + boardIp;
                                        status = true;
                                        ActivateLinkCheck(boardIp);
                                    }
                                }

                            }
                            else
                            {
                                label += "\nLINK CHECK Fail: " + boardIp;

                                DeActivateLinkCheck(boardIp);
                            }



                            ReportDb.InsertLinkCheckLog(boardIp, "LinkCheck", status);
                            OnlineTrainsDao.UpdateLinkCheckIp(boardIp, status);
                        }

                    }
                }

                MessageBox.Show(label, "Link Check Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


                (bool hasBoard, string BoardIp, int packet, int cdcid) = GetBoardIpAndPacketCdcid();
                DataTable dt = MediaDb.GetBorderColorConfiguration(cdcid);
                if (dt.Rows.Count > 0)
                {


                    if (hasBoard)
                    {
                        if (Server._connectedClients.Count > 0)
                        {


                            byte[] SetConfiguration = frmBoardDiagnosis.SetConfigurationOVDIVD(BoardIp, packet, cdcid);


                            Server.SendMessageToClient(BoardIp, SetConfiguration);
                            System.Threading.Thread.Sleep(5000);
                            // Get the received bytes from the server
                            byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                            // Check if received bytes are empty
                            if (serverReceivedBytes.Length <= 13)
                            {
                                MessageBox.Show("SET CONFIGURATION failed", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                //byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                                byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(SetConfiguration);

                                bool linkSucess = ByteFormation.validateSetConfiguration(serverReceivedBytes, trimmedLinkCheckPacket);


                                if (!linkSucess)
                                {
                                    MessageBox.Show("SET CONFIGURATION failed", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    // Initialize receivedBytes with the same length as serverReceivedBytes
                                    byte[] receivedBytes = new byte[serverReceivedBytes.Length];

                                    // Copy data from serverReceivedBytes to receivedBytes
                                    Array.Copy(serverReceivedBytes, receivedBytes, serverReceivedBytes.Length);

                                    // Convert received bytes to a string for displaying in a message box
                                    string receivedData = Encoding.ASCII.GetString(receivedBytes);

                                    // Convert received bytes to a hexadecimal string for displaying
                                    string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");

                                    // Show the received data in a message box
                                    MessageBox.Show("" + "Response  :" + receivedHex + "\nCommand: Set Configuration Excuted Sucessfully", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // MessageBox.Show(""+ receivedHex);
                                    // MessageBox.Show($"Received data from {BoardIp}:\nASCII: {receivedData}\nHex: {receivedHex}", "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else
                {
                    MessageBox.Show("Color Configuration Not Configured ", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private (bool, string, int, int) GetBoardIpAndPacketCdcid()
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
                                (int packet, int cdcid) = GetPacketIdentifierandCdcid(boardIp);

                                return (true, boardIp, packet, cdcid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            return (false, "No board selected.", -1, -1);
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

            return (0, 0);
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

                        // Create and send the LinkCheckPacket
                        string Error = cmbErrorData.Text;
                        // Create and send the LinkCheckPacket
                        byte[] ErrorPacket = frmBoardDiagnosis.ErrorDataPacket(BoardIp, packet, Error);
                        Server.SendMessageToClient(BoardIp, ErrorPacket);

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

                        MessageBox.Show("Error Data failed", "Error Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

