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
    [NUnit.Framework.DescriptionAttribute("B2B Allowed Current feature")]
    public partial class B2BAllowedCurrentFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AllowedCurrent.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "B2B Allowed Current feature", "\tIn order to verify Allowed Current feature functionality\r\n\twe run next scenarios" +
                    "", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ Change Allowed Current on device")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_ChangeAllowedCurrentOnDevice()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ Change Allowed Current on device", new string[] {
                        "b2b",
                        "web"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ Set Allowed Current for Location")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_SetAllowedCurrentForLocation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ Set Allowed Current for Location", new string[] {
                        "b2b",
                        "web"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ Same as Parent functionality when link device to Location")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_SameAsParentFunctionalityWhenLinkDeviceToLocation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ Same as Parent functionality when link device to Location", new string[] {
                        "b2b",
                        "web"});
#line 12
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ Same as Parent functionality for sublocation")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_SameAsParentFunctionalityForSublocation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ Same as Parent functionality for sublocation", new string[] {
                        "b2b",
                        "web"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_ Check the boarding value 6")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_CheckTheBoardingValue6()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_ Check the boarding value 6", new string[] {
                        "b2b",
                        "web"});
#line 18
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion