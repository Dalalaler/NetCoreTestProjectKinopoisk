using OpenQA.Selenium;

namespace Pages
{
    public abstract class AbstractPage
    {
        protected IWebDriver Driver;

        public AbstractPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public abstract void Open();
    }
}
