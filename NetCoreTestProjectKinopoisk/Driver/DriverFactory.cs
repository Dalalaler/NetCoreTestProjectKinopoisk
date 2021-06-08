using Constants;
using Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;

namespace Driver
{
    class DriverFactory
    {
        private static int _implicitWait = TestSettings.ImplicitWait;
        public static IWebDriver GetDriver(DriverNames driverName)
        {
            IWebDriver webDriver;
            switch (driverName)
            {
                case DriverNames.CHROME:
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_implicitWait);
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
