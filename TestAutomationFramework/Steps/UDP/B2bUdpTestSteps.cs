using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestAutomationFramework.Services;

namespace TestAutomationFramework.Steps.UDP

{
    [Binding]
    class B2bUdpTestSteps
    {
        //The POCO for sharing data
        public class UdpData
        {
            public string requestRx;
        }

        private readonly UdpData udpData;
        public B2bUdpTestSteps(UdpData udpData)
        {
            this.udpData = udpData;
        }

        
        [When(@"I send udp package ""(.*)""")]
        [Given(@"I send udp package ""(.*)""")]
        public void GivenISendUdpPackage(string udpPackage)
        {
            var testName = new UdpEndpointTest();
            var step = 0;
            var resultNotFound = true;
            while (step < 3 && resultNotFound)
            {
                step++;
                try
                {
                    udpData.requestRx = testName.GetRxRaw(udpPackage);
                    resultNotFound = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("WARNING!!! No UPD response, step: " + step);
                }
            }
        }

        [Then(@"UDP response should contain ""(.*)""")]
        public void ThenUDPResponseShouldContain(string textString)
        {
            Assert.AreEqual(udpData.requestRx.Contains(textString), true);
        }

    }
}
