using LPCopiers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LPCopiers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Heading = "Providing cost effective copier and printer solutions";


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "LP Copiers.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us.";

            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Manufacturers (Manufacture m)
        {
            return View(m);
        }  
    }
}
