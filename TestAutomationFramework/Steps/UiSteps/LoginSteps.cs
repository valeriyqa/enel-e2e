using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestAutomationFramework.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver;
        private string address = Hooks.webHost;

        public LoginSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            Console.WriteLine("I navigate to application");
            _driver.Navigate().GoToUrl(address + "Account/Login");
        }

        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            Console.WriteLine("I enter username and password");
            dynamic data = table.CreateDynamicInstance();
            _driver.FindElement(By.Id("Email")).SendKeys((String)data.UserName);
            _driver.FindElement(By.Id("Password")).SendKeys((String)data.Password);
        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            Console.WriteLine("I click login");
            _driver.FindElement(By.ClassName("btn-primary")).Submit();
            Thread.Sleep(2000);
        }

        [Then(@"I should see user logged into the application")]
        public void ThenIShouldSeeUserLoggedIntoTheApplication()
        {
            Console.WriteLine("I should see used logged inmto the application");
            //var element = _driver.FindElement(By.XPath("(//a[contains(@href, '#')])[2][contains(text(), 'Alexander Burdeyniy')]"));
            //Assert.That(element.Text, Is.Not.Null, "Header text not found!!!");
        }
    }
}
