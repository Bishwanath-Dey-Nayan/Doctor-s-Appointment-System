using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAS;
using DAS.Models;

namespace DAS.Controllers
{
    public class BloodGroupController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: BloodGroup
        public ActionResult Index()
        {
            return View(db.BloodGroups.ToList());
        }

        // GET: BloodGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodGroup bloodGroup = db.BloodGroups.Find(id);
            if (bloodGroup == null)
            {
                return HttpNotFound();
            }
            return View(bloodGroup);
        }

        // GET: BloodGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BloodGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] BloodGroup bloodGroup)
        {
            if (ModelState.IsValid)
            {
                db.BloodGroups.Add(bloodGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloodGroup);
        }

        // GET: BloodGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodGroup bloodGroup = db.BloodGroups.Find(id);
            if (bloodGroup == null)
            {
                return HttpNotFound();
            }
            return View(bloodGroup);
        }

        // POST: BloodGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] BloodGroup bloodGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloodGroup);
        }

        // GET: BloodGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodGroup bloodGroup = db.BloodGroups.Find(id);
            if (bloodGroup == null)
            {
                return HttpNotFound();
            }
            return View(bloodGroup);
        }

        // POST: BloodGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodGroup bloodGroup = db.BloodGroups.Find(id);
            db.BloodGroups.Remove(bloodGroup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
