using NetCoreTestProjectKinopoisk.Pages;
using NUnit.Framework;

namespace NetCoreTestProjectKinopoisk.Tests
{
    class ProfileSettingsTest : BasicTest
    {
        private string name = "FakeName";
        private string secondName = "FakeSecondName";


        [SetUp]
        public void TestPreparation()
        {
            mainPage = new MainPage(driver);
            passportPage = new PassportPage(driver);
            settingsEditingPage = new SettingsEditingPage(driver);
            mainPage.Open();
        }

        [Test]
        public void SettingChangeTest()
        {
            LoginTest loginTest = new LoginTest();
            loginTest.SuccessfulLoginTest();
            settingsEditingPage.Open();
            settingsEditingPage.enterName(name);
            settingsEditingPage.enterSecondName(secondName);
            settingsEditingPage.pressSaveAllButton();

            driver.Navigate().Refresh();


            Assert.AreEqual(settingsEditingPage.getName(), name);
            Assert.AreEqual(settingsEditingPage.getSecondName(), secondName);
        }
    }
}
