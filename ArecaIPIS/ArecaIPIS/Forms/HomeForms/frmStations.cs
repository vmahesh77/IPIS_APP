using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.HomeForms
{
    public partial class frmStations : Form
    {
        public frmStations()
        {
            InitializeComponent();
        }

        private void frmStations_Load(object sender, EventArgs e)
        {
            fillStations();
        }

        public void fillStations()
        {
            try
            {


                DataTable DivertedToTerminatedStationsDt = OnlineTrainsDao.GetDivertedToTerminatedStationsNames();

                dgvStations.Rows.Clear();



                foreach (DataRow row in DivertedToTerminatedStationsDt.Rows)
                {
                    int rowIndex = dgvStations.Rows.Add();

                    dgvStations.Rows[rowIndex].Cells["dgvEnglishcolumn"].Value = row["stationeng"].ToString();
                    dgvStations.Rows[rowIndex].Cells["dgvHindiColumn"].Value = row["stationhind"].ToString();
                    dgvStations.Rows[rowIndex].Cells["dgvRegional"].Value = row["stationreg1"].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStations_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStations_Deactivate(object sender, EventArgs e)
        {

        }
        public static List<DataGridViewRow> checkedRows = new List<DataGridViewRow>();

        public static List<DataGridViewRow> stationlist = new List<DataGridViewRow>();
        private void dgvStations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {


                checkedRows.Clear();
                foreach (DataGridViewRow row in dgvStations.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (Convert.ToBoolean(row.Cells["DgvSelectColumn"].EditedFormattedValue))
                        {
                            checkedRows.Add(row);
                        }
                    }
                }



                DataGridViewRow row1 = dgvStations.CurrentRow;
                string station = row1.Cells["dgvEnglishcolumn"].ToString();

                if (BaseClass.SchStatCode != 16)//Diverted
                {
                    foreach (DataGridViewRow row in dgvStations.Rows)
                    {
                        if (station != row.Cells["dgvEnglishcolumn"].Value?.ToString())
                        {

                            row.Cells["DgvSelectColumn"].Value = false;
                        }

                    }
                }
                else
                {
                    if (checkedRows.Count > 3)
                    {
                        foreach (DataGridViewRow row in dgvStations.Rows)
                        {
                            if (station != row.Cells["dgvEnglishcolumn"].Value?.ToString())
                            {

                                row.Cells["DgvSelectColumn"].Value = false;
                            }

                        }
                        MessageBox.Show("only select 3 cities");
                    }


                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void dgvStations_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                checkedRows.Clear();
                foreach (DataGridViewRow row in dgvStations.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (Convert.ToBoolean(row.Cells["DgvSelectColumn"].EditedFormattedValue))
                        {
                            checkedRows.Add(row);
                        }
                    }
                }
                if (checkedRows.Count > 0)
                {
                    frmOnlineTrains.ChangeCity(BaseClass.currentdatgridRow, checkedRows);
                }
                this.Close();

                Form frmOnline = Application.OpenForms["frmOnlineTrains"];
                if (frmOnline != null)
                {
                    frmOnlineTrains frm = (frmOnlineTrains)frmOnline;


                    frm.SaveChanges(BaseClass.currentdatgridRow);
                    //frm.SaveChangesInScheduleTrains();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
    }
}


