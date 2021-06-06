using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NetCoreTestProjectKinopoisk.Pages
{
    public class ExtendedSearchPage : AbstractPage
    {
        private string pageUrl = "https://www.kinopoisk.ru/s/";
        private By filmName = By.XPath("//input[@id=\"find_film\"]");
        private By filmYear = By.XPath("//input[@id=\"year\"]");
        private By filmGenre = By.XPath("//select[@id=\"m_act[genre]\"]");
        private By searchButton = By.XPath("//input[@class=\"el_18 submit nice_button\"]");

        public ExtendedSearchPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open()
        {
            driver.Url = pageUrl;
        }

        public void enterFilmName(string film)
        {
            driver.FindElement(filmName).SendKeys(film);
        }

        public void enterFilmYear(string year)
        {
            driver.FindElement(filmYear).SendKeys(year);
        }

        public void chooseFilmGenre(string genre)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(filmGenre));
            selectElement.SelectByText(genre);
        }

        public void pressSearchButton()
        {
            driver.FindElement(searchButton).Click();
        }
    }
}
