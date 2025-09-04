using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmLink : Form
    {
        public frmLink()
        {
            InitializeComponent();
        }

        private frmIndex parentForm;

        public frmLink(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void btnDisplayBoards_Click(object sender, EventArgs e)
        {
            GetTadbBoards();
        }

        public void GetTadbBoards()
        {
            DatagridCgdb.Visible = false;
            DgvBoards.Visible = true;

            List<int> packetIdentifiers = new List<int> { 3, 4, 5 };

            // Fetch data from the database
            DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

            addBoards(boards);

        }

        public void addBoards(DataTable boards)
        {
            try
            {

                DgvBoards.Rows.Clear();
                foreach (DataRow row in boards.Rows)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(DgvBoards);

                    dgvRow.Cells[DgvBoards.Columns["DgvBoardName"].Index].Value = row["Location"].ToString();
                    dgvRow.Cells[DgvBoards.Columns["dgvIpAddress"].Index].Value = row["IPAddress"].ToString();
                    dgvRow.Cells[DgvBoards.Columns["DgvBoardType"].Index].Value = BaseClass.GetPacketname(Convert.ToInt32(row["PacketIdentifier"].ToString()));
                    //dgvRow.Cells[DgvBoards.Columns["DgvLink"].Index].Value = GetLinkBasedOnipadress(row["IPAddress"].ToString());
                    dgvRow.Cells[DgvBoards.Columns["DgvLink"].Index].Value = GetDataTransferBasedOnipadress(row["LinkStatus"].ToString());



                    dgvRow.Cells[DgvBoards.Columns["DgvDataTransfer"].Index].Value = GetDataTransferBasedOnipadress(row["DataTransfer"]?.ToString());

                    DgvBoards.Rows.Add(dgvRow);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public void CgdbBoards(DataTable boards)
        {
            try
            {


                // Clear existing rows in the DataGridView
                DatagridCgdb.Rows.Clear();

                foreach (DataRow row in boards.Rows)
                {
                    if (boards.Columns.Contains("PkeyMasterhub") && int.TryParse(row["PkeyMasterhub"]?.ToString(), out int PkMasterHub))
                    {
                        string pdcip = row["IPAddress"]?.ToString();
                        string platform = row["Platform"]?.ToString();

                        foreach (DataRow eachrow in BaseClass.CgdbHubPorts.Rows)
                        {
                            if (BaseClass.CgdbHubPorts.Columns.Contains("fkey_CDC") && int.TryParse(eachrow["fkey_CDC"]?.ToString(), out int fkey_CDC))
                            {
                                if (PkMasterHub == fkey_CDC)
                                {
                                    DataGridViewRow dgvRow = new DataGridViewRow();
                                    dgvRow.CreateCells(DatagridCgdb);

                                    dgvRow.Cells[DatagridCgdb.Columns["dgvPlatformNo"].Index].Value = "Pf_No_" + platform;
                                    dgvRow.Cells[DatagridCgdb.Columns["DgvPdcIp"].Index].Value = pdcip;
                                    dgvRow.Cells[DatagridCgdb.Columns["DgvCdgdbIp"].Index].Value = eachrow["Cgdb_IpAddress"]?.ToString();
                                    // dgvRow.Cells[DatagridCgdb.Columns["dgvCgdbLinkCheck"].Index].Value = GetLinkBasedOnipadress(eachrow["Cgdb_IpAddress"]?.ToString());
                                    dgvRow.Cells[DatagridCgdb.Columns["dgvCgdbLinkCheck"].Index].Value = GetDataTransferBasedOnipadress(eachrow["LinkCheck"]?.ToString());
                                    dgvRow.Cells[DatagridCgdb.Columns["dgvCgdbDataTransfer"].Index].Value = GetDataTransferBasedOnipadress(eachrow["DataTransfer"]?.ToString());

                                    DatagridCgdb.Rows.Add(dgvRow);
                                }
                            }
                        }
                    }
                }

                // Clear selection and set the current cell to null
                DatagridCgdb.ClearSelection();
                DatagridCgdb.CurrentCell = null;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        public Image GetDataTransferBasedOnipadress(string value)
        {


            if (string.IsNullOrEmpty(value))
            {
                // Handle null or empty string by returning a default image (e.g., red icon)
                return Properties.Resources._34214_circle_green_icon;
            }

            bool isTrue;
            if (bool.TryParse(value, out isTrue))
            {
                // If parsing succeeds, return the corresponding image
                if (isTrue)
                {
                    return Properties.Resources._34211_green_icon1; // True image (e.g., green icon)
                }
                else
                {
                    return Properties.Resources._34214_circle_green_icon; // False image (e.g., red icon)
                }
            }
            else
            {
                // Handle cases where value is not a valid boolean
                return Properties.Resources._34214_circle_green_icon; // Default image for invalid input
            }


        }
        public Image GetLinkBasedOnipadress(string ipaddress)
        {
            if (Server._connectedClients.TryGetValue(ipaddress, out TcpClient client))
            {
                return Properties.Resources._34211_green_icon1;

            }
            else
            {
                // Handle cases where value is not a valid boolean
                return Properties.Resources._34214_circle_green_icon; // Default image for invalid input
            }


        }



        private void btnCoachBoards_Click(object sender, EventArgs e)
        {
            try
            {

                DgvBoards.Visible = false;
                DatagridCgdb.Visible = true;

                BaseClass.setCgdbHub();
                List<int> packetIdentifiers = new List<int> { 1 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);
                CgdbBoards(boards);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnIvdOvd_Click(object sender, EventArgs e)
        {
            try
            {
                DatagridCgdb.Visible = false;
                DgvBoards.Visible = true;
                List<int> packetIdentifiers = new List<int> { 6, 7 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);
                addBoards(boards);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private void frmLink_Load(object sender, EventArgs e)
        {
            GetTadbBoards();
        }
    }
}
