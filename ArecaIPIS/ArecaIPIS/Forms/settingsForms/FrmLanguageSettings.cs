using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class FrmLanguageSettings : Form
    {

        public FrmLanguageSettings()
        {
            InitializeComponent();
        }



        private frmIndex parentForm;

        public FrmLanguageSettings(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }


        private void GetRegionalLanguages()
        {
            try
            {
                // Call your method to get the DataTable of regional languages
                DataTable languagesdt = BaseClass.SelectionRegionalLanguagesDt;

                // Clear the ListBox before adding new items
                cmbLanguageName.Items.Clear();
                cmbLanguageName.Items.Add("--SELECT--");
                // Check if the DataTable is not null and contains data
                if (languagesdt != null && languagesdt.Rows.Count > 0)
                {
                    // Iterate through the rows of the DataTable
                    foreach (DataRow row in languagesdt.Rows)
                    {
                        string languageName = row["LanguageName"].ToString();

                        // Check if the languageName is not already present in listbSelectedLanguages
                        if (!cmbLanguageName.Items.Contains(languageName))
                        {
                            // Add the LanguageName from each row to the ListBox
                            cmbLanguageName.Items.Add(languageName);
                        }
                    }
                    cmbLanguageName.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No regional languages found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void FrmLanguageSettings_Load(object sender, EventArgs e)
        {
            GetRegionalLanguages();
            SetFontSize();
            SetFontfamily();
            SetFont();
        }

        private void cmbLanguageName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Call your method to get the DataTable of regional languages
                DataTable languagesdt = BaseClass.SelectionRegionalLanguagesDt;



                // Check if the DataTable is not null and contains data
                if (languagesdt != null && languagesdt.Rows.Count > 0)
                {
                    // Iterate through the rows of the DataTable
                    foreach (DataRow row in languagesdt.Rows)
                    {
                        string languageName = row["LanguageName"].ToString();

                        if (cmbLanguageName.Text == languageName)
                        {
                            txtLanguageCode.Text = row["LanguageID"].ToString();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("No regional languages found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void SetFontSize()
        {
            // Clear existing items in the ComboBox
            cmbFontsize.Items.Clear();

            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Font in BaseClass.FontSizeList)
            {
                // Trim the platform name
                string trimmedFont = Font.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbFontsize.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            cmbFontsize.SelectedIndex = 0;
        }
        private void SetFont()
        {
            // Clear existing items in the ComboBox
            cmbFont.Items.Clear();
            List<string> fontList = GetFontList();

            // Display the fonts
            foreach (string font in fontList)
            {
                // Trim the platform name
                string trimmedFont = font.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbFont.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            cmbFont.SelectedIndex = 0;
        }

        private void SetFontfamily()
        {
            // Clear existing items in the ComboBox
            cmbFontFamily.Items.Clear();
            List<string> fontStyles = GetFontStyles();

            // Display the font styles
            foreach (string style in fontStyles)
            {


                // Add the trimmed platform name to the ComboBox
                cmbFontFamily.Items.Add(style);
            }
            // Select the default item "--Select--"
            cmbFontFamily.SelectedIndex = 0;
        }
        static List<string> GetFontStyles()
        {
            return new List<string>
        {
            "Regular",
            "Italic",
            "Bold",
            "Underline",
            "Bold Italic"
        };
        }
        static List<string> GetFontList()
        {
            return new List<string>
        {
            "Londrina Shadow",
            "Geostar Fill",
            "Eater",
            "Griffy",
            "Galada",
            "Open Sans",
            "Hind",
            "PT Serif",
            "Indie Flower",
            "Suez One",
            "Candal",
            "Rasa",
            "Anton",
            "Space Mono",
            "Pacifico",
            "Cormorant Infant",
            "Kumar One",
            "Kaushan Script"
        };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string code = txtLanguageCode.Text;
                string languageName = cmbLanguageName.SelectedItem?.ToString();
                string font = cmbFont.SelectedItem?.ToString();
                string fontFamily = cmbFontFamily.SelectedItem?.ToString();
                bool fontSizeValid = int.TryParse(cmbFontsize.SelectedItem?.ToString(), out int fontSize);

                if (!string.IsNullOrEmpty(code) &&
                    !string.IsNullOrEmpty(languageName) &&
                    !string.IsNullOrEmpty(font) &&
                    !string.IsNullOrEmpty(fontFamily) &&
                    fontSizeValid)
                {
                    StationConfigurationDb.InsertUpdatelanguagesettings(code, languageName, font, fontFamily, fontSize);
                    MessageBox.Show("Language Settings Saved successfully.");
                }
                else
                {
                    MessageBox.Show("Please fill in all fields correctly.");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
    }
}
