using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TestAutomationFramework.POM
{
    class B2cGeneralPage
    {
        private readonly RemoteWebDriver driver;
        public B2cGeneralPage(RemoteWebDriver driver) => this.driver = driver;

        IWebElement userNameButton => driver.FindElementByXPath("//*[@id='wrapper']/nav/ul/li[3]/a");

        public string GetUserName()
        {
            return userNameButton.Text.ToString();
        }

        public void ClickMenuByName(string menuName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.Id("side-menu")).Displayed);

            IWebElement curentMenu = driver.FindElement(By.XPath("//ul[@id = 'side-menu']//a[contains(text(),'" + menuName + "')]"));
            if (!curentMenu.Displayed)
            {
                driver.FindElement(By.XPath("//ul[@id = 'side-menu']//a[contains(text(),'" + menuName + "')]//ancestor::ul[@class='nav nav-second-level collapse']/../a")).Click();
            }
            wait.Until(wd => curentMenu.Displayed);
            curentMenu.Click();
        }

        public string GetAddressByMenuName(string menuName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.Id("side-menu")).Displayed);

            string address = driver.FindElement(By.XPath("//ul[@id = 'side-menu']//a[contains(text(),'" + menuName + "')]")).GetAttribute("href").ToString().Replace("/Dashboard", "").TrimEnd('#');
            if (address.Contains("OcppAdmin"))
            {
                address = address + "/CentralSystem";
            }
            return address;
        }

    }
}
