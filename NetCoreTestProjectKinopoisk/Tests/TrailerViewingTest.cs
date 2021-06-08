using Constants;
using Driver;
using NUnit.Framework;
using Pages;

namespace Tests
{
    public class TrailerViewingTest : BaseTest
    {
        private string _filmName = TestSettings.FilmName;

        [SetUp]
        public void TestPreparation()
        {
            _driver = DriverFactory.GetDriver(Enums.DriverNames.CHROME);
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
