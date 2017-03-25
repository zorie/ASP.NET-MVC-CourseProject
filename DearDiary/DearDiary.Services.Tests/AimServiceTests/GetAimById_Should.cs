using DearDiary.Data;
using DearDiary.Models;
using DearDiary.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DearDiary.Services.Tests.AimServiceTests
{
    [TestFixture]
    public class GetAimById_Should
    {
        [TestCase(13)]
        [TestCase(25)]
        public void ReturnNull_WhenAimIsNotFound(int id)
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var aims = new List<Aim>
            {
                new Mock<Aim>().Object,
                new Mock<Aim>().Object,
                new Mock<Aim>().Object
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            Aim aim = service.GetAimById(id);

            // Assert
            Assert.IsNull(aim);
        }

        [TestCase(15)]
        [TestCase(25)]
        public void ReturnCorrectAim_WhenAimWithSuchIdExists(int id)
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();
            var expectedAim = new Aim();
            expectedAim.Id = id;
            var oneMoreAim = new Aim();
            oneMoreAim.Id = 13;
            var oneMoreAimTwo = new Aim();
            oneMoreAimTwo.Id = 55;

            var aims = new List<Aim>
            {
                oneMoreAim,
                oneMoreAimTwo,
                expectedAim
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            Aim aim = service.GetAimById(id);

            // Assert
            Assert.AreEqual(expectedAim, aim);
        }
    }
}
