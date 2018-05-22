using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestAutomationFramework.POM
{
    class B2bGeneralPage
    {
        private readonly RemoteWebDriver driver;
        public B2bGeneralPage(RemoteWebDriver driver) => this.driver = driver;

        

        public string GetUserName()
        {
            IJavaScriptExecutor js = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Console.WriteLine("1");
            wait.Until(wd => js.ExecuteScript("return $('div.user-profile-btn')"));
            Console.WriteLine("2");
            var result =  js.ExecuteScript("return $('.user-profile-btn').click(); $('a[href$=\" / my - account\"]').textContent.trim();");
            Console.WriteLine("3");
            Console.WriteLine(result);
            return result.ToString();
        }



    }
}
