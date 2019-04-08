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
    [NUnit.Framework.DescriptionAttribute("B2C MyJuiceNet")]
    public partial class B2CMyJuiceNetFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "MyJuiceNet.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "B2C MyJuiceNet", "\tIn order to verify JuiceNet functionality\r\n\twe run next scenarios", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_01 - Add/Delete JuiceNet Device")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_01_AddDeleteJuiceNetDevice()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_01 - Add/Delete JuiceNet Device", "\tNote! We collect add and delete scenarios together to avoid parallel execution c" +
                    "ollision,\r\n\twhen separate scenarios may perform mutually exclusive actions.", new string[] {
                        "b2c",
                        "web"});
#line 6
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 10
 testRunner.Given("JuiceNet device is not added (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.And("I login to the system as \"Oleksii\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When("I click on button with name \"Add JuiceNet Device\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.And("I set field \"inputUnitID\" to \"373708002\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I click on button with name \"Add JuiceNet Device\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("I click on \"Browse My JuiceNet Devices\" link (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.Then("JuiceNet device with Id \"373708002\" should exist is \"True\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
 testRunner.When("I click More Details for device with Id \"373708002\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.And("I click on button with name \"Delete\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("I click on button with name \"Yes, remove from my account\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.Then("JuiceNet device with Id \"373708002\" should exist is \"False\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_02 - JuiceNet Device Status")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_02_JuiceNetDeviceStatus()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_02 - JuiceNet Device Status", null, new string[] {
                        "b2c",
                        "web"});
#line 23
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 24
 testRunner.Given("I login to the system as \"Oleksii\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
 testRunner.When("I click More Details for device with Id \"373709011\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.Then("field with Label \"Allowed Current\" should be equal to \"60\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
 testRunner.And("field with Label \"Charging Limit\" should be equal to \"0\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.Given("all checkboxes on panel with Id \"panelNotify\" is not activated (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.When("I click all checkboxes on panel with Id \"panelNotify\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.When("I click on button with Id \"saveNotificationsButton\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.Then("all checkboxes on panel with Id \"panelNotify\" should be activated (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_03 - JuiceNet Device History")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_03_JuiceNetDeviceHistory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_03 - JuiceNet Device History", null, new string[] {
                        "b2c",
                        "web"});
