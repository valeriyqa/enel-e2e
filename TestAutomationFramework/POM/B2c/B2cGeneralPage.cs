using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;

namespace TestAutomationFramework.POM
{
    class B2cGeneralPage
    {
        private readonly RemoteWebDriver driver;
        public B2cGeneralPage(RemoteWebDriver driver) => this.driver = driver;

        IWebElement userNameButton => driver.FindElementByXPath("//*[@id='wrapper']/nav/ul/li[3]/a");

        public string GetUserName()
        {
            return userNameButton.Text.ToString();
        }

        public void ClickMenuByName(string menuName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.Id("side-menu")).Displayed);

            IWebElement curentMenu = driver.FindElement(By.XPath("//ul[@id = 'side-menu']//a[contains(text(),'" + menuName + "')]"));
            if (!curentMenu.Displayed)
            {
                driver.FindElement(By.XPath("//ul[@id = 'side-menu']//a[contains(text(),'" + menuName + "')]//ancestor::ul[@class='nav nav-second-level collapse']/../a")).Click();
            }
            wait.Until(wd => curentMenu.Displayed);
            curentMenu.Click();
        }

        public string GetAddressByMenuName(string menuName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.Id("side-menu")).Displayed);

            string address = driver.FindElement(By.XPath("//ul[@id = 'side-menu']//a[contains(text(),'" + menuName + "')]")).GetAttribute("href").ToString().Replace("/Dashboard", "").TrimEnd('#');
            if (address.Contains("OcppAdmin"))
            {
                address = address + "/CentralSystem";
            }
            return address;
        }

        public string GetInputValueById(string inputId)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//*[@id = '" + inputId + "']//ancestor-or-self::input")).GetAttribute("value").Length > 0);
            return driver.FindElement(By.XPath("//*[@id = '" + inputId + "']//ancestor-or-self::input")).GetAttribute("value");
        }

        public void SetInputValueById(string inputId, string inputValue)
        {
            //driver.FindElement(By.XPath("//div[@id = '" + inputId + "']//input")).Clear();
            //driver.FindElement(By.XPath("//div[@id = '" + inputId + "']//input")).SendKeys(inputValue);
            driver.FindElement(By.XPath("//*[@id = '" + inputId + "']//ancestor-or-self::input")).Clear();
            driver.FindElement(By.XPath("//*[@id = '" + inputId + "']//ancestor-or-self::input")).SendKeys(inputValue);
        }

        public void ClearInputValueById(string inputId)
        {
            driver.FindElement(By.XPath("//*[@id = '" + inputId + "']//ancestor-or-self::input")).Clear();
        }

        public string GetInputValueByLabel(string inputLabel)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//div//label[contains(text(),'" + inputLabel + "')]/following-sibling::div//input")).GetAttribute("value").Length > 0);
            return driver.FindElement(By.XPath("//div//label[contains(text(),'" + inputLabel + "')]/following-sibling::div//input")).GetAttribute("value");
        }

        public void SetInputValueByLabel(string inputLabel, string inputValue)
        {
            driver.FindElement(By.XPath("//div//label[contains(text(),'" + inputLabel + "')]/following-sibling::div//input")).Clear();
            driver.FindElement(By.XPath("//div//label[contains(text(),'" + inputLabel + "')]/following-sibling::div//input")).SendKeys(inputValue);
        }

        public void SelectValueById(string selectId, string selectValue)
        {
            //We use this xpath, since we have two types of selector (select with Id) and (div with Id and select inside).
            //See Reports/UserSessions page for example
            var selectElement = new SelectElement(driver.FindElement(By.XPath("//*[@id ='" + selectId + "']/descendant-or-self::select")));
            selectElement.SelectByValue(selectValue);
        }

        public string getSelectValueById(string selectId)
        {
            return driver.FindElement(By.XPath("//*[@id ='" + selectId + "']/descendant-or-self::select")).GetAttribute("value").ToString();
        }

        public void SelectTextById(string selectId, string selectText)
        {
            //We use this xpath, since we have two types of selector (select with Id) and (div with Id and select inside).
            //See Reports/UserSessions page for example
            var selectElement = new SelectElement(driver.FindElement(By.XPath("//*[@id ='" + selectId + "']/descendant-or-self::select")));
            selectElement.SelectByValue(selectText);
        }

        public void SelectValueByLabel(string selectLabel, string selectValue)
        {
            //We use this xpath, since we have two types of selector (select with label as brother) and (select with label as child).
            //See Reports/UserSessions page for example
            var selectElement = new SelectElement(driver.FindElement(By.XPath("//div//label[contains(text(),'" + selectLabel + "')]/..//select")));
            selectElement.SelectByValue(selectValue);
        }
        public void SelectCheckboxByLabel(string selectLabel)
        {
            driver.FindElement(By.XPath("//div//label[contains(text(),'" + selectLabel + "')]/input")).Click();

        }
        public void ClickButtonWithId(string buttonId)
        {
            driver.FindElementById(buttonId).Submit();
        }

        public void ClickSwitchWithId(string switchId)
        {
            driver.FindElement(By.XPath("//div[contains(@class,'bootstrap-switch-id-" + switchId + "')]")).Click();
        }

        public bool IsSwitchWithIdOn(string switchId)
        {
            if (driver.FindElement(By.XPath("//div[contains(@class,'bootstrap-switch-id-" + switchId + "')]")).GetAttribute("class").Contains("bootstrap-switch-on"))
            {
                return true;
            }
            return false;
        }

        public string GetPanelIdForSwitchWithId(string switchId)
        {
            return driver.FindElement(By.XPath("//div[contains(@class,'bootstrap-switch-id-" + switchId + "')]/ancestor::form/..")).GetAttribute("id");
        }

        public void ClickButtonWithName(string buttonName)
        {
            IJavaScriptExecutor js = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => (Int64)js.ExecuteScript("return $(\"button:contains('" + buttonName + "'):visible\").length;") > 0);

            js.ExecuteScript("$(\"button:contains('" + buttonName + "'):visible\").click();");
            
            //driver.FindElement(By.XPath("//button[contains(text(),'" + buttonName + "')]")).Submit();
        }

        //We should optimize this mathod since it use big part of GetTableById
        public DataTable GetTableFromAllListsById(string tableId)
        {
            if (!tableId.Contains("wrapper"))
            {
                tableId = tableId + "_wrapper";
            }

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id = '" + tableId + "']")).Displayed);

            DataTable dt = new DataTable();
            IList<IWebElement> headersElement = driver.FindElements(By.XPath("//div[@id = '" + tableId + "']//th"));
            foreach (IWebElement header in headersElement)
            {
                dt.Columns.Add(header.Text);
            }

            while (true)
            {
                IList<IWebElement> bodyRows = driver.FindElements(By.XPath("//div[@id = '" + tableId + "']//tbody//tr"));
                for (int i = 1; i <= bodyRows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    IList<IWebElement> cellsInRow = driver.FindElements(By.XPath("//div[@id = '" + tableId + "']//tbody//tr[" + i + "]//td"));
                    for (int j = 0; j < cellsInRow.Count; j++)
                    {
                        dr[j] = cellsInRow[j].Text;
                    }
                    dt.Rows.Add(dr);
                }

                if (driver.FindElement(By.XPath("//div[@id = '" + tableId + "']//li[contains(@class, 'paginate_button next')]")).GetAttribute("class").Contains("disabled"))
                {
                    break;
                }
                else
                {
                    driver.FindElement(By.XPath("//div[@id = '" + tableId + "']//li[contains(@class, 'paginate_button next')]/a")).Click();
                }
            }
            return dt;
        }

        public DataTable GetTableById(string tableId)
        {
            if (!tableId.Contains("wrapper"))
            {
                tableId = tableId + "_wrapper";
            }

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id = '" + tableId + "']")).Displayed);

            DataTable dt = new DataTable();
            IList<IWebElement> headersElement = driver.FindElements(By.XPath("//div[@id = '" + tableId + "']//th"));
            foreach (IWebElement header in headersElement)
            {
                dt.Columns.Add(header.Text);
            }

            IList<IWebElement> bodyRows = driver.FindElements(By.XPath("//div[@id = '" + tableId + "']//tbody//tr"));
            for (int i = 1; i <= bodyRows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                IList<IWebElement> cellsInRow = driver.FindElements(By.XPath("//div[@id = '" + tableId + "']//tbody//tr[" + i + "]//td"));
                for (int j = 0; j < cellsInRow.Count; j++)
                {
                    dr[j] = cellsInRow[j].Text;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public String getDisplayedAlertId()
        {
            return driver.FindElement(By.XPath("//div[@class='modal fade in']//div[contains(@class, 'alert') and not(contains(concat(' ',@style,' '),'display:none'))]")).GetAttribute("id");
        }

        public String getDisplayedAlertClass()
        {
            return driver.FindElement(By.XPath("//div[@class='modal fade in']//div[contains(@class, 'alert') and not(contains(concat(' ',@style,' '),'display:none'))]")).GetAttribute("class");
        }

        public String getDisplayedAlertText()
        {
            return driver.FindElement(By.XPath("//div[@class='modal fade in']//div[contains(@class, 'alert') and not(contains(concat(' ',@style,' '),'display:none'))]")).Text;
        }
    }
}
