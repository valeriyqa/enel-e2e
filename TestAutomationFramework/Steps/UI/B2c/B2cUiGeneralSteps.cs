using JsonConfig;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2cUiGeneralSteps
    {
        public class TestData
        {
            public DateTime dateTimeOnDevice;
            public string energy;
            public string savings;
            public DataTable table;
            public string guestPairingPin;
            public string ipAddress;
            public List<string> devicesId =new List<string>();
        }

        private readonly TestData testData;
        private readonly RemoteWebDriver driver;
        private ScenarioContext scenarioContext;

        public B2cUiGeneralSteps(TestData testData, RemoteWebDriver driver, ScenarioContext scenarioContext)
        {
            this.testData = testData;
            this.driver = driver;
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I verify TFS test config")]
        public void GivenIVerifyTFSTestConfig()
        {
            Console.WriteLine("--> I verify TFS test config test step started");

            foreach (var item in Config.Global)
            {
                Console.WriteLine("-> " + item.Key + " = " + item.Value);
            }


            Console.WriteLine("--> I verify TFS test config test step finished");
        }


        [Given(@"I navigate to the ""(.*)"" page \(b2c\)")]
        [Then(@"I navigate to the ""(.*)"" page \(b2c\)")]
        [When(@"I navigate to the ""(.*)"" page \(b2c\)")]
        public void INavigateToThePageB2B(string pageName)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.ClickMenuByName(pageName);
            Assert.AreEqual(driver.Url, generalPage.GetAddressByMenuName(pageName));
        }

        [Given(@"field with Id ""(.*)"" is equal to ""(.*)"" \(b2c\)")]
        public void GivenFieldWithIdIsEqualToBc(string fieldId, string fieldValue)
        {
            var generalPage = new B2cGeneralPage(driver);
            string result = generalPage.GetInputValueById(fieldId);
            if (!result.Equals(fieldValue))
            {
                generalPage.ClearInputValueById(fieldId);
                generalPage.SetInputValueById(fieldId, fieldValue);
            }
            //Assert.AreEqual(generalPage.GetInputValueById(fieldId), result);
        }


        [Then(@"field with Id ""(.*)"" should be equal to ""(.*)"" \(b2c\)")]
        public void ThenFieldWithIdShouldBeEqualToBc(string fieldId, string fieldValue)
        {
            var generalPage = new B2cGeneralPage(driver);
            string result = generalPage.GetInputValueById(fieldId);

            string expectedResult;
            switch (fieldValue.Replace(" ", "").ToLower())
            {
                case "today":
                    expectedResult = DateTime.Now.ToString("MM-dd-yyyy");
                    break;
                case "dayweekago":
                    expectedResult = DateTime.Now.AddDays(-7).ToString("MM-dd-yyyy");
                    break;
                default:
                    expectedResult = fieldValue;
                    break;
            }

            Console.WriteLine("Current result:" + result);
            Console.WriteLine("Expected result:" + expectedResult);

            Assert.AreEqual(expectedResult, result);
        }

        [Then(@"field with Label ""(.*)"" should be equal to ""(.*)"" \(b2c\)")]
        public void ThenFieldWithLabelShouldBeEqualToBc(string fieldLabel, string fieldValue)
        {
            var generalPage = new B2cGeneralPage(driver);
            string result = generalPage.GetInputValueByLabel(fieldLabel);
            string expectedResult;
            switch (fieldValue.Replace(" ", "").ToLower())
            {
                case "today":
                    expectedResult = DateTime.Now.ToString("MM-dd-yyyy");
                    break;
                case "dayweekago":
                    expectedResult = DateTime.Now.AddDays(-7).ToString("MM-dd-yyyy");
                    break;
                default:
                    expectedResult = fieldValue;
                    break;
            }

            Console.WriteLine("Current result:" + result);
            Console.WriteLine("Expected result:" + expectedResult);

            Assert.AreEqual(expectedResult, result);
        }

        [When(@"I set field with Id ""(.*)"" to ""(.*)"" \(b2c\)")]
        public void WhenISetFieldWithIdToBc(string fieldId, string fieldValue)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.SetInputValueById(fieldId, fieldValue);
        }

        [When(@"I set field with Label ""(.*)"" to ""(.*)"" \(b2c\)")]
        public void WhenISetFieldWithLabelToBc(string fieldLabel, string fieldValue)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.SetInputValueByLabel(fieldLabel, fieldValue);
        }

        [When(@"I select multiple keys from config ""(.*)"" on selector with Id ""(.*)"" \(b2c\)")]
        public void WhenISelectMultipleKeysFromConfigOnSelectorWithIdBc(string configKey, string multipleSelectorId, Table table)
        {
            driver.FindElement(By.XPath("//*[@id ='" + multipleSelectorId + "']/..//span[contains(@class, 'pull-right enel-select-arrow')]")).Click();
            foreach (var row in table.Rows)
            {
                driver.FindElement(By.XPath("//*[@id ='" + multipleSelectorId + "']/..//input[contains(@value, '" + Config.Global[row[0]] + "')]/../span")).Click();
            }
            driver.FindElement(By.XPath("//*[@id ='" + multipleSelectorId + "']/..//span[contains(@class, 'pull-right enel-select-arrow')]")).Click();
        }

        [When(@"I select key from config ""(.*)"" on selector with Id ""(.*)"" \(b2c\)")]
        public void WhenISelectKeysFromConfigOnSelectorWithIdBc(string configKey, string selectorId)
        {
            driver.FindElement(By.XPath("//*[@id ='" + selectorId + "']/..//span[contains(@class, 'pull-right enel-select-arrow')]")).Click();
            driver.FindElement(By.XPath("//*[@id ='" + selectorId + "']/..//input[contains(@value, '" + Config.Global[configKey] + "')]/../span")).Click();
            driver.FindElement(By.XPath("//*[@id ='" + selectorId + "']/..//span[contains(@class, 'pull-right enel-select-arrow')]")).Click();
        }


        //[When(@"I select multiple keys from config ""(.*)"" on selector with Id ""(.*)"" \(b2c\)")]
        //public void WhenISelectMultipleKeysFromConfigOnSelectorWithIdBc(string configKey, string multipleSelectorId, Table table)
        //{
        //    driver.FindElement(By.XPath("//select[@id='" + multipleSelectorId + "']/..//button[contains(@class,'dropdown-toggle')]")).Click();
        //    foreach (var row in table.Rows)
        //    {
        //        driver.FindElement(By.XPath("//select[@id='" + multipleSelectorId + "']/..//input[@value='" + Config.Global[row[0]] + "']")).Click();
        //    }
        //    driver.FindElement(By.XPath("//select[@id='" + multipleSelectorId + "']/..//button[contains(@class,'dropdown-toggle')]")).Click();
        //}

        //probably should be fixed
        [When(@"I select multiple ""(.*)"" on selector with Id ""(.*)"" \(b2c\)")]
        public void WhenISelectMultipleOnSelectorWithIdBc(string value, string multipleSelectorId, Table table)
        {
            driver.FindElement(By.XPath("//select[@id='" + multipleSelectorId + "']/..//button[contains(@class,'dropdown-toggle')]")).Click();
            foreach (var row in table.Rows)
            {
                driver.FindElement(By.XPath("//select[@id='" + multipleSelectorId + "']/..//input[@value='" + row[0] + "']")).Click();
            }
            driver.FindElement(By.XPath("//select[@id='" + multipleSelectorId + "']/..//button[contains(@class,'dropdown-toggle')]")).Click();
        }


        [When(@"I select ""(.*)"" on selector with Id ""(.*)"" \(b2c\)")]
        public void WhenISelectOnSelectorWithIdBc(string selectValue, string selectId)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.SelectValueById(selectId, selectValue);
        }

        [When(@"I select ""(.*)"" on general selector with Id ""(.*)"" \(b2c\)")]
        public void WhenISelectOnGeneralSelectorWithIdBc(string selectValue, string selectId)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.SelectTextByIdGeneral(selectId, selectValue);
        }

        [When(@"I select ""(.*)"" on selector with Label ""(.*)"" \(b2c\)")]
        public void WhenISelectOnSelectorWithLabelBc(string selectValue, string selectLabel)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.SelectValueByLabel(selectLabel, selectValue);
        }

        [When(@"I click on button with Id ""(.*)"" \(b2c\)")]
        public void WhenIClickOnButtonWithId(string buttonId)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.ClickButtonWithId(buttonId);
            //System.Threading.Thread.Sleep(5000);
        }

        [When(@"I click on button with name ""(.*)"" \(b2c\)")]
        public void WhenIClickOnButton(string buttonText)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.ClickButtonWithName(buttonText);
            //System.Threading.Thread.Sleep(5000);
        }

        [When(@"I get all data from table with Id ""(.*)"" \(b2c\)")]
        public void WhenIGetAllDataFromTableWithIdBc(string tableId)
        {
            var generalPage = new B2cGeneralPage(driver);
            DataTable Table = generalPage.GetTableFromAllListsById(tableId);
            testData.table = Table;

            //foreach (DataRow dataRow in Table.Rows)
            //{
            //    foreach (var item in dataRow.ItemArray)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
        }

        [When(@"I get data from table with Id ""(.*)"" \(b2c\)")]
        public void WhenIGetDataFromTableWithIdBc(string tableId)
        {
            var generalPage = new B2cGeneralPage(driver);
            DataTable Table = generalPage.GetTableById(tableId);
            testData.table = Table;
        }

        [Then(@"I assert that column with name ""(.*)"" contains all remembered IDs \(b2c\)")]
        public void ThenIAssertThatRawWithIndexContainsAllRememberedIDsBc(string columnName)
        {
            foreach (var deviceId in testData.devicesId)
            {
                Assert.IsTrue(testData.table.AsEnumerable().Any(row => deviceId == row.Field<String>(columnName)), "Unable to locate device with Id: " + deviceId);
            }

        }


        [Then(@"I print table \(test\)")]
        public void ThenIPrintTableTest()
        {
            var generalPage = new B2cGeneralPage(driver);
            var juiceBoxPage = new B2cJuiceBoxPage(driver);
            Console.WriteLine(generalPage.GetInputValueById("timepickerWdS"));
            Console.WriteLine(generalPage.GetInputValueById("timepickerWdE"));
            Console.WriteLine(generalPage.GetInputValueById("timepickerWeS"));
            Console.WriteLine(generalPage.GetInputValueById("timepickerWeE"));
            Console.WriteLine(DateTime.Now.ToString("hh:mm tt", CultureInfo.InvariantCulture));
            //System.Threading.Thread.Sleep(1000);
            var currentTime = juiceBoxPage.getCurrentTimeOnDevice();
            //System.Threading.Thread.Sleep(1000);
            Console.WriteLine(currentTime);
            Console.WriteLine(currentTime);
            Console.WriteLine(DateTime.Parse(currentTime));
        }

        [When(@"I refresh page \(b2c\)")]
        public void WhenIRefreshPageBc()
        {
            driver.Navigate().Refresh();
            //System.Threading.Thread.Sleep(1000);
        }


        [When(@"I click on switch with Id ""(.*)"" \(b2c\)")]
        public void WhenIClickOnSwithWithIdBc(string switchId)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.ClickSwitchWithId(switchId);
        }

        [Then(@"switch with Id ""(.*)"" should be enabled is ""(.*)"" \(b2c\)")]
        public void ThenSwithWithIdShouldBeEnabledIsBc(string switchId, string isEnabled)
        {
            System.Threading.Thread.Sleep(500);
            var generalPage = new B2cGeneralPage(driver);
            Assert.AreEqual(generalPage.IsSwitchWithIdOn(switchId), bool.Parse(isEnabled));
        }

        //Possible we can make it mope symply. Do not use panel.
        [Given(@"switch with Id ""(.*)"" is not activated \(b2c\)")]
        public void GivenSwitchWithIdIsNotActivatedBc(string switchId)
        {
            var generalPage = new B2cGeneralPage(driver);
            var JuiceBoxPage = new B2cJuiceBoxPage(driver);
            if (generalPage.IsSwitchWithIdOn(switchId))
            {
                generalPage.ClickSwitchWithId(switchId);
                var panelId = generalPage.GetPanelIdForSwitchWithId(switchId);
                JuiceBoxPage.ClickOnUpdateButtonForPannelWithId(panelId);

            }
            Assert.False(generalPage.IsSwitchWithIdOn(switchId));
        }
        [When(@"I select item by checkbox name ""(.*)"" \(b2c\)")]
        public void WhenISelectItemByCheckboxNameBc(string deviceName)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.SelectCheckboxByLabel(deviceName);

        }

        [Given(@"Wait for (.*) sec")]
        [When(@"Wait for (.*) sec")]
        [Then(@"Wait for (.*) sec")]
        public void WhenWaitForSec(int p0)
        {
            Console.WriteLine("Waiting for: " + p0 + " seconds");
            System.Threading.Thread.Sleep(p0 * 1000);
        }

        [Then(@"Modal with Id ""(.*)"" should be displayed \(b2c\)")]
        public void ThenModalWithIdShouldBeDisplayedBc(string modalId)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id = '" + modalId + "'][contains(@style, 'display: block;')]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id = '" + modalId + "'][contains(@style, 'display: block;')]")).Displayed);
        }

        [Then(@"Modal with Id ""(.*)"" should contain title ""(.*)"" \(b2c\)")]
        public void ThenModalWithIdShouldContainTitleBc(string modalId, string title)
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id = '" + modalId + "']//div[@class = 'modal-header']//*[contains(@class, 'modal-title')]")).Text.Contains(title));
        }

        [Then(@"field with Id ""(.*)"" should be equal to value from config ""(.*)"" \(b2c\)")]
        public void ThenFieldWithIdShouldBeEqualToValueFromConfigBc(string fieldId, string configKey)
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id = '" + fieldId + "']")).Text.Contains(Config.Global[configKey]));
        }

        [Then(@"field with Id ""(.*)"" should contains ""(.*)"" symbols \(b2c\)")]
        public void ThenFieldWithIdShouldContainsSymbolsBc(string fieldId, int numberOfSymbols)
        {
            Assert.AreEqual(numberOfSymbols, driver.FindElement(By.XPath("//*[@id = '" + fieldId + "']")).Text.Length);
        }


        [When(@"I close current modal window \(b2c\)")]
        public void WhenICloseCurrentModalWindowBc()
        {
            var modalId = driver.FindElement(By.XPath("//div[contains(@class, 'modal fade')][contains(@style, 'display: block;')]")).GetAttribute("id");
            driver.FindElement(By.XPath("//div[@id = '" + modalId + "']//button[contains(@class, 'close')]")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id = '" + modalId + "'][contains(@style, 'display: none;')]")));
            System.Threading.Thread.Sleep(1000);

        }

        [Given(@"I wait for ""(.*)"" seconds \(b2c\)")]
        public void GivenIWaitForSecondsBc(int sec)
        {
            System.Threading.Thread.Sleep(sec * 1000);
        }


    }
}
