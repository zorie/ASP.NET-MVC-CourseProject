using NUnit.Framework;

namespace DearDiary.Models.Tests.AimTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void InitializeUserLists_WhenCreated()
        {
            // Arrange
            Aim aim = new Aim();

            // Act & Assert
            Assert.IsNotNull(aim.InUsersBucketList);
            Assert.IsNotNull(aim.InUsersDoneList);
        }
    }
}
