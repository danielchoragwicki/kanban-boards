using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace E2ETests
{
    public class LandingPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div/div[1]/a")]
        public IWebElement Board { get; set; }
        public LandingPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

    }
}
