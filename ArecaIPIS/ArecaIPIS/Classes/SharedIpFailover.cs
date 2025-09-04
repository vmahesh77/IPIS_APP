using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ArecaIPIS.Classes
{
    public class SharedIpFailover
    {
        public static async Task ForceTakeoverSharedIP()
        {
            string sharedIp = "192.168.0.251";
            string myIp = GetMyLocalIp();
            string adapterName = GetPrimaryNetworkAdapterName();

            if (string.IsNullOrEmpty(myIp))
            {
                Console.WriteLine("❌ Could not get local IP.");
                return;
            }

            if (string.IsNullOrEmpty(adapterName))
            {
                Console.WriteLine("❌ Could not determine network adapter.");
                return;
            }

            string otherPcIp = GetOtherPcIp(myIp);

            Console.WriteLine($"🖥 My IP: {myIp}");
            Console.WriteLine($"🌐 Other PC IP: {otherPcIp}");
            Console.WriteLine($"📡 Adapter: {adapterName}");

            if (!string.IsNullOrEmpty(otherPcIp) && PingHost(otherPcIp))
            {
                Console.WriteLine("📶 Remote PC is reachable. Sending release request...");
                var client = new HttpClient { Timeout = TimeSpan.FromSeconds(3) };
                string releaseUrl = $"http://{otherPcIp}:82/api/cctvdata/releaseSharedIP";

                try
                {
                    var response = await client.GetAsync(releaseUrl);
                    if (response.IsSuccessStatusCode)
                        Console.WriteLine("✅ Remote PC released shared IP.");
                    else
                        Console.WriteLine("⚠️ Remote PC responded but did not confirm release.");
                }
                catch
                {
                    Console.WriteLine("⚠️ Remote PC pinged, but HTTP release failed or timed out.");
                }

                Console.WriteLine("⏳ Waiting 3 seconds before takeover...");
                await Task.Delay(3000);
            }
            else
            {
                Console.WriteLine("⚠️ Remote PC unreachable. Proceeding with forceful takeover...");
            }

            AssignSharedIP(adapterName, sharedIp);
         //   RestartNetworkAdapter(adapterName);
        }

        public static void AssignSharedIP(string adapterName, string sharedIp)
        {
            try
            {
                Console.WriteLine($"🧹 Removing shared IP {sharedIp} (if exists)...");
                RunNetshCommand($"interface ip delete address \"{adapterName}\" {sharedIp}");

                Console.WriteLine($"➕ Adding shared IP {sharedIp}...");
                RunNetshCommand($"interface ip add address \"{adapterName}\" {sharedIp} 255.255.255.0");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Failed to assign shared IP: {ex.Message}");
            }
        }

        public static void RunNetshCommand(string arguments)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "netsh",
                    Arguments = arguments,
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.WaitForExit();
        }

        public static bool IsSharedIPAlreadyAssigned(string ip)
        {
            var localIPs = NetworkInterface.GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up)
                .SelectMany(nic => nic.GetIPProperties().UnicastAddresses)
                .Where(addr => addr.Address.AddressFamily == AddressFamily.InterNetwork)
                .Select(addr => addr.Address.ToString());

            return localIPs.Contains(ip);
        }

        public static bool PingHost(string ip)
        {
            try
            {
                var ping = new Ping();
                PingReply reply = ping.Send(ip, 1000);
                return reply.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }

        public static void RestartNetworkAdapter(string adapterName)
        {
            try
            {
                Console.WriteLine("🔄 Restarting network adapter...");

                Process.Start(new ProcessStartInfo
                {
                    FileName = "netsh",
                    Arguments = $"interface set interface \"{adapterName}\" admin=disable",
                    UseShellExecute = true,
                    Verb = "runas"
                })?.WaitForExit();

                Task.Delay(2000).Wait();

                Process.Start(new ProcessStartInfo
                {
                    FileName = "netsh",
                    Arguments = $"interface set interface \"{adapterName}\" admin=enable",
                    UseShellExecute = true,
                    Verb = "runas"
                })?.WaitForExit();

                Console.WriteLine("✅ Network adapter restarted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Failed to restart adapter: {ex.Message}");
            }
        }

        public static string GetMyLocalIp()
        {
            return Dns.GetHostAddresses(Dns.GetHostName())
                      .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                      ?.ToString();
        }

        public static string GetOtherPcIp(string myIp)
        {
            if (myIp.EndsWith(".253")) return "192.168.0.254";
            if (myIp.EndsWith(".254")) return "192.168.0.253";
            return null;
        }

        public static string GetPrimaryNetworkAdapterName()
        {
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up &&
                    ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    ni.GetIPProperties().UnicastAddresses
                      .Any(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork))
                {
                    return ni.Name;
                }
            }
            return null;
        }
    }
}