using JsonConfig;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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
            public int energy = 0;
            public string terminalId;
            public string unitId;
            public string token;
            public string requestRxUdp;
            public List<string> responseList = new List<string>();
            public IRestResponse responseApi;
        }

        private readonly TestData testData;
        public B2bTerminalTestSteps(TestData testData)
        {
            this.testData = testData;
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
                    testData.requestRxUdp = testName.GetRxRaw(udpPackage);
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
            Assert.AreEqual(testData.requestRxUdp.Contains(textString), true);
        }

        [Then(@"UDP response should contain amperage higher than ""(.*)""")]
        public void ThenUDPResponseShouldContainAmperageHigherThan(string amperage)
        {
            Assert.IsTrue(Int32.Parse(testData.requestRxUdp.Substring(9, 2)) > Int32.Parse(amperage));
        }


        [Then(@"API response should be successful")]
        public void ThenAPIResponseShouldBeSuccessful()
        {
            Console.WriteLine(testData.responseApi.Content);
            Assert.AreEqual(testData.responseApi.IsSuccessful, true);
            Assert.AreEqual(testData.responseApi.StatusCode, HttpStatusCode.OK);
        }

        [When(@"I send UDP package with status ""(.*)"" to unit ""(.*)""")]
        public void WhenISendUDPPackageWithStatusToUnit(string deviceChargeState, string unitId)
        {
            System.Threading.Thread.Sleep(3000);

            testData.unitId = unitId;
            var testName = new UdpEndpointTest();
            var step = 0;
            var resultNotFound = true;
            while (step < 5 && resultNotFound)
            {
                step++;
                try
                {
                    if (deviceChargeState.Equals("Charging"))
                    {
                        testData.energy = testData.energy + new Random().Next(500, 1000);
                        testData.requestRxUdp = testName.GetRxRaw(testName.GetUdpPackage(deviceChargeState, unitId, testData.energy));
                    }
                    else
                    {
                        testData.requestRxUdp = testName.GetRxRaw(testName.GetUdpPackage(deviceChargeState, unitId));
                    }
                    resultNotFound = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("WARNING!!! No UPD response, step: " + step);
                }
            }
        }

        [Then(@"I wait till UDP package with status ""(.*)"" returns ""(.*)""")]
        [Given(@"I wait till UDP package with status ""(.*)"" returns ""(.*)""")]
        public void GivenIWaitTillUDPPackageWithStatusReturns(string deviceChargeState, string textString)
        {
            var testName = new UdpEndpointTest();
            var step = 0;
            var resultNotFound = true;
            while (step < 3 && resultNotFound)
            {
                step++;
                try
                {
                    testData.requestRxUdp = testName.GetRxRaw(testName.GetUdpPackage(deviceChargeState, testData.unitId));
                    if (testData.requestRxUdp.Contains(textString))
                    {
                        resultNotFound = false;
                    }
                    else
                    {
                        Console.WriteLine("WARNING!!! UPD response is not contains \"" + textString + "\", step: " + step);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("WARNING!!! No UPD response, step: " + step);
                }
            }
            Assert.AreEqual(resultNotFound, false);
        }

        [Then(@"I wait till UDP package with status ""(.*)"" returns amperage higher than ""(.*)""")]
        public void ThenIWaitTillUDPPackageWithStatusReturnsAmperageHigherThan(string deviceChargeState, string amperage)
        {
            var testName = new UdpEndpointTest();
            var step = 0;
            var resultNotFound = true;
            while (step < 5 && resultNotFound)
            {
                step++;
                try
                {
                    testData.requestRxUdp = testName.GetRxRaw(testName.GetUdpPackage(deviceChargeState, testData.unitId));
                    if (Int32.Parse(testData.requestRxUdp.Substring(9, 2)) > Int32.Parse(amperage))
                    {
                        resultNotFound = false;
                    }
                    else
                    {
                        Console.WriteLine("WARNING!!! UPD response is not higher \"" + amperage + "\", step: " + step);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("WARNING!!! No UPD response, step: " + step);
                }
            }
            Assert.AreEqual(resultNotFound, false);
        }


        [When(@"I send authorization API request to terminal ""(.*)""")]
        public void WhenISendAuthorizationAPIRequestToTerminal(string terminalId)
        {
            testData.terminalId = terminalId;
            var client = new RestClient(Config.Global.env_api_address);
            
            var request = new RestRequest("api/v1/{id}/sessions", Method.POST);

            Random generator = new Random();
            testData.token = generator.Next(0, 99999).ToString("D5") + generator.Next(0, 99999).ToString("D5");

            request.AddParameter("unit", testData.unitId);
            request.AddParameter("token", testData.token);
            request.AddUrlSegment("id", testData.terminalId); 

            testData.responseApi =  client.Execute(request);
        }

        [When(@"I verify device status via API request")]
        public void WhenIVerChargingyDeviceStatusViaAPIRequest()
        {
            var client = new RestClient(Config.Global.env_api_address);
            var request = new RestRequest("api/v1/{id}/sessions?token={token}", Method.GET);

            request.AddUrlSegment("id", testData.terminalId);
            request.AddUrlSegment("token", testData.token);

            testData.responseApi = client.Execute(request);
            Console.WriteLine(request.Credentials);
            Console.WriteLine(testData.responseApi.Content);

            var testtest = JObject.Parse(testData.responseApi.Content.Trim(new Char[] { '[', ']' }));
            Console.WriteLine(testtest.GetValue("status"));
        }

        [Then(@"property ""(.*)"" should be ""(.*)""")]
        public void ThenPropertyShouldBe(string propertyName, string status)
        {
            Assert.AreEqual(JObject.Parse(testData.responseApi.Content.Trim(new Char[] { '[', ']' })).GetValue(propertyName).ToString(), status);
        }

        [Then(@"energy status should be valild")]
        public void ThenEnergyStatusShouldBeValild()
        {
            Assert.AreEqual(JObject.Parse(testData.responseApi.Content.Trim(new Char[] { '[', ']' })).GetValue("energy").ToString(), testData.energy.ToString());
        }

        [Then(@"I send udp Charging packages to unit ""(.*)"" with energy ""(.*)""")]
        [Given(@"I send udp Charging packages to unit ""(.*)"" with energy ""(.*)""")]
        public void GivenISendUdpChargingPackagesToUnitWithEnergy(string unitId, int energy)
        {
            System.Threading.Thread.Sleep(3000);

            testData.unitId = unitId;
            var testName = new UdpEndpointTest();
            var step = 0;
            var resultNotFound = true;
            while (step < 3 && resultNotFound)
            {
                step++;
                try
                {
                    testData.requestRxUdp = testName.GetRxRaw(testName.GetUdpPackage("Charging", unitId, energy));
                    resultNotFound = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("WARNING!!! No UPD response, step: " + step);
                }
            }
        }

        [When(@"I send UDP package with status ""(.*)"" to unit")]
        public void WhenISendUDPPackageWithStatusToUnit(string deviceChargeState)
        {
            System.Threading.Thread.Sleep(3000);

            testData.unitId = Config.Global.pterm_unit_id;

            var testName = new UdpEndpointTest();
            var step = 0;
            var resultNotFound = true;
            while (step < 5 && resultNotFound)
            {
                step++;
                try
                {
                    if (deviceChargeState.Equals("Charging"))
                    {
                        testData.energy = testData.energy + new Random().Next(500, 1000);
                        testData.requestRxUdp = testName.GetRxRaw(testName.GetUdpPackage(deviceChargeState, testData.unitId, testData.energy));
                    }
                    else
                    {
                        testData.requestRxUdp = testName.GetRxRaw(testName.GetUdpPackage(deviceChargeState, testData.unitId));
                    }
                    resultNotFound = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("WARNING!!! No UPD response, step: " + step);
                }
            }
        }

        [When(@"I send authorization API request to terminal")]
        public void WhenISendAuthorizationAPIRequestToTerminal()
        {
            testData.terminalId = Config.Global.pterm_terminal_id;
            var client = new RestClient(Config.Global.env_api_address);
            var request = new RestRequest("api/v1/{id}/sessions", Method.POST);

            Random generator = new Random();
            testData.token = generator.Next(0, 99999).ToString("D5") + generator.Next(0, 99999).ToString("D5");

            request.AddParameter("unit", testData.unitId);
            request.AddParameter("token", testData.token);
            request.AddUrlSegment("id", testData.terminalId);

            testData.responseApi = client.Execute(request);
        }

        [Then(@"response should contain S section higher ""(.*)""")]
        public void ThenResponseShouldContainSSectionHigher(string data)
        {
            Assert.IsTrue(Int32.Parse(testData.requestRxUdp.Substring(19, 3)) > Int32.Parse(data));
        }

        [Given(@"I save response to list")]
        [When(@"I save response to list")]
        public void GivenISaveResponseToList()
        {
            testData.responseList.Add(testData.requestRxUdp);
        }

        [Then(@"at least one value of the ""(.*)"" section should not be same")]
        public void ThenValuesOfTheSectionShouldNotBeSame(string sectionLetter)
        {
            int letterIndex = 0;
            int segmentLength = 0;

            switch (sectionLetter)
            {
                case "A":
                    letterIndex = 9;
                    segmentLength = 2;
                    break;
                case "M":
                    letterIndex = 12;
                    segmentLength = 2;
                    break;
                case "C":
                    letterIndex = 15;
                    segmentLength = 2;
                    break;
                case "S":
                    letterIndex = 19;
                    segmentLength = 3;
                    break;
                default:
                    Console.WriteLine("Incorrect section");
                    Assert.Fail();
                    break;
            }
            
            //Console.WriteLine("Section " + sectionLetter + ". Start: " + letterIndex + ", lenth: " + segmentLength);
            List<string> substringList = new List<string>();

            foreach (var element in testData.responseList)
            {
                //Console.WriteLine(element);
                substringList.Add(element.Substring(letterIndex, segmentLength));
            }
            //foreach (var element in substringList)
            //{
            //    Console.WriteLine(element);
            //}
            //Console.WriteLine(substringList.Distinct().Count());
            Assert.Greater(substringList.Distinct().Count(), 1);
        }

    }
}