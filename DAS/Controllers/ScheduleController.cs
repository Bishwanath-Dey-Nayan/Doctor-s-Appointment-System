using DAS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAS.Controllers
{
    public class ScheduleController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        // GET: Schedule


        public ActionResult Index()
        {
            var DoctorEmail = Session["UserEmail"];
            var data = db.Doctors.Where(x => x.Email == DoctorEmail).FirstOrDefault();
            var ScheduleList = db.Schedules.Where(x => x.DoctorID == data.ID).ToList();
            return View(ScheduleList);
        }


        public ActionResult CreateSchedule()
        {
            var DoctorEmail = Session["UserEmail"];
            var data = db.Doctors.Where(x => x.Email == DoctorEmail).FirstOrDefault();
            var FilterChamber = db.Chambers.Where(x => x.DoctorID == data.ID).ToList();
            ViewBag.ChamberId = new SelectList(FilterChamber, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult CreateSchedule(ScheduleVM model)
        {

            double minutes = model.EndTime.Subtract(model.StartTime).TotalMinutes;
            int slots = (int)(minutes / 10);
            var DoctorEmail = Session["UserEmail"];
            var data = db.Doctors.Where(x => x.Email == DoctorEmail).FirstOrDefault();
            if (ModelState.IsValid)
            {
                Schedule s = new Schedule()
                {
                    DoctorID = data.ID,
                    ChamberID = model.ChamberID,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    FirstAppointmentFee = model.FirstAppointmentFee,
                    NextMeetingFee = model.NextMeetingFee,
                    SlotNo = slots,
                    AppointmentDate=model.AppointmentDate.Date
                };
                db.Schedules.Add(s);
                db.SaveChanges();

                for(int i=0;i<model.days.Count;i++)
                {
                    DAS.Models.ScheduleDayRel sd = new Models.ScheduleDayRel()
                    {
                        ScheduleId = s.ID,
                        DayName = model.days[i]
                    };
                    db.ScheduleDayRels.Add(sd);
                    db.SaveChanges();
                }

                //return Json(0,JsonRequestBehavior.AllowGet);
                return Json(Url.Action("Index", "Schedule"));
                
                

            }
            ViewBag.ChamberId = new SelectList(db.Chambers, "Id", "Name");
            return View(model);
        }

      
    }
}