using Moq;
using NUnit.Framework;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyAimCategory_Should
    {
        [Test]
        public void BeVirtualProperty()
        {
            // Arrange
            Aim aim = new Aim();

            // Act
            var isVirtual = aim.GetType().GetProperty("AimCategory").GetAccessors()[0].IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();
            var c = new Mock<AimCategory>().Object;

            // Act
            aim.AimCategory = c;

            // Assert
            Assert.AreEqual(c, aim.AimCategory);
        }
    }
}
