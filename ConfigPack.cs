using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AmazonTest
{
    public class ConfigPack
    {
       public IWebDriver driver;

        [SetUp]
        public IWebDriver BrowserSetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("incognito", "start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://amazon.co.uk");
            return driver;
        }

        public void QuitBrowser()
        {
            driver.Quit();
        }
    }
}
