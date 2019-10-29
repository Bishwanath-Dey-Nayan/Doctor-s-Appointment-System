using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAS.Controllers
{
    public class ChamberController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        // GET: Chamber
        public ActionResult AddChamber()
        {
            ViewBag.HospitalID = new SelectList(db.Hospitals, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddChamber(DAS.Models.ViewModel.ChamberVM cv)
        {
            var userEmail = Session["UserEmail"];
            var data = db.Doctors.Where(d => d.Email == userEmail).FirstOrDefault();
            if (ModelState.IsValid)
            {
                Chamber c = new Chamber()
                {
                    Name= cv.Name,
                    HospitalID = cv.HospitalID,
                    DoctorID = data.ID,
                    DoctorName = data.Name
                };
                db.Chambers.Add(c);
                db.SaveChanges();
                return RedirectToAction("ShowDoctor", "Home");
            }
            ViewBag.HospitalID = new SelectList(db.Hospitals, "ID", "Name");
            return View(cv);
        }

        public ActionResult Index()
        {
            var userEmail = Session["UserEmail"];
            var data = db.Doctors.Where(d => d.Email == userEmail).FirstOrDefault();
            var chamberList = db.Chambers.Where(x => x.DoctorID == data.ID).ToList();
            return View(chamberList);
        }
    }
}