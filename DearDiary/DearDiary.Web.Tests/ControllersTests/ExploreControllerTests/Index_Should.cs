using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Controllers;
using TestStack.FluentMVCTesting;
using DearDiary.Models;
using DearDiary.Web.Models;

namespace DearDiary.Web.Tests.ControllersTests.ExploreControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void CallMethodGetAllCategories_FromServiceAimCategory()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();
            mockedAimCategoryService.Setup(x => x.GetAimCategories()).Returns(new List<AimCategory>());

            ExploreController controller = new ExploreController(mockedAimService.Object, 
                                                mockedAimCategoryService.Object, mockedMapper.Object);

            // Act
            controller.Index();

            // Assert
            mockedAimCategoryService.Verify(x => x.GetAimCategories(), Times.Once);
        }

        [Test]
        public void CallMapper()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();
            var categories = new List<AimCategory>();

            mockedAimCategoryService.Setup(x => x.GetAimCategories()).Returns(categories);

            mockedMapper.Setup(x => x.Map<IEnumerable<AimCategoryViewModel>>(categories)).Verifiable();

            var controller = new ExploreController(mockedAimService.Object, 
                                    mockedAimCategoryService.Object, mockedMapper.Object);

            // Act
            controller.Index();

            // Assert
            mockedMapper.Verify(x => x.Map<IEnumerable<AimCategoryViewModel>>(categories), Times.Once);
        }

        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            var controller = new ExploreController(mockedAimService.Object, 
                                    mockedAimCategoryService.Object, mockedMapper.Object);

            // Act & Assert
            controller.WithCallTo(x => x.Index()).ShouldRenderDefaultView();
        }

        [Test]
        public void PassTheViewCorrectModel()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();
            var categories = new List<AimCategory>();
            var mappedCategories = new List<AimCategoryViewModel>();

            mockedAimCategoryService.Setup(x => x.GetAimCategories()).Returns(categories);
            mockedMapper
                .Setup(x => x.Map<IEnumerable<AimCategoryViewModel>>(categories))
                .Returns(mappedCategories);
            
            var controller = new ExploreController(mockedAimService.Object, 
                                    mockedAimCategoryService.Object, mockedMapper.Object);

            // Act & Assert
            controller
                .WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<ExploreViewModel>(x => x.AimCategories == mappedCategories);
        }
    }       
}
