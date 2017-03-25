using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DearDiary.Models.Tests.CountryTests
{
    [TestFixture]
    public class PropertyCities_Should
    {
        [Test]
        public void BeVirtualProperty()
        {
            // Arrange
            Country c = new Country();

            // Act
            var isVirtual = c.GetType().GetProperty("Cities").GetAccessors()[0].IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Country c = new Country();
            var cities = new List<City>() { new Mock<City>().Object, new Mock<City>().Object };

            // Act
            c.Cities = cities;

            // Assert
            CollectionAssert.AreEqual(cities, c.Cities);
        }
    }
}