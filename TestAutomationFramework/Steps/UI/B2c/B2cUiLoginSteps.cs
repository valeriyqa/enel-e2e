using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAutomationFramework.POM;
using OpenQA.Selenium.Support.UI;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Services;
using TestAutomationFramework.Services.ApiService;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    public class B2cUiLoginSteps
    {
        private readonly RemoteWebDriver driver;
        private string host = Config.Global.env_dashboard_address;
        //private Dictionary<string, Tools.LoadFromConf.User> usersDictionary = Tools.LoadFromConf.GetUsers();

        public B2cUiLoginSteps(RemoteWebDriver driver) => this.driver = driver;

        [Then(@"Alert message ""(.*)"" is displayed \(b2c\)")]
        public void ThenAlertMessageIsDisplayedBc(string errMsg)
        {
            var currentMessage = driver.FindElement(By.CssSelector("[class*='validation-summary-errors']>ul>li")).Text;
            Assert.AreEqual(errMsg, currentMessage);
        }

        [Then(@"panel with message ""(.*)"" should be displayed \(b2c\)")]
        public void ThenPanelWithMessageShouldBeDisplayedBc(string errMsg)
        {
            Assert.True(driver.FindElement(By.XPath("//div[contains(@class, 'panel-danger')]//div[contains(@class, 'panel-body')]/p")).Text.Contains(errMsg));
        }


        //public LoginSteps(RemoteWebDriver driver)
        //{
        //    this.driver = driver;
        //}

        //[Given(@"I navigate to application")]
        //public void GivenINavigateToApplication()
        //{
        //    Console.WriteLine("I navigate to application");
        //    driver.Navigate().GoToUrl(host + "Account/Login");
        //}

        //[Given(@"I enter username and password")]
        //public void GivenIEnterUsernameAndPassword(Table table)
        //{
        //    Console.WriteLine("I enter username and password");
        //    dynamic data = table.CreateDynamicInstance();
        //    driver.FindElement(By.Id("Email")).SendKeys((String)data.UserName);
        //    driver.FindElement(By.Id("Password")).SendKeys((String)data.Password);
        //}

        //[Given(@"I click login")]
        //public void GivenIClickLogin()
        //{
        //    Console.WriteLine("I click login");
        //    driver.FindElement(By.ClassName("btn-primary")).Submit();
        //    Thread.Sleep(2000);
        //}

        //[Then(@"I should see user logged into the application")]
        //public void ThenIShouldSeeUserLoggedIntoTheApplication()
        //{
        //    Console.WriteLine("I should see used logged inmto the application");
        //    //var element = _driver.FindElement(By.XPath("(//a[contains(@href, '#')])[2][contains(text(), 'Alexander Burdeyniy')]"));
        //    //Assert.That(element.Text, Is.Not.Null, "Header text not found!!!");
        //}

        //[Given(@"I login to the application as ""(.*)""")]
        //public void GivenILoginToTheApplicationAs(string userName)
        //{
        //    driver.Navigate().GoToUrl(host + "Account/Login");
        //    LoginPage loginPage = new LoginPage(driver);
        //    Tools.LoadUsersFromConf.User currentUser = usersDictionary[userName];
        //    loginPage.LoginToApplication(currentUser.userEmail, currentUser.userPassword);
        //    GeneralPage generalPage = new GeneralPage(driver);
        //    Assert.AreEqual(generalPage.GetUserName(), currentUser.userDescription);
        //}

    }
}
 