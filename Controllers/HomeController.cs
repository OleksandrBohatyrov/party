using party.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        [HttpPost]
        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest);
            if (ModelState.IsValid) { 
            
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }
        public void E_mail(Guest guest)
        {
            try
            {
            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;          
            WebMail.EnableSsl = true;
            WebMail.UserName = "asdsadsa365@gmail.com"; //
            WebMail.Password = "zvyh dlyh kady lcyk ";//
            WebMail.From = "asdsadsa365@gmail.com";
            WebMail.Send("asdsadsa365@gmail.com", "Vastus kutsele", guest.Name + "vastas" + ((guest.WillAttend ?? false) ?
            "tuleb peole" : "ei tule peole"));
            ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahju!Ei saa kirja saada!!!";
            }
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