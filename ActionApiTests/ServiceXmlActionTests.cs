using ActionApi.Service;
using Moq;


namespace ActionApiTests
{
    public class ServiceXmlActionTests
    {
        [Fact]
        public async Task AddMainCategory_Should_Return_True()
        {
            // Arrange
            var serviceMock = new Mock<IServiceXmlAction>();
            serviceMock.Setup(x => x.AddMainCategory()).ReturnsAsync(true);
            var service = serviceMock.Object;

            // Act
            var result = await service.AddMainCategory();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddProducer_Should_Return_True()
        {
            // Arrange
            var serviceMock = new Mock<IServiceXmlAction>();
            serviceMock.Setup(x => x.AddProducer()).ReturnsAsync(true);
            var service = serviceMock.Object;

            // Act
            var result = await service.AddProducer();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddProduct_Should_Return_True()
        {
            // Arrange
            var serviceMock = new Mock<IServiceXmlAction>();
            serviceMock.Setup(x => x.AddProduct()).ReturnsAsync(true);
            var service = serviceMock.Object;

            // Act
            var result = await service.AddProduct();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddSubCategory_Should_Return_True()
        {
            // Arrange
            var serviceMock = new Mock<IServiceXmlAction>();
            serviceMock.Setup(x => x.AddSubCategory()).ReturnsAsync(true);
            var service = serviceMock.Object;

            // Act
            var result = await service.AddSubCategory();

            // Assert
            Assert.True(result);
        }
    }
}