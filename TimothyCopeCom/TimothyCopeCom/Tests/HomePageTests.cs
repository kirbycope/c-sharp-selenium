using AutomationFramework;
using Assert = AutomationFramework.Assert;
using NUnit.Framework;
using TimothyCopeCom.POMs;

namespace TimothyCopeCom.Tests
{
    [TestFixture]
    [Parallelizable]
    public class HomePageTests : TestBase
    {
        [Test]
        [Description("Navigate to the home page and then click the Call-to-Action button.")]
        [TestCaseSource(typeof(TestBase), "GetBrowsers")]
        public void VerifyCallToAction(string browserName)
        {
            // Setup the WebDriver
            Setup(browserName);
            // Navigate to and initialize the "home" page
            HomePageObject homePageObject = HomePageObject.NavigateAndInitialize(driver, baseUrl);
            // Assert: The Call-To-Action's text reads, "Learn More"
            Assert.AreEqual("Learn More", homePageObject.linkCallToAction.Text);
            // Assert: The Call-To-Action's href is "/quality-consulting/"
            Assert.ContainsText("/quality-consulting/", homePageObject.linkCallToAction.GetAttribute("href"));
            // Click the Call-to-Action element and initialize the "quality consulting page" (that we should end up on)
            QualityConsultingPageObject qualityConsultingPageObject = HomePageObject.ClickCallToAction(driver, homePageObject);
            // Assert: We are actually on the "quality consulting" page by looking for the contact email address
            Assert.IsDisplayed(qualityConsultingPageObject.linkEmail, "Email link not displayed on the current page.");
        }
    }
}
