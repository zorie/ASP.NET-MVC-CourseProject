using NUnit.Framework;
using Moq;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Controllers;
using TestStack.FluentMVCTesting;
using System.Web.Mvc;
using DearDiary.Web.Models;

namespace DearDiary.Web.Tests.ControllersTests.AimControllerTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ReturnViewResult()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            AimController controller = new AimController(mockedAimService.Object,
                                            mockedCountryService.Object,
                                            mockedCityService.Object, mockedCategoryService.Object,
                                            mockedMapper.Object);

            // Act 
            var result = controller.Create();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void ReturnCorrectView_WithCorrectModel()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();
            var model = new Mock<CreateAimViewModel>();

            AimController controller = new AimController(mockedAimService.Object,
                                            mockedCountryService.Object,
                                            mockedCityService.Object, mockedCategoryService.Object,
                                            mockedMapper.Object);

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsInstanceOf<CreateAimViewModel>(result.Model);
        }
    }
}
