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
    public class GetAimsCount_Should
    {
        [Test]
        public void ReturnCountOfAllAims_WhenNoFilteringParametesArePassed()
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var aims = new List<Aim>
            {
                new Aim() { Name = "Jump with parachute", OwnerUsername = "crazy_dude_1"},
                new Aim() { Name = "build a spacecraft", OwnerUsername = "owneroftheworld"},
                new Aim() { Name = "visit china", OwnerUsername = "chinaman"},
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            int count = service.GetAimsCount(null, null);

            // Assert
            Assert.AreEqual(aims.Count(), count);
        }

        [TestCase("visit")]
        [TestCase("world")]
        public void ReturnCorrectCount_WhenFilteringBySearchWord(string searchWord)
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var aims = new List<Aim>
            {
                new Aim() { Name = "Jump with parachute", OwnerUsername = "crazy_dude_1"},
                new Aim() { Name = "build a spacecraft", OwnerUsername = "owneroftheworld"},
                new Aim() { Name = "visit niagara falls", OwnerUsername = "owneroftheworld"},
                new Aim() { Name = "visit china", OwnerUsername = "chinaman"},
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            int count = service.GetAimsCount(searchWord, null);

            int expectedCount = aims.Where(x => x.Name.Contains(searchWord) || x.OwnerUsername.Contains(searchWord)).ToList().Count;
            // Assert
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void ReturnCorrectCount_WhenFilteringByCategories()
        {
            // Arrange
            var categoriesIds = new int[] { 2, 3 };
            var mockedData = new Mock<IDearDiaryData>();

            var aims = new List<Aim>
            {
                new Aim() { Name = "Jump with parachute", OwnerUsername = "crazy_dude_1", AimCategoryId = 2},
                new Aim() { Name = "build a spacecraft", OwnerUsername = "owneroftheworld", AimCategoryId = 1},
                new Aim() { Name = "visit niagara falls", OwnerUsername = "owneroftheworld", AimCategoryId = 3},
                new Aim() { Name = "visit china", OwnerUsername = "chinaman", AimCategoryId = 2 }
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            int count = service.GetAimsCount(null, categoriesIds);

            int expectedCount = aims.Where(x => categoriesIds.Contains(x.AimCategoryId)).ToList().Count;
            // Assert
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void ReturnCorrectCount_WhenFilteringByCategoriesAndSearchWord()
        {
            // Arrange
            var categoriesIds = new int[] { 2, 3 };
            string searchWord = "juMP".ToLower();
            var mockedData = new Mock<IDearDiaryData>();

            var aims = new List<Aim>
            {
                new Aim() { Name = "Jump with parachute", OwnerUsername = "crazy_dude_1", AimCategoryId = 2},
                new Aim() { Name = "build a spacecraft", OwnerUsername = "owneroftheworld", AimCategoryId = 1},
                new Aim() { Name = "visit niagara falls", OwnerUsername = "owneroftheworld", AimCategoryId = 3},
                new Aim() { Name = "visit china", OwnerUsername = "chinaman", AimCategoryId = 2 }
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            int count = service.GetAimsCount(searchWord, categoriesIds);

            int expectedCount = aims
                .Where(x => categoriesIds.Contains(x.AimCategoryId))
                .Where(x => x.Name.ToLower().Contains(searchWord) || x.OwnerUsername.ToLower().Contains(searchWord))
                .ToList().Count;
            // Assert
            Assert.AreEqual(expectedCount, count);
        }
    }
}
