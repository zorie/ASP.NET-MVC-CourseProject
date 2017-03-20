using NUnit.Framework;
using Moq;
using System;
using System.Data.Entity;
using DearDiary.Data.Tests.RepositoriesTests.EFRepositoryTests.Mocks;
using DearDiary.Data.Repositories;

namespace DearDiary.Data.Tests.RepositoriesTests.EFRepositoryTests
{
    [TestFixture]
    public class GetById_Should
    {
        private static Guid[] testGuids = new Guid[] { new Guid()};

        [TestCaseSource("testGuids")]
        public void CallDbSetFindMethodWithCorrectParameter(object id)
        {
            // Arrange
            var mockedContext = new Mock<IDearDiaryDbContext>();
            var mockedDbSet = new Mock<IDbSet<MockedModel>>();

            mockedContext.Setup(c => c.Set<MockedModel>()).Returns(mockedDbSet.Object);
            mockedDbSet.Setup(x => x.Find(It.IsAny<object>())).Verifiable();

            var repo = new EFGenericRepository<MockedModel>(mockedContext.Object);

            // Act
            repo.GetById(id);

            // Assert
            mockedDbSet.Verify(s => s.Find(id), Times.Once);
        }

        [TestCaseSource("testGuids")]
        public void ReturnCorrectItem_WhenIdPassed(Guid id)
        {
            // Arrange
            var mockedContext = new Mock<IDearDiaryDbContext>();
            var mockedDbSet = new Mock<IDbSet<MockedModel>>();
            var mockedModel = new MockedModel();
            //mockedModel.Id = id;
            mockedContext.Setup(c => c.Set<MockedModel>()).Returns(mockedDbSet.Object);
            mockedDbSet.Setup(x => x.Find(It.IsAny<object>())).Returns(mockedModel);

            var repo = new EFGenericRepository<MockedModel>(mockedContext.Object);

            // Act
            var result = repo.GetById(id);

            // Assert
            Assert.AreEqual(mockedModel, result);
        }
    }
}
