using NUnit.Framework;
using System.Collections.Generic;
using Moq;

namespace DearDiary.Models.Tests.CityTests
{
    [TestFixture]
    public class PropertyAims_Should
    {
        [Test]
        public void BeVirtualProperty()
        {
            // Arrange
            City city = new City();

            // Act
            var isVirtual = city.GetType().GetProperty("Aims").GetAccessors()[0].IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            City city = new City();
            var aims = new List<Aim>() { new Mock<Aim>().Object, new Mock<Aim>().Object };

            // Act
            city.Aims = aims;

            // Assert
            CollectionAssert.AreEqual(aims, city.Aims);
        }
    }
}
