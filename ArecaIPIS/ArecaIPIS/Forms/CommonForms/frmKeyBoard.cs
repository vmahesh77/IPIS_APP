using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.CommonForms
{
    public partial class frmKeyBoard : Form
    {

        private Dictionary<char, string> keyMappings;
        private TextBox targetTextBox; // TextBox to receive keyboard input
        Panel newpanel;
        public frmKeyBoard(TextBox targetTextBox, Panel panel)
        {
            InitializeComponent();
            this.targetTextBox = targetTextBox;
            // Assign the passed TextBox to the targetTextBox field
            this.newpanel = panel;
        }
        private void frmKeyBoard_Load(object sender, EventArgs e)
        {
            string selectedLanguage = cmbLanguage.SelectedItem.ToString();
            // GenerateKeyboardButtons(selectedLanguage);
            GenerateKeyboardButtons(selectedLanguage, targetTextBox);
        }
        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle language selection event
            string selectedLanguage = cmbLanguage.SelectedItem.ToString();
            // GenerateKeyboardButtons(selectedLanguage);
            GenerateKeyboardButtons(selectedLanguage, targetTextBox);
        }

        //private void GenerateKeyboardButtons(string language, TextBox targetTextBox)
        //{
        //    panKeyBoard.Controls.Clear();

        //    // Generate number buttons
        //    GenerateNumberKeyboardButtons();

        //    // Generate buttons based on the selected language
        //    if (language == "English")
        //    {
        //        GenerateEnglishKeyboardButtons();
        //    }
        //    else if (language == "Hindi")
        //    {
        //        GenerateHindiKeyboardButtons();
        //    }
        //    // Add more language cases as needed
        //    GenerateSpecialCharactersKeyboardButtons();
        //    ButtonsGenerate(targetTextBox);
        //}
        private void GenerateKeyboardButtons(string language, TextBox targetTextBox)
        {
            try
            {


                panKeyBoard.Controls.Clear();
                GenerateNumberKeyboardButtons();

                // Generate buttons based on the selected language
                switch (language)
                {
                    case "English":
                        GenerateEnglishKeyboardButtons();
                        break;
                    case "Hindi":
                        GenerateHindiKeyboardButtons();
                        break;
                    case "Assamese":
                        GenerateAssameseKeyboardButtons();
                        break;
                    case "Bengali":
                        GenerateBengaliKeyboardButtons();
                        break;
                    case "Farsi":
                        GenerateFarsiKeyboardButtons();
                        break;
                    case "Gujarathi":
                        GenerateGujaratiKeyboardButtons();
                        break;
                    case "Devanagari":
                        GenerateDevanagariKeyboardButtons();
                        break;
                    case "Kannada":
                        GenerateKannadaKeyboardButtons();
                        break;
                    case "Malayalam":
                        GenerateMalayalamKeyboardButtons();
                        break;
                    case "Misc.Symbols":
                        GenerateMiscellaneousSymbolsKeyboardButtons();
                        break;
                    case "Marathi":
                        GenerateMarathiKeyboardButtons();
                        break;
                    case "Punjabi":
                        GeneratePunjabiKeyboardButtons();
                        break;
                    case "Tamil":
                        GenerateTamilKeyboardButtons();
                        break;
                    case "Telugu":
                        GenerateTeluguKeyboardButtons();
                        break;
                    case "Oriya":
                        GenerateOdiaKeyboardButtons();
                        break;
                    case "United Kingdom":
                        GenerateUnitedKingdomKeyboardButtons();
                        break;
                    case "Urdu":
                        GenerateUrduKeyboardButtons();
                        break;
                    case "Urdu Phonetic":
                        GenerateUrduPhoneticKeyboardButtons();
                        break;
                    case "Us Standard":
                        GenerateUSStandardKeyboardButtons();
                        break;
                    case "Us International":
                        GenerateUSInternationalKeyboardButtons();
                        break;
                    default:
                        // Handle unknown language
                        break;
                }
                GenerateSpecialCharactersKeyboardButtons();
                Font buttonFont = new Font("", 10); // Example font
                ButtonsGenerate(targetTextBox, buttonFont);
                //  ButtonsGenerate(targetTextBox);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }





        private void GenerateSpecialCharactersKeyboardButtons()
        {

            // Special characters key mappings
            //   keyMappings = new Dictionary<char, string>();

            // Add common symbols
            keyMappings.Add('!', "!");
            keyMappings.Add('"', "\"");
            keyMappings.Add('#', "#");
            keyMappings.Add('$', "$");
            keyMappings.Add('%', "%");
            keyMappings.Add('&', "&");
            keyMappings.Add('\'', "'");
            keyMappings.Add('(', "(");
            keyMappings.Add(')', ")");
            keyMappings.Add('*', "*");
            keyMappings.Add('+', "+");
            keyMappings.Add(',', ",");
            keyMappings.Add('-', "-");
            keyMappings.Add('.', ".");
            keyMappings.Add('/', "/");
            keyMappings.Add(':', ":");
            keyMappings.Add(';', ";");
            keyMappings.Add('<', "<");
            keyMappings.Add('=', "=");
            keyMappings.Add('>', ">");
            keyMappings.Add('?', "?");
            keyMappings.Add('@', "@");
            keyMappings.Add('[', "[");
            keyMappings.Add('\\', "\\");
            keyMappings.Add(']', "]");
            keyMappings.Add('^', "^");
            keyMappings.Add('_', "_");
            keyMappings.Add('`', "`");
            keyMappings.Add('{', "{");
            keyMappings.Add('|', "|");
            keyMappings.Add('}', "}");
            keyMappings.Add('~', "~");






        }

        private void GenerateNumberKeyboardButtons()
        {
            // Number key mappings
            keyMappings = new Dictionary<char, string>();

            // Unicode range for digits 0 to 9
            for (char c = '0'; c <= '9'; c++)
            {
                keyMappings.Add(c, c.ToString());
            }
        }
        private void GenerateEnglishKeyboardButtons()
        {
            // English key mappings for lowercase and uppercase letters
            //  keyMappings = new Dictionary<char, string>();
            for (char c = 'a'; c <= 'z'; c++) // Lowercase letters
            {
                keyMappings.Add(c, c.ToString());
            }
            for (char c = 'A'; c <= 'Z'; c++) // Uppercase letters
            {
                keyMappings.Add(c, c.ToString());
            }
            // Add more key mappings as needed
        }

        // Add other methods as needed...
        private void ButtonsGenerate(TextBox targetTextBox, Font buttonFont)
        {
            // Generate buttons based on key mappings
            int buttonWidth = 30;
            int buttonHeight = 30;
            int buttonSpacing = 5;
            int buttonsPerRow = 20; // Maximum buttons per row

            List<char> keys = new List<char>(keyMappings.Keys); // Convert dictionary keys to a list

            int totalKeys = keys.Count;
            int fullRows = totalKeys / buttonsPerRow; // Number of full rows
            int remainingKeys = totalKeys % buttonsPerRow; // Number of keys in the last row




            int x = 0;
            int y = 0;

            // Add buttons for full rows
            for (int i = 0; i < fullRows; i++)
            {
                for (int j = 0; j < buttonsPerRow; j++)
                {
                    // AddButton(x, y, buttonWidth, buttonHeight, keys[i * buttonsPerRow + j], targetTextBox);
                    AddButton(x, y, buttonWidth, buttonHeight, keys[i * buttonsPerRow + j], targetTextBox, buttonFont);
                    x += buttonWidth + buttonSpacing;
                }
                x = 0;
                y += buttonHeight + buttonSpacing;
            }

            // Calculate spacing for the remaining buttons in the last row
            int remainingButtonSpacing = (panKeyBoard.Width - (remainingKeys * buttonWidth)) / (remainingKeys + 1);

            // Add buttons for the last row
            for (int i = 0; i < remainingKeys; i++)
            {
                AddButton(x, y, buttonWidth, buttonHeight, keys[fullRows * buttonsPerRow + i], targetTextBox, buttonFont);
                x += buttonWidth + remainingButtonSpacing;
            }

            // Calculate position and width for the space button
            int spaceX = 0;
            int spaceY = y + buttonHeight + buttonSpacing;
            int spaceWidth = (buttonWidth + buttonSpacing) * buttonsPerRow - buttonSpacing;

            // Add space button
            AddSpaceButton(spaceX, spaceY, spaceWidth, buttonHeight, targetTextBox);
            btnClear.Click += (sender, e) =>
            {
                // Inside the event handler, clear the targetTextBox
                targetTextBox.Text = string.Empty;
            };
            // Assuming you have a button named backButton and a text box named targetTextBox

            // Add a click event handler for the backButton
            btnBackSpace.Click += (sender, e) =>
            {
                // Check if the targetTextBox is not null and contains text
                if (targetTextBox != null && targetTextBox.Text.Length > 0)
                {
                    // Get the current cursor position in the text box
                    int selectionStart = targetTextBox.SelectionStart;

                    // Remove the last character from the text box
                    targetTextBox.Text = targetTextBox.Text.Substring(0, targetTextBox.Text.Length - 1);

                    // Set the cursor position to the end of the text
                    targetTextBox.Select(targetTextBox.Text.Length, 0);

                    // Set focus back to the text box to ensure the cursor remains there
                    targetTextBox.Focus();
                }
            };

        }
        //private void AddButton(int x, int y, int width, int height, char key, TextBox targetTextBox)
        //{
        //    Button button = new Button();
        //    button.Text = keyMappings[key];
        //    button.Width = width;
        //    button.Height = height;
        //    button.Tag = key;
        //    button.Location = new Point(x, y);
        //    button.Click += (sender, e) =>
        //    {
        //        Button_Click(sender, e, targetTextBox);
        //    };
        //    panKeyBoard.Controls.Add(button);
        //}
        private bool IsUnicodeEscapeSequence(char c)
        {
            // Convert the character to its string representation
            string str = c.ToString();

            // Check if the string starts with "\u" and is followed by exactly four hexadecimal digits
            return str.StartsWith("\\u") && str.Length == 6 && IsHex(str.Substring(2));
        }

        private bool IsHex(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c) && (c < 'A' || c > 'F') && (c < 'a' || c > 'f'))
                {
                    return false;
                }
            }
            return true;
        }

        private void AddButton(int x, int y, int width, int height, char key, TextBox targetTextBox, Font buttonFont)
        {



            Button button = new Button();
            if (key == '&')
            {
                button.Text = "&" + keyMappings[key];
            }
            else
            {
                button.Text = keyMappings[key];
            }



            button.Width = width;

            button.Height = height;
            button.Tag = key;
            button.Font = buttonFont; // Set the font for the button
            button.Location = new System.Drawing.Point(x, y);
            button.Click += (sender, e) =>
            {
                // Inside the event handler, append the character to the targetTextBox
                Button clickedButton = (Button)sender;
                char character = (char)clickedButton.Tag;
                int selectionStart = targetTextBox.SelectionStart;
                targetTextBox.Text = targetTextBox.Text.Insert(selectionStart, character.ToString());
                targetTextBox.SelectionStart = selectionStart + 1;
                targetTextBox.Focus();
            };
            panKeyBoard.Controls.Add(button);
        }


        private void AddSpaceButton(int x, int y, int width, int height, TextBox targetTextBox)
        {
            // Define the layout parameters for the space button
            Button button = new Button();
            button.Text = "Space";
            button.Width = width;
            button.Height = height;
            button.BackColor = Color.Blue; // Set space button color
            button.ForeColor = Color.White; // Set space button text color
            button.Click += (sender, e) =>
            {
                SpaceButton_Click(sender, e, targetTextBox);
            }; // Attach event handler for button click

            button.Location = new Point(x, y);
            panKeyBoard.Controls.Add(button);
        }
        private void SpaceButton_Click(object sender, EventArgs e, TextBox targetTextBox)
        {
            // Get the current selection start position
            int selectionStart = targetTextBox.SelectionStart;
            // Append a space character to the target text box
            targetTextBox.Text = targetTextBox.Text.Insert(selectionStart, " ");
            // Move the cursor to the end of the text
            targetTextBox.SelectionStart = selectionStart + 1;
            // Set focus back to the textbox to ensure the cursor remains there
            targetTextBox.Focus();
        }

        private void Button_Click(object sender, EventArgs e, TextBox targetTextBox)
        {
            Button button = sender as Button;
            char key = (char)button.Tag;
            string character = keyMappings[key];
            // Get the current selection start position
            int selectionStart = targetTextBox.SelectionStart;
            // Append the character to the target text box
            targetTextBox.Text = targetTextBox.Text.Insert(selectionStart, character);
            // Move the cursor to the end of the text
            targetTextBox.SelectionStart = selectionStart + 1;
            // Set focus back to the textbox to ensure the cursor remains there
            targetTextBox.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            newpanel.Visible = false;
        }

        private void GenerateHindiKeyboardButtons()
        {
            // Hindi key mappings
            // keyMappings = new Dictionary<char, string>();

            for (int i = 0x0900; i <= 0x097F; i++)
            {
                char c = (char)i;

                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
        }


        private void GenerateUrduKeyboardButtons()
        {
            // Urdu key mappings
            // keyMappings = new Dictionary<char, string>();
            // Add Urdu characters to key mappings
            for (int i = 0x0600; i <= 0x06FF; i++)
            {
                char c = (char)i;
                // Check if the character is a Unicode character
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
            // Add additional Urdu characters or symbols as needed
        }

        //private void GenerateTeluguKeyboardButtons()
        //{
        //    // Telugu key mappings
        //    // keyMappings = new Dictionary<char, string>();

        //    for (int i = 0x0C00; i <= 0x0C7F; i++)
        //    {
        //        char c = (char)i;

        //        // Convert the character to a string
        //        string charString = c.ToString();

        //        // Convert the string back to a character
        //        char convertedChar = charString[0];

        //        // Check if the character remains the same after conversion
        //        if (c == convertedChar)
        //        {
        //            keyMappings.Add(c, c.ToString());
        //        }
        //    }
        //}
        private void GenerateTeluguKeyboardButtons2()
        {
            // Telugu key mappings
            // keyMappings = new Dictionary<char, string>();

            for (int i = 0x0C00; i <= 0x0C7F; i++)
            {
                char c = (char)i;

                // Check if the character is a Unicode character
                if (c != '఍')
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
        }

        private void GenerateTeluguKeyboardButtons()
        {
            // Clear existing keyMappings dictionary
            keyMappings.Clear();

            // Telugu special character range
            for (int i = 0x0C00; i <= 0x0C7F; i++)
            {
                char c = (char)i;

                // Add the character and its code point to the keyMappings dictionary
                keyMappings.Add(c, $"[{i} {c}]");
            }
        }













        private void GenerateUnitedKingdomKeyboardButtons()
        {
            // UK key mappings
            // keyMappings = new Dictionary<char, string>();

            // Add characters specific to the UK layout
            // For example, letters, numbers, punctuation marks, etc.
            for (char c = 'A'; c <= 'Z'; c++)
            {
                keyMappings.Add(c, c.ToString());
            }


        }

        private void GenerateOdiaKeyboardButtons()
        {
            // Odia key mappings
            // keyMappings = new Dictionary<char, string>();
            for (int i = 0x0B00; i <= 0x0B7F; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
        }
        private void GenerateGujaratiKeyboardButtons()
        {
            // Gujarati key mappings
            //keyMappings = new Dictionary<char, string>();
            for (int i = 0x0A80; i <= 0x0AFF; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
        }
        private void GenerateBengaliKeyboardButtons()
        {
            // Bengali key mappings
            // keyMappings = new Dictionary<char, string>();
            for (int i = 0x0980; i <= 0x09FF; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
        }
        private void GenerateKannadaKeyboardButtons()
        {
            // Kannada key mappings
            // keyMappings = new Dictionary<char, string>();
            for (int i = 0x0C80; i <= 0x0CFF; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
        }
        private void GenerateMalayalamKeyboardButtons()
        {
            // Malayalam key mappings
            //  keyMappings = new Dictionary<char, string>();
            for (int i = 0x0D00; i <= 0x0D7F; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
        }
        private void GeneratePunjabiKeyboardButtons()
        {
            // Punjabi (Gurmukhi) key mappings
            //  keyMappings = new Dictionary<char, string>();
            for (int i = 0x0A00; i <= 0x0A7F; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
        }
        private void GenerateAssameseKeyboardButtons()
        {
            // Assamese key mappings
            //keyMappings = new Dictionary<char, string>();
            for (int i = 0x0980; i <= 0x09FF; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
        }
        private void GenerateFarsiKeyboardButtons()
        {
            // Farsi (Persian) key mappings
            // keyMappings = new Dictionary<char, string>();
            for (int i = 0x0600; i <= 0x06FF; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
        }
        private void GenerateDevanagariKeyboardButtons()
        {
            // Devanagari key mappings
            //keyMappings = new Dictionary<char, string>();
            for (int i = 0x0900; i <= 0x097F; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
        }
        private void GenerateMarathiKeyboardButtons()
        {
            // Marathi (Devanagari) key mappings
            //  keyMappings = new Dictionary<char, string>();
            // Add characters specific to Marathi, such as additional vowels, consonants, and symbols
            for (int i = 0x0900; i <= 0x097F; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
            // Additional characters specific to Marathi can be added here
        }
        private void GenerateMiscellaneousSymbolsKeyboardButtons()
        {
            // Miscellaneous symbols key mappings
            // keyMappings = new Dictionary<char, string>();

            // Add characters from Miscellaneous Symbols and Pictographs range
            for (int i = 0x1F300; i <= 0x1F5FF; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }

            // Add additional symbols as needed from other Unicode ranges
            // For example, Emoticons range (U+1F600 - U+1F64F)
            for (int i = 0x1F600; i <= 0x1F64F; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }
        }
        private void GenerateUKKeyboardButtons()
        {
            // UK keyboard key mappings
            keyMappings = new Dictionary<char, string>();

            // Add alphabets
            for (char c = 'A'; c <= 'Z'; c++)
            {
                keyMappings.Add(c, c.ToString());
            }

            // Add digits
            for (char c = '0'; c <= '9'; c++)
            {
                keyMappings.Add(c, c.ToString());
            }


            // Add additional keys like Enter, Space, Tab, etc., if needed
        }
        private void GenerateUrduPhoneticKeyboardButtons()
        {
            // Urdu Phonetic keyboard key mappings
            //  keyMappings = new Dictionary<char, string>();

            // Alphabets
            keyMappings.Add('a', "ا");
            keyMappings.Add('b', "ب");
            keyMappings.Add('c', "ک");
            keyMappings.Add('d', "ڈ");
            keyMappings.Add('e', "ع");
            keyMappings.Add('f', "ف");
            keyMappings.Add('g', "گ");
            keyMappings.Add('h', "ہ");
            keyMappings.Add('i', "ی");
            keyMappings.Add('j', "ج");
            keyMappings.Add('k', "ک");
            keyMappings.Add('l', "ل");
            keyMappings.Add('m', "م");
            keyMappings.Add('n', "ن");
            keyMappings.Add('o', "و");
            keyMappings.Add('p', "پ");
            keyMappings.Add('q', "ق");
            keyMappings.Add('r', "ر");
            keyMappings.Add('s', "س");
            keyMappings.Add('t', "ٹ");
            keyMappings.Add('u', "ء");
            keyMappings.Add('v', "ط");
            keyMappings.Add('w', "و");
            keyMappings.Add('x', "خ");
            keyMappings.Add('y', "ی");
            keyMappings.Add('z', "ز");
            keyMappings.Add('A', "ا");
            keyMappings.Add('B', "ب");
            keyMappings.Add('C', "ک");
            keyMappings.Add('D', "ڈ");
            keyMappings.Add('E', "ع");
            keyMappings.Add('F', "ف");
            keyMappings.Add('G', "گ");
            keyMappings.Add('H', "ہ");
            keyMappings.Add('I', "ی");
            keyMappings.Add('J', "ج");
            keyMappings.Add('K', "ک");
            keyMappings.Add('L', "ل");
            keyMappings.Add('M', "م");
            keyMappings.Add('N', "ن");
            keyMappings.Add('O', "و");
            keyMappings.Add('P', "پ");
            keyMappings.Add('Q', "ق");
            keyMappings.Add('R', "ر");
            keyMappings.Add('S', "س");
            keyMappings.Add('T', "ٹ");
            keyMappings.Add('U', "ء");
            keyMappings.Add('V', "ط");
            keyMappings.Add('W', "و");
            keyMappings.Add('X', "خ");
            keyMappings.Add('Y', "ی");
            keyMappings.Add('Z', "ز");





            // Additional keys like Enter, Space, Tab, etc., if needed
        }

        private void GenerateUSStandardKeyboardButtons()
        {
            // US Standard keyboard key mappings
            //  keyMappings = new Dictionary<char, string>();

            // Alphabets
            for (char c = 'A'; c <= 'Z'; c++)
            {
                keyMappings.Add(c, c.ToString());
            }

            // Digits
            for (char c = '0'; c <= '9'; c++)
            {
                if (!keyMappings.ContainsKey(c))
                {
                    keyMappings.Add(c, c.ToString());
                }
            }


            // Additional keys like Enter, Space, Tab, etc., if needed
        }
        private void GenerateUSInternationalKeyboardButtons()
        {
            // US International keyboard key mappings
            //  keyMappings = new Dictionary<char, string>();

            // Alphabets
            for (char c = 'A'; c <= 'Z'; c++)
            {
                keyMappings.Add(c, c.ToString());
            }




            // Additional keys like Enter, Space, Tab, etc., if needed
        }
        private void GenerateTamilKeyboardButtons()
        {
            // Tamil keyboard key mappings
            //  keyMappings = new Dictionary<char, string>();

            // Vowels
            for (int i = 0x0B85; i <= 0x0B94; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }

            // Consonants
            for (int i = 0x0B95; i <= 0x0BB9; i++)
            {
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    string charText = c.ToString();

                    // Add the character to the keyMappings dictionary
                    keyMappings.Add(c, charText);
                }
            }

            // Aytham
            keyMappings.Add('\u0B83', "\u0B83");



            // Common symbols



            // Additional keys like Enter, Space, Tab, etc., if needed
        }

    }
}
