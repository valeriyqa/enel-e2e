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

        private readonly By textlabelPageHeader = By.XPath("//h2[text()='My JuiceNet Devices ']");

        public AccountsOverviewPage()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>();
        }

        protected override void ExecuteLoad()
        {
        }

        protected override bool EvaluateLoadedStatus()
        {
            if (!OTAElements.WaitForElementOnPageLoad(_driver, textlabelPageHeader))
            {
                UnableToLoadMessage = "Could not load Accounts Overview page within the designated timeout period";
                return false;
            }

            return true;
        }

        public bool IsAt()
        {
            return OTAElements.CheckElementIsVisible(_driver, textlabelPageHeader);
        }
    }
}