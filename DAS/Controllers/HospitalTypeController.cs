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
    public class HospitalTypeController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: HospitalType
        public ActionResult Index()
        {
            return View(db.HospitalTypes.ToList());
        }

        // GET: HospitalType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalType hospitalType = db.HospitalTypes.Find(id);
            if (hospitalType == null)
            {
                return HttpNotFound();
            }
            return View(hospitalType);
        }

        // GET: HospitalType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HospitalType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] HospitalType hospitalType)
        {
            if (ModelState.IsValid)
            {
                db.HospitalTypes.Add(hospitalType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospitalType);
        }

        // GET: HospitalType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalType hospitalType = db.HospitalTypes.Find(id);
            if (hospitalType == null)
            {
                return HttpNotFound();
            }
            return View(hospitalType);
        }

        // POST: HospitalType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] HospitalType hospitalType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospitalType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospitalType);
        }

        // GET: HospitalType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalType hospitalType = db.HospitalTypes.Find(id);
            if (hospitalType == null)
            {
                return HttpNotFound();
            }
            return View(hospitalType);
        }

        // POST: HospitalType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HospitalType hospitalType = db.HospitalTypes.Find(id);
            db.HospitalTypes.Remove(hospitalType);
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
