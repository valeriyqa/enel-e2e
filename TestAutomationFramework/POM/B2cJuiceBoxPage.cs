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
        IWebElement chargingStartEmailCheckbox => driver.FindElementById("Notifications_0__NotificationDeliveryMethods_0__IsSelected");
        IWebElement chargingStartSmartphoneCheckbox => driver.FindElementById("Notifications_0__NotificationDeliveryMethods_1__IsSelected");
        IWebElement chargingStopEmailCheckbox => driver.FindElementById("Notifications_1__NotificationDeliveryMethods_0__IsSelected");
        IWebElement chargingStopSmartphoneCheckbox => driver.FindElementById("Notifications_1__NotificationDeliveryMethods_1__IsSelected");
        IWebElement chargingDelayedEmailCheckbox => driver.FindElementById("Notifications_2__NotificationDeliveryMethods_0__IsSelected");
        IWebElement chargingDelayedSmartphoneCheckbox => driver.FindElementById("Notifications_2__NotificationDeliveryMethods_1__IsSelected");
        IWebElement unitOnlineEmailCheckbox => driver.FindElementById("Notifications_3__NotificationDeliveryMethods_0__IsSelected");
        IWebElement unitOnlineSmartphoneCheckbox => driver.FindElementById("Notifications_3__NotificationDeliveryMethods_1__IsSelected");
        IWebElement unitOfflineEmailCheckbox => driver.FindElementById("Notifications_4__NotificationDeliveryMethods_0__IsSelected");
        IWebElement unitOfflineSmartphoneCheckbox => driver.FindElementById("Notifications_4__NotificationDeliveryMethods_1__IsSelected");
        IWebElement unitNotPluggedEmailCheckbox => driver.FindElementById("Notifications_5__NotificationDeliveryMethods_0__IsSelected");
        IWebElement unitNotPluggedSmartphoneCheckbox => driver.FindElementById("Notifications_5__NotificationDeliveryMethods_1__IsSelected");



    }
}
