using DAS.Models.ViewModel;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAS.Controllers
{

    public class HomeController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        public ActionResult Index()
        {

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            return View(); 
        }

        public JsonResult Getddl_Data(string filterdata)
        {
            Object data = null; 
            if(filterdata == "Doctor")
            {
                data = db.Specialities.ToList();
            }
            if(filterdata == "Blood Donor")
            {
                data = db.BloodGroups.ToList();
            }
            if(filterdata == "Hospital")
            {
                data = db.HospitalTypes.ToList();
            }
            return Json(data);
        }

        [HttpPost]
        public ActionResult SearchParam(DAS.Models.ViewModel.SearchParam sp)
        {
            if (sp != null)
            {
                Object filterData = null;
                var cityName = GetCityName(sp.CityId);
                

                var data = (from d in db.Doctors
                            join c in db.Chambers on d.ID equals c.DoctorID
                            join s in db.Schedules on c.ID equals s.ChamberID
                            join h in db.Hospitals on c.HospitalID equals h.Id
                            select new DoctorList()
                            {
                                DoctorId=d.ID,
                                DoctorName = d.Name,
                                DoctorDesignation = d.Designation,
                                DoctorSpec = d.speciality.Name,
                                HospitalName = h.Name,
                                ChamberCity = h.City.Name,
                                ChamberArea = h.Area.Name,
                                Fee = s.FirstAppointmentFee,
                            }).ToList();
                if (sp.SearchType == "Doctor")
                {
                    var SpecilityName = GetDoctorSpec(sp.SpecialityId);
                    filterData = data.Where(d => d.ChamberCity == cityName && d.DoctorSpec == SpecilityName).DistinctBy(x => x.DoctorId).ToList();
                    TempData["filteredData"] = filterData;
                    return RedirectToAction("DoctorFilterResult");

                }
                if (sp.SearchType == "Blood Donor")
                {
                    //filterData = db.BloodDonors.Where(b => b.cityId == sp.CityId && b.BloodGroupId == sp.SpecialityId).ToList();
                    filterData = (from b in db.BloodDonors
                                  where b.cityId == sp.CityId
                                  && b.BloodGroupId == sp.SpecialityId
                                  select new BloodDonorList()
                                  {
                                      Name = b.Name,
                                      BloodGroup=b.BloodGroup.Name,
                                      MobileNo = b.MobileNo,
                                      Area = b.Area.Name,
                                      Address = b.AdditionalAddress
                                  }
                                  ).ToList();
                    TempData["filterBloodData"] = filterData;
                    return RedirectToAction("BloodDonorFilterResult",filterData);
                }
                if(sp.SearchType == "Hospital")
                {
                    filterData = (from h in db.Hospitals
                                  where h.HospitalTypeId == sp.SpecialityId &&
                                  h.CityId == sp.CityId
                                  select h
                                  ).ToList();
                    TempData["filterHospitalData"] = filterData;
                    return RedirectToAction("HospitalFilterResult");
                }
            }
             return View();
            
        }


        public ActionResult DoctorFilterResult()
        {
            var dc = TempData["filteredData"] as List<DoctorList>;
            return View(dc);
        }

        public ActionResult BloodDonorFilterResult()
        {
            var bd = TempData["filterBloodData"] as List<BloodDonorList>;
            return View(bd);
        }
        public ActionResult HospitalFilterResult()
        {
            var h = TempData["filterHospitalData"];
            return View(h);
        }

        public ActionResult ShowAdmin()
        {
            return View();
        }

        public ActionResult ShowDoctor()
        {
            return View();
        }

        [NonAction]
        public string GetCityName(int cityId)
        {
            string CityName ="";
            var data = db.Cities.Where(c => c.ID == cityId).FirstOrDefault();
            CityName = data.Name;
            return CityName;
        }

        [NonAction]
        public string GetDoctorSpec(int id)
        {
            string SpecName = "";
            var data = db.Specialities.Where(s => s.Id == id).FirstOrDefault();
            SpecName = data.Name;
            return SpecName;
        }

        public ActionResult ViewDoctorProfile(int? Id)
        {
            DoctorProfileVM dpv = new DoctorProfileVM();
            if(Id != null)
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
                                Gender = d.Gender
                            });
                var Docor = data.Where(d => d.DoctorId == Id).FirstOrDefault();
                dpv.DoctorList = Docor;


                var Schedule = db.Schedules.Where(s => s.DoctorID == Id).ToList();   
                dpv.Schedules = Schedule;

                return View(dpv);

            }
            return View();
        }
        public ActionResult PackageIndex()
        {
            return View(db.Packages.ToList());
        }
    }
}