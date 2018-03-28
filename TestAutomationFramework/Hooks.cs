using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;
using static TestAutomationFramework.Tools.InitializeVariables;
using static TestAutomationFramework.Tools.LoadTableFromFile;



namespace TestAutomationFramework
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        public static IDictionary globalVariables;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void GetVariables()
        {
            globalVariables = LoadVariablesFromFile("environment.xlsx", "Variables", "Variable");
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
