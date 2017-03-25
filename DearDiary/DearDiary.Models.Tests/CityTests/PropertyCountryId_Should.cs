using NUnit.Framework;

namespace DearDiary.Models.Tests.CityTests
{
    [TestFixture]
    public class PropertyCountryId_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            City city = new City();

            // Act
            city.CountryId = 1;
            
            // Assert
            Assert.AreEqual(1, city.CountryId);
        }
    }
}