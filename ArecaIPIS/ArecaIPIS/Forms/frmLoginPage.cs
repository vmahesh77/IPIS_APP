using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms.UserForms;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmLoginPage : Form
    {
        public frmLoginPage()
        {
            InitializeComponent();
        }
        private frmIndex parentForm;
        public frmLoginPage(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            txtUsername.Multiline = true;
            txtUsername.Width = 214;
            txtUsername.Height = 35;
            txtPassword.Multiline = true;
            txtPassword.Width = 214;
            txtPassword.Height = 35;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {


                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                // Retrieve the users from the database
                DataTable usersdt = UserDb.GetUsers();

                // Check if the provided username and password match any entry in the DataTable
                bool isAuthenticated = false;

                foreach (DataRow row in usersdt.Rows)
                {
                    if (row["Login"].ToString() == username && DecodeData(row["Password"].ToString()) == password && Convert.ToBoolean(row["Active"].ToString()) == true)
                    {
                        BaseClass.UserName = row["Login"].ToString();
                        BaseClass.Userrole = Convert.ToInt32(row["Role"].ToString());
                        BaseClass.Userrolename = frmCreateUser.GetuserLevel(BaseClass.Userrole);

                        int userid = Convert.ToInt32(row["UserID"]);
                        string LoginUser = row["Login"].ToString();
                        ReportDb.ApplogInReport(userid, LoginUser);
                        isAuthenticated = true;
                        break;
                    }
                }
                if (isAuthenticated)
                {
                    // Hide the login form
                    this.Hide();

                    // Check if the frmIndex form is already open
                    frmIndex frmhub;
                    Form mainForm = Application.OpenForms["frmIndex"];

                    if (mainForm != null)
                    {
                        // If the form is already open, cast it to frmIndex and load the forms
                        frmhub = (frmIndex)mainForm;
                        frmhub.LoadForms();
                    }
                    else
                    {
                        // If the form is not open, create a new instance and load the forms
                        frmhub = new frmIndex();
                        frmhub.LoadForms();
                        frmhub.Show();
                    }
                }
                else
                {
                    // Show an error message if the login fails
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public string DecodeData(string encodedData)
        {
            try
            {
                byte[] data = Convert.FromBase64String(encodedData);
                return System.Text.Encoding.UTF8.GetString(data);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return string.Empty;
            }
        }
        private void btnpicEye_Click(object sender, EventArgs e)
        {
            // Toggle the PasswordChar property
            if (txtPassword.PasswordChar == '●')
            {
                txtPassword.PasswordChar = '\0'; // Show the actual password characters
                                                 //  btnpicEye.Image = Properties.Resources.eye_closed; // Change to closed eye icon
            }
            else
            {
                txtPassword.PasswordChar = '●'; // Hide the password characters
                                                //  btnpicEye.Image = Properties.Resources.eye_open; // Change to open eye icon
            }
        }
        public void MakeButtonRound(Button button)
        {
            GraphicsPath path = new GraphicsPath();

            int curveRadius = 20; // Radius for the top curves

            // Top-left curve
            path.AddArc(0, 0, curveRadius, curveRadius, 180, 90);

            // Top edge
            path.AddLine(curveRadius, 0, button.Width - curveRadius, 0);

            // Top-right curve
            path.AddArc(button.Width - curveRadius, 0, curveRadius, curveRadius, 270, 90);

            // Straight line down the right side
            path.AddLine(button.Width, curveRadius, button.Width, button.Height);

            // Straight line along the bottom
            path.AddLine(button.Width, button.Height, 0, button.Height);

            // Straight line up the left side
            path.AddLine(0, button.Height, 0, curveRadius);

            // Apply the custom shape to the button
            path.CloseFigure();
            button.Region = new Region(path);
        }
        private Timer _scrollTimer;    // Timer for scrolling
        private double _scrollStep = 6; // Step for label movement
        private double _currentPosition; // Track the current position

        public void StartScrollingLabel(Label label)
        {
            // Initialize the starting position
            _currentPosition = label.Left;

            // Initialize Timer if it's not already initialized
            if (_scrollTimer == null)
            {
                _scrollTimer = new Timer();
                _scrollTimer.Interval = 01; // Time interval for smooth scrolling (in milliseconds)
                _scrollTimer.Tick += (s, e) => ScrollLabel(label);
            }

            // Start the scrolling
            _scrollTimer.Start();
        }

        private void ScrollLabel(Label label)
        {
            if (label != null)
            {
                // Move the label to the left by the scroll step
                _currentPosition -= _scrollStep;

                // Update the label's position
                label.Left = (int)_currentPosition;

                // If the label has moved off-screen, reset it to the right side
                if (label.Right < 0)
                {
                    _currentPosition = this.Width;
                    label.Left = this.Width;
                }
            }
        }

        public void StopScrollingLabel()
        {
            _scrollTimer?.Stop(); // Stop the timer
        }


        public static string getVersion()
        {
            string version = "1.0.0.0";
            string LastUpdated = "";
            string StationName = "";
            DataTable dt = UserDb.GetVersion();
            foreach (DataRow row in dt.Rows)
            {
                version = row["Version"].ToString().Trim();
                LastUpdated = row["LastUpdatedDate"].ToString().Trim();
                StationName = row["StationName"].ToString().Trim();
                break;
            }
            return version;


        }

        private void frmLoginPage_Load(object sender, EventArgs e)
        {
            // Example usage in a Form
            //   AddCurvedBorder(panLogin, 20, Color.FromArgb(100, 0, 0, 0), 2);

            this.lblVersionNO.Text = getVersion();
            panLogin.BackColor = Color.FromArgb(100, 0, 0, 0);
            BaseClass.setAdminRoles();
            BaseClass.setAdminMenu();
            //StartScrollingLabel(label1);

            // MakeButtonRound(btnLogin);
        }

        private void BtnApplicationExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
     "Do you want to close the application?",
     "Confirm Exit",
     MessageBoxButtons.YesNo,
     MessageBoxIcon.Question
 );

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Closes the application
            }
        }

        private void btnMinize_Click(object sender, EventArgs e)
        {
            frmIndex IndexForm;
            Form mainForm = Application.OpenForms["frmIndex"];

            if (mainForm != null)
            {
                IndexForm = (frmIndex)mainForm;

            }
            else
            {
                IndexForm = new frmIndex();

            }
            IndexForm.miniMizeWindow();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void AddCurvedBorder(Panel panel, int cornerRadius, Color borderColor, int borderWidth)
        {
            // Attach a Paint event handler to the panel
            panel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Define a path for the curved edges
                using (var path = GetEdgeCurvedRectanglePath(panel.ClientRectangle, cornerRadius))
                {
                    // Optional: Draw the border
                    using (var pen = new Pen(borderColor, borderWidth))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            // Force the panel to redraw
            panel.Invalidate();
        }

        private System.Drawing.Drawing2D.GraphicsPath GetEdgeCurvedRectanglePath(Rectangle rect, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            int arcWidth = radius * 2;
            int arcHeight = radius * 2;

            // Top-left corner
            path.AddArc(rect.X, rect.Y, arcWidth, arcHeight, 180, 90);

            // Top-right corner
            path.AddArc(rect.Right - arcWidth, rect.Y, arcWidth, arcHeight, 270, 90);

            // Straight lines between corners
            path.AddLine(rect.Right, rect.Y + radius, rect.Right, rect.Bottom - radius);

            // Bottom-right corner
            path.AddArc(rect.Right - arcWidth, rect.Bottom - arcHeight, arcWidth, arcHeight, 0, 90);

            // Bottom-left corner
            path.AddArc(rect.X, rect.Bottom - arcHeight, arcWidth, arcHeight, 90, 90);

            // Straight line back to the top
            path.AddLine(rect.X, rect.Bottom - radius, rect.X, rect.Y + radius);

            path.CloseFigure();

            return path;
        }


    }
}
