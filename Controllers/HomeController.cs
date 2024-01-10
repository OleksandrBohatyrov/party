using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace party.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kutse() 
        {
            int hour=DateTime.Now.Hour;
            ViewBag.Greeting = hour < 10 ? "Tere hommikust" : "Tere päevast";
            ViewBag.Message = "Ootan sind oma peole! Tule kindlasti!!! Ootan sind!";
            return View();        
        }
        [HttpGet]

        public ActionResult Ankeet() { 
            return View();
        
        }

        public ActionResult About()
        {
            ViewBag.Message = "Teie taotluse kirjelduse lehekülg.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Teie kontaktleht.";

            return View();
        }
    }
}