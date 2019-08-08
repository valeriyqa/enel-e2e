using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    public class JoomlaCheckoutSteps
    {
        private readonly RemoteWebDriver driver;
        private string host = Config.Global.env_site_address;

        public JoomlaCheckoutSteps(RemoteWebDriver driver) => this.driver = driver;

        [Given(@"I open site \(joomla\)")]
        public void IOpenSite()
        {
            var generalPage = new JoomlaGeneralPage(driver);
            generalPage.OpenSite(host);
        }

        [Given(@"I Navigate to menu item with ""(.*)"" ID \(joomla\)")]
        [Then(@"I Navigate to menu item with ""(.*)"" ID \(joomla\)")]
        public void INavigateToMenuItemWithIDJoomla(int itemId)
        {
            var generalPage = new JoomlaGeneralPage(driver);
            generalPage.ClickMenuItemByItemId(itemId);
        }


        [When(@"I Close cookie banner \(joomla\)")]
        public void ICloseCookieBannerJoomla()
        {
            var generalPage = new JoomlaGeneralPage(driver);
            generalPage.CloseCookieBanner();
        }

        [Then(@"Cookie banner must hide \(joomla\)")]
        public void CookieBannerMustHideJoomla()
        {
            var generalPage = new JoomlaGeneralPage(driver);
            generalPage.CookieBannerIsHidden();
        }

        [When(@"I hover top menu item with (.*) Itemid \(joomla\)")]
        public void WhenIHoverTopMenuItemWithItemidJoomla(int itemId)
        {
            var generalPage = new JoomlaGeneralPage(driver);
            generalPage.HoverTopMenuItemByItemid(itemId);
        }

        [Then(@"Menu Item (.*) Sub-menu must be visible \(joomla\)")]
        public void MenuItemSubmenuMustBeVisible(int itemId)
        {
            var generalPage = new JoomlaGeneralPage(driver);
            generalPage.MenuItemSubmenuIsVisible(itemId);
        }

        [Then(@"I Click top menu item with (.*) Itemid \(joomla\)")]
        public void ThenIClickTopMenuItemWithItemidJoomla(int itemId)
        {
            var generalPage = new JoomlaGeneralPage(driver);
            //generalPage.ClickTopMenuItemByItemid(itemId);
        }
    }
}
