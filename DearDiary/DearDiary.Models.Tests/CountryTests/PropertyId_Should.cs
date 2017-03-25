using NUnit.Framework;

namespace DearDiary.Models.Tests.CountryTests
{
    [TestFixture]
    public class PropertyId_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Country country = new Country();
            
            // Act
            country.Id = 1;

            // Assert
            Assert.AreEqual(1, country.Id);
        }
    }
}
