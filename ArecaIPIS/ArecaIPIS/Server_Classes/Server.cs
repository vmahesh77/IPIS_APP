using ArecaIPIS.DAL;
using ArecaIPIS.Forms;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ArecaIPIS.Classes
{
    public class Server
    {
        private static System.Windows.Forms.Timer networkStatusTimer;

        private static TcpListener _server;
        public static bool _isRunning;
        public static ConcurrentDictionary<string, TcpClient> _connectedClients = new ConcurrentDictionary<string, TcpClient>();
        public static string ipAdress;
        public static string SlaveipAdress;

        public static int SerialNumber = 0;

        public const int udpPort = 26000;



        public static List<string> AgdbIpAdress = new List<string>();
        public static List<string> PfdbIpAdress = new List<string>();
        public static List<string> MldbIpAdress = new List<string>();
        public static List<string> OvdIpAdress = new List<string>();
        public static List<string> IvdIpAdress = new List<string>();

        public static byte[] GetReceivedBytes = new byte[0];
        private static System.Threading.Timer _ipCheckTimer; // Timer to check for IP changes
        private static bool _isNetworkAvailable; // Track network availability
        public static bool isLanConnected = false;
        public static void StartServer()
        {

            try
            {

                if (_isRunning == true)
                {
                    StopServer();
                }

                timer();
                CheckNetworkAvailability(); // Initial check for network availability
                NetworkChange.NetworkAvailabilityChanged += NetworkAvailabilityChanged;
                int port = 25000;

                //_server = new TcpListener(IPAddress.Parse(ipAdress), port);
                //_server.Start();



                _server = new TcpListener(IPAddress.Any, port);
                _server.Start();
                _isRunning = true;

                // Start a thread to accept clients
                Thread acceptThread = new Thread(AcceptClients);
                acceptThread.Start();

                // Subscribe to network change notifications


                // Set up a timer to periodically check for IP address
                _ipCheckTimer = new System.Threading.Timer(CheckIPAddress, null, 0, 1000); // Check every 2 seconds
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }

        public static void GetSlaveip()
        {
            try
            {


                string Masterip = Server.ipAdress;

                // Check if the Masterip is null
                if (Masterip == null)
                {
                    SlaveipAdress = null;
                }

                // Check if the IP address is in the expected format
                if (Masterip == "192.168.0.254")
                {
                    SlaveipAdress = "192.168.0.253";
                }
                else if (Masterip == "192.168.0.253")
                {
                    SlaveipAdress = "192.168.0.254";
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


        }
        private static void NetworkStatusTimer_Tick(object sender, EventArgs e)
        {
            CheckNetworkStatus();
        }
        private static void NetworkStatusChanged(object sender, EventArgs e)
        {
            // Check network status when the event is triggered
            CheckNetworkStatus();

        }

        public static void timer()
        {
            try
            {


                NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(NetworkStatusChanged);


                CheckNetworkStatus();
                networkStatusTimer = new Timer();
                networkStatusTimer.Interval = 5000; // Check every 5 seconds
                networkStatusTimer.Tick += NetworkStatusTimer_Tick;
                networkStatusTimer.Start();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        private static void CheckNetworkStatus()
        {
            try
            {


                // Get all network interfaces and filter for Ethernet (LAN) interfaces only
                var ethernetInterfaces = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(nic => nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                                  && nic.OperationalStatus == OperationalStatus.Up);

                bool isEthernetConnected = false;
                string localIPAddress = string.Empty;

                // Check if any Ethernet interface has the specified IP addresses
                foreach (var nic in ethernetInterfaces)
                {
                    // Ensure the interface has valid IPv4 properties
                    if (nic.GetIPProperties().GetIPv4Properties() != null)
                    {
                        // Loop through the unicast addresses to find the IPv4 address
                        foreach (var ip in nic.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                // Get the IPv4 address as a string
                                localIPAddress = ip.Address.ToString();

                                // Check if the IP matches either 192.168.0.254 or 192.168.0.253
                                if (localIPAddress == "192.168.0.254" || localIPAddress == "192.168.0.253")
                                {
                                    isEthernetConnected = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (isEthernetConnected)
                        break;
                }

                UpdateLanStatusLabel(isEthernetConnected, localIPAddress);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        private static void UpdateLanStatusLabel(bool isEthernetConnected, string localIPAddress)
        {
            try
            {


                if (isEthernetConnected)
                {
                    Server.isLanConnected = true;
                    CheckIPAddress();


                }
                else
                {
                    Server.isLanConnected = false;
                    Server.ipAdress = "";
                    Server._connectedClients.Clear();

                }
                LanConnectedEvents();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public static void LanConnectedEvents()
        {
            try
            {

                frmHome home;

                Form homeForm = Application.OpenForms["frmHome"];

                if (homeForm != null)
                {
                    home = (frmHome)homeForm;

                }
                else
                {
                    home = new frmHome();

                }
                home.setipAddress();
                home.setDevices();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }


        private static void NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            try
            {


                _isNetworkAvailable = e.IsAvailable;

                if (_isNetworkAvailable)
                {

                    CheckIPAddress(); // Check IP immediately when network is available
                    Server.GetSlaveip();
                    //MessageBox.Show("Network connection has been restored.", "Network Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //  Console.WriteLine("Network is disconnected.");
                    // MessageBox.Show("Network connection is lost.", "Network Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            try
            {
                if (!String.IsNullOrEmpty(Server.ipAdress))
                {
                    if (!_isRunning)
                    {
                        int port = 25000;
                        _server = new TcpListener(IPAddress.Parse(ipAdress), port);
                        _server.Start();
                        _isRunning = true;
                        // Start a thread to accept clients
                        Thread acceptThread = new Thread(AcceptClients);
                        acceptThread.Start();

                        // Subscribe to network change notifications


                        // Set up a timer to periodically check for IP address
                        _ipCheckTimer = new System.Threading.Timer(CheckIPAddress, null, 0, 2000);
                    }

                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }
        private static void CheckIPAddress(object state = null)
        {
            if (!_isNetworkAvailable) return; // Only check if network is available

            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork &&
                        (ip.ToString() == "192.168.0.254" || ip.ToString() == "192.168.0.253"))
                    {
                        if (ipAdress != ip.ToString()) // Update only if IP has changed
                        {
                            ipAdress = ip.ToString();

                        }
                        return; // Exit if IP is found
                    }
                }
                //  Console.WriteLine("No valid IP found.");
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }

        }
        public static string GetLocalIPAddress()
        {
            try
            {


                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork &&
                        (ip.ToString() == "192.168.0.254" || ip.ToString() == "192.168.0.253"))
                    {
                        return ip.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            throw new Exception("No network adapters with an IPv4 address in the system matching 192.168.0.254 or 192.168.0.253!");
        }
        public static string GetBroadcastIp(string pdcIpAddress)
        {
            try
            {


                string[] systemIpArr = pdcIpAddress.Split('.');
                if (systemIpArr.Length == 4)
                {
                    // Change the 4th octet to 255
                    systemIpArr[3] = "255";
                    // Join the octets back into an IP address string
                    return string.Join(".", systemIpArr);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
            return string.Empty; // Return empty string if the IP format is incorrect
        }
        public static void CheckNetworkAvailability()
        {
            try
            {


                _isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
                if (_isNetworkAvailable)
                {
                    CheckIPAddress(); // Initial check for IP address if network is available
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }
        }
        //public static void StopServer()
        //{
        //    try
        //    {
        //        if (_isRunning)
        //        {
        //            _isRunning = false;
        //            _server.Stop();
        //            foreach (var client in _connectedClients.Values)
        //            {
        //                client.Close();
        //            }
        //            _connectedClients.Clear();
        //            LogError("Server stopped.");
        //        }
        //        else
        //        {
        //            LogError("Server is not running.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError($"Error stopping server: {ex.Message}");
        //    }
        //}
        public static void StopServer()
        {
            try
            {
                // Stop accepting new connections
                if (_server != null)
                {
                    _server.Stop();
                    _server = null; // Release the reference
                }

                // Stop the IP check timer
                if (_ipCheckTimer != null)
                {
                    _ipCheckTimer.Dispose();
                    _ipCheckTimer = null;
                }

                // Unsubscribe from network availability events
                NetworkChange.NetworkAvailabilityChanged -= NetworkAvailabilityChanged;

                // Handle any active client connections
                if (_connectedClients != null && _connectedClients.Count > 0)
                {
                    foreach (var client in _connectedClients.Values)
                    {
                        try
                        {
                            client.Close(); // Close each client connection
                            Task.Delay(100);
                        }
                        catch (Exception ex)
                        {
                            Server.LogError($"Error closing client: {ex.Message}");
                        }
                    }
                    _connectedClients.Clear(); // Clear the client list
                }

                // Signal the server as stopped
                _isRunning = false;

                Server.LogError("Server stopped successfully.");
            }
            catch (Exception ex)
            {
                Server.LogError($"Error stopping server: {ex.Message}");
            }
        }


        private static void AcceptClients()
        {
            while (_isRunning)
            {
                try
                {
                    TcpClient client = _server.AcceptTcpClient();
                    string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                    _connectedClients[clientIP] = client;
                    //  DataPacket($"Client connected: {clientIP}");

                    OnlineTrainsDao.UpdateLinkCheckIp(clientIP, true);
                    Thread clientThread = new Thread(() => HandleClient(client, clientIP));
                    clientThread.Start();




                }
                catch (Exception ex)
                {
                    if (_isRunning)
                    {

                        LogError($"Accept client error: {ex.Message}");
                    }
                }
            }
        }

        public static void SendMessageToClient(string clientIP, byte[] message)
        {
            try
            {
                if (message != null)
                {

                    if (_connectedClients.TryGetValue(clientIP, out TcpClient client))
                    {
                        GetReceivedBytes = new byte[0];
                        NetworkStream stream = client.GetStream();
                        stream.Flush();
                        stream.Write(message, 0, message.Length);
                        int packetType = 0;
                        if (BaseClass.Getinteroperabilitystatus(clientIP))
                        {
                            packetType = Convert.ToInt32(message[10]);
                        }
                        else
                        {
                            packetType = Convert.ToInt32(message[16]);
                        }
                        string CommandName = Board.GetCommandName(packetType) + " Command Sending";
                        DataPacket(clientIP, CommandName, message);
                        //DataPacket($"Message sent to client {clientIP}:{Encoding.ASCII.GetString(message)}");
                        string hexString = ByteArrayToHexString(message).ToUpper();
                        //  DataPacket(message);

                        OnlineTrainsDao.UpdateDataTransferIp(clientIP, true);
                        ReportDb.InsertDataLogReport(clientIP, hexString, " ");
                    }
                    else
                    {
                        string Error = "Sending Failed To Board " + clientIP;
                        string ErDescription = "Board Not Connected";
                        ReportDb.InsertErrorLog(Error, ErDescription);
                        OnlineTrainsDao.UpdateDataTransferIp(clientIP, false);
                        LogError($"Client {clientIP} not connected.");
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error sending message to client {clientIP}: {ex.Message}");
            }
        }
        public static List<string> AllIpadress = new List<string>();
        public static void getBoardsIpAdress()
        {
            try
            {


                DataTable IpAdressDt = OnlineTrainsDao.GetAllIpAddress();


                 AllIpadress.Clear();
                MldbIpAdress.Clear();
                PfdbIpAdress.Clear();
                AgdbIpAdress.Clear();
                 OvdIpAdress.Clear();
                 IvdIpAdress.Clear();


                foreach (DataRow row in IpAdressDt.Rows)
                {
                    string key = row["IPAddress"].ToString();
                    //if (_connectedClients.TryGetValue(key, out TcpClient client))
                    //{
                    AllIpadress.Add(key);
                    //}
                }



                if (AllIpadress.Count > 0)
                {
                    foreach (var ipadress in AllIpadress)
                    {
                        if (TryGetLastOctet(ipadress, out int lastOctet))
                        {
                            if (lastOctet >= 40 && lastOctet <= 70)
                            {
                                OvdIpAdress.Add(ipadress);
                            }
                            else if (lastOctet >= 71 && lastOctet <= 100)
                            {
                                IvdIpAdress.Add(ipadress);
                            }
                            else if (lastOctet >= 101 && lastOctet <= 130)
                            {
                                MldbIpAdress.Add(ipadress);
                            }
                            else if (lastOctet >= 131 && lastOctet <= 160)
                            {
                                AgdbIpAdress.Add(ipadress);
                            }
                            else if (lastOctet >= 161 && lastOctet <= 190)
                            {
                                PfdbIpAdress.Add(ipadress);
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
        public static bool TryGetLastOctet(string ipAddress, out int lastOctet)
        {
            lastOctet = -1;
            try
            {
                var ip = IPAddress.Parse(ipAddress);
                var bytes = ip.GetAddressBytes();
                if (bytes.Length == 4)
                {
                    lastOctet = bytes[3]; // Last octet
                    return true;
                }
            }
            catch (FormatException)
            {
                // Handle parsing error
            }
            return false;
        }

        public static void SendDataToPdc(string clientIP, byte[] message)
        {
            try
            {
                if (_connectedClients.TryGetValue(clientIP, out TcpClient client))
                {
                    GetReceivedBytes = new byte[0];
                    NetworkStream stream = client.GetStream();
                    stream.Flush();
                    stream.Write(message, 0, message.Length);

                    int packetType = Convert.ToInt32(message[16]);
                    string CommandName = Board.GetCommandName(packetType) + " Command Sending";
                    //DataPacket($"Message sent to client {clientIP}:{Encoding.ASCII.GetString(message)}");
                    string hexString = ByteArrayToHexString(message);
                    DataPacket(clientIP, CommandName, message);
                    ReportDb.InsertDataLogReport(clientIP, hexString, " ");

                }
                else
                {
                    string Error = "Sending Failed To Pdc " + clientIP;
                    string ErDescription = "client Not Connected";
                    ReportDb.InsertErrorLog(Error, ErDescription);
                    LogError($"Client {clientIP} not connected.");
                }
            }
            catch (Exception ex)
            {
                LogError($"Error sending message to client {clientIP}: {ex.Message}");
            }
        }
        public static byte[] CheckSum(byte[] buffer)
        {
            byte[] checkValue = new byte[2];
            //Its a common function for calculating crc 
            try
            {
                byte[] values = new byte[buffer.Length - 18];
                //3 for STX,2 for Site ID,2 for CRC and 3 for ETX=3+2+2+3=8 bytes removing
                Array.Copy(buffer, 9, values, 0, values.Length);
                ushort crc16CCITT = CRcTool.crc.CalcCRCITT(values);
                checkValue[0] = Convert.ToByte(crc16CCITT >> 8 & 0xff);
                checkValue[1] = Convert.ToByte(crc16CCITT & 0xff);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
            }


            return checkValue;
        }
        public static void ClearReceivedBytes()
        {
            Server.GetReceivedBytes = new byte[0];
        }

        public static int GetFourthOctet(string BoardIp)
        {

            // Split the IP address into its octets
            string[] octets = BoardIp.Split('.');

            // Ensure there are exactly 4 octets
            if (octets.Length == 4)
            {
                // Try to parse the third octet
                if (int.TryParse(octets[3], out int fourthOctet))
                {
                    return fourthOctet;
                }
            }

            return 0;
        }

        private static void HandleClient(TcpClient client, string clientIP)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                while (_isRunning)
                {
                    // ClearReceivedBytes();
                    if (!client.Connected)
                    {
                        _connectedClients.TryRemove(clientIP, out _);
                        LogError($"Client disconnected: {clientIP}");
                        break;
                    }

                    if (stream.DataAvailable)
                    {
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            break; // Client disconnected
                        }

                        byte[] receivedBytes = new byte[bytesRead];



                        Array.Copy(buffer, 0, receivedBytes, 0, bytesRead);
                        Array.Resize(ref GetReceivedBytes, receivedBytes.Length);
                        GetReceivedBytes = ChechRsposeBoard(receivedBytes);

                        if (receivedBytes.Length > 12)
                        {
                            int packetType = Convert.ToInt32(receivedBytes[16]);
                            string CommandName = Board.GetResponseCommandName(packetType) + " Command Response";
                            DataPacket(clientIP, CommandName, receivedBytes);
                        }

                        //DataPacket(receivedBytes);



                        string receivedDataString = Encoding.ASCII.GetString(receivedBytes);
                        string hexString = ByteArrayToHexString(receivedBytes);

                        Form mainForm = Application.OpenForms["frmHome"];
                        if (mainForm != null)
                        {
                            frmHome frmhome = (frmHome)mainForm;

                            // Update the label on the UI thread using Invoke
                            frmhome.Invoke((MethodInvoker)delegate
                            {
                                frmhome.setDevices();
                            });
                        }
                    }

                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                LogError($"Client handling error: {ex.Message}");
            }
           
        }




        public static byte[] ChechRsposeBoard(byte[] recievecedBytes)
        {


            return recievecedBytes;
        }

        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder hex = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
            {
                hex.AppendFormat("{0:X2} ", b); // Use {0:X2} for uppercase hex formatting
            }
            return hex.ToString().Trim(); // Use Trim() to remove the trailing space
        }


        public static async  Task WriteLog(string message)
        {
            string logDirectory = @"E:\ErrorLog\"; // Specify your log directory here
            string logFileName = $"LogError_{DateTime.Now:dd_MM_yyyy}.txt"; // Create a new file name based on today's date
            string logFilePath = Path.Combine(logDirectory, logFileName);
            int retryCount = 3;    // Number of retries
            int delay = 1000;      // Delay between retries in milliseconds

            // Ensure the directory exists; if not, create it
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                    // Ensure the file is created if it doesn't exist and then append to it
                    using (StreamWriter writer = new StreamWriter(new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
                    {
                        await writer.WriteLineAsync($"{DateTime.Now}: {message}");
                        await writer.FlushAsync();  // Ensure all data is written to the file immediately
                    }
                    break; // Exit loop if successful
                }
                catch (IOException ex) when (i < retryCount - 1)
                {
                    // Wait before retrying
                    await Task.Delay(delay);
                }
                catch (Exception ex)
                {
                    Server.LogError(ex.Message);
                    break;
                }

            }
        }

        public static void LogError(string message)
        {
            Task.Run(async () => await WriteLog(message));
        }


        public static async Task WriteDataLog(string clientIP, string CommandName, byte[] data)
        {
            string logDirectory = @"E:\DataLog\"; // Log folder
            string logFileName = $"DataPacket_{DateTime.Now:dd_MM_yyyy}.txt"; // Daily log file
            string logFilePath = Path.Combine(logDirectory, logFileName);
            int retryCount = 3;
            int delay = 1000; // milliseconds delay between retries

            // Ensure the directory exists
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                    // Use "using" to automatically dispose and close the StreamWriter
                    using (StreamWriter writer = new StreamWriter(new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
                    {
                        string hexString = ByteArrayToHexString(data).ToUpper();
                        await writer.WriteLineAsync($"{DateTime.Now}: {clientIP}:{CommandName}:{hexString}");
                        await writer.FlushAsync();  // Ensure immediate write
                    }
                    break; // Success - exit retry loop
                }
                catch (IOException) when (i < retryCount - 1)
                {
                    // Retry on IOException (e.g. file in use), wait before next attempt
                    await Task.Delay(delay);
                }
                catch (Exception ex)
                {
                    Server.LogError(ex.Message); // Log other exceptions
                    break; // Exit loop on unknown exceptions
                }
            }
        }


        public static void DataPacket(string clientIP, string CommandName, byte[] data)
        {
            Task.Run(async () => await WriteDataLog( clientIP,  CommandName,  data));
        }
        public static bool IsIpAddressConnected(string ipAddress)
        {
            try
            {
                if (string.IsNullOrEmpty(ipAddress))
                {
                    return false;
                }
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send(ipAddress, 1000); // 1000ms timeout
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Error checking IP address: {ex.Message}");
                return false;
            }
        }

    }
}
