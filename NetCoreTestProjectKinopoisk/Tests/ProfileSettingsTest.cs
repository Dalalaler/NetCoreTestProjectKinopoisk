using Constants;
using Driver;
using NUnit.Framework;
using Pages;
using Utils;

namespace Tests
{
    public class ProfileSettingsTest : BaseTest
    {
        private string _name = TestSettings.UserName;
        private string _secondName = TestSettings.UserSecondName;

        [SetUp]
        public void TestPreparation()
        {
            _driver = DriverFactory.GetDriver(Enums.DriverNames.CHROME);
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
