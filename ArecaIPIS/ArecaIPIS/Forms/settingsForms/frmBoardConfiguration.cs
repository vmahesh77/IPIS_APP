using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmBoardConfiguration : Form
    {
        public frmBoardConfiguration()
        {
            InitializeComponent();
        }

        private frmIndex parentForm;

        public frmBoardConfiguration(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmBoardConfiguration_Load(object sender, EventArgs e)
        {
            try
            {


                List<string> formatTypesList = BoardConfigurationDb.GetFormatType();
                SetFormatTypes(formatTypesList);
                SetFormats();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void SetFormats()
        {
            // Clear existing controls
            panFormats.Controls.Clear();

            int buttonSpacing = 10; // Space between buttons
            int currentY = 0; // Starting Y position

            foreach (var formatType in BaseClass.FormatsList)
            {
                // Trim the format type
                string trimmedFormatType = formatType.Trim();

                // Create a new button
                Button formatButton = new Button();
                formatButton.Text = trimmedFormatType;
                formatButton.AutoSize = true;

                // Set button properties like size, font, etc.
                formatButton.Size = new Size(200, 50); // Example size
                formatButton.Font = new Font("Arial", 20); // Example font

                // Set the location of the button
                formatButton.Location = new Point(0, currentY);
                formatButton.BackColor = Color.Yellow;
                // Add click event handler
                formatButton.Click += FormatButton_Click;

                // Update currentY for the next button
                currentY += formatButton.Height + buttonSpacing;

                // Add the button to the Panel
                panFormats.Controls.Add(formatButton);
            }
        }

        private void FormatButton_Click(object sender, EventArgs e)
        {
            try
            {


                // Get the button that was clicked
                Button clickedButton = sender as Button;
                if (clickedButton != null)
                {
                    // Retrieve the text of the clicked button
                    string buttonText = clickedButton.Text;

                    DataTable dt = BoardConfigurationDb.GetFormatname(buttonText);


                    foreach (DataRow row in dt.Rows)
                    {
                        // Assuming the column name is "FormatType"
                        string value = buttonText.Trim();
                        if (value == buttonText)
                        {
                            rtxtformatName.Text = row["ModifiedName"].ToString().Trim();
                            rtxtBoardWidth.Text = row["BoardWidth"].ToString().Trim();
                            rtxtDisplayFieldGap.Text = row["DisplayFieldGap1"].ToString().Trim();
                            cmbFormatType.Text = GetFormaTypeValue(row["Formattype"].ToString().Trim());



                        }
                    }

                    //MessageBox.Show("Button clicked: " + buttonText);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }






        private void SetFormatTypes(List<String> formatTypesList)
        {
            // Clear existing items in the ComboBox
            cmbFormatType.Items.Clear();

            // Add the default item "--Select--"
            cmbFormatType.Items.Add("--Select--");

            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Type in formatTypesList)
            {
                // Trim the platform name
                string trimmedType = Type.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbFormatType.Items.Add(trimmedType);
            }

            // Select the default item "--Select--"
            cmbFormatType.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                string formatName = rtxtformatName.Text;
                //  int fkeyformat=   GetFormatpk(formatName);
                int boardWidth = Convert.ToInt32(rtxtBoardWidth.Text);
                int fieldGap = Convert.ToInt32(rtxtDisplayFieldGap.Text);
                int formatType = GetFormaTypepk(cmbFormatType.Text);


                int rows = BoardConfigurationDb.UpsertTADDBConfiguration(formatName, boardWidth, fieldGap, formatType);
                BaseClass.setFormats();
                SetFormats();
                clearAll();

                if (rows > 0)
                {

                    lblStatus.Text = "Board Configuration saved successfully!";
                    lblStatus.ForeColor = Color.Green;
                    // Make the label visible
                    lblStatus.Visible = true;

                    // Start a timer to clear the label after 10 seconds
                    Timer timer = new Timer();
                    timer.Interval = 2000; // 5 seconds
                    timer.Tick += (s, _) =>
                    {
                        // Clear the label text and hide the label
                        lblStatus.Text = "";
                        lblStatus.Visible = false;

                        // Stop and dispose the timer
                        timer.Stop();
                        timer.Dispose();
                        this.Close();

                    };
                    timer.Start(); // Start the timer
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private int GetFormatpk(string format)
        {
            try
            {


                foreach (DataRow row in BaseClass.FormatsDt.Rows)
                {
                    // Assuming the column name is "FormatType"
                    string value = row["Format"].ToString().Trim();
                    if (value == format)
                    {
                        return Convert.ToInt32(row["Pkey_FormatName"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            return 0;
        }
        private int GetFormaTypepk(string format)
        {
            foreach (DataRow row in BaseClass.FormatTypeDt.Rows)
            {
                // Assuming the column name is "FormatType"
                string value = row["FormatType"].ToString().Trim();
                if (value == format)
                {
                    return Convert.ToInt32(row["Pkey_FormatType"].ToString().Trim());
                }
            }

            return 0;
        }

        private string GetFormaTypeValue(string format)
        {
            foreach (DataRow row in BaseClass.FormatTypeDt.Rows)
            {
                // Assuming the column name is "FormatType"
                string value = row["Pkey_FormatType"].ToString().Trim();
                if (value == format)
                {
                    return row["FormatType"].ToString().Trim();
                }
            }

            return null; ;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                string formatname = rtxtformatName.Text;
                BoardConfigurationDb.DeletePort(formatname);
                BaseClass.setFormats();
                SetFormats();
                clearAll();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        private void clearAll()
        {
            rtxtformatName.Text = "";
            rtxtBoardWidth.Text = "";
            rtxtDisplayFieldGap.Text = "";
            cmbFormatType.SelectedIndex = 0;
        }

     

       
    }
}
