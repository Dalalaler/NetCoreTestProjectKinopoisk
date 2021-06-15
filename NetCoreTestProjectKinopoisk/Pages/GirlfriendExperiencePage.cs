using NetCoreTestProjectKinopoisk.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

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
        private By _skipAddButton = By.XPath("//div[@class=\"yKZt\"]");
        private By _playButton = By.XPath("//button[@data-control-name=\"play\"]");
        private By _isAbleToClickSkipMarker = By.XPath("//div[@class=\"blDjN9gl Wmiw YprJ5 yiTpeB GSm1DEUj oVy8gO59HC\"]");

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
            else
            {
                Driver.FindElement(_markAsFavorite).Click();
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

        public void SkipAdds(int addsCount)
        {            
                WebDriverWait wait;
                wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                wait.Until(Driver => Driver.FindElements(_isAbleToClickSkipMarker).Count > 0);
                Driver.FindElements(_skipAddButton)[2].Click();            
            
        }

        public bool IsSkipButtonEnabled()
        {
            bool result = false;
            try
            {
                result = Driver.FindElement(_isAbleToClickSkipMarker).Displayed;
            } catch (Exception e)
            {

            }
            return result;
            
        }

        public void ClickPlayButton()
        {
            
                Driver.FindElement(_playButton).Click();
           
        }

        public void ClickSkipButton()
        {
            WebDriverWait wait;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(Driver => Driver.FindElements(_skipAddButton).Count > 0);
            Console.WriteLine("Skip button is anebled now");
            Driver.FindElement(_skipAddButton).Click();
        }

        public void WaitForPauseButton()
        {
            WebDriverWait wait;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(90));
            wait.Until(driver => driver.FindElements(_playButton).Count > 0);
        }
    }
}
