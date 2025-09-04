using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Server_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmIntensity : Form
    {
        public frmIntensity()
        {
            InitializeComponent();

        }
        private frmIndex parentForm;

        public frmIntensity(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void frmIntensity_Load(object sender, EventArgs e)
        {

            GetTadbBoards();
            GetCgdbBoards();
        }
        public void GetTadbBoards()
        {
            try
            {
                List<int> packetIdentifiers = new List<int> { 3, 4, 5, 6, 7 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                // Clear existing rows in the DataGridView
                dGVIntensity.Rows.Clear();
                int sno = 1;

                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in boards.Rows)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(dGVIntensity);

                    dgvRow.Cells[dGVIntensity.Columns["dgvSNo"].Index].Value = sno;
                    dgvRow.Cells[dGVIntensity.Columns["dgvLocation"].Index].Value = row["Location"];
                    dgvRow.Cells[dGVIntensity.Columns["dgvBoardip"].Index].Value = row["IPAddress"];
                    dgvRow.Cells[dGVIntensity.Columns["dgvBoardType"].Index].Value = Board.GetBoardType(row["PacketIdentifier"].ToString());
                    dgvRow.Cells[dGVIntensity.Columns["dgvCurrentIntensity"].Index].Value = frmBoardDiagnosis.GetIntensityTadb(Convert.ToInt32(row["PkeyMasterhub"]));
                    dgvRow.Cells[dGVIntensity.Columns["dgvNewIntensity"].Index].Value = frmBoardDiagnosis.GetIntensityTadb(Convert.ToInt32(row["PkeyMasterhub"]));

                    // Add the row to the DataGridView
                    dGVIntensity.Rows.Add(dgvRow);


                    sno++;
                }
                // AddTrackBarsToColumn(dGVIntensity, dGVIntensity.Columns["dgvUpdateIntensity"].Index);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public void GetCgdbBoards()
        {
            try
            {
                BaseClass.setCgdbHub();

                List<int> packetIdentifiers = new List<int> { 1 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);
                if (boards == null)
                {
                    // MessageBox.Show("Failed to fetch boards data.");
                    return;
                }

                // Clear existing rows in the DataGridView
                dgvCgdbPorts.Rows.Clear();

                foreach (DataRow row in boards.Rows)
                {
                    if (boards.Columns.Contains("PkeyMasterhub") && int.TryParse(row["PkeyMasterhub"].ToString(), out int PkMasterHub))
                    {
                        string pdcip = row["IPAddress"].ToString();
                        string platform = row["Platform"].ToString();

                        DataTable cgdbBoards = HubConfigurationDb.GetCoaches(PkMasterHub);
                        if (cgdbBoards == null)
                        {
                            // MessageBox.Show($"Failed to fetch CGDB boards for master hub: {PkMasterHub}");
                            continue;
                        }

                        if (cgdbBoards.Rows.Count > 0)
                        {
                            int sno = 1;
                            int intensity = CgdbController.GetIntensityCgdbboard(PkMasterHub);

                            DataGridViewRow dgvRow = new DataGridViewRow();
                            dgvRow.CreateCells(dgvCgdbPorts);



                            dgvRow.Cells[dgvCgdbPorts.Columns["dgvsn"].Index].Value = sno;
                            dgvRow.Cells[dgvCgdbPorts.Columns["dgvCPlatformNo"].Index].Value = "PFNo :" + platform;
                            dgvRow.Cells[dgvCgdbPorts.Columns["dgcCboardType"].Index].Value = "CGDB";
                            dgvRow.Cells[dgvCgdbPorts.Columns["dgvPDCIP"].Index].Value = row["IPAddress"].ToString();
                            dgvRow.Cells[dgvCgdbPorts.Columns["dgvCOldIntensity"].Index].Value = intensity;
                            dgvRow.Cells[dgvCgdbPorts.Columns["dgvCNewIntensity"].Index].Value = intensity;

                            dgvCgdbPorts.Rows.Add(dgvRow);
                            sno++;
                        }
                    }
                }

                // Clear selection and set the current cell to null
                dgvCgdbPorts.ClearSelection();
                dgvCgdbPorts.CurrentCell = null;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            txtIntensity.Text = trackBarAll.Value.ToString();
        }


        private void tBIntensity_ValueChanged(object sender, EventArgs e)
        {

        }




        private void UpdateColumnValuesTadb(string columnName, int newValue)
        {
            try
            {


                foreach (DataGridViewRow row in dGVIntensity.Rows)
                {
                    // Ensure you are not modifying the new row placeholder if in virtual mode
                    if (!row.IsNewRow)
                    {
                        // Attempt to get the cell
                        var cell = row.Cells[columnName];

                        if (cell != null)
                        {
                            // Update the cell value
                            cell.Value = newValue.ToString(); // Convert the integer to string to be safe
                        }
                        else
                        {
                            MessageBox.Show($"Column '{columnName}' does not exist.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void UpdateColumnValuesCgdb(string columnName, int newValue)
        {
            try
            {


                foreach (DataGridViewRow row in dgvCgdbPorts.Rows)
                {
                    // Ensure you are not modifying the new row placeholder if in virtual mode
                    if (!row.IsNewRow)
                    {
                        // Attempt to get the cell
                        var cell = row.Cells[columnName];

                        if (cell != null)
                        {
                            // Update the cell value
                            cell.Value = newValue.ToString(); // Convert the integer to string to be safe
                        }
                        else
                        {
                            MessageBox.Show($"Column '{columnName}' does not exist.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void dGVIntensity_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                HideTrackBar();
                if (e.ColumnIndex == dGVIntensity.Columns["dgvEdit"].Index && e.RowIndex >= 0)
                {
                    // Show TrackBar and set its initial value
                    trackBarSingle.Visible = true;
                    trackBarSingle.Tag = e.RowIndex; // Store the row index in the Tag property
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void trackBarSingle_Scroll(object sender, EventArgs e)
        {
            try
            {


                int rowIndex = (int)trackBarSingle.Tag; // Retrieve the row index
                if (rowIndex >= 0 && rowIndex < dGVIntensity.Rows.Count)
                {
                    DataGridViewRow row = dGVIntensity.Rows[rowIndex];
                    row.Cells["dgvNewIntensity"].Value = trackBarSingle.Value; // Update the specific cell
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void HideTrackBar()
        {
            trackBarSingle.Visible = false;
            trackBarCgdb.Visible = false;
        }

        private void btnSetIntensity_Click(object sender, EventArgs e)
        {
            try
            {


                DialogResult dialogResult = MessageBox.Show(" Do you want to Save Intensity?", "Save Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // User clicked 'Yes', continue with the process

                    // Hide the track bar
                    HideTrackBar();



                    // Loop through all rows in the DataGridView
                    foreach (DataGridViewRow row in dgvCgdbPorts.Rows)
                    {
                        // Ensure you are not modifying the new row placeholder if in virtual mode
                        if (!row.IsNewRow)
                        {
                            // Retrieve the current values from the DataGridView
                            if (int.TryParse(row.Cells["dgvCNewIntensity"].Value?.ToString(), out int intensity))
                            {
                                string ipAddress = row.Cells["dgvPDCIP"].Value?.ToString();


                                // Optionally, you can use the retrieved values for further processing, such as updating a database
                                BoardDiagnosisDb.UpdateDatabaseWithNewIntensity(ipAddress, intensity);
                            }
                            else
                            {
                                // Handle the case where the intensity value is not a valid integer
                                MessageBox.Show("Invalid intensity value in the row. Please check the data.");
                            }
                        }
                    }

                    foreach (DataGridViewRow row in dGVIntensity.Rows)
                    {
                        // Ensure you are not modifying the new row placeholder if in virtual mode
                        if (!row.IsNewRow)
                        {
                            // Retrieve the current values from the DataGridView
                            if (int.TryParse(row.Cells["dgvNewIntensity"].Value?.ToString(), out int intensity))
                            {
                                string ipAddress = row.Cells["dgvBoardip"].Value?.ToString();


                                // Optionally, you can use the retrieved values for further processing, such as updating a database
                                BoardDiagnosisDb.UpdateDatabaseWithNewIntensity(ipAddress, intensity);
                            }
                            else
                            {
                                // Handle the case where the intensity value is not a valid integer
                                MessageBox.Show("Invalid intensity value in the row. Please check the data.");
                            }
                        }
                    }
                    GetTadbBoards();
                    GetCgdbBoards();
                    BaseClass.RecallBoards();
                    frmHome.AutoSetConfigurationForAllBoards();
                    //if dont want to update whole uncomment this
                }
                else if (dialogResult == DialogResult.No)
                {
                    // User clicked 'No', handle accordingly
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void dgvCgdbPorts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                HideTrackBar();
                if (e.ColumnIndex == dgvCgdbPorts.Columns["dgvEditCGDb"].Index && e.RowIndex >= 0)
                {
                    // Show TrackBar and set its initial value
                    trackBarCgdb.Visible = true;
                    trackBarCgdb.Tag = e.RowIndex; // Store the row index in the Tag property
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void trackBarCgdb_Scroll(object sender, EventArgs e)
        {
            try
            {


                int rowIndex = (int)trackBarCgdb.Tag; // Retrieve the row index
                if (rowIndex >= 0 && rowIndex < dgvCgdbPorts.Rows.Count)
                {
                    DataGridViewRow row = dgvCgdbPorts.Rows[rowIndex];
                    row.Cells["dgvCNewIntensity"].Value = trackBarCgdb.Value; // Update the specific cell
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void trackBarAll_Scroll(object sender, EventArgs e)
        {
            try
            {


                trackBarSingle.Visible = false;
                trackBarCgdb.Visible = false;
                txtIntensity.Text = trackBarAll.Value.ToString();
                UpdateColumnValuesTadb("dgvNewIntensity", Convert.ToInt32(txtIntensity.Text));
                UpdateColumnValuesCgdb("dgvCNewIntensity", Convert.ToInt32(txtIntensity.Text));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void txtIntensity_TextChanged(object sender, EventArgs e)
        {
            try
            {

                trackBarSingle.Visible = false;
                trackBarCgdb.Visible = false;
                // Optionally detach the event handler to prevent recursive updates
                txtIntensity.TextChanged -= txtIntensity_TextChanged;

                // Try to parse the text to an integer
                if (int.TryParse(txtIntensity.Text, out int value))
                {
                    // Ensure the value is within a valid range (e.g., 0 to 100)
                    if (value < 0)
                    {
                        value = 0;
                    }
                    else if (value > 100)
                    {
                        value = 100;
                    }

                    // Update the TextBox with the adjusted value
                    txtIntensity.Text = value.ToString();
                    txtIntensity.SelectionStart = txtIntensity.Text.Length; // Move cursor to end

                    // Example: Update a TrackBar or another control with the adjusted value
                    if (trackBarAll.Minimum <= value && value <= trackBarAll.Maximum)
                    {
                        trackBarAll.Value = value;
                    }
                    txtIntensity.Text = trackBarAll.Value.ToString();
                    UpdateColumnValuesTadb("dgvNewIntensity", Convert.ToInt32(txtIntensity.Text));
                    UpdateColumnValuesCgdb("dgvCNewIntensity", Convert.ToInt32(txtIntensity.Text));
                }
                else
                {
                    // Optionally handle invalid input
                    // For example, you might want to clear the text or show an error
                    txtIntensity.Text = "";
                }

                // Reattach the event handler
                txtIntensity.TextChanged += txtIntensity_TextChanged;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
    }
}
