﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TestAutomationFramework.Features.B2C_API
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("API")]
    public partial class APIFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ApiTest.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "API", "\tIn order to test API functionality we run next scenarios", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
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
        [NUnit.Framework.DescriptionAttribute("B2C_API_ Basic test for requests without parameters")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("api")]
        [NUnit.Framework.TestCaseAttribute("get_car_models", null)]
        [NUnit.Framework.TestCaseAttribute("get_server_info", null)]
        [NUnit.Framework.TestCaseAttribute("get_timezones", null)]
        public virtual void B2C_API_BasicTestForRequestsWithoutParameters(string restAPI, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "b2c",
                    "api"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_API_ Basic test for requests without parameters", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.When(string.Format("I send \"{0}\" request", restAPI), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
 testRunner.Then("response should be valid to schema", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
 testRunner.And("property \"success\" should be equal to \"True\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_API_ Incorrect token test")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("api")]
        [NUnit.Framework.TestCaseAttribute("add_account_unit", null)]
        [NUnit.Framework.TestCaseAttribute("add_car", null)]
        [NUnit.Framework.TestCaseAttribute("delete_account_unit", null)]
        [NUnit.Framework.TestCaseAttribute("delete_car", null)]
        [NUnit.Framework.TestCaseAttribute("delete_program_signup_info", null)]
        [NUnit.Framework.TestCaseAttribute("get_history", null)]
        [NUnit.Framework.TestCaseAttribute("get_info", null)]
        [NUnit.Framework.TestCaseAttribute("get_notifications", null)]
        [NUnit.Framework.TestCaseAttribute("get_plot", null)]
        [NUnit.Framework.TestCaseAttribute("get_program_signup_info", null)]
        [NUnit.Framework.TestCaseAttribute("get_schedule", null)]
        [NUnit.Framework.TestCaseAttribute("get_share_pin", null)]
        [NUnit.Framework.TestCaseAttribute("get_state", null)]
        [NUnit.Framework.TestCaseAttribute("get_utilitybill_url", null)]
        [NUnit.Framework.TestCaseAttribute("select_car", null)]
        [NUnit.Framework.TestCaseAttribute("set_charging_time", null)]
        [NUnit.Framework.TestCaseAttribute("set_garage", null)]
        [NUnit.Framework.TestCaseAttribute("set_info", null)]
        [NUnit.Framework.TestCaseAttribute("set_limit", null)]
        [NUnit.Framework.TestCaseAttribute("set_notifications", null)]
        [NUnit.Framework.TestCaseAttribute("set_override", null)]
        [NUnit.Framework.TestCaseAttribute("set_program_signup_info", null)]
        [NUnit.Framework.TestCaseAttribute("set_schedule", null)]
        [NUnit.Framework.TestCaseAttribute("update_car", null)]
        public virtual void B2C_API_IncorrectTokenTest(string restAPI, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "b2c",
                    "api"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_API_ Incorrect token test", @__tags);
#line 70
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Value"});
            table1.AddRow(new string[] {
                        "token",
                        "incorrect_token"});
#line 71
 testRunner.When(string.Format("I send \"{0}\" request with next \"<Property>\" \"<Value>\"", restAPI), ((string)(null)), table1, "When ");
#line 74
 testRunner.Then("response should be valid to schema \"error\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
 testRunner.And("property \"success\" should be equal to \"False\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("property \"error_code\" should be equal to \"1007\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("property \"error_message\" should be equal to \"Invalid session token. Please reente" +
                    "r password.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_API_ Missing token test")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("api")]
        [NUnit.Framework.TestCaseAttribute("add_account_unit", null)]
        [NUnit.Framework.TestCaseAttribute("add_car", null)]
        [NUnit.Framework.TestCaseAttribute("delete_account_unit", null)]
        [NUnit.Framework.TestCaseAttribute("delete_car", null)]
        [NUnit.Framework.TestCaseAttribute("delete_program_signup_info", null)]
        [NUnit.Framework.TestCaseAttribute("get_history", null)]
        [NUnit.Framework.TestCaseAttribute("get_info", null)]
        [NUnit.Framework.TestCaseAttribute("get_notifications", null)]
        [NUnit.Framework.TestCaseAttribute("get_plot", null)]
        [NUnit.Framework.TestCaseAttribute("get_program_signup_info", null)]
        [NUnit.Framework.TestCaseAttribute("get_schedule", null)]
        [NUnit.Framework.TestCaseAttribute("get_share_pin", null)]
        [NUnit.Framework.TestCaseAttribute("get_state", null)]
        [NUnit.Framework.TestCaseAttribute("get_utilitybill_url", null)]
        [NUnit.Framework.TestCaseAttribute("select_car", null)]
        [NUnit.Framework.TestCaseAttribute("set_charging_time", null)]
        [NUnit.Framework.TestCaseAttribute("set_garage", null)]
        [NUnit.Framework.TestCaseAttribute("set_info", null)]
        [NUnit.Framework.TestCaseAttribute("set_limit", null)]
        [NUnit.Framework.TestCaseAttribute("set_notifications", null)]
        [NUnit.Framework.TestCaseAttribute("set_override", null)]
        [NUnit.Framework.TestCaseAttribute("set_program_signup_info", null)]
        [NUnit.Framework.TestCaseAttribute("set_schedule", null)]
        [NUnit.Framework.TestCaseAttribute("update_car", null)]
        public virtual void B2C_API_MissingTokenTest(string restAPI, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "b2c",
                    "api"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_API_ Missing token test", @__tags);
#line 106
this.ScenarioSetup(scenarioInfo);
#line 107
 testRunner.When(string.Format("I send \"{0}\" request with next \"token\" \"null\"", restAPI), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
 testRunner.Then("response should be valid to schema \"error\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
 testRunner.And("property \"success\" should be equal to \"False\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
 testRunner.And("property \"error_code\" should be equal to \"1007\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.And("property \"error_message\" should be equal to \"Invalid session token. Please reente" +
                    "r password.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_API_ Incorrect account token test")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("api")]
        [NUnit.Framework.TestCaseAttribute("add_unit", null)]
        [NUnit.Framework.TestCaseAttribute("get_account_units", null)]
        [NUnit.Framework.TestCaseAttribute("register_pushes", null)]
        public virtual void B2C_API_IncorrectAccountTokenTest(string restAPI, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "b2c",
                    "api"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_API_ Incorrect account token test", @__tags);
#line 140
this.ScenarioSetup(scenarioInfo);
#line 141
 testRunner.When(string.Format("I send \"{0}\" request with next \"account_token\" \"incorrect_token\"", restAPI), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 142
 testRunner.Then("response should be valid to schema \"error\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 143
 testRunner.And("property \"success\" should be equal to \"False\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 144
 testRunner.And("property \"error_code\" should be equal to \"1009\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 145
 testRunner.And("property \"error_message\" should be equal to \"User have not permissions to unit. C" +
                    "heck account token.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_API_ Missing account token test")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("api")]
        [NUnit.Framework.TestCaseAttribute("get_account_units", null)]
        [NUnit.Framework.TestCaseAttribute("register_pushes", null)]
        public virtual void B2C_API_MissingAccountTokenTest(string restAPI, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "b2c",
                    "api"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_API_ Missing account token test", @__tags);
#line 176
this.ScenarioSetup(scenarioInfo);
#line 177
 testRunner.When(string.Format("I send \"{0}\" request with next \"account_token\" \"null\"", restAPI), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 178
 testRunner.Then("response should be valid to schema \"error\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 179
 testRunner.And("property \"success\" should be equal to \"False\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
 testRunner.And("property \"error_code\" should be equal to \"1009\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 181
 testRunner.And("property \"error_message\" should be equal to \"Missing Account token\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_API_ Add/delete new unit to the system")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("api")]
        public virtual void B2C_API_AddDeleteNewUnitToTheSystem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_API_ Add/delete new unit to the system", new string[] {
                        "b2c",
                        "api"});
#line 212
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_API_ Add/delete car to the system")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("api")]
        public virtual void B2C_API_AddDeleteCarToTheSystem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_API_ Add/delete car to the system", new string[] {
                        "b2c",
                        "api"});
#line 215
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_API_ Add/delete Utility bill")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("api")]
        public virtual void B2C_API_AddDeleteUtilityBill()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_API_ Add/delete Utility bill", new string[] {
                        "b2c",
                        "api"});
#line 218
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_API_ Ownership operations")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("api")]
        public virtual void B2C_API_OwnershipOperations()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_API_ Ownership operations", new string[] {
                        "b2c",
                        "api"});
#line 221
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_API_ Share device operations")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("api")]
        public virtual void B2C_API_ShareDeviceOperations()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_API_ Share device operations", new string[] {
                        "b2c",
                        "api"});
#line 224
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_API_ Logout from the system")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("api")]
        public virtual void B2C_API_LogoutFromTheSystem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_API_ Logout from the system", new string[] {
                        "b2c",
                        "api"});
#line 227
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion