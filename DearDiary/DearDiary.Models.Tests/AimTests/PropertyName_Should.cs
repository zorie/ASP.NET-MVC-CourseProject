using NUnit.Framework;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyName_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();

            // Act
            aim.Name = "Test name";

            // Assert
            Assert.AreEqual("Test name", aim.Name);
        }
    }
}
