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
    public class PackTypeController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: PackType
        public ActionResult Index()
        {
            return View(db.PackTypes.ToList());
        }

        // GET: PackType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackType packType = db.PackTypes.Find(id);
            if (packType == null)
            {
                return HttpNotFound();
            }
            return View(packType);
        }

        // GET: PackType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PackType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] PackType packType)
        {
            if (ModelState.IsValid)
            {
                db.PackTypes.Add(packType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(packType);
        }

        // GET: PackType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackType packType = db.PackTypes.Find(id);
            if (packType == null)
            {
                return HttpNotFound();
            }
            return View(packType);
        }

        // POST: PackType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] PackType packType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(packType);
        }

        // GET: PackType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackType packType = db.PackTypes.Find(id);
            if (packType == null)
            {
                return HttpNotFound();
            }
            return View(packType);
        }

        // POST: PackType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PackType packType = db.PackTypes.Find(id);
            db.PackTypes.Remove(packType);
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
