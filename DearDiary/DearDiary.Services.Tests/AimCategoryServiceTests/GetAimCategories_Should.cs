using DearDiary.Data;
using DearDiary.Models;
using DearDiary.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DearDiary.Services.Tests.AimCategoryServiceTests
{
    [TestFixture]
    public class GetAimCategories_Should
    {

        [Test]
        public void ReturnCorrectCollection()
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var categories = new List<AimCategory>
            {
                new AimCategory() { Name = "Sports" },
                new AimCategory() { Name = "Extreme" },
                new AimCategory() { Name = "Travelling" }
            }.AsQueryable();

            mockedData.Setup(x => x.AimCategories.All).Returns(categories);

            AimCategoryService service = new AimCategoryService(mockedData.Object);

            // Act
            var resultCatgories = service.GetAimCategories();

            // Assert
            CollectionAssert.AreEqual(categories, resultCatgories);
        }

        [Test]
        public void ReturnCorrectSizeOfCollection()
        {
            // Arrange
            var mockedData = new Mock<IDearDiaryData>();

            var categories = new List<AimCategory>
            {
                new AimCategory() { Name = "Sports" },
                new AimCategory() { Name = "Extreme" },
                new AimCategory() { Name = "Travelling" }
            }.AsQueryable();

            mockedData.Setup(x => x.AimCategories.All).Returns(categories);

            AimCategoryService service = new AimCategoryService(mockedData.Object);

            // Act
            var resultCatgories = service.GetAimCategories();

            // Assert
            Assert.AreEqual(categories.Count(), resultCatgories.Count());
        }
    }
}
