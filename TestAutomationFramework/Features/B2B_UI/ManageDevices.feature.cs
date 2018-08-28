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
namespace TestAutomationFramework.Features.B2B_UI
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("B2B Manage Devices feature")]
    public partial class B2BManageDevicesFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ManageDevices.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "B2B Manage Devices feature", "\tIn order to verify Manage Devices feature functionality\r\n\twe run next scenarios", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ Manage Devices - Add Device(Incorrect Unit ID)")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageDevices_AddDeviceIncorrectUnitID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ Manage Devices - Add Device(Incorrect Unit ID)", new string[] {
                        "b2b",
                        "web"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ Manage Devices - Link device to Location")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageDevices_LinkDeviceToLocation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ Manage Devices - Link device to Location", new string[] {
                        "b2b",
                        "web"});
#line 30
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ Manage Devices - Unlink Device")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageDevices_UnlinkDevice()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ Manage Devices - Unlink Device", new string[] {
                        "b2b",
                        "web"});
#line 33
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ Manage Devices - Link device to Sublocation")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageDevices_LinkDeviceToSublocation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ Manage Devices - Link device to Sublocation", new string[] {
                        "b2b",
                        "web"});
#line 36
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ Manage Devices - Charging")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageDevices_Charging()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ Manage Devices - Charging", new string[] {
                        "b2b",
                        "web"});
#line 39
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ Manage devices - Reset ownership")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ManageDevices_ResetOwnership()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ Manage devices - Reset ownership", new string[] {
                        "b2b",
                        "web"});
#line 42
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
