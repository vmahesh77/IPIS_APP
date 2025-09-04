using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmNetWorkCds : Form
    {
        private frmHome parentForm;
        public frmNetWorkCds()
        {
            InitializeComponent();
        }
        public frmNetWorkCds(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void dgvCommunication_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panCommunication_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCommunication_Click(object sender, EventArgs e)
        {

        }

        private void frmNetWorkCds_Load(object sender, EventArgs e)
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

                    dgvRow.Cells[dgvCommunication.Columns["dgvPdcIp"].Index].Value = row["IPAddress"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvPDCName"].Index].Value = row["Location"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvPortNo"].Index].Value = row["PortNo"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvPlatformNo"].Index].Value = row["Platform"];

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
    }
}
