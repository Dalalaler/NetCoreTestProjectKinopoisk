using NetCoreTestProjectKinopoisk.Constants;
using OpenQA.Selenium;
using System;

namespace NetCoreTestProjectKinopoisk.Pages
{
    public class FavoriteFilmsPage : AbstractPage
    {
        private string _pageUrl = TestSettings.FavoritePageUrl;
        private By _favoriteFilmName = By.XPath("//div[@class=\"info\"]//a[@href=\"/film/415616/\"]");
        private By _selectAll = By.XPath("//input[@id='selectAllbox']");
        private By _deleteSelectedFilms = By.XPath("//input[@id='delete_selected']");

        public FavoriteFilmsPage(IWebDriver driver) : base(driver)
        {
        }


        public override void Open()
        {
            Driver.Url = _pageUrl;
        }

        public virtual void ClearFavoriteFilmsList()
        {
            try
            {
                if (Driver.FindElement(_selectAll).Displayed)
                {
                    Driver.FindElement(_selectAll).Click();
                    Driver.FindElement(_deleteSelectedFilms).Click();
                    Driver.SwitchTo().Alert().Accept();
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public string GetFavoriteFilmName()
        {
            return Driver.FindElement(_favoriteFilmName).Text;
        }
    }
}
