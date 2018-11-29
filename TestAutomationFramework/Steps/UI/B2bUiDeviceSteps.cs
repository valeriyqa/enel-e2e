using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2bUiDeviceSteps
    {
        private readonly RemoteWebDriver driver;
        public B2bUiDeviceSteps(RemoteWebDriver driver) => this.driver = driver;

        [Then(@"Tab ""(.*)"" should be selected \(b2b\)")]
        public void TabShouldBeSelectedB2b(string tabName)
        {
            //System.Threading.Thread.Sleep(5000);
            ////var attr = driver.FindElement(By.XPath("//[@class='mat-tab-label'][contains(text(),'" + tabName + "')]")).GetAttribute("aria-selected");
            //Assert.AreEqual(bool.Parse(attr), true);
        }

        [Then(@"Device with ID ""(.*)"" exist in the table is ""(.*)"" \(b2b\)")]
        public void DeviceWithIdExistInTheTableIsB2b(string numberId, string isExist)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
