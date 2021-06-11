using NetCoreTestProjectKinopoisk.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NetCoreTestProjectKinopoisk.Pages;
using System;

namespace NetCoreTestProjectKinopoisk.Utils
{
    public class LoginUtil
    {
        private static string _login = TestSettings.Login;
        private static string _password = TestSettings.Password;

        public static bool SuccessfulLogin(IWebDriver driver, MainPage mainPage, PassportPage passportPage)
        {
            mainPage.Open();
            mainPage.PressEnterButton();
            passportPage.EnterLogin(_login);
            passportPage.PressEnterButton();
            passportPage.EnterPassword(_password);
            passportPage.PressEnterButton();

            WebDriverWait wait;
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(driver => mainPage.IsEnabledExitButton());

            return mainPage.IsEnabledExitButton();
        }
    }
}
