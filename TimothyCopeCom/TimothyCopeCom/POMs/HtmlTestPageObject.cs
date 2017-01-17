using AutomationFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TimothyCopeCom.POMs
{
    public class HtmlTestPageObject
    {
        public HtmlTestPageObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #region FIND ELEMENT LOCATORS

        [FindsBy(How = How.CssSelector, Using = "#firstName")]
        public IWebElement inputFirstName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#lastName")]
        public IWebElement inputLastName { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "#NameForm > input.btn.btn-default")]
        public IWebElement btnSubmit { get; set; }

        #endregion

        #region PAGE SPECIFIC METHODS

        /// <summary>
        /// Navigates to and initializes the "/html-test-page" page
        /// </summary>
        /// <param name="driver">The current WebDriver</param>
        /// <param name="baseUrl">The base URL from the config file</param>
        /// <returns>The initialized "/html-test-page" page object</returns>
        public static HtmlTestPageObject NavigateAndInitialize(IWebDriver driver, string baseUrl)
        {
            // Navigate to the baseUrl (the "/html-test-page" page)
            SeleniumUtils.NavigateToUrl(driver, baseUrl + "/html-test-page");
            // Return the initialized "/html-test-page" page object
            return new HtmlTestPageObject(driver);
        }

        #endregion
    }
}
