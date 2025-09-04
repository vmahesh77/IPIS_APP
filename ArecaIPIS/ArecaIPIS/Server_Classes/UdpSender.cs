using ArecaIPIS.Classes;
using System.Net;
using System.Net.Sockets;

namespace ArecaIPIS.Server_Classes
{
    class UdpSender
    {
        private readonly UdpClient _udpClient;
        private readonly IPEndPoint _endPoint;
        private const int DefaultPort = 26000; // Default port

        public UdpSender(string ipAddress)
        {
            _udpClient = new UdpClient();
            _endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), DefaultPort);
        }

        public void SendData(byte[] data)
        {

            _udpClient.Send(data, data.Length, _endPoint);
            string hexString = Server.ByteArrayToHexString(data);
            // Server. DataPacket(data);
        }
    }
}
