using NUnit.Framework;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyId_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();
            
            // Act
            aim.Id = 1;

            // Assert
            Assert.AreEqual(1, aim.Id);
        }
    }
}
