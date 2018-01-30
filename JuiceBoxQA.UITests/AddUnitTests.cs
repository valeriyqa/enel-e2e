namespace JuiceBoxQA.UITests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;

    [TestClass]
    public class AddUnitTests
    {
        IWebDriver driver;
        MyJuiceNetDevicePage unitsPage;
        AddJuiceNetDevicePage addUnitsPage;

        string unitId = "0816000900000357503017082601";

        public TestContext TestContext { get; set; }

        [TestCleanup()]
        public void UITestCleanup()
        {
            driver.Quit();
        }

        [TestInitialize()]
        public void UITestInitialize()
        {
            string login = "alexander.burdeyniy@gmail.com";
            string password = "Rjcvjc2020";

            driver = new ChromeDriver();
            var loginPage = new AuthorizationPage(driver);
            unitsPage = new MyJuiceNetDevicePage(driver);
            addUnitsPage = new AddJuiceNetDevicePage(driver);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            loginPage.Open();
            loginPage.LoginAs(login, password);
        }


        [TestMethod]
        [TestCategory("Selenium")]

        public void UpdateUnitList()
        {
            unitsPage.Open();
            unitsPage.UpdateUnitList();

            //Check that the Title is what we are expecting
            StringAssert.Contains("My JuiceNet Devices - EMotorWerks JuiceNet Device Control Room", driver.Title);
        }

        [TestMethod]
        [TestCategory("Selenium")]

        public void AddDeviceByCircleButtonOnUnitsPage()
        {
            unitsPage.Open();
            unitsPage.AddUnitByCircleButton(unitId);

            //Check that the Danger Text is what we are expecting
            StringAssert.Contains(string.Format("Unit {0} was already added to your account", unitId), addUnitsPage.GetDangerText());
        }

        [TestMethod]
        [TestCategory("Selenium")]

        public void AddDeviceBySquareButtonOnUnitsPage()
        {
            unitsPage.Open();
            unitsPage.AddUnitBySquareButton(unitId);

            //Check that the Danger Text is what we are expecting
            StringAssert.Contains(string.Format("Unit {0} was already added to your account", unitId), addUnitsPage.GetDangerText());
        }

        [TestMethod]
        [TestCategory("Selenium")]

        public void AddDeviceFromAddUnitPage()
        {
            addUnitsPage.Open();
            addUnitsPage.AddUnit(unitId);

            //Check that the Danger Text is what we are expecting
            StringAssert.Contains(string.Format("Unit {0} was already added to your account", unitId), addUnitsPage.GetDangerText());
        }
    }
}