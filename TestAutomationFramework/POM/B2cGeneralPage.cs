using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

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



    }
}
