using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.ViewForms
{
    public partial class frmDefectiveLinesTaddb : Form
    {
        private frmIndex parentForm;

        public frmDefectiveLinesTaddb(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }
        public frmDefectiveLinesTaddb()
        {
            InitializeComponent();

        }
        private void lblAdress_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                string BoardIp = txtboardaddress.Text;

                int pkeyHub = Board.GetMasterHubKey(BoardIp);
                string defectiveLines = GetCheckedCheckboxes(panelCheckboxes);

                BoardConfigurationDb.InsertUpdateDefectiveLinesInTADDB(pkeyHub, defectiveLines, BoardIp);
                getDefectedBoards();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void cmbtadb_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadFields();
        }
        public void LoadFields()
        {
            string Boardname = cmbtadb.Text;
            string BoardIp = Board.GetBoardipbyname(Boardname);
            txtboardaddress.Text = BoardIp;
            int pkeyMasterhub = Board.GetMasterHubKey(BoardIp);
            int NoOfLines = Board.GetNoOfLines(pkeyMasterhub);
            txtNoOfLines.Text = NoOfLines.ToString();

            CreateCheckboxes(NoOfLines);

            getDefectivelines(pkeyMasterhub);
        }


        private string GetCheckedCheckboxes(Panel panel)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel), "Panel cannot be null.");
            }

            // Use a recursive method to find all CheckBoxes, even if they are nested
            var checkBoxes = GetAllCheckBoxes(panel);

            if (checkBoxes.Count == 0)
            {
                Console.WriteLine("No CheckBoxes found in the panel.");
                return string.Empty;
            }

            var numericValues = new List<int>();
            foreach (var chk in checkBoxes)
            {
                if (chk.Checked)
                {
                    var parts = chk.Text.Split(' '); // Split by space
                    if (parts.Length > 1 && int.TryParse(parts[2], out int numericValue))
                    {
                        numericValues.Add(numericValue);
                    }
                }
            }

            return numericValues.Count > 0 ? string.Join(",", numericValues) : string.Empty;
        }


        // Recursive method to get all CheckBoxes, even if nested
        private List<CheckBox> GetAllCheckBoxes(Control control)
        {
            var checkBoxes = new List<CheckBox>();

            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is CheckBox cb)
                {
                    checkBoxes.Add(cb);
                }
                else if (ctrl.HasChildren)
                {
                    checkBoxes.AddRange(GetAllCheckBoxes(ctrl));
                }
            }

            return checkBoxes;
        }



        private void CreateCheckboxes(int count)
        {
            // Clear any existing controls in the panel
            panelCheckboxes.Controls.Clear();

            for (int i = 1; i <= count; i++)
            {
                CheckBox checkBox = new CheckBox
                {
                    Text = $"Defective Line {i}",
                    AutoSize = true,
                    Location = new System.Drawing.Point(10, (i - 1) * 30)
                };

                panelCheckboxes.Controls.Add(checkBox);
            }
        }

        private void frmDefectiveLinesTaddb_Load(object sender, EventArgs e)
        {

            BoardDiagnosisDb.DeleteBoardNotInMasterHub();

            getBoards();

            getDefectedBoards();
        }
        private void getDefectivelines(int pkhub)
        {
            try
            {
                // Fetch the data from the database
                DataTable boards = BoardDiagnosisDb.GetEthernetPorts();

                // Loop through the rows of the DataTable
                foreach (DataRow row in boards.Rows)
                {
                    int masterpk = Convert.ToInt32(row["Pkey_Hub"].ToString().Trim());

                    // Check if the current row matches the given Pkey_Hub
                    if (masterpk == pkhub)
                    {
                        // Get the defective lines as a comma-separated string and convert them to an int array
                        string defectivelines = row["DefectiveLines"].ToString().Trim();
                        if (defectivelines.Trim().ToString() != "")
                        {
                            int[] Dl = defectivelines.Split(',').Select(int.Parse).ToArray();

                            // Get all checkboxes in the panel
                            var checkBoxes = GetAllCheckBoxes(panelCheckboxes);

                            // Iterate through each checkbox
                            foreach (var chk in checkBoxes)
                            {
                                var parts = chk.Text.Split(' '); // Split the checkbox text by space

                                if (parts.Length > 1 && int.TryParse(parts[2], out int numericValue))
                                {
                                    // Check if the numeric value of the checkbox exists in the defective lines array
                                    if (Array.Exists(Dl, element => element == numericValue))
                                    {
                                        chk.Checked = true;
                                    }
                                    else
                                    {
                                        chk.Checked = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }



        private void getBoards()
        {
            try
            {
                List<int> packetIdentifiers = new List<int> { 5 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);



                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in boards.Rows)
                {



                    cmbtadb.Items.Add(row["Location"].ToString().Trim());



                }


            }

            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }
        private void getDefectedBoards()
        {
            try
            {
                // Call the method to get the DataTable from the database
                DataTable boards = BoardDiagnosisDb.GetEthernetPorts();

                // Check if the DataTable is not null and has rows
                if (boards != null && boards.Rows.Count > 0)
                {
                    // Set the DataSource of the DataGridView to the DataTable
                    dgvDefectiveLinesTable.DataSource = boards;
                    dgvDefectiveLinesTable.Columns["DgvDelete"].DisplayIndex = dgvDefectiveLinesTable.Columns.Count - 1;
                }
                else
                {
                    // Handle the case where no data is returned
                    dgvDefectiveLinesTable.DataSource = null;
                    //MessageBox.Show("No defective boards found.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void dgvDefectiveLinesTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked column is the delete column
            if (dgvDefectiveLinesTable.Columns[e.ColumnIndex].Name == "DgvDelete")
            {
                // Ensure a valid row is clicked
                if (e.RowIndex >= 0)
                {
                    // Get the clicked row
                    DataGridViewRow row = dgvDefectiveLinesTable.Rows[e.RowIndex];

                    // Retrieve the value of "DefectiveBoardIp" cell
                    int pkhub = Convert.ToInt32(row.Cells["Pkey_Hub"].Value.ToString());
                    BoardDiagnosisDb.DeleteBoard(pkhub);


                }
            }
            getDefectedBoards();
            LoadFields();
        }


    }
}
