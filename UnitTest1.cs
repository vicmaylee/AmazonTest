using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AmazonTest
{
    public class Tests
    {
        ConfigPack homePage = new ConfigPack();
        IWebDriver? driver;
        
        [Test]
        public void Test1()
        {
            
           driver = homePage.BrowserSetUp();
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement acceptCookies = driver.FindElement(By.XPath("//*[@name='accept']"));
            acceptCookies.Click();
            IWebElement allMenu = driver.FindElement(By.Id("nav-hamburger-menu"));
                allMenu.Click();
            Thread.Sleep(2000);
           var findAGift = driver.FindElement(By.XPath("//a[@class='hmenu-item'][.='Find a Gift']"));
           (driver as IJavaScriptExecutor).ExecuteScript("arguments[0].scrollIntoView", findAGift);
            findAGift.Click();
            var giftsForMen = driver.FindElement(By.XPath("//a[@class='hmenu-item'][.='Gifts for Men']"));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(x => giftsForMen.Displayed);
            giftsForMen.Click();
            var pageTitle = driver.Title;
            string expectedPageTitle = "Gifts for Men | Amazon.co.uk Gift Finder";
            Assert.AreEqual(expectedPageTitle, pageTitle);
            string expectedProduct = "Fashion";
            string[] actualProducts = new string[25];
            //ArrayList actualProducts = new ArrayList();
            IList<IWebElement> category = driver.FindElements(By.CssSelector("div[class='sc-1wcpl6x-0 jDLbeW'] ul li"));
            for (int i = 0; i < category.Count; i++) 
            {
                actualProducts[i]=(category[i].Text);
            }
            Assert.Contains(expectedProduct, actualProducts);

        }

        [TearDown]
        public void CloseBrowser()
        {
            homePage.QuitBrowser();
        }
    }
}