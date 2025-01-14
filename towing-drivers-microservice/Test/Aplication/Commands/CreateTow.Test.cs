//using Application.Core;
//using Moq;
//using Tow.Application;
//using Tow.Domain;
//using Xunit;

//namespace Tow.Application.Tests
//{
//    public class CreateTowCommandHandlerTests
//    {
//        private readonly Mock<IdService<string>> _idServiceMock;
//        private readonly Mock<IMessageBrokerService> _messageBrokerServiceMock;
//        private readonly Mock<IEventStore> _eventStoreMock;
//        private readonly Mock<ITowRepository> _towRepositoryMock;
//        private readonly CreateTowCommandHandler _handler;

//        public CreateTowCommandHandlerTests()
//        {
//            _idServiceMock = new Mock<IdService<string>>();
//            _messageBrokerServiceMock = new Mock<IMessageBrokerService>();
//            _eventStoreMock = new Mock<IEventStore>();
//            _towRepositoryMock = new Mock<ITowRepository>();
//            _handler = new CreateTowCommandHandler(_idServiceMock.Object, _messageBrokerServiceMock.Object, _eventStoreMock.Object, _towRepositoryMock.Object);
//        }

//        [Fact]
//        public async Task Should_CreateTow_WhenLicensePlateDoesNotExist()
//        {
//            // Arrange
//            var command = new CreateTowCommand("Royex", "Royex 203", "Red", "ABC123", 2020, "Medium", "Inactive");

//            _towRepositoryMock.Setup(repo => repo.FindByLicensePlate(command.LicensePlate)).ReturnsAsync(Optional<Domain.Tow>.Empty());
//            _idServiceMock.Setup(service => service.GenerateId()).Returns("4a1658a8-95e5-45b9-8cc5-e4a4f7f160d9");

//            // Act
//            var result = await _handler.Execute(command);

//            // Assert
//            Assert.True(result.IsSuccess);
//            var response = result.Unwrap();
//            Assert.Equal("4a1658a8-95e5-45b9-8cc5-e4a4f7f160d9", response.towId);
//            _towRepositoryMock.Verify(repo => repo.Save(It.Is<Domain.Tow>(tow =>
//                tow.GetTowBrand().GetValue() == command.Brand &&
//                tow.GetTowModel().GetValue() == command.Model &&
//                tow.GetTowColor().GetValue() == command.Color &&
//                tow.GetTowLicensePlate().GetValue() == command.LicensePlate &&
//                tow.GetTowYear().GetValue() == command.Year &&
//                tow.GetTowSizeType().GetValue() == command.SizeType &&
//                tow.GetTowStatus().GetValue() == command.Status
//            )), Times.Once);
//            _eventStoreMock.Verify(store => store.AppendEvents(It.Is<List<DomainEvent>>(events =>
//                events.Count == 1 &&
//                events[0] is TowCreatedEvent
//            )), Times.Once);
//            _messageBrokerServiceMock.Verify(service => service.Publish((List<DomainEvent>)It.IsAny<IEnumerable<DomainEvent>>()), Times.Once);
//        }

//        [Fact]
//        public async Task Should_NotCreateTow_WhenLicensePlateExists()
//        {
//            // Arrange
//            var command = new CreateTowCommand("Terex", "Terex 304", "Purple", "SDF345", 2018, "Small", "Inactive");

//            _towRepositoryMock.Setup(repo => repo.FindByLicensePlate(command.LicensePlate)).ReturnsAsync(Optional<Domain.Tow>.Of(Domain.Tow.Create(
//                new TowId("a048dde8-df4b-45d7-bb06-940494782aeb"),
//                new TowBrand(command.Brand),
//                new TowModel(command.Model),
//                new TowColor(command.Color),
//                new TowLicensePlate(command.LicensePlate),
//                new TowYear(command.Year),
//                new TowSizeType(command.SizeType),
//                new TowStatus(command.Status)
//            )));

//            // Act
//            var result = await _handler.Execute(command);

//            // Assert
//            Assert.True(result.IsError);
//            var exception = Assert.Throws<TowAlreadyExistException>(() => result.Unwrap());
//            Assert.Equal("Tow Already Exists.", exception.Message);
//            _eventStoreMock.Verify(store => store.AppendEvents(It.IsAny<List<DomainEvent>>()), Times.Never);
//            _messageBrokerServiceMock.Verify(service => service.Publish((List<DomainEvent>)It.IsAny<IEnumerable<DomainEvent>>()), Times.Never);
//        }
//    }
//}
