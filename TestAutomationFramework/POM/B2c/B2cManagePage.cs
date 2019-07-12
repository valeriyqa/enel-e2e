using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestAutomationFramework.POM.B2c
{
    class B2cManagePage
    {
        private readonly RemoteWebDriver driver;
        public B2cManagePage(RemoteWebDriver driver) => this.driver = driver;

        public string getUserDescription()
        {
            return driver.FindElement(By.XPath("//div[contains(@class, 'page-header')]//p[contains(@class, 'h4')]")).Text;

        }

        public string getUserEmail()
        {
            return driver.FindElement(By.XPath("//div[contains(@class, 'page-header')]//p[contains(@class, 'h5')]")).Text;

        }
    }
}
