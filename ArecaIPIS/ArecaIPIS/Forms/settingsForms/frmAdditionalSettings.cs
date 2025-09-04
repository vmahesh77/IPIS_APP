using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.HomeForms
{
    public partial class frmAdditionalSettings : Form
    {
        public frmAdditionalSettings()
        {
            InitializeComponent();
        }
        private frmIndex parentForm;

        public frmAdditionalSettings(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void frmAdditionalSettings_Load(object sender, EventArgs e)
        {
            DataTable dt = AdditionalSettingsDao.PlatformNumberSize();
            BaseClass.AllCoachesClass = AdditionalSettingsDao.GetCoachClassesData();
            LoadAllCoachesClass();
        }

        public void LoadAllCoachesClass()
        {
            dgvCoachClasses.Rows.Clear();
            DataTable dt = AdditionalSettingsDao.GetCoachClassesData();


            foreach (DataRow row in dt.Rows)
            {
                int rowIndex = dgvCoachClasses.Rows.Add();
                dgvCoachClasses.Rows[rowIndex].Cells["dgvSnoColumn"].Value = "" + (rowIndex + 1);
                dgvCoachClasses.Rows[rowIndex].Cells["dgvClassName"].Value = row["ClassName"].ToString();
                dgvCoachClasses.Rows[rowIndex].Cells["dgvCoachCode"].Value = row["CoachCode"].ToString();
            }
        }




        private void rndSaveClass_Click(object sender, EventArgs e)
        {
            AdditionalSettingsDao.InsertCoachClass(rctClassName.Text, rctAudioName.Text, rctCoachCode.Text, rctAudioPath.Text);
            showPanelCoaches(false);
        }

        private void rndDeleteClass_Click(object sender, EventArgs e)
        {
            AdditionalSettingsDao.DeleteCoachClass(rctClassName.Text);

        }

        private void rndBtnCoachClass_Click(object sender, EventArgs e)
        {
            showPanelCoaches(true);
        }

        private void dgvCoachClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCoachClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if ((e.RowIndex >= 0 && (dgvCoachClasses.Columns[e.ColumnIndex].Name == "dgvEdit") && e.RowIndex <= dgvCoachClasses.Rows.Count - 2))
                {


                    showPanelCoaches(true);




                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }

        public void showPanelCoaches(bool flag)
        {
            
            try
            {
                pnlEdit.Visible = flag;
                if (flag)
                {
                    string ClassName = dgvCoachClasses.CurrentRow.Cells["dgvClassName"].Value.ToString();
                    if (ClassName != null)
                    {


                        DataTable dt = AdditionalSettingsDao.retrieveCoachClass(ClassName);

                        rctClassName.Text = dt.Rows[0].Field<string>("ClassName");
                        rctAudioName.Text = dt.Rows[0].Field<string>("AudioName");
                        rctAudioPath.Text = dt.Rows[0].Field<string>("AudioPath");
                        rctCoachCode.Text = dt.Rows[0].Field<string>("CoachCode");
                    }
                }
            }
            catch(Exception e)
            {
                Server.LogError(e.Message);
            }

        }

        private void rndClose_Click(object sender, EventArgs e)
        {
            showPanelCoaches(false);
        }
    }
}
