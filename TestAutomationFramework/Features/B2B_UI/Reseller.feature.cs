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
    [NUnit.Framework.DescriptionAttribute("B2B Reseller feature")]
    public partial class B2BResellerFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Reseller.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "B2B Reseller feature", "\tIn order to verify Reseller feature functionality\r\n\twe run next scenarios", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("B2B_Web_Reseller_01 Log in as a reseller (Positive)")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_Reseller_01LogInAsAResellerPositive()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_Reseller_01 Log in as a reseller (Positive)", null, new string[] {
                        "b2b",
                        "web"});
#line 6
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_Reseller_02 Log in as a reseller (Negative)")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_Reseller_02LogInAsAResellerNegative()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_Reseller_02 Log in as a reseller (Negative)", null, new string[] {
                        "b2b",
                        "web"});
#line 9
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_Reseller_03 Add New Client")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_Reseller_03AddNewClient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_Reseller_03 Add New Client", null, new string[] {
                        "b2b",
                        "web"});
#line 12
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_Reseller_04 Log in as a client")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_Reseller_04LogInAsAClient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_Reseller_04 Log in as a client", null, new string[] {
                        "b2b",
                        "web"});
#line 15
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_Reseller_05 Update client information")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_Reseller_05UpdateClientInformation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_Reseller_05 Update client information", null, new string[] {
                        "b2b",
                        "web"});
#line 18
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_WebReseller_06_ Reset password")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_WebReseller_06_ResetPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_WebReseller_06_ Reset password", null, new string[] {
                        "b2b",
                        "web"});
#line 21
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_Reseller_07 Logout")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_Reseller_07Logout()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_Reseller_07 Logout", null, new string[] {
                        "b2b",
                        "web"});
#line 24
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2B_Web_Reseller_08 Forgot password (login form)")]
        [NUnit.Framework.CategoryAttribute("b2b")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2B_Web_Reseller_08ForgotPasswordLoginForm()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2B_Web_Reseller_08 Forgot password (login form)", null, new string[] {
                        "b2b",
                        "web"});
#line 27
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

