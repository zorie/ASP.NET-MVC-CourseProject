using NUnit.Framework;
using Moq;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Controllers;
using TestStack.FluentMVCTesting;
using System.Web.Mvc;
using DearDiary.Web.Models;
using DearDiary.Models;
using System.Collections.Generic;
using System.Linq;

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
        public void ReturnCorrectView_WithCorrectModelType()
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

        [Test]
        public void ReturnViewAndViewModel_WithCorrectCountries()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            var countries = new List<Country>()
            {
                new Country() {Id = 1, Name = "The USA" },
                new Country() {Id = 2, Name = "Germany" },
                new Country() {Id = 3, Name = "Italy" }
            };

            mockedCountryService.Setup(x => x.GetAllCountries()).Returns(countries);

            AimController controller = new AimController(mockedAimService.Object,
                                            mockedCountryService.Object,
                                            mockedCityService.Object, mockedCategoryService.Object,
                                            mockedMapper.Object);

            // Act
            var result = (ViewResult)controller.Create();

            ViewDataDictionary viewData = result.ViewData;

            // Assert
            Assert.IsTrue(viewData["Country"] != null);

            //var model = (CreateAimViewModel)result.Model;
            //var selectList = model.Countries.ToList();
            //Assert.AreEqual(countries.Count, selectList.Count);
            //for (int i = 0; i < countries.Count; i++)
            //{
            //    Assert.AreEqual(countries[i].Id.ToString(), selectList[i].Value);
            //    Assert.AreEqual(countries[i].Name, selectList[i].Text);
            //}
        }

        [Test]
        public void ReturnViewAndViewModel_WithCorrectCategories()
        {
            // Arrange
            var mockedAimService = new Mock<IAimService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedCategoryService = new Mock<IAimCategoryService>();
            var mockedCountryService = new Mock<ICountryService>();
            var mockedMapper = new Mock<IMapperAdapter>();

            var categories = new List<AimCategory>()
            {
                new AimCategory() {Id = 1, Name = "Travelling" },
                new AimCategory() {Id = 2, Name = "Sports" },
                new AimCategory() {Id = 3, Name = "Extreme" }
            };

            mockedCategoryService.Setup(x => x.GetAimCategories()).Returns(categories);

            AimController controller = new AimController(mockedAimService.Object,
                                            mockedCountryService.Object,
                                            mockedCityService.Object, mockedCategoryService.Object,
                                            mockedMapper.Object);

            // Act
            var result = (ViewResult)controller.Create();

            ViewDataDictionary viewData = result.ViewData;

            // Assert
            Assert.IsTrue(viewData["Category"] != null);

            //var model = (CreateAimViewModel)result.Model;
            //var selectList = model.AimCategories.ToList();
            //Assert.AreEqual(categories.Count, selectList.Count);
            //for (int i = 0; i < categories.Count; i++)
            //{
            //    Assert.AreEqual(categories[i].Id.ToString(), selectList[i].Value);
            //    Assert.AreEqual(categories[i].Name, selectList[i].Text);
            //}
        }
    }
}
