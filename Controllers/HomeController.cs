using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel_MVC.Models;

namespace Travel_MVC.Controllers
{
    public class HomeController : Controller
    {
        TravelDB DB;
        public ActionResult Index()
        {
            DB = new TravelDB();
            ViewBag.sliderTop = DB.TopSliders.ToList();
            ViewBag.SectionTwo = DB.Section2.ToList();
            ViewBag.DiscoLeft = DB.DiscoverLefts.ToList();
            ViewBag.DiscoRight = DB.DiscoverRights.ToList();
            ViewBag.ServiceList = DB.OurServices.ToList();
            ViewBag.AllTour = DB.AllTours.ToList();
            ViewBag.OurTeam = DB.OurTeams.ToList();
            ViewBag.MoreInfo = DB.MoreInformations.ToList();
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