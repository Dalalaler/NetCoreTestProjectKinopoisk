using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreTestProjectKinopoisk.Pages
{
    public class SettingsEditingPage : AbstractPage
    {
        private string pageUrl = "https://www.kinopoisk.ru/mykp/edit_main/";
        private By nameInput = By.XPath("//input[@id=\"edit[main][first_name]\"]");
        private By secondNameInput = By.XPath("//input[@id=\"edit[main][last_name]\"]");
        private By saveAllButton = By.XPath("//input[@id=\"js-save-edit-form\"]");

        public SettingsEditingPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open()
        {
            driver.Url = pageUrl;
        }

        public void enterName(string name)
        {
            driver.FindElement(nameInput).SendKeys(Keys.Control + "a");
            driver.FindElement(nameInput).SendKeys(Keys.Delete);
            driver.FindElement(nameInput).SendKeys(name);
        }

        public string getName()
        {
            return driver.FindElement(nameInput).GetAttribute("value");
        }

        public void enterSecondName(string secondName)
        {
            driver.FindElement(secondNameInput).SendKeys(Keys.Control + "a");
            driver.FindElement(secondNameInput).SendKeys(Keys.Delete);
            driver.FindElement(secondNameInput).SendKeys(secondName);
        }

        public string getSecondName()
        {
            return driver.FindElement(secondNameInput).GetAttribute("value");
        }

        public void pressSaveAllButton()
        {
            driver.FindElement(saveAllButton).Click();
        }
    }
}
