using System;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;
using TestAutomationFramework.Services;

namespace TestAutomationFramework.Steps.UdpSteps
{
    [Binding]
    class UdpTestSteps
    {
        [Given(@"I send udp packages with next UdpData")]
        public void GivenISendUdpPackagesWithNextUdpData(Table table)
        {
            var testName = new UdpEndpointTest();
            string[] UdpData = table.Rows.Select(x => x.Values.FirstOrDefault()).ToArray();
            foreach (string data in UdpData)
            {
                Console.WriteLine("Start Udp test for: " + data);
                MethodInfo methodName = typeof(UdpEndpointTest).GetMethod(data);
                methodName.Invoke(testName, null);
                Console.WriteLine();
            }
        }
    }
}
