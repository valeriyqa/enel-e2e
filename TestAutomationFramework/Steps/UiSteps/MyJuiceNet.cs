using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationFramework.Services.ApiService;

namespace TestAutomationFramework.Steps.UiSteps
{
    [Binding]
    class MyJuiceNet
    {
        private readonly RemoteWebDriver driver;
        public MyJuiceNet(RemoteWebDriver driver) => this.driver = driver;


        [Given(@"JuiceNet device is not added")] //done
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

        [Then(@"JuiceNet device with Id ""(.*)"" should exist is ""(.*)""")]
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

        [When(@"I click More Details for device with Id ""(.*)""")]
        public void WhenIClickMoreDetailsForDeviceWithId(string deviceId)
        {
            driver.FindElementByCssSelector("[href*='unitID=" + deviceId + "']").Click();
        }

    }
}
