using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Models.ViewModel;

namespace DAS.Controllers
{
    public class HospitalController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        // GET: Hospital
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "ID", "Name");
            ViewBag.AreaId = new SelectList(db.Areas, "ID", "Name");
            ViewBag.HospitalTypeId = new SelectList(db.HospitalTypes, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HospitalVM hvm)
        {
            if(ModelState.IsValid)
            {
                DAS.Models.Hospital h = new Models.Hospital()
                {
                    Name=hvm.Name,
                    CityId = hvm.CityId,
                    AreaId = hvm.AreaId,
                    HospitalTypeId = hvm.HospitalTypeId,
                    AdditionalAddress = hvm.AdditionalAddress
                };
                db.Hospitals.Add(h);
                db.SaveChanges();
                return RedirectToAction("ShowAdmin","Home");
            }
            return View(hvm);
        }
    }
}