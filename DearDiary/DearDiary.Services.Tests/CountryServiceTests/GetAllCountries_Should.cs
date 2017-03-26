using DearDiary.Data;
using DearDiary.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DearDiary.Services.Tests.CountryServiceTests
{
    [TestFixture]
    public class GetAllCountries_Should
    {
        [Test]
        public void ReturnCorrectCollection()
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var countries = new List<Country>
            {
                new Mock<Country>().Object,
                new Mock<Country>().Object,
                new Mock<Country>().Object
            }.AsQueryable();

            mockedData.Setup(x => x.Countries.All).Returns(countries);

            CountryService service = new CountryService(mockedData.Object);

            // Act
            var resultCountries = service.GetAllCountries();

            // Assert
            CollectionAssert.AreEqual(countries, resultCountries);
        }

        [Test]
        public void ReturnCorrectSizeOfCollection()
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var countries = new List<Country>
            {
                new Mock<Country>().Object,
                new Mock<Country>().Object,
                new Mock<Country>().Object
            }.AsQueryable();

            mockedData.Setup(x => x.Countries.All).Returns(countries);

            CountryService service = new CountryService(mockedData.Object);

            // Act
            var resultCountries = service.GetAllCountries();

            // Assert
            Assert.AreEqual(countries.Count(), resultCountries.Count());
        }
    }
}
