using NetCoreTestProjectKinopoisk.Constants;
using NetCoreTestProjectKinopoisk.Driver;
using NUnit.Framework;
using NetCoreTestProjectKinopoisk.Pages;

namespace NetCoreTestProjectKinopoisk.Tests
{
    public class SearchTest : BaseTest
    {
        private string _filmName = TestSettings.FilmName;
        private string _expectedUrl = TestSettings.GirlfriendExperiencePage;
        private string _filmYear = "2009";
        private string _filmGenre = "драма";

        [SetUp]
        public void TestPreparation()
        {
            _driver = DriverSingleton.getInstance().getDriver();
            _girlfriendExperiencePage = new GirlfriendExperiencePage(_driver);
            _extendedSearchPage = new ExtendedSearchPage(_driver);
            _mainPage = new MainPage(_driver);
        }

        [Test]
        public void SearchingTest()
        {
            _mainPage.Open();
            _mainPage.SearchFilm(_filmName);
            Assert.AreEqual(_expectedUrl, _driver.Url);
        }

        [Test]
        public void SearchingWithFiltersTest()
        {
            _extendedSearchPage.Open();
            _extendedSearchPage.EnterFilmName(_filmName);
            _extendedSearchPage.EnterFilmYear(_filmYear);
            _extendedSearchPage.ChooseFilmGenre(_filmGenre);
            _extendedSearchPage.PressSearchButton();
            Assert.AreEqual(_expectedUrl, _driver.Url);
        }
    }
}
