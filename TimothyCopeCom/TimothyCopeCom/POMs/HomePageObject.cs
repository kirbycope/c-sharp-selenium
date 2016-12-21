using AutomationFramework;
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

        [FindsBy(How = How.CssSelector, Using = "#content > div.top-section > div > div > div.col-sm-4 > a")]
        public IWebElement linkCallToAction { get; set; }

        #endregion

        #region PAGE SPECIFIC METHODS

        /// <summary>
        /// Navigates to and initializes the "home" page
        /// </summary>
        /// <param name="driver">The current WebDriver</param>
        /// <param name="baseUrl">The base URL from the config file</param>
        /// <returns>The initialized "home" page object</returns>
        public static HomePageObject NavigateAndInitialize(IWebDriver driver, string baseUrl)
        {
            // Navigate to the baseUrl (the "home" page)
            SeleniumUtils.NavigateToUrl(driver, baseUrl);
            // Return the initialized "home" page object
            return new HomePageObject(driver);
        }

        /// <summary>
        /// Clicks the Call-To-Action on the "home" page
        /// </summary>
        /// <param name="driver">The current WebDriver</param>
        /// <param name="homePageObject">The initialized page object</param>
        /// <returns>The initialized "quality consulting" page object</returns>
        public static QualityConsultingPageObject ClickCallToAction(IWebDriver driver, HomePageObject homePageObject)
        {
            // Click the Call-To-Action on the "home" page
            SeleniumUtils.ClickElement(driver, homePageObject.linkCallToAction);
            // Return the initialized "quality consulting" page object
            return new QualityConsultingPageObject(driver);
        }

        #endregion
    }
}
