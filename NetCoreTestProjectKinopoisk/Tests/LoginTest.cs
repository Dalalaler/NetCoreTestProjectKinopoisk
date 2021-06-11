using NetCoreTestProjectKinopoisk.Constants;
using NetCoreTestProjectKinopoisk.Driver;
using NUnit.Framework;
using NetCoreTestProjectKinopoisk.Pages;
using NetCoreTestProjectKinopoisk.Utils;

namespace NetCoreTestProjectKinopoisk.Tests
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        private string _login = TestSettings.Login;
        private string _password = TestSettings.Password;
        private string _wrongLogin = "wronglogin" + TestSettings.Login;
        private string _wrongPassword = "wrongpass" + TestSettings.Password;
        private string _loginErrorMessage = "Такого аккаунта нет";
        private string _passwordErrorMessage = "Неверный пароль";

        [SetUp]
        public void TestPreparation()
        {
            _driver = DriverSingleton.getInstance().getDriver();
            _mainPage = new MainPage(_driver);
            _passportPage = new PassportPage(_driver);
            _mainPage.Open();
        }

        [Test]
        public void SuccessfulLoginTest()
        {
            LoginUtil.SuccessfulLogin(_driver, _mainPage, _passportPage);
            Assert.True(_mainPage.IsEnabledExitButton());
        }

        [Test]
        public void UnsuccessfulLoginTest()
        {
            _mainPage.Open();
            _mainPage.PressEnterButton();
            _passportPage.EnterLogin(_wrongLogin);
            _passportPage.PressEnterButton();
            Assert.AreEqual(_passportPage.GetErrorMessage(), _loginErrorMessage);
            _passportPage.ClearLogin();
            _passportPage.EnterLogin(_login);
            _passportPage.PressEnterButton();
            _passportPage.EnterPassword(_wrongPassword);
            _passportPage.PressEnterButton();
            Assert.AreEqual(_passportPage.GetErrorMessage(), _passwordErrorMessage);
        }

        [Test]
        public void LogoutTest()
        {
            SuccessfulLoginTest();
            _mainPage.PressAvatarButtin();
            _mainPage.PressExitButton();
            Assert.True(_mainPage.IsEnabledEnterButton());
        }
    }
}
