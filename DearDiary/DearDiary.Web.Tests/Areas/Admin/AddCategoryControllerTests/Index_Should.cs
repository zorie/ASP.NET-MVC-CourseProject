using DearDiary.Services.Contracts;
using DearDiary.Web.Areas.Admin.Controllers;
using DearDiary.Web.Areas.Admin.Models;
using DearDiary.Web.AutoMapping;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace DearDiary.Web.Tests.Areas.Admin.AddCategoryControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            var controller = new AddCategoryController(
                mockedCategoryService.Object,
                mockedMapper.Object);

            // Act & Assert
            controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
