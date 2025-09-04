using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading.Tasks;
using ArecaIPIS.Classes;
namespace ArecaIPIS.Forms.settingsForms
{
    public partial class frmSoftwareUpdate : Form
    {
        public frmSoftwareUpdate()
        {
            InitializeComponent();
        }

        private frmIndex parentForm;

        public frmSoftwareUpdate(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void rndUpdate_Click(object sender, EventArgs e)
        {
            string version = rctVersion.Text;  // Assuming rctVersion is the TextBox holding the current version
            string categoryName = "IPIS";
            string apiUrl = $"https://localhost:7026/api/CategoryDownload/download?categoryName={categoryName}&version={version}";

            AppUpdater app = new AppUpdater();
            app.UpdateApp(version, apiUrl);  // Call UpdateApp with the current version
        }

       
    }
}
