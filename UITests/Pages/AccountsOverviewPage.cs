#region

using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UITests.Helpers;

#endregion

namespace UITests.Pages
{
    public class AccountsOverviewPage : OTALoadableComponent<AccountsOverviewPage>
    {
        private readonly IWebDriver _driver;

        private readonly By _textlabelPageHeader = By.XPath("//h2[text()='My JuiceNet Devices ']");

        public AccountsOverviewPage()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>();
        }

        protected override void ExecuteLoad()
        {
        }

        protected override bool EvaluateLoadedStatus()
        {
            if (!JBElements.WaitForElementOnPageLoad(_driver, _textlabelPageHeader))
            {
                UnableToLoadMessage = "Could not load Accounts Overview page within the designated timeout period";
                return false;
            }

            return true;
        }

        public bool IsAt()
        {
            return JBElements.CheckElementIsVisible(_driver, _textlabelPageHeader);
        }
    }
}