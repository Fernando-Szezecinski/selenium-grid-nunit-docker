using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace selenium_grid_nunit_docker
{

    public enum BrowserType
    {
        Chrome,
        Firefox
    }


    [TestFixture]
    public class Hooks : Base
    {
        private BrowserType _browserType;

        public Hooks(BrowserType browser)
        {
            _browserType = browser;
        }

        [SetUp]
        public void InitializeTest()
        {
            ChooseDriverInstance(_browserType);
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }


        private void ChooseDriverInstance(BrowserType browser)
        {
            DriverOptions options;

            if (browser.Equals(BrowserType.Chrome))
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                options = new ChromeOptions();
            }
            else
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                options = new FirefoxOptions();
            }

            options.PlatformName = "Linux";
            options.BrowserVersion = "";
            Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);
        }

    }
}

