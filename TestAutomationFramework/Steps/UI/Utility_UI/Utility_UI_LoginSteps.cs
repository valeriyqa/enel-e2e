using JsonConfig;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    public class Utility_UILoginSteps
    {
        private string host = Config.Global.env_utility_ui_address;
        private string userEmail = Config.Global.admin_user_email;
        private string userPassword = Config.Global.admin_user_password;

        private readonly RemoteWebDriver driver;

        public Utility_UILoginSteps(RemoteWebDriver driver) => this.driver = driver;

        [Given(@"I login to the UtilityUI as ""(.*)"" \(utility_ui\)")]
        public void GivenILoginToTheUtilityUIAs(string userName)
        {
            driver.Navigate().GoToUrl(host);

            var loginPage = new B2bLoginPage(driver);
            loginPage.SubmitLoginForm(userEmail, userPassword);
        }
    }
}
