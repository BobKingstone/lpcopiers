using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LPCopiers.Controllers
{
    public class CustomersMenuController : Controller
    {
        //
        // GET: /Customers/
        [Authorize(Roles="admin,customer")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
