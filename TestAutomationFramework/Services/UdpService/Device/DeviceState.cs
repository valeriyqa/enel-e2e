namespace TestAutomationFramework.Services.UdpService.Device
{
    public enum ChargeStateE
    {
        Standby,
        Connected,
        Charging,
        Error1,
        Error2,
        Error3
    }
    public class DeviceState
    {
        public string UnitId;
        public int ServerIndex;
        public int Voltage;
        public ChargeStateE ChargeState;
        public int Temperature;
        public int MaxAllowedCurrent;
        //public int MaxRatingCurrent;
        public int GridFrequency;
        //---only for state 2---
        public int EnergyForSession;
        public int ActualCurrent;
        public int PowerFactor;
    }
    public class PacketFromServer
    {
        public string Header;
        public string DayTime;
        public int AllowedChargCurrentOnline;
        public int AllowedChargCurrentOffline;
        public int ServerIndex;
        public string Checksum;
    }
}
