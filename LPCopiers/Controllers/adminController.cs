using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LPCopiers.Controllers
{
    public class adminController : Controller
    {
        //
        // GET: /admin/
        [Authorize(Roles="admin")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
