using NetCoreTestProjectKinopoisk.Pages;
using NUnit.Framework;

namespace NetCoreTestProjectKinopoisk.Tests
{
    class AddingTest : BasicTest
    {
        private string filmName = "Girlfriend Experience, The 2009";

        [SetUp]
        public void TestPreparation()
        {
            mainPage = new MainPage(driver);
            passportPage = new PassportPage(driver);
            girlfriendExperiencePage = new GirlfriendExperiencePage(driver);
            mainPage.Open();
        }

        [Test]
        public void ViewedAddingTest()
        {
            LoginTest loginTest = new LoginTest();
            loginTest.SuccessfulLoginTest();
            mainPage.SearchFilm(filmName);
            Assert.True(girlfriendExperiencePage.pressMarkAsViewedButton());
        }

        [Test]
        public void FavoriteAddingTest()
        {
            LoginTest loginTest = new LoginTest();
            loginTest.SuccessfulLoginTest();
            mainPage.SearchFilm(filmName);
            girlfriendExperiencePage.openList();
            Assert.True(girlfriendExperiencePage.addToFavorite());
        }
    }
}
