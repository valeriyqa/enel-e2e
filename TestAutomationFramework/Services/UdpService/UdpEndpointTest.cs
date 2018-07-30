using JsonConfig;
using Newtonsoft.Json;
using System;
using System.Threading;
using TestAutomationFramework.Services.UdpService.Device;

namespace TestAutomationFramework.Services
{
    public class UdpEndpointTest
    {
        private string host = Config.Global.environment.udp_address;
        const int port = 8042;

        void TxRxRaw(string packet)
        {
            var udpClient = new UdpClientEx(host, port);
            var step = 0;
            var resultNotFound = true;
            while (step < 3 && resultNotFound)
            {
                step++;
                try
                {
                    string recStr = udpClient.TxRx(packet);
                    var recState = ProtConvert.DeSerializeFromServer(recStr);
                    Console.WriteLine(JsonConvert.SerializeObject(recState));
                    resultNotFound = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("WARNING!!! No UPD response, step: " + step);
                }
            }
            //Thread.Sleep(2000);
        }

        public String GetRxRaw(string packet)
        {
            var udpClient = new UdpClientEx(host, port);
            string recStr = udpClient.TxRx(packet);

            //var recState = ProtConvert.DeSerializeFromServer(recStr);
            //Console.WriteLine(JsonConvert.SerializeObject(recState));
            udpClient.Close();
            return recStr;
            //Thread.Sleep(2000);
        }

        public string GetUdpPackage(string deviceChargeState, string unitId, int energy)
        {
            var deviceState = new DeviceState
            {
                UnitId = unitId,
                Voltage = 2201,
                ChargeState = (ChargeStateE)Enum.Parse(typeof(ChargeStateE), deviceChargeState),
                Temperature = 35,
                GridFrequency = 6000,
                EnergyForSession = energy
            };
            return ProtConvert.SerializeToServer(deviceState);
        }

        public string GetUdpPackage(string deviceChargeState, string unitId)
        {
            var deviceState = new DeviceState
            {
                UnitId = unitId,
                Voltage = 2201,
                ChargeState = (ChargeStateE)Enum.Parse(typeof(ChargeStateE), deviceChargeState),
                Temperature = 35,
                GridFrequency = 6000
            };
            return ProtConvert.SerializeToServer(deviceState);
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