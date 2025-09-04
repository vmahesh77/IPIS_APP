using ArecaIPIS.Forms.HomeForms.ReportsForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmReports : Form
    {


        // private Form currentForm = null;

        private frmIndex parentForm;
        public frmReports(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }

        public frmReports()
        {
            InitializeComponent();



            //int arcSize = 15;
            //frmReports.ApplyRoundedCorners(btnTaddb, arcSize);
            //frmReports.ApplyRoundedCorners(btnCdot, arcSize);
            //frmReports.ApplyRoundedCorners(btnIVD, arcSize);
            //frmReports.ApplyRoundedCorners(btnOVD, arcSize);
            //frmReports.ApplyRoundedCorners(btnCGDB, arcSize);
            //frmReports.ApplyRoundedCorners(btnAnnouncement, arcSize);
            //frmReports.ApplyRoundedCorners(btnAGDB, arcSize);
            //frmReports.ApplyRoundedCorners(btnAppStatus, arcSize);
            //frmReports.ApplyRoundedCorners(btnPDC, arcSize);
            //frmReports.ApplyRoundedCorners(btnDataLog, arcSize);
            //frmReports.ApplyRoundedCorners(btnErrorLog, arcSize);
            //frmReports.ApplyRoundedCorners(btnLinkCheckLog, arcSize);
            //frmReports.ApplyRoundedCorners(btnPlatformChange, arcSize);
        }
        //public static void ApplyRoundedCorners(Button button, int arcSize)
        //{
        //    GraphicsPath path = new GraphicsPath();
        //    path.AddArc(0, 0, arcSize * 2, arcSize * 2, 180, 90);
        //    path.AddArc(button.Width - arcSize * 2, 0, arcSize * 2, arcSize * 2, 270, 90);
        //    path.AddArc(button.Width - arcSize * 2, button.Height - arcSize * 2, arcSize * 2, arcSize * 2, 0, 90);
        //    path.AddArc(0, button.Height - arcSize * 2, arcSize * 2, arcSize * 2, 90, 90);
        //    path.CloseAllFigures();
        //    button.Region = new Region(path);

        //}
        //public void BorderStyle()
        // {

        //     btnTaddb.ForeColor = Color.White;
        //     btnTaddb.FlatAppearance.BorderSize = 1;
        //     btnCdot.ForeColor = Color.White;
        //     btnCdot.FlatAppearance.BorderSize = 1;
        //     btnIVD.ForeColor = Color.White;
        //     btnIVD.FlatAppearance.BorderSize = 1;
        //     btnOVD.ForeColor = Color.White;
        //     btnOVD.FlatAppearance.BorderSize = 1;
        //     btnCGDB.ForeColor = Color.White;
        //     btnCGDB.FlatAppearance.BorderSize = 1;
        //     btnAnnouncement.ForeColor = Color.White;
        //     btnAnnouncement.FlatAppearance.BorderSize = 1;
        //     btnAGDB.ForeColor = Color.White;
        //     btnAGDB.FlatAppearance.BorderSize = 1;
        //     btnAppStatus.ForeColor = Color.White;
        //     btnAppStatus.FlatAppearance.BorderSize = 1;
        //     btnPDC.ForeColor = Color.White;
        //     btnPDC.FlatAppearance.BorderSize = 1;
        //     btnDataLog.ForeColor = Color.White;
        //     btnDataLog.FlatAppearance.BorderSize = 1;
        //     btnErrorLog.ForeColor = Color.White;
        //     btnErrorLog.FlatAppearance.BorderSize = 1;
        //     btnLinkCheckLog.ForeColor = Color.White;
        //     btnLinkCheckLog.FlatAppearance.BorderSize = 1;
        //     btnPlatformChange.ForeColor = Color.White;
        //     btnPlatformChange.FlatAppearance.BorderSize = 1;
        // }




        private Form currentForm;
        private void OpenFormInPanel(Form form)
        {
            if (currentForm != null)
            {
                currentForm.Close();
                currentForm.Dispose();
            }

            currentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlMainReport.Controls.Add(form);
            form.Show();

        }
        private void btnTaddb_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmTaddbReport());

        }

        private void btnCdot_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmCDOTReport());
        }

        private void btnIVD_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmIVDReport());
        }

        private void btnOVD_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmOVDReport());
        }

        private void btnCGDB_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmCGDBReport());
        }

        private void btnAnnouncement_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmAnnouncementReport());
        }

        private void btnAGDB_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmAGDBReport());
        }

        private void btnAppStatus_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmAppStatusReport());
        }

        private void btnPDC_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmPDCReport());
        }

        private void btnDataLog_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmDataLogReport());
        }

        private void btnErrorLog_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmErrorLogReport());
        }

        private void btnLinkCheckLog_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmLinkCheckLogReport());
        }

        private void btnPlatformChange_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmPlatformChangeReport());
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            // ActivateButton(sender);
            OpenFormInPanel(new frmTaddbReport());
            ActivateButton(btnTaddb);
        }
        private void btnNtesData_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmNtesReport());
        }
        private void ActivateButton(object sender)
        {
            // Change the background color of all buttons
            foreach (var button in new[] { btnTaddb, btnCdot, btnIVD, btnOVD, btnNtesData, btnCGDB, btnAnnouncement, btnAGDB, btnAppStatus, btnPDC, btnDataLog, btnErrorLog, btnLinkCheckLog, btnPlatformChange, btnDatabaseModificationReport })
            {
                button.BackColor = Color.DodgerBlue;
            }

            // Change the background color of the clicked button
            var clickedButton = (Button)sender;
            clickedButton.BackColor = Color.DarkOrange;
        }

        private void btnDatabaseModificationReport_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmDatabaseModificationReport());
        }
    }
}
