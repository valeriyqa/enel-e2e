using OpenQA.Selenium;
using Protractor;

namespace TestAutomationFramework.POM
{
    class B2bLoginPage
    {
        IWebElement LoginField => ngDriver.FindElement(NgBy.Model("model.username"));
        IWebElement PasswordField => ngDriver.FindElement(NgBy.Model("model.password"));
        IWebElement LoginButton => ngDriver.FindElement(By.Id("login-submit"));

        private readonly IWebDriver ngDriver;
        public B2bLoginPage(IWebDriver driver) => ngDriver = new NgWebDriver(driver);

        public void SetLoginField(string query)
        {
            LoginField.Clear();
            LoginField.SendKeys(query);
        }

        public void SetPasswordField(string query)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(query);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void SubmitLoginForm(string userEmail, string userPassword)
        {
            SetLoginField(userEmail);
            SetPasswordField(userPassword);
            ClickLoginButton();
        }
    }
}
