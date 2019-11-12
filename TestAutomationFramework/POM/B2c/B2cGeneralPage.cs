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
        
        //Obsolete
        public string GetUserName()
        {
            return userNameButton.Text.ToString();
        }

        public void ClickMenuByName(string menuName)
        {
            Console.WriteLine("Method: ClickMenuByName Started, with menuName = " + menuName);
            Console.WriteLine("Wait until side menu will be displayed");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.Id("side-menu")).Displayed);

            Console.WriteLine("Before IF");
            if (!driver.FindElement(By.XPath("//ul[@id = 'side-menu']//a[contains(text(),'" + menuName + "')]")).Displayed)
            {
                Console.WriteLine("Insided IF");
                //driver.FindElement(By.XPath("//ul[@id = 'side-menu']//a[contains(text(),'" + menuName + "')]//ancestor::ul[@class='nav nav-second-level collapse']/../a")).Click();
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//ul[@id = 'side-menu']//a[contains(text(),'" + menuName + "')]//ancestor::ul[@class='nav nav-second-level collapse']/../a")));
                System.Threading.Thread.Sleep(500);
            }
            Console.WriteLine("After IF");
            wait.Until(wd => driver.FindElement(By.XPath("//ul[@id = 'side-menu']//a[contains(text(),'" + menuName + "')]")).Displayed);
            driver.FindElement(By.XPath("//ul[@id = 'side-menu']//a[contains(text(),'" + menuName + "')]")).Click();
            Console.WriteLine("Method: ClickMenuByName Finished");
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

        public string GetElementTextById(string inputId)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.Id(inputId)));
            return driver.FindElement(By.Id(inputId)).Text;
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
            driver.FindElement(By.XPath("//*[@id ='" + selectId + "']/..//span[contains(@class, 'pull-right enel-select-arrow')]")).Click();
            driver.FindElement(By.XPath("//*[@id ='" + selectId + "']/..//span[contains(text(), '" + selectValue + "')]")).Click();
        }

        public void SelectValueByIdGeneral(string selectId, string selectValue)
        {
            //We use this xpath, since we have two types of selector (select with Id) and (div with Id and select inside).
            //See Reports/UserSessions page for example
            var selectElement = new SelectElement(driver.FindElement(By.XPath("//*[@id ='" + selectId + "']/descendant-or-self::select")));
            selectElement.SelectByValue(selectValue);
        }

        public void SelectTextByIdGeneral(string selectId, string selectText)
        {
            //We use this xpath, since we have two types of selector (select with Id) and (div with Id and select inside).
            //See Reports/UserSessions page for example
            var selectElement = new SelectElement(driver.FindElement(By.XPath("//*[@id ='" + selectId + "']/descendant-or-self::select")));
            selectElement.SelectByText(selectText);
        }

        public string getSelectValueById(string selectId)
        {
            return driver.FindElement(By.XPath("//*[@id ='" + selectId + "']/..//span[contains(@class,'multiselect-selected-text')]")).Text;
            //return driver.FindElement(By.XPath("//li//span[contains(text(), '" + selectText + "')]/../input")).GetAttribute("value").ToString();
        }

        //public string getSelectValueById(string selectId)
        //{
        //    return driver.FindElement(By.XPath("//*[@id ='" + selectId + "']/descendant-or-self::select")).GetAttribute("value").ToString();
        //}

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
            //selectElement.SelectByValue(selectValue);
            selectElement.SelectByText(selectValue);
        }
        public void SelectCheckboxByLabel(string selectLabel)
        {
            driver.FindElement(By.XPath("//div//label[contains(text(),'" + selectLabel + "')]/input")).Click();

        }
        public void ClickButtonWithId(string buttonId)
        {
            //driver.FindElementById(buttonId).Submit();
            driver.FindElementById(buttonId).Click();
        }

        public void ClickSwitchWithId(string switchId)
        {
            driver.FindElement(By.XPath("//input[contains(@id,'" + switchId + "')]/..")).Click();
        }

        //public void ClickSwitchWithId(string switchId)
        //{
        //    driver.FindElement(By.XPath("//div[contains(@class,'bootstrap-switch-id-" + switchId + "')]")).Click();
        //}

        public bool IsSwitchWithIdOn(string switchId)
        {
            if (driver.FindElement(By.XPath("//input[contains(@id,'" + switchId + "')]/..")).GetAttribute("class").Contains("off"))
            {
                return false;
            }
            return true;
        }

        //public bool IsSwitchWithIdOn(string switchId)
        //{
        //    if (driver.FindElement(By.XPath("//div[contains(@class,'bootstrap-switch-id-" + switchId + "')]")).GetAttribute("class").Contains("bootstrap-switch-on"))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public string GetPanelIdForSwitchWithId(string switchId)
        {
            return driver.FindElement(By.XPath("//input[contains(@id,'" + switchId + "')]/ancestor::form/..")).GetAttribute("id");
        }

        //public string GetPanelIdForSwitchWithId(string switchId)
        //{
        //    return driver.FindElement(By.XPath("//div[contains(@class,'bootstrap-switch-id-" + switchId + "')]/ancestor::form/..")).GetAttribute("id");
        //}

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

        //probably obsolete
        public String getDisplayedAlertId()
        {
            return driver.FindElement(By.XPath("//div[@class='modal fade in']//div[contains(@class, 'alert') and not(contains(concat(' ',@style,' '),'display:none'))]")).GetAttribute("id");
        }

        public String getDisplayedAlertClass()
        {
            return driver.FindElement(By.XPath("//div[@class='modal fade in']//span[contains(@class, 'message-placeholder')]")).GetAttribute("class");
        }

        public String getDisplayedAlertText()
        {
            return driver.FindElement(By.XPath("//div[@class='modal fade in']//p[contains(@role, 'alert')]")).Text;
        }

        public void clickCheckBoxTest(string cheboxText)
        {
            driver.FindElement(By.XPath("//div[contains(@class,'checkbox')]//label[contains(text(),'" + cheboxText + "')]")).Click();
        }
    }
}
