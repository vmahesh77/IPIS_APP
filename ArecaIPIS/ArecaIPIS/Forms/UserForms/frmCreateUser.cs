using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.UserForms
{
    public partial class frmCreateUser : Form
    {
        public frmCreateUser()
        {
            InitializeComponent();
        }
        int userId = -1;
        private frmIndex parentForm;
        public frmCreateUser(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            dgvUsers.CellPainting += dgvUsers_CellPainting;

        }

        private void SetRoles()
        {
            cmbUserLevel.Items.Clear();

            foreach (var role in BaseClass.AdminRolesList)
            {
                string trimmedrole = role.Trim();
                cmbUserLevel.Items.Add(trimmedrole);
            }

            cmbUserLevel.SelectedIndex = 0;
        }

        private void frmCreateUser_Load(object sender, EventArgs e)
        {
            SetRoles();
            setUsers();

        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                string username = txtUserName.Text;
                string Level = cmbUserLevel.Text;
                string password = EncodeData(txtPassword.Text);
                string confirmPassword = EncodeData(txtConfirmPassword.Text);
                bool active = chkActive.Checked;

                // Validate inputs
                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(Level))
                {
                    MessageBox.Show("User level is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int userLevel = GetuserPk(cmbUserLevel.Text);
                int rows = UserDb.InsertUpdateUserDetails(userId, username, password, userLevel, confirmPassword, active);

                if (rows >= 0)
                {
                    MessageBox.Show("User details saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearAll();

                    setUsers();
                    dgvUsers.RefreshEdit();
                    pnlcreateUser.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        public string EncodeData(string data)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(plainTextBytes);
        }
        public static int GetuserPk(string role)
        {
            foreach (DataRow row in BaseClass.AdminRolesDt.Rows)
            {
                string Approle = (row["AppRole"].ToString().Trim());
                if (Approle == role)
                {
                    return Convert.ToInt32(row["Pkey_AdminRole"].ToString().Trim());
                }
            }
            return -1;
        }

        public static string GetuserLevel(int pk)
        {
            foreach (DataRow row in BaseClass.AdminRolesDt.Rows)
            {
                int Approle = Convert.ToInt32(row["Pkey_AdminRole"].ToString().Trim());
                if (Approle == pk)
                {
                    return (row["AppRole"].ToString().Trim());
                }
            }


            return null;
        }
        public void clearAll()
        {
            txtUserName.Text = "";

            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkActive.Checked = false;
            userId = -1;


        }
        public void setUsers()
        {
            try
            {

                // Fetch data from the database
                DataTable dt = UserDb.GetAllUsers();

                // Clear existing rows in the DataGridView
                dgvUsers.Rows.Clear();

                // Import the data from the original DataTable to the DataGridView
                foreach (DataRow row in dt.Rows)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(dgvUsers);

                    // Populate cell values
                    userId = Convert.ToInt32(row["UserID"].ToString().Trim());
                    dgvRow.Cells[dgvUsers.Columns["dgvUsername"].Index].Value = row["Login"].ToString().Trim();
                    dgvRow.Cells[dgvUsers.Columns["dgvUserRole"].Index].Value = GetuserLevel(Convert.ToInt32(row["Role"].ToString().Trim()));
                    dgvRow.Cells[dgvUsers.Columns["dgvUserid"].Index].Value = row["UserID"].ToString().Trim();
                    dgvRow.Cells[dgvUsers.Columns["dgvUsername"].Index].Value = row["Login"].ToString().Trim();

                    // Check if the user is active
                    bool isActive = Convert.ToBoolean(row["Active"]);

                    // Set cell value and style based on status
                    DataGridViewCell statusCell = dgvRow.Cells[dgvUsers.Columns["dgvStatus"].Index];
                    if (isActive)
                    {
                        statusCell.Value = "Active";
                        statusCell.Style.BackColor = Color.Green;
                        statusCell.Style.ForeColor = Color.White; // Optional: Change text color for better visibility
                    }
                    else
                    {
                        statusCell.Value = "InActive";
                        statusCell.Style.BackColor = Color.Orange;
                        statusCell.Style.ForeColor = Color.White; // Optional: Change text color for better visibility
                    }

                    // Add the row to the DataGridView
                    dgvUsers.Rows.Add(dgvRow);
                }

                // Optionally clear selection
                dgvUsers.CurrentCell = null;
            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void dgvUsers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {


                // Ensure the event handler only customizes cells in the specific column
                if (e.ColumnIndex == dgvUsers.Columns["dgvStatus"].Index && e.RowIndex >= 0)
                {
                    // Draw the default cell background
                    e.PaintBackground(e.ClipBounds, true);

                    // Draw a background behind the text if it exists
                    string cellValue = e.Value?.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        // Set color based on cell value
                        Color bgColor = cellValue == "Active" ? Color.Green : Color.Orange;

                        // Draw background rectangle behind the text
                        using (Brush brush = new SolidBrush(bgColor))
                        {
                            // Adjust the rectangle to fit behind the text
                            Size textSize = TextRenderer.MeasureText(e.Graphics, cellValue, e.CellStyle.Font);
                            Rectangle textBounds = new Rectangle(
                                e.CellBounds.Left + (e.CellBounds.Width - textSize.Width) / 2,
                                e.CellBounds.Top + (e.CellBounds.Height - textSize.Height) / 2,
                                textSize.Width,
                                textSize.Height
                            );
                            e.Graphics.FillRectangle(brush, textBounds);
                        }
                    }

                    // Draw the cell text
                    TextRenderer.DrawText(
                        e.Graphics,
                        e.FormattedValue.ToString(),
                        e.CellStyle.Font,
                        e.CellBounds,
                        e.CellStyle.ForeColor,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
                    );

                    // Indicate that the cell has been painted
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                // Check if the clicked cell is in the button column
                if (e.ColumnIndex == dgvUsers.Columns["dgvEdit"].Index && e.RowIndex >= 0)
                {
                    // Retrieve the selected row
                    DataGridViewRow selectedRow = dgvUsers.Rows[e.RowIndex];

                    // Extract data from the row
                    userId = Convert.ToInt32(selectedRow.Cells["dgvUserid"].Value?.ToString());
                    string username = selectedRow.Cells["dgvUsername"].Value?.ToString();
                    string userRole = selectedRow.Cells["dgvUserRole"].Value?.ToString();
                    string status = selectedRow.Cells["dgvStatus"].Value?.ToString();

                    pnlcreateUser.Visible = true;

                    txtUserName.Text = username;
                    cmbUserLevel.Text = userRole;
                    chkActive.Checked = status == "True";
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            try
            {
                pnlcreateUser.Visible = true;
                clearAll();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlcreateUser.Visible = false;
            clearAll();
        }
    }
}
