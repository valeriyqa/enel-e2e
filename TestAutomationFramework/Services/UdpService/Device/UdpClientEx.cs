using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestAutomationFramework.Services.UdpService.Device
{
    public class UdpClientEx : UdpClient
    {
        public UdpClientEx(string host, int port) : base(host, port)
        {
            Client.ReceiveTimeout = 25000;
        }
        public string TxRx(string data)
        {
            Console.WriteLine("Tx: " + data);
            byte[] sendBytes = Encoding.ASCII.GetBytes(data);
            Send(sendBytes, sendBytes.Length);
            var remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] recBytes = Receive(ref remoteIpEndPoint);
            string recStr = Encoding.ASCII.GetString(recBytes);
            Console.WriteLine("Rx: " + recStr);
            return recStr;
        }
    }
}
