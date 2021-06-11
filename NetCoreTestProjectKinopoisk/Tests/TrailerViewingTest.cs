using NetCoreTestProjectKinopoisk.Constants;
using NetCoreTestProjectKinopoisk.Driver;
using NUnit.Framework;
using NetCoreTestProjectKinopoisk.Pages;

namespace NetCoreTestProjectKinopoisk.Tests
{
    public class TrailerViewingTest : BaseTest
    {
        private string _filmName = TestSettings.FilmName;

        [SetUp]
        public void TestPreparation()
        {
            _driver = DriverSingleton.getInstance().getDriver();
            _mainPage = new MainPage(_driver);
            _girlfriendExperiencePage = new GirlfriendExperiencePage(_driver);
            _mainPage.Open();
        }

        [Test]
        public void TrailerViewing()
        {
            _mainPage.SearchFilm(_filmName);
            _girlfriendExperiencePage.PlayTrailer();
            Assert.True(_girlfriendExperiencePage.IsEnabledAndDisplayedClosePlayer());
        }
    }
}
