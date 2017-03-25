using NUnit.Framework;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyPhoto_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();

            // Act
            aim.Photo = "image.png";

            // Assert
            StringAssert.AreEqualIgnoringCase("image.png", aim.Photo);
        }
    }
}
