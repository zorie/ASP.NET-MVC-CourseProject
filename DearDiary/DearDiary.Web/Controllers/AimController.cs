using DearDiary.Models;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using DearDiary.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DearDiary.Web.Controllers
{
    public class AimController : Controller
    {
        private readonly IAimService aimService;
        private readonly IMapperAdapter mapper;
        private readonly ICityService cityService;
        private readonly ICountryService countryService;


        public AimController(
            IAimService aimService,
            ICountryService countrySerice,
            ICityService cityService,
            IMapperAdapter mapper)
        {
            this.aimService = aimService;
            this.cityService = cityService;
            this.countryService = countrySerice;
            this.mapper = mapper;
        }
        // GET: Aim
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateAim()
        {
           

            var model = new CreateAimViewModel
            {
                Cities = GetCities()
                //Countries = GetCountries()
            };

            ViewData["country"] = GetCountries();

            return View(model);
        }

        

        [HttpPost]
        public ActionResult CreateAim(CreateAimViewModel aimModel, FormCollection form)
        {
            int countryId =  int.Parse(form["Country"].ToString());
            int cityId = int.Parse(form["city"].ToString());

            if (ModelState.IsValid)
            {
                Aim newAim = this.mapper.Map<Aim>(aimModel);

                newAim.CountryId = countryId;
                newAim.CityId = cityId;

                aimService.AddAim(newAim);

                return RedirectToAction("Index");
            }
            else
            {
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

        private IEnumerable<SelectListItem> GetCities()
        {
            var c = cityService.GetAllCities().Select(x =>
               new SelectListItem
               {
                   Value = x.Id.ToString(),
                   Text = x.Name
               });

            return new SelectList(c, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetCountries()
        {
            var c = countryService.GetAllCountries().Select(x =>
               new SelectListItem
               {
                   Value = x.Id.ToString(),
                   Text = x.Name
               });

            return new SelectList(c, "Value", "Text");
        }    
    }
}