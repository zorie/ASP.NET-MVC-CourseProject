using DearDiary.Models;
using DearDiary.Services.Contracts;
using DearDiary.Web.Areas.Admin.Models;
using DearDiary.Web.AutoMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DearDiary.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AddCityController : Controller
    {
        private readonly ICityService cityService;
        private readonly IMapperAdapter mapper;
        private readonly ICountryService countryService;

        public AddCityController(ICityService cityService, ICountryService countryService, IMapperAdapter mapper)
        {
            if (cityService == null)
            {
                throw new ArgumentNullException("City Service cannot be null");
            }

            if (countryService == null)
            {
                throw new ArgumentNullException("Country Service cannot be null");
            }

            if (mapper == null)
            {
                throw new ArgumentNullException("Mapper cannot be null");
            }

            this.cityService = cityService;
            this.countryService = countryService;
            this.mapper = mapper;
        }
        // GET: Admin/AddCity
        public ActionResult Index()
        {
            ViewData["country"] = GetCountries();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AddCityViewModel cityModel, FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                ViewData["country"] = GetCountries();
                return this.View();
            }

            int countryId = int.Parse(form["Country"].ToString());
            City newCity = this.mapper.Map<City>(cityModel);
            newCity.Aims = new List<Aim>();
            newCity.CountryId = countryId;

            try
            {
                this.cityService.AddCity(newCity);
            }
            catch (Exception)
            {

                return this.View("Error");
            }

            // temp data messages - unique city error

            return this.Redirect($"/explore");
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
    }
}