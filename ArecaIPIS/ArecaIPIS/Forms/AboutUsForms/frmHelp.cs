using ArecaIPIS.Classes;
using System;
using System.IO;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.AboutUsForms
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private frmIndex parentForm;
        public frmHelp(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }

        private void frmHelp_Load(object sender, EventArgs e)
        {

            string pdfFilePath = System.IO.Path.Combine(Application.StartupPath, "UserManual", "UserManual.pdf");
            try
            {
                // Check if the file exists
                if (File.Exists(pdfFilePath))
                {
                    // Load the PDF file
                    this.axAcroPDF1.LoadFile(pdfFilePath);  // Use axAcroPDF1 or the name of your Adobe Reader control

                    // Set the view to fit the width and height of the control
                    this.axAcroPDF1.setView("FitH");         // Set the view to fit height
                    this.axAcroPDF1.setViewScroll("FitH", 0); // Ensure the view is set for horizontal fit as well
                    this.axAcroPDF1.setZoom(100);            // Optional: Set zoom percentage for fine adjustment

                    this.axAcroPDF1.setShowToolbar(false);   // Optional: Hide the toolbar
                    this.axAcroPDF1.setShowScrollbars(false); // Optional: Hide scrollbars if needed
                }
                else
                {
                    MessageBox.Show("PDF file not found in the specified location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }
    }
}
