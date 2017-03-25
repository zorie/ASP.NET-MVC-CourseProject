using NUnit.Framework;
using System.Collections.Generic;
using Moq;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyInUsersDoneList_Should
    {
        [Test]
        public void BeVirtualProperty()
        {
            // Arrange
            Aim aim = new Aim();

            // Act
            var isVirtual = aim.GetType().GetProperty("InUsersDoneList").GetAccessors()[0].IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();
            var donelist = new List<User>() { new Mock<User>().Object, new Mock<User>().Object };

            // Act
            aim.InUsersDoneList = donelist;

            // Assert
            CollectionAssert.AreEqual(donelist, aim.InUsersDoneList);
        }
    }
}
