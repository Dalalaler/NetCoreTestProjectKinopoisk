using OpenQA.Selenium;

namespace NetCoreTestProjectKinopoisk.Pages
{
    public abstract class AbstractPage
    {
        protected IWebDriver Driver;

        public AbstractPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public abstract void Open();
    }
}
