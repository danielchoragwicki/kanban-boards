using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kanban_boards.Database;
using kanban_boards.Models;
using kanban_boards.UnitOfWork;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace kanban_boards_tests.UnitTests.Controllers
{
    [TestFixture]
    public class CardsTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        [SetUp]
        public void SetUp()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Test]
        public void GetAllCards_WhenCalled_ReturnsCards()
        {
            _unitOfWork.Setup(unit => unit.Cards.GetAll())
                .Returns(new List<Card>
                {
                    new Card()
                }.AsQueryable());

            var collectionOfCards = _unitOfWork.Object.Cards.GetAll();
            Assert.That(collectionOfCards, Is.Not.Empty);

            _unitOfWork.Verify(unit => unit.Cards.GetAll());
        }

        [Test]
        public void GetCard_NotFound_ReturnNull()
        {
            _unitOfWork.Setup(unit => unit.Cards.Get(5)).Returns(value: null);
            var result = _unitOfWork.Object.Cards.Get(5);

            Assert.That(result, Is.Null);
        }
        [Test]
        public void GetCard_CardIsFound_ReturnCard()
        {
            const int cardId = 5;
            _unitOfWork.Setup(unit => unit.Cards.Get(cardId)).Returns(new Card() { Id = cardId });
            var result = _unitOfWork.Object.Cards.Get(cardId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<Card>());
            Assert.That(cardId, Is.EqualTo(result.Id));
        }

        [Test]
        public void AddCard_WhenCalled_ReturnsTrue()
        {
            var cardMock = new Card() {Id = 5};
            _unitOfWork.Setup(unit => unit.Cards.Add(cardMock));

            _unitOfWork.Object.Cards.Add(cardMock);

            _unitOfWork.Verify(unit => unit.Cards.Add(cardMock));
        }

        [Test]
        public void PutCard_WhenCalled_ReturnTrue()
        {
            var cardMock = new Card() { Id = 5 };
            _unitOfWork.Setup(unit => unit.Cards.Put(cardMock));

            _unitOfWork.Object.Cards.Put(cardMock);

            _unitOfWork.Verify(unit => unit.Cards.Put(cardMock));
        }

        [Test]
        public void DeleteCard_WhenCalled_ReturnTrue()
        {
            var cardMock = new Card() { Id = 5 };
            _unitOfWork.Setup(unit => unit.Cards.Delete(cardMock));

            _unitOfWork.Object.Cards.Delete(cardMock);

            _unitOfWork.Verify(unit => unit.Cards.Delete(cardMock));
        }
    }
}
