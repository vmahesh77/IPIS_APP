using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Classes
{
    class Updater
    {
        public static async Task UpdateApplication(string apiUrl, string authToken, string uniqueId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");

                    HttpResponseMessage response = await client.GetAsync($"{apiUrl}?id={uniqueId}");

                    if (response.IsSuccessStatusCode)
                    {
                        string downloadUrl = await response.Content.ReadAsStringAsync();
                        await DownloadAndInstallUpdate(downloadUrl);
                    }
                    else
                    {
                        MessageBox.Show("Failed to fetch update URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task DownloadAndInstallUpdate(string downloadUrl)
        {
            try
            {
                string setupFilePath = Path.Combine(Path.GetTempPath(), "update_setup.exe");

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(downloadUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        byte[] setupBytes = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(setupFilePath, setupBytes);


                        MessageBox.Show("Update downloaded. The application will restart and install the update.", "Update Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StartUpdateProcess(setupFilePath);
                    }
                    else
                    {
                        MessageBox.Show("Failed to download the update.", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading update: {ex.Message}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void StartUpdateProcess(string setupFilePath)
        {
            Process.Start(setupFilePath);
            Application.Exit();
        }
    }
}
