using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace TestAutomationFramework
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;

        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
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
