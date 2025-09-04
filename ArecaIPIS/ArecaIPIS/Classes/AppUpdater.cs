using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ArecaIPIS.Classes
{
    class AppUpdater
    {
        public void UpdateApp(string version, string apiUrl)
        {
            try
            {
                // Step 1: Download the zip file from the API URL
                string zipFilePath = Path.Combine(Path.GetTempPath(), "app_update.zip");
                DownloadZipFile(apiUrl, zipFilePath);

                // Step 2: Extract the zip file
                string extractPath = Path.Combine(Path.GetTempPath(), "app_update");
                ExtractZipFile(zipFilePath, extractPath);

               
                extractPath = Path.Combine(extractPath, version);
               
                InstallNewVersion(extractPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during update: " + ex.Message);
            }
        }

        private void DownloadZipFile(string apiUrl, string zipFilePath)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    Console.WriteLine($"Attempting to download the file from: {apiUrl}");

                    // Make the request to download the zip file
                    client.DownloadFile(apiUrl, zipFilePath);

                    // Log when download is complete
                    Console.WriteLine("Downloaded the update zip file successfully.");
                }
            }
            catch (WebException webEx)
            {
                Console.WriteLine($"Web error while downloading zip file: {webEx.Message}");
                if (webEx.Response != null)
                {
                    using (var reader = new StreamReader(webEx.Response.GetResponseStream()))
                    {
                        string responseText = reader.ReadToEnd();
                        Console.WriteLine($"Server response: {responseText}");
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading zip file: {ex.Message}");
                throw;
            }
        }

        private void ExtractZipFile(string zipFilePath, string extractPath)
        {
            try
            {
                if (Directory.Exists(extractPath))
                {
                    Directory.Delete(extractPath, true); // Clean up any existing folder
                }
                Directory.CreateDirectory(extractPath);

                // Extract the zip file to the specified path
                ZipFile.ExtractToDirectory(zipFilePath, extractPath);
                Console.WriteLine($"Extracted zip file to {extractPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error extracting zip file: " + ex.Message);
                throw;
            }
        }

        private void UninstallOldVersion()
        {
            try
            {
                // Uninstall the old version using Windows Installer (msiexec)
                string uninstallerPath = @"C:\PathToUninstaller\uninstall.exe"; // Modify accordingly

                if (File.Exists(uninstallerPath))
                {
                    Process.Start(uninstallerPath);
                    Console.WriteLine("Uninstalled old version.");
                }
                else
                {
                    Console.WriteLine("Uninstaller not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex" + ex);
                Console.WriteLine("Error uninstalling old version: " + ex.Message);
                throw;
            }
        }

        private void InstallNewVersion(string extractPath)
        {
            try
            {
              //  string extractPath = @"C:\Users\Mahesh\AppData\Local\AppDataabc\1.0.0.0";
                string setupFilePath = Path.Combine(extractPath, "ArecaSetUp.msi");

                if (!File.Exists(setupFilePath))
                {
                    MessageBox.Show($"MSI file not found: {setupFilePath}");
                    return;
                }

                // 🔍 1️⃣ Fetch the Product Code (GUID) from the Registry
                string productCode = GetInstalledProductCode("ArecaSetUp");
                if (!string.IsNullOrEmpty(productCode))
                {
                    // 🛑 Uninstall existing version
                    if (!RunProcess("msiexec.exe", $"/x {productCode} /quiet /norestart"))
                    {
                        MessageBox.Show("Uninstallation failed.");
                        return;
                    }
                }

                // ✅ 2️⃣ Install the new version
                if (RunProcess("msiexec.exe", $"/i \"{setupFilePath}\" /quiet /norestart ALLUSERS=1"))
                {
                    MessageBox.Show("Installation successful. Restarting application...");

                    // 🚀 Restart Application
                    Process.Start(Application.ExecutablePath);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Installation failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // 🔍 Helper function to get the product code from the Windows registry
        private string GetInstalledProductCode(string productName)
        {
            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
            {
                if (key != null)
                {
                    foreach (string subKeyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                        {
                            if (subKey != null && subKey.GetValue("DisplayName")?.ToString().Contains(productName) == true)
                            {
                                return subKeyName; // This is the Product Code (GUID)
                            }
                        }
                    }
                }
            }
            return null;
        }

        // 🛠️ Helper function to run a process
        private bool RunProcess(string fileName, string arguments)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "runas"
                };

                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    process.WaitForExit();
                    return process.ExitCode == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Process Error: {ex.Message}");
                return false;
            }
        }


    }
}
