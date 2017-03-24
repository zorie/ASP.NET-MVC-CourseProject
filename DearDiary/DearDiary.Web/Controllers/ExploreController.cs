using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DearDiary.Web.Controllers
{
    public class ExploreController : Controller
    {
        private const int CountOfAims = 5;

        private readonly IAimService aimService;
        private readonly IMapperAdapter mapper;
        public ExploreController(IAimService aimService, IMapperAdapter mapper)
        {
            if (aimService == null)
            {
                throw new ArgumentNullException("Aim Service cannot be null");
            }
            if (mapper == null)
            {
                throw new ArgumentNullException("Mapper cannot be null");
            }

            this.aimService = aimService;
            this.mapper = mapper;
        }

        // GET: Explore
        public ActionResult Index()
        {
            var aims = this.aimService.GetAims(CountOfAims);

            var latestAims = new List<AimViewModel>(aims.Count());

            foreach (var aim in aims)
            {
                var a = this.mapper.Map<AimViewModel>(aim);
                latestAims.Add(a);
            }

            ExploreViewModel model = new ExploreViewModel { Aims = latestAims };
            return View(model);            
        }

        public PartialViewResult ExploreAims(ExploreSubmitViewModel submitModel, int? page)
        {
            int actualPage = page ?? 1;

            //var result = this.aimService.SearchBooks(submitModel.SearchWord, submitModel.ChosenCategoriesIds, submitModel.SortBy, actualPage, Constants.BooksPerPage);
            //var count = this.aimService.GetBooksCount(submitModel.SearchWord, submitModel.ChosenGenresIds);
            var result = this.aimService.GetAims(5);
            var resultViewModel = new ExploreResultsViewModel();
            resultViewModel.SubmitModel = submitModel;
            //resultViewModel.Pages = (int)Math.Ceiling((double)count / Constants.BooksPerPage);
            resultViewModel.Pages = 1;

            resultViewModel.Aims = mapper.Map<IEnumerable<AimViewModel>>(result);

            return this.PartialView("_ExploreResultsPartial", resultViewModel);
        }
    }
}