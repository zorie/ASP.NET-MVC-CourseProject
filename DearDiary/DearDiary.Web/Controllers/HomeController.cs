using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DearDiary.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAimService aimService;
        private readonly IMapperAdapter mapper;

        public HomeController(IAimService aimService, IMapperAdapter mapper)
        {
            if (aimService == null)
            {
                throw new ArgumentNullException("Aim ServiceCannot be null");
            }

            if (mapper == null)
            {
                throw new ArgumentNullException("Mapper cannot be null");
            }

            this.aimService = aimService;
            this.mapper = mapper;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}