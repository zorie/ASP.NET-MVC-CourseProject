using NUnit.Framework;
using System;
using System.Collections.Generic;
using Moq;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Controllers;
using TestStack.FluentMVCTesting;
using DearDiary.Models;
using DearDiary.Web.Models;

namespace DearDiary.Web.Tests.ControllersTests.AimControllerTests
{
    [TestFixture]
    public class Details_Should
    {
        [TestCase("126")]
        [TestCase("5")]    
        public void CallAimServiceGetById_IfIdIsNotNull(string id)
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            mockedAimService.Setup(x => x.GetAimById(It.IsAny<int>())).Verifiable();

            AimController controller = new AimController(mockedAimService.Object,
                                            mockedCountryService.Object,
                                            mockedCityService.Object, mockedCategoryService.Object,
                                            mockedMapper.Object);

            // Act
            controller.Details(id);

            // Assert
            mockedAimService.Verify(x => x.GetAimById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void RedirectToExplorePage_IfIdIsNull()
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


            // Act & Assert
            controller.WithCallTo(x => x.Details(null))
                .ShouldRedirectTo<ExploreController>(typeof(ExploreController).GetMethod("Index"));
        }
        [Test]
        public void ReturnErrorView_WhenAimNotFound()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            mockedAimService.Setup(x => x.GetAimById(It.IsAny<int>())).Returns((Aim)null);

            AimController controller = new AimController(mockedAimService.Object,
                                            mockedCountryService.Object,
                                            mockedCityService.Object, mockedCategoryService.Object,
                                            mockedMapper.Object);

            // Act & Assert
            controller.WithCallTo(c => c.Details("1")).ShouldRenderView("Error");
        }

        [Test]
        public void MapAimToViewModel()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();
            var mockedAim = new Mock<Aim>();

            mockedAimService.Setup(x => x.GetAimById(It.IsAny<int>())).Returns(mockedAim.Object);
            mockedMapper.Setup(x => x.Map<AimDetailsViewModel>(It.IsAny<Aim>())).Verifiable();

            AimController controller = new AimController(mockedAimService.Object,
                                            mockedCountryService.Object,
                                            mockedCityService.Object, mockedCategoryService.Object,
                                            mockedMapper.Object);
            // Act
            controller.Details("1");

            // Assert
            mockedMapper.Verify(x => x.Map<AimDetailsViewModel>(mockedAim.Object), Times.Once);
        }

        [Test]
        public void ReturnCorrectDefaultView_WhenAimIsNotNull()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();
            var mockedAim = new Mock<Aim>();

            mockedAimService.Setup(x => x.GetAimById(It.IsAny<int>())).Returns(mockedAim.Object);

            AimController controller = new AimController(mockedAimService.Object,
                                            mockedCountryService.Object,
                                            mockedCityService.Object, mockedCategoryService.Object,
                                            mockedMapper.Object);
            // Act & Assert
            controller.WithCallTo(x => x.Details("5")).ShouldRenderDefaultView();
        }

        [Test]
        public void ReturnCorrectDefaultViewWithCorrectAimDetailsModel_WhenAimIsNotNull()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();
            var mockedAim = new Mock<Aim>();
            var mockedAimDetailsViewModel = new Mock<AimDetailsViewModel>();

            mockedAimService.Setup(x => x.GetAimById(It.IsAny<int>())).Returns(mockedAim.Object);
            mockedMapper.Setup(x => x.Map<AimDetailsViewModel>(It.IsAny<Aim>()))
                .Returns(mockedAimDetailsViewModel.Object);


            AimController controller = new AimController(mockedAimService.Object,
                                            mockedCountryService.Object,
                                            mockedCityService.Object, mockedCategoryService.Object,
                                            mockedMapper.Object);
            // Act & Assert
            controller.WithCallTo(x => x.Details("7")).ShouldRenderDefaultView()
                .WithModel(mockedAimDetailsViewModel.Object);
        }
    }
}
