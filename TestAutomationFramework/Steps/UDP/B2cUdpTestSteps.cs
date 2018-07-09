using System;
using System.Reflection;
using TechTalk.SpecFlow;
using TestAutomationFramework.Services;

namespace TestAutomationFramework.Steps.UDP

{
    [Binding]
    class B2cUdpTestSteps
    {
        [Given(@"I send udp packages with next ""(.*)""")]
        public void GivenISendUdpPackagesWithNextData(string udpData)
        {
            var testName = new UdpEndpointTest();

            Console.WriteLine("Start Udp test for: " + udpData);
            MethodInfo methodName = typeof(UdpEndpointTest).GetMethod(udpData);
            methodName.Invoke(testName, null);
        }

        [Given(@"I send udp package ""(.*)"" to server ""(.*)"" with port ""(.*)""")]
        public void GivenISendUdpPackageToServerWithPort(string udpPacket, string serverAddr, string portNum)
        {
            var testName = new UdpEndpointTest();

            Console.WriteLine("Start Udp test for: " + udpPacket);
            testName.TxRxRaw(udpPacket, serverAddr, Int32.Parse(portNum));

        }

    }
}
