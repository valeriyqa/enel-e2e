﻿using JsonConfig;
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
        private string host = Config.Global.env_dashboard_address;
        //private Dictionary<string, Tools.LoadFromConf.User> usersDictionary = Tools.LoadFromConf.GetUsers();
        private string userEmail = Config.Global.web_user_email;
        private string userPassword = Config.Global.web_user_password;
        private string userDescription = Config.Global.web_user_description;

        public B2cUiRegistrationAndLogInSteps(RemoteWebDriver driver) => this.driver = driver;

        [Given(@"I navigate to ""(.*)"" page \(b2c\)")] //done
        public void GivenINavigateToPage(string page)
        {
            driver.Navigate().GoToUrl(host + page);
        }

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
            Assert.AreEqual(driver.Url, host + page);
        }

        [When(@"I set field ""(.*)"" to ""(.*)"" \(b2c\)")] //done
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

        [Then(@"I should be logged into the application \(b2c\)")]
        public void ThenIShouldBeLoggedIntoTheApplication()
        {
            Console.WriteLine("I should be logged into the application");
        }

        [Given(@"I login to the system as ""(.*)"" \(b2c\)")]
        public void GivenILoginToTheB2cSystemAs(string userName)
        {
            driver.Navigate().GoToUrl(host + "Account/Login");
            B2cLoginPage loginPage = new B2cLoginPage(driver);
            //Tools.LoadFromConf.User currentUser = usersDictionary[userName];
            loginPage.LoginToApplication(userEmail, userPassword);
            B2cGeneralPage generalPage = new B2cGeneralPage(driver);
            Assert.AreEqual(generalPage.GetUserName(), userDescription);
        }
    }
}
