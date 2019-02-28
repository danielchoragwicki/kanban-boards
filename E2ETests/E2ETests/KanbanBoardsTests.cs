using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace E2ETests
{
    [TestFixture]
    public class KanbanBoardsTests
    {
        IWebDriver _driver;
        [SetUp]
        public void StartBrowser()
        {
            _driver = new ChromeDriver();
        }
        [Test]
        public void GoogleTest()
        {
            string text = "youtube";

            _driver.Navigate().GoToUrl("https://google.pl");
            var searchTextBox = _driver.FindElement(By.Name("q"));
            searchTextBox.SendKeys(text + Keys.Enter);

        }
        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}
