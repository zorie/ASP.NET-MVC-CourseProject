using DearDiary.Data;
using NUnit.Framework;
using System.Linq;

namespace DearDiary.IntegrationTests
{
    [TestFixture]
    public class IntegrationTest
    {
        [Test]
        public void IntegrationTestMethod()
        {
            // Arrange
            DearDiaryDbContext dbContext = new DearDiaryDbContext();

            // Act
            int aimsCount = dbContext.Aims.Count();           

            // Assert
            Assert.AreEqual(0, aimsCount);
        }
    }
}
