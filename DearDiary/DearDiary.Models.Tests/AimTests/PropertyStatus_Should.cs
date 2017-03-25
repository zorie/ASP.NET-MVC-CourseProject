using NUnit.Framework;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyStatus_Should
    {
        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();

            // Act
            aim.Status = Status.Fulfilled.ToString();
            
            // Assert
            StringAssert.Contains("Fulfilled", aim.Status);
        }
    }
}