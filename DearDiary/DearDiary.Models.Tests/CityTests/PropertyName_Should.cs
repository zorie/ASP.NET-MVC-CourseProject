using NUnit.Framework;

namespace DearDiary.Models.Tests.CityTests
{
    [TestFixture]
    public class PropertyName_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            City city = new City();

            // Act
            city.Name = "Test name";

            // Assert
            Assert.AreEqual("Test name", city.Name);
        }
    }
}
