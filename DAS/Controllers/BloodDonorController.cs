using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Models.ViewModel;

namespace DAS.Controllers
{
    public class BloodDonorController : Controller
    {
        private DataBaseContext db = new DataBaseContext();


        public ActionResult HomePage()
        {
            return View();
        }
        // GET: BloodDonor
        public ActionResult Registration()
        {
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "Id", "Name");
            ViewBag.CityId = new SelectList(db.Cities, "ID", "Name");
            ViewBag.AreaId = new SelectList(db.Areas, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(BloodDonorRegistration br)
        {
            if (ModelState.IsValid)
            {
                DAS.Models.BloodDonor bd = new Models.BloodDonor()
                {
                    Name = br.Name,
                    MobileNo = br.MobileNo,
                    Email = br.Email,
                    Gender = br.Gender,
                    BloodGroupId = br.BloodGroupId,
                    cityId = br.CityId,
                    AreaId = br.AreaId,
                    AdditionalAddress = br.AdditionalAddress,
                    isRequested = false,
                    isConfirmed =false,
                    LastBloodDonateTime = br.LastBloodDonateTime
                };
                db.BloodDonors.Add(bd);
                DAS.Models.Login l = new Models.Login();
                l.Email = br.Email;
                l.Password = br.Password;
                l.Role = "BD";
                db.Logins.Add(l);
                db.SaveChanges();
                return RedirectToAction("HomePage");

            }
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "Id", "Name");
            ViewBag.CityId = new SelectList(db.Cities, "ID", "Name");
            ViewBag.AreaId = new SelectList(db.Areas, "ID", "Name");
            return View(br);
        }
    }
}