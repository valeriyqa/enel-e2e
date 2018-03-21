using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace TestAutomationFramework
{
    [Binding]
    public class Hooks
    {
        public static string apiHost;
        public static string udpHost;
        public static string webHost;

        private readonly IObjectContainer _objectContainer;

        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void GetVariables()
        {
            apiHost = Tools.InitializeVariables.GetFromEnvironment("apiHost");
            udpHost = Tools.InitializeVariables.GetFromEnvironment("udpHost");
            webHost = Tools.InitializeVariables.GetFromEnvironment("webHost");
        }

        [BeforeScenario("web")]
        public void Initialize()
        {
            //_driver = new FirefoxDriver();
            _driver = new ChromeDriver(@"C:\chromedriver");
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario("web")]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
