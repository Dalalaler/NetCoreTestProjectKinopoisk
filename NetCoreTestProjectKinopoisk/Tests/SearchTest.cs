using NetCoreTestProjectKinopoisk.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreTestProjectKinopoisk.Tests
{
    class SearchTest : BasicTest
    {
        private string filmName = "Girlfriend Experience, The 2009";
        private string expectedUrl = "https://www.kinopoisk.ru/film/415616/";
        private string filmYear = "2009";
        private string filmGenre = "драма";

        [SetUp]
        public void TestPreparation()
        {            
            girlfriendExperiencePage = new GirlfriendExperiencePage(driver);
            extendedSearchPage = new ExtendedSearchPage(driver);
            mainPage = new MainPage(driver);
        }

        [Test]
        public void SearchingTest()
        {
            mainPage.Open();
            mainPage.SearchFilm(filmName);
            Assert.AreEqual(expectedUrl, driver.Url);
        }

        [Test]
        public void SearchingWithFiltersTest()
        {
            extendedSearchPage.Open();
            extendedSearchPage.enterFilmName(filmName);
            extendedSearchPage.enterFilmYear(filmYear);
            extendedSearchPage.chooseFilmGenre(filmGenre);
            extendedSearchPage.pressSearchButton();
            Assert.AreEqual(expectedUrl, driver.Url);
        }
    }
}
