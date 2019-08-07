using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;
using TestAutomationFramework.POM.B2c;
using TestAutomationFramework.Services;
using TestAutomationFramework.Services.ApiService;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2cUiServiceBusEventsSteps
    {
        private readonly B2cUiGeneralSteps.TestData testData;
        private readonly RemoteWebDriver driver;

        public B2cUiServiceBusEventsSteps(B2cUiGeneralSteps.TestData testData, RemoteWebDriver driver)
        {
            this.testData = testData;
            this.driver = driver;
        }

        [Then(@"event with the label ""(.*)"" for the device with key in config ""(.*)"" should contains text ""(.*)"" \(b2c\)")]
        public void ThenEventWithTheLabelForTheDeviceWithKeyInConfigShouldContainsTextBc(string eventLabel, string configKey, string textShouldExist)
        {
            string result = "";
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            for (int i = 0; i < 10; i++)
            {
                wait.Until(wd => driver.FindElement(By.XPath("//div[@id = 'sb-log']/div[@class = 'row']")).Displayed);
                System.Threading.Thread.Sleep(500);

                IList<IWebElement> AllEvents = driver.FindElements(By.XPath("//div[@id = 'sb-log']/div[@class = 'row']/div/div/div[@class = 'panel-heading']/h4"));
                foreach (var element in AllEvents)
                {
                    if (element.Text.Contains(eventLabel))
                    {
                        IList<IWebElement> DesiredEvents = driver.FindElements(By.XPath("//div[@id = 'sb-log']/div[@class = 'row']/div/div/div[@class = 'panel-heading']/h4[contains(text(), '" + eventLabel + "')]/../../div[@class = 'panel-body']/div/span"));
                        foreach (var dEvent in DesiredEvents)
                        {
                            if (dEvent.Text.Contains(Config.Global[configKey]) && dEvent.Text.Contains(textShouldExist))
                            {
                                Assert.True(true);
                                return;
                            }
                        }
                            
                    }
                }
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.Id("get-sb-events-button")).Click();
            }
            Assert.False(true, "Unable to locate text \"" + textShouldExist + "\" in the frase \"" + result + "\"");
        }

        //Here we can use current/currentPlusHour keywords to set date/time from remembered on previous steps,
        //or directly from variable "dateTime"
        [When(@"I set field with Id ""(.*)"" to ""(.*)"" DateTime \(b2c\)")]
        public void WhenISetFieldWithIdToDateTimeBc(string fieldId, string dateTime)
        {
            var currentTime = testData.dateTimeOnDevice;
            var generalPage = new B2cGeneralPage(driver);
            string time;
            switch (dateTime)
            {
                case "current":
                    time = currentTime.AddHours(10).ToString("MM-dd-yyyy hh:mm tt", CultureInfo.InvariantCulture);
                    break;
                case "currentPlusHour":
                    time = currentTime.AddHours(11).ToString("MM-dd-yyyy hh:mm tt", CultureInfo.InvariantCulture);
                    break;
                default:
                    time = dateTime;
                    break;
            }
            Console.WriteLine("Trying to set field with Id \"" + fieldId + "\" to: " + time);
            generalPage.SetInputValueById(fieldId, time);
        }

        [When(@"I set field with Id ""(.*)"" to current time \(b2c\)")]
        public void WhenISetFieldWithIdToCurrentTimeBc(string fieldId)
        {
            driver.FindElement(By.Id(fieldId)).Clear();
            driver.FindElement(By.Id(fieldId)).SendKeys(testData.dateTimeOnDevice.AddMinutes(1).ToString("hh:mm tt", CultureInfo.InvariantCulture));
        }

    }
}
