using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmBoardDiagnosisTadb : Form
    {
        public frmBoardDiagnosisTadb()
        {
            InitializeComponent();
            dgvCommunication.CellPainting += dgvCommunication_CellPainting;
        }
        private frmHome parentForm;

        public frmBoardDiagnosisTadb(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void frmBoardDiagnosisTadb_Load(object sender, EventArgs e)
        {
            try
            {
                List<int> packetIdentifiers = new List<int> { 3, 4, 5 };

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


                    dgvRow.Cells[dgvCommunication.Columns["dgvLines"].Index].Value = Lines;
                    dgvRow.Cells[dgvCommunication.Columns["dgvID"].Index].Value = id;
                    dgvRow.Cells[dgvCommunication.Columns["dgvBoardIP"].Index].Value = row["IPAddress"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvBoardLocation"].Index].Value = row["Location"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvPortNo"].Index].Value = row["EthernetPort"];
                    //  dgvRow.Cells[dgvCommunication.Columns["dgvPlatformNo"].Index].Value = row["Platform"];
                    //dgvRow.Cells[dgvCommunication.Columns["dgvTemperature"].Index].Value = row["Temperature"];

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

        }

        private void dgvCommunication_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {


        }
        // Method to clear the byte array
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



                        byte[] LinkCheckPacket = frmBoardDiagnosis.LinkCheckPacket(BoardIp, packet);
                        byte[] serverReceivedBytes = Server.GetReceivedBytes;
                        byte[] trimmedserverReceivedBytes = serverReceivedBytes;
                        if (BaseClass.Getinteroperabilitystatus(BoardIp))
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
                            bool linkSucess = false;

                            int lastOctet = int.Parse(BoardIp.Split('.').Last());

                            if (lastOctet >= 130 && lastOctet <= 160)
                            {
                                if (BaseClass.GettruecolorAgdbstatus(BoardIp))
                                {
                                    trimmedserverReceivedBytes = serverReceivedBytes;


                                }
                                else
                                {
                                    trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);

                                }
                            }
                            else
                            {
                                trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            }

                            linkSucess = ByteFormation.validateLinkCheck(trimmedserverReceivedBytes, LinkCheckPacket);





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

                                MessageBox.Show("" + receivedHex + "\nIntensity:  " + intensity + "\nData Timeout: " + dataTimeout, "LINK CHECK SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                    if (status)
                        OnlineTrainsDao.UpdateDataTransferIp(BoardIp, status);

                    else
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

            // Return a default value or throw an exception if the BoardIp is not found
            throw new Exception("PacketIdentifier not found for the provided BoardIp.");
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

        private void btnSoftReset_Click(object sender, EventArgs e)
        {
            try
            {
                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {
                    if (Server._connectedClients.Count > 0)
                    {

                        //    byte[] SoftResetPacket = frmBoardDiagnosis.SoftResetPacket(BoardIp, packet);
                        //Server.SendMessageToClient(BoardIp, SoftResetPacket);
                        //System.Threading.Thread.Sleep(5000);

                        // Get the received bytes from the server
                        //byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes
                        byte[] SoftResetPacket = frmBoardDiagnosis.SoftResetPacket(BoardIp, packet);
                        byte[] serverReceivedBytes = Server.GetReceivedBytes;
                        byte[] trimmedserverReceivedBytes = serverReceivedBytes;
                        if (BaseClass.Getinteroperabilitystatus(BoardIp))
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


                    }
                    else
                    {
                        MessageBox.Show("" + "Command Excuted Failed", "SOFT RESET", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        byte[] GetConfigurationPacket = frmBoardDiagnosis.GetConfiguration(BoardIp, packet);
                        byte[] serverReceivedBytes = Server.GetReceivedBytes;//DECLARATION
                        byte[] trimmedserverReceivedBytes = serverReceivedBytes;//DECLARATION
                        if (BaseClass.Getinteroperabilitystatus(BoardIp))
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
                        if (serverReceivedBytes.Length <= 19)
                        {
                            MessageBox.Show("Get configuration failed", "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {



                            bool linkSucess = false;


                            int lastOctet = int.Parse(BoardIp.Split('.').Last());

                            if (lastOctet >= 130 && lastOctet <= 160)
                            {
                                if (BaseClass.GettruecolorAgdbstatus(BoardIp))
                                {
                                    trimmedserverReceivedBytes = serverReceivedBytes;
                                    // linkSucess = ByteFormation.validatetruecolorGetConfiguration(trimmedserverReceivedBytes, trimmedLinkCheckPacket);

                                }
                                else
                                {
                                    trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                                    // linkSucess = ByteFormation.validateGetConfiguration(trimmedserverReceivedBytes, trimmedLinkCheckPacket);

                                }


                            }
                            else
                            {
                                trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);


                            }


                            linkSucess = ByteFormation.validateGetConfiguration(trimmedserverReceivedBytes, GetConfigurationPacket);

                            if (!linkSucess)
                            {
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

        private void btnSetConfiguration_Click(object sender, EventArgs e)
        {

            try
            {
                (bool hasBoard, string BoardIp, int packet, int cdcid) = GetBoardIpAndPacketCdcid();

                if (hasBoard)
                {
                    if (Server._connectedClients.Count > 0)
                    {
                        byte[] SetConfigurationPacket;
                        int lastOctet = int.Parse(BoardIp.Split('.').Last());

                        if (lastOctet >= 130 && lastOctet <= 160)
                        {
                            if (BaseClass.GettruecolorAgdbstatus(BoardIp))
                            {

                                SetConfigurationPacket = frmBoardDiagnosis.SetConfigurationtruecolorAgdb(BoardIp, packet, cdcid);
                            }
                            else
                            {
                                SetConfigurationPacket = frmBoardDiagnosis.SetConfigurationTadb(BoardIp, packet, cdcid);

                            }
                        }
                        else
                        {
                            SetConfigurationPacket = frmBoardDiagnosis.SetConfigurationTadb(BoardIp, packet, cdcid);

                        }


                        byte[] serverReceivedBytes = Server.GetReceivedBytes;
                        byte[] trimmedserverReceivedBytes = serverReceivedBytes;
                        if (BaseClass.Getinteroperabilitystatus(BoardIp))
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
                        if (serverReceivedBytes.Length <= 13)
                        {
                            MessageBox.Show("SET CONFIGURATION failed", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            bool linkSucess = false;


                            if (lastOctet >= 130 && lastOctet <= 160)
                            {
                                if (BaseClass.GettruecolorAgdbstatus(BoardIp))
                                {
                                    trimmedserverReceivedBytes = serverReceivedBytes;
                                    // linkSucess = ByteFormation.validateTruecolorAgdbSetConfiguration(trimmedserverReceivedBytes, SetConfigurationPacket);

                                }
                                else
                                {
                                    trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                                    // linkSucess = ByteFormation.validateSetConfiguration(trimmedserverReceivedBytes, SetConfigurationPacket);
                                }


                            }
                            else
                            {
                                trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);


                            }
                            linkSucess = ByteFormation.validateSetConfiguration(trimmedserverReceivedBytes, SetConfigurationPacket);
                            //byte[] trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                            //byte[] trimmedLinkCheckPacket = ByteFormation.RemoveFirstAndLast6(SetConfiguration);

                            //bool linkSucess = ByteFormation.validateSetConfiguration(trimmedserverReceivedBytes, trimmedLinkCheckPacket);


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

                        byte[] DeleteDataPacket = frmBoardDiagnosis.DeleteData(BoardIp, packet);
                        byte[] serverReceivedBytes = Server.GetReceivedBytes;
                        byte[] trimmedserverReceivedBytes = serverReceivedBytes;
                        if (BaseClass.Getinteroperabilitystatus(BoardIp))
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
                        // Check if received bytes are empty
                        if (serverReceivedBytes.Length <= 13)
                        {
                            MessageBox.Show("Delete Data failed", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {



                            bool linkSucess = false;


                            int lastOctet = int.Parse(BoardIp.Split('.').Last());

                            if (lastOctet >= 130 && lastOctet <= 160)
                            {
                                if (BaseClass.GettruecolorAgdbstatus(BoardIp))
                                {
                                    trimmedserverReceivedBytes = serverReceivedBytes;
                                    // linkSucess = ByteFormation.validateDeleteData(trimmedserverReceivedBytes, DeleteDataPacket);

                                }
                                else
                                {
                                    trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                                }

                            }
                            else
                            {
                                trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);


                            }


                            linkSucess = ByteFormation.validateDeleteData(trimmedserverReceivedBytes, DeleteDataPacket);


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

                    var cell = row.Cells["dgvBoardIP"];
                    if (cell != null && cell.Value != null)
                    {


                        var BoardIp = cell.Value.ToString().Trim();
                        // Assuming the IP address is always after the last underscore
                        if (Server._connectedClients.Count > 0)
                        {


                            int packet = Board.GetPacketIdentifier(BoardIp);


                            byte[] LinkCheckPacket = frmBoardDiagnosis.LinkCheckPacket(BoardIp, packet);
                            byte[] serverReceivedBytes = Server.GetReceivedBytes;
                            byte[] trimmedserverReceivedBytes = serverReceivedBytes;
                            if (BaseClass.Getinteroperabilitystatus(BoardIp))
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
                                System.Threading.Thread.Sleep(2000);
                                serverReceivedBytes = Server.GetReceivedBytes;
                                trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);

                            }

                            // Check if received bytes are empty
                            if (serverReceivedBytes.Length <= 19)
                            {
                                status = false;
                                label += "\nLINK CHECK Fail: " + BoardIp;
                                DeActivateLinkCheck(BoardIp);
                            }
                            else
                            {

                                bool linkSucess = false;


                                int lastOctet = int.Parse(BoardIp.Split('.').Last());

                                if (lastOctet >= 130 && lastOctet <= 160)
                                {
                                    if (BaseClass.GettruecolorAgdbstatus(BoardIp))
                                    {
                                        trimmedserverReceivedBytes = serverReceivedBytes;
                                        //  linkSucess = ByteFormation.validateTruecolorLinkCheck(trimmedserverReceivedBytes, LinkCheckPacket);

                                    }
                                    else
                                    {
                                        trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);
                                        //  linkSucess = ByteFormation.validateLinkCheck(trimmedserverReceivedBytes, LinkCheckPacket);

                                    }


                                }
                                else
                                {
                                    trimmedserverReceivedBytes = ByteFormation.RemoveFirstAndLast6(serverReceivedBytes);


                                }

                                linkSucess = ByteFormation.validateLinkCheck(trimmedserverReceivedBytes, LinkCheckPacket);


                                if (!linkSucess)
                                {
                                    status = true;
                                    label += "\nLINK CHECK Fail: " + BoardIp;
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
                                    label += "\n" + receivedHex + "\nIntensity: " + intensity + "\nData Timeout: " + dataTimeout + "\nLINK CHECK SUCCESS of: " + BoardIp;
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

     

        private void dgvCommunication_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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
                        DeActivateLinkCheck(BoardIp);
                        MessageBox.Show("Error Data failed", "Error Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

