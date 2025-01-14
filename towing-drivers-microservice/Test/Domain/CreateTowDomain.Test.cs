//using Application.Core;
//using Xunit;

//namespace Tow.Domain.Tests
//{
//    public class CreateTowDomainTest
//    {
//        [Fact]
//        public void Should_CreateTow_WithValidProperties()
//        {
//            // Arrange
//            var towId = new TowId("4a1658a8-95e5-45b9-8cc5-e4a4f7f160d9");
//            var brand = new TowBrand("Rocca");
//            var model = new TowModel("Rocca 203");
//            var color = new TowColor("Purple");
//            var licensePlate = new TowLicensePlate("ABC123");
//            var year = new TowYear(2020);
//            var sizeType = new TowSizeType("Medium");
//            var status = new TowStatus("Active");

//            // Act
//            var tow = Tow.Create(towId, brand, model, color, licensePlate, year, sizeType, status);

//            // Assert
//            Assert.Equal(towId.GetValue(), tow.GetTowId().GetValue());
//            Assert.Equal(brand.GetValue(), tow.GetTowBrand().GetValue());
//            Assert.Equal(model.GetValue(), tow.GetTowModel().GetValue());
//            Assert.Equal(color.GetValue(), tow.GetTowColor().GetValue());
//            Assert.Equal(licensePlate.GetValue(), tow.GetTowLicensePlate().GetValue());
//            Assert.Equal(year.GetValue(), tow.GetTowYear().GetValue());
//            Assert.Equal(sizeType.GetValue(), tow.GetTowSizeType().GetValue());
//            Assert.Equal(status.GetValue(), tow.GetTowStatus().GetValue());
//        }
//    }
//}
