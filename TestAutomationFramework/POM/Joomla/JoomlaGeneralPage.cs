using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestAutomationFramework.POM
{
    class JoomlaGeneralPage
    {
        private readonly RemoteWebDriver driver;
        public JoomlaGeneralPage(RemoteWebDriver driver) => this.driver = driver;

        IWebElement cookieBoxCloseButton => driver.FindElementByCssSelector("#pwebbox204_container .pwebbox_bottombar_toggler");

        public void CloseCookieBanner()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => cookieBoxCloseButton.Displayed);
            cookieBoxCloseButton.Click();
        }

        public void CookieBannerIsHidden()
        {
            bool visible = IsElementVisible(cookieBoxCloseButton);

            Assert.IsFalse(visible);
        }

        public void MoveCursorToElement(string selector)
        {
            IWebElement element = driver.FindElementByCssSelector(selector);

            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        public void HoverTopMenuItemByItemid(int itemid)
        {
            string menuItemSelector = ".b-header__menu .item-" + itemid;

            MoveCursorToElement(menuItemSelector);
        }

        public void MenuItemSubmenuIsVisible(int itemid)
        {
            string menuItemSubmenuSelector = ".b-header__menu .item-" + itemid + " > ul.dropdown-menu";
            IWebElement element = driver.FindElementByCssSelector(menuItemSubmenuSelector);

            bool visible = IsElementVisible(element);
            Assert.IsTrue(visible);
        }

        public void ClickTopMenuItemByItemid(int itemid)
        {
            string menuItemSelector = ".b-header__menu .item-" + itemid;

            driver.FindElementByCssSelector(menuItemSelector).Click();
        }

        public bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }


    }
}
