using DearDiary.Data;
using DearDiary.Services;
using Moq;
using NUnit.Framework;
using System;

namespace DearDiary.Services.Tests.CountryServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDataIsNull()
        {
            // Arrange & Act & Assert

            Assert.Throws<ArgumentNullException>(() => new CountryService(null));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenDataIsNull()
        {
            // Arrange & Act & Assert
            Assert.That(() => new CountryService(null), Throws.ArgumentNullException.With.Message.Contains("Data"));
        }

        [Test]
        public void NotThrowAnyException_WhenDataIsValidAndNotNull()
        {
            // Arrange 
            var data = new Mock<IDearDiaryData>();

            // Act & Assert
            Assert.DoesNotThrow(() => new CountryService(data.Object));
        }
    }
}
