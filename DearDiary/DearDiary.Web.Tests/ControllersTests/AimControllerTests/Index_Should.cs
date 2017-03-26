using NUnit.Framework;
using Moq;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Controllers;
using TestStack.FluentMVCTesting;

namespace DearDiary.Web.Tests.ControllersTests.AimControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void RedirectToExplorePage()
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
            controller.WithCallTo(x => x.Index())
                .ShouldRedirectTo<ExploreController>(typeof(ExploreController).GetMethod("Index"));
        }
    }
}
