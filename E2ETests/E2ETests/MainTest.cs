using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace E2ETests
{
    public class MainTest
    {
        protected IWebDriver _driver;
        [SetUp]
        public void StartBrowser()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }

    }
}
