using NUnit.Framework;
using System.Collections.Generic;
using Moq;

namespace DearDiary.Models.Tests.AimCategoryTests
{
    [TestFixture]
    public class PropertyAims_Should
    {
        [Test]
        public void BeVirtualProperty()
        {
            // Arrange
            AimCategory category = new AimCategory();

            // Act
            var isVirtual = category.GetType().GetProperty("Aims").GetAccessors()[0].IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            AimCategory category = new AimCategory();
            var aims = new List<Aim>() { new Mock<Aim>().Object, new Mock<Aim>().Object };

            // Act
            category.Aims = aims;

            // Assert
            CollectionAssert.AreEqual(aims, category.Aims);
        }
    }
}
