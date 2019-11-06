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
    class B2cUiAdminManageRolesSteps
    {
        private readonly RemoteWebDriver driver;
        public B2cUiAdminManageRolesSteps(RemoteWebDriver driver) => this.driver = driver;

        [Given(@"role with name ""(.*)"" is not exist in the ListOfRoles table \(b2c\)")]
        public void GivenRoleWithNameIsNotExistInTheListOfRolesTableBc(string roleName)
        {
            IList<IWebElement> all = driver.FindElements(By.XPath("//table[@id = 'listOfRoles']//tbody//tr/td[2]")); ;
            foreach (IWebElement element in all)
            {
                if (element.Text.Equals(roleName))
                {
                    driver.FindElement(By.XPath("//table[@id = 'listOfRoles']//tbody//tr/td[2][text() = '" + roleName + "']/ancestor::tr/td/a")).Click();
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    wait.Until(wd => driver.FindElement(By.XPath("//div[@id = 'boxesUnderGroup']//div[contains(@class, 'alert')]")).Displayed);
                    break;
                }
            }
        }


        [Then(@"role with name ""(.*)"" exist in the ListOfRoles table is ""(.*)"" \(b2c\)")]
        public void ThenRoleWithNameExistInTheListOfRolesTableIsBc(string roleName, string shouldExist)
        {
            IList<IWebElement> all;
            bool elementExist = false;
            bool elementShouldExist = bool.Parse(shouldExist);

            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(500);
                all = driver.FindElements(By.XPath("//table[@id = 'listOfRoles']//tbody//tr/td[2]"));

                foreach (IWebElement element in all)
                {
                    try
                    {
                        if (element.Text.Equals(roleName))
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

        [When(@"I click on switch for permission with id ""(.*)"" in the table ListOfPermissions \(b2c\)")]
        public void WhenIClickOnSwitchForPermissionWithIdInTheTableListOfPermissionsBc(string permissionId, Table table)
        {
            foreach (var row in table.Rows)
            {
                for (int i = 0; i < 5; i++)
                {
                    var currentStatus = driver.FindElement(By.XPath("//table[@id = 'listOfPerm']//tbody//tr/td[1][contains(text(), '" + row[0] + "')]/..//div[contains(@class, 'btn')]")).GetAttribute("class");
                    try
                    {
                        IWebElement element = driver.FindElement(By.XPath("//table[@id = 'listOfPerm']//tbody//tr/td[1][contains(text(), '" + row[0] + "')]/..//div[contains(@class, 'btn')]//span"));
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                        element.Click();
                        //driver.FindElement(By.XPath("//table[@id = 'listOfPerm']//tbody//tr/td[1][contains(text(), '" + row[0] + "')]/..//div[contains(@class, 'btn')]//span")).Click();
                        //System.Threading.Thread.Sleep(500);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Unable to click switch " + row[0] + ", try: " + i);
                        System.Threading.Thread.Sleep(1000);
                    }
                    if (!driver.FindElement(By.XPath("//table[@id = 'listOfPerm']//tbody//tr/td[1][contains(text(), '" + row[0] + "')]/..//div[contains(@class, 'btn')]")).GetAttribute("class").Equals(currentStatus))
                    {
                        break;
                    }
                }
            }
        }

        [Then(@"all permissions in the table ListOfPermissions should be activated is ""(.*)"" \(b2c\)")]
        public void ThenAllPermissionsInTheTableListOfPermissionsShouldBeActivatedIsBc(string isActivated)
        {
            string switchValue;
            if (bool.Parse(isActivated))
            {
                switchValue = "btn-primary";
            }
            else
            {
                switchValue = "btn-default";
            }
            IList<IWebElement> all;
            all = driver.FindElements(By.XPath("//table[@id = 'listOfPerm']//tbody//tr/td[3]//div[contains(@class, 'btn')]"));
            foreach (var item in all)
            {
                Assert.IsTrue(item.GetAttribute("class").Contains(switchValue));
            }
        }


    }
}
