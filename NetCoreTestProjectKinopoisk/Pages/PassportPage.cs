using Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages
{
    public class PassportPage : AbstractPage
    {
        private string _passportPageUrl = TestSettings.PassportPageUrl;
        private By _enterButton = By.XPath("//div[@class=\"passp-button passp-sign-in-button\"]/button");
        private By _loginInput = By.XPath("//input[@id=\"passp-field-login\"]");
        private By _passwordInput = By.XPath("//input[@id=\"passp-field-passwd\"]");
        private By _errorMessage = By.XPath("//div[@class=\"Textinput-Hint Textinput-Hint_state_error\"]");

        public PassportPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterLogin(string login)
        {
            Driver.FindElement(_loginInput).SendKeys(login);
        }

        public void ClearLogin()
        {
            Driver.FindElement(_loginInput).SendKeys(Keys.Control + "a");
            Driver.FindElement(_loginInput).SendKeys(Keys.Delete);
        }

        public void EnterPassword(string password)
        {
            Driver.FindElement(_passwordInput).SendKeys(password);
        }

        public void ClearPassword()
        {
            Driver.FindElement(_passwordInput).SendKeys(Keys.Control + "a");
            Driver.FindElement(_passwordInput).SendKeys(Keys.Delete);
        }

        public void PressEnterButton()
        {
            Driver.FindElement(_enterButton).Click();
        }

        public string GetErrorMessage()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(new Type[] { typeof(NoSuchElementException), typeof(StaleElementReferenceException) });
            string result = null;
            wait.Until(drv =>
            {
                result = drv.FindElement(_errorMessage).Text;

                return result.Length > 0;
            });

            return result;
        }

        public override void Open()
        {
            Driver.Url = _passportPageUrl;
        }
    }
}
