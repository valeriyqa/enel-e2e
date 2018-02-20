#region

using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UITests.Helpers;

#endregion

namespace UITests.Pages
{
    public class LoginErrorPage : OTALoadableComponent<LoginErrorPage>
    {
        private readonly IWebDriver _driver;

        private readonly By _textlabelErrorMessage = By.XPath("//*[@class='validation-summary-errors text-danger']");

        public LoginErrorPage()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>();
        }

        protected override void ExecuteLoad()
        {
        }

        protected override bool EvaluateLoadedStatus()
        {
            if (!JBElements.WaitForElementOnPageLoad(_driver, _textlabelErrorMessage))
            {
                UnableToLoadMessage = "Could not load Login error page within the designated timeout period";
                return false;
            }

            return true;
        }

        public string GetErrorMessage()
        {
            return JBElements.GetElementText(_driver, _textlabelErrorMessage);
        }
    }
}