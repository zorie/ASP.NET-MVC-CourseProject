using Moq;
using NUnit.Framework;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyCity_Should
    {
        [Test]
        public void BeVirtualProperty()
        {
            // Arrange
            Aim aim = new Aim();

            // Act
            var isVirtual = aim.GetType().GetProperty("City").GetAccessors()[0].IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();
            var c = new Mock<City>().Object;

            // Act
            aim.City = c;

            // Assert
            Assert.AreEqual(c, aim.City);
        }
    }
}
