namespace JuiceBoxQA.UITests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;

    [TestClass]
    public partial class AuthorizationTests
    {
        private IWebDriver driver;
        private string login = "alexander.burdeyniy@gmail.com";
        private string password = "Rjcvjc2020";

        public TestContext TestContext { get; set; }

        [TestCleanup()]
        public void UITestCleanup()
        {
            driver.Quit();
        }

        [TestInitialize()]
        public void UITestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }


        [TestMethod]
        [TestCategory("Selenium")]

        public void CorrectLogin()
        {
            var loginPage = new EmotorwerksLoginPage(driver);

            loginPage.Open();
            loginPage.LoginAs(login, password);

            //Check that the Title is what we are expecting
            StringAssert.Contains("My JuiceNet Devices - EMotorWerks JuiceNet Device Control Room", driver.Title);
        }
    }
}