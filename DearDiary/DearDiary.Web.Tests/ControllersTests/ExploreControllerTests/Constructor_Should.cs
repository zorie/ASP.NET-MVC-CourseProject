using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Controllers;

namespace DearDiary.Web.Tests.ControllersTests.ExploreControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenAimServiceIsNull()
        {
            // Arrange
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            // Act & Assert
            Assert.That(() => new ExploreController(null, mockedAimCategoryService.Object, mockedMapper.Object),
                Throws.ArgumentNullException.With.Message.Contains("Aim Service"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenAimCategoryServiceIsNull()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            // Act & Assert
            Assert.That(() => new ExploreController(mockedAimService.Object, null, mockedMapper.Object),
                Throws.ArgumentNullException.With.Message.Contains("Category Service"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenMapperIsNull()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();        
            var mockedAimCategoryService = new Mock<IAimCategoryService>();

            // Act & Assert
            Assert.That(() => new ExploreController(mockedAimService.Object, mockedAimCategoryService.Object, null),
                Throws.ArgumentNullException.With.Message.Contains("Mapper"));
        }

        [Test]
        public void NotThrow_WhenConstructorParametersAreValid()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            // Act & Assert
            Assert.DoesNotThrow(() => new ExploreController(mockedAimService.Object, mockedAimCategoryService.Object, mockedMapper.Object));
        }
    }
}
