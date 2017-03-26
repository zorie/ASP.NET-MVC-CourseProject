using NUnit.Framework;
using Moq;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Controllers;
using System.Collections.Generic;
using DearDiary.Models;
using TestStack.FluentMVCTesting;
using System.Web.Mvc;

namespace DearDiary.Web.Tests.ControllersTests.AimControllerTests
{
    [TestFixture]
    public class GetCities_Should
    {
        [Test]        
        public void CallCityService_GetAllCitiesByCountry()
        {
            // Arrange
            string countryId = "132";
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            mockedCityService.Setup(x => x.GetAllCitiesByCountry(It.IsAny<string>())).Verifiable();
            mockedCityService.Setup(x => x.GetAllCitiesByCountry(It.IsAny<string>())).Returns(new List<City>());

            AimController controller = new AimController(mockedAimService.Object,
                                           mockedCountryService.Object,
                                           mockedCityService.Object, mockedCategoryService.Object,
                                           mockedMapper.Object);

            // Act 
            var jsonResult = controller.GetCities(countryId);

            // Assert
            mockedCityService.Verify(x => x.GetAllCitiesByCountry(countryId), Times.Once);
        }

        [Test]
        public void ReturnJsonWithSuccess()
        {
            // Arrange
            string countryId = "132";
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCities = new List<City>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            // TODO: how axectly to test this
            List<SelectListItem> cities = new List<SelectListItem>();
            var list = new SelectList(cities, "Value", "Text");

            mockedCityService.Setup(x => x.GetAllCitiesByCountry(It.IsAny<string>())).Returns(mockedCities);

            AimController controller = new AimController(mockedAimService.Object,
                                           mockedCountryService.Object,
                                           mockedCityService.Object, mockedCategoryService.Object,
                                           mockedMapper.Object);

            // Act & Assert
            controller.WithCallTo(x => x.GetCities(countryId))
                .ShouldReturnJson();
        }
    }
}
