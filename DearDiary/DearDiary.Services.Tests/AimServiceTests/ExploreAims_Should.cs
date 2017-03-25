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
    public class ExploreAims_Should
    {
        [TestCase("parachute")]
        [TestCase("visit")]
        [TestCase("owner")]
        public void FilterBySearchWord(string searchWord)
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
            var result = service.ExploreAims(searchWord, null, null);

            // Assert
            var expectedAims = aims.Where(x => x.Name.Contains(searchWord) || x.OwnerUsername.Contains(searchWord)).ToList();
            CollectionAssert.AreEquivalent(expectedAims, result);
        }

        [TestCase(1, 8)]
        [TestCase(2)]
        [TestCase(3)]
        public void FilterByAimCategories(params int[] categoriesIds)
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();
            var aims = new List<Aim>
            {
                new Aim() { AimCategoryId = 1 },
                new Aim() { AimCategoryId = 2 },
                new Aim() { AimCategoryId = 8 },
                new Aim() { AimCategoryId = 1 },
                new Aim() { AimCategoryId = 2 },
                new Aim() { AimCategoryId = 1 },
                new Aim() { AimCategoryId = 2 },
                new Aim() { AimCategoryId = 2 }

            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            var filteredAims = service.ExploreAims(null, categoriesIds, null);

            // Assert
            var expectedAims = aims.Where(x => categoriesIds.Contains(x.AimCategoryId)).ToList();
            CollectionAssert.AreEquivalent(expectedAims, filteredAims);
        }

        [Test]
        public void FilterBySearchWordAndAimCategories()
        {
            // Arrange
            var searchWord = "crazy_dude";
            var categoriesIds = new int[] { 3 };
            var mockedData = new Mock<IDearDiaryData>();

            var aims = new List<Aim>
            {
                new Aim() { Name = "Jump with parachute", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "build a spacecraft", OwnerUsername = "owneroftheworld", AimCategoryId = 4},
                new Aim() { Name = "visit russia", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "visit usa", OwnerUsername = "crazy_dude_1", AimCategoryId = 1},
                new Aim() { Name = "visit egypt", OwnerUsername = "chinaman", AimCategoryId = 4}
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            var filteredAims = service.ExploreAims(searchWord, categoriesIds, null);

            // Assert
            var expectedAims = aims.Where(x => x.Name.Contains(searchWord) || x.OwnerUsername.Contains(searchWord))
                .Where(x => categoriesIds.Contains(x.AimCategoryId)).ToList();

            CollectionAssert.AreEquivalent(expectedAims, filteredAims);
        }

        [Test]
        public void ReturnAllAims_WhenNoParametersArePassed()
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var aims = new List<Aim>
            {
                new Aim() { Name = "Jump with parachute", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "build a spacecraft", OwnerUsername = "owneroftheworld", AimCategoryId = 4},
                new Aim() { Name = "visit russia", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "visit usa", OwnerUsername = "crazy_dude_1", AimCategoryId = 1},
                new Aim() { Name = "visit egypt", OwnerUsername = "chinaman", AimCategoryId = 4}
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            var filteredAims = service.ExploreAims(null, null, null);

            // Assert
            CollectionAssert.AreEquivalent(aims.ToList(), filteredAims);
        }

        [Test]
        public void ReturnOrderedAimsByDefault()
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var aims = new List<Aim>
            {
                new Aim() { Name = "Jump with parachute", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "build a spacecraft", OwnerUsername = "owneroftheworld", AimCategoryId = 4},
                new Aim() { Name = "visit russia", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "visit usa", OwnerUsername = "crazy_dude_1", AimCategoryId = 1},
                new Aim() { Name = "visit egypt", OwnerUsername = "chinaman", AimCategoryId = 4}
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            var filteredAndOrderedAims = service.ExploreAims(null, null, "invalidSorting");

            // Assert
            var expectedAims = aims.OrderBy(x => x.Name).ToList();
            CollectionAssert.AreEqual(expectedAims, filteredAndOrderedAims);
        }

        [Test]
        public void ReturnOrderedAimsByOwnerUsername()
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var aims = new List<Aim>
            {
                new Aim() { Name = "Jump with parachute", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "build a spacecraft", OwnerUsername = "owneroftheworld", AimCategoryId = 4},
                new Aim() { Name = "visit russia", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "visit usa", OwnerUsername = "crazy_dude_1", AimCategoryId = 1},
                new Aim() { Name = "visit egypt", OwnerUsername = "chinaman", AimCategoryId = 4}
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            var filteredAndOrderedAims = service.ExploreAims(null, null, "ownerusername");

            // Assert
            var expectedAims = aims.OrderBy(x => x.OwnerUsername).ToList();
            CollectionAssert.AreEqual(expectedAims, filteredAndOrderedAims);
        }

        [Test]
        public void FilteringAndOrderingSimultaneously()
        {
            // Arrange
            string searchWord = "visit";
            var categoriesIds = new int[] { 4, 3 };
            var mockedData = new Mock<IDearDiaryData>();

            var aims = new List<Aim>
            {
                new Aim() { Name = "Jump with parachute", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "build a spacecraft", OwnerUsername = "owneroftheworld", AimCategoryId = 4},
                new Aim() { Name = "visit russia", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "visit usa", OwnerUsername = "crazy_dude_1", AimCategoryId = 1},
                new Aim() { Name = "visit egypt", OwnerUsername = "chinaman", AimCategoryId = 4}
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            var filteredOrderedAims = service.ExploreAims(searchWord, categoriesIds, "name");

            // Assert
            var expectedAims = aims.Where(x => x.Name.Contains(searchWord) || x.OwnerUsername.Contains(searchWord))
                .Where(x => categoriesIds.Contains(x.AimCategoryId))
                .OrderBy(x => x.Name)
                .ToList();
            CollectionAssert.AreEqual(expectedAims, filteredOrderedAims);
        }

        [Test]
        public void GetTheCorrectAims_WhenPagingOptionsChosen()
        {
            int page = 2;
            int perPage = 2;
            var mockedData = new Mock<IDearDiaryData>();
            var aims = new List<Aim>
            {
                new Aim() { Name = "Jump with parachute", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "build a spacecraft", OwnerUsername = "owneroftheworld", AimCategoryId = 4},
                new Aim() { Name = "visit russia", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "visit usa", OwnerUsername = "crazy_dude_1", AimCategoryId = 1},
                new Aim() { Name = "visit egypt", OwnerUsername = "achinaman", AimCategoryId = 4}
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            var pagingAims = service.ExploreAims(null, null, null, page, perPage);

            // Assert
            var expectedAims = aims.OrderBy(x => x.Name).Skip(2).Take(perPage);

            // has to take visit egypt & russia
            CollectionAssert.AreEqual(expectedAims, pagingAims);
        }

        [Test]
        public void TakeCorrectNumberOfAims_WhenPaging()
        {
            int page = 2;
            int perPage = 2;
            var mockedData = new Mock<IDearDiaryData>();
            var aims = new List<Aim>
            {
                new Aim() { Name = "Jump with parachute", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "build a spacecraft", OwnerUsername = "owneroftheworld", AimCategoryId = 4},
                new Aim() { Name = "visit russia", OwnerUsername = "crazy_dude_1", AimCategoryId = 3},
                new Aim() { Name = "visit usa", OwnerUsername = "crazy_dude_1", AimCategoryId = 1},
                new Aim() { Name = "visit egypt", OwnerUsername = "achinaman", AimCategoryId = 4}
            }.AsQueryable();

            mockedData.Setup(x => x.Aims.All).Returns(aims);

            AimService service = new AimService(mockedData.Object);

            // Act
            var pagingAims = service.ExploreAims(null, null, null, page, perPage);

            var expectedAims = aims.OrderBy(x => x.Name).Skip(2).Take(perPage);

            // Assert
            CollectionAssert.AreEqual(expectedAims, pagingAims);
        }
    }
}
