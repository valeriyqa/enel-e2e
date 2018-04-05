using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;
using TechTalk.SpecFlow;
using static TestAutomationFramework.Tools.InitializeVariables;

namespace TestAutomationFramework
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        public static IDictionary globalVariables;
        public static IDictionary apiRequests;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void GetVariables()
        {
            globalVariables = LoadVariablesFromFile("environment.xlsx", "Variables", "Variable");
        }

        [BeforeScenario("api")]
        public void InitializeApi()
        {
            apiRequests = LoadVariablesFromFile("restApi.xlsx", "Requests", "Command");
        }

        [BeforeScenario("web")]
        public void InitializeWeb()
        {
            //_driver = new FirefoxDriver();
            _driver = new ChromeDriver(@"C:\chromedriver");
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario("web")]
        public void CleanUp()
        {
            //if (ScenarioContext.Current.TestError != null)
            //{
            //    WebBrowser.Driver.CaptureScreenShot(ScenarioContext.Current.ScenarioInfo.Title);
            //}
            _driver.Quit();
        }
    }
}
