using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.UserForms
{
    public partial class frmUserGroups : Form
    {
        private const string PlaceholderText = "Search here...";
        private DataTable userData;
        public frmUserGroups()
        {
            InitializeComponent();
        }

        private void frmUserGroups_Load(object sender, EventArgs e)
        {
            txtSearch.Text = PlaceholderText;
            SetRoles();
            SetMenu();


        }
        private void SetRoles()
        {
            try
            {


                // Clear existing items in the ComboBox
                cmbRoles.Items.Clear();
                // Assuming BaseClass.Platforms is a collection of platform names
                foreach (var role in BaseClass.AdminRolesList)
                {
                    // Trim the platform name
                    string trimmedrole = role.Trim();

                    // Add the trimmed platform name to the ComboBox
                    cmbRoles.Items.Add(trimmedrole);
                }
                // Select the default item "--Select--"
                cmbRoles.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Server.LogError("SetRoles()" + ex.Message);
            }

        }

        private void SetMenu()
        {
            try
            {
                string userlevel = cmbRoles.Text;
                int rolepk = BaseClass.GetAdminRolesPk(userlevel);
                string fkeyMenus = GetFkeysMenuByRole(rolepk);
                List<int> fkeylist = GetPkListFromCheckedRows(fkeyMenus);

                // Fetch data from the database
                DataTable dt = BaseClass.AdminMenussDt;
                userData = dt.Copy();
                // Clear existing rows in the DataGridView
                dgvgroups.Rows.Clear();

                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in dt.Rows)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(dgvgroups);

                    int pk = Convert.ToInt32(row["Pkey_Menu"].ToString().Trim());
                    dgvRow.Cells[dgvgroups.Columns["dgvCheckBox"].Index].Value = ContainsValue(fkeylist, pk);
                    dgvRow.Cells[dgvgroups.Columns["dgvMenu"].Index].Value = row["Menu"].ToString().Trim();
                    dgvRow.Cells[dgvgroups.Columns["dgvForm"].Index].Value = row["form"].ToString().Trim();



                    dgvgroups.Rows.Add(dgvRow);
                }
                var columnNames = dgvgroups.Columns.Cast<DataGridViewColumn>()
                      .Skip(1)
                      .Select(c => c.HeaderText)
                      .ToList();
                chkFilter.Items.Clear();

                foreach (var columnName in columnNames)
                {
                    chkFilter.Items.Add(columnName);
                }
                for (int i = 0; i < chkFilter.Items.Count; i++)
                {
                    chkFilter.SetItemChecked(i, true);
                }
                chkFilter.BackColor = Color.LightSalmon;

                dgvgroups.CurrentCell = null;
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

        private frmIndex parentForm;
        public frmUserGroups(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

            SetMenu();
        }
        public static string GetFkeysMenuByRole(int rolePk)
        {
            try
            {


                // Retrieve the DataTable containing the resources for the given role
                DataTable dt = UserDb.GetResourcesbyRole(rolePk);



                // Loop through each row in the DataTable
                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("Fkey_Role") && int.TryParse(row["Fkey_Role"].ToString(), out int fkeyrole))
                    {
                        if (fkeyrole == rolePk)
                        {


                            // Extract the Fkeys_Menu value from the current row (assuming it's a string)
                            string fkeyMenu = row["Fkeys_Menu"].ToString().Trim();

                            return fkeyMenu;
                        }

                    }
                }

                // Return the concatenated comma-separated string

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return null;
        }
        public static bool ContainsValue(List<int> list, int value)
        {
            // Check if the list contains the specified value
            return list.Contains(value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userlevel = cmbRoles.Text;
            int rolepk = BaseClass.GetAdminRolesPk(userlevel);


            List<DataGridViewRow> checkedRows = GetCheckedRows(dgvgroups);

            string pkvalues = GetCheckedRowsMenusPk(checkedRows);

            int effectedrows = UserDb.InsertUpdateUserGroups(rolepk, pkvalues);
            if (effectedrows > 0)
            {
                MessageBox.Show($"Details Saved Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public string GetCheckedRowsMenusPk(List<DataGridViewRow> checkedRows)
        {


            // Use StringBuilder for efficient string concatenation
            StringBuilder pkValues = new StringBuilder();
            try
            {



                // Loop through the checked rows
                foreach (DataGridViewRow checkedRow in checkedRows)
                {
                    // Get the value from the second column
                    var value = checkedRow.Cells[1].Value?.ToString();

                    if (!string.IsNullOrEmpty(value))
                    {
                        // Get the primary key using the BaseClass method
                        int pk = BaseClass.GetAdminMenupk(value);

                        // Append the pk to the StringBuilder
                        if (pkValues.Length > 0)
                        {
                            pkValues.Append(",");
                        }
                        pkValues.Append(pk);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            return pkValues.ToString();
        }

        public static List<int> GetPkListFromCheckedRows(string pkValues)
        {
            // Create a list to hold the primary key values
            List<int> pkList = new List<int>();

            // Check if the input string is not null or empty
            if (!string.IsNullOrEmpty(pkValues))
            {
                // Split the string into an array of pk values using the comma as a delimiter
                string[] pkArray = pkValues.Split(',');

                // Loop through each value in the array
                foreach (string pkValue in pkArray)
                {
                    // Try to parse the pk value as an integer
                    if (int.TryParse(pkValue, out int pk))
                    {
                        // If successful, add the integer to the list
                        pkList.Add(pk);
                    }
                }
            }

            return pkList;
        }


        public List<DataGridViewRow> GetCheckedRows(DataGridView dgv)
        {
            // List to hold the rows with checked checkboxes
            List<DataGridViewRow> checkedRows = new List<DataGridViewRow>();

            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Check if the checkbox in the first column is checked
                if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                {
                    // Add the row to the list of checked rows
                    checkedRows.Add(row);
                }
            }

            return checkedRows;
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            btnCross.Visible = true;
            btnSearch1.Visible = false;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == PlaceholderText)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
            btnCross.Visible = true;
            btnSearch1.Visible = false;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = PlaceholderText;
                txtSearch.ForeColor = Color.Gray;
            }
        }
        private List<string> selectedColumns = new List<string>();
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {


                string searchText = txtSearch.Text.Trim();

                selectedColumns.Clear();
                foreach (var item in chkFilter.CheckedItems)
                {
                    string columnName = item.ToString();
                    if (!selectedColumns.Contains(columnName))
                    {
                        selectedColumns.Add(columnName);
                    }
                }

                if (string.IsNullOrEmpty(searchText) || (searchText == PlaceholderText))
                {
                    foreach (DataGridViewRow row in dgvgroups.Rows)
                    {
                        row.Visible = true;
                    }
                }
                else
                {
                    FilterRows(searchText);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }






        private void FilterRows(string searchText)
        {
            try
            {


                foreach (DataGridViewRow row in dgvgroups.Rows)
                {
                    row.Visible = false;
                }

                string searchLowerCase = searchText.ToLower();

                foreach (DataGridViewRow row in dgvgroups.Rows)
                {
                    bool matchFound = false;

                    foreach (DataGridViewColumn column in dgvgroups.Columns)
                    {
                        // Check if the column's header text is in the list of selected columns
                        if (selectedColumns.Contains(column.HeaderText))
                        {
                            int columnIndex = column.Index;
                            string cellValue = row.Cells[columnIndex].Value?.ToString().ToLower();

                            if (cellValue != null && cellValue.Contains(searchLowerCase))
                            {
                                matchFound = true;
                                break;
                            }
                        }
                    }

                    row.Visible = matchFound;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        public static bool chkvisible = true;
        private void btndropdown_Click(object sender, EventArgs e)
        {
            if (chkvisible)
            {
                chkFilter.Visible = true;
                chkvisible = false;
            }
            else
            {
                chkFilter.Visible = false;
                chkvisible = true;
            }
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            try
            {



                txtSearch.Text = PlaceholderText;
                txtSearch.ForeColor = Color.Gray;
                foreach (DataGridViewRow row in dgvgroups.Rows)
                {
                    row.Visible = true;
                }
                btnCross.Visible = false;
                btnSearch1.Visible = true;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
    }
}
