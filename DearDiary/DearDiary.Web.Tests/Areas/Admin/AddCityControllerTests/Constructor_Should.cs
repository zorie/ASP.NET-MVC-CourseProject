using NUnit.Framework;
using Moq;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Areas.Admin.Controllers;

namespace DearDiary.Web.Tests.Areas.Admin.AddCityControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenCityServiceIsNull()
        {
            // Arrange
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            // Act & Assert
            Assert.That(() => new AddCityController(
                null,
                mockedCountryService.Object,
                mockedMapper.Object),
                Throws.ArgumentNullException.With.Message.Contains("City Service"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenCountryServiceIsNull()
        {
            // Arrange
            var mockedCityService = new Mock<ICityService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            // Act & Assert
            Assert.That(() => new AddCityController(
                mockedCityService.Object,
                null,
                mockedMapper.Object),
                Throws.ArgumentNullException.With.Message.Contains("Country Service"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenMapperIsNull()
        {
            // Arrange
            var mockedCityService = new Mock<ICityService>();
            var mockedCountryService = new Mock<ICountryService>();

            // Act & Assert
            Assert.That(() => new AddCityController(
                mockedCityService.Object,
                mockedCountryService.Object, 
                null),
                Throws.ArgumentNullException.With.Message.Contains("Mapper"));
        }
    }
}
