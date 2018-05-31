using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;

namespace TestAutomationFramework.POM
{
    class B2bGeneralPage
    {
        IWebElement UserProfileButton => driver.FindElement(By.ClassName("user-profile-btn"));
        IWebElement UserEmail => driver.FindElement(By.CssSelector("[href*='my-account']"));


        private readonly IWebDriver driver;
        public B2bGeneralPage(IWebDriver driver) => this.driver = driver;
        //public B2bGeneralPage(IWebDriver driver) => this.driver = new NgWebDriver(driver);


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
            driver.FindElement(By.XPath("//span[contains(text(),'" + buttonName + "')]")).Click();
        }
    }
}
