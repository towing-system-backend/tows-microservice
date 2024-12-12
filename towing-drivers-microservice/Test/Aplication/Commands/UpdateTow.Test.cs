using Moq;
using Tow.Domain;
using Xunit;
using Tow.Application;
using Application.Core;

namespace Tow.Aplication.Tests
{
    public class UpdateTowCommandHandlerTests
    {
        private readonly Mock<IMessageBrokerService> _messageBrokerServiceMock;
        private readonly Mock<IEventStore> _eventStoreMock;
        private readonly Mock<ITowRepository> _towRepositoryMock;
        private readonly UpdateTowCommandHandler _handler;

        public UpdateTowCommandHandlerTests()
        {
            _messageBrokerServiceMock = new Mock<IMessageBrokerService>();
            _eventStoreMock = new Mock<IEventStore>();
            _towRepositoryMock = new Mock<ITowRepository>();
            _handler = new UpdateTowCommandHandler(_messageBrokerServiceMock.Object, _eventStoreMock.Object, _towRepositoryMock.Object);
        }

        [Fact]
        public async Task Should_UpdateTowBrand_WhenTowExists()
        {
            // Arrange
            var command = new UpdateTowCommand("d3b07384-d9a0-4c9b-8f3d-2b0a4e5e5a5a", "Chevrolet", null, null, null, null, null, null);

            _towRepositoryMock.Setup(repo => repo.FindById(command.Id)).ReturnsAsync(Optional<Tow.Domain.Tow>.Of(Tow.Domain.Tow.Create(
                        new TowId(command.Id),
                        new TowBrand("Ford"),
                        new TowModel("F-150"),
                        new TowColor("Red"),
                        new TowLicensePlate("XYZ123"),
                        new TowYear(2022),
                        new TowSizeType("Large"),
                        new TowStatus("Active")
                    )
                )
            );

            // Act 
            var result = await _handler.Execute(command);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.IsType<UpdateTowResponse>(result.Unwrap());
            Assert.Equal(command.Id, result.Unwrap().TowId);
            _towRepositoryMock.Verify(repo => repo.Save(It.Is<Tow.Domain.Tow>(tow =>
                    tow.GetTowId().GetValue() == command.Id &&
                    tow.GetTowBrand().GetValue() == "Chevrolet"
                )), Times.Once);
        }

        [Fact]
        public async Task Should_UpdateTowModel_WhenTowExists()
        {
            // Arrange
            var command = new UpdateTowCommand("d3b07384-d9a0-4c9b-8f3d-2b0a4e5e5a5a", null, "Silverado", null, null, null, null, null);

            _towRepositoryMock.Setup(repo => repo.FindById(command.Id)).ReturnsAsync(Optional<Tow.Domain.Tow>.Of(Tow.Domain.Tow.Create(
                        new TowId(command.Id),
                        new TowBrand("Chevrolet"),
                        new TowModel("Colorado"),
                        new TowColor("Blue"),
                        new TowLicensePlate("XYZ123"),
                        new TowYear(2022),
                        new TowSizeType("Medium"),
                        new TowStatus("Active")
                    )
                )
            );

            // Act 
            var result = await _handler.Execute(command);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.IsType<UpdateTowResponse>(result.Unwrap());
            Assert.Equal(command.Id, result.Unwrap().TowId);
            _towRepositoryMock.Verify(repo => repo.Save(It.Is<Tow.Domain.Tow>(tow =>
                    tow.GetTowId().GetValue() == command.Id &&
                    tow.GetTowModel().GetValue() == "Silverado"
                )), Times.Once);
        }
    }
}
