namespace JuiceBoxQA.UITests
{
    using OpenQA.Selenium;

    public class AuthorizationPage
    {
        IWebDriver drv;

        string DefaultUrl = "https://dashboard.emotorwerks.com/Account/Login";

        public IWebElement LoginField { get { return drv.FindElement(By.Id("Email")); } }
        public IWebElement PasswordField { get { return drv.FindElement(By.Id("Password")); } }
        public IWebElement SubmitButton { get { return drv.FindElement(By.XPath("//button[text()='Login']")); } }

        public AuthorizationPage(IWebDriver drv)
        {
            this.drv = drv;
        }

        public void Open()
        {
            Open(DefaultUrl);
        }

        public void Open(string url)
        {
            //Navigate to the site
            drv.Navigate().GoToUrl(url);
        }

        public void LoginAs(string email, string password)
        {
            Open();
            LoginField.SendKeys(email);
            PasswordField.SendKeys(password);
            SubmitButton.Submit();
        }
    }
}