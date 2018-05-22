using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2bUiLoginSteps
    {
        private readonly RemoteWebDriver driver;
        private string host = Config.Global.environment.dashboard_address;
        private Dictionary<string, Tools.LoadUsersFromConf.User> usersDictionary = Tools.LoadUsersFromConf.GetUsers();

        public B2bUiLoginSteps(RemoteWebDriver driver) => this.driver = driver;

        [Given(@"I login to the b2b system as ""(.*)""")]
        public void GivenILoginToTheB2bSystemAs(string userName)
        {
            driver.Navigate().GoToUrl(host);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(wd => driver.Url.Contains("/identity/login?"));
            B2bLoginPage loginPage = new B2bLoginPage(driver);
            Tools.LoadUsersFromConf.User currentUser = usersDictionary[userName];
            loginPage.LoginToApplication(currentUser.userEmail, currentUser.userPassword);

            B2bGeneralPage generalPage = new B2bGeneralPage(driver);
            Assert.AreEqual(generalPage.GetUserName(), currentUser.userEmail);
        }
    }
}
