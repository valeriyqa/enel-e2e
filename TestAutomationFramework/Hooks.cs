using BoDi;
using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
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
                environment = "alpha";
            }
            string systemConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Configuration\", environment + ".conf");
            ConfigObject sConfig = Config.ApplyJsonFromFileInfo(new FileInfo(systemConfigPath));
            Config.SetDefaultConfig(sConfig);

            string jsonConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Configuration\_requests.conf");
            ConfigObject jConfig = Config.ApplyJsonFromFileInfo(new FileInfo(jsonConfigPath));
            Config.SetUserConfig(jConfig);
        }

        [BeforeScenario("api")]
        public void InitializeApi()
        {
            if (Config.Global.launcher.skip_api)
            {
                Assert.Ignore();
            }
        }

        //[BeforeScenario("share")]
        //public void InitializeSharedToken()
        //{

        //}

        //[AfterScenario("share")]
        //public void CleanUpSharedToken()
        //{

        //}

        [BeforeScenario("udp")]
        public void InitializeUdp()
        {
            if (Config.Global.launcher.skip_udp)
            {
                Assert.Ignore();
            }
        }

        [BeforeScenario("web")]
        public void InitializeWeb()
        {
            if (Config.Global.launcher.skip_web)
            {
                Assert.Ignore();
            }
            else
            {
                //driver = new FirefoxDriver();
                driver = new ChromeDriver(@"C:\chromedriver");
                objectContainer.RegisterInstanceAs<IWebDriver>(driver);
            }
        }

        [AfterScenario("web")]
        public void CleanUp()
        {
            //if (!Config.Global.launcher.skip_web)
            //{
            //    driver.Quit();
            //}
        }
    }
}
