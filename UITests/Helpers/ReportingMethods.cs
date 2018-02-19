#region

using System;
using OpenQA.Selenium;
using UITests.Globals;

#endregion

namespace UITests.Helpers
{
    internal class ReportingMethods
    {
        public static string CreateScreenshot(IWebDriver driver)
        {
            var uuid = Guid.NewGuid().ToString();
            var fileName = Constants.ReportingImagesFolder + uuid + ".png";

            var screen = ((ITakesScreenshot) driver).GetScreenshot();
            screen.SaveAsFile(fileName, ScreenshotImageFormat.Png);

            return fileName;
        }
    }
}