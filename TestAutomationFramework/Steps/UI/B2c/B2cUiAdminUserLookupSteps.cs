using JsonConfig;
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

namespace TestAutomationFramework.Steps.UI.B2c
{
    [Binding]
    class B2cUiAdminUserLookupSteps
    {
        private readonly RemoteWebDriver driver;
        public B2cUiAdminUserLookupSteps(RemoteWebDriver driver) => this.driver = driver;

        [Then(@"unit with key in config ""(.*)"" exist in the UserDevices table is ""(.*)"" \(b2c\)")]
        public void ThenUnitWithKeyInConfigExistInTheUserDevicesTableIsBc(string configKey, string shouldExist)
        {
            //Clean it
            Console.WriteLine("Step: unit with key in config " + configKey + " exist in the UserDevices table is " + shouldExist + "  (b2c) Started");

            IList<IWebElement> all;
            bool elementExist = false;
            bool elementShouldExist = bool.Parse(shouldExist);

            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(500);
                all = driver.FindElements(By.XPath("//table[@id = 'boxlist']//tbody//tr/td[2]/a"));

                foreach (IWebElement element in all)
                {
                    try
                    {
                        if (element.Text.Equals(Config.Global[configKey]))
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
            //Clean it
            Console.WriteLine("Step: unit with key in config " + configKey + " exist in the UserDevices table is " + shouldExist + "  (b2c) Started");
        }

        [When(@"I click remove button in the UserDevices table for unit with key in config ""(.*)"" \(b2c\)")]
        public void WhenIClickRemoveButtonInTheUserDevicesTableForUnitWithKeyInConfigBc(string configKey)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//table[@id = 'boxlist']//tbody//tr/td/a[contains(@data-unit-id, '" + Config.Global[configKey] + "')]")).Displayed);
            driver.FindElement(By.XPath("//table[@id = 'boxlist']//tbody//tr/td/a[contains(@data-unit-id, '" + Config.Global[configKey] + "')]")).Click();
        }

        [Then(@"item with name ""(.*)"" in the navigation menu should exist is ""(.*)"" \(b2c\)")]
        public void ThenItemWithNameInTheNavigationMenuShouldExistIsBc(string itemName, string shouldExist)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            var element = driver.FindElements(By.XPath("//ul[@id = 'side-menu']//li//a/descendant-or-self::node()[text() = '" + itemName + "']"));
            Console.WriteLine("Found elements: " + element.Count);
            Assert.AreEqual(element.Count > 0, bool.Parse(shouldExist));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [When(@"I activate User roles button ""(.*)"" \(b2c\)")]
        public void WhenIActivateUserRolesButtonBc(string buttonName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "']")).Displayed);
            driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "']")).Click();
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "'][contains(@data-action, 'RemoveFromRole')]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "'][contains(@data-action, 'RemoveFromRole')]")).Displayed);

        }

        [When(@"I deactivate User roles button ""(.*)"" \(b2c\)")]
        public void WhenIDeactivateUserRolesButtonBc(string buttonName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "']")).Displayed);
            driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "']")).Click();
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "'][contains(@data-action, 'AddToRole')]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "'][contains(@data-action, 'AddToRole')]")).Displayed);

        }

        [Given(@"I accept user agreement is needed \(b2c\)")]
        public void GivenIAcceptUserAgreementIsNeededBc()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            if (driver.FindElements(By.Id("license-dialog")).Count > 0)
            {
                Console.WriteLine("License displayed");
                driver.FindElement(By.Id("btn-confirm")).Click();
            } else
            {
                Console.WriteLine("License Not displayed");
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Given(@"the ""(.*)"" button from User roles button activated is ""(.*)"" \(b2c\)")]
        public void GivenTheButtonFromUserRolesButtonActivatedIsBc(string buttonName, string isActivated)
        {
            string dataAction;
            if (bool.Parse(isActivated))
            {
                dataAction = "RemoveFromRole";
            }
            else
            {
                dataAction = "AddToRole";
            }
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "']")).Displayed);
            var da = driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "']")).GetAttribute("data-action");
            if (da != dataAction)
            {
                driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "']")).Click();
                wait.Until(wd => driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "'][contains(@data-action, '" + dataAction + "')]")).Displayed);
            }
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id = 'user-roles-container']//a[@data-role = '" + buttonName + "'][contains(@data-action, '" + dataAction + "')]")).Displayed);
        }

    }
}
