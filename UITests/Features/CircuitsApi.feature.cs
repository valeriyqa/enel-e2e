#region Designer generated code

#region

using TechTalk.SpecFlow;

#endregion

#pragma warning disable
namespace UITests.Features
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CircuitsApi")]
    public partial class CircuitsApiFeature
    {
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }

        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }

        private TechTalk.SpecFlow.ITestRunner testRunner;

        [NUnit.Framework.OneTimeSetUp()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(
                new System.Globalization.CultureInfo("en-US"), "CircuitsApi",
                "\tIn order to impress my friends\r\n\tAs a Formula 1 fan\r\n\tI want to know the number " +
                "of races for a given Formula 1 season", ProgrammingLanguage.CSharp, ((string[]) (null)));
            testRunner.OnFeatureStart(featureInfo);
        }

        [NUnit.Framework.OneTimeTearDown()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }

        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }

        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check the number of races in a season")]
        [NUnit.Framework.CategoryAttribute("api")]
        [NUnit.Framework.TestCaseAttribute("2017", "20", new string[0])]
        [NUnit.Framework.TestCaseAttribute("2016", "21", new string[0])]
        [NUnit.Framework.TestCaseAttribute("1966", "9", new string[0])]
        [NUnit.Framework.TestCaseAttribute("1950", "8", new string[0])]
        public virtual void CheckTheNumberOfRacesInASeason(string season, string numberOfCircuits, string[] exampleTags)
        {
            string[] @__tags = new string[]
            {
                "api"
            };
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }

            TechTalk.SpecFlow.ScenarioInfo scenarioInfo =
                new TechTalk.SpecFlow.ScenarioInfo("Check the number of races in a season", @__tags);
#line 7
            this.ScenarioSetup(scenarioInfo);
#line 8
            testRunner.Given(string.Format("I want to know the number of Formula One races in {0}", season),
                ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Given ");
#line 9
            testRunner.When("I retrieve the circuit list for that season", ((string) (null)),
                ((TechTalk.SpecFlow.Table) (null)), "When ");
#line 10
            testRunner.Then(string.Format("there should be {0} circuits in the list returned", numberOfCircuits),
                ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore

#endregion