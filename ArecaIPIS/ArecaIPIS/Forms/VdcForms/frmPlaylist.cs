using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms.VdcForms;
using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmPlaylist : Form
    {


        private frmIndex parentForm;
        public frmPlaylist(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            axWindowsMediaPlayer1.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;
        }

        public frmPlaylist()
        {
            InitializeComponent();

            btnSave.Enabled = false;
            btnPlay.Enabled = false;
            btnUpArrow.Enabled = false;
            btnDownArrow.Enabled = false;


        }

        public static List<MediaFile> SetplaylistFiles = new List<MediaFile>();

        private List<MediaFile> mediaFiles = new List<MediaFile>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {


                openFileDialog.Filter = "Media Files|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.mp4;*.avi;*.mkv;*.tif;*.tiff;*.mpeg;*.wmv;*.dat;*.mov";

                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    lblAdd.Text = "";
                    int imageTime;

                    // Check if the textbox contains a valid integer
                    if (int.TryParse(txtImageTime.Text, out imageTime))
                    {
                        foreach (string file in openFileDialog.FileNames)
                        {
                            string fileName = Path.GetFileName(file);
                            string displayEffect = cmbImageEffect.Text;  // Assuming there's a ComboBox for display effect
                            string clearingEffect = cmbClearingEffect.Text;  // Assuming there's a ComboBox for clearing effect
                            string filePath = file;  // Use the full file path
                            int mediaType = GetMediaType(fileName);  // Determine the media type

                            // Create a new MediaFile with the media type included
                            MediaFile mediaFile = new MediaFile(fileName, imageTime, displayEffect, clearingEffect, filePath, mediaType);
                            mediaFiles.Add(mediaFile);
                            lsdAddFile.Items.Add(fileName);
                            lblAdd.Text += fileName + Environment.NewLine;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid integer for the image time.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        //private void txtSelectColor_Click(object sender, EventArgs e)
        //{
        //    ColorDialog colorDialog = new ColorDialog();

        //    if (colorDialog.ShowDialog() == DialogResult.OK)
        //    {

        //        Color selectedColor = colorDialog.Color;
        //        string hexValue = ColorTranslator.ToHtml(selectedColor);
        //        txtSelectColor.BackColor = selectedColor;
        //        txtSelectColor.Text = $"{hexValue}";
        //        txtColor.BackColor = selectedColor;
        //    }
        //}

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.DarkBlue;
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.DodgerBlue;
        }

        private void btnSavePlaylist_MouseHover(object sender, EventArgs e)
        {
            btnSavePlaylist.BackColor = Color.DarkBlue;
        }

        private void btnSavePlaylist_MouseLeave(object sender, EventArgs e)
        {
            btnSavePlaylist.BackColor = Color.DodgerBlue;
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.DarkBlue;
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.DodgerBlue;
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.DarkBlue;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.DodgerBlue;
        }

        private void btnPlay_MouseHover(object sender, EventArgs e)
        {
            btnPlay.BackColor = Color.DarkBlue;
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.BackColor = Color.DodgerBlue;
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.DarkBlue;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.DodgerBlue;
        }

        private void btnPreview_MouseHover(object sender, EventArgs e)
        {
            btnPreview.BackColor = Color.DarkBlue;
        }

        private void btnPreview_MouseLeave(object sender, EventArgs e)
        {
            btnPreview.BackColor = Color.DodgerBlue;
        }

        private void btnSend_MouseHover(object sender, EventArgs e)
        {
            btnSend.BackColor = Color.DarkBlue;
        }

        private void btnSend_MouseLeave(object sender, EventArgs e)
        {
            btnSend.BackColor = Color.DodgerBlue;
        }

        private void btnDisplay_MouseHover(object sender, EventArgs e)
        {
            btnDisplay.BackColor = Color.DarkBlue;
        }

        private void btnDisplay_MouseLeave(object sender, EventArgs e)
        {
            btnDisplay.BackColor = Color.DodgerBlue;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            btnSave.BackColor = Color.Green;

            btnPlay.BackColor = Color.DodgerBlue;


            ClearselectedListBox(true);
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(580, 200, "English");
        }
        //public static Panel panel = new Panel();

        private void InitializeControls()
        {
            txtSpecialMessage.Enter += Control_Enter;
        }
        private void Control_Enter(object sender, EventArgs e)
        {
            frmKeyboard.focusedControl = (Control)sender;

        }
        public static Panel panel;

        private void InitializePanel()
        {
            if (panel == null || panel.IsDisposed)
            {
                panel = new Panel
                {
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new Size(450, 180),
                    AutoSize = true
                };
            }
        }
        private void Keyboard(int x, int y, string language)
        {
            try
            {
                InitializePanel();

                panel.Location = new Point(x, y);
                panel.Visible = true;

                frmKeyboard keyBoard = new frmKeyboard(panel, language);
                keyBoard.TopLevel = false;
                keyBoard.FormBorderStyle = FormBorderStyle.None;

                panel.Controls.Add(keyBoard);
                keyBoard.Show();

                if (!this.Controls.Contains(panel))
                {
                    this.Controls.Add(panel);
                }
                panel.BringToFront();

            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show("The panel or another object was disposed and cannot be accessed. " +
                                "Please check the state of your objects and try again.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        private void upButton(ListBox listBox)
        {
            try
            {


                if (listBox.SelectedIndex > 0)
                {
                    int currentIndex = listBox.SelectedIndex;
                    object currentItem = listBox.SelectedItem;

                    listBox.Items.RemoveAt(currentIndex);
                    listBox.Items.Insert(currentIndex - 1, currentItem);
                    listBox.SelectedIndex = currentIndex - 1;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private void downButton(ListBox listBox)
        {
            try
            {


                if (listBox.SelectedIndex < listBox.Items.Count - 1 && listBox.SelectedIndex >= 0)
                {
                    int currentIndex = listBox.SelectedIndex;
                    object currentItem = listBox.SelectedItem;

                    listBox.Items.RemoveAt(currentIndex);
                    listBox.Items.Insert(currentIndex + 1, currentItem);
                    listBox.SelectedIndex = currentIndex + 1;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            upButton(lsdAddFile);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            downButton(lsdAddFile);
        }

        //private void btnUpArrow_Click(object sender, EventArgs e)
        //{
        //   // upButton(lsdAddPlaylist);


        //}
        private void btnUpArrow_Click(object sender, EventArgs e)
        {
            // Get the index of the currently selected item
            int selectedIndex = lsdAddPlaylist.SelectedIndex;

            // Check if the selected index is valid and not the first item
            if (selectedIndex > 0)
            {
                // Swap the selected item with the item above it
                SwapMediaFiles(selectedIndex, selectedIndex - 1);

                // Update the ListBox selection
                lsdAddPlaylist.SelectedIndex = selectedIndex - 1;
            }
            else
            {
                MessageBox.Show("The selected item is already at the top.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDownArrow_Click(object sender, EventArgs e)
        {

            try
            {


                // downButton(lsdAddPlaylist);
                // Get the index of the currently selected item
                int selectedIndex = lsdAddPlaylist.SelectedIndex;

                // Check if the selected index is valid and not the last item
                if (selectedIndex >= 0 && selectedIndex < lsdAddPlaylist.Items.Count - 1)
                {
                    // Swap the selected item with the item below it
                    SwapMediaFiles(selectedIndex, selectedIndex + 1);

                    // Update the ListBox selection
                    lsdAddPlaylist.SelectedIndex = selectedIndex + 1;
                }
                else
                {
                    MessageBox.Show("The selected item is already at the bottom.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        DataTable boards = new DataTable();
        DataTable boards2 = new DataTable();

        public static DataTable MediaDatabyUsername = new DataTable();
        private void frmPlaylist_Load(object sender, EventArgs e)
        {
            try
            {


                SetBoards();
                SetEntryEffects();
                SetClearingEffects();
                SetFontSize();
                InitializeControls();
                dtpDate.MinDate = DateTime.Now;
                //  dateTimePickerselected.MinDate = DateTime.Now;
                dtpScheduler.MinDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }
        private void SetFontSize()
        {
            // Clear existing items in the ComboBox
            cmbfontsize.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Font in BaseClass.FontSizeList)
            {
                // Trim the platform name
                string trimmedFont = Font.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbfontsize.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            cmbfontsize.SelectedIndex = 0;
        }
        public void SetBoards()
        {
            try
            {


                List<int> packetIdentifiers = new List<int> { 6, 7 };
                boards.Clear();
                // Fetch data from the database
                boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                foreach (DataRow row in boards.Rows)
                {
                    cmbBoardName.Items.Add(row["Location"]);

                }

                List<int> packetIdentifiers1 = new List<int> { 4 };

                // Fetch data from the database
                boards2 = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers1);

                // Clear existing rows in the DataGridView


                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in boards2.Rows)
                {

                    string ipadress = row["IPAddress"].ToString();
                    if (BaseClass.GettruecolorAgdbstatus(ipadress))
                    {
                        cmbBoardName.Items.Add(row["Location"]);
                    }
                }
                if (cmbBoardName.Items.Count > 0)
                {
                    cmbBoardName.SelectedIndex = 0;
                }

                if (cmbBoardName.Items.Count > 0)
                {
                    cmbBoardName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }

        }
        public void SetSchedulerBoards()
        {
            try
            {
                cmbSBoardips.Items.Clear();
                cmbSBoardips.Items.Add("All");
                List<int> packetIdentifiers = new List<int> { 6, 7 };
                boards.Clear();
                // Fetch data from the database
                boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                foreach (DataRow row in boards.Rows)
                {
                    cmbSBoardips.Items.Add(row["IPAddress"]);

                }

                List<int> packetIdentifiers1 = new List<int> { 4 };

                // Fetch data from the database
                boards2 = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers1);

                // Clear existing rows in the DataGridView


                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in boards2.Rows)
                {

                    string ipadress = row["IPAddress"].ToString();
                    if (BaseClass.GettruecolorAgdbstatus(ipadress))
                    {
                        cmbSBoardips.Items.Add(row["IPAddress"]);
                    }
                }
                if (cmbSBoardips.Items.Count > 0)
                {
                    cmbSBoardips.SelectedIndex = 0;
                }

                if (cmbSBoardips.Items.Count > 0)
                {
                    cmbSBoardips.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }

        }
        private void cmbBoardName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                string BoardName = cmbBoardName.Text;
                MediaDatabyUsername.Rows.Clear();
                foreach (DataRow row in boards.Rows)
                {
                    //cmbBoardName.Items.Add(row["Location"]);
                    if (boards.Columns.Contains("Location"))
                    {

                        string name = row["Location"].ToString().Trim();
                        if (name.Equals(BoardName))
                        {
                            string boardid = row["IPAddress"].ToString().Trim();
                            txtBoardIP.Text = boardid;
                            txtBoardIP.BackColor = SystemColors.Window;
                            MediaDatabyUsername = MediaDb.GetPlayListbyUser(BaseClass.UserName, boardid);
                            SetPlaylistNameforBoards();
                        }
                    }
                }
                foreach (DataRow row in boards2.Rows)
                {
                    //cmbBoardName.Items.Add(row["Location"]);
                    if (boards2.Columns.Contains("Location"))
                    {

                        string name = row["Location"].ToString().Trim();
                        if (name.Equals(BoardName))
                        {
                            string boardid = row["IPAddress"].ToString().Trim();
                            txtBoardIP.Text = boardid;
                            txtBoardIP.BackColor = SystemColors.Window;
                            MediaDatabyUsername = MediaDb.GetPlayListbyUser(BaseClass.UserName, boardid);
                            SetPlaylistNameforBoards();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }


        }

        private void SwapMediaFiles(int index1, int index2)
        {
            // Swap items in the mediaFiles list
            MediaFile temp = RetrivemediaFiles[index1];
            RetrivemediaFiles[index1] = RetrivemediaFiles[index2];
            RetrivemediaFiles[index2] = temp;

            // Update the ListBox to reflect the change
            var items = lsdAddPlaylist.Items;
            object tempItem = items[index1];
            items[index1] = items[index2];
            items[index2] = tempItem;
        }

        private void SetPlaylistNameforBoards()
        {
            cmbSelectPlaylist.Items.Clear();
            lsdAddPlaylist.Items.Clear();
            ClearselectedListBox(false);
            foreach (DataRow row in MediaDatabyUsername.Rows)
            {
                if (MediaDatabyUsername.Columns.Contains("Username") && MediaDatabyUsername.Columns.Contains("PlayListname") &&
                    MediaDatabyUsername.Columns.Contains("Boardid"))
                {
                    string playlistname = row["PlayListname"].ToString().Trim();

                    cmbSelectPlaylist.Items.Add(playlistname);

                }
            }
            if (cmbSelectPlaylist.Items.Count > 0)
            {
                cmbSelectPlaylist.SelectedIndex = 0;
            }
            else
            {
                txtuRepeatCount.Text = "";
                txtUStarthour.Text = "";

                txtUStartminute.Text = "";
                txtuEndhour.Text = "";
                txtuEndMinute.Text = "";
            }

        }

        private void SetEntryEffects()
        {
            // Clear existing items in the ComboBox
            cmbImageEffect.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Effects in BaseClass.EntryEffectList)
            {
                // Trim the platform name
                string trimmedEffects = Effects.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbImageEffect.Items.Add(trimmedEffects);
            }
            // Select the default item "--Select--"
            cmbImageEffect.SelectedIndex = 0;
        }
        public static int GetClearingEffects(string effect)
        {
            int effectcode = 0;
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (DataRow row in BaseClass.EntryEffectDt.Rows)
            {
                if (effect == row["Name"].ToString())
                {
                    effectcode = Convert.ToInt32(row["EffectID"].ToString());
                }


            }
            return effectcode;
        }
        public static int GetEntryEffects(string effect)
        {

            int effectcode = 0;
            foreach (DataRow row in BaseClass.EntryEffectDt.Rows)
            {
                if (effect == row["Name"].ToString())
                {
                    effectcode = Convert.ToInt32(row["Pkey_DisplayEffect"].ToString());
                }


            }
            return effectcode;
        }
        public void SetClearingEffects()
        {
            // Clear existing items in the ComboBox
            cmbClearingEffect.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Effects in BaseClass.ClearingEffectsList)
            {
                // Trim the platform name
                string trimmedEffects = Effects.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbClearingEffect.Items.Add(trimmedEffects);
            }
            // Select the default item "--Select--"
            cmbClearingEffect.SelectedIndex = 0;
        }
        public static string GetmediaEntryEffectCode(string effect)
        {


            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.EntryEffectDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Name"].ToString().Trim() == effect)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pkey_DisplayEffect"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearListBox(lsdAddFile);


        }

        public void ClearListBox(ListBox listBox)
        {
            lblAdd.Text = "No File Chosen";
            mediaFiles.Clear();
            listBox.Items.Clear();
            txtPlaylistName.Text = "";
            txtRepeatCount.Text = "";
            txtuRepeatCount.Text = "";
            txtOVDstarttime.Text = "";
            txtstartminOVD.Text = "";
            txtOVDendhour.Text = "";
            txtOVDendmin.Text = "";


        }
        public void ClearselectedListBox(bool status)
        {
            dateTimePickerselected.Enabled = status;
            txtuRepeatCount.Enabled = status;
            txtUStarthour.Enabled = status;

            txtUStartminute.Enabled = status;
            txtuEndhour.Enabled = status;
            txtuEndMinute.Enabled = status;
            btnUpArrow.Visible = status;
            btnDownArrow.Visible = status;
            btnPlay.Visible = status;
            btnSave.Visible = status;
        }
        private void btnSavePlaylist_Click(object sender, EventArgs e)
        {

            try
            {

                DateTime date = dtpDate.Value.Date;

                bool hasError = false; // Flag to track if there's any error

                // Check and highlight each required text box
                hasError |= CheckAndHighlightEmptyField(txtPlaylistName);
                hasError |= CheckAndHighlightEmptyField(txtImageTime);
                hasError |= CheckAndHighlightEmptyField(txtRepeatCount);
                hasError |= CheckAndHighlightEmptyField(txtOVDstarttime);
                hasError |= CheckAndHighlightEmptyField(txtstartminOVD);
                hasError |= CheckAndHighlightEmptyField(txtOVDendhour);
                hasError |= CheckAndHighlightEmptyField(txtOVDendmin);

                hasError |= CheckAndHighlightEmptyField(txtBoardIP);
                hasError |= CheckListBoxEmpty(lsdAddFile);


                if (hasError)
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {
                    bool Error = false;
                    //Error |= CheckPlaylistName(txtPlaylistName);


                    string UserName = BaseClass.UserName;
                    string BoardName = cmbBoardName.Text.Trim();
                    string BoardId = txtBoardIP.Text.Trim();
                    string playListName = txtPlaylistName.Text.Trim();
                    int RepeatCount = Convert.ToInt32(txtRepeatCount.Text.Trim());

                    int startHour = int.Parse(txtOVDstarttime.Text.Trim());
                    int startMinute = int.Parse(txtstartminOVD.Text.Trim());
                    int endHour = int.Parse(txtOVDendhour.Text.Trim());
                    int endMinute = int.Parse(txtOVDendmin.Text.Trim());

                    bool timeError = CheckTime(startHour.ToString(), startMinute.ToString(), endHour.ToString(), endMinute.ToString(), date);
                    if (!timeError)
                    {
                        return;
                    }
                    else
                    {


                        Error |= CheckPlaylistExist(txtPlaylistName, startHour.ToString(), startMinute.ToString(), endHour.ToString(), endMinute.ToString(), date);

                        if (!Error)
                        {
                            MessageBox.Show("PlayList Name Already Exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Create a new List<string>
                            List<string> files = new List<string>();

                            // Iterate through the items in the ListBox and add each to the List<string>
                            foreach (var item in lsdAddFile.Items)
                            {
                                files.Add(item.ToString());
                            }

                            DataTable playlist = CreateMediaFilesDataTable(files, mediaFiles);

                            int rowseffected = MediaDb.InsertUpdatePlayList(UserName, BoardName, BoardId, playListName, playlist, RepeatCount, startHour.ToString(), startMinute.ToString(), endHour.ToString(), endMinute.ToString(), date);
                            if (rowseffected >= 0)
                            {
                                ClearListBox(lsdAddFile);
                                MediaDatabyUsername = MediaDb.GetPlayListbyUser(BaseClass.UserName, BoardId);
                                MediaDb.GetAllPlayLists();
                                SetPlaylistNameforBoards();
                                cmbSBoardips.Items.Clear();
                            }

                        }
                    }



                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }



        }


        private DataTable CreateMediaFilesDataTable(List<string> files, List<MediaFile> mediaFiles)
        {




            DataTable mediaFilesTable = new DataTable();
            try
            {


                mediaFilesTable.Columns.Add("FileName", typeof(string));
                mediaFilesTable.Columns.Add("ImageTime", typeof(int));
                mediaFilesTable.Columns.Add("ImageEffect", typeof(string));
                mediaFilesTable.Columns.Add("ClearingEffect", typeof(string));
                mediaFilesTable.Columns.Add("FilePath", typeof(string));
                mediaFilesTable.Columns.Add("MediaType", typeof(string));


                foreach (var item in files)
                {
                    foreach (var mediaFile in mediaFiles)
                    {
                        if (item.Equals(mediaFile.FileName))
                        {
                            DataRow row = mediaFilesTable.NewRow();
                            row["FileName"] = mediaFile.FileName;
                            row["ImageTime"] = mediaFile.ImageTime;
                            row["ImageEffect"] = mediaFile.DisplayEffect;
                            row["ClearingEffect"] = mediaFile.ClearingEffect;
                            row["FilePath"] = mediaFile.FilePath;
                            row["MediaType"] = mediaFile.MediaType;
                            mediaFilesTable.Rows.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return mediaFilesTable;
        }

        private bool CheckAndHighlightEmptyField(TextBox TextBox)
        {
            if (string.IsNullOrWhiteSpace(TextBox.Text))
            {
                TextBox.BackColor = Color.Red;
                return true;
            }
            else
            {
                TextBox.BackColor = SystemColors.Window;
                return false;
            }
        }

        private bool CheckPlaylistName(TextBox TextBox)
        {


            if (string.IsNullOrWhiteSpace(TextBox.Text))
            {

                return true; // Indicate that this text box has an error
            }
            else
            {


                string UserName = BaseClass.UserName;
                string BoardName = cmbBoardName.Text;
                string BoardId = txtBoardIP.Text;
                foreach (DataRow row in MediaDatabyUsername.Rows)
                {
                    if (MediaDatabyUsername.Columns.Contains("Username") && MediaDatabyUsername.Columns.Contains("PlayListname") &&
                        MediaDatabyUsername.Columns.Contains("Boardid"))
                    {
                        string playlistname = row["PlayListname"].ToString().Trim();

                        if (playlistname.Equals(TextBox.Text.Trim()))
                        {


                            return true;
                        }

                    }
                }

                TextBox.BackColor = SystemColors.Window; // Reset background color
                return false; // No error for this text box
            }



        }
        private bool CheckTime(string starthour, string startminute, string endhour, string endminute, DateTime date)
        {
            // Get the current date and time
            DateTime currentTime = DateTime.Now;

            // Parse the start time
            int startHour = int.Parse(starthour);
            int startMinute = int.Parse(startminute);
            DateTime startTime = new DateTime(date.Year, date.Month, date.Day, startHour, startMinute, 0);

            // Parse the end time
            int endHour = int.Parse(endhour);
            int endMinute = int.Parse(endminute);
            DateTime endTime = new DateTime(date.Year, date.Month, date.Day, endHour, endMinute, 0);

            // Check if the start time is at least 1 minute ahead of the current time
            if (startTime <= currentTime.AddMinutes(1))
            {
                MessageBox.Show("Start time must be at least 1 minute ahead of the current time.");
                return false; // Return false if the start time is too soon
            }

            // Check if the end time is greater than the start time
            if (endTime <= startTime)
            {
                MessageBox.Show("End time must be greater than start time.");
                return false; // Return false if the end time is not after the start time
            }

            // If both conditions are met, return true
            return true;
        }


        private bool CheckPlaylistExist(TextBox TextBox, string starthour, string startminute, string endhour, string endminute, DateTime date)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(TextBox.Text))
            {
                return true; // Indicate that this text box has an error
            }

            // Get the relevant details for comparison
            string UserName = BaseClass.UserName;
            string BoardName = cmbBoardName.Text;
            string BoardId = txtBoardIP.Text;

            // Loop through the rows in the dataset
            foreach (DataRow row in MediaDatabyUsername.Rows)
            {
                if (MediaDatabyUsername.Columns.Contains("Username") &&
                    MediaDatabyUsername.Columns.Contains("PlayListname") &&
                    MediaDatabyUsername.Columns.Contains("Boardid") &&
                    MediaDatabyUsername.Columns.Contains("StartHour") &&
                    MediaDatabyUsername.Columns.Contains("StartMinute") &&
                    MediaDatabyUsername.Columns.Contains("EndHour") &&
                    MediaDatabyUsername.Columns.Contains("EndMinute") &&
                    MediaDatabyUsername.Columns.Contains("Date"))
                {
                    // Extract playlist details
                    string playlistname = row["PlayListname"].ToString().Trim();
                    string Estarthour = row["StartHour"].ToString().Trim();
                    string Estartminute = row["StartMinute"].ToString().Trim();
                    string EEndhour = row["EndHour"].ToString().Trim();
                    string Eendminute = row["EndMinute"].ToString().Trim();
                    DateTime edate = DateTime.Parse(row["Date"].ToString().Trim());

                    // Check if the date and time intervals overlap
                    if (edate.Date == date.Date)
                    {
                        // Convert all times to minutes since midnight for easier comparison
                        int existingStart = int.Parse(Estarthour) * 60 + int.Parse(Estartminute);
                        int existingEnd = int.Parse(EEndhour) * 60 + int.Parse(Eendminute);
                        int newStart = int.Parse(starthour) * 60 + int.Parse(startminute);
                        int newEnd = int.Parse(endhour) * 60 + int.Parse(endminute);

                        // Check for overlap
                        if ((newStart < existingEnd && newEnd > existingStart) ||
                            (newStart == existingStart && newEnd == existingEnd))
                        {
                            return false; // A matching playlist exists
                        }
                    }
                }
            }

            // Reset TextBox background color if no error
            TextBox.BackColor = SystemColors.Window;
            return true; // No matching playlist exists
        }


        //private bool CheckPlaylistExist(TextBox TextBox, string starthour, string startminute, string endhour, string endminute, DateTime date)
        //{


        //    if (string.IsNullOrWhiteSpace(TextBox.Text))
        //    {

        //        return true; // Indicate that this text box has an error
        //    }
        //    else
        //    {


        //        string UserName = BaseClass.UserName;
        //        string BoardName = cmbBoardName.Text;
        //        string BoardId = txtBoardIP.Text;
        //        foreach (DataRow row in MediaDatabyUsername.Rows)
        //        {
        //            if (MediaDatabyUsername.Columns.Contains("Username") && MediaDatabyUsername.Columns.Contains("PlayListname") &&
        //                MediaDatabyUsername.Columns.Contains("Boardid"))
        //            {
        //                string playlistname = row["PlayListname"].ToString().Trim();
        //               string Estarthour = row["StartHour"].ToString().Trim();
        //                string Estartminute = row["StartMinute"].ToString().Trim();
        //                string EEndhour = row["EndHour"].ToString().Trim();
        //                string Eendminute = row["EndMinute"].ToString().Trim();

        //               DateTime edate = DateTime.Parse(row["Date"].ToString().Trim());



        //            }
        //        }

        //        TextBox.BackColor = SystemColors.Window; // Reset background color
        //        return false; // No error for this text box
        //    }



        //}

        private bool CheckListBoxEmpty(ListBox listBox)
        {
            if (listBox.Items.Count <= 0)
            {
                listBox.BackColor = Color.Red;
                return true;
            }
            else
            {
                listBox.BackColor = SystemColors.Window;
                return false;
            }
        }

        private void txtImageTime_TextChanged(object sender, EventArgs e)
        {
            txtImageTime.BackColor = SystemColors.Window;
        }

        private void txtPlaylistName_Click(object sender, EventArgs e)
        {
            txtPlaylistName.BackColor = SystemColors.Window;
        }


        private int GetMediaType(string fileName)
        {
            try
            {


                string extension = Path.GetExtension(fileName).ToLower();

                if (new[] { ".jpg", ".jpeg", ".bmp", ".png", ".tif", ".tiff" }.Contains(extension))
                {
                    return 0; // Image
                }
                else if (new[] { ".mp4", ".avi", ".mkv", ".mpeg", ".gif", ".dat", ".mov", ".wmv" }.Contains(extension))
                {
                    return 1; // Video
                }
                else
                {
                    return 2; // Animation or Unknown
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return 0;
        }
        List<MediaFile> RetrivemediaFiles = new List<MediaFile>();
        string playlistSelectedUserName = BaseClass.UserName;
        string playlistSelectedBoardName = "";
        public static string playlistSelectedBoardId = "";
        public static string playlistSelectedplaylistname = "";

        private void cmbSelectPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                lsdAddPlaylist.Items.Clear();
                RetrivemediaFiles.Clear();
                txtUStarthour.Text = "";
                txtUStartminute.Text = "";
                txtuEndhour.Text = "";
                txtuEndMinute.Text = "";
                txtuRepeatCount.Text = "";
                ClearselectedListBox(false);

                string UserName = BaseClass.UserName.Trim();
                string BoardName = cmbBoardName.Text.Trim();
                string BoardId = txtBoardIP.Text.Trim();
                string playlistname = cmbSelectPlaylist.Text;
                DataTable files = MediaDb.GetPlayListbyUserplaylistname(UserName, BoardId, playlistname);

                foreach (DataRow row in MediaDatabyUsername.Rows)
                {
                    if (MediaDatabyUsername.Columns.Contains("Username") && MediaDatabyUsername.Columns.Contains("PlayListname") &&
                        MediaDatabyUsername.Columns.Contains("Boardid"))
                    {
                        string playlist = row["PlayListname"].ToString().Trim();
                        if (playlistname == playlist)
                        {

                            playlistSelectedplaylistname = playlist;
                            playlistSelectedBoardId = row["Boardid"].ToString().Trim();
                            txtUStarthour.Text = row["StartHour"].ToString().Trim();
                            txtUStartminute.Text = row["StartMinute"].ToString().Trim();
                            txtuEndhour.Text = row["EndHour"].ToString().Trim();
                            txtuEndMinute.Text = row["EndMinute"].ToString().Trim();
                            txtuRepeatCount.Text = row["RepeatCount"].ToString().Trim();
                            dateTimePickerselected.Value = DateTime.Parse(row["Date"].ToString().Trim());


                        }

                        // cmbSelectPlaylist.Items.Add(playlist);

                    }
                }

                foreach (DataRow row in files.Rows)
                {
                    string fileName = row["FileName"].ToString();
                    int imageTime = Convert.ToInt32(row["imagetime"]);
                    string imageEffect = row["ImageEffect"].ToString();
                    string clearingEffect = row["ClearingEffect"].ToString();
                    string filePath = row["FilePath"].ToString();
                    int mediaType = Convert.ToInt32(row["MediaType"]);
                    playlistSelectedBoardName = row["BoardName"].ToString();

                    MediaFile mediaFile = new MediaFile(fileName, imageTime, imageEffect, clearingEffect, filePath, mediaType);
                    RetrivemediaFiles.Add(mediaFile);

                    lsdAddPlaylist.Items.Add(fileName);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {





                btnSave.BackColor = Color.DodgerBlue;

                btnPlay.BackColor = Color.DodgerBlue;



                List<string> files = new List<string>();


                foreach (var item in lsdAddPlaylist.Items)
                {
                    files.Add(item.ToString());
                }
                int startHour = int.Parse(txtUStarthour.Text.Trim());
                int startMinute = int.Parse(txtUStartminute.Text.Trim());
                int endHour = int.Parse(txtuEndhour.Text.Trim());
                int endMinute = int.Parse(txtuEndMinute.Text.Trim());
                DateTime date = dateTimePickerselected.Value.Date;

                int playlistSelectedRepeatCount = int.Parse(txtuRepeatCount.Text.Trim());


                DataTable playlist = CreateMediaFilesDataTable(files, RetrivemediaFiles);
                bool timeError = CheckTime(startHour.ToString(), startMinute.ToString(), endHour.ToString(), endMinute.ToString(), date);
                if (!timeError)
                {
                    return;
                }
                else
                {
                    int rowseffected = MediaDb.InsertUpdatePlayList(playlistSelectedUserName, playlistSelectedBoardName.Trim(), playlistSelectedBoardId, playlistSelectedplaylistname, playlist, playlistSelectedRepeatCount, startHour.ToString(), startMinute.ToString(), endHour.ToString(), endMinute.ToString(), date);
                    if (rowseffected >= 0)
                    {
                        txtUStarthour.Text = "";
                        txtUStartminute.Text = "";
                        txtuEndhour.Text = "";
                        txtuEndMinute.Text = "";
                        txtuRepeatCount.Text = "";
                        ClearListBox(lsdAddFile);
                        MediaDatabyUsername = MediaDb.GetPlayListbyUser(BaseClass.UserName, playlistSelectedBoardId);
                        MediaDb.GetAllPlayLists();
                        SetPlaylistNameforBoards();
                        ClearselectedListBox(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {


                string UserName = BaseClass.UserName;
                string BoardName = cmbBoardName.Text;
                string BoardId = txtBoardIP.Text;
                string playlistname = cmbSelectPlaylist.Text;
                DateTime date = dateTimePickerselected.Value.Date;

                int rowseffected = MediaDb.DeletePlaylist(UserName, BoardId, playlistname, date);
                if (rowseffected > 0)
                {
                    ClearListBox(lsdAddFile);
                    MediaDatabyUsername = MediaDb.GetPlayListbyUser(BaseClass.UserName, BoardId);
                    SetPlaylistNameforBoards();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private bool videoPlaying = false;
        private void btnPlay_Click(object sender, EventArgs e)
        {

            try
            {

                int selectedIndex = lsdAddPlaylist.SelectedIndex;


                if (selectedIndex < -1 || selectedIndex >= RetrivemediaFiles.Count)
                {
                    MessageBox.Show("Please select a media file to play.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MediaFile mediaFile = RetrivemediaFiles[selectedIndex];
                string filePath = mediaFile.FilePath;

                if (mediaFile.MediaType == 0) // Image
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    pictureBox.Visible = true;
                    axWindowsMediaPlayer1.Visible = false;
                    pictureBox.Image = Image.FromFile(filePath);

                }
                else if (mediaFile.MediaType == 1) // Video
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    pictureBox.Visible = false;
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.URL = filePath;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
                else if (mediaFile.MediaType == 2)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    pictureBox.Visible = false;
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.URL = filePath;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {


                List<MediaFile> playlistFiles = new List<MediaFile>();

                playlistFiles = RetrivemediaFiles;


                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.Visible = false;


                pictureBox.Visible = true;


                PlayMediaFilesAsync(playlistFiles);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private async Task PlayMediaFilesAsync(List<MediaFile> mediaFiles)
        {
            try
            {


                if (mediaFiles == null || mediaFiles.Count == 0)
                    return;

                foreach (var mediaFile in mediaFiles)
                {
                    if (mediaFile.MediaType == 0)
                    {
                        await DisplayImageAsync(mediaFile.FilePath, mediaFile.ImageTime);
                    }
                    else if (mediaFile.MediaType == 1)
                    {
                        await PlayVideoAsync(mediaFile.FilePath);

                        await WaitForVideoToFinishAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private async Task DisplayImageAsync(string filePath, int displayTime)
        {
            try
            {


                // Stop any playing video
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.Visible = false;

                // Display the image
                pictureBox.Visible = true;
                pictureBox.Image = Image.FromFile(filePath);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                await Task.Delay(displayTime * 1000);


                pictureBox.Image = null;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private async Task PlayVideoAsync(string filePath)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            pictureBox.Visible = false;
            axWindowsMediaPlayer1.Visible = true;

            axWindowsMediaPlayer1.URL = filePath;
            axWindowsMediaPlayer1.Ctlcontrols.play();

            videoPlaying = true; // Set to true when video starts playing
        }

        private async Task WaitForVideoToFinishAsync()
        {
            // Wait until video playback has finished
            while (videoPlaying)
            {
                await Task.Delay(100); // Check periodically
            }
        }

        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Check if the media has stopped
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsStopped)
            {
                videoPlaying = false;
                pictureBox.Visible = true;
            }
        }




        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = BaseClass.UserName;
                string BoardName = cmbBoardName.Text;
                string BoardId = txtBoardIP.Text;
                string playlistname = cmbSelectPlaylist.Text;
                DialogResult dialogResult = MessageBox.Show("Do you want to Transfer Playlist before Scheduling", "Send Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SendPlaylist(UserName, BoardId, playlistname);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }


        public static void SendPlaylist(string UserName, string BoardId, string playlistname)
        {
            try
            {
                MediaDatabyUsername.Rows.Clear();
                SetplaylistFiles.Clear();
                int startHour = 0; ;
                int startMinute = 0;
                int endHour = 0;
                int endMinute = 0;
                int DisplayType = 0;
                int RepeatCount = 0;


                DataTable files = MediaDb.GetPlayListbyUserplaylistname(UserName, BoardId, playlistname);

                MediaDatabyUsername = MediaDb.GetPlayListbyUser(BaseClass.UserName, BoardId);

                foreach (DataRow row in MediaDatabyUsername.Rows)
                {
                    if (MediaDatabyUsername.Columns.Contains("Username") && MediaDatabyUsername.Columns.Contains("PlayListname") &&
                        MediaDatabyUsername.Columns.Contains("Boardid"))
                    {
                        string playlist = row["PlayListname"].ToString().Trim();
                        if (playlistname == playlist)
                        {

                            playlistSelectedplaylistname = playlist;
                            playlistSelectedBoardId = row["Boardid"].ToString().Trim();
                            startHour = Convert.ToInt32(row["StartHour"].ToString().Trim());
                            startMinute = Convert.ToInt32(row["StartMinute"].ToString().Trim());
                            endHour = Convert.ToInt32(row["EndHour"].ToString().Trim());
                            endMinute = Convert.ToInt32(row["EndMinute"].ToString().Trim());
                            RepeatCount = Convert.ToInt32(row["RepeatCount"].ToString().Trim());

                        }

                        //cmbSelectPlaylist.Items.Add(playlist);

                    }
                }

                if (files.Rows.Count > 0)
                {



                    foreach (DataRow row in files.Rows)
                    {
                        string fileName = row["FileName"].ToString().Trim();
                        int imageTime = Convert.ToInt32(row["imagetime"]);
                        string imageEffect = row["ImageEffect"].ToString().Trim();
                        string clearingEffect = row["ClearingEffect"].ToString().Trim();
                        string filePath = row["FilePath"].ToString().Trim();
                        int mediaType = Convert.ToInt32(row["MediaType"]);

                        MediaFile mediaFile = new MediaFile(fileName, imageTime, imageEffect, clearingEffect, filePath, mediaType);
                        SetplaylistFiles.Add(mediaFile);


                    }

                    int packetidentifier = 0;
                    string speed = "2";

                    string volumn = "14";

                    string messageFontSize = "14";
                    string messageCharacterGap = "0";
                    string messageTopBottom = "1";//top 1 bottom 0
                    string messageLine = "1"; //Enable 1 disable 0


                    int lastOctet = int.Parse(BoardId.Split('.').Last());

                    if (lastOctet >= 130 && lastOctet <= 160)
                    {
                        packetidentifier = Board.GetPacketIdentifier(BoardId);
                        // SetForDisplay(SetplaylistFiles, BoardId);
                        // MediaDatatruecolorAgdb(files, BoardId, 1);

                    }
                    else
                    {

                        packetidentifier = Board.GetPacketIdentifier(BoardId);
                        int MasterHubPkey = Board.GetMasterHubKey(BoardId);

                        DataTable MediadetailybyPk = new DataTable();
                        MediadetailybyPk = HubConfigurationDb.GetMediaDetails(MasterHubPkey);

                        foreach (DataRow row in MediadetailybyPk.Rows)
                        {
                            if (MediadetailybyPk.Columns.Contains("fkey_masterHub") && int.TryParse(row["fkey_masterHub"].ToString(), out int PkMasterHub))
                            {
                                if (PkMasterHub == MasterHubPkey)
                                {
                                    speed = row["Speed"].ToString().Trim();

                                    volumn = row["Volumn"].ToString().Trim();

                                    messageFontSize = row["MessageFontSize"].ToString().Trim();
                                    messageCharacterGap = row["MessageCharacterGap"].ToString().Trim();
                                    //startHour = Convert.ToInt32(row["StartHour"].ToString().Trim());
                                    //startMinute = Convert.ToInt32(row["StartMinute"].ToString().Trim());

                                    //endHour = Convert.ToInt32(row["EndHour"].ToString().Trim());
                                    //endMinute = Convert.ToInt32(row["EndMinute"].ToString().Trim());
                                    DisplayType = Convert.ToInt32(row["DisplayType"].ToString().Trim());

                                    messageTopBottom = row["MessageTopBottom"].ToString().Trim();


                                    messageLine = row["MessageLine"].ToString().Trim();

                                }
                            }
                        }
                    }
                    if (DisplayType == 0 || DisplayType == 2)
                    {

                        if (Server._connectedClients.TryGetValue(BoardId, out TcpClient client))
                        {

                            SetForDisplay(SetplaylistFiles, BoardId);

                            byte[] DataTransferPacket = MediaPacketPreparation(BoardId, packetidentifier, playlistname, SetplaylistFiles, speed, volumn, messageFontSize, messageCharacterGap, messageTopBottom, messageLine, startHour, startMinute, endHour, endMinute, RepeatCount);
                            byte[] trimmedDataTransferPacket = ByteFormation.RemoveFirstAndLast6(DataTransferPacket);
                            Server.SendMessageToClient(BoardId, DataTransferPacket);

                            MessageBox.Show("PlayList Send Sucessfully!");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        public static StringBuilder MediaDatatruecolorAgdb(DataTable dt, string Ipaddress, int MediaType)
        {
            StringBuilder Textfile = new StringBuilder();
            if (MediaType == 0)
            {
                string sep = "~";

                //DataTable DataPart = dt.Tables[1];
                DataTable dr = new DataTable();
                try
                {

                    int i = 0;
                    foreach (DataRow r in dt.Rows)
                    {
                        if (i == 0)
                        {
                            //  int EffectCode = GetImageEffect(r[5].ToString());
                            int EffectCode = GetEntryEffects(r[7].ToString());
                            int clearingEffectCode = GetClearingEffects(r[8].ToString());
                            Textfile.Append("0" + Environment.NewLine);
                            string imagetime;
                            if (r[10].ToString() == "1")
                            {
                                imagetime = "0";
                            }
                            else
                            {
                                imagetime = r[6].ToString();
                            }
                            Textfile.Append(r[5].ToString().Trim() + sep + (i + 1) + sep + EffectCode.ToString() + sep + imagetime + sep + 10 + sep + "True" + sep + clearingEffectCode.ToString() + Environment.NewLine);

                            i++;
                        }
                        else
                        {
                            int EffectCode = GetEntryEffects(r[8].ToString());
                            int clearingEffectCode = GetClearingEffects(r[9].ToString());
                            string imagetime;
                            if (r[10].ToString() == "1")
                            {
                                imagetime = "0";
                            }
                            else
                            {
                                imagetime = r[6].ToString();
                            }

                            Textfile.Append(r[5].ToString().Trim() + sep + (i + 1) + sep + EffectCode.ToString() + sep + imagetime + sep + 10 + sep + "True" + sep + clearingEffectCode.ToString() + Environment.NewLine);
                            i++;
                        }
                    }
                    //Textfile.Append(GetTrueStatusColorConfig());

                    //Textfile.Append(GetTrueColorBrightnessConfig(Boardpkey));
                    //Textfile.Append(GetTruecolorBoardConfig(Ipaddress));

                    CreateVdcFile(Textfile, Ipaddress);


                }
                catch (Exception ex)
                {
                    Server.LogError(ex.ToString());
                    ///return null;
                }
                return Textfile;
            }
            else

            {
                string sep = "~";

                //DataTable DataPart = dt.Tables[1];
                DataTable dr = new DataTable();
                try
                {
                    int i = 0;
                    foreach (DataRow r in dt.Rows)
                    {
                        if (i == 0)
                        {
                            int EffectCode = GetEntryEffects(r[8].ToString());
                            int clearingEffectCode = GetClearingEffects(r[9].ToString());
                            string imagetime;
                            if (r[10].ToString() == "1")
                            {
                                imagetime = "0";
                            }
                            else
                            {
                                imagetime = r[6].ToString();
                            }

                            Textfile.Append("0" + Environment.NewLine);
                            Textfile.Append(r[5].ToString().Trim() + sep + (i + 1) + sep + EffectCode.ToString() + sep + imagetime + sep + 10 + sep + "True" + sep + clearingEffectCode.ToString() + Environment.NewLine);
                            i++;
                        }
                        else
                        {
                            int EffectCode = GetEntryEffects(r[8].ToString());
                            int clearingEffectCode = GetClearingEffects(r[9].ToString());
                            string imagetime;
                            if (r[10].ToString() == "1")
                            {
                                imagetime = "0";
                            }
                            else
                            {
                                imagetime = r[6].ToString();
                            }
                            Textfile.Append("1" + Environment.NewLine);
                            Textfile.Append(r[5].ToString().Trim() + sep + (i + 1) + sep + EffectCode.ToString() + sep + imagetime + sep + 10 + sep + "True" + sep + clearingEffectCode.ToString() + Environment.NewLine);
                            i++;
                        }
                    }
                    //Textfile.Append(GetTrueStatusColorConfig());

                    //Textfile.Append(GetTrueColorBrightnessConfig(Boardpkey));
                    //Textfile.Append(GetTruecolorBoardConfig(Ipaddress));

                    CreateVdcFile(Textfile, Ipaddress);


                }
                catch (Exception ex)
                {
                    Server.LogError(ex.ToString());
                    ///return null;
                }
                return Textfile;
            }
        }


        //public static StringBuilder MediaData(DataTable dt, string Ipaddress, int MediaType)
        //{
        //    StringBuilder Textfile = new StringBuilder();
        //    if (MediaType == 0)
        //    {
        //        string sep = "~";

        //        //DataTable DataPart = dt.Tables[1];
        //        DataTable dr = new DataTable();
        //        try
        //        {

        //            int i = 0;
        //            foreach (DataRow r in dt.Rows)
        //            {
        //                if (i == 0)
        //                {
        //                    int EffectCode = GetImageEffect(r[5].ToString());
        //                    Textfile.Append("0" + Environment.NewLine);
        //                    Textfile.Append(r[2] + sep + r[3] + sep + EffectCode.ToString() + sep + r[6] + sep + r[11] + sep + r[12] + sep + r[7] + Environment.NewLine);

        //                    i++;
        //                }
        //                else
        //                {
        //                    int EffectCode = GetImageEffect(r[5].ToString());

        //                    Textfile.Append(r[2] + sep + r[3] + sep + EffectCode.ToString() + sep + r[6] + sep + r[11] + sep + r[12] + sep + r[7] + Environment.NewLine);

        //                    i++;
        //                }
        //            }
        //            //Textfile.Append(GetTrueStatusColorConfig());

        //            //Textfile.Append(GetTrueColorBrightnessConfig(Boardpkey));
        //            //Textfile.Append(GetTruecolorBoardConfig(Ipaddress));

        //            CreateVdcFile(Textfile, Ipaddress);


        //        }
        //        catch (Exception ex)
        //        {
        //            ex.ToString();
        //            ///return null;
        //        }
        //        return Textfile;
        //    }
        //    else

        //    {
        //        string sep = "~";

        //        //DataTable DataPart = dt.Tables[1];
        //        DataTable dr = new DataTable();
        //        try
        //        {
        //            int i = 0;
        //            foreach (DataRow r in dt.Rows)
        //            {
        //                if (i == 0)
        //                {
        //                    int EffectCode = GetImageEffect(r[6].ToString());
        //                    Textfile.Append("1" + Environment.NewLine);
        //                    Textfile.Append(r[2] + sep + r[4] + sep + EffectCode.ToString() + sep + r[10] + sep + r[11] + sep + r[5] + Environment.NewLine);

        //                    i++;
        //                }
        //                else
        //                {
        //                    int EffectCode = GetImageEffect(r[6].ToString());

        //                    Textfile.Append(r[2] + sep + r[4] + sep + EffectCode.ToString() + sep + r[10] + sep + r[11] + sep + r[5] + Environment.NewLine);

        //                    i++;
        //                }
        //            }
        //            //Textfile.Append(GetTrueStatusColorConfig());

        //            //Textfile.Append(GetTrueColorBrightnessConfig(Boardpkey));
        //            //Textfile.Append(GetTruecolorBoardConfig(Ipaddress));

        //            CreateVdcFile(Textfile, Ipaddress);


        //        }
        //        catch (Exception ex)
        //        {
        //            ex.ToString();
        //            ///return null;
        //        }
        //        return Textfile;
        //    }
        //}

        public static void CreateVdcFile(StringBuilder textfile, string IpAddress)
        {
            StreamWriter swExtLogFiles;
            //string vdcfile = "Test";
            try
            {

                DirectoryInfo logDirInfos = null;
                FileInfo logFileInfos;
                string logFilePaths = "C:\\ShareToAll\\";
                logFilePaths = logFilePaths + "Media.txt";
                logFileInfos = new FileInfo(logFilePaths);
                logDirInfos = new DirectoryInfo(logFileInfos.DirectoryName);
                if (!logDirInfos.Exists) logDirInfos.Create();
                if (!logFileInfos.Exists)
                {
                    logFileInfos.Create();
                }

                File.WriteAllText(logFilePaths, String.Empty);
                swExtLogFiles = new StreamWriter(logFilePaths, true);

                swExtLogFiles.Write(textfile);
                swExtLogFiles.Flush();
                swExtLogFiles.Close();
                //    swExtLogFiles.Write(Environment.NewLine);
                createftpfile(textfile.ToString(), IpAddress, "ArecaVdc", "Areca");


            }
            catch (Exception ex)
            {
                ex.ToString();


            }



        }

        public static void createftpfile(string textContent, string ftpUrl, string userName, string password)
        {
            string testpath = ftpUrl;
            string fullpath = "FTP://" + ftpUrl + "/Media/Media.txt";
            // Get the object used to communicate with the server.
            //FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(path + "Config.xml");
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fullpath);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // request.Credentials = new NetworkCredential(userName, password);

            // convert contents to byte.
            byte[] fileContents = Encoding.Unicode.GetBytes(textContent); ;

            request.ContentLength = fileContents.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();
                requestStream.Dispose();

            }


            //using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            //{
            //    //Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            //}
        }



        private static byte[] MediaPacketPreparation(string ipaddress, int packetidentifier, string playListName, List<MediaFile> mediaFiles, string speed,
        string volumn, string messageFontSize, string messageCharacterGap, string messageTopBottom, string messageLine, int startHour, int startMinute, int endHour, int endMinute, int RepeatCount)
        {
            try
            {


                Byte[] sendbyte = ByteFormation.CommonBytes(ipaddress, packetidentifier);
                Array.Resize(ref sendbyte, sendbyte.Length + 2);
                //int sodDataType = 2; //sod and defult and window
                sendbyte[10] = (byte)ArecaIPIS.Classes.Board.MediaData;  //packet Type
                sendbyte[11] = 2;  //Sod

                int WindowsCount = mediaFiles.Count;



                int WindowsLength = WindowsCount * 10;

                List<byte[]> bytePlaylistpacket = new List<byte[]>();


                List<byte[]> byteArrayWindows = new List<byte[]>();

                byte[] terminationBytes = ByteFormation.GetTerminationBytes();

                for (int z = 0; z < WindowsCount; z++)
                {
                    byte[] windows = WindowFormation(mediaFiles[z], speed, volumn, messageFontSize, messageCharacterGap, messageTopBottom, messageLine, startHour, startMinute, endHour, endMinute, RepeatCount);

                    byteArrayWindows.Add(windows);
                }

                List<byte[]> byteArrayfilenames = new List<byte[]>();

                for (int z = 0; z < WindowsCount; z++)
                {

                    byte[] filenames = GetFileNames(mediaFiles[z]);

                    byteArrayfilenames.Add(filenames);
                }
                List<int> fileStringAdress = new List<int>();



                int position = 12;

                position = position + WindowsLength + terminationBytes.Length;   //upto to termination byte
                for (int l = 0; l < WindowsCount; l++)
                {
                    fileStringAdress.Add(position);
                    int filelength = byteArrayfilenames[l].Length;


                    position = position + filelength;

                }
                int k = 0;
                foreach (byte[] window in byteArrayWindows)
                {
                    bytePlaylistpacket.Add(window);

                    byte[] filestartadress = GetTwoBytesFromInt(fileStringAdress[k]);
                    bytePlaylistpacket.Add(filestartadress);
                    k++;
                }


                bytePlaylistpacket.Add(terminationBytes);//adding termination bytes

                foreach (byte[] filebytes in byteArrayfilenames)
                {
                    bytePlaylistpacket.Add(filebytes);


                }

                // Convert the list to a single byte array
                byte[] resultBytes = ByteFormation.ConvertListToBytes(bytePlaylistpacket);







                Array.Resize(ref sendbyte, sendbyte.Length + resultBytes.Length + 4);


                Array.Copy(resultBytes, 0, sendbyte, 12, resultBytes.Length);



                sendbyte[sendbyte.Length - 4] = 3;
                sendbyte[sendbyte.Length - 3] = 0;
                sendbyte[sendbyte.Length - 2] = 0;
                sendbyte[sendbyte.Length - 1] = 4;

                int packetLength = sendbyte.Length - 6;
                byte[] packetLengthBytes = GetTwoBytesFromInt(packetLength);
                sendbyte[3] = packetLengthBytes[0];
                sendbyte[4] = packetLengthBytes[1];

                Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);
                finalPacket[finalPacket.Length - 9] = value[0];   //crc msb
                finalPacket[finalPacket.Length - 8] = value[1];    //crc lsb


                return finalPacket;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return null;
        }
        public static byte[] GetTwoBytesFromInt(int input)
        {
            // Ensure the input is within the range that can be represented by two bytes
            if (input < 0 || input > 65535)
            {
                throw new ArgumentOutOfRangeException(nameof(input), "Input must be between 0 and 65535.");
            }

            // Create a byte array to hold the result
            byte[] resultBytes = new byte[2];

            // Store the higher byte in the first position
            resultBytes[0] = (byte)((input >> 8) & 0xFF);

            // Store the lower byte in the second position
            resultBytes[1] = (byte)(input & 0xFF);

            return resultBytes;
        }
        private static byte[] GetFileNames(MediaFile mediaFiles)
        {
            string fileName = mediaFiles.FileName;
            byte[] englishTextBytes = Encoding.UTF8.GetBytes(fileName); ;

            byte separator = 80;

            byte[] resultBytes = new byte[englishTextBytes.Length + 1];

            // Copy the initial bytes to the new array
            Array.Copy(englishTextBytes, resultBytes, englishTextBytes.Length);

            // Add the separator byte to the new array
            resultBytes[englishTextBytes.Length] = separator;

            return resultBytes;
        }


        private static byte[] WindowFormation(MediaFile mediaFiles, string speed,
        string volumn, string messageFontSize, string messageCharacterGap, string messageTopBottom, string messageLine, int startHour, int startMinute, int endHour, int endMinute, int RepeatCount)
        {

            try
            {


                string FileName = mediaFiles.FileName;
                int ImageTime = mediaFiles.ImageTime;
                string DisplayEffect = mediaFiles.DisplayEffect;
                string ClearingEffect = mediaFiles.ClearingEffect;
                string FilePath = mediaFiles.FilePath;
                int MediaType = mediaFiles.MediaType;

                byte byte1 = GetspeedRepeatCountByte(speed, RepeatCount);
                byte byte2 = GetByte2(MediaType, volumn, DisplayEffect);
                byte byte3 = GetByte3(messageFontSize, messageCharacterGap, messageTopBottom, messageLine);
                byte byte4 = (byte)startHour;
                byte byte5 = (byte)startMinute;
                byte byte6 = (byte)endHour;
                byte byte7 = (byte)endMinute;
                byte byte8 = (byte)ImageTime;

                Byte[] sendbyte = new Byte[8];
                sendbyte[0] = byte1;
                sendbyte[1] = byte2;
                sendbyte[2] = byte3;
                sendbyte[3] = byte4;
                sendbyte[4] = byte5;
                sendbyte[5] = byte6;
                sendbyte[6] = byte7;
                sendbyte[7] = byte8;



                return sendbyte;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return null;
        }

        public static byte GetspeedRepeatCountByte(string Speed, int RepeatCount)
        {
            string originalBinary = "00000000";



            int speed = Convert.ToInt32(Speed);
            string speedBinary = ByteFormation.convertDecimalToBinary(speed);


            int positionSpeed = 0;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, speedBinary, positionSpeed);



            string RepeatCountBinary = ByteFormation.convertDecimalToBinary(RepeatCount);

            int positionGaprepeatcount = 3;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, RepeatCountBinary, positionGaprepeatcount);


            // Convert the final binary string to a byte
            byte resultByte = Convert.ToByte(originalBinary, 2);

            return resultByte;
        }
        public static byte GetByte2(int MediaType, string volumn, string DisplayEffect)
        {
            int entryeffect = Convert.ToInt32(GetmediaEntryEffectCode(DisplayEffect));

            string originalBinary = "00000000";




            int effect = Convert.ToInt32(entryeffect);
            string effectBinary = ByteFormation.convertDecimalToBinary(effect);


            int positionGap = 0;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, effectBinary, positionGap);


            int volume = Convert.ToInt32(volumn);
            string volumeBinary = ByteFormation.convertDecimalToBinary(volume);


            int positionGapvolume = 3;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, volumeBinary, positionGapvolume);

            string MediaTypeBinary = ByteFormation.convertDecimalToBinary2VALUES(MediaType);


            int positionMediaTypeBinary = 6;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, MediaTypeBinary, positionMediaTypeBinary);


            // Convert the final binary string to a byte
            byte resultByte = Convert.ToByte(originalBinary, 2);

            return resultByte;
        }

        public static byte GetByte3(string messageFontSize, string messageCharacterGap, string messageTopBottom, string messageLine)
        {


            string originalBinary = "00000000";



            int CharacterGap = Convert.ToInt32(messageCharacterGap);
            string CharacterGapBinary = ByteFormation.convertDecimalToBinary(CharacterGap);


            int positionGap = 0;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, CharacterGapBinary, positionGap);


            int fontsize = Convert.ToInt32(messageFontSize);
            string fontsizeBinary = ByteFormation.convertDecimalToBinary(fontsize);


            int positionfontsize = 3;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, fontsizeBinary, positionfontsize);



            int topBottom = Convert.ToInt32(messageTopBottom);
            string topBottomBinary = ByteFormation.convertDecimalToBinary1Value(topBottom);


            int positiontopBottom = 6;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, topBottomBinary, positiontopBottom);

            int mesgEnable = Convert.ToInt32(messageLine);
            string mesgEnableBinary = ByteFormation.convertDecimalToBinary1Value(mesgEnable);


            int positionmesgEnable = 7;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, mesgEnableBinary, positionmesgEnable);

            // Convert the final binary string to a byte
            byte resultByte = Convert.ToByte(originalBinary, 2);

            return resultByte;
        }


        public static byte GetNineByte(string videotype, string letterSpeed)
        {
            string originalBinary = "00000000";


            int VType = Convert.ToInt32(videotype);
            originalBinary = "00000000";

            int speed = Convert.ToInt32(letterSpeed);
            string speedBinary = ByteFormation.convertDecimalToBinary(speed);


            int positionSpeed = 0;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, speedBinary, positionSpeed);


            byte resultByte = Convert.ToByte(originalBinary, 2);

            return resultByte;
        }
        private static void SetForDisplay(List<MediaFile> mediaFiles, string BoardIP)
        {
            try
            {
                string filename = "";
                string path;
                int listLen = mediaFiles.Count;

                for (int i = 0; i < listLen; i++)
                {
                    try
                    {
                        filename = mediaFiles[i].FileName;
                        path = mediaFiles[i].FilePath;
                        int mediaType = mediaFiles[i].MediaType;

                        if (mediaType == 1)
                        {
                            uploadImageVideoFTP("FTP://" + BoardIP + "/VDC_Videos", path);
                        }
                        else
                        {
                            //var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                            //var copyToPath = Path.Combine(baseDirectory, "images");

                            //// Ensure the directory exists
                            //if (!Directory.Exists(copyToPath))
                            //{
                            //    Directory.CreateDirectory(copyToPath);
                            //}

                            //string imgPath = System.IO.Path.Combine(copyToPath, filename);
                            uploadImageVideoFTP("FTP://" + BoardIP + "/VDC_Images", path);
                        }
                    }
                    catch (Exception ex)
                    {
                        Server.LogError(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static void uploadImageVideoFTP(string ftpUrl, string source)
        {
            FtpWebRequest reqFTP = null;

            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpUrl + "/" + Path.GetFileName(source)));

                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                reqFTP.KeepAlive = false;
                reqFTP.UseBinary = true;

                FileInfo fileInf = new FileInfo(source);
                reqFTP.ContentLength = fileInf.Length;

                const int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;

                using (FileStream fs = fileInf.OpenRead())
                {
                    using (Stream strm = reqFTP.GetRequestStream())
                    {
                        contentLen = fs.Read(buff, 0, buffLength);

                        while (contentLen != 0)
                        {
                            strm.Write(buff, 0, contentLen);
                            contentLen = fs.Read(buff, 0, buffLength);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {


                string UserName = BaseClass.UserName;
                string BoardName = cmbBoardName.Text;
                string BoardId = txtBoardIP.Text;
                string MsgTxt = txtSpecialMessage.Text;
                string Contme = txtTime.Text;
                string FntSze = cmbfontsize.Text;
                string Color = btnSelectColor.Text;
                string Effect = "Stay";

                SendMessage(MsgTxt, Contme, FntSze, Color, Effect, BoardId);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static void createftpMsgfile(string textContent, string ftpUrl)
        {
            try
            {


                string testpath = ftpUrl;
                string fullpath = "FTP://" + ftpUrl + "/SplMessage/Message.txt";
                // Get the object used to communicate with the server.
                //FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(path + "Config.xml");
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fullpath);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                //request.Credentials = new NetworkCredential(userName, password);

                // convert contents to byte.
                byte[] fileContents = Encoding.Unicode.GetBytes(textContent); ;

                request.ContentLength = fileContents.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                    requestStream.Close();
                    requestStream.Dispose();

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }



        }
        public static void SendMessage(string MsgTxt, string Contme, string FntSze, string Color, string Effect, string BoardIP)
        {
            try
            {
                string MsgInfo = MsgTxt + "~" + Contme + "~" + FntSze + "~" + Color + "~" + Effect;

                if (Server._connectedClients.TryGetValue(BoardIP, out TcpClient client))
                {


                    createftpMsgfile(MsgInfo, BoardIP);
                    //BusinessLogicLayer.SavePlayList(BoardName, PlayListName, RepeatCount, CntnRepeat);
                    // createftpMsgfile(MsgInfo, "192.168.1.166", "Dell", "areca@123");
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }



        public void CreateColorDialogBox(Button btn)
        {
            try
            {


                ColorDialog cd = new ColorDialog();
                cd.AllowFullOpen = true;
                btn.BackColor = cd.Color;
                cd.FullOpen = true;
                cd.AnyColor = true;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    btn.BackColor = cd.Color;
                    string hexColorhex = ColorTranslator.ToHtml(Color.FromArgb(cd.Color.ToArgb()));
                    btn.Text = hexColorhex;

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnSelectColor);
        }

        private void txtRepeatCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a number or a control key (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the key is not a digit or a control key, suppress the event
                e.Handled = true;
            }
        }

        private void txtUStarthour_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtUStarthour.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 23)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtUStartminute_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtUStartminute.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 59)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtuEndhour_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtuEndhour.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 23)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtuEndMinute_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtuEndMinute.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 59)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtuRepeatCount_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtuRepeatCount.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 99)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtOVDstarttime_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtOVDstarttime.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 23)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtstartminOVD_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtstartminOVD.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 59)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtOVDendhour_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtOVDendhour.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 23)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void txtOVDendmin_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and also not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then handle the event, which means the character won't be inputted
                e.Handled = true;
            }
            else
            {
                // Check the current value and new input if it's a digit (ignore for control keys like backspace)
                if (char.IsDigit(e.KeyChar))
                {
                    // Combine existing text and the new character to see what the result would be
                    string newText = txtOVDendmin.Text + e.KeyChar;

                    // Check if the resulting number exceeds 59
                    if (int.TryParse(newText, out int result) && result > 59)
                    {
                        e.Handled = true; // Cancel the input if the result is greater than 59
                    }
                }
            }
        }

        private void btnClearPlaylist_Click(object sender, EventArgs e)
        {
            string BoardIp = txtBoardIP.Text.Trim();
            clearNormalModePlaylist(BoardIp);
        }
        public static void clearNormalModePlaylist(string BoardIp)
        {
            try
            {
                int packet = GetPacketIdentifier(BoardIp);
                byte[] clearPacket = frmPlaylist.clearMediaPacket(BoardIp, packet);
                // byte[] trimmedDataTransferPacket = ByteFormation.RemoveFirstAndLast6(clearPacket);
                Server.SendMessageToClient(BoardIp, clearPacket);



            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }

        }

        public static int GetPacketIdentifier(string BoardIp)
        {
            try
            {


                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                    {

                        if (row["IPAddress"].ToString() == BoardIp)
                        {

                            if (int.TryParse(row["PacketIdentifier"].ToString(), out int packet))
                            {
                                return packet;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            throw new Exception("PacketIdentifier not found for the provided BoardIp.");
        }

        public static byte[] clearMediaPacket(string boardIp, int packet)
        {
            try
            {


                Byte[] sendbyte = ByteFormation.CommonBytes(boardIp, packet);
                if (sendbyte == null)
                {
                    return null;
                }
                Array.Resize(ref sendbyte, sendbyte.Length + 4);
                sendbyte[10] = 140;   //packet Type

                sendbyte[13] = 4;  //end of data
                int packetLength = sendbyte.Length - 6;
                byte[] packetLengthBytes = GetTwoBytesFromInt(packetLength);
                sendbyte[3] = packetLengthBytes[0];
                sendbyte[4] = packetLengthBytes[1];
                Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
                Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
                Byte[] value = Server.CheckSum(finalPacket);
                finalPacket[17] = value[0];   //crc msb
                finalPacket[18] = value[1];    //crc lsb



                return finalPacket;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
            return null;
        }

        private void toolStripContainer3_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {


        }

        private void rbScheduler_Click(object sender, EventArgs e)
        {
            pnlPreview.Visible = false;
            pnlPreview.SendToBack();
            pnlScheduler.Visible = true;
            pnlScheduler.BringToFront();
            SetSchedulerBoards();

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {


                // Ensure the selected date is in the future
                if (dtpDate.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("Please select a future date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Reset the value to today
                    dtpDate.Value = DateTime.Now.Date;
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }

        }
        private void rbtnClose_Click(object sender, EventArgs e)
        {
            pnlScheduler.Visible = false;

            pnlScheduler.SendToBack();
            pnlPreview.BringToFront();
            pnlPreview.Visible = true;
        }

        private void rbGet_Click(object sender, EventArgs e)
        {
            Filldatagrid();
        }

        public void Filldatagrid()
        {
            try
            {


                string SelectedUserName = BaseClass.UserName;

                string BoardId = cmbSBoardips.Text.Trim();
                DateTime date = dtpScheduler.Value.Date;
                dgvScheduler.Rows.Clear();
                foreach (DataRow row in BaseClass.MediaPlayListwithusername.Rows)
                {
                    if (BaseClass.MediaPlayListwithusername.Columns.Contains("Username") &&
                        BaseClass.MediaPlayListwithusername.Columns.Contains("PlayListname") &&
                        BaseClass.MediaPlayListwithusername.Columns.Contains("Boardid") &&
                        BaseClass.MediaPlayListwithusername.Columns.Contains("StartHour") &&
                        BaseClass.MediaPlayListwithusername.Columns.Contains("StartMinute") &&
                        BaseClass.MediaPlayListwithusername.Columns.Contains("EndHour") &&
                        BaseClass.MediaPlayListwithusername.Columns.Contains("EndMinute") &&
                        BaseClass.MediaPlayListwithusername.Columns.Contains("Date"))
                    {
                        // Extract playlist details
                        string username = row["Username"].ToString().Trim();
                        string playlistName = row["PlayListname"].ToString().Trim();
                        string boardip = row["Boardid"].ToString().Trim();
                        string startHour = row["StartHour"].ToString().Trim();
                        string startMinute = row["StartMinute"].ToString().Trim();
                        string endHour = row["EndHour"].ToString().Trim();
                        string endMinute = row["EndMinute"].ToString().Trim();
                        string repeatCount = row["RepeatCount"].ToString().Trim();
                        DateTime edate = DateTime.Parse(row["Date"].ToString().Trim());

                        if (BoardId == "All")
                        {

                            DataGridViewRow dgvRow = new DataGridViewRow();
                            dgvRow.CreateCells(dgvScheduler);

                            // Populate the cells
                            dgvRow.Cells[dgvScheduler.Columns["dgvBoardid"].Index].Value = boardip;
                            dgvRow.Cells[dgvScheduler.Columns["dgvUsername"].Index].Value = username;
                            dgvRow.Cells[dgvScheduler.Columns["dgvPlayListname"].Index].Value = playlistName;
                            dgvRow.Cells[dgvScheduler.Columns["dgvRepeatCount"].Index].Value = repeatCount;
                            dgvRow.Cells[dgvScheduler.Columns["dgvStartHour"].Index].Value = startHour;
                            dgvRow.Cells[dgvScheduler.Columns["dgvStartMinute"].Index].Value = startMinute;
                            dgvRow.Cells[dgvScheduler.Columns["dgvEndHour"].Index].Value = endHour;
                            dgvRow.Cells[dgvScheduler.Columns["dgvEndMinute"].Index].Value = endMinute;
                            dgvRow.Cells[dgvScheduler.Columns["dgvDate"].Index].Value = edate.ToShortDateString();

                            // Add the row to the DataGridView
                            dgvScheduler.Rows.Add(dgvRow);
                        }
                        else
                        {

                            if ((edate.Date == date.Date && boardip == BoardId && username == SelectedUserName))
                            {
                                DataGridViewRow dgvRow = new DataGridViewRow();
                                dgvRow.CreateCells(dgvScheduler);

                                // Populate the cells
                                dgvRow.Cells[dgvScheduler.Columns["dgvBoardid"].Index].Value = boardip;
                                dgvRow.Cells[dgvScheduler.Columns["dgvUsername"].Index].Value = username;
                                dgvRow.Cells[dgvScheduler.Columns["dgvPlayListname"].Index].Value = playlistName;
                                dgvRow.Cells[dgvScheduler.Columns["dgvRepeatCount"].Index].Value = repeatCount;
                                dgvRow.Cells[dgvScheduler.Columns["dgvStartHour"].Index].Value = startHour;
                                dgvRow.Cells[dgvScheduler.Columns["dgvStartMinute"].Index].Value = startMinute;
                                dgvRow.Cells[dgvScheduler.Columns["dgvEndHour"].Index].Value = endHour;
                                dgvRow.Cells[dgvScheduler.Columns["dgvEndMinute"].Index].Value = endMinute;
                                dgvRow.Cells[dgvScheduler.Columns["dgvDate"].Index].Value = edate.ToShortDateString();

                                // Add the row to the DataGridView
                                dgvScheduler.Rows.Add(dgvRow);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }

        }

        private void dgvScheduler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void roundPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvScheduler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a valid column and row are clicked
            if (e.RowIndex >= 0 && dgvScheduler.Columns[e.ColumnIndex].Name == "dgvDelete")
            {
                // Get the clicked row
                DataGridViewRow row = dgvScheduler.Rows[e.RowIndex];

                // Show a confirmation dialog
                DialogResult dialogResult = MessageBox.Show("Do you want to Delete PlayList?", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        // Extract the necessary values from the clicked row
                        string username = row.Cells["dgvUsername"].Value?.ToString();
                        string playlistName = row.Cells["dgvPlayListname"].Value?.ToString();
                        string boardip = row.Cells["dgvBoardid"].Value?.ToString();
                        DateTime date = DateTime.Parse(row.Cells["dgvDate"].Value?.ToString());

                        // Call the database method to delete the playlist
                        int rowsAffected = MediaDb.DeletePlaylist(username, boardip, playlistName, date);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Playlist deleted successfully.", "Success", MessageBoxButtons.OK);

                            // Clear and refresh the grid view and related data
                            Filldatagrid();
                            ClearListBox(lsdAddFile);
                            MediaDatabyUsername = MediaDb.GetPlayListbyUser(BaseClass.UserName, boardip);
                            SetPlaylistNameforBoards();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the playlist. Please try again.", "Error", MessageBoxButtons.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        Server.LogError(ex.ToString());
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    // User clicked 'No', handle accordingly if needed
                }
            }
        }
    }
}
