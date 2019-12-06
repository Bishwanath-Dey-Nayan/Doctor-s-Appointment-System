using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class AppointmentListVMDoctor
    {
        public int ChamberId { get; set; }
        public string ChamberName { get; set; }
        public string PaitentName { get; set; }
        public string Age { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool pre_visit { get; set; }
        public DateTime? AppointmentDate { get; set; }

    }
}