using OpenQA.Selenium;

namespace TestAutomationFramework.POM
{
    class B2bLocationPage
    {
        IWebElement TimeZoneSelect => driver.FindElement(By.Id("mat-select-0"));
        IWebElement AssignRateSelect => driver.FindElement(By.Id("mat-select-1"));
        IWebElement SameAsParentCheckbox => driver.FindElement(By.Id("mat-checkbox-1"));

        private readonly IWebDriver driver;
        public B2bLocationPage(IWebDriver driver) => this.driver = driver;

        public void ClickSameAsParentCheckbox()
        {
            SameAsParentCheckbox.Click();
        }

        public void SelectTimeZoneByValue(string value)
        {
            var generalPage = new B2bGeneralPage(driver);
            generalPage.SelectFromListByValue(TimeZoneSelect, value);
        }

        public void SelectAssignRateByValue(string value)
        {
            var generalPage = new B2bGeneralPage(driver);
            generalPage.SelectFromListByValue(AssignRateSelect, value);
        }
    }
}
