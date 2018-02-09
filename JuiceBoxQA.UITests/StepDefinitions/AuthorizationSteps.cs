using AventStack.ExtentReports;
using JuiceBoxQA.UITests.Helpers;
using JuiceBoxQA.UITests.Models;
using JuiceBoxQA.UITests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace JuiceBoxQA.UITests.StepDefinitions
{
    [Binding]
    public class AuthorizationSteps
    {
        private IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>();

        private ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();

        [Given(@"I have a registered user (.*) with username (.*) and password (.*)")]
        public void GivenIHaveARegisteredUserWithUsernameAndPassword(string firstName, string username, string password)
        {
            User user = new User();
            user.FirstName = firstName;
            user.Username = username;
            user.Password = password;

            ScenarioContext.Current.Set<User>(user);
        }

        [Given(@"he is on the JuiceNet login page")]
        public void GivenHeIsOnTheJuiceNetLoginPage()
        {
            new AuthorizationPage().
            Load();
        }

        [When(@"he logs in using his credentials")]
        public void WhenHeLogsInUsingHisCredentials()
        {
            User user = ScenarioContext.Current.Get<User>();

            new AuthorizationPage().
                Load().
                SetUsername(user.Username).
                SetPassword(user.Password).
                ClickSubmitButton();
        }

        [When(@"he logs in using an invalid password")]
        public void WhenHeLogsInUsingAnInvalidPassword()
        {
            User user = ScenarioContext.Current.Get<User>();

            new AuthorizationPage().
                Load().
                SetUsername(user.Username).
                SetPassword("incorrectpassword").
                ClickSubmitButton();
        }

        [Then(@"he should land on the Accounts Overview page")]
        public void ThenHeShouldLandOnTheAccountsOverviewPage()
        {
            JBAssert.AssertTrue(driver, test, new MyJuiceNetDevicesPage().Load().IsAt(), "User landed on the Accounts Overview page after a successful login");
        }

        [Then(@"he should see an error message stating that the login request was denied")]
        public void ThenHeShouldSeeAnErrorMessageStatingThatTheLoginRequestWasDenied()
        {
            JBAssert.AssertEquals(driver, test, new AddJuiceNetDevicePage().Load().GetErrorMessage(), "The username and password could not be verified.", "Error message indicating an unsuccessful login is displayed");
        }
    }
}