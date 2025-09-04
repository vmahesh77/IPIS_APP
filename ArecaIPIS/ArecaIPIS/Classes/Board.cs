using ArecaIPIS.DAL;
using System;
using System.Data;

namespace ArecaIPIS.Classes
{
    public class Board
    {
        public static int PDC = 1;
        public static int CGDB = 2;
        public static int PFDB = 3;
        public static int AGDB = 4;
        public static int MLDB = 5;
        public static int IVD = 6;
        public static int OVD = 7;
        public static int CCTV = 8;
        public static int pdcPortNo = 26000;



        public static int LinkCheck = 128; //80
        public static int DataTransfer = 129;//81
        public static int Stop = 130;//82
        public static int Start = 131;//83
        public static int SetConfiguration = 132;//84
        public static int GetConfiguration = 133;//85
        public static int SoftReset = 134;//86
        public static int DefaultData = 135;//87
        public static int MessageData = 136;//88
        public static int DeleteData = 137;//89
        public static int MediaData = 139;//89



        public static int GetPacketIdentifier(string BoardIp)
        {
            try
            {


                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                    {
                        // Compare the IP address as a string
                        if (row["IPAddress"].ToString() == BoardIp)
                        {
                            // Try to get the PacketIdentifier as an integer
                            if (int.TryParse(row["PacketIdentifier"].ToString(), out int packet))
                            {
                                return packet;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            // Return a default value or throw an exception if the BoardIp is not found
            throw new Exception("PacketIdentifier not found for the provided BoardIp.");
        }
        public static string GetCommandName(int commandValue)
        {
            try
            {


                switch (commandValue)
                {
                    case 128:
                        return "LinkCheck";
                    case 129:
                        return "DataTransfer";
                    case 130:
                        return "Stop";
                    case 131:
                        return "Start";
                    case 132:
                        return "SetConfiguration";
                    case 133:
                        return "GetConfiguration";
                    case 134:
                        return "SoftReset";
                    case 135:
                        return "DefaultData";
                    case 136:
                        return "MessageData";
                    case 137:
                        return "DeleteData";
                    case 139:
                        return "MediaData";
                    default:
                        return "Cgdb Data";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
        public static string GetResponseCommandName(int commandValue)
        {
            try
            {


                switch (commandValue)
                {
                    case 192:
                        return "LinkCheck";
                    case 193:
                        return "DataTransfer";
                    case 194:
                        return "Stop";
                    case 195:
                        return "Start";
                    case 196:
                        return "SetConfiguration";
                    case 197:
                        return "GetConfiguration";
                    case 198:
                        return "SoftReset";
                    case 199:
                        return "DefaultData";
                    case 200:
                        return "MessageData";
                    case 201:
                        return "DeleteData";
                    case 202:
                        return "MediaData";
                    default:
                        return "Cgdb Data";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
        public static string GetBoardType(string packetIdentifier)
        {
            try
            {


                foreach (DataRow row in BaseClass.PacketIdentifier.Rows)
                {
                    if (BaseClass.PacketIdentifier.Columns.Contains("packetIdenfier"))
                    {
                        // Compare the IP address as a string
                        if (row["packetIdenfier"].ToString() == packetIdentifier)
                        {

                            string packet = row["Packet_name"].ToString().Trim();
                            // Try to get the PacketIdentifier as an integer

                            return packet;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            // Return a default value or throw an exception if the BoardIp is not found
            throw new Exception("PacketIdentifier not found for the provided BoardIp.");
        }
        public static string GetBoardipbyname(string name)
        {


            foreach (DataRow row in BaseClass.EthernetPorts.Rows)
            {
                if (BaseClass.EthernetPorts.Columns.Contains("Location"))
                {
                    // Compare the IP address as a string
                    if (row["Location"].ToString().Trim() == name)
                    {

                        string ip = row["IPAddress"].ToString().Trim();
                        // Try to get the PacketIdentifier as an integer

                        return ip;

                    }
                }
            }

            // Return a default value or throw an exception if the BoardIp is not found
            throw new Exception("PacketIdentifier not found for the provided BoardIp.");
        }
        public static int GetMasterHubKey(string BoardIp)
        {
            foreach (DataRow row in BaseClass.EthernetPorts.Rows)
            {
                if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                {
                    // Compare the IP address as a string
                    if (row["IPAddress"].ToString() == BoardIp)
                    {
                        // Try to get the PacketIdentifier as an integer
                        if (int.TryParse(row["PkeyMasterhub"].ToString(), out int pkey))
                        {
                            return pkey;
                        }
                    }
                }
            }

            // Return a default value or throw an exception if the BoardIp is not found
            throw new Exception("PacketIdentifier not found for the provided BoardIp.");
        }
        public static int GetNoOfLines(int Pkkey)
        {
            try
            {


                DataTable boarddetailybyPk = new DataTable();
                boarddetailybyPk = HubConfigurationDb.GetBoardDetails(Pkkey);
                foreach (DataRow row in boarddetailybyPk.Rows)
                {
                    if (boarddetailybyPk.Columns.Contains("FkeyofMasterHub") && int.TryParse(row["FkeyofMasterHub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == Pkkey)
                        {

                            return Convert.ToInt32(row["NoofLines"].ToString());


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return 0;
        }
    }
}
