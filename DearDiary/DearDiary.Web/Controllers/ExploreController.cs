using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DearDiary.Web.Controllers
{
    public class ExploreController : Controller
    {
        private const int CountOfAims = 5;

        private readonly IAimService aimService;
        private readonly IAimCategoryService aimCategoryService;
        private readonly IMapperAdapter mapper;
        public ExploreController(IAimService aimService, IAimCategoryService categoryService, IMapperAdapter mapper)
        {
            if (aimService == null)
            {
                throw new ArgumentNullException("Aim Service cannot be null");
            }

            if (categoryService == null)
            {
                throw new ArgumentNullException("Category Service cannot be null");
            }

            if (mapper == null)
            {
                throw new ArgumentNullException("Mapper cannot be null");
            }

            this.aimService = aimService;
            this.mapper = mapper;
            this.aimCategoryService = categoryService;
        }

        // GET: Explore
            public ActionResult Index()
            {
                ExploreViewModel model = new ExploreViewModel();

                var categories = this.aimCategoryService.GetAimCategories();
                model.AimCategories = mapper.Map<IEnumerable<AimCategoryViewModel>>(categories);

                return View(model);            
            }
        
        public PartialViewResult ExploreAims(ExploreSubmitViewModel submitModel, int? page)
        {
            int actualPage = page ?? 1;

            var result = this.aimService.ExploreAims(submitModel.SearchWord, submitModel.ChosenCategoriesIds, submitModel.SortBy, actualPage, CountOfAims);
            var count = this.aimService.GetAimsCount(submitModel.SearchWord, submitModel.ChosenCategoriesIds);
            var resultViewModel = new ExploreResultsViewModel();
            resultViewModel.SubmitModel = submitModel;
            resultViewModel.Pages = (int)Math.Ceiling((double)count / CountOfAims);

            resultViewModel.Aims = mapper.Map<IEnumerable<AimViewModel>>(result);
            
            return this.PartialView("_ExploreResultsPartial", resultViewModel);
        }
    }
}