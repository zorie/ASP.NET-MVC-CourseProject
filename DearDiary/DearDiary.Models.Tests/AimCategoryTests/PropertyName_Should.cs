using NUnit.Framework;

namespace DearDiary.Models.Tests.AimCategoryTests
{
    [TestFixture]
    public class PropertyName_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            AimCategory category = new AimCategory();

            // Act
            category.Name = "Category name";

            // Assert
            StringAssert.AreEqualIgnoringCase("Category name", category.Name);
        }
    }
}
