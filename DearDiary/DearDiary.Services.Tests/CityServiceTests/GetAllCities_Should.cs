using DearDiary.Data;
using DearDiary.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearDiary.Services.Tests.CityServiceTests
{
    [TestFixture]
    public class GetAllCities_Should
    {
        [Test]
        public void ReturnCorrectCollection()
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var cities = new List<City>
            {
                new Mock<City>().Object,
                new Mock<City>().Object,
                new Mock<City>().Object
            }.AsQueryable();

            mockedData.Setup(x => x.Cities.All).Returns(cities);

            CityService service = new CityService(mockedData.Object);

            // Act
            var resultCities = service.GetAllCities();

            // Assert
            CollectionAssert.AreEqual(cities, resultCities);
        }

        [Test]
        public void ReturnCorrectSizeOfCollection()
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var cities = new List<City>
            {
                new Mock<City>().Object,
                new Mock<City>().Object,
                new Mock<City>().Object
            }.AsQueryable();

            mockedData.Setup(x => x.Cities.All).Returns(cities);

            CityService service = new CityService(mockedData.Object);

            // Act
            var resultCities = service.GetAllCities();

            // Assert
            Assert.AreEqual(cities.Count(), resultCities.Count());
        }
    }
}
