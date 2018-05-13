using BoDi;
using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;

namespace TestAutomationFramework
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private RemoteWebDriver driver;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void InitializeEnvironmentSettings()
        {
            string environment;
            try
            {
                environment = Environment.GetEnvironmentVariable("environment").ToLower();
            }
            catch (Exception)
            {
                environment = "prod";
            }
            string systemConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Configuration\", environment + ".conf");
            ConfigObject sConfig = Config.ApplyJsonFromFileInfo(new FileInfo(systemConfigPath));
            Config.SetDefaultConfig(sConfig);
        }

        [BeforeScenario("api")]
        public void InitializeApi()
        {
            if (!Config.Global.launcher.start_api)
            {
                Assert.Ignore();
            }
        }

        [BeforeScenario("udp")]
        public void InitializeUdp()
        {
            if (!Config.Global.launcher.start_udp)
            {
                Assert.Ignore();
            }
        }

        [BeforeScenario("web")]
        public void InitializeWeb()
        {
            if (Config.Global.launcher.start_web)
            {
                SelectBrowser(BrowserType.Chrome);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            else
            {
                Assert.Ignore();
            }
        }

        [AfterScenario("web")]
        public void CleanUp()
        {
            if (Config.Global.launcher.start_web)
            {
                driver.Quit();
            }
        }

        private void SelectBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    //options.AddArgument("--headless");
                    options.AddArguments("--start-maximized");
                    driver = new ChromeDriver(@"C:\chromedriver", options);
                    objectContainer.RegisterInstanceAs(driver);
                    break;
                case BrowserType.Firefox:
                    var driverDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    service.HideCommandPromptWindow = true;
                    service.SuppressInitialDiagnosticInformation = true;
                    driver = new FirefoxDriver(service);
                    objectContainer.RegisterInstanceAs(driver);
                    break;
                case BrowserType.Edge:
                    break;
                default:
                    break;
            }
        }

        enum BrowserType
        {
            Chrome,
            Firefox,
            Edge
        }
    }
}
