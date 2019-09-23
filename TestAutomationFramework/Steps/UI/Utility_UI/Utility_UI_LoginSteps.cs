using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;
using TestAutomationFramework.POM.B2c;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    public class Utility_UILoginSteps
    {
        private readonly string host            = Config.Global.env_utility_ui_address;
        private readonly string userEmail       = Config.Global.admin_user_email;
        private readonly string userPassword    = Config.Global.admin_user_password;

        private readonly RemoteWebDriver driver;

        public Utility_UILoginSteps(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I login to the UtilityUI as ""(.*)"" \(utility_ui\)")]
        public void GivenILoginToTheUtilityUIAs(string userName)
        {
            driver.Navigate().GoToUrl(host);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            var loginPage = new B2bLoginPage(driver);
            loginPage.SubmitLoginForm(userEmail, userPassword);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Thread.Sleep(1000);

            driver.FindElement(By.CssSelector(".user-profile-menu")).Click();
            IWebElement utilityUIuserName = driver.FindElement(By.CssSelector("a.us-name"));

            Assert.AreEqual(
                utilityUIuserName.GetAttribute("innerText")
                    .Replace("\r", "")
                    .Replace("\n","")
                    .Trim(),
                userEmail
            );
        }
    }
}
