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
            // this should not be the context - it connects to the real db?
            // Arrange
            DearDiaryDbContext dbContext = new DearDiaryDbContext();

            // Act
            int aimsCount = dbContext.Aims.Count();           

            // Assert
            Assert.AreEqual(0, 0);
        }
    }
}
