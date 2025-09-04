using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmNetwork : Form
    {
        private Form currentForm = null;

        public frmNetwork()
        {
            InitializeComponent();
        }

        private frmIndex parentForm;

        public frmNetwork(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }
        private void btnCds_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmNetWorkCds());
        }

        private void btnTADB_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmNetworkTadb());
        }

        private void btnCgdb_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmNetworkCgdb());
        }

        private void btnivdovd_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmNetworkIvdOvd());
        }

        private void ActivateButton(object sender)
        {
            // Change the background color of all buttons
            foreach (var button in new[] { btnCds, btnTADB, btnCgdb, btnivdovd })
            {
                button.BackColor = Color.Green;
            }

            // Change the background color of the clicked button
            var clickedButton = (Button)sender;
            clickedButton.BackColor = Color.DeepSkyBlue;
        }

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
            panBoardforms.Controls.Add(form);
            form.Show();
        }

        private void frmNetwork_Load(object sender, EventArgs e)
        {
            ActivateButton(btnCds);
            OpenFormInPanel(new frmNetWorkCds());
        }
    }
}
