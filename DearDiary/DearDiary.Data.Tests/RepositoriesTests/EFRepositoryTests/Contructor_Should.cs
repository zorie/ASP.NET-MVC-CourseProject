using NUnit.Framework;
using Moq;
using DearDiary.Data.Repositories;
using DearDiary.Data.Tests.RepositoriesTests.EFRepositoryTests.Mocks;

namespace DearDiary.Data.Tests.RepositoriesTests.EFRepositoryTests
{
    [TestFixture]
    public class Contructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextIsNull()
        {
            // Arrange
            IDearDiaryDbContext dbContext = null;

            // Act & Assert
            Assert.That(() => 
                new EFGenericRepository<MockedModel>(dbContext), 
                Throws.ArgumentNullException.With.Message.Contains("Database context cannot be null."));
        }

        [Test]
        public void NotThrowAnyException_WhenDbContextIsNOTNull()
        {
            // Arrange
            var mockedContext = new Mock<IDearDiaryDbContext>();

            // Act & Assert
            Assert.DoesNotThrow(() => new EFGenericRepository<MockedModel>(mockedContext.Object));
        }

        [Test]
        public void CallDbContextSetMethod_WhenValidParametersArePassed()
        {
            // Arrange
            var mockedContext = new Mock<IDearDiaryDbContext>();
            mockedContext.Setup(c => c.Set<MockedModel>()).Verifiable();

            // Act
            var repo = new EFGenericRepository<MockedModel>(mockedContext.Object);

            // Assert
            mockedContext.Verify(c => c.Set<MockedModel>(), Times.Once);
        }
    }
}
