using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models
{
    public class TransactionDetails
    {
        [Key]
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string MobileNo { get; set; }
        public string TransactionID { get; set; }
        public bool isconfirmed { get; set; }
        public DateTime date { get; set; }
       
    }
}