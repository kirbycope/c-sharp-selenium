using AutomationFramework;
using Assert = AutomationFramework.Assert;
using NUnit.Framework;
using TimothyCopeCom.POMs;

namespace TimothyCopeCom.Tests
{
    [TestFixture]
    [Parallelizable]
    public class HtmlTestPageTests : TestBase
    {
        [Test]
        [Description("Verifies the URL updates when the form is filled out and submitted.")]
        [TestCaseSource(typeof(TestBase), "GetBrowsers")]
        public void VerifyFormSubmission(string browserName)
        {
            // Setup the WebDriver
            Setup(browserName);
            // Navigate to and initialize the "/html-test-page" page
            HtmlTestPageObject htmlTestPageObject = HtmlTestPageObject.NavigateAndInitialize(driver, baseUrl);
            // Enter a value for the first name
            SeleniumUtils.InputText(driver, htmlTestPageObject.inputFirstName, "Timothy");
            // Enter a value for the last name
            SeleniumUtils.InputText(driver, htmlTestPageObject.inputLastName, "Cope");
            // Submit the form
            SeleniumUtils.ClickElement(driver, htmlTestPageObject.btnSubmit);
            // Assert: URL reflects submitted form value(s) 
            Assert.ContainsText("?FirstName=Timothy&LastName=Cope", driver.Url);
        }
    }
}
