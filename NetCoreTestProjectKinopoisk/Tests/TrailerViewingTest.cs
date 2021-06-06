using NetCoreTestProjectKinopoisk.Pages;
using NUnit.Framework;

namespace NetCoreTestProjectKinopoisk.Tests
{
    class TrailerViewingTest : BasicTest
    {
        private string filmName = "Girlfriend Experience, The 2009";

        [SetUp]
        public void TestPreparation()
        {
            mainPage = new MainPage(driver);
            girlfriendExperiencePage = new GirlfriendExperiencePage(driver);
            mainPage.Open();
        }

        [Test]
        public void TrailerViewing()
        {
            mainPage.SearchFilm(filmName);
            Assert.True(girlfriendExperiencePage.playTrailer());
        }
    }
}
