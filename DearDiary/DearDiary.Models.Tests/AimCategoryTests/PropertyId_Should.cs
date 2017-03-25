using NUnit.Framework;

namespace DearDiary.Models.Tests.AimCategoryTests
{
    [TestFixture]
    public class PropertyId_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            AimCategory category = new AimCategory();
            
            // Act
            category.Id = 2;

            // Assert
            Assert.AreEqual(2, category.Id);
        }
    }
}
