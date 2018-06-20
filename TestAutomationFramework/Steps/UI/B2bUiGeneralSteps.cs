using NUnit.Framework;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2bUiGeneralSteps
    {
        private readonly RemoteWebDriver driver;
        public B2bUiGeneralSteps(RemoteWebDriver driver) => this.driver = driver;

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

        [Then(@"Popup window with ""(.*)"" message and ""(.*)"" status should be displayed \(b2b\)")]
        public void ThenPopupWindowWithMessageAndStatusShouldBeDisplayedBb(string messageText, string status)
        {
            var generalPage = new B2bGeneralPage(driver);
            generalPage.AssertPopup(messageText, status);
        }
    }
}
