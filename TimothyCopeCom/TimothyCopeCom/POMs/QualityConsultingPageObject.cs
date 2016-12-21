using AutomationFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TimothyCopeCom.POMs
{
    public class QualityConsultingPageObject
    {
        public QualityConsultingPageObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #region FIND ELEMENT LOCATORS

        [FindsBy(How = How.CssSelector, Using = "h2 > a")]
        public IWebElement linkEmail { get; set; }

        #endregion

        #region PAGE SPECIFIC METHODS

        /// <summary>
        /// Navigates to and initializes the "quality consulting" page
        /// </summary>
        /// <param name="driver">The current WebDriver</param>
        /// <param name="baseUrl">The base URL from the config file</param>
        /// <returns>The initialized "quality consulting" page object</returns>
        public static QualityConsultingPageObject NavigateAndInitialize(IWebDriver driver, string baseUrl)
        {
            // Navigate to the "quality consulting" page
            SeleniumUtils.NavigateToUrl(driver, baseUrl + "/quality-consulting/");
            // Return the initialized "quality consulting" page object
            return new QualityConsultingPageObject(driver);
        }

        #endregion PAGE SPECIFIC METHODS
    }
}
