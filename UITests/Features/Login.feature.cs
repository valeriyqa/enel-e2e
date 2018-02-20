#region

using System.CodeDom.Compiler;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace UITests.Features
{
    [GeneratedCode("TechTalk.SpecFlow", "2.1.0.0")]
    [CompilerGenerated]
    [TestFixture]
    [Description("Login")]
    public class Login
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

        public Login(ITestRunner testRunner)
        {
            _testRunner = testRunner;
        }

        [OneTimeSetUp]
        public void FeatureSetup()
        {
            _testRunner = TestRunnerManager.GetTestRunner();

            var featureInfo = new FeatureInfo(new CultureInfo("en-US"), "Login",
                "\tIn order to access restricted site options\r\n\tAs a registered JuiceNet user\r\n\tI w" +
                "ant to be able to log in", ProgrammingLanguage.CSharp, null);

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
        [Description("Login using incorrect password")]
        [Category("browser")]
        public void LoginUsingIncorrectPassword()
        {
            _testRunner.Given("I have a registered user John with username john and password demo", null,
                null, "Given ");

            _testRunner.And("he is on the JuiceNet home page", null, null,
                "And ");

            _testRunner.When("he logs in using an invalid password", null,
                null, "When ");

            _testRunner.Then("he should see an error message stating that the login request was denied",
                null, null, "Then ");

            ScenarioCleanup();
        }

        [Test]
        [Description("Login using valid credentials")]
        [Category("browser")]
        [TestCase("John", "alexander.burdeyniy@gmail.com", "Rjcvjc2020", new string[0])]
        public void LoginUsingValidCredentials(string firstname, string username, string password, string[] exampleTags)
        {
            var tags = new[] {"browser"};

            if (exampleTags != null) tags = tags.Concat(exampleTags).ToArray();
            var scenarioInfo = new ScenarioInfo("Login using valid credentials", tags);
#line 7
            ScenarioSetup(scenarioInfo);
#line 8
            _testRunner.Given(
                $"I have a registered user {firstname} with username {username} and password {password}", null, null,
                "Given ");
#line 9
            _testRunner.And("he is on the JuiceNet home page", null, null,
                "And ");
#line 10
            _testRunner.When("he logs in using his credentials", null, null,
                "When ");
#line 11
            _testRunner.Then("he should land on the Accounts Overview page", null,
                null, "Then ");
#line hidden
            ScenarioCleanup();
        }
    }
}