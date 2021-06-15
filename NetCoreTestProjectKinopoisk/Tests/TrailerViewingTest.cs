using NetCoreTestProjectKinopoisk.Constants;
using NetCoreTestProjectKinopoisk.Driver;
using NUnit.Framework;
using NetCoreTestProjectKinopoisk.Pages;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium;
using NetCoreTestProjectKinopoisk.Utils;

namespace NetCoreTestProjectKinopoisk.Tests
{
    public class TrailerViewingTest : BaseTest
    {
        private string _filmName = TestSettings.FilmName;

        [SetUp]
        public void TestPreparation()
        {
            _driver = DriverSingleton.getInstance().getDriver();
            _mainPage = new MainPage(_driver);
            _girlfriendExperiencePage = new GirlfriendExperiencePage(_driver);
            _mainPage.Open();
        }

        [Test]
        public void TrailerViewing()
        {
            _mainPage.SearchFilm(_filmName);
            _girlfriendExperiencePage.PlayTrailer();

            By _skipAddButton = By.XPath("/html/body/div/div/div[3]/div/div[1]/div[2]/div/div[2]/div/div/div/div");   
            By _trailerIframe = By.XPath("//iframe[@class=\"discovery-trailers-iframe\"]");
            By _trailerIframe2 = By.XPath("//div[@id=\"player\"]//iframe");     
            By _playButton = By.XPath("//*[@id='player']/yaplayerskintag/div/div/div/div/div[2]/div[1]/div[2]/div[1]/button");


            _driver.SwitchTo().Frame(_driver.FindElement(_trailerIframe));        
            _driver.SwitchTo().Frame(_driver.FindElement(_trailerIframe2));

            
            IWebElement skipButton = FindElementWithTimer.FindElement(_driver, _skipAddButton, 10);
         

            IWebElement skip;
            IWebElement play;


            WebDriverWait wait;
            wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            wait.Until(driver => driver.FindElements(By.XPath("//*[name()='svg']/*[name()='path']")).Count == 2);
            skip = FindElementWithTimer.FindElement(_driver, _skipAddButton, 10);
            skip.Click();           
            wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            wait.Until(driver => driver.FindElements(By.XPath("//*[name()='svg']/*[name()='path']")).Count == 2);
            skip = FindElementWithTimer.FindElement(_driver, _skipAddButton, 10);
            skip.Click();

  
            _driver.SwitchTo().ParentFrame();
            play = FindElementWithTimer.FindElement(_driver, By.XPath("//button[@data-control-name=\"play\"]"), 20);
            play.Click(); // element click intercepted

            _driver.SwitchTo().Frame(_driver.FindElement(_trailerIframe2));
            play = FindElementWithTimer.FindElement(_driver, By.XPath("//button[@data-control-name=\"play\"]"), 20);
        
      

        }
    }
}
