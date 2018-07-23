using JsonConfig;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TestAutomationFramework.Services;

namespace TestAutomationFramework.Steps.UDP

{
    [Binding]
    class B2bTerminalTestSteps
    {
        //The POCO for sharing data
        public class TestData
        {
            public string terminalId;
            public string unitId;
            public string token;
            public string requestRxUdp;
            public IRestResponse responseApi;
        }

        private readonly TestData testData;
        public B2bTerminalTestSteps(TestData testData)
        {
            this.testData = testData;
        }


        //[When(@"I send udp package ""(.*)""")]
        //[Given(@"I send udp package ""(.*)""")]
        //public void GivenISendUdpPackage(string udpPackage)
        //{
        //    var testName = new UdpEndpointTest();
        //    var step = 0;
        //    var resultNotFound = true;
        //    while (step < 3 && resultNotFound)
        //    {
        //        step++;
        //        try
        //        {
        //            testData.requestRxUdp = testName.GetRxRaw(udpPackage);
        //            resultNotFound = false;
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("WARNING!!! No UPD response, step: " + step);
        //        }
        //    }
        //}

        [Then(@"UDP response should contain ""(.*)""")]
        public void ThenUDPResponseShouldContain(string textString)
        {
            Assert.AreEqual(testData.requestRxUdp.Contains(textString), true);
        }

        [Then(@"API response should be successful")]
        public void ThenAPIResponseShouldBeSuccessful()
        {
            Assert.AreEqual(testData.responseApi.IsSuccessful, true);
            Assert.AreEqual(testData.responseApi.StatusCode, HttpStatusCode.OK);
        }

        [When(@"I send UDP package with status ""(.*)"" to unit ""(.*)""")]
        public void WhenISendUDPPackageWithStatusToUnit(string deviceChargeState, string unitId)
        {
            if (deviceChargeState.Contains("Charging"))
            {
                System.Threading.Thread.Sleep(3000);
            }

            testData.unitId = unitId;
            var testName = new UdpEndpointTest();
            var step = 0;
            var resultNotFound = true;
            while (step < 3 && resultNotFound)
            {
                step++;
                try
                {
                    testData.requestRxUdp = testName.GetRxRaw(testName.GetUdpPackage(deviceChargeState, unitId));
                    resultNotFound = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("WARNING!!! No UPD response, step: " + step);
                }
            }
        }

        [When(@"I send authorization API request to terminal ""(.*)""")]
        public void WhenISendAuthorizationAPIRequestToTerminal(string terminalId)
        {
            testData.terminalId = terminalId;
            var client = new RestClient(Config.Global.environment.api_address);
            
            var request = new RestRequest("api/v1/{id}/sessions", Method.POST);

            request.AddParameter("unit", testData.unitId);

            Random generator = new Random();
            testData.token = generator.Next(0, 99999).ToString("D5") + generator.Next(0, 99999).ToString("D5");
            ////request.AddParameter("unit", testData.unitId);
            ////request.AddParameter("token", testData.token);
            ////request.AddParameter("token", "1092824815");

            request.AddParameter("token", testData.token);
            request.AddUrlSegment("id", terminalId); 


            testData.responseApi =  client.Execute(request);
        }

        [When(@"I verify device status via API request")]
        public void WhenIVerifyDeviceStatusViaAPIRequest()
        {
            var client = new RestClient(Config.Global.environment.api_address);
            var request = new RestRequest("api/v1/" + testData.terminalId + "/sessions?token=" + testData.token, Method.GET);

            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "text/xml");
            testData.responseApi = client.Execute(request);
            Console.WriteLine(testData.responseApi.Content);
        }

        [Then(@"status should be ""(.*)""")]
        public void ThenStatusShouldBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }


    }
}