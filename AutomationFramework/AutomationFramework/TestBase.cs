using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AutomationFramework
{
    public class TestBase
    {
        // Declare a WebDriver for the tests
        protected IWebDriver driver;
        // Define the Base URL (from the App.config)
        protected string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        // Define the  Grid Hub URI (from the App.config)
        protected Uri hubUri = new Uri(ConfigurationManager.AppSettings["hubUri"]);

        /// <summary>
        /// Sets up the appropriate WebDriver
        /// </summary>
        /// <param name="browserName">The name of the browser the test requires</param>
        public void Setup(string browserName)
        {
            if (browserName.Equals("ie"))
            {
                try // Use Remote IE
                {
                    DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorer();
                    driver = new RemoteWebDriver(hubUri, capabilities);
                }
                catch // Use local IE
                {
                    Console.WriteLine("Unable to use remote ie, using local instead.");
                    var options = new InternetExplorerOptions { EnsureCleanSession = true };
                    driver = new InternetExplorerDriver(options);
                }
            }
            else if (browserName.Equals("chrome"))
            {
                try // Use Remote Chrome
                {
                    DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                    driver = new RemoteWebDriver(hubUri, capabilities);
                }
                catch // Use Local Chrome
                {
                    Console.WriteLine("Unable to use remote chrome, using local instead.");
                    driver = new ChromeDriver();
                }
            }
            else
            {
                try // Use Remote Firefox
                {
                    DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
                    driver = new RemoteWebDriver(hubUri, capabilities);
                }
                catch // Use Local Firefox
                {
                    Console.WriteLine("Unable to use remote firefox, using local instead.");
                    try // Load Firefox From Default Location
                    {
                        driver = new FirefoxDriver();
                    }
                    catch // Load Firefox From Specific Location
                    {
                        FirefoxBinary binary = new FirefoxBinary(@"C:\Program Files\Mozilla Firefox\firefox.exe");
                        FirefoxProfile profile = new FirefoxProfile();
                        driver = new FirefoxDriver(binary, profile);
                    }
                }
            }
            // Set window to full screen
            driver.Manage().Window.Maximize();
            // Clear all cookies
            driver.Manage().Cookies.DeleteAllCookies();
            // Set max global timeout
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }

        /// <summary>
        /// Closes the driver and any associated browser windows at the end of a test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

        static string configBrowsers = "";
        /// <summary>
        /// Gets each browser from the App.config
        /// </summary>
        /// <returns>Each browser from the App.config</returns>
        public static IEnumerable<string> GetBrowsers()
        {
            // If not yet retrieved, get data
            if (configBrowsers.Length == 0)
            {
                // Get the browsers from App.config. Defaults to Chrome if none are specified
                configBrowsers = ConfigurationManager.AppSettings["browsers"] ?? "chrome";
            }
            // Split the string (by the commas) into an array
            string[] browsers = configBrowsers.Split(',');
            // Return each browser in the array
            foreach (string browser in browsers)
            {
                yield return browser;
            }
        }
    }
}
