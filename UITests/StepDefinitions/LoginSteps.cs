#region

using AventStack.ExtentReports;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UITests.DataEntities;
using UITests.Helpers;
using UITests.Pages;

#endregion

namespace UITests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>();

        private readonly ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();

        [Given(@"I have a registered user (.*) with username (.*) and password (.*)")]
        public void GivenIHaveARegisteredUserWithUsernameAndPassword(string firstName, string username, string password)
        {
            var user = new User
            {
                FirstName = firstName,
                Username = username,
                Password = password
            };

            ScenarioContext.Current.Set(user);
        }

        [Given(@"he is on the JuiceNet home page")]
        public void GivenHeIsOnTheJuiceNetHomePage()
        {
            new LoginPage().Load();
        }

        [When(@"he logs in using his credentials")]
        public void WhenHeLogsInUsingHisCredentials()
        {
            var user = ScenarioContext.Current.Get<User>();

            new LoginPage().Load().SetUsername(user.Username).SetPassword(user.Password).ClickLoginButton();
        }

        [When(@"he logs in using an invalid password")]
        public void WhenHeLogsInUsingAnInvalidPassword()
        {
            var user = ScenarioContext.Current.Get<User>();

            new LoginPage().Load().SetUsername(user.Username).SetPassword("incorrectpassword").ClickLoginButton();
        }

        [Then(@"he should land on the Accounts Overview page")]
        public void ThenHeShouldLandOnTheAccountsOverviewPage()
        {
            OTAAssert.AssertTrue(driver, test, new AccountsOverviewPage().Load().IsAt(),
                "User landed on the Accounts Overview page after a successful login");
        }

        [Then(@"he should see an error message stating that the login request was denied")]
        public void ThenHeShouldSeeAnErrorMessageStatingThatTheLoginRequestWasDenied()
        {
            OTAAssert.AssertEquals(driver, test, new LoginErrorPage().Load().GetErrorMessage(),
                "The username and password could not be verified.",
                "Error message indicating an unsuccessful login is displayed");
        }
    }
}