using NUnit.Framework;

namespace DearDiary.Models.Tests.CityTests
{
    [TestFixture]
    public class PropertyId_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            City city = new City();
            
            // Act
            city.Id = 1;

            // Assert
            Assert.AreEqual(1, city.Id);
        }
    }
}
