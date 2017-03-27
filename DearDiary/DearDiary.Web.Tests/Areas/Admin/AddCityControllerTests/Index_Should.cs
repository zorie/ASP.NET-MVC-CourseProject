using DearDiary.Services.Contracts;
using DearDiary.Web.Areas.Admin.Controllers;
using DearDiary.Web.Areas.Admin.Models;
using DearDiary.Web.AutoMapping;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace DearDiary.Web.Tests.Areas.Admin.AddCityControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var mockedCityService = new Mock<ICityService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            var controller = new AddCityController(
                mockedCityService.Object,
                mockedCountryService.Object,
                mockedMapper.Object);

            // Act & Assert
            controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
