using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LPCopiers.Models;

namespace LPCopiers.Controllers
{
    [Authorize(Roles="admin")]
    public class CustomerController : Controller
    {
        private MainContext db = new MainContext();

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            var customermodels = db.CustomerModels.Include(c => c.UserId);
            return View(customermodels.ToList());
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id = 0)
        {
            CustomerModel customermodel = db.CustomerModels.Find(id);
            if (customermodel == null)
            {
                return HttpNotFound();
            }
            return View(customermodel);
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            ViewBag.LoginId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel customermodel)
        {
            if (ModelState.IsValid)
            {
                db.CustomerModels.Add(customermodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoginId = new SelectList(db.UserProfiles, "UserId", "UserName", customermodel.LoginId);
            return View(customermodel);
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CustomerModel customermodel = db.CustomerModels.Find(id);
            if (customermodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoginId = new SelectList(db.UserProfiles, "UserId", "UserName", customermodel.LoginId);
            return View(customermodel);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerModel customermodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customermodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoginId = new SelectList(db.UserProfiles, "UserId", "UserName", customermodel.LoginId);
            return View(customermodel);
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CustomerModel customermodel = db.CustomerModels.Find(id);
            if (customermodel == null)
            {
                return HttpNotFound();
            }
            return View(customermodel);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerModel customermodel = db.CustomerModels.Find(id);
            db.CustomerModels.Remove(customermodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}