using Moq;
using NUnit.Framework;

namespace DearDiary.Models.Tests.CityTests
{
    [TestFixture]
    public class PropertyCountry_Should
    {
        [Test]
        public void BeVirtualProperty()
        {
            // Arrange
            City city = new City();

            // Act
            var isVirtual = city.GetType().GetProperty("Country").GetAccessors()[0].IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            City city = new City();
            var c = new Mock<Country>().Object;

            // Act
            city.Country = c;

            // Assert
            Assert.AreEqual(c, city.Country);
        }
    }
}
