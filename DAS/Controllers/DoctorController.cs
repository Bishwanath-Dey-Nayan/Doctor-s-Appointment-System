using DAS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAS.Controllers
{
    public class DoctorController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        // GET: Doctor
        public ActionResult Registration()
        {
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name");
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(DoctorRegistration dr)
        {
            if (ModelState.IsValid)
            {
                DAS.Doctor d = new Doctor()
                {
                    Name = dr.Name,
                    Designation = dr.Designation,
                    SpecialityId = dr.SpecialityId,
                    Gender = dr.Gender,
                    MobileNo = dr.MobileNo,
                    Email = dr.Email,
                    BMDCNo = dr.BMDCNo,
                    Description= dr.Description,
                    Degree_Spec = dr.Description

                };
                db.Doctors.Add(d);

                DAS.Models.Login l = new Models.Login();
                l.Email = dr.Email;
                l.Password = dr.Password;
                l.Role = "D";

                db.Logins.Add(l);

                db.SaveChanges();
                return RedirectToAction("Index");


            }
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name");
            return View(dr);

        }


        public ActionResult PaitentHistory()
        {
            ViewBag.ChamberId = new SelectList(db.Chambers, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaitentHistory(PaitentHistory ph)
        {
            var DoctorEmail = Session["UserEmail"];
            var data = db.Doctors.Where(x => x.Email == DoctorEmail).FirstOrDefault();
            if(ModelState.IsValid)
            {
                PaitentHistory PH = new PaitentHistory()
                {
                    DoctorID = data.ID,
                    ChamberID = ph.ChamberID,
                    Name = ph.Name,
                    Age = ph.Age,
                    Address = ph.Address,
                    ProblemSpec = ph.ProblemSpec,
                    Description = ph.Description,
                    MettingDate = System.DateTime.Now,
                    NextMeet = ph.NextMeet,

                };
                db.PaitentHistorys.Add(PH);
                db.SaveChanges();
                return RedirectToAction("ShowDoctor", "Home");
            }
            ViewBag.ChamberId = new SelectList(db.Chambers, "Id", "Name");
            return View(ph);
        }


       
    }
}