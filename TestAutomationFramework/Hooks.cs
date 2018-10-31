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
                string environment = "b2b_beta";
                //string environment = "b2c_alpha"; 

                string systemConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Configuration\", environment + ".conf");
                ConfigObject configFromFile = Config.ApplyJsonFromFileInfo(new FileInfo(systemConfigPath));
                Config.SetDefaultConfig(configFromFile);
            }
            else
            {
                //Console.WriteLine("Step1 - Start else");
                //var envVariables = Environment.GetEnvironmentVariables();
                //Console.WriteLine("Step2 - List all varibles");

                //foreach (var variable in envVariables)
                //{
                //    Console.WriteLine("Step2a - " + variable);
                //}

                //string jsonString = JsonConvert.SerializeObject(envVariables, Formatting.Indented);
                //Console.WriteLine("Step3 - Json string = " + jsonString);
                //ConfigObject configFromJson = Config.ApplyJson(jsonString);
                //Console.WriteLine("Step4 - Create Json Object");
                //Config.SetDefaultConfig(configFromJson);
                //Console.WriteLine("Step5 - Set config as default");
                //Console.WriteLine("Step6 - Finish else");
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
