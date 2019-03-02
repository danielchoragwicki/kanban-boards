using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace E2ETests.PageObjects
{
    public class CardPage
    {
        [FindsBy(How = How.ClassName, Using = "card-edit__title")]
        public IWebElement TitleInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "card-edit__desc")]
        public IWebElement DescriptionInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[2]/div/div[1]/div/div/div[1]/div/div[2]/div/form/div/div[1]/input")]
        public IWebElement DateStartInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[2]/div/div[1]/div/div/div[1]/div/div[2]/div/form/div/div[2]/input")]
        public IWebElement DateEndInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[2]/div/div[1]/div/div/div[1]/div/div[2]/div/form/div/div[3]/button")]
        public IWebElement SaveButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[2]/div/div[1]/div/div/div[1]/div/div[2]/div/form/div/div[3]/div/button")]
        public IWebElement DeleteCardButton { get; set; }


        public CardPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
