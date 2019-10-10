using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
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
                        if (element.Text.Equals("roleName"))
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
        public void WhenIClickOnSwitchForPermissionWithIdInTheTableListOfPermissionsBc(string permissionId)
        {
            driver.FindElement(By.XPath("//table[@id = 'listOfPerm']//tbody//tr/td[1][contains(text(), '" + permissionId + "')]/..//div[contains(@class, 'btn')]//span")).Click();
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
