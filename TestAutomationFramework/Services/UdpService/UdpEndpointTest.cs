using System;
using Newtonsoft.Json;
using System.Threading;
using TestAutomationFramework.Services.UdpService.Device;

namespace TestAutomationFramework.Services
{
    public class UdpEndpointTest
    {
        //Todo add properties and logger
        const string host = "emwjuicebox.cloudapp.net";
        const int port = 8042;

        void TxRxRaw(string packet)
        {
            var udpClient = new UdpClientEx(host, port);
            string recStr = udpClient.TxRx(packet);
            var recState = ProtConvert.DeSerializeFromServer(recStr);
            Console.WriteLine(JsonConvert.SerializeObject(recState));
            udpClient.Close();
            Thread.Sleep(2000);
        }

        public void TestUdpEndpoint_State_Standby()
        {
            var deviceState = new DeviceState
            {
                UnitId = "011111111",
                Voltage = 2201,
                ChargeState = ChargeStateE.Standby,
                Temperature = 35,
                GridFrequency = 6000
            };
            TxRxRaw(ProtConvert.SerializeToServer(deviceState));
        }

        public void TestUdpEndpoint_State_Connected()
        {
            var deviceState = new DeviceState
            {
                UnitId = "011111111",
                Voltage = 2201,
                ChargeState = ChargeStateE.Connected,
                Temperature = 35,
                GridFrequency = 6000
            };
            TxRxRaw(ProtConvert.SerializeToServer(deviceState));
        }

        public void TestUdpEndpoint_State_Charging()
        {
            var deviceState = new DeviceState
            {
                UnitId = "011111111",
                Voltage = 2201,
                ChargeState = ChargeStateE.Charging,
                Temperature = 35,
                GridFrequency = 6000
            };
            TxRxRaw(ProtConvert.SerializeToServer(deviceState));
        }

        public void TestUdpEndpoint_RawData()
        {
            TxRxRaw("011111112:v07,s0121,u00000,V2201,L123,S2,T35,M40,m40,t10,i45,e-1,f6000,X0,Y0,E0,A0320,p1000!DPQ:");
        }
    }
}