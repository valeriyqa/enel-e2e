using OpenQA.Selenium;

namespace TestAutomationFramework.POM
{
    class B2bLoginPage
    {
        IWebElement LoginField => driver.FindElement(By.Id("username"));
        IWebElement PasswordField => driver.FindElement(By.Id("password"));
        IWebElement LoginButton => driver.FindElement(By.Id("login-submit"));

        private readonly IWebDriver driver;
        public B2bLoginPage(IWebDriver driver) => this.driver = driver;

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
