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
namespace TestAutomationFramework.Features.B2B_UDP
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("UdpTestForB2B")]
    public partial class UdpTestForB2BFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DirectUdpCommands.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UdpTestForB2B", "\tIn order to test UDP functionality\r\n\twe run next scenarios", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("B2B_UDP_ Test UDP and API First authorization")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("p_term")]
        public virtual void B2B_UDP_TestUDPAndAPIFirstAuthorization()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_UDP_ Test UDP and API First authorization", new string[] {
                        "b2b",
                        "p_term"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.When("I send UDP package with status \"Standby\" to unit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
 testRunner.Then("UDP response should contain \"A00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 9
 testRunner.When("I send authorization API request to terminal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("API response should be successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
 testRunner.Then("I wait till UDP package with status \"Connected\" returns amperage higher than \"00\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.When("I send UDP package with status \"Charging\" to unit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("UDP response should contain amperage higher than \"00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.When("I send UDP package with status \"Charging\" to unit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.Then("UDP response should contain amperage higher than \"00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.When("I send UDP package with status \"Charging\" to unit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("UDP response should contain amperage higher than \"00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
 testRunner.When("I send UDP package with status \"Charging\" to unit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("UDP response should contain amperage higher than \"00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.Then("I wait till UDP package with status \"Standby\" returns \"A00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.When("I verify device status via API request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.Then("property \"status\" should be \"finished\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.And("energy status should be valild", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_UDP_ Test UDP and API First plug")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("p_term")]
        public virtual void B2B_UDP_TestUDPAndAPIFirstPlug()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_UDP_ Test UDP and API First plug", new string[] {
                        "b2b",
                        "p_term"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.When("I send UDP package with status \"Standby\" to unit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("UDP response should contain \"A00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.When("I send UDP package with status \"Connected\" to unit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then("UDP response should contain \"A00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
 testRunner.When("I send authorization API request to terminal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.Then("API response should be successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.Then("I wait till UDP package with status \"Charging\" returns amperage higher than \"00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
 testRunner.When("I send UDP package with status \"Charging\" to unit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.Then("UDP response should contain amperage higher than \"00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
 testRunner.When("I send UDP package with status \"Charging\" to unit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("UDP response should contain amperage higher than \"00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.When("I send UDP package with status \"Charging\" to unit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("UDP response should contain amperage higher than \"00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.Then("I wait till UDP package with status \"Standby\" returns \"A00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
 testRunner.When("I verify device status via API request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("property \"status\" should be \"finished\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.And("energy status should be valild", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion