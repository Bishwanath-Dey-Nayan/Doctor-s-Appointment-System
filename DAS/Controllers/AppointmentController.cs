using DAS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAS.Controllers
{
    public class AppointmentController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        // GET: Appointment
        public ActionResult BookAppointment(int? id)
        {
            if (id != null)
            {
                ScheduleDetails sd = new ScheduleDetails();
                var ScheduleData = db.Schedules.Where(s => s.ID == id).FirstOrDefault();
                var DoctorData = db.Doctors.Where(d => d.ID == ScheduleData.DoctorID).FirstOrDefault();
                sd.schedule = ScheduleData;
                sd.doctor = DoctorData;
                return View(sd);
            }
            return View();
        }
        public ActionResult ConfirmAppointment(int DoctorId,int ChamberId,int ScheduleId)
        {
            AppointmentProperty ap = new AppointmentProperty();
            ap.DoctorId = DoctorId;
            ap.ChamberId = ChamberId;
            ap.ScheduleId = ScheduleId;
            TempData["AppointmentCredential"] = ap;
            return View();
        }

        public ActionResult paymentForm()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult paymentForm(PaymentConfirmationVM pc)
        {
            var Data = TempData["AppointmentCredential"] as AppointmentProperty;
            if (ModelState.IsValid)
            {
                Appointment ap = new Appointment()
                {
                    P_Name = pc.Name,
                    Age = pc.Age.ToString(),
                    Mobile = pc.MobileNo,
                    Prev_visit = pc.Pre_visited,
                    DoctorID = Data.DoctorId,
                    ChamberID = Data.ChamberId,
                    SechduleId = Data.ScheduleId

                };
            }
            return View();
        }


    }


    public class AppointmentProperty
    {
        public int DoctorId { get; set; }
        public int ChamberId { get; set; }
        public int ScheduleId { get; set; }
    }
}