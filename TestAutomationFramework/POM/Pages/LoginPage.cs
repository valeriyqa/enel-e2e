using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestAutomationFramework.POM.Pages
{
    class LoginPage
    {
        private readonly RemoteWebDriver driver;
        public LoginPage(RemoteWebDriver driver) => this.driver = driver;

        IWebElement emailField => driver.FindElementById("Email");
        IWebElement passwordField => driver.FindElementByName("Password");
        IWebElement loginButton => driver.FindElementByClassName("btn-primary");

        public void LoginToApplication(string userEmail, string userPassword)
        {
            emailField.SendKeys(userEmail);
            passwordField.SendKeys(userPassword);
            loginButton.Submit();
        }

    }
}
