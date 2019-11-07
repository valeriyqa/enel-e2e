// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
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
#line 7
 testRunner.Given("I login to the system as \"WebUser\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I navigate to the \"My JuiceNet Devices\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.Then("JuiceNet device with key in config \"test2_unit_id\" should exist is \"True\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.Given("I login to the system as \"Admin\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.And("I navigate to the \"JuiceNet Device Lookup\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When("I set field \"inputUnitID\" to \"test2_unit_id\" from config (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.And("I click on related to the field with Id \"inputUnitID\" search button (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.Then("Info tab should contains unit with Id \"test2_unit_id\" from config file (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 17
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 18
 testRunner.Given("I login to the system as \"WebUser\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.And("I navigate to the \"My JuiceNet Devices\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.Then("JuiceNet device with key in config \"test3_unit_id\" should exist is \"True\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.When("I click More Details for device with key in config \"test3_unit_id\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.And("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Given("switch with Id \"toggleTOU\" is not activated (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.When("I click on switch with Id \"toggleTOU\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.And("I remeber the current time on device (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I set TOU time to \"current\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("I click on the Update button for pannel with Id \"panelTOU\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.Given("I login to the system as \"Admin\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.And("I navigate to the \"JuiceNet Device Lookup\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.When("I set field \"inputUnitID\" to \"test3_unit_id\" from config (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.And("I click on related to the field with Id \"inputUnitID\" search button (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.Then("Info tab should contains unit with Id \"test3_unit_id\" from config file (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.Then("TOU time on the Admin/JuiceNetDeviceLookup page should be equal to \"current\" (b2c" +
                    ")", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 36
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 37
 testRunner.Given("I login to the system as \"WebUser\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
 testRunner.And("I navigate to the \"My JuiceNet Devices\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.Then("JuiceNet device with key in config \"test3_unit_id\" should exist is \"True\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.Given("I login to the system as \"Admin\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.And("I navigate to the \"Manage Device Policies\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.When("I set field \"inputUnitID\" to \"test3_unit_id\" from config (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.And("I click on related to the field with Id \"inputUnitID\" search button (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.Given("related to Device ID policy set to \"Default\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.When("I click on button with name \"Set Green WT\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.Then("I should see related to Device ID policy \"Green WT\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.When("I navigate to the \"JuiceNet Device Lookup\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.And("I set field \"inputUnitID\" to \"test3_unit_id\" from config (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("I click on related to the field with Id \"inputUnitID\" search button (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.Then("Info tab should contains unit with Id \"test3_unit_id\" from config file (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.And("I should see Unit Policy \"Green Box\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.When("I navigate to the \"Manage Device Policies\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.And("I set field \"inputUnitID\" to \"test3_unit_id\" from config (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("I click on related to the field with Id \"inputUnitID\" search button (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.When("I click on button with name \"Default\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
 testRunner.Then("I should see related to Device ID policy \"Default\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 77
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 78
 testRunner.Given("JuiceNet device with key in config \"test1_unit_id\" is not added (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 79
 testRunner.And("I login to the system as \"Admin\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.When("I navigate to the \"User Lookup\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 81
 testRunner.And("I set field \"userInfoInput\" to \"web_user_email\" from config (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("I click on related to the field with Id \"userInfoInput\" search button (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And("I set field \"unitIDInput\" to \"test1_unit_id\" from config (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.When("I select \"Unit administrator\" on selector with Label \"Ownership Role\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
 testRunner.And("I click on button with Id \"addbox-button\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.Then("unit with key in config \"test1_unit_id\" exist in the UserDevices table is \"True\" " +
                    "(b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
 testRunner.Given("I login to the system as \"WebUser\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
 testRunner.And("I navigate to the \"My JuiceNet Devices\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.Then("JuiceNet device with key in config \"test1_unit_id\" should exist is \"True\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 93
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 94
 testRunner.Given("JuiceNet device with key in config \"test1_unit_id\" is added (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 95
 testRunner.Given("I login to the system as \"Admin\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 96
 testRunner.When("I navigate to the \"User Lookup\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 97
 testRunner.And("I set field \"userInfoInput\" to \"web_user_email\" from config (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("I click on related to the field with Id \"userInfoInput\" search button (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.Then("unit with key in config \"test1_unit_id\" exist in the UserDevices table is \"True\" " +
                    "(b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 100
 testRunner.When("I click remove button in the UserDevices table for unit with key in config \"test1" +
                    "_unit_id\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 101
 testRunner.Then("unit with key in config \"test1_unit_id\" exist in the UserDevices table is \"False\"" +
                    " (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
 testRunner.Given("I login to the system as \"WebUser\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 104
 testRunner.And("I navigate to the \"My JuiceNet Devices\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.Then("JuiceNet device with key in config \"test1_unit_id\" should exist is \"False\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 109
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 110
 testRunner.Given("I login to the system as \"Admin\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 111
 testRunner.When("I navigate to the \"User Lookup\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
 testRunner.And("I set field \"userInfoInput\" to \"web_user_email\" from config (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.And("I click on related to the field with Id \"userInfoInput\" search button (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.Given("the \"Admins\" button from User roles button activated is \"False\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 115
 testRunner.When("I activate User roles button \"Admins\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 117
 testRunner.Given("I login to the system as \"WebUser\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 118
 testRunner.And("I accept user agreement is needed (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.Then("item with name \"Admin Utilities\" in the navigation menu should exist is \"True\" (b" +
                    "2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
 testRunner.Then("item with name \"OCPP\" in the navigation menu should exist is \"True\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 122
 testRunner.Given("I login to the system as \"Admin\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 123
 testRunner.When("I navigate to the \"User Lookup\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
 testRunner.And("I set field \"userInfoInput\" to \"web_user_email\" from config (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.And("I click on related to the field with Id \"userInfoInput\" search button (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.When("I deactivate User roles button \"Admins\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 128
 testRunner.Given("I login to the system as \"WebUser\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 129
 testRunner.Then("item with name \"Admin Utilities\" in the navigation menu should exist is \"False\" (" +
                    "b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.Then("item with name \"OCPP\" in the navigation menu should exist is \"False\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 133
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 134
 testRunner.Given("I login to the system as \"Admin\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 135
 testRunner.When("I navigate to the \"Manage Roles\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 136
 testRunner.Given("role with name \"TestAutomationRole\" is not exist in the ListOfRoles table (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 137
 testRunner.When("I refresh page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 138
 testRunner.Then("role with name \"TestAutomationRole\" exist in the ListOfRoles table is \"False\" (b2" +
                    "c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 139
 testRunner.When("I set field with Id \"roleNameInput\" to \"TestAutomationRole\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 140
 testRunner.And("I click on button with name \"Add role\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 141
 testRunner.Then("role with name \"TestAutomationRole\" exist in the ListOfRoles table is \"True\" (b2c" +
                    ")", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 142
 testRunner.When("I click on the text \"TestAutomationRole\" in the table \"List of roles\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 143
 testRunner.Then("I wait until table with header \"List of permissions\" will be displayed (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "PermissionId"});
            table2.AddRow(new string[] {
                        "GetSharePin"});
            table2.AddRow(new string[] {
                        "SetChargingTime"});
            table2.AddRow(new string[] {
                        "SetNotifications"});
            table2.AddRow(new string[] {
                        "SetOverride"});
            table2.AddRow(new string[] {
                        "SetTOU"});
            table2.AddRow(new string[] {
                        "SetUnitCurrent"});
            table2.AddRow(new string[] {
                        "SetWireRating"});
            table2.AddRow(new string[] {
                        "ViewHistory"});
#line 144
 testRunner.When("I click on switch for permission with id \"<PermissionId>\" in the table ListOfPerm" +
                    "issions (b2c)", ((string)(null)), table2, "When ");
#line 154
 testRunner.Then("all permissions in the table ListOfPermissions should be activated is \"True\" (b2c" +
                    ")", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 158
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
#line 180
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
#line 202
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
#line 214
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
#line 231
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
