using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreTestProjectKinopoisk.Lambdatest
{
      
    [Parallelizable(ParallelScope.Children)]
    public class LambdaBaseTest
    {
        public static string LT_USERNAME = Environment.GetEnvironmentVariable("LT_USERNAME") == null ? "dalalaler" : Environment.GetEnvironmentVariable("LT_USERNAME");
        public static string LT_ACCESS_KEY = Environment.GetEnvironmentVariable("LT_ACCESS_KEY") == null ? "SGCXdpkI9iLZ1hiJPBnEtiDGejPkqDDUl71t64vyzi93F4Mn9e" : Environment.GetEnvironmentVariable("LT_ACCESS_KEY");
        public static bool tunnel = Boolean.Parse(Environment.GetEnvironmentVariable("LT_TUNNEL") == null ? "false" : Environment.GetEnvironmentVariable("LT_TUNNEL"));
        public static string build = Environment.GetEnvironmentVariable("LT_BUILD") == null ? "Demo with Kinopoisk" : Environment.GetEnvironmentVariable("LT_BUILD");
        public static string seleniumUri = "https://USERNAME:ACCESS_KEY@hub.lambdatest.com/wd/hub";


        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public String browser;
        public String version;
        public String os;

        public LambdaBaseTest(String browser, String version, String os)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
        }

        [SetUp]
        public void Init()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Version, version);
            capabilities.SetCapability(CapabilityType.Platform, os);

            //Requires a named tunnel.
            if (tunnel)
            {
                capabilities.SetCapability("tunnel", tunnel);
            }
            if (build != null)
            {
                capabilities.SetCapability("build", build);
            }

            capabilities.SetCapability("user", LT_USERNAME);
            capabilities.SetCapability("accessKey", LT_ACCESS_KEY);

            capabilities.SetCapability("name",
            String.Format("{0}:{1}",
            TestContext.CurrentContext.Test.ClassName,
            TestContext.CurrentContext.Test.MethodName));
            driver.Value = new RemoteWebDriver(new Uri(seleniumUri), capabilities, TimeSpan.FromSeconds(600));
            Console.Out.WriteLine(driver);
        }        

        [TearDown]
        public void Cleanup()
        {
            bool passed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
            try
            {
                // Logs the result to LambdaTest
                //((IJavaScriptExecutor)driver.Value).ExecuteScript("lambda-status=" + (passed ? "passed" : "failed"));
            }
            finally
            {

                // Terminates the remote webdriver session
                driver.Value.Quit();
            }
        }
    }
}
