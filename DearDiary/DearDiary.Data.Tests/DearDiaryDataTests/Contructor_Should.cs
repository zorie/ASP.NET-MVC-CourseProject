using NUnit.Framework;
using Moq;
using DearDiary.Data.Repositories;
using DearDiary.Models;

namespace DearDiary.Data.Tests.DearDiaryDataTests
{
    [TestFixture]
    public class Contructor_Should
    {
        [Test]
        public void ThrowCorrectArgumentNullException_WhenOneOfTheConstructorParametersIsNull()
        {
            // Arrange
            IDearDiaryDbContext dbContext = null;
            var mockedUsers = new Mock<IEFGenericRepository<User>>();
            var mockedAims = new Mock<IEFGenericRepository<Aim>>();
            var mockedAimCategories = new Mock<IEFGenericRepository<AimCategory>>();
            var mockedCities = new Mock<IEFGenericRepository<City>>();
            var mockedCountries = new Mock<IEFGenericRepository<Country>>();

            // Act & Assert
            Assert.That(() => 
                new DearDiaryData (dbContext, 
                mockedUsers.Object, 
                mockedAims.Object, 
                mockedAimCategories.Object,
                mockedCities.Object, 
                mockedCountries.Object), 
                Throws.ArgumentNullException.With.Message.Contains("Database context cannot be null."));
        }

        [Test]
        public void NotThrowAnyException_WhenParametersAreNotNull()
        {
            // Arrange
            var mockedDbContext = new Mock<IDearDiaryDbContext>();
            var mockedUsers = new Mock<IEFGenericRepository<User>>();
            var mockedAims = new Mock<IEFGenericRepository<Aim>>();
            var mockedAimCategories = new Mock<IEFGenericRepository<AimCategory>>();
            var mockedCities = new Mock<IEFGenericRepository<City>>();
            var mockedCountries = new Mock<IEFGenericRepository<Country>>();

            // Act & Assert
            Assert.DoesNotThrow(() =>
                new DearDiaryData(mockedDbContext.Object,
                mockedUsers.Object,
                mockedAims.Object,
                mockedAimCategories.Object,
                mockedCities.Object,
                mockedCountries.Object));
        }
    }
}
