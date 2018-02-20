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
        private readonly By _buttonLogin = By.XPath("//button[text()='Login']");
        private readonly IWebDriver _driver;
        private readonly By _textfieldPassword = By.Id("Password");
        private readonly By _textfieldUsername = By.Id("Email");

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
            if (JBElements.WaitForElementOnPageLoad(_driver, _textfieldUsername)) return true;
            UnableToLoadMessage = "Could not load login page within the designated timeout period";
            return false;
        }

        public LoginPage SetUsername(string username)
        {
            JBElements.SendKeys(_driver, _textfieldUsername, username);
            return this;
        }

        public LoginPage SetPassword(string password)
        {
            JBElements.SendKeys(_driver, _textfieldPassword, password);
            return this;
        }

        public void ClickLoginButton()
        {
            JBElements.Click(_driver, _buttonLogin);
        }
    }
}