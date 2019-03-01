using System;
using System.Runtime.InteropServices;
using E2ETests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace E2ETests
{
    [TestFixture]
    public class KanbanBoardsTests : MainTest
    {
        [Test]
        public void FullKanbanBoardTest()
        {
            _driver.Navigate().GoToUrl("http://localhost:56935/");

            var landingPage = new LandingPage(_driver);
            var boardPage = new BoardPage(_driver);
            var cardPage = new CardPage(_driver);

            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='root']/div/div/div[1]/a")));


            landingPage.Board.Click();
            boardPage.AddListInput.SendKeys("E2E test");
            boardPage.AddListInput.Submit();

            _driver.Navigate().GoToUrl("http://localhost:56935/");
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='root']/div/div/div[1]/a")));
            landingPage.Board.Click();

            boardPage.AddCardInput.SendKeys("Another test");
            boardPage.AddCardInput.Submit();

            Actions action = new Actions(_driver);
            action.MoveToElement(boardPage.CardElement).Perform();

            boardPage.EditCardButton.Click();
            cardPage.TitleInput.SendKeys("Test title");
            cardPage.DescriptionInput.SendKeys("Test Desc");
            cardPage.DateStartInput.SendKeys("1995-10-06");
            cardPage.DateEndInput.SendKeys("2005-12-06");
            cardPage.SaveButton.Click();

            var temp = "temp";

        }
    }
}
