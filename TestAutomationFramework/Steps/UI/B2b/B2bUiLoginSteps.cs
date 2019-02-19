using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2bUiLoginSteps
    {
        private string host = Config.Global.env_dashboard_address;
        private string userEmail = Config.Global.web_user_email;
        private string userPassword = Config.Global.web_user_password;

        private readonly RemoteWebDriver driver;
        public B2bUiLoginSteps(RemoteWebDriver driver) => this.driver = driver;


        [Given(@"I login to the system as ""(.*)"" \(b2b\)")]
        public void ILoginToTheB2bSystemAsB2B(string userName)
        {
            driver.Navigate().GoToUrl(host);

            var loginPage = new B2bLoginPage(driver);
            loginPage.SubmitLoginForm(userEmail, userPassword);

            var generalPage = new B2bGeneralPage(driver);
            var result = generalPage.GetUserEmail();
            Console.WriteLine("User Email=" + result);
            Assert.AreEqual(result, userEmail);
        }

        //probaby we have to make this method more general and move to the correspondig class
        [When(@"I click on the ""(.*)"" link by name \(b2b\)")]
        public void IClickOnTheLinkByNameB2b(string locationName)
        {
            var locationPage = new B2bLocationPage(driver);
            locationPage.ClickLocationLinkByName(locationName);
        }
        
    }
}
