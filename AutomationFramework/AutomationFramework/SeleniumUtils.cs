﻿using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Drawing.Imaging;

namespace AutomationFramework
{
    public class SeleniumUtils
    {
        #region global variables

        private static string screenshotFolder = ConfigurationManager.AppSettings["screenshotFolder"];

        #endregion global variables

        /// <summary>
        /// Takes a screenshot of the WebDriver's current page.
        /// </summary>
        /// <param name="driver"></param>
        public static string TakeScreenshot(IWebDriver driver)
        {
            // Get the current TimeStamp
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff");
            // Build a file name (*NOTE: The folder must already exist and allow writes to it)
            string fileName = screenshotFolder + timeStamp + ".jpg";
            // Take a screenshot
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(fileName, ImageFormat.Jpeg);
            // Return the filename of the screenshot
            return fileName;
        }
    }
}
