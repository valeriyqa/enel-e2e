#region

using System.CodeDom.Compiler;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace APITests.Features
{
    [GeneratedCode("TechTalk.SpecFlow", "2.1.0.0")]
    [CompilerGenerated]
    [TestFixture]
    [Description("CircuitsApi")]
    public class CircuitsApi
    {
        [SetUp]
        public void TestInitialize()
        {
        }

        [TearDown]
        public void ScenarioTearDown()
        {
            _testRunner.OnScenarioEnd();
        }

        private ITestRunner _testRunner;

        public CircuitsApi(ITestRunner testRunner)
        {
            _testRunner = testRunner;
        }

        [OneTimeSetUp]
        public void FeatureSetup()
        {
            _testRunner = TestRunnerManager.GetTestRunner();

            var featureInfo = new FeatureInfo(
                new CultureInfo("en-US"), "CircuitsApi",
                "\tIn order to impress my friends\r\n\tAs a Formula 1 fan\r\n\tI want to know the number " +
                "of races for a given Formula 1 season", ProgrammingLanguage.CSharp, null);

            _testRunner.OnFeatureStart(featureInfo);
        }

        [OneTimeTearDown]
        public void FeatureTearDown()
        {
            _testRunner.OnFeatureEnd();
            _testRunner = null;
        }

        private void ScenarioSetup(ScenarioInfo scenarioInfo)
        {
            _testRunner.OnScenarioStart(scenarioInfo);
        }

        private void ScenarioCleanup()
        {
            _testRunner.CollectScenarioErrors();
        }

        [Test]
        [Description("Check the number of races in a season")]
        [Category("api")]
        public void CheckTheNumberOfRacesInASeason(string season, string numberOfCircuits, string[] exampleTags)
        {
            var tags = new[] {"api"};

            if (exampleTags != null) tags = tags.Concat(exampleTags).ToArray();
            var scenarioInfo = new ScenarioInfo("Check the number of races in a season", tags);

            ScenarioSetup(scenarioInfo);

            _testRunner.Given(
                $"I want to know the number of Formula One races in {season}"
                , null, null, "Given ");

            _testRunner.When(
                "I retrieve the circuit list for that season"
                , null, null, "When ");

            _testRunner.Then(
                $"there should be {numberOfCircuits} circuits in the list returned",
                null, null, "Then ");

            ScenarioCleanup();
        }
    }
}