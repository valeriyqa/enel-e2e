using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestAutomationFramework.POM.B2c
{
    class B2cMyJuiceNetDevicesPage
    {
        private readonly RemoteWebDriver driver;
        public B2cMyJuiceNetDevicesPage(RemoteWebDriver driver) => this.driver = driver;

        public void clickPairButtonForDeviceWithId(pairButtonType pairButtonType, string deviceId)
        {
            switch (pairButtonType)
            {
                case pairButtonType.AmazonAlexa:
                    driver.FindElement(By.XPath("//*[contains(@data-unitid, '" + deviceId + "')]//button[@data-target = '#alexaPairInfo']")).Click();
                    break;
                case pairButtonType.GoogleApp:
                    driver.FindElement(By.XPath("//*[contains(@data-unitid, '" + deviceId + "')]//button[@data-target = '#googleAppPairInfo']")).Click();
                    break;
                case pairButtonType.GuestPin:
                    //driver.FindElement(By.XPath("//*[contains(@data-unitid, '" + deviceId + "')]//a[contains(@class, 'request-share-pin-button')]")).Click();
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                    executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[contains(@data-unitid, '" + deviceId + "')]//a[contains(@class, 'request-share-pin-button')]")));
                    break;
                
            }
        }

        public enum pairButtonType
        {
            AmazonAlexa,
            GoogleApp,
            GuestPin
        }

    }
}
