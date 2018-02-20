#region

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static APITests.Globals.Constants;
using static APITests.Helpers.LogTraceListener;

#endregion

namespace APITests.StepDefinitions
{
    [Binding]
    public class SetupAndTeardownSteps
    {
        private static ExtentReports _extentReports;
        private static ExtentTest _extentTest;
        private static ExtentHtmlReporter _htmlReporter;

        [BeforeFeature]
        public static void InitializeReport()
        {
            _extentReports = new ExtentReports();

            _htmlReporter =
                new ExtentHtmlReporter(ReportingFolder + FeatureContext.Current.FeatureInfo.Title + ".html");

            _htmlReporter.Configuration().Theme = Theme.Dark;

            _extentReports.AttachReporter(_htmlReporter);

            FeatureContext.Current.Set(_extentReports);
        }

        [BeforeScenario]
        public static void InitializeReportTest()
        {
            _extentTest = FeatureContext.Current.Get<ExtentReports>()
                .CreateTest(ScenarioContext.Current.ScenarioInfo.Title);

            ScenarioContext.Current.Set(_extentTest);
        }

        [BeforeStep]
        public static void LogCurrentStep()
        {
            ScenarioContext.Current.Get<ExtentTest>().Info(LastGherkinMessage);
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

        [AfterFeature]
        public static void CreateReport()
        {
            FeatureContext.Current.Get<ExtentReports>().Flush();
            FeatureContext.Current.Clear();
        }
    }
}