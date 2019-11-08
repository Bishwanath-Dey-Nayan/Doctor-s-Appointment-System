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
    }
}