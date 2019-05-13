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

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2CAdminUtilitiesFeatureSteps
    {
        private readonly RemoteWebDriver driver;
        private ScenarioContext scenarioContext;

        public B2CAdminUtilitiesFeatureSteps(RemoteWebDriver driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            this.scenarioContext = scenarioContext;
        }

        [Then(@"I save device ""(.*)"" ID \(b2c\)")]
        public void WhenISaveDeviceIDBc(string deviceID)
        {
            var sharedDeviceID = driver.FindElement(By.CssSelector("div.page-header > p:nth-child(3)")).Text;
            Assert.AreEqual(Convert.ToString(sharedDeviceID), deviceID);
            ScenarioContext.Current["sharedData"] = sharedDeviceID;
        }
        [When(@"I set field Id ""(.*)"" with shared data \(b2c\)")]
        public void WhenISetFieldIdWithSharedDataBc(string fieldId)
        {
            var generalPage = new B2cGeneralPage(driver);
            var sharedData = ScenarioContext.Current["sharedData"];
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

        [Then(@"I should see Unit Id ""(.*)"" \(b2c\)")]
        public void ThenIShouldSeeUnitIdBc(string deviceID)
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //wait.Until(wd => driver.FindElement(By.XPath("//*[@id='boxInfo']/div/div[1]/div[1]/h4/a/span")).Displayed);

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


    }
}
