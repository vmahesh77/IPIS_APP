using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.HomeForms
{
    public partial class frmScheduledTrains : Form
    {
        public frmScheduledTrains()
        {
            InitializeComponent();
        }

        private void frmScheduledTrains_Load(object sender, EventArgs e)
        {
            fillScheduledTrains();
        }
        private void FilterData(string searchTerm)
        {
            try
            {

                if (dgvScheduledRunningTrains.IsCurrentCellDirty)
                {
                    dgvScheduledRunningTrains.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

                foreach (DataGridViewRow row in dgvScheduledRunningTrains.Rows)
                {
                    if (row.IsNewRow) continue; // Skip the new row placeholder

                    bool isVisible = row.Cells.Cast<DataGridViewCell>()
                                              .Any(cell => cell.Value != null && cell.Value.ToString().ToLower().Contains(searchTerm));
                    row.Visible = isVisible;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public void fillScheduledTrains()
        {
            try
            {
                DataTable scheduledTrainsdt;
                if (BaseClass.selectTrainsDatabase == "AllTrains")
                {
                    scheduledTrainsdt = OnlineTrainsDao.GetAllTrains();
                }
                else
                {
                    scheduledTrainsdt = OnlineTrainsDao.GetTrains();
                }
                dgvScheduledRunningTrains.Rows.Clear();
                foreach (DataRow row in scheduledTrainsdt.Rows)
                {
                    int rowIndex = dgvScheduledRunningTrains.Rows.Add();
                    dgvScheduledRunningTrains.Rows[rowIndex].Cells["dgvTrainNo"].Value = row["TrainNumber"].ToString();
                    dgvScheduledRunningTrains.Rows[rowIndex].Cells["dgvCategory"].Value = row["Category"].ToString();
                    dgvScheduledRunningTrains.Rows[rowIndex].Cells["dgvTrainName"].Value = row["EnglishName"].ToString();
                    dgvScheduledRunningTrains.Rows[rowIndex].Cells["dgvSource"].Value = row["Source"].ToString();
                    dgvScheduledRunningTrains.Rows[rowIndex].Cells["dgvDestination"].Value = row["Destination"].ToString();
                    dgvScheduledRunningTrains.Rows[rowIndex].Cells["dgvArrTime"].Value = row["ArrivalTime"].ToString();
                    dgvScheduledRunningTrains.Rows[rowIndex].Cells["dgvDeptTime"].Value = row["DepartureTime"].ToString();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void dgvScheduledRunningTrains_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rtxtSerachHere_Click(object sender, EventArgs e)
        {
            rtxtSerachHere.Text = "";
            if (rtxtSerachHere.Text != "")
            {
                SearchData(rtxtSerachHere.Text);
            }

        }

        private void dgvScheduledRunningTrains_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmScheduledTrains_Leave(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["frmScheduledTrains"];

            if (mainForm != null)
            {
                frmScheduledTrains frmScheduled = (frmScheduledTrains)mainForm;
                frmScheduled.Close();
            }
        }

        private void pnlImage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rtxtSerachHere_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = rtxtSerachHere.Text.ToLower();
            FilterData(searchTerm);
        }



        private void SearchData(string searchQuery)
        {
            try
            {
                DataTable trainNumber = OnlineTrainsDao.getTrainNumber(searchQuery);

                if (trainNumber != null && trainNumber.Rows.Count > 0)
                {
                    DataTable displayTable = new DataTable();
                    displayTable.Columns.Add("TrainNumber", typeof(string));
                    displayTable.Columns.Add("EnglishName", typeof(int));

                    foreach (DataRow row in trainNumber.Rows)
                    {
                        displayTable.Rows.Add(row["TrainNumber"]);
                        displayTable.Rows.Add(row["EnglishName"]);

                        // newRow["Pkey_SpclMsgs"] = row["Pkey_SpclMsgs"];
                    }

                    dgvScheduledRunningTrains.DataSource = displayTable;
                    dgvScheduledRunningTrains.AllowUserToAddRows = false;
                    //dgvScheduledRunningTrains.Columns["Pkey_SpclMsgs"].Visible = false;

                    int totalHeight = dgvScheduledRunningTrains.ColumnHeadersHeight;
                    foreach (DataGridViewRow row in dgvScheduledRunningTrains.Rows)
                    {
                        totalHeight += row.Height;
                    }
                    dgvScheduledRunningTrains.Height = totalHeight;
                }
                else
                {
                    dgvScheduledRunningTrains.DataSource = null;
                    //  lblNoDataToDisplay.Visible = true;
                    MessageBox.Show("No data to display.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        private void frmScheduledTrains_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvScheduledRunningTrains_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (BaseClass.selectTrainsDatabase == "ScheduledTrains")
                {
                    if (e.RowIndex >= 0)
                    {

                        Form mainForm = Application.OpenForms["frmOnlineTrains"];


                        if (mainForm != null)
                        {
                            DataGridViewRow row = dgvScheduledRunningTrains.Rows[e.RowIndex];
                            string trainNumber = row.Cells["dgvTrainNo"].Value.ToString();

                            if (trainNumber != null)
                            {
                                OnlineTrainsDao.DeleteTrainByNumber(trainNumber);
                            }

                            frmOnlineTrains frmonline = (frmOnlineTrains)mainForm;

                            frmonline.fillRunningTrains();

                            fillScheduledTrains();



                        }
                        else
                        {
                            MessageBox.Show("Something Went Wrong");
                        }

                    }
                    else
                    {

                    }

                }
                else if (BaseClass.selectTrainsDatabase == "AllTrains")
                {
                    DataGridViewRow row = dgvScheduledRunningTrains.Rows[e.RowIndex];
                    string trainNumber = row.Cells["dgvTrainNo"].Value.ToString();

                    Form trainInformation = Application.OpenForms["frmTrainInformation"];

                    if (trainInformation != null)
                    {
                        frmTrainInformation frmtrain = (frmTrainInformation)trainInformation;
                        frmtrain.fillTrainInformation(trainNumber);
                    }


                }

                Form form = Application.OpenForms["frmScheduledTrains"];

                if (form != null)
                {
                    frmScheduledTrains frmScheduled = (frmScheduledTrains)form;
                    frmScheduled.Close();




                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
    }
}
