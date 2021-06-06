using NetCoreTestProjectKinopoisk.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace NetCoreTestProjectKinopoisk.Tests
{
    [TestFixture]
    abstract public class BasicTest
    {
        protected static IWebDriver driver;
        protected static MainPage mainPage;
        protected static PassportPage passportPage;
        protected static GirlfriendExperiencePage girlfriendExperiencePage;
        protected static SettingsEditingPage settingsEditingPage;
        protected static ExtendedSearchPage extendedSearchPage;

        [OneTimeSetUp]
        public void TestSetup()
        {            
            driver = DriverFactory.GetDriver(Enums.DriverNames.CHROME);
        }
        [OneTimeTearDown]
        public void QuitDriver()
        {            
            driver.Quit();
        }        
    }
}
