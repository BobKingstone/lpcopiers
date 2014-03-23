using LPCopiers.Models;
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

        public ActionResult Wage (WageCalculator m)
        {

            if(ModelState.IsValid)
            {  
                
                return View(m);
            }
                

            return RedirectToAction("WageCalculator");
        }

    }
}
