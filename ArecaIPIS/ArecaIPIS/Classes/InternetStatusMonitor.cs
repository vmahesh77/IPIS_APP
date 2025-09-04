using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace ArecaIPIS.Classes
{
    class InternetStatusMonitor
    {
        private static bool isInternetAvailable = false;
        private static CancellationTokenSource cts = new CancellationTokenSource();

        public static void StartMonitoring()
        {
            // ✅ Attach Network Availability Change Event
            NetworkChange.NetworkAvailabilityChanged += async (sender, e) =>
            {
                await CheckInternetStatus();
            };

            // ✅ Start Background Monitoring
            Task.Run(() => MonitorInternetStatus(cts.Token));

            // ✅ Check Internet Status on Startup
            Task.Run(CheckInternetStatus);
        }

        private static async Task MonitorInternetStatus(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await CheckInternetStatus();
                await Task.Delay(5000, token); // ✅ Check Every 5 Seconds
            }
        }

        private static async Task CheckInternetStatus()
        {
            bool isConnected = await IsInternetWorkingAsync();

            if (isConnected != isInternetAvailable)
            {
                isInternetAvailable = isConnected;
                BaseClass.displayInternetStaus(isConnected);
            }
        }

        private static async Task<bool> IsInternetWorkingAsync()
        {
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(9)))
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.Timeout = TimeSpan.FromSeconds(10);

                        HttpResponseMessage response = await client.GetAsync("https://www.google.com", cts.Token);
                        return response.IsSuccessStatusCode;
                    }
                }
                catch (TaskCanceledException ex) when (!cts.IsCancellationRequested)
                {
                    Server.LogError($"IsInternetWorkingAsync() - Request timed out: {ex.Message}");
                    return false;
                }
                catch (OperationCanceledException) when (cts.IsCancellationRequested)
                {
                    Server.LogError("IsInternetWorkingAsync() - Operation cancelled by request.");
                    return false;
                }
                catch (HttpRequestException ex)
                {
                    Server.LogError($"IsInternetWorkingAsync() - HTTP request error: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    Server.LogError($"IsInternetWorkingAsync() - Unexpected error: {ex}");
                    return false;
                }
            }
        }



        public static void StopMonitoring()
        {
            cts.Cancel();
        }
    }
}
