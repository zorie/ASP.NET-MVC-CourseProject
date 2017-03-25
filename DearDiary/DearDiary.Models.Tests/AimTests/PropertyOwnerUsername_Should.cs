using NUnit.Framework;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyOwnerUsername_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();

            // Act
            aim.OwnerUsername = "Some user name";

            // Assert
            StringAssert.AreEqualIgnoringCase("Some user name", aim.OwnerUsername);
        }
    }
}
