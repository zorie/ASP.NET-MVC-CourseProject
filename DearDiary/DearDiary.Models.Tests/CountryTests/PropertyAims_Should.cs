using NUnit.Framework;
using System.Collections.Generic;
using Moq;

namespace DearDiary.Models.Tests.CountryTests
{
    [TestFixture]
    public class PropertyAims_Should
    {
        [Test]
        public void BeVirtualProperty()
        {
            // Arrange
            Country c = new Country();

            // Act
            var isVirtual = c.GetType().GetProperty("Aims").GetAccessors()[0].IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Country c = new Country();
            var aims = new List<Aim>() { new Mock<Aim>().Object, new Mock<Aim>().Object };

            // Act
            c.Aims = aims;

            // Assert
            CollectionAssert.AreEqual(aims, c.Aims);
        }
    }
}
