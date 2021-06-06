using OpenQA.Selenium;

namespace NetCoreTestProjectKinopoisk.Pages
{
    abstract public class AbstractPage 
    {
        protected IWebDriver driver;

        public AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public abstract void Open();
    }
}
