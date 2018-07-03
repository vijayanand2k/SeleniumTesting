using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumTesting
{
    public class AutomationTests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.google.com");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void NavigateToWikipedia()
        {
            driver.FindElement(By.ClassName("gsfi")).SendKeys("selenium wiki");
            driver.FindElement(By.ClassName("gsfi")).SendKeys(Keys.Enter);

            driver.FindElement(By.LinkText("Selenium (software)")).Click();

            var result = driver.Title;

            Assert.AreEqual("Selenium (software) - Wikipedia", result);

        }
    }
}
