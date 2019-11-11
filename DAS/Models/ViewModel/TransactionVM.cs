using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class TransactionVM
    {
        public int AppointmentId { get; set; }
        public string Mobile { get; set; }
        public string TransactionID { get; set; }
        public bool isconfirmed { get; set; }
        public DateTime date { get; set; }
        public string P_Name { get; set; }
        public string Age { get; set; }
        public string BkashMobileNo { get; set; }
        public string Email { get; set; }
        public bool Prev_visit { get; set; }
        public int DoctorID { get; set; }
        public int ChamberID { get; set; }
        public int SechduleId { get; set; }
        public string DoctorName { get; set; }
        public string Transactioncode { get; set; }
    }
}