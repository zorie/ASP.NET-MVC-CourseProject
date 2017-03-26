using DearDiary.Data;
using DearDiary.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DearDiary.Services.Tests.CityServiceTests
{
    [TestFixture]
    public class GetAllCitiesByCountry_Should
    {
        [TestCase("1")]
        [TestCase("25")]
        public void ReturnCorrectCollection(string countryId)
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var cities = new List<City>
            {
                new City { CountryId=1 },
                new City { CountryId=2 },
                new City { CountryId=1 },
                new City { CountryId=3 }
            }.AsQueryable();

            mockedData.Setup(x => x.Cities.All).Returns(cities);

            CityService service = new CityService(mockedData.Object);

            // Act
            var resultCities = service.GetAllCitiesByCountry(countryId);

            var expectedCities = cities.Where(x => x.CountryId == int.Parse(countryId)).ToList();

            // Assert
            CollectionAssert.AreEqual(expectedCities, resultCities);
        }

        [TestCase("10")]
        [TestCase("180")]
        public void ReturnCorrectSizeOfCollection(string id)
        {
            /// Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var cities = new List<City>
            {
                new City { CountryId=180 },
                new City { CountryId=2 },
                new City { CountryId=1 },
                new City { CountryId=3 }
            }.AsQueryable();

            mockedData.Setup(x => x.Cities.All).Returns(cities);

            CityService service = new CityService(mockedData.Object);

            // Act
            var resultCities = service.GetAllCitiesByCountry(id).Count();

            var expectedCities = cities.Where(x => x.CountryId == int.Parse(id)).Count();

            // Assert
            Assert.AreEqual(expectedCities, resultCities);
        }
    }
}
