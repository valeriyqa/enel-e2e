using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;
using System.Linq;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2bUiLoginSteps
    {
        private string host = Config.Global.environment.dashboard_address;
        private Dictionary<string, Tools.LoadUsersFromConf.User> usersDictionary = Tools.LoadUsersFromConf.GetUsers();

        private readonly RemoteWebDriver driver;
        public B2bUiLoginSteps(RemoteWebDriver driver) => this.driver = driver;


        [Given(@"I login to the b2b system as ""(.*)""")]
        public void GivenILoginToTheB2bSystemAs(string userName)
        {
            Tools.LoadUsersFromConf.User currentUser = usersDictionary[userName];
            driver.Navigate().GoToUrl(host);

            var loginPage = new B2bLoginPage(driver);
            var generalPage = loginPage.SubmitLoginForm(currentUser.userEmail, currentUser.userPassword);
            Console.WriteLine("!!!" + generalPage.GetUserEmail());
            ////////System.Threading.Thread.Sleep(10000);
            ////////var generalPage = new B2bGeneralPage(driver);
            ////////Console.WriteLine("!!!" + generalPage.GetUserEmail());

            ////////System.Threading.Thread.Sleep(10000);
            //var ngDriver = new NgWebDriver(driver);
            //var zzz = ngDriver.FindElement(By.CssSelector("[href*='my-account']")).Text;

            //Console.WriteLine("!" + zzz + "!");

            //ngDriver.Navigate().Refresh();

            //Console.WriteLine(1);
            //System.Threading.Thread.Sleep(30000);
            //wait.Until(wd => ngDriver.FindElement(By.ClassName("navbar-nav")));
            //System.Threading.Thread.Sleep(30000);

            //List<NgWebElement> menuList = ngDriver.FindElements(By.ClassName("menu-item-title")).ToList();
            //System.Threading.Thread.Sleep(30000);
            Console.WriteLine("aaaa");
            //foreach (var element in menuList)
            //{
            //    Console.WriteLine("!!!" + element.Text);
            //}
        }
    }
}
