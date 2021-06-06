using NetCoreTestProjectKinopoisk.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;

namespace NetCoreTestProjectKinopoisk.Tests
{
    class DriverFactory
    {
        private static int implicitWait = 5;
        public static IWebDriver GetDriver(DriverNames driverName)
        {            
            IWebDriver webDriver;
            switch (driverName)
            {
                case DriverNames.CHROME:
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);
                    break;
                case DriverNames.EDGE:
                    webDriver = new EdgeDriver();
                    break;
                case DriverNames.FIREFOX:
                    webDriver = new FirefoxDriver();
                    break;
                case DriverNames.OPERA:
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
