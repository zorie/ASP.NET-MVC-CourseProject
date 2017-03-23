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
            // these tests run again testing db, not the real one
            // since the real one has changes - dbcontext has changes, but the testing db is the old one -> leading to a problem
            // Arrange
            DearDiaryDbContext dbContext = new DearDiaryDbContext();

            // Act
            int aimsCount = dbContext.Aims.Count();           

            // Assert
            Assert.AreEqual(0, aimsCount);
        }
    }
}
