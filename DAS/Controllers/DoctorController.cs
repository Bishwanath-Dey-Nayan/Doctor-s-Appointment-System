using DAS.Models.ViewModel;
using Microsoft.Ajax.Utilities;
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
                ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name");
                return View();


            }
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name");
            return View();

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

        public ActionResult DoctorByHospital(int? HospitalId)
        {
           
            if(HospitalId!=null)
            {
                var data = (from d in db.Doctors
                            join c in db.Chambers on d.ID equals c.DoctorID
                            join s in db.Schedules on c.ID equals s.ChamberID
                            join h in db.Hospitals on c.HospitalID equals h.Id
                            select new DoctorList()
                            {
                                DoctorId = d.ID,
                                DoctorName = d.Name,
                                DoctorDesignation = d.Designation,
                                DoctorSpec = d.speciality.Name,
                                HospitalName = h.Name,
                                ChamberCity = h.City.Name,
                                ChamberArea = h.Area.Name,
                                Fee = s.FirstAppointmentFee,
                                HospitalId = h.Id
                            }).ToList();
                var filterData = data.Where(d => d.HospitalId == HospitalId).DistinctBy(x => x.DoctorId).ToList();
                //var filterData = filterData1.Distinct();
                TempData["filteredData"] = filterData;
                return RedirectToAction("DoctorFilterResult");
            }
            return View();
        }

        public ActionResult DoctorFilterResult()
        {
            var dc = TempData["filteredData"] as List<DoctorList>;
            ViewBag.Speciality = db.Specialities.ToList();
            return View(dc);
        }

        public ActionResult Index1()
        {
            return View(db.Doctors.ToList());
        }

        public ActionResult AppointmentList1()
        { 
            var DoctorEmail = Session["UserEmail"];
            var docdata = db.Doctors.Where(x => x.Email == DoctorEmail).FirstOrDefault();
            var data = (from a in db.Appointments 
                        join s in db.Schedules on a.SechduleId equals s.ID
                        where a.DoctorID == docdata.ID
                        select new AppointmentListVMDoctor()
                        {
                            ChamberId = a.ChamberID,
                            ChamberName = a.Chamber.Name,
                            PaitentName = a.P_Name,
                            Age=a.Age,
                            Mobile = a.Mobile,
                            Email = a.Email,
                            pre_visit = a.Prev_visit,
                            AppointmentDate=s.AppointmentDate,
                        }
                        ).ToList();
            return View(data);
        }

    }
}