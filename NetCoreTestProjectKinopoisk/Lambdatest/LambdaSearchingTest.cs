using NetCoreTestProjectKinopoisk.Constants;
using NetCoreTestProjectKinopoisk.Driver;
using NetCoreTestProjectKinopoisk.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreTestProjectKinopoisk.Lambdatest
{
    [TestFixture("chrome", "60", "Windows 10")]
    [TestFixture("internet explorer", "11", "Windows 10")]
    [TestFixture("firefox", "60", "Windows 7")]
    class LambdaSearchingTest : LambdaBaseTest
    {
        public LambdaSearchingTest(string browser, string version, string os) : base(browser, version, os)
        {
        }

        private string _filmName = TestSettings.FilmName;
        private string _expectedUrl = TestSettings.GirlfriendExperiencePage;
        private string _filmYear = "2009";
        private string _filmGenre = "драма";      

        [Test]
        public void SearchingTest1()
        {           
            MainPage mainPage = new MainPage(driver.Value);
            mainPage.Open();
            mainPage.SearchFilm(_filmName);
            Assert.AreEqual(_expectedUrl, driver.Value .Url);
            driver.Value.Quit();
        }        

        [Test]
        public void SearchingWithFiltersTest5()
        {         
            ExtendedSearchPage extendedSearchPage = new ExtendedSearchPage(driver.Value);
            extendedSearchPage.Open();
            extendedSearchPage.EnterFilmName(_filmName);
            extendedSearchPage.EnterFilmYear(_filmYear);
            extendedSearchPage.ChooseFilmGenre(_filmGenre);
            extendedSearchPage.PressSearchButton();
            Assert.AreEqual(_expectedUrl, driver.Value.Url);
            driver.Value.Quit();
        }
    }
}
