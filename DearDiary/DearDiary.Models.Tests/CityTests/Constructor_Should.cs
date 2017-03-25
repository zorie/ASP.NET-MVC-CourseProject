using NUnit.Framework;

namespace DearDiary.Models.Tests.CityTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void InitializeAims_WhenCreated()
        {
            // Arrange
            City city = new City();

            // Act & Assert
            Assert.IsNotNull(city.Aims);
        }
    }
}
