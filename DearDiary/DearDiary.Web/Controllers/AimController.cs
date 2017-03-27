using DearDiary.Models;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DearDiary.Web.Controllers
{
    public class AimController : Controller
    {
        private readonly IAimService aimService;
        private readonly ICityService cityService;
        private readonly IAimCategoryService aimCategoryService;
        private readonly ICountryService countryService;
        private readonly IMapperAdapter mapper;

        private const int CountOfAims = 5;

        public AimController(
            IAimService aimService,
            ICountryService countryService,
            ICityService cityService,
            IAimCategoryService aimCategoryService,
            IMapperAdapter mapper)
        {
            if(aimService == null)
            {
                throw new ArgumentNullException("Aim Service cannot be null");
            }

            if (countryService == null)
            {
                throw new ArgumentNullException("Country Service cannot be null");
            }

            if (cityService == null)
            {
                throw new ArgumentNullException("City Service cannot be null");
            }

            if (aimCategoryService == null)
            {
                throw new ArgumentNullException("Category Service cannot be null");
            }

            if (mapper == null)
            {
                throw new ArgumentNullException("Mapper cannot be null");
            }

            this.aimService = aimService;
            this.cityService = cityService;
            this.countryService = countryService;
            this.aimCategoryService = aimCategoryService;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            return this.RedirectToRoute(new
            {
                controller = "Explore",
                action = "Index"
            });
        }

        // GET: Aim
        public ActionResult Details(string id)
        {
            if(id == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Explore",
                    action = "Index"
                });
            }

            int aimId = int.Parse(id);
            Aim aim = this.aimService.GetAimById(aimId);

            if (aim == null)
            {
                return this.RedirectToAction("Index");
            }

            AimDetailsViewModel model = this.mapper.Map<AimDetailsViewModel>(aim);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateAimViewModel();

            ViewData["country"] = GetCountries();
            ViewData["category"] = GetCategories();
            //model.Countries = GetCountries();
            //model.AimCategories = GetCategories();

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAimViewModel aimModel, FormCollection form)
        {
            if (!this.IsImage(aimModel.Photo))
            {
                ViewData["country"] = GetCountries();
                ViewData["category"] = GetCategories();
                return View();
            }

            int countryId = 0;
            int? cityId;
            try
            {
                countryId = int.Parse(form["Country"].ToString());
            }
            catch (Exception)
            {
                this.TempData.Add("Country", "Choose a valid country");
                return this.RedirectToAction("Create");
            }

            try
            {
                cityId = int.Parse(form["city"].ToString());
            }
            catch (Exception)
            {
                cityId = null;
                this.TempData.Add("City", "Choose a valid city");
                return this.RedirectToAction("Create");
            }

            int categoryId = 0;
            try
            {
                categoryId = int.Parse(form["category"].ToString());
            }
            catch (Exception)
            {
                this.TempData.Add("InvalidCategory", "Choose a valid category");
                return this.RedirectToAction("Create");
            }

            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (Request.Files.Count > 0)
                {
                    fileName = aimModel.Photo.FileName;
                    string path = this.Server.MapPath($"~/Images/{fileName}");

                    aimModel.Photo.SaveAs(path);
                }                

                Aim newAim = this.mapper.Map<Aim>(aimModel);

                newAim.CountryId = countryId;
                newAim.CityId = cityId;
                newAim.AimCategoryId = categoryId;
                newAim.OwnerUsername = this.User.Identity.Name;
                newAim.Photo = fileName;

                aimService.AddAim(newAim);
                this.TempData.Add("Addition", "Your aim was added successfully.");

                return RedirectToRoute(new
                {
                    controller = "Explore",
                    action = "Index"
                });
            }
            else
            {
                ViewData["country"] = GetCountries();
                ViewData["category"] = GetCategories();
                return View(aimModel);
            }            
        }

        public JsonResult GetCities(string id)
        {
            List<SelectListItem> cities = new List<SelectListItem>();

            var sortedCities = this.cityService.GetAllCitiesByCountry(id);

            foreach (var city in sortedCities)
            {
                cities.Add(new SelectListItem { Text = city.Name, Value = city.Id.ToString() });
            }

            return Json(new SelectList(cities, "Value", "Text"));
        }

        private bool IsImage(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return false;
            }

            var contentType = file.ContentType.ToLower();
            var result = contentType == "image/jpg"
                || contentType == "image/jpeg"
                || contentType == "image/png";

            return result;
        }

        private IEnumerable<SelectListItem> GetCities()
        {
            var c = this.cityService.GetAllCities().Select(x =>
               new SelectListItem
               {
                   Value = x.Id.ToString(),
                   Text = x.Name
               });

            return new SelectList(c, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetCountries()
        {
            var c = this.countryService.GetAllCountries().Select(x =>
               new SelectListItem
               {
                   Value = x.Id.ToString(),
                   Text = x.Name
               });

            return new SelectList(c, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetCategories()
        {
            var c = this.aimCategoryService.GetAimCategories().Select(x =>
               new SelectListItem
               {
                   Value = x.Id.ToString(),
                   Text = x.Name
               });

            return new SelectList(c, "Value", "Text");
        }
    }
}