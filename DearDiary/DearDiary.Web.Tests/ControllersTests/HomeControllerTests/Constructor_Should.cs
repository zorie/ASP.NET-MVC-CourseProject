using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Controllers;
using Moq;
using NUnit.Framework;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace DearDiary.Web.Tests.ControllersTests.HomeControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            var controller = new HomeController(mockedAimService.Object, mockedMapper.Object);

            // Act & Assert
            controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }
    }    
}
