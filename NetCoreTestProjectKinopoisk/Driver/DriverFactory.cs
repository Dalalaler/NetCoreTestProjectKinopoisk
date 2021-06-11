using NetCoreTestProjectKinopoisk.Constants;
using NetCoreTestProjectKinopoisk.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;

namespace NetCoreTestProjectKinopoisk.Driver
{
    class DriverFactory
    {
        private static int _implicitWait = TestSettings.ImplicitWait;

        public static IWebDriver GetDriver(DriverNamesEnum driverName)
        {
            IWebDriver webDriver;
            switch (driverName)
            {
                case DriverNamesEnum.CHROME:
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_implicitWait);
                    break;
                case DriverNamesEnum.EDGE:
                    webDriver = new EdgeDriver();
                    break;
                case DriverNamesEnum.FIREFOX:
                    webDriver = new FirefoxDriver();
                    break;
                case DriverNamesEnum.OPERA:
                    webDriver = new OperaDriver();
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }
            return webDriver;
        }
    }
}
