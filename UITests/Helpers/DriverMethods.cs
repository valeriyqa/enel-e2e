#region

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

#endregion

namespace UITests.Helpers
{
    public class DriverMethods
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}