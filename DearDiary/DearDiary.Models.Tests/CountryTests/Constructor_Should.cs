using NUnit.Framework;

namespace DearDiary.Models.Tests.CountryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void InitializeAimsAndCities_WhenCreated()
        {
            // Arrange
            Country country = new Country();

            // Act & Assert
            Assert.IsNotNull(country.Aims);
            Assert.IsNotNull(country.Cities);
        }
    }
}
