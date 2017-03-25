using NUnit.Framework;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyAimCategoryId_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();

            // Act
            aim.AimCategoryId = 15;

            // Assert
            Assert.AreEqual(15, aim.AimCategoryId);
        }
    }
}