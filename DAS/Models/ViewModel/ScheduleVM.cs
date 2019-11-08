using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class ScheduleVM
    {
        [Required]
        [Display(Name = "Chamber")]
        public int ChamberID { get; set; }

        [Required]
        [Display(Name ="Appointment Date")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [Display(Name = "Starts From")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Ends At")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = "First Appointment Fee(in Tk)")]
        public double FirstAppointmentFee { get; set; }

        [Required]
        [Display(Name = "Next Meeting Fee")]
        public string NextMeetingFee { get; set; }

        public List<string> days { get; set; }
    }
}