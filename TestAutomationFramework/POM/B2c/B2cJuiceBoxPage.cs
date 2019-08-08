using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;

namespace TestAutomationFramework.POM
{
    class B2cJuiceBoxPage
    {
        private readonly RemoteWebDriver driver;
        public B2cJuiceBoxPage(RemoteWebDriver driver) => this.driver = driver;

        //Notifications section
        //IWebElement chargingStartEmailCheckbox => driver.FindElementById("Notifications_0__NotificationDeliveryMethods_0__IsSelected");
        //IWebElement chargingStartSmartphoneCheckbox => driver.FindElementById("Notifications_0__NotificationDeliveryMethods_1__IsSelected");
        //IWebElement chargingStopEmailCheckbox => driver.FindElementById("Notifications_1__NotificationDeliveryMethods_0__IsSelected");
        //IWebElement chargingStopSmartphoneCheckbox => driver.FindElementById("Notifications_1__NotificationDeliveryMethods_1__IsSelected");
        //IWebElement chargingDelayedEmailCheckbox => driver.FindElementById("Notifications_2__NotificationDeliveryMethods_0__IsSelected");
        //IWebElement chargingDelayedSmartphoneCheckbox => driver.FindElementById("Notifications_2__NotificationDeliveryMethods_1__IsSelected");
        //IWebElement unitOnlineEmailCheckbox => driver.FindElementById("Notifications_3__NotificationDeliveryMethods_0__IsSelected");
        //IWebElement unitOnlineSmartphoneCheckbox => driver.FindElementById("Notifications_3__NotificationDeliveryMethods_1__IsSelected");
        //IWebElement unitOfflineEmailCheckbox => driver.FindElementById("Notifications_4__NotificationDeliveryMethods_0__IsSelected");
        //IWebElement unitOfflineSmartphoneCheckbox => driver.FindElementById("Notifications_4__NotificationDeliveryMethods_1__IsSelected");
        //IWebElement unitNotPluggedEmailCheckbox => driver.FindElementById("Notifications_5__NotificationDeliveryMethods_0__IsSelected");
        //IWebElement unitNotPluggedSmartphoneCheckbox => driver.FindElementById("Notifications_5__NotificationDeliveryMethods_1__IsSelected");

        IWebElement currentTimeOnDevice => driver.FindElement(By.XPath("//form[@id ='formTOU']//*[contains(text(),'Current time on device')]"));

        public string getCurrentTimeOnDevice()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => currentTimeOnDevice.Displayed);
            return currentTimeOnDevice.Text.Replace("Current time on device:", "").Trim();
        }

        public void ClickOnUpdateButtonForPannelWithId(string panelId)
        {
            driver.FindElement(By.XPath("//div[@id ='" + panelId + "']//button[@type ='submit']")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id ='" + panelId + "']//button[@type ='submit'][contains(@class, 'disabled')]")));
            wait.Until(wd => driver.FindElement(By.XPath("//div[@id ='" + panelId + "']//button[@type ='submit'][not(contains(@class, 'disabled'))]")));
            //System.Threading.Thread.Sleep(1000);
        }

    }
}
