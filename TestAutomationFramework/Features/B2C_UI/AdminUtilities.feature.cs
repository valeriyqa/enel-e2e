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
namespace TestAutomationFramework.Features.B2C_UI
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("B2C Admin Utilities feature")]
    public partial class B2CAdminUtilitiesFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AdminUtilities.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "B2C Admin Utilities feature", "\tIn order to verify Admin Utilities functionality\r\n\twe run next scenarios", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_01 - JuiceNet Device Lookup")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_01_JuiceNetDeviceLookup()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_01 - JuiceNet Device Lookup", null, new string[] {
                        "b2c",
                        "web"});
#line 6
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 8
 testRunner.Given("I login to the system as \"Oleksii\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I navigate to the \"My JuiceNet Devices\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.Then("JuiceNet device with Id \"373708002\" should exist is \"True\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
 testRunner.When("I click More Details for device with Id \"373708002\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("I save device \"373708002\" ID (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.Given("I navigate to \"Account/Login\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.When("I set field with Id \"Email\" to \"pavel.tsios@emotorwerks.com\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.And("I set field with Id \"Password\" to \"eMW2018\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I click on button with name \"Login\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.Given("I navigate to the \"Admin Utilities\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 testRunner.And("I navigate to the \"JuiceNet Device Lookup\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.When("I set field Id \"inputUnitID\" with shared data (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.And("I click on related to the field with Id \"inputUnitID\" search button (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.Then("I should see Unit Id \"373708002\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_02 - JuiceNet Device Lookup with active TOU")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_02_JuiceNetDeviceLookupWithActiveTOU()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_02 - JuiceNet Device Lookup with active TOU", null, new string[] {
                        "b2c",
                        "web"});
#line 28
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 30
 testRunner.Given("I login to the system as \"Oleksii\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
 testRunner.And("I navigate to the \"My JuiceNet Devices\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.Then("JuiceNet device with Id \"373709011\" should exist is \"True\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.When("I click More Details for device with Id \"373709011\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.Then("I save device \"373709011\" ID (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
 testRunner.And("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.Given("switch with Id \"toggleTOU\" is not activated (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.When("I click on swith with Id \"toggleTOU\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.Then("switch with Id \"toggleTOU\" should be enabled is \"True\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
 testRunner.And("I click on the Update button for pannel with Id \"panelTOU\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.When("I save Weekday Start time to shared data (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.And("I save Weekday End time to shared data (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.Given("I navigate to \"Account/Login\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.When("I set field with Id \"Email\" to \"pavel.tsios@emotorwerks.com\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
 testRunner.And("I set field with Id \"Password\" to \"eMW2018\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("I click on button with name \"Login\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.Given("I navigate to the \"Admin Utilities\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
 testRunner.And("I navigate to the \"JuiceNet Device Lookup\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.When("I set field Id \"inputUnitID\" with shared data (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
 testRunner.And("I click on related to the field with Id \"inputUnitID\" search button (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.Then("I should see Unit Id \"373709011\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
 testRunner.And("TOU Start time should be equal to shared data (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("TOU End time should be equal to shared data (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_03 - JuiceNet Device Lookup. Policy changes")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_03_JuiceNetDeviceLookup_PolicyChanges()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_03 - JuiceNet Device Lookup. Policy changes", null, new string[] {
                        "b2c",
                        "web"});
#line 56
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_04 - JuiceNet Device Lookup. Search by IP")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_04_JuiceNetDeviceLookup_SearchByIP()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_04 - JuiceNet Device Lookup. Search by IP", null, new string[] {
                        "b2c",
                        "web"});
#line 80
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_05 - Add Device from User Lookup page")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_05_AddDeviceFromUserLookupPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_05 - Add Device from User Lookup page", null, new string[] {
                        "b2c",
                        "web"});
#line 93
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_06 - Delete Device from User Lookup page")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_06_DeleteDeviceFromUserLookupPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_06 - Delete Device from User Lookup page", null, new string[] {
                        "b2c",
                        "web"});
#line 110
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_07 - Assign admin role to user")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_07_AssignAdminRoleToUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_07 - Assign admin role to user", null, new string[] {
                        "b2c",
                        "web"});
#line 123
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_08 - Add a new role")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_08_AddANewRole()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_08 - Add a new role", null, new string[] {
                        "b2c",
                        "web"});
#line 143
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_09 - Roles Management. All permissions off")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_09_RolesManagement_AllPermissionsOff()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_09 - Roles Management. All permissions off", null, new string[] {
                        "b2c",
                        "web"});
#line 155
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_10 - Roles Management. All permissions on")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_10_RolesManagement_AllPermissionsOn()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_10 - Roles Management. All permissions on", null, new string[] {
                        "b2c",
                        "web"});
#line 177
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_11 - Add Load Group")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_11_AddLoadGroup()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_11 - Add Load Group", null, new string[] {
                        "b2c",
                        "web"});
#line 199
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_12 - Add Devices to admin\'s Load Group")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_12_AddDevicesToAdminsLoadGroup()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_12 - Add Devices to admin\'s Load Group", null, new string[] {
                        "b2c",
                        "web"});
#line 211
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Admin_Utilities_13 - Delete Load Group with units in it")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Admin_Utilities_13_DeleteLoadGroupWithUnitsInIt()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Admin_Utilities_13 - Delete Load Group with units in it", null, new string[] {
                        "b2c",
                        "web"});
#line 228
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

