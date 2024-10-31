using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using DemoSelenium.Utility;

namespace DemoSelenium.Base
{
    [TestClass]
    public class BaseTest
    {
        public static readonly string siteUrl = ConfigurationManager.AppSettings["Url"];
        public static readonly string LoginDetailsJson = ConfigurationManager.AppSettings["LoginDetailsJsonPath"];
        public static readonly string PersonDetailsJson = ConfigurationManager.AppSettings["PersonDetailsJsonPath"];
        public IWebDriver driver;

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        /// <summary>
        /// Initilize the driver
        /// </summary>
        [TestInitialize]
        public void BaseInit()
        {
            // Run as headless
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless=new");
            // Create instance for Chrome webdriver
            this.driver = new ChromeDriver(options);
            // Navigate to a website
            this.driver.Url = siteUrl;
            //this.driver.Navigate().GoToUrl(siteUrl);
            // Maximize window
            this.driver.Manage().Window.Maximize();
            // Implicit waits
            this.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        /// <summary>
        /// Cleanup the driver
        /// </summary>
        [TestCleanup]
        public void BaseCleanup()
        {
            // close browser
            this.driver.Close();
            // destroy driver instance
            this.driver.Quit();
        }

    }
}
