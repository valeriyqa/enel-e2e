using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Threading.Tasks;
using System.Net;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2CAdminUtilitiesFeatureSteps
    {
        public class TestData
        {
            public string TimeZone;
            public string date;
            public List<int> HeatMap;
        }

        private TestData testData;
        private readonly RemoteWebDriver driver;
        private ScenarioContext scenarioContext;

        public B2CAdminUtilitiesFeatureSteps(RemoteWebDriver driver, ScenarioContext scenarioContext, TestData testData)
        {
            this.driver = driver;
            this.scenarioContext = scenarioContext; //probably should be deleted
            this.testData = testData;
        }

        [Then(@"I save device ""(.*)"" ID \(b2c\)")]
        public void WhenISaveDeviceIDBc(string deviceID)
        {
            var sharedDeviceID = driver.FindElement(By.CssSelector("div.page-header > p:nth-child(3)")).Text;
            Assert.AreEqual(Convert.ToString(sharedDeviceID), deviceID);
            ScenarioContext.Current["sharedDeviceID"] = sharedDeviceID;
        }
        [When(@"I set field Id ""(.*)"" with shared data \(b2c\)")]
        public void WhenISetFieldIdWithSharedDataBc(string fieldId)
        {
            var generalPage = new B2cGeneralPage(driver);
            var sharedData = ScenarioContext.Current["sharedDeviceID"];
            generalPage.SetInputValueById(fieldId, Convert.ToString(sharedData));
        }
        [When(@"I click on related to the field with Id ""(.*)"" search button \(b2c\)")]
        public void WhenIClickOnRelatedToTheFieldWithIdSearchButtonBc(string deviceID)
        {
            driver.FindElement(By.XPath("//input[@id='" + deviceID + "']/ancestor-or-self::div/span//i")).Click();
        }

        [Then(@"I wait ""(.*)"" seconds \(b2c\)")]
        public void ThenIWaitSecondsBc(int seconds)
        {
            System.Threading.Thread.Sleep(seconds);
        }

        [Then(@"Info tab should contains unit with Id ""(.*)"" from config file \(b2c\)")]
        public void ThenInfoTabShouldContainsUnitWithIdFromConfigFileBc(string configKey)
        {
            Console.WriteLine(driver.FindElement(By.XPath("//div[@id='boxInfo']//a/span")).Text);
            Console.WriteLine(Config.Global[configKey]);
            Assert.AreEqual(driver.FindElement(By.XPath("//div[@id='boxInfo']//a/span")).Text, Config.Global[configKey]);
        }

        [Then(@"I should see Unit Id ""(.*)"" \(b2c\)")] //probably we have to delete it
        public void ThenIShouldSeeUnitIdBc(string deviceID)
        {
            var actualDeviceID = driver.FindElement(By.XPath("//*[@id='boxInfo']/div/div[1]/div[1]/h4/a/span")).Text;
            Assert.AreEqual(Convert.ToString(actualDeviceID), deviceID);
        }

        [When(@"I save Weekday Start time to shared data \(b2c\)")]
        public void WhenISaveWeekdayStartTimeToSharedDataBc()
        {
            string startTimeTemp = driver.FindElement(By.XPath("//*[@id='timepickerWdS']")).GetAttribute("value").ToString();
            string startTime = "";

            DateTime startTimeDate = DateTime.Parse(startTimeTemp);
            startTime = startTimeDate.ToString("HH:mm");
            scenarioContext["startTime"] = startTime;
        }
        [When(@"I save Weekday End time to shared data \(b2c\)")]
        public void WhenISaveWeekdayEndTimeToSharedDataBc()
        {
            string endTimeTemp = driver.FindElement(By.XPath("//*[@id='timepickerWdE']")).GetAttribute("value").ToString();
            string endTime = "";

            DateTime endTimeDate = DateTime.Parse(endTimeTemp);
            endTime = endTimeDate.ToString("HH:mm");
            scenarioContext["endTime"] = endTime;
        }
        [Then(@"TOU Start time should be equal to shared data \(b2c\)")]
        public void ThenTOUStartTimeShouldBeEqualToSharedDataBc()
        {
            var startTime = scenarioContext["startTime"];
            var actualStartTime = driver.FindElement(By.CssSelector("[id='tou_wd_start']")).Text;
            Assert.AreEqual(Convert.ToString(actualStartTime), Convert.ToString(startTime));
        }

        [Then(@"TOU End time should be equal to shared data \(b2c\)")]
        public void ThenTOUEndTimeShouldBeEqualToSharedDataBc()
        {
            var endTime = scenarioContext["endTime"];
            var actualEndTime = driver.FindElement(By.CssSelector("[id='tou_wd_end']")).Text;
            Assert.AreEqual(Convert.ToString(actualEndTime), Convert.ToString(endTime));
        }

        [Given(@"related to Device ID policy set to ""(.*)"" \(b2c\)")]
        public void GivenRelatedToDeviceIDPolicySetToBc(string policy)
        {
            if (!driver.FindElement(By.XPath("//*[@id='boxInfo']//li/label[contains(text(), 'Current policy')]//ancestor::li")).Text.Trim().Replace("Current policy: ", "").Equals(policy))
            {
                var generalPage = new B2cGeneralPage(driver);
                generalPage.ClickButtonWithName("Set " + policy);
            }
            Assert.True(driver.FindElement(By.XPath("//*[@id='boxInfo']//li/label[contains(text(), 'Current policy')]//ancestor::li")).Text.Trim().Replace("Current policy: ", "").Equals(policy));
        }


        [Then(@"I should see related to Device ID policy ""(.*)"" \(b2c\)")]
        public void ThenIShouldSeeRelatedToDeviceIDPolicyBc(string policy)
        {
            string policyClass = "";
            if (policy == "Default")
            {
                policyClass = "color-policy-default";
            }
            else if (policy == "Green WT")
            {
                policyClass = "color-policy-green";
            }
            Assert.True(driver.FindElement(By.XPath("//*[@id='boxInfo']//li/label[contains(text(), 'Current policy')]//ancestor::li/div")).GetAttribute("class").Contains(policyClass));

        }
        [Then(@"I should see Unit Policy ""(.*)"" \(b2c\)")]
        public void ThenIShouldSeeUnitPolicyBc(string policy)
        {
            Assert.True(driver.FindElement(By.XPath("//h4[contains(text(), 'Policy')]//following-sibling::span")).Text.Contains(policy));
        }




        [When(@"I set field with Id ""(.*)"" to ""(.*)"" value")]
        public void WhenISetFieldWithIdToValue(string elemtId, string elementValue)
        {
            try
            {
                driver.FindElement(By.XPath("//input[@id = '" + elemtId + "']")).Clear();
                driver.FindElement(By.XPath("//input[@id = '" + elemtId + "']")).SendKeys("elementValue");
            }
            catch (Exception)
            {

                try
                {
                    driver.FindElement(By.XPath("//textarea[@id = '" + elemtId + "']")).Clear();
                    driver.FindElement(By.XPath("//textarea[@id = '" + elemtId + "']")).SendKeys("elementValue");
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        [When(@"I click on the text ""(.*)"" in the table ""(.*)"" \(b2c\)")]
        public void WhenIClickOnTheTextInTheTableBc(string text, string tableHeader)
        {
            driver.FindElement(By.XPath("//div[@class = 'panel-heading']//*[contains(text(), '" + tableHeader + "')]/ancestor::div[contains(@class, 'panel-emotorwerks')]//td[contains(text(), \"" + text + "\")]")).Click();
        }

        [Then(@"I wait until table with header ""(.*)"" will be displayed \(b2c\)")]
        public void ThenIWaitUntilTableWithHeaderWillBeDisplayedBc(string tableHeader)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(wd => driver.FindElement(By.XPath("//div[@class = 'panel-heading']//*[contains(text(), '" + tableHeader + "')]")).Displayed);
        }

        [Then(@"I get heatmap data for date ""(.*)"" \(b2c\)")]
        public void ThenIGetHeatmapDateForDateBc(string heatMapDate)
        {
            List<float> heatMap = new List<float>();
            var heatMapElements = driver.FindElements(By.XPath("//th[not(contains(@style,'display: none;'))]//span[contains(text(), '" + heatMapDate + "')]/ancestor::tr[last()]//td"));
            foreach (var element in heatMapElements)
            {
                try
                {
                    Console.WriteLine(element.GetAttribute("title"));
                    heatMap.Add(float.Parse(element.GetAttribute("title"), CultureInfo.InvariantCulture.NumberFormat));
                }
                catch (Exception)
                {

                    heatMap.Add(-1);
                }
            }
            Console.WriteLine("<---------------------------------------------------->");
            foreach (var item in heatMap)
            {
                Console.WriteLine(item);
            }
        }

        [When(@"I get heatmap data for date ""(.*)"" with offset \(b2c\)")]
        [Then(@"I get heatmap data for date ""(.*)"" with offset \(b2c\)")]
        public void ThenIGetHeatmapDataForDateWithOffsetBc(string heatMapDate)
        {
            if (heatMapDate.ToLower().Equals("today"))
            {
                heatMapDate = DateTime.Now.ToString("ddd M/d/yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                Console.WriteLine("Keyword \"today\" detected, converting to: " + heatMapDate);
            }
            else if (heatMapDate.ToLower().Equals("yesterday"))
            {
                heatMapDate = DateTime.Now.AddHours(-24).ToString("ddd M/d/yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                Console.WriteLine("Keyword \"yesterday\" detected, converting to: " + heatMapDate);
            }
            List<float> heatMap = new List<float>();
            var heatMapElementsCurrent = driver.FindElements(By.XPath("//th[not(contains(@style,'display: none;'))]//span[contains(text(), '" + heatMapDate + "')]/ancestor::tr[last()]//td"));
            var heatMapElementsNext = driver.FindElements(By.XPath("//th[not(contains(@style,'display: none;'))]//span[contains(text(), '" + heatMapDate + "')]/ancestor::tr[last()]/following-sibling::tr[1]//td"));
            var heatMapElements = new List<IWebElement>();
            heatMapElements.AddRange(heatMapElementsCurrent);
            heatMapElements.AddRange(heatMapElementsNext);

            foreach (var element in heatMapElements)
            {
                try
                {
                    //Console.WriteLine(element.GetAttribute("title"));
                    heatMap.Add(float.Parse(element.GetAttribute("title"), CultureInfo.InvariantCulture.NumberFormat));
                }
                catch (Exception)
                {

                    heatMap.Add(-1);
                }
            }
            var offset = Tools.HeatMap.getOffsetToUtc(testData.TimeZone);
            Console.WriteLine(offset);
            var heatMapResult = heatMap.GetRange(DateTime.Parse(heatMapDate).Add(offset).TimeOfDay.Hours*4, 24*4);
            //Console.WriteLine("<---------------------------------------------------->");
            //foreach (var item in heatMapResult)
            //{
            //    Console.WriteLine(item);
            //}
        }

        [Given(@"I send heatmap API request for device ""(.*)"" from config, with ""(.*)"" date to endpoint ""(.*)"" \(b2c\)")]
        public void GivenISendHeatmapAPIRequestForDeviceFromConfigWithDateToEndpointBc(string configKey, string heatMapDate, string endPoint)
        {
            if (heatMapDate.ToLower().Equals("today"))
            {
                heatMapDate = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                Console.WriteLine("Keyword \"today\" detected, converting to: " + heatMapDate);
            }
            else if (heatMapDate.ToLower().Equals("yesterday"))
            {
                heatMapDate = DateTime.Now.AddHours(-24).ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                Console.WriteLine("Keyword \"yesterday\" detected, converting to: " + heatMapDate);
            }

            testData.date = heatMapDate;

            if (!heatMapDate.EndsWith("Z"))
            {
                heatMapDate = heatMapDate + "Z";
            }

            //var urlPath = Config.Global.env_api_address.Replace("http://", "https://") + endPoint.ToLower() + "/unit/" + Config.Global[configKey] + "/data";
            var urlPath = "https://" +  Config.Global.env_udp_address + "/" + endPoint.ToLower() + "/unit/" + Config.Global[configKey] + "/data";
            Console.WriteLine(urlPath);
            var client = new RestClient(urlPath);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");


            //List<int> value = new List<int>(new int[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 432, 912, 354, 989, 875 });
            testData.HeatMap = Tools.HeatMap.getRandomForHeatMap();

            dynamic ecache = new ExpandoObject();
            ecache.interval_min = 15;
            ecache.intervals = new ExpandoObject();
            (ecache.intervals as IDictionary<string, Object>)[heatMapDate] = testData.HeatMap;
            dynamic eventlog = new ExpandoObject();

            dynamic heatMap = new ExpandoObject();
            heatMap.ecache = ecache;
            heatMap.eventlog = eventlog;

            var json = JsonConvert.SerializeObject(heatMap, Formatting.Indented);
            //Console.WriteLine(json);

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            request.AddParameter("text/json", json, ParameterType.RequestBody);
            
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.ErrorException);
        }

        [When(@"I remember device timezone \(b2c\)")]
        public void WhenIRememberDeviceTimezoneBc()
        {
            testData.TimeZone = driver.FindElement(By.XPath("//select[@id = 'timeZoneId']//option[contains(@selected, 'selected')]")).GetAttribute("value");
        }

        [When(@"I set correct date range \(b2c\)")]
        [Then(@"I set correct date range \(b2c\)")]
        public void ThenISetCorrectDateRangeBc()
        {
            var date = DateTime.Parse(testData.date, CultureInfo.InvariantCulture);
            var generalPage = new B2cGeneralPage(driver);
            generalPage.SetInputValueById("dateRangeStart", date.AddDays(-3).ToString("MM-dd-yyyy", CultureInfo.InvariantCulture));
            generalPage.SetInputValueById("dateRangeEnd", date.AddDays(3).ToString("MM-dd-yyyy", CultureInfo.InvariantCulture));
            generalPage.ClickButtonWithId("get-heatmap-data-button");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(wd => driver.FindElement(By.Id("heatmap-table")).Displayed);
        }

        [Then(@"heatmap data for date ""(.*)"" with offset should be equal to previously sent \(b2c\)")]
        public void ThenHeatmapDataForDateWithOffsetShouldBeEqualToPreviouslySentBc(string heatMapDate)
        {
            if (heatMapDate.ToLower().Equals("today"))
            {
                heatMapDate = DateTime.Now.ToString("ddd M/d/yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                Console.WriteLine("Keyword \"today\" detected, converting to: " + heatMapDate);
            }
            else if (heatMapDate.ToLower().Equals("yesterday"))
            {
                heatMapDate = DateTime.Now.AddHours(-24).ToString("ddd M/d/yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                Console.WriteLine("Keyword \"yesterday\" detected, converting to: " + heatMapDate);
            }
            List<string> heatMap = new List<string>();
            var heatMapElementsCurrent = driver.FindElements(By.XPath("//th[not(contains(@style,'display: none;'))]//span[contains(text(), '" + heatMapDate + "')]/ancestor::tr[last()]//td"));
            var heatMapElementsNext = driver.FindElements(By.XPath("//th[not(contains(@style,'display: none;'))]//span[contains(text(), '" + heatMapDate + "')]/ancestor::tr[last()]/following-sibling::tr[1]//td"));
            var heatMapElements = new List<IWebElement>();
            heatMapElements.AddRange(heatMapElementsCurrent);
            heatMapElements.AddRange(heatMapElementsNext);

            foreach (var element in heatMapElements)
            {
                try
                {
                    //Console.WriteLine(element.GetAttribute("title"));
                    heatMap.Add(element.GetAttribute("title"));
                }
                catch (Exception)
                {

                    heatMap.Add(string.Empty);
                }
            }
            var offset = Tools.HeatMap.getOffsetToUtc(testData.TimeZone);
            Console.WriteLine(offset);
            var heatMapResult = heatMap.GetRange(DateTime.Parse(heatMapDate).Add(offset).TimeOfDay.Hours * 4, 24 * 4);

            //Console.WriteLine("<---------------------------------------------------->");
            //foreach (var item in heatMapResult)
            //{
            //    Console.WriteLine(item);
            //}

            CollectionAssert.AreEqual(Tools.HeatMap.getExpectedResultHeatMap(testData.HeatMap), heatMapResult);
        }


    }
}
