using BoDi;
using JsonConfig;
using Newtonsoft.Json;
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
            if (File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", "taf_is_local.txt")))
            {
                //Use this variable to set local environment;
                //string environment = "b2b_beta2";
                //string environment = "b2c_prod";
                //string environment = "b2b_prod";
                //string environment = "b2b_alpha";
                //string environment = "b2c_alpha";
                //string environment = "joomla_beta";
                string environment = "b2c_v12alpha";
                //string environment = "b2c_v12beta";
                //string environment = "b2b_v12beta";
                //string environment = "b2c_beta";
                //string environment = "utility_ui_v12alpha";

                string systemConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Configuration\", environment + ".conf");
                ConfigObject configFromFile = Config.ApplyJsonFromFileInfo(new FileInfo(systemConfigPath));
                Config.SetDefaultConfig(configFromFile);
            }
            else
            {
                string systemType = Environment.GetEnvironmentVariable("env_system_type");
                string systemConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Configuration\", systemType + ".conf");
                ConfigObject configFromFile = Config.ApplyJsonFromFileInfo(new FileInfo(systemConfigPath));
                Config.SetDefaultConfig(configFromFile);

                string jsonString = "{";
                foreach (dynamic userData in Config.Global)
                {
                    jsonString += "\"" + userData.Key + "\": \"" + Environment.GetEnvironmentVariable(userData.Key) + "\", ";
                }

                jsonString = jsonString.Remove(jsonString.Length - 2);
                jsonString += "}";

                Config.Global.Clear();
                ConfigObject configFromJson = Config.ApplyJson(jsonString);
                Config.SetDefaultConfig(configFromJson);
            }
        }

        [BeforeScenario("utility_ui")]
        public void InitializeUtilityUI()
        {
            if (!Config.Global.env_system_type.Contains("utility_ui"))
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("b2b")]
        public void InitializeB2B()
        {
            if (!Config.Global.env_system_type.Contains("b2b"))
            {
                Assert.Inconclusive();
            }
        }

        //[BeforeScenario("energy")]
        //public void InitializeEnergy()
        //{
        //    if (!Config.Global.env_system_type.Contains("energy"))
        //    {
        //        Assert.Inconclusive();
        //    }
        //}

        [BeforeScenario("b2c")]
        public void InitializeB2C()
        {
            if (!Config.Global.env_system_type.Contains("b2c"))
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("api")]
        public void InitializeApi()
        {
            if (!Boolean.Parse(Config.Global.start_api))
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("udp")]
        public void InitializeUdp()
        {
            if (!Boolean.Parse(Config.Global.start_udp))
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("p_term")]
        public void InitializePaymentTerminal()
        {
            if (!Boolean.Parse(Config.Global.start_p_term))
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("joomla")]
        public void InitializeJoomla()
        {
            if (!Boolean.Parse(Config.Global.start_joomla))
            {
                Assert.Inconclusive();
            }
        }

        [BeforeScenario("web")]
        public void InitializeWeb()
        {
            if (Boolean.Parse(Config.Global.start_web))
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
            if (Boolean.Parse(Config.Global.start_web))
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
