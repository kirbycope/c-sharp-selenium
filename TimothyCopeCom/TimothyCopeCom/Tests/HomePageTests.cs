using AutomationFramework;
using NUnit.Framework;
using TimothyCopeCom.POMs;

namespace TimothyCopeCom.Tests
{
    [TestFixture]
    [Parallelizable]
    public class HomePageTests : TestBase
    {
        [Test]
        [Description("Navigate to the home page and verify the home link's text.")]
        [TestCaseSource(typeof(TestBase), "GetBrowsers")]
        public void VerifyHomeLink(string browserName)
        {
            // Setup the WebDriver
            Setup(browserName);
            // Navigate to and initialize the "home" page
            HomePageObject homePageObject = HomePageObject.NavigateAndInitialize(driver, baseUrl);
            // Assert the home link's text is the expected value
            Assert.AreEqual("Tim's Projects and Blog", homePageObject.linkHome.Text);
        }
    }
}
