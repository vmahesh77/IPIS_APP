using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmNetworkTadb : Form
    {
        public frmNetworkTadb()
        {
            InitializeComponent();
        }
        private frmHome parentForm;

        public frmNetworkTadb(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void frmNetworkTadb_Load(object sender, EventArgs e)
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

    }
}
