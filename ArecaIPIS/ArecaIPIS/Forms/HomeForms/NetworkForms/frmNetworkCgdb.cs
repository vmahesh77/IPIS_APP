using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmNetworkCgdb : Form
    {
        public frmNetworkCgdb()
        {
            InitializeComponent();
        }
        private frmHome parentForm;

        public frmNetworkCgdb(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void frmNetworkCgdb_Load(object sender, EventArgs e)
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
    }
}
