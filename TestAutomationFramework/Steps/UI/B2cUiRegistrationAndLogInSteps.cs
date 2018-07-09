using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2cUiRegistrationAndLogInSteps
    {
        private readonly RemoteWebDriver driver;
        private string host = Config.Global.environment.dashboard_address;
        private Dictionary<string, Tools.LoadUsersFromConf.User> usersDictionary = Tools.LoadUsersFromConf.GetUsers();

        public B2cUiRegistrationAndLogInSteps(RemoteWebDriver driver) => this.driver = driver;

        [Given(@"I navigate to ""(.*)"" page")] //done
        public void GivenINavigateToPage(string page)
        {
            driver.Navigate().GoToUrl(host + page);
        }

        [When(@"I click on ""(.*)"" link")]  //done
        public void WhenIClickOnLink(string linkText)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElementByPartialLinkText(linkText).Displayed);
            driver.FindElementByPartialLinkText(linkText).Click();
        }

        [Then(@"I should be navigated to the ""(.*)"" page")] //done
        public void ThenIShouldBeNavigatedToThePage(string page)
        {
            Assert.AreEqual(driver.Url, host + page);
        }

        [When(@"I set field ""(.*)"" to ""(.*)""")] //done
        public void WhenISetFieldTo(string fieldId, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElementById(fieldId).Displayed);
            driver.FindElementById(fieldId).Clear();
            driver.FindElementById(fieldId).SendKeys(value);
        }

        [When(@"I set field ""(.*)"" to ""(.*)""")] //done
        public void WhenISetFieldTo(string fieldId, string value, Table table)
        {
            foreach (var row in table.Rows)
            {
                driver.FindElementById(row[0]).Clear();
                driver.FindElementById(row[0]).SendKeys(row[1]);
            }
        }


        [Then(@"field ""(.*)"" should be masked")] //done
        public void ThenFieldShouldBeMasked(string fieldId)
        {
            Assert.AreEqual(driver.FindElementById(fieldId).GetAttribute("type"), "password");
        }

        [Then(@"field ""(.*)"" should be masked")] //done
        public void ThenFieldShouldBeMasked(string p0, Table table)
        {
            foreach (var row in table.Rows)
            {
                Assert.AreEqual(driver.FindElementById(row[0]).GetAttribute("type"), "password");
            }
        }

        [When(@"I click on button by with Id ""(.*)""")] //done
        public void WhenIClickOnButtonWithId(string buttonId)
        {
            driver.FindElementById(buttonId).Submit();
        }

        [When(@"I click on ""(.*)"" button")] //done
        public void WhenIClickOnButton(string buttonText)
        {
            IJavaScriptExecutor js = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => (Int64)js.ExecuteScript("return $(\"button:contains('" + buttonText + "'):visible\").length;") > 0);

            js.ExecuteScript("$(\"button:contains('" + buttonText + "'):visible\").click();");

        }

        [When(@"I confirm my email address")]
        public void WhenIConfirmMyEmailAddress()
        {
            Console.WriteLine("I confirm my email address");
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(AppDomain.CurrentDomain.SetupInformation);
            Console.WriteLine(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents"));
            Console.WriteLine(File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", "taf_is_local.txt")));
            Console.WriteLine(File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", "taf_is_not_local.txt")));
        }

        [Then(@"I should be logged into the application")]
        public void ThenIShouldBeLoggedIntoTheApplication()
        {
            Console.WriteLine("I should be logged into the application");
        }

        //[Given(@"I login to the application as ""(.*)""")] //done
        //public void GivenILoginToTheApplicationAs(string userName)
        //{
        //    driver.Navigate().GoToUrl(host + "Account/Login");
        //    B2cLoginPage loginPage = new B2cLoginPage(driver);
        //    Tools.LoadUsersFromConf.User currentUser = usersDictionary[userName];
        //    loginPage.LoginToApplication(currentUser.userEmail, currentUser.userPassword);
        //    B2cGeneralPage generalPage = new B2cGeneralPage(driver);
        //    Assert.AreEqual(generalPage.GetUserName(), currentUser.userDescription);
        //}

        [Given(@"I login to the b2c system as ""(.*)""")]
        public void GivenILoginToTheB2cSystemAs(string userName)
        {
            driver.Navigate().GoToUrl(host + "Account/Login");
            B2cLoginPage loginPage = new B2cLoginPage(driver);
            Tools.LoadUsersFromConf.User currentUser = usersDictionary[userName];
            loginPage.LoginToApplication(currentUser.userEmail, currentUser.userPassword);
            B2cGeneralPage generalPage = new B2cGeneralPage(driver);
            Assert.AreEqual(generalPage.GetUserName(), currentUser.userDescription);
        }
    }
}
