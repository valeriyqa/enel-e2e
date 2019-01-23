using JsonConfig;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;
using System.Data;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2cUiGeneralSteps
    {
        private readonly RemoteWebDriver driver;
        public B2cUiGeneralSteps(RemoteWebDriver driver) => this.driver = driver;

        [Given(@"I navigate to the ""(.*)"" page \(b2c\)")]
        [Then(@"I navigate to the ""(.*)"" page \(b2c\)")]
        public void INavigateToThePageB2B(string pageName)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.ClickMenuByName(pageName);
            Assert.AreEqual(driver.Url, generalPage.GetAddressByMenuName(pageName));
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

            Console.WriteLine("Current result:" +  result);
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

            //foreach (DataRow dataRow in Table.Rows)
            //{
            //    foreach (var item in dataRow.ItemArray)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
        }

    }
}
