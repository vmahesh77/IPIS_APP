using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.settingsForms
{
    public partial class frmRedundencyPc : Form
    {
        public frmRedundencyPc()
        {
            InitializeComponent();
        }

        private frmIndex parentForm;

        public frmRedundencyPc(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }
        string databaseName = "ARECA_IPIS_DB";
        string backupFilePath = @"C:\ShareToAll\Redundency\BackUpDataBase\ARECA_IPIS_DB.bak"; // Path to store the backup locally
        static async Task<(string, List<string>)> GetHostNameAndIPAsync()
        {
            // Get the host name
            string hostName = Dns.GetHostName();

            // Get the IP addresses associated with the host name asynchronously
            IPHostEntry hostEntry = await Dns.GetHostEntryAsync(hostName);

            // Prepare a list to hold IP addresses
            List<string> ipAddresses = new List<string>();

            // Loop through the IP addresses and add them to the list
            foreach (var ip in hostEntry.AddressList)
            {
                ipAddresses.Add(ip.ToString());
            }

            return (hostName, ipAddresses);
        }

        static async Task<string> GetHostNameByIPAsync(string ipAddress)
        {
            try
            {
                if (ipAddress != null)
                {
                    IPHostEntry hostEntry = await Dns.GetHostEntryAsync(ipAddress);
                    return hostEntry.HostName;
                }
                return null;
            }
            catch (SocketException ex)
            {
                return $"Could not resolve host for IP {ipAddress}: {ex.Message}";
            }
        }

        private async void frmRedundencyPc_Load(object sender, EventArgs e)
        {
            ipAddressControlsystemaddressMaster.Text = Server.ipAdress;
            string slaveIp = Server.SlaveipAdress;
            ipAddressControlSlave.Text = slaveIp;
            string hostname = await GetHostNameByIPAsync(Server.ipAdress);
            lbMasterlHostId.Text = hostname;
            lblSlaveDestopId.Text = await GetHostNameByIPAsync(slaveIp);
        }

        private void btnGetDatabase_Click(object sender, EventArgs e)
        {
            InsertServerConfiguration(false, false, false);
            RedundencyDb.BackupDatabase(DbConnection.MasterconnectionString, databaseName, backupFilePath);
            InsertServerConfiguration(BaseClass.ServerMode, BaseClass.clientMode, BaseClass.ApplicationStatus);
            btnRestore.Enabled = true;
        }
        string ClientPath = @"C:\ShareToAll\Redundency\Areca\ARECA_IPIS_DB.bak";
        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                btnRestore.Enabled = false;
                Server.GetSlaveip();
                bool SlaveConnect = Server.IsIpAddressConnected(Server.SlaveipAdress);
                if (Transfer())
                {
                    string ftpHost = Server.SlaveipAdress;
                    string ftpUser = "ftpUsername";
                    string ftpPass = "ftpPassword";
                    string ftpFilePath = $"/Areca/{Path.GetFileName(backupFilePath)}"; // Path on client FTP server



                    if (SlaveConnect)
                    {

                        //  InsertServerConfiguration(false,false,false);
                        string SlaveconnectionString = DbConnection.GetSlaveConnectionRestoreString(Server.SlaveipAdress);
                        bool status = RedundencyDb.RestoreDatabaseOnClient(SlaveconnectionString, databaseName, ClientPath);



                        if (!status)
                        {
                            DbConnection.SlaveconnectionString = null;
                            frmIndex.GetSlaveStatusUpdate();
                        }
                        else
                        {

                            DbConnection.SlaveconnectionString = DbConnection.GetSlaveConnectionString(Server.SlaveipAdress);
                            frmIndex.GetSlaveStatusUpdate();
                            // RedundencyDb.InsertUpdateClientStatus(false, true, BaseClass.ApplicationStatus, Server.SlaveipAdress, Server.ipAdress);
                        }
                    }


                }
                else
                {
                    DbConnection.SlaveconnectionString = null;
                    frmIndex.GetSlaveStatusUpdate();
                }
            }
            catch (Exception Ex)
            {
                Server.LogError(Ex.ToString());
                DbConnection.SlaveconnectionString = null;
                frmIndex.GetSlaveStatusUpdate();
            }

        }

        public static void InsertServerConfiguration(bool serverstatus, bool clientstatus, bool applicationstatus)
        {
            try
            {
                // Get the slave IP address
                string clientIp = Server.SlaveipAdress;


                string serverIp = Server.ipAdress;
                if (string.IsNullOrEmpty(serverIp))
                {
                    serverIp = "192.168.0.254";
                }
                if (string.IsNullOrEmpty(clientIp))
                {
                    clientIp = "192.168.0.253";
                }

                RedundencyDb.InsertUpdateServerStatus(serverstatus, clientstatus, applicationstatus, serverIp, clientIp);
            }
            catch (Exception ex)
            {
                Server.LogError($"Error inserting server configuration: {ex.Message}");
            }
        }



        private bool Transfer()
        {
            bool filestatus = false;
            // localFilePath = @"C:\ShareToAll\Redundency\BackUpDataBase\ARECA_IPIS_DB.bak"; // Local file path to transfer
            string ftpHost = Server.SlaveipAdress;
            int ftpPort = 22; // FTP port, modify as required
            string remoteFolderPath = "/Areca"; // Remote folder on FTP server
            string ftpUri = $"ftp://{ftpHost}:{ftpPort}{remoteFolderPath}";

            try
            {
                EnsureFtpDirectoryExists(ftpUri); // Ensure the folder exists on FTP server
                filestatus = UploadFileToFTP(ftpUri, backupFilePath); // Upload the file
                if (filestatus)
                    MessageBox.Show("File upload complete.");
                else
                {
                    return filestatus;
                }
            }
            catch (Exception ex)
            {
                filestatus = false;
                MessageBox.Show("Error: " + ex.Message);
            }

            return filestatus;
        }

        // Method to create directory if it doesn't exist
        private static void EnsureFtpDirectoryExists(string ftpUrl)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                using (var resp = (FtpWebResponse)request.GetResponse()) { }
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                // Ignore "file unavailable" error, as it indicates the folder already exists
                if (response.StatusCode != FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    throw;
                }
            }
        }

        // Method to upload file with port
        public static bool UploadFileToFTP(string ftpUrl, string sourceFilePath)
        {
            bool status = false;
            try
            {
                FtpWebRequest reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(ftpUrl + "/" + Path.GetFileName(sourceFilePath)));
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                reqFTP.KeepAlive = false;
                reqFTP.UseBinary = true;

                FileInfo fileInfo = new FileInfo(sourceFilePath);
                reqFTP.ContentLength = fileInfo.Length;

                const int bufferSize = 2048;
                byte[] buffer = new byte[bufferSize];
                int bytesRead;

                using (FileStream fs = fileInfo.OpenRead())
                using (Stream requestStream = reqFTP.GetRequestStream())
                {
                    bytesRead = fs.Read(buffer, 0, bufferSize);
                    while (bytesRead != 0)
                    {
                        requestStream.Write(buffer, 0, bytesRead);
                        bytesRead = fs.Read(buffer, 0, bufferSize);
                    }
                }

                using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
                // MessageBox.Show($"FTP upload error");

            }
            return status;
        }


    }
}
