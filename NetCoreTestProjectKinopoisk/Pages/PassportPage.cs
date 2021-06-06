using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace NetCoreTestProjectKinopoisk.Pages
{
    public class PassportPage : AbstractPage
    {
        private string passportPageUrl = "https://passport.yandex.ru/";

        private By enterButton = By.XPath("//div[@class=\"passp-button passp-sign-in-button\"]/button");
        private By loginInput = By.XPath("//input[@id=\"passp-field-login\"]");
        private By passwordInput = By.XPath("//input[@id=\"passp-field-passwd\"]");
        private By errorMessage = By.XPath("//div[@class=\"Textinput-Hint Textinput-Hint_state_error\"]");

        public PassportPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterLogin(string login)
        {
            driver.FindElement(loginInput).SendKeys(login);
        }

        public void ClearLogin()
        {
            driver.FindElement(loginInput).SendKeys(Keys.Control + "a");
            driver.FindElement(loginInput).SendKeys(Keys.Delete);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(passwordInput).SendKeys(password);
        }

        public void ClearPassword()
        {
            driver.FindElement(passwordInput).SendKeys(Keys.Control + "a");
            driver.FindElement(passwordInput).SendKeys(Keys.Delete);
        }

        public void PressEnterButton()
        {
            driver.FindElement(enterButton).Click();
        }

        public string GetErrorMessage()
        {
            IWebElement errorField = driver.FindElement(errorMessage);
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(errorField);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromMilliseconds(1000);

            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                String error = errorField.Text;
                if (error.Length > 0)
                {
                    return true;
                }
                return false;
            });

            wait.Until(waiter);

            return driver.FindElement(errorMessage).Text;
        }

        public override void Open()
        {
            driver.Url = passportPageUrl;
        }
    }
}
