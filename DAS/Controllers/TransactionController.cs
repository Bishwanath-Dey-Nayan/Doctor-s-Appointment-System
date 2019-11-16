using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public ActionResult Confirm(int? transId)
        {
            var data = db.TransactionDetails.Where(t => t.Id == transId).SingleOrDefault();
            data.isconfirmed = true;
            var EmailData = db.Appointments.Where(a => a.ID == data.AppointmentId).SingleOrDefault();
            SendverificationLinkEmail(EmailData.Email);
            db.SaveChanges();
            return View("ConfirmedTransaction");
        }

        [NonAction]
        public void SendverificationLinkEmail(string emailID)
        {
            var fromEmail = new MailAddress("bishwanathdeynayan@gmail.com", "Doctors Point");
            var toEmail = new MailAddress(emailID);
            var fromPassword = "n01682616787a";

            string subject = "";
            string body = "";
                subject = "Transaction confirmation Mail";
                body = "<br/><br/>We are here  to tell you that the transaction that you made today is successfull";
         
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromPassword),
                
            };
            using (var Message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            }
            )
                smtp.Send(Message);

        }
    }
}