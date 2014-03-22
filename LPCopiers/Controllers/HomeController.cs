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

        public ActionResult Manufacturers ()
        {
            return View();
        }  
        [HttpPost]
        public ActionResult Manufacturers (Manufacture m)
        {
            if (ModelState.IsValid)
            {
                //check photocopier selection
                if (m.Photocopier.Equals("Canon"))
                    m.CopierURL = "http://www.canon.co.uk/For_Work/business-products/office-printers/all-in-one-office-printers/index.aspx";
                else if (m.Photocopier.Equals("Xerox"))
                    m.CopierURL = "http://www.xerox.co.uk/office/copiers/engb.html";
                else
                    m.CopierURL = "http://www.sharp.co.uk/cps/rde/xchg/gb/hs.xsl/-/html/digital-copier--printers.htm";

                //check printer selection
                if (m.Printer.Equals("HP"))
                    m.PrinterURL = "http://www8.hp.com/uk/en/products/printers/index.html?facet=smb#!view=column&page=1";
                else if (m.Printer.Equals("Brother"))
                    m.PrinterURL = "http://www.brother.co.uk/g3.cfm/s_page/204410/s_name/printersprintonly";
                else
                    m.PrinterURL = "http://www.epson.co.uk/";

                //check fax selection
                if (m.Fax.Equals("Ricoh"))
                    m.FaxURL = "http://www.ricoh.co.uk/products/facsimile/index.aspx";
                else if (m.Fax.Equals("Philips"))
                    m.FaxURL = "http://www.philips.co.uk/c/faxes/139420/cat/";
                else
                    m.FaxURL = "http://www.samsung.com/uk/consumer/print-solutions/print-solutions/faxes/";

                return RedirectToAction("SelectedManufacturers",m);
            }

            //if state is invalid return
            return View(m);
        }

        public ActionResult SelectedManufacturers (Manufacture m)
        {
            if(ModelState.IsValid)
                return View(m);

            return RedirectToAction("Manufacturers");
        }
    }
}
