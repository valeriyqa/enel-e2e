using BoDi;
using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace TestAutomationFramework
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private IWebDriver driver;

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
                //driver = new FirefoxDriver();
                driver = new ChromeDriver(@"C:\chromedriver");
                objectContainer.RegisterInstanceAs<IWebDriver>(driver);
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
    }
}
