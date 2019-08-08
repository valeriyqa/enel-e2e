﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TestAutomationFramework.Features.B2B_UI
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("B2B Manage Users feature")]
    public partial class B2BManageUsersFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ManageUsers.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "B2B Manage Users feature", "\tIn order to verify Manage Users feature functionality\r\n\twe run next scenarios", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ManageUsers_01 - Add new user(Admin)")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageUsers_01_AddNewUserAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ManageUsers_01 - Add new user(Admin)", null, new string[] {
                        "b2b",
                        "web"});
#line 6
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ManageUsers_02 - Update User\'s information")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageUsers_02_UpdateUsersInformation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ManageUsers_02 - Update User\'s information", null, new string[] {
                        "b2b",
                        "web"});
#line 26
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ManageUsers_03 - Add new user(Incorrect Email)")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageUsers_03_AddNewUserIncorrectEmail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ManageUsers_03 - Add new user(Incorrect Email)", null, new string[] {
                        "b2b",
                        "web"});
#line 36
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 37
 testRunner.Given("I login to the system as \"Web user\" (b2b)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
 testRunner.When("I navigate to the \"Users\" page (b2b)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ManageUsers_04 - Add existing user")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageUsers_04_AddExistingUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ManageUsers_04 - Add existing user", null, new string[] {
                        "b2b",
                        "web"});
#line 48
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ManageUsers_05 - Assign/Remove user from group")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageUsers_05_AssignRemoveUserFromGroup()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ManageUsers_05 - Assign/Remove user from group", null, new string[] {
                        "b2b",
                        "web"});
#line 64
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ManageUsers_06 - Delete User")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageUsers_06_DeleteUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ManageUsers_06 - Delete User", null, new string[] {
                        "b2b",
                        "web"});
#line 79
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ManageUsers_07 - Charging sessions tab")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageUsers_07_ChargingSessionsTab()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ManageUsers_07 - Charging sessions tab", null, new string[] {
                        "b2b",
                        "web"});
#line 91
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

