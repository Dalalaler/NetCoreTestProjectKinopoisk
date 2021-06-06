using NetCoreTestProjectKinopoisk.Pages;
using NUnit.Framework;
using System.Threading;

namespace NetCoreTestProjectKinopoisk.Tests
{
    [TestFixture]
    public class LoginTest : BasicTest
    {
        private string login = "fakemail4tests";
        private string password = "stWgvP9WiafjNJ2";

        private string wrongLogin = "wrongfakemail4tests";
        private string wrongPassword = "wrongstWgvP9WiafjNJ2";

        private string loginErrorMessage = "Такого аккаунта нет";
        private string passwordErrorMessage = "Неверный пароль";

        [SetUp]
        public void TestPreparation()
        {
            mainPage = new MainPage(driver);
            passportPage = new PassportPage(driver);
            mainPage.Open();
        }

        [Test]
        public void SuccessfulLoginTest()
        {
            mainPage.PressEnterButton();
            passportPage.EnterLogin(login);
            passportPage.PressEnterButton();
            passportPage.EnterPassword(password);
            passportPage.PressEnterButton();

            Assert.True(mainPage.IsEnabledExitButton());
        }

        [Test]
        public void UnsuccessfulLoginTest()
        {
            mainPage.PressEnterButton();

            passportPage.EnterLogin(wrongLogin);
            passportPage.PressEnterButton();

            Assert.AreEqual(passportPage.GetErrorMessage(), loginErrorMessage);

            passportPage.ClearLogin();

            passportPage.EnterLogin(login);
            passportPage.PressEnterButton();

            passportPage.EnterPassword(wrongPassword);
            passportPage.PressEnterButton();

            Thread.Sleep(1000);
            Assert.AreEqual(passportPage.GetErrorMessage(), passwordErrorMessage);
        }

        [Test]
        public void LogoutTest()
        {
            SuccessfulLoginTest();
            mainPage.PressAvatarButtin();
            mainPage.PressExitButton();

            Assert.True(mainPage.IsEnabledEnterButton());
        }
    }
}
