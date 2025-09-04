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
    public partial class frmBoardDiagnosisCgdb : Form
    {
        public frmBoardDiagnosisCgdb()
        {
            InitializeComponent();
        }

        private void btnLinkCheck_Click(object sender, EventArgs e)
        {

            try
            {
                bool status = false;
                //(bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();
                (bool hasBoard, string BoardIp, int packet, string pdcip) = GetBoardIpAndPacketpdcip();

                if (hasBoard)
                {

                    if (Server._connectedClients.Count > 0)
                    {

                        // Create and send the LinkCheckPacket
                        byte[] LinkCheckPacket = frmBoardDiagnosis.LinkCheckPacket(BoardIp, packet);
                        byte[] serverReceivedBytes = Server.GetReceivedBytes;
                        byte[] trimmedserverReceivedBytes = serverReceivedBytes;
                        if (BaseClass.Getinteroperabilitystatus(pdcip))
                        {
                            LinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);
                            Server.SendMessageToClient(BoardIp, LinkCheckPacket);
                            System.Threading.Thread.Sleep(1000);
                            trimmedserverReceivedBytes = Server.GetReceivedBytes;
                        }
                        else
                        {
                            Server.SendMessageToClient(BoardIp, LinkCheckPacket);
                            LinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);
                            System.Threading.Thread.Sleep(5000);
                            serverReceivedBytes = Server.GetReceivedBytes;
                            trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);

                        }

                        //byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);

                        if (trimmedserverReceivedBytes.Length <= 14)
                        {
                            status = false;
                            MessageBox.Show("Link check failed", "Link Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DeActivateLinkCheck(BoardIp);
                        }
                        else
                        {
                            // byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            // byte[] trimmedserverReceivedBytes = serverReceivedBytes;
                            // byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);

                            bool linkSucess = ByteFormation.validateLinkCheck(trimmedserverReceivedBytes, LinkCheckPacket);


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

                                // Convert received bytes to a string for displaying in a message box
                                string receivedData = Encoding.ASCII.GetString(receivedBytes);

                                // Convert received bytes to a hexadecimal string for displaying
                                string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");
                                string intensity = frmBoardDiagnosis.GetIntensity(receivedBytes[12]);
                                string dataTimeout = frmBoardDiagnosis.GetDataTimeout(receivedBytes[13]);
                                // Show the received data in a message box

                                MessageBox.Show("" + receivedHex + "\nIntensity:  " + intensity + "\nData Timeout: " + dataTimeout, "lINK CHECK SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
        private void DeActivateLinkCheck(string targetIpAddress)
        {
            try
            {


                foreach (DataGridViewRow row in dgvCommunication.Rows)
                {
                    // Ensure the row is not a new row
                    if (!row.IsNewRow)
                    {
                        string ipAddress = row.Cells[dgvCommunication.Columns["dgvCoachId"].Index].Value?.ToString();

                        string tipadress = "";
                        var ipParts = targetIpAddress.Split('.');
                        if (ipParts.Length == 4) // Make sure it's a valid IP address
                        {
                            var thirdOctet = ipParts[2];
                            tipadress = "CGDBPF" + thirdOctet + "_" + targetIpAddress;


                        }

                        if (ipAddress == tipadress)
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

        private (bool, string, int, string) GetBoardIpAndPacketpdcip()
        {
            try
            {
                foreach (DataGridViewRow row in dgvCommunication.Rows)
                {
                    if (row.Cells["dgvcheckbox"] is DataGridViewCheckBoxCell checkBoxCell && checkBoxCell.Value is bool isChecked && isChecked)
                    {
                        var cellCoachId = row.Cells["dgvCoachId"];
                        var cellPdcIp = row.Cells["dgvPdcIp"];

                        if (cellCoachId != null && cellCoachId.Value != null &&
                            cellPdcIp != null && cellPdcIp.Value != null)
                        {
                            var boardIp = cellCoachId.Value.ToString().Trim();
                            var pdcIp = cellPdcIp.Value.ToString().Trim();

                            // Assuming the IP address is always after the last underscore
                            var ipAddress = boardIp.Substring(boardIp.LastIndexOf('_') + 1);
                            int packet = Board.CGDB;

                            return (true, ipAddress, packet, pdcIp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return (false, $"Error: {ex.Message}", -1, "");
            }

            return (false, "No board selected.", -1, "");
        }

        private (bool, string, int) GetBoardIpAndPacket()
        {
            try
            {


                foreach (DataGridViewRow row in dgvCommunication.Rows)
                {
                    if (row.Cells["dgvcheckbox"] is DataGridViewCheckBoxCell checkBoxCell && checkBoxCell.Value != null)
                    {
                        bool isChecked = (bool)checkBoxCell.Value;
                        if (isChecked)
                        {
                            var cell = row.Cells["dgvCoachId"];
                            if (cell != null && cell.Value != null)
                            {
                                var boardIp = cell.Value.ToString().Trim();
                                // Assuming the IP address is always after the last underscore
                                var ipAddress = boardIp.Substring(boardIp.LastIndexOf('_') + 1);
                                int packet = Board.CGDB;
                                return (true, ipAddress, packet);
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
        private (bool, string, int, int) GetdgvBoardIpAndPacketCdcid()
        {
            try
            {


                foreach (DataGridViewRow row in dgvCommunication.Rows)
                {
                    // Check if the checkbox cell is checked
                    if (row.Cells["dgvcheckbox"] is DataGridViewCheckBoxCell checkBoxCell && checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                    {
                        // Retrieve the IP address from the "dgvCoachId" cell
                        var boardIpCell = row.Cells["dgvCoachId"];
                        if (boardIpCell != null && boardIpCell.Value != null)
                        {
                            var boardIp = boardIpCell.Value.ToString().Trim();
                            var ipAddress = boardIp.Substring(boardIp.LastIndexOf('_') + 1);

                            // Assuming Board.CGDB is defined elsewhere
                            int packet = Board.CGDB;

                            // Retrieve the CDC ID from the "dgvHubId" cell
                            var cdcIdCell = row.Cells["dgvHubId"];
                            if (cdcIdCell != null && cdcIdCell.Value != null)
                            {
                                if (int.TryParse(cdcIdCell.Value.ToString().Trim(), out int cdcId))
                                {
                                    return (true, ipAddress, packet, cdcId);
                                }
                                else
                                {
                                    // Handle the case where cdcId is not an integer
                                    return (false, "Invalid CDC ID format.", -1, -1);
                                }
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



        private void ActivateLinkCheck(string targetIpAddress)
        {
            try
            {


                foreach (DataGridViewRow row in dgvCommunication.Rows)
                {
                    // Ensure the row is not a new row
                    if (!row.IsNewRow)
                    {
                        string ipAddress = row.Cells[dgvCommunication.Columns["dgvCoachId"].Index].Value?.ToString();
                        string tipadress = "";
                        var ipParts = targetIpAddress.Split('.');
                        if (ipParts.Length == 4) // Make sure it's a valid IP address
                        {
                            var thirdOctet = ipParts[2];
                            tipadress = "CGDBPF" + thirdOctet + "_" + targetIpAddress;


                        }

                        if (ipAddress == tipadress)
                        {
                            // Update the cell value in the "dgvConfiguration" column
                            row.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "Active";

                            // Change the cell's background color to green
                            row.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Green;
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

        private void dgvCommunication_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void frmBoardDiagnosisCgdb_Load(object sender, EventArgs e)
        {
            try
            {
                BaseClass.setCgdbHub();
                List<int> packetIdentifiers = new List<int> { 1 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                // Clear existing rows in the DataGridView
                dgvCommunication.Rows.Clear();

                foreach (DataRow row in boards.Rows)
                {
                    if (boards.Columns.Contains("PkeyMasterhub") && int.TryParse(row["PkeyMasterhub"].ToString(), out int PkMasterHub))
                    {
                        string pdcip = row["IPAddress"].ToString();
                        string PLATFORM = row["Platform"].ToString();

                        foreach (DataRow eachrow in BaseClass.CgdbHubPorts.Rows)
                        {
                            if (BaseClass.CgdbHubPorts.Columns.Contains("fkey_CDC") && int.TryParse(eachrow["fkey_CDC"].ToString(), out int fkey_CDC))
                            {
                                if (PkMasterHub == fkey_CDC)
                                {
                                    DataGridViewRow dgvRow = new DataGridViewRow();
                                    dgvRow.CreateCells(dgvCommunication);

                                    dgvRow.Cells[dgvCommunication.Columns["dgvPortNo"].Index].Value = eachrow["PortNo"];
                                    dgvRow.Cells[dgvCommunication.Columns["dgvCoachId"].Index].Value = "CGDBPF" + PLATFORM + "_" + eachrow["Cgdb_IpAddress"];
                                    dgvRow.Cells[dgvCommunication.Columns["dgvHubId"].Index].Value = PkMasterHub;
                                    dgvRow.Cells[dgvCommunication.Columns["dgvPdcIp"].Index].Value = pdcip;
                                    // dgvRow.Cells[dgvCommunication.Columns["dgvTemperature"].Index].Value = eachrow["Temperature"];
                                    if (eachrow["LinkCheck"].ToString().Trim() == "True")
                                    {
                                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "Active";
                                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Green;

                                    }
                                    else
                                    {
                                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "InActive";
                                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Orange;

                                    }

                                    //string ipAddress = eachrow["Cgdb_IpAddress"].ToString();

                                    //if (Server._connectedClients.TryGetValue(ipAddress, out TcpClient client))
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
                        }
                    }
                }

                // Clear selection and set the current cell to null
                dgvCommunication.ClearSelection();
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

        private void btnSoftReset_Click(object sender, EventArgs e)
        {
            try
            {
                // (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();
                (bool hasBoard, string BoardIp, int packet, string pdcip) = GetBoardIpAndPacketpdcip();

                if (hasBoard)
                {
                    if (Server._connectedClients.Count > 0)
                    {

                        //    byte[] SoftResetPacket = frmBoardDiagnosis.SoftResetPacket(BoardIp, packet);
                        //Server.SendMessageToClient(BoardIp, SoftResetPacket);
                        //System.Threading.Thread.Sleep(5000);

                        //// Get the received bytes from the server
                        //byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                        // Check if received bytes are empty
                        // Create and send the LinkCheckPacket
                        byte[] SoftResetPacket = frmBoardDiagnosis.SoftResetPacket(BoardIp, packet);
                        byte[] serverReceivedBytes = Server.GetReceivedBytes;
                        byte[] trimmedserverReceivedBytes = serverReceivedBytes;
                        if (BaseClass.Getinteroperabilitystatus(pdcip))
                        {
                            SoftResetPacket = ByteFormation.RemoveFirstAndLast6(SoftResetPacket);
                            Server.SendMessageToClient(BoardIp, SoftResetPacket);
                            System.Threading.Thread.Sleep(1000);
                            trimmedserverReceivedBytes = Server.GetReceivedBytes;
                        }
                        else
                        {
                            Server.SendMessageToClient(BoardIp, SoftResetPacket);
                            System.Threading.Thread.Sleep(5000);
                            serverReceivedBytes = Server.GetReceivedBytes;
                            trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);

                        }





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
                bool status = false;
                // (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();
                (bool hasBoard, string BoardIp, int packet, string pdcip) = GetBoardIpAndPacketpdcip();

                if (hasBoard)
                {
                    if (Server._connectedClients.Count > 0)
                    {

                        //    byte[] LinkCheckPacket = frmBoardDiagnosis.GetConfiguration(BoardIp, packet);
                        //Server.SendMessageToClient(BoardIp, LinkCheckPacket);
                        //System.Threading.Thread.Sleep(5000);
                        //// Get the received bytes from the server
                        //byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                        // Create and send the LinkCheckPacket
                        byte[] GetConfigurationPacket = frmBoardDiagnosis.GetConfiguration(BoardIp, packet);
                        byte[] serverReceivedBytes = Server.GetReceivedBytes;//DECLARATION
                        byte[] trimmedserverReceivedBytes = serverReceivedBytes;//DECLARATION
                        if (BaseClass.Getinteroperabilitystatus(pdcip))
                        {
                            GetConfigurationPacket = ByteFormation.RemoveFirstAndLast6(GetConfigurationPacket);
                            Server.SendMessageToClient(BoardIp, GetConfigurationPacket);
                            System.Threading.Thread.Sleep(1000);
                            trimmedserverReceivedBytes = Server.GetReceivedBytes;
                        }
                        else
                        {
                            Server.SendMessageToClient(BoardIp, GetConfigurationPacket);
                            GetConfigurationPacket = ByteFormation.RemoveFirstAndLast6(GetConfigurationPacket);
                            System.Threading.Thread.Sleep(5000);
                            serverReceivedBytes = Server.GetReceivedBytes;
                            trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);

                        }


                        // Check if received bytes are empty
                        if (trimmedserverReceivedBytes.Length <= 14)
                        {
                            status = false;
                            MessageBox.Show("Get configuration failed", "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            //byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);

                            bool linkSucess = ByteFormation.validateGetConfiguration(trimmedserverReceivedBytes, GetConfigurationPacket);


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

                                // Convert received bytes to a hexadecimal string for displaying
                                string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");
                                string intensity = frmBoardDiagnosis.GetIntensity(receivedBytes[12]);
                                string dataTimeout = frmBoardDiagnosis.GetDataTimeout(receivedBytes[13]);
                                // Show the received data in a message box
                                MessageBox.Show("" + receivedHex + "\nIntensity:  " + intensity + "\nData Timeout: " + dataTimeout, "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool status = false;
                (bool hasBoard, string BoardIp, int packet, int cdcid) = GetdgvBoardIpAndPacketCdcid();
                (bool hasBoard1, string BoardIp1, int packet1, string pdcip) = GetBoardIpAndPacketpdcip();

                var config = CgdbController.GetDatatimeoutAndIntensityCgdb(cdcid);
                int datatimeout = config.datatimeout;
                int intensity = config.intensity;

                if (hasBoard)
                {
                    if (Server._connectedClients.Count > 0)
                    {

                        //    byte[] SetConfiguration = CgdbController.SetConfigurationCgdb(BoardIp, packet, datatimeout, intensity);
                        //Server.SendMessageToClient(BoardIp, SetConfiguration);
                        //System.Threading.Thread.Sleep(5000);
                        //// Get the received bytes from the server
                        //byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                        // Create and send the LinkCheckPacket
                        byte[] SetConfigurationPacket = CgdbController.SetConfigurationCgdb(BoardIp, packet, datatimeout, intensity);
                        byte[] serverReceivedBytes = Server.GetReceivedBytes;
                        byte[] trimmedserverReceivedBytes = serverReceivedBytes;
                        if (BaseClass.Getinteroperabilitystatus(pdcip))
                        {
                            SetConfigurationPacket = ByteFormation.RemoveFirstAndLast6(SetConfigurationPacket);
                            Server.SendMessageToClient(BoardIp, SetConfigurationPacket);
                            System.Threading.Thread.Sleep(1000);
                            serverReceivedBytes = Server.GetReceivedBytes;
                        }
                        else
                        {
                            Server.SendMessageToClient(BoardIp, SetConfigurationPacket);
                            SetConfigurationPacket = ByteFormation.RemoveFirstAndLast6(SetConfigurationPacket);
                            System.Threading.Thread.Sleep(5000);
                            serverReceivedBytes = Server.GetReceivedBytes;
                            trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);

                        }



                        // Check if received bytes are empty
                        if (trimmedserverReceivedBytes.Length <= 14)
                        {
                            status = false;
                            MessageBox.Show("SET CONFIGURATION failed", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            status = false;
                            //byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            //byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(SetConfiguration);

                            bool linkSucess = ByteFormation.validateSetConfiguration(trimmedserverReceivedBytes, SetConfigurationPacket);


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
                                MessageBox.Show("" + "Response  :" + receivedHex + "\nCommand: Set Configuration Excuted Sucessfully", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                status = true;
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

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            try
            {
                //(bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();
                (bool hasBoard, string BoardIp, int packet, string pdcip) = GetBoardIpAndPacketpdcip();

                if (hasBoard)
                {
                    if (Server._connectedClients.Count > 0)
                    {

                        // byte[] LinkCheckPacket = frmBoardDiagnosis.DeleteData(BoardIp, packet);
                        //Server.SendMessageToClient(BoardIp, LinkCheckPacket);
                        //System.Threading.Thread.Sleep(5000);
                        //// Get the received bytes from the server
                        //byte[] serverReceivedBytes = Server.GetReceivedBytes;

                        // Create and send the LinkCheckPacket
                        byte[] DeleteDataPacket = frmBoardDiagnosis.DeleteData(BoardIp, packet);
                        byte[] serverReceivedBytes = Server.GetReceivedBytes;
                        byte[] trimmedserverReceivedBytes = serverReceivedBytes;
                        if (BaseClass.Getinteroperabilitystatus(pdcip))
                        {
                            DeleteDataPacket = ByteFormation.RemoveFirstAndLast6(DeleteDataPacket);
                            Server.SendMessageToClient(BoardIp, DeleteDataPacket);
                            System.Threading.Thread.Sleep(1000);
                            trimmedserverReceivedBytes = Server.GetReceivedBytes;
                        }
                        else
                        {
                            Server.SendMessageToClient(BoardIp, DeleteDataPacket);
                            DeleteDataPacket = ByteFormation.RemoveFirstAndLast6(DeleteDataPacket);
                            System.Threading.Thread.Sleep(5000);
                            serverReceivedBytes = Server.GetReceivedBytes;
                            trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);

                        }

                        if (trimmedserverReceivedBytes.Length < 14)
                        {
                            MessageBox.Show("Delete Data failed", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            //byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(DeleteDataPacket);

                            bool linkSucess = ByteFormation.validateDeleteData(trimmedserverReceivedBytes, DeleteDataPacket);


                            if (!linkSucess)
                            {
                                MessageBox.Show("Delete Data failed", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                MessageBox.Show("" + "Response :" + receivedHex + "\nCommand :Delete Data Excuted Sucessfully ", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    var cellCoachId = row.Cells["dgvCoachId"];
                    var cellPdcIp = row.Cells["dgvPdcIp"];
                    if (cellCoachId != null && cellCoachId.Value != null &&
                             cellPdcIp != null && cellPdcIp.Value != null)
                    {


                        var BoardIp = cellCoachId.Value.ToString().Trim();
                        var pdcip = cellPdcIp.Value.ToString().Trim();

                        if (Server._connectedClients.Count > 0)
                        {

                            // Assuming the IP address is always after the last underscore
                            var ipAddress = BoardIp.Substring(BoardIp.LastIndexOf('_') + 1);
                            int packet = Board.CGDB;
                            //byte[] LinkCheckPacket = frmBoardDiagnosis.LinkCheckPacket(ipAddress, packet);
                            //Server.SendMessageToClient(ipAddress, LinkCheckPacket);
                            //// Split the IP address by '.' and get the third octet
                            //System.Threading.Thread.Sleep(2000);

                            //byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes


                            // Create and send the LinkCheckPacket
                            byte[] LinkCheckPacket = frmBoardDiagnosis.LinkCheckPacket(BoardIp, packet);
                            byte[] serverReceivedBytes = Server.GetReceivedBytes;
                            byte[] trimmedserverReceivedBytes = serverReceivedBytes;
                            if (BaseClass.Getinteroperabilitystatus(pdcip))
                            {
                                LinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);
                                Server.SendMessageToClient(BoardIp, LinkCheckPacket);
                                System.Threading.Thread.Sleep(1000);
                                trimmedserverReceivedBytes = Server.GetReceivedBytes;
                            }
                            else
                            {
                                Server.SendMessageToClient(BoardIp, LinkCheckPacket);
                                LinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);
                                System.Threading.Thread.Sleep(1000);
                                serverReceivedBytes = Server.GetReceivedBytes;
                                trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);

                            }



                            if (trimmedserverReceivedBytes.Length <= 19)
                            {

                                status = false;
                                // MessageBox.Show("Link check failed", "Link Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                label = label + "\n" + "" + "LINK CHECK Fail :   " + BoardIp;
                                DeActivateLinkCheck(BoardIp);
                            }
                            else
                            {
                                //byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                                //byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(LinkCheckPacket);

                                bool linkSucess = ByteFormation.validateLinkCheck(trimmedserverReceivedBytes, LinkCheckPacket);

                                if (!linkSucess)
                                {
                                    status = false;
                                    //MessageBox.Show("Link check failed", "Link Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    label = label + "\n " + "" + "LINK CHECK Fail :    " + BoardIp;
                                    DeActivateLinkCheck(BoardIp);
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
                                    // Show the received data in a message box
                                    label = label + "\n" + " " + receivedHex + "\nIntensity:  " + intensity + "\nData Timeout: " + dataTimeout + "\nLINK CHECK SUCCESS of :" + BoardIp;
                                    status = true;
                                    ActivateLinkCheck(BoardIp);
                                }


                            }
                        }
                        else
                        {
                            label += "\nLINK CHECK Fail: " + BoardIp;
                            DeActivateLinkCheck(BoardIp);
                        }

                        ReportDb.InsertLinkCheckLog(BoardIp, "LinkCheck", status);
                        OnlineTrainsDao.UpdateLinkCheckIp(BoardIp, status);
                    }

                }

                MessageBox.Show(label, "Link Check Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


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
