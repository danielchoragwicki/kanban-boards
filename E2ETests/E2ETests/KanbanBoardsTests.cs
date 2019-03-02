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
        // Tytul: Utworzenie listy i karty.
        // Warunki wstępne: Istnieje juz utworzona tablice oraz przeslane dane sa prawidlowe.
        // Kroki
        //   1.Otworz tablice.
        //   2.Dodaj liste
        //   3.Utworz karte
        //   4.Edytuj karte
        //   5.Zapisz zmiany
        // Oczekiwany rezultat 
        //   - lista oraz karta zostały utworzone oraz zapisane.

        [Test]
        [TestCase("E2E test", "Another test", "Test Title", "Test Desc", "Hello world", "06102005")]
        public void CreateListAndCard( 
            string listInputText,
            string cardInputText,
            string cardTitle,
            string cardDesc,
            string cardStartDate,
            string cardEndDate )
        {
            const string assertionStartDate = "1995-10-06";
            const string assertionEndDate = "2005-10-06";

            var landingPage = new LandingPage(_driver);
            var boardPage = new BoardPage(_driver);
            var cardPage = new CardPage(_driver);

            _driver.Navigate().GoToUrl("http://localhost:56935/");
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='root']/div/div/div[1]/a")));

            landingPage.Board.Click();
            boardPage.AddListInput.SendKeys("E2E test");
            boardPage.AddListInput.Submit();

            Assert.That(boardPage.ListInput.GetAttribute("value"), Is.EqualTo(listInputText));

            RefreshPage();
            landingPage.Board.Click();

            boardPage.AddCardInput.SendKeys("Another test");
            boardPage.AddCardInput.Submit();

            Assert.That(boardPage.CardTitle.Text, Is.EqualTo(cardInputText));

            RefreshPage();
            landingPage.Board.Click();

            Actions action = new Actions(_driver);
            action.MoveToElement(boardPage.CardElement).Perform();

            boardPage.EditCardButton.Click();
            cardPage.TitleInput.Clear();
            cardPage.TitleInput.SendKeys(cardTitle);
            Assert.That(cardPage.TitleInput.GetAttribute("value"), Is.EqualTo(cardTitle));

            cardPage.DescriptionInput.SendKeys(cardDesc);
            Assert.That(cardPage.DescriptionInput.GetAttribute("value"), Is.EqualTo(cardDesc));

            cardPage.DateStartInput.SendKeys(cardStartDate);
            Assert.That(cardPage.DateStartInput.GetAttribute("value"), Is.EqualTo(assertionStartDate));

            cardPage.DateEndInput.SendKeys(cardEndDate);
            Assert.That(cardPage.DateEndInput.GetAttribute("value"), Is.EqualTo(assertionEndDate));

            cardPage.SaveButton.Click();
        }

        [Test]
        [TestCase("E2E Board")]
        public void ChangeBoardNameAndTheme(string boardName)
        {
            var landingPage = new LandingPage(_driver);
            var boardPage = new BoardPage(_driver);
            var cardPage = new CardPage(_driver);

            _driver.Navigate().GoToUrl("http://localhost:56935/");
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='root']/div/div/div[1]/a")));

            landingPage.Board.Click();
            boardPage.AddListInput.SendKeys("Another E2E test");
            boardPage.AddListInput.Submit();


            RefreshPage();
            landingPage.Board.Click();

            boardPage.AddCardInput.SendKeys("Another test");
            boardPage.AddCardInput.Submit();


            RefreshPage();
            landingPage.Board.Click();

            Actions action = new Actions(_driver);
            action.MoveToElement(boardPage.CardElement).Perform();

            boardPage.EditCardButton.Click();
            cardPage.DeleteCardButton.Click();
            Assert.AreEqual(cardPage.DeleteCardButton.Displayed, false);
            boardPage.RedColorButton.Click();
        }

        private void RefreshPage()
        {
            _driver.Navigate().GoToUrl("http://localhost:56935/");
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='root']/div/div/div[1]/a")));
        }
    }
}
