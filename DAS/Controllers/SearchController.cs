using DAS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAS.Controllers
{
    public class SearchController : Controller
    {
        DataBaseContext db = new DataBaseContext();
        // GET: Search
        public ActionResult DoctorList()
        {
            var data = (from d in db.Doctors join c in db.Chambers on d.ID equals c.DoctorID join s in db.Schedules on c.ID equals s.ChamberID
                       join h in db.Hospitals on c.HospitalID equals h.Id
                       select new DoctorList()
                       {
                           DoctorName = d.Name,
                           DoctorDesignation = d.Designation,
                           DoctorSpec= d.speciality.Name,
                           HospitalName=h.Name,
                           ChamberCity = h.City.Name,
                           ChamberArea = h.Area.Name,
                           Fee = s.FirstAppointmentFee,
                       }).ToList();
            return View(data);
        }

    }
}