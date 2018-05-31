using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;
using System.Linq;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2bUiLoginSteps
    {
        private string host = Config.Global.environment.dashboard_address;
        private Dictionary<string, Tools.LoadUsersFromConf.User> usersDictionary = Tools.LoadUsersFromConf.GetUsers();

        private readonly RemoteWebDriver driver;
        public B2bUiLoginSteps(RemoteWebDriver driver) => this.driver = driver;


        [Given(@"I login to the system as ""(.*)"" \(b2b\)")]
        public void GivenILoginToTheB2bSystemAsB2B(string userName)
        {
            Tools.LoadUsersFromConf.User currentUser = usersDictionary[userName];
            driver.Navigate().GoToUrl(host);

            var loginPage = new B2bLoginPage(driver);
            loginPage.SubmitLoginForm(currentUser.userEmail, currentUser.userPassword);

            var generalPage = new B2bGeneralPage(driver);
            Console.WriteLine("User Email=" + generalPage.GetUserEmail());
            Assert.AreEqual(generalPage.GetUserEmail(), currentUser.userEmail);
        }

        [Given(@"I navigate to the ""(.*)"" page \(b2b\)")]
        [When(@"I navigate to the ""(.*)"" page \(b2b\)")]
        public void GivenINavigateToThePageB2B(string pageName)
        {
            var generalPage = new B2bGeneralPage(driver);
            generalPage.ClickMenuByName(pageName);
            Assert.AreEqual(driver.Url.Contains(pageName.ToLower()), true);
        }

        [When(@"I click on the ""(.*)"" button \(b2b\)")]
        public void WhenIClickOnTheButtonB2b(string buttonName)
        {
            var generalPage = new B2bGeneralPage(driver);
            generalPage.ClickButtonByName(buttonName);

        }
    }
}
