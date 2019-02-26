using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http.Results;
using AutoMapper;
using kanban_boards.App_Start;
using kanban_boards.Controllers.API;
using kanban_boards.Models;
using kanban_boards.Models.DTO;
using kanban_boards.UnitOfWork;
using Moq;
using NUnit.Framework;

namespace kanban_boards_tests.UnitTests.Controllers
{
    [TestFixture]
    public class CardsControllerTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private CardsController _cardsController;
        private bool _mapperIntialized = false;

        [SetUp]
        public void SetUp()
        {
            if (!_mapperIntialized)
            {
                Mapper.Initialize(cfg => {
                    cfg.AddProfile<MappingProfile>();
                });
                _mapperIntialized = true;
            }

            _unitOfWork = new Mock<IUnitOfWork>();
            _cardsController = new CardsController(_unitOfWork.Object);
        }


        [Test]
        public void GetCards_WhenCalled_ReturnCardsDTO()
        {
            _unitOfWork.Setup(unit => unit.Cards.GetAll())
                .Returns(new List<Card>
                {
                    new Card()
                }.AsQueryable());

            var result = _cardsController.GetCards();

            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.TypeOf<List<CardDTO>>());
        }

        [Test]
        public void GetCard_CardIsNotFound_ReturnNotFoundResult()
        {
            _unitOfWork.Setup(unit => unit.Cards.Get(1))
                .Returns(value: null);

            var actionResult = _cardsController.GetCard(1);

            Assert.That(actionResult, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public void GetCard_CardIsFound_ReturnOkResult()
        {
            _unitOfWork.Setup(unit => unit.Cards.Get(1))
                .Returns(new Card() { Id =  1});

            var actionResult = _cardsController.GetCard(1);
            var contentResult = actionResult as OkNegotiatedContentResult<CardDTO>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        [Test]
        public void PostCard_CardIsValid_ReturnCreatedAtRouteResult()
        {
            _unitOfWork.Setup(unit => unit.Cards.Add(new Card() {Id = 100, KanbanListId = 1}));

            var actionResult = _cardsController.PostCard(new CardDTO() {Id = 100, KanbanListId = 1});
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Card>;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(100, createdResult.RouteValues["id"]);
        }

        [Test]
        public void PostCard_ModelStateInvalid_ReturnBadRequest()
        {
            _unitOfWork.Setup(unit => unit.Cards.Add(new Card() { Id = 100, KanbanListId = 1 }));
            _cardsController.ModelState.AddModelError("error", "error");
            var actionResult = _cardsController.PostCard(new CardDTO() { Id = 100, KanbanListId = 1 });

            Assert.That(actionResult, Is.TypeOf<InvalidModelStateResult>());
        }

        [Test]
        public void DeleteCard_CardIsNotFound_ReturnNotFoundResult()
        {
            _unitOfWork.Setup(unit => unit.Cards.Delete(new Card()));

            var actionResult = _cardsController.DeleteCard(1);

            Assert.That(actionResult, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public void DeleteCard_CardIsFound_ReturOkResult()
        {
            const int cardId = 1;

            _unitOfWork.Setup(unit => unit.Cards.Get(cardId))
                .Returns(new Card() {Id = cardId});
            _unitOfWork.Setup(unit => unit.Cards.Delete(new Card()));

            var actionResult = _cardsController.DeleteCard(1);
            var contentResult = actionResult as OkNegotiatedContentResult<Card>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(cardId, contentResult.Content.Id);
        }
    }
}
