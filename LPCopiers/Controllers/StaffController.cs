using LPCopiers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LPCopiers.Controllers
{
    public class StaffController : Controller
    {
        //
        // GET: /Staff/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WageCalculator()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WageCalculator(WageCalculator m)
        {
            return View();
        }

    }
}
