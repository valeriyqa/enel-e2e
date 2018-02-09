﻿using System;
using OpenQA.Selenium;
using JuiceBoxQA.UITests.Globals;

namespace JuiceBoxQA.UITests.Helpers
{
    class ReportingMethods
    {
        public static String CreateScreenshot(IWebDriver driver)
        {
            string uuid = Guid.NewGuid().ToString();
            string fileName = Constants.ReportingImagesFolder + uuid + ".png";
            
            Screenshot screen = ((ITakesScreenshot)driver).GetScreenshot();
            screen.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            
            return fileName;
        }
    }
}
