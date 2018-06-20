using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TestAutomationFramework.POM
{
    class B2bLocationPage
    {
        IWebElement TimeZoneSelect => driver.FindElement(By.Id("mat-select-0"));
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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.ClassName("location-node")).FindElement(By.XPath("//a[contains(text(),'" + locationName + "')]")));

            driver.FindElement(By.ClassName("location-node")).FindElement(By.XPath("//a[contains(text(),'" + locationName + "')]")).Click();
            wait.Until(wd => driver.FindElement(By.ClassName("ui-treetable")));
        }

        public bool IsLocationExist(string locationName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.ClassName("ui-treetable")));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IList<IWebElement> allLoactions = driver.FindElements(By.ClassName("location-node"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            foreach (IWebElement location in allLoactions)
            {
                if (location.FindElement(By.ClassName("ui-treetable-label")).Text.Contains(locationName))
                {
                    return true;
                }
            }
            return false;
        }



        //public class Location
        //{
        //    public string locationName { get; set; }
        //    public string parentName { get; set; }
        //    public string[] childName { get; set; }
        //    public int numberOfDevices { get; set; }
        //    public int devicesInUse { get; set; }
        //    public string locationAddress { get; set; }
        //}

        //public Dictionary<string, string> GetLocation(string locationName)
        //{
        //    return null;
        //}

        //public Dictionary<string, Location> GetAllLocations()
        //{
        //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    wait.Until(wd => LocationsTable);
        //    IList<IWebElement> AllParent = driver.FindElements(By.ClassName("ui-treetable-data.ui-widget-content"));

        //    return null;
        //}


        //        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //        wait.Until(wd => selector.GetAttribute("aria-owns").Length > 0);
        //            selector.FindElement(By.ClassName("mat-select-trigger")).Click();
        //        wait.Until(wd => driver.FindElement(By.ClassName("cdk-overlay-container")).FindElement(By.ClassName("ng-trigger")));

        //            IList<IWebElement> AllDropDownList = driver.FindElements(By.XPath("//span[@class='mat-option-text']"));
        //            foreach (var element in AllDropDownList)
        //            {
        //                if (element.Text.Contains(value))
        //                {
        //                    element.Click();
        //                    System.Threading.Thread.Sleep(500);
        //                    break;
        //                }
        //}
    }
}
