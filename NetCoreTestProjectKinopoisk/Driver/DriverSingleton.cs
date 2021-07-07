using OpenQA.Selenium;

namespace NetCoreTestProjectKinopoisk.Driver
{
    class DriverSingleton
    {
        private static DriverSingleton instance;
        private static IWebDriver _webDriver;

        private DriverSingleton()
        {
        }

        public static DriverSingleton getInstance()
        {
            if (instance == null)
            {
                instance = new DriverSingleton();
            }
            return instance;
        }

        public IWebDriver getDriver()
        {
            if (_webDriver == null)
            {
                _webDriver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
            }
            //return _webDriver;
            return _webDriver = DriverFactory.GetDriver(Enums.DriverNamesEnum.CHROME);
        }
    }
}
