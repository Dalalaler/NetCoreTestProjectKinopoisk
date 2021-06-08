using Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public class ExtendedSearchPage : AbstractPage
    {
        private string _pageUrl = TestSettings.ExtendedPageUrl;
        private By _filmName = By.XPath("//input[@id=\"find_film\"]");
        private By _filmYear = By.XPath("//input[@id=\"year\"]");
        private By _filmGenre = By.XPath("//select[@id=\"m_act[genre]\"]");
        private By _searchButton = By.XPath("//input[@class=\"el_18 submit nice_button\"]");

        public ExtendedSearchPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open()
        {
            Driver.Url = _pageUrl;
        }

        public void EnterFilmName(string film)
        {
            Driver.FindElement(_filmName).SendKeys(film);
        }

        public void EnterFilmYear(string year)
        {
            Driver.FindElement(_filmYear).SendKeys(year);
        }

        public void ChooseFilmGenre(string genre)
        {
            SelectElement selectElement = new SelectElement(Driver.FindElement(_filmGenre));
            selectElement.SelectByText(genre);
        }

        public void PressSearchButton()
        {
            Driver.FindElement(_searchButton).Click();
        }
    }
}
