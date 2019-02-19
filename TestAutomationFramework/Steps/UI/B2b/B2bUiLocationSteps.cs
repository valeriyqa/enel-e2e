using NUnit.Framework;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    class B2bUiLocationSteps
    {
        private readonly RemoteWebDriver driver;
        public B2bUiLocationSteps(RemoteWebDriver driver) => this.driver = driver;

        [When(@"I click the Same as parent checkbox \(b2b\)")]
        public void IClickTheSameAsParentCheckboxB2b()
        {
            var locationPage = new B2bLocationPage(driver);
            locationPage.ClickSameAsParentCheckbox();
        }

        [When(@"I select ""(.*)"" on the Time zone selector \(b2b\)")]
        public void ISelectOnTheTimeZoneSelectorB2b(string value)
        {
            var locationPage = new B2bLocationPage(driver);
            locationPage.SelectTimeZoneByValue(value);
        }

        [When(@"I select ""(.*)"" on the Assign rate selector \(b2b\)")]
        public void ISelectOnTheAssignRateSelectorB2b(string value)
        {
            var locationPage = new B2bLocationPage(driver);
            locationPage.SelectAssignRateByValue(value);
        }

        [When(@"I populate the Location form with correct data \(b2b\)")]
        public void IPopulateTheLocationFormWithCorrectDataB2b()
        {
            var locationPage = new B2bLocationPage(driver);
            //locationPage.ClickSameAsParentCheckbox();

            var generalPage = new B2bGeneralPage(driver);
            generalPage.ClickCheckboxByNameInRow("Same as parent", "Address");
            generalPage.SetInputByName("name", "Test Location");
            generalPage.SetInputByName("address", "Test Address", true);
            generalPage.SetInputByName("city", "Test City", true);
            generalPage.SetInputByName("state", "Test State", true);
            generalPage.SetInputByName("zip", "123456", true);
            locationPage.SelectTimeZoneByValue("(UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius");
        }

        [When(@"I populate the Location form with correct data and ""(.*)"" title \(b2b\)")]
        public void WhenIPopulateTheLocationFormWithCorrectDataAndTitleBb(string name)
        {
            var locationPage = new B2bLocationPage(driver);
            //locationPage.ClickSameAsParentCheckbox();

            var generalPage = new B2bGeneralPage(driver);
            generalPage.ClickCheckboxByNameInRow("Same as parent", "Address");
            generalPage.SetInputByName("name", name);
            generalPage.SetInputByName("address", "Test Address", true);
            generalPage.SetInputByName("city", "Test City", true);
            generalPage.SetInputByName("state", "Test State", true);
            generalPage.SetInputByName("zip", "123456", true);
            locationPage.SelectTimeZoneByValue("(UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius");
        }


        [Then(@"Location with name ""(.*)"" exist in the table is ""(.*)"" \(b2b\)")]
        public void ThenLocationWithNameExistInTheTableIsB2b(string locationName, string shouldExist)
        {
            var locationPage = new B2bLocationPage(driver);
            Assert.AreEqual(locationPage.IsLocationExist(locationName), bool.Parse(shouldExist));
        }

        [Then(@"Location with name ""(.*)"" is parent for ""(.*)"" \(b2b\)")]
        public void ThenLocationWithNameIsParentForB2b(string location, string subLocation)
        {
            var locationPage = new B2bLocationPage(driver);
            Assert.IsTrue(locationPage.IsParentForLocation(location, subLocation));
        }


        [Given(@"I delete location ""(.*)"" if exist \(b2b\)")]
        public void GivenIDeleteLocationIfExistBb(string locationName)
        {
            var locationPage = new B2bLocationPage(driver);
            var generalPage = new B2bGeneralPage(driver);
            if (locationPage.IsLocationExist(locationName))
            {
                System.Console.WriteLine("exist");
                locationPage.ClickLocationLinkByName(locationName); 
                generalPage.ClickButtonByName("Delete Location");
                generalPage.ClickButtonByName("Remove");
            }
        }

        [When(@"I click ""(.*)"" checkbox in row ""(.*)"" \(b2b\)")]
        public void WhenIClickCheckboxInRowBb(string checkboxName, string rowName)
        {
            var generalPage = new B2bGeneralPage(driver);
            generalPage.ClickCheckboxByNameInRow(checkboxName, rowName);
        }

    }
}
