using NetCoreTestProjectKinopoisk.Constants;
using OpenQA.Selenium;

namespace NetCoreTestProjectKinopoisk.Pages
{
    public class SettingsEditingPage : AbstractPage
    {
        private string _pageUrl = TestSettings.SettingsEditingPageUrl;
        private By _nameInput = By.XPath("//input[@id=\"edit[main][first_name]\"]");
        private By _secondNameInput = By.XPath("//input[@id=\"edit[main][last_name]\"]");
        private By _saveAllButton = By.XPath("//input[@id=\"js-save-edit-form\"]");

        public SettingsEditingPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open()
        {
            Driver.Url = _pageUrl;
        }

        public void EnterName(string name)
        {
            Driver.FindElement(_nameInput).SendKeys(Keys.Control + "a");
            Driver.FindElement(_nameInput).SendKeys(Keys.Delete);
            Driver.FindElement(_nameInput).SendKeys(name);
        }

        public string GetName()
        {
            return Driver.FindElement(_nameInput).GetAttribute("value");
        }

        public void EnterSecondName(string secondName)
        {
            Driver.FindElement(_secondNameInput).SendKeys(Keys.Control + "a");
            Driver.FindElement(_secondNameInput).SendKeys(Keys.Delete);
            Driver.FindElement(_secondNameInput).SendKeys(secondName);
        }

        public string GetSecondName()
        {
            return Driver.FindElement(_secondNameInput).GetAttribute("value");
        }

        public void PressSaveAllButton()
        {
            Driver.FindElement(_saveAllButton).Click();
        }
    }
}
