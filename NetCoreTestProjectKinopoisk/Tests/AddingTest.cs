using NetCoreTestProjectKinopoisk.Constants;
using NetCoreTestProjectKinopoisk.Driver;
using NUnit.Framework;
using NetCoreTestProjectKinopoisk.Pages;
using NetCoreTestProjectKinopoisk.Utils;

namespace NetCoreTestProjectKinopoisk.Tests
{
    public class AddingTest : BaseTest
    {
        private string _filmName = TestSettings.FilmName;
        private string _russianFilmName = "Девушка по вызову";

        [SetUp]
        public void TestPreparation()
        {
            //_driver = DriverSingleton.getInstance().getDriver();
            _mainPage = new MainPage(_driver);
            _passportPage = new PassportPage(_driver);
            _girlfriendExperiencePage = new GirlfriendExperiencePage(_driver);
            _favoriteFilmsPage = new FavoriteFilmsPage(_driver);
            _mainPage.Open();
        }

        [Test]
        public void FavoriteAddingTest()
        {
            LoginUtil.SuccessfulLogin(_driver, _mainPage, _passportPage);
            _favoriteFilmsPage.Open();
            _favoriteFilmsPage.ClearFavoriteFilmsList();
            _mainPage.SearchFilm(_filmName);
            _girlfriendExperiencePage.OpenList();
            _girlfriendExperiencePage.AddToFavorite();
            _girlfriendExperiencePage.OpenList();
            _favoriteFilmsPage.Open();
            Assert.AreEqual(_favoriteFilmsPage.GetFavoriteFilmName(), _russianFilmName);
        }
    }
}
