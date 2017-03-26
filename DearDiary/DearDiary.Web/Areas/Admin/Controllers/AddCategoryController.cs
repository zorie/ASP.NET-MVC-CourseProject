using DearDiary.Models;
using DearDiary.Services.Contracts;
using DearDiary.Web.Areas.Admin.Models;
using DearDiary.Web.AutoMapping;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DearDiary.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AddCategoryController : Controller
    {
        private readonly IAimCategoryService categoryService;
        private readonly IMapperAdapter mapper;

        public AddCategoryController(IAimCategoryService categoryService, IMapperAdapter mapper)
        {
            if(categoryService == null)
            {
                throw new ArgumentNullException("Category Service cannot be null");
            }

            if (mapper == null)
            {
                throw new ArgumentNullException("Mapper cannot be null");
            }

            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        // GET: Admin/AddCategory
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AddCategoryViewModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            AimCategory newCategory = this.mapper.Map<AimCategory>(categoryModel);
            newCategory.Aims = new List<Aim>();

            this.categoryService.AddAimCategory(newCategory);

            // temp data messages

            return this.Redirect($"/explore");            
        }
    }
}