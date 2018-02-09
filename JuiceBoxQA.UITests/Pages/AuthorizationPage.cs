using JuiceBoxQA.UITests.Globals;
using JuiceBoxQA.UITests.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace JuiceBoxQA.UITests.Pages
{
    public class AuthorizationPage : JBLoadableComponent<AuthorizationPage>
    {
        private IWebDriver drv;

        private By loginField = By.Id("Email");
        private By passwordField = By.Id("Password");
        private By submitButton = By.XPath("//button[text()='Login']");

        public AuthorizationPage()
        {
            drv = ScenarioContext.Current.Get<IWebDriver>();
            if (!(drv.Url.Equals(Constants.JuiceNetLoginPage)))
            {
                drv.Navigate().GoToUrl(Constants.JuiceNetLoginPage);
            }
        }

        protected override void ExecuteLoad()
        {
        }

        protected override bool EvaluateLoadedStatus()
        {
            if (!JBElements.WaitForElementOnPageLoad(drv, loginField))
            {
                UnableToLoadMessage = "Could not load login page within the designated timeout period";
                return false;
            }
            return true;
        }

        public AuthorizationPage SetUsername(string username)
        {
            JBElements.SendKeys(drv, loginField, username);
            return this;
        }

        public AuthorizationPage SetPassword(string password)
        {
            JBElements.SendKeys(drv, passwordField, password);
            return this;
        }

        public void ClickSubmitButton()
        {
            JBElements.Click(drv, submitButton);
        }
    }
}