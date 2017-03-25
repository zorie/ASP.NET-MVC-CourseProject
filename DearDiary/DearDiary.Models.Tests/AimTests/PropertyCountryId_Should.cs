using NUnit.Framework;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyCountryId_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();

            // Act
            aim.CountryId = 15;

            // Assert
            Assert.AreEqual(15, aim.CountryId);
        }
    }
}