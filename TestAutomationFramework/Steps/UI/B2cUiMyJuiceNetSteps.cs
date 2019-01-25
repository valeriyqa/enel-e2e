using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;
using TestAutomationFramework.Services.ApiService;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2cUiMyJuiceNetSteps
    {
        //private readonly TestData testData;
        //private readonly RemoteWebDriver driver;
        //public B2cUiGeneralSteps(TestData testData, RemoteWebDriver driver)
        //{
        //    this.testData = testData;
        //    this.driver = driver;
        //}
        private readonly B2cUiGeneralSteps.TestData testData;


        private readonly RemoteWebDriver driver;
        public B2cUiMyJuiceNetSteps(B2cUiGeneralSteps.TestData testData, RemoteWebDriver driver)
        {
            this.testData = testData;
            this.driver = driver;
        }

        [Given(@"JuiceNet device is not added \(b2c\)")] //done
        public void JuiceNetDeviceIsNotAdded()
        {
            Console.WriteLine("JuiceNet Device is not added");
            RestApi.SendApiRequest(RestApi.GetApiRequest("delete_account_unit"));
        }

        //[Then(@"JuiceNet device with Id ""(.*)"" should be added")]
        //public void ThenJuiceNetDeviceWithIdShouldBeAdded(string deviceId)
        //{
        //    IList<IWebElement> all = driver.FindElements(By.ClassName("unit-info-container"));
        //    bool elementExist = false;

        //    foreach (IWebElement element in all)
        //    {
        //        Console.WriteLine(element.GetAttribute("data-unitid"));
        //        if (element.GetAttribute("data-unitid").Equals(deviceId))
        //        {
        //            elementExist = true;
        //            break;
        //        }
        //    }
        //    Assert.IsTrue(elementExist);
        //}

        //[Then(@"JuiceNet device with Id ""(.*)"" should NOT exist")]
        //public void ThenJuiceNetDeviceWithIdShouldNOTExist(int deviceId)
        //{
        //    IList<IWebElement> all = driver.FindElements(By.ClassName("unit-info-container"));
        //    bool elementExist = false;

        //    foreach (IWebElement element in all)
        //    {
        //        if (element.GetAttribute("data-unitid").Equals(deviceId))
        //        {
        //            elementExist = true;
        //            break;
        //        }
        //    }
        //    Assert.IsFalse(elementExist);
        //}

        [Then(@"JuiceNet device with Id ""(.*)"" should exist is ""(.*)"" \(b2c\)")]
        public void ThenJuiceNetDeviceWithIdShouldExistIs(string deviceId, string shouldExist)
        {
            IList<IWebElement> all = driver.FindElements(By.ClassName("unit-info-container"));
            bool elementExist = false;

            foreach (IWebElement element in all)
            {
                if (element.GetAttribute("data-unitid").Equals(deviceId))
                {
                    elementExist = true;
                    break;
                }
            }
            Assert.AreEqual(bool.Parse(shouldExist), elementExist);
        }

        [When(@"I click More Details for device with Id ""(.*)"" \(b2c\)")]
        public void WhenIClickMoreDetailsForDeviceWithId(string deviceId)
        {
            driver.FindElementByXPath("//div[@data-unitid = '" + deviceId + "']//div[contains(@class, 'panel-footer')]//span").Click();
        }

        [When(@"I click all checkboxes on panel with Id ""(.*)"" \(b2c\)")]
        public void WhenIClickAllCheckboxesOnPanelWithId(string panelId)
        {
            IList<IWebElement> allCheckboxes = driver.FindElements(By.XPath("//div[@id = '" + panelId + "']//input[contains(@type, 'checkbox')]"));
            foreach (var checkbox in allCheckboxes)
            {
                checkbox.Click();
            }
        }

        [Then(@"all checkboxes on panel with Id ""(.*)"" should be activated \(b2c\)")]
        public void ThenAllCheckboxesOnPanelWithIdShouldBeActivated(string panelId)
        {
            IList<IWebElement> allCheckboxes = driver.FindElements(By.XPath("//div[@id = '" + panelId + "']//input[contains(@type, 'checkbox')]"));
            foreach (var checkbox in allCheckboxes)
            {
                Assert.AreEqual("true", checkbox.GetAttribute("checked"));
            }
        }

        [Given(@"all checkboxes on panel with Id ""(.*)"" is not activated \(b2c\)")]
        public void AllCheckboxesOnPanelWithIdIsNotActivated(string panelId)
        {
            IList<IWebElement> allCheckboxes = driver.FindElements(By.XPath("//div[@id = '" + panelId + "']//input[contains(@type, 'checkbox')]"));
            foreach (var checkbox in allCheckboxes)
            {
                if (null != checkbox.GetAttribute("checked") && checkbox.GetAttribute("checked").Equals("true"))
                {
                    checkbox.Click();
                }
            }
            var generalPage = new B2cGeneralPage(driver);
            generalPage.ClickButtonWithId("saveNotificationsButton");
        }

        [Then(@"I click on tab with label ""(.*)"" \(b2c\)")]
        [When(@"I click on tab with label ""(.*)"" \(b2c\)")]
        public void WhenIClickOnTabWithLable(string label)
        {
            driver.FindElement(By.XPath("//ul[@id = 'unit_details_tabs']//span[contains(text(),'" + label + "')]//ancestor::a")).Click();
        }

        [Then(@"table should be empty \(b2c\)")]
        public void ThenTableShouldBeEmptyBc()
        {
            foreach (DataRow dataRow in testData.table.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }
        }

    }
}
