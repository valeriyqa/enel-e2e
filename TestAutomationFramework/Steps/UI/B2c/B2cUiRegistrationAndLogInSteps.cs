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
using TestAutomationFramework.POM.B2c;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2cUiRegistrationAndLogInSteps
    {
        private readonly RemoteWebDriver driver;
        private string host = Config.Global.env_dashboard_address;
        private Dictionary<string, Tools.LoadFromConf.User> usersDictionary = Tools.LoadFromConf.GetUsers();
        //private string userEmail = Config.Global.web_user_email;
        //private string userPassword = Config.Global.web_user_password;
        //private string userDescription = Config.Global.web_user_description;

        //public B2cUiRegistrationAndLogInSteps(RemoteWebDriver driver) => this.driver = driver;

        private ScenarioContext scenarioContext;

        public B2cUiRegistrationAndLogInSteps(RemoteWebDriver driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            this.scenarioContext = scenarioContext;
        }

        //public B2cUiRegistrationAndLogInSteps(RemoteWebDriver driver, Dictionary<string, Tools.LoadFromConf.User> usersDictionary)
        //{
        //    this.driver = driver;
        //    this.usersDictionary = usersDictionary;
        //}


        [Given(@"I navigate to ""(.*)"" page \(b2c\)")] //done
        public void GivenINavigateToPage(string page)
        {
            driver.Navigate().GoToUrl(host + page);
        }

        //[When(@"I click on ""(.*)"" link \(b2c\)")]  //done
        //public void WhenIClickOnLink(string linkText)
        //{
        //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    wait.Until(wd => driver.FindElementByPartialLinkText(linkText).Displayed);
        //    driver.FindElementByPartialLinkText(linkText).Click();
        //}
        [When(@"I click on ""(.*)"" link \(b2c\)")]  //done
        public void WhenIClickOnLink(string linkText)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElementByPartialLinkText(linkText).Displayed);
            driver.FindElementByPartialLinkText(linkText).Click();
        }

        [Then(@"I should be navigated to the ""(.*)"" page \(b2c\)")] //done
        public void ThenIShouldBeNavigatedToThePage(string page)
        {
            Assert.AreEqual(host + page, driver.Url);
        }

        //Get value from config by key and set to field
        [When(@"I set field ""(.*)"" to ""(.*)"" from config \(b2c\)")] //Ok
        public void WhenISetFieldToFromConfigBc(string fieldId, string configKey)
        {
            //Clean it
            Console.WriteLine("Step: I set field " + fieldId + " to " + Config.Global[configKey] + " from config (b2c) Started");
            Console.WriteLine("Set field with Id: " + fieldId + " to: " + Config.Global[configKey]);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElementById(fieldId).Displayed);
            driver.FindElementById(fieldId).Clear();
            driver.FindElementById(fieldId).SendKeys(Config.Global[configKey]);
            Console.WriteLine("Field with Id: " + fieldId + " equals to: " + driver.FindElementById(fieldId).GetAttribute("value"));
            //Clean it
            Console.WriteLine("Step: I set field " + fieldId + " to " + Config.Global[configKey] + " from config (b2c) Finished");
        }

        //Set value to field
        [When(@"I set field ""(.*)"" to ""(.*)"" \(b2c\)")] //Ok
        public void WhenISetFieldTo(string fieldId, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElementById(fieldId).Displayed);
            driver.FindElementById(fieldId).Clear();
            driver.FindElementById(fieldId).SendKeys(value);
        }

        [When(@"I set field ""(.*)"" to ""(.*)"" \(b2c\)")] //done
        public void WhenISetFieldTo(string fieldId, string value, Table table)
        {
            foreach (var row in table.Rows)
            {
                driver.FindElementById(row[0]).Clear();
                driver.FindElementById(row[0]).SendKeys(row[1]);
            }
        }


        [Then(@"field ""(.*)"" should be masked \(b2c\)")] //done
        public void ThenFieldShouldBeMasked(string fieldId)
        {
            Assert.AreEqual(driver.FindElementById(fieldId).GetAttribute("type"), "password");
        }

        [Then(@"field ""(.*)"" should be masked \(b2c\)")] //done
        public void ThenFieldShouldBeMasked(string p0, Table table)
        {
            foreach (var row in table.Rows)
            {
                Assert.AreEqual(driver.FindElementById(row[0]).GetAttribute("type"), "password");
            }
        }

        [When(@"I confirm my email address \(b2c\)")]
        public void WhenIConfirmMyEmailAddress()
        {
            Console.WriteLine("I confirm my email address");
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(AppDomain.CurrentDomain.SetupInformation);
            Console.WriteLine(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents"));
            Console.WriteLine(File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", "taf_is_local.txt")));
            Console.WriteLine(File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", "taf_is_not_local.txt")));
        }

        [Then(@"I should be logged into the application as ""(.*)"" \(b2c\)")]
        public void ThenIShouldBeLoggedIntoTheApplicationAsBc(string userName)
        {
            Tools.LoadFromConf.User currentUser = usersDictionary[userName];
            var managePage = new B2cManagePage(driver);

            Assert.AreEqual(managePage.getUserDescription(), currentUser.userDescription);
            Assert.AreEqual(managePage.getUserEmail(), currentUser.userEmail);
        }


        //[Then(@"I should be logged into the application \(b2c\)")]
        //public void ThenIShouldBeLoggedIntoTheApplicationBc()
        //{
        //    Tools.LoadFromConf.User currentUser = usersDictionary[userName];
        //    var managePage = new B2cManagePage(driver);

        //    Assert.AreEqual(managePage.getUserDescription(), usersDictionary["userDescription"]);
        //    Assert.AreEqual(managePage.getUserEmail(), usersDictionary["userDescription"]);
        //}

        [Given(@"I login to the system as ""(.*)"" \(b2c\)")]
        public void GivenILoginToTheB2cSystemAs(string userName)
        {
            //Clean it
            Console.WriteLine("Step: I login to the system as " + userName + " (b2c) Started");

            driver.Navigate().GoToUrl(host + "Account/Login");
            B2cLoginPage loginPage = new B2cLoginPage(driver);
            Tools.LoadFromConf.User currentUser = usersDictionary[userName];
            loginPage.LoginToApplication(currentUser.userEmail, currentUser.userPassword);
            B2cGeneralPage generalPage = new B2cGeneralPage(driver);
            //Clean it
            Console.WriteLine("Step: I login to the system as " + userName + " (b2c) Finished");
        }

        //Delete it if work normally
        //[Given(@"I login to the system as ""(.*)"" \(b2c\)")]
        //public void GivenILoginToTheB2cSystemAs(string userName)
        //{
        //    driver.Navigate().GoToUrl(host + "Account/Login");
        //    B2cLoginPage loginPage = new B2cLoginPage(driver);
        //    //Tools.LoadFromConf.User currentUser = usersDictionary[userName];
        //    loginPage.LoginToApplication(userEmail, userPassword);
        //    B2cGeneralPage generalPage = new B2cGeneralPage(driver);
        //    Assert.AreEqual(generalPage.GetUserName(), userDescription);
        //}

            // ScenarioContext.Current demo mock

            //[When(@"I save this number ""(.*)"" \(b2c\)")]
            //public void WhenISaveThisNumberBc(int sharedNumber)
            //{
            //    ScenarioContext.Current["sharedNumber"] = sharedNumber;
            //}

            //[Then(@"I sum shared number with ""(.*)"" \(b2c\)")]
            //public void ThenISumThatNumberWithBc(int stepNumber)
            //{
            //    var sharedNumber = ScenarioContext.Current["sharedNumber"];
            //    int finalNumber = Convert.ToInt32(sharedNumber) + stepNumber;
            //    Console.WriteLine("Final number = {0}", finalNumber);
            //}

        }
    }
