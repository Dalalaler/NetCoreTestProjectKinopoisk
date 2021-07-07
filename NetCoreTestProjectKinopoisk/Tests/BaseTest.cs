using NUnit.Framework;
using OpenQA.Selenium;
using NetCoreTestProjectKinopoisk.Pages;
using NetCoreTestProjectKinopoisk.Driver;

namespace NetCoreTestProjectKinopoisk.Tests
{
   
    public abstract class BaseTest
    {
        protected IWebDriver _driver { get; set; }
        protected MainPage _mainPage;
        protected PassportPage _passportPage;
        protected GirlfriendExperiencePage _girlfriendExperiencePage;
        protected SettingsEditingPage _settingsEditingPage;
        protected ExtendedSearchPage _extendedSearchPage;
        protected FavoriteFilmsPage _favoriteFilmsPage;
    }
}
