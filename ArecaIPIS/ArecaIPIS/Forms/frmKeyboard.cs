using ArecaIPIS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArecaIPIS
{
    public partial class frmKeyboard : Form
    {
        private bool isShiftPressed = false;
        private bool isCapsLockOn = false;
        public static Control focusedControl = null;

        private Dictionary<string, string[]> keyboardLayouts = new Dictionary<string, string[]>
{
    { "Assamese", new string[]
    {
        "্ Space",
        "Shift অ আ ই ঈ উ ঊ ঋ এ ঐ , . Shift",
        "ও ঔ অঁ অঃ য র ল ৱ শ ষ স হ",
        "Caps ঢ ণ ত থ দ ধ ন প ফ ব ভ ম",
        "Tab ক খ গ ঘ ঙ চ ছ জ ঝ ঞ ট ঠ ড",
        "১ ২ ৩ ৪ ৫ ৬ ৭ ৮ ৯ ০ - = Backspace"
    } },
    { "CapsLock-Assamese", new string[]
    {
        "Space",
        "Shift े া ি ী ু ূ ৃ ে ৈ ো ৌ Shift",
        "Caps ঁ ং ঃ ৎ য় ড় ঢ়",
        "Tab ৽ § ₹ { } [ ] শ্র জ্ঞ",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    }},


    { "Hindi", new string[]
    {
        "् , . Space",
        "Shift ऄ अ आ इ ई उ ऊ ऋ ऌ ऍ ऎ Shift",
        "ए ऐ ऑ ऒ ओ औ र ल ळ व श ष स ह",
        "Caps ढ ण त थ द ध न प फ ब भ म य",
        "Tab क ख ग घ ङ च छ ज झ ञ ट ठ ड",
        "१ २ ३ ४ ५ ६ ७ ८ ९ ० - = Backspace"
    } },
        { "CapsLock-Hindi", new string[]
    {
        "Space",
        "Shift ँ ं ः ा ि ी ु ू ै ो ौ Shift",
        "Caps ृ ॄ ऻ ृ े ॅ ॆ ॉ ॅ ॊ ॏ",
        "क़ ख़ ग़ ज़ ड़ ढ़ फ़ ऩ ऱ ऴ य़ श्र",
        "Tab ऽ § ₹ { } [ ] ॠ ऋ ॡ ज्ञ",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    } },

    //{ "Bengali", new string[]
    //{
    //    "Space",
    //    "Shift অ আ ই ঈ উ ঊ ঋ এ ঐ ও ঔ Shift",
    //    "খ গ ঘ চ ছ জ ঝ ট ঠ ড ঢ ণ ক্ত",
    //    "Caps ত থ দ ধ ন প ফ ব ভ ম",
    //    "Tab য র ৰ ল ৱ শ ষ স হ , .",
    //    "১ ২ ৩ ৪ ৫ ৬ ৭ ৮ ৯ ০ - = Backspace"
    //} },
    //   { "CapsLock-Bengali", new string[]
    //{
    //    "Space",
    //    "Shift ং ঃ া ি ী ু ূ ঋ ৈ ো ৌ Shift",
    //    "Caps ृ े ড় ঢ়",
    //    "Tab { } [ ]",
    //    "! @ # $ % ^ & * ( ) _ + Backspace"
    //} },

      {
    "Bengali", new string[]
    {
        " ্ Space",
        "Shift অ আ ই ঈ উ ঊ ঋ এ ঐ , . Shift",
        "ও ঔ অঁ অঃ য র ল ৱ শ ষ স হ",
        "Caps ঢ ণ ত থ দ ধ ন প ফ ব ভ ম",
        "Tab ক খ গ ঘ ঙ চ ছ জ ঝ ঞ ট ঠ ড",
        "১ ২ ৩ ৪ ৫ ৬ ৭ ৮ ৯ ০ - = Backspace"
    }},
{
    "CapsLock-Bengali", new string[]
    {
        "Space",
        "Shift े া ি ী ু ূ ৃ ে ৈ ো ৌ Shift",
        "Caps ঁ ং ঃ ৎ য় ড় ঢ় জ্ঞ",
        "Tab ৽ § ₹ { } [ ] শ্র",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    }},


    { "Farsi", new string[]
    {
        "Space",
        "Shift ق و ع ف غ م ن ب پ ت Shift",
        "ض ص ث ق ف غ ع ه خ ح ج",
        "Caps ش س ی ب ل ا ت ن م , .",
        "Tab ز ژ د ر ذ خ ح ی",
        "۱ ۲ ۳ ۴ ۵ ۶ ۷ ۸ ۹ ۰ - = Backspace"
    } },
        { "CapsLock-Farsi", new string[]
    {
        "Space",
        "Shift ق و ع ف غ م ن ب پ ت Shift",
        "ض ص ث ق ف غ ع ه خ ح ج",
        "Caps ش س ی ب ل ا ت ن م , .",
        "Tab ز ژ د ر ذ خ ح ی",
        "۱ ۲ ۳ ۴ ۵ ۶ ۷ ۸ ۹ ۰ - = Backspace"
    } },
    { "Gujarati", new string[]
    {
        "Space",
        "Shift અ આ ઇ ઈ ઉ ઊ ઋ ઌ , . ੍ Shift",
        "ઍ એ ઐ ઑ ઓ ઔ ક ખ ગ ઘ ઙ ચ છ જ ઝ",
        "Caps ઞ ટ ઠ ડ ઢ ણ ત થ દ ધ ન પ ફ",
        "Tab બ ભ મ ય ર લ ળ વ શ ષ સ હ ૹ",
        "૧ ૨ ૩ ૪ ૫ ૬ ૭ ૮ ૯ ૦ - = Backspace"
    } },
        { "CapsLock-Gujarati", new string[]
    {
        "Space",
        "Shift ં ઃ ા િ ી ु ू ઋ ૈ ો ૌ Shift",
        "Caps ◌ૅ ◌ે ◌ૄ ૃ ૰ એ જ્ઞ",
        "Tab { } [ ] ક્ત  શ્ર",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    } },

    { "Devanagari", new string[]
    {
        "् , . Space",
        "Shift ऄ अ आ इ ई उ ऊ ऋ ऌ ऍ ऎ Shift",
        "ए ऐ ऑ ऒ ओ औ र ल ळ व श ष स ह",
        "Caps ढ ण त थ द ध न प फ ब भ म य",
        "Tab क ख ग घ ङ च छ ज झ ञ ट ठ ड",
        "१ २ ३ ४ ५ ६ ७ ८ ९ ० - = Backspace"
    } },
        { "CapsLock-Devanagari", new string[]
    {
        "Space",
        "Shift ँ ं ः ा ि ी ु ू ै ो ौ Shift",
        "Caps ृ ॄ ऻ ृ े ॅ ॆ ॉ ॅ ॊ ॏ",
        "क़ ख़ ग़ ज़ ड़ ढ़ फ़ ऩ ऱ ऴ य़ श्र",
        "Tab ऽ § ₹ { } [ ] ॠ ऋ ॡ ज्ञ",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    } },
    { "Kannada", new string[]
    {
        "Space",
        "Shift ಅ ಆ ಇ ಈ ಉ ಊ ಋ ಌ ಎ , . Shift",
        "ಏ ಐ ಒ ಓ ಔ ಕ ಖ ಗ ಘ ಙ ಚ ಛ ಜ ಝ ಞ",
        "Caps ಟ ಠ ಡ ಢ ಣ ತ ಥ ದ ಧ ನ ಪ ಫ ಬ",
        "Tab ಭ ಮ ಯ ರ ಱ ಲ ಳ ವ ಶ ಷ ಸ ಹ ೞ",
        "೧ ೨ ೩ ೪ ೫ ೬ ೭ ೮ ೯ ೦ - = Backspace"
    } },
        { "CapsLock-Kannada", new string[]
    {
        "Space",
         "Shift ಾ ಿ ೀ ು ೂ ೃ ೄ ೆ ೇ ೈ ೊ Shift",
        "Caps ◌ೢ ◌ೣ ೋ ೌ ◌ಁ ಂ ಃ ೖ ◌಼",
        "Tab { } [ ] ಽ । ॥ ಶ್ರ ಜ್ಞ",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    } },

    { "Malayalam", new string[]
    {
        "് , . Space",
        "Shift അ ആ ഇ ഈ ഉ ഊ ഋ ഌ എ ഏ ഐ Shift",
        "ഒ ഓ ഔ ക ഖ ഗ ഘ ങ ച ഛ ജ ഝ ഞ ട ഠ",
        "Caps ഡ ഢ ണ ത ഥ ദ ധ ന ഩ പ ഫ ബ ഭ",
        "Tab മ യ ര റ ല ള ഴ വ ശ ഷ സ ഹ ഺ",
        "൧ ൨ ൩ ൪ ൫ ൬ ൭ ൮ ൯ ൦ - = Backspace"
    } },
        { "CapsLock-Malayalam", new string[]
    {
        "ഽ । ॥ Space",
        "Shift  ാ ി ീ ீ ு ூ ெ ே ை ொ ோ Shift",
        "Caps ു ൂ ൃ ൄ ൈ ൊ ൎ ോ ൌ െ ം ഃ ഁ",
        "Tab { } [ ] ജ്ഞ ക്ത ശ്ര",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    } },
    { "Marathi", new string[]
    {
        "् , . Space",
        "Shift ऄ अ आ इ ई उ ऊ ऋ ऌ ऍ ऎ Shift",
        "ए ऐ ऑ ऒ ओ औ र ल ळ व श ष स ह",
        "Caps ढ ण त थ द ध न प फ ब भ म य",
        "Tab क ख ग घ ङ च छ ज झ ञ ट ठ ड",
        "१ २ ३ ४ ५ ६ ७ ८ ९ ० - = Backspace"
    } },
        { "CapsLock-Marathi", new string[]
    {
        "Space",
        "Shift ँ ं ः ा ि ी ु ू ै ो ौ Shift",
        "Caps ृ ॄ ऻ ृ े ॅ ॆ ॉ ॅ ॊ ॏ",
        "क़ ख़ ग़ ज़ ड़ ढ़ फ़ ऩ ऱ ऴ य़ श्र",
        "Tab ऽ § ₹ { } [ ] ॠ ऋ ॡ ज्ञ",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    } },

    {
    "Punjabi", new string[]
    {
        "Space",
        "Shift ਅ ਆ ਇ ਈ ਉ ਊ ਐ ਔ , . ੍ Shift",
        "ਏ ਈ ਅੰ ਅ: ਰ ਲ ਲ਼ ਵ ਸ਼ ਜ਼ ਸ ਹ ਖ਼",
        "Caps ਢ ਣ ਤ ਥ ਦ ਧ ਨ ਪ ਫ ਬ ਭ ਮ ਯ",
        "Tab ਕ ਖ ਗ ਘ ਙ ਚ ਛ ਜ ਝ ਞ ਟ ਠ ਡ",
        "੧ ੨ ੩ ੪ ੫ ੬ ੭ ੮ ੯ ੦ - = Backspace"
    }},

        { "CapsLock-Punjabi", new string[]
    {
        "Space",
        "Shift ਃ ◌ਂ ◌ੑ ੂ ੱ ੈ ੋ ੌ ੰ Shift",
        "Caps ੃ ੇ ਜ੍ਞ ਸ਼੍ਰ ੲ ੳ ੴ ੳ",
        "Tab § ₹ { } [ ] ਰ ਲ ਲ਼",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    } },


    { "Tamil", new string[]
    {
        ", . Space ்",
        "Shift அ ஆ இ ஈ உ ஊ எ ஏ ஐ ஒ  Shift",
        "ஓ ஔ ௳ ௴ ௵ ௶ ௷ ௸",
        "Caps ய ர ற ல ள ழ வ ஶ ஷ ஸ ஹ ",
        "Tab க ங ச ஜ ஞ ட ண த ந ன ப ம",
        "௧ ௨ ௩ ௪ ௫ ௬ ௭ ௮ ௯ ௦ - = Backspace"
    } },

        { "CapsLock-Tamil", new string[]
    {
        "Space",
        "Shift ் ி ீ ா ெ ே ை ொ ோ ௌ ் Shift",
        "Caps ு ூ ஃ ஂ ௐ ஞ்ஜ ஷ்ர",
        "Tab { } [ ] । ॥",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    } },

    {
    "Telugu", new string[]
    {
        ". । ॥ Space , ॰  ్",
        "Shift అ ఆ ఇ ఈ ఉ ఊ ఋ ౠ ఌ ౡ ఎ Shift",
        "ర ఱ ల ళ ఴ వ శ ష స హ ఔ ఓ ఒ ఐ ఏ",
        "Caps ఢ ణ త థ ద ధ న ప ఫ బ భ మ య",
        "Tab క ఖ గ ఘ ఙ చ ఛ జ ఝ ఞ ట ఠ డ",
        "౦ ౧ ౨ ౩ ౪ ౫ ౬ ౭ ౮ ౯ - = Backspace"
    }},

        { "CapsLock-Telugu", new string[]
    {
        "౸ ౹ ౺ ౻ ౼ Space ౽ ౾ ౿ ಀ",
        "Shift ా ి ీ ు ూ ృ ౄ ె ే ై ొ Shift",
        "Caps  ో ౌ ్ ౕ ౖ ం ః ఀ ౢ ౣ ౘ ౙ ౚ",
        "Tab § ₹ { } [ ] ఞ్జ శ్ర ఁ",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    } },


    { "Oriya", new string[]
    {
        "Space",
        "Shift ଅ ଆ ଇ ଈ ଉ ଊ ଋ ଌ ଏ , . Shift",
        "ଐ ଓ ଔ କ ଖ ଗ ଘ ଚ ଛ ଜ ଝ ଞ ଟ ଠ ଡ",
        "Caps ଢ ଣ ତ ଥ ଦ ଧ ନ ପ ଫ ବ ଭ ମ ଢ",
        "Tab ଯ ର ଲ ଳ ଵ ଶ ଷ ସ ହ କ୍ତ ଣ",
        "୧ ୨ ୩ ୪ ୫ ୬ ୭ ୮ ୯ ୦ - = Backspace"
    } },
        { "CapsLock-Oriya", new string[]
    {
        "Space",
        "Shift ୀ ୁ ୂ ୃ ୄ େ ୈ ୋ ୌ ୍ ୖ Shift",
        "Caps ୗ ଡ଼ ଢ଼ ଔ ଞ୍ଜ ୠ ୡୢ ୣ",
        "Tab { } [ ] ଶ୍ର ୟ ଃ ଂ ଁ",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    } },

    { "United Kingdom", new string[]
    {
        "Space",
        "Shift Z X C V B N M , . / Shift",
        "Caps A S D F G H J K L ; ' Enter",
        "Tab Q W E R T Y U I O P [ ] \\",
        "1 2 3 4 5 6 7 8 9 0 - = Backspace"
    } },
        {"CapsLock-United Kingdom", new string[]
    {
        "Space",
        "Shift z x c v b n m , . / Shift",
        "Caps a s d f g h j k l ; ' Enter",
        "Tab q w e r t y u i o p [ ] \\",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    }},

    { "Urdu", new string[]
    {
        "Space",
        " Shift ض ص ث ق ف غ ع ه خ ح ج Shift",
        "Caps ش س ی ب ل ا ت ن م , .",
        "Tab ز ژ د ر ذ خ ح ی",
        "۱ ۲ ۳ ۴ ۵ ۶ ۷ ۸ ۹ ۰ - = Backspace"
    } },
    { "CapsLock-Urdu", new string[]
    {
        "Space",
        "Shift ق و ع ف غ م ن ب پ ت Shift",
        "ض ص ث ق ف غ ع ه خ ح ج",
        "Caps ش س ی ب ل ا ت ن م , .",
        "Tab ز ژ د ر ذ خ ح ی",
        "؛ ، ۔ ' ( ) [ ] {} / | Backspace"
    }},

    { "US Standard", new string[]
    {
        "Space",
        "Shift Z X C V B N M , . / Shift",
        "Caps A S D F G H J K L ; ' Enter",
        "Tab Q W E R T Y U I O P [ ] \\",
        "1 2 3 4 5 6 7 8 9 0 - = Backspace"
    } },
    { "CapsLock-US Standard", new string[]
    {
        "Space",
        "Shift z x c v b n m , . / Shift",
        "Caps a s d f g h j k l ; ' Enter",
        "Tab q w e r t y u i o p [ ] \\",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    }},

    { "US International", new string[]
    {
        "Space",
        "Shift Z X C V B N M , . / Shift",
        "Caps A S D F G H J K L ; ' Enter",
        "Tab Q W E R T Y U I O P [ ] \\",
        "1 2 3 4 5 6 7 8 9 0 - = Backspace"
    } },
    { "CapsLock-US International", new string[]
    {
        "Space",
        "Shift z x c v b n m , . / Shift",
        "Caps a s d f g h j k l ; ' Enter",
        "Tab q w e r t y u i o p [ ] \\",
        "! @ # $ % ^ & * ( ) _ + Backspace"
    }},
};

        //private TextBox targetTextBox;
        Panel newpanel;
        private string selectedLanguage;
        public frmKeyboard(Panel panel, string Language)
        {
            InitializeComponent();

            //string a = targetTextBox.Name;
            //this.targetTextBox = targetTextBox;

            this.newpanel = panel;
            selectedLanguage = Language;
        }


        private void Control_Enter(object sender, EventArgs e)
        {
            focusedControl = (Control)sender;

        }


        private void frmKeyboard_Load(object sender, EventArgs e)
        {
            try
            {
                cmbLanguage.Items.Clear();
                var allKeys = keyboardLayouts.Keys.ToArray();
                Array.Sort(allKeys);

                var filteredKeys = allKeys.Where(key => !key.Contains("CapsLock")).ToArray();

                cmbLanguage.Items.AddRange(filteredKeys);

                if (cmbLanguage.Items.Contains(selectedLanguage))
                {
                    cmbLanguage.SelectedItem = selectedLanguage;
                }
                else if (cmbLanguage.Items.Count > 0)
                {
                    cmbLanguage.SelectedIndex = 15;
                }

                //if (cmbLanguage.Items.Count > 0)
                //{
                //    cmbLanguage.SelectedIndex = 15;
                //}
                AddSpecialButtons();
                PopulateKeyboard(cmbLanguage.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void AddSpecialButtons()
        {
            Button btnClear = new Button
            {
                Dock = DockStyle.Right,
                Text = "Clear",
                Width = 100,
                Height = 30,
                Margin = new Padding(5),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.LightGray
            };
            btnClear.Click += HandleClearPress;

            Button btnClose = new Button
            {
                Dock = DockStyle.Right,
                Text = "X",
                Width = 60,
                Height = 30,
                Margin = new Padding(5),
                Font = new Font("Arial", 15, FontStyle.Bold),
                BackColor = Color.LightGray
            };
            btnClose.Click += HandleClosePress;

            pnlLanguage.Controls.Add(btnClear);
            pnlLanguage.Controls.Add(btnClose);

        }

        private void PopulateKeyboard(string language)
        {
            try
            {
                pnlKeyboard.Controls.Clear();

                if (keyboardLayouts.TryGetValue(language, out string[] rows))
                {
                    foreach (var row in rows)
                    {
                        FlowLayoutPanel rowPanel = new FlowLayoutPanel
                        {
                            Dock = DockStyle.Top,
                            AutoSize = true
                        };
                        bool isLastRow = row == rows.Last();
                        foreach (string key in row.Split(' '))
                        {
                            switch (key)
                            {
                                case "Backspace":
                                    rowPanel.Controls.Add(CreateSpecialButton("Backspace", HandleBackspacePress, 86));
                                    break;
                                case "Tab":
                                    rowPanel.Controls.Add(CreateSpecialButton("Tab", HandleTabPress));
                                    break;
                                case "Shift":
                                    rowPanel.Controls.Add(CreateSpecialButton("Shift", HandleShiftPress));
                                    break;
                                case "Caps":
                                    rowPanel.Controls.Add(CreateSpecialButton("Caps", HandleCapsLockPress));
                                    break;
                                case "Space":
                                    //rowPanel.Controls.Add(CreateSpecialButton("Space", HandleSpacePress,100));
                                    FlowLayoutPanel spacePanel = new FlowLayoutPanel
                                    {
                                        Dock = DockStyle.Fill,
                                        AutoSize = true,
                                        FlowDirection = FlowDirection.LeftToRight,
                                        WrapContents = false
                                    };

                                    // Add empty space before and after the Space button
                                    spacePanel.Controls.Add(new Button { Width = 0, Visible = false });
                                    spacePanel.Controls.Add(CreateSpecialButton("Space", HandleSpacePress, 150));
                                    spacePanel.Controls.Add(new Button { Width = 0, Visible = false });

                                    rowPanel.Controls.Add(spacePanel);
                                    break;
                                case "Enter":
                                    rowPanel.Controls.Add(CreateSpecialButton("Enter", HandleEnterPress));
                                    break;
                                default:

                                    foreach (char c in key)
                                    {
                                        //rowPanel.Controls.Add(CreateKeyButton(c.ToString()));


                                        string adjustedKey = AdjustKeyForState(c.ToString());
                                        rowPanel.Controls.Add(CreateKeyButton(adjustedKey));
                                    }
                                    break;
                            }
                        }

                        pnlKeyboard.Controls.Add(rowPanel);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }



        }
        public static string keyBoardText = "";
        private Button CreateKeyButton(string text)
        {
            Button keyButton = new Button
            {
                Text = text,
                Width = 25,
                Height = 25,
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.White
            };
            keyButton.Click += (sender, e) =>
            {
                Button clickedButton = (Button)sender;
                HandleKeyPress(clickedButton.Text);
                keyBoardText = clickedButton.Text;
            };
            return keyButton;
        }

        private Button CreateSpecialButton(string text, EventHandler clickHandler, int width = 55)
        {
            Button specialButton = new Button
            {
                Text = text,
                Width = width,
                Height = 25,
                Font = new Font("Arial", 10),
                BackColor = Color.LightGray
            };
            specialButton.Click += clickHandler;
            return specialButton;
        }

        private string currentBaseCharacter = "";



        private void HandleKeyPress(string key)
        {
            try
            {
                if (focusedControl is TextBox textBox)
                {
                    int cursorPosition = textBox.SelectionStart;

                    if (IsMatra(key))
                    {
                        if (string.IsNullOrEmpty(currentBaseCharacter))
                        {
                            return;
                        }

                        textBox.Text = textBox.Text.Remove(cursorPosition - currentBaseCharacter.Length, currentBaseCharacter.Length);

                        string modifiedCharacter = ApplyMatraToCharacter(currentBaseCharacter, key);

                        textBox.Text = textBox.Text.Insert(cursorPosition - currentBaseCharacter.Length, modifiedCharacter);
                        textBox.SelectionStart = cursorPosition - currentBaseCharacter.Length + modifiedCharacter.Length;
                        currentBaseCharacter = "";

                    }
                    else
                    {
                        textBox.Text = textBox.Text.Insert(cursorPosition, key);
                        textBox.SelectionStart = cursorPosition + key.Length;
                        currentBaseCharacter = key;

                    }
                    textBox.ScrollToCaret();
                }
                else if (focusedControl is RichTextBox richTextBox)
                {
                    int cursorPosition = richTextBox.SelectionStart;

                    if (key.Length == 1)
                    {
                        if (IsMatra(key))
                        {
                            if (string.IsNullOrEmpty(currentBaseCharacter))
                            {
                                return;
                            }

                            richTextBox.Text = richTextBox.Text.Remove(cursorPosition - currentBaseCharacter.Length, currentBaseCharacter.Length);
                            string modifiedCharacter = ApplyMatraToCharacter(currentBaseCharacter, key);
                            richTextBox.Text = richTextBox.Text.Insert(cursorPosition - currentBaseCharacter.Length, modifiedCharacter);

                            richTextBox.SelectionStart = cursorPosition - currentBaseCharacter.Length + modifiedCharacter.Length;
                            currentBaseCharacter = "";
                        }
                        else
                        {
                            richTextBox.Text = richTextBox.Text.Insert(cursorPosition, key);
                            richTextBox.SelectionStart = cursorPosition + key.Length;
                            currentBaseCharacter = key;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private bool IsMatra(string key)
        {

            return key.Length == 1 && "¨'".Contains(key);
        }

        private void HandleBackspacePress(object sender, EventArgs e)
        {
            if (focusedControl is TextBox textBox)
            {
                int cursorPosition = textBox.SelectionStart;

                if (textBox.SelectionLength > 0)
                {
                    textBox.Text = textBox.Text.Remove(cursorPosition, textBox.SelectionLength);
                    // Reset cursor position to where the selection started
                    textBox.SelectionStart = cursorPosition;
                }
                else if (cursorPosition > 0)
                {
                    textBox.Text = textBox.Text.Remove(cursorPosition - 1, 1);
                    // Set the cursor position to the previous position
                    textBox.SelectionStart = Math.Max(0, cursorPosition - 1);
                }
            }
            else if (focusedControl is RichTextBox richTextBox)
            {
                int cursorPosition = richTextBox.SelectionStart;

                if (richTextBox.SelectionLength > 0)
                {
                    // Remove the selected text
                    richTextBox.Text = richTextBox.Text.Remove(cursorPosition, richTextBox.SelectionLength);
                    // Reset cursor position to where the selection started
                    richTextBox.SelectionStart = cursorPosition;
                }
                else if (cursorPosition > 0)
                {
                    // Remove the character before the cursor
                    richTextBox.Text = richTextBox.Text.Remove(cursorPosition - 1, 1);
                    // Set the cursor position to the previous position
                    richTextBox.SelectionStart = Math.Max(0, cursorPosition - 1);
                }
            }
        }



        string ApplyMatraToCharacter(string baseCharacter, string matra)
        {

            return baseCharacter + matra;
        }
        private void HandleTabPress(object sender, EventArgs e)
        {
            if (focusedControl is TextBox textBox)
            {
                textBox.Text += "\t";
            }
            else if (focusedControl is RichTextBox richtextBox)
            {
                richtextBox.Text += "\t";
            }
        }

        private void HandleShiftPress(object sender, EventArgs e)
        {
            isShiftPressed = !isShiftPressed;
            UpdateKeyboardLayout();
        }

        private void HandleCapsLockPress(object sender, EventArgs e)
        {
            isCapsLockOn = !isCapsLockOn;
            UpdateKeyboardLayout();
        }
        private void UpdateKeyboardLayout()
        {
            string selectedLanguage = cmbLanguage.SelectedItem.ToString();
            string layoutKey = isCapsLockOn ? $"CapsLock-{selectedLanguage}" : selectedLanguage;

            PopulateKeyboard(layoutKey);

        }
        private string AdjustKeyForState(string key)
        {
            if (isShiftPressed || isCapsLockOn)
            {
                return key.ToUpper();
            }
            return key.ToLower();
        }
        private void HandleSpacePress(object sender, EventArgs e)
        {
            if (focusedControl is TextBox textBox)
            {
                int cursorPosition = textBox.SelectionStart;
                textBox.Text = textBox.Text.Insert(cursorPosition, " ");
                textBox.SelectionStart = cursorPosition + 1;
            }
            else if (focusedControl is RichTextBox richTextBox)
            {
                int cursorPosition = richTextBox.SelectionStart;
                richTextBox.Text = richTextBox.Text.Insert(cursorPosition, " ");
                richTextBox.SelectionStart = cursorPosition + 1;
            }
        }


        private void HandleEnterPress(object sender, EventArgs e)
        {
            if (focusedControl is TextBox textBox)
            {
                textBox.AppendText(Environment.NewLine);
            }
            else if (focusedControl is RichTextBox richtextBox)
            {
                richtextBox.AppendText(Environment.NewLine);
            }
        }

        private void HandleClearPress(object sender, EventArgs e)
        {
            //if (focusedControl is TextBox textBox)
            //{
            //    textBox.Clear();
            //}
            //else if (focusedControl is RichTextBox richtextBox)
            //{
            //    richtextBox.Clear();
            //}

            if (focusedControl is TextBox textBox)
            {
                int cursorPosition = textBox.SelectionStart;
                textBox.Clear();
                textBox.SelectionStart = cursorPosition;
            }
            else if (focusedControl is RichTextBox richTextBox)
            {
                int cursorPosition = richTextBox.SelectionStart;
                richTextBox.Clear();
                richTextBox.SelectionStart = cursorPosition;
            }
        }


        private void HandleClosePress(object sender, EventArgs e)
        {

            this.Close();
            newpanel.Visible = false;
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLanguage = cmbLanguage.SelectedItem.ToString();
            PopulateKeyboard(selectedLanguage);
        }

        
    }
}
