using NetCoreTestProjectKinopoisk.Constants;
using NetCoreTestProjectKinopoisk.Driver;
using NUnit.Framework;
using NetCoreTestProjectKinopoisk.Pages;
using NetCoreTestProjectKinopoisk.Utils;

namespace NetCoreTestProjectKinopoisk.Tests
{
    public class ProfileSettingsTest : BaseTest
    {
        private string _name = TestSettings.UserName;
        private string _secondName = TestSettings.UserSecondName;

        [SetUp]
        public void TestPreparation()
        {
            _driver = DriverSingleton.getInstance().getDriver();
            _mainPage = new MainPage(_driver);

            _passportPage = new PassportPage(_driver);
            _settingsEditingPage = new SettingsEditingPage(_driver);
            _mainPage.Open();
        }

        [Test]
        public void SettingChangeTest()
        {
            LoginUtil.SuccessfulLogin(_driver, _mainPage, _passportPage);
            _settingsEditingPage.Open();
            _settingsEditingPage.EnterName(_name);
            _settingsEditingPage.EnterSecondName(_secondName);
            _settingsEditingPage.PressSaveAllButton();
            _driver.Navigate().Refresh();
            Assert.AreEqual(_settingsEditingPage.GetName(), _name);
            Assert.AreEqual(_settingsEditingPage.GetSecondName(), _secondName);
        }
    }
}
