using DearDiary.Data;
using DearDiary.Models;
using DearDiary.Services;
using Moq;
using NUnit.Framework;
using System;

namespace DearDiary.Services.Tests.AimServiceTests
{
    [TestFixture]
    public class AddAim_Should
    {
        [Test]
        public void CallDataAimsAddMethod()
        {
            // Arrange
            var mockedAim = new Mock<Aim>();
            var mockedData = new Mock<IDearDiaryData>();

            mockedData.Setup(x => x.Aims.Add(It.IsAny<Aim>())).Verifiable();

            AimService service = new AimService(mockedData.Object);

            // Act
            service.AddAim(mockedAim.Object);

            // Assert
            mockedData.Verify(x => x.Aims.Add(It.IsAny<Aim>()), Times.Once);
        }

        [Test]
        public void CallAimDataMethodAddAim_WithCorrectAim()
        {
            // Arrange
            var mockedAim = new Mock<Aim>();
            var mockedData = new Mock<IDearDiaryData>();

            mockedData.Setup(x => x.Aims.Add(mockedAim.Object)).Verifiable();

            AimService service = new AimService(mockedData.Object);

            // Act
            service.AddAim(mockedAim.Object);

            // Assert
            mockedData.Verify(x => x.Aims.Add(mockedAim.Object), Times.Once);
        }

        [Test]
        public void CallDataSaveChanges()
        {
            // Arrange
            var mockedAim = new Mock<Aim>();
            var mockedData = new Mock<IDearDiaryData>();

            mockedData.Setup(x => x.Aims.Add(It.IsAny<Aim>())).Verifiable();
            mockedData.Setup(x => x.SaveChanges()).Verifiable();

            AimService service = new AimService(mockedData.Object);

            // Act
            service.AddAim(mockedAim.Object);

            // Assert
            mockedData.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
