using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TestAutomationFramework.POM
{
    class B2bLocationPage
    {
        //delete it
        //IWebElement TimeZoneSelect => driver.FindElement(By.Id("mat-select-0"));
        IWebElement TimeZoneSelect => driver.FindElement(By.XPath("//label[contains(text(), 'Time zone')]/../..//mat-select"));
        IWebElement AssignRateSelect => driver.FindElement(By.Id("mat-select-1"));
        IWebElement SameAsParentCheckbox => driver.FindElement(By.Id("mat-checkbox-1"));
        IWebElement LocationsTable => driver.FindElement(By.ClassName("ui-treetable.ui-widget"));

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

        public void ClickLocationLinkByName(string locationName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(wd => driver.FindElement(By.ClassName("ng-star-inserted")).FindElement(By.XPath("//a[contains(text(),'" + locationName + "')]")));

            driver.FindElement(By.ClassName("ng-star-inserted")).FindElement(By.XPath("//a[contains(text(),'" + locationName + "')]")).Click();
            wait.Until(wd => driver.FindElement(By.XPath("//label[contains(text(), 'Rate Details')]")));
            //should be deleted when "500 internal error" caused due to load timeout will be fixed.
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //wait.Until(wd => driver.FindElement(By.XPath("//label[contains(text(), 'Assigned rate')]/../..//mat-checkbox[contains(@class,'mat-checkbox-checked')]")));
                wait.Until(wd => driver.FindElement(By.XPath("//locationdetails//div[@class='ng-star-inserted'][not(button)]")));
            }
            catch (Exception)
            {
                throw;
            }
            //end.
        }

        public bool IsLocationExist(string locationName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.ClassName("ui-treetable-table")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IList<IWebElement> allLoactions = driver.FindElements(By.XPath("//tbody //a[contains(@class,'ui-treetable-label')]"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            foreach (IWebElement location in allLoactions)
            {
                if (location.Text.Contains(locationName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
