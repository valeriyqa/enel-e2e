using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestAutomationFramework.POM.Pages
{
    class GeneralPage
    {
        private readonly RemoteWebDriver driver;
        public GeneralPage(RemoteWebDriver driver) => this.driver = driver;

        IWebElement userNameButton => driver.FindElementByXPath("//*[@id='wrapper']/nav/ul/li[3]/a");

        public string GetUserName()
        {
            return userNameButton.Text.ToString();
        }



    }
}
