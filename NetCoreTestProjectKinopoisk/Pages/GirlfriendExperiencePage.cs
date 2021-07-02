using NetCoreTestProjectKinopoisk.Constants;
using NetCoreTestProjectKinopoisk.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace NetCoreTestProjectKinopoisk.Pages
{
    public class GirlfriendExperiencePage : AbstractPage
    {
        private string _pageUrl = TestSettings.GirlfriendExperiencePage;
        private By _trailerPlayButton = By.XPath("//button[.=\"Трейлер\"]/..");
        private By _markAsViewedButton = By.XPath("//label[.='Любимые фильмы']");
        private By _openListButton = By.XPath("//button[@class='styles_button__VDRar styles_root__2xv1d styles_rootDark__2mnS3 styles_root__3_KIA styles_rootDark__3Jeum styles_rootGhost__1llle']");
        private By _markAsFavorite = By.XPath("//label[.='Любимые фильмы']");
        private By _addedToFavoritePopupText = By.XPath("//div[@class='styles_content__cGNhr']");
        private By _markAsFavoriteMarker = By.XPath("//div[@class='styles_userFolders__obqzA']");
        private By _markAsFavoriteMarker2 = By.XPath("//div[@class='styles_root__1yCWt styles_notifyTooltip__2C-Y4']");
        private By _playerCloseButton = By.XPath("//button[@class=\"discovery-trailers-closer\"]");
        private By _willWatchButton = By.XPath("//button[.=\"Буду смотреть\"]");
        private By _haveBeenAddedToFavoriteMarker = By.XPath("//div[@class=\"styles_userFolders__obqzA\"]");
        private By _isAbleToClickSkipMarker = By.XPath("//div[@class=\"blDjN9gl Wmiw YprJ5 yiTpeB GSm1DEUj oVy8gO59HC\"]");
        private By _skipAddButton = By.XPath("/html/body/div/div/div[3]/div/div[1]/div[2]/div/div[2]/div/div/div/div");
        private By _trailerIframe = By.XPath("//iframe[@class=\"discovery-trailers-iframe\"]");
        private By _trailerIframe2 = By.XPath("//div[@id=\"player\"]//iframe");
        private By _playButton = By.XPath("//button[@data-control-name=\"play\"]");
        private By _svgPicturesXPath = By.XPath("//*[name()='svg']/*[name()='path']");

        public GirlfriendExperiencePage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open()
        {
            Driver.Url = _pageUrl;
        }

        public void OpenList()
        {
            //IWebElement openListButton = Driver.FindElement(_openListButton);
            //Actions actions = new Actions(Driver);
            //actions.MoveToElement(openListButton).Build().Perform();
            Driver.FindElement(_openListButton).Click();
            //Thread.Sleep(3000);
        }

        public void AddToFavorite()
        {
            //IWebElement addToFavoriteButton = Driver.FindElement(_markAsFavorite);
            //Actions actions = new Actions(Driver);
            //actions.MoveToElement(addToFavoriteButton).Build().Perform();

            //actions.MoveToElement(addToFavoriteButton).Click();
            //Thread.Sleep(3000);
            Driver.FindElement(_markAsFavorite).Click();
            WebDriverWait wait;
            wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));           
            wait.Until(driver => !driver.FindElement(_addedToFavoritePopupText).Displayed);
            //Thread.Sleep(3000);
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

        public void SkipAdds()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(_trailerIframe));
            Driver.SwitchTo().Frame(Driver.FindElement(_trailerIframe2));
            IWebElement skip;
            WebDriverWait wait;
            wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));
            wait.Until(driver => driver.FindElements(_svgPicturesXPath).Count == 2);
            skip = FindElementWithTimer.FindElement(Driver, _skipAddButton, 10);
            skip.Click();
            wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));
            wait.Until(driver => driver.FindElements(_svgPicturesXPath).Count == 2);
            skip = FindElementWithTimer.FindElement(Driver, _skipAddButton, 10);
            skip.Click();
        }

        public void PressPlayButton()
        {
            IWebElement play;
            Driver.SwitchTo().ParentFrame();
            play = FindElementWithTimer.FindElement(Driver, _playButton, 20);
            Actions actions = new Actions(Driver);
            actions.MoveToElement(play).Build().Perform();
            var wait2 = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));
            var element = wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_playButton));
            play.Click();
        }
    }
}
