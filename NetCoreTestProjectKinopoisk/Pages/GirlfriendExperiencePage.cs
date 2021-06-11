using NetCoreTestProjectKinopoisk.Constants;
using OpenQA.Selenium;

namespace NetCoreTestProjectKinopoisk.Pages
{
    public class GirlfriendExperiencePage : AbstractPage
    {
        private string _pageUrl = TestSettings.GirlfriendExperiencePage;
        private By _trailerPlayButton = By.XPath("//button[.=\"Трейлер\"]/..");
        private By _markAsViewedButton = By.XPath("//span[.=\"Отметить просмотренным\"]/ancestor::button");
        private By _openListButton = By.XPath("//span[.=\"Добавить в список\"]/ancestor::button");
        private By _markAsFavorite = By.XPath("//span[.=\"Любимые фильмы\"]/..");
        private By _playerCloseButton = By.XPath("//button[@class=\"discovery-trailers-closer\"]");
        private By _willWatchButton = By.XPath("//button[.=\"Буду смотреть\"]");
        private By _haveBeenAddedToFavoriteMarker = By.XPath("//div[@class=\"styles_userFolders__obqzA\"]");

        public GirlfriendExperiencePage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open()
        {
            Driver.Url = _pageUrl;
        }

        public void OpenList()
        {
            Driver.FindElement(_openListButton).Click();
        }

        public void AddToFavorite()
        {
            bool isFilmAlreadyAdded = Driver.FindElement(_haveBeenAddedToFavoriteMarker).Displayed;
            if (!isFilmAlreadyAdded)
            {
                Driver.FindElement(_markAsFavorite).Click();
            }           
        }

        public bool PressMarkAsViewedButton()
        {
            if (Driver.FindElement(_markAsViewedButton).Enabled)
            {
                Driver.FindElement(_markAsViewedButton).Click();
                return true;
            }
            return false;
        }

        public bool PlayTrailer()
        {
            if (Driver.FindElement(_trailerPlayButton).Displayed)
            {
                Driver.FindElement(_trailerPlayButton).Click();
                return true;
            }
            return false;
        }

        public bool IsEnabledAndDisplayedClosePlayer()
        {
            return (Driver.FindElement(_playerCloseButton).Enabled && Driver.FindElement(_playerCloseButton).Displayed);
        }
    }
}
