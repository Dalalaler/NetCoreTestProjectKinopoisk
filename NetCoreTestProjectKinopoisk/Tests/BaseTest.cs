using NUnit.Framework;
using OpenQA.Selenium;
using NetCoreTestProjectKinopoisk.Pages;
using NetCoreTestProjectKinopoisk.Driver;

namespace NetCoreTestProjectKinopoisk.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected IWebDriver _driver;
        protected MainPage _mainPage;
        protected PassportPage _passportPage;
        protected GirlfriendExperiencePage _girlfriendExperiencePage;
        protected SettingsEditingPage _settingsEditingPage;
        protected ExtendedSearchPage _extendedSearchPage;
        protected FavoriteFilmsPage _favoriteFilmsPage;

        [OneTimeSetUp]
        public void DriverSetup()
        {
            _driver = DriverSingleton.getInstance().getDriver();
        }

        [OneTimeTearDown]
        public void QuitDriver()
        {
            _driver.Quit();
        }
    }
}
