using DearDiary.Models;
using DearDiary.Services.Contracts;
using DearDiary.Web.Areas.Admin.Controllers;
using DearDiary.Web.Areas.Admin.Models;
using DearDiary.Web.AutoMapping;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace DearDiary.Web.Tests.Areas.Admin.AddCategoryControllerTests
{
    [TestFixture]
    public class IndexPost_Should
    {
        private Mock<IAimCategoryService> mockedCategoryService;
        private Mock<IMapperAdapter> mockedMapper;
        private AddCategoryController controller;

        [SetUp]
        public void TestSetup()
        {
            this.mockedCategoryService = new Mock<IAimCategoryService>();            
            this.mockedMapper = new Mock<IMapperAdapter>();

            this.controller = new AddCategoryController(
                this.mockedCategoryService.Object,
                this.mockedMapper.Object);
        }

        [Test]
        public void HaveHttpPostAttribute()
        {
            var method = typeof(AddCategoryController).GetMethod("Index", new Type[] { typeof(AddCategoryViewModel) });
            var hasAttribute = method.GetCustomAttributes(typeof(HttpPostAttribute), false).Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void HaveValidateAntiForgeryAttribute()
        {
            var method = typeof(AddCategoryController).GetMethod("Index", new Type[] { typeof(AddCategoryViewModel) });
            var hasAttribute = method.GetCustomAttributes(typeof(ValidateAntiForgeryTokenAttribute), false).Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void ReturnDefaultView_WhenModelStateIsNotValid()
        {
            // Arrange
            this.controller.ModelState.AddModelError("error", "message");

            var submitModel = new AddCategoryViewModel();

            // Act & Assert
            this.controller.WithCallTo(c => c.Index(submitModel))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void AddMessageToTempdata_WhenAdditionIsSuccessful()
        {
            // Arrange
            var submitModel = new AddCategoryViewModel();
            submitModel.Name = "someName";

            var mockedAimCategory = new AimCategory();

            this.mockedMapper.Setup(x => x.Map<AimCategory>(submitModel)).Returns(mockedAimCategory);

            // Act
            this.controller.Index(submitModel);

            // Assert
            Assert.AreEqual("Successfully added the category", this.controller.TempData["Category"]);
        }
    }
}
