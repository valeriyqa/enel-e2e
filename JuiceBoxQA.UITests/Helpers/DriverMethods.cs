using System;
using JuiceBoxQA.UITests.Globals;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace JuiceBoxQA.UITests.Helpers
{
    public class DriverMethods
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Constants.PageLoadTimeout);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.DefaultTimeout);
            return driver;
        }
    }
}
