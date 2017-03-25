using NUnit.Framework;

namespace DearDiary.Models.Tests.AimCategoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void InitializeAims_WhenCreated()
        {
            // Arrange
            AimCategory category = new AimCategory();

            // Act & Assert
            Assert.IsNotNull(category.Aims);
        }
    }
}
