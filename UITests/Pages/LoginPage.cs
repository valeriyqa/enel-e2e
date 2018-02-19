#region

using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UITests.Globals;
using UITests.Helpers;

#endregion

namespace UITests.Pages
{
    public class LoginPage : OTALoadableComponent<LoginPage>
    {
        private readonly IWebDriver _driver;
        private readonly By buttonLogin = By.XPath("//button[text()='Login']");
        private readonly By textfieldPassword = By.Id("Password");

        private readonly By textfieldUsername = By.Id("Email");

        public LoginPage()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>();
            if (!_driver.Url.Equals(Constants.JuiceNetLoginPage))
                _driver.Navigate().GoToUrl(Constants.JuiceNetLoginPage);
        }

        protected override void ExecuteLoad()
        {
        }

        protected override bool EvaluateLoadedStatus()
        {
            if (!OTAElements.WaitForElementOnPageLoad(_driver, textfieldUsername))
            {
                UnableToLoadMessage = "Could not load login page within the designated timeout period";
                return false;
            }

            return true;
        }

        public LoginPage SetUsername(string username)
        {
            OTAElements.SendKeys(_driver, textfieldUsername, username);
            return this;
        }

        public LoginPage SetPassword(string password)
        {
            OTAElements.SendKeys(_driver, textfieldPassword, password);
            return this;
        }

        public void ClickLoginButton()
        {
            OTAElements.Click(_driver, buttonLogin);
        }
    }
}