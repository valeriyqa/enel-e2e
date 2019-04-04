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
    [NUnit.Framework.DescriptionAttribute("B2C Registration And LogIn Operations")]
    public partial class B2CRegistrationAndLogInOperationsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RegistrationAndLogIn.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "B2C Registration And LogIn Operations", "\tIn order to verify Registration And LogIn functionality\r\n\twe run next scenarios", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Registration_and_Login_01 - Registration with email")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Registration_And_Login_01_RegistrationWithEmail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Registration_and_Login_01 - Registration with email", null, new string[] {
                        "b2c",
                        "web"});
#line 6
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 testRunner.Given("I navigate to \"Account/Login\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.When("I click on \"Register new user with email\" link (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("I should be navigated to the \"Account/Register\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "FieldId",
                        "Value"});
            table1.AddRow(new string[] {
                        "Email",
                        "example@example.com"});
            table1.AddRow(new string[] {
                        "pwdinpuit",
                        "Pa$$w0rd"});
            table1.AddRow(new string[] {
                        "ConfirmPassword",
                        "Pa$$w0rd"});
#line 10
 testRunner.When("I set field \"<FieldId>\" to \"<Value>\" (b2c)", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "FieldId"});
            table2.AddRow(new string[] {
                        "pwdinpuit"});
            table2.AddRow(new string[] {
                        "ConfirmPassword"});
#line 15
 testRunner.Then("field \"<FieldId>\" should be masked (b2c)", ((string)(null)), table2, "Then ");
#line 19
 testRunner.When("I set field \"Fullname\" to \"Vasia Pupkin\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.And("I confirm my email address (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Registration_and_Login_02 - Registration via Twitter account**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Registration_And_Login_02_RegistrationViaTwitterAccount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Registration_and_Login_02 - Registration via Twitter account**", null, new string[] {
                        "b2c",
                        "web"});
#line 44
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Registration_and_Login_03 - Registration via Facebook account**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Registration_And_Login_03_RegistrationViaFacebookAccount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Registration_and_Login_03 - Registration via Facebook account**", null, new string[] {
                        "b2c",
                        "web"});
#line 53
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Registration_and_Login_04 - Registration via Google account**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Registration_And_Login_04_RegistrationViaGoogleAccount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Registration_and_Login_04 - Registration via Google account**", null, new string[] {
                        "b2c",
                        "web"});
#line 62
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Registration_and_Login_05 - Login with valid email and password**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Registration_And_Login_05_LoginWithValidEmailAndPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Registration_and_Login_05 - Login with valid email and password**", null, new string[] {
                        "b2c",
                        "web"});
#line 71
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 77
 testRunner.Given("I login to the system as \"Web user\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 78
 testRunner.Then("I should be navigated to the \"Portal\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Registration_and_Login_06 - Login with unregistered email**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Registration_And_Login_06_LoginWithUnregisteredEmail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Registration_and_Login_06 - Login with unregistered email**", null, new string[] {
                        "b2c",
                        "web"});
#line 82
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 90
 testRunner.Given("I navigate to \"Account/Login\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 91
 testRunner.When("I set field with Id \"Email\" to \"891355577799@mail.ru\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
 testRunner.And("I set field with Id \"Password\" to \"0123456789\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.Then("field \"Password\" should be masked (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
 testRunner.When("I click on button with name \"Login\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
 testRunner.Then("Alert message \"Oops! Please double-check your email and password.\" is displayed (" +
                    "b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Registration_and_Login_07 - Login with invalid password**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Registration_And_Login_07_LoginWithInvalidPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Registration_and_Login_07 - Login with invalid password**", null, new string[] {
                        "b2c",
                        "web"});
#line 98
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 99
 testRunner.Given("I navigate to \"Account/Login\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "FieldId",
                        "Value"});
            table3.AddRow(new string[] {
                        "Email",
                        "oleksii.khabarov@emotorwerks.com"});
            table3.AddRow(new string[] {
                        "Password",
                        "invalidPassword"});
#line 100
 testRunner.When("I set field \"<FieldId>\" to \"<Value>\" (b2c)", ((string)(null)), table3, "When ");
#line 104
 testRunner.And("I click on button with name \"Login\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.Then("Alert message \"Oops! Please double-check your email and password.\" is displayed (" +
                    "b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Registration_and_Login_08 - Login with unconfirmed email**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Registration_And_Login_08_LoginWithUnconfirmedEmail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Registration_and_Login_08 - Login with unconfirmed email**", null, new string[] {
                        "b2c",
                        "web"});
#line 108
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Registration_and_Login_09 - Set password after registration via Social ac" +
            "count**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Registration_And_Login_09_SetPasswordAfterRegistrationViaSocialAccount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Registration_and_Login_09 - Set password after registration via Social ac" +
                    "count**", null, new string[] {
                        "b2c",
                        "web"});
#line 116
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Registration_and_Login_10 - User profile settings**")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Registration_And_Login_10_UserProfileSettings()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Registration_and_Login_10 - User profile settings**", null, new string[] {
                        "b2c",
                        "web"});
#line 128
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("B2C_Web_Registration_and_Login_11 - Login with invalid email")]
        [NUnit.Framework.CategoryAttribute("b2c")]
        [NUnit.Framework.CategoryAttribute("web")]
        public virtual void B2C_Web_Registration_And_Login_11_LoginWithInvalidEmail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("B2C_Web_Registration_and_Login_11 - Login with invalid email", null, new string[] {
                        "b2c",
                        "web"});
#line 144
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 152
 testRunner.Given("I navigate to \"Account/Login\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 153
 testRunner.When("I set field with Id \"Email\" to \"891355577799\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
#line 147
 testRunner.Given("I navigate to \"Account/Login\" page (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "FieldId",
                        "Value"});
            table5.AddRow(new string[] {
                        "Email",
                        "891355577799"});
            table5.AddRow(new string[] {
                        "Password",
                        "0123456789"});
#line 148
 testRunner.When("I set field \"<FieldId>\" to \"<Value>\" (b2c)", ((string)(null)), table5, "When ");
#line 152
 testRunner.Then("field \"Password\" should be masked (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 153
 testRunner.When("I click on button with name \"Login\" (b2c)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
 testRunner.Then("Error message \"The Email field is not a valid e-mail address.\" is displayed (b2c)" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

