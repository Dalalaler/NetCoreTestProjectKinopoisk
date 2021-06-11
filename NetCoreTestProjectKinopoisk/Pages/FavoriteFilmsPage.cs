using NetCoreTestProjectKinopoisk.Constants;
using OpenQA.Selenium;

namespace NetCoreTestProjectKinopoisk.Pages
{
    public class FavoriteFilmsPage : AbstractPage
    {
        private string _pageUrl = TestSettings.FavoritePageUrl;
        private By _favoriteFilmName = By.XPath("//div[@class=\"info\"]//a[@href=\"/film/415616/\"]");

        public FavoriteFilmsPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open()
        {
            Driver.Url = _pageUrl;
        }

        public string GetFavoriteFilmName()
        {
            return Driver.FindElement(_favoriteFilmName).Text;
        }
    }
}
