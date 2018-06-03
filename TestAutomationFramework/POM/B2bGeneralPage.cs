using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TestAutomationFramework.POM
{
    class B2bGeneralPage
    {
        IWebElement UserProfileButton => driver.FindElement(By.ClassName("user-profile-btn"));
        IWebElement UserEmail => driver.FindElement(By.CssSelector("[href*='my-account']"));
        IWebElement PopupWindow => driver.FindElement(By.ClassName("cdk-overlay-container")).FindElement(By.ClassName("mat-dialog-title"));

        private readonly IWebDriver driver;
        public B2bGeneralPage(IWebDriver driver) => this.driver = driver;

        public string GetUserEmail()
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.TagName("iframe")));

            UserProfileButton.Click();
            var result = UserEmail.Text;
            UserProfileButton.Click();
            return result;
        }

        public void ClickMenuByName(string menuName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.ClassName("navbar-nav")).Displayed);

            driver.FindElement(By.ClassName("navbar-nav")).FindElement(By.CssSelector("[href*='" + menuName.ToLower() + "']")).Click();
        }

        public void ClickButtonByName(string buttonName)
        {
            driver.FindElement(By.XPath("//span[@class='mat-button-wrapper'][contains(text(),'" + buttonName + "')]")).Click();
        }

        public void SetInputByName(string inputName, string inputValue)
        {
            driver.FindElement(By.XPath("//input[@formcontrolname='" + inputName + "']")).Clear();
            driver.FindElement(By.XPath("//input[@formcontrolname='" + inputName + "']")).SendKeys(inputValue);
        }

        public void SetInputByName(string inputName, string inputValue, bool waitForFill)
        {
            if (waitForFill)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(wd => driver.FindElement(By.XPath("//input[@formcontrolname='" + inputName + "']")).GetAttribute("value").Length > 0);
            }
            SetInputByName(inputName, inputValue);
        }

        public void SelectFromListByValue(IWebElement selector, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => selector.GetAttribute("aria-owns").Length > 0);
            selector.FindElement(By.ClassName("mat-select-trigger")).Click();
            wait.Until(wd => driver.FindElement(By.ClassName("cdk-overlay-container")).FindElement(By.ClassName("ng-trigger")));

            IList<IWebElement> AllDropDownList = driver.FindElements(By.XPath("//span[@class='mat-option-text']"));
            foreach (var element in AllDropDownList)
            {
                if (element.Text.Contains(value))
                {
                    element.Click();
                    System.Threading.Thread.Sleep(500);
                    break;
                }
            }
        }

        public void AssertPopup(string message, string status)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => PopupWindow.Displayed);

            Assert.AreEqual(PopupWindow.FindElement(By.ClassName("mat-icon")).Text.Trim(), status);
            Assert.AreEqual(PopupWindow.FindElement(By.XPath("//h2")).Text.Trim(), message);
        }
    }
}
