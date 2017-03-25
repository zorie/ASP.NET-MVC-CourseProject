using Moq;
using NUnit.Framework;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyCountry_Should
    {
        [Test]
        public void BeVirtualProperty()
        {
            // Arrange
            Aim aim = new Aim();

            // Act
            var isVirtual = aim.GetType().GetProperty("Country").GetAccessors()[0].IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();
            var c = new Mock<Country>().Object;

            // Act
            aim.Country = c;

            // Assert
            Assert.AreEqual(c, aim.Country);
        }
    }
}
