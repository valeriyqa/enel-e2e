using JsonConfig;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2cUiGeneralSteps
    {
        private readonly RemoteWebDriver driver;
        public B2cUiGeneralSteps(RemoteWebDriver driver) => this.driver = driver;

        [Given(@"I navigate to the ""(.*)"" page \(b2c\)")]
        [Then(@"I navigate to the ""(.*)"" page \(b2c\)")]
        public void INavigateToThePageB2B(string pageName)
        {
            var generalPage = new B2cGeneralPage(driver);
            generalPage.ClickMenuByName(pageName);
            Assert.AreEqual(driver.Url, generalPage.GetAddressByMenuName(pageName));
        }

        //[Given(@"I click on the ""(.*)"" button \(b2b\)")]
        //[When(@"I click on the ""(.*)"" button \(b2b\)")]
        //public void IClickOnTheButtonB2b(string buttonName)
        //{
        //    var generalPage = new B2bGeneralPage(driver);
        //    generalPage.ClickButtonByName(buttonName);

        //}

        //[When(@"I set input ""(.*)"" to the value ""(.*)"" \(b2b\)")]
        //public void ISetInputToTheValueB2b(string inputName, string inputValue)
        //{
        //    var generalPage = new B2bGeneralPage(driver);
        //    generalPage.SetInputByName(inputName, inputValue);
        //}

        //[Then(@"Popup window with ""(.*)"" message and ""(.*)"" status should be displayed \(b2b\)")]
        //public void ThenPopupWindowWithMessageAndStatusShouldBeDisplayedBb(string messageText, string status)
        //{
        //    var generalPage = new B2bGeneralPage(driver);
        //    generalPage.AssertPopup(messageText, status);
        //}

        //[Given(@"Buagaga")]
        //public void GivenBuagaga()
        //{
        //    Console.WriteLine("Step1 - Start else");
        //    //var envVariables = Environment.GetEnvironmentVariables();
        //    //Console.WriteLine("Step2 - List all varibles");

        //    //foreach (var variable in envVariables)
        //    //{
        //    //    Console.WriteLine("Step2a - " + variable);
        //    //}

        //    //string jsonString = JsonConvert.SerializeObject(envVariables, Formatting.Indented);
        //    //Console.WriteLine("Step3 - Json string = " + jsonString);
        //    //ConfigObject configFromJson = Config.ApplyJson(jsonString);
        //    //Console.WriteLine("Step4 - Create Json Object");
        //    //Config.SetDefaultConfig(configFromJson);
        //    //Console.WriteLine("Step5 - Set config as default");
        //    Console.WriteLine("Step6 - Finish else");
        //}

    }
}
