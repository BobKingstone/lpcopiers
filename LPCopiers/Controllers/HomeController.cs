using LPCopiers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

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
            ViewBag.Header = "Contact Us";
            ViewBag.SubHeader = "Request a visit from an engineer";
            ViewBag.OutofHours = false;
            int CurrentHour = 11;// DateTime.Now.Hour;
            if (CurrentHour < 9 || CurrentHour > 17)
            {
                return RedirectToAction("OutOfHours");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactForm cf)
        {
            if(ModelState.IsValid)
            {   //model validation work around
                var datePlusSeven = DateTime.Now.AddDays(7);
                var datePlusNinety = DateTime.Now.AddDays(90);
                if(cf.VisitDate < datePlusSeven || cf.VisitDate>datePlusNinety)
                {
                    ViewBag.DateError = "Invalid visit date selected";
                    return View();
                }
                var customerName = cf.CName;
                var customerEmail = cf.Email;
                var customerRequest = cf.VisitType;
                var errorMessage = "";
                errorMessage = SendMail(customerRequest, errorMessage);
                return RedirectToAction("ThankYou","Home",customerRequest);
            }

            ViewBag.Message = "Error";
            return View();
        }

        private static string SendMail(string customerRequest, string errorMessage)
        {
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
                    subject: customerRequest + " Request",
                    body: "Thank you for your email, a member of our staff will contact you shortly to confirm the date."
                );
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return errorMessage;
        }

        public ActionResult ThankYou(string cr)
        {
            ViewBag.Header = "Thank you";
            ViewBag.Request = cr;
            return View();
        }
        public ActionResult OutOfHours ()
        {
            ViewBag.Header = "Out of Hours";
            ViewBag.SubHeader = "Our offices are currenlty closed";
            using(UsersContext db = new UsersContext())
            {
                   
                IEnumerable<UserProfile> users = (from UserProfiles in db.UserProfiles
                                                    where UserProfiles.forename != ""
                                                    select UserProfiles).ToList();
                
                return View(users);
            }
        }

        public ActionResult Manufacturers ()
        {
            ViewBag.Header = "Manufacturers";
            ViewBag.SubHeader = "Select preferred manufactuers";
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
            ViewBag.Header = "Selected Manufacturers";

            if(ModelState.IsValid)
                return View(m);

            return RedirectToAction("Manufacturers");
        }
    }
}
