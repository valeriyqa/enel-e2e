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
    [NUnit.Framework.DescriptionAttribute("Login")]
    public partial class LoginFeature
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
                new System.Globalization.CultureInfo("en-US"), "Login",
                "\tIn order to access restricted site options\r\n\tAs a registered JuiceNet user\r\n\tI w" +
                "ant to be able to log in", ProgrammingLanguage.CSharp, ((string[]) (null)));
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
        [NUnit.Framework.DescriptionAttribute("Login using incorrect password")]
        [NUnit.Framework.CategoryAttribute("browser")]
        public virtual void LoginUsingIncorrectPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo(
                "Login using incorrect password", new string[]
                {
                    "browser"
                });
#line 19
            this.ScenarioSetup(scenarioInfo);
#line 20
            testRunner.Given("I have a registered user John with username john and password demo", ((string) (null)),
                ((TechTalk.SpecFlow.Table) (null)), "Given ");
#line 21
            testRunner.And("he is on the JuiceNet home page", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)),
                "And ");
#line 22
            testRunner.When("he logs in using an invalid password", ((string) (null)),
                ((TechTalk.SpecFlow.Table) (null)), "When ");
#line 23
            testRunner.Then("he should see an error message stating that the login request was denied",
                ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Login using valid credentials")]
        [NUnit.Framework.CategoryAttribute("browser")]
        [NUnit.Framework.TestCaseAttribute("John", "alexander.burdeyniy@gmail.com", "Rjcvjc2020", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Bob", "parasoft", "demo", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Alex", "alex", "demo", new string[0])]
        public virtual void LoginUsingValidCredentials(string firstname, string username, string password,
            string[] exampleTags)
        {
            string[] @__tags = new string[]
            {
                "browser"
            };
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }

            TechTalk.SpecFlow.ScenarioInfo scenarioInfo =
                new TechTalk.SpecFlow.ScenarioInfo("Login using valid credentials", @__tags);
#line 7
            this.ScenarioSetup(scenarioInfo);
#line 8
            testRunner.Given(
                string.Format("I have a registered user {0} with username {1} and password {2}", firstname, username,
                    password), ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Given ");
#line 9
            testRunner.And("he is on the JuiceNet home page", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)),
                "And ");
#line 10
            testRunner.When("he logs in using his credentials", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)),
                "When ");
#line 11
            testRunner.Then("he should land on the Accounts Overview page", ((string) (null)),
                ((TechTalk.SpecFlow.Table) (null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore

#endregion