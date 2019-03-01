using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace E2ETests.PageObjects
{
    public class BoardPage
    {
        [FindsBy(How = How.ClassName, Using = "new-list__input")]
        public IWebElement AddListInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "new-card__input")]
        public IWebElement AddCardInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[2]/div/div[1]/div/div/div[1]/div/div/button")]
        public IWebElement EditCardButton { get; set; }
        [FindsBy(How = How.ClassName, Using = "card")]
        public IWebElement CardElement { get; set; }
        public BoardPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
