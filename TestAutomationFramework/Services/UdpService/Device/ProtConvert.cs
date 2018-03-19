using System;

namespace TestAutomationFramework.Services.UdpService.Device
{
    class ProtConvert
    {
        public static string SerializeToServer(DeviceState unitState)
        {
            string result = $"{unitState.UnitId}:v07,s0121,u00000,V{unitState.Voltage},L123,S{(int)unitState.ChargeState},T{unitState.Temperature}," +
                $"M40,m40,t10,i45,e-1,f{unitState.GridFrequency},X0,Y0";
            if (unitState.ChargeState == ChargeStateE.Charging)
            {
                result += $",E{unitState.EnergyForSession},A0320,p1000";
            }
            return result + CalcChecksumString(result).Replace('$', ':');
        }
        public static PacketFromServer DeSerializeFromServer(string data)
        {
            string dataBody = data.Substring(3);
            PacketFromServer packetFromServer = new PacketFromServer();
            packetFromServer.Header = data.Substring(0, 3);
            packetFromServer.DayTime = dataBody.Substring(0, 5);
            packetFromServer.AllowedChargCurrentOnline = int.Parse(dataBody.Substring(dataBody.IndexOf('A') + 1, 2));
            packetFromServer.AllowedChargCurrentOffline = int.Parse(dataBody.Substring(dataBody.IndexOf('M') + 1, 2));
            packetFromServer.ServerIndex = int.Parse(dataBody.Substring(dataBody.IndexOf('S') + 1, 3));
            packetFromServer.Checksum = dataBody.Substring(dataBody.IndexOf('!') + 1, 3);
            string crcCalc = CalcChecksumString(data.Substring(0, data.Length - 5));
            if (!crcCalc.Contains(packetFromServer.Checksum)) throw new Exception("Wrong Checksum!");
            if (packetFromServer.Header != "CMD") throw new Exception("Wrong 'CMD' header!");
            return packetFromServer;
        }

        private static UInt16 CalcChecksum(string message, int start, int end)
        {
            UInt16 h = 0;
            while (start < end)
            {
                h ^= (UInt16)((h << 5) + (h >> 2) + (byte)message[start]);
                start++;
            }
            return h;
        }

        public static string CalcChecksumString(string message)
        {
            UInt16 h = CalcChecksum(message, 0, message.Length);
            string ret = "!";

            for (int i = 0; i < 3; i++)
            {
                ret += Num2JBChar(h % 35);
                h /= 35;
            }
            ret += "$";
            return ret;
        }

        private static char Num2JBChar(int n)
        {
            n = n % 35;
            if (n < 10) return (char)('0' + n);
            if (n == 24) return 'Z';
            return (char)('A' + n - 10);
        }
    }
}
