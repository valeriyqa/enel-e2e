using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
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
        private string host = Config.Global.environment.dashboard_address;
        private Dictionary<string, Tools.LoadUsersFromConf.User> usersDictionary = Tools.LoadUsersFromConf.GetUsers();

        private readonly RemoteWebDriver driver;
        public B2bUiLoginSteps(RemoteWebDriver driver) => this.driver = driver;


        [Given(@"I login to the system as ""(.*)"" \(b2b\)")]
        public void ILoginToTheB2bSystemAsB2B(string userName)
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
        public void INavigateToThePageB2B(string pageName)
        {
            var generalPage = new B2bGeneralPage(driver);
            generalPage.ClickMenuByName(pageName);
            Assert.AreEqual(driver.Url.Contains(pageName.ToLower()), true);
        }

        [Given(@"I click on the ""(.*)"" button \(b2b\)")]
        [When(@"I click on the ""(.*)"" button \(b2b\)")]
        public void IClickOnTheButtonB2b(string buttonName)
        {
            var generalPage = new B2bGeneralPage(driver);
            generalPage.ClickButtonByName(buttonName);

        }

        [When(@"I set input ""(.*)"" to the value ""(.*)"" \(b2b\)")]
        public void ISetInputToTheValueB2b(string inputName, string inputValue)
        {
            var generalPage = new B2bGeneralPage(driver);
            generalPage.SetInputByName(inputName, inputValue);
        }

        [When(@"I click the Same as parent checkbox \(b2b\)")]
        public void IClickTheSameAsParentCheckboxB2b()
        {
            var locationPage = new B2bLocationPage(driver);
            locationPage.ClickSameAsParentCheckbox();
        }

        [When(@"I select ""(.*)"" on the Time zone selector \(b2b\)")]
        public void ISelectOnTheTimeZoneSelectorB2b(string value)
        {
            var locationPage = new B2bLocationPage(driver);
            locationPage.SelectTimeZoneByValue(value);
        }

        [When(@"I select ""(.*)"" on the Assign rate selector \(b2b\)")]
        public void ISelectOnTheAssignRateSelectorB2b(string value)
        {
            var locationPage = new B2bLocationPage(driver);
            locationPage.SelectAssignRateByValue(value);
        }

        [When(@"I populate the Location form with correct data \(b2b\)")]
        public void IPopulateTheLocationFormWithCorrectDataB2b()
        {
            var locationPage = new B2bLocationPage(driver);
            locationPage.ClickSameAsParentCheckbox();

            var generalPage = new B2bGeneralPage(driver);
            generalPage.SetInputByName("name", "Test Location");
            generalPage.SetInputByName("address", "Test Address", true);
            generalPage.SetInputByName("city", "Test City", true);
            generalPage.SetInputByName("state", "Test State", true);
            generalPage.SetInputByName("zip", "123456", true);
            locationPage.SelectTimeZoneByValue("(UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius");
        }

        [Then(@"Popup window with ""(.*)"" message and ""(.*)"" status should be displayed \(b2b\)")]
        public void ThenPopupWindowWithMessageAndStatusShouldBeDisplayedBb(string messageText, string status)
        {
            var generalPage = new B2bGeneralPage(driver);
            generalPage.AssertPopup(messageText, status);
        }

    }
}
