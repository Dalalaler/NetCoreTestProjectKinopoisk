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
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--test-type");
                    options.AddArguments("--start-maximized");
                    options.AddArguments("--allow-file-access-from-files");
                    options.AddArguments("--allow-running-insecure-content");
                    options.AddArguments("--allow-cross-origin-auth-prompt");
                    options.AddArguments("--allow-file-access");
                    options.AddArgument("--disable-web-security");
                    options.AddArguments("--disable-gpu");
                    //options.AddArguments("--user-data-dir=~/chromeTemp");
                    webDriver = new ChromeDriver(options);
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
