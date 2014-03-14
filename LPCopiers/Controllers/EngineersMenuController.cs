using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LPCopiers.Controllers
{
    public class EngineersMenuController : Controller
    {
        //
        // GET: /Engineers/
        [Authorize(Roles="admin,engineer")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
