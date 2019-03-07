using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq.Expressions;

namespace TestAutomationFramework.POM
{
    class JoomlaGeneralPage
    {
        private readonly RemoteWebDriver driver;
        public JoomlaGeneralPage(RemoteWebDriver driver) => this.driver = driver;

        IWebElement cookieBoxCloseButton => driver.FindElementByCssSelector("#pwebbox204_container .pwebbox_bottombar_toggler");
        
        public void OpenSite(string host)
        {
            driver.Navigate().GoToUrl(host);
            this.CloseCookieBanner();
            this.CookieBannerIsHidden();
        }

        public void ClickMenuItemByItemId(int itemId)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement curentMenu = driver.FindElement(By.XPath("//li[contains(@class, 'item-" + itemId + "')]/a"));
            if (!curentMenu.Displayed)
            {
                IWebElement currentMenuAncestor = driver.FindElement(By.XPath("//li[contains(@class, 'item-" + itemId + "')]/ancestor::li[contains(@class, '_level _n-1')]"));
                this.MoveCursorToElement(currentMenuAncestor);
            }
            wait.Until(wd => curentMenu.Displayed);
            curentMenu.Click();
        }

        public void ClickMenuItemByClass(string className)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = driver.FindElement(By.XPath("//li[contains(@class, '" + className + "')]/a"));

            if (!element.Displayed)
            {
                IWebElement currentMenuAncestor = driver.FindElement(By.XPath("//li[contains(@class, '" + className + "')]/ancestor::li[contains(@class, '_level _n-1')]"));
                this.MoveCursorToElement(currentMenuAncestor);
            }
            wait.Until(wd => element.Displayed);
            element.Click();
        }

        public void OpenSite(string host)
        {
            driver.Navigate().GoToUrl(host);
            this.CloseCookieBanner();
            this.CookieBannerIsHidden();
        }

        public void ClickMenuItemByItemId(int itemId)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement curentMenu = driver.FindElement(By.XPath("//li[contains(@class, 'item-" + itemId + "')]/a"));
            if (!curentMenu.Displayed)
            {
                IWebElement currentMenuAncestor = driver.FindElement(By.XPath("//li[contains(@class, 'item-" + itemId + "')]/ancestor::li[contains(@class, '_level _n-1')]"));
                this.MoveCursorToElement(currentMenuAncestor);
            }
            wait.Until(wd => curentMenu.Displayed);
            curentMenu.Click();
        }

        public void ClickMenuItemByClass(string className)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = driver.FindElement(By.XPath("//li[contains(@class, '" + className + "')]/a"));

            if (!element.Displayed)
            {
                IWebElement currentMenuAncestor = driver.FindElement(By.XPath("//li[contains(@class, '" + className + "')]/ancestor::li[contains(@class, '_level _n-1')]"));
                this.MoveCursorToElement(currentMenuAncestor);
            }
            wait.Until(wd => element.Displayed);
            element.Click();
        }

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

        public void MoveCursorToElement(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        public void HoverTopMenuItemByItemid(int itemid)
        {
            IWebElement element = driver.FindElement(By.CssSelector(".b-header__menu .item-" + itemid));
            MoveCursorToElement(element);
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

        public void ScrollToELement(IWebElement element )
        {
            Actions actions = new Actions(driver);

            actions.MoveToElement(element);
            actions.Perform();
        }

        public void SwitchToWindow(Expression<Func<IWebDriver, bool>> predicateExp)
        {
            var predicate = predicateExp.Compile();
            foreach (var handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
                if (predicate(driver))
                {
                    return;
                }
            }

            throw new ArgumentException(string.Format("Unable to find window with condition: '{0}'", predicateExp.Body));
        }
    }
}
