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

        [Given(@"JuiceNet device is not added \(b2c\)")] //Should be deleted as obsolete
        public void JuiceNetDeviceIsNotAdded()
        {
            Console.WriteLine("JuiceNet Device is not added");
            RestApi.SendApiRequest(RestApi.GetApiRequest("delete_account_unit"));
        }

        [Given(@"JuiceNet device with key in config ""(.*)"" is added \(b2c\)")]
        public void GivenJuiceNetDeviceWithKeyInConfigIsAddedBc(string configKey)
        {
            //Clean it
            Console.WriteLine("Step: JuiceNet device with key in config " + configKey + " is added (b2c) Started");
            string prefix = configKey.Substring(0, configKey.IndexOf('_'));
            //Clean it
            Console.WriteLine("Prefix = " + prefix);

            var dictionary = new Dictionary<string, Object>();
            dictionary.Add("account_token", Config.Global["api_account_token"]);
            dictionary.Add("device_id", Config.Global["api_device_id"]);
            dictionary.Add("token", Config.Global[prefix + "_token"]);
            //Clean it
            Console.WriteLine("Add to dictionary: account_token = " + Config.Global["api_account_token"]);
            Console.WriteLine("Add to dictionary: device_id = " + Config.Global["api_device_id"]);
            Console.WriteLine("Add to dictionary: token = " + Config.Global[prefix + "_token"]);

            var response = RestApi.SendApiRequest(RestApi.GetApiRequest("add_account_unit", dictionary));
            Assert.IsTrue(response.Content.Contains("\"success\": true"));
            //Clean it
            Console.WriteLine("Step: JuiceNet device with key in config " + configKey + " is added (b2c) Finished");
        }


        [Given(@"JuiceNet device with key in config ""(.*)"" is not added \(b2c\)")]
        public void GivenJuiceNetDeviceWithIdInConfigIsNotAddedBc(string configKey)
        {
            string prefix = configKey.Substring(0, configKey.IndexOf('_'));

            var dictionary = new Dictionary<string, Object>();
            dictionary.Add("account_token", Config.Global["api_account_token"]);
            dictionary.Add("device_id", Config.Global["api_device_id"]);
            dictionary.Add("token", Config.Global[prefix + "_token"]);

            var response = RestApi.SendApiRequest(RestApi.GetApiRequest("delete_account_unit", dictionary));
            Assert.IsTrue(response.Content.Contains("\"success\": true"));
        }

        [Given(@"I delete device with key in config ""(.*)"" via UI if added \(b2c\)")]
        public void GivenIDeleteDeviceWithKeyInConfigViaUIIfAddedBc(string configKey)
        {
            IList<IWebElement> all = driver.FindElements(By.ClassName("unit-info-container"));

            foreach (IWebElement element in all)
            {
                if (element.GetAttribute("data-unitid").Equals(Config.Global[configKey]))
                {
                    driver.FindElementByXPath("//div[@data-unitid = '" + Config.Global[configKey] + "']//div[contains(@class, 'row')]//a").Click();
                    var generalPage = new B2cGeneralPage(driver);
                    generalPage.ClickButtonWithName("Delete");
                    generalPage.ClickButtonWithName("Yes, remove from my account");
                    ThenJuiceNetDeviceWithKeyInConfigShouldExistIsBc(configKey, "False");
                    return;
                }
            }

        }


        [Then(@"JuiceNet device with key in config ""(.*)"" should exist is ""(.*)"" \(b2c\)")] //Ok
        public void ThenJuiceNetDeviceWithKeyInConfigShouldExistIsBc(string configKey, string shouldExist)
        {
            IList<IWebElement> all;
            bool elementExist = false;
            bool elementShouldExist = bool.Parse(shouldExist);

            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(500);
                all = driver.FindElements(By.ClassName("unit-info-container"));

                foreach (IWebElement element in all)
                {
                    try
                    {
                        if (element.GetAttribute("data-unitid").Equals(Config.Global[configKey]))
                        {
                            elementExist = true;
                            break;
                        }
                    }
                    catch (Exception)
                    {

                    }

                }
                if (elementShouldExist.Equals(elementExist))
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Try number: " + i);
                }

            }
            Assert.AreEqual(elementShouldExist, elementExist);
        }


        [Then(@"JuiceNet device with Id ""(.*)"" should exist is ""(.*)"" \(b2c\)")] //Ok
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

        [When(@"I click More Details for device with key in config ""(.*)"" \(b2c\)")] //Ok
        public void WhenIClickMoreDetailsForDeviceWithKeyInConfigBc(string configKey)
        {
            Console.WriteLine("Step: I click More Details for device with key in config " + configKey + " (b2c) Started");
            //driver.FindElementByXPath("//div[@data-unitid = '" + Config.Global[configKey] + "']//div[contains(@class, 'panel-footer')]//span").Click();
            driver.FindElementByXPath("//div[@data-unitid = '" + Config.Global[configKey] + "']//div[contains(@class, 'row')]//a").Click();
            Console.WriteLine("Step: I click More Details for device with key in config " + configKey + " (b2c) Finished");
        }


        [When(@"I click More Details for device with Id ""(.*)"" \(b2c\)")] //Ok
        public void WhenIClickMoreDetailsForDeviceWithId(string deviceId)
        {
            driver.FindElementByXPath("//div[@data-unitid = '" + deviceId + "']//div[contains(@class, 'panel-footer')]//span").Click();
        }

        [When(@"I click all checkboxes on panel with Id ""(.*)"" \(b2c\)")]
        public void WhenIClickAllCheckboxesOnPanelWithId(string panelId)
        {
            Console.WriteLine("Step: I click all checkboxes on panel with Id " + panelId + " (b2c) Started");
            IList<IWebElement> allCheckboxes = driver.FindElements(By.XPath("//div[@id = '" + panelId + "']//input[contains(@type, 'checkbox')]"));
            for (int i = 0; i < allCheckboxes.Count; i++)
            {
                driver.FindElements(By.XPath("//div[@id = '" + panelId + "']//input[contains(@type, 'checkbox')]/../ label"))[i].Click();
            }
            //IList<IWebElement> allCheckboxes = driver.FindElements(By.XPath("//div[@id = '" + panelId + "']//input[contains(@type, 'checkbox')]"));
            //foreach (var checkbox in allCheckboxes)
            //{
            //    checkbox.Click();
            //}
            Console.WriteLine("Step: I click all checkboxes on panel with Id " + panelId + " (b2c) Finished");
        }

        [Then(@"all checkboxes on panel with Id ""(.*)"" should be activated \(b2c\)")]
        public void ThenAllCheckboxesOnPanelWithIdShouldBeActivated(string panelId)
        {
            Console.WriteLine("Step: all checkboxes on panel with Id " + panelId + " should be activated (b2c) Started");
            IList<IWebElement> allCheckboxes = driver.FindElements(By.XPath("//div[@id = '" + panelId + "']//input[contains(@type, 'checkbox')]"));
            foreach (var checkbox in allCheckboxes)
            {
                Assert.AreEqual("true", checkbox.GetAttribute("checked"));
            }
            Console.WriteLine("Step: all checkboxes on panel with Id " + panelId + " should be activated (b2c) Started");
        }

        [Given(@"all checkboxes on panel with Id ""(.*)"" is not activated \(b2c\)")]
        public void AllCheckboxesOnPanelWithIdIsNotActivated(string panelId)
        {
            Console.WriteLine("Step: all checkboxes on panel with Id " + panelId + " is not activated (b2c) Started");
            IList<IWebElement> allCheckboxes = driver.FindElements(By.XPath("//div[@id = '" + panelId + "']//input[contains(@type, 'checkbox')]"));
            for (int i = 0; i < allCheckboxes.Count; i++)
            {
                if (null != driver.FindElements(By.XPath("//div[@id = '" + panelId + "']//input[contains(@type, 'checkbox')]"))[i].GetAttribute("checked") && driver.FindElements(By.XPath("//div[@id = '" + panelId + "']//input[contains(@type, 'checkbox')]"))[i].GetAttribute("checked").Equals("true"))
                {
                    driver.FindElements(By.XPath("//div[@id = '" + panelId + "']//input[contains(@type, 'checkbox')]/../ label"))[i].Click();
                }
            }

            var generalPage = new B2cGeneralPage(driver);
            generalPage.ClickButtonWithId("saveNotificationsButton");

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Step: all checkboxes on panel with Id " + panelId + " is not activated (b2c) Finished");
        }

        [Then(@"I click on tab with label ""(.*)"" \(b2c\)")]
        [When(@"I click on tab with label ""(.*)"" \(b2c\)")]
        public void WhenIClickOnTabWithLable(string label)
        {
            Console.WriteLine("Step: I click on tab with label " + label + " (b2c) Started");
            driver.FindElement(By.XPath("//ul[@id = 'unit_details_tabs']//span[contains(text(),'" + label + "')]//ancestor::a")).Click();
            Console.WriteLine("Step: I click on tab with label " + label + " (b2c) Finished");
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

        [Then(@"icon color for device with key in config ""(.*)"" should be changed to ""(.*)"" \(b2c\)")]
        public void ThenIconColorForDeviceWithKeyInConfigShouldBeChangedToBc(string configKey, string color)
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
                var result = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + Config.Global[configKey] + "')]//div[@id = 'unit-status-icon']//div[contains(@class,'icon-enel')]")).GetAttribute("class").Contains(color);
                Console.WriteLine(result);
                if (result)
                {
                    Assert.True(true);
                    return;
                }
            }
            Assert.False(true);
        }


        [Then(@"panel color for device with key in config ""(.*)"" should be changed to ""(.*)"" \(b2c\)")]
        public void ThenPanelColorForDeviceWithKeyInConfigShouldBeChangedToBc(string configKey, string color)
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
                var result = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + Config.Global[configKey] + "')]/div")).GetAttribute("class").Contains(color);
                Console.WriteLine(result);
                if (result)
                {
                    Assert.True(true);
                    return;
                }
            }
            Assert.Fail();
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
                if (result)
                {
                    Assert.True(true);
                    return;
                }
            }
            Assert.Fail();
        }

        [Then(@"device should cheange status to ""(.*)"" \(b2c\)")]
        public void ThenDeviceStatusShouldCheangeToBc(string deviceStatus)
        {
            Console.WriteLine("Step: device should cheange status to " + deviceStatus + " (B2C) Started");
            string result = "";
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
                result = driver.FindElement(By.XPath("//span[@id ='statusText']")).Text;
                Console.WriteLine(result);
                if (result.Contains(deviceStatus))
                {
                    Assert.True(true);
                    return;
                }
            }
            Assert.Fail("Device status equals to \"" + result + "\", not to \"" + deviceStatus + "\"");
            Console.WriteLine("Step: device should cheange status to " + deviceStatus + " (B2C) Finished");
        }


        //probably obsolete
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
            Assert.False(true, "Panel color is not changed to " + color);
        }

        [Then(@"device with key in config ""(.*)"" should have status ""(.*)"" \(b2c\)")]
        public void ThenDeviceWithKeyInConfigShouldHaveStatusBc(string configKey, string deviceStatus)
        {
            Assert.True(driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + Config.Global[configKey] + "')]//span[contains(@class,'unit-info-status-text')]")).Text.ToLower().Contains(deviceStatus.ToLower()));
        }


        [Then(@"device with Id ""(.*)"" should have status ""(.*)"" \(b2c\)")]
        public void ThenDeviceWithIdShouldHaveStatusBc(string deviceId, string deviceStatus)
        {
            Assert.True(driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + deviceId + "')]//span[contains(@class,'unit-info-status-text')]")).Text.ToLower().Contains(deviceStatus.ToLower()));
        }

        [When(@"I remember charging and saving values for device with key in config ""(.*)"" \(b2c\)")]
        public void WhenIRememberChargingAndSavingValuesForDeviceWithKeyInConfigBc(string configKey)
        {
            testData.energy = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + Config.Global[configKey] + "')]//span[contains(@class,'unit-info-energy')]")).Text;
            testData.savings = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + Config.Global[configKey] + "')]//span[contains(@class,'unit-info-savings')]")).Text;
        }


        [When(@"I remember charging and saving values for device with Id ""(.*)"" \(b2c\)")]
        public void WhenIRememberChargingAndSavingValuesForDeviceWithIdBc(string deviceId)
        {
            testData.energy = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + deviceId + "')]//span[contains(@class,'unit-info-energy')]")).Text;
            testData.savings = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + deviceId + "')]//span[contains(@class,'unit-info-savings')]")).Text;
        }

        [Then(@"energy and savings for device with key in config ""(.*)"" should grow \(b2c\)")]
        public void ThenEnergyAndSavingsForDeviceWithKeyInConfigShouldGrowBc(string configKey)
        {
            var finalEnergyResult = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + Config.Global[configKey] + "')]//span[contains(@class,'unit-info-energy')]")).Text;
            var finalSavingsResult = driver.FindElement(By.XPath("//div[contains(@data-unitid,'" + Config.Global[configKey] + "')]//span[contains(@class,'unit-info-savings')]")).Text;

            Console.WriteLine("Final energy should be more than initial: " + finalEnergyResult + ">" + testData.energy);
            Console.WriteLine("Final savings should be more than initial: " + finalSavingsResult + ">" + testData.savings);

            Assert.True(Convert.ToDouble(finalEnergyResult) > Convert.ToDouble(testData.energy));
            Assert.True(Convert.ToDouble(finalSavingsResult) > Convert.ToDouble(testData.savings));
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

        [When(@"I click on the override switch \(b2c\)")]
        public void WhenIClickOnTheOwerrideSwitchBc()
        {
            IJavaScriptExecutor js = driver;
            js.ExecuteScript("$('input#overrideCheckBox').click();");
            //driver.FindElement(By.XPath("//input[contains(@id,'overrideCheckBox')]"));
        }

        [When(@"I click ""(.*)"" button for load group ""(.*)"" \(b2c\)")]
        public void WhenIClickButtonForLoadGroupBc(string buttonName, string loadGroupName)
        {
            Console.WriteLine("Step: I click " + buttonName + " button for load group " + loadGroupName + " (B2C) Started");
            driver.FindElement(By.XPath("//table[contains(@id, 'loadgroups-table')]//tbody//*[text()[contains(.,'" + loadGroupName + "')]]/ancestor::tr//button[contains(@class, '" + buttonName + "')]")).Click();
            Console.WriteLine("Step: I click " + buttonName + " button for load group " + loadGroupName + " (B2C) Finished");
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

        [When(@"I remeber the current time on device \(b2c\)")]
        public void WhenIRemeberTheCurrentTimeOnDeviceBc()
        {
            var juiceBoxPage = new B2cJuiceBoxPage(driver);
            testData.dateTimeOnDevice = DateTime.Parse(juiceBoxPage.getCurrentTimeOnDevice());
        }

        // Before use this method, you should read current time. Please use "WhenIRemeberTheCurrentTimeOnDeviceBc" method previously.
        // allowed values is current, not current
        [When(@"I set TOU time to ""(.*)"" \(b2c\)")]
        public void WhenISetTOUTimeToBc(string touTime)
        {
            var generalPage = new B2cGeneralPage(driver);
            var juiceBoxPage = new B2cJuiceBoxPage(driver);
            //var currentTime = DateTime.Parse(juiceBoxPage.getCurrentTimeOnDevice());
            var currentTime = testData.dateTimeOnDevice;

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

        [Then(@"TOU time on the Admin/JuiceNetDeviceLookup page should be equal to ""(.*)"" \(b2c\)")]
        public void ThenTOUTimeOnTheAdminJuiceNetDeviceLookupPageShouldBeEqualToBc(string touTime)
        {
            var generalPage = new B2cGeneralPage(driver);
            var currentTime = testData.dateTimeOnDevice;

            string startTime;
            string endTime;

            switch (touTime.Replace(" ", "").ToLower())
            {
                case "current":
                    startTime = currentTime.ToString("HH:mm", CultureInfo.InvariantCulture);
                    endTime = currentTime.AddHours(1).ToString("HH:mm", CultureInfo.InvariantCulture);

                    break;
                case "notcurrent":
                    startTime = currentTime.AddHours(1).ToString("HH:mm", CultureInfo.InvariantCulture);
                    endTime = currentTime.AddHours(2).ToString("HH:mm", CultureInfo.InvariantCulture);
                    break;
                default:
                    Assert.Fail("Incorrect TOU value: " + touTime);
                    return;
            }

            Assert.AreEqual(generalPage.GetElementTextById("tou_wd_start"), startTime);
            Assert.AreEqual(generalPage.GetElementTextById("tou_wd_end"), endTime);
            Assert.AreEqual(generalPage.GetElementTextById("tou_we_start"), startTime);
            Assert.AreEqual(generalPage.GetElementTextById("tou_we_end"), endTime);
        }


        // allowed values is current, not current
        [Then(@"TOU time should be equal to ""(.*)"" \(b2c\)")]
        public void ThenTOUTimeShouldBeEqualToBc(string touTime)
        {
            var generalPage = new B2cGeneralPage(driver);
            var currentTime = testData.dateTimeOnDevice;

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

            Assert.AreEqual(generalPage.GetInputValueById("timepickerWdS"), startTime);
            Assert.AreEqual(generalPage.GetInputValueById("timepickerWdE"), endTime);
            Assert.AreEqual(generalPage.GetInputValueById("timepickerWeS"), startTime);
            Assert.AreEqual(generalPage.GetInputValueById("timepickerWeE"), endTime);
        }

        [Then(@"device with Id ""(.*)"" should have Current Limit equqal to ""(.*)"" \(b2c\)")]
        public void ThenDeviceWithIdShouldHaveCurrentLimitEquqalToBc(string deviceId, string currentLimit)
        {
            string cLimitFromPage = driver.FindElement(By.XPath("//table[@id='load-group-devices-table']//tbody/tr/td/a[contains(text(), '" + deviceId + "')]/../../td[3]")).Text;
            Assert.AreEqual(Int32.Parse(cLimitFromPage), Int32.Parse(currentLimit));
        }

        [Then(@"device with Id ""(.*)"" should have Current Limit lower then ""(.*)"" \(b2c\)")]
        public void ThenDeviceWithIdShouldHaveCurrentLimitLowerThenBc(string deviceId, string currentLimit)
        {
            string cLimitFromPage = driver.FindElement(By.XPath("//table[@id='load-group-devices-table']//tbody/tr/td/a[contains(text(), '" + deviceId + "')]/../../td[3]")).Text;
            Assert.True(Int32.Parse(cLimitFromPage) <= Int32.Parse(currentLimit) & Int32.Parse(cLimitFromPage) >= 0);
        }

        [Then(@"sum of the Current Limit for all devices should be lower then ""(.*)"" \(b2c\)")]
        public void ThenSumOfTheCurrentLimitForAllDevicesShouldBeLowerThenBc(string currentLimit)
        {
            Console.WriteLine("Step: sum of the Current Limit for all devices should be lower then " + currentLimit + " (b2c) Started");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id='lg-device-add-result-modal'][contains(@style,'display: none;')]")));
            System.Threading.Thread.Sleep(500);

            var allCurrentLimits = driver.FindElements(By.XPath("//table[@id='load-group-devices-table']//tbody/tr/td[3]"));
            var total = 0;
            foreach (var item in allCurrentLimits)
            {
                total += Int32.Parse(item.Text);
            }
            Assert.True(total <= Int32.Parse(currentLimit) & total >= 0);
            Console.WriteLine("Step: sum of the Current Limit for all devices should be lower then " + currentLimit + " (b2c) Finished");
        }

        //posible values "list", "grid"
        [When(@"I switch view to ""(.*)"" \(b2c\)")]
        public void WhenISwitchViewToBc(string viewType)
        {
            //Clean it
            Console.WriteLine("Step: I switch view to " + viewType + " (b2c) Started");

            Console.WriteLine("Trying to click view button: " + viewType);
            switch (viewType.ToLower())
            {
                case "list":
                    driver.FindElement(By.XPath("//span[contains(@data-display-mode, '" + viewType.ToLower() + "')]")).Click();
                    Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='unitsList']//table")).Displayed);
                    break;
                case "grid":
                    driver.FindElement(By.XPath("//span[contains(@data-display-mode, '" + viewType.ToLower() + "')]")).Click();
                    Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='unitsList'][not(table)]")).Displayed);
                    break;
                default:
                    Assert.Fail("Unknown view type: " + viewType);
                    return;
            }

            //Clean it
            Console.WriteLine("Step: I switch view to " + viewType + " (b2c) Finished");
        }

        //possible pair options "Google App", "Amazon Alexa", "Guest Pin"
        [When(@"I click pair to ""(.*)"" button for device with key in config ""(.*)"" \(b2c\)")]
        public void WhenIClickPairToButtonForDeviceWithKeyInConfigBc(string pairOption, string configKey)
        {
            //Clean it
            Console.WriteLine("Step: I click pair to " + pairOption + " button for device with key in config " + Config.Global[configKey] + " (b2c) Started");

            var pairOptionFormatted = Regex.Replace(pairOption, @"(^\w)|(\s\w)", m => m.Value.ToUpper()).Replace(" ", string.Empty);
            Enum.TryParse(pairOptionFormatted, out B2cMyJuiceNetDevicesPage.pairButtonType pairButton);
            
            //Clean it
            Console.WriteLine("pairOptionFormatted = " + pairOptionFormatted);
            
            var page = new B2cMyJuiceNetDevicesPage(driver);
            //Clean it
            Console.WriteLine("Starting clickPairButtonForDeviceWithId method");
            page.clickPairButtonForDeviceWithId(pairButton, Config.Global[configKey]);

            //Clean it
            Console.WriteLine("Step: I click pair to " + pairOption + " button for device with key in config " + Config.Global[configKey] + " (b2c) Finished");
        }

        [When(@"I remember Guest pairing pin \(b2c\)")]
        [Then(@"I remember Guest pairing pin \(b2c\)")]
        public void GivenIRememberGuestPairingPinBc()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElementById("request-share-pin-modal-pincode").Displayed);
            testData.guestPairingPin = driver.FindElement(By.Id("request-share-pin-modal-pincode")).Text;
            Console.WriteLine("Guest pairing pin equals to: " + testData.guestPairingPin);
        }

        [When(@"I set previously remembered Guest pairing pin \(b2c\)")]
        public void WhenISetPreviouslyRememberedGuestPairingPinBc()
        {
            Console.WriteLine("Set field with Id: unit-share-pin to: " + testData.guestPairingPin);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElementById("unit-share-pin").Displayed);
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.Id("unit-share-pin")).Clear();
                driver.FindElement(By.Id("unit-share-pin")).SendKeys(testData.guestPairingPin);
                if (driver.FindElementById("unit-share-pin").GetAttribute("value").Equals(testData.guestPairingPin))
                {
                    break;
                }
            }
            //driver.FindElement(By.Id("unit-share-pin")).Clear();
            //driver.FindElement(By.Id("unit-share-pin")).SendKeys(testData.guestPairingPin);
            Console.WriteLine("Field with Id: unit-share-pin equals to: " + driver.FindElementById("unit-share-pin").GetAttribute("value"));
        }


        [Then(@"Guest pairing pin should be equal to the previously remembered one \(b2c\)")]
        public void ThenGuestPairingPinShouldBeEqualToThePreviouslyRememberedOneBc()
        {
            Assert.AreEqual(testData.guestPairingPin, driver.FindElement(By.Id("request-share-pin-modal-pincode")).Text);
        }

        [When(@"I remeber my current IP address \(b2c\)")]
        public void WhenIRemeberMyCurrentIPAddressBc()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id = 'AddUnitModal']//div[contains(@class, 'panel-inner')]//div[contains(@class, 'panel-heading')]")).Displayed);
            string headingText = driver.FindElement(By.XPath("//div[@id = 'AddUnitModal']//div[contains(@class, 'panel-inner')]//div[contains(@class, 'panel-heading')]")).Text;
            int startIndex = headingText.IndexOf("IP Address: ") + "IP Address: ".Length;
            int endIndex = headingText.IndexOf(")");
            testData.ipAddress = headingText.Substring(startIndex, endIndex - startIndex);
        }

        [When(@"I set field ""(.*)"" to remembered IP addess \(b2c\)")]
        public void WhenISetFieldToRememberedIPAddessBc(string fieldId)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElementById(fieldId).Displayed);
            driver.FindElementById(fieldId).Clear();
            driver.FindElementById(fieldId).SendKeys(testData.ipAddress);
        }

        [When(@"click search button for field with id ""(.*)"" \(b2c\)")]
        public void WhenClickSearchButtonForFieldWithIdBc(string fieldId)
        {
            driver.FindElement(By.XPath("//input[@id='inputIPAddress']/..//a")).Click();
        }

        [Then(@"I wait until element with Id ""(.*)"" will be displayed \(b2c\)")]
        public void ThenIWaitUntilElementWithIdWillBeDisplayedBc(string elementId)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(wd => driver.FindElementById(elementId).Displayed);
        }

        [When(@"I remeber id for all added devices \(b2c\)")]
        public void WhenIRemeberIdForAllAddedDevicesBc()
        {
            IList<IWebElement> all = driver.FindElements(By.ClassName("unit-info-container"));
            foreach (IWebElement element in all)
            {
                testData.devicesId.Add(element.GetAttribute("data-unitid"));
            }
        }

        [When(@"I open details page for device ""(.*)"" from config \(b2c\)")]
        public void WhenIOpenDetailsPageForDeviceFromConfigBc(string configKey)
        {
            driver.FindElement(By.XPath("//a[contains(@href, '/Portal/Details?unitID=" + Config.Global[configKey] + "')]")).Click();
        }

    }
}
