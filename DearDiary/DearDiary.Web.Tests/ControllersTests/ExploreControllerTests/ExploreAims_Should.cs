using NUnit.Framework;
using Moq;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Controllers;
using DearDiary.Web.Models;
using DearDiary.Models;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;
using System.Linq;
using System;

namespace DearDiary.Web.Tests.ControllersTests.ExploreControllerTests
{
    [TestFixture]
    public class ExploreAims_Should
    {
        [Test]
        public void CallExploreAims_FromAimService_WithCorrectParameter()
        {
            // Arrange
            string searchWord = "search";
            string sortBy = "sort";
            var categoriesChosen = new int[] { 1, 2 };
            int page = 3;
            // it is a constant
            int aimsPerPage = 5;

            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            ExploreSubmitViewModel submitModel = new ExploreSubmitViewModel()
            {
                SearchWord = searchWord,
                SortBy = sortBy,
                ChosenCategoriesIds = categoriesChosen
            };

            mockedAimService
                .Setup(x => x.ExploreAims(searchWord, categoriesChosen, sortBy, page, aimsPerPage))
                .Verifiable();

            ExploreController controller = new ExploreController(mockedAimService.Object, 
                                                mockedAimCategoryService.Object, mockedMapper.Object);

            // Act
            controller.ExploreAims(submitModel, page);

            // Assert
            mockedAimService
                .Verify(x => x.ExploreAims(searchWord, categoriesChosen, sortBy, page, aimsPerPage), Times.Once);
        }

        [Test]
        public void CallExploreAimsWithDefaultPage_WhenPageParameterIsNull()
        {
            // Arrange
            string searchWord = "word";
            string sortBy = "name";
            var categoriesChosen = new int[] { 4, 2 };
            // it is a constant
            int aimsPerPage = 5;

            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            ExploreSubmitViewModel submitModel = new ExploreSubmitViewModel()
            {
                SearchWord = searchWord,
                SortBy = sortBy,
                ChosenCategoriesIds = categoriesChosen
            };

            mockedAimService
                .Setup(x => x.ExploreAims(searchWord, categoriesChosen, sortBy, 1, aimsPerPage))
                .Verifiable();

            ExploreController controller = new ExploreController(mockedAimService.Object,
                                                mockedAimCategoryService.Object, mockedMapper.Object);

            // Act
            controller.ExploreAims(submitModel, null);

            // Assert
            mockedAimService
                .Verify(x => x.ExploreAims(searchWord, categoriesChosen, sortBy, 1, aimsPerPage), Times.Once);
        }

        [Test]
        public void CallGetAimsCount_FromAimService_WhenValidParametersArePassed()
        {
            // Arrange
            string searchWord = "some searching word";
            var categoriesChosen = new int[] { 1, 16 };

            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            ExploreSubmitViewModel submitModel = new ExploreSubmitViewModel()
            {
                SearchWord = searchWord,
                ChosenCategoriesIds = categoriesChosen
            };

            mockedAimService
                .Setup(x => x.GetAimsCount(searchWord, categoriesChosen))
                .Verifiable();

            ExploreController controller = new ExploreController(mockedAimService.Object,
                                                mockedAimCategoryService.Object, mockedMapper.Object);

            // Act
            controller.ExploreAims(submitModel, null);

            // Assert
            mockedAimService
                .Verify(x => x.GetAimsCount(searchWord, categoriesChosen), Times.Once);
        }

        [Test]
        public void CallMapper_WhenFillingTheViewModel()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            var resultAims = new List<Aim>();

            mockedMapper.Setup(x => x.Map<IEnumerable<AimViewModel>>(resultAims)).Verifiable();

            mockedAimService
                .Setup(x =>
                    x.ExploreAims(It.IsAny<string>(),
                                    It.IsAny<IEnumerable<int>>(),
                                    It.IsAny<string>(),
                                    It.IsAny<int>(),
                                    It.IsAny<int>()))
                .Returns(resultAims);

            ExploreController controller = new ExploreController(mockedAimService.Object,
                                                mockedAimCategoryService.Object, mockedMapper.Object);

            // Act
            controller.ExploreAims(new ExploreSubmitViewModel(), null);

            // Assert
            mockedMapper
                .Verify(x => x.Map<IEnumerable<AimViewModel>>(resultAims), Times.Once);
        }

        [Test]
        public void ReturnCorrectPartialView()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            ExploreController controller = new ExploreController(mockedAimService.Object,
                                                    mockedAimCategoryService.Object, mockedMapper.Object);
            // Act & Assert
            controller.WithCallTo(x => x.ExploreAims(new ExploreSubmitViewModel(), null))
                .ShouldRenderPartialView("_ExploreResultsPartial"); 
        }

        [TestCase(1)]
        [TestCase(26)]
        [TestCase(131)]
        public void ReturnCorrectPartialView_WithCorrectPages(int count)
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();
            // / 5 - count of aims per page - constant
            int pages = (int)Math.Ceiling((double)count / 5);

            mockedAimService
                .Setup(x => x.GetAimsCount(It.IsAny<string>(), It.IsAny<IEnumerable<int>>()))
                .Returns(count);

            ExploreController controller = new ExploreController(mockedAimService.Object,
                                                    mockedAimCategoryService.Object, mockedMapper.Object);
            // Act & Assert
            controller.WithCallTo(x => x.ExploreAims(new ExploreSubmitViewModel(), null))
                .ShouldRenderPartialView("_ExploreResultsPartial").WithModel<ExploreResultsViewModel>(x => x.Pages == pages);
        }

        [Test]
        public void ReturnCorrectPartialView_WithExploreSubmitViewModel()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            ExploreSubmitViewModel model = new ExploreSubmitViewModel();

            ExploreController controller = new ExploreController(mockedAimService.Object,
                                                    mockedAimCategoryService.Object, mockedMapper.Object);
            // Act & Assert
            controller.WithCallTo(x => x.ExploreAims(model, null))
                .ShouldRenderPartialView("_ExploreResultsPartial")
                .WithModel<ExploreResultsViewModel>(x => x.SubmitModel == model);
        }    

        [Test]
        public void ReturnCorrectPartialView_WithCorrectAimsCollection()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedAimCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            var mappedAims = new List<AimViewModel>();

            mockedMapper.Setup(x => x.Map<IEnumerable<AimViewModel>>(It.IsAny<IEnumerable<Aim>>()))
                .Returns(mappedAims);

            ExploreController controller = new ExploreController(mockedAimService.Object,
                                                    mockedAimCategoryService.Object, mockedMapper.Object);
            // Act & Assert
            controller.WithCallTo(x => x.ExploreAims(new ExploreSubmitViewModel(), null))
                .ShouldRenderPartialView("_ExploreResultsPartial")
                .WithModel<ExploreResultsViewModel>(x => x.Aims == mappedAims);
        }
    }
}
