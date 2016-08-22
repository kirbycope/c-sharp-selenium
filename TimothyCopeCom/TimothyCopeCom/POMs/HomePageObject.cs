using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TimothyCopeCom.POMs
{
    public class HomePageObject
    {
        public HomePageObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #region FIND ELEMENT LOCATORS

        [FindsBy(How = How.CssSelector, Using = "#logo > p > a")]
        public IWebElement linkHome { get; set; }

        #endregion

        #region PAGE SPECIFIC METHODS

        /// <summary>
        /// Navigates to and initializes the "home" page
        /// </summary>
        /// <param name="driver">The current WebDriver</param>
        /// <param name="baseUrl">The base URL from the config file</param>
        /// <returns>The initialized home page object</returns>
        public static HomePageObject NavigateAndInitialize(IWebDriver driver, string baseUrl)
        {
            // Navigate to the baseUrl (the "home" page)
            driver.Url = baseUrl;
            // Return the initialized home page object
            return new HomePageObject(driver);
        }

        #endregion
    }
}
