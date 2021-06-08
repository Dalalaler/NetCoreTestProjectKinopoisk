using Constants;
using Driver;
using NUnit.Framework;
using Pages;
using Utils;

namespace Tests
{
    public class AddingTest : BaseTest
    {
        private string _filmName = TestSettings.FilmName;
        private string _russianFilmName = "Девушка по вызову";

        [SetUp]
        public void TestPreparation()
        {
            _driver = DriverFactory.GetDriver(Enums.DriverNames.CHROME);
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
            _mainPage.SearchFilm(_filmName);
            _girlfriendExperiencePage.OpenList();
            _girlfriendExperiencePage.AddToFavorite();
            _favoriteFilmsPage.Open();
            Assert.AreEqual(_favoriteFilmsPage.GetFavoriteFilmName(), _russianFilmName);
        }
    }
}