#line 34
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 35
 testRunner.Given("I login to the system as \"Oleksii\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
 testRunner.When("I click More Details for device with Id \"373709012\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.And("I click on tab with label \"History\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.When("I get data from table with Id \"usagetable\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("table should be empty (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_04 - JuiceNet Device states on dashboard")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_04_JuiceNetDeviceStatesOnDashboard()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_04 - JuiceNet Device states on dashboard", null, new string[] {
                        "b2c",
                        "web"});
#line 42
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 43
 testRunner.Given("I login to the system as \"Oleksii\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.When("I send UDP package with status \"Standby\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
 testRunner.Then("panel color for device with Id \"373709011\" should be changed to \"primary\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
 testRunner.And("device with Id \"373709011\" should have status \"Standby\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I send UDP package with status \"Connected\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.Then("panel color for device with Id \"373709011\" should be changed to \"green\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
 testRunner.And("device with Id \"373709011\" should have status \"Plugged in\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.When("I remember charging and saving values for device with Id \"373709011\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
 testRunner.And("I send UDP package with status \"Charging\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.Then("panel color for device with Id \"373709011\" should be changed to \"yellow\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
 testRunner.And("device with Id \"373709011\" should have status \"Charging\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("energy and savings for device with Id \"373709011\" should grow (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.Then("I send UDP package with status \"Standby\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_05 - JuiceNet Device Settings and Savings Parameters")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_05_JuiceNetDeviceSettingsAndSavingsParameters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_05 - JuiceNet Device Settings and Savings Parameters", null, new string[] {
                        "b2c",
                        "web"});
#line 58
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 59
 testRunner.Given("I login to the system as \"Oleksii\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 60
 testRunner.When("I click More Details for device with Id \"373709011\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
 testRunner.And("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.When("I populate the JuiceNet Device Settings form with \"initial_JDS\" data (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
 testRunner.And("I click on the Update button for pannel with Id \"panelSettings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.Then("JuiceNet Device Settings form fields values should be equal to \"initial_JDS\" data" +
                    " (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
 testRunner.When("I populate the JuiceNet Device Settings form with \"updated_JDS\" data (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.And("I click on the Update button for pannel with Id \"panelSettings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.Then("JuiceNet Device Settings form fields values should be equal to \"updated_JDS\" data" +
                    " (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_06 - JuiceNet Device Settings. Empty Zip code")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_06_JuiceNetDeviceSettings_EmptyZipCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_06 - JuiceNet Device Settings. Empty Zip code", null, new string[] {
                        "b2c",
                        "web"});
#line 70
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 71
 testRunner.Given("I login to the system as \"Oleksii\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.When("I click More Details for device with Id \"373709011\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
 testRunner.And("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.When("I populate the JuiceNet Device Settings form with \"initial_JDS\" data (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
 testRunner.And("I click on the Update button for pannel with Id \"panelSettings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.Then("JuiceNet Device Settings form fields values should be equal to \"initial_JDS\" data" +
                    " (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
 testRunner.When("I populate the JuiceNet Device Settings form with \"nozip_JDS\" data (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.And("I click on the Update button for pannel with Id \"panelSettings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.Then("Error message \"The Zip code field is required.\" is displayed (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
 testRunner.When("I refresh page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 81
 testRunner.And("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.Then("JuiceNet Device Settings form fields values should be equal to \"initial_JDS\" data" +
                    " (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_07 - Time-of-Use (TOU)")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_07_Time_Of_UseTOU()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_07 - Time-of-Use (TOU)", null, new string[] {
                        "b2c",
                        "web"});
#line 85
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 86
 testRunner.Given("I login to the system as \"Oleksii\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 87
 testRunner.When("I click More Details for device with Id \"373709011\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
 testRunner.And("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.Given("switch with Id \"toggleTOU\" is not activated (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.And("field with Id \"MinChargeKWh\" is equal to \"0.0\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.When("I click on swith with Id \"toggleTOU\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
 testRunner.Then("switch with Id \"toggleTOU\" should be enabled is \"True\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
 testRunner.When("I remeber the current time on device (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
 testRunner.And("I set TOU time to \"not current\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And("I click on the Update button for pannel with Id \"panelTOU\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("I refresh page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.Then("TOU time should be equal to \"not current\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
 testRunner.When("I click on tab with label \"Status\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.And("I send UDP package with status \"Standby\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.Then("UDP response should contain \"A00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
 testRunner.And("panel with Id \"panelStatus\" should change color to \"primary\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.When("I send UDP package with status \"Connected\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
 testRunner.Then("UDP response should contain \"A00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
 testRunner.Then("panel with Id \"panelStatus\" should change color to \"green\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 106
 testRunner.When("I click on swith with Id \"overrideCheckBox\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
 testRunner.And("I send UDP package with status \"Connected\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.Then("UDP response should contain amperage higher than \"00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
 testRunner.Then("I send UDP package with status \"Charging\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
 testRunner.And("panel with Id \"panelStatus\" should change color to \"yellow\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.When("I click on swith with Id \"overrideCheckBox\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
 testRunner.And("I send UDP package with status \"Connected\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.Then("UDP response should contain \"A00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
 testRunner.Then("I send UDP package with status \"Connected\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 115
 testRunner.And("panel with Id \"panelStatus\" should change color to \"green\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.When("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 117
 testRunner.And("I set TOU time to \"current\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.And("I click on the Update button for pannel with Id \"panelTOU\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.And("I click on tab with label \"Status\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.And("I send UDP package with status \"Connected\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.Then("UDP response should contain amperage higher than \"00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 122
 testRunner.Then("I send UDP package with status \"Charging\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 123
 testRunner.And("panel with Id \"panelStatus\" should change color to \"yellow\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.When("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 125
 testRunner.And("I click on swith with Id \"toggleTOU\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.And("I click on the Update button for pannel with Id \"panelTOU\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.Then("switch with Id \"toggleTOU\" should be enabled is \"False\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
 testRunner.And("I send UDP package with status \"Standby\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_08 - TOU Persistence")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_08_TOUPersistence()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_08 - TOU Persistence", null, new string[] {
                        "b2c",
                        "web"});
#line 131
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_09 - Minimal charge. Charging starts before TOU start time.")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_09_MinimalCharge_ChargingStartsBeforeTOUStartTime_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_09 - Minimal charge. Charging starts before TOU start time.", null, new string[] {
                        "b2c",
                        "web"});
#line 169
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 170
 testRunner.Given("I login to the system as \"Oleksii\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 171
 testRunner.When("I click More Details for device with Id \"373709011\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 172
 testRunner.And("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 173
 testRunner.Given("switch with Id \"toggleTOU\" is not activated (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 174
 testRunner.And("field with Id \"MinChargeKWh\" is equal to \"0.0\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 175
 testRunner.When("I set field \"MinChargeKWh\" to \"10\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 176
 testRunner.And("I click on swith with Id \"toggleTOU\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 177
 testRunner.Then("switch with Id \"toggleTOU\" should be enabled is \"True\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 178
 testRunner.When("I remeber the current time on device (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 179
 testRunner.And("I set TOU time to \"not current\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
 testRunner.And("I click on the Update button for pannel with Id \"panelTOU\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 181
 testRunner.And("I refresh page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 182
 testRunner.And("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 183
 testRunner.Then("TOU time should be equal to \"not current\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 184
 testRunner.When("I click on tab with label \"Status\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 185
 testRunner.When("I send UDP package with status \"Connected\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 186
 testRunner.Then("UDP response should contain amperage higher than \"00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 187
 testRunner.Then("I send UDP package with status \"Charging\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 188
 testRunner.And("panel with Id \"panelStatus\" should change color to \"yellow\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 189
 testRunner.When("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 190
 testRunner.And("I set field \"MinChargeKWh\" to \"0.0\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
 testRunner.And("I click on the Update button for pannel with Id \"panelTOU\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
 testRunner.And("I refresh page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
 testRunner.And("I click on tab with label \"Settings\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 194
 testRunner.Then("field with Id \"MinChargeKWh\" should be equal to \"0.0\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 195
 testRunner.When("I click on tab with label \"Status\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 196
 testRunner.And("I send UDP package with status \"Connected\" to unit \"373709011\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 197
 testRunner.Then("UDP response should contain \"A00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 198
 testRunner.And("panel with Id \"panelStatus\" should change color to \"green\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_11 - Minimal charge. Charging continues after TOU end time.**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_11_MinimalCharge_ChargingContinuesAfterTOUEndTime_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_11 - Minimal charge. Charging continues after TOU end time.**", null, new string[] {
                        "b2c",
                        "web"});
#line 202
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_12 - EVSE Efficiency**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_12_EVSEEfficiency()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_12 - EVSE Efficiency**", null, new string[] {
                        "b2c",
                        "web"});
#line 232
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_13 - Add empty Load groups.**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_13_AddEmptyLoadGroups_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_13 - Add empty Load groups.**", null, new string[] {
                        "b2c",
                        "web"});
#line 251
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 252
 testRunner.Given("I login to the system as \"Oleksii\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 253
 testRunner.And("I navigate to the \"Load groups\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 254
 testRunner.And("load group table is empty (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 255
 testRunner.When("I click on button with name \"New Load Group\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 256
 testRunner.And("I set field with Id \"lg-add-modal-group-name\" to \"TestGroup1\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 257
 testRunner.And("I click on button with name \"Save changes\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 258
 testRunner.Then("Alert with status \"success\" and text \"Load Group TestGroup1 created sucessfully\" " +
                    "should be displayed (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 259
 testRunner.When("I click on button with name \"Close\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 260
 testRunner.Then("Load group with name \"TestGroup1\" should apear in the table is \"true\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 261
 testRunner.When("I click on button with name \"New Load Group\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 262
 testRunner.And("I set field with Id \"lg-add-modal-group-name\" to \"TestGroup2\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 263
 testRunner.And("I click on button with name \"Save changes\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 264
 testRunner.Then("Alert with status \"danger\" and text \"User already has one empty load group\" shoul" +
                    "d be displayed (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 265
 testRunner.When("I click on button with name \"Close\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 266
 testRunner.Then("Load group with name \"TestGroup2\" should apear in the table is \"false\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 267
 testRunner.When("I click on button with name \"Edit\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 268
 testRunner.And("I set field with Id \"lg-add-modal-group-name\" to \"TestGroup2\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 269
 testRunner.And("I set field with Id \"lg-add-modal-max-current\" to \"5\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 270
 testRunner.And("I click on button with name \"Save changes\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 271
 testRunner.Then("Alert with status \"success\" and text \"Load Group TestGroup2 modified successfully" +
                    "\" should be displayed (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 272
 testRunner.When("I click on button with name \"Close\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 273
 testRunner.Then("Load group with name \"TestGroup2\" should apear in the table is \"true\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 275
 testRunner.When("I click on button with name \"Delete\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 276
 testRunner.Then("Alert with status \"danger\" and text \"Are you sure you want delete the group TestG" +
                    "roup2\" should be displayed (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 277
 testRunner.When("I click on button with name \"Delete LoadGroup\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 278
 testRunner.And("I click on button with name \"Close\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 279
 testRunner.Then("Load group table should be empty (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_14 - Add devices to Load group.**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_14_AddDevicesToLoadGroup_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_14 - Add devices to Load group.**", null, new string[] {
                        "b2c",
                        "web"});
#line 282
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_15 - Notifications**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_15_Notifications()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_15 - Notifications**", null, new string[] {
                        "b2c",
                        "web"});
#line 302
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_MyJuiceNet_16 - SW corrections**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_MyJuiceNet_16_SWCorrections()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_MyJuiceNet_16 - SW corrections**", null, new string[] {
                        "b2c",
                        "web"});
#line 313
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

