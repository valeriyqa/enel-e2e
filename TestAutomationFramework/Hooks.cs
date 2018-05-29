using BoDi;
using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Protractor;
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
        //private NgWebDriver ngdriver;

        ////
        //private readonly ScenarioContext scenarioContext;
        //public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        //{
        //    this.objectContainer = objectContainer;
        //    this.scenarioContext = scenarioContext;
        //}

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
                //environment = "b2c_prod";
                //environment = "b2b_alpha";
                environment = "b2b_beta";
            }
            string systemConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Configuration\", environment + ".conf");
            ConfigObject sConfig = Config.ApplyJsonFromFileInfo(new FileInfo(systemConfigPath));
            Config.SetDefaultConfig(sConfig);
        }

        [BeforeScenario("b2b")]
        public void InitializeB2B()
        {
            if (!Config.Global.environment.system_type.Equals("b2b"))
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("b2c")]
        public void InitializeB2C()
        {
            if (!Config.Global.environment.system_type.Equals("b2c"))
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("api")]
        public void InitializeApi()
        {
            if (!Config.Global.launcher.start_api)
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("udp")]
        public void InitializeUdp()
        {
            if (!Config.Global.launcher.start_udp)
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("web")]
        public void InitializeWeb()
        {
            if (Config.Global.launcher.start_web)
            {
                SelectBrowser(BrowserType.Chrome);
                driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            else
            {
                Assert.Inconclusive();
            }
        }

        //[BeforeScenario("web")]
        //public void InitializeWeb()
        //{
        //    if (Config.Global.launcher.start_web)
        //    {
        //        SelectBrowser(BrowserType.Chrome);
        //        driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
        //        //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    }
        //    else
        //    {
        //        Assert.Inconclusive();
        //    }
        //}

        //[BeforeScenario("web")]
        //public void InitializeWeb()
        //{
        //    if (Config.Global.launcher.start_web && 
        //        Array.IndexOf(scenarioContext.ScenarioInfo.Tags, Config.Global.environment.system_type) > -1)
        //    {
        //        Console.WriteLine("start_web = " + Config.Global.launcher.start_web);
        //        Console.WriteLine("system_type = " + Config.Global.environment.system_type);
        //        Console.WriteLine(Array.IndexOf(scenarioContext.ScenarioInfo.Tags, Config.Global.environment.system_type));
        //        Console.WriteLine();
        //        SelectBrowser(BrowserType.Chrome);
        //        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    }
        //    else
        //    {
        //        //Assert.Ignore();
        //        Assert.Inconclusive();
        //    }
        //}

        [AfterScenario("web")]
        public void CleanUp()
        {
            if (Config.Global.launcher.start_web)
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                }

            }
        }

        private void SelectBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    //options.AddArgument("--headless");
                    //options.AddArguments("--user-data-dir=C:/Users/" + Environment.UserName + "/AppData/Local/Google/Chrome/User Data");
                    //options.AddArguments("--user-data-dir=/dev/null");
                    //options.AddArguments("--incognito switch");
                    options.AddArguments("--start-maximized");
                    driver = new ChromeDriver(@"C:\chromedriver", options);
                    objectContainer.RegisterInstanceAs(driver);
                    break;
                case BrowserType.Firefox:
                    var driverDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    //service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
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
