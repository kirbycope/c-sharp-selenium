using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AutomationFramework
{
    public class TestBase
    {
        protected IWebDriver driver;

        protected string baseUrl = ConfigurationManager.AppSettings["url"];

        public void Setup(string browserName)
        {
            // Set WebDriver based on browerName parameter
            if (browserName.Equals("ie"))
            {
                var options = new InternetExplorerOptions{EnsureCleanSession = true};
                driver = new InternetExplorerDriver(options);
            }
            else if (browserName.Equals("chrome"))
            {
                driver = new ChromeDriver();
            }
            else
            {
                driver = new FirefoxDriver();
            }
            // Set window to full screen
            driver.Manage().Window.Maximize();
            // Clear all cookies
            driver.Manage().Cookies.DeleteAllCookies();
            // Set max global timeout
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

        public static IEnumerable<string> GetBrowsers()
        {
            // Get the browsers from App.config. Defaults to Chrome if none are specified
            string configBrowser = ConfigurationManager.AppSettings["browsers"] ?? "chrome";
            string[] browsers = configBrowser.Split(',');
            // Return each browser
            foreach (string browser in browsers)
            {
                yield return browser;
            }
        }
    }
}
