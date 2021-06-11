using NUnit.Framework;
using OpenQA.Selenium;
using NetCoreTestProjectKinopoisk.Pages;

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

        [TearDown]
        public void TestEnding()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Quit();
        }

        [OneTimeTearDown]
        public void QuitDriver()
        {
            _driver.Quit();
        }
    }
}
