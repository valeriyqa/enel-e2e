using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestAutomationFramework.POM
{
    class B2bLoginPage
    {
        private readonly RemoteWebDriver driver;
        public B2bLoginPage(RemoteWebDriver driver) => this.driver = driver;

        IWebElement userNameField => driver.FindElementById("username");
        IWebElement passwordField => driver.FindElementById("password");
        IWebElement loginButton => driver.FindElementById("login-submit");

        public void LoginToApplication(string userEmail, string userPassword)
        {
            userNameField.Clear();
            userNameField.SendKeys(userEmail);
            passwordField.Clear();
            passwordField.SendKeys(userPassword);
            loginButton.Submit();
        }

    }
}
