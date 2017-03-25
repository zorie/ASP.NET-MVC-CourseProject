using NUnit.Framework;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyCityId_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();

            // Act
            aim.CityId = 15;

            // Assert
            Assert.AreEqual(15, aim.CityId);
        }
    }
}