using DearDiary.Data.Repositories;
using DearDiary.Data.Tests.RepositoriesTests.EFRepositoryTests.Mocks;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace DearDiary.Data.Tests.RepositoriesTests.EFRepositoryTests
{
    [TestFixture]
    public class All_Should
    {
        [Test]
        public void ReturnDbSet()
        {
            // Arrange
            var mockedContext = new Mock<IDearDiaryDbContext>();
            var mockedDbSet = new Mock<IDbSet<MockedModel>>();

            mockedContext.Setup(c => c.Set<MockedModel>()).Returns(mockedDbSet.Object);

            var repo = new EFGenericRepository<MockedModel>(mockedContext.Object);

            // Act
            var result = repo.All;

            // Assert
            Assert.AreEqual(mockedDbSet.Object, result);
        }
    }
}
