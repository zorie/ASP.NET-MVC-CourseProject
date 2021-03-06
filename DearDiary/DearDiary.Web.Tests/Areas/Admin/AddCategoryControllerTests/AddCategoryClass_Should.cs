﻿using DearDiary.Web.Areas.Admin.Controllers;
using NUnit.Framework;
using System;
using System.Web.Mvc;

namespace DearDiary.Web.Tests.Areas.Admin.AddCategoryControllerTests
{
    [TestFixture]
    public class AddCategoryClass_Should
    {
        [Test]
        public void HaveAuthorizeAttribute()
        {
            // Arrange, Act & Assert
            var attr = Attribute.GetCustomAttribute(typeof(AddCategoryController), 
                typeof(AuthorizeAttribute));
            
            Assert.IsNotNull(attr);
        }

        [Test]
        public void HaveAuthorizeAttributeWithRoleAdmin()
        { 
            // Arrange, Act & Assert
            var attr = Attribute.GetCustomAttribute(typeof(AddCategoryController), 
                typeof(AuthorizeAttribute)) as AuthorizeAttribute;

            Assert.AreEqual("Admin", attr.Roles);
        }
    }
}
