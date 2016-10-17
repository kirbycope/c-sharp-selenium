using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
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
        #region global variables

        // Declare a WebDriver for the tests
        protected IWebDriver driver;
        // Define the Base URL (from the App.config)
        protected string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        // Define the Browsers (from the App.config)
        protected static string browsersToRun = ConfigurationManager.AppSettings["browsers"];
        // Define the  Grid Hub URI (from the App.config)
        protected Uri hubUri = new Uri(ConfigurationManager.AppSettings["hubUri"]);

        #endregion global variables

        /// <summary>
        /// Sets up the appropriate WebDriver
        /// </summary>
        /// <param name="browserName">The name of the browser the test requires</param>
        public void Setup(string browserName)
        {
            // Set WebDriver based on browerName parameter
            if (browserName.Equals("ie"))
            {
                // Use Remote IE
                try
                {
                    DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorer();
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    capabilities.SetCapability(options.EnsureCleanSession.ToString(), true);
                    driver = new RemoteWebDriver(hubUri, capabilities);
                }
                // Use local IE
                catch
                {
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.EnsureCleanSession = true;
                    driver = new InternetExplorerDriver(options);
                }
            }
            else if (browserName.Equals("chrome"))
            {
                // Use Remote Chrome
                try
                {
                    DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                    driver = new RemoteWebDriver(hubUri, capabilities);
                }
                // Use Local Chrome
                catch
                {
                    // Create an options object to specify command line arguments for the Chrome web driver
                    ChromeOptions options = new ChromeOptions();
                    // Disable extensions
                    options.AddArgument(@"--disable-extensions");
                    // Create the driver with the defined options (above)
                    driver = new ChromeDriver(options);
                }
            }
            else if (browserName.Equals("chromeDRM"))
            {
                // Create an options object to specify command line arguments for the Chrome web driver
                ChromeOptions options = new ChromeOptions();
                // Use a real profile so that DRM loads
                string localAppData = Environment.GetEnvironmentVariable("LocalAppData");
                options.AddArgument(@"user-data-dir=" + localAppData + @"\Google\Chrome\User Data\");
                options.AddArgument(@"--profile-directory=Default");
                // Allow components to update (helps with DRM)
                options.AddExcludedArgument(@"disable-component-update");
                // Disable extensions
                options.AddArgument(@"--disable-extensions");
                // Use Remote Chrome
                try
                {
                    DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                    capabilities.SetCapability(ChromeOptions.Capability, options);
                    IWebDriver driver = new RemoteWebDriver(capabilities);
                }
                // Use Local Chrome
                catch
                {
                    // Create the driver with the defined options (above)
                    driver = new ChromeDriver(options);
                }
            }
            else if (browserName.Equals("edge"))
            {
                // Use Remote Edge
                try
                {
                    DesiredCapabilities capabilities = DesiredCapabilities.Edge();
                    driver = new RemoteWebDriver(hubUri, capabilities);
                }
                // Use Local Edge
                catch
                {
                    driver = new EdgeDriver();
                }
            }
            else if (browserName.Equals("firefox"))
            {
                // Use Remote Firefox
                try
                {
                    DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
                    driver = new RemoteWebDriver(hubUri, capabilities);
                }
                // Use Local Firefox
                catch
                {
                    Console.WriteLine("Unable to use remote firefox, using local instead.");
                    // Load Firefox From Default Location
                    try
                    {
                        driver = new FirefoxDriver();
                    }
                    // Load Firefox From Specific Location (For Windows 10)
                    catch
                    {
                        FirefoxBinary binary = new FirefoxBinary(@"C:\Program Files\Mozilla Firefox\firefox.exe");
                        FirefoxProfile profile = new FirefoxProfile();
                        driver = new FirefoxDriver(binary, profile);
                    }
                }
            }
            else
            {
                throw new NotImplementedException(browserName + "not setup in TestBase.cs");
            }
            // Set window to full screen
            driver.Manage().Window.Maximize();
            // Clear all cookies (not respected by IE)
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

        /// <summary>
        /// Gets each browser from the App.config
        /// </summary>
        /// <returns>Each browser from the App.config</returns>
        public static IEnumerable<string> GetBrowsers()
        {
            // If no browsers were spcified, default to Firefox
            if (browsersToRun.Length == 0)
            {
                browsersToRun = "firefox";
            }
            // Split the list of browsers
            string[] browsers = browsersToRun.Split(',');
            // Return each browser
            foreach (string browser in browsers)
            {
                yield return browser;
            }
        }
    }
}
