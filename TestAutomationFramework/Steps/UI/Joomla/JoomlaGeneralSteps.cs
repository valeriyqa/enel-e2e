using JsonConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TestAutomationFramework.POM;

namespace TestAutomationFramework.Steps.UI
{
    [Binding]
    public class JoomlaGeneralSteps
    {
        private readonly RemoteWebDriver driver;
        private string host = Config.Global.env_site_address;

        public JoomlaGeneralSteps(RemoteWebDriver driver) => this.driver = driver;

        public class MenuItem
        {
            public string className { get; set; }
            public string href { get; set; }
        }

        [Then(@"I click all menu item in rotation \(joomla\)")]
        public void IClickAllMenuItemInRotationJoomla()
        {
            IList<IWebElement> menuItems = driver.FindElements(By.XPath("//li[contains(@class, ' item-') or starts-with(@class, 'item-') and not(contains(@class,'divider'))]"));
            var generalPage = new JoomlaGeneralPage(driver);

            if (menuItems.Count > 0)
            {
                IList<MenuItem> menuItemsList = new List<MenuItem>();
                foreach (IWebElement element in menuItems)
                {
                    IWebElement link = element.FindElement(By.XPath(".//a"));
                    menuItemsList.Add(new MenuItem{ className = element.GetAttribute("class"), href = link.GetAttribute("href") });
                }

                string mainHandle = driver.CurrentWindowHandle;
                foreach (MenuItem menuItem in menuItemsList)
                {
                    if(menuItem.href.Contains(host))
                    {
                        generalPage.ClickMenuItemByClass(menuItem.className);
                        Assert.IsTrue(driver.Url.Contains(menuItem.href));
                    }
                    else
                    {
                        generalPage.ClickMenuItemByClass(menuItem.className);
                        generalPage.SwitchToWindow(driver => driver.CurrentWindowHandle == driver.WindowHandles.Last());
                        Assert.IsTrue(driver.Url.Contains(menuItem.href));
                        generalPage.SwitchToWindow(driver => driver.CurrentWindowHandle == mainHandle);
                    }                    
                }
            }
        }
    }
}
