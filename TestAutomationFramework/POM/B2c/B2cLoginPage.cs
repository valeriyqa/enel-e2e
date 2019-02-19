using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestAutomationFramework.POM
{
    class B2cLoginPage
    {
        private readonly RemoteWebDriver driver;
        public B2cLoginPage(RemoteWebDriver driver) => this.driver = driver;

        IWebElement emailField => driver.FindElementById("Email");
        IWebElement passwordField => driver.FindElementByName("Password");
        IWebElement loginButton => driver.FindElementByClassName("btn-primary");

        public void LoginToApplication(string userEmail, string userPassword)
        {
            //emailField.Clear();
            emailField.SendKeys(userEmail);
            //passwordField.Clear();
            passwordField.SendKeys(userPassword);
            loginButton.Submit();
        }

    }
}
