using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //public void SelectTimeZoneByValue(string value)
        //{
        //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    wait.Until(wd => TimeZoneSelect.GetAttribute("aria-owns").Length > 0);
        //    driver.FindElement(By.ClassName("mat-select-trigger")).Click();
        //    wait.Until(wd => driver.FindElement(By.ClassName("cdk-overlay-container")).FindElement(By.ClassName("ng-trigger")));

        //    IList<IWebElement> AllDropDownList = driver.FindElements(By.ClassName("mat-option-text"));
        //    foreach (var element in AllDropDownList)
        //    {
        //        if (element.Text.Contains(value))
        //        {
        //            element.Click();
        //            break;
        //        }
        //    }
        //}

        //public void SelectAssignRateByValue(string value)
        //{
        //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    wait.Until(wd => AssignRateSelect.GetAttribute("aria-owns").Length > 0);
        //    driver.FindElement(By.ClassName("mat-select-trigger")).Click();
        //    wait.Until(wd => driver.FindElement(By.ClassName("cdk-overlay-container")).FindElement(By.ClassName("ng-trigger")));

        //    IList<IWebElement> AllDropDownList = driver.FindElements(By.ClassName("mat-option-text"));
        //    foreach (var element in AllDropDownList)
        //    {
        //        if (element.Text.Contains(value))
        //        {
        //            element.Click();
        //            break;
        //        }
        //    }
        //}
    }
}
