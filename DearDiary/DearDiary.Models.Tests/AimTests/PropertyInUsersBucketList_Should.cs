using NUnit.Framework;
using System.Collections.Generic;
using Moq;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class PropertyInUsersBucketList_Should
    {
        [Test]
        public void BeVirtualProperty()
        {
            // Arrange
            Aim aim = new Aim();

            // Act
            var isVirtual = aim.GetType().GetProperty("InUsersBucketList").GetAccessors()[0].IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void HaveGetterAndSetter()
        {
            // Arrange
            Aim aim = new Aim();
            var inUsersBucketList = new List<User>() { new Mock<User>().Object, new Mock<User>().Object };

            // Act
            aim.InUsersBucketList = inUsersBucketList;

            // Assert
            CollectionAssert.AreEqual(inUsersBucketList, aim.InUsersBucketList);
        }
    }
}
