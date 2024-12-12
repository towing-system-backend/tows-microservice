//using Application.Core;
//using Moq;
//using Tow.Application;
//using Tow.Domain;
//using Xunit;
//using Microsoft.AspNetCore.Mvc;

//namespace Tow.Infrastructure.Test
//{
//    public class TowControllerTests
//    {
//        private readonly Mock<IdService<string>> _mockIdService;
//        private readonly Mock<IMessageBrokerService> _mockMessageBrokerService;
//        private readonly Mock<IEventStore> _mockEventStore;
//        private readonly Mock<ITowRepository> _mockTowRepository;
//        private readonly TowController _controller;

//        public TowControllerTests()
//        {
//            _mockIdService = new Mock<IdService<string>>();
//            _mockMessageBrokerService = new Mock<IMessageBrokerService>();
//            _mockEventStore = new Mock<IEventStore>();
//            _mockTowRepository = new Mock<ITowRepository>();
//            _controller = new TowController(_mockIdService.Object, _mockMessageBrokerService.Object, _mockEventStore.Object, _mockTowRepository.Object);
//        }

//        [Fact]
//        public async Task CreateTow_ShouldReturnCreateTowResponse_WhenTowIsCreated()
//        {
//            // Arrange
//            var createTowDto = new CreateTowDto("Titan", "Model X", "Red", "XYZ123", 2023, "Medium", "Active");
//            var response = new CreateTowResponse("d3b07384-d9a0-4c9b-8f3d-2b0a4e5e5a5a");
//            _mockTowRepository.Setup(repo => repo.FindByLicensePlate(createTowDto.LicensePlate))
//                .ReturnsAsync(Optional<Tow.Domain.Tow>.Empty());
//            _mockIdService.Setup(service => service.GenerateId()).Returns("d3b07384-d9a0-4c9b-8f3d-2b0a4e5e5a5a");

//            // Act
//            var result = await _controller.CreateTow(createTowDto) as OkObjectResult;

//            // Assert
//            Assert.NotNull(result);
//            Assert.IsType<CreateTowResponse>(result.Value);
//            Assert.Equal(response.TowId, ((CreateTowResponse)result.Value).TowId);
//        }

//        [Fact]
//        public async Task CreateTow_ShouldThrowException_WhenTowAlreadyExists()
//        {
//            // Arrange
//            var createTowDto = new CreateTowDto("Titan", "Model X", "Red", "XYZ123", 2023, "Medium", "Active");
//            _mockTowRepository.Setup(repo => repo.FindByLicensePlate(createTowDto.LicensePlate))
//                .ReturnsAsync(Optional<Tow.Domain.Tow>.Of(new Tow.Domain.Tow(new TowId("d3b07384-d9a0-4c9b-8f3d-2b0a4e5e5a5a"))));

//            // Act & Assert
//            await Assert.ThrowsAsync<TowAlreadyExistException>(() => _controller.CreateTow(createTowDto));
//        }

//        [Fact]
//        public async Task UpdateTow_ShouldReturnUpdateTowResponse_WhenTowIsUpdated()
//        {
//            // Arrange
//            var updateTowDto = new UpdateTowDto("d3b07384-d9a0-4c9b-8f3d-2b0a4e5e5a5a", "Atlas", "Model Y", "Blue", "ABC789", 2024, "Large", "Inactive");
//            var tow = Tow.Domain.Tow.Create(
//                new TowId(updateTowDto.Id),
//                new TowBrand("Titan"),
//                new TowModel("Model X"),
//                new TowColor("Red"),
//                new TowLicensePlate("XYZ123"),
//                new TowYear(2023),
//                new TowSizeType("Medium"),
//                new TowStatus("Active"));
//            _mockTowRepository.Setup(repo => repo.FindById(updateTowDto.Id))
//                .ReturnsAsync(Optional<Tow.Domain.Tow>.Of(tow));

//            // Act
//            var result = await _controller.UpdateTow(updateTowDto) as OkObjectResult;

//            // Assert
//            Assert.NotNull(result);
//            Assert.IsType<UpdateTowResponse>(result.Value);
//            Assert.Equal(updateTowDto.Id, ((UpdateTowResponse)result.Value).TowId);
//        }

//        [Fact]
//        public async Task UpdateTow_ShouldThrowException_WhenTowDoesNotExist()
//        {
//            // Arrange
//            var updateTowDto = new UpdateTowDto("d3b07384-d9a0-4c9b-8f3d-2b0a4e5e5a5a", "Atlas", "Model Y", "Blue", "ABC789", 2024, "Large", "Inactive");
//            _mockTowRepository.Setup(repo => repo.FindById(updateTowDto.Id))
//                .ReturnsAsync(Optional<Tow.Domain.Tow>.Empty());

//            // Act & Assert
//            await Assert.ThrowsAsync<TowNotFoundException>(() => _controller.UpdateTow(updateTowDto));
//        }
//    }
//}
