using OpenQA.Selenium;

namespace NetCoreTestProjectKinopoisk.Pages
{
    public class GirlfriendExperiencePage : AbstractPage
    {
        private string pageUrl = "https://www.kinopoisk.ru/film/415616/";
        private By trailerPlayButton = By.XPath("//button[.=\"Трейлер\"]/..");
        private By markAsViewedButton = By.XPath("//span[.=\"Отметить просмотренным\"]/ancestor::button");
        private By openListButton = By.XPath("//span[.=\"Добавить в список\"]/ancestor::button");
        private By markAsFavorite = By.XPath("//span[.=\"Любимые фильмы\"]/..");

        public GirlfriendExperiencePage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open()
        {
            driver.Url = pageUrl;
        }

        public void openList()
        {
            driver.FindElement(openListButton).Click();
        }

        public bool addToFavorite()
        {
            if (driver.FindElement(markAsFavorite).Enabled)
            {
                driver.FindElement(markAsFavorite).Click();
                return true;
            }
            return false;
        }

        public bool pressMarkAsViewedButton()
        {
            if (driver.FindElement(markAsViewedButton).Enabled)
            {
                driver.FindElement(markAsViewedButton).Click();
                return true;
            }
            return false;
        }

        public bool playTrailer()
        {
            if (driver.FindElement(trailerPlayButton).Displayed)
            {
                driver.FindElement(trailerPlayButton).Click();
                return true;
            }
            return false;
        }
    }
}
