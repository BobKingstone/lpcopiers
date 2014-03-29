using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LPCopiers.Models;
using WebMatrix.WebData;

namespace LPCopiers.Controllers
{
    public class EquipmentController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Equipment/

        public ActionResult Index()
        {
            return View(db.Equipments.ToList());
        }

        //
        // GET: /Equipment/Details/5

        public ActionResult Details(int id = 0)
        {
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        public ActionResult DetailsByEngineer()
        {
            if (User.IsInRole("engineer"))
            {
                int engID = (int)WebSecurity.CurrentUserId;
                UserProfile eng = db.UserProfiles.Find(engID);

                IEnumerable<Equipment> equipmentQuery =
                    from equipment in db.Equipments
                    where equipment.EngRef == eng.UserName
                    select equipment;


                return View(equipmentQuery);
            }

            return RedirectToAction("index", "Staff");

        }

        //
        // GET: /Equipment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Equipment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Equipments.Add(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipment);
        }

        //
        // GET: /Equipment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        //
        // POST: /Equipment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipment);
        }

        //
        // GET: /Equipment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        //
        // POST: /Equipment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipment equipment = db.Equipments.Find(id);
            db.Equipments.Remove(equipment);
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