using LPCopiers.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LPCopiers.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        //
        // GET: /Staff/

        public ActionResult Index()
        {
            //check what role user is in then display menu options
            return View();
        }

        public ActionResult WageCalculator()
        {
            ViewBag.Header = "Wage Calculator";
            ViewBag.SubHeader = "Enter details to calculate weekly wage";
            return View();
        }

        /// <summary>
        /// takes form values and calculates wage
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult WageCalculator(WageCalculator m)
        {
            double rate = 10;   
            var overtimeHours = 0;
            double overtimeRate = 0;
            double overtimePay = 0;

            if(ModelState.IsValid)
            {
                switch (m.rate)
                {
                    case "Engineer":
                        rate = 10;
                        break;
                    case "Senior Engineer":
                        rate = 12;
                        break;
                    case "Technical Engineer":
                        rate = 25;
                        break;
                    default:
                        rate = 30;
                        break;
                }
                if (m.Beng == true)
                    rate = rate + (rate * 0.1);

                if (m.hours > 40)
                {
                    overtimeHours = (int)m.hours - 40;
                    m.hours = 40;
                    overtimeRate = rate * 1.5;
                    overtimePay = overtimeHours * overtimeRate;
                }

                m.wage = m.hours * rate;

                if (overtimeHours > 0)
                    m.wage = m.wage + overtimePay;
                //added to reset value
                m.hours += overtimeHours;

                return RedirectToAction("Wage",m);
            }

            return View();
            
        }

        /// <summary>
        /// returns calculated wage if model is valid else redirects to wage calculator action
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public ActionResult Wage (WageCalculator m)
        {
            ViewBag.Header = "Calculated Wage";

            if(ModelState.IsValid)
            {  
                
                return View(m);
            }
                

            return RedirectToAction("WageCalculator");
        }

        public ActionResult PartsRequest ()
        {
            ViewBag.Header = "Parts Request";
            ViewBag.SubHeader = "Upload Excel spreadsheet";
            if(TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"];
                ViewBag.Error = TempData["Error"];
            }
            return View();
        }

        /// <summary>
        /// Send file to check validity then store on server in uploads folder
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PartsUpload()
        {
            if(Request != null)
            {
                HttpPostedFileBase file = Request.Files[0];

                if(CheckValidFile(file))
                {
                    try
                    {
                        var fileName = "";
                        if (User.IsInRole("engineer"))
                        {
                            var engRef = Membership.GetUser();
                            fileName = engRef + DateTime.Now.ToString("ddMMyyyy");
                        }
                        else
                        {
                            fileName = "eng" + DateTime.Now.ToString("ddMMyyyy");
                        }

                        //TODO:: - change engineer eng001 to current user engref
                        
                        var path = Path.Combine(Server.MapPath("~/App_Data/uploads/"), fileName);
                        file.SaveAs(path);
                        TempData["message"] = "File uploaded successfully";
                        TempData["Error"] = false;
                    }
                    catch (Exception e)
                    {
                        TempData["message"] = e.Message.ToString();
                        TempData["Error"] = true;
                    }
                }
            }

            return RedirectToAction("partsRequest");
        }
        /// <summary>
        /// Check if file is of valid type and size
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool CheckValidFile (HttpPostedFileBase file)
        {
            if (file != null && !string.IsNullOrEmpty(file.FileName))
            {
                if(file.ContentLength > 00 && file.ContentLength < 1048576)
                {
                    if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        return true;
                    }
                    else
                    {
                        //written to temp data as viewbag is cleared after redirect
                        TempData["message"] = "Incorrect type of file - file must be an Excel spreadsheet";
                        TempData["Error"] = true;
                        return false;
                    }
                }
                else
                {
                    //don't need to worry about too small as this will be caught by previous if
                    TempData["message"] = "File size too large";
                    TempData["Error"] = true;
                    return false;
                }
            }
            else
            {
                TempData["message"] = "no file name or file uploaded";
                TempData["Error"] = true; 
                return false;
            }
        }
    }
}
