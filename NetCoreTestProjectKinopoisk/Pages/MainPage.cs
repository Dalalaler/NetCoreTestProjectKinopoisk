using OpenQA.Selenium;

namespace NetCoreTestProjectKinopoisk.Pages
{
    public class MainPage : AbstractPage
    {
        private string mainPageUrl = "https://www.kinopoisk.ru/";
        private By enterButton = By.XPath("//button[.=\"Войти\"]");
        private By exitButton = By.XPath("//button[.=\"Выйти\"]");
        private By avatarButton = By.XPath("//button[@class=\"_1yTvXZeNVzDgKDsQHyALNZ\"]");
        private By filmSearchInput = By.XPath("//input[@name=\"kp_query\"]");

        public void SearchFilm(string filmName)
        {
            driver.FindElement(filmSearchInput).SendKeys(filmName + Keys.Enter);
        }

        public void PressAvatarButtin()
        {
            driver.FindElement(avatarButton).Click();
        }

        public void PressEnterButton()
        {
            driver.FindElement(enterButton).Click();
        }

        public void PressExitButton()
        {
            driver.FindElement(exitButton).Click();
        }

        public bool IsEnabledExitButton()
        {
            return driver.FindElement(exitButton).Enabled;
        }

        public bool IsEnabledEnterButton()
        {
            return driver.FindElement(enterButton).Enabled;
        }

        public MainPage(IWebDriver driver) : base(driver)
        {
        }
        public override void Open()
        {
            driver.Url = mainPageUrl;
        }
    }
}
