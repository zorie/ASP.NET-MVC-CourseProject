using NUnit.Framework;
using Moq;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Areas.Admin.Controllers;

namespace DearDiary.Web.Tests.Areas.Admin.AddCategoryControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenCategoryServiceIsNull()
        {
            // Arrange
            var mockedMapper = new Mock<IMapperAdapter>();

            // Act & Assert
            Assert.That(() => new AddCategoryController(
                null,                
                mockedMapper.Object),
                Throws.ArgumentNullException.With.Message.Contains("Category Service"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenMapperIsNull()
        {
            // Arrange
            var mockedCategoryService = new Mock<IAimCategoryService>();

            // Act & Assert
            Assert.That(() => new AddCategoryController(
                mockedCategoryService.Object,
                null),
                Throws.ArgumentNullException.With.Message.Contains("Mapper"));
        }

        [Test]
        public void NotThrowException_WhenParametersAreValid()
        {
            // Arrange
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            // Act & Assert
            Assert.DoesNotThrow(() => new AddCategoryController(
                mockedCategoryService.Object,
                mockedMapper.Object));
        }
    }
}
