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
            DateTime now = DateTime.Now;

            string greeting;
            if (now.Hour > 6)
            { greeting = "Tere ööst"; }
            else if (now.Hour > 12)
            { greeting = "Tere hommikust"; }
            else if (now.Hour > 18)
            { greeting = "Tere päevast"; }
            else { greeting = "Tere õhtust"; }

            string message;
            string imageName;

            switch (now.Month)
            {
                case 1:
                    message = "Head uut aastat!";
                    imageName = "New_Year.jpg"; break;
                case 2:
                    message = "Head sõbrapäeva!";
                    imageName = "sober.jpg"; break;
                case 3:
                    message = "Ilusat emakeelepäeva!";
                    imageName = "emakeel.png"; break;
                case 4:
                    message = "Head ülestõusmispühade!";
                    imageName = "ülestousmispühade.jpg"; break;
                case 5:
                    message = "Toremaid kevadpühi!";
                    imageName = "kevadpuhi.jpg"; break;
                case 6:
                    message = "Head jaanipäeva!";
                    imageName = "jaanipaev.jpg"; break;
                case 7:
                    message = "Ilusat Eesti Vabariigi aastapäeva!";
                    imageName = "vabariigipaev.jpg"; break;
                case 8:
                    message = "Head tartu rahu päeva!";
                    imageName = "tartu.png"; break;
                case 9:
                    message = "Toremaid teadmiste päev!";
                    imageName = "teadmistepaev.jpg"; break;
                case 10:
                    message = "Rõõmsat õpetajate päeva!";
                    imageName = "opetaja.png"; break;
                case 11:
                    message = "Head isadepäeva!";
                    imageName = "isadepaev.jpg"; break;
                case 12:
                    message = "Rõõmsaid jõule!";
                    imageName = "joule.jpg"; break;
                default:
                    message = "Tere tulemast!";
                    imageName = "party.jpg"; break;
            }

            ViewBag.Greeting = greeting;
            ViewBag.Message = message;
            ViewBag.HolidayImage = imageName;

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
        GuestContext db = new GuestContext();
        public ActionResult Guests()
        {
            IEnumerable<Guest> guests = db.Guests;
            return View(guests);

        }
        [HttpPost]
        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest);
            E_mail2(guest);
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
            WebMail.Password = "qktj sxho bqtb rqio";//
            WebMail.From = "asdsadsa365@gmail.com";
            WebMail.Send(guest.Email, "Vastus kutsele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ?
            " tuleb peole" : "ei tule peole"));
            ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahju!Ei saa kirja saada!!!";
            }
        }
        public void E_mail2(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "asdsadsa365@gmail.com"; //
                WebMail.Password = "qktj sxho bqtb rqio";//
                WebMail.From = "asdsadsa365@gmail.com";
                WebMail.Send("asdsadsa365@gmail.com", "Vastus kutsele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ?
                " tuleb peole" : "ei tule peole", guest.Notes));
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