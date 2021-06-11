using NetCoreTestProjectKinopoisk.Constants;
using OpenQA.Selenium;

namespace NetCoreTestProjectKinopoisk.Pages
{
    public class MainPage : AbstractPage
    {
        private string _mainPageUrl = TestSettings.MainPageUrl;
        private By _enterButton = By.XPath("//button[.=\"Войти\"]");
        private By _exitButton = By.XPath("//button[.=\"Выйти\"]");
        private By _avatarButton = By.XPath("//button[@class=\"_1yTvXZeNVzDgKDsQHyALNZ\"]");
        private By _filmSearchInput = By.XPath("//input[@name=\"kp_query\"]");

        public void SearchFilm(string filmName)
        {
            Driver.FindElement(_filmSearchInput).SendKeys(filmName + Keys.Enter);
        }

        public void PressAvatarButtin()
        {
            Driver.FindElement(_avatarButton).Click();
        }

        public void PressEnterButton()
        {
            Driver.FindElement(_enterButton).Click();
        }

        public void PressExitButton()
        {
            Driver.FindElement(_exitButton).Click();
        }

        public bool IsEnabledExitButton()
        {
            return Driver.FindElement(_exitButton).Enabled;
        }

        public bool IsEnabledEnterButton()
        {
            return Driver.FindElement(_enterButton).Enabled;
        }

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open()
        {
            Driver.Url = _mainPageUrl;
        }
    }
}
