﻿#region

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UITests.Globals;
using UITests.Helpers;

#endregion

namespace UITests.StepDefinitions
{
    [Binding]
    public class SetupAndTeardownSteps
    {
        private static ExtentReports _extentReports;
        private static ExtentHtmlReporter _htmlReporter;

        private static IWebDriver _driver;

        [BeforeFeature]
        public static void InitializeReport()
        {
            _extentReports = new ExtentReports();

            _htmlReporter =
                new ExtentHtmlReporter(Constants.ReportingFolder + FeatureContext.Current.FeatureInfo.Title + ".html");

            _htmlReporter.Configuration().Theme = Theme.Dark;

            _extentReports.AttachReporter(_htmlReporter);

            FeatureContext.Current.Set(_extentReports);
        }

        [BeforeScenario("browser")]
        public static void InitializeDriver()
        {
            _driver = DriverMethods.GetDriver();

            ScenarioContext.Current.Set(_driver);
        }

        [BeforeStep]
        public static void LogCurrentStep()
        {
            ScenarioContext.Current.Get<ExtentTest>().Info(LogTraceListener.LastGherkinMessage);
        }

        [AfterScenario]
        public static void WrapUpReport()
        {
            switch (TestContext.CurrentContext.Result.Outcome.Status.ToString().ToLower())
            {
                case "passed":
                    ScenarioContext.Current.Get<ExtentTest>().Pass("Scenario execution completed successfully");
                    break;
                case "failed":
                    ScenarioContext.Current.Get<ExtentTest>()
                        .Fail("One or more errors occurred during scenario execution");
                    break;
                case "inconclusive":
                    ScenarioContext.Current.Get<ExtentTest>()
                        .Warning("Unable to determine status of scenario execution");
                    break;
                case "skipped":
                    ScenarioContext.Current.Get<ExtentTest>().Skip("Skipped scenario execution");
                    break;
                default:
                    ScenarioContext.Current.Get<ExtentTest>()
                        .Error("Error occurred during determination of scenario status");
                    break;
            }

            ScenarioContext.Current.Clear();
        }

        [AfterScenario("browser")]
        public static void CloseBrowser()
        {
            _driver.Quit();
        }

        [AfterFeature]
        public static void CreateReport()
        {
            FeatureContext.Current.Get<ExtentReports>().Flush();
            FeatureContext.Current.Clear();
        }
    }
}