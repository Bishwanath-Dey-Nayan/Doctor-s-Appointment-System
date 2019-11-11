using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAS.Controllers
{
    public class TransactionController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        // GET: Transaction
        public ActionResult PendingTransaction()
        {
            var TransactionData = (from a in db.Appointments
                                   join t in db.TransactionDetails on a.ID equals t.AppointmentId
                                   where t.isconfirmed == false
                                   select new DAS.Models.ViewModel.TransactionVM
                                   {

                                        P_Name = a.P_Name,
                                        Mobile = a.Mobile,
                                        Email = a.Email,
                                        Prev_visit = t.isconfirmed,
                                        AppointmentId = a.ID,
                                        BkashMobileNo = t.MobileNo,
                                        TransactionID = t.Id.ToString(),
                                        Transactioncode = t.TransactionID,
                                        date = t.date,
                                        DoctorID = a.DoctorID,
                                        ChamberID = a.ChamberID,
                                        DoctorName = a.Doctor.Name,
                                        SechduleId = a.SechduleId

                                   }
                                   ).ToList();
            return View(TransactionData);
        }

        public ActionResult ConfirmedTransaction()
        {
            var TransactionData = (from a in db.Appointments
                                   join t in db.TransactionDetails on a.ID equals t.AppointmentId
                                   where t.isconfirmed == true
                                   select new DAS.Models.ViewModel.TransactionVM
                                   {

                                       P_Name = a.P_Name,
                                       Mobile = a.Mobile,
                                       Email = a.Email,
                                       Prev_visit = t.isconfirmed,
                                       AppointmentId = a.ID,
                                       BkashMobileNo = t.MobileNo,
                                       TransactionID = t.Id.ToString(),
                                       Transactioncode = t.TransactionID,
                                       date = t.date,
                                       DoctorID = a.DoctorID,
                                       ChamberID = a.ChamberID,
                                       DoctorName = a.Doctor.Name,
                                       SechduleId = a.SechduleId

                                   }
                                ).ToList();
            return View(TransactionData);
        }
    }
}