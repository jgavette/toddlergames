using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToddlerGames.Controllers
{
    public class HomeController : Controller
        {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            ViewData["Day"] = DateTime.Now.ToString("MM/dd/yyyy");
            ViewData["Hour"] = DateTime.Now.ToString("hh:mm tt");

            ViewBag.Message1 = " The date is = ";
            return View("MainView");
        }

        [Route("Home/About/Contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact Me.";

            return View();
        }

        //public ViewResult Scores()
        //{
        //    ViewData["Message"] = "Baby Leader Board";

        //    return View();
        //}

        public ViewResult About()
        {

            return View("About");
        }
        public ViewResult Numbers()
        {
            return View("Numbers");
        }
        public ViewResult Shapes()
        {
            return View("Shapes");
        }
        public ViewResult Login()
        {
            return View("Login");
        }
        public ViewResult Register()
        {
            return View("Register");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}