using NUnit.Framework;

namespace DearDiary.Models.Tests.CountryTests
{
    [TestFixture]
    public class PropertyName_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Country country = new Country();

            // Act
            country.Name = "Test name";

            // Assert
            Assert.AreEqual("Test name", country.Name);
        }
    }
}
