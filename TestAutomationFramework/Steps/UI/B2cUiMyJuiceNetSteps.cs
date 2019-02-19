﻿using NUnit.Framework;
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
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;
using TestAutomationFramework.Services;
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

            System.Threading.Thread.Sleep(1000);
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
            Assert.True(testData.table.Rows[0].ItemArray[0].ToString().Contains("No data available in table"));
        }

        [Then(@"panel color for device with Id ""(.*)"" should be set to ""(.*)"" \(b2c\)")]
        public void ThenPanelColorForDeviceWithIdShouldBeSetToBc(string deviceId, string color)
        {
            Assert.True(driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + deviceId + "')]/div")).GetAttribute("class").Contains(color));
        }

        //possible color values offline, primary, green, yellow
        [Then(@"panel color for device with Id ""(.*)"" should be changed to ""(.*)"" \(b2c\)")]
        public void ThenPanelColorForDeviceWithIdShouldBeChangedToBc(string deviceId, string color)
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
                var result = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + deviceId + "')]/div")).GetAttribute("class").Contains(color);
                Console.WriteLine(result);
                if(result)
                {
                    Assert.True(true);
                    return;
                }
            }
            Assert.False(false);
        }

        [Then(@"panel with Id ""(.*)"" should change color to ""(.*)"" \(b2c\)")]
        public void ThenPanelWithIdShouldChangeColorToBc(string panelId, string color)
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
                var result = driver.FindElement(By.XPath("//div[@id ='" + panelId + "']")).GetAttribute("class").Contains(color);
                Console.WriteLine(result);
                if (result)
                {
                    Assert.True(true);
                    return;
                }
            }
            Assert.False(false);
        }

        [Then(@"device with Id ""(.*)"" should have status ""(.*)"" \(b2c\)")]
        public void ThenDeviceWithIdShouldHaveStatusBc(string deviceId, string deviceStatus)
        {
            Assert.True(driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + deviceId + "')]//span[contains(@class,'unit-info-status-text')]")).Text.ToLower().Contains(deviceStatus.ToLower()));
        }

        [When(@"I remember charging and saving values for device with Id ""(.*)"" \(b2c\)")]
        public void WhenIRememberChargingAndSavingValuesForDeviceWithIdBc(string deviceId)
        {
            testData.energy = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + deviceId + "')]//span[contains(@class,'unit-info-energy')]")).Text;
            testData.savings = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + deviceId + "')]//span[contains(@class,'unit-info-savings')]")).Text;
        }


        [Then(@"energy and savings for device with Id ""(.*)"" should grow \(b2c\)")]
        public void ThenEnergyAndSavingsForDeviceWithIdShouldGrowBc(string deviceId)
        {     
            var finalEnergyResult = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + deviceId + "')]//span[contains(@class,'unit-info-energy')]")).Text;
            var finalSavingsResult = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + deviceId + "')]//span[contains(@class,'unit-info-savings')]")).Text;

            Console.WriteLine("Final energy should be more than initial: " + finalEnergyResult + ">" + testData.energy);
            Console.WriteLine("Final savings should be more than initial: " + finalSavingsResult + ">" + testData.savings);

            Assert.True(Convert.ToDouble(finalEnergyResult) > Convert.ToDouble(testData.energy));
            Assert.True(Convert.ToDouble(finalSavingsResult) > Convert.ToDouble(testData.savings));
        }

        [When(@"I populate the JuiceNet Device Settings form with ""(.*)"" data \(b2c\)")]
        [Then(@"I populate the JuiceNet Device Settings form with ""(.*)"" data \(b2c\)")]
        public void ThenIPopulateTheJuiceNetDeviceSettingsFormWithDataBc(string sheetName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Misc\", "b2c_test_data.xlsx");
            DataTable initialData = Tools.LoadTableFromFile.LoadDataTable(filePath, sheetName);

            var generalPage = new B2cGeneralPage(driver);

            foreach (DataRow dataRow in initialData.Rows)
            {
                if (dataRow[1].ToString().Equals(""))
                {
                    Console.WriteLine("Clear " + dataRow[0].ToString() + " since value is empty");
                    generalPage.ClearInputValueById(dataRow[0].ToString());
                }
                else if (dataRow[0].Equals("timeZoneId"))
                {
                    Console.WriteLine("Set " + dataRow[0].ToString() + " to " + dataRow[1]);
                    generalPage.SelectValueById(dataRow[0].ToString(), dataRow[1].ToString());
                }
                else
                {
                    Console.WriteLine("Set " + dataRow[0].ToString() + " to " + dataRow[1]);
                    generalPage.SetInputValueById(dataRow[0].ToString(), dataRow[1].ToString());
                }
            }
        }

        [When(@"I click on the Update button for pannel with Id ""(.*)"" \(b2c\)")]
        [Then(@"I click on the Update button for pannel with Id ""(.*)"" \(b2c\)")]
        public void ThenIClickOnTheUpdateButtonForPannelWithIdBc(string panelId)
        {
            var JuiceBoxPage = new B2cJuiceBoxPage(driver);
            JuiceBoxPage.ClickOnUpdateButtonForPannelWithId(panelId);
        }

        [Then(@"JuiceNet Device Settings form fields values should be equal to ""(.*)"" data \(b2c\)")]
        public void ThenJuiceNetDeviceSettingsFormFieldsValuesShouldBeEqualToDataBc(string sheetName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Misc\", "b2c_test_data.xlsx");
            DataTable initialData = Tools.LoadTableFromFile.LoadDataTable(filePath, sheetName);

            var generalPage = new B2cGeneralPage(driver);

            foreach (DataRow dataRow in initialData.Rows)
            {
                if (dataRow[0].Equals("timeZoneId"))
                {
                    Assert.AreEqual(dataRow[1].ToString(), generalPage.getSelectValueById(dataRow[0].ToString()));
                }
                else
                {
                    Assert.AreEqual(dataRow[1].ToString(), generalPage.GetInputValueById(dataRow[0].ToString()));
                }
            }
        }

        [Then(@"Error message ""(.*)"" is displayed \(b2c\)")]
        public void ThenErrorMessageIsDisplayedBc(string errorMessage)
        {
            var currentMessage = driver.FindElement(By.XPath("//span[contains(@class,'field-validation-error')]")).Text;
            Assert.AreEqual(errorMessage, currentMessage);
        }

        // allowed values is current, not current
        [When(@"I set TOU time to ""(.*)"" \(b2c\)")]
        public void WhenISetTOUTimeToBc(string touTime)
        {
            var generalPage = new B2cGeneralPage(driver);
            var juiceBoxPage = new B2cJuiceBoxPage(driver);
            var currentTime = DateTime.Parse(juiceBoxPage.getCurrentTimeOnDevice());

            string startTime;
            string endTime;

            switch (touTime.Replace(" ", "").ToLower())
            {
                case "current":
                    startTime = currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                    endTime = currentTime.AddHours(1).ToString("hh:mm tt", CultureInfo.InvariantCulture);
                    break;
                case "notcurrent":
                    startTime = currentTime.AddHours(1).ToString("hh:mm tt", CultureInfo.InvariantCulture);
                    endTime = currentTime.AddHours(2).ToString("hh:mm tt", CultureInfo.InvariantCulture);
                    break;
                default:
                    Assert.Fail("Incorrect TOU value: " + touTime);
                    return;
            }

            generalPage.SetInputValueById("timepickerWdS", startTime);
            generalPage.SetInputValueById("timepickerWdE", endTime);
            generalPage.SetInputValueById("timepickerWeS", startTime);
            generalPage.SetInputValueById("timepickerWeE", endTime);

            juiceBoxPage.ClickOnUpdateButtonForPannelWithId("panelTOU");
        }

        }
}
