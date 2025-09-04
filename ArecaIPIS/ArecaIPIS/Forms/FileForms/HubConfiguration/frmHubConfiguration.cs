
using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArecaIPIS
{
    public partial class frmHubConfiguration : Form
    {
        // List to keep track of dynamically created buttons
        private List<Button> BoardButtons = new List<Button>();
        private List<Button> pdcBoardButtons = new List<Button>();

        private List<Button> buttonportslist = new List<Button>();
        private List<Button> imageButtonslist = new List<Button>();

        private string[] BoardLabels = { "PDC", "MLDB", "PFDB", "AGDB", "OVD", "IVD", "CCTV", "DELETE" };
        private string[] PdcBoardLabels = { "MLDB", "PFDB", "AGDB", "IVD", "CGDB", "DELETE" };
        Boolean PanelButtons = false;

        public frmHubConfiguration()
        {
            InitializeComponent();
            panHubConfiguration.Dock = DockStyle.Fill;
            panHubConfiguration.AutoScroll = true;
            panHubConfiguration.MouseClick += Panel_Click;
        }
        private frmIndex parentForm;
        public frmHubConfiguration(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }



        private void btnEthernetports_Click(object sender, EventArgs e)
        {
            if (PanelButtons)
            {
                ClearPanel();
                PanelButtons = false;
            }
            else
            {
                PanelButtons = true;
                CreatePorts();
                SetPorts();
                CreateADDImageButton();

            }



        }
        public void ClearPanel()
        {
            ClearEthernetPorts();
            ClearBoardButtons();

            ClearPdcBoardButtons();
            panPdcPorts.Visible = false;
        }


        private void SetPorts()
        {
            // DataTable ethernetports = HubConfigurationDb.GetEthernetPorts();
            try
            {
                // Loop through each button in the list of BoardButtons
                foreach (Button button in buttonportslist)
                {
                    String buttonName = button.Name;
                    int portnumber = ExtractNumericPart(buttonName);

                    foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                    {
                        if (BaseClass.EthernetPorts.Columns.Contains("PortNo") && int.TryParse(row["PortNo"].ToString(), out int port))
                        {
                            if (portnumber == port)
                            {
                                button.Text = row["Location"].ToString();
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


        private void CreatePorts()
        {
            // Assuming you have a panel named `panelHubConfiguration` to add the buttons to

            try
            {


                for (int i = 1; i <= 35; i++)
                {
                    // Create a new button
                    Button portButton = new Button
                    {
                        Size = new Size(120, 25),
                        Location = new Point(30, 5 + (i - 1) * 30),
                        TextAlign = ContentAlignment.MiddleCenter,
                        ImageAlign = ContentAlignment.MiddleLeft,
                        Text = "PORT " + i,
                        BackColor = Color.LightYellow,
                        ForeColor = Color.Red,
                        Font = new Font("Arial", 10),
                        Name = "PORT" + i
                    };

                    // Add MouseDown event handler

                    portButton.MouseClick += PortButton_MouseClick;
                    portButton.MouseDown += PortButton_MouseDown;
                    portButton.Click += PortButton_Click;
                    // Add the button to the panel
                    panHubConfiguration.Controls.Add(portButton);
                    buttonportslist.Add(portButton);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void PortButton_Click(object sender, EventArgs e)
        {
            try
            {


                Button clickedButton = sender as Button;
                portClickEvent(clickedButton);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void portClickEvent(Button clickedButton)
        {
            try
            {


                clickedButton.BackColor = Color.GreenYellow;
                ChangebackgroundColorPort(clickedButton);
                if (panPdcPorts.Visible == true)
                {

                    panPdcPorts.Visible = false;
                }


                string buttonName = clickedButton.Name;
                int portnumber = ExtractNumericPart(buttonName);

                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("PortNo") && int.TryParse(row["PortNo"].ToString(), out int port))
                    {
                        if (portnumber == port)
                        {
                            if (int.TryParse(row["PacketIdentifier"].ToString(), out int packetIdentifier))
                            {
                                string BoardType = GetPacketname(packetIdentifier).Trim();

                                if (int.TryParse(row["PkeyMasterhub"].ToString(), out int HubPk))
                                {
                                    OpenSelectedBoard(BoardType, HubPk);
                                }


                            }
                        }
                    }
                }
                ChangebackgroundColorImagePorts();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public string GetPacketname(int packetIdentifier)
        {
            foreach (DataRow row in BaseClass.PacketIdentifier.Rows)
            {
                if (BaseClass.PacketIdentifier.Columns.Contains("pk") && int.TryParse(row["pk"].ToString(), out int packetno))
                {
                    if (packetno == packetIdentifier)
                    {
                        return row["Packet_name"].ToString();
                    }
                }
            }
            return null;
        }


        // Event handler for MouseDown event
        private void PortButton_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                Button clickedButton = sender as Button;
                clickedButton.BackColor = Color.GreenYellow;
                ChangebackgroundColorPort(clickedButton);
                if (e.Button == MouseButtons.Right)
                {
                    ClearBoardButtons();
                    ClearPdcBoardButtons();
                    ShowBoards(clickedButton);
                    if (panPdcPorts.Visible == true)
                    {
                        ClearDynamicButtons();
                        panPdcPorts.Visible = false;
                    }

                }
                else if (e.Button == MouseButtons.Left)
                {

                    portClickEvent(clickedButton);

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }
        private void PortButton_MouseClick(object sender, MouseEventArgs e)
        {

            ClearBoardButtons();
            ClearPdcBoardButtons();
        }

        private void ChangebackgroundColorPort(Button button)
        {
            foreach (var btn in buttonportslist)
            {
                if (btn.Name != button.Name)
                {
                    btn.BackColor = Color.LightYellow; // Set the color to whatever you prefer
                }
                else
                {
                    btn.BackColor = Color.GreenYellow;
                }
            }
        }

        private void ChangebackgroundColorimage(Button button)
        {
            foreach (var btn in imageButtonslist)
            {
                if (btn.Name != button.Name)
                {
                    btn.BackColor = Color.LightYellow; // Set the color to whatever you prefer
                }
                else
                {
                    btn.BackColor = Color.GreenYellow;
                }
            }
        }
        private void ClearDynamicButtons()
        {
            //    foreach (Button button in dynamicButtons)
            //    {
            //        panHubConfiguration.Controls.Remove(button);
            //        button.Dispose();
            //    }
            //    dynamicButtons.Clear();

        }
        private void ClearBoardButtons()
        {

            foreach (Button button in BoardButtons)
            {
                panHubConfiguration.Controls.Remove(button);
                button.Dispose();
            }
            BoardButtons.Clear();
        }
        private void ClearEthernetPorts()
        {

            foreach (Button button in imageButtonslist)
            {
                panHubConfiguration.Controls.Remove(button);
                button.Dispose();
            }
            imageButtonslist.Clear();

            foreach (Button button in buttonportslist)
            {
                panHubConfiguration.Controls.Remove(button);
                button.Dispose();
            }
            buttonportslist.Clear();

        }
        private void ClearPdcBoardButtons()
        {

            foreach (Button button in pdcBoardButtons)
            {
                panHubConfiguration.Controls.Remove(button);
                button.Dispose();
            }
            pdcBoardButtons.Clear();
        }

        private void ClearimageButton(Button button)
        {
            // Loop through each control in the panel's controls collection
            foreach (Control control in panHubConfiguration.Controls)
            {
                // Check if the control is a Button and its name contains the name of the provided button concatenated with "image"
                if (control is Button imageButton && imageButton.Name.Contains(button.Name + "image"))
                {
                    // Remove the button from the panel
                    panHubConfiguration.Controls.Remove(imageButton);

                    // Dispose of the button
                    imageButton.Dispose();

                    // Exit the loop after deleting the first matching button
                    break;
                }
            }
        }






        private void Panel_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
        }



        private void ShowBoards(Button buttonPort)
        {


            for (int i = 0; i < BoardLabels.Length; i++)
            {
                Button btnBoards = new Button();
                btnBoards.Size = new Size(80, 30);
                btnBoards.Location = new Point(buttonPort.Location.X + buttonPort.Width, buttonPort.Location.Y + i * 30);
                btnBoards.Text = BoardLabels[i];
                btnBoards.BackColor = Color.Blue;
                btnBoards.ForeColor = Color.White;
                btnBoards.Font = new Font("Arial", 8);
                BoardButtons.Add(btnBoards);
                // btnBoards.MouseClick += btnBoards_MouseClick;
                btnBoards.MouseClick += (sender, e) => btnBoards_MouseClick(sender, e, buttonPort);
                panHubConfiguration.Controls.Add(btnBoards);
            }
        }

        private void OpenForm(Form form)
        {
            form.ShowDialog();
        }
        private void btnBoards_MouseClick(object sender, MouseEventArgs e, Button btnPort)
        {
            try
            {


                Button clickedButton = sender as Button;
                String name = btnPort.Name;
                if (clickedButton != null)
                {
                    string buttonText = clickedButton.Text;
                    //clickedButton.BackColor = Color.Yellow;

                    switch (buttonText)
                    {
                        case "PDC":
                            panelshowwindowsall.Controls.Clear();
                            frmPdcConfiguration pdcForm = new frmPdcConfiguration();
                            pdcForm.TopLevel = false;
                            pdcForm.FormBorderStyle = FormBorderStyle.None;
                            pdcForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(pdcForm);
                            pdcForm.Show();
                            pdcForm.SetPassedValue(btnPort);
                            btnPort.Text = buttonText;

                            ClearBoardButtons();
                            //  CreateAddButton(btnPort);
                            break;

                        case "MLDB":
                            panelshowwindowsall.Controls.Clear();
                            frmMLDB mldbForm = new frmMLDB();
                            mldbForm.TopLevel = false;
                            mldbForm.FormBorderStyle = FormBorderStyle.None;
                            mldbForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(mldbForm);
                            mldbForm.SetPassedValue(btnPort);
                            mldbForm.Show();
                            btnPort.Text = buttonText;
                            ClearBoardButtons();
                            //ClearimageButton(btnPort);
                            break;

                        case "PFDB":

                            panelshowwindowsall.Controls.Clear();
                            frmPFD pfdForm = new frmPFD();
                            pfdForm.TopLevel = false;
                            pfdForm.FormBorderStyle = FormBorderStyle.None;
                            pfdForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(pfdForm);
                            pfdForm.SetPassedValue(btnPort);
                            pfdForm.Show();
                            btnPort.Text = buttonText;
                            ClearBoardButtons();
                            break;

                        case "AGDB":
                            panelshowwindowsall.Controls.Clear();
                            frmAGDB agdbForm = new frmAGDB();
                            agdbForm.TopLevel = false;
                            agdbForm.FormBorderStyle = FormBorderStyle.None;
                            agdbForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(agdbForm);
                            agdbForm.SetPassedValue(btnPort);
                            agdbForm.Show();
                            btnPort.Text = buttonText;
                            ClearBoardButtons();
                            break;

                        case "OVD":
                            panelshowwindowsall.Controls.Clear();
                            frmOVD ovdForm = new frmOVD();
                            ovdForm.TopLevel = false;
                            ovdForm.FormBorderStyle = FormBorderStyle.None;
                            ovdForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(ovdForm);
                            ovdForm.SetPassedValue(btnPort);
                            ovdForm.Show();
                            btnPort.Text = buttonText;
                            ClearBoardButtons();
                            break;

                        case "IVD":
                            panelshowwindowsall.Controls.Clear();
                            frmIVD ivdForm = new frmIVD();
                            ivdForm.TopLevel = false;
                            ivdForm.FormBorderStyle = FormBorderStyle.None;
                            ivdForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(ivdForm);
                            ivdForm.SetPassedValue(btnPort);
                            ivdForm.Show();
                            btnPort.Text = buttonText;
                            ClearBoardButtons();
                            break;

                        case "CCTV":
                            panelshowwindowsall.Controls.Clear();
                            frmCCTV cctvForm = new frmCCTV();
                            cctvForm.TopLevel = false;
                            cctvForm.FormBorderStyle = FormBorderStyle.None;
                            cctvForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(cctvForm);
                            cctvForm.SetPassedValue(btnPort);
                            cctvForm.Show();
                            btnPort.Text = buttonText;
                            ClearBoardButtons();
                            break;
                        case "DELETE":
                            panelshowwindowsall.Controls.Clear();
                            DeletePort(btnPort);
                            break;


                        default:

                            break;
                    }


                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        private void DeletePort(Button btnPort)
        {
            try
            {


                // Extract the name of the button
                string name = btnPort.Name;


                // Extract the numeric part from the name
                int portNumber = ExtractNumericPart(name);

                // Iterate through the rows in the EthernetPorts DataTable
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    // Check if the "PortNo" column exists and the port number matches
                    if (BaseClass.EthernetPorts.Columns.Contains("PortNo") &&
                        int.TryParse(row["PortNo"].ToString(), out int port) &&
                        portNumber == port)
                    {
                        int pk = Convert.ToInt32(row["PkeyMasterhub"].ToString());
                        string Ip = (row["IPAddress"].ToString());


                        int rowseffected = HubConfigurationDb.DeletePort(port, pk);
                        if (rowseffected >= 0)
                        {
                            ReportDb.InsertDatabaseModificationReportData("Board Deleted With the Ip " + Ip, "4");
                            ClearPanel();
                            BaseClass.RecallBoards();
                        }
                        break; // Exit the loop after deleting the matching row

                    }
                }

                // Accept changes to finalize row deletion
                BaseClass.EthernetPorts.AcceptChanges();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void DeletePDCPort(Button btnpdcPort, int MainPort)
        {
            try
            {
                // Extract the name of the button
                string name = btnpdcPort.Name;

                // Extract the numeric part from the name
                int PdcportNumber = ExtractNumericPart(name);

                // Iterate through the rows in the EthernetPorts DataTable
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    // Check if all necessary columns exist and parse them
                    if (BaseClass.EthernetPorts.Columns.Contains("EthernetPort") &&
                        BaseClass.EthernetPorts.Columns.Contains("PdcPortNo") &&
                        BaseClass.EthernetPorts.Columns.Contains("PkeyMasterhub"))
                    {
                        if (int.TryParse(row["EthernetPort"].ToString(), out int port) &&
                            MainPort == port &&
                            int.TryParse(row["PdcPortNo"].ToString(), out int pdcport) &&
                            pdcport == PdcportNumber &&
                            int.TryParse(row["PkeyMasterhub"].ToString(), out int pkKey))
                        {
                            string Ip = (row["IPAddress"].ToString());
                            // Delete the port from the database
                            int rowsAffected = HubConfigurationDb.DeletePdcPort(pkKey, pdcport, MainPort);
                            if (rowsAffected >= 0)
                            {
                                ReportDb.InsertDatabaseModificationReportData("Board Deleted With the Ip " + Ip, "4");
                                ClearPanel();
                                BaseClass.RecallBoards();
                            }

                            // Exit the loop after deleting the matching row
                            break;
                        }
                    }
                }
                // Iterate through the rows in the EthernetPorts DataTable
                foreach (DataRow row in BaseClass.CgdbPorts.Rows)
                {
                    // Check if all necessary columns exist and parse them
                    if (BaseClass.CgdbPorts.Columns.Contains("MainEthernetPortNo") &&
                        BaseClass.CgdbPorts.Columns.Contains("pdcPortNo") &&
                        BaseClass.CgdbPorts.Columns.Contains("Fkey_CDCID"))
                    {
                        if (int.TryParse(row["MainEthernetPortNo"].ToString(), out int port) &&
                            MainPort == port &&
                            int.TryParse(row["pdcPortNo"].ToString(), out int pdcport) &&
                            pdcport == PdcportNumber &&
                            int.TryParse(row["Fkey_CDCID"].ToString(), out int fkKey))
                        {
                            // Delete the port from the database
                            int rowsAffected = HubConfigurationDb.DeletePdcPort(fkKey, pdcport, MainPort);
                            if (rowsAffected >= 0)
                            {
                                ReportDb.InsertDatabaseModificationReportData("cgdb Boards Deleted", "4");
                                ClearPanel();
                                BaseClass.RecallBoards();
                            }

                            // Exit the loop after deleting the matching row
                            break;
                        }
                    }
                }

                // Accept changes to finalize row deletion
                BaseClass.EthernetPorts.AcceptChanges();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        private void pdcbtnBoards_MouseClick(object sender, MouseEventArgs e, Button btnPort, int MainPort)
        {
            try
            {


                panelshowwindowsall.Controls.Clear();
                Button clickedButton = sender as Button;
                String name = btnPort.Name;
                if (clickedButton != null)
                {
                    string buttonText = clickedButton.Text;
                    //clickedButton.BackColor = Color.Yellow;

                    switch (buttonText)
                    {

                        case "MLDB":
                            panelshowwindowsall.Controls.Clear();
                            frmMLDB mldbForm = new frmMLDB();
                            mldbForm.TopLevel = false;
                            mldbForm.FormBorderStyle = FormBorderStyle.None;
                            mldbForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(mldbForm);
                            mldbForm.SetPassedValue(btnPort, MainPort);
                            mldbForm.Show();
                            btnPort.Text = buttonText;
                            ClearBoardButtons();
                            ClearPdcBoardButtons();
                            // ClearimageButton(btnPort);
                            break;

                        case "PFDB":
                            panelshowwindowsall.Controls.Clear();
                            frmPFD pfdForm = new frmPFD();
                            pfdForm.TopLevel = false;
                            pfdForm.FormBorderStyle = FormBorderStyle.None;
                            pfdForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(pfdForm);
                            pfdForm.SetPassedValue(btnPort, MainPort);
                            pfdForm.Show();
                            btnPort.Text = buttonText;
                            ClearBoardButtons();
                            ClearPdcBoardButtons();
                            break;

                        case "AGDB":
                            panelshowwindowsall.Controls.Clear();
                            frmAGDB agdbForm = new frmAGDB();
                            agdbForm.TopLevel = false;
                            agdbForm.FormBorderStyle = FormBorderStyle.None;
                            agdbForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(agdbForm);
                            agdbForm.SetPassedValue(btnPort, MainPort);
                            agdbForm.Show();
                            btnPort.Text = buttonText;
                            ClearBoardButtons();
                            ClearPdcBoardButtons();
                            ClearimageButton(btnPort);
                            break;

                        case "IVD":
                            panelshowwindowsall.Controls.Clear();
                            frmIVD ivdForm = new frmIVD();
                            ivdForm.TopLevel = false;
                            ivdForm.FormBorderStyle = FormBorderStyle.None;
                            ivdForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(ivdForm);
                            ivdForm.SetPassedValue(btnPort, MainPort); ;
                            ivdForm.Show();
                            btnPort.Text = buttonText;
                            ClearBoardButtons();
                            ClearPdcBoardButtons();
                            ClearimageButton(btnPort);
                            break;

                        case "OVD":
                            panelshowwindowsall.Controls.Clear();
                            frmOVD ovdForm = new frmOVD();
                            ovdForm.TopLevel = false;
                            ovdForm.FormBorderStyle = FormBorderStyle.None;
                            ovdForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(ovdForm);
                            ovdForm.SetPassedValue(btnPort, MainPort); ;
                            ovdForm.Show();
                            btnPort.Text = buttonText;
                            ClearBoardButtons();
                            ClearPdcBoardButtons();
                            ClearimageButton(btnPort);
                            break;


                        case "CGDB":
                            panelshowwindowsall.Controls.Clear();
                            frmCGDB cgdbForm = new frmCGDB();
                            cgdbForm.TopLevel = false;
                            cgdbForm.FormBorderStyle = FormBorderStyle.None;
                            cgdbForm.Dock = DockStyle.Fill;
                            panelshowwindowsall.Controls.Add(cgdbForm);
                            cgdbForm.SetPassedValue(btnPort, MainPort);
                            cgdbForm.Show();
                            btnPort.Text = buttonText;
                            ClearBoardButtons();
                            ClearPdcBoardButtons();
                            break;

                        case "DELETE":
                            panelshowwindowsall.Controls.Clear();
                            DeletePDCPort(btnPort, MainPort);
                            break;

                        default:

                            break;
                    }


                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        private void CreateADDImageButton()
        {
            try
            {


                for (int i = 1; i <= 35; i++)
                {
                    // Create a new button
                    Button imageButton = new Button
                    {
                        Size = new Size(18, 18),
                        Location = new Point(5, 10 + (i - 1) * 30),
                        TextAlign = ContentAlignment.MiddleCenter,
                        ImageAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.LightYellow,
                        ForeColor = Color.Red,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        Name = $"PORT{i}image",
                        FlatStyle = FlatStyle.Flat,
                        Image = Properties.Resources._134224_add_plus_new_icon
                    };

                    imageButton.FlatAppearance.BorderSize = 0;

                    // Add event handlers
                    // imageButton.MouseClick += ImageButton_Click;
                    imageButton.MouseDown += ImageButton_MouseDown;
                    imageButton.Click += ImageButton_Click;

                    // Add the button to the panel
                    panHubConfiguration.Controls.Add(imageButton);
                    imageButtonslist.Add(imageButton);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private void ImageButton_MouseDown(object sender, EventArgs e)
        {
            try
            {


                ClearBoardButtons();
                Button clickedButton = sender as Button;
                clickEvent(clickedButton);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        //private void CreateAddButton(Button btnport)
        //{
        //    // Create a new Button control
        //    Button imageButton = new Button();

        //    // Set the size of the button
        //    imageButton.Size = new Size(30, 30); // Adjust the size as needed

        //    // Calculate the new button's location to be beside the passed button
        //    // For example, placing it to the right of btnport with a small gap
        //    int newButtonX = btnport.Location.X - imageButton.Width - 10; // 10 is the gap between buttons
        //    int newButtonY = btnport.Location.Y;
        //    imageButton.Location = new Point(newButtonX, newButtonY);

        //    // Set the image for the button from the resources
        //    imageButton.Image = Properties.Resources._134224_add_plus_new_icon;


        //    // Set the button's properties to display only the image
        //    string name = btnport.Name;
        //    imageButton.Name = name+"image" ;
        //   // imageButton.Name = $"image{i + 1}";
        //    imageButton.FlatStyle = FlatStyle.Flat;
        //    imageButton.FlatAppearance.BorderSize = 0;
        //    imageButton.ImageAlign = ContentAlignment.MiddleCenter;

        //    // Add the button to the panel (assuming this method is in the form class)
        //    panHubConfiguration.Controls.Add(imageButton);
        //    imageButtonslist.Add(imageButton);
        //    // Optionally, you can add a click event handler for the button
        //    imageButton.Click += new EventHandler(ImageButton_Click);
        //}

        // Event handler for the button click event
        private void ImageButton_Click(object sender, EventArgs e)
        {

            Button clickedButton = sender as Button;

            clickEvent(clickedButton);
        }

        private void clickEvent(Button clickedButton)
        {
            try
            {


                ClearPdcBoardButtons();
                if (panPdcPorts.Visible)
                {
                    ClearBoardButtons();
                    panPdcPorts.Visible = false;

                    OpenImageButton(clickedButton);
                }
                else
                {


                    OpenImageButton(clickedButton);

                }

                clickedButton.BackColor = Color.GreenYellow;
                string clickedbuttonname = clickedButton.Name;
                int portNumber = ExtractNumericPart(clickedbuttonname);
                Button portButton = new Button
                {

                    Name = "PORT" + portNumber
                    // Set additional properties as needed
                };
                ChangebackgroundColorPort(portButton);
                ChangebackgroundColorimage(clickedButton);

                //ChangebackgroundColorPorts();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void OpenImageButton(Button clickedButton)
        {
            try
            {


                if (clickedButton == null) return; // Ensure the sender is a Button

                string buttonName = clickedButton.Name;
                int MainportNumber = ExtractNumericPart(buttonName);

                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("PortNo") &&
                        int.TryParse(row["PortNo"].ToString(), out int port) &&
                        MainportNumber == port)
                    {
                        if (int.TryParse(row["PacketIdentifier"].ToString(), out int packetIdentifier) &&
                            packetIdentifier == 1)
                        {
                            if (int.TryParse(row["NoofPorts"].ToString(), out int noOfPorts))
                            {
                                // Set the location of panPdcPorts based on the location of clickedButton
                                panPdcPorts.Location = new Point(clickedButton.Location.X + 15 + clickedButton.Width + 110, clickedButton.Location.Y + 5);

                                CreateSubEthernetPorts(noOfPorts, MainportNumber);
                                SetSubEthernetPorts(MainportNumber);

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
        private void SetSubEthernetPorts(int MainportNumber)
        {
            try
            {



                foreach (Control control in panPdcPorts.Controls)
                {
                    if (control is Button button)
                    {
                        int EthernetNumber = ExtractNumericPart(button.Name);
                        foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                        {
                            if (BaseClass.EthernetPorts.Columns.Contains("EthernetPort") &&
                                  int.TryParse(row["EthernetPort"].ToString(), out int ethernetport) &&
                                   ethernetport == MainportNumber && BaseClass.EthernetPorts.Columns.Contains("PdcPortNo") &&
                                   int.TryParse(row["PdcPortNo"].ToString(), out int pdcPortnumber) && pdcPortnumber == EthernetNumber)
                            {

                                button.Text = row["Location"].ToString();

                            }




                        }
                    }
                }
                foreach (Control control in panPdcPorts.Controls)
                {
                    if (control is Button button)
                    {


                        int EthernetNumber = ExtractNumericPart(button.Name);
                        foreach (DataRow row in BaseClass.CgdbPorts.Rows)
                        {
                            if (BaseClass.CgdbPorts.Columns.Contains("MainEthernetPortNo") &&
                                  int.TryParse(row["MainEthernetPortNo"].ToString(), out int ethernetport) &&
                                   ethernetport == MainportNumber && BaseClass.CgdbPorts.Columns.Contains("pdcPortNo") &&
                                   int.TryParse(row["pdcPortNo"].ToString(), out int pdcPortnumber) && pdcPortnumber == EthernetNumber)
                            {

                                string platform = row["default_platformno"].ToString().Trim();

                                button.Text = "Cgdb_" + platform;

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


        private void OpenSelectedBoard(string BoardType, int HubPk)
        {
            try
            {


                switch (BoardType)
                {
                    case "PDC":
                        panelshowwindowsall.Controls.Clear();
                        frmPdcConfiguration pdcForm = new frmPdcConfiguration();
                        pdcForm.TopLevel = false;
                        pdcForm.FormBorderStyle = FormBorderStyle.None;
                        pdcForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(pdcForm);
                        pdcForm.SetPkHubValue(HubPk);
                        pdcForm.Show();

                        ClearBoardButtons();


                        break;
                    case "MLDB":
                        panelshowwindowsall.Controls.Clear();
                        frmMLDB mldbForm = new frmMLDB();
                        mldbForm.TopLevel = false;
                        mldbForm.FormBorderStyle = FormBorderStyle.None;
                        mldbForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(mldbForm);
                        mldbForm.SetPkHubValue(HubPk);

                        mldbForm.Show();


                        ClearPdcBoardButtons();

                        break;

                    case "PFDB":
                        panelshowwindowsall.Controls.Clear();
                        frmPFD pfdForm = new frmPFD();
                        pfdForm.TopLevel = false;
                        pfdForm.FormBorderStyle = FormBorderStyle.None;
                        pfdForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(pfdForm);
                        pfdForm.SetPkHubValue(HubPk);

                        pfdForm.Show();


                        ClearPdcBoardButtons();
                        break;

                    case "AGDB":
                        panelshowwindowsall.Controls.Clear();
                        frmAGDB agdbForm = new frmAGDB();
                        agdbForm.TopLevel = false;
                        agdbForm.FormBorderStyle = FormBorderStyle.None;
                        agdbForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(agdbForm);
                        agdbForm.SetPkHubValue(HubPk);

                        agdbForm.Show();


                        ClearPdcBoardButtons();
                        break;

                    case "IVD":

                        panelshowwindowsall.Controls.Clear();
                        frmIVD ivdForm = new frmIVD();
                        ivdForm.TopLevel = false;
                        ivdForm.FormBorderStyle = FormBorderStyle.None;
                        ivdForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(ivdForm);
                        ivdForm.SetPkHubValue(HubPk);

                        ivdForm.Show();


                        ClearPdcBoardButtons();
                        break;

                    case "OVD":

                        panelshowwindowsall.Controls.Clear();
                        frmOVD ovdForm = new frmOVD();
                        ovdForm.TopLevel = false;
                        ovdForm.FormBorderStyle = FormBorderStyle.None;
                        ovdForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(ovdForm);
                        ovdForm.SetPkHubValue(HubPk);

                        ovdForm.Show();


                        ClearPdcBoardButtons();

                        break;

                    case "CGDB":
                        panelshowwindowsall.Controls.Clear();
                        frmCGDB cgdbForm = new frmCGDB();
                        cgdbForm.TopLevel = false;
                        cgdbForm.FormBorderStyle = FormBorderStyle.None;
                        cgdbForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(cgdbForm);
                        cgdbForm.SetPkHubValue(HubPk);
                        cgdbForm.Show();
                        ClearPdcBoardButtons();
                        break;



                    case "CCTV":
                        panelshowwindowsall.Controls.Clear();
                        frmCCTV cctvForm = new frmCCTV();
                        cctvForm.TopLevel = false;
                        cctvForm.FormBorderStyle = FormBorderStyle.None;
                        cctvForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(cctvForm);
                        cctvForm.SetPkHubValue(HubPk);
                        cctvForm.Show();
                        ClearPdcBoardButtons();
                        break;


                    default:

                        break;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }

        private void CreateSubEthernetPorts(int noOfPorts, int pdcportno)
        {

            try
            {


                // Clear existing controls
                panPdcPorts.Controls.Clear();
                panPdcPorts.Visible = true;

                // Initial y-coordinate and total height
                int yPos = 10;
                int totalHeight = 0;

                for (int i = 0; i < noOfPorts; i++)
                {
                    // Create a new button
                    Button EthernetportButton = new Button();
                    EthernetportButton.Text = $"EthernetPort{i + 1}";
                    EthernetportButton.Name = $"EthernetPort{i + 1}";
                    EthernetportButton.Size = new Size(100, 30);
                    EthernetportButton.BackColor = Color.CornflowerBlue;
                    // Set the location of the button based on yPos
                    EthernetportButton.Location = new Point(10, yPos);

                    // Increment yPos for the next button
                    yPos += EthernetportButton.Height + 5; // Add button height and some spacing

                    EthernetportButton.MouseDown += (sender, e) =>
                    {
                        // Access the button that triggered the event
                        Button button = sender as Button;

                        // Call the method with the button, event args, and additional value
                        EthernetPortButton_MouseDown(button, e, pdcportno);
                    };
                    EthernetportButton.Click += (sender, e) =>
                    {
                        EthernetPortButton_Click(sender, e, pdcportno);
                    };


                    // Add the button to the panel
                    panPdcPorts.Controls.Add(EthernetportButton);

                    // Update total height
                    totalHeight += EthernetportButton.Height + 5; // Add button height and spacing
                }

                // Adjust panel height
                panPdcPorts.Height = totalHeight + 5; // Add some extra space at the bottom
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        private void EthernetPortButton_Click(object sender, EventArgs e, int MainPort)
        {
            try
            {


                panelshowwindowsall.Controls.Clear();
                Button button = sender as Button;
                int EthernetNumber = ExtractNumericPart(button.Name);
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("EthernetPort") &&
                          int.TryParse(row["EthernetPort"].ToString(), out int ethernetport) &&
                           ethernetport == MainPort && BaseClass.EthernetPorts.Columns.Contains("PdcPortNo") &&
                           int.TryParse(row["PdcPortNo"].ToString(), out int pdcPortnumber) && pdcPortnumber == EthernetNumber)
                    {

                        if (int.TryParse(row["PacketIdentifier"].ToString(), out int packetIdentifier))
                        {
                            string BoardType = GetPacketname(packetIdentifier).Trim();

                            if (int.TryParse(row["PkeyMasterhub"].ToString(), out int HubPk))
                            {
                                OpenSelectedBoard(BoardType, HubPk);
                            }


                        }

                    }

                }

                foreach (DataRow row in BaseClass.CgdbPorts.Rows)
                {
                    if (BaseClass.CgdbPorts.Columns.Contains("MainEthernetPortNo") &&
                          int.TryParse(row["MainEthernetPortNo"].ToString(), out int ethernetport) &&
                           ethernetport == MainPort && BaseClass.CgdbPorts.Columns.Contains("pdcPortNo") &&
                           int.TryParse(row["pdcPortNo"].ToString(), out int pdcPortnumber) && pdcPortnumber == EthernetNumber)
                    {

                        if (int.TryParse(row["PacketIdentifier"].ToString(), out int packetIdentifier))
                        {
                            string BoardType = GetPacketname(packetIdentifier).Trim();

                            if (int.TryParse(row["Pkey_CoachConfig"].ToString(), out int HubPk))
                            {
                                OpenSelectedBoard(BoardType, HubPk);
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
        private void EthernetPortButton_MouseDown(object sender, MouseEventArgs e, int pdcportno)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button clickedButton = sender as Button;
                ClearPdcBoardButtons();

                PdcUnderBoards(clickedButton, pdcportno);
            }
        }
        public int ExtractNumericPart(string buttonName)
        {
            // Initialize an empty string to store the numeric part
            string numericPart = "";

            // Iterate through each character in the button name
            foreach (char c in buttonName)
            {
                // Check if the character is a digit
                if (char.IsDigit(c))
                {
                    // If it's a digit, append it to the numeric part string
                    numericPart += c;
                }
            }

            // Convert the numeric part string to an integer and return it
            return int.Parse(numericPart);
        }

        private void PdcUnderBoards(Button buttonPort, int pdcvalue)
        {
            try
            {


                for (int i = 0; i < PdcBoardLabels.Length; i++)
                {
                    Button pdcbtnBoards = new Button();
                    pdcbtnBoards.Size = new Size(80, 30);
                    // pdcbtnBoards.Location = new Point(270, 100 + i * 50);
                    pdcbtnBoards.Location = new Point(panPdcPorts.Location.X + panPdcPorts.Width, panPdcPorts.Location.Y + i * 30);
                    pdcbtnBoards.Text = PdcBoardLabels[i];
                    pdcbtnBoards.BackColor = Color.Blue;
                    pdcbtnBoards.ForeColor = Color.White;
                    pdcbtnBoards.Font = new Font("Arial", 10);
                    pdcBoardButtons.Add(pdcbtnBoards);
                    // dynamicButtons.Add(pdcbtnBoards);
                    // btnBoards.MouseClick += btnBoards_MouseClick;
                    pdcbtnBoards.MouseClick += (sender, e) => pdcbtnBoards_MouseClick(sender, e, buttonPort, pdcvalue);
                    panHubConfiguration.Controls.Add(pdcbtnBoards);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        private void btnEthernetports_MouseDown(object sender, MouseEventArgs e)
        {
            //// Check if the right mouse button was clicked
            //if (e.Button == MouseButtons.Right)
            //{
            //    // Handle the right-click event
            //    MessageBox.Show("Right-click detected!");
            //}
        }
        private void ChangebackgroundColorPorts()
        {
            foreach (var btn in buttonportslist)
            {

                btn.BackColor = Color.LightYellow; // Set the color to whatever you prefer

            }
        }

        private void ChangebackgroundColorImagePorts()
        {
            foreach (var btn in imageButtonslist)
            {

                btn.BackColor = Color.LightYellow; // Set the color to whatever you prefer

            }
        }

        private void frmHubConfiguration_Load(object sender, EventArgs e)
        {
            try
            {


                BaseClass.EthernetPorts = HubConfigurationDb.GetEthernetPorts();
                BaseClass.CgdbPorts = HubConfigurationDb.GetCgdbConfiguration();

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }


        public static byte[] PfdDefaultPacket(string ipaddress, int packetidentifier, string letterSpeed, int noofLines, string videoType,
                                string DisplayEffect, int fontsize, string lettergap, int DelayTime,
                                string defaultEnglish, string defaultRegional, string defaultHindi, string DisplaySequence, string FormatType)
        {
            try
            {


                Byte[] sendbyte = ByteFormation.CommonBytes(ipaddress, packetidentifier);
                if (sendbyte == null)
                {
                    return null;
                }
                Array.Resize(ref sendbyte, sendbyte.Length + 2);
                int sodDataType = 2; //sod and defult and window
                sendbyte[10] = (byte)ArecaIPIS.Classes.Board.DefaultData;  //packet Type
                sendbyte[11] = 2;  //Sod

                int WindowsCount = 0;
                List<string> languageSequence = new List<string>(DisplaySequence.Split(','));
                List<int> languageSequencepk = new List<int>();

                foreach (string language in languageSequence)
                {
                    string trimmedLanguage = language.Trim();
                    var result = BaseClass.SelectionRegionalLanguagesDt.AsEnumerable()
                        .Where(row => row.Field<string>("LanguageName") == trimmedLanguage)
                        .Select(row => row.Field<int>("Pkey_Language"))
                        .FirstOrDefault();

                    if (result != 0)
                    {
                        languageSequencepk.Add(result);
                    }
                }




                if (string.IsNullOrEmpty(defaultRegional))
                {
                    WindowsCount = 2;

                }
                else
                {
                    WindowsCount = 3;

                }

                int WindowsLength = WindowsCount * 14;


                byte[] EnglishWindow = WindowFormation(packetidentifier, letterSpeed, noofLines, videoType,
                                   DisplayEffect, fontsize, lettergap, DelayTime,
                                    defaultEnglish, defaultRegional, defaultHindi, FormatType);
                byte[] HindiWindow = WindowFormation(packetidentifier, letterSpeed, noofLines, videoType,
                                   DisplayEffect, fontsize, "0", DelayTime,
                                    defaultEnglish, defaultRegional, defaultHindi, FormatType);
                byte[] RegionalWindow = new byte[0];
                if (WindowsCount == 3)
                {
                    RegionalWindow = WindowFormation(packetidentifier, letterSpeed, noofLines, videoType,
                                       DisplayEffect, fontsize, BaseClass.regionalGapCode.ToString(), DelayTime,
                                        defaultEnglish, defaultRegional, defaultHindi, FormatType);

                }

                int len = WindowsLength + 2;//window and first termination bytes 2

                Array.Resize(ref sendbyte, sendbyte.Length + len);


                int x = 12;
                int number = 1;


                foreach (int language in languageSequencepk)
                {
                    if (language == 6)//English
                    {

                        for (int i = 0; i < EnglishWindow.Length; i++)
                        {
                            sendbyte[x] = EnglishWindow[i];
                            x++;
                        }
                    }
                    else if (language == 16)//Hindi
                    {
                        for (int i = 0; i < HindiWindow.Length; i++)
                        {
                            sendbyte[x] = HindiWindow[i];
                            x++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < RegionalWindow.Length; i++)
                        {
                            sendbyte[x] = RegionalWindow[i];
                            x++;
                        }
                    }



                }




                Byte[] tb = ByteFormation.GetTerminationBytes();
                sendbyte[sendbyte.Length - 2] = tb[0];
                sendbyte[sendbyte.Length - 1] = tb[1];
                int windowStartNumber = sendbyte.Length;


                int[] postions = getFormatType(FormatType, noofLines);
                int boardwidth = postions[1];
                byte[] EnglishDataBytes = GetEnglishBytes(defaultEnglish, fontsize, boardwidth);
                byte[] HindiDataBytes = GetHindiBytes(defaultHindi, fontsize, boardwidth);
                byte[] RegionalDataBytes = new byte[0];
                if (WindowsCount == 3)
                {
                    RegionalDataBytes = GetRegionalBytes(defaultRegional, fontsize, boardwidth);

                }
                int dataBytesLength = EnglishDataBytes.Length + HindiDataBytes.Length + RegionalDataBytes.Length;
                Array.Resize(ref sendbyte, sendbyte.Length + dataBytesLength);
                int z = windowStartNumber;
                int k = windowStartNumber - 12;
                List<int> windowStrtPostions = new List<int>();

                foreach (int language in languageSequencepk)
                {
                    windowStrtPostions.Add(k);

                    if (language == 6)//English
                    {
                        for (int i = 0; i < EnglishDataBytes.Length; i++)
                        {
                            sendbyte[z] = EnglishDataBytes[i];
                            z++;
                            k++;
                        }
                    }
                    else if (language == 16)//Hindi
                    {
                        for (int i = 0; i < HindiDataBytes.Length; i++)
                        {
                            sendbyte[z] = HindiDataBytes[i];
                            z++;
                            k++;
                        }
                    }
                    // Assuming the default behavior if the language is neither "English" nor "Hindi" when WindowsCount <= 2
                    else
                    {
                        for (int i = 0; i < RegionalDataBytes.Length; i++)
                        {
                            sendbyte[z] = RegionalDataBytes[i];
                            z++;
                            k++;
                        }
                    }

                }


                byte[] firstwindowPostion = GetTwoBytesFromInt(windowStrtPostions[0]);
                sendbyte[12 + 14 - 2] = firstwindowPostion[0];
                sendbyte[12 + 14 - 1] = firstwindowPostion[1];


                byte[] SecondwindowPostion = GetTwoBytesFromInt(windowStrtPostions[1]);
                sendbyte[12 + 14 + 14 - 2] = SecondwindowPostion[0];
                sendbyte[12 + 14 + 14 - 1] = SecondwindowPostion[1];
                if (WindowsCount > 2)
                {
                    byte[] ThirdwindowPostion = GetTwoBytesFromInt(windowStrtPostions[2]);
                    sendbyte[12 + 14 + 14 + 14 - 2] = ThirdwindowPostion[0];
                    sendbyte[12 + 14 + 14 + 14 - 1] = ThirdwindowPostion[1];

                }



                Array.Resize(ref sendbyte, sendbyte.Length + 4);

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
            catch (FormatException ex)
            {
                MessageBox.Show("Error: Invalid IP address format.\n" + ex.Message, "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            return null;
        }

        //public static byte[] AgdbDefaultPacket(string ipaddress, int packetidentifier, string letterSpeed, int noofLines, string videoType,
        //                       string DisplayEffect, int fontsize, string lettergap, int DelayTime,
        //                       string defaultEnglish, string defaultRegional, string defaultHindi, string DisplaySequence, string FormatType)
        //{
        //    try
        //    {


        //        Byte[] sendbyte = ByteFormation.CommonBytes(ipaddress, packetidentifier);
        //        if (sendbyte == null)
        //        {
        //            return null;
        //        }
        //        Array.Resize(ref sendbyte, sendbyte.Length + 2);
        //        int sodDataType = 2; //sod and defult and window
        //        sendbyte[10] = (byte)ArecaIPIS.Classes.Board.DefaultData;  //packet Type
        //        sendbyte[11] = 2;  //Sod

        //        int WindowsCount = 1;


        //        int WindowsLength = WindowsCount * 14;


        //        byte[] EnglishWindow = WindowFormation(packetidentifier, letterSpeed, noofLines, videoType,
        //                           DisplayEffect, fontsize, lettergap, DelayTime,
        //                            defaultEnglish, defaultRegional, defaultHindi, FormatType);



        //        int len = WindowsLength + 2;//window and first termination bytes 2

        //        Array.Resize(ref sendbyte, sendbyte.Length + len);


        //        int x = 12;

        //        for (int i = 0; i < EnglishWindow.Length; i++)
        //        {
        //            sendbyte[x] = EnglishWindow[i];
        //            x++;
        //        }

        //        Byte[] tb = ByteFormation.GetTerminationBytes();
        //        sendbyte[sendbyte.Length - 2] = tb[0];
        //        sendbyte[sendbyte.Length - 1] = tb[1];
        //        int windowStartNumber = sendbyte.Length;


        //        int[] postions = getFormatType(FormatType, noofLines);
        //        int boardwidth = postions[1];
        //        byte[] EnglishDataBytes;

        //       // int lastOctet = int.Parse(ipaddress.Split('.').Last());

        //        //if (lastOctet >= 130 && lastOctet <= 160)
        //        //{
        //        if (BaseClass.GettruecolorAgdbstatus(ipaddress))
        //        {
        //            EnglishDataBytes= GetEnglishBytestruecolorAgdb(defaultEnglish, fontsize, boardwidth);
        //        }
        //        else
        //        {
        //            EnglishDataBytes = GetEnglishBytes(defaultEnglish, fontsize, boardwidth);
        //        }
        //       // }



        //        int dataBytesLength = EnglishDataBytes.Length;
        //        Array.Resize(ref sendbyte, sendbyte.Length + dataBytesLength);
        //        int z = windowStartNumber;
        //        int k = windowStartNumber - 12;
        //        List<int> windowStrtPostions = new List<int>();

        //        windowStrtPostions.Add(k);

        //        for (int i = 0; i < EnglishDataBytes.Length; i++)
        //        {
        //            sendbyte[z] = EnglishDataBytes[i];
        //            z++;
        //            k++;
        //        }



        //        byte[] firstwindowPostion = GetTwoBytesFromInt(windowStrtPostions[0]);
        //        sendbyte[12 + 14 - 2] = firstwindowPostion[0];
        //        sendbyte[12 + 14 - 1] = firstwindowPostion[1];





        //        Array.Resize(ref sendbyte, sendbyte.Length + 4);




        //        sendbyte[sendbyte.Length - 4] = 3;
        //        sendbyte[sendbyte.Length - 3] = 0;
        //        sendbyte[sendbyte.Length - 2] = 0;
        //        sendbyte[sendbyte.Length - 1] = 4;

        //        int packetLength = sendbyte.Length - 6;
        //        byte[] packetLengthBytes = GetTwoBytesFromInt(packetLength);
        //        sendbyte[3] = packetLengthBytes[0];
        //        sendbyte[4] = packetLengthBytes[1];

        //        Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
        //        Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
        //        Byte[] value = Server.CheckSum(finalPacket);
        //        finalPacket[finalPacket.Length - 9] = value[0];   //crc msb
        //        finalPacket[finalPacket.Length - 8] = value[1];    //crc lsb


        //        return finalPacket;
        //    }
        //    catch (Exception ex)
        //    {
        //        Server.LogError(ex.Message);
        //    }

        //    return null;

        //}


        public static byte[] AgdbDefaultPacket(string ipaddress, int packetidentifier, string letterSpeed, int noofLines, string videoType,
                         string DisplayEffect, int fontsize, string lettergap, int DelayTime,
                         string defaultEnglish, string defaultRegional, string defaultHindi, string DisplaySequence, string FormatType)
        {
            try
            {
                var defaultparts = defaultEnglish.Split(new string[] { "||" }, StringSplitOptions.None);

                Byte[] sendbyte = ByteFormation.CommonBytes(ipaddress, packetidentifier);
                if (sendbyte == null)
                {
                    return null;
                }
                Array.Resize(ref sendbyte, sendbyte.Length + 2);
                int sodDataType = 2; //sod and defult and window
                sendbyte[10] = (byte)ArecaIPIS.Classes.Board.DefaultData;  //packet Type
                sendbyte[11] = 2;  //Sod


                int WindowsCount = defaultparts.Length;


                int WindowsLength = WindowsCount * 14;


                byte[] EnglishWindow = WindowFormation(packetidentifier, letterSpeed, noofLines, videoType,
                                   DisplayEffect, fontsize, lettergap, DelayTime,
                                     defaultparts[0], defaultRegional, defaultHindi, FormatType);
                byte[] SecondEnglishWindow;
                if (defaultparts.Length > 1)
                {

                    SecondEnglishWindow = SecondWindowFormation(packetidentifier, letterSpeed, noofLines, videoType,
                                  DisplayEffect, fontsize, lettergap, DelayTime,
                                   defaultparts[1], defaultRegional, defaultHindi, FormatType);
                }
                else
                {
                    SecondEnglishWindow = null;
                }


                int len = WindowsLength + 2;//window and first termination bytes 2

                Array.Resize(ref sendbyte, sendbyte.Length + len);


                int x = 12;

                for (int i = 0; i < EnglishWindow.Length; i++)
                {
                    sendbyte[x] = EnglishWindow[i];
                    x++;
                }

                int windowStartNumber = sendbyte.Length;

                if (defaultparts.Length > 1)
                {
                    for (int i = 0; i < SecondEnglishWindow.Length; i++)
                    {
                        sendbyte[x] = SecondEnglishWindow[i];
                        x++;
                    }

                }

                int secondwindowStartNumber = sendbyte.Length;

                Byte[] tb = ByteFormation.GetTerminationBytes();
                sendbyte[sendbyte.Length - 2] = tb[0];
                sendbyte[sendbyte.Length - 1] = tb[1];

                int[] postions = getFormatType(FormatType, noofLines);
                int boardwidth = postions[1];
                byte[] EnglishDataBytes;
                byte[] secondEnglishDataBytes;


                //{
                if (BaseClass.GettruecolorAgdbstatus(ipaddress))
                {
                    EnglishDataBytes = GetEnglishBytestruecolorAgdb(defaultparts[0], fontsize, boardwidth);
                    if (defaultparts.Length > 1)
                    {
                        secondEnglishDataBytes = GetEnglishBytestruecolorAgdb(defaultparts[1], fontsize, boardwidth);
                    }
                    else
                    {
                        secondEnglishDataBytes = null;
                    }
                }
                else
                {
                    EnglishDataBytes = GetEnglishBytes(defaultparts[0], fontsize, boardwidth);
                    if (defaultparts.Length > 1)
                    {
                        secondEnglishDataBytes = GetEnglishBytes(defaultparts[1], fontsize, boardwidth);
                    }
                    else
                    {
                        secondEnglishDataBytes = null;
                    }
                }




                int dataBytesLength = EnglishDataBytes.Length;
                int secondDataBytesLength = 0;
                if (secondEnglishDataBytes != null)
                {
                    secondDataBytesLength = secondEnglishDataBytes.Length;
                }



                if (defaultparts.Length > 1)
                {

                    Array.Resize(ref sendbyte, sendbyte.Length + dataBytesLength + secondDataBytesLength);
                }
                else
                {
                    Array.Resize(ref sendbyte, sendbyte.Length + dataBytesLength);
                }
                int z = windowStartNumber;
                int k = windowStartNumber - 12;
                List<int> windowStrtPostions = new List<int>();

                windowStrtPostions.Add(k);

                for (int i = 0; i < EnglishDataBytes.Length; i++)
                {
                    sendbyte[z] = EnglishDataBytes[i];
                    z++;
                    k++;
                }
                if (defaultparts.Length > 1)
                {
                    windowStrtPostions.Add(k);
                    for (int i = 0; i < secondEnglishDataBytes.Length; i++)
                    {
                        sendbyte[z] = secondEnglishDataBytes[i];
                        z++;
                        k++;
                    }
                }



                byte[] firstwindowPostion = GetTwoBytesFromInt(windowStrtPostions[0]);
                sendbyte[12 + 14 - 2] = firstwindowPostion[0];
                sendbyte[12 + 14 - 1] = firstwindowPostion[1];

                if (defaultparts.Length > 1)
                {

                    byte[] secondwindowPostion = GetTwoBytesFromInt(windowStrtPostions[1]);
                    sendbyte[12 + 14 + 14 - 2] = secondwindowPostion[0];
                    sendbyte[12 + 14 + 14 - 1] = secondwindowPostion[1];
                }


                Array.Resize(ref sendbyte, sendbyte.Length + 4);




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

        public static byte[] WindowFormation(
                          int packetidentifier, string letterSpeed, int noofLines, string videoType,
                     string DisplayEffect, int fontsize, string lettergap, int DelayTime,
                         string defaultEnglish, string defaultRegional, string defaultHindi, string formatIndexNo)
        {
            try
            {



                int[] postions = getFormatType(formatIndexNo, noofLines);
                byte[] byte1and2 = GetTwoBytesFromInt(postions[0]);
                byte[] byte3and4 = GetTwoBytesFromInt(postions[1]);
                byte[] byte5and6 = GetTwoBytesFromInt(postions[2]);
                byte[] byte7and8 = GetTwoBytesFromInt(postions[3]);
                byte byte9 = GetNineByte(videoType, letterSpeed);
                byte byte10 = GetTenthByte(DisplayEffect);
                byte byte11 = GetEleventhByte(lettergap, fontsize);
                byte byte12 = GetTwelvethByte(DelayTime);


                Byte[] sendbyte = new Byte[14];

                Array.Copy(byte1and2, 0, sendbyte, 0, 2);
                Array.Copy(byte3and4, 0, sendbyte, 2, 2);
                Array.Copy(byte5and6, 0, sendbyte, 4, 2);
                Array.Copy(byte7and8, 0, sendbyte, 6, 2);
                sendbyte[8] = byte9;
                sendbyte[9] = byte10;
                sendbyte[10] = byte11;
                sendbyte[11] = byte12;



                // Copy the Unicode bytes into the result array


                return sendbyte;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return null;
        }

        public static byte[] SecondWindowFormation(
                        int packetidentifier, string letterSpeed, int noofLines, string videoType,
                   string DisplayEffect, int fontsize, string lettergap, int DelayTime,
                       string defaultEnglish, string defaultRegional, string defaultHindi, string formatIndexNo)
        {
            try
            {



                int[] postions = getFormatType(formatIndexNo, noofLines);
                byte[] byte1and2 = GetTwoBytesFromInt(postions[0]);
                byte[] byte3and4 = GetTwoBytesFromInt(postions[1]);
                byte[] byte5and6 = new byte[] { 0, 16 };
                byte[] byte7and8 = new byte[] { 0, 1 };
                byte byte9 = GetNineByte(videoType, letterSpeed);
                byte byte10 = GetTenthByte(DisplayEffect);
                byte byte11 = GetEleventhByte(lettergap, fontsize);
                byte byte12 = GetTwelvethByte(DelayTime);


                Byte[] sendbyte = new Byte[14];

                Array.Copy(byte1and2, 0, sendbyte, 0, 2);
                Array.Copy(byte3and4, 0, sendbyte, 2, 2);
                Array.Copy(byte5and6, 0, sendbyte, 4, 2);
                Array.Copy(byte7and8, 0, sendbyte, 6, 2);
                sendbyte[8] = byte9;
                sendbyte[9] = byte10;
                sendbyte[10] = byte11;
                sendbyte[11] = byte12;



                // Copy the Unicode bytes into the result array


                return sendbyte;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return null;
        }



        public static byte[] CgdbWindowFormation(
                        int packetidentifier, string letterSpeed, string videoType,
                   string DisplayEffect, int fontsize, string lettergap, int DelayTime,
                       string defaultEnglish, string divOrPf, string defaultHindi)
        {
            try
            {


                byte byte1 = 1;
                byte byte2 = 48;
                byte byte3 = 16;
                byte byte4 = 1;
                byte byte5 = GetNineByte(videoType, letterSpeed);
                byte byte6 = GetTenthByte(DisplayEffect);
                byte byte7 = GetEleventhByte(lettergap, fontsize);
                byte byte8 = GetTwelvethByte(DelayTime);
                byte[] trainBits = Get10bits(defaultEnglish);
                byte[] EnglishCoach = Get10bits(divOrPf);
                byte[] fieldSeparator = ByteFormation.GapCode;
                byte[] HindiBits = GetCgdbHindibits(defaultHindi);

                //Byte[] sendbyte = new Byte[47];
                List<byte> sendbyte = new List<byte>();

                // Add the initial bytes to the list
                sendbyte.Add(byte1);
                sendbyte.Add(byte2);
                sendbyte.Add(byte3);
                sendbyte.Add(byte4);
                sendbyte.Add(byte5);
                sendbyte.Add(byte6);
                sendbyte.Add(byte7);
                sendbyte.Add(byte8);

                // Append trainBits, EnglishCoach, fieldSeparator, and HindiBits
                sendbyte.AddRange(trainBits);
                sendbyte.AddRange(EnglishCoach);
                sendbyte.AddRange(fieldSeparator);
                sendbyte.AddRange(HindiBits);

                // Append the final byte (236)
                sendbyte.Add(236);

                // Return the array
                return sendbyte.ToArray();

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return null;
        }

        public static int[] getFormatType(string formatNo, int noofLines)
        {

            int fno = Convert.ToInt32(formatNo);
            int[] resultBytes = new int[4];
            try
            {



                foreach (DataRow row in BaseClass.FormatsDt.Rows)
                {
                    if (Convert.ToInt32(row["Pkey_FormatName"]) == fno) // Assuming "Pkey_FormatName" is the column to check
                    {
                        string format = row["Format"].ToString();
                        string[] parts = format.Split('X');

                        if (parts.Length > 1)
                        {
                            int part1 = Convert.ToInt32(parts[1]);
                            int part0 = Convert.ToInt32(parts[0]);
                            resultBytes[0] = 1;
                            resultBytes[1] = part1;
                            resultBytes[2] = noofLines * part0;
                            resultBytes[3] = noofLines * part0 - 15;
                        }

                        break; // Exit loop once the match is found
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            return resultBytes;
        }

        public static byte[] GetCgdbHindibits(string Text)
        {
           byte[] resultBytes = new byte[16];
            try
            {


                byte[] HindiTextBytes = Encoding.BigEndianUnicode.GetBytes(Text);

                if (!BaseClass.CgdbHAbove16)
                {
                    // Determine the number of bytes to copy (up to 16 bytes)
                    int bytesToCopy = Math.Min(HindiTextBytes.Length, 16);

                    // Copy the relevant bytes from HindiTextBytes to resultBytes
                    Buffer.BlockCopy(HindiTextBytes, 0, resultBytes, 0, bytesToCopy);

                    for (int i = bytesToCopy; i < 16; i += 2)
                    {
                        resultBytes[i] = 0x00;
                        if (i + 1 < 16) // Ensure we don't go out of bounds
                        {
                            resultBytes[i + 1] = 0x20;
                        }
                    }

                    return resultBytes;
                }
                return HindiTextBytes;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return null;
        }

        public static byte[] Get10bits(string Text)
        {
            byte[] resultBytes = new byte[10];
            try
            {
                byte[] englishTextBytes = Encoding.BigEndianUnicode.GetBytes(Text);

                // Determine the number of bytes to copy (up to 10 bytes)
                int bytesToCopy = Math.Min(englishTextBytes.Length, 10);

                // Copy the relevant bytes from englishTextBytes to resultBytes
                Buffer.BlockCopy(englishTextBytes, 0, resultBytes, 0, bytesToCopy);

                // If the length of the text is less than 10 bytes, fill the remaining bytes with 0x00 0x20 (space character in Big Endian Unicode)
                for (int i = bytesToCopy; i < 10; i += 2)
                {
                    resultBytes[i] = 0x00;
                    if (i + 1 < 10) // Ensure we don't go out of bounds
                    {
                        resultBytes[i + 1] = 0x20;
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return resultBytes;
        }

        public static byte[] GetRegionalBytes(string RegionalText, int fontsize, int BoardWidth)
        {
            try
            {


                byte[] initialBytes = characterString();
                byte[] SeparatorfieldIndex = separatorFieldIndexRegional(RegionalText, fontsize, BoardWidth);


                byte[] englishTextBytes = Encoding.BigEndianUnicode.GetBytes(RegionalText);


                // Get the termination bytes
                byte[] terminationBytes = ByteFormation.GetTerminationBytes();

                // Create a new array to hold the initial bytes, the gap code bytes, the text bytes, and the termination bytes
                byte[] resultBytes = new byte[initialBytes.Length + SeparatorfieldIndex.Length + englishTextBytes.Length + terminationBytes.Length];

                // Copy the initial bytes to the new array
                Array.Copy(initialBytes, 0, resultBytes, 0, initialBytes.Length);

                // Copy the gap code bytes to the new array
                Array.Copy(SeparatorfieldIndex, 0, resultBytes, initialBytes.Length, SeparatorfieldIndex.Length);


                // Copy the English text bytes to the new arra
                Array.Copy(englishTextBytes, 0, resultBytes, initialBytes.Length + SeparatorfieldIndex.Length, englishTextBytes.Length);

                // Copy the termination bytes to the end of the new array
                Array.Copy(terminationBytes, 0, resultBytes, initialBytes.Length + SeparatorfieldIndex.Length + englishTextBytes.Length, terminationBytes.Length);

                return resultBytes;

            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }

        public static byte[] GetEnglishBytes(string EnglishText, int fontsize, int BoardWidth)
        {
            try
            {


                byte[] initialBytes = characterString();

                byte[] gapCodeBytes = GapCode(EnglishText, fontsize, BoardWidth);




                byte[] englishTextBytes = Encoding.BigEndianUnicode.GetBytes(EnglishText);



                byte[] terminationBytes = ByteFormation.GetTerminationBytes();

                byte[] resultBytes = new byte[initialBytes.Length + gapCodeBytes.Length + englishTextBytes.Length + terminationBytes.Length];


                Array.Copy(initialBytes, 0, resultBytes, 0, initialBytes.Length);


                Array.Copy(gapCodeBytes, 0, resultBytes, initialBytes.Length, gapCodeBytes.Length);



                Array.Copy(englishTextBytes, 0, resultBytes, initialBytes.Length + gapCodeBytes.Length, englishTextBytes.Length);


                Array.Copy(terminationBytes, 0, resultBytes, initialBytes.Length + gapCodeBytes.Length + englishTextBytes.Length, terminationBytes.Length);

                return resultBytes;
            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }
        public static byte[] GetEnglishBytestruecolorAgdb(string EnglishText, int fontsize, int BoardWidth)
        {
            try
            {

                byte[] initialBytes = BaseClass.OvdIvdcharacterString;
                byte[] gapCodeBytes = GapCode(EnglishText, fontsize, BoardWidth);


                // Convert the English text to Unicode byte array
                //  byte[] englishTextBytes = Encoding.Unicode.GetBytes(EnglishText);

                byte[] englishTextBytes = Encoding.BigEndianUnicode.GetBytes(EnglishText);


                // Get the termination bytes
                byte[] terminationBytes = ByteFormation.GetTerminationBytes();
                // Create a new array to hold the initial bytes, the gap code bytes, the text bytes, and the termination bytes
                byte[] resultBytes = new byte[initialBytes.Length + gapCodeBytes.Length + englishTextBytes.Length + terminationBytes.Length];

                // Copy the initial bytes to the new array
                Array.Copy(initialBytes, 0, resultBytes, 0, initialBytes.Length);

                // Copy the gap code bytes to the new array
                Array.Copy(gapCodeBytes, 0, resultBytes, initialBytes.Length, gapCodeBytes.Length);


                // Copy the English text bytes to the new arra
                Array.Copy(englishTextBytes, 0, resultBytes, initialBytes.Length + gapCodeBytes.Length, englishTextBytes.Length);

                // Copy the termination bytes to the end of the new array
                Array.Copy(terminationBytes, 0, resultBytes, initialBytes.Length + gapCodeBytes.Length + englishTextBytes.Length, terminationBytes.Length);

                return resultBytes;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;
        }
        public static byte[] GetHindiBytes(string HindiText, int fontsize, int BoardWidth)
        {
            try
            {


                // Initialize hindiUnicodeBytes with the values from CharacterString()
                byte[] initialBytes = characterString();
                byte[] gapCodeBytes = GapCodeHindi(HindiText, fontsize, BoardWidth);

                // Convert the Hindi text to Unicode byte array (using BigEndianUnicode)
                byte[] hindiTextBytes = Encoding.BigEndianUnicode.GetBytes(HindiText);

                byte[] terminationBytes = ByteFormation.GetTerminationBytes();
                // Create a new array to hold the initial bytes, the gap code bytes, the text bytes, and the termination bytes
                byte[] resultBytes = new byte[initialBytes.Length + gapCodeBytes.Length + hindiTextBytes.Length + terminationBytes.Length];

                // Copy the initial bytes to the new array
                Array.Copy(initialBytes, 0, resultBytes, 0, initialBytes.Length);

                // Copy the gap code bytes to the new array
                Array.Copy(gapCodeBytes, 0, resultBytes, initialBytes.Length, gapCodeBytes.Length);

                // Copy the Hindi text bytes to the new array
                Array.Copy(hindiTextBytes, 0, resultBytes, initialBytes.Length + gapCodeBytes.Length, hindiTextBytes.Length);

                // Copy the termination bytes to the end of the new array
                Array.Copy(terminationBytes, 0, resultBytes, initialBytes.Length + gapCodeBytes.Length + hindiTextBytes.Length, terminationBytes.Length);

                return resultBytes;
            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return null;

        }



        public static string[] ConvertToUnicodeStrings(string englishText)
        {
            string[] unicodeStrings = new string[englishText.Length];

            for (int i = 0; i < englishText.Length; i++)
            {
                // Convert each character to its corresponding Unicode value
                int unicodeValue = char.ConvertToUtf32(englishText, i);

                // Convert the Unicode value to a hexadecimal string
                unicodeStrings[i] = $"{unicodeValue:X2}";
            }

            return unicodeStrings;
        }

        public static string[] ConvertToHindiUnicodeStrings(string HindiText)
        {
            string[] unicodeStrings = new string[HindiText.Length];

            for (int i = 0; i < HindiText.Length; i++)
            {
                // Convert each character to its corresponding Unicode value
                int unicodeValue = char.ConvertToUtf32(HindiText, i);

                // Convert the Unicode value to a hexadecimal string
                unicodeStrings[i] = $"{unicodeValue:X2}";
            }

            return unicodeStrings;
        }
        public static List<string> GetUnicodeCombinationsList(string inputString)
        {



            StringInfo stringInfo = new StringInfo(inputString);
            var combinationsList = new List<string>();
            try
            {

                for (int i = 0; i < stringInfo.LengthInTextElements; i++)
                {
                    string textElement = stringInfo.SubstringByTextElements(i, 1);
                    List<string> unicodeBytesList = new List<string>();

                    for (int j = 0; j < textElement.Length; j++)
                    {
                        char character = textElement[j];
                        byte unicodeByte = (byte)character;
                        unicodeBytesList.Add($"{unicodeByte:X2}");
                    }

                    // Join the Unicode bytes with a comma if there are multiple bytes
                    string combinedBytes = string.Join(",", unicodeBytesList);
                    combinationsList.Add(combinedBytes);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return combinationsList;
        }
        public static void GetEnglishLength(string EnglishText, int fontSize)
        {
            fontSize = GetFontsize(fontSize);
            var TrainNamebytes = EnglishText.ToCharArray();
            DataTable Chartable = new DataTable();
            Chartable.Columns.Add("id", typeof(int));
            Chartable.Columns.Add("Character", typeof(string));
            for (int i = 0; i < TrainNamebytes.Length; i++)
            {

                Chartable.Rows.Add(i + 1, TrainNamebytes[i]);
            }
            HubConfigurationDb.getbitmaplength(fontSize, Chartable, 1);

        }




        public static int GetEnglishBitmapLength(string EnglishText, int fontSize)
        {

            int Z = 0;
            int len = 0;
            try
            {

                string[] unicodeStrings = ConvertToUnicodeStrings(EnglishText);

                // GetEnglishLength(EnglishText, fontSize);

                DataTable EnglishUnicodes = HubConfigurationDb.GetEnglishBitMap(fontSize);

                // Check if the DataTable contains the necessary column
                if (EnglishUnicodes.Columns.Contains("Unicodes"))
                {
                    // Iterate through each character in the English text
                    foreach (string c in unicodeStrings)
                    {

                        // Iterate through each row in the DataTable
                        foreach (DataRow row in EnglishUnicodes.Rows)
                        {
                            // Get the Unicode value from the current row
                            string unicodeValue = row["Unicodes"].ToString();

                            // Check if the current Unicode value matches the character
                            if (c == unicodeValue)
                            {
                                Z++;
                                // Get the length of the Unicode character from the DataTable and add it to the total length
                                int bitLength;
                                if (int.TryParse(row["BitmapLength"].ToString(), out bitLength))
                                {
                                    len += bitLength;
                                }
                                break; // Exit the inner loop once the match is found
                            }
                        }
                    }
                }
                else
                {

                }

            }

            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return len;
        }
        public static int GetHindiBitmapLength(string HindiText, int fontSize)
        {
            int len = 0;
            try
            {

                List<string> unicodeStrings = GetUnicodeCombinationsList(HindiText);
                // Get the DataTable with Hindi Unicode data based on font size
                DataTable HindiUnicodes = HubConfigurationDb.GetHindiBitMap(fontSize);

                // Check if the DataTable contains the necessary column
                if (HindiUnicodes.Columns.Contains("Unicodes"))
                {
                    // Iterate through each Unicode string
                    foreach (string unicodeString in unicodeStrings)
                    {
                        // Iterate through each row in the DataTable
                        foreach (DataRow row in HindiUnicodes.Rows)
                        {
                            // Get the Unicode value from the current row
                            string unicodeValue = row["Unicodes"].ToString();

                            // Check if the current Unicode value matches the Unicode string
                            if (unicodeString == unicodeValue)
                            {
                                // Get the length of the Unicode character from the DataTable and add it to the total length
                                if (int.TryParse(row["BitmapLength"].ToString(), out int bitLength))
                                {
                                    len += bitLength;
                                }
                                break; // Exit the inner loop once the match is found
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return len;
        }
        public static int GetRegionalBitmapLength(string RegionalText, int fontSize)
        {


            int len = 0;
            int reggapLength = 0;
            string length = "";
            string unicodes = "";
            try
            {

                List<string> unicodeStrings = GetUnicodeRegional(RegionalText);
                int reggapcode = Convert.ToInt32(BaseClass.regionalGapCode.ToString());
                reggapLength = (unicodeStrings.Count() * reggapcode) * 2;
                DataTable HindiUnicodes = HubConfigurationDb.GetRegionalBitMap(fontSize);
                int Count = 0;

                if (HindiUnicodes.Columns.Contains("Unicodes"))
                {

                    foreach (string unicodeString in unicodeStrings)
                    {

                        foreach (DataRow row in HindiUnicodes.Rows)
                        {

                            string unicodeValue = row["Unicodes"].ToString();


                            if (unicodeString == unicodeValue)
                            {

                                if (int.TryParse(row["BitmapLength"].ToString(), out int bitLength))
                                {
                                    len += bitLength;
                                    length = length + "," + bitLength;
                                    unicodes = unicodes + "/" + unicodeString;
                                    Count++;
                                }
                                break;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return len + reggapLength;
        }

       
        public static string[] LocalTextSplit(string str)
        {
            HubConfigurationDb.FillAllDatasetLocal();
            string[] empaa = new string[1];
            try
            {
                if (str == "")
                {

                    // return "";
                }
                bool ConstantsFlagLocal = false;
                bool MatrasFlagLocal = false;
                bool ViramaFlagLocal = false;

                char[] strsplt = str.ToCharArray();
                string[] CharsArry = new string[strsplt.Length - 1 + 1];
                int Chinc = 0;

                string matras = "";
                string viram = "";
                string conts = "";
                for (int i = 0; i <= str.Length - 1; i++)
                {
                    try
                    {
                        //string myText = strsplt[i].ToString();
                        //string unicode = "" ;//= Convert.ToString(Strings.AscW(myText));
                        //string unistr = "";//= System.Convert.ToString(Conversion.Hex(unicode));
                        string myText = strsplt[i].ToString();
                        byte[] bytes = System.Text.Encoding.Unicode.GetBytes(myText);
                        //bytes.Reverse();
                        string unicode = BitConverter.ToString(bytes);
                        string[] splitarr = unicode.Split('-');
                        Array.Reverse(splitarr);

                        string unistr = splitarr[0] + splitarr[1];

                        for (int c = 0; c <= HubConfigurationDb.DScLocal.Tables[0].Rows.Count - 1; c++)
                        {
                            if ((unistr == HubConfigurationDb.DScLocal.Tables[0].Rows[c][1].ToString()))
                            {
                                ConstantsFlagLocal = true;
                                break;
                            }
                        }

                        for (int m = 0; m <= HubConfigurationDb.DSmLocal.Tables[0].Rows.Count - 1; m++)
                        {
                            if ((unistr == HubConfigurationDb.DSmLocal.Tables[0].Rows[m][1].ToString()))
                            {
                                MatrasFlagLocal = true;
                                break;
                            }
                        }

                        for (int v = 0; v <= HubConfigurationDb.DSvLocal.Tables[0].Rows.Count - 1; v++)
                        {
                            if ((unistr == HubConfigurationDb.DSvLocal.Tables[0].Rows[v][1].ToString()))
                            {
                                ViramaFlagLocal = true;
                                break;
                            }
                        }

                        if ((ConstantsFlagLocal == true))
                        {
                            if ((i == 0))
                            {
                                conts = myText;
                            }

                            else
                            {
                                if ((myText == " "))
                                {
                                    conts += viram;
                                    CharsArry[Chinc] = conts;
                                    Chinc = Chinc + 1;
                                    // MessageBox.Show(conts)
                                    conts = myText;
                                    viram = "";
                                }

                                else
                                {
                                    if ((viram == ""))
                                    {
                                        CharsArry[Chinc] = conts;
                                        Chinc = Chinc + 1;
                                        // MessageBox.Show(conts)
                                        conts = myText;
                                    }
                                    else
                                    {
                                        string temp = myText;
                                        viram += temp;
                                        conts += viram;
                                        viram = "";
                                    }
                                }
                            }
                            ConstantsFlagLocal = false;
                        }
                        else
                        {
                            if ((ViramaFlagLocal == true))
                            {
                                viram = myText;
                                ViramaFlagLocal = false;

                                if (i == str.Length - 1)
                                {
                                    conts += viram; // 26.4.11
                                }

                            }
                            else
                            {
                                if ((MatrasFlagLocal == true))
                                {

                                    matras = myText;
                                    conts += matras;
                                    MatrasFlagLocal = false;
                                }
                            }
                        }

                        if (i == str.Length - 1)
                        {
                            CharsArry[Chinc] = conts;
                            Chinc = Chinc + 1;
                        } // 26.4.11
                    }

                    catch (Exception ex)
                    {
                        Server.LogError(ex.Message);
                    }
                }
                // Removing Notthings from CharsArry & Moved to TempCharsArry
                int Lch = CharsArry.Length; // - 1'0

                for (int ch = 0; ch <= CharsArry.Length - 1; ch++)
                {
                    if (CharsArry[ch] == null)
                    {
                        Lch = ch;
                        break;
                    }
                }
                string[] TempCharsArry = new string[Lch - 1 + 1];
                Array.Copy(CharsArry, 0, TempCharsArry, 0, TempCharsArry.Length);
                return TempCharsArry;
            }
            catch (Exception ex)
            {
                return empaa;
            }
        }


        public static List<string> GetUnicodeRegional(string inputString)
        {
            string[] TempCharsArry = LocalTextSplit(inputString);
            var combinationsList = new List<string>();
            string characters = "";
            try
            {
                foreach (var textElement in TempCharsArry)
                {
                    List<string> unicodeBytesList = new List<string>();

                    for (int j = 0; j < textElement.Length; j++)
                    {
                        char character = textElement[j];
                        if (character != ' ')
                        {
                            characters = characters + "," + character;
                            byte unicodeByte = (byte)character;
                            unicodeBytesList.Add($"{unicodeByte:X2}");
                        }
                        else
                        {
                            characters = characters + "," + character;
                            byte unicodeByte = (byte)character;
                            unicodeBytesList.Add($"{unicodeByte:X4}");
                        }

                    }
                    // Join the Unicode bytes with a comma if there are multiple bytes
                    string combinedBytes = string.Join(",", unicodeBytesList);
                    combinationsList.Add(combinedBytes);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

            return combinationsList;
        }


        public static int spaceCount(string word)
        {
            string[] words = word.Split(' ');
            return words.Length - 1;
        }


        public static byte[] characterString()
        {
            byte[] characterString = { 0x00, 0x00, 0x00, 0x00, 0x01 };
            return characterString;
        }

        public static int CountSpaces(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            return input.Count(c => c == ' ');
        }

        public static byte[] GapCodeHindi(string HindiText, int fontsize, int BoardWidth)
        {
            HindiText = new string(HindiText.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
            fontsize = GetFontsize(fontsize);
            int count = CountSpaces(HindiText);
            int length = GetHindiBitmapLength(HindiText, fontsize);
            int startpostion = GetStartPositionH(length, BoardWidth) + (count * 4);
            byte[] byte2and3 = GetTwoBytesFromInt(startpostion);
            byte[] GapCode = new byte[] { 0xE7, 0x00 };
            Array.Resize(ref GapCode, GapCode.Length + 2);
            GapCode[2] = byte2and3[0];
            GapCode[3] = byte2and3[1];
            return GapCode;
        }
        //public static byte[] GapCodeRegional(string RegionalText, int fontsize, int BoardWidth)
        //{
        //    RegionalText = new string(RegionalText.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
        //    // byte[] GapCode = new byte[] { 0xE7, 0x00, 0x00, 0x03 };
        //    fontsize = GetFontsize(fontsize);
        //    int count = CountSpaces(RegionalText);
        //    int length = GetRegionalBitmapLength(RegionalText, fontsize);
        //    int startpostion = GetStartPositionH(length, BoardWidth) + (count * 4);
        //    byte[] byte2and3 = GetTwoBytesFromInt(startpostion);
        //    byte[] GapCode = new byte[] { 0xE7, 0x00 };
        //    Array.Resize(ref GapCode, GapCode.Length + 2);
        //    GapCode[2] = byte2and3[0];
        //    GapCode[3] = byte2and3[1];

        //    return GapCode;
        //}

        public static byte[] GapCodeRegional(string RegionalText, int fontsize, int BoardWidth)
        {
            //RegionalText = new string(RegionalText.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
            // byte[] GapCode = new byte[] { 0xE7, 0x00, 0x00, 0x03 };
            fontsize = GetFontsize(fontsize);
            //int count = CountSpaces(RegionalText)*0;
            int length = GetRegionalBitmapLength(RegionalText, fontsize);

            int startpostion = GetStartPositionH(length, BoardWidth);
            byte[] byte2and3 = GetTwoBytesFromInt(startpostion);
            byte[] GapCode = new byte[] { 0xE7, 0x00 };
            Array.Resize(ref GapCode, GapCode.Length + 2);
            GapCode[2] = byte2and3[0];
            GapCode[3] = byte2and3[1];

            return GapCode;
        }

        public static int GetFontsize(int fontid)
        {
            if (fontid == 0)
            {
                return 7;
            }
            else if (fontid == 1)
            {
                return 8;
            }
            else if (fontid == 2)
            {
                return 10;
            }
            else if (fontid == 3)
            {
                return 12;
            }
            else if (fontid == 4)
            {
                return 14;
            }
            else if (fontid == 5)
            {
                return 16;
            }
            else
            {
                return 14;
            }
        }


        public static byte[] GapCode(string EnglishText, int fontsize, int BoardWidth)
        {
            byte[] GapCode = new byte[] { 0xE7, 0x00 };
            try
            {
                fontsize = GetFontsize(fontsize);
                int count = CountSpaces(EnglishText) * 2;
                EnglishText = new string(EnglishText.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                int length = GetEnglishBitmapLength(EnglishText, fontsize);
                int startpostion = GetStartPosition(length, BoardWidth);
                if (startpostion < 0)
                    startpostion = 1;
                byte[] byte2and3 = GetTwoBytesFromInt(startpostion);

                Array.Resize(ref GapCode, GapCode.Length + 2);
                GapCode[2] = byte2and3[0];
                GapCode[3] = byte2and3[1];

            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return GapCode;
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
        public static byte[] separatorFieldIndexRegional(string RegionalText, int fontsize, int BoardWidth)
        {

            // byte[] separator = new byte[] { 0xE7, 0x00, 0x00, 0x03 };
            fontsize = GetFontsize(fontsize);

            int length = GetRegionalBitmapLength(RegionalText, fontsize);

            int startpostion = GetStartPositionH(length, BoardWidth);
            byte[] byte2and3 = GetTwoBytesFromInt(startpostion);
            byte[] Separator = new byte[] { 0xE7, 0x00 };
            Array.Resize(ref Separator, Separator.Length + 2);
            Separator[2] = byte2and3[0];
            Separator[3] = byte2and3[1];

            return Separator;
        }

        public static int GetStartPosition(int bitlength, int boardWidth)
        {
            int actualbitLength = bitlength / 2;//two bits contain one line
            int startPostion = 0;
            if (actualbitLength >= boardWidth)
            {
                startPostion = 1;
            }
            else
            {
                int halfBWidth = boardWidth / 2;
                int halfbitlength = actualbitLength / 2;
                startPostion = (halfBWidth - halfbitlength);
            }

            return startPostion;
        }
        public static int GetStartPositionH(int bitlength, int boardWidth)
        {
            int actualbitLength = bitlength / 2;//two bits contain one line
            int startPostion = 0;
            if (actualbitLength >= boardWidth)
            {
                startPostion = 1;
            }
            else
            {
                int halfBWidth = boardWidth / 2;
                int halfbitlength = actualbitLength / 2;
                startPostion = (halfBWidth - halfbitlength);
            }
            return startPostion;
        }

        public static int GetStartPositionR(int bitlength, int boardWidth)
        {
            int actualbitLength = bitlength / 2;//two bits contain one line
            int startPostion = 0;
            if (actualbitLength >= boardWidth)
            {
                startPostion = 1;
            }
            else
            {
                int halfBWidth = boardWidth / 2;
                int halfbitlength = actualbitLength / 2;
                startPostion = (halfBWidth - halfbitlength);
            }
            return startPostion;
        }

        public static string GetUnicodeString(byte[] unicodeBytes)
        {
            // Convert the byte array to a string using Unicode encoding
            string unicodeString = Encoding.Unicode.GetString(unicodeBytes);
            return unicodeString;
        }
        public static byte GetTenthByte(string displayEffect)
        {
            // Convert the displayEffect string to an integer
            int DEffect = Convert.ToInt32(displayEffect);

            // Convert the integer to an 8-bit binary string
            string DEffectBinary = ConvertDecimalToBinary(DEffect);

            // Convert the 8-bit binary string to a byte
            byte resultByte = Convert.ToByte(DEffectBinary, 2);

            return resultByte;
        }
        public static byte GetTwelvethByte(int DelayTime)
        {
            int Time = DelayTime;
            //if (DelayTime == 0)
            //{
            //    Time = 10;
            //}
            //else if(DelayTime==1)
            //{
            //    Time = 20;
            //}
            //else
            //{
            //    Time = 30;
            //}

            // Convert the displayEffect string to an integer
            int DTime = Convert.ToInt32(Time);

            // Convert the integer to an 8-bit binary string
            string DTimeBinary = ConvertDecimalToBinary(DTime);

            // Convert the 8-bit binary string to a byte
            byte resultByte = Convert.ToByte(DTimeBinary, 2);

            return resultByte;
        }

        public static string ConvertDecimalToBinary(int decimalValue)
        {
            string binaryValue = Convert.ToString(decimalValue, 2); // Convert decimal to binary
            string paddedBinaryValue = binaryValue.PadLeft(8, '0'); // Ensure the binary string is 8 bits
            return paddedBinaryValue;
        }

        public static byte GetNineByte(string videotype, string letterSpeed)
        {
            string originalBinary = "00000000";

            // Convert the videotype to an integer and set the first bit to '1'
            int VType = Convert.ToInt32(videotype);
            originalBinary = "00000000";

            // Convert letterSpeed to binary
            int speed = Convert.ToInt32(letterSpeed);
            string speedBinary = ByteFormation.convertDecimalToBinary(speed);

            // Append speedBinary to originalBinary starting at position 0
            int positionSpeed = 0;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, speedBinary, positionSpeed);

            // Convert the final binary string to a byte
            byte resultByte = Convert.ToByte(originalBinary, 2);

            return resultByte;
        }
        public static byte GetEleventhByte(string lettergap, int fontsize)
        {
            string originalBinary = "00000000";


            // Convert letterSpeed to binary
            int Gap = Convert.ToInt32(lettergap);
            string GapBinary = ByteFormation.convertDecimalToBinary(Gap);

            // Append speedBinary to originalBinary starting at position 0
            int positionGap = 0;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, GapBinary, positionGap);

            string fontsizeBinary = ByteFormation.convertDecimalToBinary(fontsize);

            // Append speedBinary to originalBinary starting at position 0
            int positionfontsizeBinary = 3;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, fontsizeBinary, positionfontsizeBinary);


            // Convert the final binary string to a byte
            byte resultByte = Convert.ToByte(originalBinary, 2);

            return resultByte;
        }

        public static void CGDBDefaultDataPacketINTERAPROBALITY(
          int pkeyCoachConfig, int fkeyCDCID, int pdcPort, string videoType, string letterGap, string letterSpeed, string displayEffect,
          int fontSize, string formatType, int noOfCoaches, string defaultPlatformNo,
               int eraseTime, int delayTime, string defaultEnglish, string defaultHindi, string divCode, int packetIdentifier, string pdcIp, int mainEthernetPort, DataTable cgdbIp)
        {
            try
            {



                // Call the GetIpAddress method and store the result in a List<string>
                List<string> ipAddressList = GetIpAddress(cgdbIp);



                // Example output of the list (for debugging purposes)
                foreach (string ipaddress in ipAddressList)
                {



                    Byte[] sendbyte = ByteFormation.CommonBytes(ipaddress, packetIdentifier);
                    if (sendbyte == null)
                    {
                        return;
                    }
                    Array.Resize(ref sendbyte, sendbyte.Length + 2);
                    int sodDataType = 2; //sod and defult and window
                    sendbyte[10] = (byte)ArecaIPIS.Classes.Board.DefaultData;  //packet Type
                    sendbyte[11] = 2;  //Sod

                    byte[] DataPacket = CgdbWindowFormation(packetIdentifier, letterSpeed, videoType,
                                                    displayEffect, fontSize, letterGap, delayTime,
                            defaultEnglish, divCode, defaultHindi);


                    Array.Resize(ref sendbyte, sendbyte.Length + DataPacket.Length + 4);

                    int z = 12;
                    for (int i = 0; i < DataPacket.Length; i++)
                    {
                        sendbyte[z] = DataPacket[i];
                        z++;

                    }

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


                    byte[] trimmedfinalPacket = ByteFormation.RemoveFirstAndLast6(finalPacket);
                    Server.SendMessageToClient(ipaddress, trimmedfinalPacket);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }



        }

        public static void CGDBDefaultDataPacket(
              int pkeyCoachConfig, int fkeyCDCID, int pdcPort, string videoType, string letterGap, string letterSpeed, string displayEffect,
              int fontSize, string formatType, int noOfCoaches, string defaultPlatformNo,
                   int eraseTime, int delayTime, string defaultEnglish, string defaultHindi, string divCode, int packetIdentifier, string pdcIp, int mainEthernetPort, DataTable cgdbIp)
        {
            try
            {



                // Call the GetIpAddress method and store the result in a List<string>
                List<string> ipAddressList = GetIpAddress(cgdbIp);



                // Example output of the list (for debugging purposes)
                foreach (string ipaddress in ipAddressList)
                {



                    Byte[] sendbyte = ByteFormation.CommonBytes(ipaddress, packetIdentifier);
                    //if (sendbyte == null)
                    //{
                    //    return;
                    //}
                    Array.Resize(ref sendbyte, sendbyte.Length + 2);
                    int sodDataType = 2; //sod and defult and window
                    sendbyte[10] = (byte)ArecaIPIS.Classes.Board.DefaultData;  //packet Type
                    sendbyte[11] = 2;  //Sod

                    byte[] DataPacket = CgdbWindowFormation(packetIdentifier, letterSpeed, videoType,
                                                    displayEffect, fontSize, letterGap, delayTime,
                            defaultEnglish, divCode, defaultHindi);


                    Array.Resize(ref sendbyte, sendbyte.Length + DataPacket.Length + 4);

                    int z = 12;
                    for (int i = 0; i < DataPacket.Length; i++)
                    {
                        sendbyte[z] = DataPacket[i];
                        z++;

                    }

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



                    Server.SendMessageToClient(ipaddress, finalPacket);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }



        }

        public static List<string> GetIpAddress(DataTable cgdbIp)
        {
            List<string> Ipaddresscgdb = new List<string>();

            foreach (DataRow row in cgdbIp.Rows)
            {
                Ipaddresscgdb.Add(row["DgvIpAddress"].ToString());
            }

            return Ipaddresscgdb;
        }


    }
}
