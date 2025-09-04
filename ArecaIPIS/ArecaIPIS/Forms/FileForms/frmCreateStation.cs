using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmCreateStation : Form
    {
        public frmCreateStation()
        {
            InitializeComponent();
        }
        AddStationDb addstationDb = new AddStationDb();
        Rectangle r = new Rectangle(0, 0, 20, 40);

        private void frmCreateStation_Load(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool validateEnglishStationName()
        {
            if (string.IsNullOrWhiteSpace(txtEnglishName.Text))
            {
                txtEnglishName.BackColor = Color.Red; // Set background color to red
                return false; // Return false if station name is empty or whitespace
            }
            else
            {
                txtEnglishName.BackColor = SystemColors.Window; // Reset background color
                return true; // Return true if station name is not empty or whitespace
            }
        }

        private bool validateHindiStationName()
        {
            if (string.IsNullOrWhiteSpace(txtHindiName.Text))
            {
                txtHindiName.BackColor = Color.Red; // Set background color to red
                return false; // Return false if station name is empty or whitespace
            }
            else
            {
                txtHindiName.BackColor = SystemColors.Window; // Reset background color
                return true; // Return true if station name is not empty or whitespace
            }
        }

        private bool validateRegionalStationName()
        {
            if (string.IsNullOrWhiteSpace(txtRegionalName.Text))
            {
                txtRegionalName.BackColor = Color.Red; // Set background color to red
                return false; // Return false if station name is empty or whitespace
            }
            else
            {
                txtRegionalName.BackColor = SystemColors.Window; // Reset background color
                return true; // Return true if station name is not empty or whitespace
            }
        }

        private void txtStationCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the length is 4 characters


            // Allow only letters and control keys
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                txtStationCode.BackColor = Color.Red; // Change textbox background color to red
                txtStationCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
                return;
            }



        }

        private void txtEnglishName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtRegional_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtHindiName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private bool validateStationCode()
        {
            string stationCode = txtStationCode.Text.Trim(); // Remove leading and trailing whitespace
            int textLength = stationCode.Length;

            // Validate station code length
            if (textLength < 2 || textLength > 4)
            {

                txtStationCode.BackColor = Color.Red;
                return false;
            }
            else
            {

                txtStationCode.BackColor = SystemColors.Window;
                // Reset the border style to the default style
                txtStationCode.BorderStyle = BorderStyle.Fixed3D;


                return true;

            }
        }

        private bool ValidateFilePath()
        {
            // Trim leading and trailing whitespace from the file path
            string filePath = lblNoFileChoosen.Text.Trim();

            // Check if the file path is empty or null
            if (string.IsNullOrEmpty(filePath))
            {
                // File path is empty or null, return false
                return false;
            }
            else
            {
                // File path is not empty, return true
                return true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool StationCode = validateStationCode();
                bool EnglishStationName = validateEnglishStationName();
                bool HindiStationName = validateHindiStationName();
                bool RegionalStationName = validateRegionalStationName();
                bool filePath = ValidateFilePath();

                // Check if all validations pass
                if (StationCode && EnglishStationName && HindiStationName && RegionalStationName && filePath)
                {
                    string StationCodetxt = txtStationCode.Text; // Captures text from rtxtStationName
                    string EnglishStationNametxt = txtEnglishName.Text;
                    string HindiStationNametxt = txtHindiName.Text;
                    string RegionalStationNametxt = txtRegionalName.Text;
                    string filePathtxt = lblNoFileChoosen.Text.Trim();
                    int pk = 0;

                    if (pk == 0)
                    {
                        // Insert station data
                        // addstationDb.InsertStationNames(StationCodetxt, EnglishStationNametxt, HindiStationNametxt, RegionalStationNametxt, filePathtxt);
                    }
                    else
                    {
                        // Update station data
                        // addstationDb.UpdateStationNames(pk, StationCodetxt, EnglishStationNametxt, HindiStationNametxt, RegionalStationNametxt, filePathtxt);
                    }
                }




                else
                {
                    // At least one validation failed, show a message or take appropriate action
                    MessageBox.Show("Please fill in all details correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnAudioPath_Click(object sender, EventArgs e)
        {
            try
            {


                OpenFileDialog openFileDialog = new OpenFileDialog();

                // Set properties of the OpenFileDialog
                openFileDialog.Title = "Choose Audio File";
                openFileDialog.Filter = "Audio Files|*.wav;*.mp3;*.ogg|All Files|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Multiselect = false;

                // Show the OpenFileDialog and get the result
                DialogResult result = openFileDialog.ShowDialog();

                // Check if the user selected a file
                if (result == DialogResult.OK)
                {
                    // Get the selected file's path
                    string filePath = openFileDialog.FileName;

                    // Use the filePath as needed (e.g., display it in a textbox)
                    lblNoFileChoosen.Text = filePath;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


