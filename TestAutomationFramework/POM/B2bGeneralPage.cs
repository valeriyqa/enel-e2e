using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;

namespace TestAutomationFramework.POM
{
    class B2bGeneralPage
    {
        IWebElement UserProfileButton => ngDriver.FindElement(By.ClassName("user-profile-btn"));
        //IWebElement UserEmail => ngDriver.FindElement(By.CssSelector("[href*='my-account']"));


        private readonly IWebDriver ngDriver;
        public B2bGeneralPage(IWebDriver driver) => ngDriver = driver;

        public string GetUserEmail()
        {
            UserProfileButton.Click();
            var result = ngDriver.FindElement(By.CssSelector("[href*='my-account']")).Text;
            UserProfileButton.Click();
            return result;
        }
        //public string GetUserName()
        //{
        //    Console.WriteLine("1");
        //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    Console.WriteLine("2");
        //    wait.Until(wd => userProfileButton.Displayed);
        //    Console.WriteLine("3");
        //    userProfileButton.Click();
        //    Console.WriteLine("4");
        //    var result = userAccountLink.Text;
        //    Console.WriteLine("5");
        //    Console.WriteLine(result);
        //    return result.ToString();
        //}



    }
}
