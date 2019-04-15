using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2cUiLoadGroupSteps
    {
        private readonly B2cUiGeneralSteps.TestData testData;


        private readonly RemoteWebDriver driver;
        public B2cUiLoadGroupSteps(B2cUiGeneralSteps.TestData testData, RemoteWebDriver driver)
        {
            this.testData = testData;
            this.driver = driver;
        }

        [Given(@"load group table is empty \(b2c\)")]
        public void GivenLoadGroupTableIsEmptyBc()
        {
            var generalPage = new B2cGeneralPage(driver);
            IJavaScriptExecutor js = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            if ((Int64)js.ExecuteScript("return $('button.btn-delete-load-group').length;") > 0)
            {
                IList<IWebElement> deleteButtons = driver.FindElements(By.XPath("//button[contains(@class, 'btn-delete-load-group')]"));
                foreach (var button in deleteButtons)
                {
                    button.Click();
                    wait.Until(wd => driver.FindElements(By.XPath("//div[@class='modal fade in']")).Count > 0);
                    generalPage.ClickButtonWithName("Delete LoadGroup");
                    System.Threading.Thread.Sleep(1000);
                    generalPage.ClickButtonWithName("Close");
                }
            }
        }

        [Then(@"Alert with status ""(.*)"" and text ""(.*)"" should be displayed \(b2c\)")]
        public void ThenAlertWithStatusAndTextShouldBeDisplayedBc(string alertStatus, string alertString)
        {
            var generalPage = new B2cGeneralPage(driver);
            for (int i = 0; i < 10; i++)
            {
                if (generalPage.getDisplayedAlertText().Contains(alertString))
                {
                    Assert.True(generalPage.getDisplayedAlertClass().Contains(alertStatus.ToLower()));
                    return;
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
            Assert.Fail();
        }

        [Then(@"Load group with name ""(.*)"" should apear in the table is ""(.*)"" \(b2c\)")]
        public void ThenLoadGroupWithNameShouldApearInTheTableIsBc(string groupName, string isExist)
        {
            System.Threading.Thread.Sleep(500);
            var generalPage = new B2cGeneralPage(driver);
            DataTable Table = generalPage.GetTableById("loadgroups-table");
            foreach (DataRow dataRow in Table.Rows)
            {
                if (dataRow.ItemArray[0].Equals(groupName))
                {
                    Assert.AreEqual(Boolean.Parse(isExist), true);
                    return;
                }
            }
            Assert.AreEqual(Boolean.Parse(isExist), false);
        }

        [Then(@"I check load group ""(.*)"" for ""(.*)"" units in table \(b2c\)")]
        public void ThenICheckLoadGroupForUnitsInTableBc(string groupName, string unitCount)
        {
            var generalPage = new B2cGeneralPage(driver);
            DataTable Table = generalPage.GetTableById("loadgroups-table");
            foreach (DataRow dataRow in Table.Rows)
            {
                if (dataRow.ItemArray[0].Equals(groupName))
                {
                    Assert.AreEqual(unitCount, dataRow.ItemArray[2]);
                    return;
                }
            }
            Assert.AreEqual(true, false);
        }

        [When(@"I click on button in the alert with name ""(.*)"" \(b2c\)")]
        public void WhenIClickOnButtonInTheAlertWithNameBc(string buttonText)
        {
            var generalPage = new B2cGeneralPage(driver);
            var initialAlert = generalPage.getDisplayedAlertId();
            generalPage.ClickButtonWithName(buttonText);

            for (int i = 0; i < 1; i++)
            {
                System.Threading.Thread.Sleep(500);
                if (initialAlert != generalPage.getDisplayedAlertId())
                {
                    break;
                }
            }
        }

        [Then(@"Load group table should be empty \(b2c\)")]
        public void ThenLoadGroupTableShouldBeEmptyBc()
        {
            System.Threading.Thread.Sleep(500);
            IJavaScriptExecutor js = driver;
            Assert.AreEqual((Int64)js.ExecuteScript("return $('button.btn-delete-load-group').length;"), 0);
        }

        [Given(@"I click on empty Load group with name ""(.*)"" string in table \(b2c\)")]
        public void GivenIClickOnEmptyLoadGroupWithNameStringInTableBc(string groupName)
        {
            driver.FindElement(By.XPath("//*[@id='loadgroups-table']//input[contains(@value,'" + groupName + "')]//ancestor::td")).Click();
        }

        [Then(@"Device ""(.*)"" area contain load group icon \(b2c\)")]
        public void ThenDeviceAreaContainLoadGroupIconBc(string deviceID)
        {
            IWebElement element = driver.FindElement(By.CssSelector("[id='unitsList'] div[data-unitid = '" + deviceID + "'] [title = 'Device is in Load Group']"));
            Assert.True(element.Displayed);
        }

    }
}
