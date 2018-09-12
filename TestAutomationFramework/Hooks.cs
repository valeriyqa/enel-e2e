using BoDi;
using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;
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
            bool isLocal = File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", "taf_is_local.txt"));
            Console.WriteLine("!!!" + isLocal);

            if (isLocal)
            {
                //environment = "b2c_alpha";
                //environment = "b2c_beta";
                environment = "b2b_beta";
                //environment = "b2b_alpha";
            }
            else
            {
                environment = Environment.GetEnvironmentVariable("system_type").ToLower();
            }
            Console.WriteLine("!!!" + environment);

            string systemConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Configuration\", environment + ".conf");
            Console.WriteLine("!!!" + systemConfigPath);

            ConfigObject configFromFile = Config.ApplyJsonFromFileInfo(new FileInfo(systemConfigPath));
            Config.SetDefaultConfig(configFromFile);

            //if (!isLocal)
            //{
            //    var envVariablese = Environment.GetEnvironmentVariables();
            //    string jsonString = "{\"environment\": {\"dashboard_address\": \"" + envVariablese["dashboard_address"] +
            //        "\", \"api_address\": \"" + envVariablese["api_address"] + 
            //        "\", \"udp_address\": \"" + envVariablese["udp_address"] + 
            //        "\" }, \"launcher\": {\"start_web\": \"" + envVariablese["start_web"] + 
            //        "\", \"start_api\": \"" + envVariablese["start_api"] + 
            //        "\", \"start_udp\": \"" + envVariablese["start_udp"] + "\"}}";
            //    ConfigObject configFromJson = Config.ApplyJson(jsonString);
            //    Config.SetUserConfig(configFromJson);
            //}

            if (!isLocal)
            {
                var envVariablese = Environment.GetEnvironmentVariables();
                string jsonString = "{\"environment\": {\"dashboard_address\": \"" + Environment.GetEnvironmentVariable("dashboard_address").ToLower() +
                    "\", \"api_address\": \"" + Environment.GetEnvironmentVariable("api_address").ToLower() +
                    "\", \"udp_address\": \"" + Environment.GetEnvironmentVariable("udp_address").ToLower() +
                    "\" }, \"launcher\": {\"start_web\": \"" + Environment.GetEnvironmentVariable("start_web").ToLower() +
                    "\", \"start_api\": \"" + Environment.GetEnvironmentVariable("start_api").ToLower() +
                    "\", \"start_udp\": \"" + Environment.GetEnvironmentVariable("start_udp").ToLower() + "\"}}";
                ConfigObject configFromJson = Config.ApplyJson(jsonString);
                Config.SetUserConfig(configFromJson);
            }
        }

        [BeforeScenario("b2b")]
        public void InitializeB2B()
        {
            if (!Config.Global.environment.system_type.Contains("b2b"))
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("b2c")]
        public void InitializeB2C()
        {
            if (!Config.Global.environment.system_type.Contains("b2c"))
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("api")]
        public void InitializeApi()
        {
            if (!Boolean.Parse(Config.Global.launcher.start_api))
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("udp")]
        public void InitializeUdp()
        {
            if (!Boolean.Parse(Config.Global.launcher.start_udp))
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("web")]
        public void InitializeWeb()
        {
            if (Boolean.Parse(Config.Global.launcher.start_web))
            {
                SelectBrowser(BrowserType.Chrome);
                //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            else
            {
                Assert.Inconclusive();
            }
        }

        [AfterScenario("web")]
        public void CleanUp()
        {
            if (Boolean.Parse(Config.Global.launcher.start_web))
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
