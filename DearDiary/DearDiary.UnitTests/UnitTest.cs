using NUnit.Framework;

namespace DearDiary.UnitTests
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void Test()
        {
            // Arrange & act & assert
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void Test2()
        {
            // Arrange & act & assert
            Assert.IsTrue(true);
        }
    }
}
