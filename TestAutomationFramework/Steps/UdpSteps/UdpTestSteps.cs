using System;
using System.Reflection;
using TechTalk.SpecFlow;
using TestAutomationFramework.Services;

namespace TestAutomationFramework.Steps.UdpSteps
{
    [Binding]
    class UdpTestSteps
    {
        [Given(@"I send udp packages with next ""(.*)""")]
        public void GivenISendUdpPackagesWithNextData(string udpData)
        {
            var testName = new UdpEndpointTest();

            Console.WriteLine("Start Udp test for: " + udpData);
            MethodInfo methodName = typeof(UdpEndpointTest).GetMethod(udpData);
            methodName.Invoke(testName, null);
        }
    }
}
