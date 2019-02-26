using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _unitOfWork.Setup(unit => unit.Cards.Get(5)).Returns(new Card() { Id = 5 });
            var result = _unitOfWork.Object.Cards.Get(5);

            Assert.That(result, Is.Not.Null);
        }
    }
}
