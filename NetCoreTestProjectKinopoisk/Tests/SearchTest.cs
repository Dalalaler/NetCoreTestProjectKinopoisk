using NetCoreTestProjectKinopoisk.Constants;
using NetCoreTestProjectKinopoisk.Driver;
using NUnit.Framework;
using NetCoreTestProjectKinopoisk.Pages;
using OpenQA.Selenium;

namespace NetCoreTestProjectKinopoisk.Tests
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.Children)]
    public class SearchTest : Hooks
    {
        private string _filmName = TestSettings.FilmName;
        private string _expectedUrl = TestSettings.GirlfriendExperiencePage;
        private string _filmYear = "2009";
        private string _filmGenre = "драма";


        //[OneTimeSetUp]
        //public void DriverPreparation()
        //{
        //    _driver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);      
        //}

        //[OneTimeTearDown]
        //public void QuitDriver()
        //{
        //    _driver.Quit();
        //}

        [SetUp]
        public void TestPreparation()
        {
            //_driver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
            //_girlfriendExperiencePage = new GirlfriendExperiencePage(_driver);
            //_extendedSearchPage = new ExtendedSearchPage(_driver);
            //_mainPage = new MainPage(_driver);
        }

        [TearDown]
        public void DriverCleaning()
        {
            //_driver.Manage().Cookies.DeleteAllCookies();
            //_driver.Quit();
        }

        [Test]
        public void SearchingTest1()
        {
            IWebDriver driver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
            MainPage mainPage = new MainPage(driver);
            mainPage.Open();
            mainPage.SearchFilm(_filmName);
            Assert.AreEqual(_expectedUrl, driver.Url);
            driver.Quit();
        }

        [Test]
        public void SearchingTest2()
        {
            IWebDriver driver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
            MainPage mainPage = new MainPage(driver);
            mainPage.Open();
            mainPage.SearchFilm(_filmName);
            Assert.AreEqual(_expectedUrl, driver.Url);
            driver.Quit();
        }

        [Test]
        public void SearchingTest3()
        {
            IWebDriver driver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
            MainPage mainPage = new MainPage(driver);
            mainPage.Open();
            mainPage.SearchFilm(_filmName);
            Assert.AreEqual(_expectedUrl, driver.Url);
            driver.Quit();
        }

        [Test]
        public void SearchingTest4()
        {
            IWebDriver driver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
            MainPage mainPage = new MainPage(driver);
            mainPage.Open();
            mainPage.SearchFilm(_filmName);
            Assert.AreEqual(_expectedUrl, driver.Url);
            driver.Quit();
        }

        [Test]
        public void SearchingTest5()
        {
            IWebDriver driver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
            MainPage mainPage = new MainPage(driver);
            mainPage.Open();
            mainPage.SearchFilm(_filmName);
            Assert.AreEqual(_expectedUrl, driver.Url);
            driver.Quit();
        }



        [Test]
        public void SearchingWithFiltersTest1()
        {
            IWebDriver driver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
            ExtendedSearchPage extendedSearchPage = new ExtendedSearchPage(driver);
            extendedSearchPage.Open();
            extendedSearchPage.EnterFilmName(_filmName);
            extendedSearchPage.EnterFilmYear(_filmYear);
            extendedSearchPage.ChooseFilmGenre(_filmGenre);
            extendedSearchPage.PressSearchButton();
            Assert.AreEqual(_expectedUrl, driver.Url);
            driver.Quit();
        }

        [Test]
        public void SearchingWithFiltersTest2()
        {
            IWebDriver driver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
            ExtendedSearchPage extendedSearchPage = new ExtendedSearchPage(driver);
            extendedSearchPage.Open();
            extendedSearchPage.EnterFilmName(_filmName);
            extendedSearchPage.EnterFilmYear(_filmYear);
            extendedSearchPage.ChooseFilmGenre(_filmGenre);
            extendedSearchPage.PressSearchButton();
            Assert.AreEqual(_expectedUrl, driver.Url);
            driver.Quit();
        }

        [Test]
        public void SearchingWithFiltersTest3()
        {
            IWebDriver driver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
            ExtendedSearchPage extendedSearchPage = new ExtendedSearchPage(driver);
            extendedSearchPage.Open();
            extendedSearchPage.EnterFilmName(_filmName);
            extendedSearchPage.EnterFilmYear(_filmYear);
            extendedSearchPage.ChooseFilmGenre(_filmGenre);
            extendedSearchPage.PressSearchButton();
            Assert.AreEqual(_expectedUrl, driver.Url);
            driver.Quit();
        }

        [Test]
        public void SearchingWithFiltersTest4()
        {
            IWebDriver driver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
            ExtendedSearchPage extendedSearchPage = new ExtendedSearchPage(driver);
            extendedSearchPage.Open();
            extendedSearchPage.EnterFilmName(_filmName);
            extendedSearchPage.EnterFilmYear(_filmYear);
            extendedSearchPage.ChooseFilmGenre(_filmGenre);
            extendedSearchPage.PressSearchButton();
            Assert.AreEqual(_expectedUrl, driver.Url);
            driver.Quit();
        }

        [Test]
        public void SearchingWithFiltersTest5()
        {
            IWebDriver driver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
            ExtendedSearchPage extendedSearchPage = new ExtendedSearchPage(driver);
            extendedSearchPage.Open();
            extendedSearchPage.EnterFilmName(_filmName);
            extendedSearchPage.EnterFilmYear(_filmYear);
            extendedSearchPage.ChooseFilmGenre(_filmGenre);
            extendedSearchPage.PressSearchButton();
            Assert.AreEqual(_expectedUrl, driver.Url);
            driver.Quit();
        }
    }
}
