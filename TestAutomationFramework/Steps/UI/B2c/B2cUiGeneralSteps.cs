using JsonConfig;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Data;
using System.Globalization;
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
        }

        private readonly TestData testData;
        private readonly RemoteWebDriver driver;
        public B2cUiGeneralSteps(TestData testData, RemoteWebDriver driver)
        {
            this.testData = testData;
            this.driver = driver;
        }

        [Given(@"I navigate to the ""(.*)"" page \(b2c\)")]
        [Then(@"I navigate to the ""(.*)"" page \(b2c\)")]
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

        [When(@"I select ""(.*)"" on selector with Id ""(.*)"" \(b2c\)")]
        public void WhenISelectOnSelectorWithIdBc(string selectValue, string selectId)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.SelectValueById(selectId, selectValue);
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

        [When(@"I click on swith with Id ""(.*)"" \(b2c\)")]
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

    }
}
