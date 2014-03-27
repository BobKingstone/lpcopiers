using LPCopiers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
//INCOMING MAIL (POP3)...: mail.uglygekko.co.uk or darcy.clook.net
//OUTGOING MAIL (SMTP)...: mail.uglygekko.co.uk or darcy.clook.net
//USERNAME...: username@uglygekko.co.uk (must be first created as a mailbox in cPanel control panel)
//PASSWORD...: password for that account
//lpcopiersSample@uglygekko.co.uk
//ISI.JegOX.(S
namespace LPCopiers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Heading = "Providing cost effective copier and printer repair solutions";


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "LP Copiers.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.OutofHours = false;
            int CurrentHour = 11;//DateTime.Now.Hour;
            if (CurrentHour < 9 || CurrentHour > 17)
            {
                ViewBag.OutofHours = true;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactForm cf)
        {
            if(ModelState.IsValid)
            {
                var customerName = Request[cf.CName];
                var customerEmail = Request[cf.Email];
                var customerRequest = Request[cf.VisitDate.ToString()];
                var errorMessage = "";
                var debuggingFlag = false;
                try
                {
                    // Initialize WebMail helper
                    WebMail.SmtpServer = "mail.uglygekko.co.uk";
                    WebMail.SmtpPort = 25;
                    WebMail.UserName = "lpcopiersSample@uglygekko.co.uk";
                    WebMail.Password = "ISI.JegOX.(S";
                    WebMail.From = "lpcopiersSample@uglygekko.co.uk";

                    // Send email
                    WebMail.Send(to: "robert.kingstone@gmail.com",
                        subject: "Email from - " + customerName,
                        body: customerRequest
                    );
                    ViewBag.Message = "Email Sent";
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
                return View(cf);
            }

            ViewBag.Message = "Error";
            return View();
        }

        public ActionResult ProcessContact (ContactForm cf)
        {
 
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
