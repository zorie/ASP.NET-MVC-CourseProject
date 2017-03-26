using NUnit.Framework;
using Moq;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Controllers;

namespace DearDiary.Web.Tests.ControllersTests.AimControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenAimServiceIsNull()
        {
            // Arrange
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            // Act & Assert
            Assert.That(() => new AimController(null,
                mockedCountryService.Object, mockedCityService.Object, 
                mockedCategoryService.Object, mockedMapper.Object),
                Throws.ArgumentNullException.With.Message.Contains("Aim Service"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenCategoryServiceIsNull()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            // Act & Assert
            Assert.That(() => new AimController(mockedAimService.Object,
                mockedCountryService.Object, mockedCityService.Object,
                null, mockedMapper.Object),
                Throws.ArgumentNullException.With.Message.Contains("Category Service"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenCityServiceIsNull()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            // Act & Assert
            Assert.That(() => new AimController(mockedAimService.Object,
                mockedCountryService.Object, null,
                mockedCategoryService.Object, mockedMapper.Object),
                Throws.ArgumentNullException.With.Message.Contains("City Service"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenCountryServiceIsNull()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            // Act & Assert
            Assert.That(() => new AimController(mockedAimService.Object,
                null, mockedCityService.Object,
                mockedCategoryService.Object, mockedMapper.Object),
                Throws.ArgumentNullException.With.Message.Contains("Country Service"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenMapperIsNull()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();

            // Act & Assert
            Assert.That(() => new AimController(mockedAimService.Object,
                mockedCountryService.Object, mockedCityService.Object,
                mockedCategoryService.Object, null),
                Throws.ArgumentNullException.With.Message.Contains("Mapper"));
        }

        [Test]
        public void NotThrow_WhenAllParametersAreValidAndNotNull()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();


            // Act & Assert
            Assert.DoesNotThrow(() => new AimController(mockedAimService.Object,
                mockedCountryService.Object, mockedCityService.Object,
                mockedCategoryService.Object, mockedMapper.Object));
        }
    }
}
